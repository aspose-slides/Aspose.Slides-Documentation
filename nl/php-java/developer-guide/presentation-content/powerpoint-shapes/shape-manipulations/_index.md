---
title: Beheer presentatievormen in PHP
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/php-java/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatie-vorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- volgorde van vormen wijzigen
- interop-vorm-ID ophalen
- alternatieve tekst van vorm
- aanpassingspunt van vorm
- voorgedefinieerde vormaanpassing
- vormgeometrie
- vormlay-outformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u presentatievormen kunt identificeren, aanpassen, klonen, verwijderen, verbergen, herschikken, exporteren, uitlijnen en spiegelen met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aspose.Slides for PHP via Java stelt de vormen op een dia voor als een geordende [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/). De collectie is zowel de plaats waar je vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de vorm die het verst naar achteren ligt, terwijl de laatste index de vorm is die het verst naar voren ligt.

Dit artikel volgt dat model. Het legt eerst uit hoe je een vorm betrouwbaar kunt identificeren en vooraf ingestelde aanpassingspunten kunt wijzigen, en toont vervolgens hoe je vormen kunt klonen, verwijderen, verbergen en herschikken. De laatste secties behandelen opmaak op lay-outniveau, SVG-export, uitlijning en omkering-instellingen. Elk voorbeeld is onafhankelijk, zodat je alleen de bewerkingen kunt gebruiken die jouw workflow vereist.

## **Identificeer en vind vormen**

Collectie‑indexen zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identifiers. Toevoegen, verwijderen of herschikken van een vorm kan de index wijzigen. Kies een identifier op basis van hoe de presentatie is gemaakt en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getname/) is handig voor door ontwikkelaars beheerde sjablonen en is makkelijk te inspecteren in het selectiepaneel van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie vast als code ervan afhankelijk is.
- [AlternativeText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getalternativetext/) is nuttig wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik betekenisvolle toegankelijkheidstekst niet stilletjes als databasesleutel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getofficeinteropshapeid/) is een alleen-lezen identifier die uniek is binnen een dia en overeenkomt met de shape‑ID die PowerPoint‑interop gebruikt. Gebruik deze bij integratie met PowerPoint of wanneer je een ondubbelzinnige referentie nodig hebt gedurende de levensduur van een vorm. Een gekloonde of opnieuw aangemaakte vorm is een andere vorm en krijgt een eigen ID.

De verwante [Shape::getUniqueId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getuniqueid/)‑methode retourneert een identifier met presentatiescope, maar die identifier is bedoeld voor add‑ins en kan opnieuw worden toegewezen. Zie het niet als een permanente externe sleutel. Als langdurige identiteit cruciaal is, bewaar de mapping in applicatie‑data en valideer dat de verwachte vorm nog bestaat.

Het volgende voorbeeld zoekt op naam met een exacte vergelijking en rapporteert de interop‑ID met presentatiescope. Wanneer de sjabloon de verwachte vorm niet bevat, meldt de code dat resultaat in plaats van door te gaan met het verkeerde object.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Wanneer een bewerking specifiek is voor een type vorm, controleer dan de runtime‑klasse voordat je type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst bij alleen als het benoemde object een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) is.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Identificeer en wijzig vooraf ingestelde vormaanpassingen**

Vooraf ingestelde geometrievormen kunnen aanpassingspunten blootleggen die eigenschappen reguleren zoals hoekgrootte, pijlpuntverhoudingen of booghoeken. Toegang tot deze punten gebeurt via de alleen‑lezen [GeometryShape::getAdjustments](https://reference.aspose.com/slides/nl/php-java/aspose.slides/geometryshape/#getAdjustments)‑collectie. De collectie zelf wordt geleverd door de vorm, maar elke [AdjustValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/adjustvalue/) bevat een waarde die kan worden gewijzigd.

Betrouw niet uitsluitend op een vaste collectie‑index. Loop door de aanpassingen en inspecteer de alleen‑lezen [AdjustValue::getType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/adjustvalue/#getType)‑methode, waarvan de [ShapeAdjustmentType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapeadjustmenttype/)‑waarde beschrijft wat de aanpassing regelt. De alleen‑lezen [AdjustValue::getName](https://reference.aspose.com/slides/nl/php-java/aspose.slides/adjustvalue/getname/)‑methode biedt extra identificatie‑informatie en is vooral nuttig wanneer een preset meer dan één aanpassing met hetzelfde semantische type bevat.

Gebruik de waardemethode die bij de betekenis van de aanpassing past:

| Aanpassingstype | Doel | Waarde om te wijzigen |
|---|---|---|
| `CornerSize` | Grootte van afgeronde hoeken | [setRawValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Dikte van een pijpstaart | `setRawValue` |
| `ArrowheadLength` | Lengte van een pijlkop | `setRawValue` |
| `ArrowheadWidth` | Breedte van een pijlkop | `setRawValue` |
| `StartAngle` | Starthoek van een taart- of boogvorm | [setAngleValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Eindhoek van een taart- of boogvorm | `setAngleValue` |

`getType` en `getName` retourneren alleen‑lezen informatie. `getRawValue` en `setRawValue` werken met een geheel getal in de native geometrie‑eenheden van de preset, terwijl `getAngleValue` en `setAngleValue` werken met een hoek in graden. Het aantal, de volgorde, de betekenis en het geldige bereik van aanpassingen hangen af van de preset‑[GeometryShape::getShapeType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/geometryshape/#getShapeType). Een waarde die geldig is voor de ene preset kan ongeldige of een ander effect hebben voor een andere.

Wanneer `getType` `ShapeAdjustmentType::Custom` retourneert, herkent de API geen standaard semantische betekenis. Inspecteer `getName`, het preset‑type en de bestaande waarde, en laat de aanpassing ongewijzigd als de verwachte betekenis en het bereik niet bekend zijn. Zelfs voor herkende types, controleer of hetzelfde type meer dan eens voorkomt voordat je een waarde selecteert. Het artikel over [Connector](/slides/nl/php-java/connector/) toont deze situatie met boogaanpassingen van connectoren.

Het volgende volledige voorbeeld maakt standaard- en aangepaste versies van drie vooraf ingestelde vormen. Het loopt door elke aanpassing, meldt de naam en het type, wijzigt waarden gerelateerd aan grootte via `setRawValue`, wijzigt hoeken via `setAngleValue`, en slaat het resultaat op. De linkerkolom behoudt de standaardgeometrie; de rechterkolom toont de aangepaste afgeronde rechthoek, vierweg‑pijl en taart.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Voeg kolomkoppen toe voor de standaard- en aangepaste vormkolommen.
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het controleren van het semantische type vóór het wijzigen van een waarde maakt de code expliciet over de intentie en voorkomt aannames dat een bepaalde collectie‑index dezelfde betekenis heeft bij verschillende preset‑vormen.

## **Wijzig de Shape‑Collection**

De methoden voor toevoegen, klonen, verwijderen en herschikken werken direct op de collectie. Als een bewerking het aantal of de volgorde van vormen wijzigt, ga dan niet langer uit van indexen die vóór die bewerking zijn vastgelegd.

### **Kloon een vorm**

[ShapeCollection::addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addclone/) maakt een onafhankelijke kopie en voegt deze toe aan de doel‑collectie. [ShapeCollection::insertClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/insertclone/) maakt ook een kopie maar plaatst die op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen deze ook aanpassen.

Het voorbeeld maakt een doeldia, kloont een gelabelde rechthoek naar de voorgrond, en voegt een tweede kloon toe aan de achtergrond. Wijzigingen aan een van de klonen wijzigen de bronvorm niet.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Klonen kopieert de inhoud en opmaak van de vorm, inclusief naam en alternatieve tekst. Ken nieuwe logische identifiers toe aan de kloon wanneer die waarden uniek moeten zijn. Resources die door complexe vormen worden gebruikt, worden door de presentatie beheerd, maar een kloon blijft een nieuw collectie‑item met een nieuwe vorm‑identiteit.

### **Verwijder vormen**

[ShapeCollection::remove](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/remove/) verwijdert een specifiek vormobject uit de collectie. Wanneer je meerdere overeenkomsten verwijdert tijdens een geïndexeerde iteratie, loop dan van het einde naar voren zodat elke overgebleven index geldig blijft.

Dit voorbeeld verwijdert elke vorm met een opgegeven naam. Het leest de vorm op de huidige index, niet een vast collectie‑item, en cast de vorm niet onnodig.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Na verwijderen veranderen het aantal vormen en de indexen van de latere vormen. Referenties naar ongewijzigde vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook connectoren, animaties en andere presentatiefuncties in acht die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare vorm kan meer veranderen dan alleen het uiterlijk van de dia.

### **Verberg een vorm**

Instellen van [Shape::setHidden](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/sethidden/) op `true` behoudt de vorm in de collectie maar voorkomt dat deze verschijnt in de normale diavoorstelling. De index, opmaak en inhoud blijven beschikbaar voor code, dus verbergen is geschikt voor optionele elementen die later weer kunnen worden hersteld.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden gevonden en zichtbaar worden gemaakt door een gebruiker of door code, en het blijft onderdeel van het presentatie‑bestand.

### **Wijzig de Z‑order**

Overlapende vormen worden geschilderd in de volgorde van de collectie. [ShapeCollection::reorder](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/reorder/) verplaatst een bestaande vorm naar een doel‑index zonder deze te klonen. Index `0` is de achterkant; `size() - 1` is de voorkant.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De rechthoek wordt eerst aangemaakt en ligt aanvankelijk achter de ellips. Het verplaatsen naar de laatste index brengt hem naar voren. Finaliseer de z‑order na het toevoegen of klonen van alle gerelateerde vormen, want die bewerkingen voegen nieuwe collectie‑items toe of inserten ze, waardoor de beoogde stapel kan veranderen.

## **Inspecteer vormen op lay‑outdia's**

Normale dia's, lay‑outdia's en masterdia's hebben afzonderlijke vormcollecties. Een vorm in een lay‑outcollectie is niet hetzelfde object als een vergelijkbare vorm op een normale dia. Inspecteer lay‑outvormen wanneer je de opmaak die door een lay‑out wordt geleverd wilt begrijpen of wijzigen.

Het volgende voorbeeld leest elke lay‑outvorm's [FillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getfillformat/) en [LineFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getlineformat/) zonder aan te nemen dat elke vorm een `AutoShape` is.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Het bewerken van een lay‑out kan meerdere dia's die het gebruiken beïnvloeden. Controleer vóór het wijzigen van een lay‑outvorm of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die lay‑out gebruikt.

## **Exporteer een vorm naar SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/writeassvg/) schrijft de gerenderde inhoud van één vorm naar een stream. Het resultaat bevat de vorm, niet de volledige dia‑achtergrond of naburige vormen.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Houd de presentatie open tijdens het renderen. De output hangt af van de opmaak van de vorm en van resources zoals lettertypen en afbeeldingen. Als je de volledige compositie nodig hebt, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stream en moet deze sluiten.

## **Lijn vormen uit**

De overloads van [SlideUtil::alignShapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideutil/alignshapes/) aligneren ofwel alle vormen ofwel geselecteerde collectie‑indexen. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapesalignmenttype/) specificeert de rand, de middellijn of de verdelingsmodus. Stel `alignToSlide` in op `true` om de dia‑randen te gebruiken; stel het in op `false` om de geselecteerde vormen ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijnt drie vormen uit op de bovenrand van de dia. De geretourneerde vormreferenties worden direct vóór het uitlijnen omgezet naar hun huidige indexen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Uitlijning wijzigt posities, niet de z‑order. Relatieve uitlijning vereist normaliter ten minste twee vormen, terwijl horizontale of verticale distributie voldoende vormen nodig heeft om de afstand te bepalen. Herbereken indexen als je de collectie wijzigt vóór het aanroepen van de methode.

## **Spiegel een vorm**

De klasse [ShapeFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapeframe/) slaat positie, grootte, horizontale en verticale spiegelinstellingen en rotatie op. De waarden van `getFlipH` en `getFlipV` gebruiken [NullableBool](https://reference.aspose.com/slides/nl/php-java/aspose.slides/nullablebool/): `True` schakelt de spiegel in, `False` schakelt deze uit, en `NotDefined` behoudt de ongespecificeerde/standaardstatus.

De invoerpresentatie hieronder bevat één ongespiegelde vorm.

![The shape before flipping](shape_to_be_flipped.png)

Het voorbeeld behoudt elke andere frame‑waarde en vervangt alleen de twee spiegelinstellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Frame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/setframe/) het volledige frame vervangt.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De opgeslagen vorm wordt horizontaal en verticaal gespiegeld terwijl positie, grootte en rotatie behouden blijven.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vorm‑identifier?**

Alleen voor kortlevende verwerking wanneer de collectie niet verandert vóórdat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor door auteurs gemaakte sjablonen, of `OfficeInteropShapeId` voor op interop‑basis werk binnen de dia‑scope.

**Verwijdert verbergen van een vorm deze uit de z‑order?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Hij kan worden gevonden, herschikt, bewerkt of weer zichtbaar gemaakt.

**Waarom verscheen een gekloonde vorm voor een andere vorm?**

`addClone` voegt de kloon toe aan het einde van de collectie, wat de voorkant van de z‑order is. Gebruik `insertClone` om een initiële index te kiezen of `reorder` nadat alle vormen zijn toegevoegd.

**Kan ik een vaste index gebruiken om een preset‑vormaanpassing te identificeren?**

Alleen na validatie van de exacte preset en de collectie‑indeling. Geef de voorkeur aan itereren door `GeometryShape::getAdjustments` en het controleren van `AdjustValue::getType`; gebruik `AdjustValue::getName` als extra informatie wanneer hetzelfde semantische type meer dan één keer voorkomt.