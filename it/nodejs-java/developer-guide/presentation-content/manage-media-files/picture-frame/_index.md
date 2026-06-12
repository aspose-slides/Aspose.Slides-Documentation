---
title: Gestire le cornici nelle presentazioni usando JavaScript
linktitle: Cornice immagine
type: docs
weight: 10
url: /it/nodejs-java/picture-frame/
keywords:
- cornice immagine
- aggiungi cornice immagine
- crea cornice immagine
- aggiungi immagine
- crea immagine
- estrai immagine
- immagine raster
- immagine vettoriale
- ritaglia immagine
- area ritagliata
- proprietà StretchOff
- formattazione cornice immagine
- proprietà cornice immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- trasparenza immagine
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Aggiungi cornici alle presentazioni PowerPoint e OpenDocument con Aspose.Slides per Node.js via Java. Snellisci il flusso di lavoro e migliora i design delle diapositive."
---
## **Introduzione**

Una cornice è una forma che contiene un'immagine—è come una foto in una cornice.  

Puoi aggiungere un'immagine a una diapositiva tramite una cornice. In questo modo, puoi formattare l'immagine formattando la cornice.

{{% alert  title="Tip" color="primary" %}} 

Aspose fornisce convertitori gratuiti—[JPEG to PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare presentazioni rapidamente a partire da immagini. 

{{% /alert %}} 

## **Creare una cornice**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Crea un oggetto `PPImage` aggiungendo un'immagine alla [ImagesCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ImageCollection) associata all'oggetto presentazione che verrà usato per riempire la forma.
4. Specifica la larghezza e l'altezza dell'immagine.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PictureFrame) basato sulla larghezza e altezza dell'immagine tramite il metodo `addPictureFrame` esposto dall'oggetto shape associato alla diapositiva di riferimento.
6. Aggiungi una cornice (contenente l'immagine) alla diapositiva.
7. Scrivi la presentazione modificata in un file PPTX.

Questo codice JavaScript mostra come creare una cornice:

```javascript
// Istanzia la classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottiene la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Istanzia la classe Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Aggiunge una cornice immagine con l'altezza e la larghezza equivalenti all'immagine
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Scrive il file PPTX sul disco
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Le cornici consentono di creare rapidamente diapositive basate su immagini. Quando combini la cornice con le opzioni di salvataggio di Aspose.Slides, puoi gestire le operazioni di input/output per convertire le immagini da un formato all'altro.

## **Creare una cornice con scala relativa**

Alterando la scala relativa di un'immagine, puoi creare una cornice più complessa. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Aggiungi un'immagine alla collezione immagini della presentazione.
4. Crea un [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PPImage) aggiungendo un'immagine alla [ImagesCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ImageCollection) associata all'oggetto presentazione che verrà usato per riempire la forma.
5. Specifica la larghezza e l'altezza relative dell'immagine nella cornice.
6. Scrivi la presentazione modificata in un file PPTX.

Questo codice JavaScript mostra come creare una cornice con scala relativa:

```javascript
// Instanzia la classe Presentation che rappresenta il PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottiene la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Instanzia la classe Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Aggiunge una cornice immagine con altezza e larghezza equivalenti all'immagine
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Imposta la scala relativa in larghezza e altezza
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Scrive il file PPTX su disco
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Estrarre immagini raster dalle cornici**

Puoi estrarre immagini raster da oggetti [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PictureFrame) e salvarle in PNG, JPG e altri formati. L'esempio di codice seguente dimostra come estrarre un'immagine dal documento "sample.pptx" e salvarla in formato PNG.

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **Estrarre immagini SVG dalle cornici**

Quando una presentazione contiene grafiche SVG inserite all'interno di forme [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/), Aspose.Slides per Node.js via Java consente di recuperare le immagini vettoriali originali con piena fedeltà. Scorrendo la collezione di forme della diapositiva, è possibile individuare ogni [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/), verificare se il relativo [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) contiene contenuto SVG e quindi salvare quell'immagine su disco o in uno stream nel suo formato SVG nativo.

Il seguente esempio di codice dimostra come estrarre un'immagine SVG da una cornice:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **Ottenere la trasparenza dell'immagine**

Aspose.Slides consente di ottenere l'effetto di trasparenza applicato a un'immagine. Questo codice JavaScript dimostra l'operazione:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **Formattazione della cornice**

Aspose.Slides offre numerose opzioni di formattazione che possono essere applicate a una cornice. Utilizzando queste opzioni, è possibile modificare una cornice affinché soddisfi requisiti specifici.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Crea un [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PPImage) aggiungendo un'immagine alla [ImagesCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ImageCollection) associata all'oggetto presentazione che verrà usato per riempire la forma.
4. Specifica la larghezza e l'altezza dell'immagine.
5. Crea un `PictureFrame` basato sulla larghezza e altezza dell'immagine tramite il metodo [addPictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) esposto dall'oggetto [Shapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection) associato alla diapositiva di riferimento.
6. Aggiungi la cornice (contenente l'immagine) alla diapositiva.
7. Imposta il colore della linea della cornice.
8. Imposta lo spessore della linea della cornice.
9. Ruota la cornice fornendo un valore positivo o negativo.  
   * Un valore positivo ruota l'immagine in senso orario.  
   * Un valore negativo ruota l'immagine in senso antiorario.
10. Aggiungi la cornice (contenente l'immagine) alla diapositiva.
11. Scrivi la presentazione modificata in un file PPTX.

Questo codice JavaScript dimostra il processo di formattazione della cornice:

```javascript
// Istanzia la classe Presentation che rappresenta il PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottiene la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Istanzia la classe Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Aggiunge una cornice immagine con altezza e larghezza equivalenti all'immagine
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Applica alcune formattazioni a PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // Scrive il file PPTX sul disco
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

Aspose ha recentemente sviluppato un [free Collage Maker](https://products.aspose.app/slides/it/collage). Se hai bisogno di [unire JPG/JPEG](https://products.aspose.app/slides/it/collage/jpg) o immagini PNG, [creare griglie da foto](https://products.aspose.app/slides/it/collage/photo-grid), puoi usare questo servizio. 

{{% /alert %}}

## **Aggiungere un'immagine come link**

Per evitare dimensioni eccessive della presentazione, puoi aggiungere immagini (o video) tramite link invece di incorporare i file direttamente nella presentazione. Questo codice JavaScript mostra come aggiungere un'immagine e un video in un segnaposto:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ritagliare l'immagine**

Questo codice JavaScript mostra come ritagliare un'immagine esistente su una diapositiva:

```javascript
var pres = new aspose.slides.Presentation();
// Crea un nuovo oggetto immagine
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Aggiunge una PictureFrame a una diapositiva
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Ritaglia l'immagine (valori percentuali)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Salva il risultato
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Eliminare le aree ritagliate dell'immagine**

Se desideri eliminare le aree ritagliate di un'immagine contenuta in una cornice, puoi utilizzare il metodo [deletePictureCroppedAreas()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . Questo metodo restituisce l'immagine ritagliata o l'immagine originale se il ritaglio non è necessario.

Questo codice JavaScript dimostra l'operazione:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Ottiene la PictureFrame dalla prima diapositiva
    var picFrame = slide.getShapes().get_Item(0);
    // Elimina le aree ritagliate dell'immagine PictureFrame e restituisce l'immagine ritagliata
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Salva il risultato
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

Il metodo [deletePictureCroppedAreas()](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) aggiunge l'immagine ritagliata alla collezione immagini della presentazione. Se l'immagine è utilizzata solo nella [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/) elaborata, questa impostazione può ridurre le dimensioni della presentazione. Altrimenti, il numero di immagini nella presentazione risultante aumenterà.

Questo metodo converte i metafili WMF/EMF in immagini raster PNG durante l'operazione di ritaglio. 

{{% /alert %}}

## **Comprimere le immagini**

Puoi comprimere un'immagine in una presentazione usando il metodo [PictureFillFormat.compressImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) .  
Questo metodo comprime un'immagine riducendo le sue dimensioni in base alla dimensione della forma e alla risoluzione specificata, con l'opzione di eliminare le aree ritagliate.

Regola la dimensione e la risoluzione dell'immagine in modo simile alla funzionalità **Picture Format → Compress Pictures → Resolution** di PowerPoint.

Il seguente esempio JavaScript dimostra come comprimere un'immagine in una presentazione specificando una risoluzione target e, facoltativamente, rimuovendo le aree ritagliate:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Comprimi l'immagine con una risoluzione target di 150 DPI (risoluzione Web) e rimuovi le aree ritagliate.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Verifica il risultato della compressione.
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Oppure usando un altro valore DPI predefinito:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Comprimi l'immagine a 96 DPI (risoluzione per email), rimuovendo le aree ritagliate.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Il metodo converte l'immagine a una risoluzione inferiore in base alla dimensione della forma e al DPI fornito. Le regioni ritagliate possono anche essere eliminate per ottimizzare la dimensione del file.  
Se l'immagine è un metafile (WMF/EMF) o SVG, la compressione non verrà applicata. Inoltre, la qualità JPEG viene preservata o leggermente ridotta in base alla risoluzione, in modo simile a come PowerPoint gestisce i JPEG ad alta risoluzione.

{{% /alert %}}

## **Bloccare il rapporto d'aspetto**

Se desideri che una forma contenente un'immagine mantenga il rapporto d'aspetto anche dopo aver modificato le dimensioni dell'immagine, puoi utilizzare il metodo [setAspectRatioLocked](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) per impostare l'opzione *Lock Aspect Ratio*.

Questo codice JavaScript mostra come bloccare il rapporto d'aspetto di una forma:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // imposta la forma per preservare il rapporto d'aspetto durante il ridimensionamento
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

Questa impostazione *Lock Aspect Ratio* preserva solo il rapporto d'aspetto della forma e non l'immagine contenuta. 

{{% /alert %}}

## **Usare la proprietà StretchOff**

Utilizzando i metodi [setStretchOffsetLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) e [setStretchOffsetBottom](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) della classe [PictureFillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PictureFillFormat), è possibile specificare un rettangolo di riempimento.

Quando viene specificato lo stretching per un'immagine, un rettangolo sorgente viene scalato per adattarsi al rettangolo di riempimento specificato. Ogni bordo del rettangolo di riempimento è definito da un offset percentuale rispetto al corrispondente bordo del riquadro della forma. Una percentuale positiva indica un rientro, mentre una percentuale negativa indica un'estensione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice.
3. Aggiungi un rettangolo `AutoShape`. 
4. Crea un'immagine.
5. Imposta il tipo di riempimento della forma.
6. Imposta la modalità di riempimento immagine della forma.
7. Aggiungi un'immagine impostata per riempire la forma.
8. Specifica gli offset dell'immagine rispetto al corrispondente bordo del riquadro della forma.
9. Scrivi la presentazione modificata in un file PPTX.

Questo codice JavaScript dimostra un processo in cui viene usata la proprietà StretchOff:

```javascript
// Istanzia la classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottiene la prima diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Istanzia la classe ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Aggiunge un AutoShape impostato a Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Imposta il tipo di riempimento della forma
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Imposta la modalità di riempimento immagine della forma
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Imposta l'immagine per riempire la forma
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Specifica gli offset dell'immagine dal corrispondente bordo del riquadro della forma
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Scrive il file PPTX su disco
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Come posso scoprire quali formati immagine sono supportati per PictureFrame?**

Aspose.Slides supporta sia immagini raster (PNG, JPEG, BMP, GIF, ecc.) sia immagini vettoriali (ad esempio SVG) tramite l'oggetto immagine assegnato a un [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/). L'elenco dei formati supportati generalmente si sovrappone alle capacità del motore di conversione di diapositive e immagini.

**In che modo l'aggiunta di decine di immagini di grandi dimensioni influisce su dimensioni e prestazioni del PPTX?**

Incorporare immagini di grandi dimensioni aumenta la dimensione del file e l'uso di memoria; collegare le immagini consente di mantenere più piccolo il file della presentazione, ma richiede che i file esterni rimangano accessibili. Aspose.Slides offre la possibilità di aggiungere immagini tramite link per ridurre la dimensione del file.

**Come posso bloccare un oggetto immagine per evitare spostamenti o ridimensionamenti accidentali?**

Utilizza i [shape locks](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) per una [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/) (ad esempio, disabilita lo spostamento o il ridimensionamento). Il meccanismo di blocco è supportato per vari tipi di forme, incluse le [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/).

**La fedeltà vettoriale SVG è preservata quando si esporta una presentazione in PDF/immagini?**

Aspose.Slides consente di estrarre un SVG da una [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/) come vettore originale. Quando si [esporta in PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/) o in [formati raster](/slides/it/nodejs-java/convert-powerpoint-to-png/), il risultato può essere rasterizzato a seconda delle impostazioni di esportazione; il fatto che l'SVG originale sia memorizzato come vettore è confermato dal comportamento di estrazione.