---
title: 使用现代 API 强化图像处理
linktitle: 现代 API
type: docs
weight: 237
url: /zh/java/modern-api/
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
- Java
- Aspose.Slides
description: "通过使用 Java 现代 API 替换已弃用的成像 API，实现无缝的 PowerPoint 和 OpenDocument 自动化，现代化幻灯片图像处理。"
---
## **简介**

在历史上，Aspose Slides 依赖于 `java.awt`，并在公共 API 中包含以下来自该包的类：
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

自 24.4 版起，此公共 API 已标记为已弃用。

为了摆脱对这些类的依赖，我们新增了所谓的 **“现代 API”**——即应当取代已弃用 API 使用的 API，其签名中仍可能包含对 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 的依赖。 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 已被标记为已弃用，并且在公共 Slides API 中已移除其支持。

在当前版本中，请将依赖于 `java.awt` 类型的公共 API 视为遗留/已弃用。对新代码以及迁移现有图像处理工作流时，请使用现代 API。

## **现代 API**

向公共 API 添加了以下类和枚举：

- [IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/) - 表示光栅或矢量图像。
- [ImageFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imageformat/) - 表示图像的文件格式。
- [Images](https://reference.aspose.com/slides/zh/java/com.aspose.slides/images/) - 用于实例化和操作 [IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/) 接口的方法。

请注意，[IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/) 是可释放的，其使用后应调用 `dispose()` 或采用其他便利的释放模式。

使用 `getImage` 渲染单个幻灯片或形状。使用 `getImages` 渲染多个演示文稿幻灯片。使用 [Images](https://reference.aspose.com/slides/zh/java/com.aspose.slides/images/) 方法加载图像，使用 `addImage` 搭配 [IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/) 将其添加到演示文稿，使用 `replaceImage` 搭配 [IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/) 更新已有的演示文稿图像。

使用新 API 的典型场景可能如下所示：

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // 实例化一个可释放的 IImage 实例，来源于磁盘上的文件。
    IImage image = Images.fromFile("image.png");
    try {
        // 通过将 IImage 实例添加到演示文稿的图像集合中，创建 PowerPoint 图像。
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 在第 1 张幻灯片上添加图片形状
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // 获取表示第 1 张幻灯片的 IImage 实例。
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // 将图像保存到磁盘上。
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **使用现代 API 替换旧代码**

一般来说，您需要将使用 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 和 ImageIO 的调用替换为使用 [IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/) 的新方法。

### **旧的/已弃用的 API**
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
### **现代 API**
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **获取幻灯片缩略图**

旧的/已弃用的 API：

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail();
    try {
        ImageIO.write(slideImage, "PNG", new File("slide1.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

现代 API：

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage();
    try {
        slideImage.save("slide1.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **获取形状缩略图**

旧的/已弃用的 API：

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    try {
        ImageIO.write(shapeImage, "PNG", new File("shape.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

现代 API：

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    try {
        shapeImage.save("shape.png");
    } finally {
        if (shapeImage != null) shapeImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **获取演示文稿缩略图**

旧的/已弃用的 API：

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Dimension(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        try 
        {
            BufferedImage thumbnail = bitmaps[index];
            ImageIO.write(thumbnail, "PNG", new File("slide" + index + ".png"));
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

现代 API：

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Dimension(1980, 1028));
    try
    {
        for (int index = 0; index < images.length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", ImageFormat.Png);
        }
    }
    finally
    {
        for (IImage image : images)
        {
            image.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **向演示文稿添加图片**

旧的/已弃用的 API：

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    try {
        BufferedImage bufferedImages = ImageIO.read(new File("image.png"));
        ppImage = pres.getImages().addImage(bufferedImages);
    } catch (IOException e) {
        e.printStackTrace();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

现代 API：

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    IImage image = Images.fromFile("image.png");
    try {
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **已弃用的方法及其在现代 API 中的替代方案**

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
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement |

### **Output**
| 方法签名 | 替代方法签名 |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| 方法签名 | 替代方法签名 |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

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

带有 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的方法已标记为已弃用，且没有直接的现代 API 替代。

请改用现代 API 的图像渲染方法，而不是渲染至 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)：

[Slide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/zh/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **常见问题**

**为什么会移除 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)？**

在公共 API 中弃用对 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的支持，以统一渲染和图像的工作方式，消除对平台特定依赖的绑定，并转向使用跨平台的 [IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/) 的方式。请改用 `getImage` 或 `getImages`，而不是渲染至 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)。

**相较于 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)，[IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/) 的实际优势是什么？**

[IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/) 将光栅图像和矢量图像的处理统一起来，并通过 [ImageFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/imageformat/) 简化了保存为多种格式的过程。

**使用现代 API 会影响生成缩略图的性能吗？**

从 `getThumbnail` 切换到 `getImage` 并不会导致性能下降：新方法在提供相同的选项和尺寸生成图像的能力的同时，仍然支持渲染选项。具体的提升或下降取决于使用场景，但功能上两者是等价的。