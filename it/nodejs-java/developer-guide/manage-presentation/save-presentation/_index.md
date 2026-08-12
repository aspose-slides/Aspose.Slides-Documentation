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
- tipo di visualizzazione predefinito
- Formato Strict Office Open XML
- modalità Zip64
- aggiornamento miniatura
- salvataggio del progresso
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come salvare presentazioni usando Aspose.Slides per Node.js tramite Java—esporta in PowerPoint o OpenDocument mantenendo layout, font ed effetti."
---
## **Panoramica**

[Apri presentazioni in JavaScript](/slides/it/nodejs-java/open-presentation/) descrive come utilizzare la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) per aprire una presentazione. Questo articolo spiega come creare e salvare presentazioni. La classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) contiene i contenuti di una presentazione. Che tu stia creando una presentazione da zero o modificando una esistente, dovrai salvarla una volta terminato. Con Aspose.Slides per Node.js, puoi salvare in un **file** o in uno **stream**. Questo articolo illustra i diversi modi per salvare una presentazione.

## **Salvare presentazioni su file**

Salva una presentazione su file chiamando il metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/). Passa il nome del file e il formato di salvataggio al metodo. L'esempio seguente mostra come salvare una presentazione con Aspose.Slides.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Istanzia la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Esegui qualche lavoro qui...

    // Salva la presentazione su un file.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvare presentazioni su stream**

Puoi salvare una presentazione su uno stream passando uno stream di output al metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/). Una presentazione può essere scritta su molti tipi di stream. Nell'esempio sottostante, creiamo una nuova presentazione e la salviamo su un file stream.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Istanzia la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Salva la presentazione sullo stream.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Salvare presentazioni con un tipo di visualizzazione predefinito**

Aspose.Slides consente di impostare la visualizzazione iniziale che PowerPoint utilizza quando la presentazione generata viene aperta tramite la classe [ViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/). Usa il metodo [setLastView](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/#setLastView) con un valore dell'enumerazione [ViewType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewtype/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvare presentazioni nel formato Strict Office Open XML**

Aspose.Slides consente di salvare una presentazione nel formato Strict Office Open XML. Usa la classe [PptxOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxoptions/) e imposta la sua proprietà `conformance` durante il salvataggio. Se imposti [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), il file di output viene salvato nel formato Strict Office Open XML.

L'esempio seguente crea una presentazione e la salva nel formato Strict Office Open XML.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Istanzia la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Salva la presentazione nel formato Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salvare presentazioni in formato Office Open XML in modalità Zip64**

Un file Office Open XML è un archivio ZIP che impone limiti di 4 GB (2^32 byte) sulla dimensione non compressa di qualsiasi file, sulla dimensione compressa di qualsiasi file e sulla dimensione totale dell'archivio, oltre a limitare l'archivio a 65 535 (2^16‑1) file. Le estensioni del formato ZIP64 aumentano questi limiti a 2^64.

Il metodo [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) consente di scegliere quando utilizzare le estensioni del formato ZIP64 durante il salvataggio di un file Office Open XML.

Questo metodo può essere usato con le seguenti modalità:

- [IfNecessary](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/zip64mode/#IfNecessary) utilizza le estensioni ZIP64 solo se la presentazione supera le limitazioni sopra indicate. È la modalità predefinita.
- [Never](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/zip64mode/#Never) non utilizza mai le estensioni ZIP64.
- [Always](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/zip64mode/#Always) utilizza sempre le estensioni ZIP64.

Il codice seguente dimostra come salvare una presentazione come file PPTX con le estensioni ZIP64 abilitate:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Quando salvi con [Zip64Mode.Never](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/zip64mode/#Never), viene generata un'eccezione [PptxException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxexception/) se la presentazione non può essere salvata nel formato ZIP32.
{{% /alert %}}

## **Salvare presentazioni in formato Office Open XML con livelli di compressione**

Quando lavori con presentazioni di grandi dimensioni, puoi regolare il livello di compressione per bilanciare la dimensione del file e il tempo di elaborazione. A seconda delle tue esigenze, potresti preferire una elaborazione più rapida o file di output più piccoli.

Aspose.Slides fornisce il metodo [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel), che consente di specificare il livello di compressione da utilizzare quando si salva una presentazione in formato Office Open XML.

I livelli di compressione disponibili sono:

- [**None**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#None): Nessuna compressione. I file vengono memorizzati così come sono.
- [**Level1**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level1): Compressione più veloce con il rapporto di compressione più basso.
- [**Level2**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level2): Compressione più veloce con un rapporto leggermente migliore rispetto a **Level1**.
- [**Level3**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level3): Fornisce una compressione migliore rispetto a **Level2** con un impatto moderato sul tempo di elaborazione.
- [**Level4**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level4): Fornisce una compressione migliore rispetto a **Level3**.
- [**Level5**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level5): Migliora la compressione rispetto a **Level4** con ulteriore tempo di elaborazione.
- [**Level6**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level6): Compressione standard che offre un buon equilibrio tra velocità di elaborazione e dimensione del file. È il *livello di compressione predefinito*.
- [**Level7**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level7): Fornisce una compressione migliore rispetto a **Level6** ma con una elaborazione più lenta.
- [**Level8**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level8): Fornisce una compressione migliore rispetto a **Level7**.
- [**Level9**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compressionlevel/#Level9): Compressione massima. Produce il file più piccolo a costo del tempo di elaborazione più lungo.

L'esempio seguente dimostra come salvare una presentazione come file PPTX *senza compressione*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Questo esempio mostra come salvare una presentazione come file PPTX con *massima compressione*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Salvare presentazioni senza aggiornare la miniatura**

Il metodo [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controlla la generazione della miniatura quando si salva una presentazione in PPTX:

- Se impostato su `true`, la miniatura viene aggiornata durante il salvataggio. È il valore predefinito.
- Se impostato su `false`, la miniatura corrente viene preservata. Se la presentazione non ha una miniatura, non ne viene generata alcuna.

Nel codice sottostante, la presentazione viene salvata in PPTX senza aggiornare la miniatura.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Questa opzione aiuta a ridurre il tempo necessario per salvare una presentazione in formato PPTX.
{{% /alert %}}

## **Salvataggio del progresso in percentuale**

Il reporting del progresso di salvataggio è configurato tramite il metodo [setProgressCallback](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) su [SaveOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveoptions/) e le sue sottoclassi. Fornisci un proxy Java che implementi l'interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprogresscallback/); durante l'esportazione, il callback riceve aggiornamenti percentuali periodici.

Gli snippet di codice seguenti mostrano come utilizzare `IProgressCallback`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Utilizza qui il valore percentuale di avanzamento.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose ha sviluppato un'app gratuita [PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) usando la propria API. L'app consente di dividere una presentazione in più file salvando le diapositive selezionate come nuovi file PPTX o PPT.
{{% /alert %}}

## **FAQ**

**È supportato il “salvataggio veloce” (salvataggio incrementale) in modo che vengano scritte solo le modifiche?**

No. Il salvataggio crea l'intero file di destinazione ogni volta; il “salvataggio veloce” incrementale non è supportato.

**È thread‑safe salvare la stessa istanza di Presentation da più thread?**

No. Un'istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) [non è thread‑safe](/slides/it/nodejs-java/multithreading/); salvala da un singolo thread.

** Cosa succede ai collegamenti ipertestuali e ai file collegati esternamente durante il salvataggio?**

[Hyperlinks](/slides/it/nodejs-java/manage-hyperlinks/) vengono preservati. I file collegati esternamente (ad esempio video tramite percorsi relativi) non vengono copiati automaticamente: assicurati che i percorsi di riferimento rimangano accessibili.

**Posso impostare/salvare i metadati del documento (Autore, Titolo, Azienda, Data)?**

Sì. Le [proprietà del documento](/slides/it/nodejs-java/presentation-properties/) standard sono supportate e verranno scritte nel file al momento del salvataggio.