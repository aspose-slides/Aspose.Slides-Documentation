---
title: 将演示文稿导出为带外部链接图像的 HTML
type: docs
weight: 100
url: /zh/php-java/exporting-presentations-to-html-with-externally-linked-images/
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
- PHP
- Aspose.Slides
description: "在 PHP via Java 环境中使用 Aspose.Slides 将 PowerPoint 和 OpenDocument 演示文稿导出为 HTML，图像和其他资源保存为外部链接文件。"
---
## **概述**

默认情况下，Aspose.Slides 会将演示文稿导出为一个自包含的 HTML 文件。图像和其他资源会直接写入 HTML，通常采用 Base64 数据的形式。这在需要单个可移植文件时很方便，但并不总是网站、CMS 或服务器端转换流水线的最佳格式。

当您需要以下目标时，请使用外部链接资源：

- 减小 HTML 文档的体积；
- 在浏览器或 CDN 中单独缓存图像、字体、音频或视频；
- 在导出后检查、替换、压缩或后处理生成的资源；
- 使输出结构更贴合 Web 应用的预期。

有关一般的 HTML 转换工作流，请参阅[Convert PowerPoint Presentations to HTML](/slides/zh/php-java/convert-powerpoint-to-html/)。本文专注于导出过程中的资源链接部分。

## **链接资源导出工作原理**

[HtmlOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmloptions/) 可以在 Aspose.Slides 将演示文稿导出为 HTML 时使用自定义的链接/嵌入控制器。在 PHP via Java 场景中，通常使用一个小的 Java 辅助类来实现。编译该辅助类，将其添加到 PHP Java Bridge 的 classpath 中，并通过 `new Java(...)` 在 PHP 中实例化。

辅助类会逐个资源决定导出器是将数据嵌入到 HTML 中还是外部保存并写入链接。它需要实现三个回调方法：

- `ExternalResourceController.getObjectStoringLocation` 决定资源是链接还是嵌入。
- `ExternalResourceController.getUrl` 返回将写入生成的 HTML 或其他链接资源的 URL。
- `ExternalResourceController.saveExternal` 将链接资源的数据写入磁盘或其他存储目标。

文件系统路径和浏览器 URL 是分离的概念。例如，下面的示例将资源文件写入磁盘的 `html-output/assets`，而 HTML 中包含的相对 URL 如 `assets/resource-1.svg`。浏览器会相对于包含链接的文件解析这些 URL。因此，`presentation.html` 到 SVG 文件的链接使用 `assets/resource-1.svg`，而该 SVG 文件到同一 `assets` 文件夹下图像的链接使用 `resource-4.jpg`。

## **创建 Java 辅助类**

创建类似 `com.example.slides.ExternalResourceController` 的 Java 类，在 classpath 中加入 Aspose.Slides for Java，随后将编译得到的类或 JAR 提供给 PHP Java Bridge。

下面的辅助类在 Aspose.Slides 能够提供或推断安全的文件扩展名时，会链接常见的图像、字体、音频、视频以及 CSS 资源。未被识别的资源仍会保持嵌入。

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
    }

    @Override
    public int getObjectStoringLocation(
            int resourceId,
            byte[] entityData,
            String semanticName,
            String contentType,
            String recommendedExtension) {
        String extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
        return LinkEmbedDecision.Link;
    }

    @Override
    public String getUrl(int resourceId, int referrer) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (fileNamesByResourceId.containsKey(referrer)) {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    @Override
    public void saveExternal(int resourceId, byte[] entityData) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length == 0) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " contains no data and cannot be saved.");
        }

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
    }

    private static String resolveExtension(String contentType, String recommendedExtension) {
        if (contentType != null && !contentType.trim().isEmpty()) {
            String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
            if (mappedExtension != null) {
                return mappedExtension;
            }
        }

        if (!isSupportedContentType(contentType)) {
            return null;
        }

        return normalizeExtension(recommendedExtension);
    }

    private static boolean isSupportedContentType(String contentType) {
        return contentType != null &&
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
                return null;
            }
        }

        return "." + extensionCharacters.toLowerCase(Locale.ROOT);
    }

    private static String normalizeUrlPrefix(String urlPrefix) {
        if (urlPrefix == null || urlPrefix.isEmpty()) {
            return "";
        }

        String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
        return normalizedUrlPrefix.endsWith("/")
                ? normalizedUrlPrefix
                : normalizedUrlPrefix + "/";
    }
}
```

## **使用链接资源导出 HTML**

以下 PHP 代码创建输出目录，将 HTML 文件保存至该目录，并将链接资源存放在 `assets` 子目录中。它结合了 [HtmlOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/htmloptions/)、[SVGOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/svgoptions/)、[SlideImageFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slideimageformat/) 和 [SaveFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/saveformat/) 来完成导出。

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

导出完成后，输出文件夹的结构如下：

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

具体文件取决于演示文稿的内容和导出选项。例如，光栅图像通常导出为 JPEG 或 PNG。Aspose.Slides 可能会选择与源演示文稿不同的图像编解码器，以获得更小或更合适的文件。带透明度的图像会导出为 PNG。

## **为部署选择 URL**

示例使用相对 URL 前缀 `assets/`。如果 `presentation.html` 位于 `html-output/presentation.html`，浏览器会加载 `html-output/assets/resource-1.svg`。

当一个链接资源引用另一个链接资源时，示例在 `ExternalResourceController.getUrl` 中使用 `referrer` 参数，并仅返回文件名。例如，若 `resource-1.svg` 和 `resource-4.jpg` 均位于 `assets` 文件夹内，SVG 文件应引用 `resource-4.jpg`，而不是 `assets/resource-4.jpg`。

如果文件部署在其他位置，请使用不同的 URL 前缀：

- 当资产目录与 HTML 文件位于同一目录时，使用 `assets/`；
- 当资产目录位于 HTML 文件的上一级目录时，使用 `../assets/`；
- 当文件上传到 CDN 或静态文件服务器时，使用 `https://cdn.example.com/presentations/job-123/assets/`。

`ExternalResourceController.getUrl` 返回的 URL 必须与 `ExternalResourceController.saveExternal` 写入的文件最终部署位置相匹配。在服务器应用中，请为每个转换作业使用唯一的输出目录或对象存储前缀，以避免不同导出之间的文件覆盖。

## **何时应使用嵌入**

当输出必须是单个文件时（例如作为电子邮件附件、离线预览或需要在没有支持资产文件夹的情况下移动的文档），嵌入的 Base64 HTML 仍然有用。链接资源更适合在 Web 应用提供 HTML、存储在 CMS 中、通过构建流水线优化或让浏览器独立缓存的场景。

## **常见问题**

**是否可以仅外部化图像而保持其他资源嵌入？**

可以。 在 `ExternalResourceController.getObjectStoringLocation` 中，仅对想要另存为独立文件的内容类型返回 [LinkEmbedDecision](https://reference.aspose.com/slides/zh/php-java/aspose.slides/linkembeddecision/) 的 `Link` 值，其余返回 `Embed`。

**为什么导出的图像扩展名与源演示文稿不同？**

Aspose.Slides 可能会在 HTML 导出过程中重新编码光栅图像，以提升文件大小或浏览器兼容性。例如，源文件中的图像可能会根据渲染结果写入为 JPEG 或 PNG。

**移动 HTML 文件后相对 URL 还能使用吗？**

相对 URL 仅在保持相同的相对文件夹结构时有效。如果 HTML 引用了 `assets/resource-1.png`，则 `assets` 文件夹必须与 HTML 文件保持相邻，除非您生成了不同的 URL 前缀。

**服务器应用是否可以复用相同的输出文件夹？**

不建议。 为每个转换作业使用唯一的输出目录或存储前缀，避免文件名冲突并防止一次导出覆盖另一​​次导出生成的资源。