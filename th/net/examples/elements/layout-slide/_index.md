---
title: "สไลด์เค้าโครง"
type: docs
weight: 20
url: /th/net/examples/elements/layout-slide/
keywords:
- "สไลด์เค้าโครง"
- "เพิ่มสไลด์เค้าโครง"
- "เข้าถึงสไลด์เค้าโครง"
- "ลบสไลด์เค้าโครง"
- "สไลด์เค้าโครงที่ไม่ได้ใช้"
- "คัดลอกสไลด์เค้าโครง"
- "ตัวอย่างโค้ด"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "ควบคุมสไลด์เค้าโครงใน Aspose.Slides สำหรับ .NET: เลือก, นำไปใช้, และปรับแต่งเค้าโครงสไลด์, ตัวแสดงตำแหน่ง, และแม่แบบด้วยตัวอย่าง C# สำหรับการนำเสนอ PPT, PPTX, และ ODP"
---
บทความนี้สาธิตวิธีการทำงานกับ **Layout Slides** ใน Aspose.Slides สำหรับ .NET. Layout slide กำหนดการออกแบบและการจัดรูปแบบที่สไลด์ปกติสืบทอดมา คุณสามารถเพิ่ม, เข้าถึง, คัดลอก, และลบ layout slides, รวมถึงทำความสะอาดที่ไม่ได้ใช้เพื่อลดขนาดการนำเสนอได้。

## **เพิ่ม Layout Slide**

คุณสามารถสร้าง layout slide แบบกำหนดเองเพื่อกำหนดการจัดรูปแบบที่สามารถนำกลับมาใช้ได้ ตัวอย่างเช่น คุณอาจเพิ่มกล่องข้อความที่ปรากฏบนสไลด์ทั้งหมดโดยใช้เลเอาต์นี้。

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // สร้างสไลด์เค้าโครงที่มีประเภทเค้าโครงเปล่าและชื่อแบบกำหนดเอง.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // เพิ่มกล่องข้อความลงในสไลด์เค้าโครง.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // เพิ่มสไลด์สองสไลด์โดยใช้เค้าโครงนี้; ทั้งสองจะสืบทอดข้อความจากเค้าโครง.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **หมายเหตุ 1:** Layout slides ทำหน้าที่เป็นเทมเพลตสำหรับสไลด์แต่ละอัน คุณสามารถกำหนดองค์ประกอบทั่วไปเพียงครั้งเดียวและนำกลับมาใช้หลายสไลด์ได้。

> 💡 **หมายเหตุ 2:** เมื่อคุณเพิ่มรูปทรงหรือข้อความลงใน layout slide สไลด์ทั้งหมดที่อิงจากเลเอาต์นั้นจะแสดงเนื้อหาร่วมกันนี้โดยอัตโนมัติ。  
> ภาพหน้าจอด้านล่างแสดงสไลด์สองสไลด์ที่แต่ละสไลด์สืบทอดกล่องข้อความจาก layout slide เดียวกัน。

![Slides Inheriting Layout Content](layout-slide-result.png)

## **เข้าถึง Layout Slide**

สามารถเข้าถึง Layout slides โดยใช้ดัชนีหรือโดยประเภทของเลเอาต์ (เช่น `Blank`, `Title`, `SectionHeader` เป็นต้น)。

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // เข้าถึงสไลด์เค้าโครงโดยดัชนี.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // เข้าถึงสไลด์เค้าโครงโดยประเภท.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **ลบ Layout Slide**

คุณสามารถลบ layout slide เฉพาะที่ไม่จำเป็นต้องใช้แล้วได้。

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // รับสไลด์เค้าโครงโดยประเภทแล้วลบออก.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **ลบ Layout Slides ที่ไม่ใช้**

เพื่อลดขนาดการนำเสนอ คุณอาจต้องการลบ layout slides ที่ไม่มีสไลด์ปกติใดใช้。

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // ลบสไลด์เค้าโครงทั้งหมดที่ไม่ได้อ้างอิงโดยสไลด์ใดๆโดยอัตโนมัติ.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **คัดลอก Layout Slide**

คุณสามารถทำซ้ำ layout slide โดยใช้เมธอด `AddClone`。

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // รับสไลด์เค้าโครงที่มีอยู่โดยประเภท.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // คัดลอกสไลด์เค้าโครงไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์เค้าโครง.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **สรุป:** Layout slides เป็นเครื่องมือที่ทรงพลังสำหรับการจัดการการจัดรูปแบบที่สอดคล้องกันระหว่างสไลด์ Aspose.Slides ให้การควบคุมเต็มรูปแบบในการสร้าง, จัดการ, และเพิ่มประสิทธิภาพของ layout slides.