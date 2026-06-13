---
title: บันทึกย่อ
type: docs
weight: 240
url: /th/nodejs-java/examples/elements/note/
keywords:
- ตัวอย่างโค้ด
- บันทึกย่อ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ทำงานกับบันทึกย่อของสไลด์ใน Aspose.Slides for Node.js: เพิ่ม, อ่าน, แก้ไข, และส่งออกบันทึกย่อของผู้พูดในรูปแบบ PPT, PPTX, และ ODP ด้วยตัวอย่าง JavaScript ที่ชัดเจน"
---
บทความนี้แสดงวิธีการเพิ่ม, อ่าน, ลบ และอัปเดตสไลด์บันทึกย่อโดยใช้ **Aspose.Slides for Node.js via Java**.

## **เพิ่มสไลด์บันทึกย่อ**

สร้างสไลด์บันทึกย่อและกำหนดข้อความให้กับมัน.

```js
function addNote() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().addNotesSlide();
        notesSlide.getNotesTextFrame().setText("My note");

        presentation.save("note.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงสไลด์บันทึกย่อ**

อ่านข้อความจากสไลด์บันทึกย่อที่มีอยู่.

```js
function accessNote() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().getNotesSlide();

        let notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **ลบสไลด์บันทึกย่อ**

ลบสไลด์บันทึกย่อที่เชื่อมโยงกับสไลด์.

```js
function removeNote() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getNotesSlideManager().removeNotesSlide();

        presentation.save("note_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **อัปเดตข้อความบันทึกย่อ**

เปลี่ยนข้อความของสไลด์บันทึกย่อ.

```js
function updateNoteText() {
    let presentation = new aspose.slides.Presentation("note.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let notesSlide = slide.getNotesSlideManager().getNotesSlide();
        notesSlide.getNotesTextFrame().setText("Updated");

        presentation.save("note_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```