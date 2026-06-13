---
title: หมึก
type: docs
weight: 180
url: /th/net/examples/elements/ink/
keywords:
- หมึก
- เข้าถึงหมึก
- ลบหมึก
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำงานกับหมึกใน Aspose.Slides for .NET: วาด, นำเข้า, และแก้ไขเส้น, ปรับสีและความกว้าง, และส่งออกเป็น PPT, PPTX, และ ODP ด้วยตัวอย่าง C#."
---
บทความนี้ให้ตัวอย่างของการเข้าถึงรูปร่างหมึกที่มีอยู่และการลบรูปร่างเหล่านั้นโดยใช้ **Aspose.Slides for .NET**.

> ❗ **หมายเหตุ:** รูปร่างหมึกแสดงถึงอินพุตของผู้ใช้จากอุปกรณ์เฉพาะทาง. Aspose.Slides ไม่สามารถสร้างเส้นหมึกใหม่โดยโปรแกรมได้, แต่คุณสามารถอ่านและแก้ไขหมึกที่มีอยู่ได้.

## **เข้าถึงหมึก**

อ่านแท็กจากรูปร่างหมึกแรกบนสไลด์.

```csharp
static void AccessInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes[0] is Ink inkShape)
    {
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            // ใช้ tagName ตามต้องการ.
        }
    }
}
```

## **ลบหมึก**

ลบรูปร่างหมึกออกจากสไลด์หากมีอยู่.

```csharp
static void RemoveInk()
{
    using var presentation = new Presentation("ink.pptx");
    var slide = presentation.Slides[0];

    if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
    {
        slide.Shapes.Remove(ink);
    }
}
```