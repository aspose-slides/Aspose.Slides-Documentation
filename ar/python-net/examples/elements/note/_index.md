---
title: ملاحظة
type: docs
weight: 240
url: /ar/python-net/examples/elements/note/
keywords:
- ملاحظة
- إضافة شريحة ملاحظات
- الوصول إلى شريحة ملاحظات
- إزالة شريحة ملاحظات
- تحديث نص الملاحظات
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إضافة، قراءة، تعديل، وتصدير ملاحظات المتحدث في Python باستخدام Aspose.Slides: تنسيق النص، إدارة الملاحظات لكل شريحة، والتحكم في الرؤية في PowerPoint وOpenDocument."
---
يعرض كيفية إضافة، قراءة، إزالة، وتحديث شرائح الملاحظات باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة شريحة ملاحظات**

إنشاء شريحة ملاحظات وتعيين نص لها.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى شريحة ملاحظات**

قراءة النص من شريحة ملاحظات موجودة.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **إزالة شريحة ملاحظات**

إزالة شريحة الملاحظات المرتبطة بشريحة.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # إزالة شريحة الملاحظات.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **تحديث نص الملاحظات**

تغيير نص شريحة الملاحظات.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # تحديث نص الملاحظة.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```