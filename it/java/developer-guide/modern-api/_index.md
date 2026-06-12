---
title: Migliora l'elaborazione delle immagini con la Modern API
linktitle: API Moderna
type: docs
weight: 237
url: /it/java/modern-api/
keywords:
- API moderna
- disegno
- miniatura diapositiva
- diapositiva in immagine
- miniatura forma
- forma in immagine
- miniatura presentazione
- presentazione in immagini
- aggiungi immagine
- aggiungi foto
- Java
- Aspose.Slides
description: "Modernizza l'elaborazione delle immagini delle diapositive sostituendo le API di imaging obsolete con la Modern API Java per un'automazione fluida di PowerPoint e OpenDocument."
---
## **Introduzione**

Storicamente, Aspose Slides ha una dipendenza da java.awt e nell'API pubblica contiene le seguenti classi da lì:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A partire dalla versione 24.4, questa API pubblica è dichiarata deprecata.

Per eliminare le dipendenze da queste classi, abbiamo aggiunto la cosiddetta “Modern API” – cioè l'API da utilizzare al posto di quella deprecata, le cui firme contengono dipendenze da [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) è dichiarata deprecata e il suo supporto è stato rimosso dall'API pubblica di Slides.

Nelle versioni attuali, trattare l'API pubblica che dipende da tipi java.awt come legacy/deprecata. Utilizzare la Modern API per nuovo codice e quando si migra i flussi di lavoro di elaborazione immagini esistenti.

## **API Moderna**

Sono state aggiunte le seguenti classi ed enumerazioni all'API pubblica:

- [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) – rappresenta l'immagine raster o vettoriale.
- [ImageFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/imageformat/) – rappresenta il formato file dell'immagine.
- [Images](https://reference.aspose.com/slides/it/java/com.aspose.slides/images/) – metodi per istanziare e lavorare con l'interfaccia [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/).

Si noti che [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) è disposable e il suo utilizzo dovrebbe essere seguito da una chiamata `dispose()` o da un altro pratico pattern di rilascio.

Usa `getImage` per renderizzare una singola diapositiva o forma. Usa `getImages` per renderizzare più diapositive della presentazione. Usa i metodi di [Images](https://reference.aspose.com/slides/it/java/com.aspose.slides/images/) per caricare immagini, `addImage` con [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) per aggiungerle a una presentazione e `replaceImage` con [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) per aggiornare un’immagine esistente nella presentazione.

Un tipico scenario di utilizzo della nuova API può apparire come segue:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // istanzia un'istanza disposable di IImage dal file su disco.
    IImage image = Images.fromFile("image.png");
    try {
        // crea un'immagine PowerPoint aggiungendo un'istanza di IImage alle immagini della presentazione.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // aggiungi una forma immagine sulla diapositiva #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // ottieni un'istanza di IImage che rappresenta la diapositiva #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
    try {
        // salva l'immagine su disco.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sostituire il vecchio codice con la Modern API**

In generale, sarà necessario sostituire le chiamate che usano [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) e ImageIO con i nuovi metodi che usano [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/).

API legacy/deprecata:
``` java
BufferedImage slideImage = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1920, 1080));
try {
    ImageIO.write(slideImage, "PNG", new File("image.png"));
} catch (IOException e) {
    e.printStackTrace();
}
```
API Moderna:
``` java
IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(1920, 1080));
try {
    slideImage.save("image.png", ImageFormat.Png);
} finally {
    if (slideImage != null) slideImage.dispose();
}
```

### **Ottenere una miniatura di diapositiva**

API legacy/deprecata:

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

API Moderna:

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

### **Ottenere una miniatura di forma**

API legacy/deprecata:

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

API Moderna:

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

### **Ottenere una miniatura di presentazione**

API legacy/deprecata:

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

API Moderna:

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

### **Aggiungere un'immagine a una presentazione**

API legacy/deprecata:

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

API Moderna:

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

## **Metodi deprecati e loro sostituzione nella Modern API**

### **Presentation**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|----------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|----------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|----------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Nessuna sostituzione nella Modern API |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Nessuna sostituzione nella Modern API |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Nessuna sostituzione nella Modern API |

### **Output**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|----------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|----------------------------------|
| public final IPPImage addImage(BufferedImage image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|----------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|----------------------------------|
| public final BufferedImage getTileImage(Color styleColor) | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|----------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |


## **Supporto API per Graphics2D**

I metodi con [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sono dichiarati deprecati e non hanno una sostituzione diretta nella Modern API.

Utilizza i metodi di rendering immagine della Modern API al posto dell'API che renderizza su [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

## **FAQ**

**Perché è stato rimosso [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)?**

Il supporto per [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) è deprecato nell'API pubblica per unificare il lavoro di rendering e immagini, eliminare i legami con dipendenze specifiche della piattaforma e passare a un approccio cross‑platform con [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/). Usa `getImage` o `getImages` invece di renderizzare su [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html).

**Qual è il vantaggio pratico di [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) rispetto a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/iimage/) unifica il lavoro su immagini raster e vettoriali e semplifica il salvataggio in vari formati tramite [ImageFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/imageformat/).

**La Modern API influenzerà le prestazioni nella generazione delle miniature?**

Passare da `getThumbnail` a `getImage` non peggiora gli scenari: i nuovi metodi offrono le stesse capacità di produrre immagini con opzioni e dimensioni, mantenendo il supporto per le opzioni di rendering. Il guadagno o la perdita specifica dipende dallo scenario, ma funzionalmente le sostituzioni sono equivalenti.