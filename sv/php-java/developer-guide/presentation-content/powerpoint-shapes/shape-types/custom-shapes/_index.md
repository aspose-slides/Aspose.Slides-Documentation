---
title: Anpassa presentationsformer i PHP
linktitle: Anpassad form
type: docs
weight: 20
url: /sv/php-java/custom-shape/
keywords:
- anpassad form
- lägg till form
- skapa form
- ändra form
- formgeometri
- geometrisk bana
- banpunkter
- redigera punkter
- lägg till punkt
- ta bort punkt
- redigeringsåtgärd
- böjt hörn
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Skapa och anpassa former i PowerPoint-presentationer med Aspose.Slides för PHP via Java: geometriska banor, böjda hörn, sammansatta former."
---
## **Översikt**

Denna artikel förklarar hur du anpassar presentationsformer i Aspose.Slides genom att redigera formgeometri via redigeringspunkter och geometriska banor. Den visar hur du arbetar med [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) för att ändra befintliga former, utföra grundläggande banredigeringsåtgärder, lägga till eller ta bort punkter och applicera uppdaterad geometri tillbaka på en form.

Den demonstrerar också hur du skapar anpassade och sammansatta former, bygger former med böjda hörn, avgör om en formgeometri är sluten, inspekterar formelement och konverterar Java AWT‑textkonturer till geometriska banor.

## **Ändra en form med redigeringspunkter**

I PowerPoint kan du använda **Edit Points** för att ändra en fyrkant:

* Flytta ett hörn inåt eller utåt.
* Justera krökningen på en punkt.
* Lägg till nya punkter.

Att redigera punkter låter dig ändra en forms kontur eller använda en befintlig form som grund för en ny.

## **Tips för formredigering**

![overview_image](custom_shape_0.png)

När du redigerar PowerPoint‑former, håll dessa koncept i åtanke:

* En form (eller dess bana) kan antingen vara sluten eller öppen.
* En forms bana består av ankarnpunkter som är förbundna med segment.
* Ett segment kan vara rakt eller krökt. Ankarnpunkter och kontrollhandtag bestämmer dess form.
* Ankarnpunkter finns som hörnpunkter, raka punkter eller jämna punkter:
  * Vid en hörnpunkt kan intilliggande segment mötas i en vinkel.
  * Vid en jämn punkt är de två kontrollhandtagen i linje och lika långt från ankarnpunkten.
  * Vid en rak punkt är de två kontrollhandtagen i linje men kan ha olika avstånd från ankarnpunkten.
* Att flytta ankarnpunkter eller justera deras handtag ändrar formens kontur.

För att redigera PowerPoint‑former via redigeringspunkter tillhandahåller **Aspose.Slides** klassen [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* En [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)‑instans representerar en geometrisk bana för objektet [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* För att hämta [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) från en [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/)-instans kan du använda metoden [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* För att ange [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) för en form kan du använda dessa metoder: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) för former med en enda bana och [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) för former med flera banor.
* För att lägga till segment kan du använda metoderna under [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* Med metoderna [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) och [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) kan du ange utseendet för en geometrisk bana.
* Med metoden [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) kan du hämta geometrisk bana för en [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) som en array av bansegment.
* För att få ytterligare alternativ för anpassning av formgeometri kan du läsa en [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) via dess [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) och återspela segmenten på en [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Enkla redigeringsåtgärder**

Använd följande metoder för att redigera en geometrisk bana. Överlagringar som accepterar ett index sätter in ett segment på den nollbaserade positionen i banans segmentarray.

| Operation | Metod |
| --- | --- |
| Lägg till eller sätt in en rak linje. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Lägg till eller sätt in en kubisk Bézier‑kurva med två kontrollpunkter och en slutpunkt. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Lägg till eller sätt in en kvadratisk Bézier‑kurva med en kontrollpunkt och en slutpunkt. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Lägg till en elliptisk båge med angivna dimensioner och vinklar i grader. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Stäng den aktuella figuren genom att förena dess slutpunkt med startpunkten. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Ange startpunkten för en figur. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Ta bort ett segment på ett nollbaserat index. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Lägg till anpassade punkter i en form**

Detta exempel infogar två punkter i en rektangulär form med hjälp av [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) och applicerar den redigerade banan med [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). Koordinaterna är lokala för formen: båda nya punkterna ligger i dess centrum, 100 punkter från vänster och 50 punkter från toppen. Segmentindex 1 och 4 placerar dem på de övre respektive nedre kanterna och drar dessa kanter inåt.

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

## **Ta bort punkter från en form**

Detta exempel ändrar en hjärtformad kontur genom att ta bort segmentet på nollbaserat index 2 med [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Att applicera den modifierade banan med [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) uppdaterar formens kontur.

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

## **Skapa en anpassad form**

Detta exempel bygger en femuddig stjärna med [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Alternerande yttre och inre radier på 100 respektive 50 punkter definierar spetsarna och urgröparna; ett steg på 72 grader placerar de fem spetsarna jämnt. Banan stängs med [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) och appliceras på en rektangulär form med [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), vilket ersätter dess kontur.

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

## **Skapa en sammansatt anpassad form**

Detta exempel definierar två stängda [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)‑objekt för de övre och nedre tredjedelarna av en form. Att applicera båda banorna med [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) skapar en enda sammansatt form med ett tomrum över dess mellersta tredjedel.

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

## **Skapa en anpassad form med böjda hörn**

Detta exempel kombinerar raka segment med [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) för att skapa en form med inåtböjda hörn. Varje hörnstorlek anger bågens bredd och höjd i punkter, och -90‑gradssvepet ritar en moturs kvartsellips. Den färdiga banan appliceras med [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), och presentationen sparas i PPTX‑format.

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

## **Ta reda på om en formgeometri är sluten**

Följande hjälpfunktion kontrollerar om varje icke‑tom geometrisk bana avslutas med ett slutsegment. Den läser [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) och jämför det sista segmentets [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) med [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Den returnerar false när det inte finns några icke‑tomma banor. Detta kontrollerar det sista kommandot i varje bana; den inspekterar inte varje underfigur i en bana. Exemplet skriver ut `true` för en rektangel.

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

## **Inspektera geometriska bana‑kommandon**

Ladda ner [contour.pptx](contour.pptx) och placera den i applikationens arbetskatalog. Den första formen på den första bilden har en rak övre kant, en kubisk Bézier‑kurva och en rak avslutande kant. Använd [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) för att läsa formens banor och [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) för att läsa varje bans segment i ritordning. För varje segment identifierar [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) kommandot och avgör hur värdena som returneras av [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData) ska tolkas.

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

Formen ligger på (200, 100) punkter på bilden. De rapporterade koordinaterna är lokala för formen, med (0, 0) i dess övre‑vänstra hörn, x ökar åt höger och y ökar nedåt. Det avslutande segmentet återgår till startpunkten utan ytterligare koordinater.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Extrahera och inspektera formelement**

Använd [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) för att inspektera en befintlig form som element som innehåller bana‑punkter och punt‑typer. Använd varje returnerad [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) för att hämta punkt‑ och typ‑arrayerna via metoderna [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) och [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Denna representation är användbar för kontur‑analys eller för att skicka geometrin till anpassade ritverktyg.

Exemplet öppnar input.pptx, hittar den första geometriska formen direkt på den första bilden och skriver ut dess bansegment. Använd en presentation som innehåller en form med raka och krökta segment för att se båda typerna av utskrift. Det söker inte i grupper.

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
                $pointType = $types[$i] & 0x07; // Behåll segmenttypen, exkluderande flaggor.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Konsumera både kontrollpunkterna och slutpunkten.
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

Arrayerna korrelerar efter index: `$points[$i]` är en punkt och `$types[$i]` beskriver dess roll. Typ `0` startar en figur, och typ `1` ritar en linje från föregående punkt till den aktuella. Ett kubiskt Bézier‑segment startar vid föregående slutpunkt och använder tre på varandra följande typ‑`3`‑poster: två kontrollpunkter följt av den nya slutpunkten. Loopen konsumerar dessa tre poster tillsammans och kontrollerar slutpunkten för slutenhet.

Punkt‑typer innehåller även flaggor. Maskera med `0x07` för att identifiera segmenttypen, och testa `0x80` separat för att upptäcka en sluten underbana. Till exempel betyder `129` (`0x81`) en linjeslutpunkt som stänger en underbana, och `131` (`0x83`) en Bézier‑slutpunkt som stänger en. PHP/Java‑Bridge returnerar byte‑arrayen som en binär sträng; att packa upp den med `"C*"` ger unsigned byte‑värden. Maskering bevarar de avsedda bitvärdena. Att jämföra råvärdet enbart med `1` eller `3` skulle missa dessa fall. Andra flaggor, såsom streck (`0x10`) och markör (`0x20`), ändrar inte den grundläggande segmenttypen.

**Koordinater och transformationer.** Punkter mäts i punkter (1/72 tum), med X som ökar åt höger och Y som ökar nedåt. För en icke‑grupperad form innehåller de extraherade koordinaterna redan positionen som returneras av [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) och [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) samt reflekterar dess nuvarande bredd och höjd. Till exempel har en icke‑roterad rektangel på `(100, 200)` med storlek `120 × 80` konturboundaries `(100, 200)`–`(220, 280)`. Lägg inte till formens position igen. Subtrahera dess X och Y för att få koordinater relativt dess icke‑roterade ram.

De extraherade punkterna tar inte hänsyn till formens rotation, som returneras av [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation), eller horisontella och vertikala speglingar. För att reproducera den visade konturen, tillämpa dessa transformationer kring formens centrum. För grupperade former, ta även hänsyn till gruppens koordinatmappning och transformationer; anta inte att de extraherade punkterna är de slutgiltiga renderade bild‑koordinaterna eller att du ska applicera en förskjutning eller skala två gånger om den redan är reflekterad i barnets ram.

**Inspektion kontra redigering.** Extraherade arrayer beskriver konturen; att ändra dem uppdaterar inte den ursprungliga formen. Välj detta tillvägagångssätt när din analys‑ eller ritkod behöver punkt‑/typ‑arrayer. Använd [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) när du behöver geometriska kommandon i formens lokala koordinatsystem eller vill redigera dess geometri. Applicera redigerade banor via [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) eller [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Konvertera en Java AWT‑form till GeometryPath**

Detta exempel kombinerar en rektangulär kontur med text som konverterats till geometri. Konturens [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode)‑metod inaktiverar dess fyllning. En [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) skapar textkonturen i en [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Dess [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) levererar flytt‑, linje‑, kvadratisk‑, kubisk‑ och avslutningssegment, vilka exemplet återspelar på en [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

Exemplet använder en Java‑float‑array så att PHP/Java‑Bridge behåller koordinaterna som iteratorn skrev. Texten använder ett 40‑punkts Arial‑font. Konturen förskjuts 20 punkter horisontellt och placeras så att dess visuella topp är 10 punkter under formens övre kant. Textbanan fylls, medan den ursprungliga rektangeln förblir en kontur. Att applicera båda banorna med [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) skapar en enda form som innehåller både rektangeln och texten.

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

**Vad händer med fyllning och kontur efter att geometrin ersatts?**

Stilen förblir kopplad till formen; endast konturen förändras. Fyllning och kontur appliceras automatiskt på den nya geometrin.

**Hur roterar jag korrekt en anpassad form tillsammans med dess geometri?**

Använd formens [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation)‑metod; geometrin roteras med formen eftersom den är bunden till formens egna koordinatsystem.

**Kan jag konvertera en anpassad form till en bild för att “låsa” resultatet?**

Ja. Exportera det önskade [slide](/slides/sv/php-java/convert-powerpoint-to-png/)‑området eller själva [shape](/slides/sv/php-java/create-shape-thumbnails/) till ett rasterformat; detta förenklar vidare arbete med komplexa geometrier.