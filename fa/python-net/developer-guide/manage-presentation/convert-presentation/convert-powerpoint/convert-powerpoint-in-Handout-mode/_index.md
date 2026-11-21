---
title: تبدیل پرزنتیشن‌ها در حالت Handout با Python
linktitle: حالت Handout
type: docs
weight: 150
url: /fa/python-net/convert-powerpoint-in-handout-mode/
keywords:
- تبدیل PowerPoint
- تبدیل پرزنتیشن
- حالت handout
- handout
- PowerPoint
- پرزنتیشن
- PPT
- PPTX
- Python
- Aspose.Slides
description: "پرزنتیشن‌ها را به جزوات در Python تبدیل کنید. اسلایدها را در هر صفحه تنظیم کنید، یادداشت‌ها را حفظ کنید، به PDF یا تصاویر با Aspose.Slides صادر کنید، همراه با کد نمونه. رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides امکان تبدیل پرزنتیشن‌ها به قالب‌های مختلف را فراهم می‌کند، از جمله ایجاد جزوات برای چاپ در حالت Handout. این حالت به شما اجازه می‌دهد که چگونگی نمایش چند اسلاید بر روی یک صفحه را تنظیم کنید که برای کنفرانس‌ها، سمینارها و دیگر رویدادها مفید است. می‌توانید این حالت را با تنظیم ویژگی `slides_layout_options` در کلاس‌های [PdfOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pdfoptions/)، [RenderingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/renderingoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmloptions/)، و [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) فعال کنید.

برای تنظیم ابعاد و جهت‌گیری صفحه جزوات قبل از صادرات، به [اندازه صفحه یادداشت‌ها](/slides/fa/python-net/notes-size/) مراجعه کنید.

## **صادرات حالت Handout**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/handoutlayoutingoptions/) استفاده کنید که تعداد اسلایدهای قرار گرفته بر روی یک صفحه و سایر پارامترهای نمایش را تعیین می‌کند.

در زیر یک مثال کد نشان داده شده است که چگونه یک پرزنتیشن را در حالت Handout به PDF تبدیل کنید.

```py
import aspose.slides as slides

# یک پرزنتیشن را بارگیری کنید.
with slides.Presentation("sample.pptx") as presentation:

    # گزینه‌های صادرات را تنظیم کنید.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # ۴ اسلاید در یک صفحه به صورت افقی
    slides_layout_options.print_slide_numbers = True                                 # چاپ شماره اسلایدها
    slides_layout_options.print_frame_slide = True                                   # چاپ یک قاب دور اسلایدها
    slides_layout_options.print_comments = False                                     # بدون توضیح

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # پرزنتیشن را با چیدمان انتخاب شده به PDF صادر کنید.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="هشدار" %}}
به خاطر داشته باشید که ویژگی `slides_layout_options` فقط برای برخی فرمت‌های خروجی مانند PDF، HTML، TIFF و هنگام رندر به عنوان تصویر در دسترس است.
{{% /alert %}} 

## **سؤالات متداول**

**حداکثر تعداد تصاویر بندانگشتی اسلاید در هر صفحه در حالت Handout چقدر است؟**

Aspose.Slides از [پیکربندی‌های پیش‌فرض](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/handouttype/) تا 9 تصویر بندانگشتی در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: 1، 2، 3، 4 (افقی/عمودی)، 6 (افقی/عمودی) و 9 (افقی/عمودی).

**آیا می‌توانم یک شبکه سفارشی، مانند 5 یا 8 اسلاید در هر صفحه، تعریف کنم؟**

خیر. تعداد و ترتیب تصاویر بندانگشتی به‌طور کامل توسط enumerations [HandoutType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/handouttype/) کنترل می‌شود؛ چیدمان‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟**

بله. گزینه `show_hidden_slides` را در تنظیمات صادرات برای فرمت هدف فعال کنید، مانند [PdfOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmloptions/)، یا [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/).