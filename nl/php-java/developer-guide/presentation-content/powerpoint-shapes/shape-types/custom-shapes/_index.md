---
title: Aangepaste presentatievormen in PHP
linktitle: Aangepaste vorm
type: docs
weight: 20
url: /nl/php-java/custom-shape/
keywords:
- aangepaste vorm
- vorm toevoegen
- vorm maken
- vorm wijzigen
- vormgeometrie
- geometriepad
- padpunten
- bewerkingspunten
- punt toevoegen
- punt verwijderen
- bewerkingsactie
- gebogen hoek
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Vormen maken en aanpassen in PowerPoint‑presentaties met Aspose.Slides voor PHP via Java: geometriepaden, gebogen hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatievormen in Aspose.Slides kunt aanpassen door de vormgeometrie te bewerken via bewerkingspunten en geometriepaden. Het laat zien hoe je met [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) bestaande vormen kunt wijzigen, basisbewerkingsbewerkingen kunt uitvoeren, punten kunt toevoegen of verwijderen, en de bijgewerkte geometrie terug op een vorm kunt toepassen.

Het demonstreert ook hoe je aangepaste en samengestelde vormen kunt maken, vormen met gebogen hoeken kunt bouwen, kunt bepalen of een vormgeometrie gesloten is, vormonderdelen kunt inspecteren, en Java AWT‑tekstcontouren kunt omzetten naar geometriepaden.

## **Vorm wijzigen met bewerkingspunten**

In PowerPoint kun je **Bewerkingspunten** gebruiken om een vierkant aan te passen:

* Een hoek naar binnen of naar buiten verplaatsen.
* De kromming op een punt aanpassen.
* Nieuwe punten toevoegen.

Met bewerkingspunten kun je de omtrek van een vorm aanpassen of een bestaande vorm als basis voor een nieuwe gebruiken.

## **Tips voor vormbewerking**

![overview_image](custom_shape_0.png)

Houd bij het bewerken van PowerPoint‑vormen de volgende concepten in gedachten:

* Een vorm (of het pad ervan) kan gesloten of open zijn.
* Het pad van een vorm bestaat uit ankerpunten die door segmenten met elkaar verbonden zijn.
* Een segment kan recht of gebogen zijn. Ankerpunten en controlehandvatten bepalen de vorm ervan.
* Ankerpunten kunnen hoekpunten, rechte punten of vloeiende punten zijn:
  * Bij een hoekpunt kunnen aangrenzende segmenten onder een hoek samenkomen.
  * Bij een vloeiend punt zijn de twee controlehandvatten op één lijn en even ver van het ankerpunt.
  * Bij een recht punt zijn de twee controlehandvatten op één lijn maar kunnen ze verschillende afstanden tot het ankerpunt hebben.
* Het verplaatsen van ankerpunten of het aanpassen van hun handvatten verandert de omtrek van de vorm.

Om PowerPoint‑vormen via bewerkingspunten te bewerken, biedt **Aspose.Slides** de klasse [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Een [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)‑instantie vertegenwoordigt een geometriepad van het object [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Om het [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) van een [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/)-instantie op te halen, kun je de methode [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) gebruiken.
* Om het [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) voor een vorm in te stellen, kun je deze methoden gebruiken: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) voor vormen met één enkel pad en [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) voor vormen met meerdere paden.
* Om segmenten toe te voegen, kun je de methoden onder [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) gebruiken.
* Met de methoden [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) en [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) kun je het uiterlijk van een geometriepad instellen.
* Met de methode [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) kun je het geometriepad van een [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) als een array van padsegmenten ophalen.
* Voor extra opties voor het aanpassen van vormgeometrie kun je een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) lezen via zijn [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) en de segmenten opnieuw afspelen op een [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Eenvoudige bewerkingsbewerkingen**

Gebruik de volgende methoden om een geometriepad te bewerken. Overload‑varianten die een index accepteren, voegen een segment in op die nul‑gebaseerde positie in de segmentarray van het pad.

| Operatie | Methode |
| --- | --- |
| Een rechte lijn toevoegen of invoegen. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Een kubiek Bézier‑curve met twee controlepunten en een eindpunt toevoegen of invoegen. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Een kwadratische Bézier‑curve met één controlepunt en een eindpunt toevoegen of invoegen. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Een elliptische boog toevoegen met de opgegeven afmetingen en hoeken in graden. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Het huidige figuur sluiten door het eindpunt met het startpunt te verbinden. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Het startpunt van een figuur instellen. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Een segment op een nul‑gebaseerde index verwijderen. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Aangepaste punten aan een vorm toevoegen**

Dit voorbeeld voegt twee punten toe aan een rechthoekige vorm met [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) en past het bewerkte pad toe met [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). De coördinaten zijn lokaal voor de vorm: beide nieuwe punten liggen in het midden, 100 punten vanaf de linkerkant en 50 punten vanaf de bovenkant. Segmentindices 1 en 4 plaatsen ze respectievelijk op de boven‑ en onderrand, waardoor die randen naar binnen worden getrokken.

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

## **Punten van een vorm verwijderen**

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

## **Aangepaste vorm maken**

Dit voorbeeld bouwt een vijfpuntige ster met [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Afwisselend buiten‑ en binnenstralen van 100 respectievelijk 50 punten definiëren de toppen en inkepingen; een stap van 72 graad verdeelt de vijf toppen gelijkmatig. Het pad wordt gesloten met [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) en toegepast op een rechthoekige vorm via [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), waarmee de bestaande omtrek wordt vervangen.

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

## **Samengestelde aangepaste vorm maken**

Dit voorbeeld definieert twee gesloten [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)‑objecten voor respectievelijk het boven‑ en het onderste derde deel van een vorm. Door beide paden toe te passen met [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) ontstaat één samengestelde vorm met een opening in het middelste derde deel.

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

## **Aangepaste vorm met gebogen hoeken maken**

Dit voorbeeld combineert rechte segmenten met [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) om een vorm met naar binnen gebogen hoeken te creëren. Elke hoekgrootte stelt de breedte en hoogte van de boog in punten in, en de sweep van –90 graad tekent een kwart‑ellips tegen de klok in. Het voltooide pad wordt toegepast met [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), en de presentatie wordt opgeslagen in PPTX‑formaat.

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

## **Controleren of een vormgeometrie gesloten is**

De volgende hulpfunctie controleert of elke niet‑lege geometriepad eindigt met een sluitsegment. Hij leest [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) en vergelijkt het laatste segment‑commando [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) met [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Hij retourneert *false* wanneer er geen niet‑lege paden bestaan. Deze controle kijkt naar het laatste commando van elk pad; hij inspecteert niet elke subfiguur binnen een pad. Het voorbeeld geeft `true` weer voor een rechthoek.

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

## **Inspectie van geometrie‑padcommando’s**

Download [contour.pptx](contour.pptx) en plaats het in de werkmap van de applicatie. De eerste vorm op de eerste dia heeft een rechte bovenrand, een kubieke Bézier‑curve en een rechte sluitrand. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) om de paden van de vorm te lezen en [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) om elk pad’s segmenten in tekenvolgorde te lezen. Voor elk segment identificeert [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) het commando en bepaalt hoe de waarden van [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData) geïnterpreteerd moeten worden.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;

$presentation = new Presentation("contour.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    foreach ($shape->getGeometryPaths() as $pathIndex => $path) {
        foreach ($path->getPathData() as $segmentIndex => $segment) {
            $command = java_values($segment->getPathCommand());
            $data = java_values($segment->getSegmentData());
            switch ($command) {
                case PathCommandType::MoveTo:
                case PathCommandType::LineTo:
                    $name = $command === PathCommandType::MoveTo ? "MoveTo" : "LineTo";
                    $detail = sprintf("destination=(%s, %s)", ...$data);
                    break;
                case PathCommandType::CubicBezierTo:
                    $name = "CubicBezierTo";
                    $detail = sprintf("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", ...$data);
                    break;
                case PathCommandType::Close:
                    $name = "Close";
                    $detail = "no coordinates";
                    break;
                default:
                    $name = "Command " . $command;
                    $detail = "raw=" . json_encode($data);
            }
            printf("Path %d, segment %d: %s %s\n", $pathIndex, $segmentIndex, $name, $detail);
        }
    }
} finally {
    $presentation->dispose();
}
```

De vorm staat op (200, 100) punten op de dia. De gerapporteerde coördinaten zijn lokaal voor de vorm, met (0, 0) in de linkerbovenhoek, x neemt toe naar rechts en y neemt toe naar beneden. Het sluitsegment keert terug naar het startpunt zonder extra coördinaten.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Geometrie‑elementen extraheren en inspecteren**

Gebruik [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) om een bestaande vorm te inspecteren als elementen die padpunten en punt‑typen bevatten. Gebruik elk geretourneerd [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) om de punt‑ en type‑arrays op te halen via de methoden [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) en [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Deze representatie is handig voor contouranalyse of om geometrie door te geven aan aangepaste tekengereedschappen.

Het voorbeeld opent *input.pptx*, vindt de eerste geometrische vorm direct op de eerste dia, en drukt de padsegmenten af. Gebruik een presentatie met een vorm die zowel rechte als gebogen segmenten bevat om beide soorten uitvoer te zien. Het doorzoekt niet binnen groepen.

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
                        $i += 2; // Verwerk beide controlepunten en het eindpunt.
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

De arrays corresponderen per index: `$points[$i]` is een punt en `$types[$i]` beschrijft de rol ervan. Type `0` start een figuur, en type `1` tekent een lijn van het vorige punt naar het huidige punt. Een kubiek Bézier‑segment start bij het vorige eindpunt en gebruikt drie opeenvolgende type‑`3`‑items: twee controlepunten gevolgd door het nieuwe eindpunt. De lus verwerkt deze drie items samen en controleert of het eindpunt de figuur sluit.

Punt‑typen bevatten ook vlaggen. Masker met `0x07` om het segmenttype te identificeren, en test `0x80` apart om een gesloten subpad te detecteren. Bijvoorbeeld, `129` (`0x81`) betekent een lijn‑eindpunt dat een subpad sluit, en `131` (`0x83`) betekent een Bézier‑eindpunt dat een subpad sluit. De PHP/Java‑Bridge retourneert de byte‑array als een binaire string; ontpakken met `"C*"` levert onondertekende byte‑waarden op. Maskeren behoudt de bedoelde bitwaarden. Alleen vergelijken met `1` of `3` zou deze gevallen missen. Andere vlaggen, zoals dash (`0x10`) en marker (`0x20`), wijzigen het basissegmenttype niet.

**Coördinaten en transformaties.** Punten worden gemeten in points (1/72 inch), waarbij X naar rechts toeneemt en Y naar beneden. Voor een niet‑gegroepeerde vorm omvatten de geëxtraheerde coördinaten al de positie die wordt geretourneerd door [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) en [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) en weerspiegelen ze de huidige breedte en hoogte. Bijvoorbeeld, een niet‑gedraaide rechthoek op `(100, 200)` met afmeting `120 × 80` heeft contourgrenzen `(100, 200)`–`(220, 280)`. Voeg de positie van de vorm niet opnieuw toe. Trek X en Y af om coördinaten te krijgen ten opzichte van het ongedraaide kader.

De geëxtraheerde punten houden geen rekening met de rotatie van de vorm, geretourneerd door [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), of horizontale en verticale spiegelingen. Om de weergegeven contour te reproduceren, moet je die transformaties toepassen rond het middelpunt van de vorm. Voor gegroepeerde vormen moet je bovendien rekening houden met de groeps‑coördinatenmapping en transformaties; ga er niet van uit dat de geëxtraheerde punten de definitieve weergave‑coördinaten zijn of dat je een translatie of schaal tweemaal moet toepassen als deze al in het kinder‑kader is opgenomen.

**Inspectie versus bewerking.** De geëxtraheerde arrays beschrijven de contour; ze wijzigen de oorspronkelijke vorm niet. Gebruik deze aanpak wanneer je analyse‑ of tekencode punt‑/type‑arrays nodig heeft. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) wanneer je geometrie‑commando’s in het lokale coördinatensysteem van de vorm wilt of de geometrie wilt bewerken. Pas bewerkte paden toe via [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) of [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Een Java AWT‑vorm omzetten naar GeometryPath**

Dit voorbeeld combineert een rechthoekige omtrek met tekst die is omgezet naar geometrie. De methode [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) van de omtrek schakelt de vulling uit. Een [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) genereert de tekstcontour in een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Zijn [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) levert verplaatsings‑, lijn‑, kwadratische, kubieke en sluitsegmenten, die het voorbeeld opnieuw afspeelt op een [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

Het voorbeeld gebruikt een Java‑float‑array zodat de PHP/Java‑Bridge de door de iterator geschreven coördinaten behoudt. De tekst gebruikt een Arial‑lettertype van 40 points. De omtrek wordt horizontaal 20 points verschoven en verticaal zo gepositioneerd dat de visuele bovenkant 10 points onder de bovenrand van de vorm ligt. Het tekstpad wordt gevuld, terwijl de oorspronkelijke rechthoek een omtrek blijft. Beide paden toepassen met [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) resulteert in één enkele vorm die de rechthoek en de tekst bevat.

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

**Wat gebeurt er met de vulling en de omtrek nadat de geometrie is vervangen?**

De stijl blijft gekoppeld aan de vorm; alleen de contour verandert. De vulling en omtrek worden automatisch op de nieuwe geometrie toegepast.

**Hoe roteer ik een aangepaste vorm correct samen met zijn geometrie?**

Gebruik de methode [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) van de vorm; de geometrie roteert mee omdat deze is gebonden aan het eigen coördinatensysteem van de vorm.

**Kan ik een aangepaste vorm converteren naar een afbeelding om het resultaat “vast te leggen”?**

Ja. Exporteer het benodigde [slide](/slides/nl/php-java/convert-powerpoint-to-png/) of de [shape](/slides/nl/php-java/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verder werken met complexe geometrieën.