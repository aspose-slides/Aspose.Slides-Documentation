---
title: یادداشت
type: docs
weight: 240
url: /fa/net/examples/elements/note/
keywords:
- یادداشت
- افزودن اسلاید یادداشت
- دسترسی اسلاید یادداشت
- حذف اسلاید یادداشت
- به‌روزرسانی متن یادداشت
- مثال کد
- پاورپوینت
- سند باز
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کار با یادداشت‌های اسلاید در Aspose.Slides for .NET: افزودن، خواندن، ویرایش و صادر کردن یادداشت‌های گوینده در فرمت‌های PPT، PPTX و ODP با مثال‌های واضح C#."
---
این مقاله نحوه اضافه‌کردن، خواندن، حذف و به‌روزرسانی اسلایدهای یادداشت را با استفاده از **Aspose.Slides for .NET** نشان می‌دهد.

## **افزودن اسلاید یادداشت**

یک اسلاید یادداشت ایجاد کنید و متن را به آن اختصاص دهید.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **دسترسی به اسلاید یادداشت**

متن را از یک اسلاید یادداشت موجود بخوانید.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **حذف اسلاید یادداشت**

اسلاید یادداشت مرتبط با یک اسلاید را حذف کنید.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **به‌روزرسانی متن یادداشت**

متن یک اسلاید یادداشت را تغییر دهید.

```csharp
static void UpdateNoteText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```