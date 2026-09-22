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
- Formato Strict Office Open XML
- modalità Zip64
- aggiornamento miniatura
- avanzamento salvataggio
- .NET
- C#
- Aspose.Slides
description: "Salva presentazioni PowerPoint e OpenDocument su file o stream in C# con Aspose.Slides per .NET, e configura l'output PPTX e la segnalazione dell'avanzamento."
---
## **Panoramica**

Dopo aver creato una presentazione o [apri una presentazione esistente](/slides/it/net/open-presentation/), utilizza il metodo [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) per scrivere il risultato. Aspose.Slides per .NET può salvare una presentazione in un file o stream nei formati PowerPoint, OpenDocument, PDF e altri. Le sezioni seguenti coprono le operazioni di salvataggio standard e le opzioni disponibili per l'output PPTX.

## **Salva presentazioni su file**

Per salvare una presentazione su un file, passa il percorso di output e un valore [SaveFormat](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/) al metodo [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/). Il valore del formato determina il tipo di file che Aspose.Slides crea.

Il seguente esempio crea una presentazione e la salva come file PPTX:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Salva presentazioni nel loro formato originale**

Per esempi di rilevamento di file e stream, il comportamento delle presentazioni appena create e la distinzione tra formati di origine e di destinazione, consulta [Determina il formato originale della presentazione](/slides/it/net/detect-presentation-source-format/).

In un'applicazione di elaborazione batch, il formato di input potrebbe non essere noto in anticipo. Dopo aver caricato un file, leggi il suo formato originale dalla proprietà [IPresentation.SourceFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/sourceformat/). Passa il valore [SourceFormat](https://reference.aspose.com/slides/it/net/aspose.slides/sourceformat/) risultante a [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil/tosaveformat/) per ottenere il valore corrispondente di [SaveFormat](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/), e quindi utilizza [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) per scrivere la presentazione modificata.

Il seguente esempio completo elabora ogni file in una directory di input, aggiorna il suo titolo e lo salva in una directory di output nel formato da cui è stato caricato:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/it/net/aspose.slides.util/slideutil/tosaveformat/) mappa PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP e PowerPoint XML ai rispettivi formati di salvataggio della presentazione. Mappa solo i formati di origine della presentazione; non è destinato a selezionare formati di esportazione come PDF, HTML, TIFF o immagini. Passare un valore [SourceFormat](https://reference.aspose.com/slides/it/net/aspose.slides/sourceformat/) non supportato o non valido genera un [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

I file legacy PPT, PPS e POT utilizzano lo stesso contenitore binario. Quando una tale presentazione viene caricata da uno stream senza estensione di file, un file PPS o POT può quindi essere identificato come PPT. Se è necessario preservare questi sottotipi legacy, conserva separatamente il nome file originale o i metadati del formato e usali quando scegli il nome file e il formato di output.

## **Salva presentazioni su stream**

Per scrivere una presentazione senza fare affidamento su un percorso file definitivo, passa un [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) scrivibile e un valore [SaveFormat](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/) al metodo [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/). Questo approccio è utile quando l'output deve essere restituito da un servizio web, memorizzato in un database o elaborato in memoria.

Il seguente esempio salva una nuova presentazione su uno stream file:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Salva presentazioni con un tipo di visualizzazione predefinito**

È possibile specificare la visualizzazione con cui PowerPoint apre inizialmente una presentazione salvata. Imposta la proprietà [ViewProperties.LastView](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/lastview/) su un valore [ViewType](https://reference.aspose.com/slides/it/net/aspose.slides/viewtype/) prima del salvataggio.

Il seguente esempio configura la visualizzazione Master delle diapositive come visualizzazione iniziale:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Salva presentazioni in formato Strict Office Open XML**

Per creare un file PPTX che conformi al profilo Strict di Office Open XML, crea un'istanza [PptxOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pptxoptions/) e imposta la sua proprietà [Conformance](https://reference.aspose.com/slides/it/net/aspose.slides.export/pptxoptions/conformance/) su `Conformance.Iso29500_2008_Strict`. Quindi passa le opzioni al metodo [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Salva presentazioni in formato Office Open XML in modalità Zip64**

Un archivio ZIP standard limita la dimensione compressa e non compressa di ogni voce, la dimensione totale dell'archivio e il numero di voci. Poiché un file PPTX è un archivio ZIP, una presentazione molto grande può superare tali limiti. Le estensioni ZIP64 aumentano i limiti di dimensione e di conteggio delle voci applicabili.

Usa la proprietà [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/it/net/aspose.slides.export/pptxoptions/zip64mode/) per controllare se Aspose.Slides scrive le estensioni ZIP64:

- `IfNecessary` utilizza ZIP64 solo quando la presentazione supera i limiti standard di ZIP. Questa è la modalità predefinita.
- `Never` disabilita le estensioni ZIP64.
- `Always` scrive sempre le estensioni ZIP64.

Il seguente esempio abilita sempre le estensioni ZIP64 per la presentazione di output:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
Se `Zip64Mode` è impostato su `Never` e la presentazione non può rientrare nei limiti standard di ZIP, l'operazione di salvataggio genera una [PptxException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Salva presentazioni in formato Office Open XML con livelli di compressione**

Per l'output PPTX, puoi bilanciare la velocità di salvataggio rispetto alle dimensioni del file impostando la proprietà [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/it/net/aspose.slides.export/pptxoptions/compressionlevel/). L'enumerazione [CompressionLevel](https://reference.aspose.com/slides/it/net/aspose.slides.export/compressionlevel/) fornisce questi valori:

- `None` archivia i dati senza compressione.
- `Level1` fornisce la compressione più veloce e l'output compresso più grande.
- `Level2` fino a `Level5` favoriscono progressivamente un output più piccolo rispetto alla velocità di salvataggio.
- `Level6` bilancia velocità di salvataggio e dimensione del file. Questo è il livello predefinito.
- `Level7` e `Level8` favoriscono ulteriormente un output più piccolo rispetto alla velocità di salvataggio.
- `Level9` fornisce la compressione più forte e richiede il maggior tempo di elaborazione.

Il seguente esempio salva una presentazione senza compressione:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

Il seguente esempio utilizza il livello di compressione massimo:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Salva presentazioni senza aggiornare la miniatura**

Quando una presentazione viene salvata come PPTX, la proprietà [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/it/net/aspose.slides.export/pptxoptions/refreshthumbnail/) controlla la miniatura del documento:

- `true` rigenera la miniatura durante l'operazione di salvataggio. Questo è il valore predefinito.
- `false` preserva la miniatura esistente. Se la presentazione non ha una miniatura, Aspose.Slides non ne genera una.

Il seguente esempio salva una presentazione senza aggiornare la sua miniatura:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
Disabilitare l'aggiornamento della miniatura può ridurre il tempo necessario per salvare un file PPTX.
{{% /alert %}}

## **Salva aggiornamenti di progresso in percentuale**

Per monitorare un'operazione di salvataggio, implementa l'interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/net/aspose.slides/iprogresscallback/) e assegna l'implementazione alla proprietà [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/it/net/aspose.slides.export/isaveoptions/progresscallback/). Aspose.Slides quindi chiama il metodo [IProgressCallback.Reporting](https://reference.aspose.com/slides/it/net/aspose.slides/iprogresscallback/reporting/) con i valori di progresso durante l'esportazione.

Il seguente esempio segnala il progresso di un'esportazione PDF sulla console:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose fornisce gratuitamente un [PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) costruito con l'API Aspose.Slides. Salva diapositive selezionate da una presentazione come file PPT o PPTX separati.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il salvataggio incrementale o “fast save”?**

No. Ogni operazione di salvataggio scrive un file di output completo anziché aggiornare solo le parti modificate.

**Possono più thread salvare la stessa istanza di Presentation?**

No. Un'istanza [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) [non è thread-safe](/slides/it/net/multithreading/). Accedi e salva ogni istanza da un solo thread alla volta.

**Cosa succede ai collegamenti ipertestuali e ai file collegati esternamente quando salvo una presentazione?**

[Hyperlinks](/slides/it/net/manage-hyperlinks/) rimangono nella presentazione. Aspose.Slides non copia i file collegati esternamente, quindi la presentazione salvata deve comunque essere in grado di accedere alle loro posizioni.

**Posso salvare i metadati del documento come autore, titolo, azienda e data di creazione?**

Sì. Imposta le appropriate [proprietà del documento](/slides/it/net/presentation-properties/) prima del salvataggio, e Aspose.Slides le scrive nel file di output.