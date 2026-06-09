---
title: Modern API ile Görüntü İşlemeyi Geliştirin
linktitle: Modern API
type: docs
weight: 237
url: /tr/java/modern-api/
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
- Java
- Aspose.Slides
description: "Eski görüntüleme API'lerini Java Modern API ile değiştirerek slayt görüntü işlemeyi modernize edin ve sorunsuz PowerPoint ve OpenDocument otomasyonu sağlayın."
---
## **Giriş**

Tarihsel olarak, Aspose Slides java.awt'e bir bağımlılığı vardır ve açık API'de şu sınıfları içerir:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

24.4 sürümünden itibaren, bu açık API kullanımdan kaldırılmış olarak ilan edilmiştir.

Bu sınıflara olan bağımlılıklardan kurtulmak için, sözde "Modern API"yi ekledik — yani, imzalarında [BufferedImage] bağımlılığı bulunan eski, kullanımdan kaldırılmış API yerine kullanılacak API. [Graphics2D] kullanımdan kaldırılmış olarak duyurulmuş ve kamu Slides API'sinden desteği kaldırılmıştır.

Mevcut sürümlerde, java.awt tiplerine bağımlı olan açık API'yi eski/kullanımdan kaldırılmış olarak kabul edin. Yeni kodlar ve mevcut görüntü işleme iş akışlarını taşırken Modern API'yi kullanın.

## **Modern API**

Aşağıdaki sınıflar ve enum'lar açık API'ye eklendi:
- [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) - raster veya vektör görüntüyü temsil eder.
- [ImageFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imageformat/) - görüntünün dosya biçimini temsil eder.
- [Images](https://reference.aspose.com/slides/tr/java/com.aspose.slides/images/) - [IImage] arayüzünü oluşturmak ve onunla çalışmak için yöntemler.

Lütfen [IImage] nesnesinin kullanılabilir olduğunu ve kullanımının ardından bir `dispose()` çağrısı ya da başka bir uygun yok etme deseninin izlenmesi gerektiğini unutmayın.

`getImage` kullanarak tek bir slayt veya şekil oluşturun. `getImages` kullanarak birden fazla sunum slaytı oluşturun. Görüntüleri yüklemek için [Images] yöntemlerini, bir sunuma eklemek için `addImage` ile [IImage] ve mevcut bir sunum görüntüsünü güncellemek için `replaceImage` ile [IImage] kullanın.

Yeni API'yi kullanmanın tipik bir senaryosu aşağıdaki gibi görünebilir:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // diskteki dosyadan atılabilir bir IImage örneği oluştur.
    IImage image = Images.fromFile("image.png");
    try {
        // sunumun görüntülerine bir IImage örneği ekleyerek PowerPoint görüntüsü oluştur.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // slayt #1'e bir resim şekli ekle.
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // slayt #1'i temsil eden IImage örneğini al.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // görüntüyü diske kaydet.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eski Kodu Modern API ile Değiştirme**

Genel olarak, [BufferedImage] ve ImageIO kullanan çağrıları, [IImage] kullanan yeni yöntemlerle değiştirmeniz gerekecek.

Eski/kullanımdan kaldırılmış API:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
Modern API:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **Slayt Küçük Resmi Alma**

Eski/kullanımdan kaldırılmış API:

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

Modern API:

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

### **Şekil Küçük Resmi Alma**

Eski/kullanımdan kaldırılmış API:

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

Modern API:

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

### **Sunum Küçük Resmi Alma**

Eski/kullanımdan kaldırılmış API:

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

Modern API:

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

### **Sunuma Resim Ekleme**

Eski/kullanımdan kaldırılmış API:

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

Modern API:

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

## **Modern API'de Kullanımdan Kaldırılan Metotlar ve Yerine Kullanımları**

### **Sunum**
| Metot İmzası | Yerine Kullanılacak Metot İmzası |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Şekil**
| Metot İmzası | Yerine Kullanılacak Metot İmzası |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slayt**
| Metot İmzası | Yerine Kullanılacak Metot İmzası |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Modern API'de yerine yok |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Modern API'de yerine yok |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Modern API'de yerine yok |

### **Çıktı**
| Metot İmzası | Yerine Kullanılacak Metot İmzası |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Metot İmzası | Yerine Kullanılacak Metot İmzası |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Metot İmzası | Yerine Kullanılacak Metot İmzası |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Metot İmzası | Yerine Kullanılacak Metot İmzası |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Metot İmzası | Yerine Kullanılacak Metot İmzası |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |


## **Graphics2D için API Desteği**

[Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) içeren yöntemler kullanımdan kaldırılmış olarak ilan edilmiştir ve doğrudan bir Modern API karşılığı yoktur.

Graphics2D'ye render yapan API yerine Modern API görüntü renderleme yöntemlerini kullanın:

[Slide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **SSS**

**Neden [Graphics2D] kaldırıldı?**

[Graphics2D] desteği, rendering ve görüntülerle çalışma süreçlerini birleştirmek, platforma özgü bağımlılıkları ortadan kaldırmak ve [IImage] ile çapraz platform bir yaklaşıma geçmek amacıyla açık API'de kullanımdan kaldırılmıştır. [Graphics2D] yerine `getImage` veya `getImages` kullanın.

**[IImage]'in [BufferedImage]'e göre pratik faydası nedir?**

[IImage] raster ve vektör görüntülerle çalışmayı birleştirir ve [ImageFormat] aracılığıyla çeşitli formatlarda kaydetmeyi basitleştirir.

**Modern API, küçük resim oluşturma performansını etkileyecek mi?**

`getThumbnail`'dan `getImage`'a geçiş senaryoları kötüleştirmez: yeni yöntemler, seçenekler ve boyutlarla aynı yetenekleri sunar ve rendering seçenekleri desteğini korur. Kazanç ya da kayıp, senaryoya bağlıdır, ancak işlevsel olarak değişimler eşdeğerdir.