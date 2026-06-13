---
title: ส่วนหัวส่วนท้าย
type: docs
weight: 220
url: /th/net/examples/elements/header-footer/
keywords:
- ส่วนหัวส่วนท้าย
- เพิ่มส่วนหัวส่วนท้าย
- อัปเดตส่วนหัวส่วนท้าย
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ควบคุมส่วนหัวและส่วนท้ายของสไลด์ด้วย Aspose.Slides for .NET: เพิ่มวันที่, หมายเลขสไลด์, และข้อความกำหนดเองในไฟล์ PPT, PPTX, และ ODP พร้อมตัวอย่าง C#."
---
บทความนี้แสดงวิธีเพิ่มส่วนท้ายและอัปเดตตัวยึดวันที่และเวลาโดยใช้ **Aspose.Slides for .NET**.

## **เพิ่มส่วนท้าย**

เพิ่มข้อความลงในพื้นที่ส่วนท้ายของสไลด์และทำให้มองเห็นได้.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **อัปเดตวันที่และเวลา**

แก้ไขตัวยึดวันที่และเวลาในสไลด์.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```