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
- الملاحظات الرئيسية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تخصيص ملاحظات العرض التقديمي باستخدام Aspose.Slides لبايثون عبر .NET. العمل بسلاسة مع ملاحظات PowerPoint وOpenDocument لزيادة إنتاجيتك."
---

يدعم Aspose.Slides إزالة شرائح الملاحظات من عرض تقديمي. في هذا الموضوع، سنقدم هذه الميزة الجديدة لإزالة الملاحظات وكذلك إضافة شرائح نمط الملاحظات من أي عرض تقديمي. يوفر Aspose.Slides for Python via .NET ميزة إزالة ملاحظات أي شريحة بالإضافة إلى إضافة نمط للملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة ملاحظات شريحة محددة من عرض تقديمي.
- إزالة ملاحظات جميع الشرائح من عرض تقديمي.
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



## **إضافة نمط الملاحظات**
تم إضافة الخاصية [notes_style](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/notes_style/) إلى الفئة [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/). تحدد هذه الخاصية نمط نص الملاحظات. تم توضيح التنفيذ في المثال أدناه.
```py
import aspose.slides as slides

# إنشاء فئة Presentation التي تمثل ملف العرض التقديمي
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # الحصول على نمط نص MasterNotesSlide
        notesStyle = notesMaster.notes_style

        # تعيين رمز نقطي للمستوى الأول من الفقرات
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # حفظ ملف PPTX إلى القرص
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة المتكررة**

**Which API entity provides access to the notes of a specific slide?**

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) و[property](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/) التي تُعيد كائن الملاحظات، أو `None` إذا لم توجد ملاحظات.

**Are there differences in notes support across the PowerPoint versions the library works with?**

تستهدف المكتبة مجموعة واسعة من تنسيقات Microsoft PowerPoint (97‑أحدث) وODP؛ يتم دعم الملاحظات داخل هذه التنسيقات دون الاعتماد على نسخة مثبتة من PowerPoint.