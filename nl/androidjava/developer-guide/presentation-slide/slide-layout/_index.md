---
title: Toepassen of wijzigen van slide‑layouts op Android
linktitle: Slide‑layout
type: docs
weight: 60
url: /nl/androidjava/slide-layout/
keywords:
- slide‑layout
- inhouds‑layout
- plaatsaanduiding
- presentatieontwerp
- slide‑ontwerp
- ongebruikte layout
- voettekst‑zichtbaarheid
- titel‑dia
- titel en inhoud
- sectiekop
- twee inhoud
- vergelijking
- alleen titel
- lege layout
- inhoud met bijschrift
- afbeelding met bijschrift
- titel en verticale tekst
- verticale titel en tekst
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Pas slide‑layouts toe, maak ze aan en wijzig ze in Aspose.Slides voor Android via Java, voeg plaatsaanduidingen toe, verwijder ongebruikte layouts en beheer de voettekst‑zichtbaarheid."
---
## **Overzicht**

Een slide‑layout definieert de posities en opmaak van plaatsaanduidingen zoals titels, tekst, afbeeldingen, diagrammen en tabellen. Het toepassen van een layout geeft dia’s een consistente structuur terwijl elke dia zijn eigen inhoud kan bevatten.

De meest voorkomende layouts zijn:

- **Titel-dia**: Bevat plaatsaanduidingen voor titel en ondertitel.
- **Titel en inhoud**: Bevat een titelplaatsaanduiding en een algemene inhoudsplaatsaanduiding.
- **Leeg**: Bevat geen inhoudsplaatsaanduidingen en is nuttig wanneer elke vorm handmatig wordt geplaatst.

## **Begrijp layout‑erfenis**

Een presentatie kent drie gerelateerde niveaus:

1. Een [masterdia](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/) definieert het thema, gedeelde opmaak, achtergronden en gemeenschappelijke objecten.  
1. Een [layoutdia](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/) behoort tot een master en bepaalt een specifieke rangschikking van plaatsaanduidingen.  
1. Een [normale dia](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/) gebruikt één layout en slaat de ingevoerde inhoud voor die dia op.

Een normale dia erft thema en opmaak van zijn layout, en de layout erft van zijn master. Een waarde die direct op een normale dia wordt ingesteld, overschrijft de geërfde waarde op dat niveau. Wanneer een normale dia wordt aangemaakt, worden de plaatsaanduidingsvormen gegenereerd uit de gekozen layout, terwijl de ingevoerde inhoud in die plaatsaanduidingen tot de normale dia behoort.

Voeg verplichte plaatsaanduidingen toe aan een layout voordat je dia’s ervan maakt. Een later toegevoegde plaatsaanduiding aan een layout wordt niet automatisch toegevoegd aan bestaande normale dia’s.

Deze relatie heeft twee belangrijke consequenties:

- Het wijzigen van geërfde opmaak of bestaande plaatsaanduidingsgeometrie op een layout kan elke dia die ervan afhankelijk is updaten. Inspecteer vóór het bewerken van een reeds in gebruik zijnde layout de afhankelijke dia’s en bekijk de resulterende presentatie.  
- Een layout die nog door een dia wordt gebruikt, kan niet worden verwijderd. Wijs eerst de afhankelijke dia’s opnieuw toe aan een andere layout, of verwijder alleen ongebruikte layouts.

Voor meer informatie over het bovenste niveau van deze hiërarchie, zie [Slide Master](/slides/nl/androidjava/slide-master/).

## **Selecteer en pas een slide‑layout toe**

Gebruik een layouttype wanneer de presentatie standaard PowerPoint‑layoutdefinities volgt. Layoutnamen zijn bewerkbaar door de gebruiker en kunnen worden gelokaliseerd, waardoor naamgebaseerde selectie minder betrouwbaar is tenzij je de bron‑template beheert.

Het volgende voorbeeld zoekt **Titel en inhoud** op de eerste master. Als die layout niet beschikbaar is, valt het bewust terug op **Leeg**. De tweede null‑check is nodig omdat een presentatie uitsluitend aangepaste layouts kan bevatten. De gekozen layout wordt vervolgens toegepast op de eerste normale dia via de [ISlide.setLayoutSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) methode.

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

Het wijzigen van de layout van een dia verwijdert niet de gewone vormen die rechtstreeks aan de dia zijn toegevoegd. Plaatsaanduidingsposities, geërfde opmaak en de correspondentie tussen bestaande plaatsaanduidingen en de nieuwe layout kunnen echter veranderen, dus inspecteer de output bij het overschakelen tussen aanzienlijk verschillende layouts.

## **Voeg een layoutdia toe**

Selectie en creatie zijn aparte handelingen. Het vorige voorbeeld selecteert een bestaande layout; het maakt er geen nieuwe aan. Om een layout te maken, roep je de [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) methode aan op de layout‑collectie van de doel‑master.

Het volgende voorbeeld voegt altijd een nieuwe **Titel en inhoud** layout toe met de naam `Report Title and Content`, en voegt vervolgens een normale dia toe die daarop gebaseerd is. Layoutnamen moeten uniek zijn binnen de collectie.

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

Voeg alleen een layout toe wanneer de template werkelijk een extra herbruikbare structuur nodig heeft. Als er al een geschikte layout bestaat, selecteer en hergebruik die in plaats van een duplicaat te maken.

## **Voeg plaatsaanduidingen toe aan een layoutdia**

De [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) methode levert een [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) voor het toevoegen van plaatsaanduidingsvormen aan een layout.

| PowerPoint-plaatshouder | `ILayoutPlaceholderManager` Methode |
| ----------------------- | ----------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Het volgende voorbeeld controleert of de **Leeg** layout bestaat, voegt vier plaatsaanduidingen toe en maakt daarna een normale dia die de aangepaste layout gebruikt. De volgorde is opzettelijk: de plaatsaanduidingen worden toegevoegd vóór het aanmaken van de normale dia, zodat Aspose.Slides de overeenkomende plaatsaanduidingsvormen op die dia kan genereren.

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

Het resultaat:

![De plaatsaanduidingen op de layoutdia](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}

Het wijzigen van geërfde opmaak of de geometrie van bestaande layout‑plaatsaanduidingen kan afhankelijke dia’s beïnvloeden. Een nieuw toegevoegde layout‑plaatsaanduiding wordt niet achteraf ingevoegd in bestaande normale dia’s. Test layout‑wijzigingen op een kopie van de presentatie en inspecteer elke afhankelijke dia.

{{% /alert %}}

## **Verwijder ongebruikte layoutdia’s**

Gebruik de [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) methode om layouts te verwijderen die door geen enkele normale dia worden gerefereerd. De methode laat layouts die nog in gebruik zijn ongewijzigd.

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

Om één specifieke layout te verwijderen, gebruik eerst de [hasDependingSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) of [getDependingSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) methode. Wijs eventuele afhankelijke dia’s opnieuw toe voordat je [ILayoutSlide.remove](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#remove--) aanroept. Het proberen te verwijderen van een gebruikte layout veroorzaakt een [PptxEditException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxeditexception/).

## **Regel voettekst‑zichtbaarheid op een layoutdia**

Een layout heeft zijn eigen voettekst‑, dia‑nummer‑ en datum‑tijd‑plaatsaanduidingen. Gebruik de [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) methode om die plaatsaanduidingen voor één layout te beheren. Dit is handig wanneer, bijvoorbeeld, inhoud‑layouts voetteksten moeten tonen maar titel‑layouts niet.

Het volgende voorbeeld selecteert een layout veilig en maakt de voettekstelementen zichtbaar:

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

## **Regel voettekst‑zichtbaarheid op een master en diens onderliggende layouts**

Om consistente voettekstinstellingen door de hele master‑hiërarchie toe te passen, gebruik je de [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) methode. De propagatiemethoden van [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) werken op de master, diens afhankelijke layoutdia’s en normale dia’s; ze richten zich niet alleen op één normale dia.

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

**Wat is het verschil tussen een masterdia en een layoutdia?**

Een masterdia definieert het thema en de gedeelde opmaak van de presentatie. Een layoutdia behoort tot een master en bepaalt één herbruikbare rangschikking van plaatsaanduidingen. Normale dia’s gebruiken die layouts en slaan dia‑specifieke inhoud op.

**Kan ik een layoutdia van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de bestemmingscollectie met de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) methode. Bij het kopiëren tussen presentaties moet je ook lettertypen, thema’s, afbeeldingen en andere bronnen die door de bronlayout worden gebruikt verifiëren.

**Wat gebeurt er als ik een layout wijzig die al in gebruik is?**

Afhankelijke dia’s erven de layout‑wijzigingen tenzij ze de betrokken opmaak of objecten lokaal overschrijven. De geometrie van plaatsaanduidingen en geërfde styling kunnen daardoor op veel dia’s tegelijk veranderen. Gebruik [getDependingSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) om de getroffen dia’s te identificeren vóór het bewerken van de layout.

**Wat gebeurt er als ik een layout verwijder die nog in gebruik is?**

Aspose.Slides gooit een [PptxEditException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxeditexception/). Wijs eerst de afhankelijke dia’s opnieuw toe, of gebruik [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) om uitsluitend niet‑gerefereerde layouts te verwijderen.