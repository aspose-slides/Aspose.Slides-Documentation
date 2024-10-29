---
title: خلفية العرض
type: docs
weight: 20
url: /ar/python-net/presentation-background/
keywords: "خلفية PowerPoint, تعيين الخلفية, Python, Aspose.Slides لـ Python عبر .NET"
description: "تعيين الخلفية في عرض PowerPoint باستخدام Python"
---

الألوان الصلبة، والألوان التدرج، والصور تُستخدم غالبًا كصور خلفية للشرائح. يمكنك تعيين الخلفية سواء لشريحة **عادية** (شريحة واحدة) أو **شريحة رئيسية** (عدة شرائح دفعة واحدة).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **تعيين لون صلب كخلفية لشريحة عادية**

تسمح لك Aspose.Slides بتعيين لون صلب كخلفية لشريحة معينة في عرض تقديمي (حتى إذا كان يحتوي على شريحة رئيسية). يؤثر تغيير الخلفية فقط على الشريحة المحددة.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. عيّن قيمة [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) للشرائح إلى `OwnBackground` .
3. عيّن قيمة [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) لخلفية الشريحة إلى `Solid` .
4. استخدم خاصية [SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) المعروضة بواسطة [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتحديد لون صلب للخلفية.
5. احفظ العرض التقديمي المعدل.

يعرض لك هذا الكود بلغة Python كيفية تعيين لون صلب (أزرق) كخلفية لشريحة عادية:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as pres:
    # Sets the background color for the first ISlide to Blue
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.slides[0].background.fill_format.solid_fill_color.color = draw.Color.blue
    # Writes the presentation to disk
    pres.save("ContentBG_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين لون صلب كخلفية لشريحة رئيسية**

تسمح لك Aspose.Slides بتعيين لون صلب كخلفية للشريحة الرئيسية في عرض تقديمي. تعمل الشريحة الرئيسية كقالب يحتوي على إعدادات التنسيق لجميع الشرائح. لذلك، عند اختيار لون صلب كخلفية للشريحة الرئيسية، ستُستخدم تلك الخلفية الجديدة لجميع الشرائح.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. عيّن قيمة [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) للشريحة الرئيسية (`Masters`) إلى `OwnBackground` .
3. عيّن قيمة [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) لخلفية الشريحة الرئيسية إلى `Solid` .
4. استخدم خاصية [SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) المعروضة بواسطة [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتحديد لون صلب للخلفية.
5. احفظ العرض التقديمي المعدل.

يعرض لك هذا الكود بلغة Python كيفية تعيين لون صلب (أخضر غابة) كخلفية لشريحة رئيسية في عرض تقديمي:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as pres:
    # Sets the background color for the Master ISlide to Forest Green
    pres.masters[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.masters[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.masters[0].background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Writes the presentation to disk
    pres.save("SetSlideBackgroundMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين لون تدرجي كخلفية لشريحة**

التدرج هو تأثير رسومي يعتمد على تغيير تدريجي في اللون. الألوان التدريجية، عند استخدامها كخلفيات للشرائح، تجعل العروض التقديمية تبدو فنية ومهنية. تسمح لك Aspose.Slides بتعيين لون تدرجي كخلفية للشرائح في العروض التقديمية.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. عيّن قيمة [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground` .
3. عيّن قيمة [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) لخلفية الشريحة الرئيسية إلى `Gradient` .
4. استخدم خاصية [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) المعروضة بواسطة [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتحديد إعدادات التدرج المفضلة لديك.
5. احفظ العرض التقديمي المعدل.

يعرض لك هذا الكود بلغة Python كيفية تعيين لون تدرجي كخلفية لشريحة:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation(path + "SetBackgroundToGradient.pptx") as pres:
    # Apply Gradient effect to the Background
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.GRADIENT
    pres.slides[0].background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    #Writes the presentation to disk
    pres.save("ContentBG_Grad_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين صورة كخلفية لشريحة**

بجانب الألوان الصلبة والألوان التدريجية، تتيح لك Aspose.Slides أيضًا تعيين صور كخلفية للشرائح في العروض التقديمية.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. عيّن قيمة [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground` .
3. عيّن قيمة [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) لخلفية الشريحة الرئيسية إلى `Picture` .
4. قم بتحميل الصورة التي ترغب في استخدامها كخلفية للشريحة.
5. أضف الصورة إلى مجموعة الصور في العرض التقديمي.
6. استخدم خاصية [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) المعروضة بواسطة [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. احفظ العرض التقديمي المعدل.

يعرض لك هذا الكود بلغة Python كيفية تعيين صورة كخلفية لشريحة:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation(path + "SetImageAsBackground.pptx") as pres:
    # Sets conditions for background image
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.PICTURE
    pres.slides[0].background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Loads the image
    img = draw.Bitmap(path + "Tulips.jpg")

    # Adds image to presentation's images collection
    imgx = pres.images.add_image(img)

    pres.slides[0].background.fill_format.picture_fill_format.picture.image = imgx

    # Writes the presentation to disk
    pres.save("ContentBG_Img_out.pptx", slides.export.SaveFormat.PPTX)
```

### **تغيير شفافية صورة الخلفية**

قد ترغب في ضبط شفافية صورة خلفية الشريحة لجعل محتويات الشريحة بارزة. هذا الكود بلغة Python يوضح لك كيفية تغيير شفافية صورة الخلفية لشريحة:

```python
transparencyValue = 30 # على سبيل المثال

# Gets a collection of picture transform operations
imageTransform = pres.slides[0].background.fill_format.picture_fill_format.picture.image_transform

transparencyOperation = None
# Finds a transparency effect with fixed percentage.
for operation in imageTransform:
    if type(operation) is slides.AlphaModulateFixed:
        transparencyOperation = operation
        break

# Sets the new transparency value.
if transparencyOperation is None:
    imageTransform.add_alpha_modulate_fixed_effect(100 - transparencyValue)
else:
    transparencyOperation.amount = (100 - transparencyValue)
```

## **الحصول على قيمة خلفية الشريحة**

تقدم Aspose.Slides واجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) للسماح لك بالحصول على القيم الفعالة لخلفيات الشرائح. تحتوي هذه الواجهة على معلومات حول [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties) الفعالة و [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties) الفعالة.

باستخدام خاصية [Background](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/#properties) من فئة [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) ، يمكنك الحصول على القيمة الفعالة لخلفية الشريحة.

يعرض لك هذا الكود بلغة Python كيفية الحصول على قيمة الخلفية الفعالة لشريحة:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation(path + "SamplePresentation.pptx") as pres:

    effBackground = pres.slides[0].background.get_effective()

    if effBackground.fill_format.fill_type == slides.FillType.SOLID:
        print("لون التعبئة: " + str(effBackground.fill_format.solid_fill_color))
    else:
        print("نوع التعبئة: " + str(effBackground.fill_format.fill_type))
```