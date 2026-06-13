---
title: การเคลื่อนไหว
type: docs
weight: 100
url: /th/net/examples/elements/animation/
keywords:
- การเคลื่อนไหว
- เพิ่มการเคลื่อนไหว
- เข้าถึงการเคลื่อนไหว
- ลบการเคลื่อนไหว
- ลำดับการเคลื่อนไหว
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สำรวจตัวอย่างการเคลื่อนไหวของ Aspose.Slides for .NET: เพิ่ม, จัดลำดับ, และปรับแต่งเอฟเฟกต์และการเปลี่ยนภาพด้วย C# สำหรับงานนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีสร้างการเคลื่อนไหวแบบง่ายและจัดการลำดับของมันโดยใช้ **Aspose.Slides for .NET**.

## **เพิ่มการเคลื่อนไหว**

สร้างรูปร่างสี่เหลี่ยมและใช้เอฟเฟกต์ค่อยหายที่ทำงานเมื่อคลิก.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // เอฟเฟกต์ค่อยหาย
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **เข้าถึงการเคลื่อนไหว**

ดึงเอฟเฟกต์การเคลื่อนไหวแรกจากไทม์ไลน์ของสไลด์.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // เข้าถึงเอฟเฟกต์การเคลื่อนไหวแรก
    var effect = slide.Timeline.MainSequence[0];
}
```

## **ลบการเคลื่อนไหว**

ลบเอฟเฟ็กต์การเคลื่อนไหวออกจากลำดับ.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // ลบเอฟเฟกต์.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **จัดลำดับการเคลื่อนไหว**

เพิ่มเอฟเฟ็กต์หลายรายการและแสดงลำดับที่การเคลื่อนไหวเกิดขึ้น.

```csharp
static void SequenceAnimations()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

    var sequence = slide.Timeline.MainSequence;
    sequence.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    sequence.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```