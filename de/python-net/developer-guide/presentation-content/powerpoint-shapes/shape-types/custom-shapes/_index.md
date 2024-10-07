---
title: Benutzerdefinierte Form
type: docs
weight: 20
url: /python-net/custom-shape/
keywords: "PowerPoint-Form, benutzerdefinierte Form, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Fügen Sie eine benutzerdefinierte Form in einer PowerPoint-Präsentation in Python hinzu"
---

# Ändern einer Form mit Bearbeitungspunkten

Betrachten Sie ein Quadrat. In PowerPoint können Sie mit **Bearbeitungspunkten** 

* die Ecke des Quadrats hinein oder heraus bewegen
* die Krümmung für eine Ecke oder einen Punkt festlegen
* neue Punkte zum Quadrat hinzufügen
* Punkte am Quadrat manipulieren usw. 

Im Wesentlichen können Sie die beschriebenen Aufgaben auf jede Form anwenden. Mit Bearbeitungspunkten können Sie eine Form ändern oder eine neue Form aus einer vorhandenen Form erstellen. 

## Tipps zur Formbearbeitung

![overview_image](custom_shape_0.png)

Bevor Sie mit der Bearbeitung von PowerPoint-Formen über Bearbeitungspunkte beginnen, sollten Sie diese Punkte zu Formen beachten:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Wenn eine Form geschlossen ist, fehlt ein Start- oder Endpunkt. Wenn eine Form offen ist, hat sie einen Anfang und ein Ende. 
* Alle Formen bestehen aus mindestens 2 Ankerpunkten, die durch Linien miteinander verbunden sind.
* Eine Linie ist entweder gerade oder gekrümmt. Ankerpunkte bestimmen die Beschaffenheit der Linie. 
* Ankerpunkte existieren als Eckenpunkte, gerade Punkte oder glatte Punkte:
  * Ein Eckenpunkt ist ein Punkt, an dem 2 gerade Linien in einem Winkel zusammentreffen. 
  * Ein glatter Punkt ist ein Punkt, an dem 2 Griffe in einer geraden Linie liegen und die Segmente der Linie in einer sanften Kurve zusammenkommen. In diesem Fall sind alle Griffe vom Ankerpunkt durch einen gleichen Abstand getrennt. 
  * Ein gerader Punkt ist ein Punkt, an dem 2 Griffe in einer geraden Linie liegen und die Liniensegmente der Linie in einer sanften Kurve zusammenkommen. In diesem Fall müssen die Griffe nicht durch einen gleichen Abstand vom Ankerpunkt getrennt sein. 
* Durch Verschieben oder Bearbeiten von Ankerpunkten (was den Winkel der Linien ändert) können Sie das Aussehen einer Form ändern. 

Um PowerPoint-Formen über Bearbeitungspunkte zu bearbeiten, bietet **Aspose.Slides** die [**GeometryPath**](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) Klasse und die [**IGeometryPath**](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) Schnittstelle. 

* Eine [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) Instanz stellt einen Geometriepfad des [IGeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) Objekts dar.
* Um den `GeometryPath` von der `IGeometryShape` Instanz abzurufen, können Sie die [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) Methode verwenden. 
* Um den `GeometryPath` für eine Form festzulegen, können Sie diese Methoden verwenden: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) für *feste Formen* und [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) für *kompositere Formen*.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [IGeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) verwenden.
* Mit den Eigenschaften [IGeometryPath.Stroke](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) und [IGeometryPath.FillMode](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) können Sie das Aussehen eines Geometriepfades festlegen.
* Mit der [IGeometryPath.PathData](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/properties/pathdata) Eigenschaft können Sie den Geometriepfad einer `GeometryShape` als ein Array von Pfadsegmenten abrufen. 
* Um auf zusätzliche Optionen zur Anpassung der Formgeometrie zuzugreifen, können Sie [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) in [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) umwandeln.
* Verwenden Sie die Methoden `GeometryPathToGraphicsPath` und `GraphicsPathToGeometryPath` (aus der [ShapeUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/shapeutil/) Klasse), um `GeometryPath` in `GraphicsPath` und umgekehrt umzuwandeln. 

## **Einfache Bearbeitungsvorgänge**

Dieser Python-Code zeigt Ihnen, wie Sie

**Eine Linie** am Ende eines Pfades hinzufügen:

```py
line_to(point)
line_to(x, y)
```
**Eine Linie** an einer bestimmten Position auf einem Pfad hinzufügen:

```py    
line_to(point, index)
line_to(x, y, index)
```
**Eine kubische Bezier-Kurve** am Ende eines Pfades hinzufügen:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```
**Eine kubische Bezier-Kurve** an der angegebenen Position auf einem Pfad hinzufügen:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```
**Eine quadratische Bezier-Kurve** am Ende eines Pfades hinzufügen:
```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```
**Eine quadratische Bezier-Kurve** an einer bestimmten Position auf einem Pfad hinzufügen:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```
**Einen bestimmten Bogen** zu einem Pfad anhängen:
```py
arc_to(width, height, startAngle, sweepAngle)
```
**Die aktuelle Figur** eines Pfades schließen:
```py
close_figure()
```
**Die Position für den nächsten Punkt** festlegen:
```py
move_to(point)
move_to(x, y)
```
**Den Pfadsegment** an einem bestimmten Index entfernen:

```py
remove_at(index)
```
## Fügen Sie benutzerdefinierte Punkte zur Form hinzu
1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) Klasse und setzen Sie den [ShapeType.Rectangle](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)
2. Holen Sie sich eine Instanz der [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) Klasse von der Form.
3. Fügen Sie einen neuen Punkt zwischen den beiden oberen Punkten auf dem Pfad hinzu.
4. Fügen Sie einen neuen Punkt zwischen den beiden unteren Punkten auf dem Pfad hinzu.
6. Wenden Sie den Pfad auf die Form an.

Dieser Python-Code zeigt Ihnen, wie Sie benutzerdefinierte Punkte zu einer Form hinzufügen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    geometryPath = shape.get_geometry_paths()[0]

    geometryPath.line_to(100, 50, 1)
    geometryPath.line_to(100, 50, 4)
    shape.set_geometry_path(geometryPath)
```

![example1_image](custom_shape_1.png)

## Punkte von der Form entfernen

1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) Klasse und setzen Sie den [ShapeType.Heart](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) Typ. 
2. Holen Sie sich eine Instanz der [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) Klasse von der Form.
3. Entfernen Sie das Segment für den Pfad.
4. Wenden Sie den Pfad auf die Form an.

Dieser Python-Code zeigt Ihnen, wie Sie Punkte von einer Form entfernen:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)
    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## Eine benutzerdefinierte Form erstellen

1. Berechnen Sie Punkte für die Form.
2. Erstellen Sie eine Instanz der [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) Klasse. 
3. Füllen Sie den Pfad mit den Punkten.
4. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) Klasse. 
5. Wenden Sie den Pfad auf die Form an.

Dieser Python-Code zeigt Ihnen, wie Sie eine benutzerdefinierte Form erstellen:

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

starPath = slides.GeometryPath()
starPath.move_to(points[0])

for i in range(len(points)):
    starPath.line_to(points[i])

starPath.close_figure()

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(starPath)
```
![example3_image](custom_shape_3.png)


## Erstellen einer zusammengesetzten benutzerdefinierten Form

1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) Klasse.
2. Erstellen Sie eine erste Instanz der [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) Klasse.
3. Erstellen Sie eine zweite Instanz der [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) Klasse.
4. Wenden Sie die Pfade auf die Form an.

Dieser Python-Code zeigt Ihnen, wie Sie eine zusammengesetzte benutzerdefinierte Form erstellen:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometryPath0 = slides.GeometryPath()
    geometryPath0.move_to(0, 0)
    geometryPath0.line_to(shape.width, 0)
    geometryPath0.line_to(shape.width, shape.height/3)
    geometryPath0.line_to(0, shape.height / 3)
    geometryPath0.close_figure()

    geometryPath1 = slides.GeometryPath()
    geometryPath1.move_to(0, shape.height/3 * 2)
    geometryPath1.line_to(shape.width, shape.height / 3 * 2)
    geometryPath1.line_to(shape.width, shape.height)
    geometryPath1.line_to(0, shape.height)
    geometryPath1.close_figure()

    shape.set_geometry_paths([ geometryPath0, geometryPath1])
```
![example4_image](custom_shape_4.png)

## **Erstellen einer benutzerdefinierten Form mit abgerundeten Ecken**

Dieser Python-Code zeigt Ihnen, wie Sie eine benutzerdefinierte Form mit abgerundeten Ecken (nach innen) erstellen:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shapeX = 20
shapeY = 20
shapeWidth = 300
shapeHeight = 200

leftTopSize = 50
rightTopSize = 20
rightBottomSize = 40
leftBottomSize = 10

with slides.Presentation() as presentation:
    childShape = presentation.slides[0].shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shapeX, shapeY, shapeWidth, shapeHeight)

    geometryPath = slides.GeometryPath()

    point1 = draw.PointF(leftTopSize, 0)
    point2 = draw.PointF(shapeWidth - rightTopSize, 0)
    point3 = draw.PointF(shapeWidth, shapeHeight - rightBottomSize)
    point4 = draw.PointF(leftBottomSize, shapeHeight)
    point5 = draw.PointF(0, leftTopSize)

    geometryPath.move_to(point1)
    geometryPath.line_to(point2)
    geometryPath.arc_to(rightTopSize, rightTopSize, 180, -90)
    geometryPath.line_to(point3)
    geometryPath.arc_to(rightBottomSize, rightBottomSize, -90, -90)
    geometryPath.line_to(point4)
    geometryPath.arc_to(leftBottomSize, leftBottomSize, 0, -90)
    geometryPath.line_to(point5)
    geometryPath.arc_to(leftTopSize, leftTopSize, 90, -90)

    geometryPath.close_figure()

    childShape.set_geometry_path(geometryPath)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## Umwandlung von GeometryPath in GraphicsPath (System.Drawing.Drawing2D) 

1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) Klasse.
2. Erstellen Sie eine Instanz der [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) Klasse im [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) Namespace.
3. Konvertieren Sie die [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) Instanz in die [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) Instanz mit [ShapeUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/shapeutil/).
4. Wenden Sie die Pfade auf die Form an.

Dieser Python-Code—eine Umsetzung der obigen Schritte—demonstriert den Prozess der **GeometryPath** zu **GraphicsPath**-Umwandlung:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 100)

    originalPath = shape.get_geometry_paths()[0]
    originalPath.fill_mode = slides.PathFillModeType.NONE

    gPath = draw.drawing2d.GraphicsPath()

    gPath.add_string("Text in der Form", draw.FontFamily("Arial"), 1, 40, draw.PointF(10, 10), draw.StringFormat.generic_default)

    textPath = slides.util.ShapeUtil.graphics_path_to_geometry_path(gPath)
    textPath.fill_mode = slides.PathFillModeType.NORMAL

    shape.set_geometry_paths([originalPath, textPath])
```
![example5_image](custom_shape_5.png)