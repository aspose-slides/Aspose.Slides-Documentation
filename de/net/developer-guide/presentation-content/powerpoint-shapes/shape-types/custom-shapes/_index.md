---
title: Anpassen von Präsentationsformen in .NET
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
description: "Erstellen und Anpassen von Formen in PowerPoint-Präsentationen mit Aspose.Slides für .NET: Geometriepfade, abgerundete Ecken, zusammengesetzte Formen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Präsentationsformen in Aspose.Slides anpassen, indem Sie die Formgeometrie über Bearbeitungspunkte und Geometriepfade bearbeiten. Er zeigt, wie Sie mit [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) und [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) arbeiten, um vorhandene Formen zu ändern, grundlegende Pfadbearbeitungsoperationen durchzuführen, Punkte hinzuzufügen oder zu entfernen und die aktualisierte Geometrie wieder einer Form zuzuweisen.  

Er demonstriert auch, wie benutzerdefinierte und zusammengesetzte Formen erstellt, Formen mit abgerundeten Ecken gebaut, ermittelt wird, ob eine Formgeometrie geschlossen ist, und die alte Konvertierung zwischen [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) und [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) für weitere Geometrie‑Anpassungsszenarien verwendet wird.

## **Form mit Bearbeitungspunkten ändern**

In PowerPoint können Sie **Edit Points** verwenden, um ein Quadrat zu ändern:

* Eine Ecke nach innen oder außen verschieben.
* Die Krümmung an einem Punkt anpassen.
* Neue Punkte hinzufügen.

Durch das Bearbeiten von Punkten können Sie die Kontur einer Form ändern oder eine vorhandene Form als Basis für eine neue verwenden.

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Beim Bearbeiten von PowerPoint‑Formen sollten Sie diese Konzepte beachten:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder geöffnet sein.
* Der Pfad einer Form besteht aus Ankerpunkten, die durch Segmente verbunden sind.
* Ein Segment kann gerade oder gekrümmt sein. Ankerpunkte und Steuergriffe bestimmen seine Form.
* Ankerpunkte existieren als Eckpunkte, gerade Punkte oder glatte Punkte:
  * An einem Eckpunkt können benachbarte Segmente in einem Winkel aufeinandertreffen.
  * An einem glatten Punkt sind die beiden Steuergriffe ausgerichtet und gleichweit vom Ankerpunkt entfernt.
  * An einem geraden Punkt sind die beiden Steuergriffe ausgerichtet, können jedoch unterschiedliche Abstände zum Ankerpunkt haben.
* Das Verschieben von Ankerpunkten oder das Anpassen ihrer Griffe ändert die Kontur der Form.

Um PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) und das Interface [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) bereit.

* Eine [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) Instanz repräsentiert einen Geometriepfad des [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) Objekts.  
* Um die [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) aus der [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) Instanz abzurufen, können Sie die Methode [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) verwenden.  
* Um die [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) für eine Form festzulegen, können Sie diese Methoden verwenden: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) für Formen mit einem einzelnen Pfad und [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) für Formen mit mehreren Pfaden.  
* Um Segmente hinzuzufügen, können Sie die Methoden unter [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) verwenden.  
* Mit den Eigenschaften [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) und [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) können Sie das Aussehen eines Geometriepfads festlegen.  
* Über die Eigenschaft [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) können Sie den Geometriepfad einer [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) als Array von Pfadsegmenten abrufen.  
* In Legacy‑Versionen, die die nachstehenden Konvertierungsmethoden unterstützen, können Sie [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) zu [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) konvertieren.  
* Verwenden Sie die Methoden [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) und [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (aus der Klasse [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)), um zwischen [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) und [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) zu konvertieren.

## **Einfache Bearbeitungsoperationen**

Verwenden Sie die folgenden Methoden, um einen Geometriepfad zu bearbeiten. Überladungen, die einen Index akzeptieren, fügen ein Segment an dieser nullbasierten Position im Segment‑Array des Pfads ein.

| Operation | Methode |
| --- | --- |
| Eine gerade Linie anhängen oder einfügen. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Eine kubische Bézier‑Kurve mit zwei Steuerpunkten und einem Endpunkt anhängen oder einfügen. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Eine quadratische Bézier‑Kurve mit einem Steuerpunkt und einem Endpunkt anhängen oder einfügen. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Ein elliptisches Bogensegment mit den angegebenen Abmessungen und Winkeln in Grad anhängen. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Die aktuelle Figur schließen, indem ihr Endpunkt mit dem Startpunkt verbunden wird. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Den Startpunkt einer Figur festlegen. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Ein Segment an einem nullbasierten Index entfernen. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

Dieses Beispiel fügt mithilfe von [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) zwei Punkte in eine rechteckige Form ein und wendet den bearbeiteten Pfad mit [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) an. Die Koordinaten sind relativ zur Form: Beide neuen Punkte liegen im Zentrum, 100 Punkte vom linken Rand und 50 Punkte vom oberen Rand entfernt. Segmentindizes 1 und 4 positionieren sie an den oberen bzw. unteren Kanten und ziehen diese nach innen.

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

## **Punkte aus einer Form entfernen**

Dieses Beispiel ändert eine herzförmige Kontur, indem es das Segment am nullbasierten Index 2 mit [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) entfernt. Das Anwenden des modifizierten Pfads mit [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) aktualisiert die Kontur der Form.

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

## **Eine benutzerdefinierte Form erstellen**

Dieses Beispiel erstellt einen fünfzackigen Stern mit [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Wechselnde äußere und innere Radien von 100 bzw. 50 Punkten definieren die Spitzen und Einziehungen; ein Schritt von 72 Grad verteilt die fünf Spitzen gleichmäßig. Der Pfad wird mit [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) geschlossen und mittels [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) auf eine rechteckige Form angewendet, wobei deren Kontur ersetzt wird.

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

## **Eine zusammengesetzte benutzerdefinierte Form erstellen**

Dieses Beispiel definiert zwei geschlossene [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)-Objekte für das obere und untere Drittel einer Form. Das Anwenden beider Pfade mit [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) erzeugt eine einzelne zusammengesetzte Form mit einer Lücke im mittleren Drittel.

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

## **Eine benutzerdefinierte Form mit abgerundeten Ecken erstellen**

Dieses Beispiel kombiniert gerade Segmente mit [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/), um eine Form mit nach innen gekrümmten Ecken zu erzeugen. Jede Eckgröße legt die Breite und Höhe des Bogens in Punkten fest, und die -90‑Grad‑Winkelbewegung zeichnet ein gegen den Uhrzeigersinn gerichtetes Viertel­ellipsen‑Segment. Der fertige Pfad wird mit [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) angewendet, und die Präsentation wird im PPTX‑Format gespeichert.

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

## **Ermitteln, ob eine Formgeometrie geschlossen ist**

Der folgende Helfer prüft, ob jeder nicht-leere Geometriepfad mit einem Schließsegment endet. Er liest [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) und vergleicht den Befehl des letzten Segments [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) mit [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Er gibt false zurück, wenn keine nicht-leeren Pfade vorhanden sind. Diese Prüfung betrachtet den abschließenden Befehl jedes Pfads; sie untersucht nicht jede Unterfigur innerhalb eines Pfads. Das Beispiel gibt `True` für ein Rechteck aus.

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

## **Formelemente extrahieren und untersuchen**

Verwenden Sie [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/), um eine vorhandene Form als Elemente zu untersuchen, die Pfadpunkte und Punktarten enthalten. Casten Sie jedes zurückgegebene [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) zu [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/), um dessen [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/)‑ und [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/)‑Arrays zu lesen. Diese Darstellung ist nützlich für Konturanalysen oder um Geometrie an benutzerdefinierte Zeichenwerkzeuge weiterzugeben.

Das Beispiel öffnet eine Präsentation, findet die erste Geometrie‑Form direkt auf der ersten Folie und gibt deren Pfadsegmente aus. Verwenden Sie eine Präsentation, die eine Form mit geraden und gekrümmten Segmenten enthält, um beide Ausgabetypen zu sehen. Es wird nicht innerhalb von Gruppen gesucht.

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
        var pointType = types[i] & 0x07; // Behalte den Segmenttyp, ohne Flags.
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

Die Arrays korrespondieren nach Index: `points[i]` ist ein Punkt und `types[i]` beschreibt dessen Rolle. Typ `0` startet eine Figur, und Typ `1` zeichnet eine Linie vom vorherigen Punkt zum aktuellen Punkt. Ein kubisches Bézier‑Segment startet am vorherigen Endpunkt und verwendet drei aufeinanderfolgende Einträge vom Typ `3`: zwei Steuerpunkte gefolgt vom neuen Endpunkt. Die Schleife verarbeitet diese drei Einträge zusammen und prüft den Endpunkt auf Schließung.

Punktarten enthalten ebenfalls Flags. Maskieren Sie mit `0x07`, um den Segmenttyp zu ermitteln, und testen Sie `0x80` separat, um einen geschlossenen Unterpfad zu erkennen. Beispielsweise bedeutet `129` (`0x81`), dass ein Linienendpunkt einen Unterpfad schließt, und `131` (`0x83`) bedeutet, dass ein Bézier‑Endpunkt einen schließt. Der reine Vergleich des Rohwerts mit `1` oder `3` würde diese Fälle übersehen. Andere Flags, wie Strich (`0x10`) und Marker (`0x20`), ändern den Basis‑Segmenttyp nicht.

**Koordinaten und Transformationen.** Punkte werden in Punkten (1/72 Zoll) gemessen, wobei X nach rechts und Y nach unten zunimmt. Für eine nicht gruppierte Form enthalten die extrahierten Koordinaten bereits deren [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) und [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) Position und spiegeln die aktuelle Breite und Höhe wider. Zum Beispiel hat ein nicht gedrehtes Rechteck bei `(100, 200)` mit der Größe `120 × 80` Konturgrenzen von `(100, 200)`–`(220, 280)`. Fügen Sie die Position der Form nicht erneut hinzu. Subtrahieren Sie ihr X und Y, um Koordinaten relativ zu ihrem nicht gedrehten Rahmen zu erhalten.

Die extrahierten Punkte berücksichtigen nicht die [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) der Form oder horizontale bzw. vertikale Spiegelungen. Um die angezeigte Kontur wiederzugeben, wenden Sie diese Transformationen um das Zentrum der Form herum an. Bei gruppierten Formen berücksichtigen Sie außerdem die Gruppen‑Koordinatenzuordnung und -Transformationen; gehen Sie nicht davon aus, dass die extrahierten Punkte bereits die endgültigen gerenderten Folienkoordinaten darstellen, und wenden Sie keine Übersetzung oder Skalierung doppelt an, wenn sie bereits im Rahmen des Kind‑Elements enthalten ist.

**Untersuchung vs. Bearbeitung.** Extrahierte Arrays beschreiben die Kontur; deren Änderung aktualisiert die Originalform nicht. Wählen Sie diesen Ansatz, wenn Ihre Analyse‑ oder Zeichen‑Code Punkt‑/Typ‑Arrays benötigt. Verwenden Sie [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/), wenn Sie Geometrie‑Befehle im lokalen Koordinatensystem der Form benötigen oder deren Geometrie bearbeiten möchten. Wenden Sie bearbeitete Pfade über [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) oder [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) an.

## **GeometryPath in GraphicsPath konvertieren (System.Drawing.Drawing2D)**

Das folgende Beispiel erfordert eine Legacy‑Aspose.Slides‑für‑.NET‑Assembly, die [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) unterstützt, beispielsweise Version 25.10, sowie eine Windows‑Umgebung mit `System.Drawing.Common`. Die Konvertierungsmethoden wurden in [version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/) entfernt.

Dieses Beispiel kombiniert eine rechteckige Kontur mit zu Geometrie konvertiertem Text. Die [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/)-Eigenschaft der Kontur wird deaktiviert, um die Füllung zu verhindern. Ein [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) speichert die Textkontur, welche [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) in einen gefüllten Geometriepfad konvertiert. Das Anwenden beider Pfade mit [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) erzeugt eine einzelne Form, die das Rechteck und den Text enthält. Für die umgekehrte Konvertierung verwenden Sie [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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

**Was passiert mit der Füllung und Kontur, nachdem die Geometrie ersetzt wurde?**  
Der Stil bleibt an der Form erhalten; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie kann ich eine benutzerdefinierte Form zusammen mit ihrer Geometrie korrekt drehen?**  
Verwenden Sie die [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/)-Eigenschaft der Form; die Geometrie rotiert mit der Form, da sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis zu „sperren“?**  
Ja. Exportieren Sie den gewünschten [Folie](/slides/de/net/convert-powerpoint-to-png/)‑Bereich oder die [Form](/slides/de/net/create-shape-thumbnails/)‑Selbst in ein Rasterformat; das erleichtert die weitere Arbeit mit komplexen Geometrien.