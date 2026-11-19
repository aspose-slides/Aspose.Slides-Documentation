---
title: Hantera hyperlänkar i presentationer i .NET
linktitle: Hantera hyperlänkar
type: docs
weight: 20
url: /sv/net/manage-hyperlinks/
keywords:
- Lägg till URL
- Lägg till hyperlänk
- Skapa hyperlänk
- Formatera hyperlänk
- Ta bort hyperlänk
- Uppdatera hyperlänk
- Texthyperlänk
- Bildhyperlänk
- Formhyperlänk
- Bildhyperlänk
- Videohyperlänk
- Ändringsbar hyperlänk
- PowerPoint
- OpenDocument
- Presentation
- .NET
- C#
- Aspose.Slides
description: "Lägg till, formatera, uppdatera och ta bort hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET, med C#-exempel."
---
## **Introduktion**

En hyperlänk kopplar presentationsinnehåll till en webbplats eller en plats inom presentationen. I PowerPoint används hyperlänkar vanligtvis för två ändamål:

* Öppna en webbplats från text, en form eller en mediaram.
* Navigera till en annan bild, till exempel från en innehållsförteckning.

Aspose.Slides för .NET låter dig lägga till dessa länkar, styra deras utseende och ljud, uppdatera deras egenskaper och ta bort dem. Exemplen nedan visar hur du arbetar med hyperlänkar på enskilda element och hur du får åtkomst till hyperlänkar på presentations-, bild- eller textram‑nivå.

{{% alert color="info" title="Note" %}}

Du kan också redigera presentationer med den [gratis online Aspose PowerPoint‑redigerare](https://products.aspose.app/slides/editor).

{{% /alert %}}

## **Lägg till URL‑hyperlänkar**

Du kan tilldela en webbplats‑URL till text, en form eller en mediaram. Det element som du tilldelar hyperlänken bestämmer det klickbara området: en textdel länkar den markerade texten, medan en form eller ram länkar bildobjektet.

För presentationer som innehåller relativa hyperlänkar, se [Hantera hyperlänkbasen](/slides/sv/net/presentation-properties/#manage-the-hyperlink-base) för att läsa, ändra eller rensa dokumentnivåbasen.

### **Lägg till URL‑hyperlänkar till text**

För att länka text till en webbplats, tilldela en [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) till textdelens [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) egenskap, som visas nedan. Endast den delen av texten blir klickbar.

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

Tilldela en URL till rektangelns [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) egenskap för att göra hela området klickbart. [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) ger läsarna en ledtråd om destinationen när de håller musen över rektangeln. Samma egenskaper gäller för bild-, ljud- och videoram.

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

Interna hyperlänkar låter läsarna hoppa från en innehållsförteckning till en specifik bild. Följande exempel använder [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) för att länka texten “Page 2” på den första bilden till den andra bilden.

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

Du kan ändra färgen på länkad text, spela upp eller stoppa ett ljud när en läsare aktiverar en länk, och ange verktygstipset som visas vid hovring.

### **Färg**

Egenskapen [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) för [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) bestämmer om en hyperlänk använder presentationens hyperlänksfärg eller textdelens formatering. För att tillämpa en anpassad textfärg, välj [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) och ange delens fyllningsfärg. Denna funktion introducerades i PowerPoint 2019; äldre versioner tillämpar inte denna inställning.

I detta exempel gör inställning av [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) på den första länken att dess text visas röd. Den andra länken behåller presentationens hyperlänksfärg.

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

En hyperlänk kan spela upp ett ljud när den aktiveras eller stoppa ett ljud som redan spelas. Använd följande egenskaper för att konfigurera dessa beteenden:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) anger ljudet som är kopplat till hyperlänken.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) styr om aktivering av hyperlänken stoppar föregående ljud.

#### **Lägg till ett hyperlänksljud**

Knappen på den första bilden använder [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) för att spela upp ljud från en WAV‑fil när läsaren klickar för att gå vidare. På den andra bilden använder en separat knapp [StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) för att stoppa uppspelning och hålla läsaren på den bilden.

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

### **Verktygstips och interaktionsinställningar**

Du kan uppdatera följande [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) egenskaper efter att ha tilldelat en hyperlänk till text eller en form:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) anger den text som en betraktare kan visa som en ledtråd för länken.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) specificerar målramen inom ett överordnat HTML‑ramverk, när tillämpligt.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) styr om aktivering av länken lägger till dess destination i listan över visade hyperlänkar.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) styr om hyperlänken markeras när den klickas.

## **Ta bort hyperlänkar från presentationer**

Använd [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) för att samla hyperlänkbehållare, inklusive textdel‑länkar, innan du ändrar dem. Följande exempel tar bort båda aktiverings typerna från den första bilden. För att bara ta bort en typ, anropa endast [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) eller [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); att ta bort en klickåtgärd tar inte bort dess mus‑över motsvarighet.

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

För ovillkorlig borttagning tar [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) bort båda aktiveringstyperna i det valda omfånget i ett anrop. För selektiv rensning och täckning av master‑bilder, layouter och anteckningar, se [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **Rensa hyperlänkar innan SmartArt‑text ersätts**

När du ersätter ett stycke i en befintlig SmartArt‑nod, kan rensning av dess textdelar lämna en gammal hyperlänk aktiv. Hämta stycket via [ISmartArtNode.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/textframe/). Innan du rensar dess delar, anropa [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) via [HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) på textramen för nodens form som visar stycket. Detta tar bort alla hyperlänkar i den ramen, inklusive länkar i dess andra stycken.

Exemplet antar att den tredje formen på den första bilden är en SmartArt‑grafik. Det ersätter det första stycket i den fjärde noden. I denna presentation visar nodens första form det stycket.

Efter att ha lagt till båda delarna läser exemplet deras effektiva formatering med [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/). Den effektiva egenskapen [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/hyperlinkclick/) returnerar den nya hyperlänken för den första delen och `null` för den andra.

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

## **Bygg ett komplett hyperlänk‑inventarium**

Innan du distribuerar en presentation, inventera dess interaktiva åtgärder samt dess webb‑länkar. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) returnerar [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/)‑objekt, inte en platt lista med URL‑strängar. Inspektera både [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) och [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) i varje behållare. De är oberoende: samma behållare kan exponera båda åtgärderna, så en komplett rapport kan behöva upp till två rader per behållare.

Att skanna endast hyperlänkar på formnivå kan missa länkar som är fästa vid textdelar. Fråga istället det lämpliga omfånget och behåll de returnerade behållarna så att du senare kan uppdatera eller ta bort deras åtgärder.

### **Fråga presentations-, bild‑ och textram‑omfång**

Gränssnittet [IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) är tillgängligt via [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/) och [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/). Varje omfång stödjer samma frågor:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) returnerar behållare med en klickåtgärd.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) returnerar behållare med en mus‑över‑åtgärd.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) returnerar behållare med någon av eller båda åtgärderna.

Detta exempel tilldelar klick‑ och mus‑över‑åtgärder till en form och dess text, samt en makro‑åtgärd till en separat knapp. Det jämför behållarna som returneras av [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) med antalet för varje aktiveringstyp. En textram‑fråga räknar endast länkar i texten. Formens egna åtgärder visas i bild‑ och presentationsfrågorna.

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

För detta exempel rapporterar presentations‑ och bildfrågor vardera tre klickbehållare, två mus‑över‑behållare och tre behållare med någon av åtgärderna. Textram‑frågan rapporterar en behållare i varje kategori.

### **Klassificera åtgärder och destinationer**

Använd [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) för att tolka en åtgärd innan du tolkar dess destination. Värdena i [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) täcker mer än webb‑navigering:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Extern hyperlänk; inspektera URL:en och dess schema. |
| `JumpSpecificSlide` | Intern navigering till en specifik bild. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Inbyggd bildspelsnavigering, löst i bildspelskontext. |
| `JumpEndShow`, `StartCustomSlideShow` | Avsluta det aktuella bildspelet eller starta ett anpassat bildspel. |
| `StartMacro` | Kör ett makro. |
| `StartProgram` | Starta ett program. |
| `OpenFile`, `OpenPresentation` | Öppna en fil eller en annan presentation; granska separat från webb‑URL:er. |
| `StartStopMedia` | Starta eller stoppa mediuppspelning. |
| `NoAction`, `Unknown` | Ingen navigeringsåtgärd, eller en okänd åtgärd som kräver granskning. |

Läs externa destinationer från [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) och specifika interna destinationer från [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/). Interna åtgärder och inbyggda kommandon kan sakna extern URL; en tom URL betyder inte att behållaren saknar åtgärd. Bevara [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) när den skiljer sig från den normaliserade URL:en, och inkludera [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) när den är tillgänglig.

### **Rapportera, sanera och verifiera hyperlänkar**

Detta .NET 6+‑exempel öppnar presentationen från föregående exempel och skriver en JSON‑post per åtgärd. Det använder [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) för att samla behållare på vanliga bilder, master‑bilder, layouter och anteckningar, inklusive antecknings‑ och utdelnings‑master‑bilder när de finns. Det använder referensjämförelse för att räkna varje behållare en gång, tillämpar policyn som beskrivs nedan och öppnar den sparade presentationen igen för att kontrollera både klick‑ och mus‑över‑åtgärder.

Rapporten registrerar ett ett‑baserat bildindex och [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) där det finns. [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) tillhandahåller den ägande bilden för stödda behållare. Master‑bilder, layouter och anteckningar har inget vanligt bildindex och identifieras efter deras omfång. Form‑behållare och textdel‑formateringsbehållare märks separat; andra behållartyper behåller sitt körningstidstyp‑namn. Varje behållare får ett rapport‑lokalt ID så att dess två åtgärder kan korreleras.

Denna avsiktligt restriktiva programpolicy tillåter endast absoluta HTTPS‑URL:er och giltiga interna målbilder. Den avvisar makron, program, filåtgärder, andra bildspelsåtgärder, okända åtgärder och andra URL‑scheman. Dessa avslag är policybeslut, inte ett Aspose.Slides‑säkerhetsbeslut. Enbart HTTPS etablerar inte förtroende: lägg till värdlistor och andra kontroller i ditt program. Både original‑ och normaliserade externa URL:er kontrolleras. Exemplet granskar metadata utan att följa länkar eller köra åtgärder.

För åtgärd stödjer behållarens [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) och [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Här ersätts förbjudna externa klicklänkar med en fast HTTPS‑landningssida; andra förbjudna klick och förbjudna mus‑över‑åtgärder tas bort oberoende. Sätt `replaceExternalClicks` till `false` för att i stället ta bort alla policyöverträdelser. Välj en applikationsägd ersättningssida innan distribution.

Rapportens exportflagga använder en konservativ PDF‑granskningspolicy: flagga mus‑över‑åtgärder och allt annat än en extern länk eller specifik bildhoppa som potentiellt ej stödda. Det är en granskningshint, inte ett kapacitetstest eller en garanti för att oflagade länkar överlever export. Stödda [PDF](/slides/sv/net/convert-powerpoint-to-pdf/)‑ och [HTML](/slides/sv/net/convert-powerpoint-to-html/)‑exporter kan bevara hyperlänkar, beroende på åtgärden, exportalternativ och visare. Raster-[images](/slides/sv/net/convert-powerpoint-to-png/) och [video](/slides/sv/net/convert-powerpoint-to-video/) kan inte bevara interaktiva hyperlänkar; flagga varje åtgärd vid granskning för dessa utdata.

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

Med den ovan skapade indatan innehåller rapporten fem åtgärdsrader. Filens mus‑över‑länk och makroklick tas bort, medan HTTPS‑länkarna och intern bildnavigering kvarstår. Verifieringen skriver ut noll förbjudna åtgärder. En indataström som innehåller en förbjuden extern klick‑URL testar även ersättningsgrenen. En behållare med ett tillåtet klick och en förbjuden mus‑över behåller sin klickåtgärd.

Denna selektiva rensning skiljer sig från [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), som tar bort båda aktiveringstyperna i hela det valda omfånget oavsett policy. Verifieringen här kontrollerar endast hyperlänksåtgärder; den tar inte bort inbäddade VBA‑projekt, OLE‑objekt eller annat aktivt innehåll, och den validerar inte en exporterad PDF‑ eller HTML‑fil.

## **Vanliga frågor**

**How can I link to a section or its first slide?**

**Hur kan jag länka till ett avsnitt eller dess första bild?**

Sections i PowerPoint grupperar bilder, men en intern hyperlänk riktar sig till en enskild bild. För att skapa navigation till ett avsnitt, länka till den första bilden i det avsnittet.

**Can I attach a hyperlink to master slide elements so it works on all slides?**

**Kan jag fästa en hyperlänk på master‑bild‑element så att den fungerar på alla bilder?**

Ja. Master‑bild‑ och layout‑element stödjer hyperlänkar. Länkar på dessa element är tillgängliga under bildspelet på bilder som använder motsvarande master eller layout.

**Will hyperlinks be preserved when exporting to PDF, HTML, images, or video?**

**Kommer hyperlänkar att bevaras vid export till PDF, HTML, bilder eller video?**

Stödda PDF‑ och HTML‑exporter kan bevara hyperlänkar; rasterbilder och video kan inte. Se exportöverväganden i [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).