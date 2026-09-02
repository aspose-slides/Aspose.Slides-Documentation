---
title: Beheer presentatievormen in PHP
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/php-java/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatievorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- volgorde van vorm wijzigen
- interop-vorm-ID ophalen
- alternatieve tekst van vorm
- vormlay-outformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u presentatievormen kunt identificeren, klonen, verwijderen, verbergen, opnieuw ordenen, exporteren, uitlijnen en spiegelen met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aspose.Slides for PHP via Java vertegenwoordigt de vormen op een dia als een geordende [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/). De collectie is zowel de plek waar u vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de meest achterliggende vorm, terwijl de laatste index de meest voorste vorm is.

Dit artikel volgt dat model. Het legt eerst uit hoe u een vorm betrouwbaar kunt identificeren, en toont vervolgens hoe u vormen kunt klonen, verwijderen, verbergen en opnieuw ordenen. De laatste secties behandelen op lay-outniveau opmaak, SVG-export, uitlijning en spiegelinstellingen. Elk voorbeeld staat op zichzelf, zodat u alleen de bewerkingen hoeft te gebruiken die uw workflow vereist.

## **Identificeer en vind vormen**

Collectie‑indexen zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identifiers. Het toevoegen, verwijderen of opnieuw ordenen van een vorm kan de index wijzigen. Kies een identifier op basis van hoe de presentatie is gemaakt en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getname/) is nuttig voor door ontwikkelaars beheerde sjablonen en is makkelijk te inspecteren in het selectiepaneel van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamconventie op als uw code ervan afhangt.
- [AlternativeText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getalternativetext/) is bruikbaar wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik betekenisvolle toegankelijkheidstekst niet stilzwijgend als sleutel in een database.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getofficeinteropshapeid/) is een alleen‑lezen identifier die uniek is binnen een dia en overeenkomt met de shape‑ID die door PowerPoint‑interop wordt gebruikt. Gebruik deze wanneer u integreert met PowerPoint of wanneer u een ondubbelzinnige referentie nodig heeft gedurende de levensduur van een vorm. Een gekloonde of opnieuw aangemaakte vorm is een andere vorm en krijgt een eigen ID.

De gerelateerde methode [Shape::getUniqueId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getuniqueid/) retourneert een identifier met presentatiescope, maar die identifier is bedoeld voor add‑ins en kan opnieuw worden toegewezen. Beschouw het niet als een permanente externe sleutel. Als langdurige identiteit essentieel is, bewaar dan de mapping in applicatiegegevens en valideer dat de verwachte vorm nog bestaat.

Het volgende voorbeeld zoekt op naam met een exacte vergelijking en rapporteert de interop‑ID die binnen de dia geldt. Wanneer de sjabloon de verwachte vorm niet bevat, geeft de code dat resultaat weer in plaats van door te gaan met het verkeerde object.

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

Wanneer een bewerking specifiek is voor een vormtype, controleer dan de runtime‑klasse voordat u type‑specifieke leden gebruikt. Dit voorbeeld werkt de tekst en alternatieve tekst alleen bij als het benoemde object een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) is.

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

## **Wijzig de vormcollectie**

De methoden voor toevoegen, klonen, verwijderen en opnieuw ordenen werken direct op de collectie. Als een bewerking het aantal of de volgorde van vormen wijzigt, mag u niet blijven vertrouwen op indexen die vóór die bewerking zijn vastgelegd.

### **Kloon een vorm**

[ShapeCollection::addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addclone/) maakt een onafhankelijk exemplaar en voegt het toe aan de doelcollectie. [ShapeCollection::insertClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/insertclone/) maakt ook een kopie, maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen deze tevens aanpassen.

Het voorbeeld maakt een bestemmingsdia, kloont een gelabelde rechthoek naar de voorkant, en voegt een tweede kloon toe aan de achterkant. Wijzigingen aan een van de klonen wijzigen de bronvorm niet.

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

Klonen kopieert de inhoud en opmaak van de vorm, inclusief de naam en alternatieve tekst. Ken nieuwe logische identifiers toe aan de kloon wanneer die waarden uniek moeten zijn. Resources die door complexe vormen worden gebruikt, worden door de presentatie afgehandeld, maar een kloon blijft een nieuw verzamelingsitem met een nieuwe vormidentiteit.

### **Verwijder vormen**

[ShapeCollection::remove](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/remove/) verwijdert een specifiek vormobject uit zijn collectie. Wanneer u meerdere overeenkomsten verwijdert tijdens een geïndexeerde iteratie, doorloop dan vanaf het einde zodat elke resterende index geldig blijft.

Dit voorbeeld verwijdert elke vorm met een aangewezen naam. Het leest de vorm op de huidige index, niet een vast item in de collectie, en cast de vorm niet onnodig.

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

Na het verwijderen veranderen het aantal vormen en de indexen van latere vormen. Referenties naar ongewijzigde vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook rekening met connectoren, animaties en andere presentatiefuncties die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare vorm kan meer beïnvloeden dan alleen het uiterlijk van de dia.

### **Verberg een vorm**

Het instellen van [Shape::setHidden](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/sethidden/) op `true` houdt de vorm in de collectie, maar voorkomt dat deze verschijnt in de normale diavoorstelling. De index, opmaak en inhoud blijven beschikbaar voor code, dus verbergen is geschikt voor optionele elementen die later weer hersteld kunnen worden.

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

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden ontdekt en onzichtbaar gemaakt door een gebruiker of door code, en blijft onderdeel van het presentatie‑bestand.

### **Wijzig de Z‑volgorde**

Overlappende vormen worden geschilderd in de volgorde van de collectie. [ShapeCollection::reorder](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/reorder/) verplaatst een bestaande vorm naar een doel‑index zonder deze te klonen. Index `0` is de achterkant; `size() - 1` is de voorkant.

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

De rechthoek wordt eerst gemaakt en staat aanvankelijk achter de ellips. Verplaatsing naar de laatste index brengt deze naar de voorkant. Finaliseer de z‑order nadat u alle gerelateerde vormen hebt toegevoegd of gekloond, want die bewerkingen voegen nieuwe collectie‑items toe of plaatsen ze in, wat de beoogde stapel kan wijzigen.

## **Inspecteer vormen op lay‑outdia's**

Normale dia's, lay‑outdia's en master‑dia's hebben afzonderlijke vormcollecties. Een vorm in een lay‑outcollectie is niet hetzelfde object als een vergelijkbaar gepositioneerde vorm op een normale dia. Inspecteer lay‑outvormen wanneer u de opmaak die door een lay‑out wordt geleverd wilt begrijpen of wijzigen.

Het volgende voorbeeld leest voor elke lay‑outvorm de [FillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getfillformat/) en [LineFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getlineformat/) zonder aan te nemen dat elke vorm een `AutoShape` is.

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

Het bewerken van een lay‑out kan meerdere dia’s die deze gebruiken beïnvloeden. Voordat u een lay‑outvorm verandert, bepaal of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die lay‑out gebruikt.

## **Exporteer een vorm naar SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/writeassvg/) schrijft de gerenderde inhoud van één vorm naar een stream. Het resultaat bevat alleen de vorm, niet de volledige dia‑achtergrond of aangrenzende vormen.

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

Houd de presentatie open tijdens het renderen. De output hangt af van de opmaak van de vorm en van resources zoals lettertypen en afbeeldingen. Als u de hele compositie nodig hebt, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stream en moet deze sluiten.

## **Lijn vormen uit**

De [SlideUtil::alignShapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideutil/alignshapes/) overloads lijnen ofwel alle vormen uit of geselecteerde collectie‑indexen. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapesalignmenttype/) geeft de rand, het middellijn of de distributiemodus aan. Stel `alignToSlide` in op `true` om de dia‑randen te gebruiken; stel het in op `false` om de geselecteerde vormen relatief ten opzichte van elkaar uit te lijnen.

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

Uitlijning wijzigt posities, niet de z‑order. Relatieve uitlijning heeft normaal gezien ten minste twee vormen nodig, terwijl horizontale of verticale distributie voldoende vormen vereist om de afstand te bepalen. Herbereken indexen als u de collectie wijzigt vóór het aanroepen van de methode.

## **Spiegel een vorm**

De [ShapeFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapeframe/)‑klasse slaat positie, grootte, horizontale en verticale spiegelinstellingen en rotatie op. De waardes `getFlipH` en `getFlipV` gebruiken [NullableBool](https://reference.aspose.com/slides/nl/php-java/aspose.slides/nullablebool/): `True` schakelt het spiegelen in, `False` schakelt het uit, en `NotDefined` behoudt de ongespecificeerde/standaardstatus.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![De vorm vóór het spiegelen](shape_to_be_flipped.png)

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

![De vorm na het spiegelen](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vormidentifier?**

Alleen voor kortstondige verwerking wanneer de collectie niet zal veranderen voordat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor samengestelde sjablonen, of aan `OfficeInteropShapeId` voor interop‑werk binnen een dia.

**Verwijdert het verbergen van een vorm deze uit de z‑order?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Ze kan worden gevonden, opnieuw geordend, bewerkt of weer zichtbaar worden gemaakt.

**Waarom verscheen een gekloonde vorm voor een andere vorm?**

`addClone` voegt de kloon toe aan het einde van de collectie, wat de voorzijde van de z‑order is. Gebruik `insertClone` om de initiële index te kiezen of `reorder` nadat alle vormen zijn toegevoegd.