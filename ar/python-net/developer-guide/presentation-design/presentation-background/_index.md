---
title: إدارة خلفيات العروض التقديمية في بايثون
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
description: "تعلم كيفية تعيين خلفيات ديناميكية في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET، مع نصائح برمجية لتعزيز عروضك التقديمية."
---

## **نظرة عامة**

الألوان الصلبة، التدرجات، والصور تُستخدم عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية لشريحة **عادية** (شريحة واحدة) أو لشريحة **رئيسية** (تُطبّق على عدة شرائح مرة واحدة).

![PowerPoint background](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

Aspose.Slides يسمح لك بتعيين لون صلب كخلفية لشريحة محددة في عرض تقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. التطوير يطبّق فقط على الشريحة المحددة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. تعيين خاصية الشريحة [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) إلى `OWN_BACKGROUND`.
3. تعيين خاصية خلفية الشريحة [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) إلى `SOLID`.
4. استخدام خاصية `solid_fill_color` على الفئة [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. حفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية تعيين لون أزرق صلب كخلفية لشريحة عادية:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء مثيل من فئة Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # ضبط لون خلفية الشريحة إلى اللون الأزرق.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين خلفية بلون صلب للشريحة الرئيسية**

Aspose.Slides يسمح لك بتعيين لون صلب كخلفية للشريحة الرئيسية في عرض تقديمي. الشريحة الرئيسية تعمل كقالب يتحكم في تنسيق جميع الشرائح، لذا عند اختيار لون صلب لخلفية الشريحة الرئيسية، يُطبّق على كل الشريحة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. تعيين خاصية الشريحة الرئيسية [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) (عبر `masters`) إلى `OWN_BACKGROUND`.
3. تعيين خاصية خلفية الشريحة الرئيسية [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) إلى `SOLID`.
4. استخدام خاصية `solid_fill_color` على الفئة [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. حفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية تعيين لون صلب (أخضر غابات) كخلفية للشريحة الرئيسية:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# إنشاء مثيل من فئة Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # تعيين لون خلفية الشريحة الرئيسية إلى الأخضر الغابي.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين خلفية متدرجة لشريحة**

التدرج هو تأثير رسومي يُنشأ بتغيير اللون تدريجياً. عند استخدامه كخلفية لشريحة، يمكن للتدرجات أن تجعل العروض التقديمية تبدو أكثر فنية واحترافية. Aspose.Slides يسمح لك بتعيين لون متدرج كخلفية للشرائح.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. تعيين خاصية الشريحة [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) إلى `OWN_BACKGROUND`.
3. تعيين خاصية خلفية الشريحة [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) إلى `GRADIENT`.
4. استخدام خاصية `gradient_format` على الفئة [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة لديك.
5. حفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية تعيين لون متدرج كخلفية لشريحة:
```python
import aspose.slides as slides

# إنشاء مثيل من فئة Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # تطبيق تأثير تدرج على الخلفية.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين صورة كخلفية لشريحة**

بالإضافة إلى التعبئات الصلبة والمتدرجة، Aspose.Slides يسمح لك باستخدام الصور كخلفيات للشرائح.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. تعيين خاصية الشريحة [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) إلى `OWN_BACKGROUND`.
3. تعيين خاصية خلفية الشريحة [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) إلى `PICTURE`.
4. تحميل الصورة التي تريد استخدامها كخلفية للشريحة.
5. إضافة الصورة إلى مجموعة الصور في العرض التقديمي.
6. استخدام خاصية `picture_fill_format` على الفئة [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. حفظ العرض التقديمي المعدل.

المثال التالي بلغة Python يوضح كيفية تعيين صورة كخلفية لشريحة:
```python
import aspose.slides as slides

# إنشاء مثيل من فئة Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # تعيين خصائص صورة الخلفية.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # تحميل الصورة.
    with slides.Images.from_file("Tulips.jpg") as image:
        # إضافة الصورة إلى مجموعة صور العرض التقديمي.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```


العينة البرمجية التالية توضح كيفية تعيين نوع تعبئة الخلفية إلى صورة بلاط وتعديل خصائص التبليط:
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

    # تعيين وضع تعبئة الصورة إلى بلاط وتعديل خصائص البلاط.
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

اقرأ المزيد: [**صورة بلاط كقماش**](/slides/ar/python-net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في تعديل شفافية صورة خلفية الشريحة لجعل محتوى الشريحة يبرز. الكود التالي بلغة Python يوضح كيفية تغيير شفافية صورة خلفية الشريحة:
```python
transparency_value = 30  # على سبيل المثال.

# احصل على مجموعة عمليات تحويل الصورة.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# العثور على تأثير شفافية ثابت النسبة المئوية موجود.
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

Aspose.Slides توفر الفئة [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) لاسترجاع القيم الفعّالة لخلفية الشريحة. هذه الفئة تكشف عن الـ [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) و [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) الفعّالين.

باستخدام خاصية `background` في الفئة [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/)، يمكنك الحصول على الخلفية الفعّالة لشريحة.

المثال التالي بلغة Python يوضح كيفية الحصول على قيمة الخلفية الفعّالة لشريحة:
```python
import aspose.slides as slides

# إنشاء مثيل من فئة Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # استخراج الخلفية الفعّالة مع مراعاة الشريحة الرئيسية وتخطيط الشريحة والسمة.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```


## **الأسئلة المتكررة**

**هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية القالب/التخطيط؟**

نعم. احذف التعبئة المخصصة للشفرة، وستتم وراثة الخلفية مرة أخرى من شريحة [التخطيط](/slides/ar/python-net/slide-layout/)/[الرئيسية](/slides/ar/python-net/slide-master/) المقابلة (أي خلفية [السمة](/slides/ar/python-net/presentation-theme/)).

**ماذا يحدث للخلفية إذا غيرت سمة العرض التقديمي لاحقاً؟**

إذا كانت الشريحة تحتوي على تعبئتها الخاصة، فستظل دون تغيير. إذا كانت الخلفية موروثة من شريحة [التخطيط](/slides/ar/python-net/slide-layout/)/[الرئيسية](/slides/ar/python-net/slide-master/)، فستُحدّث لتطابق [السمة الجديدة](/slides/ar/python-net/presentation-theme/).