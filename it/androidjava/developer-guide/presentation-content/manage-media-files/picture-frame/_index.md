---
title: Gestisci i Frame Immagine nelle Presentazioni su Android
linktitle: Frame Immagine
type: docs
weight: 10
url: /it/androidjava/picture-frame/
keywords:
- frame immagine
- aggiungi frame immagine
- crea frame immagine
- aggiungi immagine
- crea immagine
- estrai immagine
- immagine raster
- immagine vettoriale
- ritaglia immagine
- area ritagliata
- proprietà StretchOff
- formattazione del frame immagine
- proprietà del frame immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- trasparenza immagine
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Aggiungi frame immagine a presentazioni PowerPoint e OpenDocument con Aspose.Slides per Android via Java. Snellisci il tuo flusso di lavoro e migliora il design delle diapositive."
---
## **Introduzione**

Un frame immagine è una forma che contiene un'immagine—è come un'immagine in una cornice. 

È possibile aggiungere un'immagine a una diapositiva tramite un frame immagine. In questo modo, è possibile formattare l'immagine formattando il frame immagine.

{{% alert  title="Tip" color="primary" %}} 

Aspose fornisce convertitori gratuiti—[JPEG to PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare presentazioni rapidamente a partire da immagini. 

{{% /alert %}} 

## **Crea un Frame immagine**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Crea un oggetto [IPPImage]() aggiungendo un'immagine alla [IImagescollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IImageCollection) associata all'oggetto presentazione che verrà usato per riempire la forma.
4. Specifica la larghezza e l'altezza dell'immagine.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/PictureFrame) basato sulla larghezza e altezza dell'immagine tramite il metodo `AddPictureFrame` esposto dall'oggetto forma associato alla diapositiva di riferimento.
6. Aggiungi un frame immagine (contenente l'immagine) alla diapositiva.
7. Salva la presentazione modificata come file PPTX.

Questo codice Java mostra come creare un frame immagine:

```java
// Instanzia la classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Recupera la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanzia la classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Aggiunge un frame immagine con l'altezza e la larghezza equivalenti dell'immagine
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Scrive il file PPTX su disco
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Crea un Frame immagine con Scala Relativa**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Aggiungi un'immagine alla collezione di immagini della presentazione.
4. Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPPImage) aggiungendo un'immagine alla [IImagescollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IImageCollection) associata all'oggetto presentazione che verrà usato per riempire la forma.
5. Specifica la larghezza e l'altezza relative dell'immagine nel frame immagine.
6. Salva la presentazione modificata come file PPTX.

Questo codice Java mostra come creare un frame immagine con scala relativa:

```java
// Istanzia la classe Presentation che rappresenta il PPTX
Presentation pres = new Presentation();
try {
    // Recupera la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Istanzia la classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Aggiunge un Picture Frame con altezza e larghezza equivalenti dell'immagine
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Imposta larghezza e altezza della scala relativa
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Scrive il file PPTX su disco
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Estrai Immagini Raster da Frame Immagine**

È possibile estrarre immagini raster da oggetti [PictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/PictureFrame) e salvarle in PNG, JPG e altri formati. L'esempio di codice seguente dimostra come estrarre un'immagine dal documento "sample.pptx" e salvarla in formato PNG.

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Estrai Immagini SVG da Frame Immagine**

Quando una presentazione contiene grafiche SVG posizionate all'interno di forme [PictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pictureframe/), Aspose.Slides per Android tramite Java consente di recuperare le immagini vettoriali originali con piena fedeltà. Attraversando la collezione di forme della diapositiva, è possibile identificare ogni [PictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pictureframe/), verificare se l'[IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ippimage/) sottostante contiene contenuto SVG e quindi salvare quell'immagine su disco o in uno stream nel suo formato SVG nativo.

Il seguente esempio di codice dimostra come estrarre un'immagine SVG da un frame immagine:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Ottieni Trasparenza di un'Immagine**

Aspose.Slides consente di ottenere l'effetto di trasparenza applicato a un'immagine. Questo codice Java dimostra l'operazione:

```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **Ottieni Luminosità e Contrasto di un'Immagine**

Aspose.Slides consente di ottenere l'effetto di luminosità e contrasto applicato a un'immagine. L'interfaccia [ILuminance](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iluminance/) rappresenta questo effetto di trasformazione dell'immagine.

Questo codice Java dimostra come ottenere le impostazioni di luminosità e contrasto da un frame immagine:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Formattazione del Frame Immagine**

Aspose.Slides fornisce numerose opzioni di formattazione che possono essere applicate a un frame immagine. Utilizzando queste opzioni, è possibile modificare un frame immagine per soddisfare requisiti specifici.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPPImage) aggiungendo un'immagine alla [IImagescollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IImageCollection) associata all'oggetto presentazione che verrà usato per riempire la forma.
4. Specifica la larghezza e l'altezza dell'immagine.
5. Crea un `PictureFrame` basato sulla larghezza e altezza dell'immagine tramite il metodo [AddPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) esposto dall'oggetto [IShapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection) associato alla diapositiva di riferimento.
6. Aggiungi il frame immagine (contenente l'immagine) alla diapositiva.
7. Imposta il colore del bordo del frame immagine.
8. Imposta lo spessore del bordo del frame immagine.
9. Ruota il frame immagine assegnandogli un valore positivo o negativo.
   * Un valore positivo ruota l'immagine in senso orario. 
   * Un valore negativo ruota l'immagine in senso antiorario.
10. Aggiungi il frame immagine (contenente l'immagine) alla diapositiva.
11. Salva la presentazione modificata come file PPTX.

Questo codice Java dimostra il processo di formattazione del frame immagine:

```java
// Instanzia la classe Presentation che rappresenta il PPTX
Presentation pres = new Presentation();
try {
    // Recupera la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanzia la classe Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Aggiunge un Picture Frame con altezza e larghezza equivalenti dell'immagine
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Applica qualche formattazione a PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Scrive il file PPTX su disco
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Aspose ha recentemente sviluppato un [free Collage Maker](https://products.aspose.app/slides/it/collage). Se hai bisogno di [unire immagini JPG/JPEG](https://products.aspose.app/slides/it/collage/jpg) o PNG, o di [creare griglie da foto](https://products.aspose.app/slides/it/collage/photo-grid), puoi utilizzare questo servizio. 

{{% /alert %}}

## **Aggiungi un'Immagine come Collegamento**

Per evitare dimensioni elevate della presentazione, è possibile aggiungere immagini (o video) tramite collegamenti anziché incorporare i file direttamente nelle presentazioni. Questo codice Java mostra come aggiungere un'immagine e un video in un segnaposto:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ritaglia Immagini**

Questo codice Java mostra come ritagliare un'immagine esistente su una diapositiva:

```java
Presentation pres = new Presentation();
// Crea un nuovo oggetto immagine
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Aggiunge un PictureFrame a una diapositiva
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Ritaglia l'immagine (valori percentuali)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Salva il risultato
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Elimina Aree Ritagliate di un Frame**

Se desideri eliminare le aree ritagliate di un'immagine contenuta in un frame, è possibile utilizzare il metodo [deletePictureCroppedAreas()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Questo metodo restituisce l'immagine ritagliata o l'immagine originale se il ritaglio non è necessario.

Questo codice Java dimostra l'operazione:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ottiene il PictureFrame dalla prima diapositiva
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Elimina le aree ritagliate dell'immagine del PictureFrame e restituisce l'immagine ritagliata
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Salva il risultato
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Il metodo [deletePictureCroppedAreas()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) aggiunge l'immagine ritagliata alla collezione di immagini della presentazione. Se l'immagine è utilizzata solo nel [PictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pictureframe/) elaborato, questa impostazione può ridurre le dimensioni della presentazione. Altrimenti, il numero di immagini nella presentazione risultante aumenterà.

Questo metodo converte i metafile WMF/EMF in immagini PNG raster durante l'operazione di ritaglio. 

{{% /alert %}}

## **Comprimi Immagini**

È possibile comprimere un'immagine in una presentazione utilizzando il metodo [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) .
Questo metodo comprime un'immagine riducendo le sue dimensioni in base alle dimensioni della forma e alla risoluzione specificata, con l'opzione di eliminare le aree ritagliate.

Regola le dimensioni e la risoluzione dell'immagine in modo simile alla funzione **Formato immagine > Comprimi immagini > Risoluzione** di PowerPoint.

I seguenti esempi Java dimostrano come comprimere un'immagine in una presentazione specificando una risoluzione target e opzionalmente rimuovendo le aree ritagliate:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Comprimi l'immagine con una risoluzione target di 150 DPI (risoluzione Web) ed elimina le aree ritagliate.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Verifica il risultato della compressione.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O utilizzando direttamente un valore DPI personalizzato:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Comprimi l'immagine a 150 DPI (risoluzione web), rimuovendo le aree ritagliate.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Il metodo converte l'immagine a una risoluzione inferiore in base alle dimensioni della forma e al DPI fornito. Le regioni ritagliate possono anche essere eliminate per ottimizzare le dimensioni del file.  
Se l'immagine è un metafile (WMF/EMF) o SVG, la compressione non verrà applicata. Inoltre, la qualità JPEG viene mantenuta o leggermente ridotta in base alla risoluzione, similmente a quanto fa PowerPoint con i JPEG ad alta risoluzione.

{{% /alert %}}

## **Blocca Rapporto d'Aspetto**

Se vuoi che una forma contenente un'immagine mantenga il suo rapporto d'aspetto anche dopo aver modificato le dimensioni dell'immagine, puoi utilizzare il metodo [setAspectRatioLocked](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) per impostare l'impostazione *Lock Aspect Ratio*.

Questo codice Java mostra come bloccare il rapporto d'aspetto di una forma:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // imposta la forma affinché preservi il rapporto d'aspetto al ridimensionamento
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Questa impostazione *Lock Aspect Ratio* preserva solo il rapporto d'aspetto della forma e non l'immagine contenuta.

{{% /alert %}}

## **Utilizza la Proprietà StretchOff**

Utilizzando le proprietà [StretchOffsetLeft](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) e [StretchOffsetBottom](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) dell'interfaccia [IPictureFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPictureFillFormat) e della classe [PictureFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPictureFillFormat), è possibile specificare un rettangolo di riempimento.

Quando lo stretching è specificato per un'immagine, un rettangolo sorgente viene scalato per adattarsi al rettangolo di riempimento specificato. Ogni lato del rettangolo di riempimento è definito da un offset percentuale dal corrispondente lato della bounding box della forma. Una percentuale positiva indica un rientro mentre una percentuale negativa indica un'espansione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice.
3. Aggiungi un rettangolo `AutoShape`. 
4. Crea un'immagine.
5. Imposta il tipo di riempimento della forma.
6. Imposta la modalità di riempimento immagine della forma.
7. Aggiungi un'immagine impostata per riempire la forma.
8. Specifica gli offset dell'immagine dal corrispondente bordo della bounding box della forma
9. Salva la presentazione modificata come file PPTX.

Questo codice Java dimostra un processo in cui viene utilizzata la proprietà StretchOff:

```java
// Instanzia la classe Presentation che rappresenta un file PPTX
Presentation pres = new Presentation();
try {
    // Recupera la prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Instanzia la classe ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Aggiunge un AutoShape impostato su Rettangolo
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Imposta il tipo di riempimento della forma
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Imposta la modalità di riempimento immagine della forma
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Imposta l'immagine per riempire la forma
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Specifica gli offset dell'immagine dal bordo corrispondente della bounding box della forma
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //Scrive il file PPTX su disco
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Come posso scoprire quali formati immagine sono supportati per PictureFrame?**

Aspose.Slides supporta sia immagini raster (PNG, JPEG, BMP, GIF, ecc.) sia immagini vettoriali (ad esempio SVG) tramite l'oggetto immagine assegnato a un [PictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pictureframe/). L'elenco dei formati supportati si sovrappone generalmente alle capacità del motore di conversione di diapositive e immagini.

**Come influirà l'aggiunta di decine di immagini grandi sulle dimensioni e sulle prestazioni di un PPTX?**

Incorporare immagini di grandi dimensioni aumenta la dimensione del file e il consumo di memoria; collegare le immagini aiuta a mantenere ridotte le dimensioni della presentazione, ma richiede che i file esterni rimangano accessibili. Aspose.Slides offre la possibilità di aggiungere immagini tramite collegamento per ridurre le dimensioni del file.

**Come posso bloccare un oggetto immagine per evitare spostamenti/ridimensionamenti accidentali?**

Utilizza i [blocchi forma](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) per un [PictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pictureframe/) (ad esempio, disabilita lo spostamento o il ridimensionamento). Il meccanismo di blocco è supportato per vari tipi di forma, inclusi i [PictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pictureframe/).

**La fedeltà vettoriale SVG è preservata durante l'esportazione di una presentazione in PDF/immagini?**

Aspose.Slides consente di estrarre un SVG da un [PictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pictureframe/) come vettore originale. Quando si [esporta in PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/) o in [formati raster](/slides/it/androidjava/convert-powerpoint-to-png/), il risultato può essere rasterizzato a seconda delle impostazioni di esportazione; il fatto che l'SVG originale sia memorizzato come vettore è confermato dal comportamento di estrazione.