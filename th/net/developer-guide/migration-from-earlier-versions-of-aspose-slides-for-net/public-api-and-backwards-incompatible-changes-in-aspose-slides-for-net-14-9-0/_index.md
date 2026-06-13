---
title: Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for .NET 14.9.0
linktitle: Aspose.Slides สำหรับ .NET 14.9.0
type: docs
weight: 110
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- การย้ายข้อมูล
- โค้ดเดิม
- โค้ดสมัยใหม่
- วิธีการแบบเดิม
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทบทวนการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้แตกหักใน Aspose.Slides for .NET เพื่อการย้ายโซลูชันงานนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายชื่อคลาส, เมธอด, คุณสมบัติ ฯลฯ ทั้งหมดที่ [เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) หรือ [ลบ](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 14.9.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **การสืบทอดจาก ICollection และ Generic IEnumerable Interfaces ที่เพิ่มให้กับ ISmartArtNodeCollection**
คลาส Aspose.Slides.SmartArt.SmartArtNodeCollection (และอินเทอร์เฟซที่เกี่ยวข้อง Aspose.Slides.SmartArt.ISmartArtNodeCollection) สืบทอดอินเทอร์เฟซทั่วไป IEnumerable<ISmartArtNode> และอินเทอร์เฟซ ICollection.
#### **เพิ่มค่า Enum SmartArtLayoutType.Custom**
ประเภทเลเอาต์ SmartArt แบบ Custom แทนแผนภาพที่มีเทมเพลตแบบกำหนดเอง แผนภาพ Custom สามารถโหลดได้เฉพาะจากไฟล์พรีเซนเทชันและไม่สามารถสร้างได้ผ่านเมธอด ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **เพิ่มคลาส SmartArtShape และอินเทอร์เฟซ ISmartArtShape**
คลาส Aspose.Slides.SmartArt.SmartArtShape (และอินเทอร์เฟซ Aspose.Slides.SmartArt.ISmartArtShape) ให้การเข้าถึงรูปทรงบุคคลละในแผนภาพ SmartArt สามารถใช้ SmartArtShape เพื่อเปลี่ยน FillFormat, LineFormat, เพิ่ม Hyperlinks และงานอื่น ๆ

{{% alert color="primary" %}} 

**หมายเหตุ**: SmartArtShape ไม่รองรับคุณสมบัติ IShape ได้แก่ RawFrame, Frame, Rotation, X, Y, Width, Height และจะทำให้เกิด System.NotSupportedException เมื่อพยายามเข้าถึง

ตัวอย่างการใช้งาน:

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **เพิ่มคลาส SmartArtShapeCollection, อินเทอร์เฟซ ISmartArtShapeCollection และคุณสมบัติ ISmartArtNode.Shapes**
คลาส Aspose.Slides.SmartArt.SmartArtShapeCollection (และอินเทอร์เฟซ Aspose.Slides.SmartArt.ISmartArtShapeCollection) ให้การเข้าถึงรูปทรงบุคคลละในแผนภาพ SmartArt คอลเลกชันนี้บรรจุรูปทรงที่เชื่อมโยงกับ SmartArtNode คุณสมบัติ SmartArtNode.Shapes คืนค่าคอลเลกชันของรูปทรงทั้งหมดที่เชื่อมโยงกับโหนดนั้น

{{% alert color="primary" %}} 

**หมายเหตุ**: ขึ้นอยู่กับ SmartArtLayoutType รูปทรง SmartArtShape หนึ่งอาจถูกใช้ร่วมกันระหว่างหลายโหนด

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **เพิ่มเมธอดสำหรับบันทึกสไลด์โดยคงหมายเลขหน้า**
มีการเพิ่มเมธอดต่อไปนี้:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

เมธอดเหล่านี้ช่วยให้นักพัฒนาสามารถบันทึกสไลด์ของพรีเซนเทชันที่ระบุเป็นไฟล์ PDF, XPS, TIFF, HTML ได้ อาร์เรย์ 'slides' ใช้ระบุหมายเลขหน้าโดยเริ่มจาก 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);
int[] slides = new int[] { 2, 3, 5 }; //อาร์เรย์ของตำแหน่งสไลด์
presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **เพิ่มเมธอดสำหรับการแทนที่ภาพใน PPImage, IPPImage**
มีเมธอดใหม่ที่เพิ่มเข้ามา:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);
//วิธีที่ 1

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);
//วิธีที่ 2

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);
//วิธีที่ 3

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```