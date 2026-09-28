---
title: Dia-indelingen toepassen of wijzigen in Java
linktitle: Dia-indeling
type: docs
weight: 60
url: /nl/java/slide-layout/
keywords:
- dia-indeling
- inhoudsindeling
- plaatsaanduiding
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
description: "Dia-indelingen toepassen, maken en wijzigen in Aspose.Slides voor Java, plaatsaanduidingen toevoegen, ongebruikte indelingen verwijderen en de voettekst-zichtbaarheid regelen."
---
## **Overzicht**

Een dia‑indeling definieert de posities en opmaak van plaatsaanduidingen zoals titels, tekst, afbeeldingen, diagrammen en tabellen. Het toepassen van een indeling geeft dia’s een consistente structuur, terwijl elke dia zijn eigen inhoud kan bevatten.

De meest voorkomende indelingen omvatten:

- **Titel‑dia**: Bevat plaatsaanduidingen voor titel en ondertitel.
- **Titel en inhoud**: Bevat een titelplaatsaanduiding en een algemene inhoudplaatsaanduiding.
- **Leeg**: Bevat geen inhoudsplaatsaanduidingen en is nuttig wanneer elke vorm handmatig wordt gepositioneerd.

## **Begrijp indelingsovererving**

Een presentatie heeft drie gerelateerde niveaus:

1. Een [masterdia](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/) definieert het thema, gedeelde opmaak, achtergronden en gemeenschappelijke objecten.
2. Een [indelingsdia](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/) behoort tot een master en definieert een specifieke rangschikking van plaatsaanduidingen.
3. Een [normale dia](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/) gebruikt één indeling en slaat de ingevoerde inhoud voor die dia op.

Een normale dia erft thema en opmaak van zijn indeling, en de indeling erft van de master. Een waarde die rechtstreeks op een normale dia wordt ingesteld, overschrijft de geërfde waarde op dat niveau. Wanneer een normale dia wordt gemaakt, worden de plaatsaanduidingsvormen gegenereerd vanuit de geselecteerde indeling, terwijl de ingevoerde inhoud in die plaatsaanduidingen bij de normale dia hoort.

Voeg vereiste plaatsaanduidingen toe aan een indeling voordat er dia’s van worden gemaakt. Het later toevoegen van een extra plaatsaanduiding aan een indeling voegt niet automatisch een overeenkomstige plaatsaanduidingsvorm toe aan bestaande normale dia’s.

Deze relatie heeft twee belangrijke consequenties:

- Het wijzigen van geërfde opmaak of bestaande plaatsaanduidingsgeometrie op een indeling kan elke dia die ervan afhankelijk is bijwerken. Controleer voordat u een indeling die al in gebruik is bewerkt, de afhankelijke dia’s en bekijk de resulterende presentatie.
- Een indeling die nog door een dia wordt gebruikt, kan niet worden verwijderd. Wijs eerst de afhankelijke dia’s toe aan een andere indeling, of verwijder alleen ongebruikte indelingen.

Voor meer informatie over het hoogste niveau van deze hiërarchie, zie [Dia‑master](/slides/nl/java/slide-master/).

Om geërfde logo’s of decoratieve mastervormen op één dia of via een gedeelde indeling te verbergen, zie [De zichtbaarheid van mastergrafische elementen regelen](/slides/nl/java/slide-master/). Het voorbeeld vergelijkt twee dia’s die dezelfde master gebruiken.

## **Selecteer en pas een dia‑indeling toe**

Gebruik een indelingstype wanneer de presentatie de standaard PowerPoint‑indelingsdefinities volgt. Indelingsnamen zijn door de gebruiker bewerkbaar en kunnen worden gelokaliseerd, dus selectie op basis van naam is minder betrouwbaar tenzij u de bron‑sjabloon beheert.

Het volgende voorbeeld zoekt naar **Titel en inhoud** op de eerste master. Als die indeling niet beschikbaar is, valt het bewust terug op **Leeg**. De tweede null‑check is noodzakelijk omdat een presentatie alleen aangepaste indelingen kan bevatten. De geselecteerde indeling wordt vervolgens toegepast op de eerste normale dia via de [ISlide.setLayoutSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) methode.

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

Het wijzigen van de indeling van een dia verwijdert niet de gewone vormen die rechtstreeks aan de dia zijn toegevoegd. De positie van plaatsaanduidingen, geërfde opmaak en de correspondentie tussen bestaande plaatsaanduidingen en de nieuwe indeling kunnen echter wijzigen, dus inspecteer de uitvoer bij het schakelen tussen wezenlijk verschillende indelingen.

## **Voeg een indelingsdia toe**

Selectie en creatie zijn aparte handelingen. Het vorige voorbeeld selecteert een bestaande indeling; het maakt er geen. Om een indeling te maken, roep de [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) methode aan op de indelingscollectie van de doel‑master.

Het volgende voorbeeld voegt altijd een nieuwe **Titel en inhoud** indeling toe met de naam `Report Title and Content`, en voegt vervolgens een normale dia toe die hierop gebaseerd is. Indelingsnamen moeten uniek zijn binnen de collectie.

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

Voeg alleen een indeling toe wanneer het sjabloon echt een extra herbruikbare structuur nodig heeft. Als er al een geschikte indeling bestaat, selecteer en hergebruik deze in plaats van een duplicaat te maken.

## **Voeg plaatsaanduidingen toe aan een indelingsdia**

De [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) methode levert een [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/) voor het toevoegen van plaatsaanduidingsvormen aan een indeling.

| PowerPoint‑plaatsaanduiding | `ILayoutPlaceholderManager`‑methode |
| --------------------------- | ----------------------------------- |
| ![Inhoud](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Inhoud (Verticaal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Tekst](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Tekst (Verticaal)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Afbeelding](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Grafiek](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabel](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online‑afbeelding](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Het volgende voorbeeld verifieert dat de **Leeg**‑indeling bestaat, voegt er vier plaatsaanduidingen aan toe en maakt vervolgens een normale dia die de gewijzigde indeling gebruikt. De volgorde is opzettelijk: de plaatsaanduidingen worden toegevoegd voordat de normale dia wordt gemaakt, zodat Aspose.Slides de overeenkomstige plaatsaanduidingsvormen op die dia kan genereren.

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

![De plaatsaanduidingen op de indelingsdia](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Het wijzigen van geërfde opmaak of de geometrie van bestaande indelingsplaatsaanduidingen kan afhankelijke dia’s beïnvloeden. Een nieuw toegevoegde indelingsplaatsaanduiding wordt niet automatisch toegevoegd aan bestaande normale dia’s. Test indelingswijzigingen op een kopie van de presentatie en inspecteer elke afhankelijke dia.
{{% /alert %}}

## **Verwijder ongebruikte indelingsdia's**

Gebruik de [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) methode om indelingen te verwijderen die door geen enkele normale dia worden gerefereerd. De methode laat indelingen die nog in gebruik zijn ongewijzigd.

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

Om een specifieke indeling te verwijderen, gebruik eerst de [hasDependingSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) of [getDependingSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) methode. Wijs eventuele afhankelijke dia’s opnieuw toe voordat u [ILayoutSlide.remove](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#remove--) aanroept. Het proberen te verwijderen van een gebruikte indeling veroorzaakt een [PptxEditException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxeditexception/).

## **Stel voetnoot‑zichtbaarheid in op een indelingsdia**

Een indeling heeft eigen voetnoot-, dia‑nummer‑ en datum‑tijd‑plaatsaanduidingen. Gebruik de [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) methode om die plaatsaanduidingen voor één indeling te beheren. Dit is handig wanneer bijvoorbeeld inhoudsindelingen wel voetnoten tonen maar titel‑indelingen dat niet doen.

Het volgende voorbeeld selecteert veilig een indeling en maakt de voetnoot‑elementen zichtbaar:

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

## **Stel voetnoot‑zichtbaarheid in op een master en de onderliggende indelingen**

Om consistente voetnootinstellingen toe te passen over een master‑hiërarchie, gebruik de [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) methode. De propagatiemethoden van [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslideheaderfootermanager/) werken op de master en diens afhankelijke indelings‑ en normale dia’s; ze richten zich niet op slechts één normale dia.

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

**Wat is het verschil tussen een master‑dia en een indelings‑dia?**

Een master‑dia definieert het thema en de gedeelde opmaak van de presentatie. Een indelings‑dia behoort tot een master en definieert één herbruikbare rangschikking van plaatsaanduidingen. Normale dia’s gebruiken die indelingen en slaan dia‑specifieke inhoud op.

**Kan ik een indelings‑dia van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de bestemmingscollectie met de [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) methode. Bij het kopiëren tussen presentaties moet u tevens lettertypen, thema’s, afbeeldingen en andere bronnen die door de bron‑indeling worden gebruikt verifiëren.

**Wat gebeurt er als ik een indeling wijzig die al in gebruik is?**

Afhankelijke dia’s erven de wijzigingen in de indeling, tenzij ze de getroffen opmaak of objecten lokaal overschrijven. De geometrie van plaatsaanduidingen en de geërfde stijl kunnen daardoor op veel dia’s tegelijk veranderen. Gebruik [getDependingSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) om de getroffen dia’s te identificeren voordat u de indeling bewerkt.

**Wat gebeurt er als ik een indeling verwijder die nog in gebruik is?**

Aspose.Slides gooit een [PptxEditException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxeditexception/). Wijs eerst de afhankelijke dia’s opnieuw toe, of gebruik [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) om alleen niet‑gerefereerde indelingen te verwijderen.