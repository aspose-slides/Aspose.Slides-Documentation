---
title: تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا
type: docs
weight: 100
url: /ar/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير العرض التقديمي
- تصدير الشريحة
- تصدير PPT
- تصدير PPTX
- تصدير ODP
- PowerPoint إلى HTML
- OpenDocument إلى HTML
- العرض التقديمي إلى HTML
- الشريحة إلى HTML
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
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML في .NET باستخدام Aspose.Slides مع حفظ الصور والموارد الأخرى كملفات مرتبطة خارجياً."
---
## **نظرة عامة**

بشكل افتراضي، يقوم Aspose.Slides بتصدير العرض التقديمي إلى ملف HTML مستقل. تُكتب الصور والموارد الأخرى مباشرةً في ملف HTML، عادةً كبيانات Base64. هذا ملائم عندما تحتاج إلى ملف واحد محمول، لكنه ليس دائمًا أفضل تنسيق لموقع ويب أو نظام إدارة محتوى أو خط أنابيب تحويل على الخادم.

استخدم الموارد المرتبطة خارجيًا عندما تريد:

- تقليل حجم مستند HTML؛
- تخزين الصور أو الخطوط أو الصوت أو الفيديو في المتصفح أو شبكة CDN بشكل منفصل؛
- فحص، استبدال، ضغط أو معالجة الموارد المُولَّدة بعد التصدير؛
- الحفاظ على بنية الإخراج أقرب إلى ما تتوقعه تطبيقات الويب.

للتعرف على سير عمل التحويل العام إلى HTML، راجع [تحويل عروض PowerPoint إلى HTML](/slides/ar/net/convert-powerpoint-to-html/). يركز هذا المقال على جزء ربط الموارد أثناء التصدير.

## **كيفية عمل تصدير الموارد المرتبطة**

[ILinkEmbedController](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/) يتيح لتطبيقك اتخاذ القرار، لكل مورد على حدة، ما إذا كان المصدِّر سيضمن البيانات داخل HTML أو سيحفظها خارجيًا ويكتب رابطًا.

الواجهة تحتوي على ثلاث طرق:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) يحدد ما إذا كان يجب ربط المورد أو تضمينه.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/geturl/) يُعيد عنوان URL الذي سيُكتب إلى HTML المُولَّد أو إلى مورد مرتبط آخر.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) يكتب بيانات المورد المرتبط إلى القرص أو إلى هدف تخزين آخر.

مسار نظام الملفات وعنوان URL الخاص بالمتصفح هما مسألتان منفصلتان. على سبيل المثال، يكتب المثال أدناه ملفات الموارد إلى `html-output/assets` على القرص، بينما يحتوي HTML على عناوين URL نسبية مثل `assets/resource-1.svg`. المتصفح يحل هذه العناوين نسبة إلى الملف الذي يحتوي على الرابط. لذلك، يستخدم الرابط من `presentation.html` إلى ملف SVG العنوان `assets/resource-1.svg`، بينما يستخدم الرابط من ملف SVG نفسه إلى صورة محفوظة في نفس مجلد `assets` العنوان `resource-4.jpg`.

## **تصدير HTML مع موارد مرتبطة**

المثال التالي بلغة C# ينشئ دليل إخراج، يحفظ ملف HTML هناك، ويخزن الموارد المرتبطة في مجلد فرعي باسم `assets`. يتحكم المتحكم في ربط الصور الشائعة، الخطوط، الصوت، الفيديو، وموارد CSS عندما يوفر Aspose.Slides أو يستطيع استنتاج امتداد ملف آمن. الموارد التي لا يتم التعرف عليها تظل مُضمَّنة.

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

بعد التصدير، يحتوي مجلد الإخراج على البنية التالية:

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

الملفات الدقيقة تعتمد على محتوى العرض التقديمي وخيارات التصدير. على سبيل المثال، عادةً ما تُصدَّر الصور النقطية كـ JPEG أو PNG. قد يختار Aspose.Slides ترميز صورة مختلف عن الموجود في العرض الأصلي إذا كان ينتج ملفًا أصغر أو أكثر ملاءمة. تُصدَّر الصور ذات الشفافية كـ PNG.

## **اختيار عناوين URL للنشر**

يستخدم المثال بادئة عنوان URL نسبية: `assets/`. إذا تم فتح `presentation.html` من `html-output/presentation.html`، سيقوم المتصفح بتحميل `html-output/assets/resource-1.svg`.

عندما يشير مورد مرتبط إلى مورد مرتبط آخر، يستخدم المثال المعامل `referrer` في [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/geturl/) ويُعيد فقط اسم الملف. على سبيل المثال، إذا كان كل من `resource-1.svg` و `resource-4.jpg` موجودين في مجلد `assets`، يجب أن يشير ملف SVG إلى `resource-4.jpg` وليس إلى `assets/resource-4.jpg`.

استخدم بادئة عنوان URL مختلفة عندما تُنشر الملفات في مكان آخر:

- استخدم `assets/` عندما يكون دليل الأصول بجوار ملف HTML.
- استخدم `../assets/` عندما يكون دليل الأصول مستوى واحد فوق ملف HTML.
- استخدم `https://cdn.example.com/presentations/job-123/assets/` عندما تُرفع الملفات إلى CDN أو خادم ملفات ثابت.

يجب أن يتطابق عنوان URL الذي تُرجعه [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/geturl/) مع الموقع النهائي للملف الذي يكتبه [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/saveexternal/). في تطبيقات الخادم، استخدم دليل إخراج فريد أو بادئة تخزين كائن لكل مهمة تحويل لتجنب الكتابة فوق ملفات تصدير أخرى.

## **متى يجب تضمين الموارد بدلاً من ربطها**

يظل HTML المضمَّن كـ Base64 مفيدًا عندما يجب أن يكون الإخراج ملفًا واحدًا، مثل مرفق بريد إلكتروني، معاينة دون اتصال، أو مستند سيُنقل بدون مجلد أصول داعم. تكون الموارد المرتبطة خيارًا أفضل عندما يُقدَّم HTML بواسطة تطبيق ويب، أو يُخزن في نظام إدارة محتوى، أو يُحسَّن عبر خطوط بناء، أو يُخبَّأ من قبل المتصفحات بشكل مستقل عن HTML.

## **الأسئلة المتكررة**

**هل يمكنني استخراج الصور فقط وترك الموارد الأخرى مُضمَّنة؟**

نعم. في [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/ar/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/)، أعِد `LinkEmbedDecision.Link` فقط لأنواع المحتوى التي تريد حفظها كملفات منفصلة، وأَعِد `LinkEmbedDecision.Embed` لكل ما باقي.

**لماذا يختلف امتداد الصورة المُصدَّرة عن العرض الأصلي؟**

قد يعيد Aspose.Slides ترميز الصور النقطية أثناء تصدير HTML لتحسين الحجم أو توافق المتصفح. على سبيل المثال، قد تُكتب صورة من الملف الأصلي كـ JPEG أو PNG بناءً على النتيجة المُظهرَة.

**هل تعمل عناوين URL النسبية بعد نقل ملف HTML؟**

تعمل عناوين URL النسبية فقط عندما يتم الحفاظ على نفس بنية المجلدات النسبية. إذا كان HTML يشير إلى `assets/resource-1.png`، يجب أن يبقى مجلد `assets` بجوار ملف HTML ما لم تُولِّد بادئة عنوان URL مختلفة.

**هل ينبغي لتطبيقات الخادم إعادة استخدام نفس مجلد الإخراج؟**

لا. استخدم دليل إخراج فريد أو بادئة تخزين لكل مهمة تحويل. ذلك يمنع تصادم أسماء الملفات ويمنع كتابة موارد تصدير واحدة فوق الأخرى.