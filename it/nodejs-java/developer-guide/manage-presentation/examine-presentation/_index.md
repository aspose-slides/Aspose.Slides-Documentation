---
title: Recupera e aggiorna le informazioni della presentazione in JavaScript
linktitle: Informazioni sulla presentazione
type: docs
weight: 30
url: /it/nodejs-java/examine-presentation/
keywords:
- formato della presentazione
- proprietà della presentazione
- proprietà del documento
- ottieni proprietà
- leggi proprietà
- cambia proprietà
- modifica proprietà
- aggiorna proprietà
- esamina PPTX
- esamina PPT
- esamina ODP
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument utilizzando JavaScript per ottenere approfondimenti più rapidi e audit dei contenuti più intelligenti."
---
## **Panoramica**

Aspose.Slides può identificare il formato di una presentazione e leggere i metadati del documento senza creare un modello completo di oggetti della presentazione. Questo è utile quando è necessario classificare i file, costruire un inventario o esaminare le proprietà prima di decidere se caricare e processare il contenuto della presentazione.

Questo articolo dimostra l'ispezione leggera tramite [PresentationFactory](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/) e [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/), così come gli aggiornamenti mirati tramite [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/).

## **Verificare il formato di una presentazione**

Se hai già una presentazione caricata, consulta [Determine the Original Presentation Format](/slides/it/nodejs-java/detect-presentation-source-format/) per la rilevazione dopo il caricamento e le limitazioni dei flussi legacy PPT, PPS e POT.

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

## **Creare un inventario leggero delle presentazioni**

Quando elabori molti file di presentazione, potresti aver bisogno di un inventario compatto per la convalida, l'indicizzazione o un sistema di gestione dei documenti. In questo scenario, utilizza [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) per ottenere un oggetto [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/), quindi chiama [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) per leggere i metadati del documento. Questo approccio non crea un'istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) né richiede di attraversare l'intero modello di oggetti della presentazione.

Le proprietà estese esposte da [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/) forniscono i seguenti valori di inventario:

| Metodo | Valore inventario |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getSlides) | Numero totale di diapositive. |
| [getHiddenSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Numero di diapositive nascoste. |
| [getNotes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getNotes) | Numero di diapositive che contengono note. |
| [getParagraphs](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Numero totale di paragrafi, quando disponibili. |
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

Ogni [HeadingPair](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/headingpair/) fornisce un nome di gruppo tramite [HeadingPair.getName](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/headingpair/#getName) e il numero di elementi in quel gruppo tramite [HeadingPair.getCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) restituisce un array piatto e ordinato, quindi consumare il numero di titoli consecutivi specificati da ciascuna coppia di intestazioni.

### **Metadati memorizzati e limitazioni di formato**

Le proprietà di inventario restituite da [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) riflettono i metadati disponibili nel documento sorgente. Aspose.Slides non carica e attraversa il modello di oggetti della presentazione per ricalcolare questi valori per questa chiamata. Le proprietà mancanti sono rappresentate da valori predefiniti e i valori memorizzati possono essere obsoleti se l'applicazione che ha salvato per ultima il file non ha aggiornato le proprietà del documento.

- **PPTX:** Il formato fornisce proprietà di documento estese per conteggi di diapositive, note, diapositive nascoste, paragrafi, parole e multimedia, oltre a coppie di intestazioni e titoli di parti. La disponibilità dipende da quali proprietà sono state scritte dal produttore del documento.
- **PPT:** Il formato binario può memorizzare le corrispondenti proprietà di riepilogo del documento. Se una proprietà è assente o non è stata aggiornata dal produttore del documento, Aspose.Slides restituisce il valore memorizzato o predefinito invece di calcolarlo dalle diapositive.
- **ODP:** I metadati OpenDocument forniscono statistiche generali del documento, come conteggi di pagine, paragrafi e parole, ma questi valori non corrispondono a tutte le proprietà estese specifiche di PowerPoint. I metadati di diapositive nascoste, note, multimedia, coppie di intestazioni e titoli di parti potrebbero non essere disponibili e le proprietà di inventario potrebbero restituire valori predefiniti. Non considerare un valore zero o un array vuoto come prova autoritaria dell'assenza del contenuto corrispondente.

Usa l'approccio di metadati leggeri per inventari e controlli preliminari. Carica la presentazione e ispeziona il modello di oggetti attivo quando il risultato deve riflettere modifiche in memoria o quando è necessario verificare il contenuto reale della presentazione.

## **Aggiornare le proprietà della presentazione**

Le proprietà restituite da [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) possono anche essere modificate senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/). Applica le modifiche con [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/), quindi scrivi la presentazione collegata con [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

L'immagine seguente mostra le proprietà originali del documento.

![Proprietà del documento originale della presentazione PowerPoint](input_properties.png)

L'esempio seguente cambia il titolo e l'ora dell'ultimo salvataggio e scrive il risultato in un nuovo file:

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

![Proprietà del documento aggiornate della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per controlli di sicurezza correlati e impostazioni di protezione, consulta i seguenti articoli:

- [Password-Protect Presentations](/slides/it/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/it/nodejs-java/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i caratteri sono incorporati e quali sono?**

Carica la presentazione e usa [Presentation.getFontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getfontsmanager/). Chiama [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) per ottenere i caratteri incorporati e [FontsManager.getFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getfonts/) per ottenere i caratteri utilizzati dalla presentazione. Confronta i due risultati per trovare i caratteri necessari per il rendering ma non incorporati.

**Come posso capire rapidamente se il file ha diapositive nascoste e quante?**

Quando i metadati del documento memorizzati sono sufficienti, leggi [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) tramite [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) e [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Questo è adatto per un inventario leggero. Se la presentazione è stata modificata in memoria, i metadati memorizzati potrebbero mancare o essere obsoleti, oppure è necessario verificare i valori attivi: itera su [Presentation.getSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getslides/) e controlla il metodo [Slide.getHidden](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/gethidden/) di ciascuna diapositiva.

**Posso rilevare se sono state usate dimensioni e orientamento personalizzati per le diapositive e se differiscono dai valori predefiniti?**

Sì. Carica la presentazione e chiama [Presentation.getSlideSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getslidesize/). Usa [SlideSize.getType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesize/getsize/), e [SlideSize.getOrientation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidesize/getorientation/) per confrontare le impostazioni attuali con i valori preimpostati e le dimensioni attese.

**Esiste un modo rapido per vedere se i grafici fanno riferimento a fonti dati esterne?**

Sì. Individua ogni [Chart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/) e chiama [ChartData.getDataSourceType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). Per una cartella di lavoro esterna, chiama [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Il tipo di fonte dati e il percorso identificano un riferimento esterno, ma verificare se la destinazione è disponibile richiede un controllo di risorse separato.

**Come posso valutare le diapositive "pesanti" che potrebbero rallentare il rendering o l'esportazione in PDF?**

Non esiste una singola proprietà di complessità. Attraversa [Presentation.getSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getslides/) e la collezione [BaseSlide.getShapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/#getShapes) di ciascuna diapositiva. Usa il conteggio delle forme e la presenza di immagini di grandi dimensioni, effetti, animazioni o multimedia come segnali di screening, e misura un rendering o un'esportazione rappresentativa prima di considerare una diapositiva un colpo di bottiglia confermato delle prestazioni.