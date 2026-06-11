---
title: Ulepsz przetwarzanie obrazów przy użyciu nowoczesnego API
linktitle: Nowoczesne API
type: docs
weight: 237
url: /pl/androidjava/modern-api/
keywords:
- android.graphics
- nowoczesne API
- rysowanie
- miniatura slajdu
- slajd na obraz
- miniatura kształtu
- kształt na obraz
- miniatura prezentacji
- prezentacja na obrazy
- dodaj obraz
- dodaj zdjęcie
- Android
- Java
- Aspose.Slides
description: "Zmodernizuj przetwarzanie obrazów slajdów, zastępując przestarzałe API graficzne nowoczesnym API Java, aby zapewnić płynną automatyzację PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Historycznie Aspose Slides ma zależność od android.graphics i w publicznym API posiada następujące klasy z tego pakietu:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

Od wersji 24.4 ten publiczny interfejs API jest oznaczony jako przestarzały.

Aby pozbyć się zależności od tych klas, dodaliśmy tzw. „Nowoczesne API” – czyli API, które powinno być używane zamiast przestarzałego, którego sygnatury zawierają zależności od [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap). [Canvas](https://developer.android.com/reference/android/graphics/Canvas) jest oznaczony jako przestarzały i jego obsługa została usunięta z publicznego API Slides.

W bieżących wersjach traktuj publiczne API zależne od typów android.graphics jako przestarzałe/legacy. Używaj Nowoczesnego API w nowym kodzie oraz przy migracji istniejących przepływów przetwarzania obrazów.

## **Nowoczesne API**

Do publicznego API dodano następujące klasy i wyliczenia:

- [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) - reprezentuje obraz rastrowy lub wektorowy.
- [ImageFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imageformat/) - reprezentuje format pliku obrazu.
- [Images](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/images/) - metody do tworzenia i pracy z interfejsem [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/).

Należy zauważyć, że [IImage] jest obiektem zwalnianym i po jego użyciu powinno się wywołać `dispose()` lub zastosować inny wygodny wzorzec zwalniania.

Użyj `getImage` aby renderować pojedynczy slajd lub kształt. Użyj `getImages` aby renderować kilka slajdów prezentacji. Użyj metod z [Images](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/images/) do ładowania obrazów, `addImage` z [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) aby dodać je do prezentacji oraz `replaceImage` z [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) aby zaktualizować istniejący obraz w prezentacji.

Typowy scenariusz użycia nowego API może wyglądać następująco:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // utwórz instancję IImage, którą należy zwolnić, z pliku na dysku.
    IImage image = Images.fromFile("image.png");
    try {
        // stwórz obraz PowerPoint, dodając instancję IImage do obrazów prezentacji.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // dodaj kształt obrazu na slajdzie #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // pobierz instancję IImage reprezentującą slajd #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // zapisz obraz na dysku.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zastępowanie starego kodu przy użyciu Nowoczesnego API**

Ogólnie rzecz biorąc, będziesz musiał zastąpić wywołania używające [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) nowymi metodami wykorzystującymi [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/).

Starsze/przestarzałe API:
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
Nowe API:
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

### **Uzyskiwanie miniatury slajdu**

Starsze/przestarzałe API:

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

Nowe API:

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

### **Uzyskiwanie miniatury kształtu**

Starsze/przestarzałe API:

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

Nowe API:

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

### **Uzyskiwanie miniatury prezentacji**

Starsze/przestarzałe API:

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

Nowe API:

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

### **Dodawanie obrazu do prezentacji**

Starsze/przestarzałe API:

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

Nowe API:

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

## **Przestarzałe metody i ich zamienniki w Nowoczesnym API**

### **Presentation**
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
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
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Sygnatura metody | Sygnatura metody zamiennika |
|------------------|-----------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Obsługa API dla Canvas**

Metody z [Canvas](https://developer.android.com/reference/android/graphics/Canvas) są oznaczone jako przestarzałe i nie mają bezpośredniego zamiennika w Nowoczesnym API.

Użyj metod renderowania obrazów z Nowoczesnego API zamiast API renderującego do [Canvas](https://developer.android.com/reference/android/graphics/Canvas):

[Slide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **FAQ**

**Dlaczego usunięto android.graphics.Canvas?**

Obsługa [Canvas](https://developer.android.com/reference/android/graphics/Canvas) jest przestarzała w publicznym API, aby ujednolicić pracę z renderowaniem i obrazami, wyeliminować powiązania z zależnościami specyficznymi dla platformy oraz przejść na podejście wieloplatformowe z użyciem [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/). Użyj `getImage` lub `getImages` zamiast renderowania do [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**Jaką praktyczną korzyść daje [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) w porównaniu do [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)?**

[IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) ujednolica pracę zarówno z obrazami rastrowymi, jak i wektorowymi oraz upraszcza zapisywanie do różnych formatów za pomocą [ImageFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imageformat/).

**Czy Nowoczesne API wpłynie na wydajność generowania miniatur?**

Przejście z `getThumbnail` na `getImage` nie pogarsza scenariuszy: nowe metody zapewniają te same możliwości tworzenia obrazów z opcjami i rozmiarami, zachowując obsługę opcji renderowania. Konkretne zyski lub spadki zależą od sytuacji, ale funkcjonalnie zamienniki są równoważne.