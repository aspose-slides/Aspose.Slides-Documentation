---
title: تبدیل ارائه‌ها در حالت Handout با پایتون
linktitle: حالت Handout
type: docs
weight: 150
url: /fa/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- حالت برگه‌برداری
- برگه‌برداری
- پاورپوینت
- ارائه
- PPT
- PPTX
- پایتون
- Aspose.Slides
description: "ارائه‌ها را به برگه‌های چاپی در پایتون تبدیل کنید. تعداد اسلایدها در هر صفحه را تنظیم کنید، یادداشت‌ها را نگه دارید، به PDF یا تصاویر با Aspose.Slides صادر کنید، همراه با کد نمونه. به صورت رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides امکان تبدیل ارائه‌ها به فرمت‌های مختلف را فراهم می‌کند، از جمله ایجاد برگه‌های چاپی در حالت Handout. این حالت به شما اجازه می‌دهد تا نحوه نمایش چند اسلاید بر روی یک صفحه را تنظیم کنید، که برای کنفرانس‌ها، سمینارها و سایر رویدادها مفید است. می‌توانید این حالت را با تنظیم خاصیت `slides_layout_options` در کلاس‌های [PdfOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pdfoptions/)، [RenderingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/renderingoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmloptions/)، و [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) فعال کنید.

## **صادرات حالت برگه‌برداری**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/handoutlayoutingoptions/) استفاده کنید که تعداد اسلایدهای قرار گرفته بر روی یک صفحه و سایر پارامترهای نمایش را تعیین می‌کند.

در زیر یک مثال کد آورده شده که نشان می‌دهد چگونه یک ارائه را به PDF در حالت Handout تبدیل کنید.

```py
# بارگذاری یک ارائه.
with slides.Presentation("sample.pptx") as presentation:

    # تنظیم گزینه‌های صدور.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # ۴ اسلاید به صورت افقی در یک صفحه
    slides_layout_options.print_slide_numbers = True                                 # چاپ شماره اسلایدها
    slides_layout_options.print_frame_slide = True                                   # چاپ قاب دور اسلایدها
    slides_layout_options.print_comments = False                                     # بدون نظرات

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # صادر کردن ارائه به PDF با طرح انتخابی.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
به یاد داشته باشید که خاصیت `slides_layout_options` فقط برای برخی فرمت‌های خروجی مثل PDF، HTML، TIFF و هنگام رندر به عنوان تصویر در دسترس است.
{{% /alert %}} 

## **سوالات متداول**

**حداکثر تعداد تصویر کوچک اسلایدها در هر صفحه در حالت Handout چه مقدار است؟**

Aspose.Slides پیکربندی‌های پیش‌فرض را تا 9 تصویر کوچک در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: 1، 2، 3، 4 (افقی/عمودی)، 6 (افقی/عمودی) و 9 (افقی/عمودی).

**آیا می‌توانم یک شبکه سفارشی مانند 5 یا 8 اسلاید در هر صفحه تعریف کنم؟**

خیر. تعداد و ترتیب تصویرهای کوچک به‌صورت دقیق توسط enumeration [HandoutType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/handouttype/) کنترل می‌شود؛ طرح‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟**

بله. گزینه `show_hidden_slides` را در تنظیمات خروجی برای فرمت هدف فعال کنید، مانند [PdfOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmloptions/)، یا [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/).