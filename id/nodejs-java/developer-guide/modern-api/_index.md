---
title: Tingkatkan Pemrosesan Gambar dengan Modern API
linktitle: API Modern
type: docs
weight: 237
url: /id/nodejs-java/modern-api/
keywords:
- API modern
- menggambar
- thumbnail slide
- slide ke gambar
- thumbnail bentuk
- bentuk ke gambar
- thumbnail presentasi
- presentasi ke gambar
- tambahkan gambar
- tambahkan foto
- Node.js
- JavaScript
- Aspose.Slides
description: "Modernisasi pemrosesan gambar slide dengan mengganti API imaging yang usang dengan JavaScript Modern API untuk otomatisasi PowerPoint dan OpenDocument yang mulus."
---
## **Pendahuluan**

Secara historis, Aspose Slides memiliki ketergantungan pada `java.awt` dan memiliki dalam API publik kelas‑kelas berikut dari sana:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Mulai versi 24.4, API publik ini dinyatakan usang.

Untuk menghilangkan ketergantungan pada kelas‑kelas tersebut, kami menambahkan apa yang disebut “Modern API” — yaitu API yang harus digunakan sebagai pengganti yang usang, yang tanda‑tangannya tidak lagi bergantung pada [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) dinyatakan usang dan dukungannya dihapus dari API publik Slides.

Pada versi saat ini, anggaplah API publik yang bergantung pada tipe `java.awt` sebagai warisan/usang. Gunakan Modern API untuk kode baru dan saat memigrasi alur kerja pengolahan gambar yang sudah ada.

## **Modern API**

Ditambahkan kelas dan enum berikut ke API publik:

- [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/) – mewakili gambar raster atau vektor.
- [ImageFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imageformat/) – mewakili format berkas gambar.
- [Images](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/images/) – metode untuk membuat instance dan bekerja dengan kelas [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/).

Harap dicatat bahwa [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/) dapat dibuang dan penggunaannya harus diikuti dengan pemanggilan `dispose()` atau pola pembuangan yang nyaman lainnya.

Gunakan `getImage` untuk merender satu slide atau shape. Gunakan `getImages` untuk merender beberapa slide presentasi. Gunakan metode [Images](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/images/) untuk memuat gambar, `addImage` dengan [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/) untuk menambahkannya ke presentasi, dan `replaceImage` dengan [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/) untuk memperbarui gambar presentasi yang sudah ada.

Skenario tipikal penggunaan API baru dapat terlihat sebagai berikut:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // buat sebuah instance IImage yang dapat dibuang dari berkas di disk.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // buat gambar PowerPoint dengan menambahkan instance IImage ke gambar presentasi.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // tambahkan shape gambar pada slide #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // dapatkan instance IImage yang mewakili slide #1.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // simpan gambar ke disk.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mengganti Kode Lama dengan Modern API**

Secara umum, Anda perlu mengganti pemanggilan yang menggunakan [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) dan [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) dengan metode baru yang menggunakan [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/).

API warisan/usang:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
API Modern:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **Mendapatkan Thumbnail Slide**

API warisan/usang:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "slide1.png");
    imageio.write(slideImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

API Modern:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slideImage = pres.getSlides().get_Item(0).getImage();
    slideImage.save("slide1.png", aspose.slides.ImageFormat.Png);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **Mendapatkan Thumbnail Shape**

API warisan/usang:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "shape.png");
    imageio.write(shapeImage, "PNG", file);
} finally {
    if (pres != null) pres.dispose();
}
```

API Modern:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    shapeImage.save("shape.png");
    shapeImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```

### **Mendapatkan Thumbnail Presentasi**

API warisan/usang:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var bitmaps = pres.getThumbnails(new aspose.slides.RenderingOptions(), size);
    for (var index = 0; index < bitmaps.length; index++)
    {
        var thumbnail = bitmaps[index];
        var imageio = java.import("javax.imageio.ImageIO");
        var file = java.newInstanceSync("java.io.File", "slide" + index + ".png");
        imageio.write(thumbnail, "PNG", file);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

API Modern:

``` javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 1980, 1028);
    var images = pres.getImages(new aspose.slides.RenderingOptions(), size);
    try
    {
        for (var index = 0; index < images.length; index++)
        {
            var thumbnail = images[index];
            thumbnail.save("slide" + index + ".png", aspose.slides.ImageFormat.Png);
        }
    }
    finally
    {
        images.forEach(item => {item.dispose();});
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Menambahkan Gambar ke Presentasi**

API warisan/usang:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var imageio = java.import("javax.imageio.ImageIO");
    var file = java.newInstanceSync("java.io.File", "image.png");
    var bufferedImages = imageio.read(file);
    var ppImage = pres.getImages().addImage(bufferedImages);

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

API Modern:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var image = aspose.slides.Images.fromFile("image.png");
    var ppImage = pres.getImages().addImage(image);
    image.dispose();

    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Metode Usang dan Penggantinya di Modern API**

### **Presentation**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-----------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-----------------------------------------------|-----------------------------------------------------|
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
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-----------------------------------------------|-----------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-------------------------------------------|--------------------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|--------------------------------------|-------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-------------------------------------------|-----------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-------------------------------------------|-----------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Dukungan API untuk Graphics2D**

Metode dengan [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) dinyatakan usang dan tidak memiliki pengganti Modern API yang langsung.

Gunakan metode rendering gambar Modern API sebagai pengganti API yang merender ke [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**Apa manfaat praktis dari [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/) dibandingkan dengan [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/) menyatukan kerja dengan gambar raster dan vektor serta menyederhanakan penyimpanan ke berbagai format melalui [ImageFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imageformat/).

**Apakah Modern API akan memengaruhi kinerja pembuatan thumbnail?**

Berpindah dari `getThumbnail` ke `getImage` tidak memperburuk skenario: metode baru memberikan kapabilitas yang sama untuk menghasilkan gambar dengan opsi dan ukuran, sambil tetap mendukung opsi rendering. Keuntungan atau penurunan spesifik bergantung pada skenario, tetapi secara fungsional penggantiannya setara.