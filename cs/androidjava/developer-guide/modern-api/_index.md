---
title: Vylepšete zpracování obrazu pomocí Moderního API
linktitle: Moderní API
type: docs
weight: 237
url: /cs/androidjava/modern-api/
keywords:
- android.graphics
- moderní API
- kreslení
- miniatura snímku
- snímek na obrázek
- miniatura tvaru
- tvar na obrázek
- miniatura prezentace
- prezentace na obrázky
- přidat obrázek
- přidat obrázek
- Android
- Java
- Aspose.Slides
description: "Modernizujte zpracování obrázků snímků nahrazením zastaralých obrazových API moderním Java API pro plynulou automatizaci PowerPoint a OpenDocument."
---
## **Úvod**

Historicky má Aspose Slides závislost na **android.graphics** a v veřejném API má následující třídy z tohoto balíčku:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

Od verze 24.4 je toto veřejné API označeno jako zastaralé.

Abychom se zbavili závislostí na těchto třídách, přidali jsme takzvané „Moderní API“ – tj. API, které by se mělo používat místo zastaralého, jehož podpisy obsahují závislosti na [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap). [Canvas](https://developer.android.com/reference/android/graphics/Canvas) je označen jako zastaralý a jeho podpora je odstraněna z veřejného API Slides.

V současných verzích považujte veřejné API závislé na typech **android.graphics** za legacy/zastaralé. Používejte Moderní API pro nový kód i při migraci existujících workflow pro zpracování obrazu.

## **Moderní API**

Do veřejného API byly přidány následující třídy a výčty:

- [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) – představuje rastrový nebo vektorový obraz.
- [ImageFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imageformat/) – představuje formát souboru obrazu.
- [Images](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/images/) – metody pro vytvoření a práci s rozhraním [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/).

Všimněte si, že [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) je odkládací (disposable) a po jeho použití by se měl zavolat `dispose()` nebo jiný vhodný způsob uvolnění.

Použijte `getImage` pro vykreslení jednoho snímku nebo tvaru. Použijte `getImages` pro vykreslení několika snímků prezentace. Použijte metody [Images](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/images/) pro načtení obrázků, `addImage` s [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) pro přidání do prezentace a `replaceImage` s [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) pro aktualizaci existujícího obrázku v prezentaci.

Typický scénář použití nového API může vypadat následovně:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // vytvořte jednorázovou instanci IImage ze souboru na disku.
    IImage image = Images.fromFile("image.png");
    try {
        // vytvořte obrázek PowerPoint přidáním instance IImage do obrázků prezentace.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // přidejte obrázkový tvar na snímek č. 1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // získáte instanci IImage reprezentující snímek č. 1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // uložte obrázek na disk.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nahrazení starého kódu Moderním API**

Obecně budete muset nahradit volání používající [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) novými metodami, které používají [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/).

Zastaralé/legacy API:
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
Moderní API:
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

### **Získání miniatury snímku**

Zastaralé/legacy API:

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

Moderní API:

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

### **Získání miniatury tvaru**

Zastaralé/legacy API:

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

Moderní API:

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

### **Získání miniatury prezentace**

Zastaralé/legacy API:

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

Moderní API:

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

### **Přidání obrázku do prezentace**

Zastaralé/legacy API:

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

Moderní API:

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

## **Zastaralé metody a jejich náhrada v Moderním API**

### **Presentation**
| Podpis metody | Náhradní podpis metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| Podpis metody | Náhradní podpis metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Podpis metody | Náhradní podpis metody |
|-----------------------------------------------|---------------------------------------------------------|
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
| Podpis metody | Náhradní podpis metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Podpis metody | Náhradní podpis metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Podpis metody | Náhradní podpis metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Podpis metody | Náhradní podpis metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Podpis metody | Náhradní podpis metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Podpora API pro Canvas**

Metody s [Canvas](https://developer.android.com/reference/android/graphics/Canvas) jsou označeny jako zastaralé a nemají přímou náhradu v Moderním API.

Používejte metody Moderního API pro vykreslování obrázků místo API, které vykresluje do [Canvas](https://developer.android.com/reference/android/graphics/Canvas):

[Slide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **Často kladené otázky**

**Proč byl android.graphics.Canvas vyřazen?**

Podpora [Canvas](https://developer.android.com/reference/android/graphics/Canvas) je v veřejném API označena jako zastaralá, aby se sjednotila práce s vykreslováním a obrazy, odstranily se vazby na platformně specifické závislosti a přešlo se na multiplatformní přístup s [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/). Používejte `getImage` nebo `getImages` místo vykreslování do [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**Jaký je praktický přínos [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) oproti [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)?**

[IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) sjednocuje práci s rastrovými i vektorovými obrazy a zjednodušuje ukládání do různých formátů prostřednictvím [ImageFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imageformat/).

**Ovplyvní Moderní API výkon generování miniatur?**

Přechod z `getThumbnail` na `getImage` nezhoršuje scénáře: nové metody poskytují stejné možnosti pro vytváření obrázků s volbami a velikostmi, přičemž zachovávají podporu pro renderovací možnosti. Konkrétní zisk nebo ztráta závisí na scénáři, ale funkčně jsou náhrady ekvivalentní.