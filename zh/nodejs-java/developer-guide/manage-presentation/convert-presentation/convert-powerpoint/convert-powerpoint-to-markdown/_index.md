---
title: 在 JavaScript 中将 PowerPoint 演示文稿转换为 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 MD
- 演示文稿 转 MD
- 幻灯片 转 MD
- PPT 转 MD
- PPTX 转 MD
- 将 PowerPoint 保存为 Markdown
- 将 演示文稿 保存为 Markdown
- 将 幻灯片 保存为 Markdown
- 将 PPT 保存为 MD
- 将 PPTX 保存为 MD
- 导出 PPT 为 MD
- 导出 PPTX 为 MD
- Markdown 图像导出
- CDN 图像链接
- PowerPoint
- 演示文稿
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中将 PPT 和 PPTX 演示文稿转换为 Markdown，并控制导出位图、元文件和 SVG 图像的保存位置和引用方式。"
---
## **概述**

Aspose.Slides for Node.js via Java 可以将 PPT 和 PPTX 演示文稿转换为 Markdown，用于文档、静态站点、内容迁移和版本控制工作流。您可以选择 Markdown 方言，控制幻灯片内容的渲染方式，并决定导出图像的存储位置以及生成的 Markdown 如何引用它们。

默认情况下，Markdown 导出使用纯文本输出。若要导出可视化内容，请使用 [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/markdownsaveoptions/) 方法将导出类型设置为 [MarkdownExportType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/markdownexporttype/) 枚举中的 `Sequential` 或 `Visual` 值。`Sequential` 按顺序单独呈现幻灯片项目，而 `Visual` 将分组项目保持在一起，以保留它们的视觉关系。`TextOnly` 值不生成图像资源，因此在该模式下不会调用图像保存回调。

## **将演示文稿转换为 Markdown**

使用 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类加载源文件，然后调用 [Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 方法，并传入来自 [SaveFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveformat/) 枚举的 `Md` 值。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **选择 Markdown 方言**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/markdownsaveoptions/) 方法控制输出使用的 Markdown 规范。[Flavor](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/flavor/) 枚举包括 CommonMark、GitHub Flavored Markdown 以及其他受支持的变体。

以下示例将演示文稿导出为 CommonMark：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **使用默认本地保存行为导出图像**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/markdownsaveoptions/) 类提供两种配置本地保存图像的方法：

- [setBasePath](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/markdownsaveoptions/) 指定 Markdown 文档及其资源的基目录。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/markdownsaveoptions/) 指定图像子目录。默认值为 `Images`。

以下示例渲染可视化内容，将图像写入 `output/assets`，并在 Markdown 文档中创建相对图像引用：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

当自定义图像保存处理程序返回 `false` 时，此行为也作为回退使用。

## **自定义图像保存和 Markdown 链接**

使用 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/markdownsaveoptions/) 方法注册一个回调，用于处理 Markdown 导出期间产生的非 SVG 位图和元文件资源。其 `MarkdownImageSavingHandler` 回调接收 [IImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/) 对象、其 [ImageFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/imageformat/) 值以及作为单元素字符串数组的生成的 Markdown 链接。使用提供的格式保存或上传图像，并用必须出现在 Markdown 输出中的引用替换 `link[0]`。

SVG 格式的资源单独处理。使用 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/markdownsaveoptions/) 方法注册回调。其 `MarkdownSvgImageSavingHandler` 回调接收 `ISvgImage` 对象和单元素 `link` 数组。SVG 没有 `ImageFormat` 参数；请改为从 `ISvgImage.getSvgData` 方法获取 XML 数据并写入或上传。根据导出模式和视觉分组，源演示文稿中的 SVG 可能被光栅化或与其他内容合并；生成的非 SVG 资源随后会传递给图像保存回调。若每个导出的视觉资源都需要自定义处理，请同时注册这两个回调。

在 Node.js 中，可使用 `java.newProxy` 创建这些回调接口的实现。

处理程序的返回值决定由谁处理图像：

- 返回 `true` 表示处理程序已经保存、上传、转换或以其他方式处理了图像，并为 `link[0]` 分配了有效值。Aspose.Slides 将该值写入 Markdown 文档，并且不执行默认的本地保存。
- 返回 `false` 则让 Aspose.Slides 按照由 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/markdownsaveoptions/) 和 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/markdownsaveoptions/) 设置的值本地保存图像并生成链接。

{{% alert color="warning" title="Important" %}}
返回 `true` 的处理程序对图像负全部责任。如果返回 `true` 时未为 `link[0]` 分配有效且非空的链接，导出将因 `InvalidOperationException` 而失败。
{{% /alert %}}

### **将图像保存到 CDN 源目录并使用外部 URL**

以下示例将 `cdn-origin/presentations/quarterly-report` 视为已挂载或同步的 CDN 源目录。每个处理程序提取生成的文件名，将图像保存到该自定义目录，并用公共 CDN URL 替换生成的本地引用。示例本身不执行网络上传：只有当目录被挂载为 CDN 源或其文件已发布到 CDN 时，URL 才有效。对于对象存储，请将文件系统写入替换为存储 SDK 的上传操作，并在上传成功后为 `link[0]` 赋值。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

位图处理程序针对小于 128 × 128 像素的图像故意返回 `false`，因此 Aspose.Slides 会使用默认行为将这些图像保存到 `output/fallback-images`。较大的位图、元文件以及 SVG 资源由自定义代码处理。例如，生成的本地引用 `fallback-images/image1.png` 将变为 `https://cdn.example.com/presentations/quarterly-report/image1.png`。处理程序仅在写文件时使用操作系统路径；写入 Markdown 的链接使用正斜杠并对文件名进行 URL 编码。构建相对链接时也遵循同样规则：使用 `/`，而不是平台特定的路径分隔符。

## **常见问题**

**一个处理程序能同时处理栅格图像和 SVG 图像吗？**

不能。对位图和元文件资源使用 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/markdownsaveoptions/) ，对以 SVG 形式导出的资源使用 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/markdownsaveoptions/) 。前者提供 [IImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/) 对象和 [ImageFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/imageformat/) 值；后者提供 `ISvgImage` 对象，可通过 `ISvgImage.getSvgData` 读取 SVG 数据。在导出期间被光栅化的源 SVG 将交给图像保存回调处理。

**当图像保存处理程序返回 `false` 时会发生什么？**

Aspose.Slides 将使用默认的本地保存行为。图像位置和生成的引用受由 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/markdownsaveoptions/) 和 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/markdownsaveoptions/) 设置的值控制。

**处理程序可以在不本地保存图像的情况下提供 URL 吗？**

可以。处理程序可以将图像上传到对象存储或交给其他服务，随后将得到的 URL 赋给 `link[0]` 并返回 `true`。此时处理程序必须自行完成所有处理；返回 `true` 会阻止默认的本地保存。

**为什么 Markdown 导出会因处理程序抛出 `InvalidOperationException`？**

当处理程序返回 `true` 但未提供有效链接时会出现此异常。请在返回 `true` 前为 `link[0]` 赋予应写入 Markdown 的相对路径或外部 URL。

**图像链接应使用哪种路径分隔符？**

在 Markdown 链接和 URL 中使用正斜杠。仅在文件系统路径上使用 `path.join`，随后单独构建或规范化 Markdown 引用。

**超链接在 Markdown 导出时会被保留吗？**

会。文本 [hyperlinks](/slides/zh/nodejs-java/manage-hyperlinks/) 会保留为标准的 Markdown 链接。幻灯片 [transitions](/slides/zh/nodejs-java/slide-transition/) 和 [animations](/slides/zh/nodejs-java/powerpoint-animation/) 不会被转换。

**可以并行将多个演示文稿转换为 Markdown 吗？**

可以并行处理不同的演示文稿文件，但不要在多个线程之间共享同一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 实例。请遵循 [multithreading guidelines](/slides/zh/nodejs-java/multithreading/) 并为每个文件使用独立的实例。