---
title: إدارة ملاحظات العرض التقديمي في بايثون
linktitle: ملاحظات العرض التقديمي
type: docs
weight: 110
url: /ar/python-net/presentation-notes/
keywords:
- ملاحظات
- شريحة ملاحظات
- إضافة ملاحظات
- إزالة ملاحظات
- نمط الملاحظات
- ملاحظات رئيسية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "قم بتخصيص ملاحظات العرض التقديمي باستخدام Aspose.Slides لبايثون عبر .NET. اعمل بسلاسة مع ملاحظات PowerPoint وOpenDocument لتعزيز إنتاجيتك."
---
## **نظرة عامة**

Aspose.Slides يدعم إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة، بما في ذلك كيفية إزالة الملاحظات وكيفية تطبيق نمط على شرائح الملاحظات في العرض التقديمي. Aspose.Slides يسمح لك بإزالة الملاحظات من أي شريحة وتطبيق تنسيق على الملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة الملاحظات من شريحة معينة في العرض التقديمي.
- إزالة الملاحظات من جميع الشرائح في العرض التقديمي.

للقراءة أو تعديل أبعاد صفحة الملاحظات، وتغيير الاتجاه، والتحقق من سلوك التصدير، راجع [Notes Page Size](/slides/ar/python-net/notes-size/).

## **إزالة الملاحظات من الشريحة**
يمكن إزالة الملاحظات من شريحة معينة كما هو موضح في المثال أدناه:

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # إزالة ملاحظات الشريحة الأولى
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # حفظ العرض التقديمي إلى القرص
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة الملاحظات من جميع الشرائح**
يمكن إزالة الملاحظات من جميع الشرائح في العرض التقديمي كما هو موضح في المثال أدناه:

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # إزالة ملاحظات جميع الشرائح
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # حفظ العرض التقديمي إلى القرص
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تطبيق نمط ملاحظات**
تمت إضافة الخاصية [notes_style](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masternotesslide/notes_style/) إلى الفئة [MasterNotesSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masternotesslide/). تحدد هذه الخاصية نمط نص الملاحظات. تم توضيح التنفيذ في المثال أدناه.

```py
import aspose.slides as slides

# إنشاء فئة Presentation التي تمثل ملف العرض التقديمي
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # الحصول على نمط نص MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Set ضبط علامة نقطية للفقرة من المستوى الأول
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # حفظ ملف PPTX إلى القرص
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**ما الكيان في الـ API الذي يتيح الوصول إلى ملاحظات شريحة معينة؟**

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/notesslidemanager/) و[property](https://reference.aspose.com/slides/ar/python-net/aspose.slides/notesslidemanager/notes_slide/) يُرجع كائن الملاحظات، أو `None` إذا لم توجد ملاحظات.

**هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي يعمل معها المكتبة؟**

المكتبة تستهدف مجموعة واسعة من تنسيقات Microsoft PowerPoint (97‑أحدث) وODP؛ يتم دعم الملاحظات ضمن هذه التنسيقات دون الاعتماد على نسخة مثبتة من PowerPoint.