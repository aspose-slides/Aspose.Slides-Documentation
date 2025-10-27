---
title: الوصول إلى الشرائح في العروض التقديمية باستخدام بايثون
linktitle: الوصول إلى شريحة
type: docs
weight: 20
url: /ar/python-net/access-slide-in-presentation/
keywords:
- الوصول إلى شريحة
- فهرس الشريحة
- معرف الشريحة
- موضع الشريحة
- تغيير الموضع
- خصائص الشريحة
- رقم الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية الوصول إلى الشرائح وإدارتها في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET. عزّز الإنتاجية بأمثلة الشيفرة."
---

## **نظرة عامة**

يشرح هذا المقال كيفية الوصول إلى شرائح محددة في عرض PowerPoint باستخدام Aspose.Slides لبايثون. يظهر كيفية فتح عرض تقديمي، وإشارة إلى الشرائح حسب الفهرس أو حسب المعرف الفريد، وقراءة معلومات أساسية عن الشريحة اللازمة للتنقل داخل الملف. باستخدام هذه التقنيات، يمكنك تحديد موقع الشريحة المطلوبة بدقة للمعاينة أو المعالجة.

## **الوصول إلى شريحة حسب الفهرس**

الشرائح في العرض التقديمي تُرقم حسب الموضع بدءًا من 0. الشريحة الأولى لها فهرس 0، والشريحة الثانية فهرس 1، وهكذا.

تصنّف الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) (التي تمثّل ملف عرض) الشرائح عبر مجموعة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) من كائنات [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/).

الشيفرة بايثون التالية توضح كيفية الوصول إلى شريحة بحسب فهرسها:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # الحصول على شريحة بحسب فهرسها.
    slide = presentation.slides[0]
```

## **الوصول إلى شريحة حسب المعرف (ID)**

كل شريحة في العرض التقديمي لها معرف فريد مرتبط بها. يمكنك استخدام طريقة [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (المقدمة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) لاستهداف ذلك المعرف.

الشيفرة بايثون التالية توضح كيف تُعطي معرف شريحة صالح وتصل إلى تلك الشريحة عبر طريقة [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/):

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # الحصول على معرف شريحة.
    id = presentation.slides[0].slide_id
    # الوصول إلى الشريحة بحسب معرفها.
    slide = presentation.get_slide_by_id(id)
```

## **تغيير موضع الشريحة**

تمكّنك Aspose.Slides من تغيير موضع الشريحة. على سبيل المثال، يمكنك جعل الشريحة الأولى تصبح الثانية.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على إشارة إلى الشريحة التي تريد تغيير موضعها بحسب فهرسها.
1. تعيين موضع جديد للشريحة عبر خاصية [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/).
1. حفظ العرض التقديمي المعدل.

الشيفرة بايثون التالية تنقل الشريحة في الموضع 1 إلى الموضع 2:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # الحصول على الشريحة التي سيتغير موضعها.
    slide = presentation.slides[0]
    # تعيين الموضع الجديد للشريحة.
    slide.slide_number = 2
    # حفظ العرض التقديمي المعدل.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

تصبح الشريحة الأولى هي الثانية؛ وتصبح الشريحة الثانية هي الأولى. عند تغيير موضع شريحة، تُعدّل الشرائح الأخرى تلقائيًا.

## **تعيين رقم الشريحة**

باستخدام خاصية [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (المقدمة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) يمكنك تحديد رقم جديد للشريحة الأولى في العرض التقديمي. يُعيد هذا العملية حساب أرقام الشرائح الأخرى.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. تعيين رقم الشريحة.
1. حفظ العرض التقديمي المعدل.

الشيفرة بايثون التالية توضح عملية تعيين رقم الشريحة الأولى إلى 10:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # تعيين رقم الشريحة.
    presentation.first_slide_number = 10
    # حفظ العرض التقديمي المعدل.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

إذا كنت تفضّل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (وإخفاء الرقم على الشريحة الأولى) كالتالي:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # تعيين رقم الشريحة الأولى في العرض التقديمي.
    presentation.first_slide_number = 0

    # إظهار أرقام الشرائح لجميع الشرائح.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # إخفاء رقم الشريحة على الشريحة الأولى.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # حفظ العرض التقديمي المعدل.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل رقم الشريحة الذي يراه المستخدم يطابق فهرس المجموعة القائم على الصفر؟**

يمكن أن يبدأ الرقم المعروض على الشريحة من قيمة عشوائية (مثل 10) ولا يجب أن يطابق الفهرس؛ العلاقة تُتحكم بها عبر إعداد [رقم الشريحة الأولى](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) للعرض التقديمي.

**هل تؤثر الشرائح المخفيّة على الفهرسة؟**

نعم. الشريحة المخفيّة تبقى في المجموعة وتُحسب في الفهرسة؛ "مخفي" يشير إلى العرض فقط، وليس إلى موقعها في المجموعة.

**هل يتغير فهرس الشريحة عندما تُضاف أو تُحذف شرائح أخرى؟**

نعم. الفهارس دائمًا تعكس الترتيب الحالي للشرائح وتُعاد حسابها عند عمليات الإدراج، الحذف، أو النقل.