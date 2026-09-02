---
title: 在 Android 上优化演示文稿中的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/androidjava/image/
keywords:
- 添加图像
- 添加图片
- 添加位图
- 替换图像
- 替换图片
- 来自网络
- 背景
- 添加 PNG
- 添加 JPG
- 添加 SVG
- 外部 SVG 资源
- SVG 解析器
- 链接的 SVG 图像
- SVG 字体
- 添加 EMF
- 添加 WMF
- 添加 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，简化 PowerPoint 和 OpenDocument 中的图像管理，优化性能并自动化工作流。"
---
## **简介**

图像使演示文稿更具吸引力和视觉冲击力。 在 Microsoft PowerPoint 中，您可以从文件、互联网或其他来源将图片插入到幻灯片中。 类似地，Aspose.Slides 允许您以多种方式向演示文稿幻灯片添加图像。

{{% alert  title="Tip" color="primary" %}} 
Aspose 提供免费转换器——[JPEG to PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——可快速从图像创建演示文稿。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
如果您想将图像作为图片框添加——尤其是计划调整大小、应用效果或使用其他标准格式选项——请参阅 [Picture Frame](/slides/zh/androidjava/picture-frame/)。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
您可以将图像从一种格式转换为另一种格式。请参阅以下页面：convert [image to JPG](https://products.aspose.com/slides/zh/androidjava/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/zh/androidjava/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/zh/androidjava/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/zh/androidjava/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/zh/androidjava/conversion/png-to-svg/), and [SVG to PNG](https://products.aspose.com/slides/zh/androidjava/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides 支持 JPEG、PNG、BMP、GIF 等常用图像格式。 

## **将本地存储的图像添加到幻灯片**

您可以将存储在计算机上的一个或多个图像添加到演示文稿幻灯片。以下 Java 示例代码演示了如何向幻灯片添加图像：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **将网络图像添加到幻灯片**

如果您想添加到幻灯片的图像未存储在计算机上，您可以直接从网络添加。

以下 Java 示例代码演示了如何从网络向幻灯片添加图像：

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **向幻灯片母版添加图像**

幻灯片母版存储并控制使用该母版的幻灯片的主题和布局等信息。向幻灯片母版添加图像后，图像会出现在基于该母版的每张幻灯片上。

以下 Java 示例代码演示了如何向幻灯片母版添加图像：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **将图像用作幻灯片背景**

您可以将图片用作一个或多个幻灯片的背景。更多详情，请参阅 *[Setting Images as Backgrounds for Slides](/slides/zh/androidjava/presentation-background/#setting-images-as-background-for-slides)*。

## **向演示文稿添加 SVG**

可以使用 [SvgImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/svgimage/) 类将 SVG 内容添加到演示文稿中。随后得到的 [ISvgImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isvgimage/) 对象可添加到演示文稿的图像集合，并用于创建图片框。

以下 Java 示例导入了一个自包含的 SVG 字符串。此 SVG 使用的所有图像、样式及其他资源均直接嵌入在 SVG 内容中。

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **导入包含外部资源的 SVG 内容**

从设计工具、图表编辑器、图标系统和网络管线导出的 SVG 文件可能会引用存储在 SVG 文档之外的资源。例如，SVG 可以包含类似 `images/photo.png` 的图像链接、CSS `url(...)` 值或字体 URL。

要导入此类 SVG 内容，需要创建一个 [IExternalResourceResolver](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iexternalresourceresolver/) 实现，并将其连同基 URI 一起传递给相应的 [SvgImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/svgimage/) 构造函数。基 URI 标识 SVG 文档的位置，用于解析相对链接。

[ISvgImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isvgimage/) 接口提供了对已导入 SVG 信息的访问：

- `getSvgContent()` 返回 SVG 标记字符串。
- `getSvgData()` 返回 SVG 内容的字节数组。
- `getBaseUri()` 返回用于相对链接的基 URI。
- `getExternalResourceResolver()` 返回分配给 SVG 图像的解析器。

### **实现外部资源解析器**

解析器提供两个方法：

- `resolveUri` 将基 URI 与相对资源链接合并并返回绝对 URI。无法解析或不允许的链接返回 `null`。
- `getEntity` 为绝对资源 URI 返回可读取的流。资源缺失、被阻止或不可用时返回 `null`，必要时也可以返回回退流。

以下解析器仅从允许的本地目录加载链接资源。网络资源及超出允许目录的路径被阻止。对于无法解析的图像链接，返回可选的回退图像。

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // 此解析器专门仅允许本地文件。
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // 仅对图像资源使用回退。返回图像流
            // 对于缺失的字体或样式表则不合法。
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **在 SVG 导入期间解析链接资源**

假设 `assets/diagram.svg` 包含如下相对引用：

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

以下 Java 示例将 SVG 文件 URI 作为基 URI 并提供自定义解析器。解析器将相对图像链接转换为绝对 URI，并在 Aspose.Slides 处理 SVG 时返回包含该链接资源的流。

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// 基础 URI 表示 SVG 文档的位置。
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage 公开源内容、二进制数据、基础 URI 和解析器。
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`SvgImage` 类还提供接受 SVG 数据字节数组或输入流的重载方法，同时可以指定外部资源解析器和基 URI。

{{% alert title="Important" color="warning" %}}
资源解析器在 Aspose.Slides 处理和渲染 SVG 时提供外部资源。它不会修改原始 SVG 标记或自动将解析的资源嵌入其中。

当 `ISvgImage` 被添加到演示文稿的图像集合时，PPTX 文件可能同时包含原始 SVG 表示和光栅回退图像。链接资源可能出现在生成的回退图像中，而相对链接如 `images/photo.png` 在存储的 SVG 中保持不变。渲染原生 SVG 表示的应用程序在原始外部资源不可用时可能会省略链接内容。
{{% /alert %}}

### **创建可移植的 SVG 图片**

要创建不依赖外部文件的 SVG 图片，请在创建 `SvgImage` 之前使 SVG 自包含。例如，用包含图像数据的 `data:` URI 替换链接的图像 URL：

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

在将所有必需资源嵌入 SVG 内容后，创建 `SvgImage`、将其添加到演示文稿图像集合，并像前例那样插入到图片框中。

### **处理缺失或被阻止的资源**

当资源 URI 无效、被禁止或无法解析时，`resolveUri` 应返回 `null`。当资源无法读取时，`getEntity` 应返回 `null`。Aspose.Slides 在可能的情况下会继续处理 SVG。

可以为缺失资源返回回退流，但其内容必须与请求的资源类型兼容。例如，仅在缺少图像时返回图像流，而不是返回字体或样式表流。

{{% alert title="Security" color="warning" %}}
请勿从不受信任的 SVG 文件解析任意文件路径或无限制的网络 URL。限制允许的方案、目录和主机。对于网络资源，还应设置连接超时、响应大小限制以及内容验证。
{{% /alert %}}

## **将 SVG 转换为一组形状**

Aspose.Slides 可以将 SVG 转换为一组形状，类似于 PowerPoint 中的相应功能：

![PowerPoint Popup Menu](img_01_01.png)

此功能由 [IShapeCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IShapeCollection) 接口的 [addGroupShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) 方法的重载提供，首参数接受 [ISvgImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ISvgImage) 对象。

以下 Java 示例代码演示了如何使用此方法将 SVG 文件转换为一组形状：

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// 源 SVG 文件名。
String svgFileName = "sample.svg";

// 输出演示文稿文件名。
String outPptxPath = "presentation.pptx";

// 创建新演示文稿。
IPresentation presentation = new Presentation();
try {
    // 读取 SVG 文件内容。
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // 创建 SvgImage 对象。
    ISvgImage svgImage = new SvgImage(svgContent);

    // 获取幻灯片尺寸。
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // 将 SVG 图像转换为形状组并按幻灯片尺寸进行缩放。
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // 以 PPTX 格式保存演示文稿。
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **将图像作为 EMF 添加到幻灯片**

Aspose.Slides for Android via Java 允许您使用 Aspose.Cells 从 Excel 工作表生成 EMF 图像并将其添加到演示文稿幻灯片。

以下 Java 示例代码展示了具体做法：

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// 将工作簿保存到流中。
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // 原样添加文件，使图片保持向量 EMF 而不是栅格化。
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **替换图像集合中的图像**

Aspose.Slides 让您能够替换存储在演示文稿图像集合中的图像，包括幻灯片形状使用的图像。本节描述了更新集合中图像的多种方式。您可以使用原始字节数据、[IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/) 实例或集合中已存在的其他图像来替换图像。

请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类加载包含图像的演示文件。
2. 将新图像从文件加载到字节数组中。
3. 使用字节数组将目标图像替换为新图像。
4. 在第二种方法中，将图像加载为 [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/) 对象，并使用该对象替换目标图像。
5. 在第三种方法中，用演示文稿图像集合中已存在的图像替换目标图像。
6. 将修改后的演示文稿写出为 PPTX 文件。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 第一种方式。
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // 第二种方式。
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // 第三种方式。
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // 将演示文稿保存到文件。
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
使用 Aspose 免费的 [Text to GIF](https://products.aspose.app/slides/zh/text-to-gif) 转换器，您可以轻松为文本制作动画并创建 GIF。 
{{% /alert %}}

## **常见问题**

**插入后原始图像分辨率是否保持不变？**

是的。源像素被保留，但最终显示取决于在幻灯片上对[picture](/slides/zh/androidjava/picture-frame/)的缩放方式以及保存时是否进行压缩。

**一次性替换数十张幻灯片中的相同徽标的最佳方法是什么？**

将徽标放置在母版幻灯片或布局上，并在演示文稿的图像集合中替换它——更改会传播到所有使用该资源的元素。

**插入的 SVG 能否转换为可编辑的形状？**

可以。您可以将 SVG 转换为形状组，然后各个部件即可使用标准形状属性进行编辑。

**如何一次性将图片设置为多个幻灯片的背景？**

[将图像分配为背景](/slides/zh/androidjava/presentation-background/) 在母版幻灯片或相应布局上——使用该母版/布局的任何幻灯片都将继承该背景。

**如何防止由于大量图片导致演示文稿体积过大？**

重复使用单个图像资源而不是复制，选择合适的分辨率，保存时进行压缩，并在适当情况下将重复图形放在母版上。