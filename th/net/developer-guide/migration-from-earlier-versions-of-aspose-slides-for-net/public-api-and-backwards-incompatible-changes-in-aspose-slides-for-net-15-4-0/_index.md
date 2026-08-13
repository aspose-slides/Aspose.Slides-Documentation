---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ .NET 15.4.0
linktitle: Aspose.Slides สำหรับ .NET 15.4.0
type: docs
weight: 150
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- การย้ายข้อมูล
- โค้ดเก่า
- โค้ดสมัยใหม่
- วิธีการเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้ความเข้ากันไม่ได้ใน Aspose.Slides สำหรับ .NET เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, โปรพอร์ตี้ ฯลฯ ที่ถูก [เพิ่ม](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) หรือ [ลบ](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) รวมถึงการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 15.4.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **Enum OrganizationChartLayoutType ถูกเพิ่ม**
Enum Aspose.Slides.SmartArt.OrganizationChartLayoutType แสดงประเภทการจัดรูปแบบของโหนดลูกในแผนผังองค์กร.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts ถูกเพิ่ม**
เมธอด Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts กำหนดการเลื่อนค่าเริ่มต้นที่ไม่เป็นศูนย์สำหรับ Indent ของย่อหน้าและ MarginLeft เมื่อเปิดใช้งาน bullet (เช่น PowerPoint ทำเมื่อเปิดการจัด bullet/numbering ของย่อหน้า) หาก bullet ถูกปิดใช้งานจะทำการรีเซ็ตค่า Indent ของย่อหน้าและ MarginLeft เท่านั้น (เช่น PowerPoint ทำเมื่อปิดการจัด bullet/numbering ของย่อหน้า).
ดูตัวอย่าง [ที่นี่](/slides/th/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Method IConnector.Reroute ถูกเพิ่ม**
เมธอด Aspose.Slides.IConnector.Reroute จะทำการปรับเส้นเชื่อมใหม่เพื่อให้เส้นเชื่อมใช้เส้นทางที่สั้นที่สุดระหว่างรูปร่างที่เชื่อมต่อกัน ในการทำเช่นนี้ เมธอด Reroute() อาจเปลี่ยนค่า StartShapeConnectionSiteIndex และ EndShapeConnectionSiteIndex.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}
``` 
#### **Method IPresentation.GetSlideById ถูกเพิ่ม**
เมธอด Aspose.Slides.IPresentation.GetSlideById(System.UInt32) จะคืนค่า Slide, MasterSlide หรือ LayoutSlide ตาม Id ของสไลด์.

``` csharp
using System.Diagnostics;
using Aspose.Slides;


 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}
``` 
#### **Property IShape.ConnectionSiteCount ถูกเพิ่ม**
พรอพเตอร์ี Aspose.Slides.IShape.ConnectionSiteCount คืนค่าจำนวนจุดเชื่อมต่อบนรูปร่าง.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArt.IsReversed ถูกเพิ่ม**
พรอพเตอร์ี Aspose.Slides.SmartArt.ISmartArt.IsReversed ให้สามารถรับหรือกำหนดสถานะของแผนภาพ SmartArt ว่าเป็น (ซ้ายไปขวา) LTR หรือ (ขวาไปซ้าย) RTL หากแผนภาพรองรับการกลับทิศ.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArt.Nodes ถูกเพิ่ม**
พรอพเตอร์ี Aspose.Slides.SmartArt.ISmartArt.Nodes คืนค่าคอลเลกชันของโหนดรากในอ็อบเจกต์ SmartArt.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // เลือกโหนดรากที่สอง

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.IsHidden ถูกเพิ่ม**
พรอพเตอร์ี Aspose.Slides.SmartArt.ISmartArtNode.IsHidden คืนค่า true หากโหนดนี้เป็นโหนดที่ซ่อนอยู่ในโมเดลข้อมูล.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //คืนค่า true

  if(hidden)

  {

    //ทำบางอย่างหรือแจ้งเตือน

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.OrganizationChartLayout ถูกเพิ่ม**
พรอพเตอร์ี Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout ให้สามารถรับหรือกำหนดประเภทแผนผังองค์กรที่เชื่อมโยงกับโหนดปัจจุบัน.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **เมธอด Set สำหรับ Property ISmartArt.Layout ถูกเพิ่ม**
เมธอด set สำหรับพรอพเตอร์ี Aspose.Slides.SmartArt.ISmartArt.Layout ได้ถูกเพิ่มเข้ามา ซึ่งทำให้สามารถเปลี่ยนประเภทเลย์เอาต์ของแผนภาพที่มีอยู่ได้

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **การเปลี่ยนแปลง Minor API**
**นี่คือรายการของการเปลี่ยนแปลง Minor API:**

|Enum Aspose.Slides.BevelColorMode |ลบ, enum ที่ไม่ได้ใช้ |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |ลบ, property ที่ไม่ได้ใช้ |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |เพิ่ม |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |ลบ |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |ลบเนื่องจากเป็น obsolete |