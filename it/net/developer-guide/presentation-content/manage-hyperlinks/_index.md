---
title: Gestire i collegamenti ipertestuali della presentazione in .NET
linktitle: Gestire i collegamenti ipertestuali
type: docs
weight: 20
url: /it/net/manage-hyperlinks/
keywords:
- aggiungere URL
- aggiungere collegamento ipertestuale
- creare collegamento ipertestuale
- formattare collegamento ipertestuale
- rimuovere collegamento ipertestuale
- aggiornare collegamento ipertestuale
- collegamento ipertestuale di testo
- collegamento ipertestuale di diapositiva
- collegamento ipertestuale di forma
- collegamento ipertestuale di immagine
- collegamento ipertestuale di video
- collegamento ipertestuale modificabile
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Aggiungere, formattare, aggiornare e rimuovere i collegamenti ipertestuali nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per .NET, utilizzando esempi C#."
---
## **Introduzione**

Un collegamento ipertestuale collega il contenuto della presentazione a un sito web o a una posizione all'interno della presentazione. In PowerPoint, i collegamenti ipertestuali generalmente servono a due scopi:

* Aprire un sito web da testo, forma o riquadro multimediale.
* Navigare a un'altra diapositiva, ad esempio da un indice.

Aspose.Slides for .NET consente di aggiungere questi collegamenti, controllarne l'aspetto e il suono, aggiornare le proprietà e rimuoverli. Gli esempi seguenti mostrano come lavorare con i collegamenti ipertestuali su singoli elementi e come accedere ai collegamenti a livello di presentazione, diapositiva o riquadro di testo.

{{% alert color="info" title="Nota" %}}
Puoi anche modificare le presentazioni con il [gratuito editor online Aspose PowerPoint](https://products.aspose.app/slides/it/editor).
{{% /alert %}} 

## **Aggiungere collegamenti ipertestuali URL**

È possibile associare un URL di sito web a testo, forma o riquadro multimediale. L'elemento a cui si assegna il collegamento ipertestuale determina l'area cliccabile: una porzione di testo collega il testo selezionato, mentre una forma o un riquadro collega l'oggetto della diapositiva.

### **Aggiungere collegamenti ipertestuali URL al testo**

Per collegare il testo a un sito web, assegnare un [Hyperlink](https://reference.aspose.com/slides/it/net/aspose.slides/hyperlink/) alla proprietà [HyperlinkClick](https://reference.aspose.com/slides/it/net/aspose.slides/portionformat/hyperlinkclick/) della porzione di testo, come mostrato di seguito. Solo quella porzione di testo diventa cliccabile.

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

### **Aggiungere collegamenti ipertestuali URL a forme e riquadri multimediali**

Per rendere cliccabile una forma o un riquadro, impostare la proprietà [HyperlinkClick](https://reference.aspose.com/slides/it/net/aspose.slides/shape/hyperlinkclick/). Il collegamento appartiene all'oggetto stesso anziché a una porzione di testo al suo interno.

Lo stesso approccio vale per riquadri di immagine, audio e video: assegnare il collegamento al riquadro e impostare il [Tooltip](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/tooltip/) del collegamento, se necessario.

Il seguente esempio rende cliccabile un rettangolo:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Utilizzare collegamenti ipertestuali per creare un indice**

I collegamenti ipertestuali interni consentono ai lettori di passare da un indice a una diapositiva specifica. Il seguente esempio utilizza [SetInternalHyperlinkClick](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) per collegare il testo “Page 2” della prima diapositiva alla seconda diapositiva.

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

La proprietà [ColorSource](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/colorsource/) di [IHyperlink](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/) determina se il collegamento utilizza il colore dei collegamenti della presentazione o la formattazione della porzione di testo. Per applicare un colore di testo personalizzato, selezionare [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/it/net/aspose.slides/hyperlinkcolorsource/) e impostare il colore di riempimento della porzione. Questa funzionalità è stata introdotta in PowerPoint 2019; le versioni precedenti non applicano questa impostazione.

Il seguente esempio aggiunge due collegamenti ipertestuali di testo alla stessa diapositiva. Il primo utilizza un riempimento di testo rosso, mentre il secondo mantiene il colore predefinito del collegamento.

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

- [IHyperlink.Sound](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/sound/) specifica l'audio associato al collegamento.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/stopsoundonclick/) controlla se l'attivazione del collegamento interrompe il suono precedente.

#### **Aggiungere un suono al collegamento ipertestuale**

Il seguente esempio carica `sampleaudio.wav` e lo associa a un pulsante sulla prima diapositiva. Cliccando il pulsante si riproduce il suono e si passa alla diapositiva successiva. Una seconda forma su quella diapositiva interrompe il suono precedente quando viene cliccata, senza eseguire alcuna azione di navigazione.

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

Il seguente esempio apre la presentazione creata sopra e legge l'audio del collegamento della prima forma in memoria tramite [Sound](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/sound/) e [BinaryData](https://reference.aspose.com/slides/it/net/aspose.slides/iaudio/binarydata/).

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

### **Tooltip e impostazioni di interazione**

È possibile aggiornare le seguenti proprietà di [IHyperlink](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/) dopo aver assegnato un collegamento a testo o forma:

- [Tooltip](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/tooltip/) imposta il testo che lo spettatore può visualizzare come suggerimento per il collegamento.
- [TargetFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/targetframe/) specifica il riquadro di destinazione all'interno di un frameset HTML genitore, quando applicabile.
- [History](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/history/) controlla se l'attivazione del collegamento aggiunge la sua destinazione all'elenco dei collegamenti visualizzati.
- [HighlightClick](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/highlightclick/) controlla se il collegamento è evidenziato quando viene cliccato.

## **Rimuovere i collegamenti ipertestuali dalle presentazioni**

Utilizzare [GetAnyHyperlinks](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) per raccogliere i contenitori dei collegamenti, inclusi i collegamenti di porzioni di testo, prima di modificarli. Il seguente esempio rimuove entrambi i tipi di attivazione dalla prima diapositiva. Per rimuovere solo un tipo, chiamare solo [RemoveHyperlinkClick](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) o [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); la rimozione di un'azione di click non elimina la corrispondente azione di mouse‑over.

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

Per una rimozione incondizionata, [RemoveAllHyperlinks](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) elimina entrambi i tipi di attivazione nell'ambito selezionato con una sola chiamata. Per una pulizia selettiva e la copertura di master, layout e note, vedere [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Creare un inventario completo dei collegamenti ipertestuali**

Prima di distribuire una presentazione, inventariare le sue azioni interattive così come i suoi collegamenti web. [GetAnyHyperlinks](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) restituisce oggetti [IHyperlinkContainer](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkcontainer/), non un elenco piatto di stringhe URL. Ispezionare sia [HyperlinkClick](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) sia [HyperlinkMouseOver](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) su ogni contenitore. Sono indipendenti: lo stesso contenitore può esporre entrambe le azioni, quindi un report completo richiede fino a due righe per contenitore.

Scansionare solo i collegamenti a livello di forma può far perdere collegamenti allegati a porzioni di testo. Interrogare invece l'ambito appropriato e conservare i contenitori restituiti così da poter aggiornare o rimuovere le loro azioni in seguito.

### **Interrogare ambiti di presentazione, diapositiva e riquadro di testo**

L'interfaccia [IHyperlinkQueries](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkqueries/) è disponibile tramite [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/hyperlinkqueries/) e [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/it/net/aspose.slides/itextframe/hyperlinkqueries/). Ogni ambito supporta le stesse interrogazioni:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) restituisce contenitori con un'azione di click.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) restituisce contenitori con un'azione di mouse‑over.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) restituisce contenitori con una o entrambe le azioni.

Il seguente esempio crea `hyperlink-audit-input.pptx` con un collegamento click esterno, un collegamento mouse‑over a file, una navigazione interna di diapositiva, un collegamento mouse‑over su testo e un'azione macro. Non esegue nessuna di queste azioni. Le tre interrogazioni funzionano in tutti gli ambiti; i conteggi descrivono contenitori, non il totale delle azioni. L'ambito del riquadro di testo esclude i collegamenti propri della forma contenente.

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

Per questo esempio, le interrogazioni di presentazione e diapositiva segnalano tre contenitori di click, due di mouse‑over e tre contenitori con una delle due azioni. L'interrogazione del riquadro di testo segnala un contenitore in ciascuna categoria.

### **Classificare azioni e destinazioni**

Utilizzare [IHyperlink.ActionType](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/actiontype/) per interpretare un'azione prima di interpretare la sua destinazione. I valori di [HyperlinkActionType](https://reference.aspose.com/slides/it/net/aspose.slides/hyperlinkactiontype/) coprono più della semplice navigazione web:

| Valori | Significato per una verifica |
| --- | --- |
| `Hyperlink` | Collegamento ipertestuale esterno; controllare l'URL e il suo schema. |
| `JumpSpecificSlide` | Navigazione interna a una diapositiva specifica. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigazione incorporata della presentazione, risolta nel contesto della presentazione. |
| `JumpEndShow`, `StartCustomSlideShow` | Termina lo spettacolo corrente o avvia uno spettacolo personalizzato. |
| `StartMacro` | Esegue una macro. |
| `StartProgram` | Avvia un programma. |
| `OpenFile`, `OpenPresentation` | Apri un file o un'altra presentazione; da esaminare separatamente dagli URL web. |
| `StartStopMedia` | Avvia o interrompe la riproduzione di contenuti multimediali. |
| `NoAction`, `Unknown` | Nessuna azione di navigazione, o un'azione non riconosciuta che richiede revisione. |

Leggere le destinazioni esterne da [ExternalUrl](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/externalurl/) e le destinazioni interne specifiche da [TargetSlide](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/targetslide/). Le azioni interne e i comandi incorporati potrebbero non avere un URL esterno; un URL vuoto non indica che il contenitore non abbia alcuna azione. Conservare [ExternalUrlOriginal](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/externalurloriginal/) quando differisce dall'URL normalizzato e includere il [Tooltip](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlink/tooltip/) quando disponibile.

### **Segnalare, sanitizzare e verificare i collegamenti ipertestuali**

Il seguente esempio .NET 6+ legge una presentazione esistente (usa il file creato sopra), scrive `hyperlink-audit.json`, applica una politica, salva `hyperlink-sanitized.pptx` e lo riapre per controllare di nuovo entrambi i tipi di attivazione. Raccoglie i contenitori prima di modificarli e utilizza l'uguaglianza di riferimento per evitare di elaborare due volte lo stesso contenitore. Le interrogazioni di presentazione coprono le diapositive ordinarie; per un inventario a livello di pacchetto, interroga esplicitamente anche master, layout, note e i master di note e di handout quando presenti.

Il report registra un indice di diapositiva basato su 1 e [SlideId](https://reference.aspose.com/slides/it/net/aspose.slides/ibaseslide/slideid/) dove disponibile. [ISlideComponent.Slide](https://reference.aspose.com/slides/it/net/aspose.slides/islidecomponent/slide/) fornisce la diapositiva proprietaria per i contenitori supportati. Master, layout e note non hanno un indice di diapositiva ordinario e sono identificati per ambito. I contenitori di forma e di formattazione delle porzioni di testo sono etichettati separatamente; altri tipi di contenitore mantengono il nome del tipo runtime. Ogni contenitore ottiene un ID locale al report così le sue due azioni possono essere correlate.

Questa politica applicativa deliberatamente restrittiva consente solo URL HTTPS assoluti e destinazioni interne di diapositiva valide. Rifiuta macro, programmi, azioni su file, altre azioni di presentazione, azioni sconosciute e altri schemi URL. Questi rifiuti sono decisioni di politica, non un verdetto di sicurezza di Aspose.Slides. HTTPS da solo non stabilisce fiducia: aggiungi liste di host consentiti e altri controlli per la tua applicazione. Sia gli URL originali sia quelli normalizzati vengono controllati. L'esempio verifica i metadati senza seguire i collegamenti o eseguire azioni.

Per la rimodellazione, il [HyperlinkManager](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) del contenitore supporta [SetExternalHyperlinkClick](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) e [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Qui, i collegamenti click esterni proibiti sono sostituiti con una pagina di destinazione HTTPS fissa; gli altri click proibiti e le azioni mouse‑over proibite sono rimossi indipendentemente. Impostare `replaceExternalClicks` a `false` per rimuovere tutte le violazioni di politica. Scegli una pagina di sostituzione gestita dall'applicazione prima della distribuzione.

Il flag di esportazione del report utilizza una politica di revisione PDF conservatrice: segnala le azioni mouse‑over e tutto ciò che non è un collegamento esterno o un salto di diapositiva specifico come potenzialmente non supportato. È un suggerimento di revisione, non un test di capacità o una garanzia che i collegamenti non segnalati sopravvivranno all'esportazione. Le esportazioni PDF e HTML supportate possono preservare i collegamenti, a seconda dell'azione, delle opzioni di esportazione e del visualizzatore. Le [immagini](/slides/it/net/convert-powerpoint-to-png/) raster e i [video](/slides/it/net/convert-powerpoint-to-video/) non possono preservare i collegamenti interattivi; segnala ogni azione quando effettui l'audit per questi output.

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

Con l'input creato sopra, il report contiene cinque righe di azione. Il collegamento file mouse‑over e la macro click sono rimossi, mentre i collegamenti HTTPS e la navigazione interna di diapositiva rimangono. La verifica stampa zero azioni proibite. Un input contenente un URL click esterno proibito esercita anche il ramo di sostituzione. Un contenitore con un click consentito e un mouse‑over proibito mantiene la sua azione di click.

Questa pulizia selettiva differisce da [RemoveAllHyperlinks](https://reference.aspose.com/slides/it/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), che rimuove entrambi i tipi di attivazione in tutto l'ambito selezionato indipendentemente dalla politica. La verifica qui controlla solo le azioni dei collegamenti ipertestuali; non rimuove progetti VBA incorporati, oggetti OLE o altro contenuto attivo, né valida un file PDF o HTML esportato.

## **FAQ**

**Come posso collegare a una sezione o alla sua prima diapositiva?**

Le sezioni in PowerPoint raggruppano le diapositive, ma un collegamento ipertestuale interno punta a una singola diapositiva. Per creare una navigazione a una sezione, collegare alla prima diapositiva di quella sezione.

**Posso collegare un collegamento ipertestuale agli elementi del master della diapositiva affinché funzioni su tutte le diapositive?**

Sì. Gli elementi del master e del layout supportano i collegamenti ipertestuali. I collegamenti su questi elementi sono disponibili durante la presentazione su tutte le diapositive che utilizzano il master o il layout corrispondente.

**I collegamenti ipertestuali saranno mantenuti durante l'esportazione in PDF, HTML, immagini o video?**

Le esportazioni PDF e HTML supportate possono preservare i collegamenti ipertestuali; le immagini raster e i video non possono. Vedi le considerazioni sull'esportazione in [Segnalare, sanitizzare e verificare i collegamenti ipertestuali](#report-sanitize-and-verify-hyperlinks).