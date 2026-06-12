---
title: "Migliora l'elaborazione delle immagini con la Modern API"
linktitle: "API moderna"
type: docs
weight: 237
url: /it/nodejs-java/modern-api/
keywords:
  - "API moderna"
  - "disegno"
  - "miniatura diapositiva"
  - "diapositiva in immagine"
  - "miniatura forma"
  - "forma in immagine"
  - "miniatura presentazione"
  - "presentazione in immagini"
  - "aggiungi immagine"
  - "aggiungi foto"
  - "Node.js"
  - "JavaScript"
  - "Aspose.Slides"
description: "Modernizza l'elaborazione delle immagini delle diapositive sostituendo le API di imaging deprecate con la Modern API JavaScript per un'automazione senza soluzione di continuità di PowerPoint e OpenDocument."
---
## **Introduzione**

Storicamente, Aspose Slides ha una dipendenza da java.awt e ha nell'API pubblica le seguenti classi da lì:
- [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html)
- [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)

A partire dalla versione 24.4, questa API pubblica è dichiarata deprecata.

Per eliminare le dipendenze da queste classi, abbiamo aggiunto quella che viene chiamata "Modern API" – cioè l'API che dovrebbe essere utilizzata al posto di quella deprecata, le cui firme contengono dipendenze da [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html). [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) è dichiarato deprecato e il suo supporto è rimosso dall'API pubblica di Slides.

Nelle versioni attuali, trattate l'API pubblica che dipende dai tipi java.awt come legacy/deprecata. Utilizzate la Modern API per nuovo codice e quando migrate i flussi di lavoro di elaborazione delle immagini esistenti.

## **API moderna**

Aggiunte le seguenti classi ed enum all'API pubblica:

- [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) - rappresenta l'immagine raster o vettoriale.
- [ImageFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imageformat/) - rappresenta il formato file dell'immagine.
- [Images](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/images/) - metodi per istanziare e lavorare con la classe [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/).

Nota che [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) è disposable e il suo utilizzo dovrebbe essere seguito da una chiamata `dispose()` o da un altro pattern di rilascio comodo.

Usate `getImage` per renderizzare una singola diapositiva o forma. Usate `getImages` per renderizzare più diapositive della presentazione. Usate i metodi di [Images](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/images/) per caricare immagini, `addImage` con [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) per aggiungerle a una presentazione, e `replaceImage` con [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) per aggiornare un'immagine esistente della presentazione.

Uno scenario tipico di utilizzo della nuova API può apparire come segue:

``` javascript
var pres = new aspose.slides.Presentation();
try {
    var ppImage;
    // istanziare un'istanza disposable di IImage dal file sul disco.
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        // creare un'immagine PowerPoint aggiungendo un'istanza di IImage alle immagini della presentazione.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // aggiungere una forma immagine sulla diapositiva #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
    // ottenere un'istanza di IImage che rappresenta la diapositiva #1.
    var slideImage = pres.getSlides().get_Item(0).getImage(size);
    try {
        // salvare l'immagine sul disco.
        slideImage.save("slide1.jpeg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sostituire il vecchio codice con l'API moderna**

In generale, dovrete sostituire le chiamate che usano [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) e [ImageIO](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html) con i nuovi metodi che usano [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/).

API legacy/deprecata:
``` javascript
var imageio = java.import("javax.imageio.ImageIO");
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getThumbnail(size);
var file = java.newInstanceSync("java.io.File", "image.png");
imageio.write(slideImage, "PNG", file);
```
API moderna:
``` javascript
var size = java.newInstanceSync("java.awt.Dimension", 1920, 1080);
var slideImage = pres.getSlides().get_Item(0).getImage(size);
slideImage.save("image.png", aspose.slides.ImageFormat.Png);
slideImage.dispose();
```

### **Ottenere una miniatura della diapositiva**

API legacy/deprecata:

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

API moderna:

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

### **Ottenere una miniatura della forma**

API legacy/deprecata:

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

API moderna:

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

### **Ottenere una miniatura della presentazione**

API legacy/deprecata:

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

API moderna:

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

### **Aggiungere un'immagine a una presentazione**

API legacy/deprecata:

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

API moderna:

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

## **Metodi deprecati e loro sostituzione nella Modern API**

### **Presentation**
| Firma del metodo                               | Firma del metodo di sostituzione                             |
|-----------------------------------------------|---------------------------------------------------------|
| public final BufferedImage[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options)                   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY)   |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, int[] slides, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Dimension imageSize) |
| public final BufferedImage[] getThumbnails(IRenderingOptions options, Dimension imageSize) | public final IImage[] getImages(IRenderingOptions options, Dimension imageSize) |

### **Shape**
| Firma del metodo                                                      | Firma del metodo di sostituzione                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public final BufferedImage getThumbnail()                                        | public final IImage getImage()                                                           |
| public final BufferedImage getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Firma del metodo                                                      | Firma del metodo di sostituzione                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public final BufferedImage getThumbnail() | public final IImage getImage() |
| public final BufferedImage getThumbnail(float scaleX, float scaleY) | public final IImage getImage(float scaleX, float scaleY) |
| public final BufferedImage getThumbnail(IRenderingOptions options) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, float scaleX, float scaleY) | public final IImage getImage(IRenderingOptions options) |
| public final BufferedImage getThumbnail(IRenderingOptions options, Dimension imageSize) | public final IImage getImage(IRenderingOptions options, Dimension imageSize) |
| public final BufferedImage getThumbnail(ITiffOptions options) | public final IImage getImage(ITiffOptions options) |
| public final BufferedImage getThumbnail(Dimension imageSize) | public final IImage getImage(Dimension imageSize) |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics) | Nessuna sostituzione Modern API  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY) | Nessuna sostituzione Modern API  |
| public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize) | Nessuna sostituzione Modern API  |

### **Output**
| Firma del metodo                                                | Firma del metodo di sostituzione                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public final IOutputFile add(String path, BufferedImage image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Firma del metodo                          | Firma del metodo di sostituzione               |
|-------------------------------------------|--------------------------------------------|
| public final PPImage addImage(BufferedImage image) | public final PPImage addImage(IImage image) |

### **PPImage**
| Firma del metodo                     | Firma del metodo di sostituzione   |
|--------------------------------------|-----------------------------------------|
| public final BufferedImage getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Firma del metodo                                          | Firma del metodo di sostituzione                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final BufferedImage getTileImage(Color styleColor)   | public final IImage getTile(Color styleColor) |
| public final BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTile(Color background, Color foreground) |

### **PatternFormatEffectiveData**
| Firma del metodo                                          | Firma del metodo di sostituzione                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| public final java.awt.image.BufferedImage getTileImage(Color background, Color foreground) | public final IImage getTileIImage(Color background, Color foreground) |

## **Supporto API per Graphics2D**

I metodi con [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) sono dichiarati deprecati e non hanno una sostituzione diretta nella Modern API.

Usate i metodi di rendering immagine della Modern API invece dell'API che renderizza su [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html):

[Slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Graphics2D graphics, Dimension renderingSize)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#renderToGraphics-aspose.slides.IRenderingOptions-java.awt.Graphics2D-java.awt.Dimension-)

# **FAQ**

**Qual è il vantaggio pratico di [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) rispetto a [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html)?**

[IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) unifica il lavoro sia con immagini raster sia con immagini vettoriali e semplifica il salvataggio in vari formati tramite [ImageFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imageformat/).

**La Modern API influenzerà le prestazioni nella generazione delle miniature?**

Passare da `getThumbnail` a `getImage` non peggiora gli scenari: i nuovi metodi forniscono le stesse capacità di produrre immagini con opzioni e dimensioni, mantenendo il supporto per le opzioni di rendering. Il guadagno o la perdita specifica dipende dallo scenario, ma funzionalmente le sostituzioni sono equivalenti.