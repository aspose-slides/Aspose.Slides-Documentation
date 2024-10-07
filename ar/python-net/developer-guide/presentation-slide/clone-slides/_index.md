---
title: استنساخ الشرائح
type: docs
weight: 40
url: /python-net/clone-slides/
keywords: "استنساخ شريحة، نسخ شريحة، حفظ نسخة الشريحة، PowerPoint، عرض تقديمي، Python، Aspose.Slides"
description: "استنساخ شريحة PowerPoint في Python"
---

## **استنساخ الشرائح في العرض التقديمي**
الاستنساخ هو عملية صنع نسخة مطابقة أو نسخة متماثلة من شيء ما. يتيح Aspose.Slides لـ Python عبر .NET أيضًا إنشاء نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة في العرض التقديمي الحالي أو أي عرض تقديمي مفتوح آخر. تخلق عملية استنساخ الشريحة شريحة جديدة يمكن تعديلها من قبل المطورين دون تغيير الشريحة الأصلية. هناك عدة طرق ممكنة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موضع آخر داخل العرض التقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موضع آخر في عرض تقديمي آخر.
- استنساخ في موضع محدد في عرض تقديمي آخر.

في Aspose.Slides لـ Python عبر .NET، (مجموعة من [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) الكائنات) المعرَّضة من قبل الكائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) توفر طرق [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) و [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) لتنفيذ أنواع استنساخ الشرائح المذكورة أعلاه.
## **الاستنساخ في النهاية داخل عرض تقديمي**
إذا كنت ترغب في استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي في نهاية الشرائح الموجودة، استخدم طريقة [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) وفقًا للخطوات المدرجة أدناه:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. قم بإنشاء مثيل من فئة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) بالإشارة إلى مجموعة الشرائح المعرضة من قبل كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
3. استدعِ طريقة [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) المعرضة من كائن [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) ومرر الشريحة التي سيتم استنساخها كمعامل إلى طريقة [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
4. اكتب ملف العرض التقديمي المعدل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (تقع في الموضع الأول – فهرس صفر – من العرض التقديمي) إلى نهاية العرض التقديمي.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation التي تمثل ملف عرض تقديمي
with slides.Presentation(path + "CloneWithinSamePresentationToEnd.pptx") as pres:
    # استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    slds = pres.slides

    slds.add_clone(pres.slides[0])

    # كتابة العرض التقديمي المعدل إلى القرص
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```


## **الاستنساخ في موضع آخر داخل العرض التقديمي**
إذا كنت ترغب في استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في موضع مختلف، استخدم طريقة [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/):

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. قم بإنشاء مثيل من الفئة بالإشارة إلى مجموعة **Slides** المعرضة من قبل كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
3. استدعِ طريقة [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) المعرضة من كائن [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) ومرر الشريحة التي سيتم استنساخها مع الفهرس لموضع الجديد كمعامل إلى طريقة [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).
4. اكتب العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (تقع في فهرس صفر – الموضع 1 – من العرض التقديمي) إلى الفهرس 1 – الموضع 2 – من العرض التقديمي.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation التي تمثل ملف عرض تقديمي
with slides.Presentation(path + "CloneWithInSamePresentation.pptx") as pres:
    # استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    slds = pres.slides

    # استنساخ الشريحة المطلوبة إلى الفهرس المحدد في نفس العرض التقديمي
    slds.insert_clone(2, pres.slides[1])

    # كتابة العرض التقديمي المعدل إلى القرص
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **الاستنساخ في النهاية في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واحد واستخدامها في ملف عرض تقديمي آخر، في النهاية الشرائح الموجودة:

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تحتوي على العرض التقديمي الذي سيتم استنساخ الشريحة منه.
2. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تحتوي على العرض التقديمي الوجهة الذي ستتم إضافة الشريحة إليه.
3. قم بإنشاء مثيل من فئة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) بالإشارة إلى مجموعة **Slides** المعرضة من كائن Presentation للعرض التقديمي الوجهة.
4. استدعِ طريقة [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) المعرضة من كائن [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) ومرر الشريحة من العرض التقديمي المصدر كمعامل إلى طريقة [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
5. اكتب ملف العرض التقديمي المعدل الوجهة.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (من المؤشر الأول من العرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation لتحميل ملف العرض التقديمي المصدر
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # إنشاء مثيل لفئة Presentation لوجهة PPTX (حيث سيتم استنساخ الشريحة)
    with slides.Presentation() as destPres:
        # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
        slds = destPres.slides
        slds.add_clone(srcPres.slides[0])

        # كتابة العرض التقديمي الوجهة إلى القرص
        destPres.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **الاستنساخ في موضع آخر في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واحد واستخدامها في ملف عرض تقديمي آخر، في موضع محدد:

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تحتوي على العرض التقديمي المصدر الذي ستُستنسخ منه الشريحة.
2. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تحتوي على العرض التقديمي الذي ستتم إضافة الشريحة إليه.
3. أنشئ مثيل من فئة [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) بالإشارة إلى مجموعة الشرائح المعرضة من كائن Presentation للعرض التقديمي الوجهة.
4. استدعِ طريقة [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) المعرضة من كائن [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) ومرر الشريحة من العرض التقديمي المصدر مع الموضع المطلوب كمعامل إلى طريقة [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).
5. اكتب ملف العرض التقديمي المعدل الوجهة.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (من الفهرس صفر من العرض التقديمي المصدر) إلى الفهرس 1 (الموضع 2) من العرض التقديمي الوجهة.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation لتحميل ملف العرض التقديمي المصدر
with slides.Presentation(path + "CloneAtEndOfAnother.pptx") as srcPres:
    # إنشاء مثيل لفئة Presentation لعرض التقديمي الوجهة (حيث سيتم استنساخ الشريحة)
    with slides.Presentation("Aspose2_out.pptx") as destPres:
        slds = destPres.slides
        slds.insert_clone(2, srcPres.slides[0])

        # كتابة العرض التقديمي الوجهة إلى القرص
        destPres.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```


## **استنساخ في موضع محدد في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة تحتوي على شريحة رئيسية من عرض تقديمي من واستخدامها في عرض تقديمي آخر، تحتاج إلى استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى العرض التقديمي الوجهة أولاً. ثم تحتاج إلى استخدام تلك الشريحة الرئيسية لاستنساخ الشريحة مع الشريحة الرئيسية. تتوقع **add_clone(ISlide, IMasterSlide)** شريحة رئيسية من العرض التقديمي الوجهة بدلاً من العرض التقديمي المصدر. من أجل استنساخ الشريحة مع الرئيسية، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تحتوي على العرض التقديمي المصدر الذي سيتم استنساخ الشريحة منه.
2. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تحتوي على العرض التقديمي الوجهة الذي سيتم استنساخ الشريحة إليه.
3. الوصول إلى الشريحة التي ستُستنسخ مع الشريحة الرئيسية.
4. قم بإنشاء مثيل من فئة [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) بالإشارة إلى مجموعة الماستر المعرضة من كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) للعرض التقديمي الوجهة.
5. استدعِ طريقة [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) المعرضة من كائن [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) ومرر الماستر من PPTX المصدر الذي سيتم استنساخه كمعامل إلى طريقة [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
6. قم بإنشاء مثيل من فئة [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) عن طريق تعيين الإشارة إلى مجموعة الشرائح المعرضة من كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) للعرض التقديمي الوجهة.
7. استدعِ طريقة [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) المعرضة من كائن [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) ومرر الشريحة من العرض التقديمي المصدر التي سيتم استنساخها والشريحة الرئيسية كمعامل إلى طريقة [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/).
8. اكتب ملف العرض التقديمي المعدل الوجهة.

في المثال المعطى أدناه، قمنا باستنساخ شريحة تحتوي على شريحة رئيسية (تقع في الفهرس صفر من العرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة باستخدام شريحة رئيسية من الشريحة المصدر.

```py
import aspose.slides as slides

# إنشاء مثيل لفئة Presentation لتحميل ملف العرض التقديمي المصدر
with slides.Presentation(path + "CloneToAnotherPresentationWithMaster.pptx") as srcPres:
    # إنشاء مثيل لفئة Presentation للعرض التقديمي الوجهة (حيث سيتم استنساخ الشريحة)
    with slides.Presentation() as destPres:
        # إنشئ ISlide من مجموعة الشرائح في العرض التقديمي المصدر مع
        # شريحة رئيسية
        sourceSlide = srcPres.slides[0]
        sourceMaster = sourceSlide.layout_slide.master_slide

        # استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الماستر في
        # العرض التقديمي الوجهة
        masters = destPres.masters
        destMaster = sourceSlide.layout_slide.master_slide

        # استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الماستر في
        # العرض التقديمي الوجهة
        iSlide = masters.add_clone(sourceMaster)

        # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر مع الماستر المطلوب إلى نهاية
        # مجموعة الشرائح في العرض التقديمي الوجهة
        slds = destPres.slides
        slds.add_clone(sourceSlide, iSlide, True)
      
        # استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الماستر في العرض التقديمي الوجهة
        # حفظ العرض التقديمي الوجهة إلى القرص
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```



## الاستنساخ في النهاية في قسم محدد

مع Aspose.Slides لـ Python عبر .NET، يمكنك استنساخ شريحة من قسم واحد من عرض تقديمي وإدراج تلك الشريحة في قسم آخر في نفس العرض التقديمي. في هذه الحالة، يجب عليك استخدام طريقة [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) من واجهة [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/). 

يوضح لك هذا الشيفرة البرمجية في Python كيفية استنساخ شريحة وإدراج الشريحة المستنسخة في قسم محدد:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100) # للاستنساخ
    
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    section = pres.sections.add_section("Section2", slide2)

    pres.slides.add_clone(slide, section)
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```