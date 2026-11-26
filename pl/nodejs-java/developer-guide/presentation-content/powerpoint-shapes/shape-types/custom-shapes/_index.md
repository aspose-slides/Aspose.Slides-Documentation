---
title: Dostosowywanie kształtów prezentacji w JavaScript
linktitle: Własny kształt
type: docs
weight: 20
url: /pl/nodejs-java/custom-shape/
keywords:
- niestandardowy kształt
- dodaj kształt
- utwórz kształt
- zmień kształt
- geometria kształtu
- ścieżka geometryczna
- punkty ścieżki
- edytuj punkty
- dodaj punkt
- usuń punkt
- operacja edycji
- zaokrąglony róg
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu JavaScript i Aspose.Slides dla Node.js: ścieżki geometryczne, zaokrąglone rogi, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty prezentacji w Aspose.Slides, edytując geometrię kształtu za pomocą punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/), aby modyfikować istniejące kształty, wykonywać podstawowe operacje edycji ścieżek, dodawać lub usuwać punkty oraz zastosować zaktualizowaną geometrię do kształtu.

Demonstruje także, jak tworzyć własne i złożone kształty, budować kształty z zaokrąglonymi rogami, określać, czy geometria kształtu jest zamknięta, przeglądać elementy kształtu i konwertować kontury tekstu Java AWT na ścieżki geometryczne.

## **Zmienianie kształtu przy użyciu punktów edycji**

W programie PowerPoint możesz używać **Punktów edycji**, aby modyfikować kwadrat:

* Przesuwać róg do wewnątrz lub na zewnątrz.
* Dostosowywać krzywiznę w punkcie.
* Dodawać nowe punkty.

Edycja punktów pozwala zmienić obrys kształtu lub użyć istniejącego kształtu jako podstawy dla nowego.

## **Porady dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Podczas edycji kształtów w PowerPoint pamiętaj o następujących koncepcjach:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Ścieżka kształtu składa się z punktów kotwiczących połączonych odcinkami.
* Odcinek może być prosty lub krzywy. Kształt określają punkty kotwiczące i uchwyty kontrolne.
* Punkty kotwiczące występują jako punkty narożne, proste lub płynne:
  * W punkcie narożnym przylegające odcinki mogą spotykać się pod kątem.
  * W punkcie płynnym dwa uchwyty kontrolne są wyrównane i znajdują się w jednakowej odległości od punktu kotwiczącego.
  * W punkcie prostym dwa uchwyty kontrolne są wyrównane, ale mogą mieć różne odległości od punktu kotwiczącego.
* Przesuwanie punktów kotwiczących lub dostosowywanie ich uchwytów zmienia obrys kształtu.

Aby edytować kształty PowerPoint za pomocą punktów edycji, **Aspose.Slides** udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

* Instancja [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* Aby pobrać [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) z instancji [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/), możesz użyć metody [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths).
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) dla kształtu, możesz użyć metod: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) dla kształtów z jedną ścieżką oraz [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) dla kształtów z wieloma ścieżkami.
* Aby dodawać odcinki, możesz używać metod dostępnych w [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* Korzystając z metod [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) i [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode), możesz ustawić wygląd ścieżki geometrycznej.
* Za pomocą metody [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) możesz pobrać ścieżkę geometryczną [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) jako tablicę odcinków ścieżki.
* Aby uzyskać dodatkowe opcje dostosowywania geometrii kształtu, możesz odczytać [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) przy użyciu jego [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) i odtworzyć odcinki na [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Proste operacje edycji**

Użyj poniższych metod, aby edytować ścieżkę geometryczną. Przeciążenia przyjmujące indeks wstawiają odcinek w podanej, zerowej pozycji w tablicy odcinków ścieżki.

| Operacja | Metoda |
| --- | --- |
| Dodaj lub wstaw prostą linię. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Dodaj lub wstaw krzywą Béziera trzeciego stopnia z dwoma punktami kontrolnymi i punktem końcowym. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Dodaj lub wstaw krzywą Béziera drugiego stopnia z jednym punktem kontrolnym i punktem końcowym. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Dodaj eliptyczny łuk o podanych wymiarach i kątach w stopniach. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Zamknij bieżącą figurę, łącząc jej punkt końcowy z punktem początkowym. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Ustaw punkt początkowy figury. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Usuń odcinek o zerowym indeksie. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Dodawanie własnych punktów do kształtu**

Ten przykład wstawia dwa punkty do prostokątnego kształtu przy użyciu [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) i stosuje edytowaną ścieżkę metodą [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). Współrzędne są lokalne względem kształtu: oba nowe punkty znajdują się w jego środku, 100 punktów od lewej i 50 punktów od górnej krawędzi. Indeksy odcinków 1 i 4 umieszczają je na górnej i dolnej krawędzi, ciągnąc te krawędzie do wnętrza.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Usuwanie punktów z kształtu**

Ten przykład modyfikuje obrys serca, usuwając odcinek o zerowym indeksie 2 metodą [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). Zastosowanie zmodyfikowanej ścieżki metodą [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) aktualizuje kontur kształtu.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Tworzenie własnego kształtu**

Ten przykład buduje pięcioramienną gwiazdę przy użyciu [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Naprzemienne promienie zewnętrzne i wewnętrzne o wartościach 100 i 50 punktów definiują wierzchołki i wgniecenia; krok 72 stopnie rozmieszcza pięć wierzchołków równomiernie. Ścieżka jest zamykana metodą [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) i stosowana do prostokątnego kształtu metodą [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), zastępując jego obrys.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Tworzenie złożonego własnego kształtu**

Ten przykład definiuje dwie zamknięte ścieżki [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) dla górnej i dolnej trzeciej części kształtu. Zastosowanie obu ścieżek metodą [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) tworzy jeden złożony kształt z przerwą w środkowej trzeciej części.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Tworzenie własnego kształtu z zaokrąglonymi rogami**

Ten przykład łączy proste odcinki z [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo), aby utworzyć kształt z wklęsłymi, zaokrąglonymi rogami. Rozmiar każdego rogu określa szerokość i wysokość łuku w punktach, a kąt -90 stopni rysuje przeciwzegny ćwiartkowy elipsoid. Gotowa ścieżka jest stosowana metodą [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), a prezentacja zapisywana w formacie PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sprawdzenie, czy geometria kształtu jest zamknięta**

Poniższy pomocnik sprawdza, czy każda niepusta ścieżka geometryczna kończy się odcinkiem zamykającym. Odczytuje [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) i porównuje polecenie ostatniego odcinka [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) z [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Zwraca false, gdy nie ma niepustych ścieżek. Sprawdza ostatnie polecenie każdej ścieżki; nie przegląda wszystkich podfigur w ramach jednej ścieżki. Przykład wypisuje `true` dla prostokąta.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **Inspekcja poleceń ścieżki geometrycznej**

Pobierz plik [contour.pptx](contour.pptx) i umieść go w katalogu roboczym aplikacji. Pierwszy kształt na pierwszym slajdzie ma prostą górną krawędź, krzywą Béziera trzeciego stopnia i prostą krawędź zamykającą. Użyj [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths), aby odczytać ścieżki kształtu, oraz [getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData), aby odczytać odcinki każdej ścieżki w kolejności rysowania. Dla każdego odcinka [getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) identyfikuje polecenie i określa, jak interpretować wartości zwracane przez [getSegmentData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getSegmentData).

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("contour.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paths = shape.getGeometryPaths();
    for (const [i, path] of paths.entries()) {
        const segments = path.getPathData();
        for (const [j, segment] of segments.entries()) {
            const command = segment.getPathCommand();
            const data = segment.getSegmentData();
            let detail;
            switch (command) {
                case slides.PathCommandType.MoveTo:
                case slides.PathCommandType.LineTo:
                    const name = command === slides.PathCommandType.MoveTo ? "MoveTo" : "LineTo";
                    detail = `${name} destination=(${data[0]}, ${data[1]})`;
                    break;
                case slides.PathCommandType.CubicBezierTo:
                    detail = `CubicBezierTo control1=(${data[0]}, ${data[1]}) control2=(${data[2]}, ${data[3]}) end=(${data[4]}, ${data[5]})`;
                    break;
                case slides.PathCommandType.Close:
                    detail = "Close no coordinates";
                    break;
                default:
                    detail = `command=${command} raw=[${data.join(", ")}]`;
            }
            console.log(`Path ${i}, segment ${j}: ${detail}`);
        }
    }
} finally {
    presentation.dispose();
}
```

Kształt znajduje się w punkcie (200, 100) na slajdzie. Zgłoszone współrzędne są lokalne względem kształtu, przy (0, 0) w jego lewym górnym rogu, x rośnie w prawo, a y w dół. Odcinek zamykający powraca do punktu początkowego bez dodatkowych współrzędnych.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Ekstrakcja i inspekcja elementów kształtu**

Użyj [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements), aby przeanalizować istniejący kształt jako elementy zawierające punkty ścieżki i typy punktów. Każdy zwrócony [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) pozwala pobrać tablice punktów i typów za pomocą metod [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) i [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). Taka reprezentacja jest przydatna do analizy konturu lub przekazywania geometrii do własnych narzędzi rysunkowych.

Przykład otwiera plik input.pptx, znajduje pierwszą figurę geometryczną bezpośrednio na pierwszym slajdzie i wypisuje jej odcinki ścieżki. Użyj prezentacji zawierającej kształt z prostymi i krzywymi odcinkami, aby zobaczyć oba rodzaje wyjścia. Nie przeszukuje grup.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // Zachowaj typ odcinka, wyłączając flagi.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Zużyj oba punkty kontrolne oraz punkt końcowy.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Tablice są powiązane indeksami: `points[i]` to punkt, a `types[i]` opisuje jego rolę. Typ `0` rozpoczyna figurę, a typ `1` rysuje linię od poprzedniego punktu do bieżącego. Odcinek Béziera trzeciego stopnia zaczyna się w poprzednim punkcie końcowym i używa trzech kolejnych wpisów typu `3`: dwóch punktów kontrolnych i nowego punktu końcowego. Pętla zużywa te trzy wpisy razem i sprawdza punkt końcowy pod kątem zamknięcia.

Typy punktów zawierają także flagi. Maskuj przy pomocy `0x07`, aby określić typ odcinka, oraz testuj osobno `0x80`, aby wykryć zamkniętą podścieżkę. Przykładowo, `129` (`0x81`) oznacza końcowy punkt linii zamykający podścieżkę, a `131` (`0x83`) oznacza końcowy punkt Béziera zamykający podścieżkę. Java przechowuje te flagi w bajtach ze znakiem; maskowanie zachowuje zamierzone wartości bitowe. Porównywanie surowej wartości tylko z `1` lub `3` pominęłoby te przypadki. Inne flagi, takie jak kreska (`0x10`) i znacznik (`0x20`), nie zmieniają bazowego typu odcinka.

**Współrzędne i przekształcenia.** Punkty są mierzone w punktach (1/72 cala), przy X rosnącym w prawo i Y rosnącym w dół. Dla niezagregowanego kształtu wyodrębnione współrzędne już zawierają pozycję zwróconą przez [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) i [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) oraz odzwierciedlają jego aktualną szerokość i wysokość. Na przykład nieobrócony prostokąt w `(100, 200)` o wymiarach `120 × 80` ma granice konturu `(100, 200)`–`(220, 280)`. Nie dodawaj ponownie pozycji kształtu. Odejmij jego X i Y, aby uzyskać współrzędne względem nieobróconej ramki.

Wyodrębnione punkty nie uwzględniają obrotu kształtu, zwróconego przez [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), ani odbić poziomych i pionowych. Aby odtworzyć wyświetlany kontur, zastosuj te przekształcenia wokół środka kształtu. Dla kształtów grupowanych uwzględnij także mapowanie współrzędnych grupy i przekształcenia; nie zakładaj, że wyodrębnione punkty są ostatecznymi współrzędnymi slajdu ani nie stosuj podwójnego przesunięcia lub skalowania, jeśli już zostały uwzględnione w ramce dziecka.

**Inspekcja versus edycja.** Wyodrębnione tablice opisują kontur; ich zmiana nie aktualizuje oryginalnego kształtu. Wybierz tę metodę, gdy Twoja analiza lub kod rysujący potrzebuje tablic punktów/typów. Użyj [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths), gdy potrzebujesz poleceń geometrycznych w lokalnym układzie współrzędnych kształtu lub chcesz edytować jego geometrię. Zastosuj edytowane ścieżki przy pomocy [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) lub [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Konwersja obiektu Java AWT Shape na GeometryPath**

Ten przykład łączy prostokątny obrys z tekstem skonwertowanym na geometrię. Metoda [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) obrysu wyłącza jego wypełnienie. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) tworzy kontur tekstu w obiekcie [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Jego [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) dostarcza ruchu, linii, kwadratowych, sześciennych i zamykających odcinków, które przykład odtwarza na [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

Most Java używa explicite wartości float i byte dla odpowiadających parametrów Java. Iterator zapisuje współrzędne do tablicy float w Javie; refleksja odczytuje zaktualizowane wartości z powrotem do JavaScript. Tekst używa czcionki Arial 40‑punktowej. Obrys jest przesunięty o 20 punktów w poziomie i umieszczony tak, aby jego widoczna górna krawędź znajdowała się 10 punktów poniżej górnej krawędzi kształtu. Ścieżka tekstowa jest wypełniona, podczas gdy oryginalny prostokąt pozostaje jedynie obrysem. Zastosowanie obu ścieżek metodą [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) tworzy pojedynczy kształt zawierający prostokąt i tekst.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // Przejdź do.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Linia do.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // Krzywa Beziera kwadratowa.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Krzywa Beziera sześcienna.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Zamknij figurę.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Co się stanie z wypełnieniem i obrysem po zastąpieniu geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się tylko kontur. Wypełnienie i obrys są automatycznie stosowane do nowej geometrii.

**Jak prawidłowo obrócić własny kształt wraz z jego geometrią?**

Użyj metody [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) kształtu; geometria obraca się razem z kształtem, ponieważ jest powiązana z jego własnym układem współrzędnych.

**Czy mogę przekonwertować własny kształt na obraz, aby „zablokować” rezultat?**

Tak. Wyeksportuj wymagany [slide](/slides/pl/nodejs-java/convert-powerpoint-to-png/) lub sam [shape](/slides/pl/nodejs-java/create-shape-thumbnails/) do formatu rastrowego; ułatwi to dalszą pracę z złożonymi geometriami.