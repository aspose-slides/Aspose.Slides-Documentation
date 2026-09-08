---
title: مدیریت افکت‌های تبدیل تصویر در ارائه‌ها با پایتون
linktitle: افکت‌های تبدیل تصویر
type: docs
weight: 11
url: /fa/python-java/image-transform-effects/
keywords:
- تبدیل تصویر
- افکت تصویر
- روشنایی
- کنتراست
- خاکستری
- دو‌رنگی
- رنگ‌پاشی
- HSL
- جایگزینی رنگ
- محو
- شفافیت
- افکت آلفا
- زنجیره افکت
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "اعمال، زنجیره‌سازی، بازرسی، حذف و اعتبارسنجی افکت‌های تبدیل تصویر برای قاب‌های تصویر با Aspose.Slides برای پایتون از طریق جاوا."
---
## **نمایش کلی**

Aspose.Slides تنظیمات تصویر را به عنوان مجموعه‌ای مرتب از عملیات تبدیل تصویر نمایش می‌دهد. برای یک قاب تصویر، با [Picture](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picture/) قاب شروع کنید و به [Picture.getImageTransform](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picture/#getImageTransform) دسترسی پیدا کنید. مجموعهٔ بازگشتی [ImageTransformOperationCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/) به شما اجازه می‌دهد تا اثرات را اضافه، فهرست، بازرسی، حذف و پاک کنید بدون اینکه بایت‌های تصویر اصلی بازنویسی شوند.

این مقاله یک جریان کاری کامل برای روشنایی و کنتراست، تبدیل رنگ‌ها، تار شدن، شفافیت، زنجیره‌های اثر مرتب، مقادیر مؤثر، حذف و تأیید دورانی PPTX را نشان می‌دهد.

## **درک مالکیت اثر و استفادهٔ مجدد از تصویر**

یک منبع تصویر و تصویری که آن را نمایش می‌دهد، اشیای متفاوتی هستند:

- [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) داده‌های تصویر منبع را که متعلق به ارائه است، ذخیره یا به آنها ارجاع می‌دهد.
- [Picture](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picture/) به یک پر کردن تصویر تعلق دارد و به منبع تصویر ارجاع می‌دهد در حالی که مجموعهٔ تبدیل تصویر را نگهداری می‌کند.
- [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) شکل اسلاید است که پر کردن تصویر مربوطه، هندسه، تنظیمات برش و سایر قالب‌بندی‌های سطح قاب را دارا است.

بنابراین، عملیات تبدیل تصویر بایت‌های موجود در [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) را تغییر نمی‌دهند. هنگامی که همان `PPImage` بیش از یک بار به [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addPictureFrame) داده می‌شود، هر قاب تصویر جدید `Picture` و مجموعهٔ تبدیل تصویر خود را دریافت می‌کند. اعمال مقیاس خاکستری بر یک قاب، دیگر قاب‌ها را خاکستری نمی‌کند، حتی اگر همهٔ آنها از همان منبع تصویر جاسازی‌شده استفاده کنند.

مدل `Picture.getImageTransform` مشابه برای پر کردن‌های تصویری دیگر نیز به کار می‌رود، مانند پس‌زمینهٔ شکل یا اسلاید. مثال‌های زیر بر روی قاب‌های تصویر متمرکز هستند.

## **استفاده از بازه‌ها و واحدهای معتبر برای پارامترها**

روش‌های نشان داده‌شده از بازه‌ها و واحدهای معنایی زیر استفاده می‌کنند. حتی اگر نسخهٔ خاصی از کتابخانه هر مقدار خارج از بازه را بلافاصله رد نکند، مقادیر را در این بازه‌ها نگه دارید؛ قالب هدف ممکن است هنگام ذخیره یا باز کردن فایل توسط PowerPoint، داده‌های نامعتبر را نرمال‌سازی، حذف یا رد کند.

| عملیات | پارامترها | بازه معتبر و واحد |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` تا `100`، درصد؛ `0` مؤلفه را دست‌نخورده می‌گذارد. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | None | پارامتر عددی ندارد. آلفا دست‌نخورده می‌ماند. |
| [addDuotoneEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | دو رنگ برای پیکسل‌های تاریک و روشن. کانال‌های RGB و آلفا در `java.awt.Color` از `0` تا `255` استفاده می‌شوند. |
| [addTintEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | hue از `0` (شامل) تا `360` (به‌جز) درجه؛ amount از `-100` تا `100` درصد. |
| [addHSLEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | hue از `0` تا `360` درجه؛ saturation و luminance از `-100` تا `100` درصد. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | رنگ جایگزین مقادیر کانال‌های `0` تا `255` دارد. مقادیر آلفای موجود دست‌نخورده می‌مانند. |
| [addBlurEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | radius غیرمنفی و بر حسب نقاط اندازه‌گیری می‌شود؛ `grow` یک Boolean است که کنترل می‌کند آیا محتوای تار شده می‌تواند خارج از مرزهای اصلی گسترش یابد یا خیر. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | درصد غیرمنفی. برای مقیاس شفافیت معمولی از `0` تا `100` استفاده کنید: `0` کاملاً شفاف و `100` آلفای موجود را حفظ می‌کند. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` تا `100` درصد شفافیت. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` تا `100` درصد آلفا. مقادیر زیر آستانه شفاف می‌شوند؛ مقادیر برابر یا بالاتر مات می‌شوند. |

برای مدولاسیون ثابت آلفا، شفافیت و مات بودن مکمل یکدیگرند. برای مثال، 35٪ شفافیت معادل مقدار مدولاسیون آلفا 65٪ است.

## **اعمال روشنایی و کنتراست**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) یک عملیات [BrightnessContrast](https://reference.aspose.com/slides/fa/python-java/aspose.slides/brightnesscontrast/) برمی‌گرداند. تنظیمات اسکالاری آن هنگام ایجاد عملیات تأمین می‌شود. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/brightnesscontrast/#getEffective) مقادیر فقط‌خواندنی محاسبه‌شده را برمی‌گرداند که می‌توان آن‌ها را بازرسی یا لاگ کرد.

مثال زیر روشنایی را 15٪ و کنتراست را 20٪ افزایش می‌دهد و سپس پیش‌نمایشی بدون تغییر تصویر جاسازی‌شده رندر می‌کند:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/fa/python-java/aspose.slides/brightnesscontrast/) افزونهٔ افکت تصویر Office 2010 است و کمتر قابل حمل از افکت روشنایی استاندارد DrawingML است. وقتی روشنایی و کنتراست پس از یک دور PPTX باید قابل ویرایش بمانند، از [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) استفاده کنید و پس از باز کردن مجدد فایل نتیجه را تأیید کنید. بخش محدودیت‌های فرمت این تفاوت را با جزئیات بیشتری توضیح می‌دهد.

## **اعمال تبدیل‌های رنگی**

افکت‌های رنگی می‌توانند به‌صورت مستقل بر قاب‌های تصویری مختلفی که از یک منبع تصویر استفاده می‌کنند، اعمال شوند. مثال زیر پنج قاب ایجاد می‌کند و به ترتیب خاکستری، دو‌رنگی، رنگ‌پاشی، تنظیم HSL و جایگزینی رنگ را اعمال می‌کند.

[Duotone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/duotone/) دو پارامتر رنگی مستقل و قابل ویرایش دارد: `color1` پیکسل‌های تاریک، در حالی که `color2` پیکسل‌های روشن را نقشه می‌کند. این یک مثال مفید از افکتی است که تنظیمات آن پیچیده‌تر از یک مقدار اسکالاری ساده است.

```python
import jpime
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) رنگ هر پیکسل را با یک رنگ ثابت جایگزین می‌کند در حالی که آلفا را حفظ می‌سازد. این متفاوت از [addColorChangeEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect) است که یک رنگ مبدأ را به رنگ هدف دیگری نقشه می‌کند و هر دو قالب رنگ مبدأ و هدف را نمایان می‌سازد.

## **افکت‌های تار، شفافیت و آلفا را اضافه کنید**

[addBlurEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) تمام کانال‌های رنگی، از جمله آلفا را تحت تأثیر قرار می‌دهد. وقتی لبهٔ تار ممکن است فراتر از مرزهای تصویر اصلی گسترش یابد، `grow` را به `True` تنظیم کنید.

برای شفافیت یکنواخت، از [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) استفاده کنید. این مقدار آلفای موجود را در همه پیکسل‌ها ضرب می‌کند، بنابراین پیکسل‌های نیمه‌شفاف به‌نسبت متفاوت باقی می‌مانند. [addAlphaReplaceEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) به‌جای آن یک مقدار آلفا را برای تمام پیکسل‌ها اختصاص می‌دهد. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) آلفا را بر پایهٔ یک آستانه به دو سطح تبدیل می‌کند.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

سایر عملیات آلفای بدون پارامتر شامل [addAlphaCeilingEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect) است که هر آلفای غیرصفر را کاملاً مات می‌کند؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect) که هر آلفا زیر 100٪ را کاملاً شفاف می‌کند؛ و [addAlphaInverseEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect) که آلفا را به `100% - alpha` تغییر می‌دهد.

## **ساخت زنجیرهٔ اثر مرتب**

هر متد `add...Effect` یک عملیات جدید را به انتهای مجموعه اضافه می‌کند. رندرر مجموعه را به‌عنوان یک خط تولید مرتب استفاده می‌کند: خروجی عملیات 0 ورودی عملیات 1 می‌شود و به همین ترتیب. بنابراین، همان عملیات‌ها در ترتیب متفاوت می‌توانند تصویر متفاوتی تولید کنند.

به عنوان مثال، خاکستری‌سازی سپس رنگ‌پاشی ابتدا اطلاعات کروماتیک را حذف می‌کند و سپس نتیجهٔ روشنایی را رنگ‌آمیزی می‌کند. رنگ‌پاشی سپس خاکستری‌سازی رنگ‌پاشی را دوباره حذف می‌کند. به همین ترتیب، جایگزینی آلفا می‌تواند مقادیر آلفای محاسبه‌شده توسط عملیات‌های پیشین را نادیده بگیرد، در حالی که مدولاسیون آلفا تفاوت‌های نسبی آن‌ها را حفظ می‌کند.

مثال زیر یک زنجیرهٔ چهار عملیاتی می‌سازد، آن را به‌صورت PPTX ذخیره می‌کند، ارائه را باز می‌کند، هر دو نوع عملیات و ترتیب آن‌ها را بررسی می‌کند و نتیجهٔ باز شده را رندر می‌کند:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

مجموعه محدودیتی برای ترکیب عملیات رنگ، آلفا و تار در زنجیره‌های جداگانه اعمال نمی‌کند. می‌توان آن‌ها را ترکیب کرد، اما ترکیب‌ها همیشه مفید نیستند. یک جایگزینی رنگ ثابت، تنوع RGB تولید شده توسط افکت‌های رنگی قبلی را حذف می‌کند؛ خاکستری‌سازی پس از دو‌رنگی دو رنگ انتخابی را از بین می‌برد؛ و عملیات‌های آلفا ceiling، floor، replacement یا bi‑level می‌توانند جزئیات آلفای ایجادشده در مراحل قبلی را نادیده بگیرند. زنجیره را بر مبنای توالی پردازش پیکسل موردنظر بسازید نه این‌که موارد را به‌عنوان پرچم‌های قالب‌بندی نامرتب در نظر بگیرید.

## **بازرسی مقادیر قابل ویرایش و مؤثر**

یک عملیات قابل ویرایش همان شیء ذخیره‌شده در `Picture.getImageTransform` است. بسته به افکت، ممکن است اعضای نوشتنی را مستقیماً نشان دهد. برای مثال، [Blur](https://reference.aspose.com/slides/fa/python-java/aspose.slides/blur/) مقادیر نوشتنی `radius` و `grow` را نشان می‌دهد، [AlphaModulateFixed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/alphamodulatefixed/) یک `amount` نوشتنی را افشا می‌کند، و [AlphaBiLevel](https://reference.aspose.com/slides/fa/python-java/aspose.slides/alphabilevel/) یک `threshold` نوشتنی دارد. افکت‌های رنگی مانند [Duotone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/duotone/) اشیای قابل تغییر [ColorFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/colorformat/) را نشان می‌دهند.

برخی کلاس‌های عملیات، از جمله [BrightnessContrast](https://reference.aspose.com/slides/fa/python-java/aspose.slides/brightnesscontrast/)، [HSL](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hsl/)، [Tint](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tint/)، و [AlphaReplace](https://reference.aspose.com/slides/fa/python-java/aspose.slides/alphareplace/)، مقادیر اسکالاری ساخت خود را به عنوان ویژگی‌های نوشتنی نشان نمی‌دهند. برای تغییر این تنظیمات، عملیات را حذف کنید و یک جایگزین در موقعیت موردنظر اضافه کنید.

داده‌های مؤثر برگردانده‌شده توسط `getEffective` محاسبه‌شده و فقط‑خواندنی هستند. این داده‌ها برای حل رنگ‌های وابسته به تم و خواندن مقادیر نرمال‌شده‌ای که رندرر استفاده می‌کند، مفید هستند، اما سطح ویرایشی دیگری نیستند. مثال زیر زنجیره را فهرست می‌کند و مقادیر مؤثری را که API مربوطه فراهم می‌کند، بازرسی می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

افکت‌های بدون پارامتر مانند خاکستری، آلفا ceiling و آلفا inverse همچنان یک شیء دادهٔ مؤثر دارند، اما مقدار اسکالاری برای چاپ ندارند. حضور و موقعیت آن‌ها در مجموعه، اطلاعات مهم هستند.

## **حذف یا پاک‌سازی تبدیل‌های تصویر**

از [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) برای حذف یک عملیات بر اساس شاخص استفاده کنید. چون شاخص‌ها پس از حذف جابجا می‌شوند، ابتدا هدف را جستجو کنید و سپس پس از فهرست‌گذاری آن را حذف کنید. برای حذف کل زنجیره از [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#clear) استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

حذف یا پاک‌سازی تبدیل‌ها فقط قالب‌بندی تصویر را تغییر می‌دهد. این کار منبع [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) بازاستفاده‌شده را حذف، دوباره فشرده یا به‌طور دیگری تغییر نمی‌دهد.

## **در نظر گرفتن فرمت‌های ارائه و مقاصد صادراتی**

تبدیل‌های تصویر از DrawingML نشأت می‌گیرند، بنابراین PPTX فرمت ویرایش‌پذیر ترجیحی برای زنجیره‌های اثر است. حتی در PPTX نیز همهٔ عملیات‌ها همان‌پرتابلیت ندارند:

- عملیات‌های استاندارد DrawingML مانند luminance، grayscale، duotone، tint، HSL، blur و عملیات‌های عمومی آلفا شانس بیشتری برای بقا پس از دور PPTX دارند. هنگامیکه حفظ اثر ضروری است، همیشه فایل تولیدشده را باز کنید و مجموعه را بازرسی کنید.
- [BrightnessContrast](https://reference.aspose.com/slides/fa/python-java/aspose.slides/brightnesscontrast/) یک افزونهٔ Office 2010 است نه عملیات استاندارد luminance DrawingML. می‌توان آن را برای رندر در حافظه استفاده کرد، اما تضمین نمی‌شود پس از ذخیره و باز کردن PPTX به‌صورت قابل ویرایش باقی بماند. برای تنظیمات ثابت روشنایی و کنتراست، از [addLuminanceEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) استفاده کنید.
- قالب باینری PPT پیش از مدل اثر کامل DrawingML وجود داشته است. ذخیره به‌صورت PPT می‌تواند عملیات‌های پشتیبانی‌نشده را حذف کند، زنجیره را به زیرمجموعهٔ پشتیبانی‌شده کاهش دهد یا ظاهر را تقریب بزند. PPT را برای تأیید زنجیرهٔ ویرایش‌پذیر پیچیده استفاده نکنید.
- رندر به PNG، JPEG، TIFF، PDF، SVG، HTML یا خروجی‌های تصویری دیگر، زنجیرهٔ پشتیبانی‌شده را روی ظاهر رندر شده اعمال می‌کند. این خروجی‌ها `ImageTransformOperationCollection` ویرایش‌پذیری را ندارند؛ فرمت‌های رستر نتیجه را به پیکسل‌ها مسطح می‌کنند و صادرات سند/وکتور نمایش رندر خود را ذخیره می‌کنند.
- افکت‌ها تصویر پیوندی را خودمحافظ نمی‌سازند. رندر یک تصویر پیوندی همچنان به در دسترس بودن منبع پیوندی هنگام بارگذاری ارائه وابسته است.

مصرف‌کنندگان مختلف ارائه ممکن است موارد لبه‌ای را به‌طور متفاوتی رندر کنند، به‌ویژه زمانی که چندین عملیات آلفا یا رنگی ترکیب می‌شوند. برای خروجی‌های حیاتی، هر دو دور ویرایش‌پذیر و فرمت صادرات نهایی را با همان نسخهٔ Aspose.Slides که در تولید استفاده می‌شود، تست کنید.

## **سوالات متداول**

**آیا افکت‌های تبدیل تصویر دادهٔ تصویر جاسازی‌شده را تغییر می‌دهند؟**

نه. این عملیات‌ها متعلق به `Picture` استفاده‌شده توسط پر کردن تصویر هستند. بایت‌های پایه‌ای `PPImage` دست‌نخورده می‌مانند.

**آیا دو قاب تصویری که از همان تصویر استفاده می‌کنند، افکت‌های یکسانی دارند؟**

نه. استفادهٔ مجدد از `PPImage` از تکرار دادهٔ تصویر جلوگیری می‌کند، اما هر قاب تصویر معمولاً یک `Picture` و مجموعهٔ تبدیل تصویر جداگانه دارد.

**آیا افکت‌های رنگ، تار و آلفا می‌توانند ترکیب شوند؟**

بله. مجموعه این افکت‌ها را در یک زنجیرهٔ مرتب می‌پذیرد. به این فکر کنید که هر عملیات چه تاثیری بر خروجی عملیات قبلی دارد، زیرا عملیات‌های جایگزینی و آستانه‌گذاری ممکن است جزئیات رنگ یا آلفای قبلی را حذف کنند.

**چرا مقادیر مؤثر فقط‑خواندنی هستند؟**

داده‌های مؤثر مقادیر محاسبه‌شده‌ای هستند که برای رندر استفاده می‌شوند، از جمله رنگ‌های حل‌شده. عملیات ذخیره‌شده در مجموعهٔ تبدیل را ویرایش کنید جایی که اعضای نوشتنی وجود دارد؛ در غیر این صورت آن را حذف کنید و یک جایگزین با پارامترهای ساخت جدید اضافه کنید.

**کدام فرمت را برای حفظ زنجیرهٔ تبدیل توصیه می‌شود؟**

از PPTX استفاده کنید و فایل را با باز کردن مجدد تأیید کنید. PPT قدیمی نمی‌تواند مدل کامل افکت DrawingML را نشان دهد و فرمت‌های خروجی رندر فقط ظاهر را حفظ می‌کنند نه عملیات تبدیل قابل ویرایش.