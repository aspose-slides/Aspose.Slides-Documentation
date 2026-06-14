---
title: Di chuyển một đoạn văn từ một bản trình bày sang bản trình bày khác
type: docs
weight: 130
url: /vi/net/move-a-paragraph-from-one-presentation-to-another/
---
## **Bản trình bày OpenXML**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// Di chuyển một dải đoạn văn trong hình dạng TextBody trong tài liệu nguồn
// tới một hình dạng TextBody khác trong tài liệu đích.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// Mở tệp nguồn để đọc/ghi.
using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))
{

    // Mở tệp đích để đọc/ghi.
    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))
    {

        // Lấy slide đầu tiên trong bản trình bày nguồn.
        SlidePart slide1 = GetFirstSlide(sourceDoc);
        // Lấy hình dạng TextBody đầu tiên trong nó.
        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();
        // Lấy đoạn văn đầu tiên trong hình dạng TextBody.
        // Lưu ý: "Drawing" là bí danh của không gian tên DocumentFormat.OpenXml.Drawing
        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();
        // Lấy slide đầu tiên trong bản trình bày đích.
        SlidePart slide2 = GetFirstSlide(targetDoc);
        // Lấy hình dạng TextBody đầu tiên trong nó.
        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();
        // Sao chép đoạn văn nguồn và chèn đoạn đã sao chép vào hình dạng TextBody đích.
        // Truyền "true" tạo một bản sao sâu, tạo một bản sao của 
        // đối tượng Paragraph và mọi thứ được tham chiếu trực tiếp hoặc gián tiếp bởi đối tượng đó.
        textBody2.Append(p1.CloneNode(true));
        // Xóa đoạn văn nguồn khỏi tệp nguồn.
        textBody1.RemoveChild<Drawing.Paragraph>(p1);
        // Thay thế đoạn đã xóa bằng một trình giữ chỗ.
        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());
        // Lưu slide trong tệp nguồn.
        slide1.Slide.Save();
        // Lưu slide trong tệp đích.
        slide2.Slide.Save();
    }
}
}

// Lấy phần slide của slide đầu tiên trong tài liệu bản trình bày.
public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)
{

// Lấy ID quan hệ của slide đầu tiên
PresentationPart part = presentationDocument.PresentationPart;
SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();
string relId = slideId.RelationshipId;

// Lấy phần slide bằng ID quan hệ.
SlidePart slidePart = (SlidePart)part.GetPartById(relId);
return slidePart;

}
``` 
## **Aspose.Slides**
Không hiếm khi các nhà phát triển cần trích xuất văn bản từ một bản trình bày. Để làm điều đó, bạn phải trích xuất văn bản từ tất cả các hình dạng trên tất cả các slide trong một bản trình bày. Bài viết này giải thích cách trích xuất văn bản từ các bản trình bày Microsoft PowerPoint PPTX bằng cách sử dụng Aspose.Slides. Cho dù trích xuất văn bản từ một slide duy nhất hay toàn bộ bản trình bày, Aspose.Slides sử dụng lớp PresentationScanner và các phương thức tĩnh mà nó cung cấp. Tất cả đều được đóng gói dưới không gian tên [Aspose.Slides.Util](https://reference.aspose.com/slides/vi/net/aspose.slides.util/slideutil).

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// Di chuyển một dải đoạn văn trong hình dạng TextBody trong tài liệu nguồn

// đến một hình dạng TextBody khác trong tài liệu đích.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //Khởi tạo lớp Presentation đại diện cho PPTX//Khởi tạo lớp Presentation đại diện cho PPTX

    Presentation sourcePres = new Presentation(sourceFile);

    //Truy cập hình dạng đầu tiên trong slide đầu tiên

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //Lấy văn bản từ trình giữ chỗ

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //Truy cập hình dạng đầu tiên trong slide đầu tiên

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //Lấy văn bản từ trình giữ chỗ

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
``` 
## **Tải ví dụ chạy**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)