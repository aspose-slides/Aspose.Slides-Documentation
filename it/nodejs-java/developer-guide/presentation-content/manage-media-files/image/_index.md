---
title: Ottimizza la gestione delle immagini nelle presentazioni usando JavaScript
linktitle: Gestisci Immagini
type: docs
weight: 10
url: /it/nodejs-java/image/
keywords:
- aggiungi immagine
- aggiungi immagine
- aggiungi bitmap
- sostituisci immagine
- sostituisci immagine
- dal web
- sfondo
- aggiungi PNG
- aggiungi JPG
- aggiungi SVG
- aggiungi EMF
- aggiungi WMF
- aggiungi TIFF
- PowerPoint
- OpenDocument
- presentazione
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "Ottimizza la gestione delle immagini in PowerPoint e OpenDocument con JavaScript e Aspose.Slides per Node.js, migliorando le prestazioni e automatizzando il tuo flusso di lavoro."
---
## **Introduzione**

Le immagini rendono le presentazioni più coinvolgenti e interessanti. In Microsoft PowerPoint, è possibile inserire immagini da un file, da Internet o da altre posizioni nelle diapositive. Allo stesso modo, Aspose.Slides consente di aggiungere immagini alle diapositive nelle proprie presentazioni mediante diverse procedure. 

{{% alert  title="Suggerimento" color="primary" %}} 

Aspose fornisce convertitori gratuiti—[JPEG to PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare rapidamente presentazioni a partire dalle immagini. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Se vuoi aggiungere un'immagine come oggetto di cornice—soprattutto se prevedi di utilizzare le opzioni di formattazione standard per modificarne le dimensioni, aggiungere effetti, ecc.—vedi [Picture Frame](https://docs.aspose.com/slides/it/nodejs-java/picture-frame/).

{{% /alert %}} 

Aspose.Slides supporta operazioni con immagini in questi formati popolari: JPEG, PNG, GIF e altri. 

## **Aggiungere immagini memorizzate localmente alle diapositive**

È possibile aggiungere una o più immagini dal proprio computer a una diapositiva in una presentazione. Questo esempio di codice in JavaScript mostra come aggiungere un'immagine a una diapositiva:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aggiungere immagini dallo stream alle diapositive**

Se l'immagine che desideri aggiungere a una diapositiva non è disponibile sul tuo computer, puoi aggiungere l'immagine direttamente dal web. 

Questo esempio di codice mostra come aggiungere un'immagine dal web a una diapositiva in JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Accede alla prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Carica un file excel nello stream
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Crea un oggetto dati per l'incorporamento
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Aggiunge una forma Ole Object Frame
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // Scrive il file PPTX sul disco
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aggiungere immagini ai master delle diapositive**

Un master della diapositiva è la diapositiva principale che memorizza e controlla le informazioni (tema, layout, ecc.) di tutte le diapositive sottostanti. Pertanto, quando aggiungi un'immagine a un master della diapositiva, quell'immagine appare su ogni diapositiva sotto quel master. 

Questo esempio di codice JavaScript mostra come aggiungere un'immagine a un master della diapositiva:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aggiungere immagini come sfondo della diapositiva**

Potresti decidere di utilizzare un'immagine come sfondo per una diapositiva specifica o per diverse diapositive. In tal caso, consulta *[Impostare le immagini come sfondi per le diapositive](https://docs.aspose.com/slides/it/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Aggiungere SVG alle presentazioni**
È possibile aggiungere o inserire qualsiasi immagine in una presentazione utilizzando il metodo [addPictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) appartenente alla classe [ShapeCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection).

Per creare un oggetto immagine basato su un'immagine SVG, è possibile procedere in questo modo:

1. Creare un oggetto SvgImage da inserire in ImageShapeCollection
2. Creare un oggetto PPImage da ISvgImage
3. Creare un oggetto PictureFrame utilizzando la classe PPImage

Questo esempio di codice mostra come implementare i passaggi precedenti per aggiungere un'immagine SVG a una presentazione:
```javascript
// Istanzia la classe Presentation che rappresenta un file PPTX
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Convertire SVG in un insieme di forme**
La conversione di SVG in un insieme di forme di Aspose.Slides è simile alla funzionalità di PowerPoint utilizzata per lavorare con immagini SVG:

![Menu popup di PowerPoint](img_01_01.png)

La funzionalità è fornita da una delle sovraccariche del metodo [addGroupShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) della classe [ShapeCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection) che accetta un oggetto [SvgImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SvgImage) come primo argomento.

Questo esempio di codice mostra come utilizzare il metodo descritto per convertire un file SVG in un insieme di forme:

```javascript
// Crea una nuova presentazione
var presentation = new aspose.slides.Presentation();
try {
    // Leggi il contenuto del file SVG
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // Crea l'oggetto SvgImage
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Ottieni le dimensioni della diapositiva
    var slideSize = presentation.getSlideSize().getSize();
    // Converti l'immagine SVG in un gruppo di forme ridimensionandola alle dimensioni della diapositiva
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // Salva la presentazione in formato PPTX
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Aggiungere immagini come EMF nelle diapositive**
Aspose.Slides per Node.js tramite Java consente di generare immagini EMF da fogli Excel e aggiungere le immagini come EMF nelle diapositive con Aspose.Cells. 

Questo esempio di codice mostra come eseguire il compito descritto:

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Salva la cartella di lavoro nello stream
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sostituire le immagini nella raccolta di immagini**

Aspose.Slides consente di sostituire le immagini memorizzate nella raccolta di immagini di una presentazione (incluse quelle utilizzate dalle forme delle diapositive). Questa sezione mostra diversi approcci per aggiornare le immagini nella raccolta. L'API fornisce metodi semplici per sostituire un'immagine utilizzando dati raw in byte, un'istanza di [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) o un'altra immagine già presente nella raccolta.

Segui i passaggi seguenti:

1. Caricare il file della presentazione che contiene le immagini utilizzando la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Caricare una nuova immagine da un file in un array di byte.
1. Sostituire l'immagine di destinazione con la nuova immagine utilizzando l'array di byte.
1. Nel secondo approccio, caricare l'immagine in un oggetto [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) e sostituire l'immagine di destinazione con tale oggetto.
1. Nel terzo approccio, sostituire l'immagine di destinazione con un'immagine già presente nella raccolta di immagini della presentazione.
1. Scrivere la presentazione modificata come file PPTX.

```js
// Istanzia la classe Presentation che rappresenta un file di presentazione.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Il primo modo.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Il secondo modo.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Il terzo modo.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Salva la presentazione su un file.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Utilizzando il convertitore GRATUITO Aspose [Text to GIF](https://products.aspose.app/slides/it/text-to-gif), è possibile animare facilmente i testi, creare GIF a partire dai testi, ecc. 

{{% /alert %}}

## **Domande frequenti**

**La risoluzione originale dell'immagine rimane intatta dopo l'inserimento?**

Sì. I pixel originali vengono conservati, ma l'aspetto finale dipende da come l'[immagine](/slides/it/nodejs-java/picture-frame/) viene scalata sulla diapositiva e da eventuali compressioni applicate al salvataggio.

**Qual è il modo migliore per sostituire lo stesso logo su decine di diapositive contemporaneamente?**

Posiziona il logo sul master della diapositiva o su un layout e sostituiscilo nella raccolta di immagini della presentazione: gli aggiornamenti si propagheranno a tutti gli elementi che utilizzano quella risorsa.

**È possibile convertire un SVG inserito in forme modificabili?**

Sì. È possibile convertire un SVG in un gruppo di forme, dopo di che le singole parti diventano modificabili con le proprietà standard delle forme.

**Come posso impostare un'immagine come sfondo per più diapositive contemporaneamente?**

[Assegna l'immagine come sfondo](/slides/it/nodejs-java/presentation-background/) sul master della diapositiva o sul layout pertinente: tutte le diapositive che utilizzano quel master/layout erediteranno lo sfondo.

**Come posso evitare che la presentazione cresca eccessivamente di dimensioni a causa di molte immagini?**

Riutilizza una singola risorsa immagine anziché duplicati, scegli risoluzioni ragionevoli, applica la compressione al salvataggio e mantieni le grafiche ripetute sul master quando opportuno.