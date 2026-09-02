---
title: Applicera eller ändra bildlayouter i .NET
linktitle: Bildlayout
type: docs
weight: 60
url: /sv/net/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationsdesign
- bilddesign
- oanvänd layout
- fotofältssynlighet
- titelslide
- titel och innehåll
- sektionrubrik
- två innehåll
- jämförelse
- endast titel
- tom layout
- innehåll med bildtext
- bild med bildtext
- titel och vertikal text
- vertikal titel och text
- PowerPoint
- OpenDocument
- presentation
- C#
- .NET
- Aspose.Slides
description: "Applicera, skapa och modifiera bildlayouter i Aspose.Slides för .NET, lägg till platshållare, ta bort oanvända layouter och kontrollera fotofältets synlighet."
---
## **Översikt**

En bildlayout definierar positionerna och formateringen av platshållare såsom titlar, text, bilder, diagram och tabeller. Att tillämpa en layout ger bilder en konsekvent struktur samtidigt som varje bild kan innehålla sitt eget innehåll.

De vanligaste layouterna inkluderar:

- **Titelslide**: Innehåller platshållare för titel och undertitel.
- **Titel och innehåll**: Innehåller en titelplatshållare och en allmän innehållsplatshållare.
- **Blank**: Innehåller inga innehållsplatshållare och är användbar när varje form placeras manuellt.

## **Förstå layoutarv**

En presentation har tre relaterade nivåer:

1. En [master slide](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslide/) definierar temat, delad formatering, bakgrunder och gemensamma objekt.
1. En [layout slide](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslide/) tillhör en master och definierar en specifik placering av platshållare.
1. En [normal slide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/) använder en layout och lagrar det innehåll som matats in för den bilden.

En normal bild ärver tema och formatering från sin layout, och layouten ärver från sin master. Ett värde som sätts direkt på en normal bild åsidosätter det ärvda värdet på den nivån. När en normal bild skapas genereras dess platshållarformer från den valda layouten, medan innehållet som matas in i dessa platshållare tillhör den normala bilden.

Lägg till nödvändiga platshållare i en layout innan du skapar bilder från den. Att senare lägga till en ny platshållare i en layout lägger inte automatiskt till motsvarande platshållarform i befintliga normala bilder.

Detta förhållande har två viktiga konsekvenser:

- Att ändra ärvd formatering eller befintlig platshållargeometri i en layout kan uppdatera varje bild som beror på den. Innan du redigerar en layout som redan används, inspektera dess beroende bilder och granska den resulterande presentationen.
- En layout som fortfarande används av en bild kan inte tas bort. Tilldela först dess beroende bilder till en annan layout, eller ta bara bort oanvända layouter.

För mer information om den översta nivån i denna hierarki, se [Slide Master](/slides/sv/net/slide-master/).

## **Välj och tillämpa en bildlayout**

Använd en layouttyp när presentationen följer standarddefinitionerna för PowerPoint‑layouter. Layoutnamn kan redigeras av användaren och kan lokalanpassas, så namnbaserad urval är mindre pålitligt om du inte kontrollerar källmallen.

Följande exempel letar efter **Title and Content** på den första masteren. Om den layouten inte finns, faller det avsiktligt tillbaka till **Blank**. Den andra null‑kontrollen är nödvändig eftersom en presentation kan innehålla endast anpassade layouter. Den valda layouten appliceras sedan på den första normala bilden via egenskapen [ISlide.LayoutSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/layoutslide/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Att ändra en bilds layout tar inte bort vanliga former som lagts till bilden direkt. Däremot kan platshållarpositioner, ärvd formatering och motsvarande mellan befintliga platshållare och den nya layouten förändras, så inspektera resultatet när du byter mellan väsentligt olika layouter.

## **Lägg till en layoutbild**

Urval och skapande är separata operationer. Det föregående exemplet väljer en befintlig layout; det skapar ingen ny. För att skapa en layout, anropa metoden [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/sv/net/aspose.slides/masterlayoutslidecollection/add/) på mål‑masterens layoutsamling.

Följande exempel lägger alltid till en ny **Title and Content**‑layout med namnet `Report Title and Content`, och lägger sedan till en normal bild baserad på den. Layoutnamn måste vara unika inom samlingen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Lägg bara till en layout när mallen verkligen behöver en ytterligare återanvändbar struktur. Om en lämplig layout redan finns, välj och återanvänd den istället för att skapa en duplikat.

## **Lägg till platshållare i en layoutbild**

Egenskapen [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslide/placeholdermanager/) erbjuder en [ILayoutPlaceholderManager](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutplaceholdermanager/) för att lägga till platshållarformer i en layout.

| PowerPoint-platshållare            | `ILayoutPlaceholderManager` metod |
| ---------------------------------- | --------------------------------- |
| ![Innehåll](content.png)           | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Innehåll (vertikal)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                  | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Text (vertikal)](textV.png)      | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Bild](picture.png)               | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Diagram](chart.png)              | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Tabell](table.png)               | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)          | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)                | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online-bild](onlineImage.png)   | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

Följande exempel verifierar att **Blank**‑layouten finns, lägger till fyra platshållare i den och skapar sedan en normal bild som använder den modifierade layouten. Ordningen är avsiktlig: platshållarna läggs till innan den normala bilden skapas, så att Aspose.Slides kan generera motsvarande platshållarformer på den bilden.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

Resultatet:

![Platshållarna på layoutbilden](add_placeholders.png)

{{% alert color="warning" title="Varning" %}}
Att ändra ärvd formatering eller geometrin för befintliga layout‑platshållare kan påverka beroende bilder. En nylagd layout‑platshållare fylls inte på i befintliga normala bilder. Testa layout‑ändringar på en kopia av presentationen och inspektera varje beroende bild.
{{% /alert %}}

## **Ta bort oanvända layoutbilder**

Använd metoden [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) för att ta bort layouter som ingen normal bild refererar till. Metoden lämnar intakta de layouter som fortfarande används.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

För att ta bort en specifik layout, använd först dess egenskap [HasDependingSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslide/hasdependingslides/) eller metod [GetDependingSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslide/getdependingslides/). Tilldela eventuella beroende bilder innan du anropar [ILayoutSlide.Remove](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslide/remove/). Försök att ta bort en layout som används ger ett [PptxEditException](https://reference.aspose.com/slides/sv/net/aspose.slides/pptxeditexception/).

## **Kontrollera fotofältets synlighet på en layoutbild**

En layout har egna platshållare för fotnot, bildnummer och datum‑/tid. Använd egenskapen [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslide/headerfootermanager/) för att styra dessa platshållare för en layout. Detta är användbart när innehållslayouter t.ex. ska visa fotnoter men titellayouter inte ska göra det.

Följande exempel väljer en layout på ett säkert sätt och gör dess fotonområden synliga:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Kontrollera fotofältets synlighet på en master och dess underordnade layouter**

För att tillämpa konsekventa fotofältinställningar över en master‑hierarki, använd egenskapen [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslide/headerfootermanager/). Spridningsmetoderna i [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslideheaderfootermanager/) verkar på masteren samt dess beroende layout‑ och normala bilder; de riktar sig inte bara mot en enskild normal bild.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **Vanliga frågor**

**Vad är skillnaden mellan en masterbild och en layoutbild?**

En masterbild definierar presentationens tema och delad formatering. En layoutbild tillhör en master och definierar ett återanvändbart arrangemang av platshållare. Normala bilder använder dessa layouter och lagrar bildspecifikt innehåll.

**Kan jag kopiera en layoutbild från en presentation till en annan?**

Ja. Lägg till en kopia i destinationssamlingen med metoden [AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/globallayoutslidecollection/addclone/). När du kopierar mellan presentationer, verifiera även teckensnitt, teman, bilder och andra resurser som layouten använder.

**Vad händer när jag ändrar en layout som redan är i bruk?**

Beroende bilder ärver layout‑ändringarna om de inte har lokalt åsidosatt den berörda formateringen eller objekten. Platshållargeometri och ärvd stil kan därför ändras på många bilder samtidigt. Använd [GetDependingSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslide/getdependingslides/) för att identifiera de påverkade bilderna innan du redigerar layouten.

**Vad händer om jag tar bort en layout som fortfarande används?**

Aspose.Slides kastar ett [PptxEditException](https://reference.aspose.com/slides/sv/net/aspose.slides/pptxeditexception/). Tilldela först de beroende bilderna, eller använd [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) för att endast ta bort orefererade layouter.