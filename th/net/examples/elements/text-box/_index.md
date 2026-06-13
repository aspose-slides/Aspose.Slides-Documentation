---
title: กล่องข้อความ
type: docs
weight: 40
url: /th/net/examples/elements/text-box/
keywords:
- กล่องข้อความ
- เพิ่มกล่องข้อความ
- เข้าถึงกล่องข้อความ
- ลบกล่องข้อความ
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำงานกับกล่องข้อความใน Aspose.Slides สำหรับ .NET: เพิ่ม, จัดรูปแบบ, จัดแนว, ทำการห่อข้อความ, ปรับขนาดอัตโนมัติ, และสไตล์ข้อความโดยใช้ C# สำหรับการนำเสนอ PPT, PPTX, และ ODP."
---
ใน Aspose.Slides, **กล่องข้อความ** จะถูกแทนด้วย `AutoShape`. เกือบทุกรูปทรงสามารถบรรจุข้อความได้, แต่กล่องข้อความทั่วไปไม่มีสีเติมหรือกรอบและจะแสดงข้อความเท่านั้น.

คู่มือนี้อธิบายวิธีการเพิ่ม, เข้าถึงและลบกล่องข้อความโดยใช้โปรแกรม.

## **เพิ่มกล่องข้อความ**

กล่องข้อความคือ `AutoShape` ธรรมดาที่ไม่มีการเติมสีหรือกรอบและมีข้อความที่จัดรูปแบบบางส่วน นี่คือตัวอย่างการสร้างหนึ่งกล่องข้อความ:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // สร้างรูปสี่เหลี่ยม (ค่าเริ่มต้นคือเติมสีพร้อมกรอบและไม่มีข้อความ).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // ลบการเติมสีและกรอบเพื่อให้ดูเหมือนกล่องข้อความทั่วไป.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // ตั้งค่าการจัดรูปแบบข้อความ.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // กำหนดเนื้อหาข้อความจริง.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **หมายเหตุ:** `AutoShape` ใด ๆ ที่มี `TextFrame` ไม่ว่างเปล่าสามารถทำหน้าที่เป็นกล่องข้อความได้.

## **เข้าถึงกล่องข้อความตามเนื้อหา**

เพื่อค้นหากล่องข้อความทั้งหมดที่มีคีย์เวิร์ดเฉพาะ (เช่น "Slide") ให้วนลูปผ่านรูปทรงและตรวจสอบข้อความของพวกมัน:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // เฉพาะ AutoShape เท่านั้นที่สามารถบรรจุข้อความที่แก้ไขได้.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // ทำบางอย่างกับกล่องข้อความที่ตรงกัน.
            }
        }
    }
}
```

## **ลบกล่องข้อความตามเนื้อหา**

ตัวอย่างนี้จะค้นหาและลบกล่องข้อความทั้งหมดบนสไลด์แรกที่มีคีย์เวิร์ดเฉพาะ:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **เคล็ดลับ:** ควรสร้างสำเนาของชุดรูปทรงเสมอก่อนที่จะทำการแก้ไขในระหว่างการวนลูปเพื่อหลีกเลี่ยงข้อผิดพลาดจากการแก้ไขคอลเล็กชัน.