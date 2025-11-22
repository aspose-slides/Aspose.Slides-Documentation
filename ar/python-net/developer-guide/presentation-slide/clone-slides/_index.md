---
title: استنساخ شرائح PowerPoint في Python
linktitle: استنساخ الشرائح
type: docs
weight: 40
url: /ar/python-net/clone-slides/
keywords:
- استنساخ شريحة
- نسخ شريحة
- حفظ شريحة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "استنسخ أو كرّر شرائح PowerPoint بسرعة باستخدام Aspose.Slides for Python عبر .NET. اتبع أمثلة الشيفرة الواضحة ونصائحنا لأتمتة إنشاء العروض التقديمية في ثوانٍ، وزد الإنتاجية، وتخلص من العمل اليدوي."
---

## **نظرة عامة**

الاستنساخ هو عملية إنشاء نسخة مطابقة أو مستنسخة من شيء ما. Aspose.Slides for Python via .NET يسمح لك باستنساخ أي شريحة وإدراج النسخة المستنسخة في العرض التقديمي الحالي أو في عرض تقديمي آخر مفتوح. عملية الاستنساخ تنشئ شريحة جديدة يمكنك تعديلها دون التأثير على الأصل.

هناك عدة طرق لاستنساخ شريحة:

- استنساخ شريحة في النهاية داخل نفس العرض التقديمي.
- استنساخ شريحة إلى موضع محدد داخل نفس العرض التقديمي.
- استنساخ شريحة في النهاية من عرض تقديمي آخر.
- استنساخ شريحة إلى موضع محدد في عرض تقديمي آخر.
- استنساخ شريحة مع الشريحة الرئيسية إلى عرض تقديمي آخر.

في Aspose.Slides for Python via .NET، توفر [مجموعة الشرائح](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) التي يعرّفها كائن [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) طرق `add_clone` و `insert_clone` لتنفيذ هذه الأنواع من استنساخ الشرائح.

## **استنساخ في النهاية داخل نفس العرض التقديمي**

إذا كنت تريد استنساخ شريحة داخل نفس العرض التقديمي وإلحاقها في نهاية الشرائح الموجودة، استخدم طريقة `add_clone`. اتبع الخطوات التالية:

1. أنشئ نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مجموعة الشرائح من كائن [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. استدعِ طريقة `add_clone` على كائن [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)، مع تمرير الشريحة التي تريد استنساخها.
1. احفظ العرض التقديمي المعدل.

في المثال أدناه، تُستنسخ الشريحة الأولى (الفهرس 0) وتُلحق بنهاية العرض التقديمي.
```py
import aspose.slides as slides

# إنشاء كائن فئة Presentation لتمثيل ملف العرض التقديمي.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي.
    presentation.slides.add_clone(presentation.slides[0])
    # حفظ العرض التقديمي المعدل إلى القرص.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **استنساخ إلى موضع محدد داخل نفس العرض التقديمي**

إذا كنت تريد استنساخ شريحة داخل نفس العرض التقديمي ووضعها في موضع مختلف، استخدم طريقة `insert_clone`:

1. أنشئ نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مجموعة الشرائح من كائن [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. استدعِ طريقة `insert_clone` على كائن [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)، مع تمرير الشريحة التي تريد استنساخها والفهرس المستهدف للموقع الجديد.
1. احفظ العرض التقديمي المعدل.

في المثال أدناه، تُستنسخ الشريحة في الفهرس 0 (الموضع 1) إلى الفهرس 1 (الموضع 2) داخل نفس العرض التقديمي.
```py
import aspose.slides as slides

# إنشاء كائن فئة Presentation لتمثيل ملف العرض التقديمي.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # استنساخ الشريحة المطلوبة إلى الموضع المحدد (الفهرس) داخل نفس العرض التقديمي.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # حفظ العرض التقديمي المعدل إلى القرص.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **استنساخ في النهاية من عرض تقديمي آخر**

إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي وإلحاقها في نهاية عرض تقديمي آخر:

1. أنشئ نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) للعرض المصدر (الذي يحتوي على الشريحة المراد استنساخها).
1. أنشئ نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) للعرض الهدف (حيث ستُضاف الشريحة).
1. احصل على مجموعة الشرائح من العرض الهدف.
1. استدعِ `add_clone` على [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) الخاص بالهدف، مع تمرير الشريحة من العرض المصدر.
1. احفظ العرض الهدف المعدل.

في المثال أدناه، تُستنسخ الشريحة في الفهرس 0 في العرض المصدر إلى نهاية العرض الهدف.
```py
import aspose.slides as slides

# إنشاء كائن فئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # إنشاء كائن فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة).
    with slides.Presentation() as target_presentation:
        # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # حفظ العرض التقديمي الوجهة إلى القرص.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **استنساخ إلى موضع محدد في عرض تقديمي آخر**

إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي وإدراجها في عرض تقديمي آخر في موضع محدد:

1. أنشئ نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) للعرض المصدر.
1. أنشئ نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) للعرض الهدف.
1. احصل على مجموعة الشرائح من العرض الهدف.
1. استدعِ طريقة `insert_clone` على [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) الخاص بالهدف، مع تمرير الشريحة من العرض المصدر والفهرس المستهدف.
1. احفظ العرض الهدف المعدل.

في المثال أدناه، تُستنسخ الشريحة في الفهرس 0 في العرض المصدر إلى الفهرس 1 (الموضع 2) في العرض الهدف.
```py
import aspose.slides as slides

# إنشاء كائن فئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # إنشاء كائن فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # إدراج نسخة مستنسخة من الشريحة الأولى من المصدر عند الفهرس 2 في العرض التقديمي الوجهة.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # حفظ العرض التقديمي الوجهة إلى القرص.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **استنساخ شريحة مع الشريحة الرئيسية إلى عرض تقديمي آخر**

إذا كنت بحاجة إلى استنساخ شريحة **مع الشريحة الرئيسية** من عرض تقديمي واستخدامها في آخر، قم أولاً باستنساخ الشريحة الرئيسية المطلوبة من العرض المصدر إلى العرض الهدف. ثم استخدم تلك الشريحة الرئيسية في استنساخ الشريحة. طريقة `add_clone(Slide, MasterSlide)` تتوقع **شريحة رئيسية من العرض الهدف**، وليس من العرض المصدر.

لإستنسخ شريحة مع الشريحة الرئيسية، اتبع الخطوات التالية:

1. أنشئ نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) للعرض المصدر.
1. أنشئ نسخة من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) للعرض الهدف.
1. احصل على الشريحة المصدر التي ستُستنسخ وشريحتها الرئيسية.
1. احصل على [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) من مجموعة الشرائح الرئيسية للعرض الهدف.
1. استدعِ `add_clone` على [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)، مع تمرير الشريحة الرئيسية المصدر لاستنساخها إلى الهدف.
1. احصل على [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) من مجموعة الشرائح للعرض الهدف.
1. استدعِ `add_clone` على [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)، مع تمرير الشريحة المصدر والشريحة الرئيسية المستنسخة في الهدف.
1. احفظ العرض الهدف المعدل.

في المثال أدناه، تُستنسخ الشريحة في الفهرس 0 في العرض المصدر إلى نهاية العرض الهدف باستخدام الشريحة الرئيسية المستنسخة من المصدر.
```py
import aspose.slides as slides

# إنشاء كائن فئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # إنشاء كائن فئة Presentation للعرض التقديمي الوجهة حيث سيتم استنساخ الشريحة.
    with slides.Presentation() as target_presentation:
        # الحصول على الشريحة الأولى من العرض التقديمي المصدر.
        source_slide = source_presentation.slides[0]
        # الحصول على الشريحة الرئيسية المستخدمة من قبل الشريحة الأولى.
        source_master = source_slide.layout_slide.master_slide
        # استنساخ الشريحة الرئيسية إلى مجموعة الشرائح الرئيسية للعرض التقديمي الوجهة.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # استنساخ الشريحة من العرض التقديمي المصدر إلى نهاية العرض التقديمي الوجهة باستخدام الشريحة الرئيسية المستنسخة.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # حفظ العرض التقديمي الوجهة إلى القرص.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```


## **استنساخ في النهاية في قسم محدد**

مع Aspose.Slides for Python via .NET، يمكنك استنساخ شريحة من قسم في عرض تقديمي وإدراجها في قسم آخر داخل نفس العرض. للقيام بذلك، استخدم طريقة `add_clone(Slide, Section)` لواجهة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).

يوضح مثال Python التالي كيفية استنساخ شريحة وإدراج النسخة في قسم محدد:
```py
import aspose.slides as slides

# إنشاء عرض تقديمي فارغ جديد.
with slides.Presentation() as presentation:
    # إضافة شريحة فارغة استنادًا إلى تخطيط الشريحة الأولى.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # إضافة شكل بيضاوي إلى الشريحة الجديدة؛ سيتم استنساخ هذه الشريحة لاحقًا.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # إضافة شريحة فارغة أخرى استنادًا إلى تخطيط الشريحة الأولى.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # إنشاء قسم باسم "Section2" يبدأ عند slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # استنساخ الشريحة التي تم إنشاؤها مسبقًا إلى قسم "Section2".
    presentation.slides.add_clone(slide, section)
    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة المتكررة**

**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجعين؟**

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا لم ترغب في ذلك، يمكنك [إزالتها](/slides/ar/python-net/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر البيانات الخاصة بها؟**

يتم نسخ كائن المخطط، وتنسيقه، والبيانات المدمجة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل مصنف OLE مدمج)، يتم الحفاظ على هذا الارتباط كـ [كائن OLE](/slides/ar/python-net/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكن التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**

نعم. يمكنك إدراج النسخة في فهرس شريحة محدد ووضعها في [قسم](/slides/ar/python-net/slide-section/) مختار. إذا لم يكن القسم الهدف موجودًا، أنشئه أولًا ثم انقل الشريحة إليه.