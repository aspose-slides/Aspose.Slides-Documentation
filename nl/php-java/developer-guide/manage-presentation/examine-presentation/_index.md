---
title: Presentatie-informatie ophalen en bijwerken in PHP
linktitle: Presentatie-informatie
type: docs
weight: 30
url: /nl/php-java/examine-presentation/
keywords:
- presentatieformaat
- presentatie-eigenschappen
- documenteigenschappen
- eigenschappen ophalen
- eigenschappen lezen
- eigenschappen wijzigen
- eigenschappen aanpassen
- eigenschappen bijwerken
- PPTX onderzoeken
- PPT onderzoeken
- ODP onderzoeken
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Verken dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor PHP voor snellere inzichten en slimmer content-audit."
---
## **Overzicht**

Aspose.Slides kan het formaat van een presentatie identificeren en de documentmetadata lezen zonder een volledig presentatiemodel te maken. Dit is handig wanneer u bestanden moet classificeren, een inventaris moet opstellen of eigenschappen moet inspecteren voordat u beslist of de presentatie‑inhoud geladen en verwerkt moet worden.

Dit artikel toont lichtgewicht inspectie via [PresentationFactory](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationfactory/) en [PresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/), evenals gerichte updates via [DocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/).

## **Controleer een presentatieformaat**

Gebruik [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationfactory/) om een bestand te inspecteren zonder een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instance te maken. De [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#getLoadFormat)‑methode meldt het gedetecteerde formaat, bijvoorbeeld PPTX, PPT of ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Maak een lichtgewicht presentatie‑inventaris**

Wanneer u veel presentatie‑bestanden verwerkt, heeft u mogelijk een compacte inventaris nodig voor validatie, indexering of een document‑beheersysteem. In dit scenario gebruikt u [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationfactory/) om een [PresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/)‑object te verkrijgen, en roept vervolgens [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#readDocumentProperties) aan om de documentmetadata te lezen. Deze benadering maakt geen [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instance aan en vereist niet dat u het volledige presentatiemodel doorloopt.

De uitgebreide eigenschappen die door [DocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/) worden blootgesteld, bieden de volgende inventariswaarden:

| Methode | Inventariswaarde |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#getSlides) | Totaal aantal dia's. |
| [getHiddenSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Aantal verborgen dia's. |
| [getNotes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#getNotes) | Aantal dia's die notities bevatten. |
| [getParagraphs](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#getParagraphs) | Totaal aantal alinea's, indien beschikbaar. |
| [getWords](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#getWords) | Totaal aantal woorden. |
| [getMultimediaClips](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Totaal aantal audio‑ en video‑clips. |

Het volgende voorbeeld leest deze waarden zonder een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑object te maken en drukt een compacte inventaris af. Het combineert ook [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#getHeadingPairs) met [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#getTitlesOfParts) om inhoudsgroepen weer te geven, zoals lettertypen, thema's en dia‑titels.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Elke [HeadingPair](https://reference.aspose.com/slides/nl/php-java/aspose.slides/headingpair/) levert een groepsnaam en het aantal items in die groep. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#getTitlesOfParts) retourneert een platte, geordende array, dus verwerk het aantal opeenvolgende titels dat door elk heading‑pair wordt opgegeven.

### **Opgeslagen metadata en formaatbeperkingen**

De inventaris­eigenschappen die door [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#readDocumentProperties) worden geretourneerd, weerspiegelen metadata die beschikbaar is in het bron­document. Aspose.Slides laadt en doorloopt het presentatiemodel niet om deze waarden opnieuw te berekenen voor deze oproep. Ontbrekende eigenschappen worden weergegeven met standaardwaarden, en opgeslagen waarden kunnen verouderd zijn als de toepassing die het bestand het laatst heeft opgeslagen de documenteigenschappen niet heeft bijgewerkt.

- **PPTX:** Het formaat biedt uitgebreide documenteigenschappen voor aantallen dia's, notities, verborgen dia's, alinea's, woorden en multimedia, evenals heading‑pairs en part‑titles. De beschikbaarheid hangt af van welke eigenschappen door de documentproducent zijn geschreven.
- **PPT:** Het binair formaat kan overeenkomstige document‑samenvattings­eigenschappen opslaan. Als een eigenschap afwezig is of niet is ververst door de documentproducent, retourneert Aspose.Slides de opgeslagen of standaardwaarde in plaats van deze van de dia's te berekenen.
- **ODP:** OpenDocument‑metadata biedt algemene documentstatistieken, zoals pagina‑, alinea‑ en woordtelling, maar deze waarden komen niet overeen met elke PowerPoint‑specifieke uitgebreide eigenschap. Metadata voor verborgen dia's, notitie‑dia's, multimedia, heading‑pair en part‑title kunnen ontbreken, en de inventaris­eigenschappen kunnen standaardwaarden teruggeven. Beschouw een nul‑waarde of een lege array niet als definitief bewijs dat de corresponderende inhoud afwezig is.

Gebruik de lichtgewicht metadata‑benadering voor inventarissen en voorlopige controles. Laad de presentatie en inspecteer het levende objectmodel wanneer het resultaat in‑memory wijzigingen moet weerspiegelen of wanneer u de feitelijke presentatiedata moet verifiëren.

## **Werk presentatie‑eigenschappen bij**

De eigenschappen die door [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#readDocumentProperties) worden geretourneerd, kunnen ook worden aangepast zonder een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instance te maken. Pas de wijzigingen toe met [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#updateDocumentProperties), en schrijf vervolgens de gekoppelde presentatie met [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

De volgende afbeelding toont de originele documenteigenschappen van de PowerPoint‑presentatie.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Het volgende voorbeeld wijzigt de titel en de laatst‑opgeslagen tijd en schrijft het resultaat naar een nieuw bestand:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

De volgende afbeelding toont de gewijzigde documenteigenschappen van de PowerPoint‑presentatie.

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige links**

Voor gerelateerde beveiligingscontroles en bescherminginstellingen, zie de volgende artikelen:

- [Password‑Protect Presentations](/slides/nl/php-java/password-protected-presentation/)
- [Write‑Protect Presentations](/slides/nl/php-java/write-protected-presentation/)

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingebed en welke dat zijn?**

Laad de presentatie en gebruik [Presentation::getFontsManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getFontsManager). Roep [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) aan om de ingebedde lettertypen te verkrijgen en [FontsManager::getFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/#getFonts) om de lettertypen te verkrijgen die door de presentatie worden gebruikt. Vergelijk beide resultaten om lettertypen te vinden die wel nodig zijn voor weergave, maar niet zijn ingebed.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Wanneer opgeslagen documentmetadata toereikend is, lees dan [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#getHiddenSlides) via [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationfactory/) en [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentationinfo/#readDocumentProperties). Dit is geschikt voor een lichtgewicht inventaris. Als de presentatie in het geheugen is gewijzigd, kan de opgeslagen metadata ontbreken of verouderd zijn, of u moet live‑waarden verifiëren door door [Presentation::getSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getSlides) te itereren en elke dia’s [Slide::getHidden](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getHidden)‑methode te inspecteren.

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie worden gebruikt, en of ze afwijken van de standaardinstellingen?**

Ja. Laad de presentatie en roep [Presentation::getSlideSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getSlideSize) aan. Gebruik [SlideSize::getType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesize/#getSize) en [SlideSize::getOrientation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidesize/#getOrientation) om de huidige instellingen te vergelijken met de verwachte vooraf ingestelde waarden en afmetingen.

**Is er een snelle manier om te zien of grafieken verwijzen naar externe gegevensbronnen?**

Ja. Lokaliseer elke [Chart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/) en roep [ChartData::getDataSourceType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/#getDataSourceType) aan. Voor een extern werkboek, roep [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/#getExternalWorkbookPath) aan. Het gegevenstype‑bron en het pad identificeren een externe verwijzing, maar verifiëren of het doel beschikbaar is, vereist een afzonderlijke resource‑check.

**Hoe kan ik 'zware' dia's beoordelen die het renderen of exporteren naar PDF kunnen vertragen?**

Er bestaat geen enkele complexiteits‑eigenschap. Doorloop [Presentation::getSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getSlides) en de [BaseSlide::getShapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/#getShapes)‑collectie van elke dia. Gebruik het aantal vormen en de aanwezigheid van grote afbeeldingen, effecten, animaties of multimedia als screeningssignalen, en meet een representatieve render of export voordat u een dia als een bevestigde prestatietekort beschouwt.