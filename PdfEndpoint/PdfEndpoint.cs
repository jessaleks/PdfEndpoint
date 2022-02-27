using System.IO;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf;
using iText;
using iText.Kernel.Font;
using iText.Layout;
using iText.Layout.Element;
using static iText.Kernel.Geom.PageSize;

namespace PdfEndpoint;

public class PdfEndpoint : Endpoint<MyRequest> {
    
    public override async Task HandleAsync(MyRequest req, CancellationToken ct) {

         await using (MemoryStream stream = new MemoryStream()) {
             PdfWriter writer = new PdfWriter(stream);
             PdfDocument pdf = new PdfDocument(writer);
             Document doc = new Document(pdf);

             var font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
             doc.SetFont(font);
             doc.Add(new Paragraph("123"));

             List list = new List()
                 .SetSymbolIndent(12)
                 .SetListSymbol("u2022")
                 .SetFont(font);
             // Add ListItem objects
             list.Add(new ListItem("Never gonna give you up"))
                 .Add(new ListItem("Never gonna let you down"))
                 .Add(new ListItem("Never gonna run around and desert you"))
                 .Add(new ListItem("Never gonna make you cry"))
                 .Add(new ListItem("Never gonna say goodbye"))
                 .Add(new ListItem("Never gonna tell a lie and hurt you"));
             // Add the list
             doc.Add(list);

             // create a sample pdf with iText



             await SendBytesAsync(stream.GetBuffer(), contentType: "application/pdf",
                 cancellation: new CancellationToken());
         }
        
    }

    public override void Configure() {
        Verbs(Http.POST);
        Routes("/api/pdf");
        AllowAnonymous();
    }
}