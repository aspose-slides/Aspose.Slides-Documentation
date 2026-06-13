---
title: SmartArt
type: docs
weight: 140
url: /th/net/examples/elements/smart-art/
keywords:
- SmartArt
- เพิ่ม SmartArt
- เข้าถึง SmartArt
- ลบ SmartArt
- เลย์เอาต์ SmartArt
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ทำงานกับ SmartArt ใน Aspose.Slides for .NET: สร้าง, แก้ไข, แปลงและจัดรูปแบบแผนภูมิด้วย C# สำหรับการนำเสนอ PowerPoint และ OpenDocument."
---
บทความนี้สาธิตวิธีเพิ่มกราฟิก SmartArt, เข้าถึง, ลบและเปลี่ยนเลย์เอาต์โดยใช้ **Aspose.Slides for .NET**.

## **เพิ่ม SmartArt**

แทรกกราฟิก SmartArt โดยใช้หนึ่งในเลย์เอาต์ที่มีอยู่ในตัว.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **เข้าถึง SmartArt**

ดึงอ็อบเจ็กต์ SmartArt ตัวแรกบนสไลด์.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **ลบ SmartArt**

ลบรูปทรง SmartArt ออกจากสไลด์.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **เปลี่ยนเลย์เอาต์ SmartArt**

อัปเดตประเภทเลย์เอาต์ของกราฟิก SmartArt ที่มีอยู่.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```