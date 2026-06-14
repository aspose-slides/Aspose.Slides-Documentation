---
title: Lấy tất cả các siêu liên kết bên ngoài trong một bản trình chiếu
type: docs
weight: 90
url: /vi/net/get-all-the-external-hyperlinks-in-a-presentation/
---
## **OpenXML Presentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

foreach (string s in GetAllExternalHyperlinksInPresentation(FileName))

Console.WriteLine(s);

// Trả về tất cả các siêu liên kết bên ngoài trong các slide của bản trình chiếu.

public static IEnumerable<String> GetAllExternalHyperlinksInPresentation(string fileName)

{

// Khai báo một danh sách các chuỗi.

List<string> ret = new List<string>();

// Mở tệp bản trình chiếu ở chế độ chỉ đọc.

using (PresentationDocument document = PresentationDocument.Open(fileName, false))

{

    // Duyệt qua tất cả các phần slide trong phần bản trình chiếu.

    foreach (SlidePart slidePart in document.PresentationPart.SlideParts)

    {

        IEnumerable<Drawing.HyperlinkType> links = slidePart.Slide.Descendants<Drawing.HyperlinkType>();

        // Duyệt qua tất cả các liên kết trong phần slide.

        foreach (Drawing.HyperlinkType link in links)

        {

            // Duyệt qua tất cả các quan hệ bên ngoài trong phần slide. 

            foreach (HyperlinkRelationship relation in slidePart.HyperlinkRelationships)

            {

                // Nếu ID quan hệ khớp với ID liên kết...

                if (relation.Id.Equals(link.Id))

                {

                    // Thêm URI của quan hệ bên ngoài vào danh sách các chuỗi.

                    ret.Add(relation.Uri.AbsoluteUri);

                }

            }

        }

    }

}

// Trả về danh sách các chuỗi.

return ret;

}
``` 
## **Aspose.Slides**
Aspose.Slides for .NET cho phép các nhà phát triển quản lý các siêu liên kết trong bản trình chiếu ở mức độ bản trình chiếu, slide và khung văn bản. Lớp **IHyperlinkQueries** giúp quản lý các siêu liên kết trong một bản trình chiếu.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the External Eyperlinks.pptx";

//Khởi tạo một đối tượng Presentation đại diện cho tệp PPTX

Presentation pres = new Presentation(FileName);

//Lấy các siêu liên kết từ bản trình chiếu

IList<IHyperlinkContainer> links = pres.HyperlinkQueries.GetAnyHyperlinks();

foreach (IHyperlinkContainer link in links)

    Console.WriteLine(link.HyperlinkClick.ExternalUrl);
``` 
## **Download Running Code Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Get%20all%20the%20External%20Hyperlinks)