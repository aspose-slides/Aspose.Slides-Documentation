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
description: "Aggiungi, formatta, aggiorna e rimuovi collegamenti ipertestuali nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per .NET, usando esempi in C#."
---
## **Introduzione**

Un collegamento ipertestuale collega il contenuto della presentazione a un sito web o a una posizione all'interno della presentazione. In PowerPoint, i collegamenti ipertestuali servono comunemente a due scopi:

* Aprire un sito web da testo, forma o cornice multimediale.  
* Navigare a un'altra diapositiva, ad esempio da un indice.

Aspose.Slides per .NET consente di aggiungere questi collegamenti, controllarne l'aspetto e il suono, aggiornarne le proprietà e rimuoverli. Gli esempi seguenti mostrano come lavorare con i collegamenti ipertestuali su elementi singoli e come accedere ai collegamenti a livello di presentazione, diapositiva o cornice di testo.

{{% alert color="info" title="Note" %}}
Puoi anche modificare le presentazioni con il [editor online gratuito di Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Aggiungere collegamenti URL**

Puoi assegnare un URL di un sito web a testo, forma o cornice multimediale. L'elemento a cui assegni il collegamento determina l'area cliccabile: una porzione di testo collega il testo selezionato, mentre una forma o una cornice collega l'oggetto della diapositiva.

Per le presentazioni che contengono collegamenti ipertestuali relativi, vedi [Gestire la base dei collegamenti ipertestuali](/slides/it/net/presentation-properties/#manage-the-hyperlink-base) per leggere, modificare o cancellare la base a livello di documento.

### **Aggiungere collegamenti URL al testo**

Per collegare il testo a un sito web, assegna un [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) alla proprietà [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) della porzione di testo, come mostrato di seguito. Solo quella porzione di testo diventa cliccabile.

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

### **Aggiungere collegamenti URL a forme e cornici multimediali**

Assegna un URL alla proprietà [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) del rettangolo per rendere l'intera area cliccabile. Il [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) fornisce un suggerimento sulla destinazione quando l'utente passa il mouse sul rettangolo. Le stesse proprietà si applicano a forme immagine, audio e video.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Usare i collegamenti ipertestuali per creare un indice**

I collegamenti ipertestuali interni consentono ai lettori di passare da un indice a una diapositiva specifica. L'esempio seguente utilizza [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) per collegare il testo “Page 2” sulla prima diapositiva alla seconda diapositiva.

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

Puoi modificare il colore del testo collegato, riprodurre o interrompere un suono quando un lettore attiva un collegamento e impostare il tooltip che appare al passaggio del mouse.

### **Colore**

La proprietà [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) di [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) determina se un collegamento ipertestuale utilizza il colore dei collegamenti della presentazione o la formattazione della porzione di testo. Per applicare un colore testo personalizzato, seleziona [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) e imposta il colore di riempimento della porzione. Questa funzionalità è stata introdotta in PowerPoint 2019; le versioni precedenti non applicano questa impostazione.

In questo esempio, impostare [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) sul primo collegamento fa apparire il suo testo in rosso. Il secondo collegamento mantiene il colore dei collegamenti della presentazione.

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

Un collegamento ipertestuale può riprodurre un suono quando viene attivato o interrompere un suono già in riproduzione. Usa le seguenti proprietà per configurare questi comportamenti:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) specifica l'audio associato al collegamento ipertestuale.  
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) controlla se l'attivazione del collegamento interrompe il suono precedente.

#### **Aggiungere un suono al collegamento ipertestuale**

Il pulsante sulla prima diapositiva utilizza [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) per riprodurre l'audio da un file WAV quando il lettore fa clic per avanzare. Sulla seconda diapositiva, un pulsante separato utilizza [StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) per interrompere la riproduzione e mantenere il lettore su quella diapositiva.

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

#### **Estrarre un suono dal collegamento ipertestuale**

L'esempio seguente apre la presentazione creata sopra e legge l'audio del collegamento del primo elemento nella memoria tramite [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) e [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/).

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

### **Impostazioni di tooltip e interazione**

Puoi aggiornare le seguenti proprietà di [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) dopo aver assegnato un collegamento a testo o forma:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) imposta il testo che un visualizzatore può mostrare come suggerimento per il collegamento.  
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) specifica il frame di destinazione all'interno di un frameset HTML genitore, se applicabile.  
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) controlla se l'attivazione del collegamento aggiunge la sua destinazione all'elenco dei collegamenti ipertestuali visualizzati.  
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) controlla se il collegamento è evidenziato quando viene cliccato.

## **Rimuovere i collegamenti ipertestuali dalle presentazioni**

Usa [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) per raccogliere i contenitori di collegamenti, inclusi i collegamenti di porzioni di testo, prima di modificarli. L'esempio seguente rimuove entrambi i tipi di attivazione dalla prima diapositiva. Per rimuovere solo un tipo, chiama solo [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) o [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); la rimozione di un'azione di clic non elimina la corrispondente azione al passaggio del mouse.

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

Per una rimozione incondizionata, [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) elimina entrambi i tipi di attivazione nell'ambito selezionato con una sola chiamata. Per una pulizia selettiva e la copertura di master, layout e note, vedi [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **Cancella i collegamenti ipertestuali prima di sostituire il testo SmartArt**

Quando sostituisci un paragrafo in un nodo SmartArt esistente, cancellare le sue porzioni di testo può lasciare in vigore un vecchio collegamento. Recupera il paragrafo tramite [ISmartArtNode.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/textframe/). Prima di cancellare le sue porzioni, chiama [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) tramite [HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) sulla cornice di testo della forma nodo che visualizza il paragrafo. Questo rimuove tutti i collegamenti in quella cornice, inclusi i collegamenti nei suoi altri paragrafi.

L'esempio assume che la terza forma sulla prima diapositiva sia una grafica SmartArt. Sostituisce il primo paragrafo del quarto nodo. In questa presentazione, la prima forma del nodo visualizza quel paragrafo.

Dopo aver aggiunto entrambe le porzioni, l'esempio legge la loro formattazione effettiva con [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/). La proprietà effettiva [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/hyperlinkclick/) restituisce il nuovo collegamento per la prima porzione e `null` per la seconda.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("SmartArtHyperlink.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt)slide.Shapes[2];
var node = smartArt.AllNodes[3];
var paragraph = node.TextFrame.Paragraphs[0];

node.Shapes[0].TextFrame.HyperlinkQueries.RemoveAllHyperlinks();
paragraph.Portions.Clear();

var link = new Portion("New reference");
link.PortionFormat.HyperlinkClick = new Hyperlink("https://example.com/new");
paragraph.Portions.Add(link);
var text = new Portion(" (updated)");
paragraph.Portions.Add(text);

Console.WriteLine(link.PortionFormat.GetEffective().HyperlinkClick.ExternalUrl); // https://example.com/new
Console.WriteLine(text.PortionFormat.GetEffective().HyperlinkClick?.ToString() ?? "null"); // null
```

## **Creare un inventario completo dei collegamenti ipertestuali**

Prima di distribuire una presentazione, inventaria le sue azioni interattive così come i suoi collegamenti web. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) restituisce oggetti [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/), non un elenco piatto di stringhe URL. Ispeziona sia [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) sia [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) su ciascun contenitore. Sono indipendenti: lo stesso contenitore può esporre entrambe le azioni, quindi un rapporto completo può richiedere fino a due righe per contenitore.

Scansionare solo i collegamenti a livello di forma può far perdere collegamenti allegati a porzioni di testo. Interroga l'ambito appropriato e conserva i contenitori restituiti in modo da poterli successivamente aggiornare o rimuovere le loro azioni.

### **Interrogare gli ambiti di Presentazione, Diapositiva e Cornice di testo**

L'interfaccia [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) è disponibile tramite [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/) e [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/). Ogni ambito supporta le stesse interrogazioni:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) restituisce i contenitori con un'azione di clic.  
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) restituisce i contenitori con un'azione di passaggio del mouse.  
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) restituisce i contenitori con una o entrambe le azioni.

Questo esempio assegna azioni di clic e di passaggio del mouse a una forma e al suo testo, e un'azione macro a un pulsante separato. Confronta i contenitori restituiti da [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) con i conteggi per ciascun tipo di attivazione. Un'interrogazione della cornice di testo conta solo i collegamenti nel testo. Le azioni proprie della forma di contenimento appaiono nelle interrogazioni della diapositiva e della presentazione.

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

Per questo esempio, le interrogazioni della presentazione e della diapositiva riportano ciascuna tre contenitori di clic, due di passaggio del mouse e tre contenitori con una qualsiasi delle due azioni. L'interrogazione della cornice di testo riporta un contenitore in ciascuna categoria.

### **Classificare azioni e destinazioni**

Usa [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) per interpretare un'azione prima di interpretare la sua destinazione. I valori di [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) coprono più della semplice navigazione web:

| Valori | Significato per una verifica |
| --- | --- |
| `Hyperlink` | Collegamento ipertestuale esterno; ispeziona l'URL e il suo schema. |
| `JumpSpecificSlide` | Navigazione interna a una diapositiva specifica. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigazione di presentazione integrata, risolta nel contesto della presentazione. |
| `JumpEndShow`, `StartCustomSlideShow` | Termine della presentazione corrente o avvio di una presentazione personalizzata. |
| `StartMacro` | Esecuzione di una macro. |
| `StartProgram` | Avvio di un programma. |
| `OpenFile`, `OpenPresentation` | Apertura di un file o di un'altra presentazione; esamina separatamente dagli URL web. |
| `StartStopMedia` | Avvio o interruzione della riproduzione multimediale. |
| `NoAction`, `Unknown` | Nessuna azione di navigazione, o un'azione non riconosciuta che richiede revisione. |

Leggi le destinazioni esterne da [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) e le destinazioni interne specifiche da [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). Le azioni interne e i comandi integrati potrebbero non avere un URL esterno; un URL vuoto non significa che il contenitore non abbia azioni. Conserva [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) quando differisce dall'URL normalizzato e includi il [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) quando disponibile.

### **Report, Sanitize, and Verify Hyperlinks**

Questo esempio .NET 6+ apre la presentazione dell'esempio precedente e scrive un record JSON per ogni azione. Usa [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) per raccogliere contenitori su diapositive ordinarie, master, layout e note, includendo i master di note e di opuscolo quando presenti. Usa l'uguaglianza di riferimento per contare ogni contenitore una sola volta, applica la politica descritta di seguito e riapre la presentazione salvata per verificare sia le azioni di clic sia quelle di passaggio del mouse.

Il rapporto registra un indice di diapositiva a base 1 e [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) dove disponibile. [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) fornisce la diapositiva proprietaria per i contenitori supportati. I master, i layout e le note non hanno un indice di diapositiva ordinario e sono identificati per ambito. I contenitori di forma e quelli di formattazione delle porzioni di testo sono etichettati separatamente; altri tipi di contenitore mantengono il loro nome di tipo a runtime. Ogni contenitore ottiene un ID locale al rapporto in modo che le sue due azioni possano essere correlate.

Questa politica restrittiva consente solo URL HTTPS assoluti e destinazioni interne di diapositiva valide. Rifiuta macro, programmi, azioni su file, altre azioni di presentazione, azioni sconosciute e altri schemi URL. Questi rifiuti sono decisioni di politica, non un giudizio di sicurezza di Aspose.Slides. HTTPS da solo non stabilisce fiducia: aggiungi whitelist di host e altri controlli per la tua applicazione. Sia gli URL originali che quelli normalizzati sono controllati. L'esempio esamina i metadati senza seguire i collegamenti o eseguire azioni.

Per la mitigazione, il [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) del contenitore supporta [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) e [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Qui, i collegamenti esterni di clic proibiti sono sostituiti con una pagina fissa HTTPS; gli altri clic e le azioni di passaggio del mouse proibite sono rimosse indipendentemente. Imposta `replaceExternalClicks` a `false` per rimuovere tutte le violazioni di politica. Scegli una pagina di sostituzione di proprietà dell'applicazione prima del rilascio.

Il flag di esportazione del rapporto usa una politica conservativa di revisione PDF: segnala le azioni di passaggio del mouse e tutto ciò che non è un collegamento esterno o un salto a diapositiva specifica come potenzialmente non supportato. È un suggerimento di revisione, non un test di capacità o una garanzia che i collegamenti non segnalati sopravvivranno all'esportazione. Le esportazioni supportate di [PDF](/slides/it/net/convert-powerpoint-to-pdf/) e [HTML](/slides/it/net/convert-powerpoint-to-html/) possono preservare i collegamenti, a seconda dell'azione, delle opzioni di esportazione e del visualizzatore. Le [immagini](/slides/it/net/convert-powerpoint-to-png/) raster e i [video](/slides/it/net/convert-powerpoint-to-video/) non possono preservare collegamenti interattivi; segnala ogni azione quando effettui audit per tali output.

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

Con l'input creato sopra, il rapporto contiene cinque righe di azione. Il collegamento di passaggio del mouse del file e la macro di clic sono rimossi, mentre i collegamenti HTTPS e la navigazione interna alle diapositive rimangono. La verifica stampa zero azioni proibite. Un input contenente un URL di clic esterno proibito esercita anche il ramo di sostituzione. Un contenitore con un clic consentito e un passaggio del mouse proibito mantiene la sua azione di clic.

Questa pulizia selettiva differisce da [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), che rimuove entrambi i tipi di attivazione nell'intero ambito selezionato indipendentemente dalla politica. La verifica qui controlla solo le azioni dei collegamenti ipertestuali; non rimuove progetti VBA incorporati, oggetti OLE o altro contenuto attivo, e non valida un file PDF o HTML esportato.

## **FAQ**

**Come posso collegare a una sezione o alla sua prima diapositiva?**

Le sezioni in PowerPoint raggruppano le diapositive, ma un collegamento ipertestuale interno punta a una singola diapositiva. Per creare una navigazione a una sezione, collega alla prima diapositiva di quella sezione.

**Posso allegare un collegamento ipertestuale agli elementi del master slide così da funzionare su tutte le diapositive?**

Sì. Gli elementi del master slide e del layout supportano i collegamenti ipertestuali. I collegamenti su questi elementi sono disponibili durante la presentazione nelle diapositive che utilizzano il master o il layout corrispondente.

**I collegamenti ipertestuali verranno preservati durante l'esportazione in PDF, HTML, immagini o video?**

Le esportazioni supportate di PDF e HTML possono preservare i collegamenti ipertestuali; le immagini raster e i video non possono. Vedi le considerazioni di esportazione in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).