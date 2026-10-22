---
title: Dostosuj kształty prezentacji w JavaScript
linktitle: Niestandardowy kształt
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
- punkty edycji
- dodaj punkt
- usuń punkt
- operacja edycji
- zaokrąglony narożnik
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu JavaScript i Aspose.Slides dla Node.js: ścieżki geometryczne, zaokrąglone narożniki, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty w prezentacji w Aspose.Slides, edytując geometrię kształtu przy użyciu punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) aby modyfikować istniejące kształty, wykonywać podstawowe operacje edycji ścieżki, dodawać lub usuwać punkty oraz zastosować zaktualizowaną geometrię z powrotem do kształtu. Pokazuje również, jak tworzyć niestandardowe i złożone kształty, budować kształty z zaokrąglonymi narożnikami, określić, czy geometria kształtu jest zamknięta, przeglądać elementy kształtu oraz konwertować zarysy tekstu Java AWT na ścieżki geometryczne.

## **Zmień kształt przy użyciu punktów edycji**

* Przesuń narożnik do środka lub na zewnątrz.
* Dostosuj krzywiznę w punkcie.
* Dodaj nowe punkty.

Edytowanie punktów pozwala modyfikować obrys kształtu lub używać istniejącego kształtu jako podstawy dla nowego.

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Podczas edycji kształtów w PowerPoint, zachowaj następujące pojęcia w pamięci:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Ścieżka kształtu składa się z punktów kotwic połączonych segmentami.
* Segment może być prosty lub zakrzywiony. Punkty kotwic i uchwyty kontrolne określają jego kształt.
* Punkty kotwic występują jako punkty narożne, proste lub gładkie:
  * W punkcie narożnym sąsiadujące segmenty mogą spotykać się pod kątem.
  * W punkcie gładkim dwa uchwyty kontrolne są wyrównane i znajdują się w równych odległościach od punktu kotwiczącego.
  * W punkcie prostym dwa uchwyty kontrolne są wyrównane, ale mogą mieć różne odległości od punktu kotwiczącego.
* Przesuwanie punktów kotwic lub dostosowywanie ich uchwytów zmienia obrys kształtu.

Aby edytować kształty PowerPoint przy użyciu punktów edycji, **Aspose.Slides** udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

* Instancja [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* Aby pobrać [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) z instancji [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/), możesz użyć metody [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths).
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) dla kształtu, możesz użyć następujących metod: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) dla kształtów z jedną ścieżką oraz [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) dla kształtów z wieloma ścieżkami.
* Aby dodać segmenty, możesz używać metod dostępnych w [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* Korzystając z metod [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) i [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode), możesz ustawić wygląd ścieżki geometrycznej.
* Korzystając z metody [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData), możesz pobrać ścieżkę geometryczną [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) jako tablicę segmentów ścieżki.
* Aby uzyskać dodatkowe opcje dostosowywania geometrii kształtu, możesz odczytać [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) przez jego [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) i odtworzyć segmenty na [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Proste operacje edycji**

Użyj poniższych metod aby edytować ścieżkę geometryczną. Przeciążenia przyjmujące indeks wstawiają segment na tej zerobazowej pozycji w tablicy segmentów ścieżki.

| Operacja | Metoda |
| --- | --- |
| Dodaj lub wstaw prostą linię. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Dodaj lub wstaw krzywą Bézier trójstopniową z dwoma punktami kontrolnymi i punktem końcowym. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Dodaj lub wstaw krzywą Bézier kwadratową z jednym punktem kontrolnym i punktem końcowym. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Dodaj łuk eliptyczny o podanych wymiarach i kątach w stopniach. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Zamknij bieżącą figurę, łącząc jej punkt końcowy z punktem początkowym. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Ustaw punkt początkowy figury. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Usuń segment o zerobazowym indeksie. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Dodaj niestandardowe punkty do kształtu**

Ten przykład wstawia dwa punkty do prostokątnego kształtu przy użyciu [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) i stosuje edytowaną ścieżkę za pomocą [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). Współrzędne są lokalne względem kształtu: oba nowe punkty znajdują się w jego środku, 100 punktów od lewej i 50 punktów od góry. Indeksy segmentów 1 i 4 umieszczają je na górnych i dolnych krawędziach, ciągnąc te krawędzie do środka.

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

## **Usuń punkty z kształtu**

Ten przykład zmienia obrys w kształcie serca, usuwając segment o zerobazowym indeksie 2 przy użyciu [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). Zastosowanie zmodyfikowanej ścieżki za pomocą [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) aktualizuje kontur kształtu.

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

## **Utwórz niestandardowy kształt**

Ten przykład tworzy pięciokątną gwiazdę przy użyciu [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Alternatywne zewnętrzne i wewnętrzne promienie 100 i 50 punktów definiują szczyty i wcięcia; krok 72 stopni rozmieszcza pięć szczytów równomiernie. Ścieżka jest zamykana przy użyciu [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) i stosowana do prostokątnego kształtu przy pomocy [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), zastępując jego obrys.

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

## **Utwórz złożony niestandardowy kształt**

Ten przykład definiuje dwa zamknięte obiekty [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) dla górnej i dolnej jednej trzeciej kształtu. Zastosowanie obu ścieżek przy pomocy [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) tworzy pojedynczy złożony kształt z przerwą w środkowej jednej trzeciej.

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

## **Utwórz niestandardowy kształt z zakrzywionymi narożnikami**

Ten przykład łączy proste segmenty z [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo), aby utworzyć kształt z wklęsłymi narożnikami. Rozmiar każdego narożnika określa szerokość i wysokość łuku w punktach, a przemieszczenie -90 stopni rysuje przeciwnie do ruchu wskazówek zegara ćwiartkę elipsy. Gotowa ścieżka jest zastosowana przy pomocy [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), a prezentacja zapisywana jest w formacie PPTX.

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

## **Sprawdź, czy geometria kształtu jest zamknięta**

Poniższy pomocnik sprawdza, czy każda niepusta ścieżka geometryczna kończy się segmentem zamykającym. Odczytuje [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) i porównuje polecenie ostatniego segmentu [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) z [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Zwraca false, gdy nie ma niepustych ścieżek. Sprawdza polecenie końcowe każdej ścieżki; nie przegląda każdej podfigury w ścieżce. Przykład wypisuje `true` dla prostokąta.

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

## **Wyodrębnij i sprawdź elementy kształtu**

Użyj [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements), aby przeanalizować istniejący kształt jako elementy zawierające punkty ścieżki i typy punktów. Użyj każdego zwróconego [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/), aby pobrać tablice punktów i typów za pomocą metod [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) i [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes). Ta reprezentacja jest przydatna do analizy konturu lub przekazywania geometrii do własnych narzędzi rysunkowych.

Przykład otwiera input.pptx, znajduje pierwszy kształt geometryczny bezpośrednio na pierwszym slajdzie i wypisuje jego segmenty ścieżki. Użyj prezentacji zawierającej kształt z segmentami prostymi i zakrzywionymi, aby zobaczyć oba rodzaje wyjścia. Nie przeszukuje grup.

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
                const pointType = types[i] & 0x07; // Zachowaj typ segmentu, pomijając flagi.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
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

Tablice odpowiadają sobie po indeksie: `points[i]` jest punktem, a `types[i]` opisuje jego rolę. Typ `0` rozpoczyna figurę, a typ `1` rysuje linię od poprzedniego punktu do bieżącego. Segment Bézier trójstopniowy zaczyna się od poprzedniego punktu końcowego i używa trzech kolejnych wpisów typu `3`: dwa punkty kontrolne, a następnie nowy punkt końcowy. Pętla zużywa te trzy wpisy razem i sprawdza punkt końcowy pod kątem zamknięcia.

Typy punktów zawierają także flagi. Maska `0x07` służy do identyfikacji typu segmentu, a test `0x80` oddzielnie wykrywa zamkniętą podścieżkę. Na przykład `129` (`0x81`) oznacza punkt końcowy linii, który zamyka podścieżkę, a `131` (`0x83`) oznacza punkt końcowy Bézier, który ją zamyka. Java przechowuje te flagi w bajtach ze znakiem; maskowanie zachowuje zamierzone wartości bitów. Porównywanie surowej wartości tylko z `1` lub `3` pominęłoby te przypadki. Inne flagi, takie jak kreska (`0x10`) i marker (`0x20`), nie zmieniają podstawowego typu segmentu.

**Współrzędne i przekształcenia.** Punkty mierzone są w punktach (1/72 cala), przy czym X rośnie w prawo, a Y w dół. Dla niepogrupowanego kształtu wyodrębnione współrzędne już zawierają pozycję zwróconą przez [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) i [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) i odzwierciedlają jego aktualną szerokość i wysokość. Na przykład nieobrócony prostokąt w `(100, 200)` o rozmiarze `120 × 80` ma granice konturu `(100, 200)`–`(220, 280)`. Nie dodawaj ponownie pozycji kształtu. Odejmij jego X i Y, aby uzyskać współrzędne względem nieobróconej ramki.

Wyodrębnione punkty nie uwzględniają rotacji kształtu, zwracanej przez [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), ani odbić poziomych i pionowych. Aby odtworzyć wyświetlany kontur, zastosuj te przekształcenia wokół środka kształtu. Dla zagregowanych kształtów uwzględnij także mapowanie współrzędnych grupy i przekształcenia; nie zakładaj, że wyodrębnione punkty są ostatecznymi współrzędnymi slajdu ani nie stosuj podwójnego przesunięcia lub skalowania, jeśli już jest odzwierciedlone w ramce dziecka.

**Inspekcja vs edycja.** Wyodrębnione tablice opisują kontur; ich zmiana nie aktualizuje oryginalnego kształtu. Wybierz to podejście, gdy twoja analiza lub kod rysujący potrzebuje tablic punktów/typów. Użyj [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths), gdy potrzebujesz poleceń geometrii w lokalnym układzie współrzędnych kształtu lub chcesz edytować jego geometrię. Zastosuj edytowane ścieżki poprzez [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) lub [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Konwertuj kształt Java AWT na GeometryPath**

Ten przykład łączy prostokątny obrys z tekstem skonwertowanym na geometrię. Metoda [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) obrysu wyłącza jego wypełnienie. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) tworzy zarys tekstu w [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Jego [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) dostarcza segmenty move, line, quadratic, cubic i zamknięcia, które przykład odtwarza na [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

Most Java używa explicite wartości float i byte dla odpowiednich parametrów Java. Iterator zapisuje współrzędne do tablicy float w Javie; refleksja odczytuje zaktualizowane wartości z powrotem do JavaScript. Tekst używa czcionki Arial 40 punktów. Obrys jest przesunięty o 20 punktów w poziomie i umieszczony tak, że jego wizualna góra znajduje się 10 punktów poniżej górnej krawędzi kształtu. Ścieżka tekstowa jest wypełniona, podczas gdy oryginalny prostokąt pozostaje obrysem. Zastosowanie obu ścieżek przy pomocy [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) tworzy pojedynczy kształt zawierający prostokąt i tekst.

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
            case 2: // Krzywa kwadratowa Bézier.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Krzywa sześcienna Bézier.
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

Styl pozostaje przypisany do kształtu; zmienia się tylko kontur. Wypełnienie i obrys są automatycznie zastosowane do nowej geometrii.

**Jak prawidłowo obrócić niestandardowy kształt wraz z jego geometrią?**

Użyj metody [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) kształtu; geometria obraca się razem z kształtem, ponieważ jest związana z własnym układem współrzędnych kształtu.

**Czy mogę przekonwertować niestandardowy kształt na obraz, aby "zablokować" rezultat?**

Tak. Wyeksportuj żądany obszar [slide](/slides/pl/nodejs-java/convert-powerpoint-to-png/) lub sam [shape](/slides/pl/nodejs-java/create-shape-thumbnails/) do formatu rastrowego; ułatwia to dalszą pracę z złożonymi geometriami.