---
title: 将演示文稿导出为具有外部链接图像的 HTML
type: docs
weight: 100
url: /zh/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Android 上通过 Java 将 PowerPoint 和 OpenDocument 演示文稿导出为 HTML，并将图像和其他资源保存为外部链接文件。"
---
## **概述**

默认情况下，Aspose.Slides 将演示文稿导出为一个自包含的 HTML 文件。图像和其他资源会直接写入 HTML，通常采用 Base64 数据。这样在需要单个可移植文件时非常方便，但对于网页视图、CMS 或随后发布输出的服务器端转换流水线来说，并不总是最佳格式。

当你希望：

- 减小 HTML 文档的大小；
- 在浏览器或 CDN 中单独缓存图像、字体、音频或视频；
- 在导出后检查、替换、压缩或后处理生成的资源；
- 保持输出结构更接近 Web 应用程序的预期；

请使用外部链接资源。

有关通用的 HTML 转换工作流，请参阅[转换 PowerPoint 演示文稿为 HTML](/slides/zh/androidjava/convert-powerpoint-to-html/)。本文重点关注导出过程中的资源链接部分。

## **如何链接资源导出工作**

[ILinkEmbedController](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilinkembedcontroller/) 允许你的应用程序逐个资源决定是将数据嵌入 HTML，还是外部保存并写入链接。

该接口包含三个方法：

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilinkembedcontroller/) 决定资源是链接还是嵌入。
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilinkembedcontroller/) 返回将写入生成的 HTML 或其他链接资源的 URL。
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilinkembedcontroller/) 将链接资源的数据写入磁盘或其他存储目标。

文件系统路径和浏览器 URL 是分开的概念。例如，下面的示例将资源文件写入应用程序文件存储中的 `html-output/assets`，而 HTML 中包含诸如 `assets/resource-1.svg` 的相对 URL。浏览器会相对于包含链接的文件解析这些 URL。因此，`presentation.html` 到 SVG 文件的链接使用 `assets/resource-1.svg`，而该 SVG 文件到同一 `assets` 文件夹下的图像的链接使用 `resource-4.jpg`。

## **导出带链接资源的 HTML**

以下 Android Java 示例创建输出目录，将 HTML 文件保存到该目录，并在 `assets` 子目录中存储链接资源。将 `context.getFilesDir()` 等应用拥有的目录作为 `applicationFilesDirectory` 传入。代码避免使用 `java.nio.file` API，因而兼容 Android `minSdk` 19。

控制器在 Aspose.Slides 提供或能够推断安全文件扩展名时，链接常见的图像、字体、音频、视频和 CSS 资源。未识别的资源保持嵌入。

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
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

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
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
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
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
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
        }
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

具体文件取决于演示文稿内容和导出选项。例如，光栅图像通常导出为 JPEG 或 PNG。Aspose.Slides 可能会选择不同于源演示文稿的图像编解码器，以获得更小或更合适的文件。具有透明度的图像会导出为 PNG。

## **选择部署 URL**

示例使用相对 URL 前缀：`assets/`。如果 `presentation.html` 位于 `html-output/presentation.html`，浏览器会加载 `html-output/assets/resource-1.svg`。

当一个链接资源引用另一个链接资源时，示例在[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilinkembedcontroller/) 中使用 `referrer` 参数，仅返回文件名。例如，若 `resource-1.svg` 与 `resource-4.jpg` 均位于 `assets` 文件夹，SVG 文件应引用 `resource-4.jpg`，而不是 `assets/resource-4.jpg`。

在文件部署到其他位置时请使用不同的 URL 前缀：

- 当资源目录与 HTML 文件相邻时使用 `assets/`；
- 当资源目录位于 HTML 文件上一级时使用 `../assets/`；
- 当文件上传到 CDN 或静态文件服务器时使用 `https://cdn.example.com/presentations/job-123/assets/`。

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilinkembedcontroller/) 返回的 URL 必须与 [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilinkembedcontroller/) 写入的文件的最终部署位置相匹配。在 Android 应用中，根据发布工作流使用应用专用存储、缓存目录或通过存储访问框架获取的目录。在服务器应用中，为每个转换任务使用唯一的输出目录或对象存储前缀，以避免覆盖其他导出的文件。

## **何时使用嵌入而不是链接**

当输出必须是单个文件（例如电子邮件附件、离线预览或将被移动且不带资源文件夹的文档）时，嵌入 Base64 的 HTML 仍然有用。若 HTML 将由 Web 应用提供、存储在 CMS 中、通过构建流水线优化或让浏览器独立于 HTML 缓存，链接资源则更为合适。

## **FAQ**

**我可以只外部化图像而保留其他资源嵌入吗？**

可以。在 [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ilinkembedcontroller/) 中，仅对你想保存为单独文件的内容类型返回 `Link`（来自 [LinkEmbedDecision](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/linkembeddecision/)），其余全部返回 `Embed`。

**为什么导出的图像扩展名与源演示文稿不同？**

Aspose.Slides 可能在 HTML 导出期间重新编码光栅图像，以改善文件大小或浏览器兼容性。例如，源文件中的图像可能根据渲染结果写入为 JPEG 或 PNG。

**移动 HTML 文件后相对 URL 还能工作吗？**

相对 URL 仅在保持相同的相对文件夹结构时有效。如果 HTML 引用 `assets/resource-1.png`，则 `assets` 文件夹必须与 HTML 文件保持相邻，除非你生成了不同的 URL 前缀。

**我可以将资源写入 Android 的公共外部存储吗？**

可以，只要你的应用拥有针对目标 Android 版本的有效目的地和权限模型。对于仅供应用内部使用的生成 HTML，应用专用文件或缓存目录通常更简单。对于面向用户的输出，请使用用户选定的位置或其他符合你应用需求的存储方式。

**服务器应用应该复用相同的输出文件夹吗？**

不应该。为每个转换任务使用唯一的输出目录或存储前缀。这可以避免文件名冲突，并防止一次导出覆盖另一份导出的资源。