---
title: "Modern API ile Görüntü İşlemesini Geliştirin"
linktitle: "Modern API"
type: docs
weight: 237
url: /tr/nodejs-java/modern-api/
keywords:
  - modern API
  - çizim
  - slayt küçük resmi
  - slaytı görüntüye
  - şekil küçük resmi
  - şekli görüntüye
  - sunum küçük resmi
  - sunumu görüntülere
  - görüntü ekle
  - resim ekle
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Eski görüntü işleme API'lerini JavaScript Modern API ile değiştirerek slayt görüntü işleme süreçlerini modernize edin ve sorunsuz PowerPoint ve OpenDocument otomasyonu sağlayın."
---
## **Giriş**

Tarihsel olarak, Aspose Slides java.awt'ye bir bağımlılığı vardır ve genel API'de aşağıdaki sınıfları içerir:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

24.4 sürümünden itibaren, bu genel API artık kullanımdan kaldırılmış olarak ilan edilmiştir.

Bu sınıflara olan bağımlılıklardan kurtulmak için sözde "Modern API" ekledik – yani artık kullanılmayan API yerine kullanılacak API, imzalarında [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) bağımlılığı bulunan. [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) kullanımdan kaldırılmıştır ve destekleri genel Slides API'sinden kaldırılmıştır.

Mevcut sürümlerde, java.awt tiplerine bağımlı olan genel API'yi eski/kullanımdan kaldırılmış olarak ele alın. Yeni kodlama ve mevcut görüntü işleme akışlarını taşırken Modern API'yi kullanın.

## **Modern API**

Aşağıdaki sınıflar ve enum'lar genel API'ye eklendi:

- [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) - raster veya vektör görüntüyü temsil eder.
- [ImageFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imageformat/) - görüntünün dosya biçimini temsil eder.
- [Images](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) sınıfını örneklemek ve onunla çalışmak için yöntemler.

Lütfen [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) nesnesinin atılabilir olduğunu ve kullanımının ardından bir `dispose()` çağrısı ya da başka bir uygun imha modeli izlenmesi gerektiğini unutmayın.

Tek bir slayt ya da şekil oluşturmak için `getImage` kullanın. Birden çok sunum slaytı oluşturmak için `getImages` kullanın. Görüntüleri yüklemek için [Images](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/images/) yöntemlerini, bir sunuma eklemek için `addImage` ile [IImage] kullanın ve mevcut bir sunum görüntüsünü güncellemek için `replaceImage` ile [IImage] kullanın.

Yeni API'nin tipik bir kullanımı aşağıdaki gibi görünebilir:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // diskteki dosyadan IImage'ın atılabilir bir örneğini oluştur.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // sunumun görüntülerine bir IImage örneği ekleyerek PowerPoint resmi oluştur.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // slayt #1'e bir resim şekli ekle
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // slayt #1'i temsil eden IImage örneğini al.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // resmi diske kaydet.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eski Kodu Modern API ile Değiştirme**

Genel olarak, [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) ve [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) kullanan çağrıları, [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) kullanan yeni yöntemlerle değiştirmeniz gerekir.

Legacy/kullanımdan kaldırılmış API:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
Modern API:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **Slayt Küçük Resmi Alma**

Legacy/kullanımdan kaldırılmış API:

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

Modern API:

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

### **Şekil Küçük Resmi Alma**

Legacy/kullanımdan kaldırılmış API:

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

Modern API:

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

### **Sunum Küçük Resmi Alma**

Legacy/kullanımdan kaldırılmış API:

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

Modern API:

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

### **Sunuma Resim Ekleme**

Legacy/kullanımdan kaldırılmış API:

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

Modern API:

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

## **Kullanımdan Kaldırılmış Yöntemler ve Modern API'deki Yerine Geçenler**

### **Presentation**
| Yöntem İmzası | Yerine Geçen Yöntem İmzası |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Yöntem İmzası | Yerine Geçen Yöntem İmzası |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Yöntem İmzası | Yerine Geçen Yöntem İmzası |
|-----------------------------------------------|---------------------------------------------------------|
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
| Yöntem İmzası | Yerine Geçen Yöntem İmzası |
|-----------------------------------------------|---------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Yöntem İmzası | Yerine Geçen Yöntem İmzası |
|-----------------------------------------------|---------------------------------------------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Yöntem İmzası | Yerine Geçen Yöntem İmzası |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Yöntem İmzası | Yerine Geçen Yöntem İmzası |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Yöntem İmzası | Yerine Geçen Yöntem İmzası |
|-----------------------------------------------|---------------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Graphics2D için API Desteği**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) kullanan yöntemler kullanımdan kaldırılmıştır ve doğrudan bir Modern API yerine geçeni yoktur.

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) üzerine render yapan API yerine Modern API görüntü renderleme yöntemlerini kullanın:

[Slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **SSS**

**[IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) üzerine pratik faydası nedir?**

[IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) raster ve vektör görüntülerle çalışmayı birleştirir ve [ImageFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imageformat/) aracılığıyla çeşitli biçimlere kaydetmeyi basitleştirir.

**Modern API, küçük resim oluşturma performansını etkiler mi?**

`getThumbnail` yerine `getImage` kullanmak senaryoları kötüleştirmez: yeni yöntemler aynı seçenekler ve boyutlarla görüntü üretme yeteneğini sağlarken render seçenekleri desteğini korur. Kazanç veya kayıp, senaryoya bağlıdır; fonksiyonel olarak değişimler eşdeğerdir.