---
title: ไฮเปอร์ลิงก์
type: docs
weight: 130
url: /th/net/examples/elements/hyperlink/
keywords:
- ไฮเปอร์ลิงก์
- เพิ่มไฮเปอร์ลิงก์
- เข้าถึงไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เพิ่มและจัดการไฮเปอร์ลิงก์ใน Aspose.Slides for .NET: ลิงก์ข้อความ, รูปร่าง, และภาพ, ตั้งค่าเป้าหมายและการกระทำสำหรับ PPT, PPTX, และ ODP พร้อมตัวอย่าง C#."
---
บทความนี้แสดงการเพิ่ม, เข้าถึง, ลบและอัปเดตไฮเปอร์ลิงก์บนรูปทรงโดยใช้ **Aspose.Slides for .NET**.

## **เพิ่มไฮเปอร์ลิงก์**

สร้างรูปสี่เหลี่ยมโดยมีไฮเปอร์ลิงก์ชี้ไปยังเว็บไซต์ภายนอก.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **เข้าถึงไฮเปอร์ลิงก์**

อ่านข้อมูลไฮเปอร์ลิงก์จากส่วนข้อความของรูป.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **ลบไฮเปอร์ลิงก์**

ลบไฮเปอร์ลิงก์ออกจากข้อความของรูป.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **อัปเดตไฮเปอร์ลิงก์**

เปลี่ยนเป้าหมายของไฮเปอร์ลิงก์ที่มีอยู่ ใช้ `HyperlinkManager` เพื่อแก้ไขข้อความที่มีไฮเปอร์ลิงก์อยู่แล้ว ซึ่งเลียนแบบวิธีที่ PowerPoint อัปเดตไฮเปอร์ลิงก์อย่างปลอดภัย.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // การเปลี่ยนไฮเปอร์ลิงก์ในข้อความที่มีอยู่ควรทำผ่าน
    // HyperlinkManager แทนการตั้งค่าคุณสมบัติโดยตรง.
    // นี้เลียนแบบวิธีที่ PowerPoint ปรับปรุงไฮเปอร์ลิงก์อย่างปลอดภัย.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```