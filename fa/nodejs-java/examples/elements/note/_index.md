---
title: یادداشت
type: docs
weight: 240
url: /fa/nodejs-java/examples/elements/note/
keywords:
- مثال کد
- یادداشت
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "کار با یادداشت‌های اسلاید در Aspose.Slides برای Node.js: افزودن، خواندن، ویرایش و استخراج یادداشت‌های گوینده در PPT، PPTX و ODP با استفاده از مثال‌های واضح JavaScript."
---
این مقاله نشان می‌دهد که چگونه اسلایدهای یادداشت را اضافه، بخوانید، حذف کنید و به‌روزرسانی کنید با استفاده از **Aspose.Slides for Node.js via Java**.

## **افزودن اسلاید یادداشت**

یک اسلاید یادداشت ایجاد کنید و متن را به آن اختصاص دهید.

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

## **دسترسی به اسلاید یادداشت**

متن یک اسلاید یادداشت موجود را بخوانید.

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

## **حذف اسلاید یادداشت**

اسلاید یادداشت مرتبط با یک اسلاید را حذف کنید.

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

## **به‌روزرسانی متن یادداشت**

متن یک اسلاید یادداشت را تغییر دهید.

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