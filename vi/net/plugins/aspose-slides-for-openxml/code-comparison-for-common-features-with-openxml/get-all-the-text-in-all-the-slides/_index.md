---
title: Lấy tất cả văn bản trong tất cả các slide
type: docs
weight: 100
url: /vi/net/get-all-the-text-in-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // Mở bản trình bày ở chế độ chỉ đọc.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Truyền bản trình bày tới phương thức CountSlides tiếp theo

        // và trả về số lượng slide.

        return CountSlides(presentationDocument);

    }

}

// Đếm số slide trong bản trình bày.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Kiểm tra đối tượng tài liệu null.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Lấy phần trình bày của tài liệu.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Lấy số slide từ SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Trả về số slide cho phương thức trước.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Lấy Relationship ID của slide đầu tiên.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Lấy phần slide từ Relationship ID.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // Tạo một đối tượng StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // Lấy văn bản nội bộ của slide:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

int numberOfSlides = CountSlides(FileName);

System.Console.WriteLine("Number of slides = {0}", numberOfSlides);

string slideText;

for (int i = 0; i < numberOfSlides; i++)

{

slideText = GetSlideText(FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    //Khởi tạo lớp PresentationEx đại diện cho PPTX

    using (Presentation pres = new Presentation(presentationFile))

    {

        return pres.Slides.Count;

    }

}

public static string GetSlideText(string docName, int index)

{

    string sldText = "";

    //Khởi tạo lớp PresentationEx đại diện cho PPTX

    using (Presentation pres = new Presentation(docName))

    {

        //Truy cập slide

        ISlide sld = pres.Slides[index];

        //Duyệt qua các shape để tìm placeholder

        foreach (Shape shp in sld.Shapes)

            if (shp.Placeholder != null)

            {

                //lấy văn bản của mỗi placeholder

                sldText += ((AutoShape)shp).TextFrame.Text;

            }

    }

    return sldText;

}

``` 
## **Tải xuống mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20all%20slides/)