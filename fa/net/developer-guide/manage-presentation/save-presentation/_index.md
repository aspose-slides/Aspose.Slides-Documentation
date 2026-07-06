---
title: ذخیره ارائه‌ها در .NET
linktitle: ذخیره ارائه
type: docs
weight: 80
url: /fa/net/save-presentation/
keywords:
- ذخیره PowerPoint
- ذخیره OpenDocument
- ذخیره ارائه
- ذخیره اسلاید
- ذخیره PPT
- ذخیره PPTX
- ذخیره ODP
- ارائه به فایل
- ارائه به جریان
- نوع نمای پیش‌تعریف‌شده
- قالب Strict Office Open XML
- حالت Zip64
- به‌روزرسانی تصویر کوچک
- پیشرفت ذخیره‌سازی
- .NET
- C#
- Aspose.Slides
description: "کشف کنید چگونه در .NET با استفاده از Aspose.Slides ارائه‌ها را ذخیره کنید—به PowerPoint یا OpenDocument صادر کنید و چیدمان‌ها، قلم‌ها و اثرات را حفظ کنید."
---
## **بررسی کلی**

[Open Presentations in C#](/slides/fa/net/open-presentation/) توضیح می‌دهد چگونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) برای باز کردن یک ارائه استفاده کنید. این مقاله نحوه ایجاد و ذخیره ارائه‌ها را شرح می‌دهد. کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) محتویات یک ارائه را در بر دارد. چه از ابتدا یک ارائه بسازید و چه یک ارائه موجود را تغییر دهید، پس از اتمام می‌خواهید آن را ذخیره کنید. با Aspose.Slides برای .NET می‌توانید به **فایل** یا **جریان** ذخیره کنید. این مقاله روش‌های مختلف ذخیره یک ارائه را توضیح می‌دهد.

## **ذخیره ارائه‌ها به فایل‌ها**

برای ذخیره یک ارائه به یک فایل، متد `Save` کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) را فراخوانی کنید. نام فایل و فرمت ذخیره را به متد پاس دهید. مثال زیر نشان می‌دهد چگونه یک ارائه را با Aspose.Slides ذخیره کنید.

```cs
// یک شی از کلاس Presentation ایجاد کنید که نمایانگر یک فایل ارائه است.
using (Presentation presentation = new Presentation())
{
    // در اینجا کاری انجام دهید...

    // ارائه را در یک فایل ذخیره کنید.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **ذخیره ارائه‌ها به جریان‌ها**

می‌توانید یک ارائه را به یک جریان ذخیره کنید با این‌که یک جریان خروجی را به متد `Save` کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) پاس دهید. یک ارائه می‌تواند به انواع مختلفی از جریان‌ها نوشته شود. در مثال زیر، یک ارائه جدید ایجاد می‌کنیم و آن را به یک جریان فایل ذخیره می‌کنیم.

```cs
// یک شی از کلاس Presentation ایجاد کنید که نمایانگر یک فایل ارائه است.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // ارائه را در جریان ذخیره کنید.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **ذخیره ارائه‌ها با نوع نمای از پیش تعریف‌شده**

Aspose.Slides به شما اجازه می‌دهد نمای اولیه‌ای که PowerPoint هنگام باز شدن ارائهٔ تولید‌شده استفاده می‌کند را از طریق کلاس [ViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/) تنظیم کنید. خصوصیت [LastView](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/lastview/) را به مقداری از شمارش‌نامهٔ [ViewType](https://reference.aspose.com/slides/fa/net/aspose.slides/viewtype/) می‌دهید.

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **ذخیره ارائه‌ها در قالب Strict Office Open XML**

Aspose.Slides به شما اجازه می‌دهد یک ارائه را در قالب Strict Office Open XML ذخیره کنید. از کلاس [PptxOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pptxoptions/) استفاده کنید و هنگام ذخیره ویژگی `Conformance` آن را تنظیم کنید. اگر `Conformance.Iso29500_2008_Strict` را تنظیم کنید، فایل خروجی در قالب Strict Office Open XML ذخیره می‌شود.

مثال زیر یک ارائه ایجاد می‌کند و آن را در قالب Strict Office Open XML ذخیره می‌دارد.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// یک شی از کلاس Presentation ایجاد کنید که نمایانگر یک فایل ارائه است.
using (Presentation presentation = new Presentation())
{
    // ارائه را در قالب Strict Office Open XML ذخیره کنید.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **ذخیره ارائه‌ها در قالب Office Open XML در حالت Zip64**

یک فایل Office Open XML یک آرشیو ZIP است که محدودیت ۴ GB (۲^۳۲ بایت) برای اندازهٔ فشرده‌نشدهٔ هر فایل، اندازهٔ فشردهٔ هر فایل و مجموع اندازهٔ آرشیو تعیین می‌کند و همچنین تعداد فایل‌ها را به ۶۵ ۵۳۵ (۲^۱۶‑۱) محدود می‌کند. افزونه‌های فرمت ZIP64 این محدودیت‌ها را تا ۲^۶۴ افزایش می‌دهند.

خصوصیت [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ipptxoptions/zip64mode/) به شما اجازه می‌دهد هنگام ذخیرهٔ یک فایل Office Open XML تصمیم بگیرید که از افزونه‌های فرمت ZIP64 استفاده شود یا نه.

این خصوصیت حالت‌های زیر را فراهم می‌کند:

- `IfNecessary` فقط در صورتی که ارائه محدودیت‌های بالا را رد کند از افزونه‌های ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- `Never` هرگز از افزونه‌های ZIP64 استفاده نمی‌کند.
- `Always` همیشه از افزونه‌های ZIP64 استفاده می‌کند.

کد زیر نشان می‌دهد چگونه یک ارائه را به عنوان فایل PPTX با فعال‌سازی افزونه‌های ZIP64 ذخیره کنید:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
وقتی با `Zip64Mode.Never` ذخیره می‌کنید، اگر ارائه نتواند در قالب ZIP32 ذخیره شود، یک [PptxException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxexception/) پرتاب می‌شود.
{{% /alert %}}

## **ذخیره ارائه‌ها در قالب Office Open XML با سطوح فشرده‌سازی**

هنگام کار با ارائه‌های بزرگ می‌توانید سطح فشرده‌سازی را تنظیم کنید تا بین اندازهٔ فایل و زمان پردازش تعادل برقرار شود. بسته به نیازهای شما ممکن است پردازش سریع‌تر یا فایل‌های خروجی کوچکتر ترجیح داده شود.

Aspose.Slides ویژگی [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ipptxoptions/compressionlevel/) را فراهم می‌کند که به شما اجازه می‌دهد سطح فشرده‌سازی مورد استفاده هنگام ذخیرهٔ یک ارائه در قالب Office Open XML را مشخص کنید.

سطوح فشرده‌سازی موجود عبارتند از:

- **None**: هیچ فشرده‌سازی اعمال نمی‌شود. فایل‌ها به همان شکل ذخیره می‌شوند.
- **Level1**: سریع‌ترین فشرده‌سازی با کمترین نسبت فشرده‌سازی.
- **Level2**: فشرده‌سازی سریع‌تر با نسبت فشرده‌سازی کمی بهتر نسبت به **Level1**.
- **Level3**: فشرده‌سازی بهتر نسبت به **Level2** با تأثیر متوسط بر زمان پردازش.
- **Level4**: فشرده‌سازی بهتر نسبت به **Level3**.
- **Level5**: فشرده‌سازی بهبود یافته نسبت به **Level4** با زمان پردازش اضافی.
- **Level6**: فشرده‌سازی استاندارد که تعادل خوبی بین سرعت پردازش و اندازهٔ فایل ارائه می‌دهد. این **سطح فشرده‌سازی پیش‌فرض** است.
- **Level7**: فشرده‌سازی بهتر نسبت به **Level6** با پردازش کندتر.
- **Level8**: فشرده‌سازی بهتر نسبت به **Level7**.
- **Level9**: حداکثر فشرده‌سازی. کوچک‌ترین اندازهٔ فایل را تولید می‌کند، اما طولانی‌ترین زمان پردازش را می‌طلبد.

مثال زیر نشان می‌دهد چگونه یک ارائه را به عنوان فایل PPTX *بدون فشرده‌سازی* ذخیره کنید:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

این مثال نشان می‌دهد چگونه یک ارائه را به عنوان فایل PPTX با *حداکثر فشرده‌سازی* ذخیره کنید:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **ذخیره ارائه‌ها بدون به‌روزرسانی تصویر کوچک**

خصوصیت [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) کنترل می‌کند که هنگام ذخیرهٔ یک ارائه به PPTX تصویر کوچک تولید شود یا نه:

- اگر به `true` تنظیم شود، تصویر کوچک در زمان ذخیره‌سازی به‌روزرسانی می‌شود. این حالت پیش‌فرض است.
- اگر به `false` تنظیم شود، تصویر کوچک فعلی حفظ می‌شود. اگر ارائه تصویر کوچک نداشته باشد، هیچ‌کدام تولید نمی‌شود.

در کد زیر، ارائه بدون به‌روزرسانی تصویر کوچک به PPTX ذخیره می‌شود.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
این گزینه به کاهش زمان لازم برای ذخیرهٔ یک ارائه در قالب PPTX کمک می‌کند.
{{% /alert %}}

## **دریافت به‌روزرسانی‌های پیشرفت ذخیره به درصد**

رابط [IProgressCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/iprogresscallback/) از طریق خصوصیت `ProgressCallback` که توسط رابط [ISaveOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/isaveoptions/) و کلاس انتزاعی [SaveOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveoptions/) منتشر می‌شود، استفاده می‌شود. یک پیاده‌سازی از [IProgressCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/iprogresscallback/) را به `ProgressCallback` اختصاص دهید تا به‌روزرسانی‌های پیشرفت ذخیره را به صورت درصد دریافت کنید.

کدهای زیر نشان می‌دهند چگونه از `IProgressCallback` استفاده کنید.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // از مقدار درصد پیشرفت در اینجا استفاده کنید.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose یک برنامهٔ رایگان **PowerPoint Splitter** (https://products.aspose.app/slides/fa/splitter) را با استفاده از API خود توسعه داده است. این برنامه به شما امکان می‌دهد یک ارائه را به چندین فایل تقسیم کنید و اسلایدهای منتخب را به‌عنوان فایل‌های جدید PPTX یا PPT ذخیره کنید.
{{% /alert %}}

## **سوالات متداول**

**آیا «ذخیره سریع» (ذخیره افزایشی) پشتیبانی می‌شود تا فقط تغییرات نوشته شوند؟**

خیر. هر بار ذخیره‌سازی یک فایل هدف کامل ایجاد می‌کند؛ «ذخیره سریع» افزایشی پشتیبانی نمی‌شود.

**آیا ذخیرهٔ یک نمونهٔ Presentation از چندین رشته همزمان ایمن است؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) **thread‑safe** نیست؛ آن را تنها از یک رشته ذخیره کنید.

**در هنگام ذخیره چه اتفاقی برای پیوندهای‌های هیپرلینک و فایل‌های لینک‌خوردهٔ خارجی می‌افتد؟**

[Hyperlinks](/slides/fa/net/manage-hyperlinks/) حفظ می‌شوند. فایل‌های لینک‌خوردهٔ خارجی (مثلاً ویدیوها با مسیرهای نسبی) به‌طور خودکار کپی نمی‌شوند؛ اطمینان حاصل کنید مسیرهای ارجاع‌شده در دسترس باقی بمانند.

**آیا می‌توان متادیتای سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذخیره کرد؟**

بله. خصوصیات استاندارد [document properties](/slides/fa/net/presentation-properties/) پشتیبانی می‌شوند و هنگام ذخیره به فایل نوشته می‌شوند.