---
title: Dostosowywanie kształtów prezentacji w Javie
linktitle: Własny kształt
type: docs
weight: 20
url: /pl/java/custom-shape/
keywords:
- niestandardowy kształt
- dodaj kształt
- utwórz kształt
- zmień kształt
- geometria kształtu
- ścieżka geometryczna
- punkty ścieżki
- edycja punktów
- dodaj punkt
- usuń punkt
- operacja edycji
- zaokrąglony narożnik
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Javy: ścieżki geometryczne, zaokrąglone narożniki, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty w prezentacji w Aspose.Slides, edytując geometrię kształtu przy użyciu punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) i [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/), aby modyfikować istniejące kształty, wykonywać podstawowe operacje edycji ścieżek, dodawać lub usuwać punkty oraz zastosować zaktualizowaną geometrię do kształtu.

Demonstruje także, jak tworzyć niestandardowe i złożone kształty, budować kształty z zaokrąglonymi narożnikami, określać, czy geometria kształtu jest zamknięta, przeglądać elementy kształtu oraz konwertować kontury tekstu Java AWT na ścieżki geometryczne.

## **Zmiana kształtu za pomocą punktów edycji**

W programie PowerPoint możesz używać **Punktów edycji**, aby zmodyfikować kwadrat:

* Przesunąć róg do wewnątrz lub na zewnątrz.
* Dostosować krzywiznę w punkcie.
* Dodać nowe punkty.

Edycja punktów pozwala zmienić obrys kształtu lub użyć istniejącego kształtu jako podstawy dla nowego.

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Podczas edycji kształtów PowerPoint pamiętaj o następujących koncepcjach:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Ścieżka kształtu składa się z punktów kotwiczących połączonych odcinkami.
* Odcinek może być prosty lub krzywy. Kształt określają punkty kotwiczące i uchwyty sterujące.
* Punkty kotwiczące mogą być punktami narożnymi, prostymi lub gładkimi:
  * W punkcie narożnym przylegające odcinki mogą spotykać się pod kątem.
  * W punkcie gładkim dwa uchwyty sterujące są wyrównane i równo odległe od punktu kotwiczącego.
  * W punkcie prostym dwa uchwyty sterujące są wyrównane, ale mogą mieć różne odległości od punktu kotwiczącego.
* Przesuwanie punktów kotwiczących lub regulacja ich uchwytów zmienia obrys kształtu.

Aby edytować kształty PowerPoint za pomocą punktów edycji, **Aspose.Slides** udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) oraz interfejs [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).

* Instancja [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/).
* Aby pobrać [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) z instancji [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/), możesz użyć metody [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) dla kształtu, możesz użyć metod: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) dla kształtów z pojedynczą ścieżką oraz [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) dla kształtów z wieloma ścieżkami.
* Aby dodać odcinki, możesz używać metod z interfejsu [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).
* Korzystając z metod [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) i [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-), możesz ustawić wygląd ścieżki geometrycznej.
* Metodą [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) możesz pobrać ścieżkę geometryczną [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) jako tablicę odcinków ścieżki.
* Aby uzyskać dodatkowe opcje dostosowywania geometrii kształtu, możesz odczytać [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) przez jego [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) i odtworzyć odcinki na [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

## **Proste operacje edycji**

Użyj poniższych metod do edycji ścieżki geometrycznej. Przeciążenia przyjmujące indeks wstawiają odcinek w podanej, indeksowanej od zera, pozycji w tablicy odcinków ścieżki.

| Operacja | Metoda |
| --- | --- |
| Dodaj lub wstaw prostą linię. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Dodaj lub wstaw krzywą Béziera trzeciego stopnia z dwoma punktami kontrolnymi i punktem końcowym. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Dodaj lub wstaw krzywą Béziera drugiego stopnia z jednym punktem kontrolnym i punktem końcowym. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Dodaj łuk eliptyczny o określonych wymiarach i kątach w stopniach. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Zamknij bieżącą figurę, łącząc jej punkt końcowy z punktem początkowym. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Ustaw punkt początkowy figury. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Usuń odcinek pod indeksem zerowym. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Dodawanie własnych punktów do kształtu**

Ten przykład wstawia dwa punkty do prostokątnego kształtu przy użyciu [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) i stosuje edytowaną ścieżkę metodą [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Współrzędne są lokalne względem kształtu: oba nowe punkty znajdują się w jego środku, 100 punktów od lewej i 50 punktów od góry. Indeksy odcinków 1 i 4 umieszczają je na górnej i dolnej krawędzi, ściągając te krawędzie do środka.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Usuwanie punktów z kształtu**

Ten przykład modyfikuje kontur serca, usuwając odcinek pod indeksem zerowym 2 metodą [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-). Zastosowanie zmodyfikowanej ścieżki metodą [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) aktualizuje kontur kształtu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Tworzenie własnego kształtu**

Ten przykład buduje pięcioramienną gwiazdę przy użyciu [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). Naprzemienne promienie zewnętrzny i wewnętrzny o wartościach 100 i 50 punktów definiują wierzchołki i wcięcia; krok 72 stopni równomiernie rozmieszcza pięć wierzchołków. Ścieżka jest zamykana metodą [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) i stosowana do prostokątnego kształtu metodą [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), zastępując jego obrys.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Tworzenie złożonego własnego kształtu**

Ten przykład definiuje dwie zamknięte ścieżki [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) dla górnej i dolnej jednej trzeciej kształtu. Zastosowanie obu ścieżek metodą [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) tworzy jeden złożony kształt z przerwą w środkowej jednej trzeciej.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Tworzenie własnego kształtu z zaokrąglonymi narożnikami**

Ten przykład łączy odcinki proste z metodą [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) w celu utworzenia kształtu z wklęsłymi narożnikami. Rozmiar każdego narożnika określa szerokość i wysokość łuku w punktach, a kąt -90 stopni rysuje przeciwnie do ruchu wskazówek zegara ćwiartkowy elipsoid. Gotowa ścieżka jest stosowana metodą [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), a prezentacja zapisywana jest w formacie PPTX.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sprawdzanie, czy geometria kształtu jest zamknięta**

Poniższy pomocniczy kod sprawdza, czy każda niepusta ścieżka geometryczna kończy się odcinkiem zamykającym. Odczytuje [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) i porównuje komendę końcowego odcinka [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) z [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). Zwraca false, gdy nie ma niepustych ścieżek. Sprawdza końcową komendę każdej ścieżki; nie analizuje każdego podrysunku w obrębie ścieżki. Przykład wypisuje `true` dla prostokąta.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **Inspekcja poleceń ścieżki geometrycznej**

Pobierz plik [contour.pptx](contour.pptx) i umieść go w katalogu roboczym aplikacji. Pierwszy kształt na pierwszym slajdzie ma prosty górny brzeg, krzywą Béziera trzeciego stopnia oraz prosty zamykający brzeg. Użyj [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) aby odczytać ścieżki kształtu oraz [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) aby odczytać odcinki każdej ścieżki w kolejności rysowania. Dla każdego odcinka metoda [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) identyfikuje polecenie i określa, jak interpretować wartości zwracane przez [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--).

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

Kształt znajduje się w punkcie (200, 100) na slajdzie. Zgłoszone współrzędne są lokalne względem kształtu, przy (0, 0) w lewym górnym rogu, x rośnie w prawo, a y w dół. Odcinek zamykający powraca do punktu początkowego bez dodatkowych współrzędnych.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![Kształt PowerPoint z prostym górnym brzegiem, zakrzywionym brzegiem od górnego prawego do dolnego lewego oraz prostym lewym brzegiem](contour.png)

## **Ekstrakcja i inspekcja elementów kształtu**

Użyj [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) aby przeanalizować istniejący kształt jako elementy zawierające punkty ścieżki i typy punktów. Rzutuj każdy zwrócony [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) na [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/), aby uzyskać tablice punktów i typów za pomocą metod [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) i [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--). Ta reprezentacja jest przydatna przy analizie konturu lub przekazywaniu geometrii do własnych narzędzi rysunkowych.

Przykład otwiera plik input.pptx, znajduje pierwszą formę geometryczną bezpośrednio na pierwszym slajdzie i wypisuje jej odcinki ścieżki. Użyj prezentacji zawierającej kształt z odcinkami prostymi i krzywymi, aby zobaczyć oba rodzaje wyników. Nie przeszukuje grup.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Zachowaj typ odcinka, wykluczając flagi.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Zużyj oba punkty kontrolne i punkt końcowy.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Tablice są powiązane indeksem: `points[i]` to punkt, a `types[i]` opisuje jego rolę. Typ `0` rozpoczyna figurę, a typ `1` rysuje linię od poprzedniego punktu do bieżącego. Odcinek krzywej Béziera trzeciego stopnia zaczyna się od poprzedniego punktu końcowego i wykorzystuje trzy kolejne wpisy typu `3`: dwa punkty kontrolne i nowy punkt końcowy. Pętla pobiera te trzy wpisy razem i sprawdza punkt końcowy pod kątem zamknięcia.

Typy punktów zawierają również flagi. Maskuj wartość przy pomocy `0x07`, aby zidentyfikować typ odcinka, oraz sprawdzaj `0x80` oddzielnie, aby wykryć zamkniętą podścieżkę. Na przykład `129` (`0x81`) oznacza punkt końcowy linii zamykający podścieżkę, a `131` (`0x83`) oznacza punkt końcowy Béziera zamykający podścieżkę. Java przechowuje te flagi w bajtach ze znakiem; maskowanie zachowuje zamierzone wartości bitów. Porównywanie surowej wartości jedynie z `1` lub `3` pominęłoby te przypadki. Inne flagi, takie jak kreska (`0x10`) i znacznik (`0x20`), nie zmieniają podstawowego typu odcinka.

**Współrzędne i przekształcenia.** Punkty mierzone są w punktach (1/72 cala), przy czym X rośnie w prawo, a Y w dół. Dla niezgruppowanego kształtu wyodrębnione współrzędne już zawierają pozycję zwróconą przez [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) i [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) oraz odzwierciedlają bieżącą szerokość i wysokość. Na przykład nieobrócony prostokąt w `(100, 200)` o rozmiarze `120 × 80` ma granice konturu `(100, 200)`–`(220, 280)`. Nie dodawaj ponownie pozycji kształtu. Odejmij jego X i Y, aby uzyskać współrzędne względem nieobróconej ramki.

Wyodrębnione punkty nie uwzględniają obrotu kształtu, zwróconego przez [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--), ani odbić poziomych i pionowych. Aby odtworzyć wyświetlany kontur, zastosuj te przekształcenia wokół środka kształtu. Dla kształtów w grupie uwzględnij także mapowanie współrzędnych grupy i przekształcenia; nie zakładaj, że wyodrębnione punkty są ostatecznymi współrzędnymi slajdu ani nie stosuj podwójnego przesunięcia lub skalowania, jeśli już zostały uwzględnione w ramce dziecka.

**Inspekcja vs. edycja.** Wyodrębnione tablice opisują kontur; ich modyfikacja nie aktualizuje pierwotnego kształtu. Wybierz to podejście, gdy Twoja analiza lub kod rysujący potrzebuje tablic punktów/typów. Użyj [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) gdy potrzebujesz poleceń geometrycznych w lokalnym układzie współrzędnych kształtu lub chcesz edytować jego geometrię. Zastosuj edytowane ścieżki metodą [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) lub [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Konwersja obiektu Java AWT Shape do GeometryPath**

Ten przykład łączy prostokątny obrys z tekstem skonwertowanym na geometrię. Metoda [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) obrysu wyłącza jego wypełnienie. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) tworzy kontur tekstu w obiekcie [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Jego [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) dostarcza odcinki move, line, quadratic, cubic i closing, które przykład odtwarza na obiekcie [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

Tekst używa czcionki Arial 40 punktów. Obrys jest odsunięty o 20 punktów poziomo i umieszczony tak, że jego wizualna górna krawędź znajduje się 10 punktów poniżej górnej krawędzi kształtu. Ścieżka tekstowa jest wypełniona, podczas gdy oryginalny prostokąt pozostaje jedynie obrysem. Zastosowanie obu ścieżek metodą [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) tworzy pojedynczy kształt zawierający prostokąt i tekst.

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // Utwórz nowy kształt
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Pobierz ścieżkę geometryczną kształtu
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Utwórz nową ścieżkę graficzną z tekstem
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // Konwertuj ścieżkę graficzną na ścieżkę geometryczną
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // Ustaw połączenie nowej ścieżki geometrycznej i oryginalnej ścieżki geometrycznej dla kształtu
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Co się stanie z wypełnieniem i obrysem po zastąpieniu geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się jedynie kontur. Wypełnienie i obrys są automatycznie stosowane do nowej geometrii.

**Jak poprawnie obrócić własny kształt wraz z jego geometrią?**

Użyj metody kształtu [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-); geometria obraca się razem z kształtem, ponieważ jest związana z jego własnym układem współrzędnych.

**Czy mogę przekonwertować własny kształt na obraz, aby „zablokować” rezultat?**

Tak. Wyeksportuj wymaganą [slajd](/slides/pl/java/convert-powerpoint-to-png/) lub sam [kształt](/slides/pl/java/create-shape-thumbnails/) do formatu rastrowego; upraszcza to dalszą pracę z złożonymi geometriami.