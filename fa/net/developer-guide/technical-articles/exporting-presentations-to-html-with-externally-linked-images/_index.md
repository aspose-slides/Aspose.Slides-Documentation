---
title: "صادرات ارائه‌ها به HTML با تصاویر پیوندی خارجی"
type: docs
weight: 100
url: /fa/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- "صادرات PowerPoint"
- "صادرات OpenDocument"
- "صادرات ارائه"
- "صادرات اسلاید"
- "صادرات PPT"
- "صادرات PPTX"
- "صادرات ODP"
- "PowerPoint به HTML"
- "OpenDocument به HTML"
- "ارائه به HTML"
- "اسلاید به HTML"
- "PPT به HTML"
- "PPTX به HTML"
- "ODP به HTML"
- "تصویر پیوندی"
- "تصویر پیوندی خارجی"
- "منبع پیوندی"
- "منبع خارجی"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML در .NET با استفاده از Aspose.Slides به‌طوری که تصاویر و سایر منابع به‌صورت فایل‌های پیوندی خارجی ذخیره شوند."
---
## **نمای کلی**

به‌طور پیش‌فرض، Aspose.Slides یک ارائه را به یک فایل HTML مستقل صادر می‌کند. تصاویر و سایر منابع مستقیماً داخل HTML نوشته می‌شوند، معمولاً به‌صورت داده‌های Base64. این روش زمانی که نیاز به یک فایل قابل حمل دارید مفید است، اما همیشه بهترین قالب برای یک وب‌سایت، CMS یا خط لوله تبدیل سمت سرور نیست.

از منابع پیوندی خارجی زمانی استفاده کنید که بخواهید:

- اندازه سند HTML را کاهش دهید;
- تصاویر، فونت‌ها، صدا یا ویدیو را به‌صورت جداگانه در مرورگر یا CDN کش کنید;
- پس از صادرات، منابع تولید شده را بررسی، جایگزین، فشرده یا پس‌پردازش کنید;
- ساختار خروجی را به‌آنچه یک برنامه وب انتظار دارد نزدیک‌تر کنید.

برای فرآیند کلی تبدیل HTML، به [تبدیل ارائه‌های PowerPoint به HTML](/slides/fa/net/convert-powerpoint-to-html/) مراجعه کنید. این مقاله به بخش پیوند منابع صادرات می‌پردازد.

## **نحوه کار صادرات منابع پیوندی**

[ILinkEmbedController](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ilinkembedcontroller/) به برنامهٔ شما امکان می‌دهد به‌صورت منبع به منبع تصمیم بگیرید که آیا صادرکننده داده را در HTML جاسازی کند یا به‌صورت خارجی ذخیره کرده و پیوندی بنویسد.

این رابط شامل سه متد است:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) تصمیم می‌گیرد که آیا یک منبع باید پیوند داده شود یا جاسازی.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ilinkembedcontroller/geturl/) URLی را برمی‌گرداند که در HTML تولید شده یا در منبع پیوندی دیگر نوشته می‌شود.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) دادهٔ منبع پیوندی را بر روی دیسک یا هدف ذخیره‌سازی دیگری می‌نویسد.

مسیر سیستم فایل و URL مرورگر مفاهیم جداگانه‌ای هستند. برای مثال، نمونه زیر فایل‌های منبع را در `html-output/assets` روی دیسک می‌نویسد، در حالی که HTML شامل URLهای نسبی مانند `assets/resource-1.svg` است. مرورگر این URLها را نسبت به فایلی که شامل پیوند است حل می‌کند. بنابراین، پیوندی از `presentation.html` به یک فایل SVG از `assets/resource-1.svg` استفاده می‌کند، در حالی که پیوندی از همان فایل SVG به یک تصویر ذخیره‌شده در پوشهٔ `assets` از `resource-4.jpg` استفاده می‌کند.

## **صادرات HTML با منابع پیوندی**

کد C# زیر یک پوشه خروجی ایجاد می‌کند، فایل HTML را در آن ذخیره می‌سازد و منابع پیوندی را در زیرپوشهٔ `assets` نگه می‌دارد. کنترل‌کننده هنگام ارائهٔ image، font، audio، video و CSS رایج، اگر Aspose.Slides یک پسوند امن شناسایی کند یا بتواند استنتاج کند، آنها را پیوند می‌دهد. منابعی که شناسایی نشوند به‌صورت جاسازی باقی می‌مانند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.IO;

var inputFilePath = "presentation.pptx";
var outputDirectory = "html-output";
var assetDirectoryName = "assets";
var assetDirectory = Path.Combine(outputDirectory, assetDirectoryName);

Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(assetDirectory);

var assetUrlPrefix = assetDirectoryName + "/";
var controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(string.Empty, false),
    SlideImageFormat = slideImageFormat
};

using var presentation = new Presentation(inputFilePath);

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

public sealed class ExternalResourceController : ILinkEmbedController
{
    private static readonly Dictionary<string, string> ExtensionsByContentType = new(StringComparer.OrdinalIgnoreCase)
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/gif"] = ".gif",
        ["image/bmp"] = ".bmp",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/x-emf"] = ".emf",
        ["image/x-wmf"] = ".wmf",
        ["font/woff"] = ".woff",
        ["font/woff2"] = ".woff2",
        ["font/ttf"] = ".ttf",
        ["application/font-woff"] = ".woff",
        ["application/vnd.ms-fontobject"] = ".eot",
        ["application/x-font-ttf"] = ".ttf",
        ["text/css"] = ".css",
        ["audio/mpeg"] = ".mp3",
        ["audio/mp4"] = ".m4a",
        ["audio/wav"] = ".wav",
        ["video/mp4"] = ".mp4",
        ["video/webm"] = ".webm"
    };

    private readonly string assetDirectory;
    private readonly string assetUrlPrefix;
    private readonly Dictionary<int, string> fileNamesByResourceId = new();

    public ExternalResourceController(string assetDirectory, string assetUrlPrefix)
    {
        if (string.IsNullOrWhiteSpace(assetDirectory))
        {
            throw new ArgumentException("The asset output directory must not be empty.", nameof(assetDirectory));
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
    }

    public LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        byte[] entityData,
        string semanticName,
        string contentType,
        string recommendedExtension)
    {
        var extension = ResolveExtension(contentType, recommendedExtension);
        if (extension == null)
        {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId[resourceId] = $"resource-{resourceId}{extension}";
        return LinkEmbedDecision.Link;
    }

    public string GetUrl(int resourceId, int referrer)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            return null;
        }

        if (fileNamesByResourceId.ContainsKey(referrer))
        {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    public void SaveExternal(int resourceId, byte[] entityData)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} was not registered for external storage.");
        }

        if (entityData == null || entityData.Length == 0)
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} contains no data and cannot be saved.");
        }

        Directory.CreateDirectory(assetDirectory);

        var filePath = Path.Combine(assetDirectory, fileName);
        File.WriteAllBytes(filePath, entityData);
    }

    private static string ResolveExtension(string contentType, string recommendedExtension)
    {
        if (!string.IsNullOrWhiteSpace(contentType) &&
            ExtensionsByContentType.TryGetValue(contentType, out var mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(contentType))
        {
            return null;
        }

        return NormalizeExtension(recommendedExtension);
    }

    private static bool IsSupportedContentType(string contentType)
    {
        return contentType != null &&
            (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("font/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
    }

    private static string NormalizeExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return null;
        }

        var extensionCharacters = extension.Trim().TrimStart('.');
        foreach (var character in extensionCharacters)
        {
            if (!char.IsLetterOrDigit(character))
            {
                return null;
            }
        }

        return "." + extensionCharacters.ToLowerInvariant();
    }

    private static string NormalizeUrlPrefix(string urlPrefix)
    {
        if (string.IsNullOrEmpty(urlPrefix))
        {
            return string.Empty;
        }

        var normalizedUrlPrefix = urlPrefix.Replace('\\', '/');
        return normalizedUrlPrefix.EndsWith("/")
            ? normalizedUrlPrefix
            : normalizedUrlPrefix + "/";
    }
}
```

پس از صادرات، ساختار پوشهٔ خروجی به این شکل است:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

فایل‌های دقیق بسته به محتوای ارائه و گزینه‌های خروجی متفاوت هستند. برای مثال، تصاویر رستر معمولاً به‌صورت JPEG یا PNG صادر می‌شوند. Aspose.Slides ممکن است کدک تصویری متفاوتی نسبت به ارائهٔ منبع انتخاب کند اگر این کار منجر به فایل کوچکتر یا مناسب‌تر شود. تصاویری که شفافیت دارند به‌صورت PNG صادر می‌شوند.

## **انتخاب URLها برای استقرار**

نمونه از یک پیشوند URL نسبی استفاده می‌کند: `assets/`. اگر `presentation.html` از `html-output/presentation.html` باز شود، مرورگر `html-output/assets/resource-1.svg` را بارگذاری می‌کند.

هنگامی که یک منبع پیوندی به منبع پیوندی دیگری ارجاع می‌دهد، نمونه از پارامتر `referrer` در [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ilinkembedcontroller/geturl/) استفاده کرده و فقط نام فایل را برمی‌گرداند. برای مثال، اگر `resource-1.svg` و `resource-4.jpg` هر دو در پوشهٔ `assets` باشند، فایل SVG باید به `resource-4.jpg` ارجاع دهد، نه به `assets/resource-4.jpg`.

در زمان استقرار در مکان دیگری، پیشوند URL متفاوتی استفاده کنید:

- از `assets/` زمانی استفاده کنید که پوشهٔ دارایی در کنار فایل HTML باشد.
- از `../assets/` زمانی استفاده کنید که پوشهٔ دارایی یک سطح بالاتر از فایل HTML باشد.
- از `https://cdn.example.com/presentations/job-123/assets/` زمانی استفاده کنید که فایل‌ها به یک CDN یا سرور فایل‌های استاتیک بارگذاری شده‌اند.

URLی که توسط [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ilinkembedcontroller/geturl/) برگردانده می‌شود باید با مکان نهایی استقرار فایلی که توسط [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) نوشته می‌شود مطابقت داشته باشد. در برنامه‌های سرور، برای هر کار تبدیل یک پوشهٔ خروجی یا پیشوند ذخیره‌سازی منحصر به فرد استفاده کنید تا از نوشتن روی فایل‌های صادرات دیگر جلوگیری شود.

## **چه زمانی به‌جای آن جاسازی کنیم**

HTML با Base64 جاسازی‌شده همچنان مفید است زمانی که خروجی باید یک فایل تک باشد، مانند پیوست ایمیل، پیش‌نمایش آفلاین یا سندی که بدون پوشهٔ دارایی مرتبط جابجا می‌شود. منابع پیوندی برای زمانی مناسب‌تر هستند که HTML توسط یک برنامه وب سرویس‌گذاری می‌شود، در CMS ذخیره می‌شود، توسط یک خط لوله ساخت بهینه می‌شود یا توسط مرورگرها به‌صورت مستقل از HTML کش می‌شود.

## **سوالات متداول**

**آیا می‌توانم فقط تصاویر را به‌صورت خارجی ذخیره کنم و سایر منابع را جاسازی بگذارم؟**

بله. در [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/)، برای انواع محتویاتی که می‌خواهید به‌صورت فایل‌های جداگانه ذخیره شوند `LinkEmbedDecision.Link` را برگردانید و برای بقیه `LinkEmbedDecision.Embed` را برگردانید.

**چرا پسوند تصویر صادرشده با ارائهٔ منبع متفاوت است؟**

Aspose.Slides ممکن است هنگام صادرات HTML تصاویر رستر را دوباره رمزگذاری کند تا اندازه یا سازگاری مرورگر بهبود یابد. برای مثال، یک تصویر از فایل منبع ممکن است بسته به نتیجهٔ رندر به‌صورت JPEG یا PNG نوشته شود.

**آیا URLهای نسبی پس از جابجایی فایل HTML کار می‌کنند؟**

URLهای نسبی فقط زمانی کار می‌کنند که ساختار پوشهٔ نسبی یکسان حفظ شود. اگر HTML به `assets/resource-1.png` ارجاع دهد، پوشهٔ `assets` باید در کنار فایل HTML بماند مگر این‌که پیشوند URL متفاوتی تولید کنید.

**آیا برنامه‌های سرور باید از همان پوشهٔ خروجی استفاده کنند؟**

نه. برای هر کار تبدیل یک پوشهٔ خروجی یا پیشوند ذخیره‌سازی منحصر به فرد استفاده کنید. این کار از تداخل نام فایل‌ها جلوگیری می‌کند و مانع نوشتن روی منابع تولید شده توسط صادرات دیگر می‌شود.