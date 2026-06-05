---
title: 将演示文稿导出为带外部链接图像的 HTML
type: docs
weight: 100
url: /zh/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出演示文稿
- 导出幻灯片
- 导出 PPT
- 导出 PPTX
- 导出 ODP
- PowerPoint 转 HTML
- OpenDocument 转 HTML
- 演示文稿转 HTML
- 幻灯片转 HTML
- PPT 转 HTML
- PPTX 转 HTML
- ODP 转 HTML
- 链接图像
- 外部链接图像
- 链接资源
- 外部资源
- JavaScript
- Node.js
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js（基于 Java）在 JavaScript 中将 PowerPoint 和 OpenDocument 演示文稿导出为 HTML，并将图像及其他资源保存为外部链接文件。"
---
## **概述**

默认情况下，Aspose.Slides 将演示文稿导出为一个自包含的 HTML 文件。图像和其他资源直接写入 HTML，通常以 Base64 数据的形式。这在需要单一可移植文件时很方便，但并不总是适合网站、CMS 或服务器端转换流水线的最佳格式。

当您希望：

- 减小 HTML 文档的大小；
- 在浏览器或 CDN 中单独缓存图像、字体、音频或视频；
- 在导出后检查、替换、压缩或后处理生成的资源；
- 使输出结构更接近 Web 应用程序的预期。

有关通用的 HTML 转换工作流，请参阅[将 PowerPoint 演示文稿转换为 HTML](/slides/zh/nodejs-java/convert-powerpoint-to-html/)。本文重点关注导出的资源链接部分。

## **链接资源导出工作原理**

针对 [ILinkEmbedController](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 的 Java 代理允许您的应用程序逐资源决定导出器是将数据嵌入 HTML，还是外部保存并写入链接。

该控制器有三个方法：

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 决定资源是应链接还是嵌入。
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 返回将写入生成的 HTML 或其他链接资源的 URL。
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 将链接资源的数据写入磁盘或其他存储目标。

文件系统路径和浏览器 URL 是独立的概念。例如，下面的示例将资源文件写入磁盘上的 `html-output/assets`，而 HTML 中包含诸如 `assets/resource-1.svg` 的相对 URL。浏览器会相对于包含链接的文件解析这些 URL。因此，从 `presentation.html` 链接到 SVG 文件使用 `assets/resource-1.svg`，而该 SVG 文件链接到同一 `assets` 文件夹中保存的图像时使用 `resource-4.jpg`。

## **导出带有链接资源的 HTML**

下面的 JavaScript 示例创建输出目录，将 HTML 文件保存到该目录，并将链接资源存放在 `assets` 子目录中。当 Aspose.Slides 提供或能够推断出安全的文件扩展名时，控制器会链接常见的图像、字体、音频、视频和 CSS 资源。未识别的资源仍保持嵌入。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

导出后，输出文件夹的结构如下：

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

具体的文件取决于演示文稿的内容和导出选项。例如，光栅图像通常导出为 JPEG 或 PNG。当这样可以得到更小或更合适的文件时，Aspose.Slides 可能会选择不同于源演示文稿使用的图像编解码器。带透明度的图像会导出为 PNG。

## **选择部署用的 URL**

示例使用相对 URL 前缀：`assets/`。如果从 `html-output/presentation.html` 打开 `presentation.html`，浏览器将加载 `html-output/assets/resource-1.svg`。

当一个链接资源引用另一个链接资源时，示例在 [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 中使用 `referrer` 参数，并仅返回文件名。例如，如果 `resource-1.svg` 和 `resource-4.jpg` 均位于 `assets` 文件夹中，SVG 文件应引用 `resource-4.jpg`，而不是 `assets/resource-4.jpg`。

当文件部署到其他位置时，请使用不同的 URL 前缀：

- 当资源目录与 HTML 文件位于同一目录时使用 `assets/`。
- 当资源目录位于 HTML 文件上一级时使用 `../assets/`。
- 当文件上传到 CDN 或静态文件服务器时使用 `https://cdn.example.com/presentations/job-123/assets/`。

由 [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 返回的 URL 必须与 [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 写入的文件的最终部署位置相匹配。在服务器应用程序中，请为每个转换作业使用唯一的输出目录或对象存储前缀，以避免覆盖其他导出的文件。

## **何时改为嵌入**

当输出必须是单个文件（例如电子邮件附件、离线预览或将被移动且没有配套资源文件夹的文档），嵌入的 Base64 HTML 仍然有用。HTML 将由 Web 应用程序提供、存储在 CMS 中、经过构建流水线优化或被浏览器独立缓存时，使用链接资源更为合适。

## **常见问题**

**我可以只外部化图像而保持其他资源嵌入吗？**

可以。在 [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 中，仅对希望保存为独立文件的内容类型返回 `LinkEmbedDecision.Link`，对其他全部返回 `LinkEmbedDecision.Embed`。

**为什么导出的图像扩展名与源演示文稿不同？**

Aspose.Slides 可能在 HTML 导出期间重新编码光栅图像，以优化体积或浏览器兼容性。例如，源文件中的图像可能会根据渲染结果被写入为 JPEG 或 PNG。

**移动 HTML 文件后相对 URL 还能使用吗？**

相对 URL 仅在保持相同的相对文件夹结构时可用。如果 HTML 引用 `assets/resource-1.png`，则 `assets` 文件夹必须与 HTML 文件保持同级，除非生成了不同的 URL 前缀。

**服务器应用程序应重复使用相同的输出文件夹吗？**

不应。为每个转换作业使用唯一的输出目录或存储前缀。这可以避免文件名冲突，并防止一次导出覆盖另一次导出生成的资源。