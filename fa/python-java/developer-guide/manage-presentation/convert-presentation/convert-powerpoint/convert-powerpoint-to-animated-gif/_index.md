---
title: تبدیل ارائه‌های PowerPoint به GIFهای متحرک در Python
linktitle: PowerPoint به GIF
type: docs
weight: 65
url: /fa/python-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF متحرک
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به GIF
- ارائه به GIF
- اسلاید به GIF
- PPT به GIF
- PPTX به GIF
- ذخیره PPT به صورت GIF
- ذخیره PPTX به صورت GIF
- صدور PPT به صورت GIF
- صدور PPTX به صورت GIF
- تنظیمات پیش‌فرض
- تنظیمات سفارشی
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "به آسانی ارائه‌های PowerPoint (PPT، PPTX) را به GIFهای متحرک با Aspose.Slides برای Python از طریق Java تبدیل کنید. نتایج سریع و با کیفیت بالا."
---
## **مرور کلی**

Aspose.Slides برای Python از طریق Java به شما امکان می‌دهد که ارائه‌های PowerPoint را به فایل‌های GIF متحرک با تنها چند خط کد تبدیل کنید. این برای به‌اشتراک‌گذاری محتوای اسلاید در صفحات وب، پیام‌رسان‌ها یا مستندات مفید است. این مقاله توضیح می‌دهد که چگونه یک ارائه را با تنظیمات پیش‌فرض استخراج کنید و چگونه اندازه فریم، تاخیر اسلاید و نرخ فریم انتقال را از طریق [GifOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/gifoptions/) سفارشی کنید.

## **تبدیل ارائه‌ها به GIF متحرک با استفاده از تنظیمات پیش‌فرض**

مثال زیر در Python، فایل `pres.pptx` را بارگذاری می‌کند و با استفاده از تنظیمات استاندارد آن را به صورت GIF متحرک ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
برای تنظیم خروجی GIF، هنگام ذخیره‌سازی یک شیء [GifOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/gifoptions/) را به عنوان پارامتر پاس دهید، همان‌طور که در زیر نشان داده شده است.
{{% /alert %}}

## **تبدیل ارائه‌ها به GIF متحرک با تنظیمات سفارشی**

از [setFrameSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/gifoptions/#setFrameSize) برای تعیین ابعاد خروجی بر حسب پیکسل، [setDefaultDelay](https://reference.aspose.com/slides/fa/python-java/aspose.slides/gifoptions/#setDefaultDelay) برای تنظیم تاخیر پیش‌فرض اسلاید بر حسب میلی‌ثانیه، و [setTransitionFps](https://reference.aspose.com/slides/fa/python-java/aspose.slides/gifoptions/#setTransitionFps) برای کنترل نرخ فریم انتقال استفاده کنید.

مثال زیر یک GIF با ابعاد ۹۶۰ × ۷۲۰ و تاخیر پیش‌فرض اسلاید دو ثانیه و ۳۵ فریم بر ثانیه برای انتقال‌ها استخراج می‌کند. تاخیر پیش‌فرض زمانی اعمال می‌شود که زمان پیشروی پس از اسلاید تنظیم نشده باشد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
همچنین می‌توانید مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) از Aspose را امتحان کنید.
{{% /alert %}}

## **سوالات متداول**

**اگر قلم‌های استفاده‌شده در ارائه روی سیستم نصب نشده باشند چه می‌شود؟**

قلم‌های گمشده را نصب کنید یا [قلم‌های جایگزین را پیکربندی کنید](/slides/fa/python-java/powerpoint-fonts/). جایگزینی قلم می‌تواند ظاهر GIF استخراج‌شده را تغییر دهد. در دسترس‌گذاری قلم‌های اصلی زمانی ضروری است که بخواهید طراحی ارائه را حفظ کنید.

**آیا می‌توانم یک واترمارک روی فریم‌های GIF اضافه کنم؟**

بله. [یک شیء یا لوگوی نیمه‌شفاف اضافه کنید](/slides/fa/python-java/watermark/) به اسلایدهای اصلی مرتبط یا به اسلایدهای جداگانه قبل از استخراج. واترمارک بخشی از محتوای رندر شده اسلاید می‌شود.