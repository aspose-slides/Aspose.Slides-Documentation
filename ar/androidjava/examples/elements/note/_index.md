---
title: ملاحظة
type: docs
weight: 240
url: /ar/androidjava/examples/elements/note/
keywords:
- مثال على الكود
- ملاحظة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "التعامل مع ملاحظات الشرائح في Aspose.Slides لنظام Android: إضافة، قراءة، تعديل، وتصدير ملاحظات المتحدث بصيغ PPT و PPTX و ODP باستخدام أمثلة Java واضحة."
---
توضح هذه المقالة كيفية إضافة وقراءة وإزالة وتحديث شرائح الملاحظات باستخدام **Aspose.Slides for Android via Java**.

## **إضافة شريحة ملاحظات**
إنشاء شريحة ملاحظات وتعيين النص لها.

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

## **الوصول إلى شريحة ملاحظات**
قراءة النص من شريحة ملاحظات موجودة.

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

## **إزالة شريحة ملاحظات**
إزالة شريحة الملاحظات المرتبطة بشريحة.

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

## **تحديث نص الملاحظات**
تغيير نص شريحة الملاحظات.

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