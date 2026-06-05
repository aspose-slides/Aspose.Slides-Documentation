---
title: تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا
type: docs
weight: 100
url: /ar/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير عرض تقديمي
- تصدير شريحة
- تصدير PPT
- تصدير PPTX
- تصدير ODP
- PowerPoint إلى HTML
- OpenDocument إلى HTML
- عرض تقديمي إلى HTML
- شريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- ODP إلى HTML
- صورة مرتبطة
- صورة مرتبطة خارجيًا
- مورد مرتبط
- مورد خارجي
- .NET
- C#
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML في .NET باستخدام Aspose.Slides مع حفظ الصور والموارد الأخرى كملفات مرتبطة خارجيًا."
---
## **نظرة عامة**

بشكلٍ افتراضي، تقوم Aspose.Slides بتصدير عرض تقديمي إلى ملف HTML ذاتي المحتوى. تُكتب الصور والموارد الأخرى مباشرةً داخل HTML، عادةً كبيانات Base64. هذا مُريح عندما تحتاج ملفًا واحدًا محمولًا، لكنه ليس دائمًا الصيغة المثلى لموقع ويب أو نظام إدارة محتوى أو خط أنابيب تحويل من جانب الخادم.

- تقليل حجم مستند HTML;
- تخزين الصور، الخطوط، الصوت أو الفيديو بشكلٍ منفصل في المتصفح أو CDN;
- فحص، استبدال، ضغط أو معالجة الموارد المُولدة بعد التصدير;
- جعل بنية الناتج أقرب إلى ما يتوقعه تطبيق الويب

للحصول على سير عمل التحويل العام إلى HTML، راجع [Convert PowerPoint Presentations to HTML](/slides/ar/net/convert-powerpoint-to-html/). يركز هذا المقال على جزء ربط الموارد أثناء التصدير.

## **كيفية عمل تصدير الموارد المرتبطة**

[ILinkEmbedController](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/) يسمح لتطبيقك بتحديد، لكل مورد على حدة، ما إذا كان المصدِّر سيضمّن البيانات داخل HTML أو يحفظها خارجياً ويكتب رابطًا.

تحتوي الواجهة على ثلاث طرق:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) يقرر ما إذا كان يجب ربط المورد أو تضمينه.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/geturl/) يُرجع عنوان URL الذي سيُكتب في HTML المُولَّد أو إلى مورد مرتبط آخر.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) يكتب بيانات المورد المرتبط إلى القرص أو إلى هدف تخزين آخر.

مسار نظام الملفات وعنوان URL للمتصفح هما أمران منفصلان. على سبيل المثال، يكتب المثال أدناه ملفات الموارد إلى `html-output/assets` على القرص، بينما يحتوي HTML على عناوين URL نسبية مثل `assets/resource-1.svg`. يقوم المتصفح بحل هذه العناوين بالنسبة للملف الذي يحتوي على الرابط. لذا، يستخدم رابط من `presentation.html` إلى ملف SVG العنوان `assets/resource-1.svg`، في حين يستخدم رابط من ملف SVG ذلك إلى صورة محفوظة في نفس مجلد `assets` العنوان `resource-4.jpg`.

## **تصدير HTML مع موارد مرتبطة**

المثال التالي بلغة C# ينشئ دليل إخراج، يحفظ ملف HTML هناك، ويخزن الموارد المرتبطة في مجلد فرعي `assets`. يربط المتحكم الموارد الشائعة من صور، خطوط، صوت، فيديو، وCSS عندما توفر Aspose.Slides أو يمكنها استنتاج امتداد ملف آمن. الموارد غير المعروفة تبقى مضمَّنة.

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

بعد التصدير، يحتوي مجلد الإخراج على هذه البنية:

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

الملفات الدقيقة تعتمد على محتوى العرض التقديمي وخيارات التصدير. على سبيل المثال، تُصدَّر الصور النقطية عادةً كـ JPEG أو PNG. قد تختار Aspose.Slides ترميز صورة مختلف عما يُستخدم في العرض المصدر إذا كان ينتج ملفًا أصغر أو أكثر ملاءمة. تُصدَّر الصور ذات الشفافية كـ PNG.

## **اختيار عناوين URL للنشر**

يستخدم المثال بادئة URL نسبية: `assets/`. إذا تم فتح `presentation.html` من `html-output/presentation.html`، سيحمّل المتصفح `html-output/assets/resource-1.svg`.

عندما يشير مورد مرتبط إلى مورد مرتبط آخر، يستخدم المثال معامل `referrer` في [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/geturl/) ويُعيد اسم الملف فقط. على سبيل المثال، إذا كان كل من `resource-1.svg` و `resource-4.jpg` في مجلد `assets`، يجب أن يشير ملف SVG إلى `resource-4.jpg`، وليس إلى `assets/resource-4.jpg`.

استخدم بادئة URL مختلفة عندما تُنشر الملفات في مكان آخر:

- استخدم `assets/` عندما يكون دليل الأصول بجوار ملف HTML.
- استخدم `../assets/` عندما يكون دليل الأصول مستوىً واحدًا فوق ملف HTML.
- استخدم `https://cdn.example.com/presentations/job-123/assets/` عندما تُرفع الملفات إلى شبكة توصيل محتوى (CDN) أو خادم ملفات ثابتة.

يجب أن يتطابق عنوان URL الذي تُرجعه [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/geturl/) مع الموقع النهائي للنشر للملف الذي يكتبه [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/saveexternal/). في التطبيقات الخدمية، استخدم دليل إخراج فريد أو بادئة تخزين كائنات لكل مهمة تحويل لتجنب الكتابة فوق ملفات تصدير أخرى.

## **متى يُفضَّل التضمين بدلاً من ذلك**

لا يزال HTML المضمّن كـ Base64 مفيدًا عندما يجب أن يكون الناتج ملفًا واحدًا، مثل مرفق بريد إلكتروني، معاينة دون اتصال، أو مستند يُنقل دون مجلد أصول داعم. الموارد المرتبطة تكون أكثر ملاءمة عندما يُقدَّم HTML عبر تطبيق ويب، يُخزن في نظام إدارة محتوى، يُحسّن عبر خط أنابيب بناء، أو يُخزن مؤقتًا في المتصفحات بشكلٍ مستقل عن HTML.

## **الأسئلة المتكررة**

**هل يمكنني تحويل الصور إلى موارد خارجية مع إبقاء الموارد الأخرى مضمَّنة؟**

نعم. في [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/)، أرجع `LinkEmbedDecision.Link` فقط لأنواع المحتوى التي ترغب في حفظها كملفات منفصلة، وأرجع `LinkEmbedDecision.Embed` لبقية الأنواع.

**لماذا يختلف امتداد الصورة المصدَّرة عن العرض المصدر؟**

قد تقوم Aspose.Slides بإعادة ترميز الصور النقطية أثناء تصدير HTML لتحسين الحجم أو توافق المتصفح. على سبيل المثال، قد تُكتب صورة من الملف المصدر كـ JPEG أو PNG بحسب النتيجة المُعالجة.

**هل تعمل عناوين URL النسبية بعد نقل ملف HTML؟**

تعمل عناوين URL النسبية فقط عندما يتم الحفاظ على نفس بنية المجلدات النسبية. إذا كان HTML ي référ إلى `assets/resource-1.png`، يجب أن يظل مجلد `assets` بجوار ملف HTML ما لم تُنشئ بادئة URL مختلفة.

**هل ينبغي لتطبيقات الخادم إعادة استخدام نفس مجلد الإخراج؟**

لا. استخدم دليل إخراج فريد أو بادئة تخزين لكل مهمة تحويل. يجنّب ذلك تصادم أسماء الملفات ويمنع تصديرًا واحدًا من الكتابة فوق الموارد التي أنشأها تصدير آخر.