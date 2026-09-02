---
title: "Dia-indelingen toepassen of wijzigen in PHP"
linktitle: "Dia-indeling"
type: docs
weight: 60
url: /nl/php-java/slide-layout/
keywords:
- dia-indeling
- inhoudsindeling
- plaatsaanduiding
- presentatie-ontwerp
- dia-ontwerp
- ongebruikte indeling
- voettekstzichtbaarheid
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
- PHP
- Aspose.Slides
description: "Dia-indelingen toepassen, maken en wijzigen in Aspose.Slides voor PHP via Java, plaatsaanduidingen toevoegen, ongebruikte indelingen verwijderen en de zichtbaarheid van de voettekst regelen."
---
## **Overzicht**

Een dia-indeling definieert de posities en opmaak van tijdelijke aanduidingen zoals titels, tekst, afbeeldingen, grafieken en tabellen. Het toepassen van een indeling geeft dia's een consistente structuur terwijl elke dia zijn eigen inhoud kan bevatten.

De meest voorkomende indelingen omvatten:

- **Titel-dia**: Bevat tijdelijke aanduidingen voor titel en ondertitel.
- **Titel en inhoud**: Bevat een tijdelijke aanduiding voor titel en een algemene inhoudstempelaanduiding.
- **Leeg**: Bevat geen inhoudstempelaanduidingen en is handig wanneer elke vorm handmatig wordt geplaatst.

## **Begrijpen van indelings-erfenis**

Een presentatie heeft drie gerelateerde niveaus:

1. Een [masterdia](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/) definieert het thema, de gedeelde opmaak, achtergronden en gemeenschappelijke objecten.
1. Een [indelingsdia](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/) behoort tot een master en definieert een bepaalde rangschikking van tijdelijke aanduidingen.
1. Een [normale dia](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/) gebruikt één indeling en slaat de ingevoerde inhoud voor die dia op.

Een normale dia erft thema en opmaak van zijn indeling, en de indeling erft van zijn master. Een waarde die direct op een normale dia wordt ingesteld, overschrijft de geërfde waarde op dat niveau. Wanneer een normale dia wordt aangemaakt, worden de tijdelijke aanduidingsvormen gegenereerd vanuit de gekozen indeling, terwijl de ingevoerde inhoud in die aanduidingen tot de normale dia behoort.

Voeg de benodigde tijdelijke aanduidingen toe aan een indeling voordat er dia's van worden gemaakt. Het later toevoegen van een extra tijdelijke aanduiding aan een indeling voegt niet automatisch een overeenkomstige vorm toe aan bestaande normale dia's.

Deze relatie heeft twee belangrijke consequenties:

- Het wijzigen van geërfde opmaak of de bestaande geometrie van tijdelijke aanduidingen op een indeling kan elke dia die ervan afhankelijk is bijwerken. Controleer de afhankelijk dia's en beoordeel de resulterende presentatie voordat u een al gebruikte indeling bewerkt.
- Een indeling die nog door een dia wordt gebruikt, kan niet worden verwijderd. Wijs eerst de afhankelijk dia's toe aan een andere indeling, of verwijder alleen ongebruikte indelingen.

Voor meer informatie over het hoogste niveau van deze hiërarchie, zie [Slide Master](/slides/nl/php-java/slide-master/).

## **Selecteer en pas een dia-indeling toe**

Gebruik een indelingstype wanneer de presentatie standaard PowerPoint-indelingsdefinities volgt. Indelingsnamen zijn door de gebruiker bewerkbaar en kunnen gelokaliseerd worden, waardoor selectie op basis van naam minder betrouwbaar is tenzij u de bron-sjabloon beheert.

Het volgende voorbeeld zoekt naar **Titel en inhoud** op de eerste master. Als die indeling niet beschikbaar is, valt het expres terug op **Leeg**. De tweede null-controle is nodig omdat een presentatie alleen aangepaste indelingen kan bevatten. De geselecteerde indeling wordt vervolgens toegepast op de eerste normale dia via de [Slide.setLayoutSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#setLayoutSlide)‑methode.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het wijzigen van de indeling van een dia verwijdert niet de gewone vormen die rechtstreeks aan de dia zijn toegevoegd. De posities van tijdelijke aanduidingen, geërfde opmaak en de overeenkomst tussen bestaande aanduidingen en de nieuwe indeling kunnen echter veranderen, controleer daarom de uitvoer bij het wisselen tussen sterk verschillende indelingen.

## **Voeg een indelingsdia toe**

Selectie en creatie zijn aparte bewerkingen. Het vorige voorbeeld selecteert een bestaande indeling; het maakt er geen aan. Om een indeling te maken, roep de [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterlayoutslidecollection/#add)‑methode aan op de lay-outcollectie van de doel-master.

Het volgende voorbeeld voegt altijd een nieuwe **Titel en inhoud**‑indeling toe met de naam `Report Title and Content`, en voegt vervolgens een normale dia toe gebaseerd op die indeling. Indelingsnamen moeten uniek zijn binnen de collectie.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Voeg alleen een indeling toe wanneer het sjabloon daadwerkelijk een extra herbruikbare structuur nodig heeft. Als er al een geschikte indeling bestaat, selecteer en hergebruik die in plaats van een duplicaat te maken.

## **Voeg tijdelijke aanduidingen toe aan een indelingsdia**

De [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#getPlaceholderManager)‑methode biedt een [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/) voor het toevoegen van vorm-tijdelijke aanduidingen aan een indeling.

| PowerPoint-tijdelijke aanduiding | `LayoutPlaceholderManager` Method |
| -------------------------------- | --------------------------------- |
| ![Inhoud](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Inhoud (verticaal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Tekst](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Tekst (verticaal)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Afbeelding](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Grafiek](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabel](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online-afbeelding](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Het volgende voorbeeld controleert of de **Leeg**-indeling bestaat, voegt er vier tijdelijke aanduidingen aan toe, en maakt vervolgens een normale dia die de gewijzigde indeling gebruikt. De volgorde is opzettelijk: de tijdelijke aanduidingen worden toegevoegd voordat de normale dia wordt aangemaakt, zodat Aspose.Slides de overeenkomstige vorm-tijdelijke aanduidingen op die dia kan genereren.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De tijdelijke aanduidingen op de indelingsdia](add_placeholders.png)

{{% alert color="warning" title="Waarschuwing" %}}
Het wijzigen van geërfde opmaak of de geometrie van bestaande indelingstijdelijke aanduidingen kan afhankelijke dia's beïnvloeden. Een nieuw toegevoegde indelingstijdelijke aanduiding wordt niet teruggevuld in bestaande normale dia's. Test wijziging van indelingen op een kopie van de presentatie en controleer elke afhankelijke dia.
{{% /alert %}}

## **Verwijder ongebruikte indelingsdia's**

Gebruik de [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides)‑methode om indelingen te verwijderen die door geen enkele normale dia worden verwezen. De methode laat indelingen die nog in gebruik zijn intact.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Om één specifieke indeling te verwijderen, gebruik eerst de [hasDependingSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#hasDependingSlides)‑ of [getDependingSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#getDependingSlides)‑methode. Wijs eventuele afhankelijke dia's opnieuw toe vóór het aanroepen van [LayoutSlide.remove](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#remove). Het proberen te verwijderen van een gebruikte indeling veroorzaakt een [PptxEditException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxeditexception/).

## **Stel de zichtbaarheid van de voettekst in op een indelingsdia**

Een indeling heeft zijn eigen voettekst‑, dia-nummer‑ en datum-tijd‑tijdelijke aanduidingen. Gebruik de [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#getHeaderFooterManager)‑methode om die aanduidingen voor één indeling te regelen. Dit is handig wanneer bijvoorbeeld inhouds-indelingen voetteksten moeten tonen, maar titel-indelingen dat niet moeten doen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Stel de zichtbaarheid van de voettekst in op een master en diens onderliggende indelingen**

Om consistente voettekstinstellingen toe te passen over een master-hiërarchie, gebruik de [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/#getHeaderFooterManager)‑methode. De propagatiemethoden van [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslideheaderfootermanager/) werken op de master en zijn afhankelijke indelingsdia’s en normale dia’s; ze richten zich niet alleen op één normale dia.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Wat is het verschil tussen een masterdia en een indelingsdia?**

Een masterdia definieert het thema en de gedeelde opmaak van de presentatie. Een indelingsdia behoort tot een master en definieert één herbruikbare rangschikking van tijdelijke aanduidingen. Normale dia's gebruiken die indelingen en slaan dia-specifieke inhoud op.

**Kan ik een indelingsdia van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de bestemmingscollectie met de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/globallayoutslidecollection/#addClone)‑methode. Bij het kopiëren tussen presentaties controleer ook lettertypen, thema's, afbeeldingen en andere bronnen die door de bron-indeling worden gebruikt.

**Wat gebeurt er als ik een indeling wijzig die al in gebruik is?**

Afhankelijke dia's erven de wijzigingen van de indeling, tenzij ze de betreffende opmaak of objecten lokaal overschrijven. De geometrie van tijdelijke aanduidingen en geërfde stijl kunnen daardoor op veel dia's tegelijk veranderen. Gebruik [getDependingSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#getDependingSlides) om de getroffen dia's te identificeren voordat u de indeling bewerkt.

**Wat gebeurt er als ik een indeling verwijder die nog in gebruik is?**

Aspose.Slides geeft een [PptxEditException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxeditexception/) terug. Wijs eerst de afhankelijke dia's opnieuw toe, of gebruik [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) om alleen niet-verwezen indelingen te verwijderen.