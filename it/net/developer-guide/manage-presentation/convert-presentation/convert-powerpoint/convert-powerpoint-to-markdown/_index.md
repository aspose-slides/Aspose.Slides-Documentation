---
title: Converti le presentazioni PowerPoint in Markdown con .NET
linktitle: PowerPoint in Markdown
type: docs
weight: 140
url: /it/net/convert-powerpoint-to-markdown/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in MD
- presentazione in MD
- diapositiva in MD
- PPT in MD
- PPTX in MD
- salva PowerPoint come Markdown
- salva presentazione come Markdown
- salva diapositiva come Markdown
- salva PPT come MD
- salva PPTX come MD
- esporta PPT in MD
- esporta PPTX in MD
- esportazione immagine Markdown
- collegamenti immagine CDN
- PowerPoint
- presentazione
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Converti le presentazioni PPT e PPTX in Markdown con .NET e controlla dove vengono salvate e referenziate le immagini bitmap, metafile e SVG esportate."
---
## **Panoramica**

Aspose.Slides per .NET può convertire presentazioni PPT e PPTX in Markdown per la documentazione, i siti statici, la migrazione di contenuti e i flussi di lavoro di controllo versione. È possibile scegliere una variante di Markdown, controllare come viene reso il contenuto delle diapositive e decidere dove vengono salvate le immagini esportate e come il Markdown generato le fa riferimento.

Per impostazione predefinita, l'esportazione in Markdown utilizza solo testo. Per esportare contenuti visivi, impostare la proprietà [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions/exporttype/) sul valore `Sequential` o `Visual` dell'enumerazione [MarkdownExportType](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownexporttype/). `Sequential` rende gli elementi della diapositiva separatamente e in ordine, mentre `Visual` mantiene gli elementi raggruppati insieme per preservare la loro relazione visiva. Il valore `TextOnly` non genera risorse immagine, quindi gli eventi di salvataggio delle immagini non vengono attivati in quella modalità.

## **Convertire una presentazione in Markdown**

Caricare il file di origine con la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e quindi chiamare il metodo [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) con il valore `Md` dell'enumerazione [SaveFormat](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Selezionare una variante di Markdown**

La proprietà [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions/flavor/) controlla la specifica Markdown utilizzata per l'output. L'enumerazione [Flavor](https://reference.aspose.com/slides/it/net/aspose.slides.export/flavor/) comprende CommonMark, GitHub Flavored Markdown e altre varianti supportate.

Il seguente esempio esporta una presentazione come CommonMark:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Esportare immagini usando il comportamento predefinito di salvataggio locale**

La classe [MarkdownSaveOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions/) fornisce due proprietà per le immagini salvate localmente:

- [BasePath](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions/basepath/) specifica la directory di base per il documento Markdown e le sue risorse.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) specifica la sottodirectory delle immagini. Il suo valore predefinito è `Images`.

Il seguente esempio rende il contenuto visivo, scrive le immagini in `output/assets` e crea riferimenti immagine relativi nel documento Markdown:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Questo comportamento funge anche da fallback quando un gestore di salvataggio immagini personalizzato restituisce `false`.

## **Personalizzare il salvataggio delle immagini e i collegamenti Markdown**

Utilizzare l'evento [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions/imagesaving/) per le risorse bitmap e metafile non SVG generate durante l'esportazione in Markdown. Il suo delegato [MarkdownImageSavingHandler](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) riceve l'oggetto [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/), il suo [ImageFormat](https://reference.aspose.com/slides/it/net/aspose.slides/imageformat/), e il collegamento Markdown generato come parametro `ref string`. Salvare o caricare l'immagine con il formato fornito e sostituire `link` con il riferimento che deve comparire nell'output Markdown.

Le risorse emesse in formato SVG vengono gestite separatamente. Iscriversi all'evento [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/), il cui delegato [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) riceve un oggetto [ISvgImage](https://reference.aspose.com/slides/it/net/aspose.slides/isvgimage/) e il parametro `ref string link`. Un SVG non ha un argomento `ImageFormat`; è necessario scrivere o caricare i suoi dati XML dalla proprietà [ISvgImage.SvgData](https://reference.aspose.com/slides/it/net/aspose.slides/isvgimage/svgdata/). A seconda della modalità di esportazione e del raggruppamento visivo, un SVG nella presentazione di origine può essere rasterizzato o combinato con altri contenuti; la risorsa non SVG risultante viene quindi passata a `ImageSaving`. Iscriversi a entrambi gli eventi quando ogni risorsa visiva esportata richiede una elaborazione personalizzata.

Il valore restituito dal gestore determina chi elabora l'immagine:

- Restituire `true` dopo che il gestore ha salvato, caricato, trasformato o altrimenti elaborato l'immagine e ha assegnato un valore valido a `link`. Aspose.Slides scrive quel valore nel documento Markdown e non esegue il salvataggio locale predefinito.
- Restituire `false` per consentire ad Aspose.Slides di salvare l'immagine localmente e generare il relativo collegamento in base a [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions/basepath/) e [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

{{% alert color="warning" title="Important" %}}
Un gestore che restituisce `true` si assume la responsabilità dell'immagine. Se restituisce `true` senza assegnare un collegamento valido e non vuoto, l'esportazione fallisce con un `InvalidOperationException`.
{{% /alert %}}

### **Salvare le immagini in una directory di origine CDN e usare URL esterni**

Il seguente esempio tratta `cdn-origin/presentations/quarterly-report` come una directory di origine CDN montata o sincronizzata. Ogni gestore estrae il nome file generato, salva l'immagine in quella directory personalizzata e sostituisce il riferimento locale generato con un URL CDN pubblico. L'esempio stesso non esegue alcun upload di rete: l'URL diventa valido solo dopo che la directory è stata montata come origine CDN o i suoi file sono stati pubblicati sul CDN. Per lo storage di oggetti, sostituire la scrittura sul file system con l'operazione di upload dell'SDK di storage e assegnare `link` solo dopo che l'upload ha avuto successo.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Il gestore bitmap restituisce deliberatamente `false` per le immagini più piccole di 128 × 128 pixel, così Aspose.Slides salva quelle immagini in `output/fallback-images` utilizzando il comportamento predefinito. Le risorse bitmap e metafile più grandi, così come le risorse SVG, sono gestite dal codice personalizzato. Ad esempio, un riferimento locale generato come `fallback-images/image1.png` diventa `https://cdn.example.com/presentations/quarterly-report/image1.png`. I gestori usano percorsi del sistema operativo solo durante la scrittura dei file; i collegamenti scritti nel Markdown usano barre oblique e nomi file codificati per URL. Applicare la stessa regola quando si costruiscono collegamenti relativi: usare `/`, non il separatore di directory specifico della piattaforma.

## **FAQ**

**Un gestore può elaborare sia immagini raster che immagini SVG?**

No. Utilizzare [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions/imagesaving/) per le risorse bitmap e metafile generate e [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) per le risorse generate come SVG. Il primo fornisce un oggetto [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) e un [ImageFormat](https://reference.aspose.com/slides/it/net/aspose.slides/imageformat/); il secondo fornisce un oggetto [ISvgImage](https://reference.aspose.com/slides/it/net/aspose.slides/isvgimage/) i cui dati SVG possono essere letti da [ISvgImage.SvgData](https://reference.aspose.com/slides/it/net/aspose.slides/isvgimage/svgdata/). Un SVG di origine rasterizzato durante l'esportazione è elaborato da `ImageSaving`.

**Cosa succede quando un gestore di salvataggio immagini restituisce `false`?**

Aspose.Slides utilizza il suo comportamento predefinito di salvataggio locale. La posizione dell'immagine e il riferimento generato sono controllati da [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions/basepath/) e [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/it/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

**Un gestore può fornire un URL senza salvare l'immagine localmente?**

Sì. Il gestore può caricare l'immagine su uno storage di oggetti o passarla a un altro servizio, assegnare l'URL risultante a `link` e restituire `true`. Il gestore deve completare l'elaborazione autonomamente; restituire `true` impedisce il salvataggio locale predefinito.

**Perché l'esportazione in Markdown genera un `InvalidOperationException` da un gestore?**

Questa eccezione si verifica quando il gestore restituisce `true` ma non fornisce un collegamento valido. Assegnare il percorso relativo o l'URL esterno che deve essere scritto nel Markdown prima di restituire `true`.

**Quale separatore di percorso devono usare i collegamenti alle immagini?**

Usare barre oblique nei collegamenti Markdown e negli URL. Utilizzare `Path.Combine` solo per i percorsi del file system, quindi costruire o normalizzare il riferimento Markdown separatamente.

**I collegamenti ipertestuali sono preservati durante l'esportazione in Markdown?**

Sì. Il testo [collegamenti ipertestuali](/slides/it/net/manage-hyperlinks/) è preservato come link Markdown standard. Le [transizioni](/slides/it/net/slide-transition/) e le [animazioni](/slides/it/net/powerpoint-animation/) delle diapositive non vengono convertite.

**Le presentazioni possono essere convertite in Markdown in parallelo?**

È possibile elaborare file di presentazione diversi in parallelo, ma non condividere la stessa [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) tra i thread. Seguire le [linee guida per il multithreading](/slides/it/net/multithreading/) e utilizzare un'istanza separata per ogni file.