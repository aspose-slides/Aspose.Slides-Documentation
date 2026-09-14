---
title: إدارة خلفيات العروض التقديمية في بايثون عبر جافا
linktitle: خلفية الشريحة
type: docs
weight: 20
url: /ar/python-java/presentation-background/
keywords:
- خلفية العرض التقديمي
- خلفية الشريحة
- لون صلب
- لون متدرج
- خلفية صورة
- شفافية الخلفية
- خصائص الخلفية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعرف على كيفية تعيين خلفيات دينامية في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر جافا، مع نصائح برمجية لتعزيز عروضك التقديمية."
---
## **مقدمة**

الألوان الصلبة، والتدرجات، والصور تُستخدم عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية لـ **شريحة عادية** (شريحة واحدة) أو **شريحة رئيسية** (تُطبق على عدة شرائح في آن واحد).

![خلفية PowerPoint](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

تسمح لك Aspose.Slides بتعيين لون صلب كخلفية لشريحة محددة في عرض تقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. يتم تطبيق التغيير فقط على الشريحة المختارة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. ضبط [BackgroundType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/backgroundtype/) الخاص بالشريحة إلى `OwnBackground`.
3. ضبط [FillType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/) لخلفية الشريحة إلى `Solid`.
4. استخدام الطريقة [getSolidFillColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/#getsolidfillcolor) على [FillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/) لتحديد لون الخلفية الصلبة.
5. احفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية تعيين لون صلب أزرق كخلفية لشريحة عادية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# إنشاء نسخة من فئة Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # تعيين لون خلفية الشريحة إلى الأزرق.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين خلفية بلون صلب لشريحة رئيسية**

تسمح لك Aspose.Slides بتعيين لون صلب كخلفية لشريحة رئيسية في عرض تقديمي. الشريحة الرئيسية تعمل كقالب يتحكم في تنسيق جميع الشرائح، لذا عندما تختار لونًا صلبًا لخلفية الشريحة الرئيسية، يتم تطبيقه على كل شريحة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. ضبط [BackgroundType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/backgroundtype/) الخاص بالشريحة الرئيسية (من خلال [getMasters](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getmasters)) إلى `OwnBackground`.
3. ضبط [FillType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/) لخلفية الشريحة الرئيسية إلى `Solid`.
4. استخدام الطريقة [getSolidFillColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/#getsolidfillcolor) لتحديد لون الخلفية الصلبة.
5. احفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية تعيين لون صلب (أخضر) كخلفية لشريحة رئيسية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jp.peek.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# إنشاء نسخة من فئة Presentation.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # تعيين لون خلفية الشريحة الرئيسية إلى الأخضر.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين خلفية متدرجة لشريحة**

التدرج هو تأثير رسومي يُنشأ بتغيير تدريجي في اللون. عند استخدامه كخلفية للشرائح، يمكن للتدرجات أن تجعل العروض التقديمية تبدو أكثر فنًا واحترافية. تسمح لك Aspose.Slides بتعيين لون متدرج كخلفية للشرائح.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. ضبط [BackgroundType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/backgroundtype/) الخاص بالشريحة إلى `OwnBackground`.
3. ضبط [FillType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/) لخلفية الشريحة إلى `Gradient`.
4. استخدام الطريقة [getGradientFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/#getgradientformat) على [FillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة لديك.
5. احفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية تعيين لون متدرج كخلفية لشريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# إنشاء نسخة من فئة Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # تطبيق تأثير متدرج على الخلفية.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # إضافة ألوان التدرج. بدون نقاط التدرج، تعود الخلفية إلى مراحِل افتراضية من الأسود إلى الأبيض.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين صورة كخلفية للشرائح**

بالإضافة إلى التعبئة الصلبة والمتدرجة، تسمح لك Aspose.Slides باستخدام الصور كخلفيات للشرائح.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. ضبط [BackgroundType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/backgroundtype/) الخاص بالشريحة إلى `OwnBackground`.
3. ضبط [FillType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/) لخلفية الشريحة إلى `Picture`.
4. تحميل الصورة التي تريد استخدامها كخلفية للشفرة.
5. إضافة الصورة إلى مجموعة صور العرض التقديمي.
6. استخدام الطريقة [getPictureFillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/#getpicturefillformat) على [FillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. احفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية تعيين صورة كخلفية لشريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# إنشاء نسخة من فئة Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # تعيين خصائص صورة الخلفية.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # تحميل الصورة.
    image = Images.fromFile("Tulips.jpg")
    # إضافة الصورة إلى مجموعة صور العرض التقديمي.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

المثال التالي يوضح كيفية تعيين نوع تعبئة الخلفية إلى صورة متكررة وتعديل خصائص التبويب:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # تعيين الصورة المستخدمة لملء الخلفية.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # تعيين وضع ملء الصورة إلى تجانب وتعديل خصائص التجانب.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
اقرأ المزيد: [صورة متكررة كملمس](/slides/ar/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في تعديل شفافية صورة خلفية الشريحة لجعل محتوى الشريحة يبرز. الكود التالي بلغة Python يوضح كيفية تغيير الشفافية لصورة خلفية الشريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # على سبيل المثال.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # الحصول على مجموعة عمليات تحويل الصورة.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # البحث عن تأثير شفافية ثابت بالنسبة المئوية موجود.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # تعيين قيمة الشفافية الجديدة.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الحصول على قيمة خلفية الشريحة**

تسمح لك Aspose.Slides باسترجاع القيم الفعلية لخلفية الشريحة باستخدام الطريقة [getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/background/#geteffective) على [Background](https://reference.aspose.com/slides/ar/python-java/aspose.slides/background/). البيانات المرجعة تكشف عن تنسيقات التعبئة والتأثير الفعلية.

باستخدام طريقة [getBackground](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getbackground) من فئة [BaseSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/)، يمكنك الحصول على خلفية الشريحة.

المثال التالي بلغة Python يوضح كيفية الحصول على القيمة الفعلية لخلفية الشريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# إنشاء نسخة من فئة Presentation.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # استرجاع الخلفية الفعلية مع الأخذ في الاعتبار الشريحة الرئيسية، والتخطيط، والسمة.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية السمة/التخطيط؟**

نعم. أزل التعبئة المخصصة للشفرة، وستتم وراثة الخلفية مرةً أخرى من شريحة [layout](/slides/ar/python-java/slide-layout/)/[master](/slides/ar/python-java/slide-master/) المقابلة (أي [theme background](/slides/ar/python-java/presentation-theme/)).

**ماذا يحدث للخلفية إذا غيرت سمة العرض التقديمي لاحقًا؟**

إذا كانت الشريحة تحتوي على تعبئة خاصة بها، فستظل دون تغيير. إذا كانت الخلفية مستوردة من [layout](/slides/ar/python-java/slide-layout/)/[master](/slides/ar/python-java/slide-master/)، فستُحدَّث لتطابق [new theme](/slides/ar/python-java/presentation-theme/).