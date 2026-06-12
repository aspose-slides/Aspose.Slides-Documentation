---
title: Converti presentazioni PowerPoint in HTML con .NET
linktitle: PowerPoint in HTML
type: docs
weight: 30
url: /it/net/convert-powerpoint-to-html/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in HTML
- presentazione in HTML
- diapositiva in HTML
- PPT in HTML
- PPTX in HTML
- salva PowerPoint come HTML
- salva presentazione come HTML
- salva diapositiva come HTML
- salva PPT come HTML
- salva PPTX come HTML
- esporta PPT in HTML
- esporta PPTX in HTML
- .NET
- C#
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in HTML con .NET. Usa Aspose.Slides per esportare file PPT e PPTX, diapositive selezionate, note, caratteri, immagini, SVG e contenuti multimediali."
---
## **Panoramica**

Aspose.Slides per .NET può salvare le presentazioni PowerPoint come HTML senza Microsoft PowerPoint. La conversione di base consiste in un unico caricamento di [Presentazione](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e una chiamata a [Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) con [SaveFormat](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/). Utilizza [HtmlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/htmloptions/) quando devi controllare il layout esportato, i caratteri, le immagini, le note, i commenti, l'output SVG o le risorse collegate.

Questa guida si concentra su scenari pratici di esportazione HTML:

- Esportare un’intera presentazione o diapositive selezionate.
- Generare HTML a layout fisso, responsivo o basato su SVG.
- Includere note del relatore e commenti.
- Controllare la qualità dell’immagine e i dati delle immagini ritagliate.
- Incorporare i caratteri o salvare i file dei caratteri separatamente.
- Scegliere come scrivere e fare riferimento a risorse ed elementi multimediali esterni.

Per impostazione predefinita, l’esportazione HTML produce un documento HTML autonomo in cui la maggior parte delle risorse è incorporata. Questo è comodo per condividere un unico file, ma può aumentare la dimensione dell’output. Per la pubblicazione sul web, considera risorse esterne, DPI immagine più bassi e l’incorporamento solo dei caratteri non disponibili in modo affidabile nell’ambiente di destinazione.

## **Convertire una presentazione in HTML**

Per esportare una presentazione in HTML, caricala con [Presentazione](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e salvala con [SaveFormat.Html](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

Questo esempio scrive un singolo file HTML. L’oggetto presentazione viene eliminato dalla dichiarazione `using`, che rilascia i handle dei file e le risorse di rendering dopo l’esportazione.

## **Utilizzare HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/htmloptions/) è la classe di configurazione principale per l’esportazione HTML. Le impostazioni più comuni includono:

- `SlidesLayoutOptions`: aggiunge note, commenti, dispense o altre informazioni di layout.
- `HtmlFormatter`: modifica la struttura del documento HTML o delega la formattazione a un controller.
- `SlideImageFormat`: cambia il modo in cui le diapositive sono rappresentate, ad esempio come SVG.
- `PicturesCompression`: controlla DPI dell’immagine e dimensione dell’output.
- `DeletePicturesCroppedAreas`: mantiene o rimuove i dati delle immagini ritagliate.
- `SvgResponsiveLayout`: fa adattare il contenuto SVG esportato al suo contenitore.
- `ShowHiddenSlides`: include le diapositive nascoste quando necessario.

Le sezioni seguenti mostrano le opzioni più comuni separatamente, così da combinare solo quelle richieste dal tuo flusso di lavoro.

## **Convertire diapositive selezionate in HTML**

Il sovraccarico di [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) che accetta numeri di diapositiva utilizza posizioni basate su indice 1. Il ciclo sottostante salva ogni diapositiva in un file HTML separato.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Usa questo modello quando un sito web o un’applicazione richiedono una pagina HTML per diapositiva. Se tutte le diapositive devono avere lo stesso layout, crea un’unica istanza di [HtmlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/htmloptions/) e passala a ciascuna chiamata `Save`.

## **Creare HTML responsivo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/it/net/aspose.slides.export/responsivehtmlcontroller/) fornisce output HTML responsivo tramite [HtmlFormatter](https://reference.aspose.com/slides/it/net/aspose.slides.export/htmlformatter/). Usalo quando la pagina esportata deve adattarsi meglio alla larghezza del browser.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

Per un layout responsivo basato su SVG, imposta `SvgResponsiveLayout` su [HtmlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/htmloptions/). È utile quando il contenuto della diapositiva è esportato come markup SVG scalabile.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Includere note del relatore e commenti**

Usa [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/notescommentslayoutingoptions/) tramite `HtmlOptions.SlidesLayoutOptions` per includere note del relatore o commenti. Note e commenti sono nascosti per impostazione predefinita, a meno che non ne specifichi le posizioni.

Supponiamo che la presentazione di origine contenga note del relatore:

![Diapositiva con note del relatore in PowerPoint](slide_with_notes.png)

Il codice seguente esporta il contenuto della diapositiva con le note del relatore sotto la diapositiva.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

L’HTML esportato include l’area delle note:

![Output HTML con diapositiva e note del relatore](HTML_with_notes.png)

Per esportare i commenti, imposta `CommentsPosition`, ad esempio su `CommentsPositions.Right` o `CommentsPositions.Bottom`. Se ti servono solo i commenti, ometti `NotesPosition`. Se ti servono sia note sia commenti, imposta entrambe le proprietà.

## **Controllare la qualità dell’immagine e le aree ritagliate**

L’esportazione HTML può comprimere le immagini delle diapositive per ridurre la dimensione dell’output. Imposta `PicturesCompression` su un valore da [PicturesCompression](https://reference.aspose.com/slides/it/net/aspose.slides.export/picturescompression/) quando è necessaria una qualità dell’immagine più elevata.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

Per impostazione predefinita, le aree ritagliate delle immagini possono essere rimosse dall’output esportato. Mantieni i dati ritagliati solo quando gli utenti devono poter recuperarli o ispezionarli. Conservare questi dati può aumentare le dimensioni dell’HTML.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **Aggiungere CSS**

Per uno styling semplice, passa una stringa CSS a [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/it/net/aspose.slides.export/htmlformatter/createdocumentformatter/). Questo modifica il documento HTML circostante mentre Aspose.Slides continua a renderizzare il contenuto della diapositiva.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

Per un’intestazione di documento personalizzata, un file CSS collegato o markup personalizzato intorno a diapositive e forme, implementa [IHtmlFormattingController](https://reference.aspose.com/slides/it/net/aspose.slides.export/ihtmlformattingcontroller/) e passalo a [HtmlFormatter](https://reference.aspose.com/slides/it/net/aspose.slides.export/htmlformatter/) con `CreateCustomFormatter`.

## **Incorporare i caratteri**

Se l’ambiente di destinazione potrebbe non avere i caratteri della presentazione installati, incorpora i caratteri nell’HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/it/net/aspose.slides.export/embedallfontshtmlcontroller/). L’incorporamento migliora la fedeltà visiva ma aumenta le dimensioni dell’output.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

Escludi i caratteri solo quando sei certo che i browser o i sistemi di destinazione li forniscano già. Per i caratteri del brand o quelli meno comuni, l’incorporamento è solitamente più sicuro.

## **Collegare i file dei caratteri invece di incorporarli**

Per ridurre la dimensione del file HTML, puoi scrivere i dati dei caratteri in file WOFF separati e aggiungere regole `@font-face` all’HTML. L’aiutante sottostante estende [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/it/net/aspose.slides.export/embedallfontshtmlcontroller/) e sovrascrive `WriteFont`.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

In questo esempio, i file dei caratteri vengono salvati in `html-output/fonts`, e l’HTML li riferisce con URL come `fonts/BrandFont-normal-400.woff`. Se il file HTML e i caratteri vengono distribuiti in un altro percorso, scegli `fontUrlPrefix` in modo che corrisponda al percorso URL di distribuzione.

## **Salvare le risorse esternamente**

L’HTML autonomo è facile da spostare, ma le risorse Base64 incorporate possono rendere il file grande. Se la tua applicazione necessita di file immagine esterni, implementa [ILinkEmbedController](https://reference.aspose.com/slides/it/net/aspose.slides.export/ilinkembedcontroller/) e passalo al costruttore di [HtmlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/htmloptions/htmloptions/).

Quando esternalizzi le risorse, scegli due percorsi in modo deliberato:

- Il percorso di output del file system, dove l’applicazione scrive le immagini, i caratteri, l’audio o il video generati.
- Il percorso URL, che è quello che il browser utilizza dal documento HTML per caricare quei file.

Per un’implementazione completa di collegamento immagini, vedi [Export Presentations to HTML with Externally Linked Images](/slides/it/net/exporting-presentations-to-html-with-externally-linked-images/).

## **Esportare file multimediali**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/it/net/aspose.slides.export/videoplayerhtmlcontroller/) esporta file video e audio e scrive HTML che può riprodurli in un browser. Il suo costruttore accetta:

- `path`: la directory dove verranno scritti i file multimediali generati.
- `fileName`: il nome del file HTML in fase di generazione.
- `baseUri`: il prefisso URI assoluto usato nei collegamenti HTML ai file multimediali.

Se il file HTML è `html-output/presentation.html` e i file multimediali sono salvati in `html-output/media`, `path` deve puntare alla directory multimediale sul disco, mentre `baseUri` deve puntare alla stessa directory dal punto di vista del browser. Per l’anteprima locale, puoi costruire un URI `file:///` dalla directory multimediale. Per un’applicazione distribuita, usa l’URL assoluto della directory multimediale pubblicata.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

Usa directory di output uniche per ogni operazione di esportazione, specialmente nelle applicazioni server. Percorsi di output condivisi possono causare la sovrascrittura di file provenienti da conversioni diverse.

## **Prestazioni e gestione delle risorse**

La conversione HTML è un’operazione di rendering, quindi il tempo di elaborazione e l’uso della memoria dipendono dal numero di diapositive, dalla risoluzione delle immagini, dai caratteri, dagli effetti, dai grafici e dai media incorporati. Valori DPI più alti per `PicturesCompression`, caratteri incorporati, output SVG e aree ritagliate mantenute possono migliorare la fedeltà ma solitamente aumentano la dimensione dell’output.

Per conversioni batch:

- Elimina prontamente ogni istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
- Usa directory di output separate per lavori separati.
- Evita di incorporare caratteri comuni a meno che la fedeltà non lo richieda.
- Riduci DPI delle immagini quando l’HTML è destinato a preview o thumbnail.
- Mantieni la presentazione di origine, l’HTML generato e le risorse esterne insieme fino a quando i percorsi di distribuzione non sono definitivi.

## **FAQ**

**I collegamenti ipertestuali sono conservati nell’output HTML?**

Sì. I collegamenti ipertestuali della presentazione vengono esportati in HTML e rimangono cliccabili quando l’URL di destinazione è valido.

**Posso convertire presentazioni in HTML in parallelo?**

Sì, ma non condividere un’istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) tra thread. Elabora file diversi con istanze di presentazione separate, stream separati e directory di output distinte. Consulta la [guida al multithreading](/slides/it/net/multithreading/) per i dettagli.

**Un oggetto Presentation è thread‑safe?**

No. Un’unica istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) dovrebbe essere caricata, modificata, salvata ed eliminata su un solo thread. Per lavoro parallelo, crea un’istanza indipendente per ogni thread o processo.

**Perché il file HTML generato è grande?**

L’esportazione predefinita può incorporare le risorse direttamente nell’HTML. Caratteri incorporati, immagini ad alta DPI, media, contenuto SVG e aree ritagliate mantenute aumentano la dimensione. Usa risorse esterne, escludi i caratteri comuni dall’incorporamento e abbassa `PicturesCompression` quando un output più piccolo è più importante della massima fedeltà.

**Perché una dimensione del carattere di PowerPoint come 24 pt appare come 17,999819 pt in HTML?**

Questo può accadere perché PowerPoint e HTML usano modelli DPI diversi. PowerPoint memorizza le dimensioni del testo in punti tipografici basati su 72 DPI, mentre il layout HTML si basa su pixel CSS in un modello a 96 DPI. Quando Aspose.Slides esporta una presentazione in HTML, la dimensione del carattere viene tradotta tra questi sistemi e la conversione può introdurre piccole differenze di arrotondamento.

Questi valori non indicano una reale modifica visiva della dimensione del carattere. Sono solo un effetto collaterale matematico della conversione delle metriche testuali tra PowerPoint e HTML.

**Come dovrei scegliere baseUri per l’esportazione dei media?**

Scegli `baseUri` dal punto di vista del browser e passalo come URI assoluto. Per l’anteprima locale, puoi derivarlo dalla directory di output con `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri`. Per la distribuzione, usa l’URL assoluto della directory multimediale pubblicata. Il `path` del file system e il `baseUri` del browser non devono essere la stessa stringa, ma devono descrivere la stessa posizione della risorsa.

**Posso includere diapositive nascoste?**

Sì. Imposta `ShowHiddenSlides = true` su [HtmlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/htmloptions/) quando le diapositive nascoste devono essere esportate.