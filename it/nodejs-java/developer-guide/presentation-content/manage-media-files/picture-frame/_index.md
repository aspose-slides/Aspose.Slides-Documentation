---
title: Gestire i frame immagine nelle presentazioni usando JavaScript
linktitle: Frame immagine
type: docs
weight: 10
url: /it/nodejs-java/picture-frame/
keywords:
- frame immagine
- aggiungere frame immagine
- creare frame immagine
- immagine incorporata
- immagine collegata
- estrarre immagine
- immagine raster
- immagine SVG
- ritagliare immagine
- eliminare aree ritagliate
- comprimere immagine
- Offset di allungamento
- formattazione frame immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea, formatta, collega, ritaglia, estrae e comprime i frame immagine nelle presentazioni con Aspose.Slides per Node.js tramite Java."
---
## **Panoramica**

Un frame immagine è una forma slide che visualizza un’immagine. In Aspose.Slides, la risorsa immagine e la forma che la visualizza sono oggetti separati: una [Presentazione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) possiede le risorse immagine incorporate attraverso la sua [ImageCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagecollection/), mentre un [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/) controlla la posizione, le dimensioni, la formattazione della linea, la rotazione, il ritaglio, gli effetti immagine e altre impostazioni a livello di frame.

Questa separazione è utile quando la stessa immagine viene mostrata più di una volta. Aggiungi l’immagine alla presentazione una sola volta, conserva il [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) restituito e utilizza quella risorsa immagine quando crei i frame immagine.

I frame immagine possono contenere immagini raster come PNG o JPEG e immagini vettoriali SVG. Possono inoltre riferirsi a immagini collegate invece di memorizzare i byte dell’immagine nella presentazione. La scelta influisce sulla portabilità, sulla dimensione del file, sull’estrazione e sul comportamento di esportazione, quindi è utile decidere come l’immagine dovrebbe essere memorizzata prima di applicare formattazioni o ottimizzazioni.

## **Aggiungere e formattare un’immagine incorporata**

Per un’immagine incorporata, aggiungi i dati immagine alla presentazione e crea un frame immagine con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). L’immagine diventa parte del pacchetto di presentazione, quindi la presentazione rimane autonoma quando viene spostata su un altro computer.

L’esempio seguente aggiunge un’immagine PNG, crea un frame alle dimensioni native dell’immagine e applica la formattazione della linea e la rotazione:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il frame immagine controlla la geometria visualizzata; modificare le dimensioni del frame non modifica le dimensioni in pixel originarie memorizzate nella risorsa immagine incorporata. Questa distinzione diventa importante quando si ritaglia o si comprime un’immagine in seguito.

## **Utilizzare la scala relativa**

[PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/) espone la scalatura relativa di larghezza e altezza per il frame attraverso [setRelativeScaleWidth](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) e [setRelativeScaleHeight](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Un valore di `1.0` corrisponde al 100 % della dimensione originale dell’immagine. La scala relativa è utile quando un flusso di lavoro deve preservare una relazione con la dimensione dell’immagine di origine invece di calcolare manualmente le dimensioni finali.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La scala relativa modifica le impostazioni di scala del frame; non ricampiona né comprime l’immagine incorporata.

## **Immagini incorporate e collegate**

Un’immagine incorporata memorizza i dati immagine all’interno della presentazione ed è quindi la scelta più sicura per la portabilità e il rendering prevedibile. Un’immagine collegata memorizza un percorso esterno tramite il metodo [Picture.setLinkPathLong](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) anziché incorporare i dati immagine nello stesso modo.

Le immagini collegate possono ridurre la quantità di dati immagine memorizzati nel PPTX, ma introducono una dipendenza esterna. Il file collegato deve rimanere accessibile all’applicazione che apre o visualizza la presentazione. Se il percorso cambia, il file viene spostato o la risorsa non è disponibile, l’immagine collegata potrebbe non essere visualizzata come previsto. Per presentazioni che devono essere inviate via e‑mail, archiviate o rese in ambienti isolati, le immagini incorporate sono di solito più affidabili.

### **Aggiungere un’immagine collegata**

L’esempio seguente crea un frame immagine e lo punta a un file immagine locale. Si occupa solo del collegamento dell’immagine; il collegamento video è un flusso di lavoro multimediale separato e non è mescolato in questo esempio.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Usa i collegamenti quando la gestione dei file esterni è intenzionale. Non usarli semplicemente come sostituto della compressione: un PPTX piccolo con dipendenze immagine interrotte è solitamente meno utile di una presentazione più grande e autonoma.

## **Estrarre immagini dai frame immagine**

Prima di estrarre un’immagine da una presentazione esistente, verifica che una forma sia effettivamente un [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/) e che contenga un’immagine incorporata. I frame immagine collegati potrebbero non contenere i byte immagine che possono essere estratti nello stesso modo.

### **Estrarre un’immagine raster**

L’API immagine moderna utilizza direttamente [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/). L’esempio seguente trova la prima immagine raster incorporata su una slide e la salva come PNG:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Il salvataggio tramite [IImage.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/#save) converte l’immagine estratta nel formato di output richiesto. Se hai bisogno dei byte codificati memorizzati nella presentazione anziché di un file raster convertito, usa i dati binari della risorsa immagine.

### **Estrarre un’immagine SVG**

Per un’immagine SVG, il [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) espone un oggetto [SvgImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgimage/). Questo ti consente di recuperare i dati SVG direttamente invece di rasterizzare prima l’immagine.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

Mantenere il contenuto SVG come SVG preserva la sorgente vettoriale all’interno della presentazione. Le esportazioni raster come PNG o JPEG richiedono necessariamente di renderizzare quel contenuto vettoriale in pixel. L’esportazione della slide in PDF o SVG è anch’essa un’operazione di rendering, quindi la grafica esportata non deve essere trattata come una copia byte‑per‑byte dell’SVG originale incorporato; usa i dati di [SvgImage.getSvgData](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgimage/#getSvgData--) quando è necessario la risorsa vettoriale originale.

## **Ritagliare un’immagine**

Il ritaglio modifica quale parte di un’immagine è visibile all’interno del frame. I valori di ritaglio su [PictureFillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/) sono percentuali delle dimensioni dell’immagine di origine. Il ritaglio non elimina inizialmente i pixel nascosti dall’immagine incorporata; cambia solo la regione visibile.

L’esempio seguente trova un frame immagine in modo sicuro e applica i valori di ritaglio:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Poiché i dati immagine nascosti sono ancora presenti, il ritaglio può essere modificato in seguito senza perdere i pixel originali. Se la dimensione del file è più importante della reversibilità, le regioni ritagliate possono essere rimosse fisicamente come descritto nella sezione successiva.

## **Rimuovere i dati immagine ritagliati**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) rimuove i dati immagine al di fuori del rettangolo di ritaglio corrente e restituisce la risorsa immagine risultante. Questo può ridurre la dimensione del file, ma è un’ottimizzazione distruttiva: dopo il salvataggio della presentazione, i pixel rimossi non sono più disponibili per un’operazione di “uncrop”.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Il metodo può aggiungere una nuova risorsa immagine alla presentazione. Se l’immagine originale è anche usata da altri frame immagine, quei frame hanno ancora bisogno della loro risorsa esistente, quindi la cancellazione delle aree ritagliate non riduce necessariamente il numero totale di immagini. Il ritaglio di contenuti WMF o EMF con questo metodo rasterizza il risultato ritagliato in PNG.

## **Comprimere immagini raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) riduce la risoluzione dell’immagine raster rispetto alle dimensioni con cui l’immagine viene visualizzata. Può anche rimuovere le regioni ritagliate nella stessa operazione. Il metodo restituisce `true` quando l’immagine è stata ridimensionata o ritagliata e `false` quando non era necessario alcun cambiamento.

Usa un valore predefinito di [PicturesCompression](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturescompression/) quando una risoluzione target standard è sufficiente:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

È possibile passare un valore DPI positivo personalizzato invece di un valore predefinito quando è richiesto un target specifico.

La compressione è destinata alle immagini raster. Il contenuto SVG e metafile non viene ridotto da questo flusso di lavoro di compressione raster. Ricorda anche che una risoluzione più bassa e le regioni ritagliate eliminate non possono essere recuperate dalla presentazione ottimizzata. Scegli una risoluzione target basata sulla dimensione massima alla quale l’immagine sarà effettivamente visualizzata o esportata, invece di applicare il DPI più basso a livello globale.

## **Ispezionare gli effetti immagine**

Gli effetti immagine sono memorizzati sull’immagine usata dal frame. La raccolta di trasformazioni immagine può contenere effetti come la modulazione alfa fissa per la trasparenza e la luminanza per luminosità e contrasto. L’esempio qui sotto legge in modo sicuro entrambi i tipi di effetti dal primo frame immagine su una slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Questi effetti modificano il modo in cui l’immagine è renderizzata nel frame; non riscrivono i byte originali dell’immagine incorporata.

## **Bloccare la geometria del frame immagine**

Le impostazioni di [PictureFrameLock](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframelock/) controllano quali operazioni di modifica sono disabilitate per un frame immagine. Ad esempio, [setAspectRatioLocked](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) preserva le proporzioni della forma mentre viene ridimensionata.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il blocco si applica alla forma del frame immagine. Non costringe l’immagine di origine a essere ricampionata o permanentemente modificata allo stesso rapporto d’aspetto.

## **Regolare i valori StretchOffset**

Quando la modalità di riempimento immagine è “stretch”, i valori stretch‑offset su [PictureFillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/) definiscono il rettangolo di riempimento relativo al riquadro di delimitazione del frame immagine. Percentuali positive creano un’inserzione dal bordo, mentre percentuali negative creano un’estensione.

Questo è diverso dal ritaglio. I valori di ritaglio selezionano quale parte dell’immagine di origine è visibile; gli stretch offset modificano il rettangolo in cui il riempimento immagine visibile è allungato.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Usa gli stretch offset per il posizionamento del riempimento. Usa le proprietà di ritaglio quando l’obiettivo è nascondere i bordi dell’immagine di origine.

## **Considerazioni su archiviazione, dimensione file ed esportazione**

I principali compromessi sono più facili da gestire quando l’archiviazione delle immagini e la formattazione dei frame immagine sono trattate separatamente:

- **Immagini incorporate** rendono la presentazione autonoma e sono le più affidabili per la condivisione e il rendering lato server, ma le grandi immagini raster aumentano le dimensioni del PPTX e l’uso di memoria.
- **Immagini collegate** possono mantenere il pacchetto più piccolo, ma la presentazione dipende dal fatto che i file esterni rimangano disponibili nei percorsi o nelle posizioni memorizzate.
- **Ritaglio** è inizialmente non distruttivo. I pixel nascosti rimangono incorporati finché le aree ritagliate non vengono esplicitamente cancellate o rimosse durante la compressione.
- **Compressione** può ridurre notevolmente le dimensioni del file per immagini raster sovradimensionate, ma sacrifica la risoluzione di origine. Deve essere applicata dopo che la dimensione finale sulla slide è nota.
- **Immagini SVG** dovrebbero rimanere SVG quando la conservazione vettoriale è importante. Estrai l’SVG incorporato direttamente quando hai bisogno della risorsa vettoriale stessa. Le esportazioni raster della slide convertono sempre la slide renderizzata in pixel.
- **Immagini ripetute** dovrebbero riutilizzare una risorsa [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) esistente quando possibile, anziché caricare ripetutamente lo stesso file nel flusso di lavoro della presentazione.

Per presentazioni di grandi dimensioni, l’ottimizzazione delle immagini è di solito più efficace quando eseguita in modo selettivo: mantieni loghi e diagrammi come contenuto vettoriale, comprimi le fotografie in base alle loro dimensioni reali di visualizzazione, rimuovi i pixel ritagliati solo quando non è necessario un successivo editing, ed evita i collegamenti esterni a meno che la gestione delle dipendenze non faccia parte del design di distribuzione.

## **FAQ**

**Qual è la differenza tra un frame immagine e una risorsa immagine?**

Un [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) rappresenta una risorsa immagine associata alla presentazione. Un [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/) è una forma su una slide che visualizza un’immagine e memorizza geometria e formattazione a livello di frame come dimensioni, rotazione, valori di ritaglio, effetti e blocchi.

**Devo incorporare o collegare le immagini?**

Incorpora le immagini quando la presentazione deve essere portabile, archiviata o renderizzata senza accesso a risorse esterne. Collega le immagini solo quando mantenere i file immagine fuori dal PPTX è intenzionale e le posizioni esterne possono essere gestite in modo affidabile.

**Il ritaglio riduce le dimensioni del file PPTX?**

Non di per sé. Le impostazioni di ritaglio normale nascondono parti dell’immagine di origine ma mantengono i pixel sottostanti. Usa [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) o la compressione dell’immagine con rimozione delle aree ritagliate quando quei pixel possono essere eliminati definitivamente.

**Posso ripristinare la qualità dell’immagine dopo la compressione?**

No. La compressione può ridurre la risoluzione raster memorizzata e la rimozione delle regioni ritagliate elimina i dati immagine. Conserva l’immagine sorgente originale fuori dalla presentazione se in seguito potresti aver bisogno di modifiche ad alta risoluzione.

**Come devono essere gestite le immagini SVG?**

Mantieni il contenuto SVG come SVG quando la fedeltà vettoriale è importante. L’[SvgImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgimage/) incorporato può essere estratto direttamente. Il rendering di una slide in un formato raster come PNG o JPEG rasterizza l’SVG come parte dell’immagine della slide.

**Come posso evitare cast non sicuri quando leggo slide esistenti?**

Controlla il tipo di forma prima di usare membri specifici del frame immagine. Un controllo `java.instanceOf` contro [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/) evita cast invalidi e consente al codice di gestire le slide che non contengono frame immagine.