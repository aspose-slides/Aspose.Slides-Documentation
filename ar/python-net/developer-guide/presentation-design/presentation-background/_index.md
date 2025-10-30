---
title: إدارة خلفيات العروض التقديمية في بايثون
linktitle: خلفية الشريحة
type: docs
weight: 20
url: /ar/python-net/presentation-background/
keywords:
- خلفية العرض
- خلفية الشريحة
- لون صلب
- لون تدرج
- خلفية صورة
- شفافية الخلفية
- خصائص الخلفية
- PowerPoint
- OpenDocument
- العرض
- بايثون
- Aspose.Slides
description: "تعلم كيفية تعيين خلفيات ديناميكية في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET، مع نصائح برمجية لتعزيز عروضك التقديمية."
---

## **نظرة عامة**

الألوان الصلبة، والتدرجات، والصور تُستخدم عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية لـ **شريحة عادية** (شريحة واحدة) أو **شريحة رئيسية** (تنطبق على عدة شرائح في آن واحد).

![خلفية PowerPoint](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

تتيح لك Aspose.Slides تعيين لون صلب كخلفية لشريحة محددة في عرض تقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. يُطبق التغيير فقط على الشريحة المختارة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. تعيين خاصية [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) للشرحة إلى `OWN_BACKGROUND`.
3. تعيين خاصية خلفية الشريحة [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) إلى `SOLID`.
4. استخدم الخاصية `solid_fill_color` على [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. احفظ العرض المعدل.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء مثيل من الفئة Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # تعيين لون خلفية الشريحة إلى الأزرق.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # حفظ العرض على القرص.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين خلفية بلون صلب للشريحة الرئيسية**

تتيح لك Aspose.Slides تعيين لون صلب كخلفية للشريحة الرئيسية في عرض تقديمي. الشريحة الرئيسية تعمل كقالب يتحكم في تنسيق جميع الشرائح، لذا عند اختيار لون صلب لخلفية الشريحة الرئيسية، يطبق على كل شريحة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. تعيين خاصية [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) للشريحة الرئيسية (عبر `masters`) إلى `OWN_BACKGROUND`.
3. تعيين خاصية خلفية الشريحة الرئيسية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) إلى `SOLID`.
4. استخدم الخاصية `solid_fill_color` على [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. احفظ العرض المعدل.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء مثيل من الفئة Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # تعيين لون خلفية الشريحة الرئيسية إلى أخضر الغابة.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # حفظ العرض على القرص.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين خلفية متدرجة للشريحة**

التدرج هو تأثير رسومي يُنشأ بتغير تدريجي في اللون. عندما يُستخدم كخلفية للشريحة، يمكن أن يجعل العروض أكثر إبداعًا واحترافية. تتيح لك Aspose.Slides تعيين لون متدرج كخلفية للشرائح.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. تعيين خاصية [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) للشرحة إلى `OWN_BACKGROUND`.
3. تعيين خاصية خلفية الشريحة [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) إلى `GRADIENT`.
4. استخدم الخاصية `gradient_format` على [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة.
5. احفظ العرض المعدل.

```python
import aspose.slides as slides

# إنشاء مثيل من الفئة Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # تطبيق تأثير تدرج على الخلفية.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # حفظ العرض على القرص.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين صورة كخلفية للشريحة**

بالإضافة إلى التعبئات الصلبة والمتدرجة، تتيح لك Aspose.Slides استخدام الصور كخلفيات للشرائح.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. تعيين خاصية [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) للشرحة إلى `OWN_BACKGROUND`.
3. تعيين خاصية خلفية الشريحة [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) إلى `PICTURE`.
4. تحميل الصورة التي تريد استخدامها كخلفية للشريحة.
5. إضافة الصورة إلى مجموعة صور العرض.
6. استخدم الخاصية `picture_fill_format` على [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. احفظ العرض المعدل.

```python
import aspose.slides as slides

# إنشاء مثيل من الفئة Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # تعيين خصائص صورة الخلفية.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # تحميل الصورة.
    with slides.Images.from_file("Tulips.jpg") as image:
        # إضافة الصورة إلى مجموعة صور العرض.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # حفظ العرض على القرص.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # تعيين الصورة المستخدمة لملء الخلفية.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # تعيين وضع ملء الصورة إلى Tile وتعديل خصائص البلاط.
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

قد ترغب في تعديل شفافية صورة خلفية الشريحة لجعل محتويات الشريحة تبرز. يوضح لك الكود التالي كيفية تغيير الشفافية لصورة خلفية الشريحة:

```python
transparency_value = 30  # على سبيل المثال.

# الحصول على مجموعة عمليات تحويل الصورة.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# البحث عن تأثير شفافية ثابت النسبة مئوية موجود.
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

توفر لك Aspose.Slides الفئة [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) لاسترجاع القيم الفعلية لخلفية الشريحة. تعرض هذه الفئة الـ [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) و[EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) الفعليين.

باستخدام خاصية `background` للفئة [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/)، يمكنك الحصول على الخلفية الفعلية لشريحة.

```python
import aspose.slides as slides

# إنشاء مثيل من الفئة Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # استرجاع الخلفية الفعلية، مع الأخذ في الاعتبار الشريحة الرئيسية، التخطيط، والموضوع.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **الأسئلة المتكررة**

**هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية الموضوع/التخطيط؟**

نعم. قم بإزالة التعبئة المخصصة للشفرة، وستتم وراثة الخلفية مرة أخرى من شريحة [التخطيط](/slides/ar/python-net/slide-layout/)/[الرئيسية](/slides/ar/python-net/slide-master/) المقابلة (أي خلفية [الموضوع](/slides/ar/python-net/presentation-theme/)).

**ماذا يحدث للخلفية إذا قمت بتغيير موضوع العرض لاحقًا؟**

إذا كانت الشريحة تمتلك تعبئة خاصة بها، ستظل دون تغيير. إذا كانت الخلفية موروثة من [التخطيط](/slides/ar/python-net/slide-layout/)/[الرئيسية](/slides/ar/python-net/slide-master/)، فستُحدَّث لتتناسب مع [الموضوع الجديد](/slides/ar/python-net/presentation-theme/).