---
title: Lay‑outs van dia's toepassen of wijzigen in JavaScript
linktitle: Dia‑layout
type: docs
weight: 60
url: /nl/nodejs-java/slide-layout/
keywords:
- dia‑layout
- inhoudslayout
- placeholder
- presentatie‑ontwerp
- dia‑ontwerp
- ongebruikte layout
- zichtbaarheid van voettekst
- titel­dia
- titel en inhoud
- sectiekoptekst
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Lay‑outs van dia's toepassen, maken en aanpassen in Aspose.Slides voor Node.js via Java, placeholders toevoegen, ongebruikte lay-outs verwijderen en de zichtbaarheid van de voettekst beheren."
---
## **Overzicht**

Een dia‑layout definieert de posities en opmaak van tijdelijke aanduidingen zoals titels, tekst, afbeeldingen, diagrammen en tabellen. Een layout toepassen geeft dia’s een consistente structuur terwijl elke dia zijn eigen inhoud kan bevatten.

De meest voorkomende layouts omvatten:

- **Titel-dia**: Bevat tijdelijke aanduidingen voor titel en ondertitel.
- **Titel en inhoud**: Bevat een tijdelijke aanduiding voor de titel en een algemene inhouds‑placeholder.
- **Leeg**: Bevat geen inhouds‑placeholders en is handig wanneer elke vorm handmatig wordt gepositioneerd.

## **Begrijp layout‑erfenis**

Een presentatie heeft drie gerelateerde niveaus:

1. Een [masterdia](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/) definieert het thema, gedeelde opmaak, achtergronden en gemeenschappelijke objecten.
2. Een [layoutdia](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/) behoort tot een master en definieert een specifieke ordening van placeholders.
3. Een [normale dia](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/) gebruikt één layout en slaat de ingevoerde inhoud voor die dia op.

Een normale dia erft thema en opmaak van zijn layout, en de layout erft van zijn master. Een waarde die rechtstreeks op een normale dia wordt ingesteld, overschrijft de geërfde waarde op dat niveau. Wanneer een normale dia wordt aangemaakt, worden de placeholder‑vormen gegenereerd vanuit de geselecteerde layout, terwijl de ingevoerde inhoud in die placeholders bij de normale dia hoort.

Voeg verplichte placeholders toe aan een layout voordat dia’s ervan worden aangemaakt. Het later toevoegen van een extra placeholder aan een layout voegt niet automatisch een overeenkomstige placeholder‑vorm toe aan bestaande normale dia’s.

Deze relatie heeft twee belangrijke consequenties:

- Het wijzigen van geërfde opmaak of bestaande placeholder‑geometrie in een layout kan elke dia die ervan afhankelijk is bijwerken. Controleer vóór het bewerken van een layout die al in gebruik is, de afhankelijke dia’s en evalueer de resulterende presentatie.
- Een layout die nog door een dia wordt gebruikt, kan niet worden verwijderd. Ken eerst de afhankelijke dia’s toe aan een andere layout, of verwijder alleen ongebruikte layouts.

Voor meer informatie over het bovenste niveau van deze hiërarchie, zie [Slide‑master](/slides/nl/nodejs-java/slide-master/).

Om geërfde logo’s of decoratieve master‑vormen op één dia of via een gedeelde layout te verbergen, zie [De zichtbaarheid van master‑grafische elementen beheren](/slides/nl/nodejs-java/slide-master/). Het voorbeeld vergelijkt twee dia’s die dezelfde master gebruiken.

## **Selecteer en pas een dia‑layout toe**

Gebruik een [SlideLayoutType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidelayouttype/) waarde wanneer de presentatie de standaard PowerPoint‑layoutdefinities volgt. Layout‑namen kunnen door de gebruiker worden bewerkt en vertaald, waardoor selectie op basis van naam minder betrouwbaar is tenzij je de bron‑template beheert.

Het volgende voorbeeld zoekt naar **Titel en inhoud** op de eerste master. Als die layout niet beschikbaar is, valt het bewust terug op **Leeg**. De tweede null‑controle is nodig omdat een presentatie alleen aangepaste layouts kan bevatten. De geselecteerde layout wordt vervolgens toegepast op de eerste normale dia via de [Slide.setLayoutSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#setLayoutSlide) methode.

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

Het wijzigen van de layout van een dia verwijdert de gewone vormen die rechtstreeks aan de dia zijn toegevoegd niet. Echter, placeholder‑posities, geërfde opmaak en de overeenkomst tussen bestaande placeholders en de nieuwe layout kunnen veranderen, dus controleer de output bij het wisselen tussen aanzienlijk verschillende layouts.

## **Voeg een layout‑dia toe**

Selectie en creatie zijn afzonderlijke bewerkingen. Het vorige voorbeeld selecteert een bestaande layout; het maakt er geen nieuwe aan. Om een layout te maken, roep je de [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) methode aan op de layout‑collectie van de doel‑master.

Het volgende voorbeeld voegt altijd een nieuwe **Titel en inhoud** layout toe met de naam `Report Title and Content`, en voegt vervolgens een normale dia toe die daarop gebaseerd is. Layout‑namen moeten uniek zijn binnen de collectie.

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

Voeg een layout alleen toe wanneer de template echt een extra herbruikbare structuur nodig heeft. Als er al een passende layout bestaat, selecteer en hergebruik die in plaats van een duplicaat aan te maken.

## **Voeg placeholders toe aan een layout‑dia**

De [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) methode biedt een [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/) om placeholder‑vormen aan een layout toe te voegen.

| PowerPoint‑placeholder | `LayoutPlaceholderManager` Method |
| ---------------------- | --------------------------------- |
| ![Inhoud](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Inhoud (verticaal)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Tekst](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Tekst (verticaal)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Afbeelding](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Grafiek](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabel](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online‑afbeelding](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Het volgende voorbeeld controleert of de **Leeg** layout bestaat, voegt er vier placeholders aan toe, en maakt vervolgens een normale dia die de aangepaste layout gebruikt. De volgorde is opzettelijk: de placeholders worden toegevoegd vóórdat de normale dia wordt aangemaakt, zodat Aspose.Slides de overeenkomstige placeholder‑vormen op die dia kan genereren.

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

Het resultaat:

![De placeholders op de layout‑dia](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Het wijzigen van geerbde opmaak of de geometrie van bestaande layout‑placeholders kan afhankelijke dia’s beïnvloeden. Een nieuw toegevoegde layout‑placeholder wordt niet achteraf toegevoegd aan bestaande normale dia’s. Test layout‑wijzigingen op een kopie van de presentatie en controleer elke afhankelijke dia.
{{% /alert %}}

## **Verwijder ongebruikte layout‑dia’s**

Gebruik de [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) methode om layouts te verwijderen die door geen enkele normale dia worden gerefereerd. De methode behoudt layouts die nog in gebruik zijn.

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

Om één specifieke layout te verwijderen, gebruik eerst de [hasDependingSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) of [getDependingSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) methode. Ken eventuele afhankelijke dia’s opnieuw toe voordat je [LayoutSlide.remove](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#remove) aanroept. Pogingen om een gebruikte layout te verwijderen veroorzaken een [PptxEditException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxeditexception/).

## **Beheer de zichtbaarheid van voettekst op een layout‑dia**

Een layout heeft eigen voettekst-, dia‑nummer‑ en datum‑tijd‑placeholders. Gebruik de [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) methode om die placeholders voor één layout te beheren. Dit is handig wanneer bijvoorbeeld inhouds‑layouts voetteksten moeten tonen, maar titel‑layouts niet.

Het volgende voorbeeld selecteert veilig een layout en maakt de voettekstelementen zichtbaar:

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

## **Beheer de zichtbaarheid van voettekst op een master en zijn onderliggende layouts**

Om consistente voettekstinstellingen toe te passen over een master‑hiërarchie, gebruik je de [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) methode. De propagatiemethoden van [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslideheaderfootermanager/) werken op de master en diens afhankelijke layout‑dia’s en normale dia’s; ze richten zich niet alleen op één normale dia.

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

## **FAQ**

**Wat is het verschil tussen een masterdia en een layoutdia?**

Een masterdia definieert het thema van de presentatie en de gedeelde opmaak. Een layoutdia behoort tot een master en definieert één herbruikbare ordening van placeholders. Normale dia’s gebruiken die layouts en slaan dia‑specifieke inhoud op.

**Kan ik een layoutdia van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de doelcollectie met de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) methode. Bij het kopiëren tussen presentaties moet je ook lettertypen, thema’s, afbeeldingen en andere bronnen die door de bronlayout worden gebruikt controleren.

**Wat gebeurt er als ik een layout wijzig die al in gebruik is?**

Afhankelijke dia’s erven de layout‑wijzigingen, tenzij ze de getroffen opmaak of objecten lokaal overschrijven. Placeholder‑geometrie en geërfde styling kunnen daardoor in veel dia’s tegelijk veranderen. Gebruik [getDependingSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) om de getroffen dia’s te identificeren voordat je de layout bewerkt.

**Wat gebeurt er als ik een layout verwijder die nog in gebruik is?**

Aspose.Slides gooit een [PptxEditException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxeditexception/). Ken eerst de afhankelijke dia’s opnieuw toe, of gebruik [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) om alleen niet‑gerefereerde layouts te verwijderen.