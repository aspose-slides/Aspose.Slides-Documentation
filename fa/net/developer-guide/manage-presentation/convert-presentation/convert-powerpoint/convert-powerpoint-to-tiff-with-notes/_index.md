---
title: تبدیل ارائه‌های PowerPoint به TIFF با یادداشت‌ها در .NET
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
- ذخیره PPT به صورت TIFF
- ذخیره PPTX به صورت TIFF
- صادرات PPT به TIFF
- صادرات PPTX به TIFF
- PowerPoint با یادداشت‌ها
- ارائه با یادداشت‌ها
- اسلاید با یادداشت‌ها
- PPT با یادداشت‌ها
- PPTX با یادداشت‌ها
- TIFF با یادداشت‌ها
- .NET
- C#
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به TIFF با یادداشت‌ها با استفاده از Aspose.Slides برای .NET. یاد بگیرید چگونه اسلایدها را با یادداشت‌های گوینده به‌صورت کارآمد صادر کنید."
---
## **مقدمه**

Aspose.Slides برای .NET راه‌حلی ساده برای تبدیل ارائه‌های PowerPoint و OpenDocument (PPT، PPTX و ODP) همراه با یادداشت‌ها به فرمت TIFF فراهم می‌کند. این فرمت به‌طور گسترده‌ای برای ذخیره‌سازی تصویر با کیفیت بالا، چاپ و بایگانی اسناد استفاده می‌شود. با Aspose.Slides می‌توانید نه‌ تنها کل ارائه‌ها را با یادداشت‌های گوینده صادر کنید، بلکه تصویرهای بندانگشتی اسلایدها را در نمای اسلایدهای یادداشت نیز تولید کنید. فرآیند تبدیل ساده و کارآمد است و از متد `Save` کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) برای تبدیل کل ارائه به مجموعه‌ای از تصاویر TIFF استفاده می‌کند، در حالی که یادداشت‌ها و‌چیدمان حفظ می‌شوند.

## **تبدیل یک ارائه به TIFF با یادداشت‌ها**

ذخیره یک ارائه PowerPoint یا OpenDocument به TIFF همراه با یادداشت‌ها با استفاده از Aspose.Slides برای .NET شامل مراحل زیر است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید: یک فایل PowerPoint یا OpenDocument را بارگذاری کنید.  
2. گزینه‌های چیدمان خروجی را پیکربندی کنید: از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/notescommentslayoutingoptions/) استفاده کنید تا مشخص کنید یادداشت‌ها و نظرات چگونه نمایش داده شوند.  
3. ارائه را به TIFF ذخیره کنید: گزینه‌های پیکربندی شده را به متد [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/methods/save/index) پاس دهید.

فرض کنید فایلی به نام "speaker_notes.pptx" داریم که شامل اسلاید زیر است:

![اسلاید ارائه با یادداشت‌های گوینده](slide_with_notes.png)

قطعه کد زیر نشان می‌دهد چگونه می‌توان ارائه را به تصویر TIFF در نمای اسلایدهای یادداشت تبدیل کرد با استفاده از ویژگی [SlidesLayoutOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/slideslayoutoptions/).

```c#
// یک شیء از کلاس Presentation ایجاد کنید که نمایانگر یک فایل ارائه است.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // پیکربندی گزینه‌های TIFF با چیدمان یادداشت‌ها.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // نمایش یادداشت‌ها زیر اسلاید.
        }
    };

    // ذخیره ارائه به فرمت TIFF همراه با یادداشت‌های گوینده.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

نتیجه:

![تصویر TIFF با یادداشت‌های گوینده](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
به Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) مراجعه کنید.
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم موقعیت ناحیه یادداشت‌ها را در TIFF نهایی کنترل کنم؟**

بله. از [تنظیمات چیدمان یادداشت‌ها](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) استفاده کنید تا بین گزینه‌هایی مانند `None`، `BottomTruncated` یا `BottomFull` انتخاب کنید؛ این گزینه‌ها به ترتیب یادداشت‌ها را مخفی می‌کنند، در یک صفحه جای می‌دهند یا اجازه می‌دهند به صفحات اضافی ادامه یابند.

**چگونه می‌توانم حجم فایل TIFF با یادداشت‌ها را بدون کاهش محسوس کیفیت کاهش دهم؟**

یک [فشرده‌سازی کارآمد](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/compressiontype/) (مانند `LZW` یا `RLE`) انتخاب کنید، DPI معقولی تنظیم کنید و در صورت امکان از [فرمت پیکسل](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/pixelformat/) پایین‌تری (مثل 8 bpp یا 1 bpp برای تک‌رنگ) استفاده کنید. کمی کاهش [ابعاد تصویر](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/imagesize/) نیز می‌تواند بدون کاهش قابل توجه قابلیت خواندن مفید باشد.

**آیا فونت در یادداشت‌ها بر نتیجه تاثیر می‌گذارد اگر فونت‌های اصلی در سیستم موجود نباشند؟**

بله. عدم وجود فونت‌ها باعث فعال شدن [جایگزینی](/slides/fa/net/font-selection-sequence/) می‌شود که می‌تواند متریک‌ها و ظاهر متن را تغییر دهد. برای جلوگیری از این وضعیت، [فونت‌های مورد نیاز را فراهم کنید](/slides/fa/net/custom-font/) یا یک [فونت پیش‌فرض جایگزین](/slides/fa/net/fallback-font/) تنظیم کنید تا قلم‌های مورد نظر استفاده شوند.