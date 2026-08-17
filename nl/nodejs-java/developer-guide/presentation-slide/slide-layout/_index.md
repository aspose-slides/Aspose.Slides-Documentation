---
title: Toepassen of wijzigen van dia‑lay-outs in JavaScript
linktitle: Dia‑lay-out
type: docs
weight: 60
url: /nl/nodejs-java/slide-layout/
keywords:
- dia‑lay-out
- inhoudslay-out
- placeholder
- presentatie‑ontwerp
- dia‑ontwerp
- ongebruikte lay-out
- zichtbaarheid van voettekst
- titel‑dia
- titel en inhoud
- sectiekop
- twee inhoud
- vergelijking
- alleen titel
- lege lay-out
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
description: "Toepassen, maken en wijzigen van dia‑lay-outs in Aspose.Slides voor Node.js via Java, placeholders toevoegen, ongebruikte lay-outs verwijderen en de zichtbaarheid van de voettekst regelen."
---
## **Overzicht**

Een dia‑lay-out definieert de posities en opmaak van tijdelijke aanduidingen zoals titels, tekst, afbeeldingen, diagrammen en tabellen. Het toepassen van een lay-out geeft dia's een consistente structuur, terwijl elke dia zijn eigen inhoud kan bevatten.

De meest voorkomende lay-outs omvatten:

- **Titel‑dia**: Bevat tijdelijke aanduidingen voor titel en ondertitel.
- **Titel en inhoud**: Bevat een titel‑placeholder en een algemene inhouds‑placeholder.
- **Leeg**: Bevat geen inhouds‑placeholders en is nuttig wanneer elke vorm handmatig wordt gepositioneerd.

## **Begrijp lay-out‑erfenis**

Een presentatie heeft drie gerelateerde niveaus:

1. Een [masterdia](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/) definieert het thema, gedeelde opmaak, achtergronden en gemeenschappelijke objecten.
2. Een [layoutdia](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/) behoort tot een master en definieert een specifieke ordening van placeholders.
3. Een [normale dia](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/) gebruikt één lay-out en slaat de ingevoerde inhoud voor die dia op.

Een normale dia erft thema en opmaak van zijn lay-out, en de lay-out erft van de master. Een waarde die rechtstreeks op een normale dia wordt ingesteld, overschrijft de geërfde waarde op dat niveau. Wanneer een normale dia wordt aangemaakt, worden de placeholder‑vormen gegenereerd vanuit de geselecteerde lay-out, terwijl de ingevoerde inhoud in die placeholders toebehoort aan de normale dia.

Voeg de benodigde placeholders toe aan een lay-out vóór het maken van dia's daarvan. Een later toegevoegde placeholder aan een lay-out voegt niet automatisch een overeenkomstige placeholder‑vorm toe aan bestaande normale dia's.

Deze relatie heeft twee belangrijke consequenties:

- Het wijzigen van geërfde opmaak of de bestaande placeholder‑geometrie op een lay-out kan elke afhankelijke dia bijwerken. Voordat u een lay-out bewerkt die al in gebruik is, inspecteert u de afhankelijke dia's en controleert u de resulterende presentatie.
- Een lay-out die nog door een dia wordt gebruikt, kan niet worden verwijderd. Wijs eerst haar afhankelijke dia's toe aan een andere lay-out, of verwijder alleen ongebruikte lay-outs.

Voor meer informatie over het hoogste niveau van deze hiërarchie, zie [Dia‑master](/slides/nl/nodejs-java/slide-master/).

## **Selecteer en pas een dia‑lay-out toe**

Gebruik een [SlideLayoutType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidelayouttype/) wanneer de presentatie de standaard PowerPoint‑lay-outdefinities volgt. Lay-outnamen zijn door de gebruiker bewerkbaar en kunnen worden gelokaliseerd, waardoor selectie op naam minder betrouwbaar is, tenzij u de bron‑template beheert.

Het volgende voorbeeld zoekt naar **Titel en inhoud** op de eerste master. Als die lay-out niet beschikbaar is, valt het opzettelijk terug op **Leeg**. De tweede null‑check is noodzakelijk omdat een presentatie alleen aangepaste lay-outs kan bevatten. De geselecteerde lay-out wordt vervolgens toegepast op de eerste normale dia via de [Slide.setLayoutSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#setLayoutSlide) methode.

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

Het wijzigen van de lay-out van een dia verwijdert niet de gewone vormen die rechtstreeks aan de dia zijn toegevoegd. Echter, placeholder‑posities, geërfde opmaak en de correspondentie tussen bestaande placeholders en de nieuwe lay-out kunnen wijzigen, dus controleer de output wanneer u overschakelt tussen duidelijk verschillende lay-outs.

## **Voeg een layoutdia toe**

Selectie en creatie zijn afzonderlijke handelingen. Het vorige voorbeeld selecteert een bestaande lay-out; het creëert er geen. Om een lay-out te maken, roep de [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) methode aan op de lay-outcollectie van de doel‑master.

Het volgende voorbeeld voegt altijd een nieuwe **Titel en inhoud** lay-out toe met de naam `Report Title and Content`, waarna een normale dia gebaseerd op die lay-out wordt toegevoegd. Lay-outnamen moeten uniek zijn binnen de collectie.

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

Voeg alleen een lay-out toe wanneer de template echt een extra herbruikbare structuur nodig heeft. Als er al een geschikte lay-out bestaat, selecteer en hergebruik die in plaats van een duplicaat te maken.

## **Voeg placeholders toe aan een layoutdia**

De [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) methode levert een [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/) voor het toevoegen van placeholder‑vormen aan een lay‑out.

| PowerPoint Placeholder | `LayoutPlaceholderManager` Method |
| ---------------------- | --------------------------------- |
| ![Inhoud](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Inhoud (verticaal)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Tekst](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Tekst (verticaal)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Afbeelding](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagram](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabel](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online‑afbeelding](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Het volgende voorbeeld controleert of de **Leeg** lay-out bestaat, voegt vier placeholders toe aan deze lay-out, en maakt vervolgens een normale dia die de aangepaste lay-out gebruikt. De volgorde is opzettelijk: de placeholders worden toegevoegd vóórdat de normale dia wordt aangemaakt, zodat Aspose.Slides de overeenkomstige placeholder‑vormen op die dia kan genereren.

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

![De placeholders op de layoutdia](add_placeholders.png)

{{% alert color="warning" title="Waarschuwing" %}}
Het wijzigen van geërfde opmaak of de geometrie van bestaande layout‑placeholders kan de afhankelijke dia's beïnvloeden. Een nieuw toegevoegde layout‑placeholder wordt niet teruggevuld in bestaande normale dia's. Test lay-outwijzigingen op een kopie van de presentatie en inspecteer elke afhankelijke dia.
{{% /alert %}}

## **Verwijder ongebruikte layoutdia's**

Gebruik de [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) methode om lay-outs te verwijderen die door geen enkele normale dia worden gerefereerd. De methode laat lay-outs die nog in gebruik zijn ongewijzigd.

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

Om een specifieke lay-out te verwijderen, gebruikt u eerst haar [hasDependingSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) of [getDependingSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) methode. Wijs eventuele afhankelijke dia's opnieuw toe vóór het aanroepen van [LayoutSlide.remove](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#remove). Poging tot het verwijderen van een gebruikte lay-out veroorzaakt een [PptxEditException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxeditexception/).

## **Regel de zichtbaarheid van voettekst op een layoutdia**

Een lay-out heeft zijn eigen voettekst‑, dia‑nummer‑ en datum‑tijd‑placeholders. Gebruik de [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) methode om die placeholders voor één lay-out te beheren. Dit is handig wanneer bijvoorbeeld inhoudslay-outs voetnoten moeten tonen, maar titel‑lay-outs dat niet moeten.

Het volgende voorbeeld selecteert veilig een lay-out en maakt de voettekst‑elementen zichtbaar:

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

## **Regel de zichtbaarheid van voettekst op een master en de onderliggende lay-outs**

Om consistente voettekstinstellingen toe te passen binnen een master‑hiërarchie, gebruikt u de [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) methode. De propagatiemethoden van [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslideheaderfootermanager/) werken op de master en haar afhankelijke layout‑dia's en normale dia's; ze richten zich niet uitsluitend op één normale dia.

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

## **Veelgestelde vragen**

**Wat is het verschil tussen een masterdia en een layoutdia?**

Een masterdia definieert het thema van de presentatie en gedeelde opmaak. Een layoutdia behoort tot een master en definieert één herbruikbare ordening van placeholders. Normale dia's gebruiken die lay-outs en slaan dia‑specifieke inhoud op.

**Kan ik een layoutdia van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de doel‑collectie met de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) methode. Bij het kopiëren tussen presentaties controleert u bovendien lettertypen, thema's, afbeeldingen en andere bronnen die door de bron‑lay-out worden gebruikt.

**Wat gebeurt er als ik een lay-out wijzig die al in gebruik is?**

Afhankelijke dia's erven de lay-outwijzigingen tenzij ze de betreffende opmaak of objecten lokaal overschrijven. Placeholder‑geometrie en geërfde styling kunnen daardoor in veel dia's tegelijk wijzigen. Gebruik [getDependingSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) om de getroffen dia's te identificeren vóór het bewerken van de lay-out.

**Wat gebeurt er als ik een lay-out verwijder die nog in gebruik is?**

Aspose.Slides werpt een [PptxEditException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxeditexception/). Wijs eerst de afhankelijke dia's opnieuw toe, of gebruik [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) om alleen niet‑gerefereerde lay-outs te verwijderen.