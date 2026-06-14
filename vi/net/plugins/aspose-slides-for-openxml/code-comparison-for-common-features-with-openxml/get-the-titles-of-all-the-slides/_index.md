---
title: Lấy tiêu đề của tất cả các slide
type: docs
weight: 120
url: /vi/net/get-the-titles-of-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get the titles of all the slides.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// Lấy danh sách tiêu đề của tất cả các slide trong bản trình chiếu.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // Mở bản trình chiếu ở chế độ chỉ đọc.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// Lấy danh sách tiêu đề của tất cả các slide trong bản trình chiếu.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Lấy đối tượng PresentationPart từ đối tượng PresentationDocument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // Lấy đối tượng Presentation từ đối tượng PresentationPart.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // Lấy tiêu đề của mỗi slide theo thứ tự slide.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // Lấy tiêu đề slide.

                string title = GetSlideTitle(slidePart);

                // Một tiêu đề trống cũng có thể được thêm vào.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// Lấy chuỗi tiêu đề của slide.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // Khai báo một dấu phân cách đoạn văn.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // Tìm tất cả các hình dạng tiêu đề.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // Lấy văn bản trong mỗi đoạn trong hình dạng này.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // Thêm ngắt dòng.

                paragraphText.Append(paragraphSeparator);

                foreach (var text in paragraph.Descendants<D.Text>())

                {

                    paragraphText.Append(text.Text);

                }

                paragraphSeparator = "\n";

            }

        }

        return paragraphText.ToString();

    }

    return string.Empty;

}

// Xác định xem hình dạng có phải là hình dạng tiêu đề hay không.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // Bất kỳ hình dạng tiêu đề nào.

            case PlaceholderValues.Title:

            // Tiêu đề trung tâm.

            case PlaceholderValues.CenteredTitle:

                return true;

            default:

                return false;

        }

    }

    return false;

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

GetSlideIdAndText(out slideText, FileName, i);

System.Console.WriteLine("Slide #{0} contains: {1}", i + 1, slideText);

}

System.Console.ReadKey();

public static int CountSlides(string presentationFile)

{

    // Mở bản trình chiếu ở chế độ chỉ đọc.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // Gửi bản trình chiếu tới phương thức CountSlides tiếp theo

        // và trả về số lượng slide.

        return CountSlides(presentationDocument);

    }

}

// Đếm số slide trong bản trình chiếu.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // Kiểm tra xem đối tượng tài liệu có null hay không.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // Lấy phần Presentation của tài liệu.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Lấy số lượng slide từ các SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // Trả về số lượng slide cho phương thức trước.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // Lấy ID quan hệ của slide đầu tiên.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // Lấy phần slide từ ID quan hệ.

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
## **Tải mã nguồn mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)