---
title: Recupera e Aggiorna le Informazioni della Presentazione in JavaScript
linktitle: Informazioni sulla Presentazione
type: docs
weight: 30
url: /it/nodejs-java/examine-presentation/
keywords:
- formato della presentazione
- proprietà della presentazione
- proprietà del documento
- ottenere proprietà
- leggere proprietà
- cambiare proprietà
- aggiornare proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati in presentazioni PowerPoint e OpenDocument usando JavaScript per ottenere insight più rapidi e audit di contenuto più intelligenti."
---
## **Panoramica**

Aspose.Slides può identificare il formato di una presentazione e leggere i metadati del documento senza creare un modello di oggetto della presentazione completo. Questo è utile quando è necessario classificare i file, creare un inventario o ispezionare le proprietà prima di decidere se caricare ed elaborare il contenuto della presentazione.

Questo articolo dimostra l'ispezione leggera tramite [PresentationFactory](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/) e [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/), nonché gli aggiornamenti mirati tramite [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/).

## **Verifica il formato di una presentazione**

Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) per ispezionare un file senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/). Il metodo [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/getloadformat/) restituisce il formato rilevato, ad esempio PPTX, PPT o ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **Crea un inventario di presentazioni leggero**

Quando elabori molti file di presentazione, potresti aver bisogno di un inventario compatto per la convalida, l'indicizzazione o un sistema di gestione dei documenti. In questo scenario, utilizza [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) per ottenere un oggetto [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/), e quindi chiama [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) per leggere i metadati del documento. Questo approccio non crea un'istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) né richiede di attraversare l'intero modello di oggetto della presentazione.

Le proprietà estese esposte da [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/) forniscono i seguenti valori di inventario:

| Metodo | Valore dell'inventario |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getSlides) | Numero totale di diapositive. |
| [getHiddenSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Numero di diapositive nascoste. |
| [getNotes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getNotes) | Numero di diapositive che contengono note. |
| [getParagraphs](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Numero totale di paragrafi, se disponibili. |
| [getWords](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getWords) | Numero totale di parole. |
| [getMultimediaClips](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Numero totale di clip audio e video. |

Il seguente esempio legge questi valori senza creare un oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e stampa un inventario compatto. Combina inoltre [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) con [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) per visualizzare gruppi di contenuto come caratteri, temi e titoli delle diapositive.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Ogni [HeadingPair](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/headingpair/) fornisce un nome di gruppo tramite [HeadingPair.getName](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/headingpair/#getName) e il numero di elementi in quel gruppo tramite [HeadingPair.getCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) restituisce un array piatto e ordinato, quindi si devono consumare il numero di titoli consecutivi specificato da ciascuna coppia di intestazioni.

### **Metadati archiviati e limitazioni del formato**

Le proprietà di inventario restituite da [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) riflettono i metadati disponibili nel documento di origine. Aspose.Slides non carica e non attraversa il modello di oggetto della presentazione per ricalcolare questi valori per questa chiamata. Le proprietà mancanti sono rappresentate da valori predefiniti e i valori archiviati possono essere obsoleti se l'applicazione che ha salvato per ultima il file non ha aggiornato le proprietà del documento.

- **PPTX:** Il formato fornisce proprietà di documento estese per conteggi di diapositive, note, diapositive nascoste, paragrafi, parole e contenuti multimediali, nonché coppie di intestazioni e titoli delle parti. La disponibilità dipende da quali proprietà siano state scritte dal produttore del documento.
- **PPT:** Il formato binario può memorizzare le corrispondenti proprietà di riepilogo del documento. Se una proprietà è assente o non è stata aggiornata dal produttore del documento, Aspose.Slides restituisce il valore archiviato o predefinito anziché calcolarlo dalle diapositive.
- **ODP:** I metadati OpenDocument forniscono statistiche generali del documento, come il conteggio di pagine, paragrafi e parole, ma questi valori non corrispondono a tutte le proprietà estese specifiche di PowerPoint. I metadati di diapositive nascoste, note, contenuti multimediali, coppie di intestazioni e titoli delle parti potrebbero non essere disponibili, e le proprietà di inventario potrebbero restituire valori predefiniti. Non considerare un valore zero o un array vuoto come prova autorevole che il contenuto corrispondente sia assente.

Utilizza l'approccio di metadati leggeri per inventari e controlli preliminari. Carica la presentazione e ispeziona il suo modello di oggetto live quando il risultato deve riflettere le modifiche in memoria o quando è necessario verificare il contenuto reale della presentazione.

## **Aggiorna le proprietà della presentazione**

Le proprietà restituite da [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) possono anche essere modificate senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/). Applica le modifiche con [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/), e poi scrivi la presentazione collegata con [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

L'immagine seguente mostra le proprietà del documento originale.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

Il seguente esempio modifica il titolo e l'ora dell'ultimo salvataggio e scrive il risultato in un nuovo file:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

L'immagine seguente mostra le proprietà del documento aggiornate.

![Proprietà del documento modificate della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per controlli di sicurezza correlati e impostazioni di protezione, consulta i seguenti articoli:

- [Presentazioni protette da password](/slides/it/nodejs-java/password-protected-presentation/)
- [Presentazioni protette in scrittura](/slides/it/nodejs-java/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i caratteri sono incorporati e quali sono?**

Carica la presentazione e utilizza [Presentation.getFontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getfontsmanager/). Chiama [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) per ottenere i caratteri incorporati e [FontsManager.getFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getfonts/) per ottenere i caratteri utilizzati dalla presentazione. Confronta i due risultati per individuare i caratteri necessari per il rendering ma non incorporati.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Quando i metadati del documento archiviati sono sufficienti, leggi [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) tramite [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) e [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Questo è adatto per un inventario leggero. Se la presentazione è stata modificata in memoria, i metadati archiviati potrebbero mancare o essere obsoleti, oppure è necessario verificare i valori in tempo reale, iterare su [Presentation.getSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getslides/) e ispezionare il metodo [Slide.getHidden](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/gethidden/) di ciascuna diapositiva.

**Posso rilevare se è usata una dimensione e orientamento della diapositiva personalizzati e se differiscono dai valori predefiniti?**

Sì. Carica la presentazione e chiama [Presentation.getSlideSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getslidesize/). Usa [SlideSize.getType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesize/getsize/), e [SlideSize.getOrientation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesize/getorientation/) per confrontare le impostazioni attuali con il preset e le dimensioni previste.

**Esiste un modo rapido per verificare se i grafici fanno riferimento a fonti dati esterne?**

Sì. Individua ogni [Chart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/) e chiama [ChartData.getDataSourceType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). Per una cartella di lavoro esterna, chiama [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Il tipo di origine dati e il percorso identificano un riferimento esterno, ma verificare se la destinazione è disponibile richiede un controllo delle risorse separato.

**Come posso valutare le diapositive 'pesanti' che potrebbero rallentare il rendering o l'esportazione PDF?**

Non esiste una singola proprietà di complessità. Attraversa [Presentation.getSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getslides/) e la collezione [BaseSlide.getShapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/#getShapes) di ciascuna diapositiva. Usa il conteggio delle forme e la presenza di immagini grandi, effetti, animazioni o contenuti multimediali come segnali di screening, e misura un rendering o un'esportazione rappresentativa prima di considerare una diapositiva come un collo di bottiglia di prestazioni confermato.