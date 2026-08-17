---
title: Dia-indelingen toepassen of wijzigen in Java
linktitle: Dia-indeling
type: docs
weight: 60
url: /nl/java/slide-layout/
keywords:
- dia-indeling
- inhoudsindeling
- placeholder
- presentatie-ontwerp
- dia-ontwerp
- ongebruikte indeling
- voettekst-zichtbaarheid
- titel-dia
- titel en inhoud
- sectiekop
- twee inhoud
- vergelijking
- alleen titel
- lege indeling
- inhoud met bijschrift
- afbeelding met bijschrift
- titel en verticale tekst
- verticale titel en tekst
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Dia-indelingen toepassen, maken en wijzigen in Aspose.Slides voor Java, placeholders toevoegen, ongebruikte indelingen verwijderen en de voettekst-zichtbaarheid beheren."
---
## **Overzicht**

Een dia‑indeling bepaalt de posities en opmaak van placeholders zoals titels, tekst, afbeeldingen, diagrammen en tabellen. Het toepassen van een indeling geeft dia’s een consistente structuur, terwijl elke dia zijn eigen inhoud kan bevatten.

De meest voorkomende indelingen omvatten:

- **Titel‑dia**: Bevat titel‑ en subtitel‑placeholders.
- **Titel en inhoud**: Bevat een titel‑placeholder en een algemene inhouds‑placeholder.
- **Leeg**: Bevat geen inhouds‑placeholders en is handig wanneer elke vorm handmatig wordt gepositioneerd.

## **Begrijp indeling‑erfenis**

Een presentatie heeft drie gerelateerde niveaus:

1. Een [master-dia](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/) definieert het thema, gedeelde opmaak, achtergronden en gemeenschappelijke objecten.
2. Een [layout-dia](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/) behoort tot een master en definieert een specifieke indeling van placeholders.
3. Een [normale dia](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/) gebruikt één indeling en slaat de ingevoerde inhoud voor die dia op.

Een normale dia erft thema en opmaak van zijn layout, en de layout erft van de master. Een waarde die rechtstreeks op een normale dia wordt ingesteld, overschrijft de geërfde waarde op dat niveau. Wanneer een normale dia wordt gemaakt, worden de placeholder‑vormen gegenereerd uit de geselecteerde layout, terwijl de inhoud die in die placeholders wordt ingevoerd, toebehoort aan de normale dia.

Voeg vereiste placeholders toe aan een layout voordat je er dia’s van maakt. Een later toegevoegde placeholder aan een layout wordt niet automatisch toegevoegd aan bestaande normale dia’s.

Deze relatie heeft twee belangrijke gevolgen:

- Het wijzigen van geërfde opmaak of bestaande placeholder‑geometrie op een layout kan elke dia die ervan afhankelijk is bijwerken. Controleer vóór het bewerken van een layout die al in gebruik is, de afhankelijke dia’s en bekijk de resulterende presentatie.
- Een layout die nog door een dia wordt gebruikt, kan niet worden verwijderd. Ken eerst de afhankelijke dia’s opnieuw toe aan een andere layout, of verwijder alleen ongebruikte layouts.

Voor meer informatie over het top‑niveau van deze hiërarchie, zie [Slide‑master](/slides/nl/java/slide-master/).

## **Selecteer en pas een dia‑indeling toe**

Gebruik een layouttype wanneer de presentatie de standaard PowerPoint‑layoutdefinities volgt. Layoutnamen zijn door de gebruiker bewerkbaar en kunnen worden gelokaliseerd, dus selectie op basis van naam is minder betrouwbaar tenzij je de bron‑template beheert.

Het volgende voorbeeld zoekt **Titel en inhoud** op de eerste master. Als die layout niet beschikbaar is, valt het expres terug op **Leeg**. De tweede null‑check is nodig omdat een presentatie alleen aangepaste layouts kan bevatten. De geselecteerde layout wordt vervolgens toegepast op de eerste normale dia via de [ISlide.setLayoutSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-)‑methode.

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

Het wijzigen van de layout van een dia verwijdert niet de gewone vormen die direct aan de dia zijn toegevoegd. Echter, placeholder‑posities, geërfde opmaak en de correspondentie tussen bestaande placeholders en de nieuwe layout kunnen veranderen, dus inspecteer de uitvoer bij het wisselen tussen wezenlijk verschillende layouts.

## **Voeg een layout‑dia toe**

Selectie en creatie zijn afzonderlijke handelingen. Het vorige voorbeeld selecteert een bestaande layout; het maakt er geen nieuwe aan. Om een layout te maken, roep je de [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-)‑methode aan op de layout‑collectie van de doel‑master.

Het volgende voorbeeld voegt altijd een nieuwe **Titel en inhoud**‑layout met de naam `Report Title and Content` toe, en voegt daarna een normale dia toe die daarop is gebaseerd. Layoutnamen moeten uniek zijn binnen de collectie.

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

Voeg een layout alleen toe wanneer de template echt een extra herbruikbare structuur nodig heeft. Als er al een geschikte layout bestaat, selecteer en hergebruik die in plaats van een duplicaat te maken.

## **Voeg placeholders toe aan een layout‑dia**

De [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--)‑methode levert een [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/) voor het toevoegen van placeholder‑vormen aan een layout.

| PowerPoint‑placeholder              | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Inhoud](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Inhoud (Verticaal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Tekst](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Tekst (Verticaal)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Afbeelding](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Grafiek](chart.png)                 | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabel](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online‑afbeelding](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Het volgende voorbeeld controleert of de **Leeg**‑layout bestaat, voegt er vier placeholders aan toe en maakt daarna een normale dia aan die de gewijzigde layout gebruikt. De volgorde is opzettelijk: de placeholders worden toegevoegd voordat de normale dia wordt aangemaakt, zodat Aspose.Slides de corresponderende placeholder‑vormen op die dia kan genereren.

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

![De placeholders op de layout‑dia](add_placeholders.png)

{{% alert color="warning" title="Waarschuwing" %}}
Het wijzigen van geërfde opmaak of de geometrie van bestaande layout‑placeholders kan afhankelijke dia’s beïnvloeden. Een nieuw toegevoegde layout‑placeholder wordt niet automatisch toegevoegd aan bestaande normale dia’s. Test layout‑wijzigingen op een kopie van de presentatie en inspecteer elke afhankelijke dia.
{{% /alert %}}

## **Verwijder ongebruikte layout‑dia’s**

Gebruik de [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)‑methode om layouts te verwijderen die door geen enkele normale dia worden gerefereerd. De methode laat layouts die nog in gebruik zijn ongewijzigd.

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

Om een specifieke layout te verwijderen, gebruik eerst de [hasDependingSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--)‑ of [getDependingSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#getDependingSlides--)‑methode. Ken eventuele afhankelijke dia’s opnieuw toe voordat je [ILayoutSlide.remove](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#remove--) aanroept. Het proberen te verwijderen van een gebruikte layout veroorzaakt een [PptxEditException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxeditexception/).

## **Beheer voettekst‑zichtbaarheid op een layout‑dia**

Een layout heeft zijn eigen voettekst‑, dia‑nummer‑ en datum‑tijd‑placeholders. Gebruik de [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--)‑methode om die placeholders voor één layout te beheren. Dit is handig wanneer bijvoorbeeld inhoud‑layouts wel voetteksten moeten tonen maar titel‑layouts niet.

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

## **Beheer voettekst‑zichtbaarheid op een master‑ en diens onderliggende layout‑dia’s**

Om consistente voettekst‑instellingen toe te passen over een master‑hiërarchie, gebruik de [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--)‑methode. De propagatiemethoden van [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslideheaderfootermanager/) werken op de master en zijn afhankelijke layout‑dia’s en normale dia’s; ze richten zich niet alleen op één normale dia.

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

**Wat is het verschil tussen een master‑dia en een layout‑dia?**

Een master‑dia definieert het thema en de gedeelde opmaak van de presentatie. Een layout‑dia behoort tot een master en definieert één herbruikbare indeling van placeholders. Normale dia’s gebruiken die layouts en slaan dia‑specifieke inhoud op.

**Kan ik een layout‑dia van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de doel‑collectie met de [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-)‑methode. Bij het kopiëren tussen presentaties moet je ook lettertypen, thema’s, afbeeldingen en andere resources die door de bron‑layout worden gebruikt verifiëren.

**Wat gebeurt er als ik een layout wijzig die al in gebruik is?**

Afhankelijke dia’s erven de layout‑wijzigingen tenzij ze de aangetaste opmaak of objecten lokaal overschrijven. Placeholder‑geometrie en geërfde styling kunnen daardoor in één keer op veel dia’s veranderen. Gebruik [getDependingSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) om de getroffen dia’s te identificeren voordat je de layout bewerkt.

**Wat gebeurt er als ik een layout verwijder die nog in gebruik is?**

Aspose.Slides gooit een [PptxEditException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxeditexception/). Ken eerst de afhankelijke dia’s opnieuw toe, of gebruik [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) om alleen niet‑gerefereerde layouts te verwijderen.