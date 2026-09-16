---
title: صادرات ارائه‌ها به XAML در .NET
linktitle: ارائه به XAML
type: docs
weight: 30
url: /fa/net/export-to-xaml/
keywords:
- صادرات PowerPoint
- صادرات OpenDocument
- صادرات ارائه
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- PowerPoint به XAML
- OpenDocument به XAML
- ارائه به XAML
- PPT به XAML
- PPTX به XAML
- ODP به XAML
- ذخیره PPT به عنوان XAML
- ذخیره PPTX به عنوان XAML
- ذخیره ODP به عنوان XAML
- صادرات PPT به XAML
- صادرات PPTX به XAML
- صادرات ODP به XAML
- .NET
- C#
- Aspose.Slides
description: "PowerPoint و اسلایدهای OpenDocument را به XAML در .NET با استفاده از Aspose.Slides تبدیل کنید—راه‌حل سریع و بدون Office که چینش شما را دست‌نخورده نگه می‌دارد."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به XAML صادر کنیم. شامل مقدمه‌ای کوتاه درباره XAML است، نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML ذخیره کنیم، و نشان می‌دهد چگونه صادرات را از طریق [XamlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/xamloptions/) سفارشی کنیم، از جمله صدور اسلایدهای پنهان. همچنین به چند سؤال رایج مرتبط با فونت‌های جایگزین، سازگاری پشته XAML و رفتار صدور اسلایدهای پنهان پاسخ می‌دهد.

## **درباره XAML**

XAML یک زبان نشانه‌گذاری مبتنی بر XML است که برای توصیف رابط‌های کاربری در چارچوب‌هایی مانند WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin.Forms استفاده می‌شود.

می‌توانید با فایل‌های XAML در یک طراح بصری کار کنید یا نشانه‌گذاری را به‌صورت مستقیم بنویسید و ویرایش کنید.

## **صادرات ارائه‌ها به XAML با گزینه‌های پیش‌فرض**

مثال C# زیر نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML صادر کنیم:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

به‌طور پیش‌فرض، اسلایدهای صادرشده در زیر پوشه `pres` از دایرکتوری کاری فعلی فرآیند ذخیره می‌شوند، همان‌طور که [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory) برمی‌گرداند. این پوشه به‌صورت خودکار ایجاد می‌شود و هر تصویری که نیاز باشد نیز در همانجا ذخیره می‌گردد.

نام پوشه خروجی از نام فایل منبع بدون پسوند آن گرفته می‌شود. برای `pres.pptx`, فایل‌های خروجی به صورت `pres/Slide_1.xaml`، `pres/Slide_2.xaml` و به همین ترتیب نام‌گذاری می‌شوند. حتی اگر مسیر مطلقی به ارائه ورودی بدهید، پوشه خروجی به‌صورت نسبی نسبت به دایرکتوری کاری فعلی ایجاد می‌شود و نه در کنار فایل ورودی.

## **صادرات ارائه‌ها به XAML با گزینه‌های سفارشی**

از رابط [IXamlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/ixamloptions/) برای کنترل نحوهٔ صادرات یک ارائه توسط Aspose.Slides به XAML استفاده کنید.

برای ذخیرهٔ خروجی در یک مکان سفارشی، [IXamlOutputSaver](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/ixamloutputsaver/) را پیاده‌سازی کنید و یک نمونه از پیاده‌سازی خود را به ویژگی [OutputSaver](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/xamloptions/outputsaver/) از [XamlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/xamloptions/) اختصاص دهید.

برای شامل کردن اسلایدهای پنهان در خروجی XAML، ویژگی [ExportHiddenSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) را به `true` تنظیم کنید، همان‌طور که در مثال C# زیر نشان داده شده است:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **ضبط تمام Artefacts تولید شدهٔ XAML**

یک صادرات XAML می‌تواند برای هر اسلاید صادرشده یک سند XAML به‌اضافه تصاویر جداگانه و منابع پشتیبانی ایجاد کند. برای دریافت این Artefacts به‌جای استفاده از ذخیره‌ساز پیش‌فرض سیستم فایل، یک [IXamlOutputSaver](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/ixamloutputsaver/) سفارشی به [XamlOptions.OutputSaver](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/xamloptions/outputsaver/) اختصاص دهید. صادرات را با overload مخصوص XAML از [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) که گزینه‌های XAML را می‌پذیرد، آغاز کنید.

### **درک چرخهٔ حیات Callback**

صادرکننده برای هر Artefact تولید شده به‌صورت جداگانه متد [IXamlOutputSaver.Save](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/ixamloutputsaver/save/) را فراخوانی می‌کند:

- `path` شناسایی‌کنندهٔ Artefact است و ممکن است شامل مسیرهای نسبی باشد. این اطلاعات را نگه دارید زیرا XAML ممکن است منابع را با مسیرهای نسبی ارجاع دهد.
- `data` حاوی بایت‌های Artefact است. تصاویر و سایر منابع باینری نباید به‌عنوان متن رمزگشایی شوند.
- ذخیره‌ساز مسئول نگهداری یا ماندگاری داده‌ها قبل از بازگشت است. مثال‌ها هر آرایهٔ بایت را به حافظهٔ متعلق به برنامه کپی می‌کنند.
- صادرات را تنها زمانی موفق در نظر بگیرید که عملیات ذخیرهٔ ارائه بازگردد و همهٔ Callbackها با موفقیت تکمیل شوند. خطاهای ذخیره‌سازی را نادیده نگیرید و نوشتن‌های پس‌زمینهٔ بدون نظارت را شروع نکنید. اگر ماندگاری پس از آن انجام شود، موفقیت کلی را فقط پس از موفقیت آن مرحله گزارش کنید.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) همچنین برای یک ذخیره‌ساز سفارشی اعمال می‌شود. مقدار پیش‌فرض آن `false` اسناد XAML اسلایدهای پنهان را حذف می‌کند. تنظیم آن به `true` این اسناد و هر منبع مورد نیاز برای صادرات آنها را شامل می‌شود. تعداد منابع بستگی به ارائه دارد؛ فرض نکنید که یک Callback برای هر اسلاید یا ترتیب ثابت Callback وجود دارد.

### **صادرات به حافظه و بررسی Artefacts**

این مثال کامل `pres.pptx` را بارگذاری می‌کند، هر Artefact را در یک [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) جمع‌آوری می‌نماید و نام، نوع و تعداد بایت آن را چاپ می‌کند. نام‌های ارائه‌شده را دقیقاً حفظ می‌کند. نام‌های تکراری باعث شکست جمع‌آوری می‌شوند به‌جای بازنویسی ساکت Artefact.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // فقط XAML را رمزگشایی کنید و فقط زمانی که نیاز به بازرسی متنی باشد.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

متد `InMemoryXamlExample.Run` را از برنامهٔ خود فراخوانی کنید. بررسی پسوندها برای بازرسی مفید است؛ تمام Artefacts شامل انواع منبع ناآشنا را نگه دارید. هنگام ذخیره یا انتقال بایت‌ها، آن‌ها را تغییر ندهید. برای XAMLی که نیاز به پردازش متنی دارد، فقط از [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) استفاده کنید.

### **بسته‌بندی Artefacts جمع‌آوری‌شده در یک آرشیو ZIP**

این مثال مستقل، صادرات را جمع‌آوری می‌کند، نام‌ها را اعتبارسنجی می‌نماید و بایت‌های اصلی را در یک آرشیو ZIP می‌نویسد. یک نام آرشیو منحصر به فرد، کارهای صادراتی همزمان را جدا می‌کند. ورودی‌های ZIP از اسلش‌های پیش‌رو استفاده می‌کنند و مسیرهای نسبی را حفظ می‌کنند. نام‌های ناامن یا نام‌هایی که پس از نرمال‌سازی با هم تداخل دارند، کل بسته را پیش از نوشتن رد می‌کنند.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // دایرکتوری ZIP قبل از گزارش موفقیت توسط تخلیه نهایی شده است.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

متد `ZipXamlExample.Run` را از برنامهٔ خود فراخوانی کنید. این مثال از [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) برای نوشتن یک آرشیو محلی استفاده می‌کند؛ خود صادرکننده فایل‌های XAML یا تصویر منفردی نمی‌نویسد. برای ذخیره‌سازی از راه دور، مرحلهٔ نوشتن آرشیو را با بارگذاری آرایه‌های بایت جمع‌آوری‌شده جایگزین کنید. از شناسهٔ کار صادرات به‌همراه نام کامل نسبی Artefact به‌عنوان کلید Blob استفاده کنید، یا شناسهٔ کار، نام نسبی و دادهٔ باینری را در یک ردیف دیتابیس ذخیره کنید. کار را تنها پس از تکمیل تمام بارگذاری‌ها یا commit تراکنش دیتابیس منتشر کنید. در صورت شکست ماندگاری، خروجی جزئی را پاک کنید.

برای ارائه‌های بزرگ، یک ذخیره‌ساز سفارشی می‌تواند هر Artefact را مستقیماً در ذخیره‌سازی برنامه نگهداری کند تا از نگهداری یک نسخهٔ اضافی از کل صادرات در حافظه برنامه جلوگیری شود. صادرکننده همچنان تمام Artefactهای تولیدشده را در حافظه جمع‌آوری می‌کند قبل از فراخوانی ذخیره‌ساز. هر Callback را از منظر صادرکننده به‌صورت همزمان نگه دارید: فقط پس از پذیرش بایت‌ها توسط مقصد بازگردید و اجازه دهید خطاها به فراخواننده برسند.

### **حفظ نام‌های منابع و تأیید ارجاعات**

- در صورت نیاز مقصد، جداکننده‌های مسیر را نرمال‌سازی کنید، اما مسیرهای نسبی را حفظ کنید. مگر این‌که هر نام تولید شده مطمئناً منحصربه‌فرد باشد و ارجاعات به منابع معتبر بمانند، از [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) به‌تنهایی استفاده نکنید.
- اعتبارسنجی نام مخصوص مقصد را اعمال کنید. هنگام نوشتن فایل‌های منفرد، مسیرهای ریشه‌ای و بخش‌های پیمایشی را رد کنید، مقصد را با [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) حل کنید و اطمینان حاصل کنید که زیر شاخهٔ مقصد export قرار دارد، شامل جداکنندهٔ مسیر در بررسی حاوی بودن. از یک دایرکتوری تحت کنترل برنامه استفاده کنید که لینک‌های نمادین ندارند که ممکن است نوشتار را تغییر مسیر دهند.
- برای هر کار صادرات، یک ذخیره‌ساز و فضای نام ذخیره‌سازی جداگانه استفاده کنید. پس از نرمال‌سازی جداکننده‌ها و مطابق با قوانین حساس به حروف مقصد، تداخل‌ها را شناسایی کنید.
- قبل از انتشار، هر سند XAML را به‌عنوان XML تجزیه کنید و ارجاعات به منابع مبتنی بر فایل آن را بررسی کنید، مانند ویژگی‌های `Source` یا `ImageSource` تصویر. هر URI نسبی را نسبت به دایرکتوری Artefact XAML حامل حل کنید، نام ذخیره‌سازی حاصل را نرمال‌سازی کنید و تأیید کنید که کلید مربوط به Dictionary، ورودی ZIP یا شیء ذخیره‌شده وجود دارد. URIهای خارجی و عبارات علامت‌گذاری XAML را جدا از نام‌های فایل نسبی مدیریت کنید.

به‌عنوان مثال، اگر `pres/Slide_1.xaml` به `images/image1.png` ارجاع دهد، منبع ذخیره‌شده باید به‌صورت `pres/images/image1.png` در دسترس باشد. نگه داشتن فقط `image1.png` آن رابطه را خراب می‌کند. برای ذخیره‌سازی شیء، همان ساختار را زیر پیشوند کار حفظ کنید و این URLهای منابع را برای مصرف‌کننده XAML دسترس‌پذیر کنید. ZIP تکمیل‌شده را باز کنید تا نام ورودی‌ها و بایت‌های منبع را تأیید کنید و اسلایدهای نمونه را در محیط هدف XAML بارگذاری کنید تا تأیید شود که تصاویر به‌درستی حل می‌شوند.

## **سوالات متداول**

**چگونه می‌توانم فونت‌های پیش‌بینی‌پذیر را تضمین کنم اگر فونت اصلی در دستگاه موجود نباشد؟**

در [XamlOptions]، ویژگی [DefaultRegularFont](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveoptions/defaultregularfont/) را تنظیم کنید — این فونت به‌عنوان فونت جایگزین در زمان صادرات زمانی که فونت اصلی موجود نباشد، استفاده می‌شود. این تضمین نمی‌کند که XAML تولیدشده به فونت جایگزین ارجاع دهد یا اینکه فونت در دستگاه هدف موجود باشد. اطمینان حاصل کنید که فونت‌های ارجاع‌شده توسط XAML در محیطی که نمایش داده می‌شود، موجود هستند.

**آیا XAML صادرشده فقط برای WPF منظور شده است یا می‌توان آن را در سایر پشته‌های XAML نیز استفاده کرد؟**

Aspose.Slides XAML WPF را از طریق API عمومی خود صادر می‌کند. سازگاری با سایر پشته‌های XAML مانند UWP و Xamarin.Forms تضمین نشده است. نشانه‌گذاری تولیدشده را در محیط هدف خود آزمایش کنید.

**آیا اسلایدهای پنهان پشتیبانی می‌شوند و چگونه می‌توانم از صدور پیش‌فرض آنها جلوگیری کنم؟**

به‌طور پیش‌فرض، اسلایدهای پنهان گنجانده نمی‌شوند. می‌توانید این رفتار را از طریق [ExportHiddenSlides] در [XamlOptions] کنترل کنید — اگر نیازی به صادر کردن آنها ندارید، این ویژگی را غیرفعال نگه دارید.