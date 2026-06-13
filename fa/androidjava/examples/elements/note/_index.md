---
title: یادداشت
type: docs
weight: 240
url: /fa/androidjava/examples/elements/note/
keywords:
- مثال کد
- یادداشت
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "در Aspose.Slides برای Android با یادداشت‌های اسلاید کار کنید: اضافه کردن، خواندن، ویرایش و استخراج یادداشت‌های سخنران در فرمت‌های PPT، PPTX و ODP با استفاده از مثال‌های واضح Java."
---
این مقاله نشان می‌دهد که چگونه اسلایدهای یادداشت را با استفاده از **Aspose.Slides for Android via Java** اضافه، بخوانید، حذف کنید و به‌روزرسانی کنید.

## **افزودن یک اسلاید یادداشت**

یک اسلاید یادداشت ایجاد کنید و متن را به آن اختصاص دهید.

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

## **دسترسی به یک اسلاید یادداشت**

متن را از یک اسلاید یادداشت موجود بخوانید.

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

## **حذف یک اسلاید یادداشت**

اسلاید یادداشت مرتبط با یک اسلاید را حذف کنید.

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

## **به‌روزرسانی متن یادداشت**

متن یک اسلاید یادداشت را تغییر دهید.

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