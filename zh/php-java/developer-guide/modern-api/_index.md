---
title: 提升图像处理，使用现代 API
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
description: "通过使用 PHP 现代 API 替代已废弃的图像 API，实现幻灯片图像处理的现代化，以便顺畅地自动化 PowerPoint 和 OpenDocument。"
---
## **简介**

在历史上，Aspose Slides 依赖于 java.awt，并且在公共 API 中包含以下来自该库的类：
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

自 24.4 版本起，此公共 API 已声明为已废弃。

为了消除对这些类的依赖，我们添加了所谓的“现代 API”——即应当取代已废弃 API 使用的 API，其签名不再依赖于 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)。[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 已声明为已废弃，并且其支持已从公共 Slides API 中移除。

在当前版本中，请将依赖于 java.awt 类型的公共 API 视为遗留/已废弃。对新代码以及迁移现有图像处理工作流时，请使用现代 API。

## **现代 API**

向公共 API 添加了以下类和枚举：

- [IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) - 表示光栅或矢量图像。
- [ImageFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imageformat/) - 表示图像的文件格式。
- [Images](https://reference.aspose.com/slides/zh/php-java/aspose.slides/images/) - 用于实例化和操作 [IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 类的方法。

请注意，[IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 是可释放的（使用后应进行释放）。

使用 `getImage` 渲染单个幻灯片或形状。使用 `getImages` 渲染多个幻灯片。使用 [Images](https://reference.aspose.com/slides/zh/php-java/aspose.slides/images/) 方法加载图像，使用 `addImage` 与 [IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 将图像添加到演示文稿，使用 `replaceImage` 与 [IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 更新已有的演示文稿图像。

使用新 API 的典型场景如下所示：

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# 实例化一个可释放的 IImage 对象，来自磁盘上的文件。
$image = Images::fromFile("image.png");

# 通过将 IImage 实例添加到演示文稿的图像集合中，创建 PowerPoint 图像。
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# 在第 1 张幻灯片上添加图片形状
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# 获取表示第 1 张幻灯片的 IImage 实例。
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# 将图像保存到磁盘上。
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **使用现代 API 替换旧代码**

通常，您需要将使用 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 和 [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) 的调用替换为使用 [IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 的新方法。

Legacy/deprecated API:

``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
Modern API:

``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **获取幻灯片缩略图**

Legacy/deprecated API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

Modern API:

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

Legacy/deprecated API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

Modern API:

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

Legacy/deprecated API:

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

Modern API:

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

### **向演示文稿添加图片**

Legacy/deprecated API:

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

Modern API:

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

## **已废弃方法及其在现代 API 中的替代方案**

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

带有 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的方法已声明为已废弃，且没有直接的现代 API 替代。

请使用现代 API 的图像渲染方法，而不是渲染到 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的 API：

[Slide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **常见问题**

**为什么废弃了 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)？**

对 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的支持已在公共 API 中废弃，以统一渲染和图像的工作方式，消除对平台特定依赖的关联，并转向使用跨平台的 [IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 的方法。请使用 `getImage` 或 `getImages` 代替渲染到 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)。

**[IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 相比 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 的实际好处是什么？**

[IImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/iimage/) 统一了对光栅图像和矢量图像的处理，并通过 [ImageFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imageformat/) 简化了保存为各种格式的过程。

**使用现代 API 会影响生成缩略图的性能吗？**

将 `getThumbnail` 切换为 `getImage` 并不会导致性能下降：新方法在提供相同的选项和尺寸生成图像能力的同时，仍然保留对渲染选项的支持。具体的性能提升或下降取决于使用场景，但功能上两者是等价的。