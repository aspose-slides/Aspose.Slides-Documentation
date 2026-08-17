---
title: Tillämpa eller ändra bildlayouter på Android
linktitle: Bildlayout
type: docs
weight: 60
url: /sv/androidjava/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationsdesign
- bilddesign
- oanvänd layout
- sidfotssynlighet
- titelbild
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
- Android
- Java
- Aspose.Slides
description: "Tillämpa, skapa och modifiera bildlayouter i Aspose.Slides för Android via Java, lägg till platshållare, ta bort oanvända layouter och kontrollera sidfotssynlighet."
---
## **Översikt**

En bildlayout definierar positionerna och formateringen av platshållare såsom titlar, text, bilder, diagram och tabeller. Att använda en layout ger bilder en konsekvent struktur samtidigt som varje bild kan innehålla sitt eget innehåll.

De vanligaste layouterna inkluderar:

- **Titelslide**: Innehåller platshållare för titel och undertitel.
- **Titel och innehåll**: Innehåller en titel‑platshållare och en allmän innehållsplatshållare.
- **Tom**: Innehåller inga innehållsplatshållare och är användbar när varje form placeras manuellt.

## **Förstå layoutarv**

En presentation har tre relaterade nivåer:

1. En [master slide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslide/) definierar temat, gemensam formatering, bakgrunder och vanliga objekt.
2. En [layout slide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutslide/) tillhör en master och definierar en specifik placering av platshållare.
3. En [normal slide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/) använder en layout och lagrar innehållet som matats in för den bilden.

En normal bild ärver tema och formatering från sin layout, och layouten ärver från sin master. Ett värde som sätts direkt på en normal bild åsidosätter det ärvda värdet på den nivån. När en normal bild skapas genereras dess platshållarformer från den valda layouten, medan innehållet som matats in i dessa platshållare tillhör den normala bilden.

Lägg till nödvändiga platshållare i en layout innan du skapar bilder från den. Att senare lägga till en ytterligare platshållare i en layout lägger inte automatiskt till motsvarande platshållarform i befintliga normala bilder.

Detta förhållande har två viktiga konsekvenser:

- Att ändra ärvd formatering eller befintlig platshållargeometri i en layout kan uppdatera varje bild som beror på den. Innan du redigerar en layout som redan används, inspektera dess beroende bilder och granska den resulterande presentationen.
- En layout som fortfarande används av en bild kan inte tas bort. Tilldela först dess beroende bilder till en annan layout, eller ta bara bort oanvända layouter.

För mer information om översta nivån i denna hierarki, se [Slide Master](/slides/sv/androidjava/slide-master/).

## **Välj och tillämpa en bildlayout**

Använd en layouttyp när presentationen följer standard PowerPoint‑layoutdefinitioner. Layoutnamn kan redigeras av användaren och kan lokalanpassas, så namn‑baserad urval är mindre pålitligt om du inte styr källmallen.

Det följande exemplet söker efter **Titel och innehåll** på den första masteren. Om den layouten inte finns, faller det avsiktligt tillbaka till **Tom**. Den andra null‑kontrollen är nödvändig eftersom en presentation kan innehålla endast anpassade layouter. Den valda layouten tillämpas sedan på den första normala bilden via metoden [ISlide.setLayoutSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

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

Att ändra en bilds layout tar inte bort vanliga former som lagts till direkt på bilden. Däremot kan platshållarpositioner, ärvd formatering och motsvarigheten mellan befintliga platshållare och den nya layouten förändras, så inspektera resultatet när du växlar mellan avsevärt olika layouter.

## **Lägg till en layoutbild**

Urval och skapande är separata operationer. Det föregående exemplet väljer en befintlig layout; den skapar ingen. För att skapa en layout, anropa metoden [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) på mål‑masterens layoutsamling.

Det följande exemplet lägger alltid till en ny **Titel och innehåll**‑layout med namnet `Report Title and Content`, och lägger sedan till en normal bild baserad på den. Layoutnamn måste vara unika inom samlingen.

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

Lägg bara till en layout när mallen verkligen behöver en ytterligare återanvändbar struktur. Om en lämplig layout redan finns, välj och återanvänd den istället för att skapa en duplicat.

## **Lägg till platshållare i en layoutbild**

Metoden [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) tillhandahåller en [ILayoutPlaceholderManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) för att lägga till platshållarformer i en layout.

| PowerPoint‑platshållare | `ILayoutPlaceholderManager` Method |
| ----------------------- | ---------------------------------- |
| ![Innehåll](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Innehåll (Vertikal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertikal)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Bild](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Diagram](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabell](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online‑bild](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Det följande exemplet verifierar att **Tom**‑layouten finns, lägger till fyra platshållare i den och skapar sedan en normal bild som använder den modifierade layouten. Ordningen är avsiktlig: platshållarna läggs till innan den normala bilden skapas, så att Aspose.Slides kan generera motsvarande platshållarformer på den bilden.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Varning" %}}
Att ändra ärvd formatering eller geometrin för befintliga layout‑platshållare kan påverka beroende bilder. En nylagd layout‑platshållare fylls inte retroaktivt i befintliga normala bilder. Testa layout‑ändringar på en kopia av presentationen och inspektera varje beroende bild.
{{% /alert %}}

## **Ta bort oanvända layoutbilder**

Använd metoden [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) för att ta bort layouter som ingen normal bild refererar till. Metoden lämnar intakta de layouter som fortfarande är i bruk.

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

För att ta bort en specifik layout, använd först dess [hasDependingSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--)‑ eller [getDependingSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--)‑metod. Tilldela om eventuella beroende bilder innan du anropar [ILayoutSlide.remove](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutslide/#remove--). Att försöka ta bort en layout som används kastar ett [PptxEditException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxeditexception/).

## **Styr synlighet för sidfot på en layoutbild**

En layout har sina egna sidfot-, bildnummer- och datum‑tid‑platshållare. Använd metoden [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) för att styra dessa platshållare för en layout. Detta är användbart när exempelvis innehållslayouter ska visa sidfötter men titellayouter inte ska göra det.

Det följande exemplet väljer en layout på ett säkert sätt och gör dess sidfotelement synliga:

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

## **Styr sidfotssynlighet på en master och dess underliggande layouter**

För att tillämpa enhetliga sidfotinställningar över en master‑hierarki, använd metoden [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Spridningsmetoderna i [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) verkar på masteren samt dess beroende layout‑bilder och normala bilder; de riktar sig inte bara mot en enskild normal bild.

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

## **Vanliga frågor**

**Vad är skillnaden mellan en master slide och en layout slide?**

En master slide definierar presentationens tema och delad formatering. En layout slide tillhör en master och definierar ett återanvändbart arrangemang av platshållare. Normala slides använder dessa layouter och lagrar bildspecifikt innehåll.

**Kan jag kopiera en layout slide från en presentation till en annan?**

Ja. Lägg till en kopia i destinationssamlingen med metoden [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). När du kopierar mellan presentationer, verifiera även teckensnitt, teman, bilder och andra resurser som används av källlayouten.

**Vad händer när jag modifierar en layout som redan är i bruk?**

Beroende bilder ärver layout‑ändringarna om de inte åsidosätter den påverkade formateringen eller objekten lokalt. Platshållargeometri och ärvd stil kan därför förändras på många bilder samtidigt. Använd [getDependingSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) för att identifiera de påverkade bilderna innan du redigerar layouten.

**Vad händer om jag tar bort en layout som fortfarande är i bruk?**

Aspose.Slides kastar ett [PptxEditException](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pptxeditexception/). Tilldela om de beroende bilderna först, eller använd [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) för att bara ta bort orefererade layouter.