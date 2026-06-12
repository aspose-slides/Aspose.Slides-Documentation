---
title: Meningkatkan Pemrosesan Gambar dengan API Modern
linktitle: API Modern
type: docs
weight: 237
url: /id/php-java/modern-api/
keywords:
- API modern
- menggambar
- thumbnail slide
- slide ke gambar
- thumbnail bentuk
- bentuk ke gambar
- thumbnail presentasi
- presentasi ke gambar
- menambah gambar
- menambah foto
- PHP
- Aspose.Slides
description: "Modernisasi pemrosesan gambar slide dengan mengganti API pengolahan gambar yang usang menggunakan PHP Modern API untuk otomatisasi PowerPoint dan OpenDocument yang mulus."
---
## **Pendahuluan**

Secara historis, Aspose Slides memiliki ketergantungan pada java.awt dan memiliki dalam API publik kelas-kelas berikut dari sana:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Mulai versi 24.4, API publik ini dinyatakan usang.

Untuk menghilangkan ketergantungan pada kelas-kelas ini, kami menambahkan apa yang disebut "Modern API" – yaitu API yang harus digunakan menggantikan yang usang, yang tanda tangannya mengandung ketergantungan pada [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) dinyatakan usang dan dukungannya dihapus dari API Slides publik.

Pada versi saat ini, anggap API publik yang bergantung pada tipe java.awt sebagai warisan/usang. Gunakan Modern API untuk kode baru dan saat memigrasikan alur kerja pemrosesan gambar yang ada.

## **Modern API**

Menambahkan kelas dan enum berikut ke API publik:

- [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) - mewakili gambar raster atau vektor.
- [ImageFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/imageformat/) - mewakili format berkas gambar.
- [Images](https://reference.aspose.com/slides/id/php-java/aspose.slides/images/) - metode untuk membuat instance dan bekerja dengan kelas [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) .

Catatan bahwa [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) dapat dibuang (seharusnya dibuang setelah digunakan).

Gunakan `getImage` untuk merender satu slide atau bentuk. Gunakan `getImages` untuk merender beberapa slide presentasi. Gunakan metode [Images](https://reference.aspose.com/slides/id/php-java/aspose.slides/images/) untuk memuat gambar, `addImage` dengan [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) untuk menambahkannya ke sebuah presentasi, dan `replaceImage` dengan [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) untuk memperbarui gambar presentasi yang ada.

Skenario tipikal penggunaan API baru dapat terlihat seperti berikut:

``` php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\ImageFormat;
use aspose\slides\Images;


$pres = new Presentation();

# buat sebuah instance IImage yang dapat dibuang dari file di disk.
$image = Images::fromFile("image.png");

# buat gambar PowerPoint dengan menambahkan instance IImage ke gambar presentasi.
$ppImage = $pres->getImages()->addImage($image);
$image->dispose();

# tambahkan bentuk gambar pada slide #1
$pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $ppImage);

$dimension = new Java("java.awt.Dimension", 1920, 1080);
# dapatkan sebuah instance IImage yang mewakili slide #1.
$slideImage = $pres->getSlides()->get_Item(0)->getImage($dimension);

# simpan gambar ke disk.
$slideImage->save("slide1.jpeg", ImageFormat::Jpeg);
$slideImage->dispose();

$pres->dispose();
```

## **Mengganti Kode Lama dengan Modern API**

Secara umum, Anda perlu mengganti pemanggilan yang menggunakan [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) dan [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) dengan metode baru yang menggunakan [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) .

API Warisan/usang:
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

### **Mendapatkan Thumbnail Slide**

API Warisan/usang:

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

### **Mendapatkan Thumbnail Bentuk**

API Warisan/usang:

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

### **Mendapatkan Thumbnail Presentasi**

API Warisan/usang:

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
$dimension = new Java("java.awt.Dimension", 1920, 1080");

$images = $pres->getImages($renderingOptions, $dimension);
for ($i = 0; $i < count(java_values($images)); $i++)
{
    $thumbnail = $images[$i];
    $thumbnail->save("slide" . $i . ".png", ImageFormat::Png);
}

$pres->dispose();
```

### **Menambahkan Gambar ke Presentasi**

API Warisan/usang:

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

## **Metode Usang dan Penggantinya di Modern API**

### **Presentasi**
| Tanda Tangan Metode                               | Tanda Tangan Metode Pengganti                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Bentuk**
| Tanda Tangan Metode                                                      | Tanda Tangan Metode Pengganti                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                                        | public final IImage getImage()                                                           |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Tanda Tangan Metode                                                      | Tanda Tangan Metode Pengganti                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | No Modern API replacement  |

### **Output**
| Tanda Tangan Metode                                                | Tanda Tangan Metode Pengganti                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Tanda Tangan Metode                          | Tanda Tangan Metode Pengganti               |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Tanda Tangan Metode                     | Tanda Tangan Metode Pengganti   |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Tanda Tangan Metode                                          | Tanda Tangan Metode Pengganti                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor)   | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Tanda Tangan Metode                                          | Tanda Tangan Metode Pengganti                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |


## **Dukungan API untuk Graphics2D**

Metode dengan [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) dinyatakan usang dan tidak memiliki pengganti Modern API secara langsung.

Gunakan metode rendering gambar Modern API alih-alih API yang merender ke [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Mengapa [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) dihapus?**

Dukungan untuk [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) dinyatakan usang dalam API publik untuk menyatukan kerja dengan rendering dan gambar, menghilangkan keterikatan pada ketergantungan spesifik platform, dan beralih ke pendekatan lintas‑platform dengan [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/). Gunakan `getImage` atau `getImages` alih-alih merender ke [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Apa manfaat praktis dari [IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) dibandingkan [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/iimage/) menyatukan kerja dengan gambar raster dan vektor serta menyederhanakan penyimpanan ke berbagai format melalui [ImageFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/imageformat/).

**Apakah Modern API akan memengaruhi kinerja pembuatan thumbnail?**

Berpindah dari `getThumbnail` ke `getImage` tidak memperburuk skenario: metode baru menyediakan kemampuan yang sama untuk menghasilkan gambar dengan opsi dan ukuran, sambil mempertahankan dukungan untuk opsi rendering. Keuntungan atau penurunan spesifik tergantung pada skenario, tetapi secara fungsional pengganti tersebut setara.