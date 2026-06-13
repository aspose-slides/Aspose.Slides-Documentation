---
title: อ็อบเจ็กต์ OLE
type: docs
weight: 210
url: /th/net/examples/elements/ole-object/
keywords:
- อ็อบเจ็กต์ OLE
- เพิ่มอ็อบเจ็กต์ OLE
- เข้าถึงอ็อบเจ็กต์ OLE
- ลบอ็อบเจ็กต์ OLE
- อัปเดตอ็อบเจ็กต์ OLE
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการอ็อบเจ็กต์ OLE ใน Aspose.Slides for .NET: แทรก, เชื่อมโยง, อัปเดต และสกัดข้อมูลที่ฝังไว้ด้วย C# ในงานนำเสนอ PPT, PPTX และ ODP"
---
บทความนี้แสดงวิธีการฝังไฟล์เป็นอ็อบเจ็กต์ OLE และอัปเดตข้อมูลของมันโดยใช้ **Aspose.Slides for .NET**.

## **เพิ่มอ็อบเจ็กต์ OLE**

ฝังไฟล์ PDF ลงในงานนำเสนอ.

```csharp
static void AddOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
}
```

## **เข้าถึงอ็อบเจ็กต์ OLE**

ดึงกรอบอ็อบเจ็กต์ OLE ตัวแรกบนสไลด์.

```csharp
static void AccessOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var firstOleFrame = slide.Shapes.OfType<IOleObjectFrame>().First();
}
```

## **ลบอ็อบเจ็กต์ OLE**

ลบอ็อบเจ็กต์ OLE ที่ฝังอยู่จากสไลด์.

```csharp
static void RemoveOleObject()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    slide.Shapes.Remove(oleFrame);
}
```

## **อัปเดตข้อมูลอ็อบเจ็กต์ OLE**

แทนที่ข้อมูลที่ฝังอยู่ในอ็อบเจ็กต์ OLE ที่มีอยู่.

```csharp
static void UpdateOleObjectData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var pdfData = File.ReadAllBytes("doc.pdf");
    var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
    var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    var newData = File.ReadAllBytes("Picture.png");
    var newDataInfo = new OleEmbeddedDataInfo(newData, "png");
    oleFrame.SetEmbeddedData(newDataInfo);
}
```