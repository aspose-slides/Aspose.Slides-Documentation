---
title: تبدیل ارائه‌های PowerPoint به TIFF با یادداشت‌ها در Python
linktitle: PowerPoint به TIFF با یادداشت‌ها
type: docs
weight: 100
url: /fa/python-net/convert-powerpoint-to-tiff-with-notes/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به TIFF
- ارائه به TIFF
- اسلاید به TIFF
- PPT به TIFF
- PPTX به TIFF
- PowerPoint با یادداشت‌ها
- ارائه با یادداشت‌ها
- اسلاید با یادداشت‌ها
- PPT با یادداشت‌ها
- PPTX با یادداشت‌ها
- TIFF با یادداشت‌ها
- پایتون
- Aspose.Slides
description: "با استفاده از Aspose.Slides برای Python عبر .NET، ارائه‌های PowerPoint را به TIFF با یادداشت‌ها تبدیل کنید. یاد بگیرید چگونه اسلایدها را به‌صورت کارآمد با یادداشت‌های گوینده صادر کنید."
---
## **مقدمه**

Aspose.Slides for Python via .NET یک راه حل ساده برای تبدیل ارائه‌های PowerPoint و OpenDocument (PPT، PPTX و ODP) همراه با یادداشت‌ها به فرمت TIFF فراهم می‌کند. این فرمت به‌طور گسترده‌ای برای ذخیره‌سازی تصویر با کیفیت بالا، چاپ و بایگانی اسناد استفاده می‌شود. با Aspose.Slides می‌توانید نه تنها کل ارائه‌ها را همراه با یادداشت‌های گوینده صادر کنید، بلکه تصویرهای بندانگشتی اسلاید را در نمای Notes Slide نیز تولید کنید. فرآیند تبدیل ساده و کارآمد است و از متد `save` کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای تبدیل کل ارائه به مجموعه‌ای از تصاویر TIFF در حالی که یادداشت‌ها و طرح‌بندی حفظ می‌شود، استفاده می‌کند.

## **تبدیل یک ارائه به TIFF با یادداشت‌ها**

ذخیره یک ارائه PowerPoint یا OpenDocument به TIFF همراه با یادداشت‌ها با استفاده از Aspose.Slides for Python via .NET شامل مراحل زیر است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید: یک فایل PowerPoint یا OpenDocument را بارگذاری کنید.
1. گزینه‌های طرح‌بندی خروجی را پیکربندی کنید: از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notescommentslayoutingoptions/) برای تعیین نحوه نمایش یادداشت‌ها و نظرات استفاده کنید.
1. ارائه را به TIFF ذخیره کنید: گزینه‌های پیکربندی شده را به متد [save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) پاس بدهید.

فرض کنید فایلی به نام "speaker_notes.pptx" داریم که اسلاید زیر را دارد:

![اسلاید ارائه با یادداشت‌های گوینده](slide_with_notes.png)

قطعه کد زیر نشان می‌دهد چگونه می‌توان ارائه را به تصویر TIFF در نمای Notes Slide تبدیل کرد با استفاده از ویژگی [slides_layout_options](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/slides_layout_options/).

```py
# یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد.
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # نمایش یادداشت‌ها زیر اسلاید.
    
    # پیکربندی گزینه‌های TIFF با چینش یادداشت‌ها.
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # ذخیره ارائه به TIFF همراه با یادداشت‌های گوینده.
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

نتیجه:

![تصویر TIFF با یادداشت‌های گوینده](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
به Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) مراجعه کنید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم موقعیت ناحیه یادداشت‌ها را در TIFF تولید شده کنترل کنم؟**

بله. از [notes layout settings](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) استفاده کنید تا بین گزینه‌هایی مانند `NONE`، `BOTTOM_TRUNCATED` یا `BOTTOM_FULL` انتخاب کنید که به ترتیب یادداشت‌ها را مخفی می‌کند، آنها را در یک صفحه جای می‌دهد، یا اجازه می‌دهد به صفحات اضافی ادامه یابند.

**چگونه می‌توانم حجم فایل TIFF با یادداشت‌ها را بدون کاهش آشکار کیفیت کاهش دهم؟**

یک [efficient compression](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/compression_type/) (مثلاً `LZW` یا `RLE`) انتخاب کنید، DPI معقولی تنظیم کنید و در صورت قابلیت پذیرش، از [pixel format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/pixel_format/) پایین‌تر (مانند 8 bpp یا 1 bpp برای تک‌رنگ) استفاده کنید. کمی کاهش [image dimensions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/image_size/) نیز می‌تواند کمک کند بدون اینکه به وضوح خوانایی آسیب قابل‌توجهی برساند.

**آیا فونت در یادداشت‌ها بر نتیجه تأثیر می‌گذارد اگر فونت‌های اصلی در سیستم موجود نباشند؟**

بله. نبودن فونت‌ها باعث [substitution](/slides/fa/python-net/font-selection-sequence/) می‌شود که می‌تواند معیارهای متنی و ظاهر را تغییر دهد. برای جلوگیری از این، [فونت‌های مورد نیاز را فراهم کنید](/slides/fa/python-net/custom-font/) یا یک [fallback font](/slides/fa/python-net/fallback-font/) پیش‌فرض تنظیم کنید تا قلم‌های مورد نظر استفاده شوند.