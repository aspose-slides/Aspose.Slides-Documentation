---
title: ملاحظة
type: docs
weight: 240
url: /ar/cpp/examples/elements/note/
keywords:
- مثال على الكود
- ملاحظة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "العمل مع ملاحظات الشرائح في Aspose.Slides لـ C++: إضافة، قراءة، تحرير، وتصدير ملاحظات المتحدث في صيغ PPT و PPTX و ODP باستخدام أمثلة واضحة بلغة C++."
---
توضح هذه المقالة كيفية إضافة، قراءة، إزالة وتحديث شرائح الملاحظات باستخدام **Aspose.Slides for C++**.

## **إضافة شريحة ملاحظات**

إنشاء شريحة ملاحظات وتعيين النص لها.

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

## **الوصول إلى شريحة ملاحظات**

قراءة النص من شريحة ملاحظات موجودة.

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

## **إزالة شريحة ملاحظات**

إزالة شريحة الملاحظات المرتبطة بشريحة.

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

## **تحديث نص الملاحظات**

تغيير نص شريحة الملاحظات.

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