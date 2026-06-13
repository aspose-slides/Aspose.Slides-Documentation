---
title: สไลด์มาสเตอร์
type: docs
weight: 30
url: /th/net/examples/elements/master-slide/
keywords:
- สไลด์มาสเตอร์
- เพิ่มสไลด์มาสเตอร์
- เข้าถึงสไลด์มาสเตอร์
- ลบสไลด์มาสเตอร์
- สไลด์มาสเตอร์ที่ไม่ได้ใช้
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สำรวจตัวอย่างสไลด์มาสเตอร์ของ Aspose.Slides สำหรับ .NET: สร้าง, แก้ไข, และกำหนดสไตล์มาสเตอร์, ตัวตำแหน่ง, และธีมใน PPT, PPTX, และ ODP ด้วยโค้ด C# ที่ชัดเจน."
---
สไลด์มาสเตอร์อยู่ในระดับบนสุดของลำดับชั้นการสืบทอดสไลด์ใน PowerPoint. **master slide** กำหนดองค์ประกอบการออกแบบทั่วไป เช่น พื้นหลัง, โลโก้, และการจัดรูปแบบข้อความ. **Layout slides** สืบทอดจากสไลด์มาสเตอร์, และ **normal slides** สืบทอดจาก layout slides.

บทความนี้แสดงวิธีการสร้าง, แก้ไข, และจัดการสไลด์มาสเตอร์โดยใช้ Aspose.Slides for .NET.

## **เพิ่มสไลด์มาสเตอร์**

ตัวอย่างนี้แสดงวิธีการสร้างสไลด์มาสเตอร์ใหม่โดยทำสำเนาสตางค์เริ่มต้น. จากนั้นเพิ่มแบนเนอร์ชื่อบริษัทไปยังทุกสไลด์ผ่านการสืบทอด layout.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // คัดลอกสไลด์มาสเตอร์เริ่มต้น.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // เพิ่มแบนเนอร์ชื่อบริษัทที่ด้านบนของสไลด์มาสเตอร์.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // กำหนดสไลด์มาสเตอร์ใหม่ให้กับสไลด์เลเอาต์.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // กำหนดสไลด์เลเอาต์ให้กับสไลด์แรกในงานนำเสนอ.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Note 1:** สไลด์มาสเตอร์ให้วิธีการใช้แบรนด์หรือองค์ประกอบการออกแบบที่สอดคล้องกันทั่วทุกสไลด์. การเปลี่ยนแปลงใด ๆ ที่ทำกับมาสเตอร์จะถูกสะท้อนโดยอัตโนมัติใน layout และสไลด์ปกติที่พึ่งพา.

> 💡 **Note 2:** รูปทรงหรือการจัดรูปแบบใด ๆ ที่เพิ่มลงในสไลด์มาสเตอร์จะถูกสืบทอดโดย layout slides และต่อโดยสไลด์ปกติที่ใช้ layout เหล่านั้น.
> ภาพด้านล่างแสดงตัวอย่างว่ากล่องข้อความที่เพิ่มบนสไลด์มาสเตอร์จะถูกแสดงอัตโนมัติบนสไลด์สุดท้าย.

![ตัวอย่างการสืบทอดมาสเตอร์](master-slide-banner.png)

## **เข้าถึงสไลด์มาสเตอร์**

คุณสามารถเข้าถึงสไลด์มาสเตอร์โดยใช้คอลเลกชัน `Presentation.Masters`. นี่คือวิธีการดึงและทำงานกับพวกมัน:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // เข้าถึงสไลด์มาสเตอร์แรก.
    var firstMasterSlide = presentation.Masters[0];

    // เปลี่ยนประเภทพื้นหลัง.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **ลบสไลด์มาสเตอร์**

สไลด์มาสเตอร์สามารถลบได้โดยใช้ดัชนีหรือโดยอ้างอิง.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // ลบสไลด์มาสเตอร์โดยใช้ดัชนี.
    presentation.Masters.RemoveAt(0);

    // ลบสไลด์มาสเตอร์โดยอ้างอิง.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้งาน**

งานนำเสนอบางส่วนมีสไลด์มาสเตอร์ที่ไม่ได้ใช้งาน. การลบสไลด์เหล่านี้สามารถช่วยลดขนาดไฟล์ได้.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้ทั้งหมด (รวมถึงสไลด์ที่ถูกทำเครื่องหมายเป็น Preserve).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```