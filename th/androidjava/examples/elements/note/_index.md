---
title: หมายเหตุ
type: docs
weight: 240
url: /th/androidjava/examples/elements/note/
keywords:
- ตัวอย่างโค้ด
- หมายเหตุ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ทำงานกับโน้ตสไลด์ใน Aspose.Slides for Android: เพิ่ม, อ่าน, แก้ไข, และส่งออกโน้ตผู้พูดในรูปแบบ PPT, PPTX, และ ODP โดยใช้ตัวอย่าง Java ที่ชัดเจน"
---
บทความนี้แสดงวิธีการเพิ่ม, อ่าน, ลบ และอัปเดตสไลด์โน้ตโดยใช้ **Aspose.Slides for Android via Java**.

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