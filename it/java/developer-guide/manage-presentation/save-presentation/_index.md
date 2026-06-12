---
title: Salvare presentazioni in Java
linktitle: Salva presentazione
type: docs
weight: 80
url: /it/java/save-presentation/
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
- Java
- Aspose.Slides
description: "Scopri come salvare presentazioni in Java usando Aspose.Slides—esporta in PowerPoint o OpenDocument mantenendo layout, caratteri ed effetti."
---
## **Panoramica**

[Open Presentations in Java](/slides/it/java/open-presentation/) ha descritto come usare la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) per aprire una presentazione. Questo articolo spiega come creare e salvare le presentazioni. La classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) contiene il contenuto di una presentazione. Che tu stia creando una presentazione da zero o modificando una esistente, vorrai salvarla quando hai finito. Con Aspose.Slides per Java, puoi salvare in un **file** o in uno **stream**. Questo articolo spiega i diversi modi per salvare una presentazione.

## **Salva le presentazioni in file**

Salva una presentazione su un file chiamando il metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/). Passa il nome del file e il formato di salvataggio al metodo. L'esempio seguente mostra come salvare una presentazione con Aspose.Slides.

```java
// Istanzia la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Esegui qualche operazione qui...

    // Salva la presentazione su un file.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salva le presentazioni su stream**

Puoi salvare una presentazione su uno stream passando uno stream di output al metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/). Una presentazione può essere scritta su molti tipi di stream. Nell'esempio seguente, creiamo una nuova presentazione e la salviamo su uno stream di file.

```java
// Istanzia la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Salva la presentazione sullo stream.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Salva le presentazioni con un tipo di visualizzazione predefinito**

Aspose.Slides ti consente di impostare la visualizzazione iniziale che PowerPoint utilizza quando la presentazione generata viene aperta tramite la classe [ViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/viewproperties/). Usa il metodo [setLastView](https://reference.aspose.com/slides/it/java/com.aspose.slides/viewproperties/#setLastView-int-) con un valore dell'enumerazione [ViewType](https://reference.aspose.com/slides/it/java/com.aspose.slides/viewtype/).

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salva le presentazioni nel formato Strict Office Open XML**

Aspose.Slides ti permette di salvare una presentazione nel formato Strict Office Open XML. Usa la classe [PptxOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptxoptions/) e imposta la sua proprietà conformance durante il salvataggio. Se imposti [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/it/java/com.aspose.slides/conformance/#Iso29500-2008-Strict), il file di output viene salvato nel formato Strict Office Open XML.

L'esempio seguente crea una presentazione e la salva nel formato Strict Office Open XML.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Istanzia la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Salva la presentazione nel formato Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salva le presentazioni nel formato Office Open XML in modalità Zip64**

Un file Office Open XML è un archivio ZIP che impone limiti di 4 GB (2^32 byte) sulla dimensione non compressa di qualsiasi file, sulla dimensione compressa di qualsiasi file e sulla dimensione totale dell'archivio, e limita inoltre l'archivio a 65 535 (2^16‑1) file. Le estensioni del formato ZIP64 aumentano questi limiti a 2^64.

Il metodo [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) ti consente di scegliere quando utilizzare le estensioni del formato ZIP64 durante il salvataggio di un file Office Open XML.

Questo metodo può essere usato con le seguenti modalità:

- [IfNecessary](https://reference.aspose.com/slides/it/java/com.aspose.slides/zip64mode/#IfNecessary) usa le estensioni del formato ZIP64 solo se la presentazione supera le limitazioni sopra. Questo è la modalità predefinita.
- [Never](https://reference.aspose.com/slides/it/java/com.aspose.slides/zip64mode/#Never) non utilizza mai le estensioni del formato ZIP64.
- [Always](https://reference.aspose.com/slides/it/java/com.aspose.slides/zip64mode/#Always) utilizza sempre le estensioni del formato ZIP64.

Il codice seguente dimostra come salvare una presentazione come PPTX con le estensioni ZIP64 abilitate:

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Quando salvi con [Zip64Mode.Never](https://reference.aspose.com/slides/it/java/com.aspose.slides/zip64mode/#Never), viene lanciata una [PptxException](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptxexception/) se la presentazione non può essere salvata nel formato ZIP32.
{{% /alert %}}

## **Salva le presentazioni senza aggiornare la miniatura**

Il metodo [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) controlla la generazione della miniatura quando si salva una presentazione in PPTX:

- Se impostato a `true`, la miniatura viene aggiornata durante il salvataggio. Questo è il valore predefinito.
- Se impostato a `false`, la miniatura corrente viene preservata. Se la presentazione non ha una miniatura, non ne viene generata alcuna.

Nel codice seguente, la presentazione è salvata in PPTX senza aggiornare la sua miniatura.

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Questa opzione aiuta a ridurre il tempo necessario per salvare una presentazione in formato PPTX.
{{% /alert %}}

## **Salva gli aggiornamenti di progresso in percentuale**

L'interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprogresscallback/) viene utilizzata tramite il metodo `setProgressCallback` esposto dall'interfaccia [ISaveOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/isaveoptions/) e dalla classe astratta [SaveOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveoptions/). Assegna un'implementazione di [IProgressCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprogresscallback/) con `setProgressCallback` per ricevere aggiornamenti di avanzamento del salvataggio in percentuale.

I seguenti snippet di codice mostrano come usare `IProgressCallback`.

```java
ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Usa qui il valore percentuale di avanzamento.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose ha sviluppato un'app [gratuita PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) usando la propria API. L'app ti consente di dividere una presentazione in più file salvando le diapositive selezionate come nuovi file PPTX o PPT.
{{% /alert %}}

## **FAQ**

**Il "salvataggio rapido" (salvataggio incrementale) è supportato in modo che vengano scritte solo le modifiche?**

No. Il salvataggio crea l'intero file di destinazione ogni volta; il "salvataggio rapido" incrementale non è supportato.

**È sicuro da thread salvare la stessa istanza di Presentation da più thread?**

No. Un'istanza di [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) [non è thread‑safe](/slides/it/java/multithreading/); salvala da un singolo thread.

**Cosa succede ai collegamenti ipertestuali e ai file collegati esternamente durante il salvataggio?**

[I collegamenti ipertestuali](/slides/it/java/manage-hyperlinks/) sono conservati. I file collegati esternamente (ad esempio video tramite percorsi relativi) non vengono copiati automaticamente — assicurati che i percorsi di riferimento rimangano accessibili.

**Posso impostare/salvare i metadati del documento (Autore, Titolo, Azienda, Data)?**

Sì. Le [proprietà del documento](/slides/it/java/presentation-properties/) standard sono supportate e verranno scritte nel file al momento del salvataggio.