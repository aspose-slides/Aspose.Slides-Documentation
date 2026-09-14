---
title: الوصول إلى شرائح العرض التقديمي في بايثون
linktitle: الوصول إلى شريحة
type: docs
weight: 20
url: /ar/python-java/access-slide-in-presentation/
keywords:
- الوصول إلى شريحة
- فهرس الشريحة
- معرف الشريحة
- موقع الشريحة
- تغيير الموقع
- خصائص الشريحة
- رقم الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية الوصول إلى الشرائح وإدارتها في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر Java. عزز الإنتاجية بأمثلة الشيفرة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية الوصول إلى الشرائح وإدارتها في عرض تقديمي باستخدام Aspose.Slides. تُظهر كيفية استرداد الشرائح وفقًا لفهرسها الصفري من مجموعة الشرائح وكيفية الوصول إلى شريحة عبر معرّفها الفريد باستخدام طريقة [getSlideById](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlideById).

ستتعلم أيضًا كيفية تغيير موقع الشريحة باستخدام طريقة [setSlideNumber](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#setSlideNumber) وكيفية تحديد رقم الشريحة الأول للعرض التقديمي باستخدام طريقة [setFirstSlideNumber](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#setFirstSlideNumber). توضح الأمثلة تحميل عرض تقديمي، الحصول على مراجع الشرائح، تحديث ترتيب أو ترقيم الشرائح، وحفظ العرض التقديمي المعدل.

## **الوصول إلى شريحة حسب الفهرس**

جميع الشرائح في العرض التقديمي مرتبة رقمياً بناءً على موقع الشريحة بدءًا من الصفر. الشريحة الأولى يمكن الوصول إليها عبر الفهرس 0؛ الشريحة الثانية عبر الفهرس 1؛ وهكذا.

الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي تمثل ملف العرض التقديمي، تعرض جميع الشرائح كمجموعة [SlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/) (مجموعة من كائنات [Slide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/)). يُظهر هذا الكود بلغة Python كيفية الوصول إلى شريحة عبر فهرسها:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
presentation = Presentation("demo.pptx")
try:
    # الوصول إلى شريحة باستخدام فهرسها.
    slide = presentation.getSlides().get_Item(0)
finally:
    presentation.dispose()
```

## **الوصول إلى شريحة حسب المعرف**

كل شريحة في العرض التقديمي لها معرّف فريد مرتبط بها. يمكنك استخدام طريقة [getSlideById](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlideById) (المُعرَّضة من قبل الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/)) لاستهداف هذا المعرف. يُظهر هذا الكود بلغة Python كيفية توفير معرّف شريحة صالح والوصول إلى تلك الشريحة عبر طريقة [getSlideById](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlideById):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
presentation = Presentation("demo.pptx")
try:
    # الحصول على معرف الشريحة.
    slide_id = presentation.getSlides().get_Item(0).getSlideId()

    # الوصول إلى الشريحة عبر معرفها.
    slide = presentation.getSlideById(slide_id)
finally:
    presentation.dispose()
```

## **تغيير موقع الشريحة**

يسمح Aspose.Slides لك بتغيير موقع الشريحة. على سبيل المثال، يمكنك تحديد أن الشريحة الأولى يجب أن تصبح الشريحة الثانية.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة (التي تريد تغيير موقعها) عبر فهرستها.
1. ضبط موقع جديد للشريحة عبر طريقة [setSlideNumber](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#setSlideNumber).
1. حفظ العرض التقديمي المعدّل.

يُظهر هذا الكود بلغة Python عملية يتم فيها نقل الشريحة الموجودة في الموقع 1 إلى الموقع 2:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
presentation = Presentation("Presentation.pptx")
try:
    # الحصول على الشريحة التي سيتغير موقعها.
    slide = presentation.getSlides().get_Item(0)

    # تعيين الموقع الجديد للشريحة.
    slide.setSlideNumber(2)

    # حفظ العرض التقديمي المعدل.
    presentation.save("helloworld_Pos.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

أصبحت الشريحة الأولى هي الثانية؛ وأصبحت الشريحة الثانية هي الأولى. عند تغيير موقع شريحة، يتم تعديل باقي الشرائح تلقائيًا.

## **تحديد رقم الشريحة**

باستخدام طريقة [setFirstSlideNumber](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#setFirstSlideNumber) (المُعرَّضة من قبل الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/))، يمكنك تحديد رقم جديد للشريحة الأولى في العرض التقديمي. تتسبب هذه العملية في إعادة حساب أرقام الشرائح الأخرى.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. الحصول على رقم الشريحة.
1. ضبط رقم الشريحة.
1. حفظ العرض التقديمي المعدّل.

يُظهر هذا الكود بلغة Python عملية يتم فيها تعيين رقم الشريحة الأولى إلى 10:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# إنشاء كائن Presentation يمثل ملف عرض تقديمي.
presentation = Presentation("HelloWorld.pptx")
try:
    # الحصول على رقم الشريحة.
    first_slide_number = presentation.getFirstSlideNumber()

    # تعيين رقم الشريحة.
    presentation.setFirstSlideNumber(10)

    # حفظ العرض التقديمي المعدل.
    presentation.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

إذا كنت تفضّل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (وإخفاء الترقيم للشريحة الأولى) بهذه الطريقة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    # تعيين رقم أول شريحة في العرض التقديمي.
    presentation.setFirstSlideNumber(0)

    # إظهار أرقام الشرائح لجميع الشرائح.
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(True)

    # إخفاء رقم الشريحة للـشريحة الأولى.
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(False)

    # حفظ العرض التقديمي المعدل.
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يتطابق رقم الشريحة الذي يراه المستخدم مع الفهرس الصفري للمجموعة؟**

يمكن أن يبدأ الرقم المعروض على الشريحة من قيمة عشوائية (مثلاً 10) ولا يلزم أن يتطابق مع الفهرس؛ يتم التحكم في العلاقة عبر إعداد [first slide number](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#setFirstSlideNumber) في العرض التقديمي.

**هل تؤثر الشرائح المخفية على الترقيم؟**

نعم. تظل الشريحة المخفية في المجموعة وتُحسب في الفهرسة؛ "مخفية" تشير إلى العرض فقط، لا إلى موقعها في المجموعة.

**هل يتغير فهرس الشريحة عندما تُضاف أو تُحذف شرائح أخرى؟**

نعم. دائمًا ما تعكس الفهارس الترتيب الحالي للشرائح وتُعاد حسابها عند عمليات الإدراج أو الحذف أو النقل.