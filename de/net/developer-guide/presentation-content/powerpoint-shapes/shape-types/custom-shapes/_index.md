---
title: Benutzerdefinierte Form
type: docs
weight: 20
url: /de/net/custom-shape/
keywords:
- Form
- benutzerdefinierte Form
- Form erstellen
- Geometrie
- Formgeometrie
- Geometriepfad
- Pfadpunkte
- Bearbeitungspunkte
- PowerPoint
- Präsentation
- C#
- Aspose.Slides für .NET
description: "Fügen Sie einer PowerPoint-Präsentation in .NET eine benutzerdefinierte Form hinzu"
---

## **Form mit Bearbeitungspunkten ändern**

Betrachten Sie ein Quadrat. In PowerPoint können Sie mit **Bearbeitungspunkten** 

* die Ecke des Quadrats nach innen oder außen verschieben
* die Krümmung einer Ecke oder eines Punkts festlegen
* neue Punkte zum Quadrat hinzufügen
* Punkte des Quadrats manipulieren usw. 

Im Wesentlichen können Sie die beschriebenen Aufgaben bei jeder Form ausführen. Mit Bearbeitungspunkten können Sie eine Form ändern oder aus einer bestehenden Form eine neue Form erstellen. 

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Bevor Sie mit der Bearbeitung von PowerPoint‑Formen über Bearbeitungspunkte beginnen, sollten Sie diese Punkte zu Formen berücksichtigen:

* Eine Form (oder ihr Pfad) kann geschlossen oder offen sein.
* Alle Formen bestehen aus mindestens 2 Ankerpunkten, die durch Linien miteinander verbunden sind.
* Eine Linie ist gerade oder kurvig. Ankerpunkte bestimmen die Art der Linie. 
* Ankerpunkte existieren als Eckpunkte, gerade Punkte oder glatte Punkte:
  * Ein Eckpunkt ist ein Punkt, an dem 2 gerade Linien unter einem Winkel zusammenlaufen. 
  * Ein glatter Punkt ist ein Punkt, an dem 2 Griffe in einer geraden Linie liegen und die Segmente der Linie in einer glatten Kurve zusammenlaufen. In diesem Fall sind alle Griffe vom Ankerpunkt aus in gleichem Abstand getrennt. 
  * Ein gerader Punkt ist ein Punkt, an dem 2 Griffe in einer geraden Linie liegen und die Segmente der Linie in einer glatten Kurve zusammenlaufen. In diesem Fall müssen die Griffe nicht in gleichem Abstand vom Ankerpunkt getrennt sein. 
* Durch Verschieben oder Bearbeiten von Ankerpunkten (was den Winkel der Linien ändert) können Sie das Aussehen einer Form ändern. 

Um PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) und das Interface [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath) bereit. 

* Eine [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath)-Instanz repräsentiert den Geometriepfad des Objekts [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape). 
* Um das `GeometryPath` aus der `IGeometryShape`‑Instanz abzurufen, können Sie die Methode [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths) verwenden. 
* Um das `GeometryPath` für eine Form festzulegen, können Sie diese Methoden verwenden: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) für *solide Formen* und [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) für *zusammengesetzte Formen*.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath) verwenden. 
* Mit den Eigenschaften [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) und [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode) können Sie das Erscheinungsbild eines Geometriepfads festlegen.
* Mit der Eigenschaft [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata) können Sie den Geometriepfad einer `GeometryShape` als Array von Pfadsegmenten abrufen. 
* Für zusätzliche Anpassungsoptionen zur Formgeometrie können Sie [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) in [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) konvertieren.
* Verwenden Sie die Methoden [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) und [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (aus der Klasse [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil)), um [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) in [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) hin und her zu konvertieren. 

## **Einfache Bearbeitungsoperationen**

Dieser C#‑Code zeigt, wie man

**Eine Linie** am Ende eines Pfads hinzufügt
``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```

**Eine Linie** an einer angegebenen Position im Pfad hinzufügt:
``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```

**Eine kubische Bézier‑Kurve** am Ende eines Pfads hinzufügt:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**Eine kubische Bézier‑Kurve** an einer angegebenen Position im Pfad hinzufügt:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```

**Eine quadratische Bézier‑Kurve** am Ende eines Pfads hinzufügt:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```

**Eine quadratische Bézier‑Kurve** an einer angegebenen Position im Pfad hinzufügt:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```

**Einen angegebenen Bogen** an einen Pfad anhängen:
``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**Die aktuelle Figur** eines Pfads schließen:
``` csharp
void CloseFigure();
```

**Die Position für den nächsten Punkt** festlegen:
``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```

**Das Pfadsegment** an einem angegebenen Index entfernen:
``` csharp
void RemoveAt(int index);
```


## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) und setzen Sie den Typ [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype).
2. Holen Sie sich eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) aus der Form.
3. Fügen Sie einen neuen Punkt zwischen den beiden oberen Punkten im Pfad hinzu.
4. Fügen Sie einen neuen Punkt zwischen den beiden unteren Punkten im Pfad hinzu.
5. Wenden Sie den Pfad auf die Form an.

Dieser C#‑Code zeigt, wie man benutzerdefinierte Punkte zu einer Form hinzufügt:
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

## **Punkte aus einer Form entfernen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) und setzen Sie den Typ [ShapeType.Heart](https://reference.aspose.com/slides/net/aspose.slides/shapetype).
2. Holen Sie sich eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) aus der Form.
3. Entfernen Sie das Segment aus dem Pfad.
4. Wenden Sie den Pfad auf die Form an.

Dieser C#‑Code zeigt, wie man Punkte aus einer Form entfernt:
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

## **Benutzerdefinierte Form erstellen**

1. Berechnen Sie die Punkte für die Form.
2. Erstellen Sie eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
3. Füllen Sie den Pfad mit den Punkten.
4. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
5. Wenden Sie den Pfad auf die Form an.

Dieser C#‑Code zeigt, wie man eine benutzerdefinierte Form erstellt:
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

## **Zusammengesetzte benutzerdefinierte Form erstellen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
2. Erstellen Sie eine erste Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
3. Erstellen Sie eine zweite Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath).
4. Wenden Sie die Pfade auf die Form an.

Dieser C#‑Code zeigt, wie man eine zusammengesetzte benutzerdefinierte Form erstellt:
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

## **Benutzerdefinierte Form mit abgerundeten Ecken erstellen**

Dieser C#‑Code zeigt, wie man eine benutzerdefinierte Form mit abgerundeten Ecken (nach innen) erstellt:
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


## **Überprüfen, ob eine Formgeometrie geschlossen ist**

Eine geschlossene Form ist definiert als eine, bei der alle Seiten miteinander verbunden sind und eine einzige Grenze ohne Lücken bilden. Eine solche Form kann eine einfache geometrische Form oder ein komplexes benutzerdefiniertes Umriss sein. Der folgende Beispielcode zeigt, wie man prüft, ob eine Formgeometrie geschlossen ist:
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


## **GeometryPath in GraphicsPath (System.Drawing.Drawing2D) konvertieren**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).
2. Erstellen Sie eine Instanz der Klasse [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) aus dem Namespace [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. Konvertieren Sie die [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0)-Instanz mithilfe von [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil) in eine [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath)-Instanz.
4. Wenden Sie die Pfade auf die Form an.

Dieser C#‑Code – eine Implementierung der obigen Schritte – demonstriert den Konvertierungsprozess **GeometryPath** zu **GraphicsPath**:
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

**Was passiert mit der Füllung und Kontur, nachdem die Geometrie ersetzt wurde?**

Der Stil bleibt an der Form erhalten; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie drehe ich eine benutzerdefinierte Form zusammen mit ihrer Geometrie korrekt?**

Verwenden Sie die [rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/)‑Eigenschaft der Form; die Geometrie rotiert mit der Form, weil sie an das Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis „einzusperren“?**

Ja. Exportieren Sie den gewünschten [slide](/slides/de/net/convert-powerpoint-to-png/)-Abschnitt oder die [shape](/slides/de/net/create-shape-thumbnails/)-Selbst in ein Rasterformat; das vereinfacht die weitere Arbeit mit komplexen Geometrien.