---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 14.9.0
linktitle: Aspose.Slides สำหรับ .NET 14.9.0
type: docs
weight: 110
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- การย้ายข้อมูล
- โค้ดเก่า
- โค้ดสมัยใหม่
- แนวทางเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดความขัดแย้งใน Aspose.Slides สำหรับ .NET เพื่อการย้ายข้อมูล PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น"
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่[เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)หรือ[ลบ](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)และการเปลี่ยนแปลงอื่น ๆ ที่นำเข้ามาใน Aspose.Slides for .NET 14.9.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **Inheritance from ICollection and Generic IEnumerable Interfaces Added to ISmartArtNodeCollection**
การสืบทอดจาก ICollection และ Generic IEnumerable Interfaces ถูกเพิ่มเข้าไปใน ISmartArtNodeCollection
The class Aspose.Slides.SmartArt.SmartArtNodeCollection (and the related interface Aspose.Slides.SmartArt.ISmartArtNodeCollection) inherit the generic interface IEnumerable<ISmartArtNode> and interface ICollection.
#### **SmartArtLayoutType.Custom Enum Value Added**
ค่า Enum SmartArtLayoutType.Custom ถูกเพิ่ม
The Custom SmartArt layout type represents a diagram with a custom template. Custom diagrams can only be loaded from a presentation file and can't be created via the ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) method.
#### **SmartArtShape Class and ISmartArtShape Interface Added**
คลาส SmartArtShape และ Interface ISmartArtShape ถูกเพิ่ม
The Aspose.Slides.SmartArt.SmartArtShape class (and its interface Aspose.Slides.SmartArt.ISmartArtShape) give access to individual shapes in a SmartArt diagram. SmartArtShape can be used to change FillFormat, LineFormat, adding Hyperlinks and other tasks.

{{% alert color="info" %}} 

**หมายเหตุ**: SmartArtShape ไม่สนับสนุนคุณสมบัติของ IShape ได้แก่ RawFrame, Frame, Rotation, X, Y, Width, Height และจะโยน System.NotSupportedException เมื่อพยายามเข้าถึง

Example of usage:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **SmartArtShapeCollection Class, ISmartArtShapeCollection Interface and ISmartArtNode.Shapes Property Added**
คลาส SmartArtShapeCollection, Interface ISmartArtShapeCollection และ Property ISmartArtNode.Shapes ถูกเพิ่ม
The Aspose.Slides.SmartArt.SmartArtShapeCollection class (and its interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) add access to individual shapes in a SmartArt diagram. The collection contains shapes associated with SmartArtNode. The SmartArtNode.Shapes property returns collections of all shapes associated with the node.

{{% alert color="info" %}} 

**หมายเหตุ**: ขึ้นอยู่กับ SmartArtLayoutType รูปแบบ SmartArtShape หนึ่งอาจถูกแชร์ระหว่างหลาย node.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **Methods for Saving Slides with Page Numbers Keeping Added**
เมธอดสำหรับบันทึกสไลด์พร้อมหมายเลขหน้า ที่ถูกเพิ่ม
The following methods have been added:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

These methods allow developers to save specified presentation slides to PDF, XPS, TIFF, HTML formats. The 'slides' array is used to specify page numbers, starting from 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //อาร์เรย์ของตำแหน่งสไลด์

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **Methods for Replacing Images Added to PPImage, IPPImage**
เมธอดสำหรับแทนที่รูปภาพที่เพิ่มเข้ามาใน PPImage, IPPImage
New methods added:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //วิธีแรก

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //วิธีที่สอง

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //วิธีที่สาม

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```