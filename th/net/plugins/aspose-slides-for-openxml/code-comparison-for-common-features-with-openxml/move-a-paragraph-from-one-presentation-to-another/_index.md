---
title: ย้ายย่อหน้าจากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่ง
type: docs
weight: 130
url: /th/net/move-a-paragraph-from-one-presentation-to-another/
---
## **นำเสนอ OpenXML**
``` csharp

  string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

}

// ย้ายช่วงย่อหน้าในรูปร่าง TextBody ในเอกสารต้นทาง
// ไปยังรูปร่าง TextBody อีกอันในเอกสารเป้าหมาย.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

// เปิดไฟล์ต้นทางในโหมดอ่าน/เขียน.
using (PresentationDocument sourceDoc = PresentationDocument.Open(sourceFile, true))

{

    // เปิดไฟล์เป้าหมายในโหมดอ่าน/เขียน.
    using (PresentationDocument targetDoc = PresentationDocument.Open(targetFile, true))

    {

        // ดึงสไลด์แรกจากการนำเสนอต้นทาง.
        SlidePart slide1 = GetFirstSlide(sourceDoc);
        // ดึงรูปร่าง TextBody แรกในสไลด์นั้น.
        TextBody textBody1 = slide1.Slide.Descendants<TextBody>().First();
        // ดึงย่อหน้าแรกในรูปร่าง TextBody.
        // หมายเหตุ: "Drawing" คือชื่อแทนของเนมสเปซ DocumentFormat.OpenXml.Drawing
        Drawing.Paragraph p1 = textBody1.Elements<Drawing.Paragraph>().First();
        // ดึงสไลด์แรกจากการนำเสนอเป้าหมาย.
        SlidePart slide2 = GetFirstSlide(targetDoc);
        // ดึงรูปร่าง TextBody แรกในสไลด์นั้น.
        TextBody textBody2 = slide2.Slide.Descendants<TextBody>().First();
        // คัดลอกย่อหน้าในต้นทางและแทรกย่อหน้าที่คัดลอกลงในรูปร่าง TextBody ของเป้าหมาย.
        // การส่งค่า "true" จะทำการคัดลอกเชิงลึก ซึ่งสร้างสำเนาของ
        // วัตถุ Paragraph และทุกอย่างที่อ้างอิงโดยตรงหรือโดยอ้อมจากวัตถุนั้น.
        textBody2.Append(p1.CloneNode(true));
        // ลบย่อหน้าในต้นทางออกจากไฟล์ต้นทาง.
        textBody1.RemoveChild<Drawing.Paragraph>(p1);
        // แทนที่ย่อหน้าที่ถูกลบด้วยตัวแทนชั่วคราว.
        textBody1.AppendChild<Drawing.Paragraph>(new Drawing.Paragraph());
        // บันทึกสไลด์ในไฟล์ต้นทาง.
        slide1.Slide.Save();
        // บันทึกสไลด์ในไฟล์เป้าหมาย.
        slide2.Slide.Save();
    }

}

}

// ดึงส่วนสไลด์ของสไลด์แรกในเอกสารการนำเสนอ.
public static SlidePart GetFirstSlide(PresentationDocument presentationDocument)

{

// ดึง ID ความสัมพันธ์ของสไลด์แรก
PresentationPart part = presentationDocument.PresentationPart;
SlideId slideId = part.Presentation.SlideIdList.GetFirstChild<SlideId>();
string relId = slideId.RelationshipId;
// ดึงส่วนสไลด์โดยใช้ ID ความสัมพันธ์นั้น.
SlidePart slidePart = (SlidePart)part.GetPartById(relId);
return slidePart;

}


``` 
## **Aspose.Slides**
ไม่ได้แปลกที่นักพัฒนาต้องการดึงข้อความจากการนำเสนอ เพื่อทำเช่นนั้น คุณต้องดึงข้อความจากรูปทรงทั้งหมดในทุกสไลด์ของการนำเสนอ บทความนี้อธิบายวิธีดึงข้อความจากการนำเสนอ Microsoft PowerPoint PPTX ด้วย Aspose.Slides ไม่ว่าจะดึงข้อความจากสไลด์เดียวหรือจากการนำเสนอทั้งหมด Aspose.Slides ใช้คลาส PresentationScanner และเมธอดแบบสเตติกที่เปิดเผยทั้งหมด ซึ่งรวมอยู่ในเนมสเปซ [Aspose.Slides.Util](https://reference.aspose.com/slides/th/net/aspose.slides.util/slideutil).

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a Paragraph from One Presentation to Another 1.pptx";

string DestFileName = FilePath + "Move a Paragraph from One Presentation to Another 2.pptx";

MoveParagraphToPresentation(FileName, DestFileName);

// ย้ายช่วงย่อหน้าในรูปร่าง TextBody ของเอกสารต้นทาง
// ไปยังรูปร่าง TextBody อีกอันในเอกสารเป้าหมาย.

public static void MoveParagraphToPresentation(string sourceFile, string targetFile)

{

    string Text = "";

    //สร้างอินสแตนซ์คลาส Presentation ที่แทนไฟล์ PPTX//สร้างอินสแตนซ์คลาส Presentation ที่แทนไฟล์ PPTX

    Presentation sourcePres = new Presentation(sourceFile);

    //เข้าถึงรูปร่างแรกในสไลด์แรก

    IShape shp = sourcePres.Slides[0].Shapes[0];

    if (shp.Placeholder != null)

    {

        //ดึงข้อความจาก placeholder

        Text = ((IAutoShape)shp).TextFrame.Text;

        ((IAutoShape)shp).TextFrame.Text = "";

    }

    Presentation destPres = new Presentation(targetFile);

    //เข้าถึงรูปร่างแรกในสไลด์แรก

    IShape destshp = sourcePres.Slides[0].Shapes[0];

    if (destshp.Placeholder != null)

    {

        //ดึงข้อความจาก placeholder

        ((IAutoShape)destshp).TextFrame.Text += Text;

    }

    sourcePres.Save(sourceFile, Aspose.Slides.Export.SaveFormat.Pptx);

    destPres.Save(targetFile, Aspose.Slides.Export.SaveFormat.Pptx);

}

}   
``` 
## **ดาวน์โหลดตัวอย่างโค้ดที่ทำงาน**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **โค้ดตัวอย่าง**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Move%20a%20Paragraph)