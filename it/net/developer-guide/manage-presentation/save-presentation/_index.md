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
- presentazione su file
- presentazione su stream
- tipo di visualizzazione predefinito
- formato Strict Office Open XML
- modalità Zip64
- aggiornamento miniatura
- salvataggio avanzamento
- .NET
- C#
- Aspose.Slides
description: "Scopri come salvare presentazioni in .NET usando Aspose.Slides—esporta in PowerPowerPoint o OpenDocument mantenendo layout, caratteri ed effetti."
---
## **Panoramica**

[Open Presentations in C#](/slides/it/net/open-presentation/) descrive come utilizzare la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) per aprire una presentazione. Questo articolo spiega come creare e salvare le presentazioni. La classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) contiene il contenuto di una presentazione. Che tu stia creando una presentazione da zero o modificando una esistente, vorrai salvarla una volta terminato. Con Aspose.Slides per .NET, puoi salvare su un **file** o su **stream**. Questo articolo spiega i diversi modi per salvare una presentazione.

## **Salva presentazioni su file**

Salva una presentazione su file chiamando il metodo `Save` della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Passa il nome del file e il formato di salvataggio al metodo. L'esempio seguente mostra come salvare una presentazione con Aspose.Slides.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Esegui qualche operazione qui...

    // Salva la presentazione su un file.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Salva presentazioni su stream**

Puoi salvare una presentazione su uno stream passando uno stream di output al metodo `Save` della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Una presentazione può essere scritta su molti tipi di stream. Nell'esempio seguente, creiamo una nuova presentazione e la salviamo su un file stream.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Salva la presentazione sullo stream.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Salva presentazioni con un tipo di visualizzazione predefinito**

Aspose.Slides consente di impostare la visualizzazione iniziale che PowerPoint utilizza quando la presentazione generata viene aperta tramite la classe [ViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/). Imposta la proprietà [LastView](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/lastview/) a un valore dell'enumerazione [ViewType](https://reference.aspose.com/slides/it/net/aspose.slides/viewtype/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Salva presentazioni nel formato Strict Office Open XML**

Aspose.Slides consente di salvare una presentazione nel formato Strict Office Open XML. Usa la classe [PptxOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pptxoptions/) e imposta la sua proprietà conformance al momento del salvataggio. Se imposti `Conformance.Iso29500_2008_Strict`, il file di output viene salvato nel formato Strict Office Open XML.

L'esempio seguente crea una presentazione e la salva nel formato Strict Office Open XML.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Salva la presentazione nel formato Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Salva presentazioni nel formato Office Open XML in modalità Zip64**

Un file Office Open XML è un archivio ZIP che impone limiti di 4 GB (2^32 byte) sulla dimensione non compressa di qualsiasi file, sulla dimensione compressa di qualsiasi file e sulla dimensione totale dell'archivio, e limita inoltre l'archivio a 65 535 (2^16‑1) file. Le estensioni del formato ZIP64 aumentano questi limiti a 2^64.

La proprietà [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipptxoptions/zip64mode/) consente di scegliere quando utilizzare le estensioni del formato ZIP64 durante il salvataggio di un file Office Open XML.

Questa proprietà fornisce le seguenti modalità:

- `IfNecessary` utilizza le estensioni del formato ZIP64 solo se la presentazione supera le limitazioni sopra indicate. Questa è la modalità predefinita.
- `Never` non utilizza mai le estensioni del formato ZIP64.
- `Always` utilizza sempre le estensioni del formato ZIP64.

Il codice seguente dimostra come salvare una presentazione come file PPTX con le estensioni del formato ZIP64 abilitate:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
Quando salvi con `Zip64Mode.Never`, viene generata un'eccezione [PptxException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxexception/) se la presentazione non può essere salvata nel formato ZIP32.
{{% /alert %}}

## **Salva presentazioni nel formato Office Open XML con livelli di compressione**

Quando lavori con presentazioni di grandi dimensioni, puoi regolare il livello di compressione per bilanciare le dimensioni del file e il tempo di elaborazione. A seconda delle tue esigenze, potresti preferire un'elaborazione più veloce o file di output più piccoli.

Aspose.Slides fornisce la proprietà [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipptxoptions/compressionlevel/), che consente di specificare il livello di compressione usato quando si salva una presentazione nel formato Office Open XML.

Sono disponibili i seguenti livelli di compressione:

- **None**: Nessuna compressione applicata. I file sono conservati così come sono.
- **Level1**: La compressione più veloce con il rapporto di compressione più basso.
- **Level2**: Compressione più veloce con un rapporto di compressione leggermente migliore rispetto a **Level1**.
- **Level3**: Fornisce una compressione migliore rispetto a **Level2** con un impatto moderato sul tempo di elaborazione.
- **Level4**: Fornisce una compressione migliore rispetto a **Level3**.
- **Level5**: Fornisce una compressione migliorata rispetto a **Level4** con tempo di elaborazione aggiuntivo.
- **Level6**: Compressione standard che offre un buon equilibrio tra velocità di elaborazione e dimensione del file. Questo è il *livello di compressione predefinito*.
- **Level7**: Fornisce una compressione migliore rispetto a **Level6** con elaborazione più lenta.
- **Level8**: Fornisce una compressione migliore rispetto a **Level7**.
- **Level9**: Compressione massima. Produce la dimensione di file più piccola al prezzo del tempo di elaborazione più lungo.

L'esempio seguente dimostra come salvare una presentazione come file PPTX *senza compressione*:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Salva presentazioni senza aggiornare la miniatura**

La proprietà [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) controlla la generazione della miniatura durante il salvataggio di una presentazione in PPTX:

- Se impostata su `true`, la miniatura viene aggiornate durante il salvataggio. Questo è il valore predefinito.
- Se impostata su `false`, la miniatura corrente viene preservata. Se la presentazione non ha una miniatura, non ne viene generata alcuna.

Nel codice seguente, la presentazione viene salvata in PPTX senza aggiornare la sua miniatura.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Questa opzione aiuta a ridurre il tempo necessario per salvare una presentazione nel formato PPTX.
{{% /alert %}}

## **Salva aggiornamenti di progresso in percentuale**

L'interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/net/aspose.slides/iprogresscallback/) è utilizzata tramite la proprietà `ProgressCallback` esposta dall'interfaccia [ISaveOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/isaveoptions/) e dalla classe astratta [SaveOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveoptions/). Assegna un'implementazione di [IProgressCallback](https://reference.aspose.com/slides/it/net/aspose.slides/iprogresscallback/) a `ProgressCallback` per ricevere aggiornamenti sul progresso del salvataggio in percentuale.

I seguenti frammenti di codice mostrano come utilizzare `IProgressCallback`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Usa il valore della percentuale di progresso qui.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose ha sviluppato una [app gratuita PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) utilizzando la propria API. L'app consente di dividere una presentazione in più file salvando le diapositive selezionate come nuovi file PPTX o PPT.
{{% /alert %}}

## **FAQ**

**Il “salvataggio rapido” (salvataggio incrementale) è supportato in modo che vengano scritte solo le modifiche?**

No. Il salvataggio crea l'intero file di destinazione ogni volta; il “salvataggio rapido” incrementale non è supportato.

**È thread‑safe salvare la stessa istanza di Presentation da più thread?**

No. Un'istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) **non è thread‑safe** (/slides/it/net/multithreading/); salvala da un singolo thread.

**Cosa succede a collegamenti ipertestuali e file collegati esternamente durante il salvataggio?**

[Ipertestuali](/slides/it/net/manage-hyperlinks/) vengono preservati. I file collegati esternamente (ad es. video tramite percorsi relativi) non vengono copiati automaticamente – assicurati che i percorsi di riferimento rimangano accessibili.

**Posso impostare/salvare i metadati del documento (Autore, Titolo, Azienda, Data)?**

Sì. Le [proprietà del documento](/slides/it/net/presentation-properties/) standard sono supportate e verranno scritte nel file al salvataggio.