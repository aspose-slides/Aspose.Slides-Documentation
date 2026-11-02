---
title: Gestire i collegamenti ipertestuali della presentazione in .NET
linktitle: Gestire i collegamenti ipertestuali
type: docs
weight: 20
url: /it/net/manage-hyperlinks/
keywords:
- aggiungi URL
- aggiungi collegamento ipertestuale
- crea collegamento ipertestuale
- formatta collegamento ipertestuale
- rimuovi collegamento ipertestuale
- aggiorna collegamento ipertestuale
- collegamento ipertestuale di testo
- collegamento ipertestuale di diapositiva
- collegamento ipertestuale di forma
- collegamento ipertestuale di immagine
- collegamento ipertestuale video
- collegamento ipertestuale modificabile
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Aggiungi, formatta, aggiorna e rimuovi collegamenti ipertestuali in presentazioni PowerPoint e OpenDocument con Aspose.Slides per .NET, usando esempi C#."
---
## **Introduzione**

Un collegamento ipertestuale collega il contenuto di una presentazione a un sito web o a una posizione all'interno della presentazione. In PowerPoint, i collegamenti ipertestuali servono comunemente a due scopi:

* Apri un sito web dal testo, da una forma o da un frame multimediale.
* Vai a un'altra diapositiva, ad esempio da un indice.

Aspose.Slides per .NET consente di aggiungere questi collegamenti, controllarne l'aspetto e il suono, aggiornare le proprietà e rimuoverli. Gli esempi seguenti mostrano come lavorare con i collegamenti ipertestuali su elementi individuali e come accedere ai collegamenti ipertestuali a livello di presentazione, diapositiva o riquadro di testo.

{{% alert color="info" title="Note" %}}
È inoltre possibile modificare le presentazioni con il [gratuito editor online di Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Aggiungere collegamenti URL**

È possibile assegnare un URL di sito web a testo, forma o frame multimediale. L'elemento a cui si assegna il collegamento ipertestuale determina l'area cliccabile: una porzione di testo collega il testo selezionato, mentre una forma o un frame collega l'oggetto della diapositiva.

Per le presentazioni che contengono collegamenti ipertestuali relativi, consultare [Gestisci la base dei collegamenti ipertestuali](/slides/it/net/presentation-properties/#manage-the-hyperlink-base) per leggere, modificare o cancellare la base a livello di documento.

### **Aggiungere collegamenti URL al testo**

Per collegare il testo a un sito web, assegnare un [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) alla proprietà [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) della porzione di testo, come mostrato di seguito. Solo quella porzione di testo diventa cliccabile.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **Aggiungere collegamenti URL a forme e frame multimediali**

Per rendere una forma o un frame cliccabile, impostare la sua proprietà [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/). Il collegamento ipertestuale appartiene all'oggetto stesso piuttosto che a una porzione di testo al suo interno.

Lo stesso approccio si applica ai frame di immagine, audio e video: assegnare il collegamento ipertestuale al frame e impostare il [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) del collegamento, se necessario.

Il seguente esempio rende un rettangolo cliccabile:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Utilizzare i collegamenti ipertestuali per creare un indice**

I collegamenti ipertestuali interni consentono ai lettori di passare da un indice a una diapositiva specifica. Il seguente esempio utilizza [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) per collegare il testo “Page 2” sulla prima diapositiva alla seconda diapositiva.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **Formattare i collegamenti ipertestuali**

### **Colore**

La proprietà [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) di [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) determina se un collegamento ipertestuale utilizza il colore dei collegamenti ipertestuali della presentazione o la formattazione della porzione di testo. Per applicare un colore di testo personalizzato, selezionare [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) e impostare il colore di riempimento della porzione. Questa funzionalità è stata introdotta in PowerPoint 2019; le versioni precedenti non applicano questa impostazione.

Il seguente esempio aggiunge due collegamenti ipertestuali di testo alla stessa diapositiva. Il primo utilizza un riempimento di testo rosso, mentre il secondo mantiene il colore predefinito del collegamento ipertestuale.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```
### **Suono**

Un collegamento ipertestuale può riprodurre un suono quando viene attivato o interrompere un suono già in riproduzione. Utilizzare le seguenti proprietà per configurare questi comportamenti:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) specifica l'audio associato al collegamento ipertestuale.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) controlla se l'attivazione del collegamento ipertestuale interrompe il suono precedente.

#### **Aggiungere un suono al collegamento ipertestuale**

Il seguente esempio carica `sampleaudio.wav` e lo associa a un pulsante sulla prima diapositiva. Cliccando il pulsante il suono viene riprodotto e si passa alla diapositiva successiva. Una seconda forma su quella diapositiva interrompe il suono precedente quando viene cliccata, senza eseguire un'azione di navigazione.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **Estrarre un suono da un collegamento ipertestuale**

Il seguente esempio apre la presentazione creata sopra e legge l'audio del collegamento ipertestuale della prima forma in memoria tramite [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) e [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **Impostazioni Tooltip e di interazione**

È possibile aggiornare le seguenti proprietà di [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) dopo aver assegnato un collegamento ipertestuale a testo o a una forma:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) imposta il testo che un visualizzatore può visualizzare come suggerimento per il collegamento.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) specifica il frame di destinazione all'interno di un frameset HTML padre, se applicabile.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) controlla se l'attivazione del collegamento aggiunge la sua destinazione all'elenco dei collegamenti ipertestuali visualizzati.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) controlla se il collegamento ipertestuale viene evidenziato quando viene cliccato.

## **Rimuovere i collegamenti ipertestuali dalle presentazioni**

Utilizzare [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) per raccogliere i contenitori di collegamenti ipertestuali, inclusi i collegamenti a porzioni di testo, prima di modificarli. Il seguente esempio rimuove entrambi i tipi di attivazione dalla prima diapositiva. Per rimuovere solo un tipo, chiamare solo [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) o [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); la rimozione di un'azione di click non rimuove la sua controparte mouse-over.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

Per rimozione incondizionata, [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) rimuove entrambi i tipi di attivazione nell'ambito selezionato con una singola chiamata. Per una pulizia selettiva e la copertura di master, layout e note, vedere [Report, Sanitizzazione e Verifica dei collegamenti ipertestuali](#report-sanitize-and-verify-hyperlinks).

## **Creare un inventario completo dei collegamenti ipertestuali**

Prima di distribuire una presentazione, inventariare le sue azioni interattive così come i suoi collegamenti web. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) restituisce oggetti [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/), non un elenco piatto di stringhe URL. Ispezionare sia [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) che [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) su ciascun contenitore. Sono indipendenti: lo stesso contenitore può esporre entrambe le azioni, quindi un report completo richiede fino a due righe per contenitore.

Scansionare solo i collegamenti ipertestuali a livello di forma può perdere i collegamenti allegati a porzioni di testo. Interrogare invece l'ambito appropriato e conservare i contenitori restituiti in modo da poterli successivamente aggiornare o rimuovere le loro azioni.

### **Interrogare ambiti di presentazione, diapositiva e riquadro di testo**

L'interfaccia [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) è disponibile tramite [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/), e [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/). Ogni ambito supporta le stesse query:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) restituisce i contenitori con un'azione di click.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) restituisce i contenitori con un'azione mouse-over.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) restituisce i contenitori con una o entrambe le azioni.

Il seguente esempio crea `hyperlink-audit-input.pptx` con un collegamento di click esterno, un collegamento mouse-over su file, una navigazione interna tra diapositive, un collegamento mouse-over su testo e un'azione macro. Non esegue nessuna di queste azioni. Le stesse tre query funzionano in ogni ambito; i conteggi descrivono i contenitori, non il totale delle azioni. L'ambito del riquadro di testo esclude i collegamenti della forma contenente.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

Per questo esempio, le query di presentazione e di diapositiva restituiscono ciascuna tre contenitori di click, due contenitori di mouse-over e tre contenitori con una qualsiasi delle due azioni. La query del riquadro di testo restituisce un contenitore in ciascuna categoria.

### **Classificare azioni e destinazioni**

Utilizzare [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) per interpretare un'azione prima di interpretare la sua destinazione. I valori di [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) coprono più della semplice navigazione web:

| Valori | Significato per un audit |
| --- | --- |
| `Hyperlink` | Collegamento ipertestuale esterno; esaminare l'URL e il suo schema. |
| `JumpSpecificSlide` | Navigazione interna a una diapositiva specifica. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigazione incorporata della presentazione, risolta nel contesto della presentazione. |
| `JumpEndShow`, `StartCustomSlideShow` | Termina la presentazione corrente o avvia una presentazione personalizzata. |
| `StartMacro` | Esegue una macro. |
| `StartProgram` | Avvia un programma. |
| `OpenFile`, `OpenPresentation` | Apre un file o un'altra presentazione; revisionare separatamente dagli URL web. |
| `StartStopMedia` | Avvia o interrompe la riproduzione multimediale. |
| `NoAction`, `Unknown` | Nessuna azione di navigazione, o un'azione non riconosciuta che richiede revisione. |

Leggere le destinazioni esterne da [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) e le destinazioni interne specifiche da [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). Le azioni interne e i comandi integrati possono non avere URL esterni; un URL vuoto non significa che il contenitore non abbia azioni. Conservare [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) quando differisce dall'URL normalizzato, e includere il [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) quando disponibile.

### **Report, Sanitizzazione e Verifica dei collegamenti ipertestuali**

Il seguente esempio .NET 6+ legge una presentazione esistente (utilizzare il file creato sopra), scrive `hyperlink-audit.json`, applica una politica, salva `hyperlink-sanitized.pptx` e la riapre per verificare nuovamente entrambi i tipi di attivazione. Raccoglie i contenitori prima di modificarli e utilizza l'uguaglianza di riferimento per evitare di elaborare lo stesso contenitore due volte. Le query di presentazione coprono le diapositive ordinarie; per un inventario a livello di pacchetto, interroga esplicitamente anche master, layout, note e i master di note e di handout quando presenti.

Il report registra un indice di diapositiva basato su 1 e [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) dove disponibile. [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) fornisce la diapositiva proprietaria per i contenitori supportati. I master, i layout e le note non hanno un indice di diapositiva ordinario e sono identificati dal loro ambito. I contenitori di forme e i contenitori di formattazione di porzioni di testo sono etichettati separatamente; gli altri tipi di contenitore conservano il loro nome di tipo di runtime. Ogni contenitore ottiene un ID locale al report così le sue due azioni possono essere correlate.

Questa politica applicativa deliberatamente restrittiva consente solo URL HTTPS assoluti e destinazioni di diapositive interne valide. Rifiuta macro, programmi, azioni su file, altre azioni di presentazione, azioni sconosciute e altri schemi URL. Questi rifiuti sono decisioni di politica, non un giudizio di sicurezza di Aspose.Slides. HTTPS da solo non garantisce la fiducia: aggiungere whitelist di host e altri controlli per la tua applicazione. Sia gli URL esterni originali che quelli normalizzati sono verificati. L'esempio esamina i metadati senza seguire i collegamenti o eseguire azioni.

Per la rimessione in ordine, il [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) del contenitore supporta [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), e [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Qui, i collegamenti di click esterni proibiti sono sostituiti con una pagina di destinazione HTTPS fissa; altri click proibiti e azioni mouse-over proibite sono rimossi in modo indipendente. Impostare `replaceExternalClicks` su `false` per rimuovere tutte le violazioni della politica. Scegliere una pagina di sostituzione di proprietà dell'applicazione prima della distribuzione.

Il flag di esportazione del report utilizza una politica di revisione PDF conservativa: segnala le azioni mouse-over e tutto ciò che non è un collegamento esterno o un salto a una diapositiva specifica come potenzialmente non supportato. È un suggerimento di revisione, non un test di capacità o una garanzia che i collegamenti non segnalati sopravviveranno all'esportazione. Le esportazioni [PDF](/slides/it/net/convert-powerpoint-to-pdf/) e [HTML](/slides/it/net/convert-powerpoint-to-html/) supportate possono preservare i collegamenti ipertestuali, a seconda dell'azione, delle opzioni di esportazione e del visualizzatore. Le [immagini](/slides/it/net/convert-powerpoint-to-png/) raster e i [video](/slides/it/net/convert-powerpoint-to-video/) non possono preservare i collegamenti ipertestuali interattivi; segnalare ogni azione durante l'audit per questi output.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

Con l'input creato sopra, il report contiene cinque righe di azioni. Il collegamento mouse-over al file e il click della macro sono rimossi, mentre i collegamenti HTTPS e la navigazione interna delle diapositive rimangono. La verifica stampa zero azioni proibite. Un input contenente un URL di click esterno proibito esercita anche il ramo di sostituzione. Un contenitore con un click consentito e un mouse-over proibito mantiene la sua azione di click.

Questa pulizia selettiva differisce da [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), che rimuove entrambi i tipi di attivazione in tutto l'ambito selezionato indipendentemente dalla politica. La verifica qui controlla solo le azioni dei collegamenti ipertestuali; non rimuove progetti VBA incorporati, oggetti OLE o altri contenuti attivi, e non convalida un file PDF o HTML esportato.

## **FAQ**

**How can I link to a section or its first slide?**

Le sezioni in PowerPoint raggruppano le diapositive, ma un collegamento ipertestuale interno punta a una diapositiva individuale. Per creare una navigazione a una sezione, collegare alla prima diapositiva di quella sezione.

**Can I attach a hyperlink to master slide elements so it works on all slides?**

Sì. Gli elementi del master della diapositiva e del layout supportano i collegamenti ipertestuali. I collegamenti su questi elementi sono disponibili durante la presentazione sulle diapositive che utilizzano il master o il layout corrispondente.

**Will hyperlinks be preserved when exporting to PDF, HTML, images, or video?**

Le esportazioni PDF e HTML supportate possono preservare i collegamenti ipertestuali; le immagini raster e i video no. Vedere le considerazioni sull'esportazione in [Report, Sanitizzazione e Verifica dei collegamenti ipertestuali](#report-sanitize-and-verify-hyperlinks).