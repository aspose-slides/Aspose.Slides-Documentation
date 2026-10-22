---
title: Dostosuj kształty prezentacji w .NET
linktitle: Kształt niestandardowy
type: docs
weight: 20
url: /pl/net/custom-shape/
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
- zaokrąglony narożnik
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET: ścieżki geometryczne, zaokrąglone narożniki, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty prezentacji w Aspose.Slides, edytując ich geometrię przy użyciu punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) i [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) , aby modyfikować istniejące kształty, wykonywać podstawowe operacje edycji ścieżek, dodawać lub usuwać punkty oraz zastosować zaktualizowaną geometrię z powrotem do kształtu.

Pokazuje również, jak tworzyć własne i złożone kształty, budować kształty z zaokrąglonymi narożnikami, określić, czy geometria kształtu jest zamknięta, oraz używać starszej konwersji między [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) a [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) w dodatkowych scenariuszach dostosowywania geometrii.

## **Zmienianie kształtu przy użyciu punktów edycji**

W programie PowerPoint możesz używać **Edit Points** do modyfikacji kwadratu:

* Przenieś róg do wewnątrz lub na zewnątrz.
* Dostosuj krzywiznę w punkcie.
* Dodaj nowe punkty.

Edytowanie punktów pozwala modyfikować obrys kształtu lub używać istniejącego kształtu jako podstawy dla nowego.

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Podczas edycji kształtów w PowerPoint, pamiętaj o następujących koncepcjach:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Ścieżka kształtu składa się z punktów kotwiczących połączonych segmentami.
* Segment może być prosty lub krzywy. Punkty kotwiczące i uchwyty kontrolne określają jego kształt.
* Punkty kotwiczące występują jako punkty narożne, proste lub gładkie:
  * W punkcie narożnym przylegające segmenty mogą łączyć się pod kątem.
  * W punkcie gładkim dwa uchwyty kontrolne są wyrównane i równo oddalone od punktu kotwiczącego.
  * W punkcie prostym dwa uchwyty kontrolne są wyrównane, ale mogą mieć różne odległości od punktu kotwiczącego.
* Przesuwanie punktów kotwiczących lub regulowanie ich uchwytów zmienia obrys kształtu.

Aby edytować kształty PowerPoint przy użyciu punktów edycji, **Aspose.Slides** udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) oraz interfejs [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) .

* Instancja [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) .
* Aby pobrać [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) z instancji [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) , możesz użyć metody [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) .
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) dla kształtu, możesz użyć tych metod: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) dla kształtów z pojedynczą ścieżką oraz [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) dla kształtów z wieloma ścieżkami.
* Aby dodać segmenty, możesz używać metod dostępnych w [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) .
* Używając właściwości [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) i [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) , możesz ustawić wygląd ścieżki geometrycznej.
* Korzystając z właściwości [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) , możesz pobrać ścieżkę geometryczną [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) jako tablicę segmentów ścieżki.
* W starszych wersjach, które obsługują poniższe metody konwersji, możesz konwertować [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) na [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) .
* Użyj metod [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) i [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (z klasy [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/) ) , aby konwertować między [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) a [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) .

## **Proste operacje edycji**

Użyj następujących metod do edycji ścieżki geometrycznej. Przeciążenia przyjmujące indeks wstawiają segment w tej zerowej pozycji w tablicy segmentów ścieżki.

| Operacja | Metoda |
| --- | --- |
| Dodaj lub wstaw prostą linię. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Dodaj lub wstaw krzywą Béziera stopnia trzeciego z dwoma punktami kontrolnymi i punktem końcowym. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Dodaj lub wstaw krzywą Béziera stopnia drugiego z jednym punktem kontrolnym i punktem końcowym. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Dodaj łuk eliptyczny o podanych wymiarach i kątach w stopniach. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Zamknij bieżącą figurę, łącząc jej punkt końcowy z punktem początkowym. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Ustaw punkt początkowy figury. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Usuń segment o zerowym indeksie. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Dodawanie własnych punktów do kształtu**

Ten przykład wstawia dwa punkty do prostokątnego kształtu przy użyciu [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) i stosuje edytowaną ścieżkę przy pomocy [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) . Współrzędne są lokalne względem kształtu: oba nowe punkty znajdują się w jego środku, 100 punktów od lewej i 50 punktów od góry. Indeksy segmentów 1 i 4 umieszczają je na górnej i dolnej krawędzi, ściągając te krawędzie do środka.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Usuwanie punktów z kształtu**

Ten przykład zmienia obrys w kształcie serca, usuwając segment o zerowym indeksie 2 przy pomocy [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) . Zastosowanie zmodyfikowanej ścieżki przy użyciu [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) aktualizuje kontur kształtu.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Tworzenie własnego kształtu**

Ten przykład tworzy pięcioramienną gwiazdę przy użyciu [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) . Alternujące promienie zewnętrzne i wewnętrzne o wartościach 100 i 50 punktów definiują końcówki i wcięcia; krok 72 stopni równomiernie rozmieszcza pięć końcówek. Ścieżka jest zamknięta przy pomocy [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) i zastosowana do prostokątnego kształtu za pomocą [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) , zastępując jego obrys.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **Tworzenie złożonego własnego kształtu**

Ten przykład definiuje dwa zamknięte obiekty [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) dla górnej i dolnej jednej trzeciej kształtu. Zastosowanie obu ścieżek przy użyciu [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) tworzy pojedynczy złożony kształt z przerwą w środkowej jednej trzeciej.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(0, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **Tworzenie własnego kształtu z zaokrąglonymi narożnikami**

Ten przykład łączy proste segmenty z [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) , tworząc kształt z wklęsłymi zaokrąglonymi narożnikami. Rozmiar każdego narożnika określa szerokość i wysokość łuku w punktach, a obrót -90 stopni rysuje przeciwnie do ruchu wskazówek zegara ćwiartkę elipsy. Gotowa ścieżka jest stosowana przy użyciu [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) , a prezentacja jest zapisywana w formacie PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Sprawdzenie, czy geometria kształtu jest zamknięta**

Poniższy pomocnik sprawdza, czy każda niepusta ścieżka geometryczna kończy się segmentem zamykającym. Odczytuje [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) i porównuje polecenie ostatniego segmentu [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) z [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/) . Zwraca false, gdy nie ma niepustych ścieżek. Sprawdza to końcowe polecenie każdej ścieżki; nie analizuje wszystkich podfigur w ścieżce. Przykład wypisuje `True` dla prostokąta.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **Wyodrębnianie i inspekcja elementów kształtu**

Użyj [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) , aby przejrzeć istniejący kształt jako elementy zawierające punkty ścieżki i typy punktów. Rzutuj każdy zwrócony [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) na [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) , aby odczytać jego tablice [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) i [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) . Ta reprezentacja jest przydatna do analizy obrysu lub przekazywania geometrii do własnych narzędzi rysujących.

Przykład otwiera prezentację, znajduje pierwszy kształt geometryczny bezpośrednio na pierwszym slajdzie i wypisuje jego segmenty ścieżki. Użyj prezentacji zawierającej kształt z segmentami prostymi i krzywymi, aby zobaczyć oba rodzaje wyników. Nie przeszukuje grup.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // Zachowaj typ segmentu, wyłączając flagi.
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // Consume both control points and the endpoint.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

Tablice odpowiadają sobie indeksami: `points[i]` jest punktem, a `types[i]` opisuje jego rolę. Typ `0` rozpoczyna figurę, a typ `1` rysuje linię od poprzedniego punktu do bieżącego. Segment krzywej Béziera trzeciego stopnia rozpoczyna się w poprzednim punkcie końcowym i używa trzech kolejnych wpisów typu `3`: dwa punkty kontrolne oraz nowy punkt końcowy. Pętla przetwarza te trzy wpisy razem i sprawdza punkt końcowy pod kątem zamknięcia.

Typy punktów zawierają także flagi. Maskuj przy użyciu `0x07`, aby zidentyfikować typ segmentu, oraz testuj osobno `0x80`, aby wykryć zamkniętą podścieżkę. Na przykład `129` (`0x81`) oznacza punkt końcowy linii, który zamyka podścieżkę, a `131` (`0x83`) oznacza punkt końcowy Béziera, który ją zamyka. Porównywanie surowej wartości tylko z `1` lub `3` pominęłoby te przypadki. Inne flagi, takie jak kreska (`0x10`) i znacznik (`0x20`), nie zmieniają podstawowego typu segmentu.

**Współrzędne i transformacje.**  
Punkty mierzone są w punktach (1/72 cala), przy czym X rośnie w prawo, a Y rośnie w dół. Dla niepogrupowanego kształtu wyodrębnione współrzędne już zawierają jego pozycję [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) i [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) oraz odzwierciedlają bieżącą szerokość i wysokość. Na przykład nieobrócony prostokąt w `(100, 200)` o rozmiarze `120 × 80` ma granice obrysu `(100, 200)`–`(220, 280)`. Nie dodawaj ponownie pozycji kształtu. Odejmij jego X i Y, aby uzyskać współrzędne względem nieobróconej ramki.

Wyodrębnione punkty nie uwzględniają [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) kształtu ani odbić poziomych i pionowych. Aby odtworzyć wyświetlany obrys, zastosuj te transformacje wokół środka kształtu. Dla pogrupowanych kształtów uwzględnij także mapowanie współrzędnych grupy i transformacje; nie zakładaj, że wyodrębnione punkty są ostatecznymi współrzędnymi wyświetlanymi na slajdzie ani nie stosuj podwójnie translacji lub skalowania, jeśli już zostały uwzględnione w ramce dziecka.

Inspekcja vs edycja.  
Wyodrębnione tablice opisują obrys; ich zmiana nie aktualizuje oryginalnego kształtu. Wybierz to podejście, gdy Twoja analiza lub kod rysujący potrzebuje tablic punktów/typów. Użyj [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) , gdy potrzebujesz poleceń geometrycznych w lokalnym układzie współrzędnych kształtu lub chcesz edytować jego geometrię. Zastosuj edytowane ścieżki za pomocą [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) lub [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) .

## **Konwersja GeometryPath do GraphicsPath (System.Drawing.Drawing2D)**

Poniższy przykład wymaga starszego zestawu Aspose.Slides for .NET, który obsługuje [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) , np. wersji 25.10, oraz środowiska Windows z `System.Drawing.Common`. Metody konwersji zostały usunięte w [wersji 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/) .

Ten przykład łączy prostokątny obrys z tekstem przekonwertowanym na geometrię. [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) obrysu jest ustawiony tak, aby wyłączyć wypełnienie. [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) przechowuje obrys tekstu, który [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) konwertuje na wypełnioną ścieżkę geometryczną. Zastosowanie obu ścieżek przy użyciu [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) tworzy pojedynczy kształt zawierający prostokąt i tekst. Do konwersji w odwrotnym kierunku użyj [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) .

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Co się stanie z wypełnieniem i obrysem po zamianie geometrii?**  
Styl pozostaje przypisany do kształtu; zmienia się tylko jego kontur. Wypełnienie i obrys są automatycznie stosowane do nowej geometrii.

**Jak prawidłowo obrócić własny kształt wraz z jego geometrią?**  
Użyj właściwości [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) kształtu; geometria obraca się razem z kształtem, ponieważ jest związana z jego własnym układem współrzędnych.

**Czy mogę przekonwertować własny kształt na obraz, aby „zablokować” wynik?**  
Tak. Wyeksportuj wymaganą [slide](/slides/pl/net/convert-powerpoint-to-png/) lub sam [shape](/slides/pl/net/create-shape-thumbnails/) do formatu rastrowego; ułatwia to dalszą pracę z złożonymi geometrjami.