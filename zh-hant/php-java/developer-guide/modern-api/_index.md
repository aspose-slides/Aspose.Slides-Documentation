---
title: 使用現代 API 加強影像處理
linktitle: 現代 API
type: docs
weight: 237
url: /zh-hant/php-java/modern-api/
keywords:
- 現代 API
- 繪圖
- 投影片縮圖
- 投影片轉圖像
- 圖形縮圖
- 圖形轉圖像
- 簡報縮圖
- 簡報轉圖像
- 新增影像
- 新增圖片
- PHP
- Aspose.Slides
description: "透過使用 PHP 現代 API 取代已棄用的影像 API，讓投影片影像處理現代化，以實現無縫的 PowerPoint 與 OpenDocument 自動化。"
---
## **簡介**

從歷史上看，Aspose Slides 依賴於 `java.awt`，且在公開 API 中包含以下來自該套件的類別：
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

自 24.4 版起，這些公開 API 已被宣告為已棄用。

為了擺脫對這些類別的相依，我們加入了所謂的「現代 API」——即應取代已棄用 API 使用的 API，其簽章不再依賴 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)。[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 已宣告為已棄用，且其支援已從公開 Slides API 中移除。

在目前的版本中，請將依賴 `java.awt` 類型的公開 API 視為傳統/已棄用。於新程式碼或遷移既有影像處理工作流程時，請使用現代 API。

## **現代 API**

已在公開 API 中加入以下類別與列舉：

- [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) - 代表點陣圖或向量圖像。
- [ImageFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imageformat/) - 代表圖像的檔案格式。
- [Images](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/images/) - 用於實例化與操作 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 類別的方法。

請注意 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 為可釋放的（使用後應釋放）。

使用 `getImage` 來渲染單一投影片或圖形。使用 `getImages` 來渲染多張投影片。使用 [Images](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/images/) 方法載入圖像，使用 `addImage` 搭配 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 將圖像加入投影片，並使用 `replaceImage` 搭配 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 取代現有投影片圖像。

使用新 API 的典型情境如下：

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# 從磁碟上的檔案建立可釋放的 IImage 實例。
$image = Images::fromFile("image.png");

# 透過將 IImage 實例加入簡報的 Images，建立 PowerPoint 圖像。
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# 在第 1 張投影片上加入圖片圖形
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# 取得代表第 1 張投影片的 IImage 實例。
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# 將圖像儲存至磁碟。
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **以現代 API 取代舊程式碼**

一般而言，您需要將使用 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) 與 [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) 的呼叫，改為使用以 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 為參數的新方法。

舊版/已棄用的 API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
現代 API:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **取得投影片縮圖**

舊版/已棄用的 API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

現代 API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### **取得圖形縮圖**

舊版/已棄用的 API:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

現代 API:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### **取得簡報縮圖**

舊版/已棄用的 API:

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

現代 API:

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

### **將圖片加入簡報**

舊版/已棄用的 API:

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

現代 API:

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

## **已棄用的方法及其在現代 API 中的取代方案**

### **Presentation**
| 方法簽章 | 取代方法簽章 |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| 方法簽章 | 取代方法簽章 |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| 方法簽章 | 取代方法簽章 |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | 無現代 API 替代方案 |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | 無現代 API 替代方案 |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | 無現代 API 替代方案 |

### **Output**
| 方法簽章 | 取代方法簽章 |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| 方法簽章 | 取代方法簽章 |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| 方法簽章 | 取代方法簽章 |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| 方法簽章 | 取代方法簽章 |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| 方法簽章 | 取代方法簽章 |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |


## **Graphics2D 的 API 支援**

使用 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的方法已宣告為已棄用，且沒有直接的現代 API 替代方案。

請改用現代 API 的影像渲染方法，取代渲染至 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 的 API：

[Slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **常見問題**

**為什麼棄用 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)？**

公開 API 中的 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) 支援已被棄用，目的是統一渲染與圖像的處理方式，消除平台特定的相依，並轉向使用跨平台的 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/)。請改為使用 `getImage` 或 `getImages`，而非渲染至 [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)。

**相較於 [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)，[IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 實際上有什麼好處？**

[IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/) 統一了點陣圖與向量圖的處理，並透過 [ImageFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imageformat/) 簡化了存為各種格式的工作。

**現代 API 會影響產生縮圖的效能嗎？**

從 `getThumbnail` 轉為 `getImage` 不會使效能變差：新方法在提供相同的選項與尺寸產出圖像的功能，同時保留了渲染選項的支援。具體的效能提升或下降取決於使用情境，但功能上兩者是等價的。