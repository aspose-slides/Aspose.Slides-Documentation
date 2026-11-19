---
title: Beheer presentatie‑hyperlinks in .NET
linktitle: Beheer hyperkoppelingen
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
- tekst hyperlink
- dia hyperlink
- vorm hyperlink
- afbeelding hyperlink
- video hyperlink
- aanpasbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Voeg hyperkoppelingen toe, formatteer, werk bij en verwijder ze in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor .NET, met C#‑voorbeelden."
---
## **Inleiding**

Een hyperlink verbindt de inhoud van een presentatie met een website of een locatie binnen de presentatie. In PowerPoint dienen hyperlinks meestal twee doelen:

* Een website openen vanuit tekst, een vorm of een mediakader.
* Navigeren naar een andere dia, bijvoorbeeld vanuit een inhoudsopgave.

Aspose.Slides for .NET stelt u in staat deze koppelingen toe te voegen, hun uiterlijk en geluid te regelen, hun eigenschappen bij te werken en ze te verwijderen. De voorbeelden hieronder laten zien hoe u met hyperlinks werkt op individuele elementen en hoe u hyperlinks benadert op presentatieniveau, dia‑niveau of tekst‑kaderniveau.

{{% alert color="info" title="Note" %}}
U kunt presentaties ook bewerken met de [gratis online Aspose PowerPoint editor](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **URL‑hyperlinks toevoegen**

U kunt een website‑URL toewijzen aan tekst, een vorm of een mediakader. Het element waaraan u de hyperlink toewijst bepaalt het klikbare gebied: een tekstgedeelte koppelt de geselecteerde tekst, terwijl een vorm of kader het dia‑object koppelt.

Voor presentaties met relatieve hyperlinks, zie [Beheer van de hyperlinkbasis](/slides/nl/net/presentation-properties/#manage-the-hyperlink-base) om de document‑niveau basis te lezen, te wijzigen of te wissen.

### **URL‑hyperlinks toevoegen aan tekst**

Om tekst naar een website te koppelen, wijst u een [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) toe aan de [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/)‑eigenschap van het tekstgedeelte, zoals hieronder weergegeven. Alleen dat gedeelte van de tekst wordt klikbaar.

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

Wijs een URL toe aan de [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/)‑eigenschap van de rechthoek om het volledige gebied klikbaar te maken. De [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) geeft lezers een hint over de bestemming wanneer ze met de muis over de rechthoek gaan. dezelfde eigenschappen gelden voor afbeelding‑, audio‑ en videokaders.

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

Interne hyperlinks laten lezers van een inhoudsopgave naar een specifieke dia springen. Het volgende voorbeeld gebruikt [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) om de tekst “Page 2” op de eerste dia te koppelen aan de tweede dia.

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

U kunt de kleur van gekoppelde tekst wijzigen, een geluid afspelen of stoppen wanneer een lezer een koppeling activeert, en de tooltip instellen die verschijnt bij aanwijzen.

### **Kleur**

De [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/)‑eigenschap van [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) bepaalt of een hyperlink de hyperlink‑kleur van de presentatie of de opmaak van het tekstgedeelte gebruikt. Om een aangepaste tekstkleur toe te passen, selecteert u [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) en stelt u de vulkleur van het gedeelte in. Deze functie werd geïntroduceerd in PowerPoint 2019; oudere versies passen deze instelling niet toe.

In dit voorbeeld zorgt het instellen van [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) op de eerste koppeling ervoor dat de tekst rood verschijnt. De tweede koppeling behoudt de hyperlink‑kleur van de presentatie.

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

Een hyperlink kan een geluid afspelen wanneer deze wordt geactiveerd of een geluid stoppen dat al afspeelt. Gebruik de volgende eigenschappen om dit gedrag te configureren:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) specificeert het audio‑bestand dat aan de hyperlink is gekoppeld.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) bepaalt of het activeren van de hyperlink het vorige geluid stopt.

#### **Een hyperlink‑geluid toevoegen**

De knop op de eerste dia gebruikt [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) om audio van een WAV‑bestand af te spelen wanneer de lezer klikt om verder te gaan. Op de tweede dia gebruikt een aparte knop [StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) om de weergave te stoppen en de lezer op die dia te houden.

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

Het volgende voorbeeld opent de hierboven gemaakte presentatie en leest het hyperlink‑audio van de eerste vorm in het geheugen via [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) en [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/).

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

U kunt de volgende [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/)‑eigenschappen bijwerken nadat u een hyperlink aan tekst of een vorm hebt toegewezen:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) stelt de tekst in die een kijker kan weergeven als hint voor de koppeling.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) specificeert het doelkader binnen een bovenliggend HTML‑frameset, indien van toepassing.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) bepaalt of het activeren van de koppeling de bestemming toevoegt aan de lijst van bekeken hyperlinks.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) bepaalt of de hyperlink wordt gemarkeerd wanneer erop wordt geklikt.

## **Hyperlinks uit presentaties verwijderen**

Gebruik [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) om hyperlink‑containers, inclusief tekst‑gedeelte‑koppelingen, te verzamelen voordat u ze wijzigt. Het volgende voorbeeld verwijdert beide activeringssoorten van de eerste dia. Om slechts één type te verwijderen, roep alleen [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) of [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) aan; het verwijderen van een klikactie verwijdert niet de bijbehorende muis‑over‑actie.

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

Voor onvoorwaardelijke verwijdering verwijdert [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) beide activeringssoorten in de geselecteerde scope met één aanroep. Voor selectieve opschoning en dekking van masters, lay-outs en notities, zie [Rapport, saniteren en verifiëren van hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **Hyperlinks wissen vóór het vervangen van SmartArt‑tekst**

Wanneer u een alinea in een bestaand SmartArt‑knooppunt vervangt, kan het wissen van de tekstgedeelten een oude hyperlink in stand houden. Haal de alinea op via [ISmartArtNode.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/textframe/). Voordat u de gedeelten wist, roept u [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) aan via [HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) op het tekstkader van het knooppunt‑vorm die de alinea weergeeft. Dit verwijdert elke hyperlink in dat kader, inclusief koppelingen in andere alinea's.

Het voorbeeld gaat ervan uit dat de derde vorm op de eerste dia een SmartArt‑grafiek is. Het vervangt de eerste alinea van het vierde knooppunt. In deze presentatie geeft de eerste vorm van het knooppunt die alinea weer.

Na het toevoegen van beide gedeelten leest het voorbeeld hun effectieve opmaak met [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/). De effectieve [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/hyperlinkclick/)‑eigenschap geeft de nieuwe hyperlink voor het eerste gedeelte terug en `null` voor het tweede.

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

## **Een volledige hyperlink‑inventaris samenstellen**

Voordat u een presentatie verspreidt, inventariseer u de interactieve acties en de webkoppelingen. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) levert [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/)‑objecten op, niet een platte lijst van URL‑strings. Inspecteer zowel [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) als [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) op elke container. Ze zijn onafhankelijk: dezelfde container kan beide acties blootleggen, zodat een volledig rapport tot twee rijen per container kan bevatten.

Alleen hyperlinks op vorm‑niveau scannen kan koppelingen missen die aan tekstgedeelten zijn gekoppeld. Vraag in plaats daarvan de juiste scope op, en bewaar de geretourneerde containers zodat u later hun acties kunt bijwerken of verwijderen.

### **Vraag presentatie‑, dia‑ en tekstkader‑scopes op**

De interface [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) is beschikbaar via [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/) en [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/). Elke scope ondersteunt dezelfde queries:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) retourneert containers met een klikactie.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) retourneert containers met een muis‑over‑actie.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) retourneert containers met een van beide of beide acties.

Dit voorbeeld kent klik‑ en muis‑over‑acties toe aan een vorm en de bijbehorende tekst, en een macro‑actie aan een aparte knop. Het vergelijkt de containers die door [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) worden geretourneerd met de tellingen voor elke activeringssoort. Een tekstkader‑query telt alleen de koppelingen in de tekst. De acties van de omvattende vorm verschijnen in de dia‑ en presentatiewaarnemingen.

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

Voor dit voorbeeld rapporteren presentatiewaarnemingen en dia‑waarnemingen elk drie klik‑containers, twee muis‑over‑containers en drie containers met een van beide acties. De tekstkader‑waarneming rapporteert één container per categorie.

### **Acties en bestemmingen classificeren**

Gebruik [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) om een actie te interpreteren alvorens de bestemming te interpreteren. De waarden van [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) omvatten meer dan webnavigatie:

| Waarden | Betekenis voor een audit |
| --- | --- |
| `Hyperlink` | Externe hyperlink; inspecteer de URL en het schema. |
| `JumpSpecificSlide` | Interne navigatie naar een specifieke dia. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ingebouwde diavoorstelling‑navigatie, opgelost in de diavoorstelling‑context. |
| `JumpEndShow`, `StartCustomSlideShow` | Huidige show beëindigen of een aangepaste show starten. |
| `StartMacro` | Een macro uitvoeren. |
| `StartProgram` | Een programma starten. |
| `OpenFile`, `OpenPresentation` | Een bestand of een andere presentatie openen; apart beoordelen van web‑URL’s. |
| `StartStopMedia` | Media‑afspelen starten of stoppen. |
| `NoAction`, `Unknown` | Geen navigatie‑actie, of een niet‑herkende actie die nader bekeken moet worden. |

Lees externe bestemmingen uit [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) en specifieke interne bestemmingen uit [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). Interne acties en ingebouwde commando’s hebben mogelijk geen externe URL; een lege URL betekent niet dat de container geen actie heeft. Bewaar [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) wanneer deze verschilt van de genormaliseerde URL, en voeg de [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) toe wanneer beschikbaar.

### **Rapport, saniteren en verifiëren van hyperlinks**

Dit .NET 6+‑voorbeeld opent de presentatie uit het vorige voorbeeld en schrijft één JSON‑record per actie. Het gebruikt [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) om containers te verzamelen op gewone dia’s, masters, lay‑outs en notities, inclusief de notitie‑ en handout‑masters wanneer aanwezig. Het gebruikt referentie‑gelijkheid om elke container één keer te tellen, past het beleid hieronder beschreven toe, en opent de opgeslagen presentatie opnieuw om zowel klik‑ als muis‑over‑acties te controleren.

Het rapport legt een één‑gebaseerde dia‑index en [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) vast waar beschikbaar. [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) levert de eigende dia voor ondersteunde containers. Masters, lay‑outs en notities hebben geen gewone dia‑index en worden geïdentificeerd door hun scope. Vorm‑containers en tekst‑gedeelte‑opmaak‑containers worden apart gelabeld; andere containertypen behouden hun runtime‑type‑naam. Elke container krijgt een rapport‑lokale ID zodat de twee acties met elkaar kunnen worden gekoppeld.

Dit opzettelijk restrictieve toepassingsbeleid staat alleen absolute HTTPS‑URL’s en geldige interne dia‑doelen toe. Het wijst macro’s, programma’s, bestandsacties, andere diavoorstelling‑acties, onbekende acties en andere URL‑schema’s af. Deze afwijzingen zijn beleids­beslissingen, geen veiligheidsoordeel van Aspose.Slides. Alleen HTTPS garandeert geen vertrouwen: voeg host‑whitelists en andere controles toe voor uw applicatie. Zowel originele als genormaliseerde externe URL’s worden gecontroleerd. Het voorbeeld controleert metadata zonder links te volgen of acties uit te voeren.

Voor herstel ondersteunt de [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) van de container [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) en [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Hier worden verboden externe klik‑links vervangen door een vaste HTTPS‑landingspagina; andere verboden klikken en verboden muis‑over‑acties worden onafhankelijk verwijderd. Stel `replaceExternalClicks` in op `false` om alle beleids­schendingen te verwijderen. Kies een door de applicatie beheerde vervangingspagina vóór implementatie.

De export‑vlag van het rapport hanteert een conservatief PDF‑review‑beleid: markeer muis‑over‑acties en alles behalve een externe link of een specifieke dia‑sprong als potentieel niet‑ondersteund. Het is een review‑hint, geen capaciteits‑test of garantie dat niet‑gemarkeerde links de export overleven. Ondersteunde [PDF](/slides/nl/net/convert-powerpoint-to-pdf/)‑ en [HTML](/slides/nl/net/convert-powerpoint-to-html/)‑exports kunnen hyperlinks behouden, afhankelijk van de actie, export‑opties en viewer. Raster‑[images](/slides/nl/net/convert-powerpoint-to-png/) en [video](/slides/nl/net/convert-powerpoint-to-video/) kunnen geen interactieve hyperlinks behouden; markeer elke actie wanneer u audit voor die uitvoerformaten.

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

Met de hierboven gemaakte invoer bevat het rapport vijf actierijen. De muis‑over‑link van het bestand en de macro‑klik worden verwijderd, terwijl de HTTPS‑links en interne dia‑navigatie behouden blijven. De verificatie geeft nul verboden acties weer. Een invoer met een verboden externe klik‑URL doorloopt eveneens de vervangings‑tak. Een container met een toegestane klik en een verboden muis‑over behoudt zijn klik‑actie.

Deze selectieve opschoning verschilt van [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), dat beide activeringssoorten door de geselecteerde scope heen verwijdert, ongeacht beleid. Verificatie in dit voorbeeld controleert alleen hyperlink‑acties; het verwijdert geen ingesloten VBA‑projecten, OLE‑objecten of andere actieve inhoud, en het valideert geen geëxporteerde PDF‑ of HTML‑bestanden.

## **FAQ**

**Hoe kan ik naar een sectie of de eerste dia daarvan linken?**

Secties in PowerPoint groeperen dia’s, maar een interne hyperlink richt zich op een individuele dia. Om naar een sectie te navigeren, linkt u naar de eerste dia van die sectie.

**Kan ik een hyperlink aan elementen van de master‑dia bevestigen zodat deze op alle dia’s werkt?**

Ja. Elementen van de master‑dia en lay‑out ondersteunen hyperlinks. Koppelingen op deze elementen zijn beschikbaar tijdens de diavoorstelling op dia’s die de betreffende master of lay‑out gebruiken.

**Worden hyperlinks behouden bij export naar PDF, HTML, afbeeldingen of video?**

Ondersteunde PDF‑ en HTML‑exports kunnen hyperlinks behouden; raster‑afbeeldingen en video niet. Zie de export‑overwegingen in [Rapport, saniteren en verifiëren van hyperlinks](#report-sanitize-and-verify-hyperlinks).