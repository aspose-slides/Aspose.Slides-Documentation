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
- تبدیل به خاکستری
- دو رنگی
- رنگ‌سایه
- HSL
- جایگزینی رنگ
- تاری
- شفافیت
- اثر آلفا
- زنجیرهٔ اثر
- PowerPoint
- ارائه
- پایتون
- Aspose.Slides
description: "اعمال، زنجیره‌بندی، بازرسی، حذف و تأیید اثرهای تبدیل تصویر برای قاب‌های تصویری با Aspose.Slides برای پایتون از طریق .NET."
---
## **مرور کلی**

Aspose.Slides تنظیمات تصویر را به صورت یک مجموعهٔ مرتب از عملیات تبدیل تصویر (image transform) نشان می‌دهد. برای یک قاب تصویر، ابتدا از [Picture](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picture/) قاب شروع کنید و به ویژگی [image_transform](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picture/image_transform/) آن دسترسی پیدا کنید. مجموعهٔ [ImageTransformOperationCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/effects/imagetransformoperationcollection/) برگردانده‌شده به شما امکان می‌دهد عملیات‌ها را اضافه، پیمایش، بررسی، حذف و پاک‌سازی کنید بدون این که بایت‌های تصویر اصلی بازنویسی شوند.

این مقاله یک جریان کاری کامل برای روشنایی و کنتراست، تبدیل‌های رنگی، تاری، شفافیت، زنجیرهٔ اثربخشی مرتبی، مقادیر مؤثر، حذف و اعتبارسنجی دوره‌گرد PPTX را نشان می‌دهد.

## **درک مالکیت اثر و استفاده مجدد از تصویر**

یک منبع تصویر و تصویری که آن را نمایش می‌دهد، اشیای متفاوتی هستند:

- [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) دادهٔ تصویر منبع را که متعلق به ارائه (presentation) است، ذخیره یا ارجاع می‌دهد.
- [Picture](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picture/) متعلق به یک پر کردن تصویر (picture fill) است و به منبع تصویر اشاره می‌کند در حالی که مجموعهٔ تبدیل تصویر را نگه می‌دارد.
- [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) شکل اسلاید است که پر کردن تصویر، هندسه، تنظیمات برش و سایر قالب‌بندی‌های سطح قاب را در اختیار دارد.

بنابراین، عملیات‌های تبدیل تصویر بایت‌های موجود در [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) را تغییر نمی‌دهند. وقتی همان `PPImage` بیشتر از یک بار به [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_picture_frame/) پاس داده می‌شود، هر قاب تصویر جدید یک `Picture` و یک مجموعهٔ تبدیل تصویر جداگانه دریافت می‌کند. اعمال خاکستری بر یک قاب، باعث نمی‌شود سایر قاب‌ها خاکستری شوند، حتی اگر همهٔ آن‌ها از همان منبع تصویر تعبیه‌شده استفاده کنند.

مدل `Picture.image_transform` همچنین توسط پر کردن‌های تصویری دیگر مانند شکل یا پس‌زمینهٔ اسلاید استفاده می‌شود. مثال‌های زیر بر قاب‌های تصویری تمرکز دارند.

## **استفاده از بازه‌ها و واحدهای معتبر پارامتر**

روش‌های نشان‌داده‌شده از بازه‌ها و واحدهای معنایی زیر استفاده می‌کنند. حتی اگر نسخهٔ خاصی از کتابخانه هر مقدار خارج از بازه را بلافاصله رد نکند، مقادیر را در این بازه‌ها نگه دارید؛ فرمت هدف ممکن است در زمان ذخیره یا هنگام باز کردن فایل توسط PowerPoint، داده‌های نامعتبر را نرمال‌سازی، حذف یا رد کند.

| عملیات | پارامترها | بازه و واحد معتبر |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` تا `100`، درصد؛ `0` مؤلفه را بدون تغییر می‌گذارد. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | بدون پارامتر عددی. آلفا بدون تغییر می‌ماند. |
| [add_duotone_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | دو رنگ برای پیکسل‌های تاریک و روشن. مقادیر کانال‌های RGB و آلفا از `0` تا `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | `hue` از `0` شامل تا `360` به‌جز می‌باشد، بر حسب درجه؛ `amount` از `-100` تا `100`، درصد. |
| [add_hsl_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | `hue` از `0` شامل تا `360` به‌جز، بر حسب درجه؛ `saturation` و `luminance` از `-100` تا `100`، درصد. |
| [add_color_replace_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | رنگ جایگزین از مقادیر `0` تا `255` برای هر کانال استفاده می‌کند. مقادیر آلفای موجود بدون تغییر می‌مانند. |
| [add_blur_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | `radius` غیرمنفی و بر حسب پوینت اندازه‌گیری می‌شود؛ `grow` یک Boolean است که تعیین می‌کند آیا محتوای تاری می‌تواند خارج از مرزهای اصلی گسترش یابد یا نه. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | درصد غیرمنفی. برای مقیاس‌گذاری شفافیت معمولی از `0` تا `100` استفاده کنید: `0` کاملاً شفاف و `100` آلفای موجود را حفظ می‌کند. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` تا `100`، درصد شفافیت. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` تا `100`، درصد آستانهٔ آلفا. مقادیر زیر این آستانه شفاف می‌شوند؛ مقادیر برابر یا بالای آن مات می‌شوند. |

برای مدولاسیون ثابت آلفا، شفافیت و مات بودن مکمل یکدیگرند. به‌عنوان مثال، 35٪ شفافیت معادل مقدار مدولاسیون آلفا 65٪ است.

## **اعمال روشنایی و کنتراست**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) یک عملیات [BrightnessContrast](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/brightnesscontrast/) بر می‌گرداند. تنظیمات اسکالر آن هنگام ایجاد عملیات فراهم می‌شود. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) مقادیر محاسبه‌شدهٔ فقط‑خواندنی را بر می‌گرداند که می‌توان آن‌ها را بررسی یا لاگ کرد.

مثال زیر روشنایی را 15٪ و کنتراست را 20٪ افزایش می‌دهد، سپس پیش‌نمایشی را بدون تغییر تصویر تعبیه‌شده رندر می‌کند:

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

[BrightnessContrast](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/brightnesscontrast/) یک افزونهٔ اثر تصویری Office 2010 است و نسبت به اثر روشنایی استاندارد DrawingML قابل‌حمل کمتری دارد. هنگامی که روشنایی و کنتراست پس از یک دور‌گرد PPTX باید ویرایش‌پذیر باقی بمانند، از [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) استفاده کنید و پس از باز کردن مجدد فایل، نتیجه را تأیید کنید. بخش محدودیت‌های فرمت این تفاوت را با جزئیات بیشتری توضیح می‌دهد.

## **اعمال تبدیل‌های رنگی**

تاثیرات رنگی می‌توانند به‌صورت مستقل بر قاب‌های تصویری مختلفی که یک منبع تصویر را به‌ اشتراک می‌گذارند، اعمال شوند. مثال زیر پنج قاب ایجاد کرده و به ترتیب خاکستری، دو‑تن، رنگ‌سایه، تنظیم HSL و جایگزینی رنگ را اعمال می‌کند.

[Duotone](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/duotone/) دو پارامتر رنگی مستقل‑قابل‑ویرایش دارد: `color1` پیکسل‌های تاریک را نگاشت می‌کند، در حالی که `color2` پیکسل‌های روشن را. این یک مثال مفید از اثری است که تنظیماتش پیچیده‌تر از یک مقدار اسکالر ساده است.

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

[add_color_replace_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) هر پیکسل را با یک رنگ ثابت جایگزین می‌کند در حالی که آلفا را حفظ می‌نماید. این متفاوت از [add_color_change_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/) است که یک رنگ منبع را به رنگ دیگر نگاشت می‌کند و هر دو فرمت رنگ منبع و هدف را در دسترس می‌گذارد.

## **افزودن تاری، شفافیت و اثرات آلفا**

[add_blur_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) تمام کانال‌های رنگی از جمله آلفا را تحت تأثیر قرار می‌دهد. زمانی که لبهٔ تاری ممکن است فراتر از مرزهای تصویر اصلی گسترش یابد، `grow` را به `True` تنظیم کنید.

برای شفافیت یکنواخت، از [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) استفاده کنید. این اثر هر مقدار آلفای موجود را ضرب می‌کند، بنابراین پیکسل‌های نیمه‌شفاف به‌نسبت متفاوت باقی می‌مانند. [add_alpha_replace_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) به‌جای آن یک مقدار آلفا واحد را به همهٔ پیکسل‌ها اختصاص می‌دهد. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) آلفا را بر اساس یک آستانه به دو سطح تبدیل می‌کند.

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

سایر عملیات آلفای بدون پارامتر شامل [add_alpha_ceiling_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/) است که هر آلفای غیراز صفر را کاملاً مات می‌کند؛ [add_alpha_floor_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/) که هر آلفای زیر 100٪ را کاملاً شفاف می‌کند؛ و [add_alpha_inverse_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/) که آلفا را به `100% - alpha` تغییر می‌دهد.

## **ساخت یک زنجیرهٔ اثر مرتب**

هر متد `add_..._effect` یک عملیات جدید را به انتهای مجموعه اضافه می‌کند. رندرر مجموعه را به‌عنوان یک خط لولهٔ مرتب استفاده می‌کند: خروجی عملیات 0 به عنوان ورودی عملیات 1 و به همین ترتیب. بنابراین، همان عملیات‌ها به ترتیب متفاوت می‌توانند تصویر متفاوتی تولید کنند.

به‌عنوان مثال، ابتدا خاکستری و سپس رنگ‌سایه ابتدا اطلاعات رنگی را حذف می‌کند و سپس نتیجهٔ روشنایی را رنگ‌آمیزی می‌کند. رنگ‌سایه سپس خاکستری باعث حذف دوبارهٔ رنگ‌سایه می‌شود. به‌طور مشابه، جایگزینی آلفا می‌تواند مقادیر آلفای محاسبه‌شده توسط عملیات‌های قبلی را بازنویسی کند، در حالی که مدولاسیون آلفا اختلافات نسبی آن‌ها را حفظ می‌کند.

مثال زیر یک زنجیرهٔ چهارعملیاتی می‌سازد، آن را به‌صورت PPTX ذخیره می‌کند، ارائه را باز می‌خواند، هر دو نوع عملیات و ترتیب آن‌ها را بررسی می‌کند و نتیجهٔ بازخوانی شده را رندر می‌کند:

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

مجموعه محدودیتی برای ترکیب اثرات رنگ، آلفا و تاری در زنجیره‌های جداگانه اعمال نمی‌کند. می‌توان آن‌ها را ترکیب کرد، اگرچه ترکیب‌ها همیشه مفید نیستند. یک جایگزینی رنگ ثابت، تنوع RGB تولیدشده توسط اثرات رنگی قبلی را حذف می‌کند؛ خاکستری پس از دو‑تن دو رنگ انتخابی را از بین می‌برد؛ و عملیات‌های آلفا ceiling، floor، replacement یا bi‑level می‌توانند جزئیات آلفایی ایجادشده پیش‌تر را نادیده بگیرند. زنجیره را بر اساس توالی پردازش پیکسل موردنظر بسا‌ید نه به‌عنوان پرچم‌های قالب‌بندی بدون ترتیب.

## **بررسی مقادیر قابل‌ویرایش و مؤثر**

یک عملیات قابل‌ویرایش همان شیء ذخیره‌شده در `Picture.image_transform` است. بسته به اثر، ممکن است اعضای قابل‌نوشت مستقیم را ارائه دهد. به‌عنوان مثال، [Blur](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/blur/) خصوصیات نوشتنی `radius` و `grow` را افشا می‌کند، [AlphaModulateFixed](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/alphamodulatefixed/) خصوصیت نوشتنی `amount` را، و [AlphaBiLevel](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/alphabilevel/) خصوصیت نوشتنی `threshold` را. اثرات رنگی مانند [Duotone](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/duotone/) اشیای [ColorFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/colorformat/) قابل تغییر را ارائه می‌دهند.

برخی عملیات‌ها مانند [BrightnessContrast](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/brightnesscontrast/)، [HSL](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/hsl/)، [Tint](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/tint/) و [AlphaReplace](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/alphareplace/) اسکالرهای ساخت خود را به‌عنوان خصوصیت‌های نوشتنی در دسترس قرار نمی‌دهند. برای تغییر این تنظیمات، عملیات را حذف کرده و یک جایگزین در موقعیت موردنظر اضافه کنید.

دادهٔ مؤثر بازگردانده‌شده توسط `get_effective()` محاسبه‌شده و فقط‑خواندنی است. برای حل رنگ‌های وابسته به تم و خواندن مقادیر نرمال‌شده‌ای که رندرر استفاده می‌کند مفید است، اما سطح ویرایش دیگری نیست. مثال زیر زنجیره را پیمایش کرده و مقادیر مؤثر را در جایی که API مربوطه آن‌ها را فراهم می‌کند، بررسی می‌کند:

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

اثرهای بدون پارامتر مانند grayscale، alpha ceiling و alpha inverse همچنان یک شیء دادهٔ مؤثر دارند، اما مقدار اسکالری برای چاپ ندارند. حضور و موقعیت آن‌ها در مجموعه اطلاعات مهم هستند.

## **حذف یا پاک‌سازی تبدیل‌های تصویر**

از [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) برای حذف یک عملیات بر اساس شاخص استفاده کنید. چون شاخص‌ها پس از حذف جابه‌جا می‌شوند، ابتدا هدف را جستجو کنید و پس از پیمایش آن را حذف کنید. برای حذف کل زنجیره از `clear()` استفاده کنید.

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

حذف یا پاک‌سازی تبدیل‌ها فقط قالب‌بندی تصویر را تغییر می‌دهد. منبع [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) تعبیه‌شده حذف، فشرده‌سازی یا به‌طور دیگری تغییر نمی‌کند.

## **در نظر گرفتن فرمت‌های ارائه و هدف‌های خروجی**

تبدیل‌های تصویر در DrawingML منشا می‌گیرند، بنابراین PPTX فرمت قابل‌ویرایش ترجیحی برای زنجیره‌های اثر است. حتی با PPTX، هر عملیات قابلیت حمل یکسانی ندارد:

- عملیات‌های استاندارد DrawingML مانند luminance، grayscale، duotone، tint، HSL، blur و عملیات‌های آلفای رایج بیشترین شانس برای بقا پس از یک دور‌گرد PPTX را دارند. همیشه فایل تولیدشده را بازخوانی کنید و مجموعه را بررسی کنید وقتی حفظ‌پذیری الزامی است.
- [BrightnessContrast](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/brightnesscontrast/) یک افزونهٔ Office 2010 است نه عملیات استاندارد luminance DrawingML. می‌تواند برای رندرینگ در حافظه استفاده شود، اما تضمین نمی‌شود پس از ذخیره و بازخوانی PPTX به‌عنوان یک عملیات `BrightnessContrast` قابل‌ویرایش بماند. برای تنظیمات پایدار روشنایی و کنتراست، از [add_luminance_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) استفاده کنید.
- فرمت باینری PPT پیش از مدل کامل اثر DrawingML وجود داشته است. ذخیره به PPT ممکن است عملیات‌های پشتیبانی‌نشده را حذف کند، زنجیره را به زیرمجموعه‌ای پشتیبانی‌شده تقلیل دهد یا ظاهر را تقریب بزند. برای تأیید زنجیرهٔ پیچیدهٔ قابل‌ویرایش از PPT استفاده نکنید.
- رندرینگ به PNG، JPEG، TIFF، PDF، SVG، HTML یا سایر خروجی‌های بصری، زنجیرهٔ پشتیبانی‌شده را بر ظاهر رندر شده اعمال می‌کند. این خروجی‌ها `ImageTransformOperationCollection` قابل‌ویرایش را شامل نمی‌شوند؛ فرمت‌های رستر نتیجه را به پیکسل‌ها مسطح می‌کنند و صادرات اسناد یا برداری نمایش رندر خودشان را ذخیره می‌کنند.
- اثرات تصویر یک تصویر پیوندی را خودمند نمی‌کنند. رندرینگ تصویر لینک‌شده همچنان به در دسترس بودن منبع لینک‌شده هنگام بارگذاری ارائه وابسته است.

مصرف‌کنندگان مختلف ارائه ممکن است موارد لبه‌ای را به‌صورت متفاوتی رندر کنند، به‌ویژه وقتی چندین عملیات آلفا یا رنگ‑کوانت‌سازی ترکیب شوند. برای خروجی‌های بحرانی، هر دو دور‌گرد قابل‌ویرایش و فرمت خروجی نهایی را با همان نسخهٔ Aspose.Slides که در تولید استفاده می‌شود، تست کنید.

## **سؤالات متداول**

**آیا اثرات تبدیل تصویر دادهٔ تصویر تعبیه‌شده را تغییر می‌دهند؟**

نه. این عملیات‌ها متعلق به `Picture` استفاده‌شده توسط پر کردن تصویر هستند. بایت‌های زیرین `PPImage` بدون تغییر می‌مانند.

**آیا دو قاب تصویر که از یک تصویر استفاده می‌کنند اثرات خود را به‌اشتراک می‌گذارند؟**

نه. استفاده مجدد از یک `PPImage` از تکرار دادهٔ تصویر جلوگیری می‌کند، اما هر قاب تصویر به‌طور معمول یک `Picture` و یک مجموعهٔ تبدیل تصویر جداگانه دارد.

**آیا می‌توان اثرات رنگ، تاری و آلفا را ترکیب کرد؟**

بله. مجموعه آن‌ها را در یک زنجیرهٔ مرتب می‌پذیرد. به این فکر کنید که هر عملیات چه وضعیتی را بر خروجی عملیات قبلی ایجاد می‌کند، چون عملیات‌های جایگزینی و آستانه ممکن است جزئیات رنگ یا آلفای قبلی را حذف کنند.

**چرا مقادیر مؤثر فقط‑خواندنی هستند؟**

دادهٔ مؤثر مقادیر محاسبه‌شده‌ای را نشان می‌دهد که برای رندر استفاده می‌شود، از جمله رنگ‌های حل‑شده. برای ویرایش، عملیات ذخیره‌شده در مجموعهٔ تبدیل را ویرایش کنید جایی که اعضای نوشتنی موجود هستند؛ در غیر این صورت آن را حذف کنید و با پارامترهای ساخت جدید جایگزین کنید.

**کدام فرمت را برای حفظ یک زنجیرهٔ تبدیل توصیه می‌کنید؟**

از PPTX استفاده کنید و فایل را با بازخوانی مجدد تأیید کنید. PPT قدیمی قادر به نمایش کامل مدل اثر DrawingML نیست و فرمت‌های خروجی رندر شده فقط ظاهر را حفظ می‌کنند نه عملیات‌های تبدیل قابل‌ویرایش.