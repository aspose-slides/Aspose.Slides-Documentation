---
title: الوصول إلى الشرائح في العروض التقديمية باستخدام Python
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
- العرض التقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية الوصول إلى الشرائح وإدارتها في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Python عبر .NET. زد الإنتاجية بأمثلة الشيفرات."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية الوصول إلى شرائح محددة في عرض PowerPoint باستخدام Aspose.Slides for Python. تعرض كيفية فتح عرض تقديمي، والإشارة إلى الشرائح عبر الفهرس أو عبر المعرف الفريد، وقراءة المعلومات الأساسية للشرائح المطلوبة للتنقل داخل الملف. باستخدام هذه التقنيات، يمكنك تحديد موقع الشريحة المطلوبة بدقة لتفحصها أو معالجتها.

## **الوصول إلى شريحة عن طريق الفهرس**

يتم فهرسة الشرائح في العرض التقديمي بحسب الموضع بدءًا من 0. الشريحة الأولى لها فهرس 0، والشريحة الثانية لها فهرس 1، وهكذا.

فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) (التي تمثل ملف عرض تقديمي) تُظهر الشرائح عبر [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) من كائنات [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/).

الكود التالي بلغة Python يوضح كيفية الوصول إلى شريحة عبر فهرستها:

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide by its index.
    slide = presentation.slides[0]
```

## **الوصول إلى شريحة عن طريق المعرف**

كل شريحة في العرض التقديمي لها معرف فريد مرتبط بها. يمكنك استخدام طريقة [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (المقدمة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) لاستهداف ذلك المعرف.

الكود التالي بلغة Python يوضح كيفية توفير معرف شريحة صالح والوصول إلى تلك الشريحة عبر طريقة [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/):

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide ID.
    id = presentation.slides[0].slide_id
    # Access the slide by its ID.
    slide = presentation.get_slide_by_id(id)
```

## **تغيير موضع الشريحة**

تسمح لك Aspose.Slides بتغيير موضع الشريحة. على سبيل المثال، يمكنك جعل الشريحة الأولى تصبح الثانية.

1. أنشئ مثيلًا لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على إشارة إلى الشريحة التي تريد تغيير موضعها عبر فهرستها.
3. حدد موضعًا جديدًا للشريحة عبر خاصية [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/).
4. احفظ العرض التقديمي المعدل.

الكود التالي بلغة Python ينقل الشريحة في الموضع 1 إلى الموضع 2:

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get the slide whose position will be changed.
    slide = presentation.slides[0]
    # Set the new position for the slide.
    slide.slide_number = 2
    # Save the modified presentation.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

تصبح الشريحة الأولى هي الثانية؛ وتصبح الشريحة الثانية هي الأولى. عندما تغير موضع شريحة، تُضبط الشرائح الأخرى تلقائيًا.

## **تعيين رقم الشريحة**

باستخدام خاصية [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (المقدمة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/))، يمكنك تحديد رقم جديد للشريحة الأولى في العرض التقديمي. يؤدي هذا الإجراء إلى إعادة حساب أرقام الشرائح الأخرى.

1. أنشئ مثيلًا لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. عيّن رقم الشريحة.
3. احفظ العرض التقديمي المعدل.

الكود التالي بلغة Python يوضح عملية يتم فيها تعيين رقم الشريحة الأولى إلى 10:

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Set the slide number.
    presentation.first_slide_number = 10
    # Save the modified presentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

إذا كنت تفضل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (وإخفاء الرقم على الشريحة الأولى) كما يلي:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Set the number for the first slide in the presentation.
    presentation.first_slide_number = 0

    # Show slide numbers for all slides.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Hide the slide number on the first slide.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Save the modified presentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**هل يتطابق رقم الشريحة الذي يظهر للمستخدم مع الفهرس الصفري للمجموعة؟**

يمكن أن يبدأ الرقم المعروض على الشريحة من قيمة عشوائية (مثال: 10) ولا يلزم أن يتطابق مع الفهرس؛ تُتحكم العلاقة بواسطة إعداد [رقم الشريحة الأولى](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) للعرض التقديمي.

**هل تؤثر الشرائح المخفية على الفهرسة؟**

نعم. الشريحة المخفية تظل في المجموعة وتُحسب في الفهرسة؛ "مخفي" يشير إلى العرض فقط، وليس إلى موقعها في المجموعة.

**هل يتغير فهرس الشريحة عندما تُضاف أو تُحذف شرائح أخرى؟**

نعم. الفهارس دائمًا تعكس الترتيب الحالي للشرائح وتُعيد حسابها عند عمليات الإدراج أو الحذف أو النقل.