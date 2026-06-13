---
title: Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for .NET 15.4.0
linktitle: Aspose.Slides for .NET 15.4.0
type: docs
weight: 150
url: /th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- การย้ายข้อมูล
- โค้ดเดิม
- โค้ดสมัยใหม่
- วิธีการเดิม
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้เกิดความไม่เข้ากันใน Aspose.Slides for .NET เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, วิธีการ, คุณสมบัติ และอื่น ๆ ที่[added](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) หรือ[removed](/slides/th/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) พร้อมกับการเปลี่ยนแปลงอื่น ๆ ที่แนะนำใน Aspose.Slides for .NET 15.4.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
#### **Enum OrganizationChartLayoutType ถูกเพิ่ม**
enum Aspose.Slides.SmartArt.OrganizationChartLayoutType แสดงประเภทการจัดรูปแบบของโหนดลูกในแผนภูมิองค์กร.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts ถูกเพิ่ม**
Method Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts ตั้งค่าการเลื่อนค่าเริ่มต้นที่ไม่เป็นศูนย์สำหรับ Indent ย่อหน้าและ MarginLeft ที่มีผลเมื่อเปิดใช้งานหัวข้อย่อย (เช่น PowerPoint ทำเมื่อเปิดใช้งานหัวข้อย่อย/การนับเลขในย่อหน้า) หากปิดใช้งานหัวข้อย่อยจะรีเซ็ต Indent และ MarginLeft ของย่อหน้า (เช่น PowerPoint ทำเมื่อปิดการใช้งานหัวข้อย่อย/การนับเลขในย่อหน้า).  
ดูตัวอย่าง[ที่นี่](/slides/th/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Method IConnector.Reroute ถูกเพิ่ม**
Method Aspose.Slides.IConnector.Reroute ทำการกำหนดเส้นเชื่อมใหม่เพื่อให้เส้นเชื่อมใช้เส้นทางที่สั้นที่สุดระหว่างรูปร่างที่เชื่อมต่อกัน เพื่อทำเช่นนี้เมธอด Reroute() อาจเปลี่ยนค่า StartShapeConnectionSiteIndex และ EndShapeConnectionSiteIndex.

``` csharp

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
Method Aspose.Slides.IPresentation.GetSlideById(System.UInt32) ส่งคืน Slide, MasterSlide หรือ LayoutSlide ตาม slide Id.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Property IShape.ConnectionSiteCount ถูกเพิ่ม**
Property Aspose.Slides.IShape.ConnectionSiteCount ส่งคืนจำนวนจุดเชื่อมต่อบนรูปร่าง.

``` csharp

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
Property Aspose.Slides.SmartArt.ISmartArt.IsReversed ให้การเรียกหรือกำหนดสถานะของแผนภาพ SmartArt ว่าเป็น (จากซ้ายไปขวา) LTR หรือ (จากขวาไปซ้าย) RTL หากแผนภาพรองรับการกลับด้าน.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.Nodes ถูกเพิ่ม**
Property Aspose.Slides.SmartArt.ISmartArt.Nodes ส่งคืนคอลเลกชันของโหนดรากในออบเจ็กต์ SmartArt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // เลือกโหนดรากที่สอง

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.IsHidden ถูกเพิ่ม**
Property Aspose.Slides.SmartArt.ISmartArtNode.IsHidden ส่งคืนค่า true หากโหนดนี้เป็นโหนดที่ซ่อนอยู่ในโมเดลข้อมูล.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //คืนค่า true

  if(hidden)

  {

    //ทำการดำเนินการหรือแจ้งเตือน

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.OrganizationChartLayout ถูกเพิ่ม**
Property Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout ให้การเรียกหรือกำหนดประเภทแผนภูมิองค์กรที่สัมพันธ์กับโหนดปัจจุบัน.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Set Method for Property ISmartArt.Layout ถูกเพิ่ม**
เมธอด set สำหรับ property Aspose.Slides.SmartArt.ISmartArt.Layout ถูกเพิ่ม. มันอนุญาตให้เปลี่ยนประเภท layout ของแผนภาพที่มีอยู่.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **การเปลี่ยนแปลง Minor API**
**นี่คือรายการการเปลี่ยนแปลง Minor API:**

|Enum Aspose.Slides.BevelColorMode |ถูกลบ, ไม่ได้ใช้ enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |ถูกลบ, ไม่ได้ใช้ property |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |เพิ่ม |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |ถูกลบ |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |ลบ เนื่องจากเลิกใช้ |