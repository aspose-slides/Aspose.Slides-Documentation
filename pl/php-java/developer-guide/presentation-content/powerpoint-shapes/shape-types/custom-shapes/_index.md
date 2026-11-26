---
title: Dostosuj kształty prezentacji w PHP
linktitle: Własny kształt
type: docs
weight: 20
url: /pl/php-java/custom-shape/
keywords:
- własny kształt
- dodaj kształt
- utwórz kształt
- zmień kształt
- geometria kształtu
- ścieżka geometryczna
- punkty ścieżki
- punkty edycji
- dodaj punkt
- usuń punkt
- operacja edycji
- zaokrąglony róg
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint za pomocą Aspose.Slides dla PHP przez Java: ścieżki geometryczne, zaokrąglone rogi, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty prezentacji w Aspose.Slides, edytując geometrię kształtu za pomocą punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/), aby zmodyfikować istniejące kształty, wykonać podstawowe operacje edycji ścieżki, dodać lub usunąć punkty oraz zastosować zaktualizowaną geometrię do kształtu.

Demonstruje również, jak tworzyć własne i złożone kształty, budować kształty z zaokrąglonymi rogami, określać, czy geometria kształtu jest zamknięta, przeglądać elementy kształtu oraz konwertować kontury tekstu Java AWT na ścieżki geometryczne.

## **Zmień kształt za pomocą punktów edycji**

W programie PowerPoint możesz używać **Edit Points**, aby modyfikować kwadrat:

* Przenieść róg do środka lub na zewnątrz.
* Dostosować krzywiznę w punkcie.
* Dodać nowe punkty.

Edycja punktów pozwala zmienić obrys kształtu lub użyć istniejącego kształtu jako podstawy nowego.

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Podczas edycji kształtów w PowerPoint pamiętaj o następujących pojęciach:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Ścieżka kształtu składa się z punktów kotwiczących połączonych odcinkami.
* Odcinek może być prosty lub krzywy. Punkty kotwiczące i uchwyty kontrolne określają jego kształt.
* Punkty kotwiczące występują jako punkty narożne, proste lub płynne:
  * W punkcie narożnym sąsiadujące odcinki mogą się łączyć pod kątem.
  * W punkcie płynnym dwa uchwyty kontrolne są wyrównane i znajdują się w równych odległościach od punktu kotwiczącego.
  * W punkcie prostym dwa uchwyty kontrolne są wyrównane, ale ich odległości od punktu kotwiczącego mogą się różnić.
* Przesuwanie punktów kotwiczących lub dostosowywanie ich uchwytów zmienia kontur kształtu.

Aby edytować kształty PowerPoint za pomocą punktów edycji, **Aspose.Slides** udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* Instancja [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* Aby pobrać [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) z instancji [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/), możesz użyć metody [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) dla kształtu, możesz użyć metod: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) dla kształtów z jedną ścieżką oraz [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) dla kształtów z wieloma ścieżkami.
* Aby dodać odcinki, możesz używać metod dostępnych w [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* Korzystając z metod [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) i [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode), możesz ustawić wygląd ścieżki geometrycznej.
* Metodą [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) możesz pobrać ścieżkę geometryczną [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) jako tablicę segmentów ścieżki.
* Aby uzyskać dodatkowe opcje dostosowywania geometrii kształtu, możesz odczytać [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) za pomocą jego [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) i odtworzyć segmenty na [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **Proste operacje edycji**

Użyj poniższych metod, aby edytować ścieżkę geometryczną. Przeciążenia przyjmujące indeks wstawiają odcinek w podanej pozycji zerowej w tablicy segmentów ścieżki.

| Operacja | Metoda |
| --- | --- |
| Dodaj lub wstaw prostą linię. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| Dodaj lub wstaw krzywą Béziera trzeciego stopnia z dwoma punktami kontrolnymi i punktem końcowym. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Dodaj lub wstaw krzywą Béziera kwadratowego stopnia z jednym punktem kontrolnym i punktem końcowym. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Dodaj łuk eliptyczny o podanych wymiarach i kątach w stopniach. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| Zamknij bieżącą figurę, łącząc jej punkt końcowy z punktem początkowym. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| Ustaw punkt początkowy figury. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| Usuń odcinek o indeksie zerowym. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **Dodaj własne punkty do kształtu**

Ten przykład wstawia dwa punkty do prostokątnego kształtu przy użyciu [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) i stosuje edytowaną ścieżkę za pomocą [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). Współrzędne są lokalne względem kształtu: oba nowe punkty znajdują się w jego centrum, 100 punktów od lewej i 50 punktów od góry. Indeksy segmentów 1 i 4 umieszczają je na górnej i dolnej krawędzi, ściągając te krawędzie do środka.

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

## **Usuń punkty z kształtu**

Ten przykład zmienia kontur serca, usuwając segment o indeksie zerowym 2 przy użyciu [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). Zastosowanie zmodyfikowanej ścieżki za pomocą [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) aktualizuje obrys kształtu.

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

## **Utwórz własny kształt**

Ten przykład buduje pięcioramienną gwiazdę przy użyciu [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). Alternujące promienie zewnętrzne i wewnętrzne o wartościach 100 i 50 punktów definiują wierzchołki i wcięcia; krok 72 stopni równomiernie rozmieszcza pięć wierzchołków. Ścieżka jest zamykana metodą [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) i stosowana do prostokątnego kształtu przy użyciu [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), zastępując jego obrys.

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

## **Utwórz złożony własny kształt**

Ten przykład definiuje dwa zamknięte obiekty [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) dla górnej i dolnej trzeciej części kształtu. Zastosowanie obu ścieżek metodą [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) tworzy jeden złożony kształt z przerwą w środkowej trzeciej części.

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

## **Utwórz własny kształt z zaokrąglonymi rogami**

Ten przykład łączy proste odcinki z metodą [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo), aby stworzyć kształt z wklęsłymi zaokrąglonymi rogami. Każdy rozmiar rogu określa szerokość i wysokość łuku w punktach, a kąt -90 stopni rysuje eliptyczny łuk w kierunku przeciwnym do ruchu wskazówek zegara. Gotowa ścieżka jest stosowana metodą [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath), a prezentacja jest zapisywana w formacie PPTX.

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

## **Sprawdź, czy geometria kształtu jest zamknięta**

Poniższy pomocnik sprawdza, czy każda niepusta ścieżka geometryczna kończy się segmentem zamykającym. Czyta [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) i porównuje końcowy segment metodą [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) z [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). Zwraca false, gdy nie ma niepustych ścieżek. To sprawdza jedynie ostatnie polecenie każdej ścieżki; nie analizuje wszystkich podfigur w obrębie ścieżki. Przykład wypisuje `true` dla prostokąta.

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

## **Przeglądaj polecenia ścieżki geometrycznej**

Pobierz plik [contour.pptx](contour.pptx) i umieść go w katalogu roboczym aplikacji. Pierwszy kształt na pierwszym slajdzie ma prostą górną krawędź, krzywą Béziera trzeciego stopnia oraz prostą zamykającą krawędź. Użyj [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths), aby odczytać ścieżki kształtu, oraz [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData), aby odczytać segmenty każdej ścieżki w kolejności rysowania. Dla każdego segmentu metoda [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) identyfikuje polecenie i określa, jak interpretować wartości zwracane przez [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData).

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

Kształt znajduje się w punkcie (200, 100) na slajdzie. Zgłoszone współrzędne są lokalne względem kształtu, przy (0, 0) w jego lewym górnym rogu, x rośnie w prawo, a y w dół. Segment zamykający powraca do punktu początkowego bez dodatkowych współrzędnych.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Wyodrębnij i przeglądaj elementy kształtu**

Użyj [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements), aby przeanalizować istniejący kształt jako elementy zawierające punkty ścieżki i typy punktów. Każdy zwrócony [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) pozwala pobrać tablice punktów i typów za pomocą metod [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) oraz [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). Ta reprezentacja jest przydatna do analizy konturu lub przekazywania geometrii do własnych narzędzi rysunkowych.

Przykład otwiera plik input.pptx, znajduje pierwszy kształt geometryczny bezpośrednio na pierwszym slajdzie i wypisuje jego segmenty ścieżki. Użyj prezentacji zawierającej kształt z segmentami prostymi i krzywymi, aby zobaczyć oba rodzaje wyjścia. Nie przeszukuje obiektów wewnątrz grup.

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
                $pointType = $types[$i] & 0x07; // Zachowaj typ segmentu, wyłączając flagi.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Pobierz oba punkty kontrolne i punkt końcowy.
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

Tablice są powiązane indeksami: `$points[$i]` to punkt, a `$types[$i]` opisuje jego rolę. Typ `0` rozpoczyna figurę, a typ `1` rysuje linię od poprzedniego punktu do bieżącego. Segment krzywej Béziera trzeciego stopnia zaczyna się od poprzedniego punktu końcowego i używa trzech kolejnych wpisów typu `3`: dwóch punktów kontrolnych i nowego punktu końcowego. Pętla konsoliduje te trzy wpisy i sprawdza punkt końcowy pod kątem zamknięcia.

Typy punktów zawierają także flagi. Maskuj przy pomocy `0x07`, aby określić typ segmentu, i testuj `0x80` osobno, aby wykryć zamkniętą podścieżkę. Przykładowo, `129` (`0x81`) oznacza punkt końcowy linii, który zamyka podścieżkę, a `131` (`0x83`) oznacza punkt końcowy Béziera, który zamyka podścieżkę. PHP/Java Bridge zwraca tablicę bajtów jako ciąg binarny; rozpakowanie jej przy pomocy `"C*"` daje wartości bajtów bez znaku. Maskowanie zachowuje zamierzone bity. Porównywanie surowej wartości jedynie z `1` lub `3` pominęłoby te przypadki. Inne flagi, takie jak kreska (`0x10`) i znacznik (`0x20`), nie zmieniają podstawowego typu segmentu.

**Współrzędne i przekształcenia.** Punkty są mierzone w punktach (1/72 cala), przy X rosnącym w prawo i Y rosnącym w dół. Dla kształtu niebędącego w grupie wyodrębnione współrzędne już zawierają pozycję zwróconą przez [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) i [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) oraz odzwierciedlają jego aktualną szerokość i wysokość. Na przykład, nieobrócony prostokąt w `(100, 200)` o rozmiarze `120 × 80` ma granice konturu `(100, 200)`–`(220, 280)`. Nie dodawaj pozycji kształtu ponownie. Odejmij jego X i Y, aby uzyskać współrzędne względem nieobróconej ramki.

Wyodrębnione punkty nie uwzględniają obrotu kształtu zwróconego przez [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) ani odbić poziomych i pionowych. Aby odtworzyć wyświetlany kontur, zastosuj te przekształcenia wokół środka kształtu. Dla kształtów grupowanych uwzględnij również mapowanie współrzędnych grupy i przekształcenia; nie zakładaj, że wyodrębnione punkty są ostatecznymi współrzędnymi slajdu ani nie stosuj podwójnego przesunięcia lub skalowania, jeśli już jest odzwierciedlone w ramce dziecka.

**Inspekcja vs. edycja.** Wyodrębnione tablice opisują kontur; ich modyfikacja nie aktualizuje oryginalnego kształtu. Wybierz to podejście, gdy Twoja analiza lub kod rysujący potrzebuje tablic punktów/typów. Użyj [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths), gdy potrzebujesz poleceń geometrii w lokalnym systemie współrzędnych kształtu lub chcesz edytować jego geometrię. Zastosuj edytowane ścieżki za pomocą [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) lub [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Konwertuj kształt Java AWT na GeometryPath**

Ten przykład łączy prostokątny obrys z tekstem skonwertowanym na geometrię. Metoda [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) obrysu wyłącza jego wypełnienie. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) tworzy kontur tekstu w obiekcie [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Jego [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) dostarcza ruchu, linii, kwadratowych, sześciennych i zamykających segmentów, które przykład odtwarza na [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

Przykład używa tablicy typu float w Javie, aby PHP/Java Bridge zachował współrzędne zapisane przez iterator. Tekst używa czcionki Arial 40 punktów. Obrys jest przesunięty o 20 punktów w poziomie i umieszczony tak, aby jego wizualna górna krawędź znajdowała się 10 punktów poniżej górnej krawędzi prostokąta. Ścieżka tekstowa jest wypełniona, podczas gdy oryginalny prostokąt pozostaje jedynie obrysem. Zastosowanie obu ścieżek metodą [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) tworzy jeden kształt zawierający prostokąt i tekst.

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

**Co się stanie z wypełnieniem i obrysem po zastąpieniu geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się tylko kontur. Wypełnienie i obrys są automatycznie stosowane do nowej geometrii.

**Jak prawidłowo obrócić własny kształt wraz z jego geometrią?**

Użyj metody [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) kształtu; geometria obraca się wraz z kształtem, ponieważ jest powiązana z jego własnym układem współrzędnych.

**Czy mogę przekonwertować własny kształt na obraz, aby „zablokować” wynik?**

Tak. Wyeksportuj wymagany [slide](/slides/pl/php-java/convert-powerpoint-to-png/) lub sam [shape](/slides/pl/php-java/create-shape-thumbnails/) do formatu rastrowego; uprości to dalszą pracę z złożonymi geometriami.