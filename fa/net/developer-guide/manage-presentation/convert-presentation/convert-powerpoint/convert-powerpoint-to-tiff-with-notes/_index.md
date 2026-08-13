---
title: تبدیل ارائه‌های PowerPoint به TIFF همراه با یادداشت‌ها در .NET
linktitle: PowerPoint به TIFF با یادداشت‌ها
type: docs
weight: 100
url: /fa/net/convert-powerpoint-to-tiff-with-notes/
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
- ذخیره PPT به عنوان TIFF
- ذخیره PPTX به عنوان TIFF
- صدور PPT به TIFF
- صدور PPTX به TIFF
- PowerPoint با یادداشت‌ها
- ارائه با یادداشت‌ها
- اسلاید با یادداشت‌ها
- PPT با یادداشت‌ها
- PPTX با یادداشت‌ها
- TIFF با یادداشت‌ها
- .NET
- C#
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به TIFF همراه با یادداشت‌ها با استفاده از Aspose.Slides برای .NET. روش کارآمد صادرات اسلایدها با یادداشت‌های گوینده را بیاموزید."
---
## **مقدمه**

Aspose.Slides برای .NET راه‌حل ساده‌ای برای تبدیل ارائه‌های PowerPoint و OpenDocument (PPT، PPTX و ODP) همراه با یادداشت‌ها به فرمت TIFF فراهم می‌کند. این فرمت به‌طور گسترده‌ای برای ذخیره‌سازی تصویر با کیفیت بالا، چاپ و بایگانی اسناد استفاده می‌شود. با Aspose.Slides می‌توانید نه تنها کل ارائه‌ها را با یادداشت‌های گوینده صادر کنید، بلکه تصویرهای کوچک اسلاید را در نمای اسلاید یادداشت‌ها نیز تولید کنید. فرآیند تبدیل ساده و کارآمد است و از متد `Save` کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) استفاده می‌کند تا کل ارائه را به مجموعه‌ای از تصاویر TIFF تبدیل کند در حالی که یادداشت‌ها و چیدمان حفظ می‌شود.

## **تبدیل ارائه به TIFF همراه با یادداشت‌ها**

ذخیره یک ارائه PowerPoint یا OpenDocument به TIFF همراه با یادداشت‌ها با استفاده از Aspose.Slides برای .NET شامل مراحل زیر است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید: یک فایل PowerPoint یا OpenDocument را بارگذاری کنید.
1. گزینه‌های چیدمان خروجی را پیکربندی کنید: از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/notescommentslayoutingoptions/) برای تعیین نحوه نمایش یادداشت‌ها و نظرات استفاده کنید.
1. ارائه را به TIFF ذخیره کنید: گزینه‌های پیکربندی‌شده را به متد [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/methods/save/index) پاس دهید.

فرض کنید فایلی به نام "speaker_notes.pptx" داریم که اسلاید زیر را دارد:

![اسلاید ارائه با یادداشت‌های گوینده](slide_with_notes.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد کنید که نمایانگر یک فایل ارائه است.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // گزینه‌های TIFF را با چیدمان یادداشت‌ها پیکربندی کنید.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // یادداشت‌ها را در زیر اسلاید نمایش دهد.
        }
    };

    // ارائه را با یادداشت‌های گوینده به فرمت TIFF ذخیره کنید.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

نتیجه:

![تصویر TIFF با یادداشت‌های گوینده](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
به Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) مراجعه کنید.
{{% /alert %}}

## **سوالات متداول**

### آیا می‌توانم موقعیت ناحیه یادداشت‌ها را در TIFF تولید شده کنترل کنم؟

بله. از [تنظیمات چیدمان یادداشت‌ها](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) استفاده کنید تا بین گزینه‌هایی مانند `None`، `BottomTruncated` یا `BottomFull` انتخاب کنید که به ترتیب یادداشت‌ها را مخفی می‌کند، آن‌ها را در یک صفحه جا می‌دهد، یا اجازه می‌دهد در صفحات اضافی ادامه یابند.

### چگونه می‌توانم اندازهٔ فایل TIFF همراه با یادداشت‌ها را بدون کاهش قابل مشاهده کیفیت کاهش دهم؟

یک [فشرده‌سازی مؤثر](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/compressiontype/) (مثلاً `LZW` یا `RLE`) انتخاب کنید، DPI معقولی تنظیم کنید و در صورت امکان از یک [فرمت پیکسل](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/pixelformat/) پایین‌تر (مانند 8 بیتی یا 1 بیتی برای تک‌رنگ) استفاده کنید. کمی کاهش [ابعاد تصویر](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/imagesize/) نیز می‌تواند مفید باشد بدون اینکه به‌وضوح خوانایی آسیب قابل توجهی برساند.

### آیا قلم موجود در یادداشت‌ها بر نتیجه تأثیر می‌گذارد اگر قلم‌های اصلی در سیستم موجود نباشند؟

بله. قلم‌های گمشده باعث [جایگزینی](/slides/fa/net/font-selection-sequence/) می‌شوند که ممکن است متریک و ظاهر متن را تغییر دهد. برای جلوگیری از این مسئله، [قلم‌های موردنیاز را فراهم کنید](/slides/fa/net/custom-font/) یا یک [قلم پیش‌فرض جایگزین](/slides/fa/net/fallback-font/) تنظیم کنید تا قلم‌های مدنظر استفاده شوند.