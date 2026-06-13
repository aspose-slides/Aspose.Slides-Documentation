---
title: บันทึก
type: docs
weight: 240
url: /th/java/examples/elements/note/
keywords:
- ตัวอย่างโค้ด
- บันทึก
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ทำงานกับโน้ตสไลด์ใน Aspose.Slides for Java: เพิ่ม, อ่าน, แก้ไข, และส่งออกโน้ตผู้บรรยายในรูปแบบ PPT, PPTX, และ ODP ด้วยตัวอย่าง Java ที่ชัดเจน."
---
บทความนี้แสดงวิธีการเพิ่ม, อ่าน, ลบ, และปรับปรุงสไลด์โน้ตโดยใช้ **Aspose.Slides for Java**.

## **เพิ่มสไลด์โน้ต**

สร้างสไลด์โน้ตและกำหนดข้อความให้กับมัน.

```java
static void addNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("My note");
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงสไลด์โน้ต**

อ่านข้อความจากสไลด์โน้ตที่มีอยู่.

```java
static void accessNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        String notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **ลบสไลด์โน้ต**

ลบสไลด์โน้ตที่เชื่อมโยงกับสไลด์.

```java
static void removeNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().removeNotesSlide();
    } finally {
        presentation.dispose();
    }
}
```

## **อัปเดตข้อความโน้ต**

เปลี่ยนข้อความของสไลด์โน้ต.

```java
static void updateNoteText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Old");
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Updated");
    } finally {
        presentation.dispose();
    }
}
```