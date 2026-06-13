---
title: مدیریت پس‌زمینه‌های ارائه در پایتون
linktitle: پس‌زمینه اسلاید
type: docs
weight: 20
url: /fa/python-net/presentation-background/
keywords:
- پس‌زمینه ارائه
- پس‌زمینه اسلاید
- رنگ ثابت
- رنگ گرادیان
- پس‌زمینه تصویر
- شفافیت پس‌زمینه
- ویژگی‌های پس‌زمینه
- PowerPoint
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه پس‌زمینه‌های پویا را در فایل‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق .NET تنظیم کنید، همراه با نکات کد برای تقویت ارائه‌های خود."
---
## **مقدمه**

رنگ‌های ثابت، گرادیان‌ها و تصاویر معمولاً برای پس‌زمینه اسلایدها استفاده می‌شوند. می‌توانید پس‌زمینه یک **اسلاید معمولی** (یک اسلاید تک) یا یک **اسلاید اصلی** (که به‌صورت همزمان برای چندین اسلاید اعمال می‌شود) تنظیم کنید.

![پس‌زمینه PowerPoint](powerpoint-background.png)

## **تنظیم پس‌زمینه رنگ ثابت برای اسلاید معمولی**

Aspose.Slides به شما امکان می‌دهد یک رنگ ثابت را به‌عنوان پس‌زمینه یک اسلاید خاص در ارائه تنظیم کنید — حتی اگر ارائه از یک اسلاید اصلی استفاده کند. این تغییر فقط بر روی اسلاید انتخاب‌شده اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. خاصیت [BackgroundType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/backgroundtype/) اسلاید را به `OWN_BACKGROUND` تنظیم کنید.
3. خاصیت [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) پس‌زمینه اسلاید را به `SOLID` تنظیم کنید.
4. از ویژگی `solid_fill_color` در [FillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/) برای تعیین رنگ ثابت پس‌زمینه استفاده کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # رنگ پس‌زمینه اسلاید را به آبی تنظیم کنید.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # ارائه را در دیسک ذخیره کنید.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم پس‌زمینه رنگ ثابت برای اسلاید اصلی**

Aspose.Slides به شما امکان می‌دهد یک رنگ ثابت را به‌عنوان پس‌زمینه اسلاید اصلی در ارائه تنظیم کنید. اسلاید اصلی به‌عنوان قالبی عمل می‌کند که قالب‌بندی تمام اسلایدها را کنترل می‌کند، بنابراین وقتی یک رنگ ثابت را برای پس‌زمینه اسلاید اصلی انتخاب می‌کنید، بر تمام اسلایدها اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. خاصیت [BackgroundType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/backgroundtype/) اسلاید اصلی (از طریق `masters`) را به `OWN_BACKGROUND` تنظیم کنید.
3. خاصیت [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) پس‌زمینه اسلاید اصلی را به `SOLID` تنظیم کنید.
4. از ویژگی `solid_fill_color` در [FillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/) برای تعیین رنگ ثابت پس‌زمینه استفاده کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # رنگ پس‌زمینه اسلاید اصلی را به سبز جنگلی تنظیم کنید.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # ارائه را در دیسک ذخیره کنید.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم پس‌زمینه گرادیان برای اسلاید**

گرادیان یک اثر گرافیکی است که با تغییر تدریجی رنگ ایجاد می‌شود. زمانی که به‌عنوان پس‌زمینه اسلاید استفاده شود، می‌تواند ارائه‌ها را هنری‌تر و حرفه‌ای‌تر نشان دهد. Aspose.Slides به شما امکان می‌دهد یک رنگ گرادیان را به‌عنوان پس‌زمینه اسلایدها تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. خاصیت [BackgroundType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/backgroundtype/) اسلاید را به `OWN_BACKGROUND` تنظیم کنید.
3. خاصیت [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) پس‌زمینه اسلاید را به `GRADIENT` تنظیم کنید.
4. از ویژگی `gradient_format` در [FillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/) برای پیکربندی تنظیمات دلخواه گرادیان استفاده کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # یک اثر گرادیان به پس‌زمینه اعمال کنید.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # ارائه را در دیسک ذخیره کنید.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم تصویر به‌عنوان پس‌زمینه اسلاید**

علاوه بر پرکننده‌های ثابت و گرادیان، Aspose.Slides به شما امکان می‌دهد از تصاویر به‌عنوان پس‌زمینه اسلایدها استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. خاصیت [BackgroundType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/backgroundtype/) اسلاید را به `OWN_BACKGROUND` تنظیم کنید.
3. خاصیت [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) پس‌زمینه اسلاید را به `PICTURE` تنظیم کنید.
4. تصویری که می‌خواهید به‌عنوان پس‌زمینه اسلاید استفاده کنید، بارگذاری کنید.
5. تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.
6. از ویژگی `picture_fill_format` در [FillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/) برای اختصاص تصویر به‌عنوان پس‌زمینه استفاده کنید.
7. ارائهٔ تغییر یافته را ذخیره کنید.

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # تنظیم ویژگی‌های تصویر پس‌زمینه.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # بارگذاری تصویر.
    with slides.Images.from_file("Tulips.jpg") as image:
        # تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # ارائه را در دیسک ذخیره کنید.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

کد نمونه زیر نشان می‌دهد چگونه نوع پرکنندهٔ پس‌زمینه را به تصویر کاشی‌شده تنظیم کرده و ویژگی‌های کاشی‌گذاری را تغییر دهید:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # تصویر استفاده‌شده برای پرکردن پس‌زمینه را تنظیم کنید.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # حالت پرکردن تصویر را به کاشی تنظیم کنید و ویژگی‌های کاشی را تنظیم کنید.
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
بیشتر بخوانید: [**تصویر کاشی‌شده به‌عنوان بافت**](/slides/fa/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغییر شفافیت تصویر پس‌زمینه**

ممکن است بخواهید شفافیت تصویر پس‌زمینهٔ اسلاید را تنظیم کنید تا محتوای اسلاید برجسته‌تر شود. کد Python زیر نشان می‌دهد چگونه شفافیت تصویر پس‌زمینهٔ اسلاید را تغییر دهید:

```python
transparency_value = 30  # برای مثال.

# دریافت مجموعه عملیات تبدیل تصویر.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# یافتن یک اثر شفافیت درصدی ثابت موجود.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# تنظیم مقدار شفافیت جدید.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **دریافت مقدار پس‌زمینه اسلاید**

Aspose.Slides کلاس [IBackgroundEffectiveData](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ibackgroundeffectivedata/) را برای دریافت مقادیر مؤثر پس‌زمینهٔ اسلاید فراهم می‌کند. این کلاس، [FillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/) و [EffectFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/effectformat/) مؤثر را نشان می‌دهد.

با استفاده از ویژگی `background` کلاس [BaseSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/) می‌توانید پس‌زمینهٔ مؤثر یک اسلاید را به دست آورید.

کد مثال Python زیر نشان می‌دهد چگونه مقدار پس‌زمینهٔ مؤثر یک اسلاید را دریافت کنید:

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # دریافت پس‌زمینه مؤثر، با در نظر گرفتن اسلاید اصلی، چیدمان و تم.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **پرسش‌های متداول**

**آیا می‌توانم پس‌زمینهٔ سفارشی را بازنشانی کرده و پس‌زمینهٔ تم/چیدمان را بازیابی کنم؟**

بله. پرکنندهٔ سفارشی اسلاید را حذف کنید، و پس‌زمینه دوباره از اسلاید [layout](/slides/fa/python-net/slide-layout/)/[master](/slides/fa/python-net/slide-master/) مربوطه به ارث می‌رسد (یعنی [theme background](/slides/fa/python-net/presentation-theme/)).

**چه اتفاقی برای پس‌زمینه می‌افتد اگر بعداً تم ارائه را تغییر دهم؟**

اگر یک اسلاید پرکنندهٔ خود را داشته باشد، بدون تغییر باقی می‌ماند. اگر پس‌زمینه از [layout](/slides/fa/python-net/slide-layout/)/[master](/slides/fa/python-net/slide-master/) به ارث برده شود، با تم [new theme](/slides/fa/python-net/presentation-theme/) به‌روزرسانی می‌شود.