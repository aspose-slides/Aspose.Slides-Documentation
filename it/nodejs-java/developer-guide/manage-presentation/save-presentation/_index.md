---
title: Salva presentazioni in JavaScript
linktitle: Salva presentazione
type: docs
weight: 80
url: /it/nodejs-java/save-presentation/
keywords:
- salva PowerPoint
- salva OpenDocument
- salva presentazione
- salva diapositiva
- salva PPT
- salva PPTX
- salva ODP
- presentazione su file
- presentazione su stream
- tipo di vista predefinito
- Formato Strict di Office Open XML
- modalità Zip64
- aggiornamento miniatura
- salvataggio avanzamento
- Node.js
- JavaScript
- Aspose.Slides
description: "Salva presentazioni PowerPoint e OpenDocument su file o stream in JavaScript con Aspose.Slides, e configura l'output PPTX e il reporting di avanzamento."
---
## **Panoramica**

Dopo aver creato una presentazione o [apri una esistente](/slides/it/nodejs-java/open-presentation/), utilizza il metodo [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) per scrivere il risultato. Aspose.Slides per Node.js via Java può salvare una presentazione in un file o stream in formati PowerPoint, OpenDocument, PDF e altri formati. Le sezioni seguenti illustrano le operazioni di salvataggio standard e le opzioni disponibili per l'output PPTX.

## **Salva presentazioni su file**

Per salvare una presentazione su file, passa il percorso di destinazione e un valore [SaveFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/) al metodo [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save). Il valore del formato determina il tipo di file che Aspose.Slides crea.

L'esempio seguente crea una presentazione e la salva come file PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Aggiungi o modifica il contenuto della presentazione qui.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salva presentazioni nel loro formato originale**

Per esempi di rilevamento di file e stream, il comportamento delle presentazioni appena create e la distinzione tra formati di origine e di destinazione, vedi [Determina il formato originale della presentazione](/slides/it/nodejs-java/detect-presentation-source-format/).

In un'applicazione batch, il formato di input potrebbe non essere noto in anticipo. Dopo aver caricato un file, leggi il suo formato originale dal metodo [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getSourceFormat). Passa il valore [SourceFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sourceformat/) risultante a [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideutil/#toSaveFormat) per ottenere il corrispondente valore [SaveFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/) e poi utilizza [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) per scrivere la presentazione modificata.

L'esempio completo seguente elabora tutti i file in una directory di input, aggiorna il titolo e lo salva in una directory di output nel formato da cui è stato caricato:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideutil/#toSaveFormat) mappa PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP e PowerPoint XML nei rispettivi formati di salvataggio della presentazione. Mappa solo i formati di origine della presentazione; non è destinato a selezionare formati di esportazione come PDF, HTML, TIFF o immagini. Passare un valore [SourceFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sourceformat/) non supportato o non valido genera un errore.

I file legacy PPT, PPS e POT utilizzano lo stesso contenitore binario. Quando una presentazione di questo tipo viene caricata da uno stream senza estensione di file, un file PPS o POT può quindi essere identificato come PPT. Se è necessario preservare questi sottotipi legacy, conserva separatamente il nome file originale o i metadati del formato e usali quando scegli il nome file e il formato di destinazione.

## **Salva presentazioni su stream**

Per scrivere una presentazione senza dipendere da un percorso file definitivo, passa uno stream scrivibile e un valore [SaveFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/) al metodo [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save). Questo approccio è utile quando l'output deve essere restituito da un servizio web, memorizzato in un database o elaborato in memoria.

L'esempio seguente salva una nuova presentazione in uno stream di file:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Salva presentazioni con un tipo di vista predefinito**

Puoi specificare la vista con cui PowerPoint apre inizialmente una presentazione salvata. Usa il metodo [ViewProperties.setLastView](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/#setLastView) con un valore [ViewType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewtype/) prima di salvare.

L'esempio seguente configura la vista Slide Master come vista iniziale:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salva presentazioni nel formato Strict di Office Open XML**

Per creare un file PPTX conforme al profilo Strict di Office Open XML, crea un'istanza [PptxOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxoptions/) e utilizza il suo metodo [setConformance](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxoptions/#setConformance) con [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict). Quindi passa le opzioni al metodo [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salva presentazioni in formato Office Open XML in modalità Zip64**

Un archivio ZIP standard limita la dimensione compressa e non compressa di ciascuna voce, la dimensione totale dell'archivio e il numero di voci. Poiché un file PPTX è un archivio ZIP, una presentazione molto grande può superare tali limiti. Le estensioni ZIP64 aumentano i limiti di dimensione e di conteggio delle voci applicabili.

Usa il metodo [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) per controllare se Aspose.Slides scrive le estensioni ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/zip64mode/#IfNecessary) utilizza ZIP64 solo quando la presentazione supera i limiti ZIP standard. Questa è la modalità predefinita.
- [Never](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/zip64mode/#Never) disabilita le estensioni ZIP64.
- [Always](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/zip64mode/#Always) scrive sempre le estensioni ZIP64.

L'esempio seguente abilita sempre le estensioni ZIP64 per la presentazione di output:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Se viene usato [Zip64Mode.Never](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/zip64mode/#Never) e la presentazione non può rientrare nei limiti ZIP standard, l'operazione di salvataggio genera una [PptxException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Salva presentazioni in formato Office Open XML con livelli di compressione**

Per l'output PPTX, puoi bilanciare la velocità di salvataggio rispetto alle dimensioni del file usando il metodo [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel). La classe [CompressionLevel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/) fornisce questi valori:

- [None](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#None) archivia i dati senza compressione.
- [Level1](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level1) fornisce la compressione più rapida e l'output compresso più grande.
- [Level2](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level2) fino a [Level5](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level5) favoriscono progressivamente un output più piccolo a scapito della velocità di salvataggio.
- [Level6](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level6) bilancia velocità di salvataggio e dimensione del file. Questo è il livello predefinito.
- [Level7](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level7) e [Level8](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level8) favoriscono ulteriormente un output più piccolo a scapito della velocità di salvataggio.
- [Level9](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level9) fornisce la compressione più forte e richiede più tempo di elaborazione.

L'esempio seguente salva una presentazione senza compressione:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

L'esempio seguente utilizza il livello di compressione massimo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salva presentazioni senza aggiornare la miniatura**

Quando una presentazione viene salvata come PPTX, il metodo [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controlla la miniatura del documento:

- `true` rigenera la miniatura durante l'operazione di salvataggio. Questo è il valore predefinito.
- `false` preserva la miniatura esistente. Se la presentazione non ha una miniatura, Aspose.Slides non ne genera una.

L'esempio seguente salva una presentazione senza aggiornare la sua miniatura:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Disabilitare l'aggiornamento della miniatura può ridurre il tempo necessario per salvare un file PPTX.
{{% /alert %}}

## **Salva aggiornamenti di avanzamento in percentuale**

Per monitorare un'operazione di salvataggio, implementa l'interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprogresscallback/) con un proxy Java e passa l'implementazione al metodo [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides quindi chiama il metodo [IProgressCallback.reporting](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprogresscallback/#reporting-double-) con i valori di avanzamento durante l'esportazione.

L'esempio seguente segnala l'avanzamento di un'esportazione PDF nella console:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose offre gratuitamente un PowerPoint Splitter realizzato con l'API Aspose.Slides. Salva le diapositive selezionate da una presentazione come file PPT o PPTX separati.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il salvataggio incrementale o “fast save”?**

No. Ogni operazione di salvataggio scrive un file di output completo invece di aggiornare solo le parti modificate.

**Possono più thread salvare la stessa istanza di Presentation?**

No. Un'istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) non è thread-safe. Accedi e salva ogni istanza da un solo thread alla volta.

**Cosa succede a collegamenti ipertestuali e file collegati esternamente quando salvo una presentazione?**

[Hyperlinks](/slides/it/nodejs-java/manage-hyperlinks/) rimangono nella presentazione. Aspose.Slides non copia i file collegati esternamente, quindi la presentazione salvata deve ancora poter accedere alle loro posizioni.

**Posso salvare i metadati del documento come autore, titolo, azienda e data di creazione?**

Sì. Imposta le appropriate [document properties](/slides/it/nodejs-java/presentation-properties/) prima di salvare e Aspose.Slides le scrive nel file di output.