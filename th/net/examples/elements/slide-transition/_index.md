---
title: การเปลี่ยนสไลด์
type: docs
weight: 110
url: /th/net/examples/elements/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- เข้าถึงการเปลี่ยนสไลด์
- ลบการเปลี่ยนสไลด์
- ระยะเวลาในการเปลี่ยน
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ควบคุมการเปลี่ยนสไลด์ใน Aspose.Slides สำหรับ .NET: เพิ่ม, ปรับแต่ง, และจัดลำดับเอฟเฟกต์และระยะเวลา ด้วยตัวอย่าง C# สำหรับงานนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้แสดงวิธีการใช้เอฟเฟกต์การเปลี่ยนสไลด์และการตั้งเวลาใน **Aspose.Slides for .NET**.

## **เพิ่มการเปลี่ยนสไลด์**
ใช้เอฟเฟกต์การเปลี่ยนแบบจางกับสไลด์แรก.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // ใช้การเปลี่ยนแบบจาง.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **เข้าถึงการเปลี่ยนสไลด์**
อ่านประเภทการเปลี่ยนที่กำหนดไว้ในสไลด์ปัจจุบัน.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // เข้าถึงประเภทการเปลี่ยน.
    var type = slide.SlideShowTransition.Type;
}
```

## **ลบการเปลี่ยนสไลด์**
ล้างเอฟเฟกต์การเปลี่ยนใด ๆ โดยตั้งประเภทเป็น `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // ลบการเปลี่ยนโดยตั้งค่าเป็น none.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **ตั้งระยะเวลาในการเปลี่ยน**
ระบุระยะเวลาที่สไลด์จะแสดงก่อนที่จะเปลี่ยนต่อไปโดยอัตโนมัติ.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // ในมิลลิวินาที
}
```