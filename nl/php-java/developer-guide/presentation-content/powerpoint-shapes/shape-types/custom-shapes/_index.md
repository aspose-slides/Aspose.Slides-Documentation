---
title: "Aangepaste presentatievormen in PHP"
linktitle: "Aangepaste vorm"
type: docs
weight: 20
url: /nl/php-java/custom-shape/
keywords:
- "aangepaste vorm"
- "vorm toevoegen"
- "vorm maken"
- "vorm wijzigen"
- "vormgeometrie"
- "geometriepad"
- "padpunten"
- "bewerkingspunten"
- "punt toevoegen"
- "punt verwijderen"
- "bewerkingsoperatie"
- "afgeronde hoek"
- "PowerPoint"
- "presentatie"
- "PHP"
- "Aspose.Slides"
description: "Maak en pas vormen aan in PowerPoint-presentaties met Aspose.Slides voor PHP via Java: geometriepaden, afgeronde hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatievormen in Aspose.Slides kunt aanpassen door de vormgeometrie te bewerken via bewerkingspunten en geometriepaden. Het laat zien hoe je werkt met [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) om bestaande vormen te wijzigen, basisbewerkingsbewerkingen uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie terug op een vorm toe te passen.

Het toont ook hoe je aangepaste en samengestelde vormen maakt, vormen bouwt met afgeronde hoeken, bepaalt of een vormgeometrie gesloten is, vormelementen inspecteert, en Java AWT-tekstcontouren omzet in geometriepaden.

## **Een Vorm Wijzigen met Bewerkingpunten**

In PowerPoint kun je **Bewerkingpunten** gebruiken om een vierkant te wijzigen:

* Een hoek naar binnen of buiten verplaatsen.
* De kromming op een punt aanpassen.
* Nieuwe punten toevoegen.

Bewerkingpunten laten je de omtrek van een vorm wijzigen of een bestaande vorm als basis voor een nieuwe gebruiken.

## **Tips voor Vormbewerking**

![overview_image](custom_shape_0.png)

Houd bij het bewerken van PowerPoint‑vormen de volgende concepten in gedachten:

* Een vorm (of het pad ervan) kan gesloten of open zijn.
* Het pad van een vorm bestaat uit ankerpunten die met segmenten verbonden zijn.
* Een segment kan recht of gebogen zijn. Ankerpunten en controlehandvatten bepalen de vorm ervan.
* Ankerpunten bestaan als hoekpunten, rechte punten of vloeiende punten:
  * Bij een hoekpunt kunnen aangrenzende segmenten onder een hoek samenkomen.
  * Bij een vloeiend punt zijn de twee controlehandvatten uitgelijnd en even ver van het ankerpunt verwijderd.
  * Bij een recht punt zijn de twee controlehandvatten uitgelijnd maar kunnen ze verschillende afstanden tot het ankerpunt hebben.
* Het verplaatsen van ankerpunten of het aanpassen van hun handvatten wijzigt de omtrek van de vorm.

Om PowerPoint‑vormen via bewerkingpunten te bewerken, biedt **Aspose.Slides** de klasse [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Een [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)‑instantie vertegenwoordigt een geometriepad van het object [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Om het [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) van de [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/)‑instantie op te halen, kun je de methode [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) gebruiken.
* Om het [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) voor een vorm in te stellen, kun je deze methoden gebruiken: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) voor vormen met één enkel pad en [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) voor vormen met meerdere paden.
* Om segmenten toe te voegen, kun je de methoden onder [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) gebruiken.
* Met behulp van de methoden [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) en [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) kun je het uiterlijk van een geometriepad instellen.
* Met de methode [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) kun je het geometriepad van een [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) ophalen als een array van padsegmenten.
* Voor extra aanpassingsopties van vormgeometrie kun je een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) uitlezen via zijn [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) en de segmenten opnieuw afspelen op een [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Eenvoudige Bewerkingstaken**

Gebruik de volgende methoden om een geometriepad te bewerken. Overloads die een index accepteren, voegen een segment in op die nul‑gebaseerde positie in de segmentarray van het pad.

| Operatie | Methode |
| --- | --- |
| Een rechte lijn toevoegen of invoegen. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Een kubische Bézier‑curve toevoegen of invoegen met twee controlepunten en een eindpunt. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Een kwadratische Bézier‑curve toevoegen of invoegen met één controlepunt en een eindpunt. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Een elliptische boog toevoegen met de opgegeven afmetingen en hoeken in graden. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| De huidige figuur sluiten door het eindpunt met het startpunt te verbinden. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Het startpunt van een figuur instellen. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Een segment op een nul‑gebaseerde index verwijderen. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Aangepaste Punten aan een Vorm Toevoegen**

Dit voorbeeld voegt twee punten in een rechthoekige vorm in met behulp van [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) en past het bewerkte pad toe met [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). De coördinaten zijn lokaal voor de vorm: beide nieuwe punten liggen in het midden, 100 punten van de linkerkant en 50 punten van de bovenkant. Segmentindices 1 en 4 plaatsen ze op respectievelijk de boven‑ en onderrand, waardoor die randen naar binnen worden getrokken.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![example1_image](custom_shape_1.png)

## **Punten uit een Vorm Verwijderen**

Dit voorbeeld wijzigt de omtrek van een hartvorm door het segment op nul‑gebaseerde index 2 te verwijderen met [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Het toepassen van het aangepaste pad met [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) werkt de contour van de vorm bij.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![example2_image](custom_shape_2.png)

## **Een Aangepaste Vorm Maken**

Dit voorbeeld bouwt een ster met vijf punten met behulp van [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Afwisselend buiten‑ en binnenstraal van respectievelijk 100 en 50 punten bepalen de punten en inkepingen; een stap van 72 graad verdeelt de vijf punten gelijkmatig. Het pad wordt gesloten met [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) en toegepast op een rechthoekige vorm via [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), waardoor de omtrek wordt vervangen.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![example3_image](custom_shape_3.png)

## **Een Samengestelde Aangepaste Vorm Maken**

Dit voorbeeld definieert twee gesloten [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)‑objecten voor respectievelijk het boven‑ en onderste derde deel van een vorm. Beide paden toepassen met [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) creëert één samengestelde vorm met een gat over het middelste derde deel.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![example4_image](custom_shape_4.png)

## **Een Aangepaste Vorm met Afgeronde Hoeken Maken**

Dit voorbeeld combineert rechte segmenten met [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) om een vorm met naar binnen gebogen hoeken te creëren. Elke hoekgrootte stelt de breedte en hoogte van de boog in punten in, en de -90‑graden sweep tekent een tegen de klok in kwart‑ellips. Het voltooide pad wordt toegepast met [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), en de presentatie wordt opgeslagen in PPTX‑formaat.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controleren of een Vormgeometrie Gesloten Is**

De volgende hulpfunctie controleert of elke niet‑lege geometriepad eindigt met een sluitsegment. Hij leest [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) en vergelijkt het laatste segment‑[PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) met [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Hij retourneert false wanneer er geen niet‑lege paden zijn. Deze controleert het laatste commando van elk pad; hij inspecteert niet elke subfiguur binnen een pad. Het voorbeeld print `true` voor een rechthoek.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Vormelementen Uittrekken en Inspecteren**

Gebruik [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) om een bestaande vorm te bekijken als elementen die padpunten en punt‑typen bevatten. Gebruik elk geretourneerd [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) om de punt‑ en type‑arrays op te halen via de methoden [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) en [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Deze representatie is nuttig voor contouranalyse of voor het doorgeven van geometrie aan aangepaste tekengereedschappen.

Het voorbeeld opent `input.pptx`, vindt de eerste geometrievorm direct op de eerste dia, en print de padsegmenten. Gebruik een presentatie met een vorm die rechte en gebogen segmenten bevat om beide soorten uitvoer te zien. Het zoekt niet binnen groepen.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // Behoud het segmenttype, exclusief vlaggen.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Verwerk zowel de controlepunten als het eindpunt.
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

De arrays corresponderen op index: `$points[$i]` is een punt en `$types[$i]` beschrijft zijn rol. Type `0` start een figuur, en type `1` tekent een lijn van het vorige punt naar het huidige punt. Een kubisch Bézier‑segment start bij het vorige eindpunt en gebruikt drie opeenvolgende type‑`3`‑items: twee controlepunten gevolgd door het nieuwe eindpunt. De lus consumeert deze drie items samen en controleert het eindpunt op sluiting.

Punt‑typen bevatten ook vlaggen. Maskeer met `0x07` om het segmenttype te identificeren, en test `0x80` apart om een gesloten subpad te detecteren. Bijvoorbeeld, `129` (`0x81`) betekent een lijneindpunt dat een subpad sluit, en `131` (`0x83`) betekent een Bézier‑eindpunt dat een subpad sluit. De PHP/Java‑Bridge geeft de byte‑array terug als een binaire string; uitpakken met `"C*"` levert ongetekende byte‑waarden. Maskeermethoden behouden de bedoelde bitwaarden. Het vergelijken van de ruwe waarde alleen met `1` of `3` zou deze gevallen missen. Andere vlaggen, zoals streep (`0x10`) en marker (`0x20`), veranderen het basissegmenttype niet.

**Coördinaten en transformaties.** Punten worden gemeten in punten (1/72 inch), met X toenemend naar rechts en Y toenemend naar beneden. Voor een niet‑gegroepeerde vorm bevatten de uitgepakte coördinaten al de positie die teruggegeven wordt door [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) en [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) en weerspiegelen ze de huidige breedte en hoogte. Bijvoorbeeld, een ongerotateerde rechthoek op `(100, 200)` met grootte `120 × 80` heeft contourgrenzen `(100, 200)`–`(220, 280)`. Voeg de positie van de vorm niet opnieuw toe. Trek X en Y af om coördinaten te verkrijgen relatief aan het ongerotateerde kader.

De uitgepakte punten houden geen rekening met de rotatie van de vorm, teruggegeven door [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), of horizontale en verticale spiegelingen. Om de weergegeven contour te reproduceren, pas je die transformaties toe rond het middelpunt van de vorm. Voor gegroepeerde vormen moet je ook rekening houden met de coördinatenmapping en transformaties van de groep; ga er niet van uit dat de uitgepakte punten de uiteindelijke weergegeven dia‑coördinaten zijn of dat je een translatie of schaal tweemaal toepast als die al in het kindkader is verwerkt.

**Inspectie versus bewerking.** Uitgepakte arrays beschrijven de contour; wijzigen ervan werkt de originele vorm niet bij. Kies deze aanpak wanneer je analyse‑ of tekencode punt‑/type‑arrays nodig heeft. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) wanneer je geometrie‑commando’s in het lokale coördinatensysteem van de vorm wilt of wanneer je de geometrie wilt bewerken. Pas bewerkte paden toe via [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) of [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Een Java AWT‑Vorm Omzetten naar GeometryPath**

Dit voorbeeld combineert een rechthoekige omtrek met tekst die naar geometrie wordt omgezet. De [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode)‑methode van de omtrek schakelt de vulling uit. Een [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) creëert de tekstcontour in een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Zijn [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) levert verplaatsings‑, lijn‑, kwadratische, kubische en sluitsegmenten, die het voorbeeld opnieuw afspeelt op een [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

Het voorbeeld gebruikt een Java‑float‑array zodat de PHP/Java‑Bridge de door de iterator geschreven coördinaten behoudt. De tekst gebruikt een Arial‑lettertype van 40 punten. De omtrek wordt horizontaal 20 punten verschoven en verticaal zo geplaatst dat de visuele bovenkant 10 punten onder de bovenrand van de vorm ligt. Het tekstpad wordt gevuld, terwijl de oorspronkelijke rechthoek een omtrek blijft. Beide paden toepassen met [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) levert één vorm op die de rechthoek en de tekst bevat.

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Wat gebeurt er met de vulling en omtrek na het vervangen van de geometrie?**

De stijl blijft bij de vorm; alleen de contour verandert. De vulling en omtrek worden automatisch toegepast op de nieuwe geometrie.

**Hoe roteer ik een aangepaste vorm correct samen met de geometrie?**

Gebruik de [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation)‑methode van de vorm; de geometrie roteert mee omdat deze gekoppeld is aan het eigen coördinatensysteem van de vorm.

**Kan ik een aangepaste vorm omzetten naar een afbeelding om het resultaat vast te leggen?**

Ja. Exporteer het gewenste [slide](/slides/nl/php-java/convert-powerpoint-to-png/)‑gebied of de [shape](/slides/nl/php-java/create-shape-thumbnails/) zelf naar een rasterformaat; dat maakt verder werk met complexe geometrieën eenvoudiger.