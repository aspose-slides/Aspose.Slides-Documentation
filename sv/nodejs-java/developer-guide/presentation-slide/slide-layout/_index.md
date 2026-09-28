---
title: Tillämpa eller ändra bildlayouter i JavaScript
linktitle: Bildlayout
type: docs
weight: 60
url: /sv/nodejs-java/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationsdesign
- bilddesign
- oanvänd layout
- fotnotssynlighet
- titelsida
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Tillämpa, skapa och ändra bildlayouter i Aspose.Slides för Node.js via Java, lägg till platshållare, ta bort oanvända layouter och kontrollera fotnotssynlighet."
---
## **Översikt**

En bildlayout definierar positionerna och formateringen av platshållare såsom titlar, text, bilder, diagram och tabeller. Att tillämpa en layout ger bilder en konsekvent struktur samtidigt som varje bild kan innehålla sitt eget innehåll.

De vanligaste layouterna inkluderar:

- **Titelbild**: Innehåller platshållare för titel och undertitel.
- **Titel och Innehåll**: Innehåller en titelplatshållare och en allmän innehållsplatshållare.
- **Tom**: Innehåller inga innehållsplatshållare och är användbar när varje form placeras manuellt.

## **Förstå Layoutarv**

En presentation har tre relaterade nivåer:

1. En [master slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/) definierar temat, delad formatering, bakgrunder och gemensamma objekt.
1. En [layout slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/) tillhör en master och definierar en särskild ordning av platshållare.
1. En [normal slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/) använder en layout och lagrar innehållet som skrivits in för den bilden.

En normal bild ärver tema och formatering från sin layout, och layouten ärver från sin master. Ett värde som sätts direkt på en normal bild åsidosätter det ärvda värdet på den nivån. När en normal bild skapas genereras dess platshållarformer från den valda layouten, medan innehållet som skrivits in i dessa platshållare tillhör den normala bilden.

Lägg till erforderliga platshållare i en layout innan du skapar bilder från den. Att lägga till en ny platshållare i en layout senare lägger inte automatiskt till motsvarande platshållarform i befintliga normala bilder.

Detta förhållande har två viktiga konsekvenser:

- Att ändra ärvd formatering eller befintlig platshållargeometri på en layout kan uppdatera varje bild som beror på den. Innan du redigerar en layout som redan används, inspektera dess beroende bilder och granska den resulterande presentationen.
- En layout som fortfarande används av en bild kan inte tas bort. Tilldela först dess beroende bilder till en annan layout, eller ta bara bort oanvända layouter.

För mer information om top‑nivån i denna hierarki, se [Slide Master](/slides/sv/nodejs-java/slide-master/).

För att dölja ärvda logotyper eller dekorativa masterformer på en bild eller via en delad layout, se [Control the Visibility of Master Graphics](/slides/sv/nodejs-java/slide-master/). Exemplet jämför två bilder som använder samma master.

## **Välj och tillämpa en bildlayout**

Använd ett [SlideLayoutType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidelayouttype/)‑värde när presentationen följer standarddefinitioner för PowerPoint‑layouter. Layoutnamn kan redigeras av användaren och kan lokalanpassas, så namnbaserad urval är mindre pålitligt om du inte styr källmallen.

Följande exempel söker efter **Title and Content** på den första masteren. Om den layouten saknas faller den avsiktligt tillbaka till **Blank**. Den andra null‑kontrollen är nödvändig eftersom en presentation kan innehålla endast anpassade layouter. Den valda layouten appliceras sedan på den första normala bilden via metoden [Slide.setLayoutSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#setLayoutSlide).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Att ändra en bilds layout tar inte bort vanliga former som lagts till direkt på bilden. Däremot kan platshållarpositioner, ärvd formatering och motsvarande mellan befintliga platshållare och den nya layouten förändras, så inspektera resultatet när du byter mellan väsentligt olika layouter.

## **Lägg till en layoutbild**

Urval och skapande är separata operationer. Det föregående exemplet väljer en befintlig layout; det skapar ingen ny. För att skapa en layout, anropa metoden [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) på mål‑masterens layoutsamling.

Följande exempel lägger alltid till en ny **Title and Content**‑layout med namnet `Report Title and Content`, och lägger sedan till en normal bild baserad på den. Layoutnamn måste vara unika inom samlingen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lägg bara till en layout när mallen verkligen behöver ytterligare en återanvändbar struktur. Om en lämplig layout redan finns, välj och återanvänd den istället för att skapa en dubblett.

## **Lägg till platshållare i en layoutbild**

Metoden [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) ger en [LayoutPlaceholderManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/) för att lägga till platshållarformer i en layout.

| PowerPoint‑platshållare            | `LayoutPlaceholderManager`-metod |
| ----------------------------------- | --------------------------------- |
| ![Innehåll](content.png)            | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Innehåll (Vertikal)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertikal)](textV.png)       | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Bild](picture.png)                | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagram](chart.png)               | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabell](table.png)                | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Onlinebild](onlineImage.png)      | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Följande exempel verifierar att **Blank**‑layouten finns, lägger till fyra platshållare i den och skapar sedan en normal bild som använder den modifierade layouten. Ordningen är avsiktlig: platshållarna läggs till innan den normala bilden skapas, så att Aspose.Slides kan generera motsvarande platshållarformer på den bilden.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Platshållarna på layoutbilden](add_placeholders.png)

{{% alert color="warning" title="Varning" %}}
Att ändra ärvd formatering eller geometrin för befintliga layout‑platshållare kan påverka beroende bilder. En nyinlagd layout‑platshållare fylls inte retroaktivt i befintliga normala bilder. Testa layout‑ändringar på en kopia av presentationen och inspektera varje beroende bild.
{{% /alert %}}

## **Ta bort oanvända layoutbilder**

Använd metoden [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) för att ta bort layouter som ingen normal bild refererar till. Metoden lämnar intakta de layouter som fortfarande är i bruk.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

För att ta bort en specifik layout, använd först dess [hasDependingSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides)‑ eller [getDependingSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/#getDependingSlides)‑metod. Tilldela eventuella beroende bilder innan du anropar [LayoutSlide.remove](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/#remove). Att försöka ta bort en layout som används resulterar i ett [PptxEditException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxeditexception/).

## **Styr fotnotssynlighet på en layoutbild**

En layout har egna fotnoter, bildnummer‑ och datum‑tid‑platshållare. Använd metoden [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) för att kontrollera dessa platshållare för en specifik layout. Detta är användbart när t.ex. innehållslayouter skall visa fotnoter men titel‑layouter inte.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Styr fotnotssynlighet på en master och dess underliggande layouter**

För att tillämpa konsekventa fotnotinställningar över en masterhierarki, använd metoden [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Spridningsmetoderna i [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslideheaderfootermanager/) verkar på masteren samt dess beroende layout‑bilder och normala bilder; de riktar sig inte enbart mot en enskild normal bild.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vanliga frågor**

**Vad är skillnaden mellan en master slide och en layout slide?**

En master slide definierar presentationens tema och delade formateringar. En layout slide tillhör en master och definierar en återanvändbar ordning av platshållare. Normala bilder använder dessa layouter och lagrar bildspecifikt innehåll.

**Kan jag kopiera en layout slide från en presentation till en annan?**

Ja. Lägg till en kopia i destinationssamlingen med metoden [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). När du kopierar mellan presentationer, verifiera även teckensnitt, teman, bilder och andra resurser som används av käll‑layouten.

**Vad händer när jag ändrar en layout som redan används?**

Beroende bilder ärver layout‑ändringarna om de inte lokalt åsidosätter den påverkade formateringen eller objekten. Platshållar‑geometri och ärvd stil kan därför förändras på många bilder samtidigt. Använd [getDependingSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) för att identifiera de påverkade bilderna innan du redigerar layouten.

**Vad händer om jag tar bort en layout som fortfarande används?**

Aspose.Slides kastar ett [PptxEditException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxeditexception/). Tilldela först de beroende bilderna, eller använd [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) för att enbart ta bort orefererade layouter.