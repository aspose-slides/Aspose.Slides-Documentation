---
title: จัดการคอนเนคเตอร์ในงานนำเสนอด้วย .NET
linktitle: คอนเนคเตอร์
type: docs
weight: 10
url: /th/net/connector/
keywords:
- คอนเนคเตอร์
- ชนิดคอนเนคเตอร์
- จุดคอนเนคเตอร์
- เส้นคอนเนคเตอร์
- มุมคอนเนคเตอร์
- จุดเชื่อมต่อ
- จุดปรับค่า
- เชื่อมต่อรูปร่าง
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, แนบ, ปรับเส้นทางใหม่, ปรับค่า, และตรวจสอบคอนเนคเตอร์ PowerPoint แบบตรง, หยัก, และโค้งด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

คอนเนคเตอร์คือเส้นที่สามารถยึดติดกับรูปร่างสองรูปเมื่อรูปร่างใดรูปร่างหนึ่งเคลื่อนที่ จุดเชื่อมต่อปลายของคอนเนคเตอร์ต่อกับตำแหน่งการเชื่อมต่อที่แสดงด้วยจุดสีเขียวใน PowerPoint คอนเนคเตอร์ที่หยักและโค้งบางประเภทยังมีจุดปรับค่าแสดงด้วยจุดสีส้ม ซึ่งควบคุมตำแหน่งของส่วนย่อยของคอนเนคเตอร์แต่ละส่วน.

Aspose.Slides แสดงคอนเนคเตอร์ผ่านอินเตอร์เฟซ [IConnector](https://reference.aspose.com/slides/th/net/aspose.slides/iconnector/) คุณสามารถสร้างคอนเนคเตอร์เหล่านี้ แนบปลายของมันกับรูปร่าง เลือกตำแหน่งการเชื่อมต่อ ปรับเส้นทางใหม่ และแก้ไขเรขาคณิตของคอนเนคเตอร์ที่มีจุดปรับค่าได้.

## **ประเภทคอนเนคเตอร์**

Enumeration [ShapeType](https://reference.aspose.com/slides/th/net/aspose.slides/shapetype/) มีพรีเซ็ตคอนเนคเตอร์แบบตรง, หยัก, และโค้ง ตารางต่อไปนี้แสดงเรขาคณิตของคอนเนคเตอร์ที่มีให้และจำนวนจุดปรับค่าที่กำหนดโดยแต่ละพรีเซ็ต.

| คอนเนคเตอร์ | รูปภาพ | จำนวนจุดปรับค่า |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

จำนวนและความหมายของจุดปรับค่าคือส่วนหนึ่งของพรีเซ็ตคอนเนคเตอร์ที่เลือก อย่าสันนิษฐานว่าชนิดคอนเนคเตอร์สองแบบจะแสดงโครงสร้างคอลเลกชันเดียวกัน.

## **เชื่อมโยงรูปร่างสองรูป**

ใช้ [IShapeCollection.AddConnector](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addconnector/) เพื่อเพิ่มคอนเนคเตอร์และกำหนดคุณสมบัติ [StartShapeConnectedTo](https://reference.aspose.com/slides/th/net/aspose.slides/connector/startshapeconnectedto/) และ [EndShapeConnectedTo](https://reference.aspose.com/slides/th/net/aspose.slides/connector/endshapeconnectedto/) ของมัน หลังจากที่ปลายทั้งสองถูกเชื่อมต่อแล้ว [IConnector.Reroute](https://reference.aspose.com/slides/th/net/aspose.slides/iconnector/reroute/) จะเลือกเส้นทางสั้นระหว่างรูปร่าง.

ตัวอย่างต่อไปนี้เชื่อมต่อรูปวงรีและสี่เหลี่ยมผืนผ้าด้วยคอนเนคเตอร์แบบหยัก:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;
connector.Reroute();

presentation.Save("connected-shapes.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}
การเรียก `Reroute` อาจทำให้ค่า [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/th/net/aspose.slides/connector/startshapeconnectionsiteindex/) และ [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/th/net/aspose.slides/connector/endshapeconnectionsiteindex/) เปลี่ยนแปลง ให้กำหนดตำแหน่งการเชื่อมต่อเฉพาะหลังจากปรับเส้นทางใหม่ หากตำแหน่งเหล่านั้นต้องคงที่.
{{% /alert %}}

## **เลือกตำแหน่งการเชื่อมต่อ**

แต่ละรูปร่างที่สามารถเชื่อมต่อได้รายงานจำนวนตำแหน่งผ่าน [ConnectionSiteCount](https://reference.aspose.com/slides/th/net/aspose.slides/shape/connectionsitecount/). ตรวจสอบดัชนีตำแหน่งฐานศูนย์ที่ต้องการก่อนกำหนดให้กับปลายคอนเนคเตอร์; จำนวนตำแหน่งจะแตกต่างกันตามเรขาคณิตของรูปร่าง.

ตัวอย่างนี้แนบคอนเนคเตอร์ไปยังตำแหน่งเฉพาะบนรูปวงรีเมื่อมีตำแหน่งนั้นอยู่:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;

uint preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse.ConnectionSiteCount)
{
    connector.StartShapeConnectionSiteIndex = preferredSiteIndex;
}
else
{
    Console.WriteLine($"The ellipse has only {ellipse.ConnectionSiteCount} connection sites.");
}

presentation.Save("specific-connection-site.pptx", SaveFormat.Pptx);
```

## **ปรับจุดคอนเนคเตอร์**

คอนเนคเตอร์ที่มีจุดปรับค่าสามารถเข้าถึงได้ผ่าน [IGeometryShape.Adjustments](https://reference.aspose.com/slides/th/net/aspose.slides/igeometryshape/adjustments/). ตรวจสอบทุก [IAdjustValue](https://reference.aspose.com/slides/th/net/aspose.slides/iadjustvalue/) และเช็ก [Type](https://reference.aspose.com/slides/th/net/aspose.slides/adjustvalue/type/) ก่อนเปลี่ยนค่า [RawValue](https://reference.aspose.com/slides/th/net/aspose.slides/adjustvalue/rawvalue/). กฎทั่วไปสำหรับการระบุการปรับรูปพรีเซ็ตอธิบายไว้ใน [Shape Manipulation](/slides/th/net/shape-manipulations/).

จำนวน ลำดับ ความหมาย และช่วงค่าที่ถูกต้องของการปรับค่าคอนเนคเตอร์ขึ้นอยู่กับพรีเซ็ตคอนเนคเตอร์. คุณสมบัติ `Type` เป็นแบบอ่านอย่างเดียว ส่วนค่าการปรับสามารถเขียนได้. คุณสมบัติอ่านอย่างเดียว [Name](https://reference.aspose.com/slides/th/net/aspose.slides/adjustvalue/name/) ให้การระบุเพิ่มเติมเมื่อคอนเนคเตอร์มีการปรับค่ามากกว่าหนึ่งรายการที่มีประเภทเชิงความหมายเดียวกัน.

### **เส้นทางหลีกเลี่ยงอุปสรรค**

ในรูปแบบต่อไปนี้ คอนเนคเตอร์ `BentConnector5` ระหว่างสองรูปร่างจะผ่านรูปร่างที่สาม:

![connector-obstruction](connector-obstruction.png)

โค้ดนี้สร้างคอนเนคเตอร์ที่ถูกบัง:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

presentation.Save("connector-obstruction.pptx", SaveFormat.Pptx);
```

การย้ายการงอแบบแนวตั้งทำให้เส้นทางเปลี่ยนไปเพื่อให้คอนเนคเตอร์หลบอุปสรรค:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

แทนที่จะสันนิษฐานว่าดัชนีคอลเลกชัน `1` แสดงการงอแนวตั้งเสมอ ตัวอย่างนี้จะค้นหา `ConnectorBendPositionY` และเปลี่ยนค่าเฉพาะเมื่อพบประเภทเชิงความหมายที่คาดหวัง:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend is null)
{
    Console.WriteLine("The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend.RawValue = 60000;
    presentation.Save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
}
```

`BentConnector5` มีการปรับค่า `ConnectorBendPositionX` สองรายการและ `ConnectorBendPositionY` หนึ่งรายการ หากประเภทที่คุณต้องการมีหลายรายการ ให้ตรวจสอบ `Name` และเรขาคณิตที่รู้ของพรีเซ็ตก่อนเลือกหนึ่งรายการ หากการปรับค่ารายงานเป็น `ShapeAdjustmentType.Custom` ให้ถือความหมายและช่วงค่าตามพรีเซ็ตนั้นและอย่าเปลี่ยนจนกว่าจะทราบสัญญานั้น.

## **เชื่อมโยงค่าการปรับกับเรขาคณิตของคอนเนคเตอร์**

สำหรับคอนเนคเตอร์แบบหยัก ค่าการปรับสามารถใช้ประมาณตำแหน่งของส่วนย่อยแต่ละส่วน การคำนวณเหล่านี้เฉพาะพรีเซ็ตคอนเนคเตอร์:

- `BentConnector4`โดยทั่วไปจะแสดงการปรับค่า `ConnectorBendPositionX` หนึ่งค่าและ `ConnectorBendPositionY` หนึ่งค่า.
- สำหรับตำแหน่งการงอนี้ `RawValue / 100000f` ให้ส่วนของความกว้างหรือความสูงของเฟรมคอนเนคเตอร์ที่ใช้ในตัวอย่างต่อไปนี้.
- เฟรมของคอนเนคเตอร์สามารถหมุนหรือพลิกได้ ดังนั้นพิกัดเฟรมต้องแปลงก่อนจึงจะเปรียบเทียบกับพิกัดสไลด์.

ตัวอย่างต่อไปนี้ใช้ `Type` เพื่อระบุตัวการปรับค่าเป็นอันดับแรก ไม่ได้ใช้ดัชนีคอลเลกชันเป็นตัวระบุตัวตนที่พกพาได้.

### **คอนเนคเตอร์ที่ไม่ได้หมุน**

รูปแบบเริ่มต้นมีรูปร่างข้อความสองรูปที่เชื่อมต่อด้วย `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

ตัวอย่างนี้ตรวจสอบคอนเนคเตอร์และดึงการปรับค่าองศาแนวนอนและแนวตั้งของการงอ:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
targetShape.TextFrame.Text = "To";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
}
```

เพื่อเปลี่ยนการงอทั้งสอง ค้นหาประเภทที่คาดหวังแต่ละประเภทและแก้ไขค่าเฉพาะหลังจากที่พบทั้งสองแล้ว:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;
    presentation.Save("connector-adjusted.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์คือคอนเนคเตอร์ที่ส่วนแนวนอนและแนวตั้งได้เคลื่อนที่:

![connector-adjusted-1](connector-adjusted-1.png)

เมื่อทราบประเภทเชิงความหมายแล้ว ค่าของมันสามารถแปลงเป็นพิกัดเฟรมคอนเนคเตอร์ได้ ตัวอย่างนี้วาดสี่เหลี่ยมแผ่นบางเหนือส่วนแนวตั้งที่ควบคุมโดยการปรับค่าการงอสองค่า:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    var x = connector.X + connector.Width * horizontalBend.RawValue / 100000f;
    var y = connector.Y;
    var height = connector.Height * verticalBend.RawValue / 100000f;
    slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 1, height);
    presentation.Save("connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

รูปร่างไกด์ทำเครื่องหมายส่วนที่คำนวณได้:

![connector-adjusted-2](connector-adjusted-2.png)

### **คอนเนคเตอร์ที่หมุนหรือพลิก**

เมื่อเรขาคณิตของคอนเนคเตอร์เดียวกันถูกจัดแนวแนวตั้ง ค่า [Frame](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/frame/), [FlipH](https://reference.aspose.com/slides/th/net/aspose.slides/shapeframe/fliph/), และ [FlipV](https://reference.aspose.com/slides/th/net/aspose.slides/shapeframe/flipv/) มีผลต่อการแปลงจากพิกัดเฟรมคอนเนคเตอร์ไปยังพิกัดสไลด์.

ตัวอย่างนี้สร้างและปรับคอนเนคเตอร์ที่จัดแนวแนวตั้ง:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
targetShape.TextFrame.Text = "To 1";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        adjustment.RawValue += 20000;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        adjustment.RawValue += 200000;
    }
}

presentation.Save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
```

คอนเนคเตอร์ที่ปรับแล้วปรากฏเป็นแนวตั้งระหว่างรูปร่าง:

![connector-adjusted-3](connector-adjusted-3.png)

สำหรับมุมการหมุนใด ๆ `alpha` ให้หมุนจุดในเฟรมคอนเนคเตอร์ `(x, y)` รอบศูนย์กลางเฟรม `(x0, y0)` ตามสูตร:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

โค้ดต่อไปนี้จัดการการวางแนว 90 องศาที่ใช้ในตัวอย่างนี้และวาดไกด์สีแดงเหนือส่วนคอนเนคเตอร์ที่สอดคล้องกัน:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;

    var x = connector.X;
    var y = connector.Y;
    if (connector.Frame.FlipH == NullableBool.True)
    {
        x += connector.Width;
    }
    if (connector.Frame.FlipV == NullableBool.True)
    {
        y += connector.Height;
    }

    x += connector.Width * horizontalBend.RawValue / 100000f;
    var rotatedX = connector.Frame.CenterX - y + connector.Frame.CenterY;
    var rotatedY = x - connector.Frame.CenterX + connector.Frame.CenterY;
    var segmentWidth = connector.Height * verticalBend.RawValue / 100000f;
    var guide = slide.Shapes.AddAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    guide.LineFormat.FillFormat.FillType = FillType.Solid;
    guide.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

ไกด์สีแดงทำเครื่องหมายส่วนที่คำนวณหลังจากการแปลงพิกัด:

![connector-adjusted-4](connector-adjusted-4.png)

สูตรเหล่านี้อธิบายพรีเซ็ตที่ใช้ในตัวอย่าง ไม่ได้เป็นโมเดลคอนเนคเตอร์สากล ตรวจสอบประเภทการปรับ, การจัดแนวของเฟรม, และช่วงค่าก่อนนำการคำนวนเดียวกันไปใช้กับพรีเซ็ตอื่น.

## **ค้นหามุมทิศทางของคอนเนคเตอร์**

ทิศทางของคอนเนคเตอร์แบบตรงสามารถคำนวณจากความกว้างและความสูงของมัน โดยคำนึงถึงการพลิกแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้รายงานมุมตามเข็มน時計จากแกนแนวนอนบวกในพิกัดสไลด์:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

var flipH = connector.Frame.FlipH == NullableBool.True;
var flipV = connector.Frame.FlipV == NullableBool.True;
var deltaX = connector.Width * (flipH ? -1 : 1);
var deltaY = connector.Height * (flipV ? -1 : 1);
var angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

if (angle < 0)
{
    angle += 360;
}

Console.WriteLine($"Connector direction: {angle:F2} degrees");
```

## **คำถามที่พบบ่อย**

**ฉันจะรู้ได้อย่างไรรับว่าคอนเนคเตอร์สามารถแนบกับรูปร่างได้หรือไม่?**

ตรวจสอบ `ConnectionSiteCount` ของรูปร่าง จำนวนบวกหมายถึงรูปร่างมีตำแหน่งเชื่อมต่อ ตรวจสอบดัชนีตำแหน่งที่เลือกก่อนกำหนดให้กับปลายคอนเนคเตอร์ใด ๆ.

**ฉันสามารถระบุการปรับค่าคอนเนคเตอร์ด้วยดัชนีคอลเลกชันได้หรือไม่?**

ดัชนีมีความหมายเฉพาะกับพรีเซ็ตคอนเนคเตอร์และโครงสร้างคอลเลกชันที่รู้เท่านั้น ตรวจสอบ `IAdjustValue.Type` ก่อนแก้ค่าหนึ่งค่า และใช้ `IAdjustValue.Name` เป็นข้อมูลเพิ่มเติมเมื่อประเภทเชิงความหมายเดียวกันปรากฏหลายครั้ง.

**เกิดอะไรขึ้นเมื่อรูปร่างที่เชื่อมต่อถูกลบ?**

ปลายคอนเนคเตอร์ที่สัมพันธ์จะถูกแยกออก รูปร่างคอนเนคเตอร์ยังคงอยู่บนสไลด์และสามารถลบได้, ตั้งเป็นเส้นอิสระ, หรือแนบกับรูปร่างอื่น.

**การผูกคอนเนคเตอร์จะถูกเก็บไว้เมื่อทำสำเนาสไลด์หรือไม่?**

การผูกมักจะถูกเก็บไว้เมื่อรูปร่างที่เชื่อมต่อถูกคัดลอกพร้อมสไลด์ หากคอนเนคเตอร์ถูกคัดลอกโดยไม่มีรูปร่างเป้าหมายหนึ่งรูปปลายที่ได้รับผลกระทบต้องถูกแนบใหม่.