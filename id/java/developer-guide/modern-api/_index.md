---
title: Meningkatkan Pemrosesan Gambar dengan API Modern
linktitle: API Modern
type: docs
weight: 237
url: /id/java/modern-api/
keywords:
- API modern
- menggambar
- miniatur slide
- slide ke gambar
- miniatur bentuk
- bentuk ke gambar
- miniatur presentasi
- presentasi ke gambar
- tambahkan gambar
- tambahkan foto
- Java
- Aspose.Slides
description: "Modernisasi pemrosesan gambar slide dengan mengganti API imaging yang tidak lagi disarankan dengan Java Modern API untuk otomatisasi PowerPoint dan OpenDocument yang mulus."
---
## **Pendahuluan**

Secara historis, Aspose Slides memiliki ketergantungan pada java.awt dan dalam API publik memiliki kelas‑kelas berikut dari sana:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Mulai versi 24.4, API publik ini dinyatakan tidak lagi disarankan.

Untuk menghilangkan ketergantungan pada kelas‑kelas ini, kami menambahkan apa yang disebut “API Modern” — yaitu API yang harus digunakan menggantikan yang tidak lagi disarankan, yang tanda tangannya tidak mengandung ketergantungan pada [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) dinyatakan tidak lagi disarankan dan dukungannya dihapus dari API Slides publik.

Pada versi saat ini, perlakukan API publik yang bergantung pada tipe java.awt sebagai warisan/tidak lagi disarankan. Gunakan API Modern untuk kode baru dan saat memigrasikan alur kerja pemrosesan gambar yang ada.

## **API Modern**

Menambahkan kelas dan enum berikut ke API publik:

- [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/) - merepresentasikan gambar raster atau vektor.
- [ImageFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/imageformat/) - merepresentasikan format file gambar.
- [Images](https://reference.aspose.com/slides/id/java/com.aspose.slides/images/) - metode untuk membuat instance dan bekerja dengan antarmuka [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/).

Harap perhatikan bahwa [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/) dapat dibuang dan penggunaannya harus diikuti dengan pemanggilan `dispose()` atau pola pembuangan lain yang nyaman.

Gunakan `getImage` untuk merender satu slide atau bentuk. Gunakan `getImages` untuk merender beberapa slide presentasi. Gunakan metode [Images](https://reference.aspose.com/slides/id/java/com.aspose.slides/images/) untuk memuat gambar, `addImage` dengan [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/) untuk menambahkannya ke presentasi, dan `replaceImage` dengan [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/) untuk memperbarui gambar presentasi yang ada.

Skenario tipikal menggunakan API baru dapat terlihat sebagai berikut:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // instansiasi instance IImage yang dapat dibuang dari file di disk.
    IImage image = Images.fromFile("image.png");
    try {
        // buat gambar PowerPoint dengan menambahkan instance IImage ke gambar presentasi.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // tambahkan bentuk gambar pada slide #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // dapatkan instance IImage yang merepresentasikan slide #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // simpan gambar ke disk.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menggantikan Kode Lama dengan API Modern**

Secara umum, Anda perlu mengganti pemanggilan yang menggunakan [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) dan ImageIO dengan metode baru yang menggunakan [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/).

API warisan/tidak lagi disarankan:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
API Modern:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **Mendapatkan Miniatur Slide**

API warisan/tidak lagi disarankan:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail();
    try {
        ImageIO.write(slideImage, "PNG", new File("slide1.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

API Modern:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage();
    try {
        slideImage.save("slide1.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Mendapatkan Miniatur Bentuk**

API warisan/tidak lagi disarankan:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    try {
        ImageIO.write(shapeImage, "PNG", new File("shape.png"));
    } catch (IOException e) {
        e.printStackTrace();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

API Modern:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    try {
        shapeImage.save("shape.png");
    } finally {
        if (shapeImage != null) shapeImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Mendapatkan Miniatur Presentasi**

API warisan/tidak lagi disarankan:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    BufferedImage[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Dimension(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        try 
        {
            BufferedImage thumbnail = bitmaps[index];
            ImageIO.write(thumbnail, "PNG", new File("slide" + index + ".png"));
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

API Modern:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    IImage[] images = pres.getImages(new RenderingOptions(), new Dimension(1980, 1028));
    try
    {
        for (int index = 0; index < images.length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", ImageFormat.Png);
        }
    }
    finally
    {
        for (IImage image : images)
        {
            image.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Menambahkan Gambar ke Presentasi**

API warisan/tidak lagi disarankan:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage = null;
    try {
        BufferedImage bufferedImages = ImageIO.read(new File("image.png"));
        ppImage = pres.getImages().addImage(bufferedImages);
    } catch (IOException e) {
        e.printStackTrace();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

API Modern:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    IImage image = Images.fromFile("image.png");
    try {
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Metode yang Tidak Lagi Disarankan dan Penggantiannya di API Modern**

### **Presentation**
| Tanda Tangan Metode                               | Tanda Tangan Metode Pengganti                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
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
| public final BufferedImage getTileImage(Color background, Color foreground) |public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Tanda Tangan Metode                                          | Tanda Tangan Metode Pengganti                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Dukungan API untuk Graphics2D**

Metode dengan [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) dinyatakan tidak lagi disarankan dan tidak memiliki pengganti API Modern yang langsung.

Gunakan metode rendering gambar API Modern alih-alih API yang merender ke [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Mengapa [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) dihapus?**

Dukungan untuk [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) tidak lagi disarankan dalam API publik untuk menyatukan kerja dengan rendering dan gambar, menghilangkan ketergantungan pada platform tertentu, dan beralih ke pendekatan lintas platform dengan [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/). Gunakan `getImage` atau `getImages` alih-alih merender ke [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Apa manfaat praktis [IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/) dibandingkan [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/iimage/) menyatukan kerja dengan gambar raster dan vektor serta menyederhanakan penyimpanan ke berbagai format melalui [ImageFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/imageformat/).

**Apakah API Modern akan memengaruhi kinerja pembuatan miniatur?**

Berpindah dari `getThumbnail` ke `getImage` tidak memperburuk skenario: metode baru memberikan kemampuan yang sama untuk menghasilkan gambar dengan opsi dan ukuran, sambil tetap mendukung opsi rendering. Keuntungan atau penurunan spesifik tergantung pada skenario, tetapi secara fungsional penggantinya setara.