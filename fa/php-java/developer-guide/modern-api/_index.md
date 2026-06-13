---
title: "بهبود پردازش تصویر با API مدرن"
linktitle: "API مدرن"
type: docs
weight: 237
url: /fa/php-java/modern-api/
keywords:
- "API مدرن"
- "رسم"
- "تصویر کوچک اسلاید"
- "تبدیل اسلاید به تصویر"
- "تصویر کوچک شکل"
- "تبدیل شکل به تصویر"
- "تصویر کوچک ارائه"
- "تبدیل ارائه به تصاویر"
- "افزودن تصویر"
- "افزودن عکس"
- "PHP"
- "Aspose.Slides"
description: "پردازش تصویر اسلاید را با جایگزینی APIهای منسوخ تصویری با API مدرن PHP، مدرن‌سازی کنید تا خودکارسازی یکپارچه PowerPoint و OpenDocument امکان‌پذیر شود."
---
## **معرفی**

به‌صورت تاریخی، Aspose Slides به java.awt وابسته بوده و در API عمومی کلاس‌های زیر را دارد:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

به‌موجب نسخه 24.4، این API عمومی به‌عنوان منسوخ اعلام شده است.

به‌منظور حذف وابستگی‌ها به این کلاس‌ها، ما به اصطلاح «API مدرن» را افزودیم – یعنی API‌ای که باید به‌جای نسخه منسوخ استفاده شود، که امضاهای آن شامل وابستگی به [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) هستند. [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) به‌عنوان منسوخ اعلام شده و پشتیبانی آن از API عمومی Slides حذف شده است.

در نسخه‌های فعلی، API عمومی که به انواع java.awt وابسته است را به‌عنوان قدیمی/منسوخ درنظر بگیرید. برای کد جدید و هنگام مهاجرت جریان‌های پردازش تصویر موجود از API مدرن استفاده کنید.

## **API مدرن**

کلاس‌ها و enumهای زیر به API عمومی اضافه شدند:

- [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) - تصویر رستر یا وکتور را نشان می‌دهد.
- [ImageFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imageformat/) - فرمت فایل تصویر را نشان می‌دهد.
- [Images](https://reference.aspose.com/slides/fa/php-java/aspose.slides/images/) - متدهایی برای ایجاد نمونه و کار با کلاس [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) .

توجه داشته باشید که [IImage] قابل حذف است (باید پس از استفاده حذف شود).

از `getImage` برای رندر یک اسلاید یا شکل استفاده کنید. از `getImages` برای رندر چندین اسلاید ارائه استفاده کنید. از متدهای [Images](https://reference.aspose.com/slides/fa/php-java/aspose.slides/images/) برای بارگذاری تصاویر، `addImage` با [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) برای افزودن آن‌ها به یک ارائه، و `replaceImage` با [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) برای به‌روزرسانی تصویر موجود در ارائه استفاده کنید.

یک سناریوی معمولی برای استفاده از API جدید می‌تواند به‌صورت زیر باشد:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# یک نمونه‌ی حذف‌پذیر از IImage را از فایل روی دیسک ایجاد کنید.
$image = Images::fromFile("image.png");

# یک تصویر PowerPoint ایجاد کنید با افزودن یک نمونه IImage به تصاویر ارائه.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# افزودن یک شکل تصویر به اسلاید شماره ۱
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# یک نمونه از IImage که اسلاید شماره ۱ را نمایندگی می‌کند، دریافت کنید.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# تصویر را روی دیسک ذخیره کنید.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **جایگزینی کدهای قدیمی با API مدرن**

به‌طور کلی، شما باید فراخوانی‌هایی که از [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) و [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) استفاده می‌کنند را با متدهای جدید که از [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) استفاده می‌کنند، جایگزین کنید.

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

### **دریافت تصویر کوچک اسلاید**

Legacy/deprecated API:
``` php
use aspose\slides\Presentation;


$pres = new Presentation("pres.pptx");

$slideImage = $pres->getSlides()->get_Item(0)->getThumbnail();

imageio = new Java("javax.imageio.ImageIO");
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

### **دریافت تصویر کوچک شکل**

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

### **دریافت تصویر کوچک ارائه**

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

### **افزودن تصویر به یک ارائه**

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

## **متدهای منسوخ و جایگزین آن‌ها در API مدرن**

### **Presentation**
| امضای متد | امضای متد جایگزین |
|-----------|-------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| امضای متد | امضای متد جایگزین |
|-----------|-------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| امضای متد | امضای متد جایگزین |
|-----------|-------------------|
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
| امضای متد | امضای متد جایگزین |
|-----------|-------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| امضای متد | امضای متد جایگزین |
|-----------|-------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| امضای متد | امضای متد جایگزین |
|-----------|-------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| امضای متد | امضای متد جایگزین |
|-----------|-------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| امضای متد | امضای متد جایگزین |
|-----------|-------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **پشتیبانی API برای Graphics2D**

متدهای دارای [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) به‌عنوان منسوخ اعلام شده‌اند و جایگزین مستقیم در API مدرن ندارند.

به‌جای API که به [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) رندر می‌کند، از متدهای رندر تصویر API مدرن استفاده کنید:

[Slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**چرا [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) حذف شد؟**

پشتیبانی از [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) در API عمومی منسوخ شده است تا کار با رندر و تصاویر یکپارچه شود، وابستگی‌های پلتفرم‑خاص حذف شوند و به رویکردی چندپلتفرمی با [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) سوئیچ کنیم. به‌جای رندر به [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) از `getImage` یا `getImages` استفاده کنید.

**مزیت عملی [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) نسبت به [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) چیست؟**

[IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) کار با هر دو تصویر رستر و وکتور را یکپارچه می‌کند و ذخیره به فرمت‌های مختلف را از طریق [ImageFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imageformat/) ساده می‌سازد.

**آیا API مدرن بر عملکرد تولید تصویر کوچک تأثیر خواهد گذاشت؟**

تبدیل از `getThumbnail` به `getImage` باعث کاهش یا افزایش عملکرد نمی‌شود: متدهای جدید همان قابلیت‌ها را برای تولید تصاویر با گزینه‌ها و اندازه‌ها فراهم می‌کنند و پشتیبانی از گزینه‌های رندر را حفظ می‌کنند. سود یا هزینه خاص بسته به سناریو متفاوت است، اما از نظر عملکردی جایگزین‌ها معادل هستند.