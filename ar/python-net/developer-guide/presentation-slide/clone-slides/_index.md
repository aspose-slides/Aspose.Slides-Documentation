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
description: "استنسخ أو كرّر شرائح PowerPoint بسرعة باستخدام Aspose.Slides للـ Python عبر .NET. اتبع أمثلة الشيفرة الواضحة والنصائح الخاصة بنا لأتمتة إنشاء العروض التقديمية في ثوانٍ، وزيادة الإنتاجية، وإلغاء الأعمال اليدوية."
---

## **نظرة عامة**

الاستنساخ هو عملية إنشاء نسخة مطابقة أو نسخ متماثل لشيء ما. يتيح Aspose.Slides for Python via .NET استنساخ أي شريحة وإدراج تلك النسخة في العرض التقديمي الحالي أو في عرض تقديمي آخر مفتوح. ينشئ عملية الاستنساخ شريحة جديدة يمكنك تعديلها دون التأثير على الأصل.

هناك عدة طرق لاستنساخ شريحة:

- استنساخ شريحة في النهاية ضمن نفس العرض التقديمي.
- استنساخ شريحة إلى موقع محدد ضمن نفس العرض التقديمي.
- استنساخ شريحة في النهاية من عرض تقديمي آخر.
- استنساخ شريحة إلى موقع محدد في عرض تقديمي آخر.
- استنساخ شريحة مع الشريحة الرئيسية الخاصة بها إلى عرض تقديمي آخر.

في Aspose.Slides for Python via .NET، توفر [مجموعة الشرائح](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) التي يُظهرها كائن [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) طرق `add_clone` و `insert_clone` لإجراء هذه الأنواع من استنساخ الشرائح.

## **استنساخ في النهاية ضمن نفس العرض التقديمي**

إذا كنت ترغب في استنساخ شريحة ضمن نفس العرض التقديمي وإلحاقها في نهاية الشرائح الحالية، استخدم طريقة `add_clone`. اتبع الخطوات التالية:

1. إنشاء مثال من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مجموعة الشرائح من كائن [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. استدعِ طريقة `add_clone` على [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)، مع تمرير الشريحة التي تريد استنساخها.
1. احفظ العرض التقديمي المعدل.

في المثال أدناه، يتم استنساخ الشريحة الأولى (الفهرس 0) وإلحاقها في نهاية العرض التقديمي.
```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation لتمثيل ملف العرض التقديمي.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي.
    presentation.slides.add_clone(presentation.slides[0])
    # حفظ العرض التقديمي المعدل إلى القرص.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **استنساخ إلى موقع محدد ضمن نفس العرض التقديمي**

إذا كنت ترغب في استنساخ شريحة ضمن نفس العرض التقديمي ووضعها في موقع مختلف، استخدم طريقة `insert_clone`:

1. إنشاء مثال من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مجموعة الشرائح من كائن [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. استدعِ طريقة `insert_clone` على [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)، مع تمرير الشريحة التي تريد استنساخها والفهرس الهدف لموقعها الجديد.
1. احفظ العرض التقديمي المعدل.

في المثال أدناه، يتم استنساخ الشريحة عند الفهرس 0 (الموضع 1) إلى الفهرس 1 (الموضع 2) ضمن نفس العرض التقديمي.
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف العرض التقديمي.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # استنساخ الشريحة المطلوبة إلى الموضع المحدد (الفهرس) داخل نفس العرض التقديمي.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # حفظ العرض التقديمي المعدل إلى القرص.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **استنساخ في النهاية من عرض تقديمي آخر**

إذا كنت تحتاج إلى استنساخ شريحة من عرض تقديمي واحد وإلحاقها في نهاية عرض تقديمي آخر:

1. إنشاء مثال من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) للعرض المصدر (الذي يحتوي على الشريحة المراد استنساخها).
1. إنشاء مثال من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) للعرض الوجهة (حيث ستُضاف الشريحة).
1. احصل على مجموعة الشرائح من العرض الوجهة.
1. استدعِ `add_clone` على [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) الوجهة، مع تمرير الشريحة من العرض المصدر.
1. احفظ العرض الوجهة المعدل.

في المثال أدناه، يتم استنساخ الشريحة عند الفهرس 0 في العرض المصدر إلى نهاية العرض الوجهة.
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # إنشاء كائن من فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة).
    with slides.Presentation() as target_presentation:
        # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # حفظ العرض التقديمي الوجهة إلى القرص.
        target_presentation.save("Asp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **استنساخ إلى موقع محدد في عرض تقديمي آخر**

إذا كنت تحتاج إلى استنساخ شريحة من عرض تقديمي واحد وإدراجها في عرض تقديمي آخر في موقع محدد:

1. إنشاء مثال من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) للعرض المصدر (الذي يحتوي على الشريحة المراد استنساخها).
1. إنشاء مثال من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) للعرض الوجهة (حيث ستُضاف الشريحة).
1. احصل على مجموعة الشرائح من العرض الوجهة.
1. استدعِ طريقة `insert_clone` على [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) الوجهة، مع تمرير الشريحة من العرض المصدر والفهرس الهدف المطلوب.
1. احفظ العرض الوجهة المعدل.

في المثال أدناه، يتم استنساخ الشريحة عند الفهرس 0 في العرض المصدر إلى الفهرس 1 (الموضع 2) في العرض الوجهة.
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # إنشاء كائن من فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # إدراج نسخة مستنسخة من الشريحة الأولى من المصدر عند الفهرس 2 في العرض التقديمي الوجهة.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # حفظ العرض التقديمي الوجهة إلى القرص.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **استنساخ شريحة مع شريحتها الرئيسية إلى عرض تقديمي آخر**

إذا كنت تحتاج إلى استنساخ شريحة **مع الماستر** من عرض تقديمي واستخدامها في آخر، استنسخ أولاً شريحة الماستر المطلوبة من العرض المصدر إلى العرض الوجهة. ثم استخدم ذلك الماستر الوجهة عند استنساخ الشريحة. طريقة `add_clone(Slide, MasterSlide)` تتوقع **شريحة ماستر من العرض الوجهة**، لا من المصدر.

للاستنساخ مع الماستر، اتبع الخطوات التالية:

1. إنشاء مثال من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) للعرض المصدر (الذي يحتوي على الشريحة المراد استنساخها).
1. إنشاء مثال من فئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) للعرض الوجهة.
1. الوصول إلى الشريحة المصدر التي سيتم استنساخها وشريحتها الرئيسية.
1. احصل على [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) من مجموعة الماستر في العرض الوجهة.
1. استدعِ `add_clone` على [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)، مع تمرير الماستر المصدر لاستنساخه إلى الوجهة.
1. احصل على [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) من مجموعة الشرائح في العرض الوجهة.
1. استدعِ `add_clone` على [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)، مع تمرير الشريحة المصدر والماستر المستنسخ في الوجهة.
1. احفظ العرض الوجهة المعدل.

في المثال أدناه، يتم استنساخ الشريحة عند الفهرس 0 في العرض المصدر إلى نهاية العرض الوجهة باستخدام الماستر المستنسخ من المصدر.
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # إنشاء كائن من فئة Presentation للعرض التقديمي الوجهة حيث سيتم استنساخ الشريحة.
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

مع Aspose.Slides for Python via .NET، يمكنك استنساخ شريحة من قسم في عرض تقديمي وإدراجها في قسم آخر داخل نفس العرض. للقيام بذلك، استخدم طريقة `add_clone(Slide, Section)` لفئة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).

المثال التالي في بايثون يوضح كيفية استنساخ شريحة وإدراج النسخة المستنسخة في قسم محدد:
```py
import aspose.slides as slides

    # إنشاء عرض تقديمي جديد فارغ.
    with slides.Presentation() as presentation:
        # إضافة شريحة فارغة بناءً على تخطيط الشريحة الأولى.
        slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
        # إضافة شكل بيضاوي إلى الشريحة الجديدة؛ سيتم استنساخ هذه الشريحة لاحقًا.
        slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
        # إضافة شريحة فارغة أخرى بناءً على تخطيط الشريحة الأولى.
        slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
        # إنشاء قسم باسم "Section2" يبدأ عند slide2.
        section = presentation.sections.add_section("Section2", slide2)
        # استنساخ الشريحة التي تم إنشاؤها مسبقًا في قسم "Section2".
        presentation.slides.add_clone(slide, section)
        # حفظ العرض التقديمي كملف PPTX.
        presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجعين؟**

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا كنت لا تريدها، [قم بإزالتها](/slides/ar/python-net/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر بياناتها؟**

يتم نسخ كائن المخطط وتنسيقه والبيانات المضمنة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل مصنف OLE مدمج)، فإن هذا الارتباط يُحافظ عليه كـ [كائن OLE](/slides/ar/python-net/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**

نعم. يمكنك إدراج النسخة المستنسخة عند فهرس شريحة محدد ووضعها في [قسم](/slides/ar/python-net/slide-section/) مختار. إذا لم يكن القسم المستهدف موجودًا، أنشئه أولاً ثم انقل الشريحة إليه.