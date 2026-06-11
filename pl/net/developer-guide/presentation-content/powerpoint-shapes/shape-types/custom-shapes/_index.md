---
title: Dostosuj kształty prezentacji w .NET
linktitle: Niestandardowy kształt
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
- punkty edycji
- dodaj punkt
- usuń punkt
- operacja edycji
- zaokrąglony róg
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET: ścieżki geometryczne, zaokrąglone rogi, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty w prezentacji w Aspose.Slides, edytując geometrię kształtu za pomocą punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z `GeometryPath` i `IGeometryPath`, aby modyfikować istniejące kształty, wykonywać podstawowe operacje edycji ścieżki, dodawać lub usuwać punkty oraz zastosować zaktualizowaną geometrię z powrotem do kształtu.

Pokazuje również, jak tworzyć niestandardowe i złożone kształty, budować kształty z zaokrąglonymi narożnikami, określać, czy geometria kształtu jest zamknięta, oraz konwertować między `GeometryPath` a `GraphicsPath` w dodatkowych scenariuszach dostosowywania geometrii.

## **Zmienianie kształtu za pomocą punktów edycji**

Rozważmy kwadrat. W programie PowerPoint, używając **punktów edycji**, możesz
* przesunąć róg kwadratu do środka lub na zewnątrz
* określić krzywiznę rogu lub punktu
* dodać nowe punkty do kwadratu
* manipulować punktami na kwadracie itd.

Zasadniczo możesz wykonywać opisane czynności na dowolnym kształcie. Korzystając z punktów edycji, możesz zmienić kształt lub utworzyć nowy kształt z istniejącego.

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Zanim rozpoczniesz edycję kształtów PowerPoint za pomocą punktów edycji, warto rozważyć następujące kwestie dotyczące kształtów:
* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Wszystkie kształty składają się z co najmniej 2 punktów kotwiczących połączonych ze sobą liniami.
* Linia może być prosta lub krzywa. Punkty kotwiczące określają charakter linii.
* Punkty kotwiczące występują jako punkty narożne, proste lub płynne:
  * Punkt narożny to punkt, w którym dwie proste linie łączą się pod kątem.
  * Punkt płynny to punkt, w którym dwa uchwyty znajdują się na jednej prostej, a odcinki linii łączą się w płynną krzywą. W tym przypadku wszystkie uchwyty są oddalone od punktu kotwiczącego o równą odległość.
  * Punkt prosty to punkt, w którym dwa uchwyty znajdują się na jednej prostej, a odcinki tej linii łączą się w płynną krzywą. W tym przypadku uchwyty nie muszą być oddalone od punktu kotwiczącego o równą odległość.
* Przesuwając lub edytując punkty kotwiczące (co zmienia kąt linii), możesz zmienić wygląd kształtu.

Aby edytować kształty PowerPoint za pomocą punktów edycji, **Aspose.Slides** udostępnia klasę [**GeometryPath**](https://reference.aspose.com/slides/pl/net/aspose.slides/geometrypath) oraz interfejs [**IGeometryPath**](https://reference.aspose.com/slides/pl/net/aspose.slides/igeometrypath).
* Instancja [GeometryPath](https://reference.aspose.com/slides/pl/net/aspose.slides/geometrypath) reprezentuje ścieżkę geometryczną obiektu [IGeometryShape](https://reference.aspose.com/slides/pl/net/aspose.slides/igeometryshape).
* Aby pobrać `GeometryPath` z instancji `IGeometryShape`, możesz użyć metody [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/pl/net/aspose.slides/igeometryshape/methods/getgeometrypaths).
* Aby ustawić `GeometryPath` dla kształtu, możesz użyć następujących metod: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/pl/net/aspose.slides/igeometryshape/methods/setgeometrypath) dla *kształtów stałych* oraz [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/pl/net/aspose.slides/igeometryshape/methods/setgeometrypaths) dla *kształtów złożonych*.
* Aby dodać segmenty, możesz użyć metod dostępnych w [IGeometryPath](https://reference.aspose.com/slides/pl/net/aspose.slides/igeometrypath).
* Korzystając z właściwości [IGeometryPath.Stroke](https://reference.aspose.com/slides/pl/net/aspose.slides/igeometrypath/properties/stroke) i [IGeometryPath.FillMode](https://reference.aspose.com/slides/pl/net/aspose.slides/igeometrypath/properties/fillmode), możesz ustawić wygląd ścieżki geometrycznej.
* Używając właściwości [IGeometryPath.PathData](https://reference.aspose.com/slides/pl/net/aspose.slides/igeometrypath/properties/pathdata), możesz pobrać ścieżkę geometryczną `GeometryShape` jako tablicę segmentów ścieżki.
* Aby uzyskać dostęp do dodatkowych opcji dostosowywania geometrii kształtu, możesz konwertować [GeometryPath](https://reference.aspose.com/slides/pl/net/aspose.slides/geometrypath) na [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
* Użyj metod [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/pl/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) i [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/pl/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (z klasy [ShapeUtil](https://reference.aspose.com/slides/pl/net/aspose.slides.util/shapeutil)), aby konwertować [GeometryPath](https://reference.aspose.com/slides/pl/net/aspose.slides/geometrypath) na [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) i odwrotnie.

## **Proste operacje edycji**

Ten kod C# pokazuje, jak
**Dodaj linię** na końcu ścieżki
``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Dodaj linię** do określonej pozycji na ścieżce:
``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Dodaj krzywą Beziera stopnia trzeciego** na końcu ścieżki:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Dodaj krzywą Beziera stopnia trzeciego** do określonej pozycji na ścieżce:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Dodaj krzywą Beziera stopnia drugiego** na końcu ścieżki:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Dodaj krzywą Beziera stopnia drugiego** do określonej pozycji na ścieżce:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Dołącz dany łuk** do ścieżki:
``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Zamknij bieżącą figurę** ścieżki:
``` csharp
void CloseFigure();
```
**Ustaw pozycję dla następnego punktu**:
``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Usuń segment ścieżki** o podanym indeksie:
``` csharp
void RemoveAt(int index);
```

## **Dodaj własne punkty do kształtu**

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/net/aspose.slides/geometryshape) i ustaw typ [ShapeType.Rectangle](https://reference.aspose.com/slides/pl/net/aspose.slides/shapetype).
2. Pobierz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/net/aspose.slides/geometrypath) z kształtu.
3. Dodaj nowy punkt pomiędzy dwoma górnymi punktami na ścieżce.
4. Dodaj nowy punkt pomiędzy dwoma dolnymi punktami na ścieżce.
5. Zastosuj ścieżkę do kształtu.

Ten kod C# pokazuje, jak dodać własne punkty do kształtu:
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```

![example1_image](custom_shape_1.png)

##  **Usuń punkty z kształtu**

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/net/aspose.slides/geometryshape) i ustaw typ [ShapeType.Heart](https://reference.aspose.com/slides/pl/net/aspose.slides/shapetype).
2. Pobierz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/net/aspose.slides/geometrypath) z kształtu.
3. Usuń segment ścieżki.
4. Zastosuj ścieżkę do kształtu.

Ten kod C# pokazuje, jak usunąć punkty z kształtu:
``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```

![example2_image](custom_shape_2.png)

##  **Utwórz własny kształt**

1. Oblicz punkty dla kształtu.
2. Utwórz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/net/aspose.slides/geometrypath).
3. Wypełnij ścieżkę punktami.
4. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/net/aspose.slides/geometryshape).
5. Zastosuj ścieżkę do kształtu.

Ten kod C# pokazuje, jak utworzyć własny kształt:
``` csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```

![example3_image](custom_shape_3.png)

## **Utwórz złożony własny kształt**

  1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/net/aspose.slides/geometryshape).
  2. Utwórz pierwszą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/net/aspose.slides/geometrypath).
  3. Utwórz drugą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/net/aspose.slides/geometrypath).
  4. Zastosuj ścieżki do kształtu.

Ten kod C# pokazuje, jak utworzyć złożony własny kształt:
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```

![example4_image](custom_shape_4.png)

## **Utwórz własny kształt z zaokrąglonymi narożnikami**

Ten kod C# pokazuje, jak utworzyć własny kształt z zaokrąglonymi narożnikami (do wewnątrz);
```c#
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Sprawdź, czy geometria kształtu jest zamknięta**

Zamknięty kształt definiuje się jako taki, w którym wszystkie jego boki łączą się, tworząc jedną granicę bez przerw. Taki kształt może być prostą formą geometryczną lub złożonym, niestandardowym konturem. Poniższy przykład kodu pokazuje, jak sprawdzić, czy geometria kształtu jest zamknięta:
```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```

## **Konwertuj GeometryPath na GraphicsPath (System.Drawing.Drawing2D)**

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/net/aspose.slides/geometryshape).
2. Utwórz instancję klasy [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) z przestrzeni nazw [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. Skonwertuj instancję [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) na instancję [GeometryPath](https://reference.aspose.com/slides/pl/net/aspose.slides/geometrypath) przy użyciu [ShapeUtil](https://reference.aspose.com/slides/pl/net/aspose.slides.util/shapeutil).
4. Zastosuj ścieżki do kształtu.

Ten kod C# — implementacja powyższych kroków — demonstruje proces konwersji **GeometryPath** na **GraphicsPath**:
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**Co się stanie z wypełnieniem i obrysem po zastąpieniu geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się jedynie kontur. Wypełnienie i obrys są automatycznie stosowane do nowej geometrii.

**Jak prawidłowo obrócić własny kształt wraz z jego geometrią?**

Użyj właściwości [rotation](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/rotation/) kształtu; geometria obraca się wraz z kształtem, ponieważ jest związana z własnym układem współrzędnych kształtu.

**Czy mogę przekonwertować własny kształt na obraz, aby „zablokować” wynik?**

Tak. Wyeksportuj wymaganą [slide](/slides/pl/net/convert-powerpoint-to-png/) (obszar) lub sam [shape](/slides/pl/net/create-shape-thumbnails/) do formatu rastrowego; ułatwia to dalszą pracę z złożonymi geometriami.