---
title: Tillämpa eller ändra bildlayouter i Java
linktitle: Bildlayout
type: docs
weight: 60
url: /sv/java/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationsdesign
- bilddesign
- oanvänd layout
- sidfotssynlighet
- titelsida
- titel och innehåll
- sektionsrubrik
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
- Java
- Aspose.Slides
description: "Tillämpa, skapa och ändra bildlayouter i Aspose.Slides för Java, lägg till platshållare, ta bort oanvända layouter och kontrollera sidfotssynlighet."
---
## **Översikt**

En bildlayout definierar positionerna och formateringen för platshållare såsom titlar, text, bilder, diagram och tabeller. Att tillämpa en layout ger bilder en konsekvent struktur samtidigt som varje bild kan innehålla sitt eget innehåll.

De vanligaste layouterna inkluderar:

- **Title Slide**: Innehåller platshållare för titel och undertitel.
- **Title and Content**: Innehåller en titelplatshållare och en allmän innehållsplatshållare.
- **Blank**: Innehåller inga innehållsplatshållare och är användbar när varje form placeras manuellt.

## **Förstå layoutarv**

En presentation har tre relaterade nivåer:

1. En [master slide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslide/) definierar temat, delad formatering, bakgrunder och gemensamma objekt.
2. En [layout slide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutslide/) tillhör ett master och definierar en specifik placering av platshållare.
3. En [normal slide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/) använder en layout och lagrar innehållet som matats in för den bilden.

En normal bild ärver tema och formatering från sin layout, och layouten ärver från sitt master. Ett värde som sätts direkt på en normal bild åsidosätter det ärvda värdet på den nivån. När en normal bild skapas genereras dess platshållarformer från den valda layouten, medan innehållet som matas in i dessa platshållare tillhör den normala bilden.

Lägg till erforderliga platshållare i en layout innan du skapar bilder från den. Att lägga till en annan platshållare i en layout senare lägger inte automatiskt till motsvarande platshållarform i befintliga normala bilder.

Detta förhållande har två viktiga konsekvenser:

- Att ändra ärvd formatering eller befintlig platshållargeometri i en layout kan uppdatera varje bild som beror på den. Innan du redigerar en layout som redan används, inspektera dess beroende bilder och granska den resulterande presentationen.
- En layout som fortfarande används av en bild kan inte tas bort. Tilldela först dess beroende bilder till en annan layout, eller ta bara bort oanvända layouter.

För mer information om den översta nivån i denna hierarki, se [Slide Master](/slides/sv/java/slide-master/).

## **Välj och tillämpa en bildlayout**

Använd en layouttyp när presentationen följer standard PowerPoint‑layoutdefinitioner. Layoutnamn kan redigeras av användaren och kan lokalanpassas, så namn‑baserad urval är mindre pålitligt om du inte kontrollerar källmallen.

Det följande exemplet söker efter **Title and Content** på den första masteren. Om den layouten inte finns, faller det avsiktligt tillbaka till **Blank**. Den andra null‑kontrollen är nödvändig eftersom en presentation kan innehålla endast anpassade layouter. Den valda layouten appliceras sedan på den första normala bilden via metoden [ISlide.setLayoutSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Att ändra en bilds layout tar inte bort vanliga former som lagts till direkt på bilden. Dock kan platshållarpositioner, ärvd formatering och motsvarigheten mellan befintliga platshållare och den nya layouten förändras, så inspektera resultatet när du växlar mellan väsentligt olika layouter.

## **Lägg till en layoutbild**

Urval och skapande är separata operationer. Det föregående exemplet väljer en befintlig layout; det skapar ingen. För att skapa en layout, anropa metoden [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) på mål‑masterns layoutsamling.

Det följande exemplet lägger alltid till en ny **Title and Content**‑layout med namnet `Report Title and Content`, och lägger sedan till en normal bild baserad på den. Layoutnamn måste vara unika inom samlingen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lägg till en layout endast när mallen verkligen behöver en ytterligare återanvändbar struktur. Om en lämplig layout redan finns, välj och återanvänd den istället för att skapa en dublett.

## **Lägg till platshållare i en layoutbild**

Metoden [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) ger en [ILayoutPlaceholderManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutplaceholdermanager/) för att lägga till platshållarformer i en layout.

| PowerPoint‑platshållare | `ILayoutPlaceholderManager`‑metod |
| ----------------------- | --------------------------------- |
| ![Innehåll](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Innehåll (Vertikal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertikal)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Bild](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Diagram](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabell](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online‑bild](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Det följande exemplet verifierar att **Blank**‑layouten finns, lägger till fyra platshållare i den och skapar sedan en normal bild som använder den modifierade layouten. Ordningen är avsiktlig: platshållarna läggs till innan den normala bilden skapas, så Aspose.Slides kan generera motsvarande platshållarformer på den bilden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Platshållarna på layoutbilden](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Att ändra ärvd formatering eller geometrin för befintliga layout‑platshållare kan påverka beroende bilder. En nyadderad layout‑platshållare fylls inte i befintliga normala bilder. Testa layout‑ändringar på en kopia av presentationen och inspektera varje beroende bild.
{{% /alert %}}

## **Ta bort oanvända layoutbilder**

Använd metoden [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) för att ta bort layouter som ingen normal bild refererar till. Metoden lämnar layouter som fortfarande är i bruk intakta.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

För att ta bort en specifik layout, använd först dess [hasDependingSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) eller [getDependingSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) metod. Tilldela eventuella beroende bilder innan du anropar [ILayoutSlide.remove](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutslide/#remove--). Ett försök att ta bort en layout som används resulterar i ett [PptxEditException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pptxeditexception/).

## **Styr synlighet för sidfot på en layoutbild**

En layout har sina egna platshållare för sidfot, bildnummer och datum‑tid. Använd metoden [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) för att kontrollera dessa platshållare för en layout. Detta är praktiskt när till exempel innehållslayouter ska visa sidfot men titellayouter inte ska göra det.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Styr synlighet för sidfot på en master och dess underliggande layouter**

För att tillämpa konsekventa sidfot‑inställningar över en master‑hierarki, använd metoden [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Spridningsmetoderna i [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslideheaderfootermanager/) verkar på master‑objektet samt dess beroende layout‑ och normala bilder; de riktar sig inte enbart mot en normal bild.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Vad är skillnaden mellan en master‑slide och en layout‑slide?**

En master‑slide definierar presentationens tema och delade formateringar. En layout‑slide tillhör en master och definierar ett återanvändbart arrangemang av platshållare. Normala bilder använder dessa layouter och lagrar bildspecifikt innehåll.

**Kan jag kopiera en layout‑slide från en presentation till en annan?**

Ja. Lägg till en kopia i destinationssamlingen med metoden [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). När du kopierar mellan presentationer, verifiera även typsnitt, teman, bilder och andra resurser som käll‑layouten använder.

**Vad händer när jag ändrar en layout som redan är i bruk?**

Beroende bilder ärver layout‑ändringarna om de inte lokalt åsidosätter den påverkade formateringen eller objekten. Platshållargeometri och ärvd stil kan därför förändras på många bilder samtidigt. Använd [getDependingSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) för att identifiera de påverkade bilderna innan du redigerar layouten.

**Vad händer om jag tar bort en layout som fortfarande används?**

Aspose.Slides kastar ett [PptxEditException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pptxeditexception/). Tilldela först de beroende bilderna, eller använd [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) för att bara ta bort orefererade layouter.