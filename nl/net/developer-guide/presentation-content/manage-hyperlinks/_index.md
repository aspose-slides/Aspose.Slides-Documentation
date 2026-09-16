---
title: Beheer presentatie‑hyperlinks in .NET
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
- videohyperlink
- aanpasbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Voeg hyperlinks toe, formatteer, werk bij en verwijder hyperlinks in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor .NET, met C#‑voorbeelden."
---
## **Inleiding**

Een hyperlink verbindt presentatietoepassing met een website of een locatie binnen de presentatie. In PowerPoint dienen hyperlinks meestal twee doelen:

* Open een website vanuit tekst, een vorm of een mediakader.
* Navigeer naar een andere dia, bijvoorbeeld vanuit een inhoudsopgave.

Aspose.Slides for .NET stelt u in staat deze koppelingen toe te voegen, hun uiterlijk en geluid te regelen, hun eigenschappen bij te werken en ze te verwijderen. De onderstaande voorbeelden laten zien hoe u met hyperlinks op individuele elementen werkt en hoe u hyperlinks op presentatieniveau, dia‑ of tekstkader‑niveau benadert.

{{% alert color="info" title="Opmerking" %}}

U kunt ook presentaties bewerken met de [gratis online Aspose PowerPoint‑editor](https://products.aspose.app/slides/nl/editor).

{{% /alert %}} 

## **URL‑hyperlinks toevoegen**

U kunt een website‑URL toewijzen aan tekst, een vorm of een mediakader. Het element waaraan u de hyperlink toekent bepaalt het klikbare gebied: een tekstgedeelte linkt de geselecteerde tekst, terwijl een vorm of kader het dia‑object linkt.

### **URL‑hyperlinks aan tekst toevoegen**

Om tekst aan een website te koppelen, kent u een [Hyperlink](https://reference.aspose.com/slides/nl/net/aspose.slides/hyperlink/) toe aan de eigenschap [HyperlinkClick](https://reference.aspose.com/slides/nl/net/aspose.slides/portionformat/hyperlinkclick/) van het tekstgedeelte, zoals hieronder getoond. Alleen dat deel van de tekst wordt klikbaar.

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

### **URL‑hyperlinks aan vormen en mediakaders toevoegen**

Om een vorm of kader klikbaar te maken, stelt u de eigenschap [HyperlinkClick](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/hyperlinkclick/) in. De hyperlink behoort tot het object zelf in plaats van tot een tekstgedeelte erin.

Dezelfde aanpak geldt voor foto‑, audio‑ en videokaders: ken de hyperlink toe aan het kader en stel, indien nodig, de [Tooltip](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/tooltip/) van de link in.

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

Interne hyperlinks laten lezers springen van een inhoudsopgave naar een specifieke dia. Het onderstaande voorbeeld gebruikt [SetInternalHyperlinkClick](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) om de tekst “Page 2” op de eerste dia te koppelen aan de tweede dia.

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

De eigenschap [ColorSource](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/colorsource/) van [IHyperlink](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/) bepaalt of een hyperlink de hyperlink‑kleur van de presentatie of de opmaak van het tekstgedeelte gebruikt. Om een aangepaste tekstkleur toe te passen, selecteert u [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/hyperlinkcolorsource/) en stelt u de vulkleur van het gedeelte in. Deze functie werd geïntroduceerd in PowerPoint 2019; oudere versies passen deze instelling niet toe.

Het volgende voorbeeld voegt twee tekst‑hyperlinks toe aan dezelfde dia. De eerste gebruikt een rode tekstvulling, terwijl de tweede de standaard hyperlink‑kleur behoudt.

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

Een hyperlink kan een geluid afspelen wanneer deze wordt geactiveerd of een reeds afgespeeld geluid stoppen. Gebruik de volgende eigenschappen om dit gedrag te configureren:

- [IHyperlink.Sound](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/sound/) specificeert het audio‑bestand dat aan de hyperlink is gekoppeld.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/stopsoundonclick/) bepaalt of het activeren van de hyperlink het vorige geluid stopt.

#### **Een hyperlink‑geluid toevoegen**

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

#### **Een hyperlink‑geluid extraheren**

Het volgende voorbeeld opent de hierboven gemaakte presentatie en leest het audio‑bestand van de eerste vorm‑hyperlink in het geheugen via [Sound](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/sound/) en [BinaryData](https://reference.aspose.com/slides/nl/net/aspose.slides/iaudio/binarydata/).

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

### **Tooltip‑ en interactie‑instellingen**

U kunt de volgende [IHyperlink](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/)‑eigenschappen bijwerken nadat u een hyperlink aan tekst of een vorm hebt toegewezen:

- [Tooltip](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/tooltip/) stelt de tekst in die een kijker kan weergeven als hint voor de link.
- [TargetFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/targetframe/) specificeert het doelkader binnen een bovenliggend HTML‑frameset, indien van toepassing.
- [History](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/history/) bepaalt of het activeren van de link de bestemming toevoegt aan de lijst van bekeken hyperlinks.
- [HighlightClick](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/highlightclick/) bepaalt of de hyperlink wordt gemarkeerd bij een klik.

## **Hyperlinks uit presentaties verwijderen**

Gebruik [GetAnyHyperlinks](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) om hyperlink‑containers, inclusief tekst‑gedeelte‑links, te verzamelen voordat u ze wijzigt. Het volgende voorbeeld verwijdert beide activeringstypen van de eerste dia. Om slechts één type te verwijderen, roep alleen [RemoveHyperlinkClick](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) of [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) aan; het verwijderen van een klik‑actie verwijdert de mouse‑over‑tegenhanger niet.

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

Voor onvoorwaardelijke verwijdering verwijdert [RemoveAllHyperlinks](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) beide activeringstypen in de geselecteerde scope in één aanroep. Voor selectieve opschoning en dekking van masters, layouts en notities, zie [Rapport, opschonen en controleren van hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Een volledige hyperlink‑inventaris opbouwen**

Voordat u een presentatie verspreidt, inventariseer u zowel de interactieve acties als de web‑links. [GetAnyHyperlinks](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) retourneert [IHyperlinkContainer](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkcontainer/)‑objecten, niet een platte lijst van URL‑strings. Inspecteer zowel [HyperlinkClick](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) als [HyperlinkMouseOver](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) op elke container. Ze zijn onafhankelijk: dezelfde container kan beide acties exposeren, dus een volledig rapport kan maximaal twee rijen per container bevatten.

Alleen hyperlinks op vormniveau scannen kan links die aan tekst‑gedeelten zijn gekoppeld missen. Vraag in plaats daarvan de juiste scope op en bewaar de geretourneerde containers zodat u later hun acties kunt bijwerken of verwijderen.

### **Presentatie‑, dia‑ en tekstkader‑scopes opvragen**

De interface [IHyperlinkQueries](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkqueries/) is beschikbaar via [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/hyperlinkqueries/) en [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/hyperlinkqueries/). Elke scope ondersteunt dezelfde queries:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) retourneert containers met een klik‑actie.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) retourneert containers met een mouse‑over‑actie.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) retourneert containers met één of beide acties.

Het volgende voorbeeld maakt `hyperlink-audit-input.pptx` aan met een externe klik‑link, een bestands‑mouse‑over‑link, interne dia‑navigatie, een tekst‑mouse‑over‑link en een macro‑actie. Het voert geen van deze acties uit. De drie queries werken in elke scope; de tellingen beschrijven containers, niet het aantal acties. De tekstkader‑scope sluit de eigen links van de omvattende vorm uit.

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

Voor dit voorbeeld rapporteren presentaties‑ en dia‑queries elk drie klik‑containers, twee mouse‑over‑containers en drie containers met één van de twee acties. De tekstkader‑query rapporteert één container in elke categorie.

### **Acties en bestemmingen classificeren**

Gebruik [IHyperlink.ActionType](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/actiontype/) om een actie te interpreteren vóórdat u de bestemming interpreteert. De waarden van [HyperlinkActionType](https://reference.aspose.com/slides/nl/net/aspose.slides/hyperlinkactiontype/) bestrijken meer dan web‑navigatie:

| Waarden | Betekenis voor een audit |
| --- | --- |
| `Hyperlink` | Externe hyperlink; inspecteer de URL en het schema. |
| `JumpSpecificSlide` | Interne navigatie naar een specifieke dia. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ingebouwde diavoorstelling‑navigatie, opgelost in de diavoorstellingscontext. |
| `JumpEndShow`, `StartCustomSlideShow` | Het huidige programma beëindigen of een aangepast programma starten. |
| `StartMacro` | Een macro uitvoeren. |
| `StartProgram` | Een programma starten. |
| `OpenFile`, `OpenPresentation` | Een bestand of een andere presentatie openen; apart beoordelen van web‑URL’s. |
| `StartStopMedia` | Media‑afspelen starten of stoppen. |
| `NoAction`, `Unknown` | Geen navigatie‑actie, of een niet‑herkende actie die nadere controle vereist. |

Lees externe bestemmingen uit [ExternalUrl](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/externalurl/) en specifieke interne bestemmingen uit [TargetSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/targetslide/). Interne acties en ingebouwde commando’s kunnen geen externe URL hebben; een lege URL betekent niet dat de container geen actie heeft. Bewaar [ExternalUrlOriginal](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/externalurloriginal/) wanneer die verschilt van de genormaliseerde URL, en neem de [Tooltip](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlink/tooltip/) op wanneer beschikbaar.

### **Rapport, opschonen en controleren van hyperlinks**

Het volgende .NET 6+‑voorbeeld leest een bestaande presentatie (gebruik het eerder aangemaakte bestand), schrijft `hyperlink-audit.json`, past een beleid toe, slaat `hyperlink-sanitized.pptx` op en opent deze opnieuw om beide activeringstypen opnieuw te controleren. Het verzamelt containers vóór wijziging en gebruikt reference‑equality om te voorkomen dat dezelfde container tweemaal wordt verwerkt. Presentatie‑queries behandelen gewone dia’s; voor een inventaris over het gehele pakket wordt expliciet ook master‑, layout‑ en notitie‑masters ge‑queryd, indien aanwezig.

Het rapport registreert een één‑gebaseerde dia‑index en, waar beschikbaar, [SlideId](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/slideid/). [ISlideComponent.Slide](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecomponent/slide/) levert de eigen dia voor ondersteunde containers. Masters, layouts en notities hebben geen gewone dia‑index en worden geïdentificeerd aan de hand van hun scope. Vorm‑containers en tekst‑gedeelte‑opmaak‑containers krijgen een apart label; andere container‑typen behouden hun runtime‑type‑naam. Elke container krijgt een rapport‑lokaal ID zodat de twee acties met elkaar kunnen worden gecorreleerd.

Dit opzettelijk restrictieve toepassingsbeleid staat alleen absolute HTTPS‑URL’s en geldige interne dia‑doelen toe. Het verwerpt macro’s, programma’s, bestands‑acties, andere diavoorstellings‑acties, onbekende acties en andere URL‑schema’s. Deze afwijzingen zijn beleidsbeslissingen, geen veiligheids‑beoordeling van Aspose.Slides. Alleen HTTPS garandeert geen vertrouwen: voeg host‑allowlists en andere controles toe voor uw toepassing. Zowel originele als genormaliseerde externe URL’s worden gecontroleerd. Het voorbeeld controleert metadata zonder links te volgen of acties uit te voeren.

Voor correctie ondersteunt de [HyperlinkManager](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) van de container [SetExternalHyperlinkClick](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) en [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Hier worden verboden externe klik‑links vervangen door een vaste HTTPS‑landingspagina; andere verboden klikken en verboden mouse‑over‑acties worden onafhankelijk verwijderd. Stel `replaceExternalClicks` in op `false` om alle beleids­schendingen te verwijderen. Kies een toepassings‑eigen vervangingspagina vóór inzet.

De export‑vlag van het rapport hanteert een conservatief PDF‑review‑beleid: markeer mouse‑over‑acties en alles behalve een externe link of een specifieke dia‑sprong als potentieel on‑ondersteund. Het is een review‑hint, geen capaciteits‑test of garantie dat niet‑gemarkeerde links behouden blijven bij export. Ondersteunde [PDF](/slides/nl/net/convert-powerpoint-to-pdf/)‑ en [HTML](/slides/nl/net/convert-powerpoint-to-html/)‑exports kunnen hyperlinks behouden, afhankelijk van de actie, export‑opties en viewer. Raster‑[images](/slides/nl/net/convert-powerpoint-to-png/) en [video](/slides/nl/net/convert-powerpoint-to-video/) kunnen geen interactieve hyperlinks behouden; markeer elke actie bij audit voor die outputs.

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

Met de hierboven gemaakte invoer bevat het rapport vijf actierijen. De bestands‑mouse‑over‑link en de macro‑klik worden verwijderd, terwijl de HTTPS‑links en interne dia‑navigatie behouden blijven. De verificatie geeft nul verboden acties weer. Een invoer met een verboden externe klik‑URL test ook de vervangings‑tak. Een container met een toegestane klik en een verboden mouse‑over behoudt zijn klik‑actie.

Deze selectieve opschoning verschilt van [RemoveAllHyperlinks](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), die beide activeringstypen in de geselecteerde scope verwijdert ongeacht beleid. Verificatie controleert hier alleen hyperlink‑acties; het verwijdert geen ingebedde VBA‑projecten, OLE‑objecten of andere actieve inhoud, en het valideert geen geëxporteerd PDF‑ of HTML‑bestand.

## **FAQ**

**Hoe kan ik naar een sectie of de eerste dia daarvan linken?**

Secties in PowerPoint groeperen dia’s, maar een interne hyperlink richt zich op een individuele dia. Om naar een sectie te navigeren, linkt u naar de eerste dia in die sectie.

**Kan ik een hyperlink aan master‑dia‑elementen koppelen zodat deze werkt op alle dia’s?**

Ja. Master‑dia‑ en layout‑elementen ondersteunen hyperlinks. Links op deze elementen zijn beschikbaar tijdens de diavoorstelling op alle dia’s die de betreffende master of layout gebruiken.

**Worden hyperlinks behouden bij export naar PDF, HTML, afbeeldingen of video?**

Ondersteunde PDF‑ en HTML‑exports kunnen hyperlinks behouden; raster‑afbeeldingen en video niet. Zie de export‑overwegingen in [Rapport, opschonen en controleren van hyperlinks](#report-sanitize-and-verify-hyperlinks).