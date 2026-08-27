---
title: تبدیل ارائه‌های PowerPoint به Markdown در .NET
linktitle: PowerPoint به Markdown
type: docs
weight: 140
url: /fa/net/convert-powerpoint-to-markdown/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به MD
- ارائه به MD
- اسلاید به MD
- PPT به MD
- PPTX به MD
- ذخیره PowerPoint به صورت Markdown
- ذخیره ارائه به صورت Markdown
- ذخیره اسلاید به صورت Markdown
- ذخیره PPT به صورت MD
- ذخیره PPTX به صورت MD
- صادرات PPT به MD
- صادرات PPTX به MD
- صادرات تصویر Markdown
- پیوندهای تصویر CDN
- PowerPoint
- ارائه
- Markdown
- .NET
- C#
- Aspose.Slides
description: تبدیل ارائه‌های PPT و PPTX به Markdown در .NET و کنترل مکان ذخیره‌سازی و ارجاع تصاویر بیت‌مپ، متافایل و SVG صادر شده.
---
## **نمایش کلی**

Aspose.Slides برای .NET می‌تواند ارائه‌های PPT و PPTX را به Markdown برای مستندات، سایت‌های ایستا، مهاجرت محتوا و گردش‌های کنترل نسخه تبدیل کند. می‌توانید یک نوع Markdown را انتخاب کنید، نحوه رندر محتوای اسلایدها را کنترل کنید و محل ذخیره‌سازی تصاویر صادرشده و نحوه ارجاع آن‌ها در Markdown تولید شده را تعیین کنید.

به طور پیش‌فرض، خروجی Markdown فقط متن است. برای خروجی محتوی بصری، ویژگی [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions/exporttype/) را به مقدار `Sequential` یا `Visual` از شمارش‌نامه [MarkdownExportType](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownexporttype/) تنظیم کنید. `Sequential` موارد اسلاید را به‌صورت جداگانه و به ترتیب رندر می‌کند، در حالی که `Visual` عناصر گروه‌بندی‌شده را کنار هم نگه می‌دارد تا رابطه بصری آن‌ها حفظ شود. مقدار `TextOnly` منابع تصویر را صادر نمی‌کند، بنابراین رویدادهای ذخیره‌سازی تصویر در این حالت فراخوانی نمی‌شوند.

## **تبدیل یک ارائه به Markdown**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بارگذاری کنید، سپس متد [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) را با مقدار `Md` از شمارش‌نامه [SaveFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) فراخوانی کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **انتخاب یک نوع Markdown**

ویژگی [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions/flavor/) مشخص می‌کند که کدام مشخصات Markdown برای خروجی استفاده شود. شمارش‌نامه [Flavor](https://reference.aspose.com/slides/fa/net/aspose.slides.export/flavor/) شامل CommonMark، GitHub Flavored Markdown و سایر انواع پشتیبانی‌شده است.

مثال زیر یک ارائه را به عنوان CommonMark صادر می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **صدور تصاویر با رفتار پیش‌فرض ذخیره‌سازی محلی**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions/) دو ویژگی برای تصاویر ذخیره‌شده به‌صورت محلی ارائه می‌دهد:

- [BasePath](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions/basepath/) مسیر پایه برای سند Markdown و منابع آن را مشخص می‌کند.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) زیرپوشهٔ تصاویر را تعیین می‌کند. مقدار پیش‌فرض آن `Images` است.

مثال زیر محتوی بصری را رندر می‌کند، تصاویر را در `output/assets` می‌نویسد و ارجاع‌های نسبی تصویر را در سند Markdown ایجاد می‌کند:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

این رفتار همچنین به‌عنوان بازگشت‌پذیری عمل می‌کند وقتی یک پردازش‌گر سفارشی ذخیره تصویر مقدار `false` برگرداند.

## **سفارشی‌سازی ذخیره‌سازی تصویر و پیوندهای Markdown**

از رویداد [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions/imagesaving/) برای منابع بیت‌مپ و متافایل غیر SVG که هنگام صدور Markdown تولید می‌شوند استفاده کنید. واگذار کنندهٔ [MarkdownImageSavingHandler](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) یک شیٔ [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) ، [ImageFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/imageformat/) مربوطه و پیوند Markdown تولید شده به‌عنوان پارامتر `ref string` دریافت می‌کند. تصویر را با فرمت ارائه‌شده ذخیره یا بارگذاری کنید و مقدار `link` را با مرجعی که باید در خروجی Markdown ظاهر شود، جایگزین کنید.

منابع صادرشده با فرمت SVG به‌طور جداگانه مدیریت می‌شوند. به رویداد [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) مشترک شوید؛ واگذار کنندهٔ [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) یک شیٔ [ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/) و پارامتر `ref string link` را دریافت می‌کند. یک SVG آرگومان `ImageFormat` ندارد؛ به‌جای آن داده‌های XML آن را از ویژگی [ISvgImage.SvgData](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/svgdata/) بنویسید یا بارگذاری کنید. بسته به حالت صدور و گروه‌بندی بصری، یک SVG در ارائه منبع ممکن است رستر شود یا با محتوای دیگر ترکیب شود؛ منبع غیر SVG حاصل سپس به `ImageSaving` پاس داده می‌شود. زمانی که هر منبع بصری صادرشده نیاز به پردازش سفارشی دارد، هر دو رویداد را مشترک کنید.

مقدار برگشتی پردازش‌گر تعیین می‌کند که چه کسی تصویر را پردازش می‌کند:

- مقدار `true` را برگردانید پس از این که پردازش‌گر تصویر را ذخیره، بارگذاری، تبدیل یا به‌هر شکل دیگری پردازش کرده و مقدار معتبری به `link` اختصاص دهد. Aspose.Slides آن مقدار را در سند Markdown می‌نویسد و ذخیره‌سازی محلی پیش‌فرض را انجام نمی‌دهد.
- مقدار `false` را برگردانید تا Aspose.Slides تصویر را به‌صورت محلی ذخیره کند و پیوند آن را بر اساس [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions/basepath/) و [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) تولید کند.

{{% alert color="warning" title="مهم" %}}
یک پردازش‌گر که مقدار `true` برمی‌گرداند، مسئولیت تصویر را برعهده می‌گیرد. اگر بدون اختصاص یک پیوند معتبر و غیرخالی مقدار `true` را برگرداند، صدور با یک `InvalidOperationException` شکست می‌خورد.
{{% /alert %}}

### **ذخیره تصاویر در یک دایرکتوری منبع CDN و استفاده از URLهای خارجی**

مثال زیر `cdn-origin/presentations/quarterly-report` را به‌عنوان یک دایرکتوری منبع CDN سوار یا همگام‌شده در نظر می‌گیرد. هر پردازش‌گر نام فایل تولیدشده را استخراج می‌کند، تصویر را در آن دایرکتوری سفارشی ذخیره می‌کند و مرجع محلی تولیدشده را با یک URL عمومی CDN جایگزین می‌کند. خود نمونه هیچ بارگذاری شبکه‌ای انجام نمی‌دهد: URL فقط پس از سوار شدن دایرکتوری به‌عنوان منبع CDN یا انتشار فایل‌ها به CDN معتبر می‌شود. برای ذخیره‌سازی شیء، عملیات نوشتن فایل‑سیستم را با عملیات بارگذاری SDK ذخیره‌سازی جایگزین کنید و `link` را تنها پس از موفقیت‌آمیز شدن بارگذاری اختصاص دهید.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

پردازش‌گر بیت‌مپ به‌صورت عمدی برای تصاویر کوچکتر از 128 × 128 پیکسل مقدار `false` باز می‌گرداند، بنابراین Aspose.Slides این تصاویر را در `output/fallback-images` با استفاده از رفتار پیش‌فرض ذخیره می‌کند. منابع بیت‌مپ و متافایل بزرگ‌تر، همانند منابع SVG، توسط کد سفارشی پردازش می‌شوند. برای مثال، یک مرجع محلی تولیدشده مانند `fallback-images/image1.png` به `https://cdn.example.com/presentations/quarterly-report/image1.png` تبدیل می‌شود. پردازش‌گرها فقط هنگام نوشتن فایل‌ها از مسیرهای سیستم‌عامل استفاده می‌کنند؛ پیوندهای نوشته‌شده در Markdown از اسلش‌های مستقیم و نام‌های فایل بر رمزگذاری URL استفاده می‌کنند. همان قانون را هنگام ساخت پیوندهای نسبی اعمال کنید: از `/` استفاده کنید، نه جداکنندهٔ مسیر مخصوص به پلتفرم.

## **سوالات متداول**

**آیا یک پردازش‌گر می‌تواند هم تصاویر رستری و هم تصاویر SVG را پردازش کند؟**

خیر. برای منابع بیت‌مپ و متافایل صادرشده از [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions/imagesaving/) استفاده کنید و برای منابع صادرشده به‌صورت SVG از [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) استفاده کنید. اولین مورد یک شیٔ [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) و یک [ImageFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/imageformat/) ارائه می‌دهد؛ مورد دوم یک شیٔ [ISvgImage](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/) که دادهٔ SVG آن را می‌توانید از [ISvgImage.SvgData](https://reference.aspose.com/slides/fa/net/aspose.slides/isvgimage/svgdata/) بخوانید. یک SVG منبع که در حین صدور رستر شود، توسط `ImageSaving` پردازش می‌شود.

**چه اتفاقی می‌افتد وقتی یک پردازش‌گر ذخیره تصویر مقدار `false` برمی‌گرداند؟**

Aspose.Slides از رفتار پیش‌فرض ذخیره‌سازی محلی استفاده می‌کند. مکان تصویر و مرجع تولیدشده توسط [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions/basepath/) و [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/fa/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) کنترل می‌شود.

**آیا یک پردازش‌گر می‌تواند URL ارائه دهد بدون اینکه تصویر را به‌صورت محلی ذخیره کند؟**

بله. پردازش‌گر می‌تواند تصویر را به ذخیره‌ساز شیء بارگذاری کند یا به سرویس دیگری بفرستد، URL حاصل را به `link` اختصاص دهد و مقدار `true` بازگرداند. پردازش‌گر باید خود پردازش را کامل کند؛ بازگرداندن `true` ذخیره‌سازی محلی پیش‌فرض را جلوگیری می‌کند.

**چرا خروجی Markdown از یک پردازش‌گر `InvalidOperationException` می‌دهد؟**

این استثنا زمانی رخ می‌دهد که پردازش‌گر مقدار `true` برگرداند ولی پیوند معتبری فراهم نکند. قبل از بازگرداندن `true` مسیر نسبی یا URL خارجی که باید در Markdown نوشته شود را اختصاص دهید.

**کدام جداکننده مسیر باید در پیوندهای تصویر استفاده شود؟**

در پیوندهای Markdown و URLها از اسلش‌های مستقیم (`/`) استفاده کنید. برای مسیرهای فایل‌سیستم از `Path.Combine` استفاده کنید و سپس مرجع Markdown را جداگانه بسازید یا نرمال کنید.

**آیا لینک‌های ابرمتنی در خروجی Markdown حفظ می‌شوند؟**

بله. متن [hyperlinks](/slides/fa/net/manage-hyperlinks/) به‌صورت پیوندهای استاندارد Markdown حفظ می‌شود. [transitions](/slides/fa/net/slide-transition/) و [animations](/slides/fa/net/powerpoint-animation/) اسلایدها تبدیل نمی‌شوند.

**آیا می‌توان ارائه‌ها را به‌صورت موازی به Markdown تبدیل کرد؟**

می‌توانید فایل‌های ارائه مختلف را به‌صورت موازی پردازش کنید، اما نباید همان شیٔ [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) را بین رشته‌ها به اشتراک بگذارید. guidelines مربوط به [multithreading](/slides/fa/net/multithreading/) را دنبال کنید و برای هر فایل یک نمونه جداگانه استفاده کنید.