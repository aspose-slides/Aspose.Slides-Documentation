---
title: 将演示文稿导出为带外部链接图像的 HTML
type: docs
weight: 100
url: /zh/java/exporting-presentations-to-html-with-externally-linked-images/
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
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides 将 PowerPoint 和 OpenDocument 演示文稿导出为 HTML，并将图像和其他资源保存为外部链接文件。"
---
## **概述**

默认情况下，Aspose.Slides 将演示文稿导出为自包含的 HTML 文件。图像和其他资源直接写入 HTML，通常以 Base64 数据的形式。这在需要单一可移植文件时很方便，但并不总是适合网站、CMS 或服务器端转换流水线的最佳格式。

当您希望以下情况时，请使用外部链接资源：

- 减小 HTML 文档的大小；
- 在浏览器或 CDN 中单独缓存图像、字体、音频或视频；
- 在导出后检查、替换、压缩或后处理生成的资源；
- 使输出结构更接近 Web 应用程序的预期。

有关一般的 HTML 转换工作流，请参阅[将 PowerPoint 演示文稿转换为 HTML](/slides/zh/java/convert-powerpoint-to-html/)。本文重点介绍导出的资源链接部分。

## **链接资源导出工作原理**

[ILinkEmbedController](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 让您的应用程序能够逐个资源决定导出器是将数据嵌入 HTML 还是外部保存并写入链接。

该接口有三种方法：

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 决定资源是应链接还是嵌入。
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 返回将写入生成的 HTML 或其他链接资源的 URL。
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 将链接资源数据写入磁盘或其他存储目标。

文件系统路径和浏览器 URL 是不同的概念。例如，下面的示例将资源文件写入磁盘上的 `html-output/assets`，而 HTML 中包含相对 URL，如 `assets/resource-1.svg`。浏览器会相对于包含链接的文件解析这些 URL。因此，从 `presentation.html` 链接到 SVG 文件使用 `assets/resource-1.svg`，而该 SVG 文件中链接到同一 `assets` 文件夹中保存的图像时使用 `resource-4.jpg`。

## **导出带链接资源的 HTML**

下面的 Java 示例创建输出目录，将 HTML 文件保存到该目录，并在 `assets` 子目录中存储链接资源。当 Aspose.Slides 提供或能够推断出安全的文件扩展名时，控制器会链接常见的图像、字体、音频、视频和 CSS 资源。未识别的资源保持嵌入。

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void main(String[] args) throws IOException {
        Path inputFilePath = Paths.get("presentation.pptx");
        Path outputDirectory = Paths.get("html-output");
        String assetDirectoryName = "assets";
        Path assetDirectory = outputDirectory.resolve(assetDirectoryName);

        Files.createDirectories(outputDirectory);
        Files.createDirectories(assetDirectory);

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFilePath.toString());
        try {
            Path htmlFilePath = outputDirectory.resolve("presentation.html");
            presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final Path assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

        private ExternalResourceController(Path assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
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

            try {
                Files.createDirectories(assetDirectory);
                Path filePath = assetDirectory.resolve(fileName);
                Files.write(filePath, entityData);
            } catch (IOException exception) {
                throw new IllegalStateException("Failed to save external resource " + resourceId + ".", exception);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
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
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().isEmpty()) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.isEmpty()) {
                return null;
            }

            for (int index = 0; index < extensionCharacters.length(); index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
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
}
```

导出后，输出文件夹结构如下：

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

具体文件取决于演示文稿内容和导出选项。例如，光栅图像通常导出为 JPEG 或 PNG。当使用不同的图像编解码器能够生成更小或更合适的文件时，Aspose.Slides 可能会选择与源演示文稿不同的编解码器。具有透明度的图像会导出为 PNG。

## **选择部署用 URL**

示例使用相对 URL 前缀：`assets/`。如果从 `html-output/presentation.html` 打开 `presentation.html`，浏览器会加载 `html-output/assets/resource-1.svg`。

当一个链接资源引用另一个链接资源时，示例在[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 中使用 `referrer` 参数，仅返回文件名。例如，如果 `resource-1.svg` 和 `resource-4.jpg` 都位于 `assets` 文件夹中，SVG 文件应引用 `resource-4.jpg`，而不是 `assets/resource-4.jpg`。

当文件部署在其他位置时，请使用不同的 URL 前缀：

- 当资源目录与 HTML 文件相邻时，使用 `assets/`。
- 当资源目录位于 HTML 文件上一级时，使用 `../assets/`。
- 当文件上传至 CDN 或静态文件服务器时，使用 `https://cdn.example.com/presentations/job-123/assets/`。

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 返回的 URL 必须与 [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 写入文件的最终部署位置相匹配。在服务器应用程序中，为每个转换任务使用唯一的输出目录或对象存储前缀，以避免覆盖其他导出的文件。

## **何时选择嵌入**

当输出必须是单个文件时（例如电子邮件附件、离线预览或将被移动且没有支持资源文件夹的文档），嵌入式 Base64 HTML 仍然有用。若 HTML 将由 Web 应用程序提供、存储在 CMS 中、通过构建流水线进行优化，或浏览器独立于 HTML 缓存资源，则链接资源更为合适。

## **常见问题**

**我可以仅将图像外部化而保持其他资源嵌入吗？**

可以。在[ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ilinkembedcontroller/) 中，仅对想要保存为独立文件的内容类型返回 `LinkEmbedDecision.Link`，对其他所有内容返回 `LinkEmbedDecision.Embed`。

**导出的图像扩展名为何与源演示文稿不同？**

Aspose.Slides 可能在 HTML 导出期间重新编码光栅图像，以改善文件大小或浏览器兼容性。例如，源文件中的图像可能会根据渲染结果写入为 JPEG 或 PNG。

**移动 HTML 文件后相对 URL 还能工作吗？**

相对 URL 仅在保持相同的相对文件夹结构时才有效。如果 HTML 引用了 `assets/resource-1.png`，则 `assets` 文件夹必须保持在 HTML 文件旁边，除非您生成了不同的 URL 前缀。

**服务器应用程序应该复用相同的输出文件夹吗？**

不应。为每个转换任务使用唯一的输出目录或存储前缀。这可以避免文件名冲突，并防止一次导出覆盖另一导出生成的资源。