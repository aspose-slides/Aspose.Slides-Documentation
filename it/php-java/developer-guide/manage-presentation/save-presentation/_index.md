---
title: Salva presentazioni in PHP
linktitle: Salva presentazione
type: docs
weight: 80
url: /it/php-java/save-presentation/
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
- formato Strict Office Open XML
- modalità Zip64
- aggiornamento miniatura
- progresso di salvataggio
- PHP
- Aspose.Slides
description: "Scopri come salvare le presentazioni usando Aspose.Slides per PHP tramite Java — esporta in PowerPoint o OpenDocument mantenendo layout, caratteri e effetti."
---
## **Panoramica**

[Apri le presentazioni in PHP](/slides/it/php-java/open-presentation/) descrive come utilizzare la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) per aprire una presentazione. Questo articolo spiega come creare e salvare presentazioni. La classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) contiene il contenuto di una presentazione. Che tu stia creando una presentazione da zero o modificandone una esistente, vorrai salvarla quando hai finito. Con Aspose.Slides per PHP, puoi salvare in un **file** o **stream**. Questo articolo spiega i diversi modi per salvare una presentazione.

## **Salva presentazioni su file**

Salva una presentazione su un file chiamando il metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/). Passa il nome del file e il formato di salvataggio al metodo. L'esempio seguente mostra come salvare una presentazione con Aspose.Slides.

```php
// Instanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Esegui del lavoro qui...

    // Salva la presentazione su un file.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Salva presentazioni su stream**

Puoi salvare una presentazione su uno stream passando uno stream di output al metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/). Una presentazione può essere scritta su molti tipi di stream. Nell'esempio seguente, creiamo una nuova presentazione e la salviamo su uno stream di file.

```php
// Instanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Salva la presentazione sullo stream.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Salva presentazioni con un tipo di visualizzazione predefinito**

Aspose.Slides ti consente di impostare la visualizzazione iniziale che PowerPoint usa quando la presentazione generata viene aperta tramite la classe [ViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/). Usa il metodo [setLastView](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/#setLastView) con un valore dell'enumerazione [ViewType](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewtype/).

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Salva presentazioni nel formato Strict Office Open XML**

Aspose.Slides ti consente di salvare una presentazione nel formato Strict Office Open XML. Usa la classe [PptxOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxoptions/) e imposta la sua proprietà conformance durante il salvataggio. Se imposti [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/it/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), il file di output viene salvato nel formato Strict Office Open XML.

L'esempio seguente crea una presentazione e la salva nel formato Strict Office Open XML.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Instanzia la classe Presentation che rappresenta un file di presentazione.
$presentation = new Presentation();
try {
    // Salva la presentazione nel formato Strict Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Salva presentazioni in formato Office Open XML in modalità Zip64**

Un file Office Open XML è un archivio ZIP che impone limiti di 4 GB (2^32 byte) sulla dimensione non compressa di qualsiasi file, sulla dimensione compressa di qualsiasi file e sulla dimensione totale dell'archivio, e limita inoltre l'archivio a 65.535 (2^16‑1) file. Le estensioni del formato ZIP64 aumentano questi limiti a 2^64.

Il metodo [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxoptions/#setZip64Mode) ti consente di scegliere quando utilizzare le estensioni del formato ZIP64 durante il salvataggio di un file Office Open XML.

Questo metodo può essere usato con le seguenti modalità:

- [IfNecessary](https://reference.aspose.com/slides/it/php-java/aspose.slides/zip64mode/#IfNecessary) utilizza le estensioni del formato ZIP64 solo se la presentazione supera le limitazioni sopra. Questa è la modalità predefinita.
- [Never](https://reference.aspose.com/slides/it/php-java/aspose.slides/zip64mode/#Never) non utilizza mai le estensioni del formato ZIP64.
- [Always](https://reference.aspose.com/slides/it/php-java/aspose.slides/zip64mode/#Always) utilizza sempre le estensioni del formato ZIP64.

Il codice seguente dimostra come salvare una presentazione come PPTX con le estensioni del formato ZIP64 abilitate:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Quando salvi con [Zip64Mode.Never](https://reference.aspose.com/slides/it/php-java/aspose.slides/zip64mode/#Never), viene sollevata una [PptxException](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxexception/) se la presentazione non può essere salvata nel formato ZIP32.
{{% /alert %}}

## **Salva presentazioni senza aggiornare la miniatura**

Il metodo [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controlla la generazione della miniatura quando si salva una presentazione in PPTX:

- Se impostato su `true`, la miniatura viene aggiornata durante il salvataggio. Questa è l'impostazione predefinita.
- Se impostato su `false`, la miniatura corrente viene preservata. Se la presentazione non ha una miniatura, non ne viene generata alcuna.

Nel codice seguente, la presentazione viene salvata in PPTX senza aggiornare la sua miniatura.

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Questa opzione aiuta a ridurre il tempo necessario per salvare una presentazione in formato PPTX.
{{% /alert %}}

## **Salva aggiornamenti di avanzamento in percentuale**

Il reporting del salvataggio avanzato è configurato tramite il metodo [setProgressCallback](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveoptions/#setProgressCallback) su [SaveOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveoptions/) e le sue sottoclassi. Fornisci un proxy Java che implementi l'interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprogresscallback/); durante l'esportazione, il callback riceve aggiornamenti percentuali periodici.

I seguenti frammenti di codice mostrano come usare `IProgressCallback`.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Usa il valore percentuale di avanzamento qui.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose ha sviluppato un'applicazione gratuita [PowerPoint Splitter app](https://products.aspose.app/slides/it/splitter) che utilizza la propria API. L'app consente di dividere una presentazione in più file salvando le diapositive selezionate come nuovi file PPTX o PPT.
{{% /alert %}}

## **FAQ**

**È supportato il "fast save" (salvataggio incrementale) in modo che vengano scritte solo le modifiche?**

No. Il salvataggio crea il file di destinazione completo ogni volta; il salvataggio incrementale "fast save" non è supportato.

**È thread‑safe salvare la stessa istanza di Presentation da più thread?**

No. Un'istanza di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) [non è thread‑safe](/slides/it/php-java/multithreading/); salvala da un unico thread.

**Cosa succede ai collegamenti ipertestuali e ai file collegati esternamente durante il salvataggio?**

[Hyperlinks](/slides/it/php-java/manage-hyperlinks/) vengono preservati. I file collegati esternamente (ad esempio video tramite percorsi relativi) non vengono copiati automaticamente — assicurati che i percorsi di riferimento rimangano accessibili.

**Posso impostare/salvare i metadati del documento (Autore, Titolo, Azienda, Data)?**

Sì. Le [document properties](/slides/it/php-java/presentation-properties/) standard sono supportate e verranno scritte nel file al salvataggio.