---
title: ملاحظة
type: docs
weight: 240
url: /ar/net/examples/elements/note/
keywords:
- ملاحظة
- إضافة شريحة ملاحظات
- الوصول إلى شريحة ملاحظات
- إزالة شريحة ملاحظات
- تحديث نص الملاحظات
- مثال على الشفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "العمل مع ملاحظات الشرائح في Aspose.Slides for .NET: إضافة، قراءة، تحرير، وتصدير ملاحظات المتحدث في PPT و PPTX و ODP باستخدام أمثلة C# واضحة."
---
هذا المقال يوضح كيفية إضافة، قراءة، إزالة، وتحديث شرائح الملاحظات باستخدام **Aspose.Slides for .NET**.

## **إضافة شريحة ملاحظات**

إنشاء شريحة ملاحظات وتعيين نص لها.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **الوصول إلى شريحة ملاحظات**

قراءة النص من شريحة ملاحظات موجودة.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **إزالة شريحة ملاحظات**

إزالة شريحة الملاحظات المرتبطة بشريحة.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **تحديث نص الملاحظات**

تغيير نص شريحة الملاحظات.

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