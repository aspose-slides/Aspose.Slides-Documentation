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
description: "استنسخ أو كرّر شرائح PowerPoint بسرعة باستخدام Aspose.Slides for Python عبر .NET. اتبع أمثلة الشيفرة الواضحة والنصائح لأتمتة إنشاء PPT في ثوانٍ، وزد الإنتاجية، وتخلص من العمل اليدوي."
---
## **مقدمة**

الاستنساخ هو عملية إنشاء نسخة مطابقة أو نسخة متماثلة من شيء ما. يتيح Aspose.Slides أيضًا إمكانية نسخ (استنساخ) أي شريحة ثم إدراج الشريحة المستنسخة في العرض التقديمي الحالي أو أي عرض تقديمي مفتوح آخر. يُنشئ استنساخ الشرائح شريحة جديدة يمكن للمطورين تعديلها دون التأثير على الشريحة الأصلية. هناك عدة طرق لاستنساخ شريحة:

- استنساخ في نهاية العرض التقديمي.
- استنساخ في موضع آخر داخل العرض التقديمي.
- استنساخ في نهاية عرض تقديمي آخر.
- استنساخ في موضع آخر في عرض تقديمي آخر.
- استنساخ في موضع محدد في عرض تقديمي آخر.

في Aspose.Slides for Python via .NET ، توفر [مجموعة الشرائح](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/) التي يُعرَضها كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) طرق `add_clone` و `insert_clone` لتنفيذ هذه الأنواع من استنساخ الشرائح.

## **التثبيت**

```bash
pip install aspose.slides
```

## **استنساخ في النهاية داخل نفس العرض التقديمي**

إذا كنت ترغب في استنساخ شريحة داخل نفس العرض التقديمي وإلحاقها بنهاية الشرائح الموجودة، استخدم الطريقة `add_clone`. اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. الحصول على مجموعة الشرائح من كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. استدعاء الطريقة `add_clone` على كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/)، مع تمرير الشريحة المراد استنساخها.
1. حفظ العرض التقديمي المعدَّل.

في المثال أدناه، يتم استنساخ الشريحة الأولى (الفهرس 0) وإلحاقها بنهاية العرض التقديمي.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation لتمثيل ملف العرض التقديمي.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي.
    presentation.slides.add_clone(presentation.slides[0])
    # حفظ العرض التقديمي المعدل إلى القرص.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **استنساخ إلى موضع محدد داخل نفس العرض التقديمي**

إذا كنت ترغب في استنساخ شريحة داخل نفس العرض التقديمي ووضعها في موضع مختلف، استخدم الطريقة `insert_clone`:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. الحصول على مجموعة الشرائح من كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. استدعاء الطريقة `insert_clone` على كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/)، مع تمرير الشريحة المراد استنساخها والفهرس الهدف للموضع الجديد.
1. حفظ العرض التقديمي المعدَّل.

في المثال أدناه، يتم استنساخ الشريحة في الفهرس 1 (الموضع 2) إلى الفهرس 2 (الموضع 3) داخل نفس العرض التقديمي.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation لتمثيل ملف العرض التقديمي.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # استنساخ الشريحة المطلوبة إلى الموضع المحدد (الفهرس) داخل نفس العرض التقديمي.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # حفظ العرض التقديمي المعدل إلى القرص.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **استنساخ في النهاية من عرض تقديمي آخر**

إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي وإلحاقها بنهاية عرض تقديمي آخر:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض التقديمي المصدر (الذي يحتوي على الشريحة المراد استنساخها).
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض التقديمي الهدف (حيث ستُضاف الشريحة).
1. الحصول على مجموعة الشرائح من العرض التقديمي الهدف.
1. استدعاء `add_clone` على كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/) في العرض الهدف، مع تمرير الشريحة من العرض المصدر.
1. حفظ العرض التقديمي الهدف المعدَّل.

في المثال أدناه، يتم استنساخ الشريحة في الفهرس 0 في العرض المصدر إلى نهاية العرض الهدف.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # إنشاء مثيل لفئة Presentation للملف PPTX الهدف (حيث سيتم استنساخ الشريحة).
    with slides.Presentation() as target_presentation:
        # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الهدف.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # حفظ العرض التقديمي الهدف إلى القرص.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **استنساخ إلى موضع محدد في عرض تقديمي آخر**

إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي وإدراجها في عرض تقديمي آخر في موضع محدد:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض التقديمي المصدر (الذي يحتوي على الشريحة المراد استنساخها).
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض التقديمي الهدف (حيث ستُضاف الشريحة).
1. الحصول على مجموعة الشرائح من العرض التقديمي الهدف.
1. استدعاء الطريقة `insert_clone` على كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/) في العرض الهدف، مع تمرير الشريحة من العرض المصدر والفهرس الهدف المرغوب.
1. حفظ العرض التقديمي الهدف المعدَّل.

في المثال أدناه، يتم استنساخ الشريحة في الفهرس 0 في العرض المصدر إلى الفهرس 2 (الموضع 3) في العرض الهدف.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # إنشاء مثيل لفئة Presentation للملف PPTX الهدف (حيث سيتم استنساخ الشريحة).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # إدراج نسخة مستنسخة من الشريحة الأولى من المصدر عند الفهرس 2 في العرض التقديمي الهدف.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # حفظ العرض التقديمي الهدف إلى القرص.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **استنساخ شريحة مع شريحة الماستر الخاصة بها إلى عرض تقديمي آخر**

إذا كنت بحاجة إلى استنساخ شريحة **مع الماستر الخاص بها** من عرض تقديمي واستخدامها في آخر، استنسخ أولاً شريحة الماستر المطلوبة من العرض المصدر إلى العرض الهدف. ثم استخدم ذلك الماستر المستهدف عند استنساخ الشريحة. الطريقة `add_clone(Slide, MasterSlide)` تتوقع **شريحة ماستر من العرض التقديمي الهدف**، وليس من المصدر.

لِاستنساخ شريحة مع ماسترها، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض التقديمي المصدر.
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض التقديمي الهدف.
1. الوصول إلى الشريحة المصدر التي سيتم استنساخها وشريحة الماستر الخاصة بها.
1. الحصول على [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/) من مجموعة الماستر في العرض الهدف.
1. استدعاء `add_clone` على كائن [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/)، مع تمرير الماستر المصدر لاستنساخه إلى الهدف.
1. الحصول على [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/) من مجموعة الشرائح في العرض الهدف.
1. استدعاء `add_clone` على كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/)، مع تمرير الشريحة المصدر والماستر المستنسخ في الهدف.
1. حفظ العرض التقديمي الهدف المعدَّل.

في المثال أدناه، يتم استنساخ الشريحة في الفهرس 0 في العرض المصدر إلى نهاية العرض الهدف باستخدام الماستر المستنسخ من المصدر.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # إنشاء مثيل لفئة Presentation للعرض التقديمي الهدف حيث سيتم استنساخ الشريحة.
    with slides.Presentation() as target_presentation:
        # الحصول على الشريحة الأولى من العرض التقديمي المصدر.
        source_slide = source_presentation.slides[0]
        # الحصول على شريحة الماستر المستخدمة من قبل الشريحة الأولى.
        source_master = source_slide.layout_slide.master_slide
        # استنساخ شريحة الماستر في مجموعة ماسترات العرض التقديمي الهدف.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # استنساخ الشريحة من العرض التقديمي المصدر إلى نهاية العرض التقديمي الهدف باستخدام الماستر المستنسخ.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # حفظ العرض التقديمي الهدف إلى القرص.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **استنساخ في النهاية ضمن قسم محدد**

مع Aspose.Slides for Python via .NET، يمكنك استنساخ شريحة من قسم من العرض التقديمي وإدراجها في قسم آخر داخل نفس العرض. للقيام بذلك، استخدم الطريقة `add_clone(Slide, Section)` في فئة [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/).

يظهر المثال التالي بلغة Python كيفية استنساخ شريحة وإدراج النسخة المستنسخة في قسم محدد:

```py
import aspose.slides as slides

# إنشاء عرض تقديمي فارغ جديد.
with slides.Presentation() as presentation:
    # إضافة شريحة فارغة بناءً على تخطيط الشريحة الأولى.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # إضافة شكل بيضاوي إلى الشريحة الجديدة؛ ستتم استنساخ هذه الشريحة لاحقًا.
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

## **التأكد من تطابق حجم الشريحة**

عند استنساخ الشرائح إلى عرض تقديمي آخر، تأكد من أن حجم الشرائح في العرض الهدف يطابق حجم العرض المصدر. إذا اختلف حجم الشرائح، لا يعيد Aspose.Slides تعديل مقاسات الأشكال المستنسخة تلقائيًا—تبقى إحداثياتها وأبعادها الأصلية محفوظة، مما قد يؤدي إلى ظهور المحتوى بشكل غير محاذٍ أو خروجه عن حدود الشريحة.

يمكنك ضبط حجم الشرائح في العرض الهدف ليتطابق مع المصدر قبل استنساخ الماستر والشريحة:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

قم بذلك قبل استنساخ الماستر والشريحة.

## **الأسئلة الشائعة**

### هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجع؟

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا لم تكن ترغب فيها، يمكنك [إزالتها](/slides/ar/python-net/presentation-notes/) بعد الإدراج.

### كيف يتم التعامل مع المخططات ومصادر بياناتها؟

يتم نسخ كائن المخطط وتنسيقه والبيانات المدمجة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل مصنف OLE مدمج)، يتم الحفاظ على هذا الارتباط كـ [كائن OLE](/slides/ar/python-net/manage-ole/). بعد النقل بين الملفات، يُنصَح بالتحقق من توفر البيانات وسلوك التحديث.

### هل يمكنني التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟

نعم. يمكنك إدراج النسخة المستنسخة عند فهرس شريحة محدد ووضعها في [القسم](/slides/ar/python-net/slide-section/) المختار. إذا لم يكن القسم الهدف موجودًا، أنشئه أولاً ثم انقل الشريحة إليه.