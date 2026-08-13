---
title: เพิ่มกรอบรูปพร้อมการเคลื่อนไหวด้วย VSTO และ Aspose.Slides สำหรับ .NET
linktitle: กรอบรูปพร้อมการเคลื่อนไหว
type: docs
weight: 60
url: /th/net/adding-picture-frame-with-animation/
keywords:
- กรอบรูป
- เพิ่มรูปภาพ
- เพิ่มรูป
- รูปภาพพร้อมการเคลื่อนไหว
- รูปพร้อมการเคลื่อนไหว
- การย้าย
- VSTO
- การทำงานอัตโนมัติของ Office
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ย้ายจากการทำงานอัตโนมัติของ Microsoft Office ไปยัง Aspose.Slides สำหรับ .NET และทำให้กรอบรูปเคลื่อนไหวในสไลด์ PowerPoint (PPT, PPTX) ด้วยโค้ด C# ที่สะอาดและชัดเจน."
---
{{% alert color="info" %}} 
กรอบรูปถูกนำไปใช้กับรูปร่างหรือรูปภาพใน Microsoft PowerPoint เพื่อใส่กรอบให้กับภาพในงานนำเสนอ บทความนี้แสดงวิธีสร้างกรอบรูปและเพิ่มการเคลื่อนไหวให้กับมันโดยโปรแกรมโดยใช้ [VSTO 2008](/slides/th/net/adding-picture-frame-with-animation/) ก่อน แล้วตามด้วย [Aspose.Slides for .NET](/slides/th/net/adding-picture-frame-with-animation/). ขั้นแรก เราแสดงวิธีใส่กรอบและการเคลื่อนไหวโดยใช้ VSTO 2008 แล้วจึงแสดงวิธีทำขั้นตอนเดียวกันโดยใช้ Aspose.Slides for .NET.
{{% /alert %}} 
## **การเพิ่มกรอบรูปพร้อมการเคลื่อนไหว**
ตัวอย่างโค้ดด้านล่างสร้างงานนำเสนอพร้อมสไลด์หนึ่งแผ่น, เพิ่มรูปภาพพร้อมกรอบรูป และใส่การเคลื่อนไหวให้กับมัน
### **ตัวอย่าง VSTO 2008**
ใช้ VSTO 2008 ทำตามขั้นตอนต่อไปนี้:

1. สร้างงานนำเสนอ
1. เพิ่มสไลด์เปล่า
1. เพิ่มรูปร่างรูปภาพลงในสไลด์
1. ใส่การเคลื่อนไหวให้กับรูปภาพ
1. บันทึกงานนำเสนอลงดิสก์

**งานนำเสนอผลลัพธ์ที่สร้างด้วย VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)

```c#
//สร้างงานนำเสนอเปล่า
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Add Picture Frame
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Applying animation on picture frame
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Saving Presentation
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```

### **ตัวอย่าง Aspose.Slides for .NET**
ใช้ Aspose.Slides for .NET ทำตามขั้นตอนต่อไปนี้:

1. สร้างงานนำเสนอ
1. เข้าถึงสไลด์แรก
1. เพิ่มรูปภาพลงในคอลเลกชันรูป
1. เพิ่มรูปร่างรูปภาพลงในสไลด์
1. ใส่การเคลื่อนไหวให้กับรูปภาพ
1. บันทึกงานนำเสนอลงดิสก์

**งานนำเสนอผลลัพธ์ที่สร้างด้วย Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// สร้างงานนำเสนอเปล่า
using (Presentation pres = new Presentation())
{
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.Slides[0];

    // เพิ่มรูปภาพลงในคอลเลกชันรูปของงานนำเสนอ
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // เพิ่มกรอบรูปที่ความสูงและความกว้างตรงกับความสูงและความกว้างของรูปภาพ
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // รับลำดับการเคลื่อนไหวหลักของสไลด์
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // เพิ่มเอฟเฟกต์การเคลื่อนที่แบบบินจากด้านซ้ายให้กับกรอบรูป
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // บันทึกงานนำเสนอ
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```