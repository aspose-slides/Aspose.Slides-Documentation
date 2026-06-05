---
title: 将演示文稿导出为带外部链接图像的 HTML
type: docs
weight: 100
url: /zh/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出 演示文稿
- 导出 幻灯片
- 导出 PPT
- 导出 PPTX
- 导出 ODP
- PowerPoint 转 HTML
- OpenDocument 转 HTML
- 演示文稿 转 HTML
- 幻灯片 转 HTML
- PPT 转 HTML
- PPTX 转 HTML
- ODP 转 HTML
- 链接图像
- 外部链接图像
- 链接资源
- 外部资源
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 将 PowerPoint 和 OpenDocument 演示文稿导出为 HTML（.NET），并将图像及其他资源保存为外部链接文件。"
---
## **概述**

默认情况下，Aspose.Slides 将演示文稿导出为自包含的 HTML 文件。图像和其他资源直接写入 HTML，通常以 Base64 数据的形式。这在需要单个可移植文件时很方便，但它并不总是适合网站、CMS 或服务器端转换流水线的最佳格式。

当您希望以下情况时，请使用外部链接资源：

- 减小 HTML 文档的大小；
- 在浏览器或 CDN 中单独缓存图像、字体、音频或视频；
- 在导出后检查、替换、压缩或后处理生成的资源；
- 保持输出结构更接近 Web 应用程序的预期。

有关通用 HTML 转换工作流，请参见[将 PowerPoint 演示文稿转换为 HTML](/slides/zh/net/convert-powerpoint-to-html/)。本文聚焦于导出的资源链接部分。

## **链接资源导出工作原理**

[ILinkEmbedController](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ilinkembedcontroller/) 允许您的应用程序逐个资源决定导出器是将数据嵌入 HTML，还是将其外部保存并写入链接。

该接口有三个方法：

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) 决定资源是应该链接还是嵌入。
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ilinkembedcontroller/geturl/) 返回将写入生成的 HTML 或其他链接资源的 URL。
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) 将链接资源的数据写入磁盘或其他存储目标。

文件系统路径和浏览器 URL 是不同的关注点。例如，下面的示例将资源文件写入磁盘上的 `html-output/assets`，而 HTML 包含诸如 `assets/resource-1.svg` 的相对 URL。浏览器会相对于包含链接的文件解析这些 URL。因此，从 `presentation.html` 链接到 SVG 文件使用 `assets/resource-1.svg`，而该 SVG 文件链接到同一 `assets` 文件夹中保存的图像时使用 `resource-4.jpg`。

## **使用链接资源导出 HTML**

下面的 C# 示例创建一个输出目录，将 HTML 文件保存到该目录，并在 `assets` 子目录中存储链接资源。当 Aspose.Slides 提供或可以推断安全的文件扩展名时，控制器会链接常见的图像、字体、音频、视频和 CSS 资源。未识别的资源仍保持嵌入。

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

导出后，输出文件夹具有以下结构：

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

确切的文件取决于演示文稿的内容和导出选项。例如，光栅图像通常导出为 JPEG 或 PNG。当生成更小或更合适的文件时，Aspose.Slides 可能会选择不同于源演示文稿的图像编解码器。具有透明度的图像会导出为 PNG。

## **部署时的 URL 选择**

示例使用相对 URL 前缀：`assets/`。如果从 `html-output/presentation.html` 打开 `presentation.html`，浏览器会加载 `html-output/assets/resource-1.svg`。

当一个链接资源引用另一个链接资源时，示例在[ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ilinkembedcontroller/geturl/) 中使用 `referrer` 参数，并仅返回文件名。例如，如果 `resource-1.svg` 和 `resource-4.jpg` 都位于 `assets` 文件夹中，SVG 文件应引用 `resource-4.jpg`，而不是 `assets/resource-4.jpg`。

当文件部署在其他位置时，请使用不同的 URL 前缀：

- 当资源目录与 HTML 文件相邻时，使用 `assets/`。
- 当资源目录位于 HTML 文件上一级时，使用 `../assets/`。
- 当文件上传到 CDN 或静态文件服务器时，使用 `https://cdn.example.com/presentations/job-123/assets/`。

由[ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ilinkembedcontroller/geturl/) 返回的 URL 必须与 [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) 写入文件的最终部署位置相匹配。在服务器应用程序中，对每个转换作业使用唯一的输出目录或对象存储前缀，以避免覆盖其他导出的文件。

## **何时选择嵌入而非链接**

当输出必须是单个文件时（例如电子邮件附件、离线预览或将被移动且没有配套资产文件夹的文档），嵌入的 Base64 HTML 仍然有用。而当 HTML 将由 Web 应用程序提供、存储在 CMS 中、经构建流水线优化，或由浏览器独立于 HTML 缓存时，链接资源更为合适。

## **常见问题**

**我可以仅外部化图像而保持其他资源嵌入吗？**

是的。在[ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/zh/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) 中，仅对想要保存为单独文件的内容类型返回 `LinkEmbedDecision.Link`，对其他所有内容返回 `LinkEmbedDecision.Embed`。

**为何导出的图像扩展名与源演示文稿不同？**

Aspose.Slides 可能在 HTML 导出期间重新编码光栅图像，以优化文件大小或浏览器兼容性。例如，源文件中的图像可能根据渲染结果被写入为 JPEG 或 PNG。

**在移动 HTML 文件后，相对 URL 还能工作吗？**

相对 URL 仅在保持相同的相对文件夹结构时才有效。如果 HTML 引用了 `assets/resource-1.png`，则 `assets` 文件夹必须与 HTML 文件保持相邻，除非您生成了不同的 URL 前缀。

**服务器应用程序是否应重复使用相同的输出文件夹？**

不。对每个转换作业使用唯一的输出目录或存储前缀。这可避免文件名冲突，防止一次导出覆盖另一导出生成的资源。