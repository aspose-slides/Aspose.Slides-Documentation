---
title: Hyperlinks in presentaties beheren in .NET
linktitle: Hyperlinks beheren
type: docs
weight: 20
url: /nl/net/manage-hyperlinks/
keywords:
- URL toevoegen
- hyperlink toevoegen
- hyperlink maken
- hyperlink opmaken
- hyperlink verwijderen
- hyperlink bijwerken
- teksthyperlink
- diahyperlink
- vormhyperlink
- afbeeldinghyperlink
- video‑hyperlink
- aanpasbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Voeg hyperlinks toe, formatteer, werk bij en verwijder hyperlinks in PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor .NET, met C#‑voorbeelden."
---
## **Introductie**

Een hyperlink verbindt presentatie‑inhoud met een website of een locatie binnen de presentatie. In PowerPoint worden hyperlinks doorgaans voor twee doeleinden gebruikt:

* Open een website vanuit tekst, een vorm of een mediakader.
* Navigeer naar een andere dia, bijvoorbeeld vanaf een inhoudsopgave.

Aspose.Slides voor .NET stelt u in staat deze links toe te voegen, hun uiterlijk en geluid te beheersen, hun eigenschappen bij te werken en ze te verwijderen. De onderstaande voorbeelden laten zien hoe u met hyperlinks op individuele elementen werkt en hoe u hyperlinks op presentatie‑, dia‑ of tekstkaderniveau benadert.

{{% alert color="info" title="Note" %}}
U kunt ook presentaties bewerken met de [gratis online Aspose PowerPoint-editor](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **URL‑hyperlinks toevoegen**

U kunt een website‑URL toewijzen aan tekst, een vorm of een mediakader. Het element waaraan u de hyperlink toewijst bepaalt het klikbare gebied: een tekstgedeelte linkt de geselecteerde tekst, terwijl een vorm of kader de dia‑object linkt.

Voor presentaties met relatieve hyperlinks, zie [Beheer de hyperlinkbasis](/slides/nl/net/presentation-properties/#manage-the-hyperlink-base) om de document‑niveau basis te lezen, te wijzigen of te wissen.

### **URL‑hyperlinks toevoegen aan tekst**

Om tekst aan een website te koppelen, kent u een [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) toe aan de [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/)‑eigenschap van het tekstgedeelte, zoals hieronder getoond. Alleen dat tekstgedeelte wordt klikbaar.

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

### **URL‑hyperlinks toevoegen aan vormen en mediakaders**

Om een vorm of kader klikbaar te maken, stelt u de [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/)‑eigenschap in. De hyperlink behoort tot het object zelf en niet tot een tekstgedeelte erin.

Dezelfde benadering geldt voor afbeelding‑, audio‑ en videokaders: ken de hyperlink toe aan het kader en stel desgewenst de [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) van de link in.

Het volgende voorbeeld maakt een rechthoek klikbaar:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Hyperlinks gebruiken om een inhoudsopgave te maken**

Interne hyperlinks laten lezers springen van een inhoudsopgave naar een specifieke dia. Het volgende voorbeeld gebruikt [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) om de tekst “Pagina 2” op de eerste dia te koppelen aan de tweede dia.

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

## **Hyperlinks opmaken**

### **Kleur**

De [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/)‑eigenschap van [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) bepaalt of een hyperlink de hyperlinkkleur van de presentatie gebruikt of de opmaak van het tekstgedeelte. Om een aangepaste tekstkleur toe te passen, selecteert u [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) en stelt u de vulkleur van het gedeelte in. Deze functie werd geïntroduceerd in PowerPoint 2019; oudere versies passen deze instelling niet toe.

Het volgende voorbeeld voegt twee tekst‑hyperlinks toe aan dezelfde dia. De eerste gebruikt een rode tekstvulling, terwijl de tweede de standaard hyperlinkkleur behoudt.

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
### **Geluid**

Een hyperlink kan een geluid afspelen wanneer deze wordt geactiveerd of een al afspelend geluid stoppen. Gebruik de volgende eigenschappen om dit gedrag te configureren:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) geeft het audio‑bestand op dat aan de hyperlink is gekoppeld.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) bepaalt of het activeren van de hyperlink het vorige geluid stopt.

#### **Hyperlinkgeluid toevoegen**

Het volgende voorbeeld laadt `sampleaudio.wav` en koppelt het aan een knop op de eerste dia. Klikken op de knop speelt het geluid af en navigeert naar de volgende dia. Een tweede vorm op die dia stopt het vorige geluid bij een klik, zonder een navigatie‑actie uit te voeren.

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

#### **Hyperlinkgeluid extraheren**

Het volgende voorbeeld opent de hierboven gemaakte presentatie en leest de hyperlink‑audio van de eerste vorm in het geheugen via [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) en [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/).

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

### **Tooltip‑ en interactiesettings**

U kunt de volgende [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/)‑eigenschappen bijwerken nadat u een hyperlink aan tekst of een vorm heeft toegewezen:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) stelt de tekst in die een kijker als hint voor de link kan weergeven.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) specificeert het doelkader binnen een bovenliggende HTML‑frameset, indien van toepassing.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) bepaalt of het activeren van de link de bestemming toevoegt aan de lijst van bekeken hyperlinks.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) bepaalt of de hyperlink gemarkeerd wordt bij een klik.

## **Hyperlinks uit presentaties verwijderen**

Gebruik [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) om hyperlink‑containers, inclusief links naar tekstgedeelten, te verzamelen voordat u ze wijzigt. Het volgende voorbeeld verwijdert beide activeringstypen van de eerste dia. Om slechts één type te verwijderen, roep alleen [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) of [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) aan; het verwijderen van een klikactie verwijdert niet de bijbehorende muis‑over‑actie.

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

Voor onvoorwaardelijke verwijdering verwijdert [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) beide activeringstypen in de geselecteerde scope met één aanroep. Voor selectieve opschoning en dekking van masters, lay-outs en aantekeningen, zie [Rapport, opschonen en hyperlinks verifiëren](#report-sanitize-and-verify-hyperlinks).

## **Een volledige hyperlink‑inventaris opbouwen**

Voordat u een presentatie verspreidt, maakt u een inventaris van de interactieve acties en de web‑links. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) retourneert [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/)‑objecten, niet een eenvoudige lijst met URL‑strings. Inspecteer zowel [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) als [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) op elke container. Ze zijn onafhankelijk: dezelfde container kan beide acties blootleggen, dus een volledig rapport heeft tot twee rijen per container nodig.

Alleen hyperlinks op vormniveau scannen kan links die aan tekstgedeelten zijn gekoppeld missen. Vraag in plaats daarvan de juiste scope op en bewaar de geretourneerde containers zodat u later hun acties kunt bijwerken of verwijderen.

### **Presentatie-, dia- en tekstkaderscopes opvragen**

De [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) interface is beschikbaar via [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/) en [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/). Elke scope ondersteunt dezelfde queries:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) retourneert containers met een klik‑actie.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) retourneert containers met een muis‑over‑actie.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) retourneert containers met één of beide acties.

Het volgende voorbeeld maakt `hyperlink-audit-input.pptx` met een externe klik‑link, een bestand‑muis‑over‑link, interne dia‑navigatie, een tekst‑muis‑over‑link en een macro‑actie. Het voert geen van deze acties uit. Dezelfde drie queries werken op elke scope; de tellingen beschrijven containers, niet het totaal aantal acties. De tekstkader‑scope sluit de eigen links van de omliggende vorm uit.

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

Voor dit voorbeeld rapporteren presentatie‑ en dia‑queries elk drie klik‑containers, twee muis‑over‑containers en drie containers met één van de acties. De tekstkader‑query rapporteert één container in elke categorie.

### **Acties en bestemmingen classificeren**

Gebruik [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) om een actie te interpreteren vóór het interpreteren van de bestemming. De waarden van [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) omvatten meer dan alleen webnavigatie:

| Waarden | Betekenis voor een audit |
| --- | --- |
| `Hyperlink` | Externe hyperlink; inspecteer de URL en het schema. |
| `JumpSpecificSlide` | Interne navigatie naar een specifieke dia. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ingebouwde diavoorstellingnavigatie, opgelost in de diavoorstellingcontext. |
| `JumpEndShow`, `StartCustomSlideShow` | Beëindig de huidige show of start een aangepaste show. |
| `StartMacro` | Voer een macro uit. |
| `StartProgram` | Start een programma. |
| `OpenFile`, `OpenPresentation` | Open een bestand of een andere presentatie; afzonderlijk beoordelen van web‑URL’s. |
| `StartStopMedia` | Start of stop mediabestand afspelen. |
| `NoAction`, `Unknown` | Geen navigatie‑actie, of een niet‑herkende actie die beoordeling vereist. |

Lees externe bestemmingen uit [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) en specifieke interne bestemmingen uit [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). Interne acties en ingebouwde commando’s kunnen geen externe URL hebben; een lege URL betekent niet dat de container geen actie heeft. Bewaar [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) wanneer deze verschilt van de genormaliseerde URL, en voeg de [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) toe indien beschikbaar.

### **Rapporteren, opschonen en hyperlinks verifiëren**

Het volgende .NET 6+ voorbeeld leest een bestaande presentatie (gebruik het hierboven gemaakte bestand), schrijft `hyperlink-audit.json`, past een beleid toe, slaat `hyperlink-sanitized.pptx` op en opent het opnieuw om beide activeringstypen opnieuw te controleren. Het verzamelt containers vóór het wijzigen ervan en gebruikt referentie‑gelijkheid om te voorkomen dat dezelfde container twee keer wordt verwerkt. Presentatie‑queries bestrijken gewone dia’s; voor een pakket‑brede inventarisie vraagt het ook expliciet masters, lay-outs, aantekeningen en de aantekeningen‑ en handout‑masters op indien aanwezig.

Het rapport registreert een één‑gebaseerde dia‑index en [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) waar beschikbaar. [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) levert de eigenaar‑dia voor ondersteunde containers. Masters, lay-outs en aantekeningen hebben geen gewone dia‑index en worden geïdentificeerd op basis van hun scope. Vorm‑containers en tekst‑gedeelte‑opmaak‑containers worden afzonderlijk gelabeld; andere containertypen behouden hun runtime‑typenaam. Elke container krijgt een rapport‑lokale ID zodat de twee acties kunnen worden gecorreleerd.

Dit opzettelijk restrictieve toepassingsbeleid staat alleen absolute HTTPS‑URL’s en geldige interne diadoelwitten toe. Het wijst macro’s, programma’s, bestand‑acties, andere diavoorstelling‑acties, onbekende acties en andere URL‑schema’s af. Deze afwijzingen zijn beleidsbeslissingen, geen veiligheidsbeoordeling van Aspose.Slides. Alleen HTTPS geeft geen vertrouwen: voeg host‑toelatingslijsten en andere controles toe voor uw toepassing. Zowel de originele als de genormaliseerde externe URL’s worden gecontroleerd. Het voorbeeld controleert metadata zonder links te volgen of acties uit te voeren.

Voor herstel ondersteunt de [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) van de container [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) en [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Hier worden verboden externe klik‑links vervangen door een vaste HTTPS‑landingspagina; andere verboden klik‑ en muis‑over‑acties worden onafhankelijk verwijderd. Stel `replaceExternalClicks` in op `false` om alle beleids‑schendingen te verwijderen. Kies een door de applicatie geleverde vervangingspagina vóór implementatie.

De export‑vlag van het rapport gebruikt een conservatief PDF‑review‑beleid: markeer muis‑over‑acties en alles behalve een externe link of een specifieke dia‑sprong als potentieel niet‑ondersteund. Het is een review‑hint, geen capaciteits‑test of garantie dat niet‑gemarkeerde links de export overleven. Ondersteunde [PDF](/slides/nl/net/convert-powerpoint-to-pdf/)‑ en [HTML](/slides/nl/net/convert-powerpoint-to-html/)‑exports kunnen hyperlinks behouden, afhankelijk van de actie, exportopties en viewer. Raster‑[afbeeldingen](/slides/nl/net/convert-powerpoint-to-png/) en [video](/slides/nl/net/convert-powerpoint-to-video/) kunnen geen interactieve hyperlinks behouden; markeer elke actie bij het auditen voor die uitvoer.

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

Met de hierboven gemaakte invoer bevat het rapport vijf actierijen. De bestand‑muis‑over‑link en macro‑klik worden verwijderd, terwijl de HTTPS‑links en interne dia‑navigatie behouden blijven. De verificatie geeft nul verboden acties weer. Een invoer met een verboden externe klik‑URL test ook de vervangings‑tak. Een container met een toegestane klik en een verboden muis‑over‑actie behoudt zijn klik‑actie.

Deze selectieve opschoning verschilt van [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), die beide activeringstypen in de geselecteerde scope verwijdert, ongeacht het beleid. Verificatie hier controleert alleen hyperlink‑acties; het verwijdert geen ingebedde VBA‑projecten, OLE‑objecten of andere actieve inhoud, en het valideert geen geëxporteerde PDF‑ of HTML‑file.

## **FAQ**

**Hoe kan ik naar een sectie of de eerste dia ervan linken?**

Secties in PowerPoint groeperen dia's, maar een interne hyperlink richt zich op een individuele dia. Om navigatie naar een sectie te maken, linkt u naar de eerste dia van die sectie.

**Kan ik een hyperlink aan elementen van de masterslide koppelen zodat deze op alle dia's werkt?**

Ja. Elementen van de masterslide en lay-out ondersteunen hyperlinks. Links op deze elementen zijn beschikbaar tijdens de diavoorstelling op dia's die de corresponderende master of lay-out gebruiken.

**Worden hyperlinks behouden bij export naar PDF, HTML, afbeeldingen of video?**

Ondersteunde PDF‑ en HTML‑exports kunnen hyperlinks behouden; raster‑afbeeldingen en video kunnen dat niet. Zie de exportoverwegingen in [Rapport, opschonen en hyperlinks verifiëren](#report-sanitize-and-verify-hyperlinks).