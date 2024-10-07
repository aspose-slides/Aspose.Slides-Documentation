---
title: واجهة برمجة التطبيقات الحديثة
type: docs
weight: 237
url: /php-java/modern-api/
keywords: "واجهة برمجة التطبيقات الحديثة عبر الأنظمة"
description: "واجهة برمجة التطبيقات الحديثة"
---

## المقدمة

تاريخيًا، كان Aspose Slides يعتمد على java.awt ويحتوي في واجهته العامة على الفئات التالية من هناك:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

اعتبارًا من الإصدار 24.4، تم إعلان هذه الواجهة العامة كواجهة م deprecated.

للتخلص من الاعتماد على هذه الفئات، قمنا بإضافة ما يسمى بـ "واجهة برمجة التطبيقات الحديثة" - أي الواجهة التي يجب استخدامها بدلاً من تلك الم deprecated، والتي تحتوي تعريفاتها على اعتمادات على BufferedImage. تم إعلان Graphics2D كم deprecated وتمت إزالة دعمه من واجهة Slides العامة.

سيكون إزالة الواجهة العامة الم deprecated مع الاعتمادات على System.Drawing في الإصدار 24.8.

## واجهة برمجة التطبيقات الحديثة

تمت إضافة الفئات والتعدادات التالية إلى الواجهة العامة:

- IImage - يمثل الصورة النقطية أو المتجهة.
- ImageFormat - يمثل تنسيق الملف للصورة.
- Images - طرق لإنشاء وعمل مع واجهة IImage.

يرجى ملاحظة أن IImage قابلة للتخلي (تنفذ واجهة IDisposable ويجب لف استخدامها في using أو التخلص منها بطريقة ملائمة أخرى).

قد يبدو سيناريو الاستخدام المعتاد للواجهة الجديدة كما يلي:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# إنشاء مثيل قابل للتخلي من IImage من الملف الموجود على القرص.
$image = Images::fromFile("image.png");

# إنشاء صورة PowerPoint عن طريق إضافة مثيل من IImage إلى صور العرض.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# إضافة شكل صورة على الشريحة #1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# الحصول على مثيل من IImage يمثل الشريحة #1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# حفظ الصورة على القرص.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## استبدال الكود القديم بواجهة برمجة التطبيقات الحديثة

بشكل عام، ستحتاج إلى استبدال استدعاء الطريقة القديمة باستخدام ImageIO بالطريقة الجديدة.

قديمة:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
جديدة:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### الحصول على مصغرة الشريحة

كود باستخدام واجهة برمجة التطبيقات الم deprecated:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```

واجهة برمجة التطبيقات الحديثة:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```

### الحصول على مصغرة شكل

كود باستخدام واجهة برمجة التطبيقات الم deprecated:

``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```

واجهة برمجة التطبيقات الحديثة:

``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```

### الحصول على مصغرة عرض تقديمي

كود باستخدام واجهة برمجة التطبيقات الم deprecated:

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

واجهة برمجة التطبيقات الحديثة:

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

### إضافة صورة إلى عرض تقديمي

كود باستخدام واجهة برمجة التطبيقات الم deprecated:

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

واجهة برمجة التطبيقات الحديثة:

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

## طرق سيتم إزالتها واستبدالها في واجهة برمجة التطبيقات الحديثة

### عرض تقديمي
| توقيع الطريقة                             | توقيع طريقة الاستبدال                             |
|-------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### شكل
| توقيع الطريقة                                                      | توقيع طريقة الاستبدال                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                                        | public final IImage getImage()                                                           |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### شريحة
| توقيع الطريقة                                                      | توقيع طريقة الاستبدال                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | سيتم حذفه بالكامل  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | سيتم حذفه بالكامل  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | سيتم حذفه بالكامل  |

### الناتج
| توقيع الطريقة                                                | توقيع طريقة الاستبدال                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### مجموعة الصور
| توقيع الطريقة                          | توقيع طريقة الاستبدال               |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### صورة العرض
| توقيع الطريقة                     | توقيع طريقة الاستبدال   |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### تنسيق النمط
| توقيع الطريقة                                          | توقيع طريقة الاستبدال                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor)   | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) |public final IImage getTile(Color background, Color foreground) |

### البيانات الفعالة لتنسيق النمط
| توقيع الطريقة                                          | توقيع طريقة الاستبدال                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |


## دعم واجهة برمجة التطبيقات لـ Graphics2D سيتوقف

هُناك طرق مع [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) تم إعلانها كم deprecated وسيدعم هذه الطرق سيتم إزالته من الواجهة العامة.

ستتم إزالة جزء من الواجهة الذي يستخدمها:

[شريحة](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)