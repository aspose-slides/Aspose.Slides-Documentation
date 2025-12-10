---
title: ملاحظة
type: docs
weight: 240
url: /ar/net/examples/elements/elements/note/
keywords:
- مثال على الملاحظة
- إضافة شريحة ملاحظات
- الوصول إلى شريحة ملاحظات
- إزالة شريحة ملاحظات
- تحديث نص الملاحظات
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إضافة، قراءة، تعديل وتصدير ملاحظات المتحدث في C# باستخدام Aspose.Slides: تنسيق النص، إدارة الملاحظات لكل شريحة، والتحكم في وضوحها في PowerPoint وOpenDocument."
---

يعرض كيفية إضافة وقرأة وإزالة وتحديث شرائح الملاحظات باستخدام **Aspose.Slides for .NET**.

## **إضافة شريحة ملاحظات**
إنشاء شريحة ملاحظات وتعيين نص لها.
```csharp
static void Add_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```


## **الوصول إلى شريحة ملاحظات**
قراءة النص من شريحة ملاحظات موجودة.
```csharp
static void Access_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```


## **إزالة شريحة ملاحظات**
إزالة شريحة الملاحظات المرتبطة بشريحة.
```csharp
static void Remove_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```


## **تحديث نص الملاحظات**
تغيير نص شريحة الملاحظات.
```csharp
static void Update_Note_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```
