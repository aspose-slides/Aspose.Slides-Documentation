---
title: Lấy tất cả văn bản trong một slide
type: docs
weight: 110
url: /vi/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Lấy tất cả văn bản trong một slide.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // Mở bản thuyết trình ở chế độ chỉ đọc.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Truyền bản thuyết trình và chỉ số slide

        // tới phương thức GetAllTextInSlide tiếp theo, và

        // sau đó trả về mảng các chuỗi mà nó trả về. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // Kiểm tra xem tài liệu bản thuyết trình có tồn tại không.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Kiểm tra xem chỉ số slide có vượt quá phạm vi không.

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // Lấy phần bản thuyết trình của tài liệu bản thuyết trình.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Kiểm tra xem phần bản thuyết trình và bản thuyết trình có tồn tại không.

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // Lấy đối tượng Presentation từ phần bản thuyết trình.

        Presentation presentation = presentationPart.Presentation;

        // Kiểm tra xem danh sách ID slide có tồn tại không.

        if (presentation.SlideIdList != null)

        {

            // Lấy tập hợp các ID slide từ danh sách ID slide.

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // Nếu ID slide nằm trong phạm vi...

            if (slideIndex < slideIds.Count)

            {

                // Lấy ID quan hệ của slide.

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // Lấy phần slide được chỉ định từ ID quan hệ.

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // Truyền phần slide tới phương thức tiếp theo, và

                // sau đó trả về mảng các chuỗi mà phương thức đó

                // trả về cho phương thức trước đó.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // Nếu không, trả về null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // Kiểm tra xem phần slide có tồn tại không.

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // Tạo một danh sách liên kết mới của các chuỗi.

    LinkedList<string> texts = new LinkedList<string>();

    // Nếu slide tồn tại...

    if (slidePart.Slide != null)

    {

        // Duyệt qua tất cả các đoạn văn trong slide.

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // Tạo một StringBuilder mới.                    

            StringBuilder paragraphText = new StringBuilder();

            // Duyệt qua các dòng của đoạn văn.

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // Gắn mỗi dòng vào các dòng trước đó.

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // Thêm mỗi đoạn văn vào danh sách liên kết.

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // Trả về một mảng các chuỗi.

        return texts.ToArray();

    }

    else

    {

        return null;

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// Lấy tất cả văn bản trong một slide.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// Tạo một danh sách liên kết mới các chuỗi.

List<string> texts = new List<string>();

//Instantiate PresentationEx class that represents PPTX
using (Presentation pres = new Presentation(presentationFile))

{

    //Access the slide
    ISlide sld = pres.Slides[slideIndex];

    //Iterate through shapes to find the placeholder
    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            //get the text of each placeholder
            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// Return an array of strings.

return texts;

}

``` 
## **Tải mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)