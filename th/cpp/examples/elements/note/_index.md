---
title: บันทึก
type: docs
weight: 240
url: /th/cpp/examples/elements/note/
keywords:
- ตัวอย่างโค้ด
- บันทึก
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ทำงานกับบันทึกสไลด์ใน Aspose.Slides for C++: เพิ่ม, อ่าน, แก้ไข, และส่งออกบันทึกผู้พูดใน PPT, PPTX, และ ODP โดยใช้ตัวอย่าง C++ ที่ชัดเจน."
---
บทความนี้แสดงวิธีการเพิ่ม, อ่าน, ลบ และอัปเดตสไลด์บันทึกโดยใช้ **Aspose.Slides for C++**.

## **เพิ่มสไลด์บันทึก**

สร้างสไลด์บันทึกและกำหนดข้อความให้กับมัน.

```cpp
static void AddNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"My note");

    presentation->Dispose();
}
```

## **เข้าถึงสไลด์บันทึก**

อ่านข้อความจากสไลด์บันทึกที่มีอยู่.

```cpp
static void AccessNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    auto notes = notesSlide->get_NotesTextFrame()->get_Text();

    presentation->Dispose();
}
```

## **ลบสไลด์บันทึก**

ลบสไลด์บันทึกที่เชื่อมกับสไลด์.

```cpp
static void RemoveNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->RemoveNotesSlide();

    presentation->Dispose();
}
```

## **อัปเดตข้อความบันทึก**

เปลี่ยนข้อความของสไลด์บันทึก.

```cpp
static void UpdateNoteText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Old");
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Updated");

    presentation->Dispose();
}
```