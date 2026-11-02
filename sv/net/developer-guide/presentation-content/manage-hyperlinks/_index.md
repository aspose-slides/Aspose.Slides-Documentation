---
title: Hantera hyperlänkar i presentationer i .NET
linktitle: Hantera hyperlänkar
type: docs
weight: 20
url: /sv/net/manage-hyperlinks/
keywords:
- lägga till URL
- lägga till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- texthyperlänk
- bildhyperlänk
- formhyperlänk
- bildfilhyperlänk
- videohyperlänk
- ändringsbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lägg till, formatera, uppdatera och ta bort hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET, med C#-exempel."
---
## **Introduktion**

En hyperlänk kopplar presentationsinnehåll till en webbplats eller en plats inom presentationen. I PowerPoint används hyperlänkar vanligtvis för två ändamål:

* Öppna en webbplats från text, en form eller en mediaram.
* Navigera till en annan bild, till exempel från en innehållsförteckning.

Aspose.Slides för .NET låter dig lägga till dessa länkar, styra deras utseende och ljud, uppdatera deras egenskaper och ta bort dem. exemplen nedan visar hur du arbetar med hyperlänkar på enskilda element och hur du får åtkomst till hyperlänkar på presentations-, bild- eller textramnivå.

{{% alert color="info" title="Note" %}}
Du kan också redigera presentationer med den [gratis online Aspose PowerPoint-redigeraren](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Lägg till URL‑hyperlänkar**

Du kan tilldela en webbplats‑URL till text, en form eller en mediaram. Det element som du tilldelar hyperlänken bestämmer det klickbara området: en textdel länkar den markerade texten, medan en form eller ram länkar bildobjektet.

För presentationer som innehåller relativa hyperlänkar, se [Hantera hyperlänkbasen](/slides/sv/net/presentation-properties/#manage-the-hyperlink-base) för att läsa, ändra eller rensa dokumentnivåens bas.

### **Lägg till URL‑hyperlänkar till text**

För att länka text till en webbplats, tilldela en [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) till textdelens [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/)‑egenskap, som visas nedan. Endast den textdelen blir klickbar.

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

### **Lägg till URL‑hyperlänkar till former och mediaramar**

För att göra en form eller ram klickbar, ange dess [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/)‑egenskap. Hyperlänken tillhör själva objektet snarare än en textdel inuti det.

Samma metod gäller för bild-, ljud- och videoram: tilldela hyperlänken till ramen och ställ in ramens [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) om så behövs.

Följande exempel gör en rektangel klickbar:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Använd hyperlänkar för att skapa en innehållsförteckning**

Interna hyperlänkar låter läsare hoppa från en innehållsförteckning till en specifik bild. Följande exempel använder [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) för att länka texten “Page 2” på den första bilden till den andra bilden.

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

## **Formatera hyperlänkar**

### **Färg**

Egenskapen [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) för [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) bestämmer om en hyperlänk använder presentationens hyperlänkfärg eller textdelens formatering. För att använda en anpassad textfärg, välj [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) och ange delens fyllnadsfärg. Denna funktion introducerades i PowerPoint 2019; äldre versioner använder inte denna inställning.

Följande exempel lägger till två texthyperlänkar på samma bild. Den första använder en röd textfyllning, medan den andra behåller standardhyperlänkfärgen.

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
### **Ljud**

En hyperlänk kan spela ett ljud när den aktiveras eller stoppa ett ljud som redan spelas. Använd följande egenskaper för att konfigurera dessa beteenden:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) anger ljudet som är kopplat till hyperlänken.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) styr om aktiveringen av hyperlänken stoppar föregående ljud.

#### **Lägg till ett hyperlänksljud**

Följande exempel läser in `sampleaudio.wav` och kopplar den till en knapp på den första bilden. När knappen klickas spelas ljudet och navigerar till nästa bild. En andra form på samma bild stoppar det föregående ljudet när den klickas, utan att utföra någon navigationsåtgärd.

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

#### **Extrahera ett hyperlänksljud**

Följande exempel öppnar presentationen som skapades ovan och läser den första formens hyperlänksljud till minnet via [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) och [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/).

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

### **Verktygstips‑ och interaktionsinställningar**

Du kan uppdatera följande [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/)‑egenskaper efter att du tilldelat en hyperlänk till text eller en form:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) anger den text som en betraktare kan visa som ett tips för länken.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) specificerar målramen inom en överordnad HTML‑ramuppsättning, när tillämpligt.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) styr om aktiveringen av länken lägger till dess destination i listan över visade hyperlänkar.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) styr om hyperlänken markeras när den klickas.

## **Ta bort hyperlänkar från presentationer**

Använd [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) för att samla in hyperlänkbehållare, inklusive länkar för textdelar, innan du ändrar dem. Följande exempel tar bort båda aktiveringstyperna från den första bilden. För att bara ta bort en typ, anropa endast [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) eller [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); att ta bort en klickåtgärd tar inte bort motsvarande mus‑över‑åtgärd.

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

För villkorsfri borttagning tar [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) bort båda aktiveringstyperna i det valda omfånget i ett anrop. För selektiv rensning och täckning av master‑bilder, layout och anteckningar, se [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Bygg ett fullständigt hyperlänksregister**

Innan du distribuerar en presentation, inventera dess interaktiva åtgärder samt dess webblänkar. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) returnerar [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/)‑objekt, inte en platt lista med URL‑strängar. Inspektera både [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) och [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) för varje behållare. De är oberoende: samma behållare kan erbjuda båda åtgärderna, så en komplett rapport kan behöva upp till två rader per behållare.

Att bara skanna hyperlänkar på formnivå kan missa länkar som är kopplade till textdelar. Fråga istället rätt omfång och behåll de returnerade behållarna så att du senare kan uppdatera eller ta bort deras åtgärder.

### **Fråga presentation, bild och textram‑omfång**

Gränssnittet [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) är tillgängligt via [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/), och [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/). Varje omfång stöder samma frågor:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) returnerar behållare med en klickåtgärd.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) returnerar behållare med en mus‑över‑åtgärd.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) returnerar behållare med någon av eller båda åtgärderna.

Följande exempel skapar `hyperlink-audit-input.pptx` med en extern klicklänk, en fil‑mus‑över‑länk, intern bildnavigering, en text‑mus‑över‑länk och en makroåtgärd. Det kör inte någon av dessa åtgärder. Samma tre frågor fungerar i varje omfång; räknarna beskriver behållare, inte totalt antal åtgärder. Textram‑omfånget utesluter den omgivande formens egna länkar.

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

För detta exempel rapporterar presentation‑ och bild‑frågor vardera tre klickbehållare, två mus‑över‑behållare och tre behållare med någon av åtgärderna. Textram‑frågan rapporterar en behållare i varje kategori.

### **Klassificera åtgärder och destinationer**

Använd [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) för att tolka en åtgärd innan du tolkar dess destination. Värdena i [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) täcker mer än webbnavigering:

| Värden | Betydelse för en revision |
| --- | --- |
| `Hyperlink` | Extern hyperlänk; granska URL‑en och dess schema. |
| `JumpSpecificSlide` | Intern navigering till en specifik bild. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Inbyggd bildspelsnavigering, löst i bildspelskontext. |
| `JumpEndShow`, `StartCustomSlideShow` | Avsluta det aktuella bildspelet eller starta ett anpassat bildspel. |
| `StartMacro` | Kör ett makro. |
| `StartProgram` | Starta ett program. |
| `OpenFile`, `OpenPresentation` | Öppna en fil eller en annan presentation; granska separat från webbadresser. |
| `StartStopMedia` | Starta eller stoppa medieuppspelning. |
| `NoAction`, `Unknown` | Ingen navigeringsåtgärd, eller en okänd åtgärd som kräver granskning. |

Läs externa destinationer från [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) och specifika interna destinationer från [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). Interna åtgärder och inbyggda kommandon kan sakna extern URL; en tom URL betyder inte att behållaren saknar åtgärd. Bevara [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) när den skiljer sig från den normaliserade URL‑en, och inkludera [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) när den finns tillgänglig.

### **Rapportera, sanera och verifiera hyperlänkar**

Följande .NET 6+‑exempel läser en befintlig presentation (använd filen som skapades ovan), skriver `hyperlink-audit.json`, tillämpar en policy, sparar `hyperlink-sanitized.pptx` och öppnar den igen för att kontrollera båda aktiveringstyperna igen. Det samlar in behållare innan de ändras och använder referensjämförelse för att undvika att bearbeta samma behållare två gånger. Presentationsfrågor täcker vanliga bilder; för ett paketomfattande register frågar det också explicit master‑bilder, layouter, anteckningar samt antecknings‑ och utdelnings‑master‑bilder när de finns.

Rapporten lagrar ett ett-baserat bildindex och [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) där det finns. [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) tillhandahåller den ägande bilden för de stödda behållarna. Master‑bilder, layouter och anteckningar har inget vanligt bildindex och identifieras efter sitt omfång. Form‑behållare och formaterings‑behållare för textdelar märks separat; andra behållartyper behåller sitt kör‑tids‑typnamn. Varje behållare får ett rapport‑lokalt ID så att dess två åtgärder kan korreleras.

Denna avsiktligt restriktiva applikationspolicy tillåter endast absoluta HTTPS‑URL:er och giltiga interna bildmål. Den avvisar makron, program, filåtgärder, andra bildspelsåtgärder, okända åtgärder och andra URL‑scheman. Dessa avslag är policybeslut, inte ett säkerhetsbeslut från Aspose.Slides. Enbart HTTPS skapar inte förtroende: lägg till värd‑allowlists och andra kontroller för din applikation. Både original‑ och normaliserade externa URL:er kontrolleras. Exemplet granskar metadata utan att följa länkar eller köra åtgärder.

För korrigering stödjer behållarens [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) och [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Här ersätts förbjudna externa klicklänkar med en fast HTTPS‑landningssida; andra förbjudna klick och förbjudna mus‑över‑åtgärder tas bort oberoende av varandra. Sätt `replaceExternalClicks` till `false` för att istället ta bort alla policy‑överträdelse. Välj en applikationsägd ersättningssida innan distribution.

Rapportens exportflagga använder en konservativ PDF‑granskningspolicy: flagga mus‑över‑åtgärder och allt annat än en extern länk eller ett specifikt bildsprång som potentiellt ej stödjat. Det är en granskningshint, inte ett kapabilitetstest eller en garanti för att ej flaggade länkar överlever export. Stödda [PDF](/slides/sv/net/convert-powerpoint-to-pdf/)‑ och [HTML](/slides/sv/net/convert-powerpoint-to-html/)‑exporter kan bevara hyperlänkar, beroende på åtgärd, exportalternativ och visare. Raster‑[images](/slides/sv/net/convert-powerpoint-to-png/) och [video](/slides/sv/net/convert-powerpoint-to-video/) kan inte bevara interaktiva hyperlänkar; flagga varje åtgärd vid granskning för dessa utdata.

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

Med den indata som skapades ovan innehåller rapporten fem åtgärdsrader. Fil‑mus‑över‑länken och makro‑klicket tas bort, medan HTTPS‑länkarna och den interna bildnavigeringen kvarstår. Verifieringen visar noll förbjudna åtgärder. En indata som innehåller en förbjuden extern klick‑URL testar även ersättningsgrenen. En behållare med ett tillåtet klick och ett förbjudet mus‑över‑åtgärd behåller sin klickåtgärd.

Denna selektiva rensning skiljer sig från [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), som tar bort båda aktiveringstyperna i hela det valda omfånget oavsett policy. Verifieringen här kontrollerar endast hyperlänkåtgärder; den tar inte bort inbäddade VBA‑projekt, OLE‑objekt eller annat aktivt innehåll, och den validerar inte en exporterad PDF‑ eller HTML‑fil.

## **FAQ**

**Hur kan jag länka till ett avsnitt eller dess första bild?**

Avsnitt i PowerPoint grupperar bilder, men en intern hyperlänk riktar sig mot en enskild bild. För att skapa navigering till ett avsnitt, länka till den första bilden i det avsnittet.

**Kan jag fästa en hyperlänk på master‑bildselement så att den fungerar på alla bilder?**

Ja. Master‑bilder och layout‑element stöder hyperlänkar. Länkar på dessa element är tillgängliga under bildspelet på bilder som använder den motsvarande master‑ eller layout‑bilden.

**Kommer hyperlänkar att bevaras vid export till PDF, HTML, bilder eller video?**

Stödda PDF‑ och HTML‑exporter kan bevara hyperlänkar; rasterbilder och video kan inte. Se exportaspekterna i [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).