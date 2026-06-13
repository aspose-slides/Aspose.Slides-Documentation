---
title: หมายเหตุ
type: docs
weight: 240
url: /th/net/examples/elements/note/
keywords:
- โน้ต
- เพิ่มสไลด์บันทึก
- เข้าถึงสไลด์บันทึก
- ลบสไลด์บันทึก
- อัปเดตข้อความบันทึก
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "ทำงานกับบันทึกสไลด์ใน Aspose.Slides for .NET: เพิ่ม, อ่าน, แก้ไข, และส่งออกบันทึกพูดใน PPT, PPTX, และ ODP โดยใช้ตัวอย่าง C# ที่ชัดเจน."
---
บทความนี้แสดงวิธีการเพิ่ม, อ่าน, ลบ, และอัปเดตสไลด์บันทึกโดยใช้ **Aspose.Slides for .NET**.

## **เพิ่มสไลด์บันทึก**

สร้างสไลด์บันทึกและกำหนดข้อความให้กับมัน.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **เข้าถึงสไลด์บันทึก**

อ่านข้อความจากสไลด์บันทึกที่มีอยู่.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **ลบสไลด์บันทึก**

ลบสไลด์บันทึกที่เชื่อมโยงกับสไลด์.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **อัปเดตข้อความบันทึก**

เปลี่ยนข้อความของสไลด์บันทึก.

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