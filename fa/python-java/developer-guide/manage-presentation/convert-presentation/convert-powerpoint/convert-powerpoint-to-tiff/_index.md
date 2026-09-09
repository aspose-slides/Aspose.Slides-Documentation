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
- ذخیره PPT به عنوان TIFF
- ذخیره PPTX به عنوان TIFF
- صادرات PPT به TIFF
- صادرات PPTX به TIFF
- Python
- Java
- Aspose.Slides
description: "چگونگی تبدیل آسان ارائه‌های PowerPoint (PPT, PPTX) به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای Python از طریق Java، همراه با مثال‌های کد را بیاموزید."
---
## **مقدمه**

TIFF (**Tagged Image File Format**) یک فرمت تصویر رستر است که از صفحات چندگانه و فشرده‌سازی بدون افت کیفیت پشتیبانی می‌کند. این فرمت برای ذخیره‌سازی اسلایدهای رندر شده در یک فایل تصویر مفید است.

با استفاده از Aspose.Slides برای Python از طریق Java، می‌توانید ارائه‌های PowerPoint (PPT, PPTX) و OpenDocument (ODP) را به TIFF تبدیل کنید. هر مثال زیر در صورت نیاز ماشین مجازی Java را راه‌اندازی می‌کند و پس از استفاده ارائه را آزاد می‌سازد.

## **تبدیل ارائه به TIFF**

با استفاده از متد [save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) می‌توانید به سرعت یک ارائه کامل PowerPoint را به TIFF تبدیل کنید. TIFF چندصفحه‌ای حاصل شامل تصویر رندر شده هر اسلاید با اندازه پیش‌فرض است.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به TIFF تبدیل کنیم:

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

## **تبدیل ارائه به TIFF سیاه‑سفید**

متد [setBwConversionMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/#setBwConversionMode) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه‑سفید را مشخص کنید. توجه داشته باشید این تنظیم فقط زمانی اعمال می‌شود که متد [setCompressionType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/#setCompressionType) بر روی [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) یا [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffcompressiontypes/#CCITT3) تنظیم شده باشد.

{{% alert color="info" title="توجه" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/#setBwConversionMode) یک تنظیم سطح خروجی است که الگوریتم تبدیل پیکسل برای کل تصویر TIFF را انتخاب می‌کند. برای تعریف نحوه نمایش یک شکل خاص هنگام فعال بودن حالت نمایش سیاه‑سفید، از [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#setBlackWhiteMode) استفاده کنید. برای مثال‌ها به [Control Black-and-White Rendering for Shapes](/slides/fa/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) مراجعه کنید.
{{% /alert %}}

فرض کنید فایلی به نام "sample.pptx" داشته باشیم که شامل اسلاید زیر باشد:

![A presentation slide](slide_black_and_white.png)

این کد نشان می‌دهد چگونه اسلاید رنگی را به TIFF سیاه‑سفید تبدیل کنیم:

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

![Black-and-White TIFF](TIFF_black_and_white.png)

## **تبدیل ارائه به TIFF با اندازه دلخواه**

اگر به تصویری TIFF با ابعاد خاص نیاز دارید، می‌توانید مقادیر دلخواه را با استفاده از متدهای موجود در [TiffOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/) تنظیم کنید. به‌عنوان مثال، متد [setImageSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/#setImageSize) به شما امکان می‌دهد اندازه تصویر خروجی را تعریف کنید.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه دلخواه تبدیل کنیم:

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

    # رزولوشن افقی و عمودی را تنظیم کنید.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # ابعاد خروجی را بر حسب پیکسل تنظیم کنید.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # یادداشت‌های سخنران کامل را زیر هر اسلاید درج کنید.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **تبدیل ارائه به TIFF با قالب پیکسل تصویر دلخواه**

با استفاده از متد [setPixelFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/#setPixelFormat) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/) می‌توانید قالب پیکسل دلخواه خود را برای تصویر TIFF خروجی تعیین کنید.

این کد نشان می‌دهد چگونه یک ارائه PowerPoint را به تصویر TIFF با قالب پیکسل دلخواه تبدیل کنیم:

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
به ابزار [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) رایگان Aspose نگاهی بیندازید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم به جای تبدیل کل ارائه PowerPoint، فقط یک اسلاید را به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای منفرد از ارائه‌های PowerPoint و OpenDocument را به صورت جداگانه به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

هیچ محدودیت ثابت‌تری برای تعداد اسلایدها در صادرات TIFF وجود ندارد. حافظه موجود، پیچیدگی اسلایدها و ابعاد خروجی بر اندازه ارائه‌هایی که می‌توانید پردازش کنید، تأثیر می‌گذارد.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمّت تصویر ثابت است. بنابراین، انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط تصاویر ثابت اسلایدها صادر می‌شود.