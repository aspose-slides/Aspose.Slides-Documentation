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
- باوربوينت
- مستند مفتوح
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "تعلم كيفية الوصول إلى الشرائح وإدارتها في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. عزز الإنتاجية مع أمثلة الشيفرة."
---

## **نظرة عامة**

توضح هذه المقالة كيفية الوصول إلى شرائح معينة في عرض PowerPoint باستخدام Aspose.Slides للغة Python. تُظهر كيفية فتح العرض، والإشارة إلى الشرائح وفق الفهرس أو المعرف الفريد، وقراءة المعلومات الأساسية للشرائح اللازمة للتنقل داخل الملف. باستخدام هذه التقنيات، يمكنك تحديد الشريحة المطلوبة بدقة للفحص أو المعالجة.

## **الوصول إلى شريحة حسب الفهرس**

يتم فهرسة الشرائح في العرض وفقًا للموضع بدءًا من 0. الشريحة الأولى لها فهرس 0، الشريحة الثانية لها فهرس 1، وهكذا.

تُصدر فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) (التي تمثل ملف عرض) الشرائح عبر [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) من كائنات [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/).

يعرض الشيفرة التالية بلغة Python كيفية الوصول إلى شريحة وفق فهرسها:
```python
import aspose.slides as slides

# إنشاء عرض تقديمي يمثل ملف عرض.
with slides.Presentation("sample.pptx") as presentation:
    # احصل على شريحة حسب فهرستها.
    slide = presentation.slides[0]
```


## **الوصول إلى شريحة حسب المعرف**

كل شريحة في العرض لها معرف فريد مرتبط بها. يمكنك استخدام طريقة [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (المُستَخرجة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) لاستهداف ذلك المعرف.

يعرض الشيفرة التالية بلغة Python كيفية توفير معرف شريحة صالح والوصول إلى تلك الشريحة عبر طريقة [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/):
```python
import aspose.slides as slides

# إنشاء عرض تقديمي يمثل ملف عرض.
with slides.Presentation("sample.pptx") as presentation:
    # الحصول على معرف الشريحة.
    id = presentation.slides[0].slide_id
    # الوصول إلى الشريحة باستخدام معرفها.
    slide = presentation.get_slide_by_id(id)
```


## **تغيير موضع الشريحة**

تسمح لك Aspose.Slides بتغيير موضع الشريحة. على سبيل المثال، يمكنك جعل الشريحة الأولى تصبح الثانية.

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة التي تريد تغيير موضعها بحسب فهرسها.
1. اضبط موضعًا جديدًا للشريحة عبر الخاصية [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/).
1. احفظ العرض المُعدَّل.

يعرض الشيفرة التالية بلغة Python نقل الشريحة التي في الموضع 1 إلى الموضع 2:
```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # احصل على الشريحة التي سيتم تغيير موضعها.
    slide = presentation.slides[0]
    # حدد الموضع الجديد للشريحة.
    slide.slide_number = 2
    # احفظ العرض التقديمي المعدل.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```


تصبح الشريحة الأولى هي الثانية؛ وتصبح الشريحة الثانية هي الأولى. عند تغيير موضع شريحة، يتم تعديل باقي الشرائح تلقائيًا.

## **تعيين رقم الشريحة**

باستخدام الخاصية [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (المُستَخرجة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/))، يمكنك تحديد رقم جديد للشريحة الأولى في العرض. يؤدي هذا الإجراء إلى إعادة حساب أرقام الشرائح الأخرى.

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. اضبط رقم الشريحة.
1. احفظ العرض المُعدَّل.

يعرض الشيفرة التالية بلغة Python عملية يتم فيها تعيين رقم الشريحة الأولى إلى 10:
```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    # تعيين رقم الشريحة.
    presentation.first_slide_number = 10
    # حفظ العرض التقديمي المعدل.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```


إذا كنت تفضل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (وحذف الرقم من الشريحة الأولى) كما يلي:
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

    # إخفاء رقم الشريحة في الشريحة الأولى.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # حفظ العرض التقديمي المعدل.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة المتكررة**

**هل رقم الشريحة الذي يراه المستخدم يطابق الفهرس الصفري للمجموعة؟**

يمكن أن يبدأ الرقم المعروض على الشريحة من قيمة عشوائية (مثل 10) ولا يلزم أن يطابق الفهرس؛ يتم التحكم في العلاقة عبر إعداد [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) للعرض.

**هل تؤثر الشرائح المخفية على الفهرسة؟**

نعم. تظل الشريحة المخفية في المجموعة وتُحسب في الفهرسة؛ "مخفي" يشير إلى العرض فقط، وليس إلى موقعها في المجموعة.

**هل يتغير فهرس الشريحة عندما تُضاف أو تُحذف شرائح أخرى؟**

نعم. الفهارس دائمًا تعكس الترتيب الحالي للشرائح وتُعاد حسابها عند عمليات الإدراج والحذف والنقل.