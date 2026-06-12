---
title: Vylepšete zpracování obrázků pomocí Moderního API
linktitle: Moderní API
type: docs
weight: 237
url: /cs/java/modern-api/
keywords:
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
- Java
- Aspose.Slides
description: "Modernizujte zpracování obrázků snímků nahrazením zastaralých obrazových API moderním Java API pro plynulou automatizaci PowerPointu a OpenDocumentu."
---
## **Úvod**

Historicky má Aspose Slides závislost na java.awt a v veřejném API obsahuje následující třídy z ní:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

Od verze 24.4 je toto veřejné API označeno jako zastaralé.

Abychom se zbavili závislostí na těchto třídách, přidali jsme takzvané „Moderní API“ – tj. API, které by mělo být používáno místo zastaralého, jehož podpisy obsahují závislosti na [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) je označeno jako zastaralé a jeho podpora je z veřejného Slides API odebrána.

V současných verzích považujte veřejné API, které závisí na typech java.awt, za legacy/zastaralé. Pro nový kód a při migraci existujících workflow pro zpracování obrázků používejte Moderní API.

## **Moderní API**

Do veřejného API byly přidány následující třídy a výčty:

- [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) – představuje rastrový nebo vektorový obrázek.
- [ImageFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imageformat/) – představuje formát souboru obrázku.
- [Images](https://reference.aspose.com/slides/cs/java/com.aspose.slides/images/) – metody pro vytvoření a práci s rozhraním [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/).

Všimněte si, že [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) je disposable a po jeho použití by měl být zavolán `dispose()` nebo jiný vhodný vzor uvolnění.

Použijte `getImage` k vykreslení jedné snímku nebo tvaru. Použijte `getImages` k vykreslení několika snímků prezentace. Použijte metody z [Images](https://reference.aspose.com/slides/cs/java/com.aspose.slides/images/) k načtení obrázků, `addImage` s [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) pro přidání do prezentace a `replaceImage` s [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) pro aktualizaci existujícího obrázku v prezentaci.

Typický scénář použití nového API může vypadat následovně:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // vytvořte vyřaditelnou instanci IImage ze souboru na disku.
    IImage image = Images.fromFile("image.png");
    try {
        // vytvořte PowerPoint obrázek přidáním instance IImage do obrázků prezentace.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // přidejte obrázkový tvar na snímek #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // získejte instanci IImage představující snímek #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
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

## **Nahrazení starého kódu moderním API**

Obecně budete muset nahradit volání, která používají [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) a ImageIO, novými metodami, které používají [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/).

Legacy/deprecated API:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
Moderní API:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **Získání miniatury snímku**

Legacy/deprecated API:

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

Legacy/deprecated API:

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

Legacy/deprecated API:

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

Moderní API:

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

### **Přidání obrázku do prezentace**

Legacy/deprecated API:

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

## **Zastaralé metody a jejich náhrada v moderním API**

### **Presentation**
| Podpis metody | Podpis náhradní metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Podpis metody | Podpis náhradní metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Podpis metody | Podpis náhradní metody |
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
| Podpis metody | Podpis náhradní metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Podpis metody | Podpis náhradní metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Podpis metody | Podpis náhradní metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Podpis metody | Podpis náhradní metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Podpis metody | Podpis náhradní metody |
|-----------------------------------------------|---------------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Podpora API pro Graphics2D**

Metody s [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) jsou označeny jako zastaralé a nemají přímou náhradu v Moderním API.

Použijte metody Moderního API pro vykreslování obrázků místo API, které vykresluje do [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Proč byl [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) odstraněn?**

Podpora pro [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) je v veřejném API označena jako zastaralá, aby se sjednotila práce s vykreslováním a obrázky, odstranily se vazby na platformně specifické závislosti a přešlo se na multiplatformní přístup s [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/). Používejte `getImage` nebo `getImages` místo vykreslování do [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Jaký je praktický přínos [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) ve srovnání s [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) sjednocuje práci s rastrovými i vektorovými obrázky a zjednodušuje ukládání do různých formátů pomocí [ImageFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imageformat/).

**Ovlivní Moderní API výkon při generování miniatur?**

Přechod z `getThumbnail` na `getImage` nezhoršuje scénáře: nové metody poskytují stejné možnosti pro tvorbu obrázků s možnostmi a velikostmi, přičemž zachovávají podporu pro vykreslovací možnosti. Konkrétní zisk nebo ztráta závisí na scénáři, ale funkčně jsou náhrady ekvivalentní.