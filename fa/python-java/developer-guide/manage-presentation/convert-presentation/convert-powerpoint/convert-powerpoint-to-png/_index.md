---
title: تبدیل اسلایدهای PowerPoint به PNG در Python
linktitle: PowerPoint به PNG
type: docs
weight: 30
url: /fa/python-java/convert-powerpoint-to-png/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به PNG
- ارائه به PNG
- اسلاید به PNG
- PPT به PNG
- PPTX به PNG
- ذخیره PPT به عنوان PNG
- ذخیره PPTX به عنوان PNG
- صدور PPT به PNG
- صدور PPTX به PNG
- Python
- Java
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint به تصاویر PNG در Python از طریق Java. خروجی ارائه‌های PPT، PPTX و ODP با مقیاس‌های سفارشی یا ابعاد دقیق تصویر."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه اسلایدهای ارائه را به تصاویر PNG تبدیل کنید با استفاده از Aspose.Slides for Python via Java. می‌توانید ارائه‌ها را در قالب‌هایی مانند PPT، PPTX و ODP بارگذاری کنید، هر اسلاید را رندر کنید و به‌عنوان یک تصویر PNG جداگانه ذخیره نمایید.

مثال‌های زیر رندر با مقیاس پیش‌فرض، افزایش مقیاس، مشخص‌کردن ابعاد خروجی بر حسب پیکسل، و انتخاب سبک رندر گرادیان را نشان می‌دهند.

## **تبدیل PowerPoint به PNG**

یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) بارگذاری کنید و اسلایدهای آن را از طریق مجموعه [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) دسترسی پیدا کنید. مثال با استفاده از [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) بدون پارامتر برای ایجاد تصویر بندانگشتی، هر اسلاید را رندر می‌کند. سپس با فراخوانی [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) و استفاده از [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) هر اسلاید رندر شده به صورت تصویر PNG ذخیره می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

بارگذاری بدون پارامتر [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) با مقیاس ۰٫۲ انجام می‌شود. به‌عنوان مثال، اسلایدی با اندازه ۷۲۰ × ۵۴۰ نقطه، یک تصویر بندانگشتی ۱۴۴ × ۱۰۸ پیکسل تولید می‌کند. برای کنترل ابعاد خروجی، از بارگذاری‌های با فاکتورهای مقیاس یا اندازهٔ تصویر صریح استفاده کنید همان‌طور که در ادامه نشان داده شده است.

{{% /alert %}}

## **تبدیل PowerPoint به PNG با ابعاد سفارشی**

فاکتورهای مقیاس افقی و عمودی را به [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) پاس دهید تا ابعاد رندر شده را کنترل کنید. در این مثال هر دو فاکتور برابر ۲ هستند، بنابراین اسلایدی با اندازه ۷۲۰ × ۵۴۰ نقطه، تصویر ۱۴۴۰ × ۱۰۸۰ پیکسل تولید می‌کند. فاکتورهای مقیاس برابر نسبت عرض‑ارتفاع اسلاید را حفظ می‌کنند. هر تصویر رندر شده به فرمت PNG ذخیره می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **تبدیل PowerPoint به PNG با اندازهٔ سفارشی**

برای مشخص‌کردن ابعاد خروجی بر حسب پیکسل، به جای فاکتورهای مقیاس یک اندازه به [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) پاس دهید. این مثال هر اسلاید را با ابعاد ۹۶۰ × ۷۲۰ پیکسل رندر می‌کند و نتیجه را در فرمت PNG ذخیره می‌نماید. برای جلوگیری از کشیدگی تصویر، ابعادی را انتخاب کنید که نسبت عرض‑ارتفاع اسلاید را حفظ کنند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **انتخاب سبک رندر گرادیان**

فرض کنید اسلایدی شامل پرکننده‌های گرادیانی باشد، اما انتقال‌های رنگ در PNG خروجی روشن‌تر یا متفاوت از آنچه در PowerPoint می‌بینید، باشد. می‌توانید از متد [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) که توسط [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) به ارث برده شده است، برای انتخاب نحوهٔ رندر گرادیان‌ها استفاده کنید.

فایل [gradient-styles.pptx](gradient-styles.pptx) را دانلود کنید و در دایرکتوری کاری برنامه قرار دهید. اسلاید نخست آن شامل دو گرادیان خطی است: از سیان به نارنجی در بالا و از آبی به زرد در پایین. هر گرادیان دارای دو توقف است، در ۰٪ و ۱۰۰٪.

مثال زیر این ارائه را بارگذاری کرده و اسلاید نخست را در هر دو حالت با [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) رندر می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

تصاویر زیر خروجی یکسان اسلاید را نشان می‌دهند، با هر دو گرادیان در هر تصویر:

| Default | PowerPointUI |
| --- | --- |
| ![رندر گرادیان‌های سیان‑به‑نارنجی و آبی‑به‑زرد با Default](gradient-Default.png) | ![همان گرادیان‌ها رندر شده با PowerPointUI](gradient-PowerPointUI.png) |

در این مثال، `Default` رنگ‌های میانی روشن‌تری تولید می‌کند، در حالی که `PowerPointUI` رنگ‌های میانی تیره‌تری می‌دهد. این تفاوت به رنگ‌ها و نقاط توقف در گرادیان بستگی دارد.

`Default` را زمانی انتخاب کنید که خروجی استاندارد Aspose.Slides برای نیازهای شما کافی باشد. `PowerPointUI` را وقتی استفاده کنید که تطبیق ظاهر با PowerPoint برای شما اولویت داشته باشد. هر دو خروجی را با نتیجهٔ مورد نظر مقایسه کنید؛ هیچ‌یک به‌طور کلی بر دیگری ترجیح داده نمی‌شود.

## **سوالات متداول**

**چگونه می‌توانم یک شکل خاص، مانند نمودار یا تصویر، را به‌جای کل اسلاید استخراج کنم؟**

Aspose.Slides از [ایجاد تصویر کوچک برای اشکال جداگانه](/slides/fa/python-java/create-shape-thumbnails/) پشتیبانی می‌کند که به شما اجازه می‌دهد یک شکل را به‌صورت تصویر PNG رندر کنید.

**آیا تبدیل موازی در سرور پشتیبانی می‌شود؟**

بله. برای هر رِیِد یا فرآیند یک نمونهٔ ارائه جداگانه استفاده کنید؛ [از به‌اشتراک‌گذاری یک نمونهٔ واحد بین رِیِدها](/slides/fa/python-java/multithreading/) خودداری کنید.

**محدودیت‌های ارزیابی هنگام خروجی به PNG چیست؟**

حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌کند و تا زمان اعمال لایسنس، [محدودیت‌های دیگر](/slides/fa/python-java/licensing/) را اعمال می‌نماید.