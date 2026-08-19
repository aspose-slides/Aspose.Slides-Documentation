---
title: 在 Android 上优化演示文稿中的图像管理
linktitle: 管理图像
type: docs
weight: 10
url: /zh/androidjava/image/
keywords:
- 添加图像
- 添加图片
- 替换图像
- 图像集合
- 图片框
- 链接图像
- 背景
- 添加 PNG
- 添加 JPG
- 添加 SVG
- SVG 转形状
- 外部 SVG 资源
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何在 PowerPoint 和 OpenDocument 演示文稿中使用 Aspose.Slides for Android via Java 添加、复用、链接、替换和管理光栅图像及 SVG 图像。"
---
## **介绍**

Aspose.Slides for Android via Java 提供了多种处理图像的方式，每种方式都有不同的用途。您可以在演示文稿中存储图像、在图片框中显示图像、将其用作幻灯片背景、链接到外部图像、替换共享的图像资源，或将 SVG 内容转换为可编辑的形状。  
本文重点介绍图像资源以及它们在整个演示文稿中的使用方式。有关对单个图片框进行裁剪、透明度、效果、拉伸以及其他格式设置的内容，请参阅[Picture Frame](/slides/zh/androidjava/picture-frame/)。

## **了解图像模型**

以下 API 概念密切相关，但不可互换：

- [presentation image collection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimagecollection/) 用于存储演示文稿使用的图像资源。使用 [ImageCollection.addImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imagecollection/) 添加图像数据并获取 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/) 资源。
- [picture frame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipictureframe/) 是一种在幻灯片、布局或母版上显示图像的形状。使用 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/) 将图像资源放置在幻灯片上。
- 幻灯片背景将图像用作幻灯片填充的一部分，而不是形状。因此其行为不同于图片框。
- [IPPImage.replaceImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/) 可替换图像资源。如果多个演示文稿元素使用该资源，它们都会使用替换后的图像。
- 将 SVG 转换为形状会创建可编辑的幻灯片形状。转换后，内容不再作为单个图片资源进行管理。

因此，典型的工作流程是：将图像数据添加到图像集合中，获取一个 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/)，然后在一个或多个图片框或填充中使用该资源。

## **添加嵌入图像**

要插入本地图像，加载文件，将其添加到图像集合中，并创建使用返回的 `IPPImage` 的图片框。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以这种方式添加的图像会嵌入到演示文稿中，因此生成的文件不依赖于原始图像文件的可用性。

### **从网络添加图像**

当图像可通过 HTTP 或 HTTPS 获取时，下载其字节，将其添加到演示文稿的图像集合中，并像本地图像一样使用返回的图像资源。

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在长期运行的应用程序中，应重用适合该应用的 HTTP 客户端或连接管理策略，而不是反复创建不必要的网络基础设施。当来源不可靠时，还应验证远程 URL、响应大小和内容类型。

## **在幻灯片间复用图像**

如果同一图像需要使用多次，请只在演示文稿中添加一次，并在创建额外的图片框时复用返回的 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/)。这样可避免重复加载相同的源数据，并明确共享图像资源与其使用之间的关系。

对于应自动出现在多张幻灯片上的图形，例如公司徽标，建议将图片框放置在[slide master](/slides/zh/androidjava/slide-master/)或布局上，而不是在每张幻灯片中添加等效的形状。

## **将图像用作幻灯片背景**

背景图像被分配给幻灯片填充；它不是以图片框形状添加的。当图片需要覆盖幻灯片背景且不应像普通幻灯片对象那样进行操作时，这非常有用。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

有关更多背景选项（包括母版和布局背景），请参阅[Presentation Background](/slides/zh/androidjava/presentation-background/)。

## **嵌入图像和链接图像**

嵌入图像和链接图像在可移植性和文件大小方面有不同的取舍：

- **Embedded image:** 图像数据存储在演示文稿内部。演示文稿是自包含的，但文件大小会包含图像数据。
- **Linked image:** 演示文稿存储指向外部图像的路径或 URL。这可以减小演示文稿的大小，但在打开或渲染演示文稿时，外部资源必须保持可访问。

可以通过 [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islidespicture/) 指定外部路径或 URL 来创建链接图片，而不是嵌入图像数据。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

仅在部署环境能够可靠访问外部资源时才使用链接图像。对于必须离线运行或在系统之间移动的演示文稿，嵌入图像通常更安全。

## **使用 SVG 图像**

SVG 是矢量格式，可用于图标、图表以及其他需要在不失细节的情况下缩放的图形。Aspose.Slides 同时支持将 SVG 作为图像资源和可编辑幻灯片形状的来源。

### **将 SVG 添加为图像**

创建 [SvgImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/svgimage/)，将其添加到图像集合中，然后将生成的图像资源放入图片框中。

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **带有外部资源的 SVG 文件**

SVG 可以引用外部图像、样式表或字体。针对这些情况，[SvgImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/svgimage/) 提供接受 [IExternalResourceResolver](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iexternalresourceresolver/) 和基础 URI 的构造函数。解析器可以将相对 URI 映射为允许的绝对 URI，并返回所请求资源的流。

解析器在 Aspose.Slides 处理 SVG 时提供外部资源，但并不会将 SVG 重写为自包含文档。如果 SVG 必须保持可移植性，请将其所需资源嵌入 SVG 本身，例如使用 `data:` URI 来链接图像。

当 SVG 文件来自不可信来源时，应限制解析器可访问的协议、文件位置和主机。网络解析器还应使用超时、响应大小限制和内容验证。

### **将 SVG 转换为可编辑形状**

Aspose.Slides 可以将 SVG 转换为一组可编辑的幻灯片形状，类似于相应的 PowerPoint 命令。

![PowerPoint Popup Menu](img_01_01.png)

使用接受 [ISvgImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isvgimage/) 的 [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/) 重载来执行转换。

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

当需要将单个矢量元素编辑为 PowerPoint 形状时，请使用 SVG 转形状转换。如果 SVG 只需显示，保持其为图像更简单，也避免创建大量单独的形状。

## **替换已有图像资源**

当需要替换已有图像资源时，请使用 [IPPImage.replaceImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/)。这对于共享图形（如徽标）尤其有用。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果多个图片框、背景、母版或布局使用相同的图像资源，替换该资源会更新所有这些使用位置。如果仅需要更改某个图片框，请为该框分配不同的图像，而不是替换共享资源。

`replaceImage` 还提供接受字节数组或另一个 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/) 的重载。

## **实用图像管理指南**

### **控制演示文稿大小**

大型光栅图像会导致演示文稿体积过大。请使用尺寸符合实际显示需求的源图像，尽可能复用共享图像资源，并避免嵌入相同全分辨率图形的重复副本。

对于已放置在图片框中的光栅图片，可使用 [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipicturefillformat/) 根据选定的分辨率和裁剪设置压缩图像数据。这属于图片框处理，而非图像集合管理，相关格式化操作请参阅[Picture Frame](/slides/zh/androidjava/picture-frame/)。

### **在嵌入和链接内容间做选择**

嵌入使演示文稿可移植，因为所有必需的图像数据随文件一起存在。链接可以减小文件大小，但会引入外部依赖。仅在该依赖可接受且稳定时才使用链接。

### **复用共享品牌元素**

对于重复使用的徽标、水印或装饰性图形，请使用单个图像资源并复用。如果图形属于演示文稿的设计而非幻灯片内容，请将其放置在母版或布局上，以便相应幻灯片继承。

### **保持 SVG 资源的可移植性**

自包含的 SVG 比依赖外部文件或网络资源的 SVG 更易于移动和一致渲染。尽可能在导入 SVG 前嵌入所需资源。仅在需要编辑单个矢量元素时才将 SVG 转换为形状。

### **使用现代跨平台图像 API**

对于新的 Android via Java 代码，请使用 Aspose.Slides 的 [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/) 和 [Images](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/images/) API，而不是基于 `android.graphics.Bitmap` 的旧版公共 API。迁移指导请参阅[Modern API](/slides/zh/androidjava/modern-api/)。

WMF 和 EMF 需要特别考虑。当这些格式通过 [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/) 传递时，[ImageCollection.addImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imagecollection/) 会在插入前将该元文件转换为光栅 PNG 表示。如果需要保留元文件数据，请改用基于流的 [ImageCollection.addImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imagecollection/) 重载。将 EMF 内容从电子表格或其他产品生成属于单独的集成工作流，不在本文范围内。

## **常见问题**

**图像集合和图片框之间有什么区别？**

图像集合用于存储可复用的图像资源。图片框是一种幻灯片形状，用于显示这些资源之一，并提供裁剪、特效等特定于图片的格式设置。

**在所有位置替换同一徽标的最佳方式是什么？**

如果徽标已经作为单个图像资源共享，请使用 [IPPImage.replaceImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/) 替换该资源。对于全演示文稿的品牌标识，也可以将徽标放在母版或布局上，以减少重复的幻灯片内容。

**为什么链接的图像在另一台电脑上消失？**

链接图片依赖其外部文件或 URL。如果在另一台电脑上无法访问该资源，链接图像就可能不可用。演示文稿必须自包含时，请嵌入图像。

**插入的 SVG 能否编辑为 PowerPoint 形状？**

可以。使用 [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/) 转换 SVG；生成的组包含可编辑的幻灯片形状，而不是单个 SVG 图片。

**如何保持包含大量图像的演示文稿体积更小？**

复用共享图像资源，避免使用不必要的大尺寸光栅源，适时压缩合适的光栅图片，将重复的品牌元素放在母版或布局上，并仅在外部依赖可接受时使用链接图像。