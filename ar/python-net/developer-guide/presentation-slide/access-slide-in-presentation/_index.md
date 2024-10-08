---
title: الوصول إلى الشريحة في العرض التقديمي
type: docs
weight: 20
url: /ar/python-net/access-slide-in-presentation/
keywords: "الوصول إلى عرض PowerPoint، الوصول إلى الشريحة، تحرير خصائص الشريحة، تغيير موضع الشريحة، تعيين رقم الشريحة، الفهرس، المعرف، الموضع Python، Aspose.Slides"
description: "الوصول إلى شريحة PowerPoint بواسطة الفهرس أو المعرف أو الموضع في Python. تحرير خصائص الشريحة"
---

تتيح لك Aspose.Slides الوصول إلى الشرائح بطريقتين: بواسطة الفهرس وبواسطة المعرف.

## **الوصول إلى الشريحة بواسطة الفهرس**

تكون جميع الشرائح في العرض التقديمي مرتبة رقمياً بناءً على موضع الشريحة بدءًا من 0. يمكن الوصول إلى الشريحة الأولى من خلال الفهرس 0؛ يتم الوصول إلى الشريحة الثانية من خلال الفهرس 1؛ وهكذا.

تقوم فئة Presentation، التي تمثل ملف العرض التقديمي، بإظهار جميع الشرائح كمجموعة [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)). يوضح لك هذا الكود Python كيفية الوصول إلى شريحة من خلال فهرسها:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # الحصول على مرجع الشريحة من خلال فهرسها
    slide = presentation.slides[0]
```

## **الوصول إلى الشريحة بواسطة المعرف**

تمتلك كل شريحة في العرض التقديمي معرفاً فريداً مرتبطاً بها. يمكنك استخدام طريقة `get_slide_by_id(id)` (المكشوفة من قبل فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) لاستهداف هذا المعرف. يوضح لك هذا الكود Python كيفية تقديم معرف شريحة صالح والوصول إلى تلك الشريحة من خلال طريقة `get_slide_by_id(id)`:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # الحصول على معرف الشريحة
    id = presentation.slides[0].slide_id
    # الوصول إلى الشريحة من خلال معرفها
    slide = presentation.get_slide_by_id(id)
```

## **تغيير موضع الشريحة**

تسمح لك Aspose.Slides بتغيير موضع الشريحة. على سبيل المثال، يمكنك تحديد أن الشريحة الأولى يجب أن تصبح الشريحة الثانية.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة (التي ترغب في تغيير موضعها) من خلال فهرسها
1. تعيين موضع جديد للشريحة من خلال خاصية `slide_number`. 
1. حفظ العرض التقديمي المعدل.

يظهر لك هذا الكود Python عملية يتم فيها نقل الشريحة في الموضع 1 إلى الموضع 2:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
with slides.Presentation(path + "ChangePosition.pptx") as pres:
    # الحصول على الشريحة التي سيتم تغيير موضعها
    sld = pres.slides[0]
    # تعيين الموضع الجديد للشريحة
    sld.slide_number = 2
    # حفظ العرض التقديمي المعدل
    pres.save("Aspose_out.pptx", slides.export.SaveFormat.PPTX)
```

أصبحت الشريحة الأولى هي الثانية؛ وأصبحت الشريحة الثانية هي الأولى. عند تغيير موضع الشريحة، يتم ضبط الشرائح الأخرى تلقائيًا.

## **تعيين رقم الشريحة**

باستخدام خاصية `first_slide_number` (المكشوفة من قبل فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/))، يمكنك تحديد رقم جديد للشريحة الأولى في العرض التقديمي. تسبب هذه العملية في إعادة حساب أرقام الشرائح الأخرى.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على رقم الشريحة.
1. تعيين رقم الشريحة.
1. حفظ العرض التقديمي المعدل.

يظهر لك هذا الكود Python عملية يتم فيها تعيين رقم الشريحة الأولى إلى 10:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # الحصول على رقم الشريحة
    firstSlideNumber = presentation.first_slide_number
    # تعيين رقم الشريحة
    presentation.first_slide_number = 10
    # حفظ العرض التقديمي المعدل
    presentation.save("Set_Slide_Number_out.pptx", slides.export.SaveFormat.PPTX)
```

إذا كنت تفضل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (وإخفاء الترقيم للشريحة الأولى) بهذه الطريقة:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # تعيين الرقم للشريحة الأولى في العرض التقديمي
    presentation.first_slide_number = 0

    # إظهار أرقام الشرائح لجميع الشرائح
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # إخفاء رقم الشريحة للشريحة الأولى
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # حفظ العرض التقديمي المعدل
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```