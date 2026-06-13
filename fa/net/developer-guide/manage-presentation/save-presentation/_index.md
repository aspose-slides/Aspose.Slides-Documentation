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
- پیشرفت ذخیره
- .NET
- C#
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌ها را در .NET با استفاده از Aspose.Slides ذخیره کنید—صادر به PowerPoint یا OpenDocument در حالی که طرح‌ها، قلم‌ها و افکت‌ها حفظ می‌شوند."
---
## **مروری کلی**

[Open Presentations in C#](/slides/fa/net/open-presentation/) نحوه استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) برای باز کردن یک ارائه را توضیح می‌دهد. این مقاله نحوه ایجاد و ذخیره ارائه‌ها را شرح می‌دهد. کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) محتوای ارائه را در خود دارد. چه از ابتدا یک ارائه بسازید و چه یک ارائه موجود را اصلاح کنید، پس از اتمام کار باید آن را ذخیره کنید. با Aspose.Slides برای .NET می‌توانید به یک **فایل** یا **جریان** ذخیره کنید. این مقاله روش‌های مختلف ذخیره یک ارائه را بیان می‌کند.

## **ذخیره ارائه‌ها در فایل‌ها**

یک ارائه را با فراخوانی متد `Save` کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) به یک فایل ذخیره کنید. نام فایل و قالب ذخیره را به متد پاس دهید. مثال زیر نحوه ذخیره یک ارائه با Aspose.Slides را نشان می‌دهد.

```cs
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
using (Presentation presentation = new Presentation())
{
    // کمی کار انجام دهید...

    // ارائه را در یک فایل ذخیره کنید.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **ذخیره ارائه‌ها در جریان‌ها**

می‌توانید یک ارائه را به یک جریان ذخیره کنید با پاس دادن یک جریان خروجی به متد `Save` کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/). یک ارائه می‌تواند به انواع مختلفی از جریان‌ها نوشته شود. در مثال زیر، یک ارائه جدید ایجاد می‌کنیم و آن را به یک جریان فایل ذخیره می‌کنیم.

```cs
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // ارائه را در جریان ذخیره کنید.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **ذخیره ارائه‌ها با نوع نمای پیش‌تعریف‌شده**

Aspose.Slides به شما امکان می‌دهد نمای اولیه‌ای که PowerPoint هنگام باز شدن ارائه تولید شده استفاده می‌کند، از طریق کلاس [ViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/) تنظیم کنید. خصوصیت [LastView](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/lastview/) را به مقداری از شمارش [ViewType](https://reference.aspose.com/slides/fa/net/aspose.slides/viewtype/) تنظیم کنید.

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **ذخیره ارائه‌ها در قالب Strict Office Open XML**

Aspose.Slides به شما امکان می‌دهد یک ارائه را در قالب Strict Office Open XML ذخیره کنید. هنگام ذخیره از کلاس [PptxOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pptxoptions/) استفاده کنید و خصوصیت conformance آن را تنظیم کنید. اگر مقدار `Conformance.Iso29500_2008_Strict` را تنظیم کنید، فایل خروجی در قالب Strict Office Open XML ذخیره می‌شود.

مثال زیر یک ارائه ایجاد کرده و آن را در قالب Strict Office Open XML ذخیره می‌کند.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
using (Presentation presentation = new Presentation())
{
    // ذخیره ارائه در قالب Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **ذخیره ارائه‌ها در قالب Office Open XML با حالت Zip64**

یک فایل Office Open XML یک آرشیو ZIP است که محدودیت ۴ گیگابایت (۲^۳۲ بایت) برای اندازهٔ غیر فشردهٔ هر فایل، اندازهٔ فشردهٔ هر فایل و کل اندازهٔ آرشیو اعمال می‌کند و همچنین تعداد فایل‌ها را به ۶۵٬۵۳۵ (۲^۱۶‑۱) محدود می‌سازد. افزونه‌های فرمت ZIP64 این محدودیت‌ها را به ۲^۶۴ افزایش می‌دهند.

خصوصیت [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ipptxoptions/zip64mode/) به شما اجازه می‌دهد وقتی یک فایل Office Open XML ذخیره می‌کنید، انتخاب کنید که چه زمانی از افزونه‌های فرمت ZIP64 استفاده شود.

این خصوصیت حالت‌های زیر را فراهم می‌کند:

- `IfNecessary` تنها در صورتی که ارائه از محدودیت‌های فوق تجاوز کند، از افزونه‌های ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- `Never` هرگز از افزونه‌های ZIP64 استفاده نمی‌کند.
- `Always` همیشه از افزونه‌های ZIP64 استفاده می‌کند.

کد زیر نحوه ذخیره یک ارائه به عنوان PPTX با فعال بودن افزونه‌های فرمت ZIP64 را نشان می‌دهد:

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
هنگامی که با `Zip64Mode.Never` ذخیره می‌کنید، اگر ارائه نتواند در قالب ZIP32 ذخیره شود، یک [PptxException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxexception/) پرتاب می‌شود.
{{% /alert %}}

## **ذخیره ارائه‌ها بدون به‌روزرسانی تصویر کوچک**

خصوصیت [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) تولید تصویر کوچک را هنگام ذخیره یک ارائه به PPTX کنترل می‌کند:

- اگر به `true` تنظیم شود، تصویر کوچک هنگام ذخیره به‌روزرسانی می‌شود. این حالت پیش‌فرض است.
- اگر به `false` تنظیم شود، تصویر کوچک فعلی حفظ می‌شود. اگر ارائه هیچ تصویر کوچکی نداشته باشد، هیچ‌کدام تولید نمی‌شود.

در کد زیر، ارائه بدون به‌روزرسانی تصویر کوچک‌اش به PPTX ذخیره می‌شود.

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
این گزینه به کاهش زمان مورد نیاز برای ذخیره یک ارائه در قالب PPTX کمک می‌کند.
{{% /alert %}}

## **به‌روزرسانی پیشرفت ذخیره به درصد**

اینترفیس [IProgressCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/iprogresscallback/) از طریق خصوصیت `ProgressCallback` که توسط اینترفیس [ISaveOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/isaveoptions/) و کلاس انتزاعی [SaveOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveoptions/) منتشر می‌شود، استفاده می‌شود. برای دریافت به‌روزرسانی‌های پیشرفت ذخیره به صورت درصد، یک پیاده‌سازی از [IProgressCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/iprogresscallback/) را به `ProgressCallback` انتساب دهید.

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
        // در اینجا از مقدار درصد پیشرفت استفاده کنید.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose یک برنامهٔ رایگان تقسیم‌کنندهٔ PowerPoint (PowerPoint Splitter) با استفاده از API خود توسعه داده است. این برنامه به شما امکان می‌دهد یک ارائه را به چندین فایل تقسیم کنید؛ اسلایدهای انتخاب‌شده را به عنوان فایل‌های جدید PPTX یا PPT ذخیره می‌کند.
{{% /alert %}}

## **سوالات متداول**

**آیا «ذخیره سریع» (ذخیره افزایشی) پشتیبانی می‌شود تا تنها تغییرات نوشته شوند؟**

خیر. هر بار ذخیره، تمام فایل هدف به‌صورت کامل ایجاد می‌شود؛ ذخیرهٔ افزایشی «ذخیره سریع» پشتیبانی نمی‌شود.

**آیا ذخیرهٔ یک نمونهٔ Presentation از چندین رشته (thread) به‌صورت ایمن است؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) [امن در چند رشته نیست](/slides/fa/net/multithreading/); آن را فقط از یک رشته ذخیره کنید.

**هنگام ذخیره، چه اتفاقی برای پیوندهای Hyperlink و فایل‌های مرتبط خارجی می‌افتد؟**

[Hyperlinks](/slides/fa/net/manage-hyperlinks/) حفظ می‌شوند. فایل‌های مرتبط خارجی (مثلاً ویدئوها با مسیرهای نسبی) به‌طور خودکار کپی نمی‌شوند—اطمینان حاصل کنید مسیرهای اشاره‌شده همچنان در دسترس باشند.

**آیا می‌توانم متادیتای سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذخیره کنم؟**

بله. [خصوصیات استاندارد سند](/slides/fa/net/presentation-properties/) پشتیبانی می‌شوند و هنگام ذخیره به فایل نوشته خواهند شد.