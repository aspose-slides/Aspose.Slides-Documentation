---
title: ایجاد تصویرهای بندانگشتی از اشکال ارائه در Python via Java
linktitle: بندانگشتی‌های شکل
type: docs
weight: 70
url: /fa/python-java/create-shape-thumbnails/
keywords:
- بندانگشتی شکل
- تصویر شکل
- رندر شکل
- رندرینگ شکل
- حاشیه‌های بصری
- حاشیه‌های شکل
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "تولید تصویرهای بندانگشتی با کیفیت بالا از اشکال اسلایدهای PowerPoint با Aspose.Slides برای Python via Java – به‌راحتی تصویرهای بندانگشتی ارائه ایجاد و صادر کنید."
---
## **معرفی**

Aspose.Slides for Python via Java می‌تواند برای ایجاد فایل‌های ارائه استفاده شود که در آن هر صفحه معادل یک اسلاید است. اسلایدها می‌توانند با باز کردن فایل‌های ارائه در Microsoft PowerPoint مشاهده شوند. اما گاهی توسعه‌دهندگان نیاز دارند تصاویر اشکال را به صورت جداگانه در یک مشاهده‌گر تصویر ببینند. در چنین مواردی Aspose.Slides for Python via Java به آن‌ها کمک می‌کند تا تصاویر بندانگشتی اشکال اسلاید را تولید کنند.

این مقاله توضیح می‌دهد که چگونه می‌توان بندانگشتی‌های اشکل را به روش‌های مختلف تولید کرد:

- تولید یک بندانگشتی شکل در داخل یک اسلاید.
- تولید یک بندانگشتی شکل برای یک اسلاید با ابعاد تعریف‌شده توسط کاربر.
- تولید یک بندانگشتی شکل در محدودیت‌های ظاهر شکل.

## **تولید تصویر بندانگشتی شکل از یک اسلاید**
برای تولید تصویر بندانگشتی شکل از هر اسلاید با استفاده از Aspose.Slides for Python via Java، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی با استفاده از شناسه یا ایندکس آن به دست آورید.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) برای یک شکل در اسلاید مرجع با مقیاس پیش‌فرض دریافت کنید.
1. تصویر بندانگشتی را در قالب تصویری دلخواه خود ذخیره کنید.

این کد نمونه نشان می‌دهد که چگونه تصویر بندانگشتی شکل را از یک اسلاید تولید کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# یک نمونه از کلاس Presentation که فایل ارائه را نشان می‌دهد ایجاد کنید.
presentation = Presentation("Thumbnail.pptx")
try:
    # یک تصویر با مقیاس کامل ایجاد کنید.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # تصویر را در قالب PNG روی دیسک ذخیره کنید.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **تولید تصویر بندانگشتی با عامل مقیاس‌گذاری تعریف‌شده توسط کاربر**
برای تولید تصویر بندانگشتی شکل یک اسلاید با استفاده از Aspose.Slides for Python via Java، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی با استفاده از شناسه یا ایندکس آن به دست آورید.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) برای یک شکل در اسلاید مرجع با ابعاد تعریف‌شده توسط کاربر دریافت کنید.
1. تصویر بندانگشتی را در قالب تصویری دلخواه خود ذخیره کنید.

این کد نمونه نشان می‌دهد که چگونه تصویر بندانگشتی شکل را بر اساس یک عامل مقیاس‌گذاری تعریف‌شده تولید کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# یک نمونه از کلاس Presentation که فایل ارائه را نشان می‌دهد ایجاد کنید.
presentation = Presentation("Thumbnail.pptx")
try:
    # یک تصویر با مقیاس ۲ در هر دو جهت ایجاد کنید.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # تصویر را در قالب PNG روی دیسک ذخیره کنید.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **ایجاد تصویر بندانگشتی ظاهر شکل بر مبنای حاشیه‌ها**
این روش ایجاد بندانگشتی برای اشکال به توسعه‌دهندگان اجازه می‌دهد تا تصویر بندانگشتی را در محدودیت‌های ظاهر شکل تولید کنند. تمام افکت‌های شکل در نظر گرفته می‌شود. تصویر بندانگشتی تولید شده توسط حاشیه‌های اسلاید محدود می‌شود. برای تولید تصویر بندانگشتی یک شکل اسلاید داخل محدوده ظاهر آن، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی با استفاده از شناسه یا ایندکس آن به دست آورید.
1. تصویر بندانگشتی یک شکل در اسلاید مرجع را با استفاده از حدود ظاهر آن دریافت کنید.
1. تصویر بندانگشتی را در قالب تصویری دلخواه خود ذخیره کنید.

این کد نمونه بر اساس مراحل بالا است:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# یک نمونه از کلاس Presentation که فایل ارائه را نمایندگی می‌کند ایجاد کنید.
presentation = Presentation("Thumbnail.pptx")
try:
    # یک تصویر با مقیاس کامل ایجاد کنید.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # تصویر را در قالب PNG روی دیسک ذخیره کنید.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **دریافت حاشیه‌های بصری واقعی یک شکل**

ویژگی‌های چارچوب [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) — متدهای [getX](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getX)، [getY](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getY)، [getWidth](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getWidth) و [getHeight](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getHeight) — مستطیل ذخیره‌شده در مدل ارائه را توصیف می‌کنند. محتوای واقعی که رندر می‌شود می‌تواند فراتر از آن چارچوب باشد یا مستطیل محورها متفاوتی را اشغال کند. چرخش، خطوط حاشیه، سرپیکان‌ها، چیدمان متن و سرریز، هندسه SmartArt تولیدشده و سایر افکت‌های رندر می‌توانند ناحیه اشغال‌شده را تغییر دهند.

از [Shape.getVisualBounds](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getVisualBounds) برای محاسبهٔ این ناحیه بدون ایجاد تصویر استفاده کنید. این متد یک شیء [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) در مختصات اسلاید باز می‌گرداند. مستطیل بازگردانده‌شده به اسلاید برش داده نمی‌شود، بنابراین مختصات آن می‌تواند منفی باشد وقتی محتوا فراتر از نقطهٔ آغاز اسلاید گسترش یابد.

مثال زیر حاشیهٔ چارچوب و حاشیهٔ بصری را دریافت و مقایسه می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

همان [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) می‌تواند برای ترازبندی اشکال نزدیک به لبهٔ چپ، راست، بالا یا پایین آن استفاده شود؛ فضای کافی در یک چیدمان تولیدشده رزرو شود؛ یا محتوای خارج از منطقهٔ مجاز شناسایی شود. حاشیه‌های بصری به‌خصوص برای SmartArt، جعبه‌های متن، پیکان‌ها، تصاویر، اشکال چرخیده و گروه‌های شکل که چارچوب ذخیره‌شده ممکن است نمای رندر شدهٔ کامل را نشان ندهد، مفید هستند.

از [Shape.getVisualBounds](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getVisualBounds) زمانی که به مختصات برای چیدمان یا اعتبارسنجی نیاز دارید و نیازی به بیت‌مپ ندارید، استفاده کنید. از [Shape.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) زمانی که نیاز به رندر شکل دارید، استفاده کنید. با [ShapeThumbnailBounds](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapethumbnailbounds/)، [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapethumbnailbounds/#Shape) اندازهٔ تصویر را از حاشیهٔ شکل، شامل تنظیمات حاشیه، تعیین می‌کند، در حالی که [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapethumbnailbounds/#Appearance) آن را از ظاهر شکل اندازه‌گیری می‌کند و نتیجه را به حاشیه‌های اسلاید محدود می‌سازد. بر خلاف آن، [Shape.getVisualBounds](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getVisualBounds) فقط مستطیل محاسبه‌شده را برمی‌گرداند و آن را به اسلاید برش نمی‌دهد.

## **پرسش‌های متداول**

**کدام قالب‌های تصویری می‌توانند هنگام ذخیرهٔ بندانگشتی اشکال استفاده شوند؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imageformat/)، و دیگران. اشکال همچنین می‌توانند به‌عنوان SVG برداری [exported as vector SVG](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#writeAsSvgToBytes) با ذخیرهٔ محتوای شکل به‌صورت SVG صادر شوند.

**فرق بین حاشیهٔ Shape و Appearance هنگام رندر یک بندانگشتی چیست؟**

`Shape` از هندسهٔ شکل استفاده می‌کند؛ `Appearance` اثرات بصری را (سایه‌ها، درخشش و غیره) در نظر می‌گیرد.

**اگر یک شکل به‌عنوان hidden علامت‌گذاری شود چه می‌شود؟ آیا همچنان به‌صورت بندانگشتی رندر می‌شود؟**

یک شکل مخفی همچنان بخشی از مدل است و می‌تواند رندر شود؛ پرچم مخفی فقط نمایش اسلایدشو را تحت تأثیر قرار می‌دهد اما از تولید تصویر شکل جلوگیری نمی‌کند.

**آیا اشکال گروهی، نمودارها، SmartArt و سایر اشیای پیچیده پشتیبانی می‌شوند؟**

بله. هر شیئی که به عنوان [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) نمایش داده می‌شود (از جمله [GroupShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/)، و [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/)) می‌تواند به‌صورت بندانگشتی یا SVG ذخیره شود.

**آیا قلم‌های نصب‌شده در سیستم بر کیفیت بندانگشتی‌های اشکال متنی تأثیر می‌گذارند؟**

بله. برای جلوگیری از استفادهٔ ناخواسته از جایگزین‌ها و بازپیکربندی متن باید [فونت‌های مورد نیاز را فراهم کنید](/slides/fa/python-java/custom-font/) (یا [جایگزینی فونت‌ها را پیکربندی کنید](/slides/fa/python-java/font-substitution/)).