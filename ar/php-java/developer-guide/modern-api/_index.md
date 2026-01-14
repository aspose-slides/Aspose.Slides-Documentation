---
title: تحسين معالجة الصور باستخدام الواجهة الحديثة
linktitle: الواجهة الحديثة
type: docs
weight: 237
url: /ar/php-java/modern-api/
keywords:
- واجهة برمجة التطبيقات الحديثة
- الرسم
- صورة مصغرة للشرائح
- تحويل الشريحة إلى صورة
- صورة مصغرة للشكل
- تحويل الشكل إلى صورة
- صورة مصغرة للعرض التقديمي
- تحويل العرض التقديمي إلى صور
- إضافة صورة
- إضافة صورة
- PHP
- Aspose.Slides
description: "تحديث معالجة صور الشرائح عبر استبدال واجهات برمجة التطبيقات القديمة للصور بواجهة برمجة التطبيقات الحديثة لـ PHP لتحقيق أتمتة سلسة لعروض PowerPoint ومستندات OpenDocument."
---

## **المقدمة**

تاريخيًا، يحتوي Aspose Slides على تبعية إلى java.awt ويوجد في واجهة برمجة التطبيقات العامة (API) الفئات التالية منها:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

اعتبارًا من الإصدار 24.4، تم إعلان هذه الواجهة العامة (API) غير مفضلة (Deprecated).

من أجل التخلص من التبعيات على هذه الفئات، أضفنا ما يُسمى بـ "Modern API" - أي الواجهة التي يجب استخدامها بدلاً من الواجهة غير المفضلة، والتي لا تحتوي توقيعاتها على تبعيات إلى BufferedImage. تم إعلان Graphics2D غير مفضلة وتم حذف دعمها من واجهة Slides العامة.

ستتم إزالة الواجهة العامة غير المفضلة التي تعتمد على System.Drawing في الإصدار 24.8.

## **Modern API**

تم إضافة الفئات والعدادات (enums) التالية إلى الواجهة العامة:

- IImage - تمثّل الصورة النقطية أو المتجهية.
- ImageFormat - تمثّل تنسيق ملف الصورة.
- Images - طرق لإنشاء والعمل مع فئة IImage.

لاحظ أن `IImage` قابلة للتصرف (Disposable) (يجب تحريرها بعد الاستخدام).

سيناريو نموذجي لاستخدام الواجهة الجديدة قد يبدو كما يلي:
``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# إنشاء كائن IImage يمكن التخلص منه من الملف على القرص.
$image = Images::fromFile("image.png");

# إنشاء صورة PowerPoint بإضافة كائن IImage إلى صور العرض التقديمي.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# إضافة شكل صورة إلى الشريحة رقم 1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# الحصول على كائن IImage الذي يمثل الشريحة رقم 1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# حفظ الصورة على القرص.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```


## **استبدال الكود القديم بالواجهة الحديثة**

بشكل عام، سيتعين عليك استبدال استدعاء الطريقة القديمة باستخدام ImageIO بالطريقة الجديدة.

القديم:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```

الجديد:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```


### **الحصول على صورة مصغرة للشرائح**

الكود باستخدام واجهة غير مفضلة:
``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "slide1.png");
$imageio->write($slideImage, "PNG", $javafile);

$pres->dispose();
```


الواجهة الحديثة:
``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getImage();
$slideImage->save("slide1.png", ImageFormat::Png);
$slideImage->dispose();

$pres->dispose();
```


### **الحصول على صورة مصغرة للشكل**

الكود باستخدام واجهة غير مفضلة:
``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail();

$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "shape.png");
$imageio->write($shapeImage, "PNG", $javafile);

$pres->dispose();
```


الواجهة الحديثة:
``` php
use aspose\slides\Presentation;
use aspose\slides\ImageFormat;


$pres = new Presentation("pres.pptx");

$shapeImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
$shapeImage->save("shape.png");
$shapeImage->dispose();

$pres->dispose();
```


### **الحصول على صورة مصغرة للعرض التقديمي**

الكود باستخدام واجهة غير مفضلة:
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


الواجهة الحديثة:
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


### **إضافة صورة إلى عرض تقديمي**

الكود باستخدام واجهة غير مفضلة:
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


الواجهة الحديثة:
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


## **الطرق التي ستُحذف واستبدالها في الواجهة الحديثة**

### **Presentation**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| توقيع الطريقة | توقيع الطريقة البديلة |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| توقيع الطريقة | توقيع الطريقة البديلة |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | سيتم حذفها بالكامل |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | سيتم حذفها بالكامل |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | سيتم حذفها بالكامل |

### **Output**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| توقيع الطريقة | توقيع الطريقة البديلة |
|--------------------------------------|-------------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------|----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------|----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **سيتم إيقاف دعم API الخاص بـ Graphics2D**

الطرق التي تستخدم [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) تم إعلانها غير مفضلة وسيتم حذف دعمها من الواجهة العامة.

الجزء من الواجهة الذي يستخدمها سيتم إزالته:

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **الأسئلة المتكررة**

**لماذا تم حذف java.awt.Graphics2D؟**

يتم إزالة دعم `Graphics2D` من الواجهة العامة لتوحيد العمل مع التصيير (rendering) والصور، وإلغاء الربط بالاعتماديات الخاصة بالنظام الأساسي، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/). جميع طرق التصيير إلى `Graphics2D` ستُحذف.

**ما الفائدة العملية من IImage مقارنةً بـ BufferedImage؟**

[IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) يوحّد التعامل مع كل من الصور النقطية والمتجهية ويبسّط الحفظ إلى صيغ متعددة عبر [ImageFormat](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/).

**هل ستؤثر الواجهة الحديثة على أداء إنشاء الصور المصغرة؟**

التحول من `getThumbnail` إلى `getImage` لا يضعف السيناريوهات: الطرق الجديدة توفر نفس الإمكانيات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات التصيير. الاعتماد الفعلي على الأداء يعتمد على السيناريو، لكن من الناحية الوظيفية التعويضات متكافئة.