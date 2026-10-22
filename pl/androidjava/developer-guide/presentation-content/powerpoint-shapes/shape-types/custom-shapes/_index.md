---
title: Dostosuj kształty prezentacji na Androidzie
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
- edytuj punkty
- dodaj punkt
- usuń punkt
- operacja edycji
- zaokrąglony narożnik
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Androida w języku Java: ścieżki geometryczne, zaokrąglone narożniki, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty prezentacji w Aspose.Slides poprzez edycję geometrii kształtu za pomocą punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) i [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) w celu modyfikacji istniejących kształtów, wykonywania podstawowych operacji edycji ścieżek, dodawania lub usuwania punktów oraz zastosowania zaktualizowanej geometrii z powrotem do kształtu.

Demonstruje również, jak tworzyć własne i złożone kształty, budować kształty z zaokrąglonymi narożnikami, określać, czy geometria kształtu jest zamknięta, oraz przeglądać elementy kształtu przy użyciu tablic punktów Android.

## **Zmiana kształtu za pomocą punktów edycji**

W PowerPoint możesz używać **Punktów edycji**, aby modyfikować kwadrat:

* Przesuwać narożnik do wewnątrz lub na zewnątrz.
* Dostosowywać krzywiznę w danym punkcie.
* Dodawać nowe punkty.

Edycja punktów pozwala zmienić kontur kształtu lub użyć istniejącego kształtu jako podstawy dla nowego.

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Podczas edycji kształtów w PowerPoint pamiętaj o następujących pojęciach:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Ścieżka kształtu składa się z punktów kotwicowych połączonych odcinkami.
* Odcinek może być prosty lub krzywy. Kształt określają punkty kotwicowe i uchwyty kontrolne.
* Punkty kotwicowe występują jako punkty narożne, proste lub gładkie:
  * W punkcie narożnym łączące się odcinki mogą tworzyć kąt.
  * W punkcie gładkim dwa uchwyty kontrolne są wyrównane i znajdują się w jednakowej odległości od punktu kotwicowego.
  * W punkcie prostym dwa uchwyty kontrolne są wyrównane, ale mogą mieć różne odległości od punktu kotwicowego.
* Przesuwanie punktów kotwicowych lub regulacja ich uchwytów zmienia obrys kształtu.

Aby edytować kształty PowerPoint za pomocą punktów edycji, **Aspose.Slides** udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) oraz interfejs [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).

* Instancja [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/).
* Aby pobrać [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) z instancji [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/), można użyć metody [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) dla kształtu, można użyć metod: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) dla kształtów z jedną ścieżką oraz [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) dla kształtów z wieloma ścieżkami.
* Aby dodać odcinki, można używać metod dostępnych w [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).
* Korzystając z metod [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) i [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-), można określić wygląd ścieżki geometrycznej.
* Metodą [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) można pobrać ścieżkę geometryczną obiektu [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) jako tablicę segmentów ścieżki.

## **Proste operacje edycji**

Użyj poniższych metod, aby edytować ścieżkę geometryczną. Przeciążenia przyjmujące indeks wstawiają odcinek w podanej, zerowo‑indeksowanej pozycji w tablicy odcinków ścieżki.

| Operacja | Metoda |
| --- | --- |
| Dodaj lub wstaw prostą linię. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Dodaj lub wstaw krzywą Béziera trzeciego stopnia z dwoma punktami kontrolnymi i punktem końcowym. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Dodaj lub wstaw krzywą Béziera drugiego stopnia z jednym punktem kontrolnym i punktem końcowym. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Dodaj łuk eliptyczny o podanych wymiarach i kątach w stopniach. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Zamknij bieżącą figurę, łącząc jej punkt końcowy z punktem początkowym. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Ustaw punkt początkowy figury. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Usuń odcinek o podanym zerowo‑indeksowanym indeksie. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Dodawanie własnych punktów do kształtu**

Poniższy przykład wstawia dwa punkty do prostokątnego kształtu przy użyciu [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) i stosuje edytowaną ścieżkę za pomocą [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). Współrzędne są lokalne względem kształtu: oba nowe punkty znajdują się w jego środku, 100 punktów od lewej i 50 punktów od góry. Indeksy segmentów 1 i 4 umieszczają je na górnej i dolnej krawędzi, ściągając te krawędzie do środka.

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

Przykład modyfikuje obrys serca, usuwając segment o zerowo‑indeksowanym indeksie 2 przy użyciu [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). Zastosowanie zmodyfikowanej ścieżki za pomocą [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) aktualizuje kontur kształtu.

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

Przykład buduje pięcioramienną gwiazdę przy użyciu [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Naprzemienne promienie zewnętrzne i wewnętrzne o wartościach 100 i 50 punktów definiują szczyty i wklęsłości; krok 72 stopnie rozmieszcza pięć szczytów równomiernie. Ścieżka jest zamykana metodą [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) i stosowana do prostokątnego kształtu przy pomocy [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), zastępując jego obrys.

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

Przykład definiuje dwie zamknięte ścieżki [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) dla górnej i dolnej trzeciej części kształtu. Zastosowanie obu ścieżek przy pomocy [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) tworzy jeden złożony kształt z przerwą w środkowej trzeciej części.

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

Przykład łączy proste odcinki z [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) w celu stworzenia kształtu z wklęsłymi narożnikami. Rozmiar każdego narożnika określa szerokość i wysokość łuku w punktach, a kąt -90° rysuje ćwiartkę elipsy w kierunku przeciwnym do ruchu wskazówek zegara. Gotowa ścieżka jest stosowana metodą [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), a prezentacja zapisywana jest w formacie PPTX.

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

Poniższy pomocniczy kod sprawdza, czy każda niepusta ścieżka geometryczna kończy się odcinkiem zamknięcia. Odczytuje [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) i porównuje polecenie ostatniego segmentu [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) z [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Zwraca false, gdy nie ma niepustych ścieżek. Kod sprawdza tylko ostatnie polecenie każdej ścieżki; nie analizuje wszystkich podfigur w obrębie ścieżki. Przykład wypisuje `true` dla prostokąta.

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

## **Wyodrębnianie i przeglądanie elementów kształtu**

Użyj [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) do przeglądania istniejącego kształtu jako elementów zawierających punkty ścieżki i ich typy. Rzutuj każdy zwrócony [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) na [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/), aby pobrać tablice punktów i typów poprzez metody [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) i [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--). Taka reprezentacja jest przydatna przy analizie konturu lub przekazywaniu geometrii do własnych narzędzi rysunkowych.

Przykład otwiera `input.pptx`, znajduje pierwszy kształt geometryczny bezpośrednio na pierwszym slajdzie i wypisuje jego segmenty ścieżki. Użyj prezentacji zawierającej kształt z odcinkami prostymi i krzywymi, aby zobaczyć oba rodzaje wyników. Nie przeszukuje grup.

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
                        i += 2; // Consume both control points and the endpoint.
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

Tablice są powiązane indeksem: `points[i]` to punkt, a `types[i]` opisuje jego rolę. Typ `0` rozpoczyna figurę, a typ `1` rysuje linię od poprzedniego punktu do bieżącego. Segment Béziera trzeciego stopnia rozpoczyna się w poprzednim punkcie końcowym i wykorzystuje trzy kolejne wpisy typu `3`: dwa punkty kontrolne oraz nowy punkt końcowy. Pętla zużywa te trzy wpisy razem i sprawdza punkt końcowy pod kątem zamknięcia.

Typy punktów zawierają także flagi. Maskuj wartość przy użyciu `0x07`, aby określić typ odcinka, a sprawdzaj `0x80` oddzielnie, aby wykryć zamkniętą podścieżkę. Przykładowo, `129` (`0x81`) oznacza koniec linii zamykający podścieżkę, a `131` (`0x83`) oznacza koniec Béziera zamykający podścieżkę. Java przechowuje te flagi w bajtach ze znakiem; maskowanie zachowuje zamierzone wartości bitowe. Porównywanie surowej wartości jedynie z `1` lub `3` pominęłoby te przypadki. Inne flagi, takie jak kreska (`0x10`) i znacznik (`0x20`), nie zmieniają podstawowego typu odcinka.

**Współrzędne i przekształcenia.** Punkty mierzone są w punktach (1/72 cala), przy czym X rośnie w prawo, a Y w dół. Dla niepogrupowanego kształtu wyodrębnione współrzędne już zawierają pozycję zwróconą przez [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) i [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) oraz odzwierciedlają jego aktualną szerokość i wysokość. Przykładowo, nieobrócony prostokąt w `(100, 200)` o rozmiarze `120 × 80` ma granice konturu `(100, 200)`–`(220, 280)`. Nie dodawaj ponownie pozycji kształtu. Odejmij jego X i Y, aby uzyskać współrzędne względem nieobróconej ramki.

Wyodrębnione punkty nie uwzględniają obrotu kształtu, zwracanego przez [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--), ani odbić poziomych i pionowych. Aby odtworzyć wyświetlany kontur, zastosuj te przekształcenia względem środka kształtu. Dla kształtów grupowanych uwzględnij także mapowanie współrzędnych grupy i jej przekształcenia; nie zakładaj, że wyodrębnione punkty są ostatecznymi współrzędnymi slajdu ani nie stosuj podwójnego przesunięcia lub skalowania, jeśli już zostały uwzględnione w ramce dziecka.

**Inspekcja a edycja.** Wyodrębnione tablice opisują kontur; ich modyfikacja nie aktualizuje oryginalnego kształtu. Wybierz tę metodę, gdy potrzebujesz tablic punktów/typów do analizy lub własnego kodu rysującego. Użyj [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) w przypadku, gdy potrzebujesz poleceń geometrycznych w lokalnym układzie współrzędnych kształtu lub chcesz edytować jego geometrię. Edytowane ścieżki aplikuj przy pomocy [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) lub [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **FAQ**

**Co się stanie z wypełnieniem i obrysem po zastąpieniu geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się tylko kontur. Wypełnienie i obrys są automatycznie stosowane do nowej geometrii.

**Jak prawidłowo obrócić własny kształt wraz z jego geometrią?**

Użyj metody [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) kształtu; geometria obraca się razem z kształtem, ponieważ jest związana z jego własnym układem współrzędnych.

**Czy mogę skonwertować własny kształt na obraz, aby „zablokować” rezultat?**

Tak. Wyeksportuj wybrany [slide](/slides/pl/androidjava/convert-powerpoint-to-png/) lub sam [shape](/slides/pl/androidjava/create-shape-thumbnails/) do formatu rastrowego; upraszcza to dalszą pracę z złożonymi geometriami.