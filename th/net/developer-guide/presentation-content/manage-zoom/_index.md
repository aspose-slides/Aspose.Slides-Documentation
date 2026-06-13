---
title: จัดการการซูมของการนำเสนอใน .NET
linktitle: จัดการการซูม
type: docs
weight: 60
url: /th/net/manage-zoom/
keywords:
- ซูม
- กรอบซูม
- ซูมสไลด์
- ซูมส่วน
- ซูมสรุป
- เพิ่มซูม
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างและปรับแต่งการซูมด้วย Aspose.Slides สำหรับ .NET — กระโดดระหว่างส่วนต่าง ๆ, เพิ่มภาพย่อและการเปลี่ยนภาพในงานนำเสนอรูปแบบ PPT, PPTX และ ODP"
---
## **บทนำ**

Zoom ใน PowerPoint ช่วยให้คุณกระโดดไปและกลับจากสไลด์, ส่วน, และส่วนต่าง ๆ ของการนำเสนอได้ เมื่อคุณกำลังนำเสนอ ความสามารถในการนำทางอย่างรวดเร็วผ่านเนื้อหาอาจเป็นประโยชน์มาก

![ภาพรวม](overview.png)

* เพื่อสรุปการนำเสนอทั้งหมดในสไลด์เดียว, ใช้ [Summary Zoom](#Summary-Zoom).
* เพื่อแสดงเฉพาะสไลด์ที่เลือก, ใช้ [Slide Zoom](#Slide-Zoom).
* เพื่อแสดงเฉพาะส่วนเดียว, ใช้ [Section Zoom](#Section-Zoom).

## **การซูมสไลด์**
การซูมสไลด์สามารถทำให้การนำเสนอของคุณมีความไดนามิกมากขึ้น, ให้คุณนำทางอย่างอิสระระหว่างสไลด์ในลำดับใดก็ได้โดยไม่รบกวนการไหลของการนำเสนอ การซูมสไลด์เหมาะสำหรับการนำเสนอสั้นที่ไม่มีส่วนหลายส่วน, แต่คุณยังสามารถใช้ในสถานการณ์การนำเสนออื่นได้

การซูมสไลด์ช่วยให้คุณเจาะลึกข้อมูลหลายชิ้นในขณะที่รู้สึกเหมือนอยู่บนผืนผ้าเดียว

![ภาพรวม](slidezoomsel.png)

สำหรับอ็อบเจ็กต์การซูมสไลด์, Aspose.Slides มี enumeration [ZoomImageType](https://reference.aspose.com/slides/th/net/aspose.slides/zoomimagetype), interface [IZoomFrame](https://reference.aspose.com/slides/th/net/aspose.slides/izoomframe) และบางเมธอดภายใต้ interface [IShapeCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection)

### **สร้างกรอบซูม**

คุณสามารถเพิ่มกรอบซูมบนสไลด์ได้ตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. สร้างสไลด์ใหม่ที่คุณต้องการเชื่อมโยงกับกรอบซูม.
3. เพิ่มข้อความบ่งชี้และพื้นหลังให้กับสไลด์ที่สร้าง.
4. เพิ่มกรอบซูม (ซึ่งมีการอ้างอิงถึงสไลด์ที่สร้าง) ไปยังสไลด์แรก.
5. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด C# นี้แสดงวิธีสร้างกรอบซูมบนสไลด์:

``` csharp 
using (Presentation pres = new Presentation())
{
    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //สร้างพื้นหลังสำหรับสไลด์ที่สอง
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //สร้างกล่องข้อความสำหรับสไลด์ที่สอง
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //สร้างพื้นหลังสำหรับสไลด์ที่สาม
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    //สร้างกล่องข้อความสำหรับสไลด์ที่สาม
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //เพิ่มออบเจ็กต์ ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    //บันทึกงานนำเสนอ
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **สร้างกรอบซูมด้วยรูปภาพกำหนดเอง**
ด้วย Aspose.Slides สำหรับ .NET, คุณสามารถสร้างกรอบซูมด้วยภาพตัวอย่างสไลด์ที่แตกต่างกันได้ตามนี้:
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. สร้างสไลด์ใหม่ที่คุณต้องการเชื่อมโยงกับกรอบซูม.
3. เพิ่มข้อความบ่งชี้และพื้นหลังให้กับสไลด์.
4. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage) โดยใส่รูปภาพลงในคอลเลกชัน Images ที่เชื่อมกับอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) เพื่อใช้เติมกรอบ.
5. เพิ่มกรอบซูม (ซึ่งอ้างอิงถึงสไลด์ที่สร้าง) ไปยังสไลด์แรก.
6. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด C# นี้แสดงวิธีสร้างกรอบซูมด้วยรูปภาพที่แตกต่าง:

``` csharp 
using (Presentation pres = new Presentation())
{
    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    //สร้างพื้นหลังสำหรับสไลด์ที่สอง
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    //สร้างกล่องข้อความสำหรับสไลด์ที่สาม
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    //สร้างภาพใหม่สำหรับออบเจ็กต์ซูม
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //เพิ่มออบเจ็กต์ ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    //บันทึกงานนำเสนอ
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **จัดรูปแบบกรอบซูม**
ในส่วนก่อนหน้าเราได้แสดงวิธีสร้างกรอบซูมอย่างง่าย เพื่อสร้างกรอบซูมที่ซับซ้อนมากขึ้น คุณต้องปรับการจัดรูปแบบของกรอบอย่างง่าย มีตัวเลือกการจัดรูปแบบหลายอย่างที่คุณสามารถใช้กับกรอบซูม

คุณสามารถควบคุมการจัดรูปแบบของกรอบซูมบนสไลด์ได้ตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. สร้างสไลด์ใหม่ที่คุณต้องการเชื่อมโยงกับกรอบซูม.
3. เพิ่มข้อความบ่งชี้และพื้นหลังให้กับสไลด์ที่สร้าง.
4. เพิ่มกรอบซูม (ซึ่งมีการอ้างอิงถึงสไลด์ที่สร้าง) ไปยังสไลด์แรก.
5. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage) โดยใส่รูปภาพลงในคอลเลกชัน Images ที่เชื่อมกับอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) เพื่อใช้เติมกรอบ.
6. ตั้งค่าภาพกำหนดเองสำหรับอ็อบเจ็กต์กรอบซูมแรก.
7. เปลี่ยนการจัดรูปแบบเส้นสำหรับอ็อบเจ็กต์กรอบซูมที่สอง.
8. ลบพื้นหลังจากภาพของอ็อบเจ็กต์กรอบซูมที่สอง.
5. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด C# นี้แสดงวิธีเปลี่ยนการจัดรูปแบบของกรอบซูมบนสไลด์:

``` csharp 
using (Presentation pres = new Presentation())
{
    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // สร้างพื้นหลังสำหรับสไลด์ที่สอง
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // สร้างกล่องข้อความสำหรับสไลด์ที่สอง
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // สร้างพื้นหลังสำหรับสไลด์ที่สาม
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // สร้างกล่องข้อความสำหรับสไลด์ที่สาม
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //เพิ่มออบเจ็กต์ ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // สร้างรูปภาพใหม่สำหรับออบเจ็กต์ซูม
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // ตั้งค่าภาพกำหนดเองสำหรับออบเจ็กต์ zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // ตั้งค่ารูปแบบกรอบซูมสำหรับออบเจ็กต์ zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // การตั้งค่าสำหรับไม่แสดงพื้นหลังสำหรับออบเจ็กต์ zoomFrame2
    zoomFrame2.ShowBackground = false;

    // บันทึกงานนำเสนอ
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **การซูมส่วน**

การซูมส่วนเป็นลิงก์ไปยังส่วนในการนำเสนอของคุณ คุณสามารถใช้การซูมส่วนเพื่อกลับไปยังส่วนที่ต้องการเน้นจริง ๆ หรือใช้เพื่อเน้นว่าชิ้นส่วนต่าง ๆ ของการนำเสนอเชื่อมโยงกันอย่างไร

![ภาพรวม](seczoomsel.png)

สำหรับอ็อบเจ็กต์การซูมส่วน, Aspose.Slides มี interface [ISectionZoomFrame](https://reference.aspose.com/slides/th/net/aspose.slides/isectionzoomframe) และบางเมธอดภายใต้ interface [IShapeCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection)

### **สร้างกรอบซูมส่วน**

คุณสามารถเพิ่มกรอบซูมส่วนบนสไลด์ได้ตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. สร้างสไลด์ใหม่.
3. เพิ่มพื้นหลังบ่งชี้ให้กับสไลด์ที่สร้าง.
4. สร้างส่วนใหม่ที่คุณต้องการเชื่อมโยงกับกรอบซูม.
5. เพิ่มกรอบซูมส่วน (ซึ่งมีการอ้างอิงถึงส่วนที่สร้าง) ไปยังสไลด์แรก.
6. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด C# นี้แสดงวิธีสร้างกรอบซูมบนสไลด์:

``` csharp 
using (Presentation pres = new Presentation())
{
    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // เพิ่ม Section ใหม่ลงในงานนำเสนอ
    pres.Sections.AddSection("Section 1", slide);

    // เพิ่มออบเจ็กต์ SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // บันทึกงานนำเสนอ
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **สร้างกรอบซูมส่วนด้วยรูปภาพกำหนดเอง**

ด้วย Aspose.Slides สำหรับ .NET, คุณสามารถสร้างกรอบซูมส่วนด้วยภาพตัวอย่างสไลด์ที่แตกต่างกันได้ตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. สร้างสไลด์ใหม่.
3. เพิ่มพื้นหลังบ่งชี้ให้กับสไลด์ที่สร้าง.
4. สร้างส่วนใหม่ที่คุณต้องการเชื่อมโยงกับกรอบซูม.
5. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage) โดยใส่รูปภาพลงในคอลเลกชัน Images ที่เชื่อมกับอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) เพื่อใช้เติมกรอบ.
5. เพิ่มกรอบซูมส่วน (ซึ่งอ้างอิงถึงส่วนที่สร้าง) ไปยังสไลด์แรก.
6. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด C# นี้แสดงวิธีสร้างกรอบซูมด้วยรูปภาพที่แตกต่าง:

``` csharp 
using (Presentation pres = new Presentation())
{
    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // เพิ่ม Section ใหม่ลงในงานนำเสนอ
    pres.Sections.AddSection("Section 1", slide);

    // สร้างรูปภาพใหม่สำหรับออบเจ็กต์ซูม
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // เพิ่มออบเจ็กต์ SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // บันทึกงานนำเสนอ
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **จัดรูปแบบกรอบซูมส่วน**

เพื่อสร้างกรอบซูมส่วนที่ซับซ้อนมากขึ้น คุณต้องปรับการจัดรูปแบบของกรอบอย่างง่าย มีตัวเลือกการจัดรูปแบบหลายอย่างที่คุณสามารถใช้กับกรอบซูมส่วน

คุณสามารถควบคุมการจัดรูปแบบของกรอบซูมส่วนบนสไลด์ได้ตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. สร้างสไลด์ใหม่.
3. เพิ่มพื้นหลังบ่งชี้ให้กับสไลด์ที่สร้าง.
4. สร้างส่วนใหม่ที่คุณต้องการเชื่อมโยงกับกรอบซูม.
5. เพิ่มกรอบซูมส่วน (ซึ่งมีการอ้างอิงถึงส่วนที่สร้าง) ไปยังสไลด์แรก.
6. เปลี่ยนขนาดและตำแหน่งของอ็อบเจ็กต์ซูมส่วนที่สร้าง.
7. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage) โดยใส่รูปภาพลงในคอลเลกชัน Images ที่เชื่อมกับอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) เพื่อใช้เติมกรอบ.
8. ตั้งค่าภาพกำหนดเองสำหรับอ็อบเจ็กต์กรอบซูมส่วนที่สร้าง.
9. ตั้งค่าความสามารถ *กลับไปยังสไลด์ต้นฉบับจากส่วนที่เชื่อมโยง*.
10. ลบพื้นหลังจากภาพของอ็อบเจ็กต์กรอบซูมส่วน.
11. เปลี่ยนการจัดรูปแบบเส้นสำหรับอ็อบเจ็กต์กรอบซูมที่สอง.
12. เปลี่ยนระยะเวลาในการเปลี่ยนภาพ.
13. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด C# นี้แสดงวิธีเปลี่ยนการจัดรูปแบบของกรอบซูมส่วน:

``` csharp 
using (Presentation pres = new Presentation())
{
    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    //เพิ่ม Section ใหม่ลงในงานนำเสนอ
    pres.Sections.AddSection("Section 1", slide);

    //เพิ่มออบเจ็กต์ SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    //การจัดรูปแบบสำหรับ SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    //บันทึกงานนำเสนอ
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **การซูมสรุป**

การซูมสรุปเป็นเหมือนหน้า Landing Page ที่แสดงส่วนต่าง ๆ ของการนำเสนอของคุณพร้อมกัน เมื่อคุณกำลังนำเสนอ คุณสามารถใช้การซูมเพื่อไปจากตำแหน่งหนึ่งไปยังอีกตำแหน่งหนึ่งในลำดับใดก็ได้ตามต้องการ คุณสามารถสร้างสรรค์, ข้ามไปข้างหน้า, หรือกลับมาดูส่วนต่าง ๆ ของการสไลด์โชว์โดยไม่รบกวนการไหลของการนำเสนอ

![ภาพรวม](sumzoomsel.png)

สำหรับอ็อบเจ็กต์การซูมสรุป, Aspose.Slides มี interface [ISummaryZoomFrame](https://reference.aspose.com/slides/th/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/th/net/aspose.slides/isummaryzoomsection), และ [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/th/net/aspose.slides/isummaryzoomsectioncollection) พร้อมบางเมธอดภายใต้ interface [IShapeCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection)

### **สร้างการซูมสรุป**

คุณสามารถเพิ่มกรอบซูมสรุปบนสไลด์ได้ตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. สร้างสไลด์ใหม่พร้อมพื้นหลังบ่งชี้และส่วนใหม่สำหรับสไลด์ที่สร้าง.
3. เพิ่มกรอบซูมสรุปไปยังสไลด์แรก.
4. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด C# นี้แสดงวิธีสร้างกรอบซูมสรุปบนสไลด์:

``` csharp 
using (Presentation pres = new Presentation())
{
    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // เพิ่ม Section ใหม่ลงในงานนำเสนอ
    pres.Sections.AddSection("Section 1", slide);

    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // เพิ่ม Section ใหม่ลงในงานนำเสนอ
    pres.Sections.AddSection("Section 2", slide);

    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // เพิ่ม Section ใหม่ลงในงานนำเสนอ
    pres.Sections.AddSection("Section 3", slide);

    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // เพิ่ม Section ใหม่ลงในงานนำเสนอ
    pres.Sections.AddSection("Section 4", slide);

    // เพิ่มออบเจ็กต์ SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // บันทึกงานนำเสนอ
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **เพิ่มและลบส่วนการซูมสรุป**

ทุกส่วนในกรอบซูมสรุปถูกแทนด้วยอ็อบเจ็กต์ [ISummaryZoomFrameSection](https://reference.aspose.com/slides/th/net/aspose.slides/isummaryzoomsection) ซึ่งจัดเก็บในอ็อบเจ็กต์ [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/th/net/aspose.slides/isummaryzoomsectioncollection) คุณสามารถเพิ่มหรือเอาออกอ็อบเจ็กต์ส่วนซูมสรุปผ่าน interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/th/net/aspose.slides/isummaryzoomsectioncollection) ได้ตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. สร้างสไลด์ใหม่พร้อมพื้นหลังบ่งชี้และส่วนใหม่สำหรับสไลด์ที่สร้าง.
3. เพิ่มกรอบซูมสรุปไปยังสไลด์แรก.
4. เพิ่มสไลด์และส่วนใหม่ลงในการนำเสนอ.
5. เพิ่มส่วนที่สร้างลงในกรอบซูมสรุป.
6. เอาส่วนแรกออกจากกรอบซูมสรุป.
7. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด C# นี้แสดงวิธีเพิ่มและลบส่วนในกรอบซูมสรุป:

``` csharp 
using (Presentation pres = new Presentation())
{
    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // เพิ่ม Section ใหม่ลงในงานนำเสนอ
    pres.Sections.AddSection("Section 1", slide);

    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // เพิ่ม Section ใหม่ลงในงานนำเสนอ
    pres.Sections.AddSection("Section 2", slide);

    // เพิ่มออบเจ็กต์ SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // เพิ่ม Section ใหม่ลงในงานนำเสนอ
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // เพิ่ม Section ไปยัง Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // ลบ Section จาก Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // บันทึกงานนำเสนอ
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **จัดรูปแบบส่วนการซูมสรุป**

เพื่อสร้างอ็อบเจ็กต์ส่วนการซูมสรุปที่ซับซ้อนมากขึ้น คุณต้องปรับการจัดรูปแบบของกรอบอย่างง่าย มีตัวเลือกการจัดรูปแบบหลายอย่างที่คุณสามารถใช้กับอ็อบเจ็กต์ส่วนการซูมสรุป

คุณสามารถควบคุมการจัดรูปแบบของอ็อบเจ็กต์ส่วนการซูมสรุปในกรอบซูมสรุปได้ตามนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. สร้างสไลด์ใหม่พร้อมพื้นหลังบ่งชี้และส่วนใหม่สำหรับสไลด์ที่สร้าง.
3. เพิ่มกรอบซูมสรุปไปยังสไลด์แรก.
4. รับอ็อบเจ็กต์ส่วนการซูมสรุปสำหรับอ็อบเจ็กต์แรกจาก `ISummaryZoomSectionCollection`.
7. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage) โดยใส่รูปภาพลงในคอลเลกชัน images ที่เชื่อมกับอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) เพื่อใช้เติมกรอบ.
8. ตั้งค่าภาพกำหนดเองสำหรับอ็อบเจ็กต์ส่วนซูมที่สร้าง.
9. ตั้งค่าความสามารถ *กลับไปยังสไลด์ต้นฉบับจากส่วนที่เชื่อมโยง*.
11. เปลี่ยนการจัดรูปแบบเส้นสำหรับอ็อบเจ็กต์กรอบซูมที่สอง.
12. เปลี่ยนระยะเวลาในการเปลี่ยนภาพ.
13. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด C# นี้แสดงวิธีเปลี่ยนการจัดรูปแบบของอ็อบเจ็กต์ส่วนการซูมสรุป:

``` csharp 
using (Presentation pres = new Presentation())
{
    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // เพิ่ม Section ใหม่ลงในงานนำเสนอ
    pres.Sections.AddSection("Section 1", slide);

    //เพิ่มสไลด์ใหม่ลงในงานนำเสนอ
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // เพิ่ม Section ใหม่ลงในงานนำเสนอ
    pres.Sections.AddSection("Section 2", slide);

    // เพิ่มออบเจ็กต์ SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // ดึงออบเจ็กต์ SummaryZoomSection แรก
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // การจัดรูปแบบสำหรับออบเจ็กต์ SummaryZoomSection
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // บันทึกงานนำเสนอ
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมการกลับไปยังสไลด์ 'พาเรนต์' หลังจากแสดงเป้าหมายได้หรือไม่?**

ใช่. [Zoom frame](https://reference.aspose.com/slides/th/net/aspose.slides/zoomframe/) หรือ [section](https://reference.aspose.com/slides/th/net/aspose.slides/sectionzoomframe/) มีพฤติกรรม `ReturnToParent` ที่เมื่อเปิดใช้งานจะพาผู้ชมกลับไปยังสไลด์ต้นทางหลังจากเข้าชมเนื้อหาเป้าหมาย

**ฉันสามารถปรับ 'ความเร็ว' หรือระยะเวลาในการเปลี่ยนภาพของการซูมได้หรือไม่?**

ใช่. การซูมรองรับการตั้งค่า `TransitionDuration` เพื่อให้คุณควบคุมระยะเวลาที่ใช้ในการกระโดดแอนิเมชัน

**มีขีดจำกัดจำนวนอ็อบเจ็กต์ซูมที่การนำเสนอสามารถมีได้หรือไม่?**

ไม่มีขีดจำกัด API คงที่ที่ระบุในเอกสาร ขีดจำกัดที่เป็นไปได้ขึ้นอยู่กับความซับซ้อนโดยรวมของการนำเสนอและประสิทธิภาพของผู้ชม คุณสามารถเพิ่มกรอบซูมได้หลายอัน แต่ควรคำนึงถึงขนาดไฟล์และเวลาเรนเดอร์