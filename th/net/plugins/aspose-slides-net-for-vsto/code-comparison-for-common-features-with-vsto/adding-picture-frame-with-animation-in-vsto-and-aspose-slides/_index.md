---
title: การเพิ่มกรอบรูปพร้อมการเคลื่อนไหวใน VSTO และ Aspose.Slides
type: docs
weight: 20
url: /th/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
ตัวอย่างโค้ดด้านล่างสร้างพรีเซนเทชันพร้อมสไลด์, เพิ่มรูปภาพด้วยกรอบรูปและใส่การเคลื่อนไหวให้กับมัน.
## **VSTO**
โดยใช้ VSTO ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างพรีเซนเทชัน.
1. เพิ่มสไลด์เปล่า.
1. เพิ่มรูปภาพรูปทรงลงในสไลด์.
1. ใส่การเคลื่อนไหวให้รูปภาพ.
1. บันทึกพรีเซนเทชันลงดิสก์.

``` csharp

 //สร้างพรีเซนเทชันเปล่า

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//เพิ่มสไลด์เปล่า

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//เพิ่มกรอบรูป

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//ใส่การเคลื่อนไหวบนกรอบรูป

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//บันทึกพรีเซนเทชัน

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
โดยใช้ Aspose.Slides สำหรับ .NET ทำตามขั้นตอนต่อไปนี้:

1. สร้างพรีเซนเทชัน.
1. เข้าถึงสไลด์แรก.
1. เพิ่มรูปภาพลงในคอลเลกชันรูปภาพ.
1. เพิ่มรูปภาพรูปทรงลงในสไลด์.
1. ใส่การเคลื่อนไหวให้รูปภาพ.
1. บันทึกพรีเซนเทชันลงดิสก์.

``` csharp

 //Creating empty presentation
 //สร้างพรีเซนเทชันเปล่า

Presentation pres = new Presentation();

//Accessing the First slide
//เข้าถึงสไลด์แรก

Slide slide = pres.GetSlideByPosition(1);

//Adding the picture object to pictures collection of the presentation
//เพิ่มวัตถุรูปภาพไปยังคอลเลกชันรูปภาพของพรีเซนเทชัน

Picture pic = new Picture(pres, "pic.jpeg");

//After the picture object is added, the picture is given a uniqe picture Id
//หลังจากเพิ่มวัตถุรูปภาพแล้ว รูปภาพจะได้รับรหัสรูปภาพที่ไม่ซ้ำ

int picId = pres.Pictures.Add(pic);

//Adding Picture Frame
//เพิ่มกรอบรูป

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Applying animation on picture frame
//ใส่การเคลื่อนไหวบนกรอบรูป

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Saving Presentation
//บันทึกพรีเซนเทชัน

pres.Write("AsposeAnim.ppt");

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)