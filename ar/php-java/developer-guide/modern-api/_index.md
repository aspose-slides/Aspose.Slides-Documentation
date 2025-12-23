---
title: تحسين معالجة الصور باستخدام واجهة برمجة التطبيقات الحديثة
linktitle: واجهة برمجة التطبيقات الحديثة
type: docs
weight: 237
url: /ar/php-java/modern-api/
keywords:
- واجهة برمجة التطبيقات الحديثة
- رسم
- صورة مصغرة للشرائح
- الشرائح إلى صورة
- صورة مصغرة للشكل
- الشكل إلى صورة
- صورة مصغرة للعرض التقديمي
- العرض التقديمي إلى صور
- إضافة صورة
- إضافة صورة
- PHP
- Aspose.Slides
description: "تحديث معالجة صور الشرائح عن طريق استبدال واجهات برمجة التطبيقات التصويرية القديمة بواجهة برمجة التطبيقات الحديثة للـ PHP لتوفير أتمتة سلسة لملفات PowerPoint وOpenDocument."
---

## **المقدمة**

تقليديًا، Aspose Slides يعتمد على java.awt ويحتوي في واجهة البرمجة العامة على الفئات التالية من هناك:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

بدءًا من الإصدار 24.4، تم إعلان أن هذه الواجهة العامة للبرمجة أصبحت مهملة.

من أجل التخلص من الاعتماد على هذه الفئات، أضفنا ما يسمى بـ “واجهة برمجة التطبيقات الحديثة” — أي الواجهة التي يجب استخدامها بدلاً من الواجهة المهملة، والتي تحتوي توقيعاتها على اعتماد على BufferedImage. تم إعلان Graphics2D مهملة وتم إزالة دعمه من واجهة برمجة تطبيقات Slides العامة.

إزالة الواجهة العامة المهملة التي تعتمد على System.Drawing سيكون في الإصدار 24.8.

## **واجهة برمجة التطبيقات الحديثة**

تم إضافة الفئات والعدادات (enums) التالية إلى الواجهة العامة للبرمجة:

- IImage - يمثل الصورة النقطية أو المتجهة.
- ImageFormat - يمثل تنسيق ملف الصورة.
- Images - طرق لإنشاء والعمل مع واجهة IImage.

يرجى ملاحظة أن IImage قابلة للتصريف (تنفذ واجهة IDisposable ويجب تغليف استخدامها داخل using أو التخلص منها بطريقة مناسبة أخرى).

سيناريو نموذجي لاستخدام الواجهة الحديثة قد يبدو كما يلي:
``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# إنشاء مثال قابل للتصريف من IImage من الملف الموجود على القرص.
$image = Images::fromFile("image.png");

# إنشاء صورة PowerPoint بإضافة مثال IImage إلى صور العرض التقديمي.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# إضافة شكل صورة على الشريحة #1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# الحصول على مثال IImage الذي يمثل الشريحة #1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# حفظ الصورة على القرص.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```


## **استبدال الشيفرة القديمة بواجهة برمجة التطبيقات الحديثة**

بشكل عام، ستحتاج إلى استبدال الاستدعاء إلى الطريقة القديمة التي تستخدم ImageIO بالطريقة الجديدة.

القديمة:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```

الجديدة:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```


### **الحصول على صورة مصغرة للشرائح**

كود يستخدم واجهة برمجة تطبيقات مهملة:
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


### **الحصول على صورة مصغرة للشكل**

كود يستخدم واجهة برمجة تطبيقات مهملة:
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


### **الحصول على صورة مصغرة للعرض التقديمي**

كود يستخدم واجهة برمجة تطبيقات مهملة:
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


### **إضافة صورة إلى عرض تقديمي**

كود يستخدم واجهة برمجة تطبيقات مهملة:
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
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| توقيع الطريقة | توقيع الطريقة البديلة |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| توقيع الطريقة | توقيع الطريقة البديلة |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **ستتوقف دعم واجهة برمجة التطبيقات Graphics2D**

الطرق التي تتضمن [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) تم إعلانها مهملة وسيتزيل دعمها من الواجهة العامة.

الجزء من الواجهة الذي يستخدمها سيتم إزالته:

[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **الأسئلة الشائعة**

**لماذا تم إلغاء java.awt.Graphics2D؟**

يتم إزالة الدعم لـ `Graphics2D` من الواجهة العامة لتوحيد العمل مع العرض والصور، وإزالة الروابط إلى الاعتمادات الخاصة بالمنصات، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/). ستُزال جميع طرق العرض إلى `Graphics2D`.

**ما هي الفائدة العملية من IImage مقارنةً بـ BufferedImage؟**

[IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) يوحّد العمل مع الصور النقطية والمتجهة ويبسّط الحفظ إلى صيغ متعددة عبر [ImageFormat](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/).

**هل ستؤثر الواجهة الحديثة على أداء إنشاء الصور المصغرة؟**

التحول من `getThumbnail` إلى `getImage` لا يفاقم السيناريوهات: توفر الطرق الجديدة نفس القدرات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات العرض. الفائدة أو الفقدان المحدد يعتمد على السيناريو، لكن وظيفيًا تعتبر البدائل معادلة.