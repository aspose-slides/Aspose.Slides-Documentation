---
title: 将 PowerPoint 演示文稿转换为 .NET 中的 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/net/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 MD
- 演示文稿转 MD
- 幻灯片转 MD
- PPT 转 MD
- PPTX 转 MD
- 将 PowerPoint 保存为 Markdown
- 将演示文稿保存为 Markdown
- 将幻灯片保存为 Markdown
- 将 PPT 保存为 MD
- 将 PPTX 保存为 MD
- 导出 PPT 为 MD
- 导出 PPTX 为 MD
- Markdown 图像导出
- CDN 图像链接
- PowerPoint
- 演示文稿
- Markdown
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中将 PPT 和 PPTX 演示文稿转换为 Markdown，并控制导出的位图、元文件和 SVG 图像的保存位置及引用方式。"
---
## **概述**

Aspose.Slides for .NET 可以将 PPT 和 PPTX 演示文稿转换为 Markdown，以用于文档编写、静态站点、内容迁移和版本控制工作流。您可以选择 Markdown 方言，控制幻灯片内容的呈现方式，并决定导出图像的存储位置以及生成的 Markdown 如何引用它们。

默认情况下，Markdown 导出使用纯文本输出。要导出可视化内容，请将 [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions/exporttype/) 属性设置为 [MarkdownExportType](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownexporttype/) 枚举中的 `Sequential` 或 `Visual` 值。`Sequential` 按顺序分别渲染幻灯片项，而 `Visual` 将分组项保持在一起，以保留它们的视觉关系。`TextOnly` 值不会生成图像资源，因此在该模式下不会触发图像保存事件。

## **将演示文稿转换为 Markdown**

使用 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类加载源文件，然后调用 [Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/) 方法，并使用 [SaveFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/) 枚举中的 `Md` 值。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **选择 Markdown 方言**

[MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions/flavor/) 属性控制输出使用的 Markdown 规范。[Flavor](https://reference.aspose.com/slides/zh/net/aspose.slides.export/flavor/) 枚举包括 CommonMark、GitHub Flavored Markdown 以及其他受支持的变体。

下面的示例将演示文稿导出为 CommonMark：

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

## **使用默认的本地保存行为导出图像**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions/) 类提供两个用于本地保存图像的属性：

- [BasePath](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions/basepath/) 指定 Markdown 文档及其资源的基目录。
- [ImagesSaveFolderName](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) 指定图像子目录，其默认值为 `Images`。

下面的示例渲染可视化内容，将图像写入 `output/assets`，并在 Markdown 文档中创建相对图像引用：

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

该行为也会在自定义图像保存处理程序返回 `false` 时作为回退使用。

## **自定义图像保存和 Markdown 链接**

在 Markdown 导出期间，对非 SVG 位图和元文件资源使用 [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions/imagesaving/) 事件。其 [MarkdownImageSavingHandler](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) 委托接收 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 对象、其 [ImageFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/imageformat/) 和作为 `ref string` 参数的生成的 Markdown 链接。使用提供的格式保存或上传图像，并用必须出现在 Markdown 输出中的引用替换 `link`。

以 SVG 格式发出的资源单独处理。订阅 [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) 事件，其 [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) 委托接收 [ISvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/) 对象和 `ref string link` 参数。SVG 没有 `ImageFormat` 参数；请改为从 [ISvgImage.SvgData](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/svgdata/) 属性写入或上传其 XML 数据。根据导出模式和视觉分组，源演示文稿中的 SVG 可能会被光栅化或与其他内容合并；生成的非 SVG 资源随后会传递给 `ImageSaving`。当每个导出的视觉资源都需要自定义处理时，请同时订阅这两个事件。

处理程序的返回值决定由谁处理图像：

- 在处理程序保存、上传、转换或以其他方式处理图像并为 `link` 分配有效值后返回 `true`。Aspose.Slides 将该值写入 Markdown 文档，并且不会执行默认的本地保存。
- 返回 `false` 让 Aspose.Slides 按照 [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions/basepath/) 和 [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) 本地保存图像并生成链接。

{{% alert color="warning" title="Important" %}}

返回 `true` 的处理程序对图像负全责。如果它在未分配有效且非空链接的情况下返回 `true`，则导出会因 `InvalidOperationException` 而失败。

{{% /alert %}}

### **将图像保存到 CDN 源目录并使用外部 URL**

下面的示例将 `cdn-origin/presentations/quarterly-report` 视为已挂载或已同步的 CDN 源目录。每个处理程序提取生成的文件名，将图像保存到该自定义目录，并用公共 CDN URL 替换生成的本地引用。示例本身不执行网络上传：只有在目录被挂载为 CDN 源或其文件已发布到 CDN 后，URL 才会有效。若使用对象存储，请将文件系统写入替换为存储 SDK 的上传操作，并在上传成功后为 `link` 赋值。

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

位图处理程序有意对小于 128 × 128 像素的图像返回 `false`，因此 Aspose.Slides 会使用默认行为将这些图像保存到 `output/fallback-images`。较大的位图、元文件资源以及 SVG 资源由自定义代码处理。例如，生成的本地引用 `fallback-images/image1.png` 将变为 `https://cdn.example.com/presentations/quarterly-report/image1.png`。处理程序仅在写入文件时使用操作系统路径；写入 Markdown 的链接使用正斜杠并对文件名进行 URL 编码。构建相对链接时也遵循同样规则：使用 `/`，而不是平台特定的目录分隔符。

## **常见问题**

**一个处理程序可以同时处理光栅图像和 SVG 图像吗？**

不能。对发出的位图和元文件资源使用 [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions/imagesaving/)；对以 SVG 发出的资源使用 [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/)。前者提供 [IImage](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/) 对象和 [ImageFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/imageformat/)；后者提供 [ISvgImage](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/) 对象，可从 [ISvgImage.SvgData](https://reference.aspose.com/slides/zh/net/aspose.slides/isvgimage/svgdata/) 读取 SVG 数据。在导出期间被光栅化的源 SVG 由 `ImageSaving` 处理。

**当图像保存处理程序返回 `false` 时会发生什么？**

Aspose.Slides 会使用默认的本地保存行为。图像位置和生成的引用由 [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions/basepath/) 和 [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/zh/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) 控制。

**处理程序可以在不本地保存图像的情况下提供 URL 吗？**

可以。处理程序可以将图像上传到对象存储或交给其他服务，随后为 `link` 赋予生成的 URL 并返回 `true`。处理程序必须自行完成所有处理；返回 `true` 会阻止默认的本地保存。

**为什么 Markdown 导出会因处理程序抛出 `InvalidOperationException`？**

当处理程序返回 `true` 但未提供有效链接时会出现此异常。请在返回 `true` 之前为 Markdown 分配相对路径或外部 URL。

**图像链接应使用哪种路径分隔符？**

在 Markdown 链接和 URL 中使用正斜杠。仅在文件系统路径上使用 `Path.Combine`，然后单独构造或规范化 Markdown 引用。

**超链接在 Markdown 导出时会被保留吗？**

会。文本 [hyperlinks](/slides/zh/net/manage-hyperlinks/) 会保留为标准的 Markdown 链接。幻灯片 [transitions](/slides/zh/net/slide-transition/) 和 [animations](/slides/zh/net/powerpoint-animation/) 不会被转换。

**可以并行将演示文稿转换为 Markdown 吗？**

可以并行处理不同的演示文稿文件，但不要在多个线程之间共享同一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 实例。请遵循 [multithreading guidelines](/slides/zh/net/multithreading/) 并为每个文件使用独立的实例。