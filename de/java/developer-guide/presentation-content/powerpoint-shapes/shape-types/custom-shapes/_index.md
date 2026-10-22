---
title: Präsentationsformen in Java anpassen
linktitle: Benutzerdefinierte Form
type: docs
weight: 20
url: /de/java/custom-shape/
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
- Java
- Aspose.Slides
description: "Erstellen und anpassen von Formen in PowerPoint-Präsentationen mit Aspose.Slides für Java: Geometriepfade, abgerundete Ecken, zusammengesetzte Formen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Präsentationsformen in Aspose.Slides anpasst, indem man die Formgeometrie über Bearbeitungspunkte und Geometriepfade bearbeitet. Er zeigt, wie man mit [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) und [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) bestehende Formen modifiziert, grundlegende Pfad‑Bearbeitungsoperationen durchführt, Punkte hinzufügt oder entfernt und die aktualisierte Geometrie wieder einer Form zuweist.

Außerdem wird demonstriert, wie man benutzerdefinierte und zusammengesetzte Formen erstellt, Formen mit abgerundeten Ecken baut, ermittelt, ob eine Formgeometrie geschlossen ist, Formelemente inspiziert und Java‑AWT‑Textumrisse in Geometriepfade konvertiert.

## **Form mit Bearbeitungspunkten ändern**

In PowerPoint können Sie **Bearbeitungspunkte** verwenden, um ein Quadrat zu verändern:

* Einen Eckpunkt nach innen oder außen verschieben.
* Die Krümmung an einem Punkt anpassen.
* Neue Punkte hinzufügen.

Das Bearbeiten von Punkten ermöglicht es, die Kontur einer Form zu verändern oder eine vorhandene Form als Grundlage für eine neue zu nutzen.

## **Tipps zum Bearbeiten von Formen**

![overview_image](custom_shape_0.png)

Beim Bearbeiten von PowerPoint‑Formen sollten Sie diese Konzepte beachten:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Der Pfad einer Form besteht aus Ankerpunkten, die durch Segmente verbunden sind.
* Ein Segment kann gerade oder gekrümmt sein. Ankerpunkte und Steuer‑Handles bestimmen seine Form.
* Ankerpunkte können Eckpunkte, gerade Punkte oder glatte Punkte sein:
  * An einem Eckpunkt können benachbarte Segmente einen Winkel bilden.
  * An einem glatten Punkt sind die beiden Steuer‑Handles ausgerichtet und gleichweit vom Ankerpunkt entfernt.
  * An einem geraden Punkt sind die beiden Steuer‑Handles ausgerichtet, können jedoch unterschiedliche Abstände zum Ankerpunkt haben.
* Das Verschieben von Ankerpunkten oder das Anpassen ihrer Handles ändert die Kontur der Form.

Um PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) und das Interface [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) bereit.

* Eine Instanz von [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) stellt den Geometriepfad des Objekts [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) dar.
* Um den [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) aus einer [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/)‑Instanz zu erhalten, können Sie die Methode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) verwenden.
* Um den [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) für eine Form festzulegen, können Sie diese Methoden verwenden: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) für Formen mit einem einzelnen Pfad und [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) für Formen mit mehreren Pfaden.
* Zum Hinzufügen von Segmenten können Sie die Methoden unter [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) nutzen.
* Mit den Methoden [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) und [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) können Sie das Aussehen eines Geometriepfads festlegen.
* Durch Aufruf von [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) erhalten Sie den Geometriepfad einer [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) als Array von Pfadsegmenten.
* Um zusätzliche Optionen zur Anpassung der Formgeometrie zu nutzen, können Sie ein [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) über dessen [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) auslesen und die Segmente auf einem [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) reproduzieren.

## **Einfache Bearbeitungsoperationen**

Verwenden Sie die folgenden Methoden, um einen Geometriepfad zu bearbeiten. Überladungen, die einen Index akzeptieren, fügen ein Segment an dieser nullbasierten Position im Segment‑Array des Pfads ein.

| Operation | Methode |
| --- | --- |
| Eine gerade Linie anhängen oder einfügen. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Eine kubische Bézier‑Kurve mit zwei Kontrollpunkten und einem Endpunkt anhängen oder einfügen. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Eine quadratische Bézier‑Kurve mit einem Kontrollpunkt und einem Endpunkt anhängen oder einfügen. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Einen elliptischen Bogen mit den angegebenen Maßen und Winkeln in Grad anhängen. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Die aktuelle Figur schließen, indem ihr Endpunkt mit dem Startpunkt verbunden wird. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Den Startpunkt einer Figur festlegen. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Ein Segment an einem nullbasierten Index entfernen. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

Dieses Beispiel fügt einer rechteckigen Form zwei Punkte über [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) ein und wendet den bearbeiteten Pfad mit [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) an. Die Koordinaten sind relativ zur Form: beide neuen Punkte liegen in der Mitte, 100 Punkte vom linken Rand und 50 Punkte vom oberen Rand. Die Segment‑Indizes 1 und 4 platzieren sie an den oberen bzw. unteren Kanten und ziehen diese nach innen.

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

Dieses Beispiel ändert die Kontur einer herzförmigen Form, indem es das Segment am nullbasierten Index 2 mit [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) entfernt. Das Anwenden des modifizierten Pfads über [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) aktualisiert die Kontur der Form.

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

Dieses Beispiel erzeugt einen fünfzackigen Stern mithilfe von [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). Wechselnde äußere und innere Radien von 100  bzw. 50 Punkten definieren die Spitzen und Einziehungen; ein Schritt von 72 Grad verteilt die fünf Spitzen gleichmäßig. Der Pfad wird mit [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) geschlossen und über [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) einer rechteckigen Form zugewiesen, sodass deren Kontur ersetzt wird.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
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

Dieses Beispiel definiert zwei geschlossene [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)‑Objekte für das obere und das untere Drittel einer Form. Das Anwenden beider Pfade mit [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) erzeugt eine einzige zusammengesetzte Form mit einer Lücke im mittleren Drittel.

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

Dieses Beispiel kombiniert gerade Segmente mit [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) , um eine Form mit nach innen gekrümmten Ecken zu erzeugen. Jede Eckgröße legt die Breite und Höhe des Bogens in Punkten fest, und der Sweep‑Winkel von ‑90 Grad zeichnet ein gegen den Uhrzeigersinn verlaufendes Viertel‑Ellipse‑Segment. Der fertige Pfad wird mit [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) angewendet, und die Präsentation wird im PPTX‑Format gespeichert.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

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

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

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

Der folgende Helfer prüft, ob jeder nicht leere Geometriepfad mit einem Schließsegment endet. Er liest [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) und vergleicht den Befehl des letzten Segments mit [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) gegen [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). Gibt **false** zurück, wenn keine nicht leeren Pfade vorhanden sind. Dabei wird nur der letzte Befehl jedes Pfads geprüft; nicht jedes Teil‑Figure innerhalb eines Pfads. Das Beispiel gibt `true` für ein Rechteck aus.

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

## **Formelemente extrahieren und analysieren**

Verwenden Sie [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) , um eine vorhandene Form als Elemente zu inspizieren, die Pfad‑Punkte und Punkt‑Typen enthalten. Casten Sie jedes zurückgegebene [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) zu [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/), um über die Methoden [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) und [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) auf die jeweiligen Arrays zuzugreifen. Diese Darstellung ist nützlich für Konturanalysen oder zum Weitergeben der Geometrie an benutzerdefinierte Zeichenwerkzeuge.

Das Beispiel öffnet *input.pptx*, findet die erste Geometrie‑Form auf der ersten Folie und gibt deren Pfadsegmente aus. Verwenden Sie eine Präsentation, die eine Form mit geraden und gekrümmten Segmenten enthält, um beide Ausgaben zu sehen. Es wird nicht innerhalb von Gruppen gesucht.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

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
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Behalte den Segmenttyp, ohne die Flags.
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

Die Arrays korrespondieren nach Index: `points[i]` ist ein Punkt und `types[i]` beschreibt seine Rolle. Typ `0` startet eine Figur, Typ `1` zeichnet eine Linie vom vorherigen Punkt zum aktuellen Punkt. Ein kubisches Bézier‑Segment startet am vorherigen Endpunkt und verwendet drei aufeinanderfolgende Typ‑`3`‑Einträge: zwei Kontrollpunkte gefolgt vom neuen Endpunkt. Die Schleife verarbeitet diese drei Einträge zusammen und prüft den Endpunkt auf Geschlossenheit.

Punkt‑Typen enthalten außerdem Flags. Maskieren Sie mit `0x07`, um den Segment‑Typ zu ermitteln, und prüfen Sie `0x80` separat, um einen geschlossenen Sub‑Path zu erkennen. Beispiel: `129` (`0x81`) bedeutet ein Linien‑Endpunkt, der einen Sub‑Path schließt, und `131` (`0x83`) bedeutet ein Bézier‑Endpunkt, der schließt. Java speichert diese Flags in signierten Bytes; das Maskieren bewahrt die beabsichtigten Bit‑Werte. Ein bloßer Vergleich des Rohwerts mit `1` oder `3` würde diese Fälle übersehen. Weitere Flags, wie Strich (`0x10`) und Marker (`0x20`), ändern den Basis‑Segment‑Typ nicht.

**Koordinaten und Transformationen.** Punkte werden in Punkten (1/72 Zoll) gemessen, wobei X nach rechts und Y nach unten zunimmt. Für eine nicht gruppierte Form beinhalten die extrahierten Koordinaten bereits die Position, die über [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) bzw. [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) zurückgegeben wird, und spiegeln die aktuelle Breite und Höhe wider. Beispiel: Ein nicht gedrehtes Rechteck bei `(100, 200)` mit Größe `120 × 80` hat Kontur‑Grenzen `(100, 200)`–`(220, 280)`. Fügen Sie die Position der Form nicht erneut hinzu. Subtrahieren Sie X und Y, um Koordinaten relativ zu ihrem ungedrehten Rahmen zu erhalten.

Die extrahierten Punkte berücksichtigen nicht die Drehung der Form, die über [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) zurückgegeben wird, noch horizontale bzw. vertikale Spiegelungen. Um die angezeigte Kontur wiederzugeben, müssen diese Transformationen um das Zentrum der Form angewendet werden. Bei gruppierten Formen sind zudem die Gruppen‑Koordinaten‑Abbildung und Transformationen zu berücksichtigen; gehen Sie nicht davon aus, dass die extrahierten Punkte bereits die endgültigen Folien‑Koordinaten darstellen, und vermeiden Sie doppelte Übersetzungen oder Skalierungen.

**Inspektion vs. Bearbeitung.** Extrahierte Arrays beschreiben die Kontur; Änderungen daran aktualisieren die ursprüngliche Form nicht. Verwenden Sie diesen Ansatz, wenn Ihre Analyse‑ oder Zeichen‑Logik Punkt‑/Typ‑Arrays benötigt. Nutzen Sie [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) , wenn Sie Geometrie‑Kommandos im lokalen Koordinatensystem der Form benötigen oder die Geometrie bearbeiten wollen. Wenden Sie bearbeitete Pfade über [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) bzw. [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) an.

## **Ein Java AWT Shape in GeometryPath umwandeln**

Dieses Beispiel kombiniert einen rechteckigen Umriss mit Text, der in Geometrie konvertiert wurde. Der Aufruf von [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) deaktiviert die Füllung des Umrisses. Ein [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) erzeugt den Textumriss in einem [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Sein [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) liefert Move‑, Line‑, Quadratic‑, Cubic‑ und Closing‑Segmente, die das Beispiel auf einem [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) wiederholt.

Der Text verwendet die 40‑Punkt‑Arial‑Schrift. Der Umriss wird horizontal um 20 Punkte verschoben und vertikal so positioniert, dass seine visuelle Oberkante 10 Punkte unter der Oberkante der Form liegt. Der Textpfad wird gefüllt, während das ursprüngliche Rechteck ein Umriss bleibt. Das Anwenden beider Pfade mit [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) erzeugt eine einzige Form, die sowohl das Rechteck als auch den Text enthält.

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // Neue Form erstellen
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Geometriepfad der Form abrufen
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Neuen Grafikpfad mit Text erstellen
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // Grafikpfad in Geometriepfad konvertieren
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // Kombination aus neuem Geometriepfad und ursprünglichem Geometriepfad der Form setzen
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Was passiert mit Füllung und Kontur, wenn die Geometrie ersetzt wird?**

Der Stil bleibt an der Form erhalten; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie drehe ich eine benutzerdefinierte Form korrekt zusammen mit ihrer Geometrie?**

Verwenden Sie die Methode [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) der Form; die Geometrie dreht sich mit der Form, da sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis „einzusperren“?**

Ja. Exportieren Sie den gewünschten [slide](/slides/de/java/convert-powerpoint-to-png/)‑Bereich oder die [shape](/slides/de/java/create-shape-thumbnails/) selbst in ein Rasterformat; das erleichtert die weitere Arbeit mit komplexen Geometrien.