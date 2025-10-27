---
title: الوصول إلى الشرائح في العروض التقديمية باستخدام بايثون
linktitle: الوصول إلى شريحة
type: docs
weight: 20
url: /ar/python-net/developer-guide/presentation-slide/access-slide-in-presentation/
keywords:
- الوصول إلى شريحة
- فهرس الشريحة
- معرف الشريحة
- موضع الشريحة
- تغيير الموضع
- خصائص الشريحة
- رقم الشريحة
- باوربوينت
- أوبن دوكومنت
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "تعلم كيفية الوصول إلى الشرائح وإدارتها في عروض باوربوينت وأوبن دوكومنت باستخدام Aspose.Slides for Python عبر .NET. عزّز الإنتاجية بأمثلة التعليمات البرمجية."
---

## **نظرة عامة**

يشرح هذا المقال كيفية الوصول إلى شرائح محددة في عرض باوربوينت باستخدام Aspose.Slides for Python. يوضح كيفية فتح عرض تقديمي، والإشارة إلى الشرائح عبر الفهرس أو المعرف الفريد، وقراءة معلومات الشريحة الأساسية المطلوبة للتنقل داخل الملف. باستخدام هذه التقنيات، يمكنك تحديد الشريحة الدقيقة التي تريد فحصها أو معالجتها بثقة.

## **الوصول إلى شريحة عبر الفهرس**

يتم فهرسة الشرائح في العرض التقديمي بحسب الموضع بدءًا من 0. الشريحة الأولى لها فهرس 0، والشريحة الثانية لها فهرس 1، وهكذا.

تُظهر الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) (التي تمثل ملف عرض تقديمي) الشرائح عبر مجموعة [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) من كائنات [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/).

يظهر الشيفرة التالية بلغة بايثون كيفية الوصول إلى شريحة عبر فهرسها:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # الحصول على شريحة عبر فهرسها.
    slide = presentation.slides[0]
```

## **الوصول إلى شريحة عبر المعرف (ID)**

كل شريحة في العرض التقديمي لها معرف فريد مرتبط بها. يمكنك استخدام طريقة [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (التي توفرها فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) لاستهداف ذلك المعرف.

تُظهر الشيفرة التالية بلغة بايثون كيفية توفير معرف شريحة صالح والوصول إلى تلك الشريحة عبر طريقة [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/):

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # الحصول على معرف الشريحة.
    id = presentation.slides[0].slide_id
    # الوصول إلى الشريحة عبر معرفها.
    slide = presentation.get_slide_by_id(id)
```

## **تغيير موضع الشريحة**

يتيح لك Aspose.Slides تغيير موضع الشريحة. على سبيل المثال، يمكنك جعل الشريحة الأولى تصبح الثانية.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على إشارة إلى الشريحة التي تريد تغيير موضعها عبر فهرسها.
3. تعيين موضع جديد للشريحة عبر الخاصية [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/).
4. حفظ العرض التقديمي المعدل.

تُظهر الشيفرة التالية بلغة بايثون نقل الشريحة الموجودة في الموضع 1 إلى الموضع 2:

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

تصبح الشريحة الأولى هي الثانية؛ وتصبح الشريحة الثانية هي الأولى. عند تغيير موضع شريحة، يتم تعديل مواضع الشرائح الأخرى تلقائيًا.

## **تعيين رقم الشريحة**

باستخدام الخاصية [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (التي توفرها فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/))، يمكنك تحديد رقم جديد للشريحة الأولى في العرض التقديمي. تتسبب هذه العملية في إعادة حساب أرقام الشرائح الأخرى.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. تعيين رقم الشريحة.
3. حفظ العرض التقديمي المعدل.

تُظهر الشيفرة التالية بلغة بايثون عملية ضبط رقم الشريحة الأولى إلى 10:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # تعيين رقم الشريحة.
    presentation.first_slide_number = 10
    # حفظ العرض التقديمي المعدل.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

إذا كنت تفضل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (واخفاء الرقم على الشريحة الأولى) كما يلي:

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

## **الأسئلة المتكررة**

**هل رقم الشريحة الذي يراه المستخدم يطابق الفهرس الصفري للمجموعة؟**

يمكن أن يبدأ الرقم الظاهر على الشريحة من قيمة عشوائية (مثل 10) ولا يلزم أن يطابق الفهرس؛ يتم التحكم في العلاقة عبر إعداد [رقم الشريحة الأولى](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) في العرض التقديمي.

**هل تؤثر الشرائح المخفية على الفهرسة؟**

نعم. الشريحة المخفية تظل موجودة في المجموعة وتُحسب في الفهرسة؛ "المخفية" تشير إلى العرض فقط، وليس إلى موضعها في المجموعة.

**هل يتغير فهرس الشريحة عندما تُضاف أو تُحذف شرائح أخرى؟**

نعم. الفهارس دائمًا تعكس الترتيب الحالي للشرائح وتُعاد حسابها عند عمليات الإدراج أو الحذف أو النقل.