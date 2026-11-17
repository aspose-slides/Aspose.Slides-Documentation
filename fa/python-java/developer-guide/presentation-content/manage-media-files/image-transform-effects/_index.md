---
title: مدیریت اثرهای تبدیل تصویر در ارائه‌ها با Python
linktitle: اثرهای تبدیل تصویر
type: docs
weight: 11
url: /fa/python-java/image-transform-effects/
keywords:
- تبدیل تصویر
- اثر تصویر
- روشنایی
- کنتراست
- خاکستری
- دو‑تونی
- تینت
- HSL
- جایگزینی رنگ
- تاری
- شفافیت
- اثر آلفا
- زنجیرهٔ اثر
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "اعمال، زنجیره‌بندی، بررسی، حذف و تأیید اثرهای تبدیل تصویر برای چارچوب‌های تصویری با Aspose.Slides برای Python از طریق Java."
---
## **نمای کلی**

Aspose.Slides تنظیمات تصویر را به‌عنوان مجموعه‌ای مرتب از عملیات تبدیل تصویر نمایش می‌دهد. برای یک چارچوب تصویر، با [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) چارچوب شروع کنید و به [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform) دسترسی پیدا کنید. [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/) بازگشتی به شما اجازه می‌دهد تا اثرات را اضافه، شمارش، بررسی، حذف و پاک‌سازی کنید بدون اینکه بایت‌های تصویر اصلی بازنویسی شوند.

این مقاله یک جریان کار کامل برای روشنایی و کنتراست، تبدیل‌های رنگ، تاری، شفافیت، زنجیره‌های اثر مرتب، مقادیر مؤثر، حذف و تأیید دورانی PPTX را نشان می‌دهد.

## **درک مالکیت اثر و بازاستفاده تصویر**

یک منبع تصویر و عکسی که آن را نمایش می‌دهد، اشیای متفاوتی هستند:

- [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) داده‌های تصویر منبع را که متعلق به ارائه است، ذخیره یا مرجع می‌کند.
- [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) به یک پرکن تصویر تعلق دارد و به یک منبع تصویر ارجاع می‌دهد در حالی که مجموعه تبدیل تصویر را نگه می‌دارد.
- [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) شکل اسلایدی است که پرکن تصویر مرتبط، هندسه، تنظیمات برش و سایر قالب‌بندی‌های سطح چارچوب را در اختیار دارد.

به همین دلیل، عملیات تبدیل تصویر بایت‌های [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) را تغییر نمی‌دهند. وقتی همان `PPImage` بیش از یک بار به [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) داده شود، هر چارچوب تصویر جدید یک `Picture` و مجموعه تبدیل مختص به خود دریافت می‌کند. اعمال خاکستری به یک چارچوب، دیگر چارچوب‌ها را خاکستری نمی‌کند، حتی اگر همه آن‌ها از همان منبع تصویر توکار استفاده کنند.

مدل `Picture.getImageTransform` مشابه توسط پرکن‌های تصویری دیگر، مانند یک شکل یا پس‌زمینه اسلاید، نیز استفاده می‌شود. مثال‌های زیر بر چارچوب‌های تصویر متمرکز شده‌اند.

## **استفاده از بازه‌ها و واحدهای معتبر پارامترها**

متدهای نمایش داده‌شده از بازه‌ها و واحدهای معنایی زیر استفاده می‌کنند. حتی اگر نسخهٔ خاصی از کتابخانه هر مقدار خارج از بازه را فوراً رد نکند، مقادیر را در این بازه‌ها نگه دارید؛ قالب هدف ارائه ممکن است در زمان ذخیره یا هنگام باز کردن فایل توسط PowerPoint عیار، حذف یا رد داده‌های نامعتبر را انجام دهد.

| عملیات | پارامترها | محدوده معتبر و واحد |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`، `contrast` | `-100` تا `100`، درصد؛ `0` مؤلفه را دست‌نخورده می‌گذارد. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | None | هیچ پارامتر عددی وجود ندارد. آلفا دست‌نخورده است. |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`، `color2` | دو رنگ برای پیکسل‌های تیره و روشن. مقادیر کانال‌های RGB و آلفا در `java.awt.Color` از `0` تا `255` استفاده می‌شود. |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`، `amount` | `hue` از `0` شامل تا `360` منفصل، بر حسب درجه؛ `amount` از `-100` تا `100`، درصد. |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`، `saturation`، `luminance` | `hue` از `0` شامل تا `360` منفصل، بر حسب درجه؛ `saturation` و `luminance` از `-100` تا `100`، درصد. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | رنگ جایگزین از `0` تا `255` برای هر کانال استفاده می‌کند. مقادیر آلفای موجود دست‌نخورده می‌مانند. |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`، `grow` | `radius` غیرمنفی است و برحسب پوینت اندازه‌گیری می‌شود؛ `grow` یک Boolean است که کنترل می‌کند آیا محتوی تاری می‌تواند خارج از مرزهای اصلی گسترش یابد. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | درصد غیرمنفی. برای مقیاس‌رسانی شفافیت معمولی از `0` تا `100` استفاده کنید: `0` کاملاً شفاف و `100` آلفای موجود را حفظ می‌کند. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` تا `100`، درصد شفافیت. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` تا `100`، درصد آلفا آستانه. مقادیر زیر این مقدار شفاف می‌شوند؛ مقادیر برابر یا بالاتر مات می‌شوند. |

برای مدولاسیون ثابت آلفا، شفافیت و مات بودن مکمل یکدیگر هستند. برای مثال، 35٪ شفافیت معادل مقدار مدولاسیون آلفا 65٪ است.

## **اعمال روشنایی و کنتراست**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) یک عملیات [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) باز می‌گرداند. تنظیمات اسکالاری آن هنگام ساخت عملیات فراهم می‌شود. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) مقادیر محاسبه‌شدهٔ فقط‑خواندنی را برمی‌گرداند که می‌توان آنها را بررسی یا ثبت کرد.

مثال زیر روشنایی را به‌مقدار 15٪ و کنتراست را به‌مقدار 20٪ افزایش می‌دهد، سپس پیش‌نمایشی را بدون تغییر تصویر توکار رندر می‌کند:

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

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) یک افزونهٔ اثر تصویری Office 2010 است و نسبت به اثر استاندارد DrawingML کمتری قابلیت حمل دارد. وقتی روشنایی و کنتراست باید پس از یک دورانی PPTX ویرایش‌پذیر بمانند، از [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) استفاده کنید و پس از باز کردن دوبارهٔ فایل، نتیجه را تأیید نمایید. بخش محدودیت‌های قالب این تمایز را با جزئیات بیشتری توضیح می‌دهد.

## **اعمال تبدیل‌های رنگی**

اثرات رنگی می‌توانند به‌صورت مستقل بر چارچوب‌های تصویری مختلف که یک منبع تصویر را بازاستفاده می‌کنند اعمال شوند. مثال زیر پنج چارچوب ایجاد می‌کند و به ترتیب سردست، دو‌تونی، تینت، تنظیم HSL و جایگزینی رنگ را اعمال می‌کند.

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) دو پارامتر رنگی به‌صورت مستقل و قابل ویرایش دارد: `color1` پیکسل‌های تیره را نگاشت می‌کند، در حالی که `color2` پیکسل‌های روشن را. این مثال مفیدی برای اثر است که تنظیماتش پیچیده‌تر از یک مقدار اسکالاری است.

```python
import jpype
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

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) هر پیکسل را با یک رنگ ثابت جایگزین می‌کند در حالی که آلفا را حفظ می‌کند. این متفاوت از [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect) است که یک رنگ منبع را به رنگ دیگری نگاشت می‌کند و هر دو قالب رنگ منبع و هدف را نشان می‌دهد.

### **اعمال آستانهٔ روشنایی**

یک آستانهٔ روشنایی می‌تواند نشانه‌های ضعیف روی صفحهٔ اسکن‌شده را برای تمایز از پس‌زمینه آسان‌تر کند. [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) سایه‌های میانی خاکستری را حفظ می‌کند. [addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) روشنایی را به سیاه یا سفید نگاشت می‌کند، در حالی که [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) آستانه‌ای را بر شفافیت اعمال می‌کند.

آستانهٔ روشنایی از 0٪ تا 100٪، شامل هر دو، متغیر است. پیکسل‌های زیر آستانه به‌صورت سیاه می‌شوند. پیکسل‌های برابر یا بالای آستانه سفید می‌شوند. افزایش آستانه باعث می‌شود سایه‌های بیشتری سیاه شوند چون بیشترشان زیر قطع‌نقطه قرار می‌گیرند.

فایل [grayscale-swatches.png](grayscale-swatches.png) را در پوشهٔ کاری دانلود کنید. هر برچسب سطح خاکستری اصلی را روی مقیاس 0 تا 255 نشان می‌دهد. مثال اصلی را در کنار دو کپی قرار می‌دهد و آستانهٔ هر کپی را در ارائه ذخیره می‌کند.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720.0, 150.0, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    image_data = Path("grayscale-swatches.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    frames = []
    for index, caption in enumerate(("Original", "Threshold 20%", "Threshold 60%")):
        x = 12 + 240 * index
        label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36)
        label.getTextFrame().setText(caption)
        frame = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image)
        frames.append(frame)

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20.0)
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60.0)

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ارائهٔ خروجی را در PowerPoint باز کنید تا سه چارچوب را مقایسه کنید. سواچ برچسب‌دار 96 تقریباً 38٪ روشنایی (96 از 255) دارد. در آستانهٔ 20٪ سفید می‌شود و در آستانهٔ 60٪ سیاه.

![نمونه‌های خاکستری اصلی در کنار نتایج سیاه‑سفید با آستانه‌های روشنایی 20٪ و 60٪](luminance-threshold.png)

## **افزودن تاری، شفافیت و اثرات آلفا**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) بر تمام کانال‌های رنگی، از جمله آلفا، تأثیر می‌گذارد. وقتی لبهٔ تار می‌تواند فراتر از مرزهای تصویر اصلی گسترش یابد، `grow` را به `True` تنظیم کنید.

برای شفافیت یکنواخت، از [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) استفاده کنید. این اثر تمام مقادیر آلفای موجود را ضرب می‌کند، بنابراین پیکسل‌های نیمه‌شفاف به نسبت متفاوت باقی می‌مانند. [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) به‌جای آن یک مقدار آلفا را به همهٔ پیکسل‌ها اختصاص می‌دهد. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) آلفا را بر پایهٔ یک آستانه به دو سطح تبدیل می‌کند.

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

دیگر عملیات‌های آلفا بدون پارامتر شامل [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect) است که هر آلفای غیرصفر را کاملاً مات می‌کند؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect) که هر آلفایی زیر 100٪ را کاملاً شفاف می‌کند؛ و [addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect) که آلفا را به `100% - alpha` تغییر می‌دهد.

## **ساخت زنجیرهٔ اثر مرتب**

هر متد `add...Effect` یک عملیات جدید را به انتهای مجموعه اضافه می‌کند. رندرکننده مجموعه را به‌عنوان یک خط لولهٔ مرتب استفاده می‌کند: خروجی عملیات 0 ورودی عملیات 1 می‌شود و به همین ترتیب. بنابراین، همان عملیات‌ها به ترتیب متفاوت می‌توانند تصویر متفاوتی تولید کنند.

به‌عنوان مثال، خاکستری کردن سپس تینت ابتدا اطلاعات رنگی را پاک می‌کند و سپس روشنایی نتیجه را دوباره رنگ می‌دهد. تینت سپس خاکستری کردن دوباره تینت را حذف می‌کند. به‌طور مشابه، جایگزینی آلفا می‌تواند مقادیر آلفای محاسبه‌شده توسط عملیات‌های قبلی را نادیده بگیرد، در حالی که مدولاسیون آلفا تفاوت‌های نسبی آن‌ها را حفظ می‌کند.

مثال زیر یک زنجیرهٔ چهارعملیاتی می‌سازد، آن را به‌صورت PPTX ذخیره می‌کند، ارائه را دوباره باز می‌کند، هر دو نوع عملیات و ترتیب آن‌ها را بررسی می‌کند و نتیجهٔ بازگشایی‌شده را رندر می‌نماید:

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

مجموعه محدودیتی در مورد ماتریس سازگاری که اثرات رنگ، آلفا و تاری را به زنجیره‌های جداگانه محدود کند، اعمال نمی‌کند. می‌توان آن‌ها را ترکیب کرد، اما ترکیب‌ها همیشه مفید نیستند. یک جایگزینی رنگ ثابت، تنوع RGB تولیدشده توسط اثرات رنگی قبلی را حذف می‌کند؛ خاکستری پس از دو‌تونی، دو رنگ انتخاب‌شده را حذف می‌کند؛ و عملیات آلفا سِقف، کف، جایگزینی یا دو‌سطحی می‌توانند جزئیات آلفایی که پیش‌تر ایجاد شده‌اند را از بین ببرند. زنجیره را براساس توالی پردازش پیکسلی موردنظر بسازید نه اینکه آیتم‌های آن را به‌عنوان پرچم‌های قالب‌بندی نامرتب در نظر بگیرید.

<!-- visual-explanation:image-transform-effects:start -->
[![همین تصویر ابتدا از طریق خاکستری سپس تینت و سپس تینت سپس خاکستری می‌گذرد. دو تصویر نهایی خاکستری رنگ‌های متفاوتی دارند.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*در این نمای شبیه‌سازی‌شده از Aspose.Slides برای .NET 26.11، تینت 220° با 25% تصویر خاکستری را دست‌نخورده می‌گذارد. اعمال همان تینت قبل از خاکستری شدن رنگ‌های متفاوتی ایجاد می‌کند.*
<!-- visual-explanation:image-transform-effects:end -->

## **بررسی مقادیر قابل ویرایش و مؤثر**

یک عملیات قابل ویرایش همان شیء ذخیره‌شده در `Picture.getImageTransform` است. بسته به اثر، ممکن است اعضای قابل نوشتن را مستقیماً گشود. برای مثال، [Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) مقادیر `radius` و `grow` قابل نوشتن را در اختیار می‌گذارد، [AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) `amount` قابل نوشتن دارد و [AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) `threshold` قابل نوشتن را افشا می‌کند. اثرات رنگی مانند [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) شیءهای [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/) قابل تغییر را نشان می‌دهند.

برخی کلاس‌های عملیات، از جمله [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/)، [HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/)، [Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/) و [AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/)، اسکالارهای ساخت خود را به‌عنوان ویژگی‌های قابل نوشتن نشان نمی‌دهند. برای تغییر این تنظیمات، عملیات را حذف کنید و جایگزین موردنیاز را در موقعیت دلخواه اضافه کنید.

دادهٔ مؤثر بازگردانده‌شده توسط `getEffective` محاسبه‌شده و فقط‑خواندنی است. برای حل رنگ‌های وابسته به تم و خواندن مقادیر نُرم‌سازی‌شده‌ای که رندرکننده استفاده می‌کند مفید است، اما سطح ویرایش دیگری نیست. مثال زیر زنجیره را شمارش می‌کند و مقادیر مؤثر را جایی که API متناظر آن‌ها را فراهم می‌کند، بررسی می‌نماید:

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

اثرات بدون پارامتر مانند خاکستری، آلفا سِقف و آلفا معکوس همچنان یک شیء دادهٔ مؤثر دارند، اما تنظیمات اسکالاری برای چاپ ندارند. حضور و موقعیت آن‌ها در مجموعه اطلاعات مهم هستند.

## **حذف یا پاک‌سازی تبدیل‌های تصویر**

از [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) برای حذف یک عملیات بر اساس اندیس استفاده کنید. چون اندیس‌ها پس از حذف جابه‌جا می‌شوند، ابتدا هدف را جستجو کنید و پس از شمارش حذف کنید. از [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear) برای حذف کل زنجیره استفاده کنید.

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

حذف یا پاک‌سازی تبدیل‌ها فقط قالب‌بندی تصویر را تغییر می‌دهد. منبع تصویر توکار [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) را حذف، فشرده‌سازی یا به‌صورت دیگری تغییر نمی‌دهد.

## **در نظر گرفتن فرمت‌های ارائه و اهداف خروجی**

تبدیل‌های تصویر از DrawingML نشأت می‌گیرند، بنابراین PPTX قالب ویرایش‌پذیر ترجیحی برای زنجیره‌های اثر است. حتی در PPTX هم هر عملیات قابلیت قابل حمل یکسانی ندارد:

- عملیات‌های استاندارد DrawingML مانند luminance، grayscale، duotone، tint، HSL، blur و عملیات‌های معمول آلفا بیشترین شانس بقا پس از یک دورانی PPTX را دارند. همیشه فایل تولیدشده را دوباره باز کنید و مجموعه را هنگام نیاز به حفظ بررسی نمایید.
- [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) یک افزونهٔ Office 2010 است نه عملیات استاندارد luminance DrawingML. می‌توان از آن برای رندر در حافظه استفاده کرد، اما پس از ذخیره و بازگشایی PPTX تضمین نیست که به‌عنوان یک [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) ویرایش‌پذیر باقی بماند. برای تنظیمات ثابت روشنایی و کنتراست، از [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) استفاده کنید.
- قالب باینری PPT پیش از مدل کامل اثر DrawingML وجود داشته است. ذخیره در PPT می‌تواند عملیات‌های پشتیبانی‌نشده را حذف کند، زنجیره را به زیرمجموعه‌ای پشتیبانی‌شده کاهش دهد یا ظاهر را تقریب بزند. برای یک زنجیرهٔ ویرایش‌پذیر پیچیده، از PPT به‌عنوان قالب تأیید استفاده نکنید.
- رندر به PNG، JPEG، TIFF، PDF، SVG، HTML یا سایر خروجی‌های بصری، زنجیرهٔ پشتیبانی‌شده را بر روی ظاهر رندر شده اعمال می‌کند. این خروجی‌ها شامل یک `ImageTransformOperationCollection` ویرایش‌پذیر نیستند؛ فرمت‌های رستر نتیجه را به پیکسل‌ها مسطح می‌کنند و صادرات سند/وکتور نمای رندر خودشان را ذخیره می‌کنند.
- اثرها تصویر پیوندی را خودکفا نمی‌سازند. رندر یک تصویر پیوندی همچنان به در دسترس بودن منبع پیوندی هنگام بارگذاری ارائه وابسته است.

مصرف‌کنندگان مختلف ارائه ممکن است موارد لبه را به‌صورت متفاوتی رندر کنند، به‌ویژه وقتی چندین عملیات آلفا یا رنگ‑کوانتایزینگ ترکیب می‌شوند. برای خروجی بحرانی، هر دو دورانی ویرایش‌پذیر و قالب نهایی صادراتی را با همان نسخهٔ Aspose.Slides که در تولید استفاده می‌شود، تست کنید.

## **سؤالات متداول**

**آیا اثرهای تبدیل تصویر داده‌های تصویر توکار را تغییر می‌دهند؟**

نه. این عملیات به `Picture` استفاده‌شده توسط پرکن تصویر تعلق دارند. بایت‌های زیرین `PPImage` دست‌نخورده می‌مانند.

**آیا دو چارچوب تصویر که یک تصویر را بازاستفاده می‌کنند اثرهای خود را به‌اشتراک می‌گذارند؟**

نه. بازاستفاده از `PPImage` از تکرار داده‌های تصویر جلوگیری می‌کند، اما هر چارچوب تصویر معمولاً `Picture` و مجموعه تبدیل تصویر جداگانه‌ای دارد.

**آیا می‌توان اثرهای رنگ، تاری و آلفا را ترکیب کرد؟**

بله. مجموعه آن‌ها را در یک زنجیرهٔ مرتب می‌پذیرد. به این فکر کنید که هر عملیات چه تأثیری بر خروجی عملیات قبلی دارد، زیرا عملیات‌های جایگزینی و آستانه ممکن است جزئیات رنگ یا آلفای قبلی را حذف کنند.

**چرا مقادیر مؤثر فقط‑خواندنی هستند؟**

دادهٔ مؤثر مقادیر محاسبه‌شده‌ای را نشان می‌دهد که برای رندر استفاده می‌شود، شامل رنگ‌های حل‌شده. عملیات ذخیره‌شده در مجموعه تبدیل را جایی ویرایش کنید که اعضای قابل نوشتن دارد؛ در غیر این صورت آن را حذف کنید و با پارامترهای ساخت جدید جایگزین نمایید.

**برای حفظ یک زنجیرهٔ تبدیل کدام قالب مناسب است؟**

از PPTX استفاده کنید و پس از ذخیره، فایل را دوباره باز کنید تا تأیید شود. PPT قدیمی نمی‌تواند مدل کامل اثر DrawingML را نشان دهد و فرمت‌های خروجی رندر فقط ظاهر را حفظ می‌کنند نه عملیات تبدیل ویرایش‌پذیر.