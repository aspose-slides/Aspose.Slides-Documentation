---
title: Salva presentazioni in .NET
linktitle: Salva presentazione
type: docs
weight: 80
url: /it/net/save-presentation/
keywords:
- salva PowerPoint
- salva OpenDocument
- salva presentazione
- salva diapositiva
- salva PPT
- salva PPTX
- salva ODP
- presentazione a file
- presentazione a stream
- tipo di visualizzazione predefinito
- Formato Strict Office Open XML
- modalità Zip64
- aggiornamento della miniatura
- avanzamento del salvataggio
- .NET
- C#
- Aspose.Slides
description: "Scopri come salvare le presentazioni in .NET usando Aspose.Slides—esporta in PowerPoint o OpenDocument mantenendo layout, caratteri ed effetti."
---
## **Panoramica**

[Open Presentations in C#](/slides/it/net/open-presentation/) descrive come utilizzare la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) per aprire una presentazione. Questo articolo spiega come creare e salvare presentazioni. La classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) contiene il contenuto di una presentazione. Che tu stia creando una presentazione da zero o modificando una esistente, dovrai salvarla al termine. Con Aspose.Slides per .NET, puoi salvare in un **file** o in **stream**. Questo articolo illustra i diversi modi per salvare una presentazione.

## **Salva presentazioni su file**

Salva una presentazione su file chiamando il metodo `Save` della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Passa il nome del file e il formato di salvataggio al metodo. L'esempio seguente mostra come salvare una presentazione con Aspose.Slides.

```cs
// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Esegui qualche operazione qui...

    // Salva la presentazione in un file.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Salva presentazioni su stream**

Puoi salvare una presentazione su stream passando uno stream di output al metodo `Save` della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Una presentazione può essere scritta su molti tipi di stream. Nell'esempio sottostante, creiamo una nuova presentazione e la salviamo su un file stream.

```cs
// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Salva la presentazione nello stream.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Salva presentazioni con un tipo di visualizzazione predefinito**

Aspose.Slides ti consente di impostare la visualizzazione iniziale che PowerPoint usa quando la presentazione generata viene aperta tramite la classe [ViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/). Imposta la proprietà [LastView](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/lastview/) su un valore dell'enumerazione [ViewType](https://reference.aspose.com/slides/it/net/aspose.slides/viewtype/).

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Salva presentazioni nel formato Strict Office Open XML**

Aspose.Slides ti consente di salvare una presentazione nel formato Strict Office Open XML. Usa la classe [PptxOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pptxoptions/) e imposta la sua proprietà `Conformance` al momento del salvataggio. Se imposti `Conformance.Iso29500_2008_Strict`, il file di output viene salvato nel formato Strict Office Open XML.

L'esempio sottostante crea una presentazione e la salva nel formato Strict Office Open XML.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Salva la presentazione nel formato Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Salva presentazioni in formato Office Open XML in modalità Zip64**

Un file Office Open XML è un archivio ZIP che impone limiti di 4 GB (2^32 byte) sulla dimensione non compressa di qualsiasi file, sulla dimensione compressa di qualsiasi file e sulla dimensione totale dell'archivio, e limita l'archivio a 65 535 (2^16‑1) file. Le estensioni del formato ZIP64 aumentano questi limiti a 2^64.

La proprietà [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipptxoptions/zip64mode/) ti consente di scegliere quando utilizzare le estensioni ZIP64 durante il salvataggio di un file Office Open XML.

Questa proprietà fornisce le seguenti modalità:

- `IfNecessary` usa le estensioni ZIP64 solo se la presentazione supera i limiti sopra indicati. È la modalità predefinita.
- `Never` non usa mai le estensioni ZIP64.
- `Always` usa sempre le estensioni ZIP64.

Il codice seguente dimostra come salvare una presentazione come file PPTX con le estensioni ZIP64 abilitate:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
Quando salvi con `Zip64Mode.Never`, viene generata un'eccezione [PptxException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxexception/) se la presentazione non può essere salvata in formato ZIP32.
{{% /alert %}}

## **Salva presentazioni in formato Office Open XML con livelli di compressione**

Quando lavori con presentazioni di grandi dimensioni, puoi regolare il livello di compressione per bilanciare la dimensione del file e il tempo di elaborazione. A seconda delle tue esigenze, potresti preferire una velocità di elaborazione maggiore o file di output più piccoli.

Aspose.Slides fornisce la proprietà [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipptxoptions/compressionlevel/), che consente di specificare il livello di compressione da utilizzare quando si salva una presentazione in formato Office Open XML.

I seguenti livelli di compressione sono disponibili:

- **None**: nessuna compressione. I file sono conservati così come sono.
- **Level1**: compressione più veloce con rapporto di compressione più basso.
- **Level2**: compressione più veloce con un rapporto leggermente migliore rispetto a **Level1**.
- **Level3**: fornisce una compressione migliore rispetto a **Level2** con un impatto moderato sul tempo di elaborazione.
- **Level4**: fornisce una compressione migliore rispetto a **Level3**.
- **Level5**: migliora la compressione rispetto a **Level4** con ulteriore tempo di elaborazione.
- **Level6**: compressione standard che offre un buon equilibrio tra velocità di elaborazione e dimensione del file. È il *livello di compressione predefinito*.
- **Level7**: fornisce una compressione migliore rispetto a **Level6** con elaborazione più lenta.
- **Level8**: fornisce una compressione migliore rispetto a **Level7**.
- **Level9**: compressione massima. Produce il file più piccolo al costo del tempo di elaborazione più lungo.

L'esempio seguente dimostra come salvare una presentazione come file PPTX *senza compressione*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Questo esempio mostra come salvare una presentazione come file PPTX con *compressione massima*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Salva presentazioni senza aggiornare la miniatura**

La proprietà [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) controlla la generazione della miniatura quando si salva una presentazione in PPTX:

- Se impostata a `true`, la miniatura viene aggiornata durante il salvataggio. È il valore predefinito.
- Se impostata a `false`, la miniatura corrente viene conservata. Se la presentazione non ha una miniatura, non ne viene generata alcuna.

Nel codice sotto, la presentazione viene salvata in PPTX senza aggiornare la sua miniatura.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Questa opzione aiuta a ridurre il tempo necessario per salvare una presentazione in formato PPTX.
{{% /alert %}}

## **Aggiornamenti di avanzamento del salvataggio in percentuale**

L'interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/net/aspose.slides/iprogresscallback/) è utilizzata tramite la proprietà `ProgressCallback` esposta dall'interfaccia [ISaveOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/isaveoptions/) e dalla classe astratta [SaveOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveoptions/). Assegna un'implementazione di [IProgressCallback](https://reference.aspose.com/slides/it/net/aspose.slides/iprogresscallback/) a `ProgressCallback` per ricevere aggiornamenti di avanzamento del salvataggio in percentuale.

I seguenti frammenti di codice mostrano come utilizzare `IProgressCallback`.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Usa il valore percentuale di avanzamento qui.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose ha sviluppato un'app [gratuita PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) che utilizza la propria API. L'app ti consente di dividere una presentazione in più file salvando le diapositive selezionate come nuovi file PPTX o PPT.
{{% /alert %}}

## **FAQ**

**È supportato il “salvataggio veloce” (salvataggio incrementale) in modo che vengano scritte solo le modifiche?**

No. Il salvataggio crea l'intero file di destinazione ogni volta; il “salvataggio veloce” incrementale non è supportato.

**È thread‑safe salvare la stessa istanza di Presentation da più thread?**

No. Un'istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) **non è thread‑safe** (/slides/it/net/multithreading/); salvala da un singolo thread.

** Cosa succede a collegamenti ipertestuali e file collegati esternamente durante il salvataggio?**

[Hyperlinks](/slides/it/net/manage-hyperlinks/) vengono preservati. I file collegati esternamente (ad es. video tramite percorsi relativi) non vengono copiati automaticamente: assicurati che i percorsi referenziati rimangano accessibili.

**Posso impostare/salvare i metadati del documento (Autore, Titolo, Azienda, Data)?**

Sì. Le [proprietà del documento](/slides/it/net/presentation-properties/) standard sono supportate e verranno scritte nel file al momento del salvataggio.