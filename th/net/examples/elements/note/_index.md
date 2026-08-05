---
title: บันทึกย่อ
type: docs
weight: 240
url: /th/net/examples/elements/note/
aliases:
  - /net/examples/elements/elements/note/
keywords:
  - บันทึกย่อ
  - เพิ่มสไลด์บันทึกย่อ
  - เข้าถึงสไลด์บันทึกย่อ
  - ลบสไลด์บันทึกย่อ
  - อัปเดตข้อความบันทึกย่อ
  - ตัวอย่างโค้ด
  - PowerPoint
  - OpenDocument
  - งานนำเสนอ
  - .NET
  - C#
  - Aspose.Slides
description: "ทำงานกับบันทึกย่อสไลด์ใน Aspose.Slides for .NET: เพิ่ม อ่าน แก้ไข และส่งออกบันทึกย่อผู้พูดในรูปแบบ PPT, PPTX และ ODP ด้วยตัวอย่าง C# ที่ชัดเจน."
---
บทความนี้แสดงวิธีการเพิ่ม อ่าน ลบ และอัปเดตสไลด์บันทึกย่อโดยใช้ **Aspose.Slides for .NET**.

## **เพิ่มสไลด์บันทึกย่อ**

สร้างสไลด์บันทึกย่อและกำหนดข้อความให้กับมัน.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **เข้าถึงสไลด์บันทึกย่อ**

อ่านข้อความจากสไลด์บันทึกย่อที่มีอยู่.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **ลบสไลด์บันทึกย่อ**

ลบสไลด์บันทึกย่อที่เชื่อมโยงกับสไลด์.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **อัปเดตข้อความบันทึกย่อ**

เปลี่ยนข้อความของสไลด์บันทึกย่อ.

```csharp
static void UpdateNoteText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```