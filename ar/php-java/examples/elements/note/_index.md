---
title: ملاحظة
type: docs
weight: 240
url: /ar/php-java/examples/elements/note/
keywords:
- ملاحظة
- إضافة شريحة ملاحظات
- الوصول إلى شريحة ملاحظات
- إزالة شريحة ملاحظات
- تحديث نص الملاحظات
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إضافة، قراءة، تعديل وتصدير ملاحظات المتحدث في PHP باستخدام Aspose.Slides: تنسيق النص، إدارة الملاحظات لكل شريحة، والتحكم في الرؤية في PowerPoint وOpenDocument."
---
Shows how to add, read, remove, and update notes slides using **Aspose.Slides for PHP via Java**.

## **إضافة شريحة ملاحظات**

إنشاء شريحة ملاحظات وتعيين نص لها.

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

## **الوصول إلى شريحة ملاحظات**

قراءة النص من شريحة ملاحظات موجودة.

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

## **إزالة شريحة ملاحظات**

إزالة شريحة الملاحظات المرتبطة بشريحة.

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

## **تحديث نص الملاحظات**

تغيير نص شريحة الملاحظات.

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