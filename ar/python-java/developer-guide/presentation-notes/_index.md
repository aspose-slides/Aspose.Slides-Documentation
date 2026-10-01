---
title: إدارة ملاحظات العرض التقديمي في بايثون عبر جافا
linktitle: ملاحظات العرض التقديمي
type: docs
weight: 110
url: /ar/python-java/presentation-notes/
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
- Java
- Aspose.Slides
description: "تخصيص ملاحظات العرض التقديمي باستخدام Aspose.Slides للبايثون عبر جافا. العمل بسلاسة مع ملاحظات PowerPoint و OpenDocument لتعزيز إنتاجيتك."
---
## **نظرة عامة**

Aspose.Slides يدعم إزالة شرائح الملاحظات من عرض تقديمي. يقدم هذا الموضوع هذه الميزة، بما في ذلك كيفية إزالة الملاحظات وكيفية تطبيق نمط على شرائح الملاحظات في عرض تقديمي. يتيح Aspose.Slides لك إزالة الملاحظات من أي شريحة وتطبيق تنسيق على الملاحظات الحالية. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة الملاحظات من شريحة محددة في عرض تقديمي.
- إزالة الملاحظات من جميع الشرائح في عرض تقديمي.

لقراءة أو تعديل أبعاد صفحة الملاحظات، وتبديل الاتجاه، والتحقق من سلوك التصدير، راجع [حجم صفحة الملاحظات](/slides/ar/python-java/notes-size/).

## **إزالة الملاحظات من شريحة**

يمكن إزالة الملاحظات من شريحة محددة كما هو موضح في المثال أدناه:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
presentation = Presentation("presWithNotes.pptx")
try:
    # إزالة الملاحظات من الشريحة الأولى.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إزالة الملاحظات من عرض تقديمي**

يمكن إزالة الملاحظات من جميع الشرائح في عرض تقديمي كما هو موضح في المثال أدناه:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
presentation = Presentation("presWithNotes.pptx")
try:
    # إزالة الملاحظات من جميع الشرائح.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إضافة نمط ملاحظات**

توفر طريقة [getNotesStyle](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masternotesslide/#getNotesStyle) في فئة [MasterNotesSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masternotesslide/) إمكانية الوصول إلى نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # الحصول على نمط نص شريحة الملاحظات الرئيسية.
        notes_style = notes_master.getNotesStyle()

        # تعيين نقاط رمزية للفقرات من المستوى الأول.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**ما الكيان API الذي يوفر الوصول إلى ملاحظات شريحة محددة؟**

يتم الوصول إلى الملاحظات من خلال مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notesslidemanager/) وطريقة [getNotesSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/notesslidemanager/#getNotesSlide) التي تُعيد كائن الملاحظات، أو `None` إذا لم تكن هناك ملاحظات.

**هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي يعمل معها المكتبة؟**

تستهدف المكتبة مجموعة واسعة من صيغ Microsoft PowerPoint (من الإصدار 97 وما بعده) وODP؛ يتم دعم الملاحظات داخل هذه الصيغ دون الاعتماد على نسخة مثبتة من PowerPoint.