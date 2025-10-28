---
title: إدارة ملاحظات العرض التقديمي في Python
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
- الملاحظات الأساسية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "قم بتخصيص ملاحظات العرض التقديمي باستخدام Aspose.Slides لـ Python عبر .NET. اعمل بسلاسة مع ملاحظات PowerPoint وOpenDocument لتعزيز إنتاجيتك."
---

Aspose.Slides يدعم إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنعرّف هذه الميزة الجديدة لإزالة الملاحظات وإضافة شرائح نمط الملاحظات من أي عرض تقديمي. Aspose.Slides لـ Python عبر .NET يوفر خاصية إزالة ملاحظات أي شريحة بالإضافة إلى إضافة نمط للملاحظات الحالية. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة ملاحظات شريحة محددة في العرض التقديمي.
- إزالة ملاحظات جميع شرائح العرض التقديمي.

## **إزالة الملاحظات من الشريحة**
يمكن إزالة ملاحظات شريحة محددة كما هو موضح في المثال أدناه:

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Removing notes of first slide
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # save presentation to disk
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة الملاحظات من جميع الشرائح**
يمكن إزالة ملاحظات جميع شرائح العرض التقديمي كما هو موضح في المثال أدناه:

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Removing notes of all slides
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # save presentation to disk
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إضافة نمط الملاحظات**
تمت إضافة خاصية NotesStyle إلى [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) والصف [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/). تحدد هذه الخاصية نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents the presentation file
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Get MasterNotesSlide text style
        notesStyle = notesMaster.notes_style

        #Set symbol bullet for the first level paragraphs
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # save the PPTX file to the Disk
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**ما الكيان API الذي يوفر الوصول إلى ملاحظات شريحة محددة؟**

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) و[خاصية](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/) تُعيد كائن الملاحظات، أو `None` إذا لم توجد ملاحظات.

**هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي يعمل معها المكتبة؟**

تستهدف المكتبة مجموعة واسعة من صيغ Microsoft PowerPoint (97‑الأحدث) وODP؛ وتدعم الملاحظات داخل هذه الصيغ دون الاعتماد على نسخة مثبتة من PowerPoint.