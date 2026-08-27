---
title: 在 Android 上通过 Java 将 PowerPoint 演示文稿转换为 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/androidjava/convert-powerpoint-to-markdown/
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
- Android
- Java
- Aspose.Slides
description: "在 Android 上通过 Java 将 PPT 和 PPTX 演示文稿转换为 Markdown，并控制导出的位图、元文件和 SVG 图像的保存位置及引用方式。"
---
## **概述**

Aspose.Slides for Android via Java 可以将 PPT 和 PPTX 演示文稿转换为 Markdown，以用于文档编写、静态站点、内容迁移和版本控制工作流。您可以选择 Markdown 方言，控制幻灯片内容的渲染方式，并决定导出图像的存储位置以及生成的 Markdown 如何引用它们。

默认情况下，Markdown 导出使用纯文本输出。若要导出可视内容，请使用 [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/markdownsaveoptions/) 方法将导出类型设置为来自 [MarkdownExportType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/markdownexporttype/) 枚举的 `Sequential` 或 `Visual` 值。`Sequential` 会按顺序分别渲染幻灯片项，而 `Visual` 则将分组项保持在一起，以保留它们的视觉关系。`TextOnly` 值不会输出图像资源，因此在该模式下不会调用图像保存回调。

## **将演示文稿转换为 Markdown**

使用 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类加载源文件，然后调用 [Presentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 方法，并使用来自 [SaveFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveformat/) 枚举的 `Md` 值。

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

## **选择 Markdown 方言**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/markdownsaveoptions/) 方法控制输出所使用的 Markdown 规范。[Flavor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/flavor/) 枚举包括 CommonMark、GitHub Flavored Markdown 以及其他受支持的变体。

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

## **使用默认的本地保存行为导出图像**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/markdownsaveoptions/) 类提供两种配置本地保存图像的方法：

- [setBasePath](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/markdownsaveoptions/) 指定 Markdown 文档及其资源的基目录。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/markdownsaveoptions/) 指定图像子目录。其默认值为 `Images`。

下面的示例渲染可视内容，将图像写入 `output/assets`，并在 Markdown 文档中创建相对图像引用：

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

该行为也会在自定义图像保存处理程序返回 `false` 时作为回退使用。

## **自定义图像保存和 Markdown 链接**

使用 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/markdownsaveoptions/) 方法注册一个回调，以处理 Markdown 导出期间发出的非 SVG 位图和元文件资源。其 `MarkdownImageSavingHandler` 回调会接收 [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/) 对象、其 [ImageFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imageformat/) 值以及作为单元素 `String[]` 参数的生成的 Markdown 链接。使用提供的格式保存或上传图像，并将 `link[0]` 替换为必须出现在 Markdown 输出中的引用。

以 SVG 格式发出的资源单独处理。使用 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/markdownsaveoptions/) 方法注册回调。其 `MarkdownSvgImageSavingHandler` 回调会接收 [ISvgImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isvgimage/) 对象和单元素 `String[] link` 参数。SVG 没有 `ImageFormat` 参数；请改为使用 [ISvgImage.getSvgData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isvgimage/) 方法写入或上传其 XML 数据。根据导出模式和可视分组，源演示文稿中的 SVG 可能会被光栅化或与其他内容合并；生成的非 SVG 资源随后会传递给图像保存回调。若每个导出的可视资源都需要自定义处理，请同时注册这两个回调。

处理程序的返回值决定谁来处理图像：

- 返回 `true` 表示处理程序已保存、上传、转换或以其他方式处理图像，并为 `link[0]` 分配了有效值。Aspose.Slides 将该值写入 Markdown 文档，并且不会执行默认的本地保存。
- 返回 `false` 表示让 Aspose.Slides 按照通过 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/markdownsaveoptions/) 和 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/markdownsaveoptions/) 设置的值本地保存图像并生成链接。

{{% alert color="warning" title="Important" %}}
返回 `true` 的处理程序需要对图像负责。如果它返回 `true` 但未为 `link[0]` 分配有效且非空的链接，导出将因 `InvalidOperationException` 而失败。
{{% /alert %}}

### **将图像保存到 CDN 源目录并使用外部 URL**

下面的示例将 `cdn-origin/presentations/quarterly-report` 视为已挂载或已同步的 CDN 源目录。每个处理程序提取生成的文件名，将图像保存到该自定义目录，并将生成的本地引用替换为公共 CDN URL。示例本身不执行网络上传：只有在目录实际作为 CDN 源挂载或其文件发布到 CDN 后，URL 才有效。对于对象存储，请将文件系统写入替换为存储 SDK 的上传操作，并仅在上传成功后为 `link[0]` 赋值。

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

位图处理程序有意对小于 128 × 128 像素的图像返回 `false`，因此 Aspose.Slides 会使用默认行为将这些图像保存到 `output/fallback-images`。较大的位图、元文件以及 SVG 资源则由自定义代码处理。例如，生成的本地引用 `fallback-images/image1.png` 会变为 `https://cdn.example.com/presentations/quarterly-report/image1.png`。处理程序仅在写入文件时使用操作系统路径；写入 Markdown 的链接使用正斜杠和 URL 转义的文件名。构建相对链接时同样使用 `/`，而不是平台特定的目录分隔符。

## **常见问题**

**一个处理程序能同时处理栅格图像和 SVG 图像吗？**

不能。请使用 [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/markdownsaveoptions/) 处理发出的位图和元文件资源，使用 [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/markdownsaveoptions/) 处理以 SVG 发出的资源。前者提供 [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/) 对象和 [ImageFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imageformat/) 值；后者提供 [ISvgImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isvgimage/) 对象，可通过 [ISvgImage.getSvgData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isvgimage/) 读取 SVG 数据。导出期间被光栅化的源 SVG 将由图像保存回调处理。

**当图像保存处理程序返回 `false` 时会发生什么？**

Aspose.Slides 将使用默认的本地保存行为。图像位置和生成的引用由 [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/markdownsaveoptions/) 和 [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/markdownsaveoptions/) 的设定值控制。

**处理程序可以在不本地保存图像的情况下提供 URL 吗？**

可以。处理程序可以将图像上传至对象存储或交给其他服务，随后将得到的 URL 赋给 `link[0]` 并返回 `true`。此时处理程序须自行完成所有处理；返回 `true` 会阻止默认的本地保存。

**为什么 Markdown 导出会因处理程序抛出 `InvalidOperationException`？**

当处理程序返回 `true` 但未提供有效链接时会出现此异常。请在返回 `true` 之前为 Markdown 分配应写入的相对路径或外部 URL。

**图像链接应使用哪种路径分隔符？**

在 Markdown 链接和 URL 中使用正斜杠。仅在文件系统路径中使用 `Path.resolve`，随后单独构造或规范化 Markdown 引用。

**超链接在 Markdown 导出时会保留吗？**

会。文本 [hyperlinks](/slides/zh/androidjava/manage-hyperlinks/) 会保留为标准的 Markdown 链接。幻灯片 [transitions](/slides/zh/androidjava/slide-transition/) 和 [animations](/slides/zh/androidjava/powerpoint-animation/) 则不会被转换。

**可以并行将多个演示文稿转换为 Markdown 吗？**

可以并行处理不同的演示文稿文件，但不要在多个线程之间共享同一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 实例。请遵循 [multithreading guidelines](/slides/zh/androidjava/multithreading/) 并为每个文件使用独立的实例。