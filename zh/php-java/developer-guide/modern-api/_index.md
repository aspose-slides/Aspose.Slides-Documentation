---
title: 使用现代 API 增强图像处理
linktitle: 现代 API
type: docs
weight: 237
url: /zh/php-java/modern-api/
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
- PHP
- Aspose.Slides
description: "通过使用 PHP 现代 API 替换已弃用的成像 API，实现幻灯片图像处理的现代化，以实现无缝的 PowerPoint 和 OpenDocument 自动化。"
---

## **介绍**

在历史上，Aspose Slides 依赖于 `java.awt`，并在公共 API 中包含了以下类：
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

从 24.4 版本开始，此公共 API 已声明为已过时。

为了去除对这些类的依赖，我们添加了所谓的 “现代 API” —— 即应该替代已过时 API 使用的 API，其签名不再依赖 `BufferedImage`。`Graphics2D` 已声明为已过时，并且其支持已从公共 Slides API 中移除。

对依赖 `System.Drawing` 的已过时公共 API 的移除将在 24.8 版本发布。

## **现代 API**

向公共 API 添加了以下类和枚举：

- IImage – 表示栅格或矢量图像。
- ImageFormat – 表示图像的文件格式。
- Images – 用于实例化和使用 IImage 接口的方法。

请注意，IImage 是可释放的（实现了 `IDisposable` 接口，使用时应放在 `using` 中或以其他合适方式释放）。

使用新 API 的典型场景如下所示：
``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# 从磁盘上的文件实例化可释放的 IImage 实例。
$image = Images::fromFile("image.png");

# 通过将 IImage 实例添加到演示文稿的图像集合中来创建 PowerPoint 图像。
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# 在第 1 张幻灯片上添加图片形状
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# 获取表示第 1 张幻灯片的 IImage 实例。
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# 将图像保存到磁盘。
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```


## **使用现代 API 替换旧代码**

一般来说，您需要将使用 `ImageIO` 的旧方法调用替换为新的调用。

旧：
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```

新：
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```


### **获取幻灯片缩略图**

使用已过时 API 的代码：
``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```


现代 API：
``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```


### **获取形状缩略图**

使用已过时 API 的代码：
``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```


现代 API：
``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```


### **获取演示文稿缩略图**

使用已过时 API 的代码：
``` php
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$bitmaps = $pres->getThumbnails($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($bitmaps)); $i++)
{
    $thumbnail = $bitmaps[$i];
    $imageio = new Java("javax.imageio.ImageIO");
    $javafile = new Java("java.io.File", "slide" . $i . ".png");
    $imageio->write($thumbnail, "PNG", $javafile);
}

$pres->dispose();
```


现代 API：
``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;
use aspose\slides\RenderingOptions;


$pres = new Presentation("pres.pptx");

$renderingOptions = new RenderingOptions();
$dimension = new Java("java.awt.Dimension", 1920, 1080);

$images = $pres->getImages($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($images)); $i++)
{
    $thumbnail = $images[$i];
    $thumbnail->save("slide" . $i . ".png", ImageFormat::Png);
}

$pres->dispose();
```


### **向演示文稿中添加图片**

使用已过时 API 的代码：
``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;


$pres = new Presentation();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");

$bufferedImages = $imageio->read($javafile);
$ppImage = $pres->getImages()->addImage($bufferedImages);

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```


现代 API：
``` php
use aspose\slides\Presentation;
use aspose\slides\Images;
use aspose\slides\ShapeType;


$pres = new Presentation();

$image = Images::fromFile("image.png");
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$pres->dispose();
```


## **将被删除的方法及其在现代 API 中的替代方案**

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
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Will be deleted completely |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Will be deleted completely |

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

## **Graphics2D 支持将被终止**

带有 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的方法已声明为已过时，其支持将从公共 API 中移除。

使用该类的 API 部分将被删除：

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**为什么放弃 java.awt.Graphics2D？**

`Graphics2D` 的支持被从公共 API 中移除，以统一渲染和图像的工作方式，消除对平台特定依赖的联系，并转向使用跨平台的 [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) 的方法。所有针对 `Graphics2D` 的渲染方法都将被删除。

**相较于 BufferedImage，IImage 的实际好处是什么？**

[IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) 统一了栅格图像和矢量图像的处理，并通过 [ImageFormat](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/) 简化了保存为各种格式的操作。

**现代 API 会影响生成缩略图的性能吗？**

从 `getThumbnail` 切换到 `getImage` 不会导致性能恶化：新方法在生成带有选项和尺寸的图像方面提供了相同的能力，同时保留对渲染选项的支持。具体的提升或下降取决于使用场景，但功能上替代是等价的。