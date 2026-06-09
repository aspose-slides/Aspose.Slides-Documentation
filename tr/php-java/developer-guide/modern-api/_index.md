---
title: Modern API ile Görüntü İşlemeyi Geliştirin
linktitle: Modern API
type: docs
weight: 237
url: /tr/php-java/modern-api/
keywords:
- modern API
- çizim
- slayt küçük resmi
- slayttan görüntüye
- şekil küçük resmi
- şekilden görüntüye
- sunum küçük resmi
- sunumu görüntülere
- görsel ekle
- resim ekle
- PHP
- Aspose.Slides
description: "Eski görüntüleme API'lerini PHP Modern API ile değiştirerek slayt görüntü işlemeyi modernleştirin; sorunsuz PowerPoint ve OpenDocument otomasyonu sağlayın."
---
## **Giriş**

Tarihsel olarak, Aspose Slides, java.awt'e bağımlıdır ve genel API'sinde aşağıdaki sınıfları içerir:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

24.4 sürümünden itibaren bu genel API kullanımdan kaldırılmış olarak ilan edilmiştir.

Bu sınıflara olan bağımlılıklardan kurtulmak için sözde "Modern API"yi ekledik – yani, kullanım dışı bırakılanın yerine kullanılacak API, imzalarında [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) bağımlılıkları bulunan. [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) kullanım dışı bırakılmış ve desteği genel Slides API'sinden kaldırılmıştır.

Mevcut sürümlerde, java.awt türlerine bağımlı olan genel API'yi eski/kullanımdan kaldırılmış olarak değerlendirin. Yeni kodlar için ve mevcut görüntü işleme iş akışlarını taşırken Modern API'yi kullanın.

## **Modern API**

Aşağıdaki sınıflar ve enum'lar genel API'ye eklendi:

- [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) - raster veya vektör görüntüyü temsil eder.
- [ImageFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imageformat/) - görüntünün dosya biçimini temsil eder.
- [Images](https://reference.aspose.com/slides/tr/php-java/aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) sınıfını örneklemek ve onunla çalışmak için yöntemler.

Not: [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) atık edilebilir (kullanımdan sonra atılmalıdır).

`getImage` tek bir slayt veya şekil oluşturmak için kullanılır. `getImages` birden fazla sunum slaytını oluşturmak için kullanılır. Görüntüleri yüklemek için [Images](https://reference.aspose.com/slides/tr/php-java/aspose.slides/images/) yöntemlerini, bir sunuma eklemek için `addImage` ile [IImage] ve mevcut bir sunum görüntüsünü güncellemek için `replaceImage` ile [IImage] kullanın.

Yeni API'yi kullanmanın tipik bir senaryosu aşağıdaki gibi görünebilir:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# diskteki dosyadan IImage'in kullanılabilir bir örneğini oluşturur.
$image = Images::fromFile("image.png");

# bir IImage örneğini sunumun resimlerine ekleyerek PowerPoint resmi oluşturur.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# slayt #1 üzerine bir resim şekli ekle
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# slayt #1'i temsil eden IImage örneğini alır.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# resmi diske kaydeder.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Eski Kodu Modern API ile Değiştirme**

Genel olarak, [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) ve [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) kullanan çağrıları, [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) kullanan yeni yöntemlerle değiştirmeniz gerekir.

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

### **Slayt Küçük Resmi Alma**

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

### **Şekil Küçük Resmi Alma**

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

### **Sunum Küçük Resmi Alma**

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

### **Sunuma Resim Ekleme**

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

## **Deprecated Methods and Their Replacement in Modern API**

### **Presentation**
| Metod İmzası | Yerine Koyulan Metod İmzası |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Metod İmzası | Yerine Koyulan Metod İmzası |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Metod İmzası | Yerine Koyulan Metod İmzası |
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
| Metod İmzası | Yerine Koyulan Metod İmzası |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Metod İmzası | Yerine Koyulan Metod İmzası |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Metod İmzası | Yerine Koyulan Metod İmzası |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Metod İmzası | Yerine Koyulan Metod İmzası |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Metod İmzası | Yerine Koyulan Metod İmzası |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **API Support for Graphics2D**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) içeren yöntemler kullanımdan kaldırılmıştır ve doğrudan Modern API karşılığı yoktur.

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)'ye render yapan API yerine Modern API görüntü renderleme yöntemlerini kullanın:

[Slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **SSS**

**Neden [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) kaldırıldı?**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) desteği, render ve görüntülerle çalışmayı birleştirmek, platforma özgü bağımlılıkları ortadan kaldırmak ve [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) ile çapraz platform bir yaklaşım benimsemek için genel API'de kullanımdan kaldırılmıştır. [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)'ye render etmek yerine `getImage` veya `getImages` kullanın.

**Pratik olarak [IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) kullanmanın [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) karşısındaki faydası nedir?**

[IImage](https://reference.aspose.com/slides/tr/php-java/aspose.slides/iimage/) raster ve vektör görüntülerle çalışmayı birleştirir ve [ImageFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/imageformat/) aracılığıyla çeşitli biçimlerde kaydetmeyi basitleştirir.

**Modern API, küçük resim oluşturma performansını etkiler mi?**

`getThumbnail`'dan `getImage`'a geçiş senaryoları kötüleştirmez: yeni yöntemler, seçenekler ve boyutlarla aynı yetenekleri sunar ve render seçeneklerine destek verir. Kazanç veya kayıp senaryoya bağlıdır, ancak fonksiyonel olarak değişimler eşdeğerdir.