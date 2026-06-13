---
title: บันทึกย่อ
type: docs
weight: 240
url: /th/php-java/examples/elements/note/
keywords:
- บันทึกย่อ
- เพิ่มสไลด์บันทึกย่อ
- เข้าถึงสไลด์บันทึกย่อ
- ลบสไลด์บันทึกย่อ
- อัปเดตข้อความบันทึกย่อ
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เพิ่ม อ่าน แก้ไข และส่งออกบันทึกย่อของผู้พูดใน PHP ด้วย Aspose.Slides: จัดรูปแบบข้อความ จัดการบันทึกย่อในแต่ละสไลด์ และควบคุมการมองเห็นใน PowerPoint และ OpenDocument."
---
แสดงวิธีการเพิ่ม อ่าน ถอนออก และอัปเดตสไลด์บันทึกย่อโดยใช้ **Aspose.Slides for PHP via Java**.

## **เพิ่มสไลด์บันทึกย่อ**

สร้างสไลด์บันทึกย่อและกำหนดข้อความให้กับมัน.

```php
function addNote() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("My note");

        $presentation->save("note.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **เข้าถึงสไลด์บันทึกย่อ**

อ่านข้อความจากสไลด์บันทึกย่อที่มีอยู่.

```php
function accessNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notes = $notesSlide->getNotesTextFrame()->getText();
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบสไลด์บันทึกย่อ**

ลบสไลด์บันทึกย่อที่เชื่อมโยงกับสไลด์.

```php
function removeNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getNotesSlideManager()->removeNotesSlide();

        $presentation->save("note_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **อัปเดตข้อความบันทึกย่อ**

เปลี่ยนข้อความของสไลด์บันทึกย่อ.

```php
function updateNoteText() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("Updated");

        $presentation->save("note_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```