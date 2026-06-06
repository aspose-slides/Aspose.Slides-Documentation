---
title: تحسين معالجة الصور باستخدام واجهة برمجة التطبيقات الحديثة
linktitle: واجهة برمجة التطبيقات الحديثة
type: docs
weight: 237
url: /ar/php-java/modern-api/
keywords:
- واجهة برمجة تطبيقات حديثة
- الرسم
- صورة مصغرة للشريحة
- تحويل الشريحة إلى صورة
- صورة مصغرة للشكل
- تحويل الشكل إلى صورة
- صورة مصغرة للعرض التقديمي
- تحويل العرض التقديمي إلى صور
- إضافة صورة
- إضافة صورة
- PHP
- Aspose.Slides
description: "قم بتحديث معالجة صور الشرائح باستبدال واجهات برمجة التطبيقات القديمة للصور بـواجهة برمجة التطبيقات الحديثة لـ PHP لتحقيق أتمتة سلسة لملفات PowerPoint وOpenDocument."
---
## **المقدمة**

تاريخيًا، تعتمد Aspose Slides على java.awt وتحتوي الواجهة البرمجية العامة على الفئات التالية منها:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

اعتبارًا من الإصدار 24.4، تم إعلان أن هذه الواجهة البرمجية العامة مهجورة.

من أجل التخلص من الاعتماد على هذه الفئات، أضفنا ما يُسمى "الواجهة البرمجية الحديثة" – أي الواجهة التي يجب استخدامها بدلاً من القديمة، التي لا تحتوي توقيعاتها على اعتماد على [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). تم إعلان [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) مهجور وتم إزالة دعمه من الواجهة العامة لـ Slides.

في الإصدارات الحالية، عُد الواجهة العامة التي تعتمد على أنواع java.awt إلى الوضع legacy/مهجور. استخدم الواجهة الحديثة للشفرة الجديدة وعند ترحيل سير عمل معالجة الصور الحالي.

## **الواجهة البرمجية الحديثة**

تم إضافة الفئات والعدادات التالية إلى الواجهة العامة:

- [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) - تمثّل الصورة النقطية أو المتجهة.
- [ImageFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imageformat/) - تمثّل تنسيق ملف الصورة.
- [Images](https://reference.aspose.com/slides/ar/php-java/aspose.slides/images/) - طرق لإنشاء واستخدام الفئة [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/).

لاحظ أن [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) قابلة للتخلص منها (يجب استدعاء Dispose بعد الاستخدام).

استخدم `getImage` لتصوير شريحة واحدة أو شكل واحد. استخدم `getImages` لتصوير عدة شرائح من العرض التقديمي. استخدم طرق [Images](https://reference.aspose.com/slides/ar/php-java/aspose.slides/images/) لتحميل الصور، `addImage` مع [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) لإضافتها إلى عرض تقديمي، و `replaceImage` مع [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) لتحديث صورة موجودة في العرض التقديمي.

سيناريو نموذجي لاستخدام الواجهة الحديثة قد يبدو كالتالي:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# إنشاء نسخة قابلة للتخلص منها من IImage من الملف على القرص.
$image = Images::fromFile("image.png");

# إنشاء صورة PowerPoint بإضافة نسخة من IImage إلى صور العرض التقديمي.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# إضافة شكل صورة إلى الشريحة رقم 1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# الحصول على نسخة من IImage تمثل الشريحة رقم 1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# حفظ الصورة على القرص.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **استبدال الكود القديم بالواجهة الحديثة**

بشكل عام، سيتوجب عليك استبدال الاستدعاءات التي تستخدم [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) و [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) بالطرق الجديدة التي تستخدم [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/).

الواجهة القديمة/المهجرة:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail($dimension);
$imageio = new Java("javax.imageio.ImageIO");
$javafile = new Java("java.io.File", "image.png");
$imageio->write($slideImage, "PNG", $javafile);
```
الواجهة الحديثة:
``` php
$dimension = new Java("java.awt.Dimension", 1920, 1080);
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);
$slideImage->save("image.png", ImageFormat::Png);
$slideImage->dispose();
```

### **الحصول على صورة مصغرة للشريحة**

الواجهة القديمة/المهجرة:

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

الواجهة القديمة/المهجرة:

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

الواجهة القديمة/المهجرة:

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

الواجهة القديمة/المهجرة:

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

## **الطرق المهجورة واستبدالاتها في الواجهة الحديثة**

### **Presentation**
| توقيع الدالة | توقيع الدالة البديلة |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| توقيع الدالة | توقيع الدالة البديلة |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| توقيع الدالة | توقيع الدالة البديلة |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | لا يوجد استبدال في الواجهة الحديثة |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | لا يوجد استبدال في الواجهة الحديثة |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | لا يوجد استبدال في الواجهة الحديثة |

### **Output**
| توقيع الدالة | توقيع الدالة البديلة |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| توقيع الدالة | توقيع الدالة البديلة |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| توقيع الدالة | توقيع الدالة البديلة |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| توقيع الدالة | توقيع الدالة البديلة |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| توقيع الدالة | توقيع الدالة البديلة |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **دعم الواجهة البرمجية لـ Graphics2D**

الطرق التي تحتوي على [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) مُعلنة كمهجورة ولا يوجد لها استبدال مباشر في الواجهة الحديثة.

استخدم طرق تصوير الصور في الواجهة الحديثة بدلاً من الواجهة التي تُصوّر إلى [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **الأسئلة المتكررة**

**لماذا تم حذف [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)؟**

تم إهمال دعم [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) في الواجهة العامة لتوحيد العمل مع التصيير والصور، وإزالة الارتباطات بالاعتماديات الخاصة بالمنصة، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/). استخدم `getImage` أو `getImages` بدلاً من التصيير إلى [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**ما الفائدة العملية من [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) مقارنةً بـ [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)؟**

توحد [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/) التعامل مع الصور النقطية والمتجهة وتبسط حفظها بتنسيقات مختلفة عبر [ImageFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/imageformat/).

**هل ستؤثر الواجهة الحديثة على أداء إنشاء الصور المصغرة؟**

التحول من `getThumbnail` إلى `getImage` لا يُقلل من الأداء في السيناريوهات العامة: الطُرق الجديدة توفر نفس القدرات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات التصيير. الفائدة أو الفقدان يعتمد على السيناريو المحدد، لكن من الناحية الوظيفية فإن الاستبدالات متساوية.