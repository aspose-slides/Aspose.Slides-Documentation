---
title: Toepassen of Wijzigen van dia-indelingen op Android
linktitle: Dia-indeling
type: docs
weight: 60
url: /nl/androidjava/slide-layout/
keywords:
- dia-indeling
- inhoudsindeling
- plaatshouder
- presentatiedesign
- dia-ontwerp
- ongebruikte indeling
- voettekst-zichtbaarheid
- titelpagina
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
- Android
- Java
- Aspose.Slides
description: "Dia-indelingen toepassen, aanmaken en aanpassen in Aspose.Slides voor Android via Java, plaatshouders toevoegen, ongebruikte indelingen verwijderen en de zichtbaarheid van de voettekst regelen."
---
## **Overzicht**

Een dia‑indeling definieert de posities en opmaak van plaatshouders zoals titels, tekst, afbeeldingen, diagrammen en tabellen. Het toepassen van een indeling geeft dia’s een consistente structuur, terwijl elke dia zijn eigen inhoud kan bevatten.

De meest voorkomende indelingen zijn:

- **Titelpagina**: Bevat plaatshouders voor titel en ondertitel.  
- **Titel en Inhoud**: Bevat een titel‑plaatshouder en een algemene inhouds‑plaatshouder.  
- **Leeg**: Bevat geen inhouds‑plaatshouders en is handig wanneer elke vorm handmatig wordt gepositioneerd.

## **Begrijp Indelings‑Erfenis**

Een presentatie heeft drie gerelateerde niveaus:

1. Een [masterdia](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/) definieert het thema, gedeelde opmaak, achtergronden en gemeenschappelijke objecten.  
2. Een [indelingsdia](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/) behoort tot een master en definieert een specifieke rangschikking van plaatshouders.  
3. Een [normale dia](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/) gebruikt één indeling en slaat de ingevoerde inhoud voor die dia op.

Een normale dia erft thema en opmaak van zijn indeling, en de indeling erft van zijn master. Een waarde die rechtstreeks op een normale dia wordt gezet, overschrijft de geërfde waarde op dat niveau. Wanneer een normale dia wordt aangemaakt, worden de plaatshouder‑vormen gegenereerd vanuit de geselecteerde indeling, terwijl de ingevoerde inhoud in die plaatshouders tot de normale dia behoort.

Voeg vereiste plaatshouders toe aan een indeling vóór het aanmaken van dia’s ervan. Het later toevoegen van een extra plaatshouder aan een indeling voegt niet automatisch een overeenkomstige plaatshouder‑vorm toe aan reeds bestaande normale dia’s.

Deze relatie heeft twee belangrijke consequenties:

- Het wijzigen van geërfde opmaak of de bestaande geometrie van een plaatshouder in een indeling kan elke dia die ervan afhankelijk is bijwerken. Controleer vóór het bewerken van een indeling die al in gebruik is de afhankelijke dia’s en beoordeel de resulterende presentatie.  
- Een indeling die nog door een dia wordt gebruikt, kan niet worden verwijderd. Wijs eerst de afhankelijke dia’s opnieuw toe aan een andere indeling, of verwijder alleen ongebruikte indelingen.

Voor meer informatie over het hoogste niveau van deze hiërarchie, zie [Slide Master](/slides/nl/androidjava/slide-master/).

Om geërfde logo’s of decoratieve master‑vormen op één dia of via een gedeelde indeling te verbergen, zie [Control the Visibility of Master Graphics](/slides/nl/androidjava/slide-master/). Het voorbeeld vergelijkt twee dia’s die dezelfde master gebruiken.

## **Selecteer en Pas een Dia‑Indeling Toe**

Gebruik een indelingstype wanneer de presentatie standaard PowerPoint‑indelingsdefinities volgt. Indelingsnamen zijn bewerkbaar door de gebruiker en kunnen worden gelokaliseerd, zodat selectie op naam minder betrouwbaar is tenzij u de bron‑template beheert.

Het volgende voorbeeld zoekt **Titel en Inhoud** op de eerste master. Als die indeling niet beschikbaar is, valt het bewust terug op **Leeg**. De tweede null‑controle is nodig omdat een presentatie alleen aangepaste indelingen kan bevatten. De geselecteerde indeling wordt vervolgens toegepast op de eerste normale dia via de [ISlide.setLayoutSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-)‑methode.

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

Het wijzigen van de indeling van een dia verwijdert geen gewone vormen die rechtstreeks aan de dia zijn toegevoegd. Echter, de posities van plaatshouders, geërfde opmaak en de correspondentie tussen bestaande plaatshouders en de nieuwe indeling kunnen veranderen, dus inspecteer de output bij het wisselen tussen aanzienlijk verschillende indelingen.

## **Voeg een Indelings‑Dia Toe**

Selectie en aanmaak zijn gescheiden handelingen. Het vorige voorbeeld selecteert een bestaande indeling; het maakt er geen nieuwe aan. Om een indeling te maken, roep de [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-)‑methode aan op de indelingscollectie van de doel‑master.

Het volgende voorbeeld voegt steeds een nieuwe **Titel en Inhoud**‑indeling toe met de naam `Report Title and Content`, en voegt vervolgens een normale dia toe op basis daarvan. Indelingsnamen moeten uniek zijn binnen de collectie.

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

Voeg alleen een indeling toe wanneer de template echt een extra herbruikbare structuur nodig heeft. Als er al een geschikte indeling bestaat, selecteer en hergebruik die in plaats van een duplicaat te maken.

## **Voeg Plaatshouders toe aan een Indelings‑Dia**

De [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--)‑methode levert een [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) voor het toevoegen van plaatshouder‑vormen aan een indeling.

| PowerPoint‑plaatshouder            | `ILayoutPlaceholderManager`‑methode |
| ----------------------------------- | ------------------------------------ |
| ![Content](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png)                 | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Het volgende voorbeeld controleert of de **Leeg**‑indeling bestaat, voegt vier plaatshouders toe en maakt daarna een normale dia die de aangepaste indeling gebruikt. De volgorde is opzettelijk: de plaatshouders worden toegevoegd vóór de normale dia, zodat Aspose.Slides de overeenkomende plaatshouder‑vormen op die dia kan genereren.

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

![De plaatshouders op de indelings‑dia](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}Het wijzigen van geërfde opmaak of de geometrie van bestaande indelings‑plaatshouders kan afhankelijke dia’s beïnvloeden. Een nieuw toegevoegde indelings‑plaatshouder wordt niet achteraf toegevoegd aan bestaande normale dia’s. Test indelingswijzigingen op een kopie van de presentatie en inspecteer elke afhankelijke dia.{{% /alert %}}

## **Verwijder Ongebruikte Indelings‑Dia’s**

Gebruik de [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)‑methode om indelingen te verwijderen waar geen normale dia naar verwijst. De methode laat indelingen die nog in gebruik zijn onaangetast.

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

Om één specifieke indeling te verwijderen, gebruik eerst de [hasDependingSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--)‑ of [getDependingSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--)‑methode. Wijs eventuele afhankelijke dia’s opnieuw toe voordat u [ILayoutSlide.remove](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#remove--) aanroept. Het proberen te verwijderen van een gebruikte indeling veroorzaakt een [PptxEditException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxeditexception/).

## **Reguleer Voettekst‑Zichtbaarheid op een Indelings‑Dia**

Een indeling heeft eigen voettekst-, dia‑nummer‑ en datum‑tijd‑plaatshouders. Gebruik de [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--)‑methode om die plaatshouders voor één indeling te beheren. Dit is handig wanneer bijvoorbeeld inhouds‑indelingen voetteksten moeten weergeven, maar titel‑indelingen niet.

Het volgende voorbeeld selecteert veilig een indeling en maakt de voettekstelementen zichtbaar:

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

## **Reguleer Voettekst‑Zichtbaarheid op een Master en Zijn Kind‑Indelingen**

Om consistente voettekstinstellingen door een master‑hiërarchie heen toe te passen, gebruik de [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--)‑methode. De propagatiemethoden van [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) werken op de master én de afhankelijke indelings‑ en normale dia’s; ze richten zich niet alleen op één normale dia.

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

Een master‑dia definieert het thema en de gedeelde opmaak van de presentatie. Een indelings‑dia behoort tot een master en definieert één herbruikbare rangschikking van plaatshouders. Normale dia’s gebruiken die indelingen en slaan dia‑specifieke inhoud op.

**Kan ik een indelings‑dia van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de bestemmingscollectie met de [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-)‑methode. Bij het kopiëren tussen presentaties moet u ook lettertypen, thema’s, afbeeldingen en andere bronnen die door de bron‑indeling worden gebruikt verifiëren.

**Wat gebeurt er als ik een indeling aanpas die al in gebruik is?**

Afhankelijke dia’s erven de wijzigingen tenzij ze de betreffende opmaak of objecten lokaal overschrijven. De geometrie van plaatshouders en geërfde styling kunnen daardoor in één keer op veel dia’s veranderen. Gebruik [getDependingSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) om de getroffen dia’s te identificeren voordat u de indeling bewerkt.

**Wat gebeurt er als ik een indeling verwijder die nog in gebruik is?**

Aspose.Slides gooit een [PptxEditException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxeditexception/). Wijs eerst de afhankelijke dia’s opnieuw toe, of gebruik [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) om alleen niet‑gerefereerde indelingen te verwijderen.