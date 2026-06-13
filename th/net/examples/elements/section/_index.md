---
title: ส่วน
type: docs
weight: 90
url: /th/net/examples/elements/section/
keywords:
- ส่วน
- ส่วนของสไลด์
- เพิ่มส่วน
- เข้าถึงส่วน
- ลบส่วน
- เปลี่ยนชื่อส่วน
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการส่วนของสไลด์ใน Aspose.Slides for .NET: สร้าง, เปลี่ยนชื่อ, จัดลำดับใหม่และจัดกลุ่มสไลด์ด้วยตัวอย่าง C# สำหรับ PPT, PPTX และ ODP."
---
ตัวอย่างการจัดการส่วนของการนำเสนอ—เพิ่ม, เข้าถึง, ลบ และเปลี่ยนชื่อโดยใช้ **Aspose.Slides for .NET** ผ่านการเขียนโปรแกรม

## **เพิ่มส่วน**

สร้างส่วนที่เริ่มต้นจากสไลด์ที่กำหนด

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // ระบุสไลด์ที่ทำเครื่องหมายจุดเริ่มต้นของส่วน
    presentation.Sections.AddSection("New Section", slide);
}
```

## **เข้าถึงส่วน**

อ่านข้อมูลส่วนจากการนำเสนอ

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // เข้าถึงส่วนโดยใช้ดัชนี
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **ลบส่วน**

ลบส่วนที่เพิ่มไว้ก่อนหน้านี้

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // ลบส่วนแรก.
    presentation.Sections.RemoveSection(section);
}
```

## **เปลี่ยนชื่อส่วน**

เปลี่ยนชื่อของส่วนที่มีอยู่

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```