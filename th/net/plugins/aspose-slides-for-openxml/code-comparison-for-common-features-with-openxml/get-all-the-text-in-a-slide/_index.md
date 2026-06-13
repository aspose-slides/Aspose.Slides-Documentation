---
title: ดึงข้อความทั้งหมดในสไลด์
type: docs
weight: 110
url: /th/net/get-all-the-text-in-a-slide/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Get all the text in a slide.pptx";

foreach (string s in GetAllTextInSlide(FileName, 0))

Console.WriteLine(s);

Console.ReadKey();

// ดึงข้อความทั้งหมดในสไลด์.

public static string[] GetAllTextInSlide(string presentationFile, int slideIndex)

{

    // เปิดงานนำเสนอแบบอ่านอย่างเดียว.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // ส่งงานนำเสนอและดัชนีสไลด์

        // ไปยังเมธอด GetAllTextInSlide ถัดไป, และ

        // จากนั้นคืนอาเรย์ของสตริงที่มันส่งกลับ. 

        return GetAllTextInSlide(presentationDocument, slideIndex);

    }

}

public static string[] GetAllTextInSlide(PresentationDocument presentationDocument, int slideIndex)

{

    // ตรวจสอบว่าเอกสารการนำเสนอมีอยู่

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // ตรวจสอบว่าดัชนีสไลด์ไม่ได้เกินขอบเขต

    if (slideIndex < 0)

    {

        throw new ArgumentOutOfRangeException("slideIndex");

    }

    // ดึงส่วนการนำเสนอจากเอกสารการนำเสนอ

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // ตรวจสอบว่าส่วนการนำเสนอและการนำเสนอมีอยู่

    if (presentationPart != null && presentationPart.Presentation != null)

    {

        // ดึงอ็อบเจ็กต์ Presentation จากส่วนการนำเสนอ

        Presentation presentation = presentationPart.Presentation;

        // ตรวจสอบว่ารายการ ID สไลด์มีอยู่

        if (presentation.SlideIdList != null)

        {

            // ดึงชุดของ ID สไลด์จากรายการ ID สไลด์

            DocumentFormat.OpenXml.OpenXmlElementList slideIds =

                presentation.SlideIdList.ChildElements;

            // หาก ID สไลด์อยู่ในช่วง...

            if (slideIndex < slideIds.Count)

            {

                // ดึง Relationship ID ของสไลด์

                string slidePartRelationshipId = (slideIds[slideIndex] as SlideId).RelationshipId;

                // ดึงส่วนสไลด์ที่ระบุจาก Relationship ID

                SlidePart slidePart =

                    (SlidePart)presentationPart.GetPartById(slidePartRelationshipId);

                // ส่งส่วนสไลด์ไปยังเมธอดถัดไป, และ

                // จากนั้นคืนอาเรย์ของสตริงที่เมธอดนั้น

                // ส่งกลับไปยังเมธอดก่อนหน้า.

                return GetAllTextInSlide(slidePart);

            }

        }

    }

    // มิฉะนั้น, คืนค่า null.

    return null;

}

public static string[] GetAllTextInSlide(SlidePart slidePart)

{

    // ตรวจสอบว่าส่วนสไลด์มีอยู่

    if (slidePart == null)

    {

        throw new ArgumentNullException("slidePart");

    }

    // สร้าง linked list ใหม่ของสตริง

    LinkedList<string> texts = new LinkedList<string>();

    // หากสไลด์มีอยู่...

    if (slidePart.Slide != null)

    {

        // วนซ้ำผ่านทุกย่อหน้าภายในสไลด์

        foreach (DocumentFormat.OpenXml.Drawing.Paragraph paragraph in

            slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>())

        {

            // สร้าง StringBuilder ใหม่.                    

            StringBuilder paragraphText = new StringBuilder();

            // วนซ้ำผ่านบรรทัดของย่อหน้า

            foreach (DocumentFormat.OpenXml.Drawing.Text text in

                paragraph.Descendants<DocumentFormat.OpenXml.Drawing.Text>())

            {

                // ต่อเติมแต่ละบรรทัดไปยังบรรทัดก่อนหน้า

                paragraphText.Append(text.Text);

            }

            if (paragraphText.Length > 0)

            {

                // เพิ่มแต่ละย่อหน้าไปยัง linked list

                texts.AddLast(paragraphText.ToString());

            }

        }

    }

    if (texts.Count > 0)

    {

        // คืนอาเรย์ของสตริง

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

// ดึงข้อความทั้งหมดในสไลด์.

public static List<string> GetAllTextInSlide(string presentationFile, int slideIndex)

{

// สร้าง linked list ใหม่ของสตริง.

List<string> texts = new List<string>();

// สร้างอินสแตนซ์ของคลาส PresentationEx ที่แทน PPTX

using (Presentation pres = new Presentation(presentationFile))

{

    // เข้าถึงสไลด์

    ISlide sld = pres.Slides[slideIndex];

    // วนซ้ำผ่านรูปร่างเพื่อหา placeholder

    foreach (Shape shp in sld.Shapes)

        if (shp.Placeholder != null)

        {

            // ดึงข้อความของแต่ละ placeholder

            texts.Add(((AutoShape)shp).TextFrame.Text);

        }

}

// คืนค่าอาเรย์ของสตริง.

return texts;

}

``` 
## **ดาวน์โหลดโค้ดตัวอย่าง**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Get%20all%20the%20text%20in%20a%20slide/)