---
title: تبدیل ارائه‌های PowerPoint به TIFF در Python
linktitle: PowerPoint به TIFF
type: docs
weight: 90
url: /fa/python-java/convert-powerpoint-to-tiff/
keywords:
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به TIFF
- ارائه به TIFF
- اسلاید به TIFF
- PPT به TIFF
- PPTX به TIFF
- ذخیره PPT به صورت TIFF
- ذخیره PPTX به صورت TIFF
- صدور PPT به TIFF
- صدور PPTX به TIFF
- پایتون
- جاوا
- Aspose.Slides
description: "یاد بگیرید که چگونه به راحتی ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا تبدیل کنید با استفاده از Aspose.Slides برای Python از طریق Java، همراه با مثال‌های کد."
---
## **معرفی**

TIFF (**Tagged Image File Format**) یک فرمت تصویر رستر است که از چندین صفحه و فشرده‌سازی بدون فقدان پشتیبانی می‌کند. برای ذخیره اسلایدهای رندر شده در یک فایل تصویر مفید است.

با استفاده از Aspose.Slides برای Python از طریق Java، می‌توانید ارائه‌های PowerPoint (PPT، PPTX) و OpenDocument (ODP) را به TIFF تبدیل کنید. هر مثال زیر در صورت نیاز ماشین مجازی Java را اجرا می‌کند و پس از استفاده ارائه را آزاد می‌سازد. 

## **تبدیل یک ارائه به TIFF**

با استفاده از متد [save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/)، می‌توانید به سرعت یک ارائهٔ کامل PowerPoint را به TIFF تبدیل کنید. TIFF چندصفحهٔ حاصل حاوی تصویر رندر شدهٔ هر اسلاید با اندازهٔ پیش‌فرض است.

این کد نحوهٔ تبدیل یک ارائهٔ PowerPoint به TIFF را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # تمام اسلایدها را در یک فایل TIFF چندصفحه‌ای ذخیره کنید.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **تبدیل یک ارائه به TIFF سیاه‌سفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/#setBwConversionMode) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/) به شما امکان می‌دهد الگوریتم استفاده شده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه‌سفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/#setCompressionType) بر روی [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) یا [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffcompressiontypes/#CCITT3) قرار داده شود.

{{% alert color="info" title="توجه" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/#setBwConversionMode) یک تنظیم سطح صادراتی است که الگوریتم تبدیل پیکسل برای کل تصویر TIFF را انتخاب می‌کند. برای تعریف نحوهٔ نمایش یک شکل فردی هنگام فعال بودن حالت نمایش سیاه‌سفید، از [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#setBlackWhiteMode) استفاده کنید. برای مثال‌ها به [Control Black-and-White Rendering for Shapes](/slides/fa/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) مراجعه کنید.
{{% /alert %}}

فرض کنید فایلی به نام "sample.pptx" داریم که اسلاید زیر را دارد:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد نحوهٔ تبدیل اسلاید رنگی به TIFF سیاه‌سفید را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

نتیجه:

![TIFF سیاه‌سفید](TIFF_black_and_white.png)

## **تبدیل یک ارائه به TIFF با اندازهٔ سفارشی**

اگر به تصویری TIFF با ابعاد خاص نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/) تنظیم کنید. برای مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/#setImageSize) به شما امکان تعریف اندازهٔ تصویر حاصل را می‌دهد.

این کد نحوهٔ تبدیل یک ارائهٔ PowerPoint به تصاویر TIFF با اندازهٔ سفارشی را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # تنظیم وضوح افقی و عمودی.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # تنظیم ابعاد خروجی بر حسب پیکسل.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # درج کامل یادداشت‌های سخنران زیر هر اسلاید.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **تبدیل یک ارائه به TIFF با قالب پیکسل تصویر سفارشی**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/#setPixelFormat) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/)، می‌توانید قالب پیکسل مورد نظر خود را برای تصویر TIFF حاصل تعیین کنید.

این کد نحوهٔ تبدیل یک ارائهٔ PowerPoint به تصویر TIFF با قالب پیکسل سفارشی را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="نکته" color="success" %}}
به مبدل رایگان PowerPoint به پوستر Aspose مراجعه کنید: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم یک اسلاید تک به‌جای کل ارائهٔ PowerPoint به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای تک‌تک را از ارائه‌های PowerPoint و OpenDocument به‌صورت جداگانه به تصاویری TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

هیچ محدودیت ثابتی برای تعداد اسلایدها در صادرات به TIFF وجود ندارد. حافظه موجود، پیچیدگی اسلایدها و ابعاد خروجی بر حجم ارائه‌هایی که می‌توانید پردازش کنید تأثیر می‌گذارند.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین، انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط تصاویر ثابت از اسلایدها صادر می‌شوند.