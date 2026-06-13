---
title: เพิ่มกรอบรูปพร้อมการเคลื่อนไหวโดยใช้ VSTO และ Aspose.Slides สำหรับ .NET
linktitle: กรอบรูปพร้อมการเคลื่อนไหว
type: docs
weight: 60
url: /th/net/adding-picture-frame-with-animation/
keywords:
- กรอบรูป
- เพิ่มรูปภาพ
- เพิ่มรูป
- ภาพพร้อมการเคลื่อนไหว
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
{{% alert color="primary" %}} 

กรอบรูปถูกนำไปใช้กับรูปทรงหรือรูปภาพใน Microsoft PowerPoint เพื่อใส่กรอบให้กับรูปภาพในงานนำเสนอ บทความนี้แสดงวิธีสร้างกรอบรูปและใส่การเคลื่อนไหวลงไปโดยโปรแกรมโดยใช้แรกคือ [VSTO 2008](/slides/th/net/adding-picture-frame-with-animation/) แล้วจึงตามด้วย [Aspose.Slides for .NET](/slides/th/net/adding-picture-frame-with-animation/) ขั้นแรก เราจะแสดงวิธีการใส่กรอบและการเคลื่อนไหวโดยใช้ VSTO 2008 จากนั้นเราจะแสดงวิธีทำขั้นตอนเดียวกันโดยใช้ Aspose.Slides for .NET

{{% /alert %}} 
## **การเพิ่มกรอบรูปพร้อมการเคลื่อนไหว**
### **ตัวอย่าง VSTO 2008**
โดยใช้ VSTO 2008 ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างงานนำเสนอ
1. เพิ่มสไลด์เปล่า
1. เพิ่มรูปทรงรูปภาพลงในสไลด์
1. ใส่การเคลื่อนไหวให้กับรูปภาพ
1. บันทึกงานนำเสนอลงดิสก์

**งานนำเสนอผลลัพธ์ที่สร้างด้วย VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//สร้างงานนำเสนอเปล่า
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//เพิ่มสไลด์เปล่า
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//เพิ่มกรอบรูป
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//ใส่การเคลื่อนไหวให้กับกรอบรูป
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//บันทึกงานนำเสนอ
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **ตัวอย่าง Aspose.Slides for .NET**
โดยใช้ Aspose.Slides for .NET ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างงานนำเสนอ
1. เข้าถึงสไลด์แรก
1. เพิ่มภาพลงในคอลเลกชันรูปภาพ
1. เพิ่มรูปทรงรูปภาพลงในสไลด์
1. ใส่การเคลื่อนไหวให้กับรูปภาพ
1. บันทึกงานนำเสนอลงดิสก์

**งานนำเสนอผลลัพธ์ที่สร้างด้วย Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
// สร้างงานนำเสนอเปล่า
using (Presentation pres = new Presentation())
{
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.Slides[0];

    // เพิ่มรูปภาพลงในคอลเลกชันรูปภาพของงานนำเสนอ
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // เพิ่มกรอบรูปที่มีความสูงและความกว้างตรงกับความสูงและความกว้างของรูปภาพ
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // ดึงลำดับการเคลื่อนไหวหลักของสไลด์
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // เพิ่มเอฟเฟกต์การเคลื่อนไหว Fly from Left ให้กับกรอบรูป
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // บันทึกงานนำเสนอ
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```