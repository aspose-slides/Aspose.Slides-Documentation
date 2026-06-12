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
- avanzamento salvataggio
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come salvare presentazioni utilizzando Aspose.Slides per Node.js tramite Java - esporta in PowerPoint o OpenDocument mantenendo layout, caratteri ed effetti."
---
## **Panoramica**

[Open Presentations in JavaScript](/slides/it/nodejs-java/open-presentation/) descrive come utilizzare la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) per aprire una presentazione. Questo articolo spiega come creare e salvare presentazioni. La classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) contiene il contenuto di una presentazione. Che tu stia creando una presentazione da zero o modificando una esistente, dovrai salvarla al termine. Con Aspose.Slides per Node.js, puoi salvare in un **file** o **stream**. Questo articolo descrive i diversi modi per salvare una presentazione.

## **Salva presentazioni su file**

Salva una presentazione su un file chiamando il metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/). Passa il nome del file e il formato di salvataggio al metodo. L’esempio seguente mostra come salvare una presentazione con Aspose.Slides.

```js
// Istanzia la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    // Esegui qualche operazione qui...

    // Salva la presentazione in un file.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salva presentazioni su stream**

Puoi salvare una presentazione su uno stream passando uno stream di output al metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/). Una presentazione può essere scritta in molti tipi di stream. Nell’esempio seguente, creiamo una nuova presentazione e la salviamo su un file stream.

```js
// Istanzia la classe Presentation che rappresenta un file di presentazione.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Salva la presentazione nello stream.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Salva presentazioni con un tipo di visualizzazione predefinito**

Aspose.Slides ti consente di impostare la visualizzazione iniziale che PowerPoint utilizza quando la presentazione generata viene aperta tramite la classe [ViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/). Usa il metodo [setLastView](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/#setLastView) con un valore dell’enumerazione [ViewType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewtype/).

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salva presentazioni nel formato Strict Office Open XML**

Aspose.Slides ti permette di salvare una presentazione nel formato Strict Office Open XML. Usa la classe [PptxOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxoptions/) e imposta la sua proprietà `conformance` al salvataggio. Se imposti [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), il file di output viene salvato nel formato Strict Office Open XML.

L’esempio seguente crea una presentazione e la salva nel formato Strict Office Open XML.

```js
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

## **Salva presentazioni in Office Open XML Format in modalità Zip64**

Un file Office Open XML è un archivio ZIP che impone limiti di 4 GB (2^32 byte) sulla dimensione non compressa di qualsiasi file, sulla dimensione compressa di qualsiasi file e sulla dimensione totale dell’archivio, e limita inoltre l’archivio a 65 535 (2^16‑1) file. Le estensioni del formato ZIP64 elevano questi limiti a 2^64.

Il metodo [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) ti consente di scegliere quando utilizzare le estensioni del formato ZIP64 durante il salvataggio di un file Office Open XML.

Questo metodo può essere usato con le seguenti modalità:

- [IfNecessary](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/zip64mode/#IfNecessary) utilizza le estensioni ZIP64 solo se la presentazione supera le limitazioni sopra riportate. È la modalità predefinita.
- [Never](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/zip64mode/#Never) non utilizza mai le estensioni ZIP64.
- [Always](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/zip64mode/#Always) utilizza sempre le estensioni ZIP64.

Il codice seguente dimostra come salvare una presentazione come PPTX con le estensioni ZIP64 abilitate:

```js
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
Quando salvi usando [Zip64Mode.Never](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/zip64mode/#Never), viene sollevata una [PptxException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxexception/) se la presentazione non può essere salvata nel formato ZIP32.
{{% /alert %}}

## **Salva presentazioni senza aggiornare la miniatura**

Il metodo [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controlla la generazione della miniatura quando una presentazione viene salvata in PPTX:

- Se impostato a `true`, la miniatura viene aggiornata durante il salvataggio. È il valore predefinito.
- Se impostato a `false`, la miniatura corrente viene conservata. Se la presentazione non ha una miniatura, non ne viene generata alcuna.

Nel codice seguente, la presentazione è salvata in PPTX senza aggiornare la sua miniatura.

```js
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
Questa opzione aiuta a ridurre il tempo necessario per salvare una presentazione nel formato PPTX.
{{% /alert %}}

## **Aggiornamenti di avanzamento del salvataggio in percentuale**

La segnalazione dell’avanzamento del salvataggio è configurata tramite il metodo [setProgressCallback](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) su [SaveOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveoptions/) e le sue classi derivate. Fornisci un proxy Java che implementi l’interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprogresscallback/); durante l’esportazione, il callback riceve aggiornamenti periodici in percentuale.

Gli snippet di codice seguenti mostrano come utilizzare `IProgressCallback`.

```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Usa qui il valore percentuale di avanzamento.
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
Aspose ha sviluppato un’app gratuita **PowerPoint Splitter** (https://products.aspose.app/slides/it/splitter) che utilizza la propria API. L’app consente di dividere una presentazione in più file salvando le diapositive selezionate come nuovi file PPTX o PPT.
{{% /alert %}}

## **FAQ**

**È supportato il “salvataggio veloce” (salvataggio incrementale) in modo che vengano scritte solo le modifiche?**

No. Il salvataggio crea il file di destinazione completo ogni volta; il “salvataggio veloce” incrementale non è supportato.

**È thread‑safe salvare la stessa istanza di Presentation da più thread?**

No. Un’istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) [non è thread‑safe](/slides/it/nodejs-java/multithreading/); salvala da un singolo thread.

**Cosa succede a collegamenti ipertestuali e file collegati esternamente durante il salvataggio?**

[I collegamenti ipertestuali](/slides/it/nodejs-java/manage-hyperlinks/) vengono preservati. I file collegati esternamente (ad es. video tramite percorsi relativi) non vengono copiati automaticamente: assicurati che i percorsi di riferimento rimangano accessibili.

**Posso impostare/salvare i metadati del documento (Autore, Titolo, Azienda, Data)?**

Sì. Le [proprietà del documento](/slides/it/nodejs-java/presentation-properties/) standard sono supportate e verranno scritte nel file al salvataggio.