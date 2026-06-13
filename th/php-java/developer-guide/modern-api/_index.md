---
title: ปรับปรุงการประมวลผลภาพด้วย API สมัยใหม่
linktitle: API สมัยใหม่
type: docs
weight: 237
url: /th/php-java/modern-api/
keywords:
- API สมัยใหม่
- การวาด
- ภาพตัวอย่างสไลด์
- สไลด์เป็นภาพ
- ภาพตัวอย่างรูปร่าง
- รูปร่างเป็นภาพ
- ภาพตัวอย่างงานนำเสนอ
- งานนำเสนอเป็นภาพ
- เพิ่มภาพ
- เพิ่มรูปภาพ
- PHP
- Aspose.Slides
description: "ปรับสมัยการประมวลผลภาพสไลด์โดยการแทนที่ API การทำภาพที่เลิกใช้งานด้วย PHP Modern API เพื่อการทำงานอัตโนมัติของ PowerPoint และ OpenDocument อย่างราบรื่น."
---
## **บทนำ**

Historically, Aspose Slides มีการพึ่งพา java.awt และใน API สาธารณะมีคลาสต่อไปนี้จากนั้น:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

ตั้งแต่เวอร์ชัน 24.4 API สาธารณะนี้ได้รับการประกาศว่าเลิกใช้งานแล้ว

เพื่อกำจัดการพึ่งพาเหล่านี้ เราได้เพิ่ม “Modern API” – คือ API ที่ควรใช้แทน API ที่เลิกใช้ ซึ่งลายเซ็นของมันไม่อ้างอิงถึง [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) อีกต่อไป ส่วน [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ถูกประกาศว่าเลิกใช้และการสนับสนุนถูกลบออกจาก API สาธารณะของ Slides

ในเวอร์ชันปัจจุบัน ให้ถือว่า API สาธารณะที่พึ่งพา java.awt เป็น Legacy/Deprecated ใช้ Modern API สำหรับโค้ดใหม่และเมื่อย้ายเวิร์กโฟลว์การประมวลผลภาพที่มีอยู่

## **API สมัยใหม่**

เพิ่มคลาสและ enum ต่อไปนี้ลงใน API สาธารณะ:

- [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) – แสดงถึงภาพ raster หรือ vector
- [ImageFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/imageformat/) – แสดงถึงรูปแบบไฟล์ของภาพ
- [Images](https://reference.aspose.com/slides/th/php-java/aspose.slides/images/) – เมธอดสำหรับสร้างและทำงานกับคลาส [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/)

โปรดทราบว่า [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) เป็น disposable (ควรทำการ dispose หลังการใช้งาน)

ใช้ `getImage` เพื่อเรนเดอร์สไลด์หรือรูปแบบเดียว ใช้ `getImages` เพื่อเรนเดอร์สไลด์หลายสไลด์ ใช้เมธอดของ [Images](https://reference.aspose.com/slides/th/php-java/aspose.slides/images/) เพื่อโหลดภาพ, `addImage` พร้อม [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) เพื่อเพิ่มลงในงานนำเสนอ, และ `replaceImage` พร้อม [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) เพื่ออัปเดตภาพในงานนำเสนอที่มีอยู่

สถานการณ์ทั่วไปของการใช้ API ใหม่อาจมีลักษณะดังต่อไปนี้:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# สร้างตัวอย่าง IImage ที่เป็น disposable จากไฟล์บนดิสก์.
$image = Images::fromFile("image.png");

# สร้างภาพ PowerPoint โดยเพิ่มตัวอย่าง IImage ลงใน collection ภาพของงานนำเสนอ.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# เพิ่มรูปร่างรูปภาพบนสไลด์ที่ 1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# รับตัวอย่างของ IImage ที่แสดงสไลด์ที่ 1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# บันทึกภาพลงบนดิสก์.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **การแทนที่โค้ดเก่าด้วย API สมัยใหม่**

โดยทั่วไป คุณจะต้องแทนที่การเรียกที่ใช้ [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) และ [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) ด้วยเมธอดใหม่ที่ใช้ [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/)

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

### **การรับ Thumbnail ของสไลด์**

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

### **การรับ Thumbnail ของรูปร่าง**

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

### **การรับ Thumbnail ของงานนำเสนอ**

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

### **การเพิ่มรูปภาพลงในงานนำเสนอ**

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

## **เมธอดที่เลิกใช้และการแทนที่ใน Modern API**

### **Presentation**
| Signature ของเมธอด | Signature ของเมธอดทดแทน |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Signature ของเมธอด | Signature ของเมธอดทดแทน |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Signature ของเมธอด | Signature ของเมธอดทดแทน |
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
| Signature ของเมธอด | Signature ของเมธอดทดแทน |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Signature ของเมธอด | Signature ของเมธอดทดแทน |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Signature ของเมธอด | Signature ของเมธอดทดแทน |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Signature ของเมธอด | Signature ของเมธอดทดแทน |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Signature ของเมธอด | Signature ของเมธอดทดแทน |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **การสนับสนุน API สำหรับ Graphics2D**

เมธอดที่ใช้ [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ถูกประกาศว่าเลิกใช้และไม่มีการแทนที่โดยตรงใน Modern API

ใช้เมธอดการเรนเดอร์ภาพของ Modern API แทน API ที่เรนเดอร์ไปยัง [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**ทำไมถึงลบ [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ออก?**

การสนับสนุน [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) ถูกเลิกใช้ใน API สาธารณะเพื่อรวมการทำงานกับการเรนเดอร์และภาพ, กำจัดการเชื่อมโยงกับการพึ่งพาแพลตฟอร์มเฉพาะ, และเปลี่ยนไปใช้วิธีการข้ามแพลตฟอร์มกับ [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/). ใช้ `getImage` หรือ `getImages` แทนการเรนเดอร์ไปยัง [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**ประโยชน์เชิงปฏิบัติของ [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) เทียบกับ [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) คืออะไร?**

[IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) รวมการทำงานกับภาพ raster และ vector ไว้ในตัวเดียวและทำให้การบันทึกเป็นรูปแบบต่าง ๆ ง่ายขึ้นผ่าน [ImageFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/imageformat/).

**Modern API จะส่งผลต่อประสิทธิภาพการสร้าง thumbnail หรือไม่?**

การเปลี่ยนจาก `getThumbnail` ไปเป็น `getImage` ไม่ทำให้สถานการณ์แย่ลง: เมธอดใหม่ให้ความสามารถเดียวกันในการผลิตภาพพร้อมตัวเลือกและขนาด, พร้อมยังคงสนับสนุนตัวเลือกการเรนเดอร์. ผลลัพธ์ด้านประสิทธิภาพขึ้นอยู่กับสถานการณ์, แต่ในเชิงฟังก์ชันการแทนที่เทียบเท่ากัน.