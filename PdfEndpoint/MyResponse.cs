using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace PdfEndpoint; 

public class MyResponse {
    public int code { get; set; }
    public string mimeType { get; set; }
    public byte[] pdf { get; set; }
}