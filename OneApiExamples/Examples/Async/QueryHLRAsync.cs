using System;
using System.IO;
using log4net.Config;
using OneApi.Client.Impl;
using OneApi.Config;

namespace OneApi.Examples.Async
{

    /**
     * To run this example follow these 4 steps:
     *
     *  1.) Download 'Infobip C# library' - available at www.github.com/infobip   
     *
     *  2.) Open 'OneApi.sln' in 'Visual Studio 2010' and locate 'OneApiExamples' project 
     * 
     *  3.) Open 'Examples.QueryHLRAsync' class to edit where you should populate the following fields:  
     *		'address'   
     *
     *  4.) Run the 'OneApiExample' project, where an a example list with ordered numbers will be displayed in the console. 
     *      There you will enter the appropriate example number in the console and press 'Enter' key 
     *      on which the result will be displayed in the Console.
     **/

    public class QueryHLRAsync
    {
        private static string address = "";

        public static void Execute()
        {
            // Configure in the 'app.config' which Logger levels are enabled(all levels are enabled in the example)
            // Check http://logging.apache.org/log4net/release/manual/configuration.html for more informations about the log4net configuration
            XmlConfigurator.Configure(new FileInfo("OneApiExamples.exe.config"));


            // Initialize Configuration object 
            Configuration configuration = new Configuration(System.Configuration.ConfigurationManager.AppSettings.Get("Username"),
                                                            System.Configuration.ConfigurationManager.AppSettings.Get("Password"));

            // Initialize SMSClient using the Configuration object
            SMSClient smsClient = new SMSClient(configuration);

            smsClient.HlrClient.QueryHLRAsync(address, (roaming, e) =>
            {
                if (e == null)
                {
                    Console.WriteLine(roaming);
                }
                else
                {
                    Console.WriteLine(e.Message);
                }
            });

        }
    }
}