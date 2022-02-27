namespace PdfEndpoint; 

public class MyRequest {
    public MyRequest() {
    }

    public MyRequest(string name, string lastName) {
        this.name = name ?? throw new ArgumentNullException(nameof(name));
        this.lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
    }

    public string name { get; set; }
    public string lastName { get; set; }
}