---
title: 使用现代 API 增强图像处理
linktitle: 现代 API
type: docs
weight: 237
url: /zh/nodejs-java/modern-api/
keywords:
- 现代 API
- 绘图
- 幻灯片缩略图
- 幻灯片转图像
- 形状缩略图
- 形状转图像
- 演示文稿缩略图
- 演示文稿转图像
- 添加图像
- 添加图片
- Node.js
- JavaScript
- Aspose.Slides
description: "通过使用 JavaScript 现代 API 替代已弃用的图像 API，实现幻灯片图像处理的现代化，以实现无缝的 PowerPoint 和 OpenDocument 自动化。"
---
## **介绍**

在历史上，Aspose Slides 依赖于 `java.awt`，并在公共 API 中包含以下来自该库的类：
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

从 24.4 版开始，此公共 API 已被标记为已弃用。

为了摆脱对这些类的依赖，我们添加了所谓的“现代 API”——即应替代已弃用 API 使用的 API，其签名不再依赖于 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)。[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 已被标记为已弃用，并且其支持已从公共 Slides API 中移除。

在当前版本中，请将依赖于 `java.awt` 类型的公共 API 视为遗留/已弃用。对于新代码以及迁移现有图像处理工作流时，请使用现代 API。

## **现代 API**

向公共 API 添加了以下类和枚举：

- [IImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/) - 表示光栅或矢量图像。
- [ImageFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/imageformat/) - 表示图像的文件格式。
- [Images](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/images/) - 提供实例化和使用 [IImage] 类的方法。

请注意，[IImage] 是可释放的，使用后应调用 `dispose()` 或采用其他便捷的释放模式。

使用 `getImage` 渲染单个幻灯片或形状。使用 `getImages` 渲染多个演示文稿幻灯片。使用 [Images] 方法加载图像，使用 `addImage` 搭配 [IImage] 将图像添加到演示文稿，使用 `replaceImage` 搭配 [IImage] 更新现有演示文稿中的图像。

使用新 API 的典型场景如下所示：

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // 从磁盘上的文件实例化一个可释放的 IImage 实例。
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // 通过将 IImage 实例添加到演示文稿的图像集合中来创建 PowerPoint 图像。
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 在第 1 张幻灯片上添加图片形状
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // 获取表示第 1 张幻灯片的 IImage 实例。
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // 将图像保存到磁盘。
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **使用现代 API 替换旧代码**

一般情况下，您需要将使用 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 和 [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) 的调用替换为使用 [IImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/) 的新方法。

### **Legacy/deprecated API:**
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
### **Modern API:**
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **获取幻灯片缩略图**

Legacy/deprecated API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "slide1.png");
    imageio.write(slideImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getImage();
    slideImage.save("slide1.png", aspose.slides.ImageFormat.Png);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **获取形状缩略图**

Legacy/deprecated API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "shape.png");
    imageio.write(shapeImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    shapeImage.save("shape.png");
    shapeImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **获取演示文稿缩略图**

Legacy/deprecated API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var bitmaps = pres.getThumbnails(new aspose.slides.RenderingOptions(), size);
    for (var index = 0; index < bitmaps.length; index++)
    {
        var thumbnail = bitmaps[index];
        var imageio = java.import("javax.imageio.ImageIO");
        var file = java.newInstanceSync("java.io.File", "slide" + index + ".png");
        imageio.write(thumbnail, "PNG", file);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var images = pres.getImages(new aspose.slides.RenderingOptions(), size);
    try
    {
        for (var index = 0; index < images.length; index++)
        {
            var thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", aspose.slides.ImageFormat.Png);
        }
    }
    finally
    {
        images.forEach(item => {item.dispose();});
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **向演示文稿添加图片**

Legacy/deprecated API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "image.png");
    var bufferedImages = imageio.read(file);
    var ppImage = pres.getImages().addImage(bufferedImages);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

Modern API:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var image = aspose.slides.Images.fromFile("image.png");
    var ppImage = pres.getImages().addImage(image);
    image.dispose();

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **已弃用方法及其在现代 API 中的替代方案**

### **Presentation**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| 方法签名 | 替代方法签名 |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| 方法签名 | 替代方法签名 |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | 无现代 API 替代 |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | 无现代 API 替代 |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | 无现代 API 替代 |

### **Output**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| 方法签名 | 替代方法签名 |
|-------------------------------------------|--------------------------------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| 方法签名 | 替代方法签名 |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Graphics2D 的 API 支持**

带有 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的方法已声明为已弃用，且没有直接的现代 API 替代。

请使用现代 API 的图像渲染方法，而不是渲染到 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的 API：

[Slide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **常见问题**

**使用 [IImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/) 相比于 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 的实际好处是什么？**

[IImage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/iimage/) 统一了对光栅图像和矢量图像的操作，并通过 [ImageFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/imageformat/) 简化了保存为多种格式的过程。

**现代 API 会影响生成缩略图的性能吗？**

从 `getThumbnail` 切换到 `getImage` 不会导致性能下降：新方法在提供相同选项和尺寸生成图像的能力的同时，仍然保留对渲染选项的支持。具体的提升或下降取决于实际场景，但功能上两者是等价的。