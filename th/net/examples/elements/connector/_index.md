---
title: คอนเนคเตอร์
type: docs
weight: 190
url: /th/net/examples/elements/connector/
keywords:
- คอนเนคเตอร์
- เพิ่มคอนเนคเตอร์
- เข้าถึงคอนเนคเตอร์
- ลบคอนเนคเตอร์
- เชื่อมต่อรูปร่างใหม่
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม เส้นเชื่อมและกำหนดรูปแบบคอนเนคเตอร์ระหว่างรูปร่างโดยใช้ Aspose.Slides สำหรับ .NET พร้อมตัวอย่าง C# สำหรับการนำเสนอในรูปแบบ PPT, PPTX และ ODP"
---
บทความนี้สาธิตวิธีเชื่อมต่อรูปร่างด้วยคอนเนคเตอร์และเปลี่ยนเป้าหมายของพวกมันโดยใช้ **Aspose.Slides for .NET**.

## **เพิ่มคอนเนคเตอร์**

แทรกรูปร่างคอนเนคเตอร์ระหว่างสองจุดบนสไลด์.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **เข้าถึงคอนเนคเตอร์**

ดึงรูปร่างคอนเนคเตอร์ตัวแรกที่เพิ่มลงในสไลด์.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **ลบคอนเนคเตอร์**

ลบคอนเนคเตอร์ออกจากสไลด์.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **เชื่อมต่อรูปร่างใหม่**

แนบคอนเนคเตอร์กับสองรูปร่างโดยกำหนดเป้าหมายเริ่มต้นและสิ้นสุด.

```csharp
static void ReconnectShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    connector.StartShapeConnectedTo = shape1;
    connector.EndShapeConnectedTo = shape2;
}
```