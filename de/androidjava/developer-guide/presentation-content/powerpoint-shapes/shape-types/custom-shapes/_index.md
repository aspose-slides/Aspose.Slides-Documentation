---
title: Anpassen von Präsentationsformen auf Android
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
- Bearbeitungspunkte
- Punkt hinzufügen
- Punkt entfernen
- Bearbeitungsoperation
- abgerundete Ecke
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen und Anpassen von Formen in PowerPoint-Präsentationen mit Aspose.Slides für Android via Java: Geometriepfade, abgerundete Ecken, zusammengesetzte Formen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Präsentationsformen in Aspose.Slides anpassen, indem Sie die Formgeometrie über Bearbeitungspunkte und Geometriepfade bearbeiten. Er zeigt, wie Sie mit [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) und [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) arbeiten, um vorhandene Formen zu modifizieren, grundlegende Pfadbearbeitungsoperationen durchzuführen, Punkte hinzuzufügen oder zu entfernen und die aktualisierte Geometrie wieder einer Form zuzuweisen. Außerdem wird gezeigt, wie benutzerdefinierte und zusammengesetzte Formen erstellt, Formen mit abgerundeten Ecken gebaut, festgestellt, ob eine Formgeometrie geschlossen ist, und Formelemente mit Android-Punktarrays inspiziert werden.

## **Form mit Bearbeitungspunkten ändern**

In PowerPoint können Sie **Edit Points** verwenden, um ein Quadrat zu ändern:

* Einen Eckpunkt nach innen oder außen verschieben.
* Die Krümmung an einem Punkt anpassen.
* Neue Punkte hinzufügen.

Durch das Bearbeiten von Punkten können Sie die Kontur einer Form ändern oder eine vorhandene Form als Basis für eine neue verwenden.

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Beim Bearbeiten von PowerPoint-Formen sollten Sie diese Konzepte im Hinterkopf behalten:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Der Pfad einer Form besteht aus Ankerpunkten, die durch Segmente verbunden sind.
* Ein Segment kann gerade oder gekrümmt sein. Ankerpunkte und Steuergriffe bestimmen dessen Form.
* Ankerpunkte existieren als Eckpunkte, gerade Punkte oder glatte Punkte:
  * An einem Eckpunkt können angrenzende Segmente in einem Winkel zusammentreffen.
  * An einem glatten Punkt sind die beiden Steuergriffe ausgerichtet und gleich weit vom Ankerpunkt entfernt.
  * An einem geraden Punkt sind die beiden Steuergriffe ausgerichtet, können jedoch unterschiedliche Abstände vom Ankerpunkt haben.
* Das Verschieben von Ankerpunkten oder das Anpassen ihrer Griffe verändert die Kontur der Form.

Um PowerPoint-Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) und das Interface [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) bereit.

* Eine [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)‑Instanz stellt einen Geometriepfad des [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/)-Objekts dar.
* Um den [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) von der [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/)-Instanz abzurufen, können Sie die Methode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) verwenden.
* Um den [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) für eine Form festzulegen, können Sie diese Methoden verwenden: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) für Formen mit einem einzelnen Pfad und [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) für Formen mit mehreren Pfaden.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) verwenden.
* Mit den Methoden [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) und [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) können Sie das Erscheinungsbild eines Geometriepfads festlegen.
* Mit der Methode [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) können Sie den Geometriepfad einer [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) als Array von Pfadsegmenten abrufen.

## **Einfache Bearbeitungsoperationen**

Verwenden Sie die folgenden Methoden, um einen Geometriepfad zu bearbeiten. Überladungen, die einen Index akzeptieren, fügen ein Segment an dieser nullbasierten Position im Segment‑Array des Pfades ein.

| Vorgang | Methode |
| --- | --- |
| Eine gerade Linie anhängen oder einfügen. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Eine kubische Bézier‑Kurve mit zwei Steuerpunkten und einem Endpunkt anhängen oder einfügen. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Eine quadratische Bézier‑Kurve mit einem Steuerpunkt und einem Endpunkt anhängen oder einfügen. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Ein elliptisches Bogensegment mit den angegebenen Abmessungen und Winkeln in Grad anhängen. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Die aktuelle Figur schließen, indem das Endpunkt mit dem Startpunkt verbunden wird. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Den Startpunkt einer Figur festlegen. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Ein Segment an einem nullbasierten Index entfernen. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

Dieses Beispiel fügt einer rechteckigen Form mithilfe von [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) zwei Punkte hinzu und wendet den bearbeiteten Pfad mit [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) an. Die Koordinaten sind relativ zur Form: beide neuen Punkte liegen in ihrer Mitte, 100 Punkte vom linken Rand und 50 Punkte vom oberen Rand entfernt. Segment‑Indizes 1 und 4 platzieren sie an den oberen bzw. unteren Kanten und ziehen diese Kanten nach innen.

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

Dieses Beispiel ändert die Kontur einer herzförmigen Form, indem das Segment am nullbasierten Index 2 mit [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) entfernt wird. Durch das Anwenden des modifizierten Pfads mit [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) wird die Kontur der Form aktualisiert.

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

Dieses Beispiel erstellt einen fünfzackigen Stern mit [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Abwechselnde äußere und innere Radien von 100 bzw. 50 Punkten definieren die Spitzen und Einziehungen; ein Schritt von 72 Grad verteilt die fünf Spitzen gleichmäßig. Der Pfad wird mit [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) geschlossen und mittels [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) auf eine rechteckige Form angewendet, wodurch deren Kontur ersetzt wird.

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

Dieses Beispiel definiert zwei geschlossene [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)‑Objekte für das obere und untere Drittel einer Form. Das Anwenden beider Pfade mit [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) erzeugt eine einzige zusammengesetzte Form mit einer Lücke über ihr mittleres Drittel.

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

Dieses Beispiel kombiniert gerade Segmente mit [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) , um eine Form mit nach innen gekrümmten Ecken zu erzeugen. Jede Eckgröße legt die Breite und Höhe des Bogens in Punkten fest, und der -90‑Grad‑Bogen zeichnet ein gegen den Uhrzeigersinn verlaufendes Viertel‑Ellipse. Der fertige Pfad wird mit [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) angewendet, und die Präsentation wird im PPTX‑Format gespeichert.

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

Der folgende Helfer prüft, ob jeder nicht leere Geometriepfad mit einem Schließsegment endet. Er liest [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) und vergleicht das letzte Segment‑[IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) mit [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). Er gibt false zurück, wenn keine nicht leeren Pfade vorhanden sind. Dabei wird nur das abschließende Kommando jedes Pfads geprüft; nicht jedes Unter‑Figure im Pfad wird inspiziert. Das Beispiel gibt `true` für ein Rechteck aus.

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

## **Formelemente extrahieren und inspizieren**

Verwenden Sie [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) , um eine vorhandene Form als Elemente zu inspizieren, die Pfadpunkte und Punkt­typen enthalten. Casten Sie jedes zurückgegebene [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) zu [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) , um die Punkt‑ und Typ‑Arrays über die Methoden [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) und [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) abzurufen. Diese Darstellung ist nützlich für Konturanalysen oder zum Weitergeben von Geometrie an benutzerdefinierte Zeichenwerkzeuge.

Das Beispiel öffnet input.pptx, findet die erste Geometrie‑Form direkt auf der ersten Folie und gibt deren Pfadsegmente aus. Verwenden Sie eine Präsentation, die eine Form mit geraden und gekrümmten Segmenten enthält, um beide Ausgabetypen zu sehen. Es durchsucht nicht die Gruppen.

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
                        i += 2; // Verarbeite sowohl die Steuerpunkte als auch den Endpunkt.
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

Die Arrays entsprechen dem Index: `points[i]` ist ein Punkt und `types[i]` beschreibt seine Rolle. Typ `0` startet eine Figur, und Typ `1` zeichnet eine Linie vom vorherigen Punkt zum aktuellen Punkt. Ein kubisches Bézier‑Segment beginnt am vorherigen Endpunkt und verwendet drei aufeinander folgende Typ‑`3`‑Einträge: zwei Steuerpunkte gefolgt vom neuen Endpunkt. Die Schleife verarbeitet diese drei Einträge zusammen und prüft den Endpunkt auf Schließung.

Punkt­typen enthalten außerdem Flags. Maskieren Sie mit `0x07`, um den Segmenttyp zu ermitteln, und testen Sie `0x80` separat, um einen geschlossenen Unterpfad zu erkennen. Beispiel: `129` (`0x81`) bedeutet ein Linien‑Endpunkt, der einen Unterpfad schließt, und `131` (`0x83`) bedeutet ein Bézier‑Endpunkt, der einen schließt. Java speichert diese Flags in signierten Bytes; das Maskieren bewahrt die beabsichtigten Bit‑Werte. Ein Vergleich des Rohwerts nur mit `1` oder `3` würde diese Fälle übersehen. Andere Flags, wie Strich (`0x10`) und Marker (`0x20`), ändern den Grundsegmenttyp nicht.

**Koordinaten und Transformationen.** Punkte werden in Punkten (1/72 Zoll) gemessen, wobei X nach rechts und Y nach unten zunimmt. Für eine nicht gruppierte Form enthalten die extrahierten Koordinaten bereits die Position, die von [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) und [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) zurückgegeben wird, und spiegeln ihre aktuelle Breite und Höhe wider. Beispiel: Ein nicht gedrehtes Rechteck bei `(100, 200)` mit Größe `120 × 80` hat Konturgrenzen `(100, 200)`–`(220, 280)`. Addieren Sie die Position der Form nicht erneut. Subtrahieren Sie ihr X und Y, um Koordinaten relativ zu ihrem unrotierten Rahmen zu erhalten.

Die extrahierten Punkte berücksichtigen nicht die Drehung der Form, die von [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) zurückgegeben wird, sowie horizontale und vertikale Spiegelungen. Um die angezeigte Kontur wiederzugeben, wenden Sie diese Transformationen um das Zentrum der Form herum an. Für gruppierte Formen berücksichtigen Sie ebenfalls die Gruppierungs‑Koordinatenabbildung und Transformationen; gehen Sie nicht davon aus, dass die extrahierten Punkte die endgültigen gerenderten Folienkoordinaten sind, und wenden Sie keine Translation oder Skalierung doppelt an, wenn diese bereits im Rahmen des Kindes enthalten ist.

**Inspektion vs. Bearbeitung.** Extrahierte Arrays beschreiben die Kontur; deren Änderung aktualisiert die ursprüngliche Form nicht. Wählen Sie diesen Ansatz, wenn Ihre Analyse‑ oder Zeichen‑Logik Punkt‑/Typ‑Arrays benötigt. Verwenden Sie [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) , wenn Sie Geometrie‑Kommandos im lokalen Koordinatensystem der Form benötigen oder ihre Geometrie bearbeiten wollen. Anwenden bearbeiteter Pfade erfolgt über [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) oder [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **FAQ**

**Was passiert mit Füllung und Kontur, nachdem die Geometrie ersetzt wurde?**

Der Stil bleibt bei der Form; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie rotiere ich eine benutzerdefinierte Form zusammen mit ihrer Geometrie korrekt?**

Verwenden Sie die Methode [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) der Form; die Geometrie rotiert mit der Form, da sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis „abzusichern“?**

Ja. Exportieren Sie den gewünschten [Folie](/slides/de/androidjava/convert-powerpoint-to-png/)‑Bereich oder die [Form](/slides/de/androidjava/create-shape-thumbnails/) selbst in ein Rasterformat; dies erleichtert die weitere Arbeit mit komplexen Geometrien.