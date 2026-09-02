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
- salvataggio avanzamento
- Android
- Java
- Aspose.Slides
description: "Scopri come salvare le presentazioni in Java usando Aspose.Slides per Android—esporta in PowerPoint o OpenDocument mantenendo layout, caratteri ed effetti."
---
## **Panoramica**

[Open Presentations on Android](/slides/it/androidjava/open-presentation/) descrive come utilizzare la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) per aprire una presentazione. Questo articolo spiega come creare e salvare presentazioni. La classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) contiene il contenuto di una presentazione. Che tu stia creando una presentazione da zero o modificando una esistente, vorrai salvarla quando hai finito. Con Aspose.Slides per Android, puoi salvare in un **file** o **stream**. Questo articolo spiega i diversi modi per salvare una presentazione.

## **Salvare le presentazioni su file**

Salva una presentazione su un file chiamando il metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/). Passa il nome del file e il formato di salvataggio al metodo. Il seguente esempio mostra come salvare una presentazione con Aspose.Slides.

```java
import com.aspose.slides.*;

// Instanzia la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Esegui qualche operazione qui...

    // Salva la presentazione su un file.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvare le presentazioni su stream**

Puoi salvare una presentazione su uno stream passando un output stream al metodo `save` della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/). Una presentazione può essere scritta su molti tipi di stream. Nel seguente esempio, creiamo una nuova presentazione e la salviamo su uno stream file.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Instanzia la classe Presentation che rappresenta un file di presentazione.
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

## **Salvare le presentazioni con un tipo di visualizzazione predefinito**

Aspose.Slides consente di impostare la visualizzazione iniziale che PowerPoint utilizza quando la presentazione generata viene aperta tramite la classe [ViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/viewproperties/). Usa il metodo [setLastView](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) con un valore dell'enumerazione [ViewType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/viewtype/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Salvare le presentazioni nel formato Strict Office Open XML**

Aspose.Slides consente di salvare una presentazione nel formato Strict Office Open XML. Usa la classe [PptxOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pptxoptions/) e imposta la sua proprietà conformance durante il salvataggio. Se imposti [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), il file di output viene salvato nel formato Strict Office Open XML.

Il seguente esempio crea una presentazione e la salva nel formato Strict Office Open XML.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Instanzia la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Salva la presentazione nel formato Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Salvare le presentazioni nel formato Office Open XML in modalità Zip64**

Un file Office Open XML è un archivio ZIP che impone limiti di 4 GB (2^32 byte) sulla dimensione non compressa di qualsiasi file, sulla dimensione compressa di qualsiasi file e sulla dimensione totale dell'archivio, limitando inoltre l'archivio a 65.535 (2^16‑1) file. Le estensioni del formato ZIP64 aumentano questi limiti a 2^64.

Il metodo [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) consente di scegliere quando utilizzare le estensioni del formato ZIP64 durante il salvataggio di un file Office Open XML.

Questo metodo può essere utilizzato con le seguenti modalità:

- [IfNecessary](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/zip64mode/#IfNecessary) utilizza le estensioni del formato ZIP64 solo se la presentazione supera le limitazioni sopra. Questa è la modalità predefinita.
- [Never](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/zip64mode/#Never) non utilizza mai le estensioni del formato ZIP64.
- [Always](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/zip64mode/#Always) utilizza sempre le estensioni del formato ZIP64.

Il codice seguente dimostra come salvare una presentazione come file PPTX con le estensioni del formato ZIP64 abilitate:

```java
import com.aspose.slides.*;

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
Quando salvi con [Zip64Mode.Never](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/zip64mode/#Never), viene sollevata una [PptxException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pptxexception/) se la presentazione non può essere salvata in formato ZIP32.
{{% /alert %}}

## **Salvare le presentazioni nel formato Office Open XML con livelli di compressione**

Quando lavori con presentazioni di grandi dimensioni, puoi regolare il livello di compressione per bilanciare la dimensione del file e il tempo di elaborazione. A seconda delle tue esigenze, potresti preferire un'elaborazione più rapida o file di output più piccoli.

Aspose.Slides fornisce il metodo [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) , che consente di specificare il livello di compressione usato quando si salva una presentazione nel formato Office Open XML.

I livelli di compressione disponibili sono:

- **None**: Nessuna compressione è applicata. I file sono memorizzati così come sono.
- **Level1**: Compressione più veloce con il più basso rapporto di compressione.
- **Level2**: Compressione più veloce con un rapporto di compressione leggermente migliore rispetto a **Level1**.
- **Level3**: Fornisce una compressione migliore rispetto a **Level2** con un impatto moderato sul tempo di elaborazione.
- **Level4**: Fornisce una compressione migliore rispetto a **Level3**.
- **Level5**: Fornisce una compressione migliorata rispetto a **Level4** con tempo di elaborazione aggiuntivo.
- **Level6**: Compressione standard che offre un buon equilibrio tra velocità di elaborazione e dimensione del file. Questo è il *livello di compressione predefinito*.
- **Level7**: Fornisce una compressione migliore rispetto a **Level6** con elaborazione più lenta.
- **Level8**: Fornisce una compressione migliore rispetto a **Level7**.
- **Level9**: Compressione massima. Produce la dimensione di file più piccola al costo del tempo di elaborazione più lungo.

Il seguente esempio dimostra come salvare una presentazione come file PPTX *senza compressione*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Questo esempio mostra come salvare una presentazione come file PPTX con *compressione massima*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Salvare le presentazioni senza aggiornare la miniatura**

Il metodo [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) controlla la generazione della miniatura quando si salva una presentazione in PPTX:

- Se impostato a `true`, la miniatura è aggiornata durante il salvataggio. È l'impostazione predefinita.
- Se impostato a `false`, la miniatura corrente è conservata. Se la presentazione non ha miniatura, non ne viene generata.

Nel codice seguente, la presentazione è salvata in PPTX senza aggiornare la sua miniatura.

```java
import com.aspose.slides.*;

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

## **Salvare gli aggiornamenti di avanzamento in percentuale**

L'interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iprogresscallback/) è usata tramite il metodo `setProgressCallback` esposto dall'interfaccia [ISaveOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/isaveoptions/) e dalla classe astratta [SaveOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveoptions/). Assegna un'implementazione di [IProgressCallback](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iprogresscallback/) con `setProgressCallback` per ricevere aggiornamenti sul progresso del salvataggio in percentuale.

Il seguente frammento di codice mostra come utilizzare `IProgressCallback`.

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Utilizza qui il valore percentuale di avanzamento.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose ha sviluppato una [app gratuita PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) usando la propria API. L'app ti consente di dividere una presentazione in più file salvando le diapositive selezionate come nuovi file PPTX o PPT.
{{% /alert %}}

## **FAQ**

**Il "fast save" (salvataggio incrementale) è supportato in modo che vengano scritte solo le modifiche?**

No. Il salvataggio crea l'intero file di destinazione ogni volta; il "fast save" incrementale non è supportato.

**È thread‑safe salvare la stessa istanza di Presentation da più thread?**

No. Un'istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) [non è thread‑safe](/slides/it/androidjava/multithreading/); salvala da un singolo thread.

**Cosa succede ai collegamenti ipertestuali e ai file collegati esternamente durante il salvataggio?**

[Hyperlinks](/slides/it/androidjava/manage-hyperlinks/) vengono preservati. I file collegati esternamente (ad es., video tramite percorsi relativi) non vengono copiati automaticamente — assicurati che i percorsi di riferimento rimangano accessibili.

**Posso impostare/salvare i metadati del documento (Autore, Titolo, Azienda, Data)?**

Sì. Le [proprietà del documento](/slides/it/androidjava/presentation-properties/) standard sono supportate e verranno scritte nel file al momento del salvataggio.