using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Text;


namespace MLClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string PredictionResult;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void predictLB_Click1(object sender, EventArgs e)
        {
            string results;
            int number = 0;
            if (txtUserId.Text == "" || (int.TryParse(txtUserId.Text, out number)) == false || Convert.ToInt32(txtUserId.Text) > 50000) 
            {
                results = "Only numeric values between 0 and 50000";
            }
            else
            {
                var client = new RestClient("https://ussouthcentral.services.azureml.net/workspaces/2ac5a4fe2ef5413a90509bb7b3e1d333/services/2d32880fd88f4554a81e6dbf7ff10d7a/execute?api-version=2.0&details=true");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer NSMFkiaPZOkp/QN8ik0F8WT2gR0jR3sYUUiXr5nZ0qLj6GAmqBzKsAXHVTB/NoLos9dIUiEN41XyZzqhmRM4nw==");
                request.AddHeader("Content-Type", "application/json");
                var body = @"{" + "\n" + @"  ""Inputs"": {" + "\n" + @"    ""input1"": {" + "\n" + @"      ""ColumnNames"": [" + "\n" + @"        ""UserId"", " + "\n" + @"        ""Movie Name"", " + "\n" + @"        ""Rating"" " + "\n" + @"      ]," + "\n" +
                @"      ""Values"": [" + "\n" + @"        [" + "\n" + @"          " + txtUserId.Text + ", " + "\n" + @"          ""value"", " + "\n" + @"          ""0"" " + "\n" + @"        ], " + "\n" + @"        [" + "\n" + @"          ""0"", " + "\n" +
                @"          ""value""," + "\n" + @"          ""0"" " + "\n" + @"        ]" + "\n" + @"      ]" + "\n" + @"    }" + "\n" + @"  }, " + "\n" + @"  ""GlobalParameters"": {}" + "\n" + @"}";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                results = convertToTable(response.Content.ToString());
            }
            lblResults.Text = results;
        }

        private string convertToTable (string suggestions)
        {
            StringBuilder sb = new StringBuilder();

            dynamic DynamicData = JObject.Parse(suggestions);

            sb.Append("<h3>Recommendations for User: " + DynamicData.Results.output1.value.Values[0][0] + "</h3><br />");
            sb.Append("<table><th>Title</th>");
            sb.Append("<tr><td>" + DynamicData.Results.output1.value.Values[0][1] + "</td></tr>");
            sb.Append("<tr><td>" + DynamicData.Results.output1.value.Values[0][2] + "</td></tr>");
            sb.Append("<tr><td>" + DynamicData.Results.output1.value.Values[0][3] + "</td></tr>");
            sb.Append("<tr><td>" + DynamicData.Results.output1.value.Values[0][4] + "</td></tr>");
            sb.Append("<tr><td>" + DynamicData.Results.output1.value.Values[0][5] + "</td></tr>");

            return sb.ToString();
        }
    }
}