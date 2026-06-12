---
title: Slide‑lay-outs toepassen of wijzigen in PHP
linktitle: Slide‑lay-out
type: docs
weight: 60
url: /nl/php-java/slide-layout/
keywords:
- slide‑lay-out
- inhoudslay-out
- plaatsaanduiding
- presentatie‑ontwerp
- slide‑ontwerp
- ongebruikte lay-out
- voettekst‑zichtbaarheid
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
- PHP
- Aspose.Slides
description: "Beheer en pas slide‑lay-outs aan in Aspose.Slides voor PHP via Java. Verken lay‑outtypen, controle over plaatsaanduidingen en voettekst‑zichtbaarheid via code‑voorbeelden."
---
## **Inleiding**

Een dia‑indeling bepaalt de rangschikking van tijdelijke aanduidingsvakken en de opmaak van de inhoud op een dia. Ze regelt welke tijdelijke aanduidingen beschikbaar zijn en waar ze verschijnen. Dia‑indelingen helpen u presentaties snel en consistent te ontwerpen — of u nu iets eenvoudigs of complexers maakt. Enkele van de meest voorkomende dia‑indelingen in PowerPoint zijn:

**Titel‑dia‑indeling** – Bevat twee tekst‑plaatsaanduidingen: één voor de titel en één voor de ondertitel.

**Titel‑en‑Inhoud‑indeling** – Heeft een kleinere titel‑plaatsaanduiding bovenaan en een grotere eronder voor de hoofdinhoud (zoals tekst, opsommingstekens, diagrammen, afbeeldingen en meer).

**Lege indeling** – Bevat geen plaatsaanduidingen, waardoor u volledige controle heeft om de dia vanaf nul te ontwerpen.

Dia‑indelingen maken deel uit van een dia‑master, die de bovenliggende dia is die de indelingsstijlen voor de presentatie definieert. U kunt indelingsdia’s benaderen en aanpassen via de dia‑master — op type, naam of unieke ID. U kunt ook een specifieke indelingsdia rechtstreeks in de presentatie bewerken.

Om te werken met dia‑indelingen in Aspose.Slides for PHP, kunt u gebruiken:

- Methoden zoals [getLayoutSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getLayoutSlides) en [getMasters](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getMasters) onder de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse
- Types zoals [LayoutSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/), en [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Om meer te leren over het werken met masterdia’s, bekijk het artikel [Slide Master](/slides/nl/php-java/slide-master/) .
{{% /alert %}}

## **Dia‑indelingen toevoegen aan presentaties**

Om het uiterlijk en de structuur van uw dia’s aan te passen, moet u mogelijk nieuwe indelingsdia’s aan een presentatie toevoegen. Aspose.Slides for PHP stelt u in staat om te controleren of een bepaalde indeling al bestaat, deze indien nodig toe te voegen, en te gebruiken om dia’s in te voegen op basis van die indeling.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
1. Benader de [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterlayoutslidecollection/) .
1. Controleer of de gewenste indelingsdia al bestaat in de collectie. Zo niet, voeg dan de benodigde indelingsdia toe.
1. Voeg een lege dia toe op basis van de nieuwe indelingsdia.
1. Sla de presentatie op.

De volgende PHP‑code toont hoe u een dia‑indeling aan een PowerPoint‑presentatie kunt toevoegen:

```php
// Maak een instantie van de Presentation‑klasse die een PowerPoint‑bestand vertegenwoordigt.
$presentation = new Presentation("Sample.pptx");
try {
    // Doorloop de layout‑dia‑types om een layout‑dia te selecteren.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // Een situatie waarin de presentatie niet alle layout‑types bevat.
        // Het presentatiesbestand bevat alleen lege en aangepaste layout‑types.
        // Echter, layout‑dia’s met aangepaste types kunnen herkenbare namen hebben,
        // zoals "Title", "Title and Content", etc., which can be used for layout slide selection.
        // U kunt ook vertrouwen op een reeks plaatsaanduidings‑vormtypes.
        // Bijvoorbeeld, een Title slide should have only the Title placeholder type, and so on.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Voeg een lege dia toe met behulp van de toegevoegde layout‑dia.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // Sla de presentatie op schijf.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ongebruikte indelingsdia’s verwijderen**

Aspose.Slides biedt de [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides)‑methode van de [Compress](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/)‑klasse, waarmee u ongewenste en ongebruikte indelingsdia’s kunt verwijderen.

De volgende PHP‑code laat zien hoe u een indelingsdia uit een PowerPoint‑presentatie verwijdert:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Plaatsaanduidingen toevoegen aan dia‑indelingen**

Aspose.Slides biedt de [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#getPlaceholderManager)‑methode, waarmee u nieuwe plaatsaanduidingen aan een indelingsdia kunt toevoegen.

Deze manager bevat methoden voor de volgende plaatsaanduidingstypen:

| PowerPoint‑plaatsaanduiding | [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/) Methode |
| --------------------------- | ------------------------------------------------------------ |
| ![Inhoud](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Inhoud (Verticaal)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Tekst](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Tekst (Verticaal)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Afbeelding](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagram](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabel](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online‑afbeelding](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

De volgende PHP‑code toont hoe u nieuwe plaatsaanduiding‑vormen toevoegt aan de lege indelingsdia:

```php
$presentation = new Presentation();
try {
    // Haal de lege lay-outdia op.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Haal de plaatsaanduidingsmanager van de lay-outdia op.
    $placeholderManager = $layout->getPlaceholderManager();

    // Voeg verschillende plaatsaanduidingen toe aan de lege lay-outdia.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Voeg een nieuwe dia toe met de lege lay-out.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![The placeholders on the layout slide](add_placeholders.png)

## **Voettekst‑zichtbaarheid instellen voor een indelingsdia**

In PowerPoint‑presentaties kunnen voettekstelementen zoals datum, dia‑nummer en aangepaste tekst worden weergegeven of verborgen, afhankelijk van de dia‑indeling. Aspose.Slides for PHP stelt u in staat de zichtbaarheid van deze voettekst‑plaatsaanduidingen te beheren. Dit is handig wanneer u wilt dat bepaalde indelingen voettekst‑informatie tonen, terwijl andere strak en minimaal blijven.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar een indelingsdia op basis van de index.
1. Stel de voettekst‑plaatsaanduiding van de dia in op zichtbaar.
1. Stel de dia‑nummer‑plaatsaanduiding in op zichtbaar.
1. Stel de datum‑tijd‑plaatsaanduiding in op zichtbaar.
1. Sla de presentatie op.

De volgende PHP‑code laat zien hoe u de zichtbaarheid van een dia‑voettekst instelt en gerelateerde taken uitvoert:

```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

## **Voettekst‑zichtbaarheid voor onderliggende dia’s instellen**

In PowerPoint‑presentaties kunnen voettekstelementen zoals datum, dia‑nummer en aangepaste tekst op het niveau van de master‑dia worden beheerd om consistentie over alle indelingsdia’s te waarborgen. Aspose.Slides for PHP stelt u in staat de zichtbaarheid en inhoud van deze voettekst‑plaatsaanduidingen op de master‑dia in te stellen en deze instellingen door te voeren naar alle onderliggende indelingsdia’s. Deze aanpak zorgt voor uniforme voettekst‑informatie in de hele presentatie.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar de master‑dia op basis van de index.
1. Stel de voettekst‑plaatsaanduidingen van de master en alle onderliggende dia’s in op zichtbaar.
1. Stel de dia‑nummer‑plaatsaanduidingen van de master en alle onderliggende dia’s in op zichtbaar.
1. Stel de datum‑tijd‑plaatsaanduidingen van de master en alle onderliggende dia’s in op zichtbaar.
1. Sla de presentatie op.

De volgende PHP‑code toont deze bewerking:

```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Wat is het verschil tussen een master‑dia en een indelingsdia?**

Een master‑dia definieert het algemene thema en de standaardopmaak, terwijl indelingsdia’s specifieke rangschikkingen van plaatsaanduidingen voor verschillende soorten inhoud bepalen.

**Kan ik een indelingsdia van de ene presentatie naar de andere kopiëren?**

Ja, u kunt een indelingsdia klonen vanuit de indelingsdia‑collectie van een presentatie, toegankelijk via de [getLayoutSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getLayoutSlides)‑methode, en deze in een andere presentatie invoegen met de `addClone`‑methode.

**Wat gebeurt er als ik een indelingsdia verwijder dat nog door een dia wordt gebruikt?**

Als u probeert een indelingsdia te verwijderen dat nog wordt verwezen door ten minste één dia in de presentatie, zal Aspose.Slides een [PptxEditException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxeditexception/) werpen. Gebruik [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) om alleen de indelingsdia’s die niet in gebruik zijn veilig te verwijderen.