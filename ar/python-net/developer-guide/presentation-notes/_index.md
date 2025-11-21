---
title: إدارة ملاحظات العرض التقديمي في Python
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
- الملاحظات الرئيسية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "قم بتخصيص ملاحظات العرض التقديمي باستخدام Aspose.Slides for Python عبر .NET. اعمل بسلاسة مع ملاحظات PowerPoint وOpenDocument لتعزيز إنتاجيتك."
---

Aspose.Slides يدعم إزالة شرائح الملاحظات من عرض تقديمي. في هذا الموضوع، سنقدم هذه الميزة الجديدة لإزالة الملاحظات وكذلك إضافة شرائح نمط الملاحظات من أي عرض تقديمي. Aspose.Slides for Python عبر .NET يوفر ميزة إزالة ملاحظات أي شريحة بالإضافة إلى إضافة نمط إلى الملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة ملاحظات شريحة معينة من العرض التقديمي.
- إزالة ملاحظات جميع الشرائح من العرض التقديمي.
## **إزالة الملاحظات من الشريحة**
يمكن إزالة ملاحظات بعض الشرائح المحددة كما هو موضح في المثال أدناه:
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
يمكن إزالة ملاحظات جميع شرائح العرض التقديمي كما هو موضح في المثال أدناه:
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


## **إضافة NotesStyle**
تمت إضافة الخاصية NotesStyle إلى الواجهة [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) والفئة [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) على التوالي. تحدد هذه الخاصية نمط نص الملاحظات. يتم عرض التنفيذ في المثال أدناه.
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # الحصول على نمط نص MasterNotesSlide
        notesStyle = notesMaster.notes_style

        # تعيين رموز نقطية للفقرة من المستوى الأول
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # حفظ ملف PPTX إلى القرص
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**ما الكيان API الذي يوفر الوصول إلى ملاحظات شريحة معينة؟**

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) و[property](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/) التي تُعيد كائن الملاحظات، أو `None` إذا لم تكن هناك ملاحظات.

**هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي يعمل معها المكتبة؟**

تستهدف المكتبة مجموعة واسعة من تنسيقات Microsoft PowerPoint (97–newer) وODP؛ يتم دعم الملاحظات ضمن هذه التنسيقات دون الاعتماد على نسخة مثبتة من PowerPoint.