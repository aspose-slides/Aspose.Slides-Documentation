---
title: استنساخ شرائح العرض التقديمي في بايثون
linktitle: استنساخ الشرائح
type: docs
weight: 35
url: /ar/python-java/clone-slides/
keywords:
- استنساخ شريحة
- نسخ شريحة
- حفظ شريحة
- باوربوينت
- مستند مفتوح
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "استنسخ شرائح PowerPoint بسرعة باستخدام Aspose.Slides for Python via Java. اتبع أمثلتنا الواضحة للشفرة لأتمتة إنشاء عروض PPT في ثوانٍ وإزالة العمل اليدوي."
---
## **المقدمة**

النسخ هو العملية التي تُنشئ نسخة مطابقة أو متماثلة من شيء ما. تجعل Aspose.Slides for Python via Java من الممكن إنشاء نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة في العرض التقديمي الحالي أو أي عرض تقديمي آخر مفتوح. عملية استنساخ الشرائح تُنشئ شريحة جديدة يمكن للمطورين تعديلها دون تغيير الشريحة الأصلية. هناك عدة طرق لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موضع آخر داخل عرض تقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موضع آخر في عرض تقديمي آخر.
- استنساخ مع الشريحة الرئيسية الخاصة به في عرض تقديمي آخر.

في Aspose.Slides for Python via Java، مجموعة الشرائح (مجموعة من [Slide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/) objects) التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) توفر طريقتي [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) و[insertClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#insertClone) لأداء الأنواع المذكورة أعلاه من استنساخ الشرائح.

## **استنساخ شريحة في نهاية عرض تقديمي**

إذا كنت تريد استنساخ شريحة ثم استخدامها داخل ملف العرض التقديمي نفسه في نهاية الشرائح الموجودة، استخدم طريقة [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) وفقًا للخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. الحصول على كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/) بالإشارة إلى مجموعة Slides التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/) وتمرير الشريحة المراد استنساخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone).
1. كتابة ملف العرض التقديمي المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (تقع في الموضع الأول – الفهرس صفر – للعرض التقديمي) إلى نهاية العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # كتابة العرض التقديمي المعدل إلى القرص
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استنساخ شريحة إلى موضع آخر داخل عرض تقديمي**

إذا كنت تريد استنساخ شريحة ثم استخدامها داخل ملف العرض التقديمي نفسه ولكن في موضع مختلف، استخدم طريقة [insertClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#insertClone):

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. الحصول على إشارة إلى مجموعة الشرائح التي تُرجعها طريقة [getSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlides) على كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#insertClone) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/) وتمرير الشريحة المراد استنساخها مع الفهرس للموضع الجديد كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#insertClone).
1. كتابة العرض التقديمي المعدل بصيغة PPTX.

في المثال أدناه، قمنا باستنساخ شريحة (تقع في الفهرس 1 – الموضع 2 – للعرض التقديمي) إلى الفهرس 2 – الموضع 3 – للعرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # الحصول على مجموعة الشرائح في العرض التقديمي
    slides = presentation.getSlides()

    # استنساخ الشريحة المطلوبة إلى الفهرس المحدد في نفس العرض التقديمي
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # كتابة العرض التقديمي المعدل إلى القرص
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استنساخ شريحة في نهاية عرض تقديمي آخر**

إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واحد واستخدامها في عرض تقديمي آخر، في نهاية الشرائح الموجودة:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي تحتوي على العرض التقديمي المصدر للشرائح.
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي تحتوي على العرض التقديمي الوجهة الذي ستُضاف إليه الشريحة.
1. الحصول على كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/) بالإشارة إلى مجموعة الشرائح التي تُرجعها طريقة [getSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlides) على كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) للعرض التقديمي الوجهة.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/) وتمرير الشريحة من العرض التقديمي المصدر كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone).
1. كتابة ملف العرض التقديمي الوجهة المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (من الفهرس 0 للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # إنشاء كائن من فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    destination_presentation = Presentation()
    try:
        # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # كتابة العرض التقديمي الوجهة إلى القرص
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **استنساخ شريحة إلى موضع آخر في عرض تقديمي آخر**

إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واحد واستخدامها في عرض تقديمي آخر، في موضع محدد:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي تحتوي على العرض التقديمي المصدر للشرائح.
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي تحتوي على العرض التقديمي الوجهة التي ستُضاف إليها الشريحة.
1. الحصول على كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/) بالإشارة إلى مجموعة Slides التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) للعرض التقديمي الوجهة.
1. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#insertClone) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/) وتمرير الشريحة من العرض التقديمي المصدر مع الموضع المطلوب كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#insertClone).
1. كتابة ملف العرض التقديمي الوجهة المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (من الفهرس صفر للعرض التقديمي المصدر) إلى الفهرس 1 (الموضع 2) للعرض التقديمي الوجهة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # إنشاء كائن من فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    destination_presentation = Presentation()
    try:
        # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى الفهرس المحدد في العرض التقديمي الوجهة
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # كتابة العرض التقديمي الوجهة إلى القرص
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **استنساخ شريحة مع شريحتها الرئيسية إلى عرض تقديمي آخر**

إذا كنت تحتاج إلى استنساخ شريحة مع شريحتها الرئيسية من عرض تقديمي واحد واستخدامها في عرض تقديمي آخر، يجب أولاً استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى العرض التقديمي الوجهة. ثم استخدم الشريحة الرئيسية المستنسخة عند استنساخ الشريحة. تتوقع طريقة [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) شريحة رئيسية من العرض التقديمي الوجهة وليس من المصدر. لتستنسخ الشريحة مع شريحة رئيسية، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي تحتوي على العرض التقديمي المصدر.
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) التي تحتوي على العرض التقديمي الوجهة.
1. الوصول إلى الشريحة المراد استنساخها مع شريحتها الرئيسية.
1. الحصول على كائن [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslidecollection/) بالإشارة إلى مجموعة Masters التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) للعرض التقديمي الوجهة.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslidecollection/#addClone) التي يُظهرها كائن [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslidecollection/) وتمرير الشريحة الرئيسية من العرض التقديمي المصدر لِاستنساخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslidecollection/#addClone).
1. الحصول على كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/) بالإشارة إلى مجموعة Slides التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) للعرض التقديمي الوجهة.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/) وتمرير الشريحة من العرض التقديمي المصدر مع الشريحة الرئيسية كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone).
1. كتابة ملف العرض التقديمي الوجهة المعدل.

في المثال أدناه، قمنا باستنساخ شريحة مع شريحة رئيسية (تقع في الفهرس صفر للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة باستخدام شريحة المصدر الرئيسية.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # إنشاء كائن من فئة Presentation للعرض التقديمي الوجهة (حيث سيتم استنساخ الشريحة)
    destination_presentation = Presentation()
    try:
        # إنشاء شريحة من مجموعة الشرائح في العرض التقديمي المصدر مع
        # الشريحة الرئيسية
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الشرائح الرئيسية في
        # العرض التقديمي الوجهة
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر مع الشريحة الرئيسية المطلوبة إلى نهاية
        # مجموعة الشرائح في العرض التقديمي الوجهة
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # حفظ العرض التقديمي الوجهة إلى القرص
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **استنساخ شريحة في نهاية قسم محدد**

إذا أردت استنساخ شريحة ثم استخدامها داخل ملف العرض التقديمي نفسه لكن في قسم مختلف، استخدم طريقة [**addClone**](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addClone) التي يُظهرها الصف [**SlideCollection**](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/). تجعل Aspose.Slides for Python via Java من الممكن استنساخ شريحة من القسم الأول ثم إدراج تلك الشريحة المستنسخة في القسم الثاني من نفس العرض التقديمي.

المقتطف البرمجي التالي يوضح كيفية استنساخ شريحة وإدراج الشريحة المستنسخة في قسم محدد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # حفظ العرض التقديمي الوجهة إلى القرص
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **التأكد من مطابقة حجم الشريحة**

عند استنساخ الشرائح إلى عرض تقديمي آخر، تأكد من أن عرض تقديمي الوجهة له نفس حجم الشريحة مثل المصدر. إذا اختلف حجم الشرائح، لا تقوم Aspose.Slides بإعادة ضبط حجم الأشكال المستنسخة تلقائيًا – تُحافظ على إحداثياتها وأبعادها الأصلية، مما قد يؤدي إلى ظهور المحتوى غير محاذٍ أو تجاوز حدود الشريحة.

يمكنك ضبط حجم شريحة عرض تقديمي الوجهة ليتطابق مع المصدر قبل استنساخ الشريحة والرئيسية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

قم بذلك قبل استنساخ الشريحة والرئيسية.

## **الأسئلة المتداولة**

**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجعين؟**

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا كنت لا تريدها، [قم بإزالتها](/slides/ar/python-java/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر بياناتها؟**

يتم نسخ كائن المخطط والتنسيق والبيانات المضمنة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل مصنف OLE مدمج)، يتم الحفاظ على هذا الارتباط كـ [OLE object](/slides/ar/python-java/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**

نعم. يمكنك إدراج النسخة في فهرس شريحة محدد ووضعها في [section](/slides/ar/python-java/slide-section/) مختار. إذا لم يكن القسم المستهدف موجودًا، أنشئه أولاً ثم انقل الشريحة إليه.