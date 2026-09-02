---
title: ذخیرهٔ ارائه‌ها در .NET
linktitle: ذخیرهٔ ارائه
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
- فرمت Strict Office Open XML
- حالت Zip64
- به‌روزرسانی تصویر بندانگشتی
- پیشرفت ذخیره‌سازی
- .NET
- C#
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌ها را در .NET با استفاده از Aspose.Slides ذخیره کنید—به PowerPoint یا OpenDocument صادر کنید در حالی که طرح‌ها، فونت‌ها و جلوه‌ها حفظ می‌شوند."
---
## **نمایش کلی**

[باز کردن ارائه‌ها در C#](/slides/fa/net/open-presentation/) نحوه استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) را برای باز کردن یک ارائه توضیح داد. این مقاله نحوه ایجاد و ذخیرهٔ ارائه‌ها را بیان می‌کند. کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) شامل محتوای یک ارائه است. چه از ابتدا یک ارائه ایجاد کنید و چه یک ارائه موجود را ویرایش کنید، پس از اتمام کار می‌خواهید آن را ذخیره کنید. با Aspose.Slides برای .NET می‌توانید به **فایل** یا **جریان** (stream) ذخیره کنید. این مقاله روش‌های مختلف ذخیرهٔ یک ارائه را شرح می‌دهد.

## **ذخیرهٔ ارائه‌ها در فایل‌ها**

یک ارائه را با فراخوانی متد `Save` کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) در یک فایل ذخیره کنید. نام فایل و فرمت ذخیره را به متد پاس بدهید. مثال زیر نشان می‌دهد چگونه یک ارائه را با Aspose.Slides ذخیره کنید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
using (Presentation presentation = new Presentation())
{
    // در اینجا کارهایی انجام دهید...
    
    // ارائه را در یک فایل ذخیره می‌کند.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **ذخیرهٔ ارائه‌ها در جریان‌ها**

می‌توانید یک ارائه را با ارسال یک جریان خروجی به متد `Save` کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) در یک جریان ذخیره کنید. ارائه می‌تواند به انواع مختلفی از جریان‌ها نوشته شود. در مثال زیر، یک ارائهٔ جدید ایجاد می‌کنیم و آن را در یک فایل‌استریم ذخیره می‌کنیم.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // ارائه را در جریان ذخیره می‌کند.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **ذخیرهٔ ارائه‌ها با نوع نمای پیش‌تعریف‌شده**

Aspose.Slides به شما اجازه می‌دهد نمای اولیهٔ مورد استفادهٔ PowerPoint هنگام باز شدن ارائهٔ تولیدی را از طریق کلاس [ViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/) تنظیم کنید. ویژگی [LastView](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/lastview/) را به مقداری از شمارش‌گر [ViewType](https://reference.aspose.com/slides/fa/net/aspose.slides/viewtype/) اختصاص دهید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **ذخیرهٔ ارائه‌ها در قالب Strict Office Open XML**

Aspose.Slides به شما اجازه می‌دهد یک ارائه را در قالب Strict Office Open XML ذخیره کنید. از کلاس [PptxOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pptxoptions/) استفاده کنید و هنگام ذخیره ویژگی conformance آن را تنظیم کنید. اگر `Conformance.Iso29500_2008_Strict` را تنظیم کنید، فایل خروجی در قالب Strict Office Open XML ذخیره می‌شود.

مثال زیر یک ارائه ایجاد می‌کند و آن را در قالب Strict Office Open XML ذخیره می‌کند.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
using (Presentation presentation = new Presentation())
{
    // ارائه را در قالب Strict Office Open XML ذخیره می‌کند.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **ذخیرهٔ ارائه‌ها در قالب Office Open XML در حالت Zip64**

یک فایل Office Open XML یک آرشیو ZIP است که محدودیت ۴ گیگابایت (۲^۳۲ بایت) برای اندازهٔ فشرده‌نشدهٔ هر فایل، اندازهٔ فشردهٔ هر فایل و کل آرشیو اعمال می‌کند و همچنین‌ تعداد فایل‌های آرشیو را به ۶۵،۵۳۵ (۲^۱۶‑۱) محدود می‌سازد. افزونه‌های فرمت ZIP64 این محدودیت‌ها را به ۲^۶۴ افزایش می‌دهند.

ویژگی [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ipptxoptions/zip64mode/) به شما امکان می‌دهد زمان استفاده از افزونه‌های فرمت ZIP64 را هنگام ذخیرهٔ یک فایل Office Open XML انتخاب کنید.

این ویژگی حالت‌های زیر را فراهم می‌کند:

- `IfNecessary` فقط در صورتی که ارائه محدودیت‌های فوق را تجاوز کند، از افزونه‌های ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- `Never` هرگز از افزونه‌های ZIP64 استفاده نمی‌کند.
- `Always` همیشه از افزونه‌های ZIP64 استفاده می‌کند.

کد زیر نشان می‌دهد چگونه یک ارائه را به‌عنوان فایل PPTX با فعال‌سازی افزونه‌های فرمت ZIP64 ذخیره کنید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
هنگامی که با `Zip64Mode.Never` ذخیره می‌کنید، اگر ارائه نتواند در قالب ZIP32 ذخیره شود، یک [PptxException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxexception/) پرتاب می‌شود.
{{% /alert %}}

## **ذخیرهٔ ارائه‌ها در قالب Office Open XML با سطوح فشرده‌سازی**

هنگام کار با ارائه‌های بزرگ می‌توانید سطح فشرده‌سازی را تنظیم کنید تا تعادل بین اندازهٔ فایل و زمان پردازش برقرار شود. بسته به نیازهای شما ممکن است پردازش سریع‌تر یا فایل‌های خروجی کوچکتر را ترجیح دهید.

Aspose.Slides ویژگی [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ipptxoptions/compressionlevel/) را فراهم می‌کند که به شما امکان می‌دهد سطح فشرده‌سازی مورد استفاده هنگام ذخیرهٔ یک ارائه در قالب Office Open XML را مشخص کنید.

سطوح فشرده‌سازی موجود عبارتند از:

- **None**: هیچ فشرده‌سازی اعمال نمی‌شود. فایل‌ها همان‌طور ذخیره می‌شوند.
- **Level1**: سریع‌ترین فشرده‌سازی با کمترین نسبت فشرده‌سازی.
- **Level2**: فشرده‌سازی سریع‌تر با نسبت فشرده‌سازی کمی بهتر نسبت به **Level1**.
- **Level3**: فشرده‌سازی بهتر نسبت به **Level2** با تأثیر متوسط بر زمان پردازش.
- **Level4**: فشرده‌گذاری بهتر نسبت به **Level3**.
- **Level5**: بهبود فشرده‌سازی نسبت به **Level4** با زمان پردازش اضافی.
- **Level6**: فشرده‌سازی استاندارد که تعادل خوبی بین سرعت پردازش و اندازهٔ فایل ارائه می‌دهد. این **سطح فشرده‌سازی پیش‌فرض** است.
- **Level7**: فشرده‌گذاری بهتر نسبت به **Level6** با پردازش آهسته‌تر.
- **Level8**: فشرده‌گذاری بهتر نسبت به **Level7**.
- **Level9**: حداکثر فشرده‌سازی. کوچک‌ترین اندازهٔ فایل را تولید می‌کند که هزینهٔ زمان پردازش طولانی‌تری دارد.

مثال زیر نشان می‌دهد چگونه یک ارائه را به‌عنوان فایل PPTX *بدون فشرده‌سازی* ذخیره کنید:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

این مثال نشان می‌دهد چگونه یک ارائه را به‌عنوان فایل PPTX با *حداکثر فشرده‌سازی* ذخیره کنید:
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **ذخیرهٔ ارائه‌ها بدون به‌روزرسانی تصویر بندانگشتی**

ویژگی [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) کنترل می‌کند که آیا تصویر بندانگشتی هنگام ذخیرهٔ ارائه به PPTX تازه سازی شود یا خیر:

- اگر `true` باشد، تصویر بندانگشتی در هنگام ذخیره تازه سازی می‌شود. این مقدار پیش‌فرض است.
- اگر `false` باشد، تصویر بندانگشتی فعلی حفظ می‌شود. اگر ارائه هیچ تصویر بندانگشتی نداشته باشد، هیچ تصویری تولید نمی‌شود.

در کد زیر، ارائه بدون به‌روزرسانی تصویر بندانگشتی به PPTX ذخیره می‌شود.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
این گزینه به کاهش زمان مورد نیاز برای ذخیرهٔ یک ارائه در قالب PPTX کمک می‌کند.
{{% /alert %}}

## **دریافت به‌روزرسانی پیشرفت ذخیره به صورت درصدی**

اینترفیس [IProgressCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/iprogresscallback/) از طریق ویژگی `ProgressCallback` که توسط اینترفیس [ISaveOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/isaveoptions/) و کلاس انتزاعی [SaveOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveoptions/) ارائه می‌شود، مورد استفاده قرار می‌گیرد. یک پیاده‌سازی از [IProgressCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/iprogresscallback/) را به `ProgressCallback` اختصاص دهید تا به‌روزرسانی‌های پیشرفت ذخیره به صورت درصدی دریافت کنید.

کدهای زیر نشان می‌دهند چگونه از `IProgressCallback` استفاده کنید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

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
Aspose یک برنامهٔ رایگان **PowerPoint Splitter** (https://products.aspose.app/slides/fa/splitter) با استفاده از API خود توسعه داده است. این برنامه به شما امکان می‌دهد یک ارائه را به چندین فایل تقسیم کنید و اسلایدهای انتخاب‌شده را به‌صورت فایل‌های جدید PPTX یا PPT ذخیره کنید.
{{% /alert %}}

## **سؤالات متداول**

**آیا «ذخیرهٔ سریع» (ذخیرهٔ افزایشی) پشتیبانی می‌شود تا تنها تغییرات نوشته شوند؟**

خیر. هر بار ذخیره، فایل هدف کامل ایجاد می‌شود؛ «ذخیرهٔ سریع» افزایشی پشتیبانی نمی‌شود.

**آیا ذخیرهٔ یک شیء Presentation از چندین رشته همزمان ایمن است؟**

خیر. شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) **thread‑safe** نیست؛ آن را فقط از یک رشته ذخیره کنید.

**هنگام ذخیره چه اتفاقی برایهایپ لینک‌ها و فایل‌های لینک‌خوردهٔ خارجی می‌افتد؟**

[هایپرلینک‌ها](/slides/fa/net/manage-hyperlinks/) حفظ می‌شوند. فایل‌های لینک‌خوردهٔ خارجی (مانند ویدئوها با مسیرهای نسبی) به‌صورت خودکار کپی نمی‌شوند؛ اطمینان حاصل کنید مسیرهای اشاره‌شده قابل دسترسی باقی بمانند.

**آیا می‌توان متادیتای سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذخیره کرد؟**

بله. خصوصیات استاندارد سند [/slides/fa/net/presentation-properties/] پشتیبانی می‌شوند و هنگام ذخیره در فایل نوشته می‌شوند.