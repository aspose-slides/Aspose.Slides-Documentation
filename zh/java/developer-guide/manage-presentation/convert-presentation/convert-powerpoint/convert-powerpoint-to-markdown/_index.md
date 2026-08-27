---
title: 在 Java 中将 PowerPoint 演示文稿转换为 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "在 Java 中将 PPT 和 PPTX 演示文稿转换为 Markdown，并控制导出的位图、元文件和 SVG 图像的保存位置和引用方式。"
---
## **Overview**

Aspose.Slides for Java 可以将 PPT 和 PPTX 演示文稿转换为 Markdown，以用于文档编写、静态站点、内容迁移和版本控制工作流。您可以选择 Markdown 方言，控制幻灯片内容的渲染方式，并决定导出图像的存储位置以及生成的 Markdown 如何引用这些图像。

默认情况下，Markdown 导出使用仅文本输出。要导出可视化内容，请使用 [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/markdownsaveoptions/) 方法将导出类型设置为来自 [MarkdownExportType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/markdownexporttype/) 枚举的 `Sequential` 或 `Visual` 值。`Sequential` 按顺序单独渲染幻灯片项目，而 `Visual` 将分组项目保持在一起，以保留它们的视觉关系。`TextOnly` 值不会发出图像资源，因此在该模式下不会调用图像保存回调。

## **Convert a Presentation to Markdown**

使用 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类加载源文件，然后调用 [Presentation.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 方法，并使用来自 [SaveFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveformat/) 枚举的 `Md` 值。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Select a Markdown Flavor**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/markdownsaveoptions/) 方法控制输出使用的 Markdown 规范。[Flavor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/flavor/) 枚举包括 CommonMark、GitHub Flavored Markdown 以及其他受支持的变体。

下面的示例将演示文稿导出为 CommonMark：

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Export Images Using the Default Local-Saving Behavior**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/markdownsaveoptions/) 类提供了两种配置本地保存图像的方法：

- [setBasePath](https://reference.aspose.com/slides/zh/java/com.aspose.slides/markdownsaveoptions/) 用于指定 Markdown 文档及其资源的基目录。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/zh/java/com.aspose.slides/markdownsaveoptions/) 用于指定图像子目录。默认值为 `Images`。

下面的示例渲染可视化内容，将图像写入 `output/assets`，并在 Markdown 文档中创建相对图像引用：

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

当自定义图像保存处理程序返回 `false` 时，此行为也会作为回退使用。

## **Customize Image Saving and Markdown Links**

使用 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh/java/com.aspose.slides/markdownsaveoptions/) 方法注册回调，以处理在 Markdown 导出期间发出的非 SVG 位图和元文件资源。其 `MarkdownImageSavingHandler` 回调接收 [IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/) 对象、其 [ImageFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imageformat/) 值，以及作为单元素 `String[]` 参数的生成的 Markdown 链接。使用提供的格式保存或上传图像，并用必须出现在 Markdown 输出中的引用替换 `link[0]`。

以 SVG 格式发出的资源单独处理。使用 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh/java/com.aspose.slides/markdownsaveoptions/) 方法注册回调。其 `MarkdownSvgImageSavingHandler` 回调接收 [ISvgImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isvgimage/) 对象和单元素 `String[] link` 参数。SVG 没有 `ImageFormat` 参数；请改为使用 [ISvgImage.getSvgData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isvgimage/) 方法写入或上传其 XML 数据。根据导出模式和视觉分组，源演示文稿中的 SVG 可能会被光栅化或与其他内容合并；生成的非 SVG 资源随后会传递给图像保存回调。当每个导出的视觉资源都需要自定义处理时，请同时注册这两个回调。

处理程序的返回值决定由谁来处理图像：

- 返回 `true` 表示处理程序已保存、上传、转换或以其他方式处理了图像，并为 `link[0]` 分配了有效值。Aspose.Slides 会将该值写入 Markdown 文档，并且不会执行默认的本地保存。
- 返回 `false` 表示让 Aspose.Slides 按照由 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh/java/com.aspose.slides/markdownsaveoptions/) 和 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh/java/com.aspose.slides/markdownsaveoptions/) 设置的值本地保存图像并生成链接。

{{% alert color="warning" title="Important" %}}

返回 `true` 的处理程序需要对图像负责。如果它返回 `true` 但未为 `link[0]` 分配有效且非空的链接，导出将因 `InvalidOperationException` 而失败。

{{% /alert %}}

### **Save Images to a CDN Origin Directory and Use External URLs**

下面的示例将 `cdn-origin/presentations/quarterly-report` 视为已挂载或已同步的 CDN 源目录。每个处理程序提取生成的文件名，将图像保存到该自定义目录，并用公共 CDN URL 替换生成的本地引用。示例本身不执行网络上传：只有在目录被挂载为 CDN 源或其文件已发布到 CDN 后，URL 才会生效。对于对象存储，请将文件系统写入替换为存储 SDK 的上传操作，并仅在上传成功后为 `link[0]` 赋值。

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

位图处理程序有意对小于 128 × 128 像素的图像返回 `false`，因此 Aspose.Slides 会使用默认行为将这些图像保存到 `output/fallback-images`。较大的位图和元文件资源以及 SVG 资源则由自定义代码处理。例如，生成的本地引用 `fallback-images/image1.png` 将变为 `https://cdn.example.com/presentations/quarterly-report/image1.png`。处理程序仅在写入文件时使用操作系统路径；写入 Markdown 的链接使用正斜杠并对文件名进行 URL 编码。构建相对链接时也遵循同样规则：使用 `/`，而不是平台特定的目录分隔符。

## **FAQ**

**Can one handler process both raster images and SVG images?**

No. Use [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh/java/com.aspose.slides/markdownsaveoptions/) for emitted bitmap and metafile resources and [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh/java/com.aspose.slides/markdownsaveoptions/) for resources emitted as SVG. The former provides an [IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/) object and an [ImageFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imageformat/) value; the latter provides an [ISvgImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isvgimage/) object whose SVG data can be read with [ISvgImage.getSvgData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isvgimage/). A source SVG that is rasterized during export is processed by the image-saving callback instead.

**What happens when an image-saving handler returns `false`?**

Aspose.Slides uses its default local-saving behavior. The image location and generated reference are controlled by the values set with [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh/java/com.aspose.slides/markdownsaveoptions/) and [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh/java/com.aspose.slides/markdownsaveoptions/).

**Can a handler provide a URL without saving the image locally?**

Yes. The handler can upload the image to object storage or pass it to another service, assign the resulting URL to `link[0]`, and return `true`. The handler must complete the processing itself; returning `true` prevents the default local save.

**Why does Markdown export throw an `InvalidOperationException` from a handler?**

This exception occurs when the handler returns `true` but does not provide a valid link. Assign the relative path or external URL that should be written to Markdown before returning `true`.

**Which path separator should image links use?**

Use forward slashes in Markdown links and URLs. Use `Path.resolve` only for file-system paths, then construct or normalize the Markdown reference separately.

**Are hyperlinks preserved during Markdown export?**

Yes. Text [hyperlinks](/slides/zh/java/manage-hyperlinks/) are preserved as standard Markdown links. Slide [transitions](/slides/zh/java/slide-transition/) and [animations](/slides/zh/java/powerpoint-animation/) are not converted.

**Can presentations be converted to Markdown in parallel?**

You can process different presentation files in parallel, but do not share the same [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) instance between threads. Follow the [multithreading guidelines](/slides/zh/java/multithreading/) and use a separate instance for each file.