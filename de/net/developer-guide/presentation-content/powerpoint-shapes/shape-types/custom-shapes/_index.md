---
title: Formen in .NET anpassen
linktitle: Benutzerdefinierte Form
type: docs
weight: 20
url: /de/net/custom-shape/
keywords:
- benutzerdefinierte Form
- Form hinzufügen
- Form erstellen
- Form ändern
- Formgeometrie
- Geometriepfad
- Pfadpunkte
- Bearbeitungspunkte
- Punkt hinzufügen
- Punkt entfernen
- Bearbeitungsoperation
- abgerundete Ecke
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen und anpassen von Formen in PowerPoint-Präsentationen mit Aspose.Slides für .NET: Geometriepfade, abgerundete Ecken, zusammengesetzte Formen."
---

## **Form mithilfe von Bearbeitungspunkten ändern**

Betrachten Sie ein Quadrat. In PowerPoint können Sie mit **Bearbeitungspunkten**  

* die Ecke des Quadrats nach innen oder außen verschieben  
* die Krümmung einer Ecke oder eines Punktes festlegen  
* neue Punkte zum Quadrat hinzufügen  
* Punkte auf dem Quadrat manipulieren usw.  

Im Wesentlichen können Sie die beschriebenen Vorgänge an jeder Form durchführen. Mit Bearbeitungspunkten können Sie eine Form ändern oder aus einer vorhandenen Form eine neue Form erstellen. 

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Bevor Sie beginnen, PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, sollten Sie folgende Punkte zu Formen beachten:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.  
* Alle Formen bestehen aus mindestens 2 Ankerpunkten, die durch Linien miteinander verbunden sind.  
* Eine Linie ist entweder gerade oder gekrümmt. Ankerpunkte bestimmen die Art der Linie.  
* Ankerpunkte können als Eckpunkte, gerade Punkte oder sanfte Punkte vorliegen:  
  * Ein Eckpunkt ist ein Punkt, an dem zwei gerade Linien in einem Winkel zusammentreffen.  
  * Ein sanfter Punkt ist ein Punkt, an dem sich 2 Griffe in einer geraden Linie befinden und die Liniensegmente zu einer glatten Kurve verbunden werden. In diesem Fall sind alle Griffe vom Ankerpunkt gleichweit entfernt.  
  * Ein gerader Punkt ist ein Punkt, an dem sich 2 Griffe in einer geraden Linie befinden und die Liniensegmente zu einer glatten Kurve verbunden werden. In diesem Fall müssen die Griffe nicht gleichweit vom Ankerpunkt entfernt sein.  
* Durch Verschieben oder Bearbeiten von Ankerpunkten (was den Winkel der Linien ändert) können Sie das Aussehen einer Form ändern.  

Um PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) und das Interface [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath) bereit.  

* Eine [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath)‑Instanz stellt einen Geometrie‑Pfad des Objekts [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape) dar.  
* Um den `GeometryPath` aus der `IGeometryShape`‑Instanz abzurufen, können Sie die Methode [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths) verwenden.  
* Um den `GeometryPath` für eine Form festzulegen, können Sie diese Methoden verwenden: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) für *einfachere Formen* und [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) für *zusammengesetzte Formen*.  
* Um Segmente hinzuzufügen, können Sie die Methoden unter [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath) verwenden.  
* Mit den Eigenschaften [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) und [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode) können Sie das Aussehen eines Geometrie‑Pfads festlegen.  
* Über die Eigenschaft [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata) können Sie den Geometrie‑Pfad einer `GeometryShape` als Array von Pfadsegmenten abrufen.  
* Um weitere Optionen zur Anpassung der Formgeometrie zu nutzen, können Sie [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) in [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) konvertieren.  
* Verwenden Sie die Methoden [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) und [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (aus der Klasse [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil)), um [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) in [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) und zurück zu konvertieren.  

## **Einfache Bearbeitungsoperationen**

Dieser C#‑Code zeigt, wie man  

**Linie hinzufügen** am Ende eines Pfads:  
``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
  

**Linie hinzufügen** an einer bestimmten Position im Pfad:  
``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
  

**Kubische Bézier‑Kurve hinzufügen** am Ende eines Pfads:  
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
  

**Kubische Bézier‑Kurve hinzufügen** an der angegebenen Position im Pfad:  
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
  

**Quadratische Bézier‑Kurve hinzufügen** am Ende eines Pfads:  
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
  

**Quadratische Bézier‑Kurve hinzufügen** an der angegebenen Position im Pfad:  
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
  

**Einen gegebenen Bogen** zum Pfad hinzufügen:  
``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
  

**Die aktuelle Figur** des Pfads schließen:  
``` csharp
void CloseFigure();
```
  

**Position für den nächsten Punkt** festlegen:  
``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
  

**Pfadsegment** an einem angegebenen Index entfernen:  
``` csharp
void RemoveAt(int index);
```
  

## **Benutzerdefinierte Punkte zur Form hinzufügen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) und setzen Sie den Typ [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype).  
2. Holen Sie eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) von der Form.  
3. Fügen Sie einen neuen Punkt zwischen den beiden oberen Punkten des Pfads hinzu.  
4. Fügen Sie einen neuen Punkt zwischen den beiden unteren Punkten des Pfads hinzu.  
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
2. Holen Sie eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) von der Form.  
3. Entfernen Sie das Segment des Pfads.  
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

Dieser C#‑Code zeigt, wie man eine benutzerdefinierte Form mit gekrümmten Ecken (nach innen) erstellt;  
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
  

## **Ermitteln, ob eine Formgeometrie geschlossen ist**

Eine geschlossene Form ist definiert als eine, bei der alle Seiten verbunden sind und eine durchgehende Grenze ohne Lücken bilden. Eine solche Form kann eine einfache geometrische Gestalt oder ein komplexes benutzerdefiniertes Kontur sein. Der nachfolgende Code‑Beispiel zeigt, wie man prüft, ob eine Formgeometrie geschlossen ist:  
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
  

## **GeometryPath in GraphicsPath konvertieren (System.Drawing.Drawing2D)**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape).  
2. Erstellen Sie eine Instanz der Klasse [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) des Namespaces [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).  
3. Konvertieren Sie die [GraphicsPath]-Instanz mithilfe von [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil) in die [GeometryPath]-Instanz.  
4. Wenden Sie die Pfade auf die Form an.  

Dieser C#‑Code – eine Umsetzung der obigen Schritte – demonstriert den Konvertierungsprozess von **GeometryPath** zu **GraphicsPath**:  
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

Der Stil bleibt bei der Form erhalten; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.  

**Wie drehe ich eine benutzerdefinierte Form korrekt zusammen mit ihrer Geometrie?**  

Verwenden Sie die [rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/)‑Eigenschaft der Form; die Geometrie rotiert mit der Form, da sie an das eigene Koordinatensystem der Form gebunden ist.  

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis zu „sperren“?**  

Ja. Exportieren Sie den gewünschten [slide](/slides/de/net/convert-powerpoint-to-png/)‑Bereich oder die [shape](/slides/de/net/create-shape-thumbnails/) selbst in ein Rasterformat; das erleichtert die weitere Arbeit mit komplexen Geometrien.