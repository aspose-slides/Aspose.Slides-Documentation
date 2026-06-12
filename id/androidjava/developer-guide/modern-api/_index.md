---
title: "Tingkatkan Pemrosesan Gambar dengan API Modern"
linktitle: "API Modern"
type: docs
weight: 237
url: /id/androidjava/modern-api/
keywords:
- android.graphics
- API Modern
- menggambar
- thumbnail slide
- slide ke gambar
- thumbnail bentuk
- bentuk ke gambar
- thumbnail presentasi
- presentasi ke gambar
- tambahkan gambar
- tambahkan gambar
- Android
- Java
- Aspose.Slides
description: "Modernisasi pemrosesan gambar slide dengan mengganti API pengolahan gambar yang usang dengan Java API Modern untuk otomasi PowerPoint dan OpenDocument yang mulus."
---
## **Pendahuluan**

Secara historis, Aspose Slides memiliki ketergantungan pada android.graphics dan memiliki dalam API publik kelas‑kelas berikut dari sana:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

Mulai versi 24.4, API publik ini dinyatakan usang.

Untuk menghilangkan ketergantungan pada kelas‑kelas ini, kami menambahkan apa yang disebut "Modern API" - yaitu API yang harus digunakan alih‑alih yang usang, yang tanda tangannya mengandung ketergantungan pada [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap). [Canvas](https://developer.android.com/reference/android/graphics/Canvas) dinyatakan usang dan dukungannya dihapus dari API Slides publik.

Pada versi saat ini, anggap API publik yang bergantung pada tipe android.graphics sebagai warisan/usang. Gunakan Modern API untuk kode baru dan saat memigrasi alur kerja pemrosesan gambar yang ada.

## **Modern API**

Menambahkan kelas dan enum berikut ke API publik:

- [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/) - mewakili gambar raster atau vektor.
- [ImageFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imageformat/) - mewakili format berkas gambar.
- [Images](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/images/) - metode untuk membuat instance dan bekerja dengan antarmuka [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/).

Harap perhatikan bahwa [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/) dapat dibuang dan penggunaannya harus diikuti dengan pemanggilan `dispose()` atau pola pembuangan yang nyaman lainnya.

Gunakan `getImage` untuk merender satu slide atau bentuk. Gunakan `getImages` untuk merender beberapa slide presentasi. Gunakan metode [Images](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/images/) untuk memuat gambar, `addImage` dengan [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/) untuk menambahkannya ke presentasi, dan `replaceImage` dengan [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/) untuk memperbarui gambar presentasi yang ada.

Skenario tipikal penggunaan API baru dapat terlihat seperti berikut:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // instantiate sebuah instance IImage yang dapat dibuang dari file di disk.
    IImage image = Images.fromFile("image.png");
    try {
        // buat gambar PowerPoint dengan menambahkan sebuah instance IImage ke gambar presentasi.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // tambahkan bentuk gambar pada slide #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // dapatkan sebuah instance IImage yang mewakili slide #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
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

## **Menggantikan Kode Lama dengan Modern API**

Secara umum, Anda harus mengganti pemanggilan yang menggunakan [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) dengan metode baru yang menggunakan [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/).

API Warisan/usang:
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

### **Mendapatkan Thumbnail Slide**

API Warisan/usang:

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

### **Mendapatkan Thumbnail Bentuk**

API Warisan/usang:

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

### **Mendapatkan Thumbnail Presentasi**

API Warisan/usang:

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

### **Menambahkan Gambar ke Presentasi**

API Warisan/usang:

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

## **Metode Usang dan Penggantiannya dalam Modern API**

### **Presentation**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-----------------------------------------------|-----------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-----------------------------------------------|-----------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(Size imageSize) | public final IImage getImage(Size imageSize) |
| public final Bitmap getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final Bitmap getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final Bitmap getThumbnail(IRenderingOptions options, Size imageSize) | public final IImage getImage(IRenderingOptions options, Size imageSize) |
| public final Bitmap getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize) | No Modern API replacement |
| public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY) | No Modern API replacement |

### **Output**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-----------------------------------------------|-----------------------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-----------------------------------------------|-----------------------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-----------------------------------------------|-----------------------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-----------------------------------------------|-----------------------------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Tanda Tangan Metode | Tanda Tangan Metode Pengganti |
|-----------------------------------------------|-----------------------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Dukungan API untuk Canvas**

Metode dengan [Canvas](https://developer.android.com/reference/android/graphics/Canvas) dinyatakan usang dan tidak memiliki pengganti Modern API langsung.

Gunakan metode rendering gambar Modern API alih‑alih API yang merender ke [Canvas](https://developer.android.com/reference/android/graphics/Canvas):

[Slide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **FAQ**

**Mengapa android.graphics.Canvas dihapus?**

Dukungan untuk [Canvas](https://developer.android.com/reference/android/graphics/Canvas) usang dalam API publik untuk menyatukan kerja dengan rendering dan gambar, menghilangkan ketergantungan pada platform spesifik, dan beralih ke pendekatan lintas‑platform dengan [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/). Gunakan `getImage` atau `getImages` alih‑alih merender ke [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**Apa manfaat praktis [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/) dibandingkan [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)?**

[IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/) menyatukan kerja dengan gambar raster dan vektor serta mempermudah penyimpanan ke berbagai format melalui [ImageFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imageformat/).

**Apakah Modern API akan memengaruhi kinerja pembuatan thumbnail?**

Berpindah dari `getThumbnail` ke `getImage` tidak memperburuk skenario: metode baru memberikan kemampuan yang sama untuk menghasilkan gambar dengan opsi dan ukuran, sambil mempertahankan dukungan untuk opsi rendering. Keuntungan atau penurunan spesifik bergantung pada skenario, tetapi secara fungsional penggantiannya setara.