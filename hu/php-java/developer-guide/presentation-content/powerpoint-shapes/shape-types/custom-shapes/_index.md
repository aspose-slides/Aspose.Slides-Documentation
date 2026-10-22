---
title: PHP-ban a prezentáció alakzatainak testreszabása
linktitle: Egyedi alakzat
type: docs
weight: 20
url: /hu/php-java/custom-shape/
keywords:
- egyedi alakzat
- alakzat hozzáadása
- alakzat létrehozása
- alakzat módosítása
- alakzat geometria
- geometriai útvonal
- útvonal pontok
- szerkesztési pontok
- pont hozzáadása
- pont eltávolítása
- szerkesztési művelet
- görbe sarok
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Alakzatok létrehozása és testreszabása PowerPoint-prezentációkban az Aspose.Slides for PHP Java-on keresztül: geometriai útvonalak, görbe sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a prezentáció alakzatokat az Aspose.Slides-ban a alakzat geometriájának szerkesztésével a szerkesztési pontok és geometriai útvonalak segítségével.  
Megmutatja, hogyan lehet a [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) használatával módosítani a meglévő alakzatokat, alapvető útvonal‑szerkesztési műveleteket végrehajtani, pontokat hozzáadni vagy eltávolítani, és az frissített geometriát visszaalkalmazni egy alakzatra.  

Emellett bemutatja a saját és összetett alakzatok létrehozását, a görbe sarkokkal rendelkező alakzatok építését, annak meghatározását, hogy egy alakzat geometriája zárt‑e, az alakzatelemek vizsgálatát, valamint a Java AWT szövegvonalak átalakítását geometriai útvonalakká.

## **Alakzat módosítása szerkesztési pontokkal**

PowerPoint‑ban a **Edit Points** segítségével módosíthat egy négyzetet:

* Egy sarkot beljebb vagy kifelé mozdíthat.  
* Egy pontnál a görbületet állíthatja.  
* Új pontokat adhat hozzá.  

A szerkesztési pontok lehetővé teszik az alakzat körvonalának módosítását, vagy egy meglévő alakzat alapként való felhasználását egy újnál.

## **Alakzat szerkesztési tippek**

![overview_image](custom_shape_0.png)

PowerPoint‑alakzatok szerkesztésekor tartsa szem előtt a következő fogalmakat:

* Egy alakzat (vagy annak útvonala) lehet zárt vagy nyílt.  
* Az alakzat útvonala horgonypontokból áll, amelyeket szegmensek kapcsolnak össze.  
* Egy szegmens lehet egyenes vagy íves. A horgonypontok és a vezérlő fogantyúk határozzák annak formáját.  
* A horgonypontok létezhetnek sarokpontként, egyenes pontként vagy sima pontként:  
  * Sarokpontnál a szomszédos szegmensek szöget zárhatnak be.  
  * Sima pontnál a két vezérlő fogantyú egy vonalban van és egyenlő távolságra a horgonyponttól.  
  * Egyenes pontnál a két vezérlő fogantyú egy vonalban van, de különböző távolságra lehet a horgonyponttól.  
* A horgonypontok mozgatása vagy a fogantyúk állítása megváltoztatja az alakzat körvonalát.

PowerPoint‑alakzatok szerkesztéséhez a szerkesztési pontok segítségével, a **Aspose.Slides** a [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) osztályt biztosítja.

* A [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) példány a [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) objektum geometriai útvonalát képviseli.  
* A [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) lekéréséhez a [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) példányból a [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) metódust használhatja.  
* A [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) egy alakzathoz való beállításához a következő metódusokat használhatja: a [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) egyszerű útvonalú alakzatokhoz és a [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) több útvonalú alakzatokhoz.  
* Szegmensek hozzáadásához a [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) alatti metódusokat használhatja.  
* A [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) és a [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) metódusokkal beállíthatja egy geometriai útvonal megjelenését.  
* A [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) metódussal lekérheti egy [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) geometriai útvonalát útvonal‑szegmensek tömbjeként.  
* További alakzatgeometria‑testreszabási lehetőségekhez a [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) objektumot a saját [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)‑én keresztül olvashatja, majd a szegmenseket egy [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)‑ra reprodukálhatja.

## **Egyszerű szerkesztési műveletek**

Az alábbi metódusokkal szerkesztheti a geometriai útvonalat. Az indexet elfogadó túlterhelések egy szegmenset szúrnak be a nullától számított pozícióba a szegmens‑tömbben.

| Művelet | Metódus |
| --- | --- |
| Egyenes vonal hozzáadása vagy beszúrása. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Köbös Bézier‑görbe (két vezérlőponttal és egy végponttal) hozzáadása vagy beszúrása. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Másodfokú Bézier‑görbe (egy vezérlőponttal és egy végponttal) hozzáadása vagy beszúrása. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Elliptikus ív hozzáadása a megadott méretekkel és fokban megadott szögekkel. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Az aktuális alakzat lezárása a végpont és a kezdőpont összekapcsolásával. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Az alakzat kezdőpontjának beállítása. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Szegmens eltávolítása a nulla‑bázisú indexen. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Egyéni pontok hozzáadása egy alakzathoz**

Ez a példa két pontot szúr be egy téglalap alakzatba a [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) használatával, majd a szerkesztett útvonalat a [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) alkalmazza. A koordináták az alakzathoz helyi értékek: mindkét új pont a közepénél van, 100 pont balról és 50 pont felülről. Az 1‑es és 4‑es szegmens‑indexek a felső és alsó élre helyezik őket, ezáltal azok befelé húzódnak.

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

## **Pontok eltávolítása egy alakzatból**

Ez a példa egy szív alakú körvonalat módosít a [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) segítségével a nullától számított 2‑es indexen lévő szegmens eltávolításával. A módosított útvonal alkalmazása a [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) metódussal frissíti az alakzat kontúrját.

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

## **Egyéni alakzat létrehozása**

Ez a példa egy ötágú csillagot épít a [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) segítségével. Az 100‑es és 50‑es pontokkal váltakozó külső‑ és belső‑sugár meghatározza a csúcsokat és a benyomulásokat; a 72 fokos lépés egyenletesen elosztja az öt csúcsot. Az útvonalat a [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) zárja le, majd a [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) alkalmazza egy téglalap alakzatra, felülírva annak körvonalát.

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

## **Összetett egyéni alakzat létrehozása**

Ez a példa két zárt [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) objektumot definiál az alakzat felső és alsó harmadjára. Mindkét útvonal a [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) használatával egyetlen összetett alakzatot hoz létre, amelynek középső harmadában egy rés van.

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

## **Egyéni alakzat létrehozása görbe sarkokkal**

Ez a példa egyenes szegmenseket kombinál a [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) használatával, hogy befelé görbített sarkú alakzatot kapjon. Minden sarokméret meghatározza az ív szélességét és magasságát pontban, a -90 fokos ív a balra forgó negyed ellipszist rajzolja. A kész útvonalat a [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) alkalmazza, majd a prezentációt PPTX formátumban menti.

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

## **Megállapítás, hogy az alakzat geometriája zárt‑e**

Az alábbi segédfüggvény ellenőrzi, hogy minden nem üres geometriai útvonal záró szegmenssel végződik‑e. A [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) beolvassa, és a végső szegmens [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) értékét összehasonlítja a [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/) típussal. Ha nincs nem üres útvonal, hamisat ad vissza. Ez a végső parancsot ellenőrzi minden útvonalnál; nem vizsgálja meg minden alalakzatot az útvonalon belül. A példa `true`‑t nyomtat egy téglalapra.

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

## **Alakzatelemek kinyerése és vizsgálata**

Használja a [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) metódust, hogy meglévő alakzatot elemekként vizsgáljon, amelyek tartalmazzák az útvonal pontokat és ponttípusokat. Minden visszaadott [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) segítségével lekérheti a pont‑ és típus‑tömböket a [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) és a [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) metódusokkal. Ez a reprezentáció hasznos a kontúr‑analízishez vagy a geometria egyedi rajzoló eszközökhöz való átadásához.

A példa megnyitja az input.pptx‑et, megtalálja az első geometriai alakzatot közvetlenül az első dián, és kiírja annak útvonal‑szegmenseit. Használjon egy olyan prezentációt, amelyben egy alakzat egyenes és íves szegmenseket is tartalmaz, hogy mindkét típusú kimenetet lássa. A csoportokon belül nem keres.

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
                $pointType = $types[$i] & 0x07; // Tartsa meg a szegmens típusát, a jelzők nélkül.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Consume both control points and the endpoint.
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

A tömbök index szerint egyeznek: `$points[$i]` egy pont, `$types[$i]` pedig annak szerepét írja le. A `0` típus új alakzatot nyit, az `1` típus az előző pontból a jelenlegi pontba vonalat rajzol. Egy köbös Bézier‑szegmens az előző végpontból indul, és három egymást követő `3` típusú elem használ: két vezérlőpontot, majd az új végpontot. A ciklus ezeket a három elemet egyszerre fogyasztja, és ellenőrzi, hogy a végpont zárta‑e az alakzatot.

A ponttípusok további jelzőket is tartalmaznak. `0x07`‑es maszkot használva azonosítható a szegmens típusa, `0x80`‑as teszttel pedig meghatározható, hogy egy alútvonal zárt‑e. Például a `129` (`0x81`) egy vonal‑végpont, amely alútvonalat zár, a `131` (`0x83`) egy Bézier‑végpont, amely szintén zár. A PHP/Java Bridge a bájt‑tömböt bináris sztringként adja vissza; a `"C*"`‑el történő kicsomagolás unsigned bájt‑értékeket ad. A maszk alkalmazása megőrzi a kívánt bitértékeket. Ha csak a nyers értéket (`1` vagy `3`) hasonlítaná, ezek a esetek kimaradnának. A dash (`0x10`) és marker (`0x20`) jelzők nem változtatják az alapszegmens‑típust.

**Koordináták és transzformációk.** A pontok pontban vannak mérve (1/72 hüvelyk), az X jobbra, a Y lefelé növekszik. Egy csoporton kívüli alakzatra a kinyert koordináták már tartalmazzák a [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) és [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) által visszaadott helyzetet, valamint a jelenlegi szélességet és magasságot. Például egy 120 × 80-as méretű, nem elforgatott téglalap a `(100, 200)`‑as bal‑felső sarokban `(100, 200)`‑tól `(220, 280)`‑ig határozza meg a kontúrhatárokat. Ne adja hozzá újra az alakzat helyzetét. Vonja ki az X és Y értékét a koordináták helyi, elforgatás nélküli keretéhez.

A kinyert pontok nem alkalmazzák az alakzat [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) által visszaadott forgását, illetve a vízszintes és függőleges tükrözést. A megjelenített kontúr reprodukálásához ezeket a transzformációkat az alakzat középpontja körül kell alkalmazni. Csoportos alakzatok esetén vegye figyelembe a csoportkoordináta‑leképezést és a transzformációkat; ne feltételezze, hogy a kinyert pontok már a végső diára vetített koordináták, és ne alkalmazzon kétszeres eltolást vagy méretezést, ha az már szerepel a gyermek keretében.

**Vizsgálat vs. szerkesztés.** A kinyert tömbök a kontúrt leírják; módosításuk nem frissíti az eredeti alakzatot. Ezt a megközelítést akkor válassza, ha a pont‑/típus‑tömbökre szüksége van elemzési vagy rajzoló kódban. Használja a [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) metódust, ha a geometriai parancsokra van szüksége az alakzat helyi koordináta‑rendszerében, vagy ha a geometriát szerkeszteni szeretné. A szerkesztett útvonalak alkalmazásához a [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) vagy a [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) metódusokat használja.

## **Java AWT Shape átalakítása GeometryPath‑vé**

Ez a példa egy téglalap körvonalát kombinálja a geometriává konvertált szöveggel. A körvonal [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) metódusa letiltja a kitöltést. Egy [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) hozza létre a szöveg körvonalát egy [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) segítségével. A [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) mozgás, egyenes, másod‑ és harmad‑rendű, valamint záró szegmenseket ad, amelyeket a példa egy [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)‑ra játszik le.

A példa egy Java float tömböt használ, hogy a PHP/Java Bridge megőrizze az iterátor által írt koordinátákat. A szöveg 40‑pont Arial betűtípussal jelenik meg. A körvonal 20 ponttal vízszintesen el van tolva, és a vizuális teteje 10 ponttal az alakzat felső szélétől van lejjebb. A szöveg útvonal kitöltött, míg az eredeti téglalap csak körvonal marad. Mindkét útvonal a [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) használatával kerül alkalmazásra, egyetlen alakzatot hozva létre, amely a téglalapot és a szöveget egyaránt tartalmazza.

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

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal a geometria cseréje után?**  
A stílus az alakzaton marad; csak a körvonal változik. A kitöltés és a körvonal automatikusan az új geometriára kerül alkalmazásra.

**Hogyan forgathatom helyesen egy egyéni alakzatot a geometriájával együtt?**  
Használja az alakzat [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) metódusát; a geometria az alakzattal együtt forog, mivel az az alakzat saját koordináta‑rendszeréhez van kötve.

**Átalakíthatom-e egy egyéni alakzatot képpé a végeredmény „lezárásához”?**  
Igen. Exportálja a szükséges [slide](/slides/hu/php-java/convert-powerpoint-to-png/) területet vagy a [shape](/slides/hu/php-java/create-shape-thumbnails/) képet raszteres formátumba; ez megkönnyíti a további munkát a komplex geometriákkal.