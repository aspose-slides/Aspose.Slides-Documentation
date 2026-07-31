---
title: تبدیل ارائه‌ها در حالت Handout با Python
linktitle: حالت Handout
type: docs
weight: 150
url: /fa/python-net/convert-powerpoint-in-handout-mode/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- حالت Handout
- Handout
- PowerPoint
- ارائه
- PPT
- PPTX
- Python
- Aspose.Slides
description: "ارائه‌ها را به جزوه‌ها در Python تبدیل کنید. اسلایدها را در هر صفحه تنظیم کنید، یادداشت‌ها را نگه دارید، به PDF یا تصاویر با Aspose.Slides صادر کنید، با کد نمونه. به صورت رایگان امتحان کنید."
---
## **معرفی**

Aspose.Slides امکان تبدیل ارائه‌ها به فرمت‌های مختلف را فراهم می‌کند، از جمله ایجاد جزوه‌ها برای چاپ در حالت Handout. این حالت به شما اجازه می‌دهد نحوه نمایش چندین اسلاید روی یک صفحه را تنظیم کنید، که برای کنفرانس‌ها، سمینارها و رویدادهای دیگر مفید است. می‌توانید این حالت را با تنظیم ویژگی `slides_layout_options` در کلاس‌های [PdfOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmloptions/), و [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) فعال کنید.

## **صادر کردن در حالت Handout**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/handoutlayoutingoptions/) استفاده کنید که تعیین می‌کند چه تعداد اسلاید بر روی یک صفحه قرار گیرند و سایر پارامترهای نمایش.

در ادامه یک مثال کد نشان داده شده است که نحوه تبدیل یک ارائه به PDF در حالت Handout را نشان می‌دهد.

```py
# یک ارائه را بارگذاری کنید.
with slides.Presentation("sample.pptx") as presentation:

    # گزینه‌های خروجی را تنظیم کنید.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 اسلاید در یک صفحه به صورت افقی
    slides_layout_options.print_slide_numbers = True                                 # چاپ شماره اسلایدها
    slides_layout_options.print_frame_slide = True                                   # چاپ قاب دور اسلایدها
    slides_layout_options.print_comments = False                                     # بدون نظرات

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # ارائه را با چیدمان انتخاب شده به PDF صادر کنید.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
به‌خاطر داشته باشید که ویژگی `slides_layout_options` فقط برای برخی فرمت‌های خروجی، مانند PDF، HTML، TIFF، و هنگام رندر به‌صورت تصویر، در دسترس است.
{{% /alert %}} 

## **سوالات متداول**

**حداکثر تعداد تصویر بندانگشتی اسلایدها در هر صفحه در حالت Handout چقدر است؟**

Aspose.Slides از [پیش‌تنظیم‌ها](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/handouttype/) تا 9 تصویر بندانگشتی در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: 1، 2، 3، 4 (افقی/عمودی)، 6 (افقی/عمودی) و 9 (افقی/عمودی).

**آیا می‌توانم یک شبکه سفارشی، مثل 5 یا 8 اسلاید در هر صفحه، تعریف کنم؟**

خیر. تعداد و ترتیب تصویرهای بندانگشتی صرفاً توسط شمارش‌گر [HandoutType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/handouttype/) کنترل می‌شود؛ طرح‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout شامل کنم؟**

بله. گزینه `show_hidden_slides` را در تنظیمات خروجی برای فرمت هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmloptions/), یا [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) فعال کنید.