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
description: "استنسخ أو كرّر شرائح PowerPoint بسرعة باستخدام Aspose.Slides للـ Python عبر .NET. اتبع أمثلتنا البرمجية الواضحة والنصائح لتلقائيًا إنشاء عروض PPT في ثوانٍ، وزيادة الإنتاجية، وإلغاء العمل اليدوي."
---
## **المقدمة**

التنسخ هو العملية التي يتم من خلالها إنشاء نسخة مطابقة أو نسخة مماثلة من شيء ما. يتيح Aspose.Slides أيضًا نسخ (تنسخ) أي شريحة ثم إدراج الشريحة المستنسخة في العرض التقديمي الحالي أو أي عرض تقديمي مفتوح آخر. يخلق تنسخ الشرائح شريحة جديدة يمكن للمطورين تعديلها دون التأثير على الشريحة الأصلية. هناك عدة طرق لتنسخ شريحة:

- تنسخ في نهاية العرض التقديمي.
- تنسخ في موقع آخر داخل العرض التقديمي.
- تنسخ في نهاية عرض تقديمي آخر.
- تنسخ في موقع آخر في عرض تقديمي آخر.
- تنسخ في موقع محدد في عرض تقديمي آخر.

في Aspose.Slides for Python عبر .NET، توفر [مجموعة الشرائح](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/) التي تعرضها كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) طرق `add_clone` و `insert_clone` لتنفيذ هذه الأنواع من تنسخ الشرائح.

## **التثبيت**

```bash
pip install aspose.slides
```

## **تنسخ في النهاية داخل نفس العرض التقديمي**

إذا كنت تريد تنسخ شريحة داخل نفس العرض التقديمي وإلحاقها في نهاية الشرائح الحالية، استخدم طريقة `add_clone`. اتبع الخطوات التالية:

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. احصل على مجموعة الشرائح من كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. استدعِ طريقة `add_clone` على [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/)، مع تمرير الشريحة المراد نسخها.
1. احفظ العرض التقديمي المعدل.

في المثال أدناه، يتم نسخ الشريحة الأولى (الفهرس 0) وإلحاقها في نهاية العرض التقديمي.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف العرض التقديمي.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # نسخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي.
    presentation.slides.add_clone(presentation.slides[0])
    # حفظ العرض التقديمي المُعدَّل إلى القرص.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنسخ إلى موقع محدد داخل نفس العرض التقديمي**

إذا كنت تريد تنسخ شريحة داخل نفس العرض التقديمي ووضعها في موقع مختلف، استخدم طريقة `insert_clone`:

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. احصل على مجموعة الشرائح من كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. استدعِ طريقة `insert_clone` على [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/)، مع تمرير الشريحة المراد نسخها والمؤشر الهدف لموقعها الجديد.
1. احفظ العرض التقديمي المعدل.

في المثال أدناه، يتم نسخ الشريحة في الفهرس 1 (الموقع 2) إلى الفهرس 2 (الموقع 3) داخل نفس العرض التقديمي.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف العرض التقديمي.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # نسخ الشريحة المطلوبة إلى الموضع المحدد (الفهرس) داخل نفس العرض التقديمي.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # حفظ العرض التقديمي المعدل إلى القرص.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنسخ في نهاية عرض تقديمي آخر**

إذا كنت بحاجة إلى نسخ شريحة من عرض تقديمي واحد وإلحاقها في نهاية عرض تقديمي آخر:

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض المصدر (الذي يحتوي على الشريحة المراد نسخها).
1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض الوجهة (حيث ستُضاف الشريحة).
1. احصل على مجموعة الشرائح من العرض الوجهة.
1. استدعِ `add_clone` على [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/) الخاصة بالوجهة، مع تمرير الشريحة من العرض المصدر.
1. احفظ العرض الوجهة المعدل.

في المثال أدناه، يتم نسخ الشريحة في الفهرس 0 في العرض المصدر إلى نهاية العرض الوجهة.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # إنشاء كائن من فئة Presentation لملف الـ PPTX الوجهة (حيث سيتم نسخ الشريحة).
    with slides.Presentation() as target_presentation:
        # نسخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # حفظ العرض التقديمي الوجهة إلى القرص.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنسخ إلى موقع محدد في عرض تقديمي آخر**

إذا كنت بحاجة إلى نسخ شريحة من عرض تقديمي واحد وإدراجها في عرض تقديمي آخر في موقع محدد:

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض المصدر (الذي يحتوي على الشريحة المراد نسخها).
1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض الوجهة (حيث ستُضاف الشريحة).
1. احصل على مجموعة الشرائح من العرض الوجهة.
1. استدعِ طريقة `insert_clone` على [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/) الخاصة بالوجهة، مع تمرير الشريحة من العرض المصدر والمؤشر الهدف المطلوب.
1. احفظ العرض الوجهة المعدل.

في المثال أدناه، يتم نسخ الشريحة في الفهرس 0 في العرض المصدر إلى الفهرس 2 (الموقع 3) في العرض الوجهة.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # إنشاء كائن من فئة Presentation للملف PPTX الوجهة (حيث سيتم نسخ الشريحة).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # إدراج نسخة مستنسخة من الشريحة الأولى من المصدر في الفهرس 2 داخل العرض التقديمي الوجهة.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # حفظ العرض التقديمي الوجهة إلى القرص.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنسخ شريحة مع شريحة الماستر الخاصة بها إلى عرض تقديمي آخر**

إذا كنت بحاجة إلى نسخ شريحة **مع الماستر الخاص بها** من عرض تقديمي واستخدامها في آخر، قم أولاً بنسخ شريحة الماستر المطلوبة من العرض المصدر إلى العرض الوجهة. ثم استخدم ذلك الماستر الوجهة عند نسخ الشريحة. الطريقة `add_clone(Slide, MasterSlide)` تتوقع **شريحة ماستر من العرض الوجهة**، وليس من المصدر.

للنسخ مع الماستر، اتبع الخطوات التالية:

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض المصدر (الذي يحتوي على الشريحة المراد نسخها).
1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض الوجهة.
1. وصول إلى الشريحة المصدر التي سيتم نسخها والماستر الخاص بها.
1. احصل على [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/) من مجموعة الماستر للعرض الوجهة.
1. استدعِ `add_clone` على [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/)، مع تمرير الماستر المصدر لنسخه إلى الوجهة.
1. احصل على [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/) من مجموعة الشرائح للعرض الوجهة.
1. استدعِ `add_clone` على [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/)، مع تمرير الشريحة المصدر والماستر المستنسخ للوجهة.
1. احفظ العرض الوجهة المعدل.

في المثال أدناه، يتم نسخ الشريحة في الفهرس 0 في العرض المصدر إلى نهاية العرض الوجهة باستخدام الماستر المنسوخ من المصدر.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # إنشاء كائن من فئة Presentation للعرض التقديمي الوجهة حيث سيتم نسخ الشريحة.
    with slides.Presentation() as target_presentation:
        # الحصول على الشريحة الأولى من العرض التقديمي المصدر.
        source_slide = source_presentation.slides[0]
        # الحصول على شريحة الماستر المستخدمة من قبل الشريحة الأولى.
        source_master = source_slide.layout_slide.master_slide
        # استنساخ شريحة الماستر إلى مجموعة ماستر العرض التقديمي الوجهة.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # استنساخ الشريحة من العرض التقديمي المصدر إلى نهاية العرض التقديمي الوجهة باستخدام الماستر المستنسخ.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # حفظ العرض التقديمي الوجهة إلى القرص.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنسخ في النهاية في قسم محدد**

مع Aspose.Slides for Python عبر .NET، يمكنك نسخ شريحة من قسم في عرض تقديمي وإدراجها في قسم آخر داخل نفس العرض. للقيام بذلك، استخدم طريقة `add_clone(Slide, Section)` من فئة [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/).

يوضح المثال التالي بلغة Python كيفية نسخ شريحة وإدراج النسخة في قسم محدد:

```py
import aspose.slides as slides

# إنشاء عرض تقديمي فارغ جديد.
with slides.Presentation() as presentation:
    # إضافة شريحة فارغة بناءً على تخطيط الشريحة الأولى.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # إضافة شكل إهليلجي إلى الشريحة الجديدة؛ ستتم استنساخ هذه الشريحة لاحقًا.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # إضافة شريحة فارغة أخرى بناءً على تخطيط الشريحة الأولى.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # إنشاء قسم باسم "Section2" يبدأ عند slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # استنساخ الشريحة التي تم إنشاؤها مسبقًا إلى قسم "Section2".
    presentation.slides.add_clone(slide, section)
    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

### هل يتم نسخ ملاحظات المتحدث وتعليقات المراجع؟

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة. إذا كنت لا تريدها، [أزلها](/slides/ar/python-net/presentation-notes/) بعد الإدراج.

### كيف يتم معالجة المخططات ومصادر بياناتها؟

يتم نسخ كائن المخطط، وتنسيقه، والبيانات المضمنة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل دفتر عمل مدمج OLE)، يتم الحفاظ على هذا الارتباط كـ [OLE object](/slides/ar/python-net/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

### هل يمكنني التحكم في موقع الإدراج والأقسام للنسخة؟

نعم. يمكنك إدراج النسخة في فهرس شريحة محدد ووضعها في [section](/slides/ar/python-net/slide-section/) مختارة. إذا لم يكن القسم المستهدف موجودًا، أنشئه أولاً ثم انقل الشريحة إليه.