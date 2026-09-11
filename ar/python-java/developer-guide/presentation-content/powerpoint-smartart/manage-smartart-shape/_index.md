---
title: إدارة رسومات SmartArt في العروض التقديمية باستخدام Python
linktitle: رسومات SmartArt
type: docs
weight: 20
url: /ar/python-java/manage-smartart-shape/
keywords:
- كائن SmartArt
- رسم SmartArt
- نمط SmartArt
- لون SmartArt
- إنشاء SmartArt
- إضافة SmartArt
- تحرير SmartArt
- تغيير SmartArt
- وصول SmartArt
- نوع تخطيط SmartArt
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "أتمتة إنشاء وتحرير وتنسيق SmartArt في PowerPoint باستخدام Python و Aspose.Slides، مع أمثلة شفرة مختصرة وإرشادات تركّز على الأداء."
---
## **نظرة عامة**

Aspose.Slides يسمح لك بإنشاء وإدارة رسومات SmartArt في عروض PowerPoint التقديمية برمجياً. توضح هذه المقالة كيفية إضافة شكل SmartArt إلى شريحة، الوصول إلى أشكال SmartArt الموجودة، العثور على SmartArt بنوع تخطيط محدد، وتحديث مظهره البصري عن طريق تغيير نمط SmartArt أو نمط اللون.

تُظهر الأمثلة كيفية العمل مع أشكال SmartArt عبر مجموعة أشكال شريحة العرض التقديمي، والتحقق مما إذا كان الشكل هو SmartArt ثم تعديل أو فحص خصائصه.

## **إنشاء شكل SmartArt**
Aspose.Slides for Python via Java يوفر API لإنشاء أشكال SmartArt. لإنشاء شكل SmartArt في شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على شريحة حسب فهرستها.
1. [إضافة شكل SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addSmartArt) عن طريق تحديد [SmartArtLayoutType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartartlayouttype/) .
1. حفظ العرض التقديمي المعدل كملف PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل SmartArt.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # حفظ العرض التقديمي.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**شكل: تم إضافة شكل SmartArt إلى الشريحة**|

## **الوصول إلى شكل SmartArt على شريحة**
المثال التالي يصل إلى أشكال SmartArt على شريحة عرض تقديمي. يت iterates عبر كل شكل في الشريحة ويتحقق مما إذا كان الشكل هو [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/) .

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # التجول عبر كل شكل في الشريحة الأولى.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **الوصول إلى شكل SmartArt بنوع تخطيط معين**
المثال التالي يصل إلى شكل [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/) بنوع تخطيط معين، يتم إرجاعه بواسطة [SmartArt.getLayout](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/#getLayout) .

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.
1. الحصول على الشريحة الأولى حسب فهرستها.
1. iterates عبر كل شكل في الشريحة الأولى.
1. التحقق مما إذا كان الشكل هو [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/) .
1. التحقق مما إذا كان شكل SmartArt يملك نوع التخطيط المحدد وإجراء العملية المطلوبة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # التجول عبر كل شكل في الشريحة الأولى.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # التحقق من تخطيط SmartArt.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **تغيير نمط شكل SmartArt**
هذا المثال يوضح كيفية تغيير النمط السريع لشكل SmartArt.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.
1. الحصول على الشريحة الأولى حسب فهرستها.
1. iterates عبر كل شكل في الشريحة الأولى.
1. التحقق مما إذا كان الشكل هو [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/) .
1. العثور على شكل SmartArt بالنمط المحدد.
1. تعيين النمط الجديد لشكل SmartArt.
1. حفظ العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # التجول عبر كل شكل في الشريحة الأولى.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # التحقق وتغيير نمط SmartArt.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**شكل: تم تغيير نمط شكل SmartArt**|

## **تغيير نمط لون شكل SmartArt**
هذا المثال يصل إلى شكل SmartArt بنمط لون معين ويغيّر ذلك النمط.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.
1. الحصول على الشريحة الأولى حسب فهرستها.
1. iterates عبر كل شكل في الشريحة الأولى.
1. التحقق مما إذا كان الشكل هو [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/) .
1. العثور على شكل SmartArt بنمط اللون المحدد.
1. تعيين نمط اللون الجديد لشكل SmartArt.
1. حفظ العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # التجول عبر كل شكل في الشريحة الأولى.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # التحقق وتغيير نمط SmartArt.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**شكل: تم تغيير نمط لون شكل SmartArt**|

## **الأسئلة الشائعة**

**هل يمكنني تحريك SmartArt ككائن واحد؟**

نعم. SmartArt هو شكل، لذا يمكنك تطبيق [الرسوم المتحركة القياسية](/slides/ar/python-java/powerpoint-animation/) عبر API الرسوم المتحركة (دخول، خروج، تأكيد، مسارات حركة) تماماً كما هو الحال مع الأشكال الأخرى.

**كيف يمكنني العثور على SmartArt محدد في شريحة إذا لم أعرف معرِّفه الداخلي؟**

استخدم [النص البديل] (https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#setAlternativeText) وابحث عن الشكل بالقيمة المحددة—هذه طريقة موصى بها لتحديد الشكل المستهدف.

**هل يمكنني تجميع SmartArt مع أشكال أخرى؟**

نعم. يمكنك تجميع SmartArt مع أشكال أخرى (صور، جداول، إلخ) ثم [التعامل مع المجموعة](/slides/ar/python-java/group/) .

**كيف أحصل على صورة SmartArt محدد (مثلاً للمعاينة أو التقرير)؟**

قم بتصدير صورة مصغرة/صورة للشكل؛ المكتبة يمكنها [تصيير الأشكال الفردية](/slides/ar/python-java/create-shape-thumbnails/) إلى ملفات نقطية (PNG/JPG/TIFF).

**هل سيُحافظ مظهر SmartArt عند تحويل العرض التقديمي بأكمله إلى PDF؟**

نعم. محرك التصيير يهدف إلى دقة عالية لتصدير [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/)، مع مجموعة من خيارات الجودة والتوافق.