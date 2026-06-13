---
title: یادداشت
type: docs
weight: 240
url: /fa/php-java/examples/elements/note/
keywords:
- یادداشت
- افزودن اسلاید یادداشت
- دسترسی به اسلاید یادداشت
- حذف اسلاید یادداشت
- به‌روزرسانی متن یادداشت
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "در PHP با Aspose.Slides افزودن، خواندن، ویرایش و استخراج یادداشت‌های سخنران: قالب‌بندی متن، مدیریت یادداشت‌ها برای هر اسلاید و کنترل نمایش در PowerPoint و OpenDocument."
---
نحوه افزودن، خواندن، حذف و به‌روزرسانی اسلایدهای یادداشت با استفاده از **Aspose.Slides for PHP via Java** را نشان می‌دهد.

## **Add a Notes Slide**
یک اسلاید یادداشت ایجاد کنید و متن را به آن اختصاص دهید.

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

## **Access a Notes Slide**
متن یک اسلاید یادداشت موجود را بخوانید.

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

## **Remove a Notes Slide**
اسلاید یادداشت مرتبط با یک اسلاید را حذف کنید.

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

## **Update Notes Text**
متن یک اسلاید یادداشت را تغییر دهید.

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