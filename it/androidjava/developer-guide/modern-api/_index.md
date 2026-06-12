---
title: "Migliora l'elaborazione delle immagini con la Modern API"
linktitle: "API Moderna"
type: docs
weight: 237
url: /it/androidjava/modern-api/
keywords:
- android.graphics
- API moderna
- disegno
- miniatura di diapositiva
- diapositiva in immagine
- miniatura di forma
- forma in immagine
- miniatura di presentazione
- presentazione in immagini
- aggiungi immagine
- aggiungi foto
- Android
- Java
- Aspose.Slides
description: "Modernizza l'elaborazione delle immagini delle diapositive sostituendo le API di imaging obsolete con la Modern API Java per un'automazione fluida di PowerPoint e OpenDocument."
---
## **Introduzione**

Storicamente, Aspose Slides ha una dipendenza da android.graphics e ha nell'API pubblica le seguenti classi da lì:
- [Canvas](https://developer.android.com/reference/android/graphics/Canvas)
- [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)

A partire dalla versione 24.4, questa API pubblica è dichiarata obsoleta.

Per eliminare le dipendenze da queste classi, abbiamo aggiunto la cosiddetta “Modern API” – ovvero l'API da utilizzare al posto di quella deprecata, le cui firme contengono dipendenze da [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap). [Canvas](https://developer.android.com/reference/android/graphics/Canvas) è dichiarato obsoleto e il suo supporto è stato rimosso dall'API pubblica di Slides.

Nelle versioni correnti, trattate l'API pubblica che dipende da tipi android.graphics come legacy/obsoleta. Utilizzate la Modern API per nuovo codice e quando migrate i flussi di elaborazione delle immagini esistenti.

## **API Modern**

Aggiunte le seguenti classi ed enum all'API pubblica:

- [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) – rappresenta l'immagine raster o vettoriale.  
- [ImageFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imageformat/) – rappresenta il formato file dell'immagine.  
- [Images](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/images/) – metodi per istanziare e lavorare con l'interfaccia [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/).

Si noti che [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) è disposable e il suo utilizzo deve essere seguito da una chiamata a `dispose()` o da un altro pattern di rilascio conveniente.

Usate `getImage` per renderizzare una singola diapositiva o forma. Usate `getImages` per renderizzare più diapositive della presentazione. Usate i metodi di [Images](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/images/) per caricare immagini, `addImage` con [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) per aggiungerle a una presentazione, e `replaceImage` con [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) per aggiornare un'immagine esistente della presentazione.

Uno scenario tipico di utilizzo della nuova API può apparire come segue:

``` java
Presentation pres = new Presentation();
try {
    IPPImage ppImage;
    // istanziare un'istanza disposable di IImage dal file su disco.
    IImage image = Images.fromFile("image.png");
    try {
        // creare un'immagine PowerPoint aggiungendo un'istanza di IImage alle immagini della presentazione.
        ppImage = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // aggiungere una forma immagine alla diapositiva #1
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // ottenere un'istanza di IImage che rappresenta la diapositiva #1.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Size(1920, 1080));
    try {
        // salvare l'immagine su disco.
        slideImage.save("slide1.jpeg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sostituire il vecchio codice con l'API Modern**

In generale, dovrete sostituire le chiamate che usano [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap) con i nuovi metodi che usano [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/).

Legacy/API obsoleta:
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
API Modern:
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

### **Ottenere una miniatura di una diapositiva**

Legacy/API obsoleta:

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

API Modern:

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

### **Ottenere una miniatura di una forma**

Legacy/API obsoleta:

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

API Modern:

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

### **Ottenere una miniatura di una presentazione**

Legacy/API obsoleta:

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

API Modern:

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

### **Aggiungere un'immagine a una presentazione**

Legacy/API obsoleta:

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

API Modern:

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

## **Metodi obsoleti e loro sostituzione nella API Modern**

### **Presentation**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
| public final Bitmap[] getThumbnails(IRenderingOptions options) | public final IImage[] getImages(IRenderingOptions options) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, float scaleX, float scaleY) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides) | public final IImage[] getImages(IRenderingOptions options, int[] slides) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | public final IImage[] getImages(IRenderingOptions options, int[] slides, Size imageSize) |
| public final Bitmap[] getThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | public final IImage[] getImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY) |

### **Shape**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
| public final Bitmap getThumbnail() | public final IImage getImage() |
| public final Bitmap getThumbnail(int bounds, float scaleX, float scaleY) | public final IImage getImage(int bounds, float scaleX, float scaleY) |

### **Slide**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
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
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
| public final IOutputFile add(String path, Bitmap image) | public final IOutputFile add(String path, IImage image) |

### **ImageCollection**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
| public final IPPImage addImage(Bitmap image) | public final IPPImage addImage(IImage image) |

### **PPImage**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
| public final Bitmap getSystemImage() | public final IImage getImage() |

### **PatternFormat**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
| public final Bitmap getTileImage(Integer styleColor) | public final IImage getTile(Integer styleColor) |
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTile(Integer background, Integer foreground) |

### **PatternFormatEffectiveData**
| Firma del metodo | Firma del metodo di sostituzione |
|------------------|-----------------------------------|
| public final Bitmap getTileImage(Integer background, Integer foreground) | public final IImage getTileIImage(Integer background, Integer foreground) |

## **Supporto API per Canvas**

I metodi con [Canvas](https://developer.android.com/reference/android/graphics/Canvas) sono dichiarati obsoleti e non hanno una sostituzione diretta nella Modern API.

Utilizzate i metodi di rendering immagine della Modern API al posto dell'API che renderizza su [Canvas](https://developer.android.com/reference/android/graphics/Canvas):

[Slide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slide/)

- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-float-float-)
- [public final void renderToGraphics(IRenderingOptions options, Canvas graphics, Size renderingSize)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slide/#renderToGraphics-com.aspose.slides.IRenderingOptions-android.graphics.Canvas-com.aspose.slides.android.Size-)

## **FAQ**

**Perché è stato rimosso android.graphics.Canvas?**

Il supporto per [Canvas](https://developer.android.com/reference/android/graphics/Canvas) è deprecato nell'API pubblica per unificare il lavoro con il rendering e le immagini, eliminare i legami con dipendenze specifiche della piattaforma e passare a un approccio cross‑platform con [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/). Utilizzate `getImage` o `getImages` invece del rendering su [Canvas](https://developer.android.com/reference/android/graphics/Canvas).

**Qual è il vantaggio pratico di [IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) rispetto a [Bitmap](https://developer.android.com/reference/android/graphics/Bitmap)?**

[IImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iimage/) unifica la gestione di immagini raster e vettoriali e semplifica il salvataggio in vari formati tramite [ImageFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imageformat/).

**La Modern API influenzerà le prestazioni nella generazione delle miniature?**

Il passaggio da `getThumbnail` a `getImage` non peggiora gli scenari: i nuovi metodi forniscono le stesse capacità di produrre immagini con opzioni e dimensioni, mantenendo il supporto per le opzioni di rendering. Il guadagno o la perdita specifica dipende dallo scenario, ma funzionalmente le sostituzioni sono equivalenti.