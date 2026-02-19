---
title: ملاحظة
type: docs
weight: 240
url: /ar/nodejs-java/examples/elements/note/
keywords:
- مثال شفرة
- ملاحظة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "التعامل مع ملاحظات الشرائح في Aspose.Slides for Node.js: إضافة، قراءة، تعديل، وتصدير ملاحظات المتحدث بصيغ PPT و PPTX و ODP باستخدام أمثلة JavaScript واضحة."
---
هذه المقالة توضح كيفية إضافة، قراءة، إزالة، وتحديث شرائح الملاحظات باستخدام **Aspose.Slides for Node.js via Java**.

## **إضافة شريحة ملاحظات**

إنشاء شريحة ملاحظات وتعيين نص لها.

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

## **الوصول إلى شريحة ملاحظات**

قراءة النص من شريحة ملاحظات موجودة.

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

## **إزالة شريحة ملاحظات**

إزالة شريحة الملاحظات المرتبطة بشريحة.

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

## **تحديث نص الملاحظات**

تغيير نص شريحة الملاحظات.

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