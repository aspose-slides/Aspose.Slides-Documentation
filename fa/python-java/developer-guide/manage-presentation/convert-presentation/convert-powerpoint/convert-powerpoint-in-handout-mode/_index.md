---
title: تبدیل ارائه‌های PowerPoint به حالت جزوه با استفاده از Python
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
description: "ارائه‌های PowerPoint را به جزوه‌ها در Python از طریق Java تبدیل کنید. چندین اسلاید را در هر صفحه ترتیب دهید و با Aspose.Slides به PDF صادر کنید."
---
## **مقدمه**

Aspose.Slides for Python via Java به شما امکان می‌دهد ارائه‌ها را در حالت جزوه صادر کنید و چندین اسلاید را بر روی یک صفحه قرار دهید. این قابلیت برای چاپ مطالب ارائه در کنفرانس‌ها، سمینارها و رویدادهای مشابه مفید است.

طرح‌بندی را از طریق روش [setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) پیکربندی کنید. طرح‌های جزوه توسط [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/)، [RenderingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/renderingoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/) و [TiffOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/) پشتیبانی می‌شوند. برای مشخص کردن تنظیمات طرح و نمایش، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/handoutlayoutingoptions/) استفاده کنید.

برای تنظیم ابعاد و جهت‌گیری صفحه جزوه پیش از صادرات، به بخش [Notes Page Size](/slides/fa/python-java/notes-size/) مراجعه کنید.

## **صادرات در حالت جزوه**

برای صادر کردن یک ارائه در حالت جزوه، یک نمونه از [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/handoutlayoutingoptions/) ایجاد کنید و آن را با استفاده از [setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) به گزینه‌های صادرات هدف اختصاص دهید.

مثال زیر فایل `sample.pptx` را بارگذاری می‌کند و آن را به PDF با چهار اسلاید در هر صفحه به ترتیب افقی صادر می‌نماید. این مثال شماره اسلایدها و قاب‌های اطراف اسلایدها را شامل می‌شود و نظرات را حذف می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# بارگذاری یک ارائه.
presentation = Presentation("sample.pptx")
try:
    # پیکربندی طرح‌بندی جزوه.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # صادر کردن ارائه به PDF با طرح‌بندی انتخاب شده.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}

تنظیمات طرح جزوه برای فرمت‌های خروجی پشتیبانی‌شده مانند PDF، HTML، TIFF و تصاویر رندر شده اعمال می‌شوند. این تنظیمات اسلایدهای موجود در ارائه منبع را مرتب نمی‌کنند.

{{% /alert %}}

## **سوالات متداول**

**حداکثر تعداد تصویر بندانگشت اسلاید در هر صفحه در حالت جزوه چقدر است؟**

Aspose.Slides تا نه تصویر بندانگشت در هر صفحه را پشتیبانی می‌کند. پیش‌تنظیم‌های [HandoutType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/handouttype/) یک، دو، سه، چهار، شش یا نه اسلاید در هر صفحه را فراهم می‌آورند. پیش‌تنظیم‌های چهار، شش و نه اسلایدی امکان ترتیب افقی و عمودی را ارائه می‌دهند.

**آیا می‌توانم یک شبکه سفارشی، مانند پنج یا هشت اسلاید در هر صفحه تعریف کنم؟**

خیر. تعداد و ترتیب تصویرهای بندانگشت توسط مقادیر از پیش تعریف‌شدهٔ [HandoutType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/handouttype/) کنترل می‌شود. شبکه‌های دلخواه توسط این تنظیمات طرح جزوه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی جزوه گنجانده کنم؟**

بله. اسلایدهای مخفی را در تنظیمات صادرات برای فرمت هدف فعال کنید. برای PDF، قبل از ذخیرهٔ ارائه، متد [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) را با مقدار `True` فراخوانی کنید.