---
title: "Egyéni prezentációs alakzatok testreszabása PHP-ben"
linktitle: "Egyéni alakzat"
type: docs
weight: 20
url: /hu/php-java/custom-shape/
keywords:
- "egyéni alakzat"
- "alakzat hozzáadása"
- "alakzat létrehozása"
- "alakzat módosítása"
- "alakzat geometria"
- "geometriai útvonal"
- "útvonal pontok"
- "szerkesztési pontok"
- "pont hozzáadása"
- "pont eltávolítása"
- "szerkesztési művelet"
- "ívelt sarok"
- "PowerPoint"
- "prezentáció"
- "PHP"
- "Aspose.Slides"
description: "Alakzatok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for PHP Java-n keresztül: geometriai útvonalak, ívelt sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a prezentáció alakzatait az Aspose.Slides‑ben a forma geometria szerkesztésével szerkesztési pontok és geometriai útvonalak segítségével. Megmutatja, hogyan dolgozzunk a [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) használatával meglévő alakzatok módosításához, alapvető útvonal‑szerkesztési műveletekhez, pontok hozzáadásához vagy eltávolításához, és a frissített geometria egy alakzatra való alkalmazásához.

Továbbá bemutatja, hogyan hozhatunk létre egyedi és összetett alakzatokat, ívelt sarkokkal rendelkező formákat, hogyan határozhatjuk meg, hogy egy forma geometria zárt‑e, hogyan vizsgálhatjuk meg az alakzatelemeket, és hogyan konvertálhatjuk a Java AWT szövegvonalakat geometriai útvonalakká.

## **Alakzat módosítása szerkesztési pontokkal**

* Egy sarkot befelé vagy kifelé mozgat.
* A pont görbületét állítani.
* Új pontok hozzáadása.

A szerkesztési pontok használata lehetővé teszi egy forma körvonalának módosítását, vagy egy meglévő alakzat alapul vételét egy újhoz.

## **Alakzat‑szerkesztési tippek**

![áttekintés_kép](custom_shape_0.png)

PowerPoint‑alkalmazásban történő alakzat‑szerkesztéskor vegye figyelembe az alábbi fogalmakat:

* Egy alakzat (vagy annak útvonala) lehet zárt vagy nyitott.
* Az alakzat útvonala horgonypontokból áll, amelyeket szegmensek kötnek össze.
* Egy szegmens lehet egyenes vagy íves. A horgonypontok és a vezérlőfogantyúk határozzák meg alakját.
* A horgonypontok létezhetnek sarokpontként, egyenes pontként vagy sima pontként:
  * Sarokpontnál a szomszédos szegmensek szöget zárhatnak be.
  * Sima pontnál a két vezérlőfogantyú egy vonalban van és egyenlő távolságra helyezkedik el a horgonyponttól.
  * Egyenes pontnál a két vezérlőfogantyú egy vonalban van, de távolságuk a horgonyponttól eltérő lehet.
* A horgonypontok mozgatása vagy a fogantyúk beállítása megváltoztatja az alakzat körvonalát.

A PowerPoint‑alakzatok szerkesztéséhez szerkesztési pontokkal az **Aspose.Slides** a [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) osztályt biztosítja.

* A [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) példány a [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) objektum geometriai útvonalát képviseli.
* A [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) példányból a [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) lekérdezhető a [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) metódussal.
* Egy alakzat számára a [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) beállítható a [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) metódussal (egyetlen útvonal esetén) vagy a [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) metódussal (több útvonal esetén).
* Szegmensek hozzáadásához a [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) alatti metódusok használhatók.
* A [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) és a [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) metódusokkal beállítható egy geometriai útvonal megjelenése.
* A [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) metódussal a [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) geometriai útvonala szegmens‑tömbként olvasható ki.
* További alakzat‑geometria testreszabási lehetőségekhez egy [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) használatával olvasható be, és a szegmensek újra lejátszhatók egy [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)‑en.

## **Egyszerű szerkesztési műveletek**

Az alábbi metódusokkal szerkeszthető egy geometriai útvonal. A túlterhelések, amelyek indexet várnak, a szegmens tömbben a nullától számított pozícióba szúrják be a szegmenst.

| Művelet | Metódus |
| --- | --- |
| Egyenes vonal hozzáadása vagy beszúrása. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Kettő vezérlőponttal és egy végponttal rendelkező kúp‑Bézier görbe hozzáadása vagy beszúrása. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Egy vezérlőponttal és egy végponttal rendelkező kvadratikus Bézier görbe hozzáadása vagy beszúrása. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Elliptikus ív hozzáadása a megadott méretekkel és fokban megadott szögekkel. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Az aktuális alakzat lezárása az végpont és a kezdőpont összekötésével. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Egy alakzat kezdőpontjának beállítása. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Szegmens eltávolítása nullától számított index alapján. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Egyedi pontok hozzáadása egy alakzathoz**

Ez a példa két pontot szúr be egy téglalap alakzatba a [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) segítségével, majd a szerkesztett útvonalat a [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) metódussal alkalmazza. A koordináták az alakzathoz képest lokálisak: mindkét új pont a középpontban helyezkedik el, 100 pontbalra a bal szélről és 50 pontbalra a tetejétől. Az 1‑es és 4‑es szegmens‑indexek a pontokat a felső és alsó élre helyezik, ezáltal ezeket az éleket befelé húzva.

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

![példa1_kép](custom_shape_1.png)

## **Pontok eltávolítása egy alakzatból**

Ez a példa egy szív alakú körvonalat módosít azzal, hogy eltávolítja a 2‑es nullától számított indexű szegmenst a [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) segítségével. A módosított útvonal alkalmazása a [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) metódussal frissíti az alakzat kontúrját.

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
![példa2_kép](custom_shape_2.png)

## **Egyedi alakzat létrehozása**

Ez a példa egy ötszögű csillagot épít a [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) használatával. Az egymást váltó külső és belső sugár (100 és 50 pont) határozza meg a csúcsokat és a benyúlásokat; egy 72‑fokos lépés egyenletesen elosztja az öt csúcsot. Az útvonalat a [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) metódussal zárjuk le, majd a [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) segítségével egy téglalap alakzatra alkalmazzuk, lecserélve annak körvonalát.

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
![példa3_kép](custom_shape_3.png)

## **Kompozit egyedi alakzat létrehozása**

Ez a példa két zárt [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) objektumot definiál az alakzat felső és alsó harmadjára. Mindkét útvonal a [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) segítségével kerül alkalmazásra, így egyetlen kompozit alakzat jön létre, amelynek középső harmadja nyílásban van.

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
![példa4_kép](custom_shape_4.png)

## **Egyedi alakzat ívelt sarkokkal**

Ez a példa egyenes szegmenseket kombinál a [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) metódussal, hogy befelé ívelt sarkokkal rendelkező alakzatot hozzon létre. Minden sarokméret beállítja az ív szélességét és magasságát pontokban, a –90‑fokos ív egy óramutató járásával ellentétes negyed-ellipszist rajzol. A kész útvonalat a [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) metódussal alkalmazzuk, és a bemutatót PPTX formátumban mentjük.

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

## **Megállapítás, hogy egy alakzat geometria zárt-e**

Az alábbi segédfüggvény ellenőrzi, hogy minden nem üres geometriai útvonal záró szegmenssel végződik‑e. A [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) beolvassa az adatokat, és a végső szegmens [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) értékét összehasonlítja a [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/) értékkel. Üres útvonalak hiányában **false** értéket ad vissza. Ez a módszer csak a végső parancsot vizsgálja minden útvonalban; nem elemzi az egyes alalakzatokat. A példa egy téglalap esetén **true**‑t ír ki.

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

## **Geometriai útvonal parancsok vizsgálata**

Töltse le a [contour.pptx](contour.pptx) fájlt, és helyezze el az alkalmazás munkakönyvtárában. Az első dián az első alakzatnak egy egyenes felső él, egy kúp‑Bézier görbe és egy egyenes záró él van. A [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) segítségével olvashatók az alakzat útvonalai, a [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) pedig minden útvonal szegmenseit a rajzolási sorrendben adja vissza. Minden szegmenshez a [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) határozza meg a parancsot, és megmondja, hogyan kell értelmezni a [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData) által visszaadott értékeket.

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

Az alakzat a dián (200, 100) pontnál helyezkedik el. A jelentett koordináták az alakzathoz helyi koordináták, (0, 0) a bal‑felső sarok, az X jobbra, a Y lefelé nő. A záró szegmens a kezdőpontra tér vissza további koordináták nélkül.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint alakzat egy egyenes felső éllel, egy ívelt éllel a jobb felső saroktól a bal alsó sarokig, és egy egyenes bal éllel](contour.png)

## **Alakzatelemek kinyerése és vizsgálata**

Használja a [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) metódust egy meglévő alakzat elemeinek vizsgálatára, amelyek útvonal‑pontokat és pont‑típusokat tartalmaznak. Minden visszaadott [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) a [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) és a [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) metódusokkal adja vissza a pont‑ és típus‑tömböket. Ez a reprezentáció hasznos kontúr‑elemzéshez vagy egyedi rajzolóeszközöknek történő geometria átadásához.

A példa megnyitja az input.pptx‑et, megtalálja az első geometriai alakzatot közvetlenül az első dián, és kiírja annak szegmens‑adatait. Használjon egy olyan prezentációt, amely egyaránt tartalmaz egyenes és ívelt szegmensekkel rendelkező alakzatot, hogy mindkét kimenetet lássa. A csoportokban lévő alakzatokat nem keresi.

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
                $pointType = $types[$i] & 0x07; // Tartsa meg a szegmens típust, a flagokat kizárva.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Fogyasztja mindkét vezérlőpontot és a végpontot.
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

A tömbök index szerint párosulnak: `$points[$i]` egy pont, `$types[$i]` pedig annak szerepét írja le. A `0` típus új alakzatot indít, a `1` típus az előző ponttól a jelenlegi pontig egy vonalat rajzol. Egy kúp‑Bézier szegmens az előző végpontból indul, és három egymást követő `3` típusú bejegyzést használ: két vezérlőpontot, majd az új végpontot. A ciklus ezeket a három bejegyzést egyszerre fogyasztja, és ellenőrzi a végpontot a lezárás szempontjából.

A pont‑típusok flag‑eket is tartalmaznak. A `0x07` maszkkal azonosítható a szegmens típusa, a `0x80` flag önállóan a zárt alútvonalakat jelzi. Például a `129` (`0x81`) egy olyan vonal‑végpont, amely alútvonalat zár, a `131` (`0x83`) pedig egy Bézier‑végpont, amely szintén zár. A PHP/Java Bridge a bájt‑tömböt bináris karakterláncként adja vissza; a `"C*"` kicsomagolás unsigned bájt‑értékeket ad. A maszkolás megőrzi a tervezett bit‑értékeket. A nyers érték csak `1`‑re vagy `3`‑ra való összehasonlítása kihagyja ezeket az eseteket. Más flag‑ek, például a szaggatottság (`0x10`) és a marker (`0x20`), nem változtatják az alap szegmens típust.

**Koordináták és transzformációk.** A pontok pontban (1/72 hüvelyk) vannak mérve, az X jobbra, az Y lefelé nő. Egy nem csoportosított alakzat esetén a kinyert koordináták már tartalmazzák a [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) és [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) által visszaadott pozíciót, valamint a jelenlegi szélességet és magasságot. Például egy nem elforgatott téglalap `(100, 200)`‑on, `120 × 80` mérettel, `(100, 200)`‑`(220, 280)` kontúrbounds‑szel rendelkezik. Ne adja hozzá újra az alakzat pozícióját. Vonja ki az X‑et és Y‑t a nem elforgatott kerethez viszonyított koordináták meghatározásához.

A kinyert pontok nem veszik figyelembe az alakzat [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) által visszaadott forgását, illetve a vízszintes és függőleges tükrözéseket. A megjelenített kontúr reprodukálásához alkalmazza ezeket a transzformációkat az alakzat középpontja körül. Csoportos alakzatok esetén vegye figyelembe a csoport‑koordináta leképezést és a transzformációkat; ne tételezze, hogy a kinyert pontok a végleges dián megjelenő koordináták, és ne alkalmazzon kétszer fordítási vagy skálázási műveletet, ha már a gyermek keretben megjelennek.

**Vizsgálat vs. szerkesztés.** A kinyert tömbök a kontúrt írják le; módosításuk nem frissíti az eredeti alakzatot. Ezt a megközelítést válassza, ha elemzési vagy rajzoló kódja pont‑/típus‑tömböket igényel. Használja a [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) metódust, ha a geometriai parancsokra van szükség az alakzat helyi koordináta‑rendszerében, vagy ha a geometria szerkesztését tervezi. A szerkesztett útvonalak alkalmazásához a [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) vagy a [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) metódusok használhatók.

## **Java AWT alakzat átalakítása GeometryPath-re**

Ez a példa egy téglalap körvonalat kombinál a szöveghez konvertált geometriával. A körvonal [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) metódusa letiltja a kitöltést. Egy [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) hozza létre a szöveg körvonalát egy [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) objektumban. A [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) mozgás, vonal, kvadratikus, kúp‑Bézier és záró szegmenseket ad, amelyeket a példa újra lejátszik egy [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)‑en.

A példa egy Java float tömböt használ, hogy a PHP/Java Bridge megtartsa az iterátor által írt koordinátákat. A szöveg 40‑pontos Arial betűtípussal jelenik meg. A körvonal vízszintesen 20 ponttal van eltolva, a vizuális teteje pedig 10 ponttal a forma felső élétől helyezkedik el. A szöveg útvonala kitöltött, míg az eredeti téglalap csak körvonal marad. Mindkét útvonal [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) használatával egyetlen alakzatot hoz létre, amely a téglalapot és a szöveget tartalmazza.

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
![példa5_kép](custom_shape_5.png)

## **GYIK**

**Mi fog történni a kitöltéssel és körvonallal a geometria cseréje után?**

A stílus az alakzaton marad; csak a kontúr változik. A kitöltés és a körvonal automatikusan az új geometriára kerülnek alkalmazásra.

**Hogyan forgathatom helyesen egy egyedi alakzatot a geometriai adatokkal együtt?**

Használja az alakzat [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) metódusát; a geometria az alakzattal együtt forog, mivel az az alakzat saját koordináta‑rendszeréhez van kötve.

**Átalakíthatom‑e egy egyedi alakzatot képpé a végeredmény „lezárásához”?**

Igen. Exportálja a szükséges [dia](/slides/hu/php-java/convert-powerpoint-to-png/) területet vagy a [alakzat](/slides/hu/php-java/create-shape-thumbnails/) magát raszteres formátumba; ez megkönnyíti a bonyolult geometriákkal való további munkát.