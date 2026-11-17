---
title: مدیریت اثرهای تبدیل تصویر در ارائه‌ها با پایتون
linktitle: اثرهای تبدیل تصویر
type: docs
weight: 11
url: /fa/python-net/image-transform-effects/
keywords:
- تبدیل تصویر
- اثر تصویر
- روشنایی
- کنتراست
- خاکستری
- دو‌رنگ
- رنگ‌دمه
- HSL
- جایگزینی رنگ
- محو کردن
- شفافیت
- اثر آلفا
- زنجیره اثر
- PowerPoint
- ارائه
- پایتون
- Aspose.Slides
description: "اعمال، زنجیره‌بندی، بازرسی، حذف و تأیید اثرهای تبدیل تصویر برای فریم‌های تصویر با Aspose.Slides برای پایتون از طریق .NET."
---
## **بررسی کلی**

Aspose.Slides تنظیمات تصویر را به عنوان یک مجموعه مرتب از عملیات تبدیل تصویر ارائه می‌دهد. برای یک فریم تصویر، با فریم‌ٔ [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) شروع کنید و ویژگی [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/) آن را دسترسی پیدا کنید. مجموعهٔ بازگردانده‌شده [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) به شما امکان افزودن، شمارش، بازرسی، حذف و پاک‌سازی اثرها را بدون بازنویسی بایت‌های تصویر اصلی می‌دهد.

این مقاله یک جریان کاری کامل برای روشنایی و کنتراست، تبدیلات رنگ، محو کردن، شفافیت، زنجیره‌های اثر مرتب، مقادیر مؤثر، حذف و تأیید دورانی PPTX را نشان می‌دهد.

## **درک مالکیت اثر و بازاستفاده از تصویر**

یک منبع تصویر و تصویری که آن را نمایش می‌دهد اشیای متفاوتی هستند:

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) تصویر منبع را که متعلق به ارائه است ذخیره یا مرجع می‌کند.
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) متعلق به یک پرکننده تصویر است و به منبع تصویر ارجاع می‌دهد در حالی که مجموعهٔ تبدیل تصویر را ذخیره می‌کند.
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) شکل اسلاید است که پرکنندهٔ تصویر مربوطه، شکل‌جغرافیایی، تنظیمات برش و سایر فرمت‌بندی‌های سطح فریم را در اختیار دارد.

به همین دلیل، عملیات تبدیل تصویر بایت‌های موجود در [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) را تغییر نمی‌دهد. وقتی یک `PPImage` یک‌بار بیش از یک‌بار به [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) داده می‌شود، هر فریم تصویر جدید یک `Picture` و مجموعهٔ تبدیل خود را دریافت می‌کند. اعمال تبدیل خاکستری به یک فریم، فریم‌های دیگر را خاکستری نمی‌کند، حتی اگر همهٔ آن‌ها از همان منبع تصویر جاسازی‌شده استفاده کنند.

مدل `Picture.image_transform` نیز توسط پرکننده‌های تصویر دیگر، مانند یک شکل یا پس‌زمینهٔ اسلاید، استفاده می‌شود. مثال‌های زیر بر روی فریم‌های تصویر متمرکز هستند.

## **استفاده از بازه‌ها و واحدهای معتبر برای پارامترها**

متدهای نشان‌داده‌شده از بازه‌ها و واحدهای معنایی زیر استفاده می‌کنند. حتی اگر نسخهٔ خاصی از کتابخانه هر مقدار خارج از بازه را بلافاصله رد نکند، مقادیر را در این بازه‌ها نگه دارید؛ قالب هدف ممکن است داده‌های نامعتبر را هنگام ذخیره‌سازی یا باز کردن فایل توسط PowerPoint نرمال‌سازی، حذف یا رد کند.

| عملیات | پارامترها | بازه معتبر و واحد |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` تا `100`، درصد؛ `0` مؤلفه را بدون تغییر می‌گذارد. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | هیچ پارامتر عددی ندارد. مقدار آلفا تغییر نمی‌کند. |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | دو رنگ برای پیکسل‌های تاریک و روشن. کانال‌های RGB و آلفا از `0` تا `255` استفاده می‌کنند. |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | `hue` از `0` (شامل) تا `360` (به‌جز) درجه؛ `amount` از `-100` تا `100` درصد. |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | `hue` از `0` (شامل) تا `360` (به‌جز) درجه؛ `saturation` و `luminance` از `-100` تا `100` درصد. |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | رنگ جایگزین مقادیر کانال از `0` تا `255` دارد. مقادیر آلفای موجود بدون تغییر می‌مانند. |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | `radius` غیرمنفی و بر حسب پوینت اندازه‌گیری می‌شود؛ `grow` یک مقدار Boolean است که تعیین می‌کند محتوای محو شده ممکن است خارج از مرزهای اصلی تصویر گسترش یابد. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | درصد غیرمنفی. برای مقیاس‌گذاری شفافیت معمولی از `0` تا `100` استفاده کنید: `0` کاملاً شفاف و `100` شفافیت موجود را حفظ می‌کند. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` تا `100` درصد شفافیت. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` تا `100` درصد آلفای آستانه. مقادیر پایین‌تر شفاف می‌شوند؛ مقادیر برابر یا بالاتر مات می‌شوند. |

برای مدولاسیون ثابت آلفا، شفافیت و مات بودن مکمل یکدیگر هستند. برای مثال، 35 % شفافیت معادل مقدار مدولاسیون آلفا 65 % است.

## **اعمال روشنایی و کنتراست**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) یک عملیات [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) بازمی‌گرداند. تنظیمات اسکالر آن هنگام ساخت عملیات تامین می‌شود. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) مقادیر محاسبه‌شدهٔ فقط‑خواندنی را بر می‌گرداند که می‌توان آن‌ها را بازرسی یا لاگ کرد.

مثال زیر روشنایی را 15 % و کنتراست را 20 % افزایش می‌دهد، سپس پیش‌نمایشی را بدون تغییر تصویر جاسازی‌شده رندر می‌کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) یک افزونهٔ اثر تصویر Office 2010 است و نسبت به اثر روشنایی استاندارد DrawingML قابل‌حملیت کمتری دارد. وقتی که روشنایی و کنتراست باید پس از یک دورانی PPTX قابل ویرایش باقی بمانند، از [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) استفاده کنید و پس از باز کردن دوباره فایل نتیجه را تأیید کنید. بخش محدودیت‌های قالب این تفاوت را با جزئیات بیشتری توضیح می‌دهد.

## **اعمال تبدیلات رنگ**

اثرهای رنگ می‌توانند به‌صورت مستقل بر روی فریم‌های تصویری مختلف اعمال شوند که از یک منبع تصویر استفاده می‌کنند. مثال زیر پنج فریم ایجاد می‌کند و به ترتیب خاکستری، دو‑رنگ، رنگ‌دمه، تنظیم HSL و جایگزینی رنگ را اعمال می‌کند.

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) دو پارامتر رنگی مستقل دارد: `color1` پیکسل‌های تاریک و `color2` پیکسل‌های روشن را نقشه می‌کند. این باعث می‌شود که مثال مفیدی برای اثری باشد که تنظیمات پیچیده‌تری نسبت به یک مقدار اسکالر دارد.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) هر پیکسل را با یک رنگ ثابت جایگزین می‌کند در حالی که آلفا را حفظ می‌کند. این متفاوت از [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/) است که یک رنگ منبع را به رنگ هدفی نگاشت می‌کند و هر دو قالب رنگ منبع و هدف را در دسترس می‌گذارد.

### **اعمال آستانه روشنایی**

یک آستانه روشنایی می‌تواند علامت‌های ضعیف روی صفحهٔ اسکن‌شده را از پس‌زمینه متمایز کند. [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) سایه‌های میانی خاکستری را حفظ می‌کند. [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) روشنایی را به سیاه یا سفید نگاشت می‌کند، در حالی که [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) آستانه‌ای به شفافیت اعمال می‌کند.

آستانه روشنایی از 0 % تا 100 %، به شامل، متغیر است. پیکسل‌های زیر آستانه سیاه می‌شوند. پیکسل‌های برابر یا بالاتر سفید می‌شوند. افزایش آستانه رنگ‌های بیشتری را سیاه می‌کند زیرا تعداد بیشتری از آن‌ها زیر برش قرار می‌گیرند.

فایل [grayscale-swatches.png](grayscale-swatches.png) را در پوشهٔ کاری خود دانلود کنید. هر برچسب سطح خاکستری اصلی را روی مقیاس 0 تا 255 نشان می‌دهد. مثال اصلی را کنار دو نسخهٔ کپی قرار می‌دهد و آستانهٔ هر کپی را در ارائه ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 150, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    with slides.Images.from_file("grayscale-swatches.png") as source_image:
        image = presentation.images.add_image(source_image)

    def add_frame(x, caption):
        label = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 12, 216, 36)
        label.text_frame.text = caption
        return shapes.add_picture_frame(slides.ShapeType.RECTANGLE, x, 60, 216, 72, image)

    add_frame(12, "Original")

    low_threshold = add_frame(252, "Threshold 20%")
    low_threshold.picture_format.picture.image_transform.add_bi_level_effect(20)
    
    high_threshold = add_frame(492, "Threshold 60%")
    high_threshold.picture_format.picture.image_transform.add_bi_level_effect(60)

    presentation.save("luminance-threshold.pptx", slides.export.SaveFormat.PPTX)
```

ارائهٔ خروجی را در PowerPoint باز کنید تا سه فریم را مقایسه کنید. سواش با برچسب 96 حدود 38 % روشنایی (96 از 255) دارد. در آستانهٔ 20 % سفید می‌شود و در آستانهٔ 60 % سیاه می‌شود.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **افزودن محو، شفافیت و اثرهای آلفا**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) همهٔ کانال‌های رنگ، از جمله آلفا را تحت تأثیر قرار می‌دهد. وقتی که لبهٔ محو ممکن است خارج از مرزهای اصلی تصویر گسترش یابد، `grow` را به `True` تنظیم کنید.

برای شفافیت یکنواخت، از [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) استفاده کنید. این مقدار هر آلفای موجود را ضرب می‌کند، بنابراین پیکسل‌های نیمه‌شفاف به نسبتی متفاوت باقی می‌مانند. [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) به‌جای آن یک مقدار آلفا واحد را به تمام پیکسل‌ها اختصاص می‌دهد. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) آلفا را بر پایهٔ یک آستانه به دو سطح تبدیل می‌کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

سایر عملیات آلفای بدون پارامتر شامل [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/)، که هر آلفای غیرصفر را کاملاً مات می‌کند؛ [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/)، که هر آلفای زیر 100 % را کاملاً شفاف می‌کند؛ و [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/)، که آلفا را به ‎`100% - alpha` تغییر می‌دهد، می‌باشد.

## **ساخت یک زنجیرهٔ اثر مرتب**

هر متد `add_..._effect` یک عملیات جدید را به انتهای مجموعه اضافه می‌کند. رندرکننده مجموعه را به‌عنوان یک لولهٔ پردازشی مرتب استفاده می‌کند: خروجی عملیات 0 ورودی عملیات 1 می‌شود و به همین ترتیب. بنابراین، همان عملیات‌ها در ترتیب متفاوت می‌توانند تصویر متفاوتی تولید کنند.

به‌عنوان مثال، خاکستری‑سپس‑رنگ‌دمه ابتدا اطلاعات رنگی را حذف می‌کند و سپس نتیجهٔ روشنایی را رنگ‌دمه می‌کند. رنگ‌دمه‑سپس‑خاکستری رنگ‌دمه را دوباره حذف می‌کند. به‌طور مشابه، جایگزینی آلفا می‌تواند مقادیر آلفای محاسبه‌شده توسط عملیات‌های قبلی را بازنویسی کند، در حالی که مدولاسیون آلفا اختلافات نسبی آن‌ها را حفظ می‌کند.

مثال زیر یک زنجیرهٔ چهارعملیاتی می‌سازد، به‌صورت PPTX ذخیره می‌کند، ارائه را دوباره باز می‌کند، هم نوع عملیات و هم ترتیب آن‌ها را بررسی می‌کند و نتیجهٔ بازگشایی‌شده را رندر می‌کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

مجموعه محدودیتی برای ترکیب رنگ، آلفا و محو در زنجیره‌های جداگانه اعمال نمی‌کند. می‌توان آن‌ها را ترکیب کرد، اما ترکیب‌ها همیشه مفید نیستند. یک جایگزینی رنگ ثابت، تنوع RGB تولیدشده توسط اثرهای رنگی قبلی را حذف می‌کند؛ خاکستری پس از دو‑رنگ دو رنگ منتخب را حذف می‌کند؛ و عملیات‌های آلفای ceiling، floor، replacement یا bi‑level می‌توانند جزئیات آلفا ایجادشدهٔ قبلی را از بین ببرند. زنجیره را بر اساس توالی پردازش پیکسل موردنظر بسازید نه به‌عنوان پرچم‌های فرمت‌بندی بدون ترتیب.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*در این رندر نمونهٔ Aspose.Slides for .NET 26.11، یک رنگ‌دمهٔ 220° با 25 % تصویر خاکستری را تغییر نمی‌دهد. اعمال همان رنگ‌دمه قبل از خاکستری تن‌های متفاوتی تولید می‌کند.*
<!-- visual-explanation:image-transform-effects:end -->

## **بازرسی مقادیر قابل ویرایش و مؤثر**

یک عملیات قابل ویرایش شیئی است که در `Picture.image_transform` ذخیره می‌شود. بسته به اثر، ممکن است اعضای قابل نوشتن را مستقیماً افشا کند. به‌عنوان مثال، [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) ویژگی‌های `radius` و `grow` را قابل نوشتن می‌کند، [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) ویژگی `amount` را قابل نوشتن می‌نماید، و [AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) ویژگی `threshold` را قابل نوشتن می‌کند. اثرهای رنگی مانند [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) اشیای [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/) قابل تغییر را افشا می‌کند.

برخی عملیات‌ها، از جمله [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/)، [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/)، [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/)، و [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/)، مقادیر اسکالر ایجادشان را به عنوان ویژگی‌های قابل نوشتن افشا نمی‌کنند. برای تغییر این تنظیمات، عملیات را حذف کنید و یک جایگزین در موقعیت موردنظر اضافه کنید.

دادهٔ مؤثر برگردانده‌شده توسط `get_effective()` محاسبه‌شده و فقط‑خواندنی است. برای حل رنگ‌های وابسته به تم و خواندن مقادیر نرمال‌شده‌ای که رندرکننده استفاده می‌کند مفید است، اما سطح ویرایش دیگری نیست. مثال زیر زنجیره را شمارش می‌کند و مقادیر مؤثری که API متناظر آن‌ها را فراهم می‌کند، بازرسی می‌نماید:

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

اثرهای بدون پارامتر مانند خاکستری، آلفا ceiling و آلفا inverse همچنان یک شیء دادهٔ مؤثر دارند، اما مقدار اسکالر برای چاپ وجود ندارد. حضور و موقعیت‌شان در مجموعه اطلاعات مهم هستند.

## **حذف یا پاک‌سازی تبدیل‌های تصویر**

از [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) برای حذف یک عملیات بر اساس اندیس استفاده کنید. چون اندیس‌ها پس از حذف جابجا می‌شوند، ابتدا هدف را جستجو کنید و پس از شمارش آن را حذف کنید. برای حذف تمام زنجیره از `clear()` استفاده کنید.

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

حذف یا پاک‌سازی تبدیل‌ها فقط قالب‌بندی تصویر را تغییر می‌دهد. منبع [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) استفاده‌شده را حذف، بازنشر یا به‌صورت دیگری تغییر نمی‌دهد.

## **در نظر گرفتن قالب‌های ارائه و اهداف خروجی**

تبدیل‌های تصویر از DrawingML منشأ می‌گیرند، بنابراین PPTX قالب ویرایش‌پذیر ترجیحی برای زنجیره‌های اثر است. حتی با PPTX، همهٔ عملیات‌ها همان سطح قابل‌حملیت را ندارند:

- عملیات‌های استاندارد DrawingML مانند luminance، grayscale، duotone، tint، HSL، blur و عملیات‌های رایج آلفا شانس بهترین بقا را در یک دورانی PPTX دارند. همیشه فایل تولیدشده را دوباره باز کنید و مجموعه را بررسی کنید زمانی که حفظ‌پذیری ضروری است.
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) یک افزونهٔ Office 2010 است نه عملیات استاندارد DrawingML luminance. می‌تواند برای رندر در حافظه استفاده شود، اما تضمین نمی‌شود که پس از ذخیره‌سازی و بازگشایی PPTX همچنان به‌عنوان عملیات `BrightnessContrast` ویرایش‑پذیر باقی بماند. برای تنظیمات دائمی روشنایی و کنتراست از [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) استفاده کنید.
- قالب باینری PPT پیش از مدل کامل اثر DrawingML وجود داشته است. ذخیره به PPT می‌تواند عملیات‌های پشتیبانی‌نشده را حذف کند، زنجیره را به زیرمجموعه‌ای پشتیبانی‌شده کاهش دهد یا ظاهر را تقریب بزند. برای تأیید یک زنجیرهٔ ویرایش‑پذیر پیچیده، از PPT به‌عنوان قالب تأیید استفاده نشود.
- رندر به PNG، JPEG، TIFF، PDF، SVG، HTML یا سایر خروجی‌های تصویری زنجیرهٔ پشتیبانی‌شده را بر روی ظاهر رندر اعمال می‌کند. این خروجی‌ها شامل `ImageTransformOperationCollection` ویرایش‑پذیر نیستند؛ فرمت‌های رستر نتیجه را به‌صورت پیکسل‌ها مسطح می‌کنند و صادرات اسناد یا برداری نمایش رندر خود را ذخیره می‌کنند.
- اثرها تصویر پیوندی را خودکفا نمی‌سازند. رندر یک تصویر پیوندی همچنان به موجود بودن منبع پیوندی هنگام بارگذاری ارائه وابسته است.

مصرف‌کنندگان مختلف ارائه ممکن است موارد لبه‌ای را به‌صورت متفاوتی رندر کنند، به‌ویژه وقتی چندین عملیات آلفا یا رنگ‑کمیت‌دار ترکیب شوند. برای خروجی‌های بحرانی، هم دورانی ویرایش‑پذیر و هم قالب صادراتی نهایی را با همان نسخهٔ Aspose.Slides که در تولید استفاده می‌شود، تست کنید.

## **سوالات متداول**

**آیا اثرهای تبدیل تصویر دادهٔ تصویر جاسازی‌شده را تغییر می‌دهند؟**

نه. این عملیات‌ها متعلق به `Picture` استفاده‌شده توسط پرکنندهٔ تصویر هستند. بایت‌های زیرین `PPImage` بدون تغییر می‌مانند.

**آیا دو فریم تصویری که از یک تصویر استفاده می‌کنند اثرهای خود را به‌اشتراک می‌گذارند؟**

نه. استفادهٔ مشترک از `PPImage` از تکرار دادهٔ تصویر جلوگیری می‌کند، اما هر فریم تصویری معمولاً `Picture` و مجموعهٔ تبدیل تصویر جداگانه‌ای دارد.

**آیا می‌توان اثرهای رنگ، محو و آلفا را ترکیب کرد؟**

بله. مجموعه آن‌ها را در یک زنجیرهٔ مرتب می‌پذیرد. به این فکر کنید که هر عملیات چه تأثیری بر خروجی عملیات قبلی دارد زیرا عملیات‌های جایگزینی و آستانه ممکن است جزئیات رنگ یا آلفای قبلی را از بین ببرند.

**چرا مقادیر مؤثر فقط‑خواندنی هستند؟**

دادهٔ مؤثر مقادیر محاسبه‌شدهٔ استفاده‌شده برای رندر، از جمله رنگ‌های حل‌شده، را نمایان می‌کند. عملیات ذخیره‌شده در مجموعهٔ تبدیل را ویرایش کنید جایی که اعضای قابل نوشتن وجود دارد؛ در غیر این صورت آن را حذف کنید و با پارامترهای ایجاد جدید جایگزین کنید.

**کدام قالب را باید برای حفظ زنجیرهٔ تبدیل استفاده کنم؟**

از PPTX استفاده کنید و فایل را با بازگشایی دوباره تأیید کنید. قالب قدیمی PPT نمی‌تواند مدل کامل اثر DrawingML را نشان دهد و قالب‌های خروجی رندر فقط ظاهر را حفظ می‌کند، نه عملیات قابل ویرایش.