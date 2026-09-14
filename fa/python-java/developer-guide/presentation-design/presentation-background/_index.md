---
title: مدیریت پس‌زمینه‌های ارائه در پایتون از طریق جاوا
linktitle: پس‌زمینه اسلاید
type: docs
weight: 20
url: /fa/python-java/presentation-background/
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
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه پس‌زمینه‌های پویا را در فایل‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق جاوا تنظیم کنید، همراه با نکات کد برای بهبود ارائه‌های شما."
---
## **مقدمه**

رنگ‌های ثابت، گرادیان‌ها و تصاویر معمولاً برای پس‌زمینهٔ اسلایدها استفاده می‌شوند. می‌توانید پس‌زمینه را برای یک **اسلاید معمولی** (یک اسلاید تک) یا یک **اسلاید مستر** (که بر روی چندین اسلاید به‌صورت همزمان اعمال می‌شود) تنظیم کنید.

![پس‌زمینه PowerPoint](powerpoint-background.png)

## **تنظیم پس‌زمینهٔ رنگ ثابت برای اسلاید معمولی**

Aspose.Slides به شما امکان می‌دهد یک رنگ ثابت را به‌عنوان پس‌زمینهٔ یک اسلاید خاص در یک ارائه تنظیم کنید — حتی اگر ارائه از اسلاید مستر استفاده کند. این تغییر فقط بر روی اسلاید انتخاب‌شده اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. ویژگی [BackgroundType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filltype/) پس‌زمینه اسلاید را به `Solid` تنظیم کنید.
4. از متد [getSolidFillColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/#getsolidfillcolor) در [FillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/) برای مشخص کردن رنگ پس‌زمینهٔ ثابت استفاده کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر به زبان پایتون نشان می‌دهد چگونه یک رنگ آبی ثابت را به‌عنوان پس‌زمینهٔ اسلاید معمولی تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# یک نمونه از کلاس Presentation ایجاد کنید.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # رنگ پس‌زمینه اسلاید را به آبی تنظیم کنید.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # ارائه را روی دیسک ذخیره کنید.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم پس‌زمینهٔ رنگ ثابت برای اسلاید مستر**

Aspose.Slides به شما امکان می‌دهد یک رنگ ثابت را به‌عنوان پس‌زمینهٔ اسلاید مستر در یک ارائه تنظیم کنید. اسلاید مستر به‌عنوان الگو عمل می‌کند و قالب‌بندی تمام اسلایدها را کنترل می‌کند، بنابراین وقتی یک رنگ ثابت برای پس‌زمینهٔ اسلاید مستر انتخاب می‌کنید، این رنگ بر تمام اسلایدها اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. ویژگی [BackgroundType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/backgroundtype/) (از طریق متد [getMasters](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getmasters)) اسلاید مستر را به `OwnBackground` تنظیم کنید.
3. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filltype/) پس‌زمینه اسلاید مستر را به `Solid` تنظیم کنید.
4. از متد [getSolidFillColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/#getsolidfillcolor) برای مشخص کردن رنگ پس‌زمینهٔ ثابت استفاده کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر به زبان پایتون نشان می‌دهد چگونه یک رنگ ثابت (سبز) را به‌عنوان پس‌زمینهٔ اسلاید مستر تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# یک نمونه از کلاس Presentation ایجاد کنید.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # رنگ پس‌زمینه اسلاید مستر را به سبز تنظیم کنید.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # ارائه را روی دیسک ذخیره کنید.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم پس‌زمینهٔ گرادیان برای اسلاید**

گرادیان یک اثر گرافیکی است که با تغییر تدریجی رنگ ایجاد می‌شود. هنگام استفاده به‌عنوان پس‌زمینهٔ اسلاید، گرادیان‌ها می‌توانند ظاهر ارائه را هنری‌تر و حرفه‌ای‌تر کنند. Aspose.Slides به شما امکان می‌دهد یک رنگ گرادیان را به‌عنوان پس‌زمینهٔ اسلایدها تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. ویژگی [BackgroundType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filltype/) پس‌زمینه اسلاید را به `Gradient` تنظیم کنید.
4. از متد [getGradientFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/#getgradientformat) در [FillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/) برای پیکربندی تنظیمات دلخواه گرادیان استفاده کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر به زبان پایتون نشان می‌دهد چگونه یک رنگ گرادیان را به‌عنوان پس‌زمینهٔ اسلاید تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# یک نمونه از کلاس Presentation ایجاد کنید.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # یک افکت گرادیان را به پس‌زمینه اعمال کنید.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # رنگ‌های گرادیان را اضافه کنید. بدون نقاط توقف گرادیان، پس‌زمینه به یک رنگ‌پاله پیش‌فرض سیاه‑به‑سفید باز می‌گردد.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # ارائه را روی دیسک ذخیره کنید.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تنظیم تصویر به‌عنوان پس‌زمینهٔ اسلاید**

علاوه بر پرکردن‌های ثابت و گرادیان، Aspose.Slides به شما اجازه می‌دهد از تصاویر به‌عنوان پس‌زمینهٔ اسلایدها استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. ویژگی [BackgroundType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. ویژگی [FillType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filltype/) پس‌زمینه اسلاید را به `Picture` تنظیم کنید.
4. تصویری که می‌خواهید به‌عنوان پس‌زمینهٔ اسلاید استفاده کنید را بارگذاری کنید.
5. تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.
6. از متد [getPictureFillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/#getpicturefillformat) در [FillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/) برای اختصاص تصویر به‌عنوان پس‌زمینه استفاده کنید.
7. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر به زبان پایتون نشان می‌دهد چگونه یک تصویر را به‌عنوان پس‌زمینهٔ اسلاید تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# یک نمونه از کلاس Presentation ایجاد کنید.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # ویژگی‌های تصویر پس‌زمینه را تنظیم کنید.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # تصویر را بارگذاری کنید.
    image = Images.fromFile("Tulips.jpg")
    # تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # ارائه را روی دیسک ذخیره کنید.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نمونهٔ کد زیر نشان می‌دهد چگونه نوع پرشدگی پس‌زمینه را به یک تصویر کاشی‌شده تنظیم کنید و ویژگی‌های کاشی‌بندی را تغییر دهید:

```python
import jpway
import asposeslides

if not jpway.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # تنظیم تصویر مورد استفاده برای پر شدن پس‌زمینه.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # تنظیم حالت پر شدن تصویر به Tile و تنظیم ویژگی‌های کاشی.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
بیشتر بخوانید: [Tile Picture as Texture](/slides/fa/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغییر شفافیت تصویر پس‌زمینه**

ممکن است بخواهید شفافیت تصویر پس‌زمینهٔ اسلاید را تنظیم کنید تا محتوای اسلاید بیشتر به چشم بیاید. کد پایتون زیر نشان می‌دهد چگونه شفافیت تصویر پس‌زمینهٔ اسلاید را تغییر دهید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # برای مثال.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # دریافت مجموعهٔ عملیات تبدیل تصویر.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # پیدا کردن یک اثر شفافیت ثابت‑درصد موجود.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # تنظیم مقدار شفافیت جدید.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دریافت مقدار پس‌زمینهٔ اسلاید**

Aspose.Slides به شما اجازه می‌دهد مقادیر موثر پس‌زمینهٔ یک اسلاید را با استفاده از متد [getEffective](https://reference.aspose.com/slides/fa/python-java/aspose.slides/background/#geteffective) در [Background](https://reference.aspose.com/slides/fa/python-java/aspose.slides/background/) دریافت کنید. داده‌های بازگشتی شامل فرمت پرشدگی و اثرات موثر هستند.

با استفاده از متد [getBackground](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getbackground) در کلاس [BaseSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/) می‌توانید پس‌زمینهٔ یک اسلاید را دریافت کنید.

مثال زیر به زبان پایتون نشان می‌دهد چگونه مقدار پس‌زمینهٔ موثر یک اسلاید را دریافت کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# یک نمونه از کلاس Presentation ایجاد کنید.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # پس‌زمینهٔ موثر را دریافت کنید، با در نظر گرفتن مستر، لِی‌اوت و تم.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا می‌توانم پس‌زمینهٔ سفارشی را بازنشانی کنم و پس‌زمینهٔ قالب/چیدمان را بازیابی کنم؟**

بله. پرکردن سفارشی اسلاید را حذف کنید؛ پس‌زمینه دوباره از اسلاید [layout](/slides/fa/python-java/slide-layout/)/[master](/slides/fa/python-java/slide-master/) مربوطه (یعنی [theme background](/slides/fa/python-java/presentation-theme/)) ارث‌بری می‌شود.

**اگر بعداً قالب ارائه را تغییر دهم، چه اتفاقی برای پس‌زمینه می‌افتد؟**

اگر یک اسلاید پرشدگی اختصاصی داشته باشد، بدون تغییر باقی می‌ماند. اگر پس‌زمینه از [layout](/slides/fa/python-java/slide-layout/)/[master](/slides/fa/python-java/slide-master/) ارث‌بری شده باشد، با قالب جدید به‌روزرسانی می‌شود.