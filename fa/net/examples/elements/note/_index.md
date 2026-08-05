---
title: یادداشت
type: docs
weight: 240
url: /fa/net/examples/elements/note/
aliases:
  - /net/examples/elements/elements/note/
keywords:
- یادداشت
- افزودن اسلاید یادداشت
- دسترسی به اسلاید یادداشت
- حذف اسلاید یادداشت
- به‌روزرسانی متن یادداشت
- مثال کد
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کار با یادداشت‌های اسلاید در Aspose.Slides برای .NET: افزودن، خواندن، ویرایش و استخراج یادداشت‌های سخنران در فرمت‌های PPT، PPTX و ODP با استفاده از مثال‌های واضح C#."
---
این مقاله نحوه افزودن، خواندن، حذف و به روز رسانی اسلایدهای یادداشت را با استفاده از **Aspose.Slides for .NET** نشان می‌دهد.

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
اسلاید یادداشت مربوط به یک اسلاید را حذف کنید.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **به روز رسانی متن یادداشت**
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