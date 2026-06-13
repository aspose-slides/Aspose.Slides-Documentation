---
title: เพิ่มสไลด์ไปยังการนำเสนอ
type: docs
weight: 20
url: /th/net/adding-slide-to-presentation/
---
## **OpenXML การนำเสนอ**
ในฟังก์ชันด้านล่าง โดยค่าเริ่มต้นจะมีการเพิ่มสไลด์หนึ่งสไลด์ไปยังการนำเสนอ เรากำลังเพิ่มสไลด์ใหม่ที่ตำแหน่งที่ 2 พร้อมข้อความบางส่วนในสไลด์นั้น.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Adding Slide to Presentation.pptx";

InsertNewSlide(FileName, 1, "My new slide");

// แทรกสไลด์ลงในงานนำเสนอที่ระบุ

public static void InsertNewSlide(string presentationFile, int position, string slideTitle)

{

    // เปิดเอกสารต้นฉบับในโหมดอ่าน/เขียน. 

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        // ส่งเอกสารต้นฉบับ ตำแหน่ง และหัวข้อสไลด์ที่ต้องการแทรกไปยังเมธอดถัดไป.

        InsertNewSlide(presentationDocument, position, slideTitle);

    }

}

// แทรกสไลด์ที่ระบุลงในงานนำเสนอที่ตำแหน่งที่กำหนด.

public static void InsertNewSlide(PresentationDocument presentationDocument, int position, string slideTitle)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (slideTitle == null)

    {

        throw new ArgumentNullException("slideTitle");

    }

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // ตรวจสอบว่างานนำเสนอไม่ว่างเปล่า.

    if (presentationPart == null)

    {

        throw new InvalidOperationException("The presentation document is empty.");

    }

    // ประกาศและสร้างอินสแตนซ์สไลด์ใหม่.

    Slide slide = new Slide(new CommonSlideData(new ShapeTree()));

    uint drawingObjectId = 1;

    // สร้างเนื้อหาของสไลด์.            

    // ระบุคุณสมบัติที่ไม่แสดงผลของสไลด์ใหม่.

    NonVisualGroupShapeProperties nonVisualProperties = slide.CommonSlideData.ShapeTree.AppendChild(new NonVisualGroupShapeProperties());

    nonVisualProperties.NonVisualDrawingProperties = new NonVisualDrawingProperties() { Id = 1, Name = "" };

    nonVisualProperties.NonVisualGroupShapeDrawingProperties = new NonVisualGroupShapeDrawingProperties();

    nonVisualProperties.ApplicationNonVisualDrawingProperties = new ApplicationNonVisualDrawingProperties();

    // ระบุคุณสมบัติของกลุ่มรูปร่างของสไลด์ใหม่.

    slide.CommonSlideData.ShapeTree.AppendChild(new GroupShapeProperties());

    // ประกาศและสร้างอินสแตนซ์รูปร่างหัวข้อของสไลด์ใหม่.

    Shape titleShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // ระบุคุณสมบัติรูปแบบที่จำเป็นสำหรับรูปร่างหัวข้อ. 

    titleShape.NonVisualShapeProperties = new NonVisualShapeProperties

        (new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Title" },

        new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

        new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Type = PlaceholderValues.Title }));

    titleShape.ShapeProperties = new ShapeProperties();

    // ระบุข้อความของรูปร่างหัวข้อ.

    titleShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph(new Drawing.Run(new Drawing.Text() { Text = slideTitle })));

    // ประกาศและสร้างอินสแตนซ์รูปร่างเนื้อหาของสไลด์ใหม่.

    Shape bodyShape = slide.CommonSlideData.ShapeTree.AppendChild(new Shape());

    drawingObjectId++;

    // ระบุคุณสมบัติรูปแบบที่จำเป็นสำหรับรูปร่างเนื้อหา.

    bodyShape.NonVisualShapeProperties = new NonVisualShapeProperties(new NonVisualDrawingProperties() { Id = drawingObjectId, Name = "Content Placeholder" },

            new NonVisualShapeDrawingProperties(new Drawing.ShapeLocks() { NoGrouping = true }),

            new ApplicationNonVisualDrawingProperties(new PlaceholderShape() { Index = 1 }));

    bodyShape.ShapeProperties = new ShapeProperties();

    // ระบุข้อความของรูปร่างเนื้อหา.

    bodyShape.TextBody = new TextBody(new Drawing.BodyProperties(),

            new Drawing.ListStyle(),

            new Drawing.Paragraph());

    // สร้างส่วนสไลด์สำหรับสไลด์ใหม่.

    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();

    // บันทึกส่วนสไลด์ใหม่.

    slide.Save(slidePart);

    // แก้ไขรายการ ID ของสไลด์ในส่วนงานนำเสนอ.

    // รายการ ID ของสไลด์ไม่ควรเป็น null.

    SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

    // ค้นหา ID สไลด์ที่มากที่สุดในรายการปัจจุบัน.

    uint maxSlideId = 1;

    SlideId prevSlideId = null;

    foreach (SlideId slideId in slideIdList.ChildElements)

    {

        if (slideId.Id > maxSlideId)

        {

            maxSlideId = slideId.Id;

        }

        position--;

        if (position == 0)

        {

            prevSlideId = slideId;

        }

    }

    maxSlideId++;

    // รับ ID ของสไลด์ก่อนหน้า.

    SlidePart lastSlidePart;

    if (prevSlideId != null)

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(prevSlideId.RelationshipId);

    }

    else

    {

        lastSlidePart = (SlidePart)presentationPart.GetPartById(((SlideId)(slideIdList.ChildElements[0])).RelationshipId);

    }

    // ใช้เค้าโครงสไลด์เดียวกับสไลด์ก่อนหน้า.

    if (null != lastSlidePart.SlideLayoutPart)

    {

        slidePart.AddPart(lastSlidePart.SlideLayoutPart);

    }

    // แทรกสไลด์ใหม่ลงในรายการสไลด์หลังจากสไลด์ก่อนหน้า.

    SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);

    newSlideId.Id = maxSlideId;

    newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);

    // บันทึกงานนำเสนอที่แก้ไขแล้ว.

    presentationPart.Presentation.Save();

}

}
``` 
## **Aspose.Slides**
แต่ละไฟล์การนำเสนอ PowerPoint มี **Main Master slide** หนึ่งสไลด์และ **Normal slides** อื่น ๆ หมายความว่าไฟล์การนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์หรือมากกว่า สิ่งสำคัญที่ต้องทราบคือไฟล์การนำเสนอที่ไม่มีสไลด์จะไม่ได้รับการสนับสนุนโดย Aspose.Slides for .NET แต่ละสไลด์มีตำแหน่งเฉพาะและ **unique Id** ที่ไม่ซ้ำกัน **slide Id** สามารถอยู่ในช่วงตั้งแต่ 0 ถึง 255 สำหรับสไลด์ master และตั้งแต่ 256 ถึง 65535 สำหรับสไลด์ปกติ

Aspose.Slides for .NET อนุญาตให้ผู้พัฒนาสามารถเพิ่มสไลด์เปล่าลงในการนำเสนอโดยใช้เมธอด **AddEmptySlide** ของอ็อบเจกต์ **Presentation** เพื่อเพิ่มสไลด์เปล่าในการนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส Presentation
- เรียกเมธอด AddEmptySlide ที่เปิดให้ใช้โดยอ็อบเจกต์ Presentation
- ทำงานบางอย่างกับสไลด์เปล่าที่เพิ่มใหม่
- เพิ่มสไลด์อื่นและแทรกข้อความลงในสไลด์นั้น
- สุดท้าย เขียนไฟล์ PPT โดยใช้เมธอด Write ที่เปิดให้ใช้โดยอ็อบเจกต์ Presentation

``` csharp

 string FileName = FilePath + "Adding Slide to Presentation.pptx";

//สร้างอินสแตนซ์ของคลาส PresentationEx ที่เป็นตัวแทนไฟล์ PPT
Presentation pres = new Presentation();

//สไลด์เปล่าถูกเพิ่มโดยค่าเริ่มต้นเมื่อคุณสร้าง
//งานนำเสนอจากคอนสตรัคเตอร์เริ่มต้น
//การเพิ่มสไลด์เปล่าไปยังงานนำเสนอและรับอ้างอิงของ
//สไลด์เปล่านั้น
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

//เขียนผลลัพธ์ไปยังดิสก์
pres.Save(FileName,Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **ดาวน์โหลดตัวอย่างโค้ด**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/)