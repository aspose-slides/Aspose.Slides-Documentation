---
title: Dostosowywanie kształtów prezentacji na Androidzie
linktitle: Własny kształt
type: docs
weight: 20
url: /pl/androidjava/custom-shape/
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
- zakrzywiony róg
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Androida w języku Java: ścieżki geometryczne, zakrzywione rogi, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty prezentacji w Aspose.Slides, edytując geometrię kształtu za pomocą punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) i [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/), aby modyfikować istniejące kształty, wykonywać podstawowe operacje edycji ścieżek, dodawać lub usuwać punkty oraz zastosować zaktualizowaną geometrię z powrotem do kształtu.

Demonstruje również, jak tworzyć własne i złożone kształty, budować kształty z zaokrąglonymi rogami, określać, czy geometria kształtu jest zamknięta, oraz przeglądać elementy kształtu przy użyciu tablic punktów Android.

## **Zmienianie kształtu za pomocą punktów edycji**

* Przesuń róg do wewnątrz lub na zewnątrz.
* Dostosuj krzywiznę w punkcie.
* Dodaj nowe punkty.

Edycja punktów pozwala modyfikować obrys kształtu lub użyć istniejącego kształtu jako podstawy do nowego.

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Podczas edycji kształtów w PowerPoint należy pamiętać o następujących pojęciach:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Ścieżka kształtu składa się z punktów kotwiczących połączonych odcinkami.
* Odcinek może być prosty lub zakrzywiony. Punkty kotwiczące i uchwyty kontrolne określają jego kształt.
* Punkty kotwiczące występują jako punkty narożne, proste lub gładkie:
  * W punkcie narożnym sąsiadujące odcinki mogą spotkać się pod kątem.
  * W punkcie gładkim dwa uchwyty kontrolne są wyrównane i znajdują się w tej samej odległości od punktu kotwiczącego.
  * W punkcie prostym dwa uchwyty kontrolne są wyrównane, ale mogą mieć różne odległości od punktu kotwiczącego.
* Przesuwanie punktów kotwiczących lub regulacja ich uchwytów zmienia obrys kształtu.

Aby edytować kształty PowerPoint za pomocą punktów edycji, **Aspose.Slides** udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) oraz interfejs [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* Instancja [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* Aby pobrać [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) z instancji [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/), możesz użyć metody [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) dla kształtu, możesz użyć następujących metod: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) dla kształtów z jedną ścieżką oraz [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) dla kształtów z wieloma ścieżkami.
* Aby dodać odcinki, możesz używać metod dostępnych w [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).
* Korzystając z metod [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) i [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-), możesz ustawić wygląd ścieżki geometrycznej.
* Używając metody [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--), możesz pobrać ścieżkę geometryczną [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) jako tablicę segmentów ścieżki.

## **Proste operacje edycji**

Użyj następujących metod do edycji ścieżki geometrycznej. Przeciążenia przyjmujące indeks wstawiają segment na tej pozycji (liczonej od zera) w tablicy segmentów ścieżki.

| Operacja | Metoda |
| --- | --- |
| Dodaj lub wstaw prostą linię. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Dodaj lub wstaw krzywą Béziera stopnia trzeciego z dwoma punktami kontrolnymi i punktem końcowym. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Dodaj lub wstaw krzywą Béziera stopnia drugiego z jednym punktem kontrolnym i punktem końcowym. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Dodaj łuk eliptyczny o podanych wymiarach i kątach w stopniach. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Zamknij bieżącą figurę, łącząc jej punkt końcowy z punktem początkowym. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Ustaw punkt początkowy figury. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Usuń segment o indeksie liczonym od zera. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Dodawanie własnych punktów do kształtu**

Ten przykład wstawia dwa punkty do prostokątnego kształtu przy użyciu [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) i stosuje edytowaną ścieżkę za pomocą [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Współrzędne są lokalne względem kształtu: oba nowe punkty znajdują się w jego środku, 100 punktów od lewej i 50 punktów od góry. Indeksy segmentów 1 i 4 umieszczają je na górnej i dolnej krawędzi, ściągając te krawędzie do środka.

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

Ten przykład zmienia kontur w kształcie serca, usuwając segment o indeksie liczonym od zera równym 2 za pomocą [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). Zastosowanie zmodyfikowanej ścieżki przy pomocy [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) aktualizuje obrys kształtu.

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

Ten przykład tworzy pięcioramienną gwiazdę za pomocą [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Naprzemienne promienie zewnętrzne i wewnętrzne o wartościach 100 i 50 punktów definiują końcówki i wcięcia; krok 72 stopnie równomiernie rozmieszcza pięć końcówek. Ścieżka jest zamykana przy użyciu [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) i następnie stosowana do prostokątnego kształtu za pomocą [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), zastępując jego obrys.

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
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

Ten przykład definiuje dwa zamknięte obiekty [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) dla górnej i dolnej jednej trzeciej kształtu. Zastosowanie obu ścieżek przy pomocy [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) tworzy jeden złożony kształt z przerwą w środkowej jednej trzeciej.

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

## **Tworzenie własnego kształtu z zakrzywionymi rogami**

Ten przykład łączy proste odcinki z [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) aby utworzyć kształt z wewnętrznie zakrzywionymi rogami. Rozmiar każdego rogu określa szerokość i wysokość łuku w punktach, a przemieszczenie -90 stopni rysuje przeciwzegarową ćwiartkę elipsy. Gotowa ścieżka jest stosowana przy użyciu [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), a prezentacja jest zapisywana w formacie PPTX.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

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

Poniższy pomocnik sprawdza, czy każda niepusta ścieżka geometryczna kończy się segmentem zamykającym. Odczytuje [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) i porównuje polecenie ostatniego segmentu [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) z [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Zwraca false, gdy nie ma niepustych ścieżek. Sprawdza polecenie końcowe każdej ścieżki; nie przegląda wszystkich pod‑figur wewnątrz ścieżki. Przykład wypisuje `true` dla prostokąta.

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

Pobierz [contour.pptx](contour.pptx) i zamień przykładową nazwę pliku na jego ścieżkę na urządzeniu. Pierwszy kształt na pierwszym slajdzie ma prostą górną krawędź, krzywą Béziera trzeciego stopnia oraz prostą krawędź zamykającą. Użyj [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) , aby odczytać ścieżki kształtu, oraz [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) , aby odczytać segmenty każdej ścieżki w kolejności rysowania. Dla każdego segmentu [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) określa polecenie i decyduje, jak interpretować wartości zwracane przez [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--).

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

Kształt znajduje się w punkcie (200, 100) na slajdzie. Zgłoszone współrzędne są lokalne względem kształtu, z (0, 0) w jego lewym górnym rogu, x rośnie w prawo, a y w dół. Segment zamykający powraca do punktu początkowego bez dodatkowych współrzędnych.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```
![Kształt PowerPoint z prostą górną krawędzią, zakrzywioną krawędzią od prawego górnego do lewego dolnego oraz prostą lewą krawędzią](contour.png)

## **Wyodrębnianie i przeglądanie elementów kształtu**

Użyj [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) , aby przejrzeć istniejący kształt jako elementy zawierające punkty ścieżki i typy punktów. Rzutuj każdy zwrócony [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) na [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/), aby uzyskać tablice punktów i typów przy użyciu metod [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) i [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) . Ta reprezentacja jest przydatna do analizy konturu lub przekazywania geometrii do własnych narzędzi rysunkowych.

Przykład otwiera plik input.pptx, znajduje pierwszy kształt geometryczny bezpośrednio na pierwszym slajdzie i wypisuje jego segmenty ścieżki. Użyj prezentacji zawierającej kształt z segmentami prostymi i zakrzywionymi, aby zobaczyć oba rodzaje wyników. Nie przeszukuje grup.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Zachowaj typ segmentu, pomijając flagi.
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

Tablice odpowiadają sobie indeksami: `points[i]` to punkt, a `types[i]` opisuje jego rolę. Typ `0` rozpoczyna figurę, a typ `1` rysuje linię od poprzedniego punktu do bieżącego. Segment krzywej Béziera trzeciego stopnia zaczyna się od poprzedniego punktu końcowego i wykorzystuje trzy kolejne wpisy typu `3`: dwa punkty kontrolne oraz nowy punkt końcowy. Pętla zużywa te trzy wpisy razem i sprawdza punkt końcowy pod kątem zamknięcia.

Typy punktów zawierają także flagi. Maskuj przy użyciu `0x07`, aby określić typ segmentu, oraz testuj oddzielnie `0x80`, aby wykryć zamkniętą pod‑ścieżkę. Na przykład `129` (`0x81`) oznacza punkt końcowy linii, który zamyka pod‑ścieżkę, a `131` (`0x83`) oznacza punkt końcowy Béziera, który ją zamyka. Java przechowuje te flagi w bajtach ze znakiem; maskowanie zachowuje zamierzone wartości bitów. Porównywanie surowej wartości tylko z `1` lub `3` pominęłoby te przypadki. Inne flagi, takie jak kreska (`0x10`) i znacznik (`0x20`), nie zmieniają podstawowego typu segmentu.

**Współrzędne i przekształcenia.** Punkty są mierzone w punktach (1/72 cala), przy czym X rośnie w prawo, a Y w dół. Dla niegrupowanego kształtu wyodrębnione współrzędne już zawierają pozycję zwracaną przez [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) i [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) oraz odzwierciedlają jego aktualną szerokość i wysokość. Na przykład nieobrócony prostokąt w `(100, 200)` o wymiarach `120 × 80` ma granice konturu `(100, 200)`–`(220, 280)`. Nie dodawaj ponownie pozycji kształtu. Odejmij jego X i Y, aby uzyskać współrzędne względem nieobróconej ramki.

Wyodrębnione punkty nie uwzględniają obrotu kształtu, zwracanego przez [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--), ani odbić poziomych i pionowych. Aby odtworzyć wyświetlany kontur, zastosuj te przekształcenia wokół środka kształtu. Dla grupowanych kształtów uwzględnij także mapowanie współrzędnych grupy i przekształcenia; nie zakładaj, że wyodrębnione punkty są ostatecznymi współrzędnymi slajdu ani nie stosuj podwójnego przesunięcia lub skalowania, jeśli już są odzwierciedlone w ramce dziecka.

**Inspekcja vs. edycja.** Wyodrębnione tablice opisują kontur; ich modyfikacja nie aktualizuje oryginalnego kształtu. Wybierz to podejście, gdy analiza lub kod rysujący wymaga tablic punktów/typów. Użyj [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) , gdy potrzebujesz poleceń geometrycznych w lokalnym układzie współrzędnych kształtu lub chcesz edytować jego geometrię. Zastosuj edytowane ścieżki przy pomocy [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) lub [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **FAQ**

**Co się stanie z wypełnieniem i obrysem po zastąpieniu geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się tylko kontur. Wypełnienie i obrys są automatycznie zastosowane do nowej geometrii.

**Jak prawidłowo obrócić własny kształt wraz z jego geometrią?**

Użyj metody [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) kształtu; geometria obraca się razem z kształtem, ponieważ jest powiązana z jego własnym układem współrzędnych.

**Czy mogę konwertować własny kształt na obraz, aby "zablokować" wynik?**

Tak. Wyeksportuj wymagany [slajd](/slides/pl/androidjava/convert-powerpoint-to-png/) lub sam [kształt](/slides/pl/androidjava/create-shape-thumbnails/) do formatu rastrowego; ułatwia to dalszą pracę z złożonymi geometries.