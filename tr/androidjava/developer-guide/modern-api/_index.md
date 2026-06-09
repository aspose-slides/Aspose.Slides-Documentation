---
title: Modern API ile Görüntü İşlemeyi Geliştirin
linktitle: Modern API
type: docs
weight: 237
url: /tr/androidjava/modern-api/
keywords:
- android.graphics
- Modern API
- çizim
- slayt küçük resmi
- slayttan görüntüye
- şekil küçük resmi
- şekilden görüntüye
- sunum küçük resmi
- sunumu görüntülere
- görüntü ekle
- resim ekle
- Android
- Java
- Aspose.Slides
description: "Eski görüntüleme API'lerini Java Modern API ile değiştirerek slayt görüntü işlemeyi modernize edin ve sorunsuz PowerPoint ve OpenDocument otomasyonu sağlayın."
---
## **Giriş**

Geçmişte, Aspose Slides android.graphics'e bağımlıdır ve genel API'sinde aşağıdaki sınıfları içerir:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

24.4 sürümünden itibaren, bu genel API kullanımdan kaldırılmış olarak ilan edilmiştir.

Bu sınıflara olan bağımlılıkları ortadan kaldırmak için, sözde "Modern API"yi ekledik - yani, kullanımdan kaldırılmış olanın yerine kullanılacak API, imzalarında [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) bağımlılığı bulunan. [Canvas](https://developer.android.com/reference/android/graphics/Canvas) kullanımdan kaldırılmış olarak ilan edilmiştir ve destek, genel Slides API'sinden kaldırılmıştır.

Mevcut sürümlerde, android.graphics türlerine bağımlı genel API'yi eski/kullanımdan kaldırılmış olarak ele alın. Yeni kod için ve mevcut görüntü işleme iş akışlarını taşıma sırasında Modern API'yi kullanın.

## **Modern API**

Aşağıdaki sınıflar ve enum'lar genel API'ye eklendi:

- [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) - raster veya vektör görüntüyü temsil eder.
- [ImageFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imageformat/) - görüntünün dosya formatını temsil eder.
- [Images](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) arayüzünü örneklemek ve onunla çalışmak için yöntemler.

Lütfen [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) 'ın atılabilir olduğunu ve kullanımının bir `dispose()` çağrısı veya başka uygun bir imha düzeni ile takip edilmesi gerektiğini unutmayın.

`getImage` kullanarak tek bir slayt veya şekil oluşturun. `getImages` ile birden fazla sunum slaytı oluşturun. [Images](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/images/) yöntemlerini kullanarak görüntüleri yükleyin, `addImage` ile [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) sunuma ekleyin ve `replaceImage` ile [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) mevcut sunum görüntüsünü güncelleyin.

Yeni API'yi kullanmanın tipik bir senaryosu aşağıdaki gibi görünebilir:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // diskteki dosyadan atılabilir bir IImage örneği oluşturun.
    IImage image = Images.fromFile("image.png");
    try {
        // IImage örneğini sunumun görüntülerine ekleyerek bir PowerPoint görüntüsü oluşturun.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // #1 slayta bir resim şekli ekleyin
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // #1 slaytı temsil eden IImage örneğini alın.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // görüntüyü diske kaydedin.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eski Kodu Modern API ile Değiştirme**

Genel olarak, [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) kullanan çağrıları, [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) kullanan yeni yöntemlerle değiştirmeniz gerekir.

Eski/kullanımdan kaldırılmış API:
``` java
Presentation pres = new Presentation();
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail(new Size(1920, 1080));
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("image.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```
Modern API:
``` java
Presentation pres = new Presentation();
try {
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        slideImage.save("image.png", ImageFormat.Png);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Slayt Küçük Resmi Alma**

Eski/kullanımdan kaldırılmış API:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    Bitmap slideImage = pres.getSlides().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("slide1.png");
        slideImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
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
    Bitmap shapeImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail();
    FileOutputStream fos = null;
    try {
        fos = new FileOutputStream("shape.png");
        shapeImage.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    } finally {
        if (fos != null) {
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
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
    Bitmap[] bitmaps = pres.getThumbnails(new RenderingOptions(), new Size(1980, 1028));
    for (int index = 0; index < bitmaps.length; index++)
    {
        android.graphics.Bitmap thumbnail = bitmaps[index];
        FileOutputStream fos = null;
        try {
            fos = new FileOutputStream("slide" + index + ".png");
            thumbnail.compress(android.graphics.Bitmap.CompressFormat.PNG, 100, fos);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } finally {
            if (fos != null) {
                try {
                    fos.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
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
    IImage[] images = pres.getImages(new RenderingOptions(), new Size(1980, 1028));
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
    File file = new File("image.png");
    Bitmap bitmap = BitmapFactory.decodeFile(file.getAbsolutePath());
    ppImage = pres.getImages().addImage(bitmap);

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

## **Modern API'de Kullanımdan Kaldırılan Yöntemler ve Yerine Geçenler**

### **Presentation**
| Yöntem İmzası                               | Yerine Geçen Yöntem İmzası                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| Yöntem İmzası                                                      | Yerine Geçen Yöntem İmzası                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Yöntem İmzası                                                      | Yerine Geçen Yöntem İmzası                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | No Modern API replacement  |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | No Modern API replacement  |

### **Output**
| Yöntem İmzası                                                | Yerine Geçen Yöntem İmzası                                |
|-------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Yöntem İmzası                          | Yerine Geçen Yöntem İmzası               |
|-------------------------------------------|--------------------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Yöntem İmzası                     | Yerine Geçen Yöntem İmzası   |
|--------------------------------------|-----------------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Yöntem İmzası                                          | Yerine Geçen Yöntem İmzası                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer styleColor)   | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Yöntem İmzası                                          | Yerine Geçen Yöntem İmzası                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |


## **Canvas İçin API Desteği**

[Canvas](https://developer.android.com/reference/android/graphics/Canvas) içeren yöntemler kullanımdan kaldırılmış olarak ilan edilmiş ve doğrudan Modern API karşılığı yoktur.

API'yi [Canvas](https://developer.android.com/reference/android/graphics/Canvas)'a render eden yerine Modern API görüntü renderleme yöntemlerini kullanın:

[Slayt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **SSS**

**android.graphics.Canvas neden kaldırıldı?**

Genel API'de [Canvas] desteği, renderlama ve görüntülerle çalışma sürecini birleştirmek, platforma özgü bağımlılıkları ortadan kaldırmak ve [IImage] ile çapraz platform bir yaklaşım benimsemek için kullanımdan kaldırılmıştır. [Canvas] yerine `getImage` veya `getImages` kullanın.

**[IImage]’in [Bitmap]’e göre pratik faydası nedir?**

[IImage], raster ve vektör görüntülerle çalışmayı birleştirir ve [ImageFormat] aracılığıyla çeşitli formatlara kaydetmeyi kolaylaştırır.

**Modern API, küçük resim oluşturma performansını etkiler mi?**

`getThumbnail`'dan `getImage`'a geçiş senaryoları kötüleştirmez: yeni yöntemler, seçenekler ve boyutlarla görüntü üretmek için aynı yetenekleri sağlar ve render seçenekleri desteğini korur. Belirli bir kazanç ya da kayıp senaryoya bağlıdır, ancak işlevsel olarak yerine geçenler eşdeğerdir.