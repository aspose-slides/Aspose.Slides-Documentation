---
title: Recupera e Aggiorna le Informazioni della Presentazione in .NET
linktitle: Informazioni sulla Presentazione
type: docs
weight: 30
url: /it/net/examine-presentation/
keywords:
- formato della presentazione
- proprietà della presentazione
- proprietà del documento
- ottenere proprietà
- leggere proprietà
- cambiare proprietà
- modificare proprietà
- aggiornare proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument usando .NET per ottenere informazioni più rapide e audit dei contenuti più intelligenti."
---
## **Panoramica**

Aspose.Slides può identificare il formato di una presentazione e leggere i metadati del documento senza creare un modello completo di oggetti della presentazione. Questo è utile quando è necessario classificare i file, creare un inventario o ispezionare le proprietà prima di decidere se caricare ed elaborare il contenuto della presentazione.

Questo articolo dimostra l'ispezione leggera mediante [PresentationFactory](https://reference.aspose.com/slides/it/net/aspose.slides/presentationfactory/) e [IPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/), nonché aggiornamenti mirati tramite [IDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/).

## **Controllare il formato di una presentazione**

Utilizza [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/presentationfactory/getpresentationinfo/) per ispezionare un file senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). La proprietà [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/loadformat/) restituisce il formato rilevato, ad esempio PPTX, PPT o ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Creare un inventario leggero delle presentazioni**

Quando elabori molti file di presentazione, potresti aver bisogno di un inventario compatto per la convalida, l'indicizzazione o un sistema di gestione dei documenti. In questo scenario, utilizza [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/presentationfactory/getpresentationinfo/) per ottenere un oggetto [IPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/), quindi chiama [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/readdocumentproperties/) per leggere i metadati del documento. Questo approccio non crea un'istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) né richiede di attraversare l'intero modello di oggetti della presentazione.

Le proprietà estese esposte da [IDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/) forniscono i seguenti valori dell'inventario:

| Proprietà | Valore dell'inventario |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/slides/it/) | Numero totale di diapositive. |
| [HiddenSlides](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/hiddenslides/) | Numero di diapositive nascoste. |
| [Notes](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/notes/) | Numero di diapositive che contengono note. |
| [Paragraphs](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/paragraphs/) | Numero totale di paragrafi, se disponibili. |
| [Words](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/words/) | Numero totale di parole. |
| [MultimediaClips](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/multimediaclips/) | Numero totale di clip audio e video. |

Il seguente esempio legge questi valori senza creare un oggetto [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e stampa un inventario compatto. Combina inoltre [HeadingPairs](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/headingpairs/) con [TitlesOfParts](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/titlesofparts/) per visualizzare gruppi di contenuti come font, temi e titoli delle diapositive.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Ogni [IHeadingPair](https://reference.aspose.com/slides/it/net/aspose.slides/iheadingpair/) fornisce un nome di gruppo e il numero di elementi in quel gruppo. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/titlesofparts/) è un array piatto e ordinato, quindi occorre consumare il numero di titoli consecutivi specificati da ciascuna coppia di intestazioni.

### **Metadati archiviati e limitazioni del formato**

Le proprietà dell'inventario restituite da [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/readdocumentproperties/) riflettono i metadati disponibili nel documento sorgente. Aspose.Slides non carica e attraversa il modello di oggetti della presentazione per ricalcolare questi valori per questa chiamata. Le proprietà mancanti sono rappresentate con valori predefiniti e i valori archiviati possono essere obsoleti se l'applicazione che ha salvato per ultima il file non ha aggiornato le sue proprietà del documento.

- **PPTX:** Il formato fornisce proprietà di documento estese per conteggi di diapositive, note, diapositive nascoste, paragrafi, parole e contenuti multimediali, nonché coppie di intestazioni e titoli di parti. La disponibilità dipende da quali proprietà sono state scritte dal produttore del documento.
- **PPT:** Il formato binario può memorizzare le corrispondenti proprietà di riepilogo del documento. Se una proprietà è assente o non è stata aggiornata dal produttore del documento, Aspose.Slides restituisce il valore archiviato o predefinito invece di calcolarlo dalle diapositive.
- **ODP:** I metadati OpenDocument forniscono statistiche generali del documento, come conteggi di pagine, paragrafi e parole, ma questi valori non corrispondono a tutte le proprietà estese specifiche di PowerPoint. I metadati di diapositive nascoste, note, contenuti multimediali, coppie di intestazioni e titoli di parti potrebbero non essere disponibili e le proprietà dell'inventario potrebbero restituire valori predefiniti. Non considerare un valore zero o un array vuoto come prova autorevole dell'assenza del contenuto corrispondente.

Utilizza l'approccio ai metadati leggeri per inventari e controlli preliminari. Carica la presentazione e ispeziona il suo modello di oggetti in tempo reale quando il risultato deve riflettere le modifiche in memoria o quando è necessario verificare il contenuto effettivo della presentazione.

## **Aggiornare le proprietà della presentazione**

Le proprietà restituite da [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/readdocumentproperties/) possono essere modificate anche senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Applica le modifiche con [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) e quindi scrivi la presentazione associata con [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

L'immagine seguente mostra le proprietà originali del documento.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

Il seguente esempio modifica il titolo e l'ora dell'ultimo salvataggio e scrive il risultato in un nuovo file:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

L'immagine seguente mostra le proprietà del documento aggiornate.

![Proprietà del documento della presentazione PowerPoint modificate](output_properties.png)

## **Link utili**

Per controlli di sicurezza correlati e impostazioni di protezione, vedere i seguenti articoli:

- [Presentazioni protette da password](/slides/it/net/password-protected-presentation/)
- [Presentazioni protette in scrittura](/slides/it/net/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i caratteri sono incorporati e quali sono?**

Carica la presentazione e utilizza [Presentation.FontsManager](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/fontsmanager/). Chiama [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getembeddedfonts/) per ottenere i caratteri incorporati e [FontsManager.GetFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getfonts/) per ottenere i caratteri utilizzati dalla presentazione. Confronta i due risultati per individuare i caratteri necessari per il rendering ma non incorporati.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Quando i metadati del documento memorizzati sono sufficienti, leggi [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/it/net/aspose.slides/idocumentproperties/hiddenslides/) tramite [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/presentationfactory/getpresentationinfo/) e [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentationinfo/readdocumentproperties/). Questo è adatto per un inventario leggero. Se la presentazione è stata modificata in memoria, i metadati memorizzati potrebbero mancare o essere obsoleti, o se è necessario verificare i valori in tempo reale, itera attraverso [Presentation.Slides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slides/it/) e ispeziona la proprietà [Slide.Hidden](https://reference.aspose.com/slides/it/net/aspose.slides/slide/hidden/) di ciascuna diapositiva.

**Posso rilevare se viene utilizzata una dimensione e un orientamento personalizzati della diapositiva e se differiscono dalle impostazioni predefinite?**

Sì. Carica la presentazione e leggi [Presentation.SlideSize](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slidesize/). Ispeziona [ISlideSize.Type](https://reference.aspose.com/slides/it/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/it/net/aspose.slides/islidesize/size/), e [ISlideSize.Orientation](https://reference.aspose.com/slides/it/net/aspose.slides/islidesize/orientation/) per confrontare le impostazioni attuali con il preset e le dimensioni previste.

**Esiste un modo rapido per verificare se i grafici fanno riferimento a sorgenti dati esterne?**

Sì. Individua ogni [Chart](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chart/) e ispeziona [ChartData.DataSourceType](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/datasourcetype/). Per una cartella di lavoro esterna, leggi [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/externalworkbookpath/). Il tipo di sorgente dati e il percorso identificano un riferimento esterno, ma la verifica della disponibilità del target richiede un controllo delle risorse separato.

**Come posso valutare le diapositive 'pesanti' che potrebbero rallentare il rendering o l'esportazione in PDF?**

Non esiste un'unica proprietà di complessità. Attraversa [Presentation.Slides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slides/it/) e la collezione [IBaseSlide.Shapes](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/shapes/) di ciascuna diapositiva. Usa il conteggio delle forme e la presenza di immagini di grandi dimensioni, effetti, animazioni o contenuti multimediali come segnali di screening, e misura un rendering o un'esportazione rappresentativa prima di considerare una diapositiva come un collo di bottiglia di prestazioni confermato.