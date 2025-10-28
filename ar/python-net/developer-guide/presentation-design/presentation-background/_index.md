---
title: إدارة خلفيات العروض التقديمية في Python
linktitle: خلفية الشريحة
type: docs
weight: 20
url: /ar/python-net/presentation-background/
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
- Aspose.Slides
description: "تعرف على كيفية تعيين خلفيات ديناميكية في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides للغة Python عبر .NET، مع نصائح برمجية لتعزيز عروضك التقديمية."
---

## **نظرة عامة**

الألوان الصلبة، التدرجات، والصور تُستخدم عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية لشريحة **عادية** (شريحة واحدة) أو لشريحة **رئيسية** (تُطبق على عدة شرائح في آن واحد).

![PowerPoint background](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

Aspose.Slides يتيح لك تعيين لون صلب كخلفية لشريحة محددة في العرض التقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. التغيير يُطبق فقط على الشريحة المختارة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) للشفرة `OWN_BACKGROUND`.
3. تعيين الخاصية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للشفرة `SOLID`.
4. استخدام الخاصية `solid_fill_color` على [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. حفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية تعيين لون أزرق صلب كخلفية لشريحة عادية:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # تعيين لون خلفية الشريحة إلى الأزرق.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين خلفية بلون صلب للشريحة الرئيسية**

Aspose.Slides يتيح لك تعيين لون صلب كخلفية للشريحة الرئيسية في العرض التقديمي. الشريحة الرئيسية تعمل كقالب يتحكم في تنسيق جميع الشرائح، لذا عندما تختار لونًا صلبًا لخلفية الشريحة الرئيسية، سيُطبق على كل الشريحة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) (عبر `masters`) للشفرة `OWN_BACKGROUND`.
3. تعيين الخاصية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للشفرة `SOLID`.
4. استخدام الخاصية `solid_fill_color` على [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. حفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية تعيين لون أخضر غابوي صلب كخلفية للشريحة الرئيسية:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # تعيين لون خلفية الشريحة الرئيسية إلى الأخضر الغابوي.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين خلفية متدرجة لشريحة**

التدرج هو تأثير رسومي ينتج عن تغيير تدريجي في اللون. عندما يُستخدم كخلفية للشرائح، يمكن أن يجعل العروض التقديمية تبدو أكثر فنيةً واحترافية. Aspose.Slides يتيح لك تعيين لون متدرج كخلفية للشرائح.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) للشفرة `OWN_BACKGROUND`.
3. تعيين الخاصية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للشفرة `GRADIENT`.
4. استخدام الخاصية `gradient_format` على [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة لديك.
5. حفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية تعيين لون متدرج كخلفية لشريحة:

```python
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # تطبيق تأثير التدرج على الخلفية.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **استخدام صورة كخلفية للشريحة**

بالإضافة إلى التعبئات الصلبة والمتدرجة، Aspose.Slides يتيح لك استخدام الصور كخلفيات للشرائح.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) للشفرة `OWN_BACKGROUND`.
3. تعيين الخاصية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) للشفرة `PICTURE`.
4. تحميل الصورة التي تريد استخدامها كخلفية للشريحة.
5. إضافة الصورة إلى مجموعة الصور في العرض التقديمي.
6. استخدام الخاصية `picture_fill_format` على [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. حفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية تعيين صورة كخلفية لشريحة:

```python
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # تعيين خصائص صورة الخلفية.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # تحميل الصورة.
    with slides.Images.from_file("Tulips.jpg") as image:
        # إضافة الصورة إلى مجموعة الصور في العرض التقديمي.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

الكود التالي يوضح كيفية تعيين نوع التعبئة الخلفية إلى صورة متكررة وتعديل خصائص التكرار:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # تعيين الصورة المستخدمة لتعبئة الخلفية.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # تعيين نمط تعبئة الصورة إلى Tile وضبط خصائص التجاور.
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

اقرأ المزيد: [**صورة متكررة كنقش**](/slides/ar/python-net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في تعديل شفافية صورة خلفية الشريحة لجعل محتوى الشريحة يبرز. الكود التالي بلغة Python يوضح كيفية تغيير الشفافية لصورة خلفية الشريحة:

```python
transparency_value = 30  # على سبيل المثال.

# الحصول على مجموعة عمليات تحويل الصورة.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# البحث عن تأثير شفافية بنسبة مئوية ثابتة موجود مسبقًا.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# تعيين قيمة الشفافية الجديدة.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **الحصول على قيمة خلفية الشريحة**

Aspose.Slides توفر الفئة [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) لاسترجاع قيم الخلفية الفعلية للشريحة. هذه الفئة تكشف عن الـ [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) و [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) الفعليين.

باستخدام خاصية `background` في الفئة [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/)، يمكنك الحصول على الخلفية الفعلية لشريحة.

المثال التالي بلغة Python يوضح كيفية الحصول على قيمة الخلفية الفعلية لشريحة:

```python
import aspose.slides as slides

# إنشاء كائن من الفئة Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # استرجاع الخلفية الفعلية مع الأخذ في الاعتبار الشريحة الرئيسية، التخطيط، والموضوع.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **الأسئلة الشائعة**

**هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية الموضوع/التخطيط؟**

نعم. احذف التعبئة المخصصة للشفرة، وستُورث الخلفية مرة أخرى من شريحة [layout](/slides/ar/python-net/slide-layout/)/[master](/slides/ar/python-net/slide-master/) المقابلة (أي من [theme background](/slides/ar/python-net/presentation-theme/)).

**ماذا يحدث للخلفية إذا غيرت موضوع العرض التقديمي لاحقًا؟**

إذا كانت الشريحة لها تعبئة خاصة، ستبقى دون تغيير. إذا كانت الخلفية مُورثة من [layout](/slides/ar/python-net/slide-layout/)/[master](/slides/ar/python-net/slide-master/)، فستُحدَّث لتطابق [الموضوع الجديد](/slides/ar/python-net/presentation-theme/).