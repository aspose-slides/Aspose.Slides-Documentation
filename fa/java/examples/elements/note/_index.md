---
title: یادداشت
type: docs
weight: 240
url: /fa/java/examples/elements/note/
keywords:
- مثال کد
- یادداشت
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "کار با یادداشت‌های اسلاید در Aspose.Slides for Java: افزودن، خواندن، ویرایش و استخراج یادداشت‌های گوینده در PPT، PPTX و ODP با استفاده از مثال‌های واضح جاوا."
---
این مقاله نشان می‌دهد که چگونه اسلایدهای یادداشت را با استفاده از **Aspose.Slides for Java** اضافه، بخوانید، حذف کنید و به‌روز کنید.

## **افزودن اسلاید یادداشت**
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

## **دسترسی به اسلاید یادداشت**
متن یک اسلاید یادداشت موجود را بخوانید.

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

## **حذف اسلاید یادداشت**
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