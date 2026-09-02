---
title: Ottimizzare la gestione delle immagini nelle presentazioni usando JavaScript
linktitle: Gestire le immagini
type: docs
weight: 10
url: /it/nodejs-java/image/
keywords:
- aggiungere immagine
- aggiungere foto
- sostituire immagine
- collezione immagini
- riquadro immagine
- immagine collegata
- sfondo
- aggiungere PNG
- aggiungere JPG
- aggiungere SVG
- SVG in forme
- risorse SVG esterne
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come aggiungere, riutilizzare, collegare, sostituire e gestire immagini raster e SVG nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per Node.js tramite Java."
---
## **Introduzione**

Aspose.Slides per Node.js tramite Java offre diversi modi per lavorare con le immagini, e ciascuno serve a uno scopo diverso. È possibile memorizzare un'immagine in una presentazione, visualizzarla in un riquadro immagine, usarla come sfondo diapositiva, collegarla a un'immagine esterna, sostituire una risorsa immagine condivisa o convertire contenuti SVG in forme modificabili.

Questo articolo si concentra sulle risorse immagine e su come vengono utilizzate all'interno di una presentazione. Per il ritaglio, la trasparenza, gli effetti, lo stretching e altre formattazioni applicate a un singolo riquadro immagine, vedere [Riquadro immagine](/slides/it/nodejs-java/picture-frame/).

## **Comprendere il modello immagine**

I seguenti concetti API sono strettamente correlati ma non intercambiabili:

- La [collezione di immagini della presentazione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagecollection/) memorizza le risorse immagine utilizzate dalla presentazione. Utilizzare [ImageCollection.addImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagecollection/) per aggiungere dati immagine e ottenere una risorsa [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/).
- Un [riquadro immagine](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/) è una forma che visualizza un'immagine su una diapositiva, layout o master. Utilizzare [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/) per posizionare una risorsa immagine su una diapositiva.
- Uno sfondo diapositiva utilizza un'immagine come parte del riempimento della diapositiva anziché come forma. Pertanto non si comporta come un riquadro immagine.
- [PPImage.replaceImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) sostituisce una risorsa immagine. Se diversi elementi della presentazione utilizzano quella risorsa, tutti useranno la sostituzione.
- La conversione di un SVG in forme crea forme diapositiva modificabili. Dopo la conversione, il contenuto non è più gestito come un'unica risorsa immagine.

Un flusso di lavoro tipico è quindi: aggiungere dati immagine alla collezione di immagini, ricevere un [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/), e quindi utilizzare quella risorsa in uno o più riquadri immagine o riempimenti.

## **Aggiungere un'immagine incorporata**

Per inserire un'immagine locale, caricare il file, aggiungerlo alla collezione di immagini e creare un riquadro immagine che utilizzi la risorsa [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) restituita.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'immagine aggiunta in questo modo è incorporata nella presentazione, quindi il file risultante non dipende dal file immagine originale che deve rimanere disponibile.

### **Aggiungere un'immagine dal Web**

Quando un'immagine è disponibile tramite HTTP o HTTPS, scaricare i suoi byte, aggiungerli alla collezione di immagini della presentazione e utilizzare la risorsa immagine restituita nello stesso modo di un'immagine locale.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

In applicazioni a lungo termine, riutilizzare un client HTTP o una strategia di gestione delle connessioni adeguata all'applicazione invece di creare ripetutamente infrastrutture di rete non necessarie. Inoltre, convalidare URL remoti, dimensioni delle risposte e tipologie di contenuto quando la fonte non è attendibile.

## **Riutilizzare le immagini tra le diapositive**

Se la stessa immagine è necessaria più volte, aggiungerla alla presentazione una sola volta e riutilizzare il [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) restituito quando si creano ulteriori riquadri immagine. Questo evita di caricare ripetutamente gli stessi dati sorgente e rende esplicita la relazione tra la risorsa immagine condivisa e i suoi utilizzi.

Per grafiche che dovrebbero apparire automaticamente su molte diapositive, come il logo aziendale, considerare di posizionare il riquadro immagine su un [master diapositiva](/slides/it/nodejs-java/slide-master/) o layout invece di aggiungere una forma equivalente a ogni diapositiva.

## **Usare un'immagine come sfondo diapositiva**

Un'immagine di sfondo viene assegnata al riempimento della diapositiva; non viene aggiunta come forma di riquadro immagine. Questo è utile quando l'immagine deve coprire lo sfondo della diapositiva e non deve essere manipolata come un normale oggetto diapositiva.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per ulteriori opzioni di sfondo, inclusi sfondi master e layout, vedere [Presentation Background](/slides/it/nodejs-java/presentation-background/).

## **Immagini incorporate e immagini collegate**

Le immagini incorporate e le immagini collegate hanno diversi compromessi di portabilità e dimensione del file:

- **Immagine incorporata:** i dati dell'immagine sono memorizzati all'interno della presentazione. La presentazione è autonoma, ma la dimensione del file include i dati dell'immagine.
- **Immagine collegata:** la presentazione memorizza un percorso o URL a un'immagine esterna. Questo può ridurre la dimensione della presentazione, ma la risorsa esterna deve rimanere accessibile quando la presentazione viene aperta o resa.

Un'immagine collegata può essere creata assegnando il percorso o URL esterno tramite [Picture.setLinkPathLong](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picture/) invece di incorporare i dati dell'immagine.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilizzare immagini collegate solo quando l'ambiente di distribuzione può accedere in modo affidabile alla risorsa esterna. Per presentazioni che devono funzionare offline o essere spostate tra sistemi, le immagini incorporate sono solitamente più sicure.

## **Lavorare con immagini SVG**

SVG è un formato vettoriale, quindi può essere utile per icone, diagrammi e altre grafiche che devono scalare senza la stessa perdita di dettaglio delle immagini raster. Aspose.Slides supporta SVG sia come risorsa immagine sia come sorgente per forme diapositiva modificabili.

### **Aggiungere un SVG come immagine**

Creare un [SvgImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgimage/), aggiungerlo alla collezione di immagini e posizionare la risorsa immagine risultante in un riquadro immagine.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **File SVG con risorse esterne**

Un SVG può fare riferimento a immagini, fogli di stile o font esterni. Per questi casi, [SvgImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/svgimage/) fornisce costruttori che accettano un [ExternalResourceResolver](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/externalresourceresolver/) e un URI di base. Il risolutore può mappare un URI relativo a un URI assoluto consentito e restituire uno stream per la risorsa richiesta.

Il risolutore rende disponibili le risorse esterne mentre Aspose.Slides elabora l'SVG, ma non riscrive l'SVG in un documento autonomo. Se l'SVG deve rimanere portabile, incorporare le risorse richieste direttamente nell'SVG, ad esempio usando URI `data:` per le immagini collegate.

Quando i file SVG provengono da fonti non attendibili, limitare gli schemi, le posizioni dei file e gli host a cui il risolutore può accedere. I risolutori di rete dovrebbero anche applicare timeout, limiti di dimensione della risposta e convalida del contenuto.

### **Convertire SVG in forme modificabili**

Aspose.Slides può convertire un SVG in un gruppo di forme diapositiva modificabili, simile al comando corrispondente di PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Utilizzare la sovraccarico [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/) che accetta un'immagine SVG per eseguire la conversione.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilizzare la conversione SVG-in-forme quando gli elementi vettoriali individuali devono essere modificati come forme PowerPoint. Se l'SVG deve solo essere visualizzato, mantenerlo come immagine è più semplice e evita di creare molte forme separate.

## **Sostituire una risorsa immagine esistente**

Utilizzare [PPImage.replaceImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) quando si desidera sostituire una risorsa immagine esistente. Questo è particolarmente utile per grafiche condivise come i loghi.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se più riquadri immagine, sfondi, master o layout utilizzano la stessa risorsa immagine, sostituire quella risorsa aggiorna tutti gli utilizzi. Se deve cambiare solo un riquadro immagine, assegnare un'immagine diversa a quel riquadro invece di sostituire la risorsa condivisa.

[PPImage.replaceImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) fornisce anche sovraccarichi che accettano un array di byte o un altro [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/).

## **Linee guida pratiche per la gestione delle immagini**

### **Controllare la dimensione della presentazione**

Le grandi immagini raster possono rendere una presentazione inutilmente grande. Utilizzare immagini sorgente con dimensioni appropriate per la dimensione di visualizzazione prevista, riutilizzare le risorse immagine condivise dove possibile e evitare di incorporare copie ripetute della stessa grafica a piena risoluzione.

Per le immagini raster già inserite in riquadri immagine, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/) può ridurre i dati immagine in base alla risoluzione e alle impostazioni di ritaglio selezionate. Questo è un'elaborazione di riquadro immagine anziché una gestione della collezione di immagini, quindi vedere [Picture Frame](/slides/it/nodejs-java/picture-frame/) per le operazioni di formattazione correlate.

### **Scegliere tra contenuto incorporato e collegato**

L'incorporamento rende la presentazione portatile perché tutti i dati immagine necessari viaggiano con il file. Il collegamento può ridurre la dimensione del file, ma introduce una dipendenza esterna. Utilizzare collegamenti solo quando tale dipendenza è accettabile e stabile.

### **Riutilizzare il branding condiviso**

Per loghi, filigrane o grafiche decorative ripetute, utilizzare una singola risorsa immagine e riutilizzarla. Se la grafica appartiene al design della presentazione più che al contenuto della diapositiva, posizionarla su un master o layout affinché venga ereditata dalle diapositive appropriate.

### **Mantenere le risorse SVG portabili**

Un SVG autonomo è più facile da spostare e renderizzare in modo coerente rispetto a un SVG che dipende da file o risorse di rete esterne. Quando possibile, incorporare le risorse richieste prima di importare l'SVG. Convertire SVG in forme solo quando gli elementi vettoriali individuali devono essere modificati.

### **Utilizzare l'API immagine moderna multipiattaforma**

Per nuovo codice Node.js tramite Java, utilizzare le API Aspose.Slides [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/) e [Images](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/images/) invece della legacy API pubblica basata su `java.awt.image.BufferedImage`. Vedere [Modern API](/slides/it/nodejs-java/modern-api/) per le indicazioni di migrazione.

WMF e EMF richiedono considerazioni speciali. Quando questi formati sono passati tramite un [IImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagecollection/) converte il metafile in una rappresentazione raster PNG prima dell'inserimento. Se è importante preservare i dati del metafile, utilizzare la sovraccarico basata su stream di [ImageCollection.addImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagecollection/) invece. Generare contenuti EMF da fogli di calcolo o altri prodotti è un flusso di integrazione separato ed è fuori dall'ambito di questo articolo.

## **FAQ**

**Qual è la differenza tra la collezione di immagini e un riquadro immagine?**

La collezione di immagini memorizza risorse immagine riutilizzabili. Un riquadro immagine è una forma di diapositiva che visualizza una di tali risorse e fornisce formattazioni specifiche per l'immagine, come ritaglio ed effetti.

**Qual è il modo migliore per sostituire lo stesso logo ovunque?**

Se il logo è già condiviso come una singola risorsa immagine, sostituire quella risorsa con [PPImage.replaceImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/). Per il branding a livello di tutta la presentazione, posizionare il logo su un master o layout può anche ridurre il contenuto duplicato delle diapositive.

**Perché un'immagine collegata scompare su un altro computer?**

Un'immagine collegata dipende dal suo file o URL esterno. Se quella risorsa non è raggiungibile dall'altro computer, l'immagine collegata può risultare non disponibile. Incorporare l'immagine quando la presentazione deve essere autonoma.

**Un SVG inserito può essere modificato come forme PowerPoint?**

Sì. Convertire l'SVG con [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/); il gruppo risultante contiene forme diapositiva modificabili anziché un'unica immagine SVG.

**Come posso mantenere più piccole le presentazioni con molte immagini?**

Riutilizzare le risorse immagine condivise, evitare sorgenti raster inutilmente grandi, comprimere le immagini raster appropriate quando opportuno, mantenere il branding ripetuto su master o layout, e utilizzare immagini collegate solo quando una dipendenza esterna è accettabile.