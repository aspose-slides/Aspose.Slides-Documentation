---
title: ملاحظات العرض
type: docs
weight: 110
url: /python-net/presentation-notes/
keywords: "ملاحظات، ملاحظات PowerPoint، إضافة ملاحظات، إزالة ملاحظات، عرض PowerPoint، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "إضافة وإزالة الملاحظات في عروض PowerPoint باستخدام بايثون"
---

يدعم Aspose.Slides إزالة شرائح الملاحظات من عرض تقديمي. في هذا الموضوع، سنقدم هذه الميزة الجديدة لإزالة الملاحظات وكذلك إضافة شرائح الملاحظات بأسلوب من أي عرض تقديمي. يوفر Aspose.Slides لـ بايثون عبر .NET ميزة إزالة ملاحظات أي شريحة بالإضافة إلى إضافة أسلوب للملاحظات الحالية. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة ملاحظات شريحة معينة من عرض تقديمي.
- إزالة ملاحظات جميع الشرائح من عرض تقديمي.
## **إزالة الملاحظات من الشريحة**
يمكن إزالة ملاحظات شريحة محددة كما هو موضح في المثال أدناه:

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف العرض التقديمي 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # إزالة ملاحظات الشريحة الأولى
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # حفظ العرض التقديمي على القرص
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إزالة الملاحظات من جميع الشرائح**
يمكن إزالة ملاحظات جميع الشرائح من عرض تقديمي كما هو موضح في المثال أدناه:

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف العرض التقديمي 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # إزالة ملاحظات جميع الشرائح
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # حفظ العرض التقديمي على القرص
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إضافة NotesStyle**
تم إضافة خاصية NotesStyle إلى [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) و [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) على التوالي. تحدد هذه الخاصية أسلوب نص الملاحظات.  يتم توضيح التنفيذ في المثال أدناه.

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف العرض التقديمي
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # الحصول على أسلوب نص MasterNotesSlide
        notesStyle = notesMaster.notes_style

        # تعيين رمز نقطي للفقرتين من المستوى الأول
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # حفظ ملف PPTX على القرص
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```