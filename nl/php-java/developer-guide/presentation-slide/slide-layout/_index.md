---
title: Dia-indelingen toepassen of wijzigen in PHP
linktitle: Dia-indeling
type: docs
weight: 60
url: /nl/php-java/slide-layout/
keywords:
- dia-indeling
- inhoudsindeling
- placeholder
- presentatieontwerp
- diaontwerp
- ongebruikte indeling
- zichtbaarheid van voettekst
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
- PHP
- Aspose.Slides
description: "Dia-indelingen toepassen, maken en aanpassen in Aspose.Slides voor PHP via Java, placeholders toevoegen, ongebruikte indelingen verwijderen en de zichtbaarheid van de voettekst beheren."
---
## **Overzicht**

Een slide‑indeling definieert de posities en opmaak van placeholders zoals titels, tekst, afbeeldingen, grafieken en tabellen. Het toepassen van een indeling geeft dia’s een consistente structuur, terwijl elke dia zijn eigen inhoud kan bevatten.

De meest voorkomende indelingen zijn:

- **Titel‑dia**: Bevat placeholders voor titel en ondertitel.
- **Titel en inhoud**: Bevat een titel‑placeholder en een algemene inhouds‑placeholder.
- **Leeg**: Bevat geen inhouds‑placeholders en is nuttig wanneer elke vorm handmatig wordt geplaatst.

## **Begrijp overerving van indelingen**

Een presentatie heeft drie gerelateerde niveaus:

1. Een [master‑dia](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/) definieert het thema, gedeelde opmaak, achtergronden en gemeenschappelijke objecten.
2. Een [indelings‑dia](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/) behoort tot een master en definieert een specifieke ordening van placeholders.
3. Een [normale dia](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/) gebruikt één indeling en slaat de ingevoerde inhoud voor die dia op.

Een normale dia erft thema en opmaak van haar indeling, en de indeling erft van haar master. Een waarde die direct op een normale dia wordt gezet, overschrijft de geërfde waarde op dat niveau. Wanneer een normale dia wordt aangemaakt, worden de placeholder‑vormen gegenereerd vanuit de gekozen indeling, terwijl de ingevoerde inhoud tot de normale dia behoort.

Voeg vereiste placeholders toe aan een indeling voordat je er dia’s van maakt. Een later toegevoegde placeholder aan een indeling wordt niet automatisch toegevoegd aan bestaande normale dia’s.

Deze relatie heeft twee belangrijke consequenties:

- Het wijzigen van geërfde opmaak of bestaande placeholder‑geometrie op een indeling kan elke dia die ervan afhankelijk is bijwerken. Controleer vóór het bewerken van een al in gebruik zijnde indeling de afhankelijke dia’s en bekijk de resulterende presentatie.
- Een indeling die nog door een dia wordt gebruikt, kan niet worden verwijderd. Wijs eerst de afhankelijke dia’s aan een andere indeling toe, of verwijder alleen ongebruikte indelingen.

Voor meer informatie over het bovenste niveau van deze hiërarchie, zie [Dia‑master](/slides/nl/php-java/slide-master/).

Om overgeërfde logo’s of decoratieve master‑vormen op één dia of via een gedeelde indeling te verbergen, zie [De zichtbaarheid van master‑grafische elementen beheren](/slides/nl/php-java/slide-master/). Het voorbeeld vergelijkt twee dia’s die dezelfde master gebruiken.

## **Selecteer en pas een dia‑indeling toe**

Gebruik een indelingstype wanneer de presentatie de standaard PowerPoint‑indelingsdefinities volgt. Indelingsnamen zijn door de gebruiker bewerkbaar en kunnen worden gelokaliseerd, dus selectie op basis van naam is minder betrouwbaar tenzij je de bron‑template beheert.

Het volgende voorbeeld zoekt **Titel en inhoud** op de eerste master. Als die indeling niet beschikbaar is, valt het expres terug op **Leeg**. De tweede null‑controle is noodzakelijk omdat een presentatie alleen aangepaste indelingen kan bevatten. De gekozen indeling wordt vervolgens toegepast op de eerste normale dia via de [Slide.setLayoutSlide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#setLayoutSlide)‑methode.

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

Het wijzigen van de indeling van een dia verwijdert niet de gewone vormen die rechtstreeks aan de dia zijn toegevoegd. Placeholder‑posities, geërfde opmaak en de correspondentie tussen bestaande placeholders en de nieuwe indeling kunnen echter veranderen, dus inspecteer de output bij het wisselen tussen sterk verschillende indelingen.

## **Voeg een indelings‑dia toe**

Selectie en creatie zijn afzonderlijke handelingen. Het vorige voorbeeld selecteert een bestaande indeling; het maakt er geen nieuwe aan. Om een indeling te maken, roep je de [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterlayoutslidecollection/#add)‑methode aan op de indelingscollectie van de doel‑master.

Het volgende voorbeeld voegt altijd een nieuwe **Titel en inhoud**‑indeling toe met de naam `Report Title and Content`, en voegt vervolgens een normale dia toe op basis daarvan. Indelingsnamen moeten uniek zijn binnen de collectie.

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

Voeg een indeling alleen toe wanneer de template werkelijk een extra herbruikbare structuur nodig heeft. Als er al een geschikte indeling bestaat, selecteer en hergebruik die in plaats van een duplicaat te maken.

## **Voeg placeholders toe aan een indelings‑dia**

De [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#getPlaceholderManager)‑methode biedt een [LayoutPlaceholderManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/) voor het toevoegen van placeholder‑vormen aan een indeling.

| PowerPoint‑placeholder              | `LayoutPlaceholderManager`‑methode |
| ----------------------------------- | ----------------------------------- |
| ![Inhoud](content.png)              | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Inhoud (verticaal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Tekst](text.png)                  | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Tekst (verticaal)](textV.png)    | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Afbeelding](picture.png)          | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Grafiek](chart.png)               | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabel](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online‑afbeelding](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Het volgende voorbeeld controleert of de **Leeg**‑indeling bestaat, voegt vier placeholders toe en maakt vervolgens een normale dia die de aangepaste indeling gebruikt. De volgorde is opzettelijk: de placeholders worden toegevoegd vóór de normale dia, zodat Aspose.Slides de bijbehorende placeholder‑vormen op die dia kan genereren.

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

![De placeholders op de indelings‑dia](add_placeholders.png)

{{% alert color="warning" title="Waarschuwing" %}}
Het wijzigen van geërfde opmaak of de geometrie van bestaande indelings‑placeholders kan afhankelijke dia’s beïnvloeden. Een nieuw toegevoegde placeholder wordt niet automatisch toegevoegd aan bestaande normale dia’s. Test indelingswijzigingen op een kopie van de presentatie en controleer elke afhankelijke dia.
{{% /alert %}}

## **Verwijder ongebruikte indelings‑dia's**

Gebruik de [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides)‑methode om indelingen te verwijderen die door geen enkele normale dia worden gerefereerd. De methode laat indelingen die nog in gebruik zijn onaangeroerd.

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

Om één specifieke indeling te verwijderen, gebruik eerst de [hasDependingSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#hasDependingSlides)‑ of [getDependingSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#getDependingSlides)‑methode. Wijs eventuele afhankelijke dia’s opnieuw toe voordat je [LayoutSlide.remove](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#remove) aanroept. Het proberen te verwijderen van een gebruikte indeling leidt tot een [PptxEditException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxeditexception/).

## **Beheer de zichtbaarheid van voettekst op een indelings‑dia**

Een indeling heeft zijn eigen voettekst‑, dia‑nummer‑ en datum‑tijd‑placeholders. Gebruik de [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#getHeaderFooterManager)‑methode om die placeholders voor één indeling te beheren. Dit is handig wanneer bijvoorbeeld inhouds‑indelingen wel voetteksten moeten tonen maar titel‑indelingen niet.

Het volgende voorbeeld selecteert veilig een indeling en maakt de voettekstelementen zichtbaar:

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

## **Beheer de zichtbaarheid van voettekst op een master en zijn onderliggende indelingen**

Om consistent voettekst‑instellingen door de hele master‑hiërarchie toe te passen, gebruik je de [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslide/#getHeaderFooterManager)‑methode. De propagatiemethoden van [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/masterslideheaderfootermanager/) werken op de master en op zijn afhankelijke indelings‑ en normale dia’s; ze richten zich niet op één enkele normale dia.

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

## **Veelgestelde vragen**

**Wat is het verschil tussen een master‑dia en een indelings‑dia?**

Een master‑dia definieert het thema en de gedeelde opmaak van de presentatie. Een indelings‑dia behoort tot een master en definieert één herbruikbare ordening van placeholders. Normale dia’s gebruiken die indelingen en slaan dia‑specifieke inhoud op.

**Kan ik een indelings‑dia van de ene presentatie naar de andere kopiëren?**

Ja. Voeg een kopie toe aan de bestemmingscollectie met de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/globallayoutslidecollection/#addClone)‑methode. Bij het kopiëren tussen presentaties moet je ook fonts, thema’s, afbeeldingen en andere bronnen die door de bron‑indeling worden gebruikt controleren.

**Wat gebeurt er als ik een indeling bewerk die al in gebruik is?**

Afhankelijke dia’s erven de indelingswijzigingen, tenzij ze de betreffende opmaak of objecten lokaal overschrijven. Placeholder‑geometrie en geërfde styling kunnen daardoor op veel dia’s tegelijk veranderen. Gebruik [getDependingSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/layoutslide/#getDependingSlides) om de getroffen dia’s te identificeren voordat je de indeling bewerkt.

**Wat gebeurt er als ik een indeling verwijder die nog in gebruik is?**

Aspose.Slides gooit een [PptxEditException](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pptxeditexception/). Wijs eerst de afhankelijke dia’s opnieuw toe, of gebruik [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) om alleen niet‑gerefereerde indelingen te verwijderen.