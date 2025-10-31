---
title: الوصول إلى الشرائح في العروض التقديمية باستخدام بايثون
linktitle: الوصول إلى الشريحة
type: docs
weight: 20
url: /ar/python-net/access-slide-in-presentation/
keywords:
- الوصول إلى الشريحة
- فهرس الشريحة
- معرف الشريحة
- موضع الشريحة
- تغيير الموضع
- خصائص الشريحة
- رقم الشريحة
- PowerPoint
- OpenDocument
- العرض التقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية الوصول إلى الشرائح وإدارتها في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET. عزز الإنتاجية من خلال أمثلة الأكواد."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية الوصول إلى شرائح محددة في عرض PowerPoint باستخدام Aspose.Slides لبايثون. تُظهر كيفية فتح عرض تقديمي، والإشارة إلى الشرائح عبر الفهرس أو عبر المعرف الفريد، وقراءة معلومات أساسية عن الشريحة اللازمة للتنقل داخل الملف. باستخدام هذه التقنيات، يمكنك تحديد موقع الشريحة المطلوبة بدقة للفحص أو المعالجة.

## **الوصول إلى شريحة عبر الفهرس**

يتم فهرسة الشرائح في العرض حسب الموقع بدءًا من 0. الشريحة الأولى لها فهرس 0، والشريحة الثانية لها فهرس 1، وهكذا.

يظهر فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) (التي تمثل ملف عرض تقديمي) الشرائح من خلال [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) من كائنات [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/).

الكود التالي بايثون يوضح كيفية الوصول إلى شريحة عبر فهرسها:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # الحصول على شريحة وفقًا لموقعها.
    slide = presentation.slides[0]
```

## **الوصول إلى شريحة عبر المعرف**

كل شريحة في العرض لها معرف فريد مرتبط بها. يمكنك استخدام طريقة [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (المعروضة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) لاستهداف ذلك المعرف.

الكود التالي بايثون يوضح كيفية توفير معرف شريحة صالح والوصول إلى تلك الشريحة عبر طريقة [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/):

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # الحصول على معرف الشريحة.
    id = presentation.slides[0].slide_id
    # الوصول إلى الشريحة باستخدام معرفها.
    slide = presentation.get_slide_by_id(id)
```

## **تغيير موضع الشريحة**

تتيح لك Aspose.Slides تغيير موضع الشريحة. على سبيل المثال، يمكنك جعل الشريحة الأولى تصبح الثانية.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة التي تريد تغيير موضعها عبر فهرستها.
3. تعيين موضع جديد للشريحة من خلال خاصية [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/).
4. حفظ العرض التقديمي المعدل.

الكود التالي بايثون ينقل الشريحة في الموضع 1 إلى الموضع 2:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # الحصول على الشريحة التي سيتم تغيير موقعها.
    slide = presentation.slides[0]
    # تعيين الموقع الجديد للشريحة.
    slide.slide_number = 2
    # حفظ العرض التقديمي المعدل.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

تصبح الشريحة الأولى هي الثانية؛ وتصبح الشريحة الثانية هي الأولى. عندما تغير موضع شريحة، يتم تعديل باقي الشرائح تلقائيًا.

## **تعيين رقم الشريحة**

باستخدام خاصية [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (المعروضة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) يمكنك تحديد رقم جديد للشريحة الأولى في العرض. يؤدي هذا إلى إعادة حساب أرقام الشرائح الأخرى.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. تعيين رقم الشريحة.
3. حفظ العرض التقديمي المعدل.

الكود التالي بايثون يوضح عملية تعيين رقم الشريحة الأولى إلى 10:

```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # تعيين رقم الشريحة.
    presentation.first_slide_number = 10
    # حفظ العرض التقديمي المعدل.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

إذا كنت تفضل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية ( وإخفاء الرقم على الشريحة الأولى ) كالتالي:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # تعيين رقم أول شريحة في العرض التقديمي.
    presentation.first_slide_number = 0

    # إظهار أرقام الشرائح لجميع الشرائح.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # إخفاء رقم الشريحة على الشريحة الأولى.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # حفظ العرض التقديمي المعدل.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**هل رقم الشريحة الذي يراه المستخدم يطابق الفهرس القائم على الصفر في المجموعة؟**

يمكن أن يبدأ الرقم المعروض على الشريحة من قيمة عشوائية (مثلاً 10) ولا يلزم أن يطابق الفهرس؛ يتم التحكم في العلاقة عبر إعداد [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) للعرض.

**هل تؤثر الشرائح المخفية على الفهرسة؟**

نعم. الشريحة المخفية تظل في المجموعة وتُحسب في الفهرسة؛ "مخفية" تشير إلى العرض فقط، وليس إلى موقعها في المجموعة.

**هل يتغير فهرس الشريحة عندما يتم إضافة أو حذف شرائح أخرى؟**

نعم. الفهارس دائمًا تعكس الترتيب الحالي للشرائح ويتم إعادة حسابها عند عمليات الإدراج أو الحذف أو النقل.