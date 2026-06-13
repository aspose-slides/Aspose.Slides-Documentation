---
title: กลุ่มรูปทรง
type: docs
weight: 170
url: /th/net/examples/elements/group-shape/
keywords:
  - กลุ่ม
  - เพิ่มกลุ่มรูปทรง
  - เข้าถึงกลุ่มรูปทรง
  - ลบกลุ่มรูปทรง
  - แยกกลุ่มรูปทรง
  - ตัวอย่างโค้ด
  - PowerPoint
  - OpenDocument
  - การนำเสนอ
  - .NET
  - C#
  - Aspose.Slides
description: "จัดการรูปทรงที่กลุ่มใน Aspose.Slides for .NET: สร้าง, ซ้อน, จัดตำแหน่ง, จัดลำดับใหม่, และปรับสไตล์กลุ่มรูปทรงด้วยตัวอย่าง C# ในการนำเสนอ PPT, PPTX และ ODP"
---
ตัวอย่างการสร้างกลุ่มของรูปร่าง การเข้าถึง การแยกกลุ่ม และการลบด้วย **Aspose.Slides for .NET**.

## **เพิ่ม Group Shape**

สร้างกลุ่มที่มีรูปร่างพื้นฐานสองรูป

```csharp
static void AddGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```

## **เข้าถึง Group Shape**

รับ Group Shape แรกจากสไลด์

```csharp
static void AccessGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```

## **ลบ Group Shape**

ลบ Group Shape จากสไลด์

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **แยกกลุ่ม Shapes**

ย้ายรูปร่างออกจากคอนเทนเนอร์กลุ่ม

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // ย้ายรูปออกจากกลุ่ม.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```