---
title: Salva presentazioni su Android
linktitle: Salva presentazione
type: docs
weight: 80
url: /it/androidjava/save-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Salva presentazioni PowerPoint e OpenDocument su file o stream su Android con Aspose.Slides, e configura l'output PPTX e il reporting dell'avanzamento."
---
## **Panoramica**

Dopo aver creato una presentazione o [aperto una esistente](/slides/it/androidjava/open-presentation/), utilizza il metodo [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) per scrivere il risultato. Aspose.Slides per Android via Java può salvare una presentazione su file o stream in formati PowerPoint, OpenDocument, PDF e altri formati. Le sezioni seguenti illustrano le operazioni di salvataggio standard e le opzioni disponibili per l'output PPTX.

## **Salva le presentazioni su file**

Per salvare una presentazione su file, passa il percorso di output e un valore [SaveFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveformat/) al metodo [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Il valore del formato determina il tipo di file che Aspose.Slides crea.

L'esempio seguente crea una presentazione e la salva come file PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Aggiungi o modifica il contenuto della presentazione qui.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salva le presentazioni nel loro formato originale**

Per esempi di rilevamento di file e stream, il comportamento delle presentazioni appena create e la distinzione tra formati di origine e di output, vedere [Determina il formato della presentazione originale](/slides/it/androidjava/detect-presentation-source-format/).

In un'applicazione di elaborazione batch, il formato di input potrebbe non essere noto in anticipo. Dopo aver caricato un file, leggi il suo formato originale dal metodo [IPresentation.getSourceFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) . Passa il valore [SourceFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/sourceformat/) risultante a [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) per ottenere il corrispondente valore [SaveFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveformat/), e poi utilizza [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) per scrivere la presentazione modificata.

Il seguente esempio completo elabora tutti i file in una directory di input, aggiorna il titolo e lo salva in una directory di output nel formato da cui è stato caricato:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) mappa PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP e PowerPoint XML nei rispettivi formati di salvataggio della presentazione. Mappa solo i formati di origine della presentazione; non è destinato a selezionare formati di esportazione come PDF, HTML, TIFF o immagini. Passare un valore [SourceFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/sourceformat/) non supportato o non valido genera una [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException).

I file legacy PPT, PPS e POT utilizzano lo stesso contenitore binario. Quando una presentazione di questo tipo viene caricata da uno stream senza estensione, un file PPS o POT può quindi essere identificato come PPT. Se è necessario preservare questi sottotipi legacy, conserva separatamente il nome file originale o i metadati del formato e usali quando scegli il nome file e il formato di output.

## **Salva le presentazioni su stream**

Per scrivere una presentazione senza fare affidamento su un percorso file finale, passa un stream scrivibile e un valore [SaveFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveformat/) al metodo [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Questo approccio è utile quando l'output deve essere restituito da un servizio web, memorizzato in un database o elaborato in memoria.

Il seguente esempio salva una nuova presentazione su uno stream di file:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Salva le presentazioni con un tipo di visualizzazione predefinito**

Puoi specificare la visualizzazione con cui PowerPoint apre inizialmente una presentazione salvata. Usa il metodo [ViewProperties.setLastView](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) con un valore [ViewType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/viewtype/) prima del salvataggio.

Il seguente esempio imposta la visualizzazione Slide Master come visualizzazione iniziale:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salva le presentazioni nel formato Strict Office Open XML**

Per creare un file PPTX conforme al profilo Strict di Office Open XML, crea un'istanza [PptxOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pptxoptions/) e utilizza il suo metodo [setConformance](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) con [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict). Quindi passa le opzioni al metodo [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salva le presentazioni in formato Office Open XML in modalità Zip64**

Un archivio ZIP standard limita la dimensione compressa e non compressa di ogni voce, la dimensione totale dell'archivio e il numero di voci. Poiché un file PPTX è un archivio ZIP, una presentazione molto grande può superare tali limiti. Le estensioni ZIP64 aumentano i limiti di dimensione e di numero di voci applicabili.

Usa il metodo [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) per controllare se Aspose.Slides scrive le estensioni ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/zip64mode/#IfNecessary) usa ZIP64 solo quando la presentazione supera i limiti ZIP standard. Questa è la modalità predefinita.
- [Never](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/zip64mode/#Never) disabilita le estensioni ZIP64.
- [Always](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/zip64mode/#Always) scrive sempre le estensioni ZIP64.

Il seguente esempio abilita sempre le estensioni ZIP64 per la presentazione di output:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Se viene usato [Zip64Mode.Never](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/zip64mode/#Never), e la presentazione non può rientrare nei limiti ZIP standard, l'operazione di salvataggio genera una [PptxException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Salva le presentazioni in formato Office Open XML con livelli di compressione**

Per l'output PPTX, è possibile bilanciare velocità di salvataggio e dimensione del file usando il metodo [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-). La classe [CompressionLevel](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compressionlevel/) fornisce questi valori:

- [None](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compressionlevel/#None) memorizza i dati senza compressione.
- [Level1](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compressionlevel/#Level1) fornisce la compressione più veloce e l'output compresso più grande.
- [Level2](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compressionlevel/#Level2) fino a [Level5](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compressionlevel/#Level5) favoriscono progressivamente un output più piccolo rispetto alla velocità di salvataggio.
- [Level6](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compressionlevel/#Level6) bilancia velocità di salvataggio e dimensione del file. Questo è il livello predefinito.
- [Level7](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compressionlevel/#Level7) e [Level8](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compressionlevel/#Level8) favoriscono ulteriormente un output più piccolo rispetto alla velocità di salvataggio.
- [Level9](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compressionlevel/#Level9) fornisce la compressione più forte e richiede più tempo di elaborazione.

Il seguente esempio salva una presentazione senza compressione:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Il seguente esempio usa il livello di compressione massimo:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salva le presentazioni senza aggiornare la miniatura**

Quando una presentazione viene salvata come PPTX, il metodo [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) controlla la miniatura del documento:

- `true` rigenera la miniatura durante l'operazione di salvataggio. Questo è il valore predefinito.
- `false` conserva la miniatura esistente. Se la presentazione non ha una miniatura, Aspose.Slides non ne genera una.

Il seguente esempio salva una presentazione senza aggiornare la sua miniatura:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Disabilitare l'aggiornamento della miniatura può ridurre il tempo necessario per salvare un file PPTX.
{{% /alert %}}

## **Salva gli aggiornamenti di avanzamento in percentuale**

Per monitorare un'operazione di salvataggio, implementa l'interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iprogresscallback/) e passa l'implementazione al metodo [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-). Aspose.Slides quindi chiama il metodo [IProgressCallback.reporting](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) con i valori di avanzamento durante l'esportazione.

Il seguente esempio segnala l'avanzamento di un'esportazione PDF sulla console:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose offre un [PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) gratuito, costruito con l'API Aspose.Slides. Salva le diapositive selezionate da una presentazione come file PPT o PPTX separati.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il salvataggio incrementale o “fast save”?**

No. Ogni operazione di salvataggio scrive un file di output completo anziché aggiornare solo le parti modificate.

**È possibile che più thread salvino la stessa istanza di Presentation?**

No. Un'istanza [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) [non è thread-safe](/slides/it/androidjava/multithreading/). Accedi e salva ogni istanza da un solo thread alla volta.

**Cosa succede ai collegamenti ipertestuali e ai file collegati esternamente quando salvo una presentazione?**

[Hyperlinks](/slides/it/androidjava/manage-hyperlinks/) rimangono nella presentazione. Aspose.Slides non copia i file collegati esternamente, quindi la presentazione salvata deve comunque poter accedere alle loro posizioni.

**Posso salvare i metadati del documento come autore, titolo, azienda e data di creazione?**

Sì. Imposta le appropriate [document properties](/slides/it/androidjava/presentation-properties/) prima del salvataggio, e Aspose.Slides le scrive nel file di output.