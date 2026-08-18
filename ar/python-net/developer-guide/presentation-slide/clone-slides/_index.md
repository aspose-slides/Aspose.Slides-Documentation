---
title: "استنساخ شرائح PowerPoint في Python"
linktitle: "استنساخ الشرائح"
type: docs
weight: 40
url: /ar/python-net/clone-slides/
keywords:
  - "استنساخ شريحة"
  - "نسخ شريحة"
  - "حفظ شريحة"
  - "PowerPoint"
  - "عرض تقديمي"
  - "Python"
  - "Aspose.Slides"
description: "استنسخ أو كرّر شرائح PowerPoint بسرعة باستخدام Aspose.Slides لبايثون عبر .NET. اتبع أمثلتنا البرمجية الواضحة ونصائحنا لأتمتة إنشاء ملفات PPT في ثوانٍ، وزيادة الإنتاجية، وإزالة العمل اليدوي."
---
## **المقدمة**

التصنيع هو عملية إنشاء نسخة دقيقة أو متماثلة لشيء ما. تتيح لك Aspose.Slides أيضًا نسخ (استنساخ) أي شريحة ثم إدراج الشريحة المستنسخة في العرض التقديمي الحالي أو أي عرض تقديمي مفتوح آخر. إنشاء نسخة من الشريحة يخلق شريحة جديدة يمكن للمطورين تعديلها دون التأثير على الشريحة الأصلية. هناك عدة طرق لاستنساخ شريحة:

- استنساخ في نهاية العرض التقديمي.
- استنساخ في موقع آخر داخل العرض التقديمي.
- استنساخ في نهاية عرض تقديمي آخر.
- استنساخ في موقع آخر في عرض تقديمي آخر.
- استنساخ في موقع محدد في عرض تقديمي آخر.

في Aspose.Slides لبايثون عبر .NET، توفر [مجموعة الشرائح](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/) التي يعرضها كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) الطريقتين `add_clone` و `insert_clone` لأداء هذه الأنواع من استنساخ الشرائح.

## **التثبيت**

```bash
pip install aspose.slides
```

## **استنساخ في النهاية داخل نفس العرض التقديمي**

إذا كنت ترغب في استنساخ شريحة داخل نفس العرض التقديمي وإلحاقها في نهاية الشرائح الحالية، استخدم الطريقة `add_clone`. اتبع الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. الحصول على مجموعة الشرائح من كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. استدعاء الطريقة `add_clone` على [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/)، مع تمرير الشريحة التي سيتم استنساخها.
1. حفظ العرض التقديمي المعدل.

في المثال أدناه، يتم استنساخ الشريحة الأولى (الفهرس 0) وإلحاقها بنهاية العرض التقديمي.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف العرض التقديمي.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي.
    presentation.slides.add_clone(presentation.slides[0])
    # حفظ العرض التقديمي المعدل على القرص.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **استنساخ إلى موقع محدد داخل نفس العرض التقديمي**

إذا كنت ترغب في استنساخ شريحة داخل نفس العرض التقديمي ووضعها في موقع مختلف، استخدم الطريقة `insert_clone`:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. الحصول على مجموعة الشرائح من كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).
1. استدعاء الطريقة `insert_clone` على [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/)، مع تمرير الشريحة التي سيتم استنساخها والفهرس المستهدف لموقعها الجديد.
1. حفظ العرض التقديمي المعدل.

في المثال أدناه، يتم استنساخ الشريحة الموجودة في الفهرس 1 (الموقع 2) إلى الفهرس 2 (الموقع 3) داخل نفس العرض التقديمي.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف العرض التقديمي.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # استنساخ الشريحة المطلوبة إلى الموقع المحدد (الفهرس) داخل نفس العرض التقديمي.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # حفظ العرض التقديمي المعدل على القرص.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **استنساخ في نهاية عرض تقديمي آخر**

إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي وإلحاقها في نهاية عرض تقديمي آخر:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض المصدر (الذي يحتوي على الشريحة المراد استنساخها).
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض الهدف (حيث ستتم إضافة الشريحة).
1. الحصول على مجموعة الشرائح من العرض الهدف.
1. استدعاء `add_clone` على [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/) الخاصة بالعرض الهدف، وتمرير الشريحة من العرض المصدر.
1. حفظ العرض الهدف المعدل.

في المثال أدناه، يتم استنساخ الشريحة الموجودة في الفهرس 0 في العرض التقديمي المصدر إلى نهاية العرض التقديمي الهدف.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # إنشاء كائن من فئة Presentation للملف PPTX الهدف (حيث سيتم استنساخ الشريحة).
    with slides.Presentation() as target_presentation:
        # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الهدف.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # حفظ العرض التقديمي الهدف على القرص.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **استنساخ إلى موقع محدد في عرض تقديمي آخر**

إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي وإدراجها في عرض آخر في موقع محدد:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض المصدر (الذي يحتوي على الشريحة المراد استنساخها).
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض الهدف (حيث ستتم إضافة الشريحة).
1. الحصول على مجموعة الشرائح من العرض الهدف.
1. استدعاء الطريقة `insert_clone` على [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/) الخاصة بالعرض الهدف، وتمرير الشريحة من العرض المصدر والفهرس المستهدف المطلوب.
1. حفظ العرض الهدف المعدل.

في المثال أدناه، يتم استنساخ الشريحة الموجودة في الفهرس 0 في العرض التقديمي المصدر إلى الفهرس 2 (الموقع 3) في العرض التقديمي الهدف.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # إنشاء كائن من فئة Presentation للملف PPTX الهدف (حيث سيتم استنساخ الشريحة).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # إدراج نسخة مستنسخة من الشريحة الأولى من المصدر عند الفهرس 2 في العرض التقديمي الهدف.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # حفظ العرض التقديمي الهدف على القرص.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **استنساخ شريحة مع شريحة ماستر الخاصة بها إلى عرض تقديمي آخر**

إذا كنت بحاجة إلى استنساخ شريحة **مع الماستر** من عرض تقديمي واستخدامها في آخر، قم أولاً باستنساخ شريحة الماستر المطلوبة من العرض المصدر إلى العرض الهدف. ثم استخدم ذلك الماستر الهدف عند استنساخ الشريحة. الطريقة `add_clone(Slide, MasterSlide)` تتوقع **شريحة ماستر من العرض الهدف**، لا من المصدر.

لاستنساخ شريحة مع ماسترها، اتبع الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض المصدر (الذي يحتوي على الشريحة المراد استنساخها).
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) للعرض الهدف.
1. الوصول إلى الشريحة المصدر التي سيتم استنساخها وماسترها.
1. الحصول على [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/) من مجموعة ماستر العرض الهدف.
1. استدعاء `add_clone` على [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/)، وتمرير ماستر المصدر لاستنساخه إلى الهدف.
1. الحصول على [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/) من مجموعة الشرائح للعرض الهدف.
1. استدعاء `add_clone` على [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/)، وتمرير الشريحة المصدر والماستر المستنسخ للهدف.
1. حفظ العرض الهدف المعدل.

في المثال أدناه، يتم استنساخ الشريحة الموجودة في الفهرس 0 في العرض التقديمي المصدر إلى نهاية العرض التقديمي الهدف باستخدام الماستر المستنسخ من المصدر.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation لتمثيل ملف العرض التقديمي المصدر.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # إنشاء كائن من فئة Presentation للعرض التقديمي الهدف حيث سيتم استنساخ الشريحة.
    with slides.Presentation() as target_presentation:
        # الحصول على الشريحة الأولى من العرض التقديمي المصدر.
        source_slide = source_presentation.slides[0]
        # الحصول على شريحة الماستر المستخدمة من قبل الشريحة الأولى.
        source_master = source_slide.layout_slide.master_slide
        # استنساخ شريحة الماستر إلى مجموعة الماسترز في العرض التقديمي الهدف.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # استنساخ الشريحة من العرض التقديمي المصدر إلى نهاية العرض التقديمي الهدف باستخدام الماستر المستنسخ.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # حفظ العرض التقديمي الهدف على القرص.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **استنساخ في النهاية في قسم محدد**

مع Aspose.Slides لبايثون عبر .NET، يمكنك استنساخ شريحة من قسم في عرض تقديمي وإدراجها في قسم آخر داخل نفس العرض. للقيام بذلك، استخدم طريقة `add_clone(Slide, Section)` من فئة [SlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/).

يعرض المثال التالي بلغة Python كيفية استنساخ شريحة وإدراج النسخة المستنسخة في قسم محدد:

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
    # إنشاء قسم باسم "Section2" يبدأ من الشريحة slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # استنساخ الشريحة التي تم إنشاؤها مسبقًا إلى قسم "Section2".
    presentation.slides.add_clone(slide, section)
    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **التأكد من توافق حجم الشريحة**

عند استنساخ الشرائح إلى عرض تقديمي آخر، تأكد من أن العرض الهدف يملك نفس حجم الشريحة كالملف المصدر. إذا اختلفت أحجام الشرائح، لا يقوم Aspose.Slides بإعادة تحجيم الأشكال المستنسخة تلقائيًا—تظل إحداثياتها وأبعادها الأصلية محفوظة، مما قد يؤدي إلى ظهور المحتوى غير مرتب أو يمتد خارج حدود الشريحة.

يمكنك تعيين حجم شرائح العرض التقديمي الهدف ليتطابق مع المصدر قبل استنساخ الماستر والشريحة:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

قم بذلك قبل استنساخ الماستر والشريحة.

## **الأسئلة الشائعة**

**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجعين؟**

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا كنت لا تريدها، [قم بإزالتها](/slides/ar/python-net/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر البيانات الخاصة بها؟**

يتم نسخ كائن المخطط، والتنسيق، والبيانات المضمّنة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثلاً، دفتر عمل مضمن كـ OLE)، فإن هذا الارتباط يُحفظ كـ [كائن OLE](/slides/ar/python-net/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**

نعم. يمكنك إدراج النسخة المستنسخة عند فهرس شريحة محدد ووضعها في [قسم](/slides/ar/python-net/slide-section/) مختار. إذا لم يكن القسم الهدف موجودًا، أنشئه أولاً ثم انقل الشريحة إليه.