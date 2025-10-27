---
title: إدارة خلفيات العروض التقديمية باستخدام بايثون
linktitle: خلفية الشريحة
type: docs
weight: 20
url: /ar/python-net/presentation-background/
keywords:
- presentation background
- slide background
- solid color
- gradient color
- image background
- background transparency
- background properties
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "تعرف على كيفية تعيين خلفيات ديناميكية في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides للبايثون عبر .NET، مع نصائح برمجية لتعزيز عروضك التقديمية."
---

## **نظرة عامة**

الألوان الصلبة، التدرجات، والصور تُستخدم عادةً لخلفيات الشرائح. يمكنك تعيين الخلفية لشريحة **عادية** (شريحة واحدة) أو شريحة **رئيسية** (تنطبق على عدة شرائح مرة واحدة).

![PowerPoint background](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

Aspose.Slides يتيح لك تعيين لون صلب كخلفية لشريحة معينة في العرض التقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. التغيير يُطبق فقط على الشريحة المحددة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. تعيين خاصية الخلفية [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) إلى `OWN_BACKGROUND`.
3. تعيين خاصية ملء الخلفية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) إلى `SOLID`.
4. استخدم الخاصية `solid_fill_color` على [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. حفظ العرض التقديمي المعدل.

المثال التالي بايثون يوضح كيفية تعيين لون أزرق كخلفية صلبة لشريحة عادية:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Set the background color of the slide to blue.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Save the presentation to disk.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين خلفية بلون صلب للشريحة الرئيسية**

Aspose.Slides يتيح لك تعيين لون صلب كخلفية للشريحة الرئيسية في العرض التقديمي. الشريحة الرئيسية تعمل كقالب يتحكم في تنسيق جميع الشرائح، لذا عندما تختار لونًا صلبًا لخلفية الشريحة الرئيسية، يُطبق على كل الشريحة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. تعيين خاصية الخلفية [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) (عبر `masters`) إلى `OWN_BACKGROUND`.
3. تعيين خاصية ملء الخلفية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) إلى `SOLID`.
4. استخدم الخاصية `solid_fill_color` على [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. حفظ العرض التقديمي المعدل.

المثال التالي بايثون يوضح كيفية تعيين لون أخضر غابة كخلفية للشريحة الرئيسية:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Set the background color for the Master slide to Forest Green.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Save the presentation to disk.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين خلفية متدرجة لشريحة**

التدرج هو تأثير رسومي يُنشأ بتغيير اللون تدريجيًا. عند استخدامه كخلفية لشريحة، يمكن أن يُضفي مظهرًا فنيًا واحترافيًا على العروض. Aspose.Slides يتيح لك تعيين لون متدرج كخلفية للشرائح.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. تعيين خاصية الخلفية [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) إلى `OWN_BACKGROUND`.
3. تعيين خاصية ملء الخلفية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) إلى `GRADIENT`.
4. استخدم الخاصية `gradient_format` على [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة لديك.
5. حفظ العرض التقديمي المعدل.

المثال التالي بايثون يوضح كيفية تعيين لون متدرج كخلفية لشريحة:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Apply a gradient effect to the background.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Save the presentation to disk.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **استخدام صورة كخلفية للشريحة**

إضافةً إلى التعبئة الصلبة والمتدرجة، Aspose.Slides يتيح لك استخدام الصور كخلفيات للشرائح.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. تعيين خاصية الخلفية [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) إلى `OWN_BACKGROUND`.
3. تعيين خاصية ملء الخلفية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) إلى `PICTURE`.
4. تحميل الصورة التي تريد استخدامها كخلفية للشريحة.
5. إضافة الصورة إلى مجموعة صور العرض التقديمي.
6. استخدم الخاصية `picture_fill_format` على [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. حفظ العرض التقديمي المعدل.

المثال التالي بايثون يوضح كيفية تعيين صورة كخلفية لشريحة:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Set background image properties.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Load the image.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Add the image to the presentation's image collection.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Save the presentation to disk.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

المثال التالي يوضح كيفية تعيين نوع التعبئة كصورة متكررة وتعديل خصائص التكرار:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Set the image used for the background fill.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Set the picture fill mode to Tile and adjust the tile properties.
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}

اقرأ المزيد: [**Tile Picture As Texture**](/slides/ar/python-net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في تعديل شفافية صورة الخلفية لجعل محتوى الشريحة يبرز. الكود البايثون التالي يوضح كيفية تغيير الشفافية لصورة خلفية الشريحة:

```python
transparency_value = 30  # For example.

# Get the collection of picture transform operations.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Find an existing fixed-percentage transparency effect.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Set the new transparency value.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **استرجاع قيمة خلفية الشريحة**

Aspose.Slides توفر الفئة [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) لاسترجاع القيم الفعّالة لخلفية الشريحة. هذه الفئة تكشف عن الـ [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) والـ [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) الفعّالين.

باستخدام الخاصية `background` من الفئة [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/)، يمكنك الحصول على الخلفية الفعّالة لشريحة.

المثال التالي بايثون يوضح كيفية الحصول على قيمة الخلفية الفعّالة للشريحة:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Retrieve the effective background, taking into account master, layout, and theme.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **الأسئلة الشائعة**

**هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية السمة/التخطيط؟**

نعم. أزل التعبئة المخصصة للشفيفة، وستتم وراثة الخلفية مرة أخرى من الشريحة [layout](/slides/ar/python-net/slide-layout/)/[master](/slides/ar/python-net/slide-master/) المقابلة (أي خلفية [theme](/slides/ar/python-net/presentation-theme/)).

**ماذا يحدث للخلفية إذا غيرت سمة العرض التقديمي لاحقًا؟**

إذا كانت الشريحة تحتوي على تعبئة خاصة بها، فستبقى دون تغيير. إذا كانت الخلفية مُورثة من الـ [layout](/slides/ar/python-net/slide-layout/)/[master](/slides/ar/python-net/slide-master/)، فستُحدَّث لتطابق السمة [الجديدة](/slides/ar/python-net/presentation-theme/).