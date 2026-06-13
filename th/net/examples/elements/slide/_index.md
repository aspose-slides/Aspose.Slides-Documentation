---
title: สไลด์
type: docs
weight: 10
url: /th/net/examples/elements/slide/
keywords:
- สไลด์
- เพิ่มสไลด์
- เข้าถึงสไลด์
- ดัชนีสไลด์
- ทำสำเนาสไลด์
- จัดเรียงสไลด์ใหม่
- ลบสไลด์
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ควบคุมสไลด์ใน Aspose.Slides สำหรับ .NET: สร้าง, ทำสำเนา, จัดเรียงใหม่, ปรับขนาด, ตั้งค่าพื้นหลัง, และใช้การเปลี่ยนฉากด้วย C# สำหรับการนำเสนอในรูปแบบ PPT, PPTX และ ODP."
---
บทความนี้ให้ตัวอย่างหลายรายการที่แสดงวิธีการทำงานกับสไลด์โดยใช้ **Aspose.Slides for .NET** คุณจะเรียนรู้วิธีการเพิ่ม, เข้าถึง, ทำสำเนา, จัดเรียงใหม่, และลบสไลด์โดยใช้คลาส `Presentation`.

แต่ละตัวอย่างด้านล่างประกอบด้วยคำอธิบายสั้น ๆ ตามด้วยโค้ดสแนปช็อตใน C#.

## **เพิ่มสไลด์**

เพื่อเพิ่มสไลด์ใหม่ คุณต้องเลือกเค้าโครงก่อน ในตัวอย่างนี้ เราใช้เค้าโครง `Blank` และเพิ่มสไลด์ว่างลงในพรีเซนเทชัน

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // แต่ละสไลด์สร้างจากเค้าโครง ซึ่งเองก็สร้างจากมาสเตอร์สไลด์.
    // ใช้เค้าโครง Blank เพื่อสร้างสไลด์ใหม่.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // เพิ่มสไลด์ว่างใหม่โดยใช้เค้าโครงที่เลือก.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **หมายเหตุ:** เค้าโครงสไลด์แต่ละอันสืบทอดมาจากสไลด์หลัก ซึ่งกำหนดการออกแบบโดยรวมและโครงสร้างของตัวแทนภาพ ตัวอย่างด้านล่างแสดงว่ามาสเตอร์สไลด์และเค้าโครงที่เกี่ยวข้องถูกจัดระเบียบใน PowerPoint อย่างไร

![Master and Layout Relationship](master-layout-slide.png)

## **เข้าถึงสไลด์โดยดัชนี**

คุณสามารถเข้าถึงสไลด์โดยใช้ดัชนีของมัน หรือค้นหาดัชนีของสไลด์ตามอ้างอิง สิ่งนี้มีประโยชน์สำหรับการวนซ้ำหรือแก้ไขสไลด์เฉพาะ

```csharp
static void AccessSlide()
{
    // โดยค่าเริ่มต้น การนำเสนอจะถูกสร้างด้วยสไลด์ว่างหนึ่งสไลด์.
    using var presentation = new Presentation();

    // เพิ่มสไลด์ว่างอีกหนึ่งสไลด์.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // เข้าถึงสไลด์โดยใช้ดัชนี.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // รับดัชนีสไลด์จากการอ้างอิง แล้วเข้าถึงโดยใช้ดัชนี.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **ทำสำเนาสไลด์**

ตัวอย่างนี้สาธิตวิธีทำสำเนาสไลด์ที่มีอยู่ สไลด์ที่ทำสำเนาจะถูกเพิ่มโดยอัตโนมัติไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์

```csharp
static void CloneSlide()
{
    // โดยค่าเริ่มต้น การนำเสนอจะมีสไลด์ว่างหนึ่งสไลด์.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // ทำสำเนาสไลด์แรก; จะถูกเพิ่มที่ตำแหน่งสุดท้ายของการนำเสนอ.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // ดัชนีของสไลด์ที่ทำสำเนาคือ 1 (สไลด์ที่สองในการนำเสนอ).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **จัดเรียงสไลด์ใหม่**

คุณสามารถเปลี่ยนลำดับของสไลด์โดยย้ายสไลด์หนึ่งไปยังดัชนีใหม่ ในกรณีนี้ เราย้ายสไลด์ที่ทำสำเนาไปยังตำแหน่งแรก

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Add a clone of the first slide (created by default).
    // Move the cloned slide to the first position (others shift down).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Move the cloned slide to the first position (others shift down).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **ลบสไลด์**

เพื่อทำการลบสไลด์ เพียงอ้างอิงสไลด์นั้นและเรียก `Remove` ตัวอย่างนี้เพิ่มสไลด์ที่สองแล้วลบสไลด์เดิม ทำให้เหลือเพียงสไลด์ใหม่เท่านั้น

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // เพิ่มสไลด์ว่างใหม่เพิ่มเติมจากสไลด์แรกเริ่มต้น.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // ลบสไลด์แรก; จะเหลือแค่สไลด์ที่เพิ่งเพิ่มไว้เท่านั้น.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```