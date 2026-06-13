---
title: یادداشت
type: docs
weight: 240
url: /fa/cpp/examples/elements/note/
keywords:
- مثال کد
- یادداشت
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "کار با یادداشت‌های اسلاید در Aspose.Slides for C++: اضافه کردن، خواندن، ویرایش و استخراج یادداشت‌های گوینده در فرمت‌های PPT، PPTX و ODP با استفاده از مثال‌های واضح C++."
---
این مقاله نشان می‌دهد که چگونه اسلایدهای یادداشت را با استفاده از **Aspose.Slides for C++** اضافه، بخوانید، حذف کنید و به‌روزرسانی کنید.

## **اضافه کردن یک اسلاید یادداشت**

یک اسلاید یادداشت ایجاد کنید و متن را به آن اختصاص دهید.

```cpp
static void AddNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"My note");

    presentation->Dispose();
}
```

## **دسترسی به یک اسلاید یادداشت**

متن را از یک اسلاید یادداشت موجود بخوانید.

```cpp
static void AccessNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    auto notes = notesSlide->get_NotesTextFrame()->get_Text();

    presentation->Dispose();
}
```

## **حذف یک اسلاید یادداشت**

اسلاید یادداشت مرتبط با یک اسلاید را حذف کنید.

```cpp
static void RemoveNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->RemoveNotesSlide();

    presentation->Dispose();
}
```

## **به‌روزرسانی متن اسلاید یادداشت**

متن یک اسلاید یادداشت را تغییر دهید.

```cpp
static void UpdateNoteText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Old");
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Updated");

    presentation->Dispose();
}
```