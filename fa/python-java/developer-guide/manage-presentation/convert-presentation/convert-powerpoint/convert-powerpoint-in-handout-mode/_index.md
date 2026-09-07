---
title: تبدیل ارائه‌های PowerPoint در حالت جزوه با استفاده از Python
linktitle: حالت جزوه
type: docs
weight: 150
url: /fa/python-java/convert-powerpoint-in-handout-mode/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- حالت جزوه
- جزوه
- PPT
- PPTX
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به جزوه‌ها در Python از طریق Java. چندین اسلاید را در هر صفحه ترتیب دهید و با Aspose.Slides به PDF صادر کنید."
---
## **مقدمه**

Aspose.Slides for Python via Java امکان صادرات ارائه‌ها را در حالت جزوه فراهم می‌کند و چندین اسلاید را بر روی یک صفحه تنظیم می‌نماید. این قابلیت برای چاپ مواد ارائه در کنفرانس‌ها، سمینارها و رویدادهای مشابه مفید است.

چیدمان را از طریق متد [setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) پیکربندی کنید. چیدمان‌های جزوه توسط [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/)، [RenderingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/renderingoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/)، و [TiffOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/) پشتیبانی می‌شوند. برای تعیین تنظیمات چیدمان و نمایش، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/handoutlayoutingoptions/) استفاده کنید.

## **صادر کردن در حالت جزوه**

برای صادرات یک ارائه در حالت جزوه، یک نمونه از [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/handoutlayoutingoptions/) ایجاد کنید و آن را با استفاده از [setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) به گزینه‌های صادرات هدف اختصاص دهید.

مثال زیر فایل `sample.pptx` را بارگذاری کرده و با چهار اسلاید در هر صفحه به صورت افقی به PDF صادر می‌کند. این مثال شامل شماره اسلایدها و قاب‌های دور اسلایدها بوده و نظرات را حذف می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# یک ارائه را بارگذاری کنید.
presentation = Presentation("sample.pptx")
try:
    # چیدمان جزوه را پیکربندی کنید.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # ارائه را با چیدمان انتخاب شده به PDF صادر کنید.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="هشدار" %}}
تنظیمات چیدمان جزوه برای فرمت‌های خروجی پشتیبانی‌شده مانند PDF، HTML، TIFF و تصاویر رندر شده اعمال می‌شود. این تنظیمات اسلایدها را در ارائه منبع جابه‌جا نمی‌کند.
{{% /alert %}}

## **سوالات متداول**

**حداکثر تعداد تصویر بند انگشتی اسلاید در هر صفحه در حالت جزوه چقدر است؟**

Aspose.Slides حداکثر تا نه تصویر بند انگشتی در هر صفحه را پشتیبانی می‌کند. پیش‌تنظیم‌های [HandoutType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/handouttype/) یک، دو، سه، چهار، شش یا نه اسلاید در هر صفحه را فراهم می‌آورند. پیش‌تنظیم‌های چهار، شش و نه اسلاید امکان ترتیب افقی و عمودی را ارائه می‌دهند.

**آیا می‌توانم شبکه سفارشی، مانند پنج یا هشت اسلاید در هر صفحه تعریف کنم؟**

خیر. تعداد و ترتیب تصویرهای بند انگشتی توسط مقادیر پیش‌تعریف‌شدهٔ [HandoutType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/handouttype/) کنترل می‌شود. شبکه‌های دلخواه توسط این تنظیمات چیدمان جزوه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی جزوه گنجانده کنم؟**

بله. اسلایدهای مخفی را در تنظیمات خروجی برای فرمت هدف فعال کنید. برای PDF، قبل از ذخیرهٔ ارائه، متد [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) را با مقدار `True` فراخوانی کنید.