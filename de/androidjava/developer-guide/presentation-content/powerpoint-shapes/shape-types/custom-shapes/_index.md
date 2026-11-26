---
title: Präsentationsformen auf Android anpassen
linktitle: Benutzerdefinierte Form
type: docs
weight: 20
url: /de/androidjava/custom-shape/
keywords:
- benutzerdefinierte Form
- Form hinzufügen
- Form erstellen
- Form ändern
- Formgeometrie
- Geometriepfad
- Pfadpunkte
- Punkte bearbeiten
- Punkt hinzufügen
- Punkt entfernen
- Bearbeitungsoperation
- abgerundete Ecke
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen und Anpassen von Formen in PowerPoint-Präsentationen mit Aspose.Slides für Android über Java: Geometriepfade, abgerundete Ecken, zusammengesetzte Formen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Präsentationsformen in Aspose.Slides durch Bearbeiten der Formgeometrie über Edit‑Punkte und Geometrie‑Pfade anpasst. Er zeigt, wie man mit [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) und [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) arbeitet, um vorhandene Formen zu ändern, grundlegende Pfad‑Bearbeitungsoperationen durchzuführen, Punkte hinzuzufügen oder zu entfernen und die aktualisierte Geometrie zurück auf eine Form anzuwenden.  

Er demonstriert außerdem, wie man benutzerdefinierte und zusammengesetzte Formen erstellt, Formen mit abgerundeten Ecken baut, ermittelt, ob eine Formgeometrie geschlossen ist, und Formelemente mithilfe von Android‑Punkt‑Arrays inspiziert.

## **Form mit Edit‑Punkten ändern**

In PowerPoint können Sie **Edit‑Points** verwenden, um ein Quadrat zu ändern:

* Verschieben Sie eine Ecke nach innen oder außen.
* Passen Sie die Krümmung an einem Punkt an.
* Fügen Sie neue Punkte hinzu.

Durch das Bearbeiten von Punkten können Sie die Kontur einer Form ändern oder eine vorhandene Form als Basis für eine neue verwenden.

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Beim Bearbeiten von PowerPoint‑Formen sollten Sie folgende Konzepte berücksichtigen:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Der Pfad einer Form besteht aus Ankerpunkten, die durch Segmente verbunden sind.
* Ein Segment kann gerade oder kurvig sein. Ankerpunkte und Steuergriffe bestimmen seine Form.
* Ankerpunkte können Eckpunkte, gerade Punkte oder glatte Punkte sein:
  * An einem Eckpunkt können benachbarte Segmente in einem Winkel aufeinandertreffen.
  * An einem glatten Punkt sind die beiden Steuergriffe ausgerichtet und gleichweit vom Ankerpunkt entfernt.
  * An einem geraden Punkt sind die beiden Steuergriffe ausgerichtet, können aber unterschiedliche Abstände vom Ankerpunkt haben.
* Das Verschieben von Ankerpunkten oder das Anpassen ihrer Griffe ändert die Kontur der Form.

Um PowerPoint‑Formen über Edit‑Punkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) und das Interface [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) bereit.

* Eine [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)‑Instanz stellt den Geometrie‑Pfad des [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/)-Objekts dar.
* Um den [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) aus einer [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/)-Instanz zu erhalten, können Sie die Methode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) verwenden.
* Um den [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) für eine Form zu setzen, können Sie diese Methoden verwenden: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) für Formen mit einem einzelnen Pfad und [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) für Formen mit mehreren Pfaden.
* Zum Hinzufügen von Segmenten können Sie die Methoden unter [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) nutzen.
* Mit den Methoden [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) und [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) können Sie das Aussehen eines Geometrie‑Pfads festlegen.
* Mit der Methode [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) können Sie den Geometrie‑Pfad einer [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) als Array von Pfadsegmenten abrufen.

## **Einfache Bearbeitungsoperationen**

Verwenden Sie die folgenden Methoden, um einen Geometrie‑Pfad zu bearbeiten. Überladungen, die einen Index akzeptieren, fügen ein Segment an dieser nullbasierten Position im Segment‑Array des Pfads ein.

| Operation | Methode |
| --- | --- |
| Eine gerade Linie anhängen oder einfügen. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Einen kubischen Bézier‑Kurvenabschnitt mit zwei Steuerpunkten und einem Endpunkt anhängen oder einfügen. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Einen quadratischen Bézier‑Kurvenabschnitt mit einem Steuerpunkt und einem Endpunkt anhängen oder einfügen. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Einen elliptischen Bogen mit den angegebenen Abmessungen und Winkeln in Grad anhängen. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Die aktuelle Figur schließen, indem ihr Endpunkt mit dem Startpunkt verbunden wird. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Den Startpunkt einer Figur festlegen. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Ein Segment an einem nullbasierten Index entfernen. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

Dieses Beispiel fügt einer rechteckigen Form zwei Punkte mit [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) ein und wendet den bearbeiteten Pfad mit [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) an. Die Koordinaten sind relativ zur Form: beide neuen Punkte liegen in der Mitte, 100 Punkte vom linken Rand und 50 Punkte vom oberen Rand. Die Segment‑Indizes 1 und 4 platzieren sie an den oberen bzw. unteren Kanten und ziehen diese Kanten nach innen.

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

## **Punkte aus einer Form entfernen**

Dieses Beispiel verändert die Kontur einer herzförmigen Form, indem es das Segment am nullbasierten Index 2 mit [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) entfernt. Das Anwenden des modifizierten Pfads mit [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) aktualisiert die Kontur der Form.

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

## **Eine benutzerdefinierte Form erstellen**

Dieses Beispiel erstellt einen fünfzackigen Stern mit [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Wechselnde äußere und innere Radien von 100 und 50 Punkten definieren die Spitzen und Einziehungen; ein Schritt von 72 Grad verteilt die fünf Spitzen gleichmäßig. Der Pfad wird mit [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) geschlossen und mit [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) auf ein rechteckiges Objekt angewendet, wodurch dessen Kontur ersetzt wird.

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

## **Eine zusammengesetzte benutzerdefinierte Form erstellen**

Dieses Beispiel definiert zwei geschlossene [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)-Objekte für das obere und untere Drittel einer Form. Das Anwenden beider Pfade mit [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) erzeugt eine einzige zusammengesetzte Form mit einer Lücke im mittleren Drittel.

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

## **Eine benutzerdefinierte Form mit abgerundeten Ecken erstellen**

Dieses Beispiel kombiniert gerade Segmente mit [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) und erzeugt eine Form mit nach innen gekrümmten Ecken. Jeder Eckgrößen‑Wert legt die Breite und Höhe des Bogens in Punkten fest, und der -90‑Grad‑Bogen zeichnet ein gegen den Uhrzeigersinn gerichttes Viertel‑Ellipse. Der fertige Pfad wird mit [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) angewendet, und die Präsentation wird im PPTX‑Format gespeichert.

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

## **Ermitteln, ob eine Formgeometrie geschlossen ist**

Der folgende Helfer prüft, ob jeder nicht leere Geometrie‑Pfad mit einem Schließsegment endet. Er liest [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) und vergleicht den Pfad‑Befehl des letzten Segments ([IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--)) mit [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Er gibt **false** zurück, wenn keine nicht leeren Pfade vorhanden sind. Diese Prüfung betrachtet nur den finalen Befehl jedes Pfads; sie inspiziert nicht jede Unterfigur innerhalb eines Pfads. Das Beispiel gibt `true` für ein Rechteck aus.

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

## **Geometrie‑Pfadbefehle inspizieren**

Laden Sie [contour.pptx](contour.pptx) herunter und ersetzen Sie den Beispiel‑Dateinamen durch den Pfad auf dem Gerät. Die erste Form auf der ersten Folie hat eine gerade obere Kante, eine kubische Bézier‑Kurve und eine gerade abschließende Kante. Verwenden Sie [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) um die Pfade der Form auszulesen und [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) um die Segmente jedes Pfads in Zeichenreihenfolge zu erhalten. Für jedes Segment identifiziert [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) den Befehl und bestimmt, wie die von [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--) zurückgegebenen Werte zu interpretieren sind.

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

Die Form befindet sich bei (200, 100) Punkten auf der Folie. Die angegebenen Koordinaten sind relativ zur Form, wobei (0, 0) in der oberen linken Ecke liegt, x nach rechts und y nach unten zunimmt. Das Schließsegment kehrt zum Ausgangspunkt zurück, ohne zusätzliche Koordinaten zu benötigen.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint‑Form mit einer geraden oberen Kante, einer gekrümmten Kante von rechts‑oben nach links‑unten und einer geraden linken Kante](contour.png)

## **Formelemente extrahieren und inspizieren**

Verwenden Sie [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) um eine vorhandene Form als Elemente zu untersuchen, die Pfadpunkte und Punkt‑Typen enthalten. Casten Sie jedes zurückgegebene [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) zu [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/), um über die Methoden [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) und [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) auf die entsprechenden Arrays zuzugreifen. Diese Darstellung ist nützlich für Konturanalysen oder zum Weitergeben der Geometrie an benutzerdefinierte Zeichenwerkzeuge.

Das Beispiel öffnet *input.pptx*, findet die erste Geometrie‑Form direkt auf der ersten Folie und gibt deren Pfadsegmente aus. Verwenden Sie eine Präsentation, die eine Form mit geraden und gekrümmten Segmenten enthält, um beide Ausgabetypen zu sehen. Gruppen werden nicht durchsucht.

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
                int pointType = types[i] & 0x07; // Behalte den Segmenttyp, ohne Flags.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Verwende beide Steuerpunkte und den Endpunkt.
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

Die Arrays korrespondieren nach Index: `points[i]` ist ein Punkt und `types[i]` beschreibt seine Rolle. Typ 0 startet eine Figur, Typ 1 zeichnet eine Linie vom vorherigen Punkt zum aktuellen Punkt. Ein kubischer Bézier‑Segment beginnt beim vorherigen Endpunkt und verwendet drei aufeinanderfolgende Typ‑3‑Einträge: zwei Steuerpunkte gefolgt vom neuen Endpunkt. Die Schleife verarbeitet diese drei Einträge gemeinsam und prüft den Endpunkt auf Abschluss.

Punkt‑Typen enthalten außerdem Flags. Maskieren Sie mit `0x07`, um den Segmenttyp zu ermitteln, und prüfen Sie `0x80` separat, um einen geschlossenen Unterpfad zu erkennen. Beispielsweise bedeutet `129` (`0x81`), dass ein Linien‑Endpunkt einen Unterpfad schließt, und `131` (`0x83`) bedeutet, dass ein Bézier‑Endpunkt einen schließt. Java speichert diese Flags in signed bytes; das Maskieren bewahrt die beabsichtigten Bitwerte. Ein reiner Vergleich des Rohwerts mit `1` oder `3` würde diese Fälle übersehen. Andere Flags wie Dash (`0x10`) und Marker (`0x20`) ändern den Grundsegmenttyp nicht.

**Koordinaten und Transformationen.** Punkte werden in Punkten (1/72 Zoll) gemessen, wobei X nach rechts und Y nach unten wächst. Für eine nicht gruppierte Form enthalten die extrahierten Koordinaten bereits die Position, die von [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) und [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) zurückgegeben wird, und sie spiegeln die aktuelle Breite und Höhe wider. Ein ungedrehtes Rechteck bei `(100, 200)` mit Größe `120 × 80` hat Konturgrenzen von `(100, 200)`–`(220, 280)`. Fügen Sie die Position der Form nicht erneut hinzu. Subtrahieren Sie X und Y, um Koordinaten relativ zum ungedrehten Rahmen zu erhalten.

Die extrahierten Punkte berücksichtigen nicht die Rotation der Form, die von [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) zurückgegeben wird, noch horizontale bzw. vertikale Spiegelungen. Um die angezeigte Kontur wiederzugeben, wenden Sie diese Transformationen um den Mittelpunkt der Form an. Für gruppierte Formen berücksichtigen Sie zusätzlich das Koordinaten‑Mapping und die Transformationen der Gruppe; gehen Sie nicht davon aus, dass die extrahierten Punkte bereits die endgültigen Folienkoordinaten darstellen oder dass eine Translation bzw. Skalierung doppelt angewendet werden muss.

**Inspektion versus Bearbeitung.** Extrahierte Arrays beschreiben die Kontur; das Ändern dieser Arrays aktualisiert die ursprüngliche Form nicht. Verwenden Sie diesen Ansatz, wenn Ihre Analyse‑ oder Zeichen‑Logik Punkt‑/Typ‑Arrays benötigt. Nutzen Sie [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--), wenn Sie Geometrie‑Befehle im lokalen Koordinatensystem der Form benötigen oder die Geometrie bearbeiten möchten. Wenden Sie bearbeitete Pfade über [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) bzw. [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) an.

## **FAQ**

**Was passiert mit Füllung und Kontur, wenn die Geometrie ersetzt wird?**  
Der Stil bleibt bei der Form erhalten; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie rotiere ich eine benutzerdefinierte Form zusammen mit ihrer Geometrie korrekt?**  
Verwenden Sie die Methode [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) der Form; die Geometrie rotiert mit der Form, weil sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis „einzusperren“?**  
Ja. Exportieren Sie den gewünschten [Folie](/slides/de/androidjava/convert-powerpoint-to-png/)‑Bereich oder die [Form](/slides/de/androidjava/create-shape-thumbnails/) selbst in ein Rasterformat; das erleichtert die weitere Arbeit mit komplexen Geometrien.