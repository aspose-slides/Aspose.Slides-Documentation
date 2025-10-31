---
title: إدارة ملاحظات العرض التقديمي في بايثون
linktitle: ملاحظات العرض التقديمي
type: docs
weight: 110
url: /ar/python-net/presentation-notes/
keywords:
- ملاحظات
- شريحة الملاحظات
- إضافة ملاحظات
- إزالة ملاحظات
- نمط الملاحظات
- ملاحظات الأساس
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "قم بتخصيص ملاحظات العرض التقديمي باستخدام Aspose.Slides للبايثون عبر .NET. تعامل بسلاسة مع ملاحظات PowerPoint وOpenDocument لتعزيز إنتاجيتك."
---

Aspose.Slides يدعم إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة الجديدة لإزالة الملاحظات وكذلك إضافة شرائح بنمط ملاحظات من أي عرض تقديمي. Aspose.Slides للبايثون عبر .NET يوفر ميزة إزالة ملاحظات أي شريحة بالإضافة إلى إضافة نمط إلى الملاحظات الحالية. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة ملاحظات شريحة معينة من عرض تقديمي.
- إزالة ملاحظات جميع الشرائح من عرض تقديمي.

## **إزالة الملاحظات من الشريحة**
يمكن إزالة ملاحظات شريحة محددة كما هو موضح في المثال أدناه:

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # إزالة ملاحظات الشريحة الأولى
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # حفظ العرض التقديمي إلى القرص
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة الملاحظات من جميع الشرائح**
يمكن إزالة ملاحظات جميع الشرائح كما هو موضح في المثال أدناه:

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # إزالة ملاحظات جميع الشرائح
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # حفظ العرض التقديمي إلى القرص
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة نمط ملاحظات**
تم إضافة الخاصية NotesStyle إلى واجهة [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) وإلى الفئة [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) على التوالي. تحدد هذه الخاصية نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.

```py
import aspose.slides as slides

# إنشاء فئة Presentation التي تمثل ملف العرض التقديمي
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # الحصول على نمط نص MasterNotesSlide
        notesStyle = notesMaster.notes_style

        # ضبط نقطه رمزية للفقرات من المستوى الأول
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # حفظ ملف PPTX إلى القرص
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ما الكيان API الذي يوفر الوصول إلى ملاحظات شريحة معينة؟**

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) و[خاصية](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/) تُعيد كائن الملاحظات، أو `None` إذا لم توجد ملاحظات.

**هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي يعمل معها المكتبة؟**

المكتبة تستهدف مجموعة واسعة من تنسيقات Microsoft PowerPoint (97‑الإصدارات الأحدث) وODP؛ يتم دعم الملاحظات ضمن هذه التنسيقات دون الاعتماد على نسخة مثبتة من PowerPoint.