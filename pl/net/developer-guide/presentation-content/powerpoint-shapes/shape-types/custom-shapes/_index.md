---
title: Dostosuj kształty prezentacji w .NET
linktitle: Własny kształt
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
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint za pomocą Aspose.Slides dla .NET: ścieżki geometryczne, zaokrąglone rogi, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty w prezentacji w Aspose.Slides, edytując geometrię kształtu za pomocą punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) i [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) w celu modyfikacji istniejących kształtów, wykonywania podstawowych operacji edycji ścieżek, dodawania lub usuwania punktów oraz zastosowania zaktualizowanej geometrii do kształtu.

Demonstruje również, jak tworzyć własne i złożone kształty, budować kształty z zaokrąglonymi rogami, określać, czy geometria kształtu jest zamknięta, oraz korzystać z konwersji legacy między [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) a [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) w dodatkowych scenariuszach dostosowywania geometrii.

## **Zmiana kształtu przy użyciu punktów edycji**

W PowerPoint możesz używać **Edit Points**, aby modyfikować kwadrat:

* Przesunąć róg do środka lub na zewnątrz.
* Dostosować krzywiznę w punkcie.
* Dodać nowe punkty.

Edycja punktów pozwala zmienić obrys kształtu lub użyć istniejącego kształtu jako podstawy nowego.

## **Wskazówki dotyczące edycji kształtów**

![obrazek_przeglądowy](custom_shape_0.png)

Podczas edycji kształtów w PowerPoint pamiętaj o następujących pojęciach:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Ścieżka kształtu składa się z punktów kotwiczących połączonych segmentami.
* Segment może być prosty lub krzywy. Punkty kotwiczące i uchwyty kontrolne określają jego kształt.
* Punkty kotwiczące występują jako punkty narożne, proste lub gładkie:
  * W punkcie narożnym łączące się segmenty mogą spotkać się pod kątem.
  * W punkcie gładkim dwa uchwyty kontrolne są wyrównane i znajdują się w równej odległości od punktu kotwiczącego.
  * W punkcie prostym dwa uchwyty kontrolne są wyrównane, ale mogą mieć różne odległości od punktu kotwiczącego.
* Przesuwanie punktów kotwiczących lub regulowanie ich uchwytów zmienia obrys kształtu.

Aby edytować kształty w PowerPoint za pomocą punktów edycji, **Aspose.Slides** udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) oraz interfejs [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Instancja [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Aby uzyskać [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) z instancji [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), możesz użyć metody [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) dla kształtu, możesz użyć metod: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) dla kształtów z jedną ścieżką oraz [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) dla kształtów z wieloma ścieżkami.
* Aby dodać segmenty, możesz używać metod dostępnych w [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* Korzystając z właściwości [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) i [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/), możesz ustawić wygląd ścieżki geometrycznej.
* Dzięki właściwości [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) możesz pobrać ścieżkę geometryczną [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) jako tablicę segmentów ścieżki.
* W starszych wersjach, które obsługują poniższe metody konwersji, możesz przekonwertować [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) na [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Użyj metod [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) i [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (z klasy [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) do konwersji między [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) a [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Proste operacje edycji**

Użyj następujących metod do edycji ścieżki geometrycznej. Przeciążenia przyjmujące indeks wstawiają segment na tej zeroodstawowej pozycji w tablicy segmentów ścieżki.

| Operacja | Metoda |
| --- | --- |
| Dodaj lub wstaw prostą linię. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Dodaj lub wstaw krzywą Béziera trzeciego stopnia z dwoma punktami kontrolnymi i punktem końcowym. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Dodaj lub wstaw krzywą Béziera drugiego stopnia z jednym punktem kontrolnym i punktem końcowym. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Dodaj łuk eliptyczny o podanych wymiarach i kątach w stopniach. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Zamknij bieżącą figurę, łącząc jej punkt końcowy z punktem początkowym. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Ustaw punkt początkowy figury. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Usuń segment pod zeroodstawowym indeksem. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Dodawanie własnych punktów do kształtu**

Ten przykład wstawia dwa punkty do prostokątnego kształtu przy użyciu [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) i zastosowuje edytowaną ścieżkę za pomocą [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Współrzędne są lokalne względem kształtu: oba nowe punkty znajdują się w jego centrum, 100 punktów od lewej i 50 punktów od góry. Indeksy segmentów 1 i 4 umieszczają je na górnej i dolnej krawędzi, przyciągając te krawędzie do środka.

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

![obrazek_przykład1](custom_shape_1.png)

## **Usuwanie punktów z kształtu**

Ten przykład modyfikuje obrys serca, usuwając segment o zeroodstawowym indeksie 2 przy użyciu [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Zastosowanie zmodyfikowanej ścieżki za pomocą [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) aktualizuje kontur kształtu.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![obrazek_przykład2](custom_shape_2.png)

## **Tworzenie własnego kształtu**

Ten przykład buduje pięcioramienną gwiazdę przy użyciu [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Naprzemienne promienie zewnętrzne i wewnętrzne o wartościach 100 i 50 punktów definiują szczyty i wgłębienia; krok 72 stopni równomiernie rozmieszcza pięć szczytów. Ścieżka jest zamykana metodą [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) i stosowana do prostokątnego kształtu przy użyciu [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), zastępując jego obrys.

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
![obrazek_przykład3](custom_shape_3.png)

## **Tworzenie złożonego własnego kształtu**

Ten przykład definiuje dwa zamknięte obiekty [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) dla górnej i dolnej trzeciej części kształtu. Zastosowanie obu ścieżek za pomocą [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) tworzy pojedynczy złożony kształt z przerwą w środkowej trzeciej części.

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
bottomPath.MoveTo(shape.Height / 3 * 2, 0);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![obrazek_przykład4](custom_shape_4.png)

## **Tworzenie własnego kształtu z zaokrąglonymi rogami**

Ten przykład łączy proste segmenty z [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/), aby utworzyć kształt z wklęsłymi rogami. Rozmiar każdego rogu określa szerokość i wysokość łuku w punktach, a kąt -90 stopni rysuje przeciwzegarowy ćwiartkowy elipsę. Gotowa ścieżka jest stosowana przy użyciu [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), a prezentacja jest zapisywana w formacie PPTX.

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

## **Sprawdzanie, czy geometria kształtu jest zamknięta**

Poniższy pomocniczy kod sprawdza, czy każda niepusta ścieżka geometryczna kończy się segmentem zamykającym. Odczytuje [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) i porównuje polecenie ostatniego segmentu [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) z [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Zwraca false, gdy nie ma niepustych ścieżek. Sprawdza końcowe polecenie każdej ścieżki; nie analizuje każdej podfigury wewnątrz ścieżki. Przykład wypisuje `True` dla prostokąta.

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

## **Inspekcja poleceń ścieżki geometrycznej**

Pobierz plik [contour.pptx](contour.pptx) i umieść go w katalogu roboczym aplikacji. Na pierwszym slajdzie znajduje się kształt z prostą górną krawędzią, krzywą Béziera trzeciego stopnia i prostą krawędzią zamykającą. Użyj [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) aby odczytać jego ścieżki. Każda ścieżka wymienia swoje segmenty w kolejności rysowania w [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/). Polecenie każdego segmentu, [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/), określa, jak odczytać jego [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("contour.pptx");

var shape = (IGeometryShape)presentation.Slides[0].Shapes[0];
var paths = shape.GetGeometryPaths();

for (int i = 0; i < paths.Length; i++)
{
    var segments = paths[i].PathData;
    for (int j = 0; j < segments.Length; j++)
    {
        var command = segments[j].PathCommand;
        var data = segments[j].SegmentData;
        var detail = command switch
        {
            PathCommandType.MoveTo or PathCommandType.LineTo => $"destination=({data[0]}, {data[1]})",
            PathCommandType.CubicBezierTo => $"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})",
            PathCommandType.Close => "no coordinates",
            _ => $"raw=[{string.Join(", ", data)}]"
        };
        Console.WriteLine($"Path {i}, segment {j}: {command} {detail}");
    }
}
```

Kształt znajduje się w położeniu (200, 100) punktów na slajdzie. Zgłoszone współrzędne są lokalne względem kształtu, przy (0, 0) w jego lewym górnym rogu, przy czym x rośnie w prawo, a y w dół. Segment zamykający powraca do punktu początkowego bez dodatkowych współrzędnych.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![Kształt PowerPoint z prostą górną krawędzią, zakrzywioną krawędzią od prawego górnego do lewego dolnego oraz prostą lewą krawędzią](contour.png)

## **Wyodrębnianie i inspekcja elementów kształtu**

Użyj [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) aby przeanalizować istniejący kształt jako elementy zawierające punkty ścieżki i typy punktów. Rzutuj każdy zwrócony [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) na [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/), aby odczytać jego tablice [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) i [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Taka reprezentacja jest przydatna do analizy konturu lub przekazywania geometrii do własnych narzędzi rysunkowych.

Przykład otwiera prezentację, znajduje pierwszy geometryczny kształt bezpośrednio na pierwszym slajdzie i wypisuje jego segmenty ścieżki. Użyj prezentacji zawierającej kształt z prostymi i zakrzywionymi segmentami, aby zobaczyć oba rodzaje wyjścia. Nie przeszukuje grup.

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
        var pointType = types[i] & 0x07; // Zachowaj typ segmentu, pomijając flagi.
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
                i += 2; // Zużyj oba punkty kontrolne i punkt końcowy.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

Tablice są powiązane indeksami: `points[i]` to punkt, a `types[i]` opisuje jego rolę. Typ `0` rozpoczyna figurę, a typ `1` rysuje linię od poprzedniego punktu do bieżącego. Segment Béziera trzeciego stopnia zaczyna się w poprzednim punkcie końcowym i używa trzech kolejnych wpisów typu `3`: dwóch punktów kontrolnych i nowego punktu końcowego. Pętla konsoliduje te trzy wpisy i sprawdza punkt końcowy pod kątem zamknięcia.

Typy punktów zawierają również flagi. Maskuj wartość `0x07`, aby określić typ segmentu, oraz testuj `0x80` oddzielnie, aby wykryć zamkniętą podścieżkę. Na przykład `129` (`0x81`) oznacza punkt końcowy linii zamykający podścieżkę, a `131` (`0x83`) oznacza punkt końcowy Béziera zamykający podścieżkę. Porównywanie surowej wartości tylko z `1` lub `3` pominęłoby te przypadki. Inne flagi, takie jak kreska (`0x10`) i znacznik (`0x20`), nie zmieniają podstawowego typu segmentu.

**Współrzędne i przekształcenia.** Punkty są mierzone w punktach (1/72 cala), przy czym X rośnie w prawo, a Y w dół. Dla niezgroupowanego kształtu wyodrębnione współrzędne już zawierają jego pozycję [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) i [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) oraz odzwierciedlają aktualną szerokość i wysokość. Na przykład nieobrócony prostokąt w `(100, 200)` o rozmiarze `120 × 80` ma granice konturu `(100, 200)`–`(220, 280)`. Nie dodawaj ponownie pozycji kształtu. Odejmij jego X i Y, aby uzyskać współrzędne względem jego nieobróconej ramki.

Wyodrębnione punkty nie uwzględniają [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) kształtu ani odbić poziomego i pionowego. Aby odtworzyć wyświetlany kontur, zastosuj te przekształcenia wokół środka kształtu. Dla zgrupowanych kształtów uwzględnij także mapowanie współrzędnych grupy i przekształcenia; nie zakładaj, że wyodrębnione punkty są ostatecznymi współrzędnymi slajdu ani nie stosuj podwójnych translacji lub skal, jeśli już są odzwierciedlone w ramce dziecka.

**Inspekcja vs. edycja.** Wyodrębnione tablice opisują kontur; ich modyfikacja nie aktualizuje oryginalnego kształtu. Wybierz to podejście, gdy Twoja analiza lub kod rysujący potrzebuje tablic punktów/typów. Użyj [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/), gdy potrzebujesz poleceń geometrycznych w lokalnym układzie współrzędnych kształtu lub chcesz edytować jego geometrię. Zastosuj edytowane ścieżki poprzez [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) lub [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Konwersja GeometryPath do GraphicsPath (System.Drawing.Drawing2D)**

Poniższy przykład wymaga starszego zestawu Aspose.Slides for .NET, który obsługuje [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), np. wersji 25.10, oraz środowiska Windows z `System.Drawing.Common`. Metody konwersji zostały usunięte w [wersji 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Ten przykład łączy prostokątny obrys z tekstem przekonwertowanym na geometrię. Właściwość [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) obrysu jest ustawiona na wyłączenie wypełnienia. [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) przechowuje obrys tekstu, który [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) konwertuje na wypełnioną ścieżkę geometryczną. Zastosowanie obu ścieżek za pomocą [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) tworzy pojedynczy kształt zawierający prostokąt i tekst. Do konwersji w odwrotnym kierunku użyj [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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
![obrazek_przykład5](custom_shape_5.png)

## **FAQ**

**Co się stanie z wypełnieniem i obrysem po zastąpieniu geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się tylko kontur. Wypełnienie i obrys są automatycznie stosowane do nowej geometrii.

**Jak prawidłowo obrócić własny kształt razem z jego geometrią?**

Użyj właściwości [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) kształtu; geometria obraca się razem z kształtem, ponieważ jest związana z jego własnym układem współrzędnych.

**Czy mogę przekonwertować własny kształt na obraz, aby „zablokować” wynik?**

Tak. Wyeksportuj wybrany [slide](/slides/pl/net/convert-powerpoint-to-png/) lub sam [shape](/slides/pl/net/create-shape-thumbnails/) do formatu rastrowego; upraszcza to dalszą pracę z złożonymi geometriami.