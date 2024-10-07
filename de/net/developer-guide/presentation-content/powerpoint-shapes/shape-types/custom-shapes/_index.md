---
title: Benutzerdefinierte Form
type: docs
weight: 20
url: /net/custom-shape/
keywords: 
- Form
- benutzerdefinierte Form
- Form erstellen
- Geometrie
- Formgeometrie
- Geometriepunkte
- Pfadpunkte
- Punkte bearbeiten
- PowerPoint
- Präsentation
- C#
- Aspose.Slides für .NET
description: "Fügen Sie einer PowerPoint-Präsentation in .NET eine benutzerdefinierte Form hinzu"
---

## Ändern einer Form mit Bearbeitungspunkten

Betrachten Sie ein Quadrat. In PowerPoint können Sie mit **Bearbeitungspunkten** 

* die Ecke des Quadrats nach innen oder außen bewegen
* die Krümmung für eine Ecke oder einen Punkt festlegen
* neue Punkte zum Quadrat hinzufügen
* Punkte auf dem Quadrat manipulieren usw. 

Im Wesentlichen können Sie die beschriebenen Aufgaben an jeder Form ausführen. Mit Bearbeitungspunkten können Sie eine Form ändern oder eine neue Form aus einer vorhandenen Form erstellen. 

## **Tipps zum Bearbeiten von Formen**

![overview_image](custom_shape_0.png)

Bevor Sie beginnen, PowerPoint-Formen über Bearbeitungspunkte zu bearbeiten, sollten Sie diese Punkte zu Formen in Betracht ziehen:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Alle Formen bestehen aus mindestens 2 Ankerpunkten, die durch Linien miteinander verbunden sind.
* Eine Linie ist entweder gerade oder gekrümmt. Ankerpunkte bestimmen die Natur der Linie. 
* Ankerpunkte gibt es als Eckenpunkte, gerade Punkte oder glatte Punkte:
  * Ein Eckpunkt ist ein Punkt, an dem sich 2 gerade Linien in einem Winkel treffen. 
  * Ein glatter Punkt ist ein Punkt, an dem 2 Griffe in einer geraden Linie vorhanden sind und die Liniensegmente in einer glatten Kurve zusammenlaufen. In diesem Fall sind alle Griffe von dem Ankerpunkt durch einen gleichen Abstand getrennt. 
  * Ein gerader Punkt ist ein Punkt, an dem 2 Griffe in einer geraden Linie vorhanden sind und die Liniensegmente dieser Linie in einer glatten Kurve zusammenlaufen. In diesem Fall müssen die Griffe nicht durch einen gleichen Abstand vom Ankerpunkt getrennt sein. 
* Durch Verschieben oder Bearbeiten von Ankerpunkten (was den Winkel der Linien ändert) können Sie das Aussehen einer Form ändern. 

Um PowerPoint-Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) Klasse und das [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath) Interface bereit. 

* Eine [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) Instanz repräsentiert einen Geometriep path des [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape) Objekts. 
* Um den `GeometryPath` von der `IGeometryShape` Instanz abzurufen, können Sie die [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths) Methode verwenden. 
* Um den `GeometryPath` für eine Form festzulegen, können Sie diese Methoden verwenden: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) für *feste Formen* und [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) für *komplexe Formen*.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath) verwenden. 
* Mit den [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) und [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode) Eigenschaften können Sie das Aussehen für einen Geometriep path festlegen.
* Mit der [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata) Eigenschaft können Sie den Geometriep path einer `GeometryShape` als Array von P 测段en abrufen. 
* Um auf zusätzliche Anpassungsoptionen für die Formgeometrie zuzugreifen, können Sie [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) in [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) umwandeln.
* Verwenden Sie die Methoden [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) und [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (aus der [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil) Klasse), um [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) in [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) und umgekehrt umzuwandeln. 

## **Einfache Bearbeitungsoperationen**

Dieser C# Code zeigt Ihnen, wie man

**Eine Linie** an das Ende eines Pfades hinzufügen kann

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Eine Linie** an einer bestimmten Position auf einem Pfad hinzufügen:

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Eine kubische Bezierkurve** am Ende eines Pfades hinzufügen:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Eine kubische Bezierkurve** an der angegebenen Position auf einem Pfad hinzufügen:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Eine quadratische Bezierkurve** am Ende eines Pfades hinzufügen:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Eine quadratische Bezierkurve** an einer bestimmten Position auf einem Pfad hinzufügen:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Einen bestimmten Bogen** zu einem Pfad hinzufügen:

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Die aktuelle Figur** eines Pfades schließen:

``` csharp
void CloseFigure();
```
**Die Position für den nächsten Punkt** festlegen:

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Das Pfadsegment** an einem bestimmten Index entfernen:

``` csharp
void RemoveAt(int index);
```

## **Benutzerdefinierte Punkte zur Form hinzufügen**

1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) Klasse und setzen Sie den [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype) Typ.
2. Holen Sie sich eine Instanz der [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) Klasse von der Form.
3. Fügen Sie einen neuen Punkt zwischen den beiden oberen Punkten auf dem Pfad hinzu.
4. Fügen Sie einen neuen Punkt zwischen den beiden unteren Punkten auf dem Pfad hinzu.
5. Wenden Sie den Pfad auf die Form an.

Dieser C# Code zeigt Ihnen, wie Sie benutzerdefinierte Punkte zu einer Form hinzufügen können:

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

##  **Punkte von der Form entfernen**

1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) Klasse und setzen Sie den [ShapeType.Heart](https://reference.aspose.com/slides/net/aspose.slides/shapetype) Typ. 
2. Holen Sie sich eine Instanz der [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) Klasse von der Form.
3. Entfernen Sie das Segment für den Pfad.
4. Wenden Sie den Pfad auf die Form an.

Dieser C# Code zeigt Ihnen, wie Sie Punkte von einer Form entfernen können:

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

##  **Benutzerdefinierte Form erstellen**

1. Berechnen Sie die Punkte für die Form.
2. Erstellen Sie eine Instanz der [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) Klasse. 
3. Füllen Sie den Pfad mit den Punkten.
4. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) Klasse. 
5. Wenden Sie den Pfad auf die Form an.

Dieser C# zeigt Ihnen, wie Sie eine benutzerdefinierte Form erstellen können:

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

## **Erstellen Sie eine komplexe benutzerdefinierte Form**

  1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) Klasse.
  2. Erstellen Sie eine erste Instanz der [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) Klasse.
  3. Erstellen Sie eine zweite Instanz der [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) Klasse.
  4. Wenden Sie die Pfade auf die Form an.

Dieser C# Code zeigt Ihnen, wie Sie eine komplexe benutzerdefinierte Form erstellen:

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

## **Erstellen Sie eine benutzerdefinierte Form mit abgerundeten Ecken**

Dieser C# Code zeigt Ihnen, wie Sie eine benutzerdefinierte Form mit abgerundeten Ecken (nach innen) erstellen können:

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

## **Feststellen, ob die Geometrie einer Form geschlossen ist**

Zu überprüfen, ob eine Form in einer PowerPoint-Präsentation geschlossen ist, kann entscheidend für die korrekte Anzeige und Bearbeitung von Objekten in Folien sein. Eine geschlossene Form ist definiert als eine, bei der alle ihre Seiten verbunden sind, um eine einzelne Grenze ohne Lücken zu bilden. Eine solche Form kann eine einfache geometrische Form oder eine komplexe benutzerdefinierte Kontur sein.

Die Geschlossenheit einer Form ist wichtig für das Ausführen verschiedener Operationen, wie das Füllen mit Farbe oder Verlauf, das Anwenden von Effekten und Transformationen sowie das Sicherstellen der ordnungsgemäßen Interaktion mit anderen Folienelementen.

Um zu überprüfen, ob die Geometrie einer Form geschlossen ist, müssen Sie Folgendes tun:
1. Zugriff auf die Geometrie der Form erhalten.
2. Die Geometriep paths in der Form auflisten.
    2.1. Holen Sie sich das letzte Segment des nächsten Pfades.
    2.2. Überprüfen, ob das letzte Segment der `CLOSE` Befehl ist.

Das folgende Codebeispiel zeigt, wie dies geht:

```cs
if (shape is GeometryShape geometryShape)
{
    for (int i = 0; i < geometryShape.GetGeometryPaths().Length; i++)
    {
        IGeometryPath path = geometryShape.GetGeometryPaths()[i];

        if (path.PathData.Length == 0) continue;

        IPathSegment lastSegment = path.PathData[path.PathData.Length - 1];
        bool isClosed = lastSegment.PathCommand == PathCommandType.Close;
        
        Console.WriteLine($"Pfad {i} ist geschlossen: {isClosed}");
    }
}
```

## **GeometryPath in GraphicsPath (System.Drawing.Drawing2D) umwandeln** 

1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) Klasse.
2. Erstellen Sie eine Instanz der [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) Klasse des [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) Namensraums.
3. Wandeln Sie die Instanz von [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) in die Instanz von [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) unter Verwendung von [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil) um.
4. Wenden Sie die Pfade auf die Form an.

Dieser C# Code—eine Implementierung der oben beschriebenen Schritte—zeigt den **GeometryPath** zu **GraphicsPath** Umwandlungsprozess:

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