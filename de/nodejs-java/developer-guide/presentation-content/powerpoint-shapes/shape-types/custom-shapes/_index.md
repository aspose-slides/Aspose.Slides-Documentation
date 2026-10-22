---
title: Präsentationsformen in JavaScript anpassen
linktitle: Benutzerdefinierte Form
type: docs
weight: 20
url: /de/nodejs-java/custom-shape/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen und Anpassen von Formen in PowerPoint-Präsentationen mit JavaScript und Aspose.Slides für Node.js: Geometriepfade, abgerundete Ecken, zusammengesetzte Formen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Präsentationsformen in Aspose.Slides durch Bearbeiten der Formen‑Geometrie mittels Bearbeitungspunkten und Geometriepfaden anpasst. Er zeigt, wie man mit [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) arbeitet, um vorhandene Formen zu ändern, grundlegende Pfadbearbeitungs‑Operationen durchzuführen, Punkte hinzuzufügen oder zu entfernen und die aktualisierte Geometrie wieder einer Form zuzuweisen. Er demonstriert zudem, wie man benutzerdefinierte und zusammengesetzte Formen erstellt, Formen mit abgerundeten Ecken baut, ermittelt, ob eine Formen‑Geometrie geschlossen ist, Formelemente inspiziert und Java‑AWT‑Textkonturen in Geometriepfade konvertiert.

## **Form mit Bearbeitungspunkten ändern**

In PowerPoint können Sie **Edit Points** verwenden, um ein Quadrat zu verändern:

* Einen Eckpunkt nach innen oder außen verschieben.
* Die Krümmung an einem Punkt anpassen.
* Neue Punkte hinzufügen.

Durch das Bearbeiten von Punkten können Sie die Kontur einer Form ändern oder eine vorhandene Form als Grundlage für eine neue verwenden.

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Beim Bearbeiten von PowerPoint‑Formen sollten Sie diese Konzepte im Hinterkopf behalten:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Der Pfad einer Form besteht aus Ankerpunkten, die durch Segmente verbunden sind.
* Ein Segment kann gerade oder kurvig sein. Ankerpunkte und Steuergriffe bestimmen dessen Form.
* Ankerpunkte können Eckpunkte, Gerade‑Punkte oder Glatt‑Punkte sein:
  * Bei einem Eckpunkt können benachbarte Segmente in einem Winkel aufeinandertreffen.
  * Bei einem glatten Punkt sind die beiden Steuergriffe ausgerichtet und haben denselben Abstand zum Ankerpunkt.
  * Bei einem geraden Punkt sind die beiden Steuergriffe ausgerichtet, können jedoch unterschiedliche Abstände zum Ankerpunkt haben.
* Das Verschieben von Ankerpunkten oder das Anpassen ihrer Griffe verändert die Kontur der Form.

Um PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) bereit.

* Eine [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)‑Instanz repräsentiert einen Geometriepfad des Objekts [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/).
* Um das [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) aus der [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/)-Instanz zu erhalten, können Sie die Methode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) verwenden.
* Um das [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) für eine Form festzulegen, können Sie diese Methoden verwenden: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) für Formen mit einem einzelnen Pfad und [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) für Formen mit mehreren Pfaden.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) nutzen.
* Mit den Methoden [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) und [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) können Sie das Aussehen eines Geometriepfads festlegen.
* Mit der Methode [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) können Sie den Geometriepfad einer [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) als Array von Pfadsegmenten abrufen.
* Um zusätzliche Optionen zur Anpassung der Formen‑Geometrie zu erhalten, können Sie ein [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) über dessen [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) auslesen und die Segmente auf einem [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) wiedergeben.

## **Einfache Bearbeitungs‑Operationen**

Verwenden Sie die folgenden Methoden, um einen Geometriepfad zu bearbeiten. Überladungen, die einen Index akzeptieren, fügen ein Segment an dieser nullbasierten Position im Segment‑Array des Pfades ein.

| Operation | Method |
| --- | --- |
| Eine gerade Linie anhängen oder einfügen. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Eine kubische Bézier‑Kurve mit zwei Steuerpunkten und einem Endpunkt anhängen oder einfügen. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Eine quadratische Bézier‑Kurve mit einem Steuerpunkt und einem Endpunkt anhängen oder einfügen. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Ein elliptisches Bogensegment mit den angegebenen Abmessungen und Winkeln (in Grad) anhängen. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Die aktuelle Figur schließen, indem ihr Endpunkt mit dem Startpunkt verbunden wird. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Den Startpunkt einer Figur festlegen. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Ein Segment an einem nullbasierten Index entfernen. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

Dieses Beispiel fügt einer rechteckigen Form mit [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) zwei Punkte hinzu und wendet den bearbeiteten Pfad mit [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) an. Die Koordinaten sind relativ zur Form: beide neuen Punkte liegen in ihrer Mitte, 100 Punkte von links und 50 Punkte von oben. Die Segmentindizes 1 und 4 positionieren sie an den oberen bzw. unteren Kanten und ziehen diese nach innen.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Punkte aus einer Form entfernen**

Dieses Beispiel ändert die Kontur einer herzförmigen Form, indem es das Segment am nullbasierten Index 2 mit [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) entfernt. Das Anwenden des modifizierten Pfades mit [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) aktualisiert die Kontur der Form.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Eine benutzerdefinierte Form erstellen**

Dieses Beispiel erstellt einen fünfzackigen Stern mit [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Wechselnde äußere und innere Radien von 100 bzw. 50 Punkten definieren die Spitzen und Einziehungen; ein Schritt von 72 Grad verteilt die fünf Spitzen gleichmäßig. Der Pfad wird mit [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) geschlossen und über [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) auf eine rechteckige Form angewendet, wodurch deren Kontur ersetzt wird.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Eine zusammengesetzte benutzerdefinierte Form erstellen**

Dieses Beispiel definiert zwei geschlossene [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)‑Objekte für das obere und untere Drittel einer Form. Das Anwenden beider Pfade mit [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) erzeugt eine einzelne zusammengesetzte Form mit einer Lücke im mittleren Drittel.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Eine benutzerdefinierte Form mit abgerundeten Ecken erstellen**

Dieses Beispiel kombiniert gerade Segmente mit [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo), um eine Form mit nach innen gekrümmten Ecken zu erzeugen. Jede Eckgröße legt die Breite und Höhe des Bogens in Punkten fest, und der -90‑Grad‑Bogen zeichnet ein gegen den Uhrzeigersinn gerichtetes Viertel‑Ellipse. Der fertige Pfad wird mit [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) angewendet und die Präsentation im PPTX‑Format gespeichert.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Herausfinden, ob eine Formgeometrie geschlossen ist**

Der folgende Helfer prüft, ob jeder nicht‑leere Geometriepfad mit einem Schließsegment endet. Er liest [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) und vergleicht den Befehls­typ des letzten Segments [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) mit [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). Er gibt false zurück, wenn es keine nicht‑leeren Pfade gibt. Dabei wird nur das abschließende Kommando jedes Pfades geprüft; nicht jedes Unter‑Figurelement eines Pfades wird inspiziert. Das Beispiel gibt `true` für ein Rechteck aus.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **Formelemente extrahieren und inspizieren**

Verwenden Sie [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements), um eine vorhandene Form als Elemente zu inspizieren, die Pfadpunkte und Punkt‑Typen enthalten. Verwenden Sie jedes zurückgegebene [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) , um über die Methoden [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) und [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) die Punkte‑ und Typ‑Arrays abzurufen. Diese Darstellung ist nützlich für Konturanalysen oder um Geometrie an benutzerdefinierte Zeichenwerkzeuge zu übergeben.

Das Beispiel öffnet input.pptx, findet die erste Geometrie‑Form direkt auf der ersten Folie und gibt deren Pfadsegmente aus. Verwenden Sie eine Präsentation, die eine Form mit geraden und gekrümmten Segmenten enthält, um beide Ausgabetypen zu sehen. Es wird nicht in Gruppen gesucht.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // Behalte den Segmenttyp, ohne Flags.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Die Arrays entsprechen einander nach Index: `points[i]` ist ein Punkt und `types[i]` beschreibt dessen Rolle. Typ `0` startet eine Figur, und Typ `1` zeichnet eine Linie vom vorherigen Punkt zum aktuellen Punkt. Ein kubisches Bézier‑Segment beginnt am vorherigen Endpunkt und verwendet drei aufeinanderfolgende Einträge des Typs `3`: zwei Steuerpunkte gefolgt vom neuen Endpunkt. Die Schleife verarbeitet diese drei Einträge zusammen und prüft den Endpunkt auf Schließung.

Punkt‑Typen enthalten außerdem Flags. Maskieren Sie mit `0x07`, um den Segmenttyp zu ermitteln, und prüfen Sie `0x80` separat, um einen geschlossenen Unterpfad zu erkennen. Zum Beispiel bedeutet `129` (`0x81`), dass ein Linien‑Endpunkt einen Unterpfad schließt, und `131` (`0x83`) bedeutet, dass ein Bézier‑Endpunkt einen schließt. Java speichert diese Flags in signierten Bytes; das Maskieren erhält die beabsichtigten Bitwerte. Ein Vergleich des Rohwerts nur mit `1` oder `3` würde diese Fälle übersehen. Andere Flags, wie Strich (`0x10`) und Marker (`0x20`), ändern den Basis‑Segmenttyp nicht.

**Koordinaten und Transformationen.** Punkte werden in Punkten (1/72 Zoll) gemessen, wobei X nach rechts und Y nach unten zunimmt. Für eine nicht gruppierte Form enthalten die extrahierten Koordinaten bereits die Position, die von [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) und [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) zurückgegeben wird, und spiegeln ihre aktuelle Breite und Höhe wider. Zum Beispiel hat ein nicht gedrehtes Rechteck bei `(100, 200)` mit Größe `120 × 80` Konturgrenzen `(100, 200)`–`(220, 280)`. Addieren Sie die Position der Form nicht erneut. Subtrahieren Sie ihr X und Y, um Koordinaten relativ zu ihrem nicht gedrehten Rahmen zu erhalten.

Die extrahierten Punkte berücksichtigen nicht die Rotation der Form, die von [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation) zurückgegeben wird, noch horizontale und vertikale Spiegelungen. Um die angezeigte Kontur wiederzugeben, wenden Sie diese Transformationen um das Zentrum der Form herum an. Für gruppierte Formen berücksichtigen Sie zudem die Koordinatentransformationen der Gruppe; gehen Sie nicht davon aus, dass die extrahierten Punkte die endgültigen gerenderten Folienkoordinaten sind, oder wenden Sie eine Verschiebung bzw. Skalierung nicht doppelt an, wenn sie bereits im Rahmen des Unterobjekts enthalten ist.

**Inspektion vs. Bearbeitung.** Extrahierte Arrays beschreiben die Kontur; deren Änderung aktualisiert die ursprüngliche Form nicht. Verwenden Sie diesen Ansatz, wenn Ihre Analyse‑ oder Zeichenlogik Punkt‑/Typ‑Arrays benötigt. Nutzen Sie [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths), wenn Sie Geometrie‑Befehle im lokalen Koordinatensystem der Form benötigen oder deren Geometrie bearbeiten möchten. Wenden Sie bearbeitete Pfade über [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) oder [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) an.

## **Ein Java AWT‑Shape in GeometryPath konvertieren**

Dieses Beispiel kombiniert eine rechteckige Kontur mit in Geometrie konvertiertem Text. Die Methode [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) der Kontur deaktiviert deren Füllung. Ein [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) erzeugt die Textkontur in einem [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Sein [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) liefert Bewegungs‑, Linien‑, quadratische, kubische und Schließ‑Segmente, die das Beispiel auf einem [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) wieder abspielt.

Die Java‑Brücke verwendet explizite Float‑ und Byte‑Werte für die entsprechenden Java‑Parameter. Der Iterator schreibt Koordinaten in ein Java‑Float‑Array; Reflexion liest die aktualisierten Werte zurück nach JavaScript. Der Text verwendet eine 40‑Punkt‑Arial‑Schrift. Die Kontur wird um 20 Punkte horizontal verschoben und mit ihrer visuellen Oberkante 10 Punkte unter der Oberkante der Form positioniert. Der Textpfad ist gefüllt, während das ursprüngliche Rechteck eine Kontur bleibt. Das Anwenden beider Pfade mit [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) erzeugt eine einzelne Form, die das Rechteck und den Text enthält.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // Bewegen zu.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Linie zu.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // Quadratische Bézier-Kurve.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Kubische Bézier-Kurve.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Figur schließen.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Was passiert mit Füllung und Kontur, nachdem die Geometrie ersetzt wurde?**

Der Stil bleibt bei der Form erhalten; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie drehe ich eine benutzerdefinierte Form zusammen mit ihrer Geometrie korrekt?**

Verwenden Sie die Methode [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) der Form; die Geometrie rotiert mit der Form, da sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis zu „sperren“?**

Ja. Exportieren Sie den gewünschten [slide](/slides/de/nodejs-java/convert-powerpoint-to-png/)‑Bereich oder die [shape](/slides/de/nodejs-java/create-shape-thumbnails/)‑Selbst in ein Rasterformat; dies erleichtert die weitere Arbeit mit komplexen Geometrien.