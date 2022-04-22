using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HTTPServer
{

    public enum StatusCode
    {
        OK = 200,
        InternalServerError = 500,
        NotFound = 404,
        BadRequest = 400,
        Redirect = 301
    }

    class Response
    {
        string responseString;
        public string ResponseString
        {
            get
            {
                return responseString;
            }
        }
        StatusCode code;
        List<string> headerLines = new List<string>();
        public Response(StatusCode code, string contentType, string content, string redirectoinPath)
        {
            //throw new NotImplementedException();
            // TODO: Add headlines (Content-Type, Content-Length,Date, [location if there is redirection])
            this.code = code;

            string returned_status_line = GetStatusLine(code);
            string status_line =  returned_status_line;
            string returned_contentType = "Content-Type: " + contentType +"\r\n";
            string content_Length = "Content-Length: " + content.Length + "\r\n";
            string date = "Date: " + DateTime.Now + "\r\n";

            headerLines.Add(returned_contentType);
            headerLines.Add(content_Length);
            headerLines.Add(date);
            


            // TODO: Create the request string
            if (code == StatusCode.Redirect)
            {
                string location = "Location: " + redirectoinPath + "\r\n";
                headerLines.Add(location);

            }
           

            responseString = status_line;
            for (int i = 0; i < headerLines.Count; i++)
            {
                responseString += headerLines[i];
            }
            responseString += "\r\n";
            responseString += content;

        }

        private string GetStatusLine(StatusCode code)
        {
            // TODO: Create the response status line and return it
            string statusLine = string.Empty;

             statusLine = "HTTP/1.1 " + ((int)code).ToString() + " " +  code.ToString() + "\r\n";

            return statusLine;
        }
    }
}
