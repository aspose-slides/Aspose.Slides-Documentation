---
title: รับชื่อของสไลด์ทั้งหมด
type: docs
weight: 120
url: /th/net/get-the-titles-of-all-the-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get the titles of all the slides.pptx";

foreach (string s in GetSlideTitles(FileName))

Console.WriteLine(s);

Console.ReadKey();

// รับรายการชื่อของสไลด์ทั้งหมดในงานนำเสนอ.

public static IList<string> GetSlideTitles(string presentationFile)

{

    // เปิดงานนำเสนอในโหมดอ่านอย่างเดียว.

    using (PresentationDocument presentationDocument =

        PresentationDocument.Open(presentationFile, false))

    {

        return GetSlideTitles(presentationDocument);

    }

}

// รับรายการชื่อของสไลด์ทั้งหมดในงานนำเสนอ.

public static IList<string> GetSlideTitles(PresentationDocument presentationDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // รับอ็อบเจกต์ PresentationPart จากอ็อบเจกต์ PresentationDocument.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    if (presentationPart != null &&

        presentationPart.Presentation != null)

    {

        // รับอ็อบเจกต์ Presentation จากอ็อบเจกต์ PresentationPart.

        Presentation presentation = presentationPart.Presentation;

        if (presentation.SlideIdList != null)

        {

            List<string> titlesList = new List<string>();

            // รับชื่อของแต่ละสไลด์ตามลำดับสไลด์.

            foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())

            {

                SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;

                // รับชื่อสไลด์.

                string title = GetSlideTitle(slidePart);

                // สามารถเพิ่มชื่อว่างได้เช่นกัน.

                titlesList.Add(title);

            }

            return titlesList;

        }

    }

    return null;

}

// รับสตริงชื่อของสไลด์.

public static string GetSlideTitle(SlidePart slidePart)

{

    if (slidePart == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // ประกาศตัวคั่นย่อหน้า.

    string paragraphSeparator = null;

    if (slidePart.Slide != null)

    {

        // ค้นหารูปแบบชื่อทั้งหมด.

        var shapes = from shape in slidePart.Slide.Descendants<Shape>()

                     where IsTitleShape(shape)

                     select shape;

        StringBuilder paragraphText = new StringBuilder();

        foreach (var shape in shapes)

        {

            // รับข้อความในแต่ละย่อหน้าในรูปแบบนี้.

            foreach (var paragraph in shape.TextBody.Descendants<D.Paragraph>())

            {

                // เพิ่มการขึ้นบรรทัดใหม่.

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

// กำหนดว่ารูปแบบเป็นรูปแบบชื่อหรือไม่.

private static bool IsTitleShape(Shape shape)

{

    var placeholderShape = shape.NonVisualShapeProperties.ApplicationNonVisualDrawingProperties.GetFirstChild<PlaceholderShape>();

    if (placeholderShape != null && placeholderShape.Type != null && placeholderShape.Type.HasValue)

    {

        switch ((PlaceholderValues)placeholderShape.Type)

        {

            // รูปแบบชื่อใดก็ได้.

            case PlaceholderValues.Title:

            // ชื่ออยู่กึ่งกลาง.

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

    // เปิดงานนำเสนอในโหมดอ่านอย่างเดียว.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // ส่งงานนำเสนอไปยังเมธอด CountSlides ถัดไป

        // และคืนค่าจำนวนสไลด์.

        return CountSlides(presentationDocument);

    }

}

// นับจำนวนสไลด์ในงานนำเสนอ.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // ตรวจสอบว่าอ็อบเจกต์เอกสารเป็น null หรือไม่.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // ดึงส่วน Presentation ของเอกสาร.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // ดึงจำนวนสไลด์จาก SlideParts.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // คืนค่าจำนวนสไลด์ให้เมธอดก่อนหน้า.

    return slidesCount;

}

public static void GetSlideIdAndText(out string sldText, string docName, int index)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, false))

    {

        // ดึง Relationship ID ของสไลด์แรก.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[index] as SlideId).RelationshipId;

        // ดึงส่วน Slide จาก Relationship ID.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        // สร้างอ็อบเจกต์ StringBuilder.

        StringBuilder paragraphText = new StringBuilder();

        // ดึงข้อความภายในของสไลด์:

        IEnumerable<A.Text> texts = slide.Slide.Descendants<A.Text>();

        foreach (A.Text text in texts)

        {

            paragraphText.Append(text.Text);

        }

        sldText = paragraphText.ToString();

    }

}

``` 
## **ดาวน์โหลดตัวอย่างโค้ด**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20the%20titles%20of%20all%20the%20slides/)