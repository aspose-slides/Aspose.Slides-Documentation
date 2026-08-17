---
title: Applicera eller ändra bildlayouter i JavaScript
linktitle: Bildlayout
type: docs
weight: 60
url: /sv/nodejs-java/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationdesign
- bilddesign
- oanvänd layout
- fotnotsynlighet
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
description: "Applicera, skapa och modifiera bildlayouter i Aspose.Slides för Node.js via Java, lägg till platshållare, ta bort oanvända layouter och kontrollera fotnotsynlighet."
---
## **Översikt**

En bildlayout definierar positionerna och formateringen av platshållare såsom titlar, text, bilder, diagram och tabeller. Att tillämpa en layout ger bilder en konsekvent struktur samtidigt som varje bild kan innehålla sitt eget innehåll.

De vanligaste layouterna inkluderar:

- **Titelsida**: Innehåller platshållare för titel och undertitel.
- **Titel och innehåll**: Innehåller en titelplatshållare och en generell innehållsplatshållare.
- **Tom**: Innehåller inga innehållsplatshållare och är användbar när varje form placeras manuellt.

## **Förstå layoutarv**

En presentation har tre relaterade nivåer:

1. En [master slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/) definierar temat, delad formatering, bakgrunder och gemensamma objekt.
1. En [layout slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/) tillhör en master och definierar en specifik arrangemang av platshållare.
1. En [normal slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/) använder en layout och lagrar det innehåll som matats in för den bilden.

En normal bild ärver tema och formatering från sin layout, och layouten ärver från sin master. Ett värde som sätts direkt på en normal bild åsidosätter det ärvda värdet på den nivån. När en normal bild skapas genereras dess platshållarformer från den valda layouten, medan innehållet som matas in i dessa platshållare tillhör den normala bilden.

Lägg till erforderliga platshållare i en layout innan du skapar bilder från den. Att senare lägga till en ytterligare platshållare i en layout lägger inte automatiskt till en motsvarande platshållarform i befintliga normala bilder.

Detta förhållande har två viktiga konsekvenser:

- Att ändra ärvd formatering eller befintlig platshållargeometri i en layout kan uppdatera varje bild som är beroende av den. Innan du redigerar en layout som redan används, inspektera dess beroende bilder och granska den resulterande presentationen.
- En layout som fortfarande används av en bild kan inte tas bort. Tilldela dess beroende bilder till en annan layout först, eller ta bara bort oanvända layouter.

För mer information om den översta nivån i denna hierarki, se [Slide Master](/slides/sv/nodejs-java/slide-master/).

## **Välj och tillämpa en bildlayout**

Använd ett [SlideLayoutType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidelayouttype/) värde när presentationen följer standard PowerPoint layoutdefinitioner. Layoutnamn kan redigeras av användaren och kan lokalanpassas, så namnbaserad urval är mindre pålitligt om du inte kontrollerar källmallen.

Följande exempel söker efter **Titel och innehåll** på den första mastern. Om den layouten inte finns, faller den avsiktligt tillbaka till **Tom**. Den andra nullkontrollen är nödvändig eftersom en presentation kan innehålla endast anpassade layouter. Den valda layouten tillämpas sedan på den första normala bilden via [Slide.setLayoutSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#setLayoutSlide) metoden.

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

Att ändra en bilds layout tar inte bort vanliga former som lagts till direkt på bilden. Däremot kan platshållarpositioner, ärvd formatering och motsvarigheten mellan befintliga platshållare och den nya layouten ändras, så inspektera utskriften när du växlar mellan väsentligt olika layouter.

## **Lägg till en layoutbild**

Urval och skapande är separata operationer. Det föregående exemplet väljer en befintlig layout; det skapar ingen. För att skapa en layout, anropa [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) metoden på målmastarens layoutsamling.

Följande exempel lägger alltid till en ny **Titel och innehåll** layout med namnet `Report Title and Content`, och lägger sedan till en normal bild baserad på den. Layoutnamn måste vara unika inom samlingen.

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

Lägg till en layout endast när mallen verkligen behöver en annan återanvändbar struktur. Om en lämplig layout redan finns, välj och återanvänd den istället för att skapa en dubblett.

## **Lägg till platshållare i en layoutbild**

Metoden [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) tillhandahåller en [LayoutPlaceholderManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/) för att lägga till platshållarformer i en layout.

| PowerPoint‑platshållare | `LayoutPlaceholderManager`‑metod |
| ----------------------- | --------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Följande exempel verifierar att **Tom** layouten finns, lägger till fyra platshållare i den och skapar sedan en normal bild som använder den modifierade layouten. Ordningen är avsiktlig: platshållarna läggs till innan den normala bilden skapas, så att Aspose.Slides kan generera de motsvarande platshållarformerna på den bilden.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Varning" %}}
Att ändra ärvd formatering eller geometrin för befintliga layoutplatshållare kan påverka beroende bilder. En nylagd layoutplatshållare fylls inte retroaktivt i befintliga normala bilder. Testa layoutändringar på en kopia av presentationen och inspektera varje beroende bild.
{{% /alert %}}

## **Ta bort oanvända layoutbilder**

Använd metoden [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) för att ta bort layouter som ingen normal bild refererar till. Metoden lämnar layouter som fortfarande används intakta.

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

För att ta bort en specifik layout, använd först dess [hasDependingSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) eller [getDependingSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) metod. Tilldela eventuella beroende bilder innan du anropar [LayoutSlide.remove](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/#remove). Att försöka ta bort en layout som används kastar ett [PptxEditException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxeditexception/).

## **Styr fotnotens synlighet på en layoutbild**

En layout har egna fot-, bildnummer- och datum‑tid‑platshållare. Använd metoden [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) för att styra dessa platshållare för en layout. Detta är användbart när t.ex. innehållslayouter ska visa fotnoter men titel‑layouter inte ska göra det.

Följande exempel väljer en layout på ett säkert sätt och gör dess fotnots‑element synliga:

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

## **Styr fotnotens synlighet på en master och dess underlayouter**

För att tillämpa konsekventa fotinställningar över en master‑hierarki, använd metoden [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Spridningsmetoderna i [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslideheaderfootermanager/) arbetar på mastern samt dess beroende layoutbilder och normala bilder; de riktar sig inte bara mot en enskild normal bild.

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

**Vad är skillnaden mellan en master‑bild och en layout‑bild?**

En master‑bild definierar presentationens tema och delad formatering. En layout‑bild tillhör en master och definierar ett återanvändbart arrangemang av platshållare. Normala bilder använder dessa layouter och lagrar bildspecifikt innehåll.

**Kan jag kopiera en layout‑bild från en presentation till en annan?**

Ja. Lägg till en kopia i destinationssamlingen med [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) metoden. Vid kopiering mellan presentationer, verifiera även typsnitt, teman, bilder och andra resurser som används av källlayouten.

**Vad händer när jag ändrar en layout som redan är i bruk?**

Beroende bilder ärver layout‑ändringarna om de inte överskriver den påverkade formateringen eller objekten lokalt. Platshållargeometri och ärvd stil kan därför förändras på många bilder samtidigt. Använd [getDependingSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) för att identifiera de påverkade bilderna innan du redigerar layouten.

**Vad händer om jag tar bort en layout som fortfarande används?**

Aspose.Slides kastar ett [PptxEditException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxeditexception/). Tilldela först de beroende bilderna på nytt, eller använd [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) för att enbart ta bort orefererade layouter.