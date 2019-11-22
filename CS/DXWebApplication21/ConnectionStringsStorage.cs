using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Json;
using DevExpress.DataAccess.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace DXWebApplication21 {
    public class ConnectionStringsStorage : IDataSourceWizardConnectionStringsStorage {
        static Dictionary<string, DataConnectionParametersBase> storage;
        string connectionString;
        static Dictionary<string, DataConnectionParametersBase> Storage {
            get {
                if (storage == null)
                    storage = new Dictionary<string, DataConnectionParametersBase>();
                return storage;
            }
        }
        public ConnectionStringsStorage(string connectionString) {
            storage = CreateNewStorage();
            this.connectionString = connectionString;
        }

        Dictionary<string, DataConnectionParametersBase> CreateNewStorage() {
            var dictionary = new Dictionary<string, DataConnectionParametersBase>();

            // Load existing SQL Connection Strings from Web.config
            foreach (ConnectionStringSettings connectionStringSettings in ConfigurationManager.ConnectionStrings)
                dictionary.Add(connectionStringSettings.Name, new CustomStringConnectionParameters(connectionStringSettings.ConnectionString));

            // Add predefined JSON connections
            var jsonConnectionParams = new JsonSourceConnectionParameters();
            jsonConnectionParams.JsonSource = new UriJsonSource(new Uri("https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/customers.json"));
            dictionary.Add("Customers_JSON", jsonConnectionParams);

            // Load JSON connections from a DB
            using (JsonConnectionContext context = new JsonConnectionContext()) {
                context.Connections.ToList().ForEach(c => {
                    if (!dictionary.ContainsKey(c.Name))
                        dictionary.Add(c.Name, new CustomStringConnectionParameters(c.ConnectionString));
                    else
                        dictionary[c.Name] = new CustomStringConnectionParameters(c.ConnectionString);
                });
            }

            return dictionary;
        }

        Dictionary<string, string> IDataSourceWizardConnectionStringsProvider.GetConnectionDescriptions() {
            return Storage.Keys.ToDictionary(key => key, value => value);
        }

        DataConnectionParametersBase IDataSourceWizardConnectionStringsProvider.GetDataConnectionParameters(string name) {
            return Storage[name];
        }

        // Save JSON connections to a DB
        void IDataSourceWizardConnectionStringsStorage.SaveDataConnectionParameters(string name, DataConnectionParametersBase connectionParameters, bool saveCredentials) {
            JsonSourceConnectionParameters jsonParams = connectionParameters as JsonSourceConnectionParameters;
            if (jsonParams != null) {
                using (JsonConnectionContext context = new JsonConnectionContext()) {
                    JsonDataConnection dataConnection = new JsonDataConnection(jsonParams.JsonSource);

                    var existingConnection = context.Connections.Where(c => c.Name == name).FirstOrDefault();
                    if (existingConnection == null) {
                        MyJsonConnection jsonConnection = new MyJsonConnection();
                        jsonConnection.Name = name;
                        jsonConnection.ConnectionString = dataConnection.CreateConnectionString();
                        context.Connections.Add(jsonConnection);
                    } else {
                        existingConnection.ConnectionString = dataConnection.CreateConnectionString();
                    }
                    context.SaveChanges();
                }

                Storage[name] = new CustomStringConnectionParameters(connectionString);
            }
        }
    }
}