---
title: Dia‑indelingen toepassen of wijzigen in JavaScript
linktitle: Dia‑indeling
type: docs
weight: 60
url: /nl/nodejs-java/slide-layout/
keywords:
- dia‑indeling
- inhoudsindeling
- placeholder
- presentatie‑ontwerp
- dia‑ontwerp
- ongebruikte indeling
- voettekst‑zichtbaarheid
- titeldia
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer en pas dia‑indelingen aan in Aspose.Slides voor Node.js. Ontdek indelingstypen, placeholder‑beheer en voettekst‑zichtbaarheid aan de hand van codevoorbeelden."
---
## **Introductie**

Een dia‑indeling bepaalt de rangschikking van placeholder‑vakken en de opmaak van de inhoud op een dia. Ze regelt welke placeholders beschikbaar zijn en waar ze verschijnen. Dia‑indelingen helpen u presentaties snel en consistent te ontwerpen—of u nu iets eenvoudigs of complexers maakt. Enkele van de meest voorkomende dia‑indelingen in PowerPoint zijn:

**Titel‑dia‑indeling** – Bevat twee tekst‑placeholders: één voor de titel en één voor de ondertitel.

**Titel‑en‑inhoud‑indeling** – Beschikt over een kleinere titel‑placeholder bovenaan en een grotere eronder voor de hoofdinhoud (zoals tekst, opsommingstekens, grafieken, afbeeldingen enzovoort).

**Lege indeling** – Bevat geen placeholders, zodat u de dia volledig zelf kunt ontwerpen vanaf nul.

Dia‑indelingen maken deel uit van een dia‑master, de bovenste dia die de indelingsstijlen voor de presentatie bepaalt. U kunt indelingsdia's benaderen en aanpassen via de dia‑master—op type, naam of unieke ID. Alternatief kunt u een specifieke indelingsdia rechtstreeks in de presentatie bewerken.

Om te werken met dia‑indelingen in Aspose.Slides for Node.js, kunt u gebruiken:

- Methoden zoals [getLayoutSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getLayoutSlides) en [getMasters](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getMasters) onder de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/).
- Typen zoals [LayoutSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/) en [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslideheaderfootermanager/).

{{% alert title="Info" color="info" %}}
Om meer te weten te komen over het werken met masterslides, bekijk het artikel [Slide Master](/slides/nl/nodejs-java/slide-master/).
{{% /alert %}}

## **Dia‑indelingen toevoegen aan presentaties**

Om het uiterlijk en de structuur van uw dia's aan te passen, moet u mogelijk nieuwe indelingsdia's aan een presentatie toevoegen. Aspose.Slides voor Node.js stelt u in staat te controleren of een bepaalde indeling al bestaat, deze indien nodig toe te voegen, en te gebruiken om dia's in te voegen op basis van die indeling.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/).
1. Benader de [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterlayoutslidecollection/).
1. Controleer of de gewenste indelingsdia al bestaat in de collectie. Zo niet, voeg dan de benodigde indelingsdia toe.
1. Voeg een lege dia toe op basis van de nieuwe indelingsdia.
1. Sla de presentatie op.

```js
// Instantieer de Presentation‑klasse die een PowerPoint‑bestand vertegenwoordigt.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Doorloop de indelingsdia‑typen om een indelingsdia te selecteren.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // Een situatie waarin de presentatie niet alle indelingstypen bevat.
        // Het presentiebestand bevat alleen lege en aangepaste indelingstypen.
        // Echter kunnen indelingsdia's met aangepaste typen herkenbare namen hebben,
        // zoals "Title", "Title and Content", enz., die gebruikt kunnen worden voor het selecteren van een indelingsdia.
        // U kunt ook vertrouwen op een reeks placeholder‑vormtypen.
        // Bijvoorbeeld moet een Titeldia alleen het Title‑placeholder‑type hebben, enzovoort.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // Voeg een lege dia toe met de toegevoegde indelingsdia.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Sla de presentatie op naar schijf.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ongebruikte indelingsdia's verwijderen**

Aspose.Slides biedt de methode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) van de klasse [Compress](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/) aan om ongewenste en ongebruikte indelingsdia's te verwijderen.

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Placeholders toevoegen aan dia‑indelingen**

Aspose.Slides biedt de methode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) die u in staat stelt nieuwe placeholders toe te voegen aan een indelingsdia.

Deze manager bevat methoden voor de volgende placeholder‑typen:

| PowerPoint‑placeholder              | [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutplaceholdermanager/) Methode |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)       | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)             | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)                 | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)                 | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)    | addOnlineImagePlaceholder(float x, float y, float width, float height) |

De volgende JavaScript‑code toont hoe u nieuwe placeholder‑vormen kunt toevoegen aan de lege indelingsdia:

```js
let presentation = new aspose.slides.Presentation();
try {
    // Haal de lege indelingsdia op.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // Haal de placeholder‑manager van de indelingsdia op.
    let placeholderManager = layout.getPlaceholderManager();

    // Voeg verschillende placeholders toe aan de lege indelingsdia.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Voeg een nieuwe dia toe met de lege indeling.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De placeholders op de indelingsdia](add_placeholders.png)

## **Voettekst‑zichtbaarheid instellen voor een indelingsdia**

In PowerPoint‑presentaties kunnen voettekstelementen zoals datum, dia‑nummer en aangepaste tekst worden weergegeven of verborgen, afhankelijk van de dia‑indeling. Aspose.Slides voor Node.js stelt u in staat de zichtbaarheid van deze voettekst‑placeholders te beheren. Dit is handig wanneer u wilt dat bepaalde indelingen voettekstinformatie tonen, terwijl andere strak en minimaal blijven.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/).
1. Haal een referentie naar een indelingsdia op basis van de index op.
1. Stel de voettekst‑placeholder van de dia in op zichtbaar.
1. Stel de placeholder voor het dia‑nummer in op zichtbaar.
1. Stel de datum‑tijd‑placeholder in op zichtbaar.
1. Sla de presentatie op.

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Voettekst‑zichtbaarheid voor onderliggende dia's instellen**

In PowerPoint‑presentaties kunnen voettekstelementen zoals datum, dia‑nummer en aangepaste tekst op het niveau van de masterslide worden beheerd om consistentie over alle indelingsdia's te waarborgen. Aspose.Slides voor Node.js stelt u in staat de zichtbaarheid en inhoud van deze voettekst‑placeholders op de masterslide in te stellen en deze instellingen door te geven aan alle onderliggende indelingsdia's. Deze aanpak garandeert uniforme voettekst‑informatie in de gehele presentatie.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/).
1. Haal een referentie naar de masterslide op basis van de index op.
1. Stel de voettekst‑placeholders van de master en alle onderliggende dia's in op zichtbaar.
1. Stel de dia‑nummer‑placeholders van de master en alle onderliggende dia's in op zichtbaar.
1. Stel de datum‑tijd‑placeholders van de master en alle onderliggende dia's in op zichtbaar.
1. Sla de presentatie op.

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Wat is het verschil tussen een masterslide en een indelingsdia?**

Een masterslide bepaalt het globale thema en de standaardopmaak, terwijl indelingsdia's specifieke rangschikkingen van placeholders voor verschillende soorten inhoud definiëren.

**Kan ik een indelingsdia van de ene presentatie naar de andere kopiëren?**

Ja, u kunt een indelingsdia klonen uit de indelingsdia‑collectie van een presentatie, toegankelijk via de methode [getLayoutSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getLayoutSlides), en deze in een andere presentatie invoegen met de `addClone`‑methode.

**Wat gebeurt er als ik een indelingsdia verwijder die nog door een dia wordt gebruikt?**

Als u probeert een indelingsdia te verwijderen die nog door ten minste één dia in de presentatie wordt gebruikt, zal Aspose.Slides een [PptxEditException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxeditexception/) werpen. Gebruik in plaats daarvan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides), die veilig alleen de niet‑gebruikte indelingsdia's verwijdert.