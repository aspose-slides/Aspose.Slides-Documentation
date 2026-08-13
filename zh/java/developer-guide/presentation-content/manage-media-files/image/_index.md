---
title: 使用 Java 优化演示文稿中的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/java/image/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 和 OpenDocument 中简化图像管理，优化性能并实现工作流自动化。"
---
## **简介**

图像可以使演示更具吸引力和视觉冲击力。在 Microsoft PowerPoint 中，您可以从文件、互联网或其他来源将图片插入幻灯片。同样，Aspose.Slides 也允许以多种方式向演示幻灯片添加图像。

{{% alert  title="Tip" color="info" %}} 

Aspose 提供免费的转换器——[JPEG to PowerPoint](https://products.aspose.app/slides/zh/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/zh/import/png-to-ppt)——可帮助您快速从图像创建演示文稿。 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

如果您想将图像作为图片框添加——尤其是计划对其进行缩放、应用效果或使用其他标准格式选项——请参阅 [Picture Frame](/slides/zh/java/picture-frame/)。 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

您可以将图像从一种格式转换为另一种格式。请参阅以下页面：转换 [图像转JPG](https://products.aspose.com/slides/zh/java/conversion/image-to-jpg/)、[JPG转图像](https://products.aspose.com/slides/zh/java/conversion/jpg-to-image/)、[JPG转PNG](https://products.aspose.com/slides/zh/java/conversion/jpg-to-png/)、[PNG转JPG](https://products.aspose.com/slides/zh/java/conversion/png-to-jpg/)、[PNG转SVG](https://products.aspose.com/slides/zh/java/conversion/png-to-svg/)，以及 [SVG转PNG](https://products.aspose.com/slides/zh/java/conversion/svg-to-png/)。 

{{% /alert %}}

Aspose.Slides 支持 JPEG、PNG、BMP、GIF 等常用格式的图像。 

## **在本地存储的图像添加到幻灯片**

您可以将计算机上存储的一个或多个图像添加到演示幻灯片。以下 Java 示例代码演示了如何向幻灯片添加图像：

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

## **从网络添加图像到幻灯片**

如果要添加到幻灯片的图像未存储在本地，您可以直接从网络添加。

以下 Java 示例代码演示了如何从网络将图像添加到幻灯片：

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

幻灯片母版存储并控制使用该母版的幻灯片的主题和布局信息。向幻灯片母版添加图像后，该图像会出现在基于该母版的每张幻灯片上。

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

## **将图像设为幻灯片背景**

您可以使用图片作为一个或多个幻灯片的背景。有关详细信息，请参阅 *[Setting Images as Backgrounds for Slides](/slides/zh/java/presentation-background/#setting-images-as-background-for-slides)*。

## **将 SVG 添加到演示文稿**

可以使用 [SvgImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgimage/) 类将 SVG 内容添加到演示文稿。生成的 [ISvgImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isvgimage/) 对象随后可以添加到演示文稿的图像集合中，并用于创建图片框。

以下 Java 示例导入了一个自包含的 SVG 字符串。该 SVG 中使用的所有图像、样式和其他资源均直接嵌入在 SVG 内容中。

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

## **导入带外部资源的 SVG 内容**

从设计工具、图表编辑器、图标系统和 Web 流程导出的 SVG 文件可能会引用存储在 SVG 文档外部的资源。例如，SVG 可以包含 `images/photo.png` 这样的图像链接、CSS `url(...)` 值或字体 URL。

要导入此类 SVG 内容，请实现一个 [IExternalResourceResolver](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iexternalresourceresolver/) 并将其与基 URI 一起传递给相应的 [SvgImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/svgimage/) 构造函数。基 URI 用于标识 SVG 文档的位置，并用于解析相对链接。

[ISvgImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isvgimage/) 接口提供对导入的 SVG 信息的访问：

- `getSvgContent()` 返回 SVG 标记的字符串形式。
- `getSvgData()` 返回 SVG 内容的字节数组。
- `getBaseUri()` 返回用于相对链接的基 URI。
- `getExternalResourceResolver()` 返回分配给 SVG 图像的解析器。

### **实现外部资源解析器**

解析器有两个方法：

- `resolveUri` 将基 URI 与相对资源链接组合并返回绝对 URI。无法解析或不允许的链接返回 `null`。
- `getEntity` 为绝对资源 URI 返回可读取的流。当资源缺失、被阻止或不可用时返回 `null`。必要时也可以返回回退流。

以下解析器仅从允许的本地目录加载链接资源。网络资源和超出允许目录的路径将被阻止。对于未解析的图像链接，可返回可选的回退图像。

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

            // 此解析器有意仅允许本地文件。
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

            // 仅在图像资源时使用回退。返回图像流
            // 对于缺失的字体或样式表则无效。
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

以下 Java 示例将 SVG 文件的 URI 作为基 URI 并提供自定义解析器。解析器将相对图像链接转换为绝对 URI，并在 Aspose.Slides 处理 SVG 时返回包含链接资源的流。

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

`SvgImage` 类还提供接受字节数组或输入流的重载形式，并可配合外部资源解析器和基 URI 使用。

{{% alert title="Important" color="warning" %}}

资源解析器在 Aspose.Slides 处理和渲染 SVG 时使外部资源可用。它不会修改原始 SVG 标记，也不会自动将已解析的资源嵌入其中。

当 `ISvgImage` 被添加到演示文稿的图像集合时，PPTX 文件可以同时包含原始 SVG 表示和光栅回退图像。生成的回退图像中可能出现链接资源，而存储的 SVG 中的相对链接（如 `images/photo.png`）保持不变。渲染本机 SVG 表示的应用程序在原始外部资源不可用时可能会省略该链接内容。

{{% /alert %}}

### **创建便携式 SVG 图片**

要创建不依赖外部文件的 SVG 图片，请在创建 `SvgImage` 前使 SVG 自包含。例如，用包含图像数据的 `data:` URI 替换链接的图像 URL：

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

在所有必需资源嵌入到 SVG 内容后，创建 `SvgImage`，将其添加到演示文稿的图像集合中，并按前例插入到图片框中。

### **处理缺失或被阻止的资源**

当资源 URI 无效、被禁止或无法解析时，`resolveUri` 返回 `null`。当资源无法读取时，`getEntity` 返回 `null`。Aspose.Slides 在可能的情况下继续处理 SVG，而不使用该资源。

可以为缺失的资源返回回退流，但其内容必须与请求的资源类型兼容。例如，仅对缺失的图像返回图像流，而不是对字体或样式表返回图像流。

{{% alert title="Security" color="warning" %}}

请勿从不受信任的 SVG 文件解析任意文件路径或无限制的网络 URL。限制允许的方案、目录和主机。对于网络资源，还应设置连接超时、响应大小限制以及内容验证。

{{% /alert %}}

## **将 SVG 转换为形状集合**

Aspose.Slides 可以将 SVG 转换为形状集合，类似于 PowerPoint 中的对应功能：

![PowerPoint Popup Menu](img_01_01.png)

此功能由 [IShapeCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IShapeCollection) 接口的 [addGroupShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) 方法的重载提供，该重载接受一个 [ISvgImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISvgImage) 对象作为第一个参数。

以下 Java 示例代码展示了如何使用此方法将 SVG 文件转换为形状集合：

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

// 创建一个新演示文稿。
IPresentation presentation = new Presentation();
try {
    // 读取 SVG 文件内容。
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // 创建 SvgImage 对象。
    ISvgImage svgImage = new SvgImage(svgContent);

    // 获取幻灯片大小。
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // 将 SVG 图像转换为形状组并按幻灯片大小进行缩放。
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

Aspose.Slides for Java 允许您使用 Aspose.Cells 从 Excel 工作表生成 EMF 图像并将其添加到演示幻灯片。

以下 Java 示例代码演示了如何实现：

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

        // 按原样添加文件，使图片保持矢量 EMF 而不是光栅化。
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

Aspose.Slides 允许您替换存储在演示文稿图像集合中的图像，包括幻灯片形状使用的图像。本节介绍了更新集合中图像的多种方式。您可以使用原始字节数据、[IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/) 实例或集合中已有的其他图像来替换目标图像。

请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类加载包含图像的演示文件。
2. 将新图像从文件加载到字节数组中。
3. 使用字节数组将目标图像替换为新图像。
4. 在第二种方法中，将图像加载到 [IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/) 对象，并使用该对象替换目标图像。
5. 在第三种方法中，将目标图像替换为演示文稿图像集合中已存在的图像。
6. 将修改后的演示文稿写入为 PPTX 文件。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 第一种方法。
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // 第二种方法。
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // 第三种方法。
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // 将演示文稿保存到文件。
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

使用 Aspose 免费的 [Text to GIF](https://products.aspose.app/slides/zh/text-to-gif) 转换器，您可以轻松为文本添加动画并创建 GIF。 

{{% /alert %}}

## **常见问题**

**插入后原始图像分辨率是否保持不变？**

是的。源像素会被保留，但最终外观取决于在幻灯片上对 [picture](/slides/zh/java/picture-frame/) 的缩放方式以及保存时的压缩情况。

**一次性更换数十张幻灯片中的同一徽标的最佳方式是什么？**

将徽标放置在母版幻灯片或布局上，并在演示文稿的图像集合中替换它——所有使用该资源的元素都会更新。

**插入的 SVG 能否转换为可编辑的形状？**

可以。您可以将 SVG 转换为一组形状，随后各个部分即可使用标准形状属性进行编辑。

**如何一次性将图片设为多张幻灯片的背景？**

在母版幻灯片或相应布局上 [Assign the image as the background](/slides/zh/java/presentation-background/)，使用该母版/布局的所有幻灯片都会继承该背景。

**如何防止因为大量图片导致演示文稿体积过大？**

重复使用单个图像资源而非复制，选择合理的分辨率，保存时进行压缩，并在适当情况下将重复的图形保留在母版上。