---
title: Benutzerdefinierte Form
type: docs
weight: 20
url: /de/nodejs-java/custom-shape/
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
- JavaScript
- Aspose.Slides für Node.js via Java
description: "Fügen Sie einer PowerPoint-Präsentation in JavaScript eine benutzerdefinierte Form hinzu"
---

## **Eine Form mit Bearbeitungspunkten ändern**

Betrachten Sie ein Quadrat. In PowerPoint können Sie mit **Bearbeitungspunkten** 

* die Ecke des Quadrats nach innen oder außen verschieben
* die Krümmung für eine Ecke oder einen Punkt festlegen
* neue Punkte zum Quadrat hinzufügen
* Punkte auf dem Quadrat manipulieren usw. 

Im Wesentlichen können Sie die beschriebenen Aufgaben an jeder Form ausführen. Mit Bearbeitungspunkten können Sie eine Form ändern oder aus einer vorhandenen Form eine neue Form erstellen. 

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Bevor Sie beginnen, PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, sollten Sie diese Punkte zu Formen berücksichtigen:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Wenn eine Form geschlossen ist, fehlt ein Start‑ oder Endpunkt. Wenn eine Form offen ist, hat sie einen Anfang und ein Ende. 
* Alle Formen bestehen aus mindestens 2 Ankerpunkten, die durch Linien miteinander verbunden sind
* Eine Linie ist entweder gerade oder gekrümmt. Ankerpunkte bestimmen die Art der Linie. 
* Ankerpunkte existieren als Eckpunkte, gerade Punkte oder glatte Punkte:
  * Ein Eckpunkt ist ein Punkt, an dem 2 gerade Linien unter einem Winkel zusammentreffen. 
  * Ein glatter Punkt ist ein Punkt, an dem 2 Anfasser (Handles) in einer geraden Linie liegen und die Liniensegmente in einer glatten Kurve zusammentreffen. In diesem Fall sind alle Anfasser vom Ankerpunkt aus gleichen Abstand getrennt. 
  * Ein gerader Punkt ist ein Punkt, an dem 2 Anfasser in einer geraden Linie liegen und die Liniensegmente in einer glatten Kurve zusammentreffen. In diesem Fall müssen die Anfasser nicht in gleichem Abstand vom Ankerpunkt getrennt sein. 
* Durch Verschieben oder Bearbeiten von Ankerpunkten (die den Winkel der Linien ändern) können Sie das Aussehen einer Form verändern. 

Um PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) und die Klasse [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) bereit.

* Eine [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) Instanz stellt einen Geometriepfad des [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) Objekts dar. 
* Um den`GeometryPath` aus der`GeometryShape`‑Instanz abzurufen, können Sie die Methode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--) verwenden. 
* Um den`GeometryPath` für eine Form festzulegen, können Sie diese Methoden verwenden: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) für *einfachere Formen* und [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) für *Zusammenstellungsformen*. 
* Um Segmente hinzuzufügen, können Sie die Methoden unter [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) verwenden. 
* Mit den Methoden [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) und [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-) können Sie das Aussehen eines Geometriepfads festlegen. 
* Mit der Methode [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#getPathData--) können Sie den Geometriepfad eines `GeometryShape` als Array von Pfadsegmenten abrufen. 
* Um zusätzliche Optionen zur Anpassung von Formgeometrien zu erhalten, können Sie [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) konvertieren. 
* Verwenden Sie die Methoden [geometryPathToGraphicsPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) und [graphicsPathToGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (aus der Klasse [ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil)), um [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) hin und her zu konvertieren. 

## **Einfache Bearbeitungsoperationen**

Dieser JavaScript‑Code zeigt, wie man

**Eine Linie** an das Ende eines Pfads hinzufügen
```javascript
lineTo(point);
lineTo(x, y);
```

**Eine Linie** an einer angegebenen Position im Pfad hinzufügen:
```javascript
lineTo(point, index);
lineTo(x, y, index);
```

**Eine kubische Bezier‑Kurve** an das Ende eines Pfads hinzufügen:
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```

**Eine kubische Bezier‑Kurve** an einer angegebenen Position im Pfad hinzufügen:
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```

**Eine quadratische Bezier‑Kurve** an das Ende eines Pfads hinzufügen:
```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```

**Eine quadratische Bezier‑Kurve** an einer angegebenen Position im Pfad hinzufügen:
```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```

**Einen angegebenen Bogen** an einen Pfad anhängen:
```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```

**Die aktuelle Figur** eines Pfads schließen:
```javascript
closeFigure();
```

**Die Position für den nächsten Punkt** festlegen:
```javascript
moveTo(point);
moveTo(x, y);
```

**Das Pfadsegment** an einem angegebenen Index entfernen:
```javascript
removeAt(index);
```


## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) und setzen Sie den Typ [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType). 
2. Holen Sie eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) von der Form. 
3. Fügen Sie einen neuen Punkt zwischen den beiden oberen Punkten des Pfads hinzu. 
4. Fügen Sie einen neuen Punkt zwischen den beiden unteren Punkten des Pfads hinzu. 
5. Wenden Sie den Pfad auf die Form an. 

Dieser JavaScript‑Code zeigt, wie man benutzerdefinierte Punkte zu einer Form hinzufügt:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example1_image](custom_shape_1.png)

## **Punkte aus einer Form entfernen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) und setzen Sie den Typ [ShapeType.Heart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType). 
2. Holen Sie eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) von der Form. 
3. Entfernen Sie das Segment des Pfads. 
4. Wenden Sie den Pfad auf die Form an. 

Dieser JavaScript‑Code zeigt, wie man Punkte aus einer Form entfernt:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example2_image](custom_shape_2.png)

## **Benutzerdefinierte Form erstellen**

1. Berechnen Sie die Punkte für die Form. 
2. Erstellen Sie eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath). 
3. Füllen Sie den Pfad mit den Punkten. 
4. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape). 
5. Wenden Sie den Pfad auf die Form an. 

Dieser JavaScript‑Code zeigt, wie man eine benutzerdefinierte Form erstellt:
```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example3_image](custom_shape_3.png)

## **Zusammengesetzte benutzerdefinierte Form erstellen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape). 
2. Erstellen Sie eine erste Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath). 
3. Erstellen Sie eine zweite Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath). 
4. Wenden Sie die Pfade auf die Form an. 

Dieser JavaScript‑Code zeigt, wie man eine zusammengesetzte benutzerdefinierte Form erstellt:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example4_image](custom_shape_4.png)

## **Benutzerdefinierte Form mit gekrümmten Ecken erstellen**

Dieser JavaScript‑Code zeigt, wie man eine benutzerdefinierte Form mit gekrümmten Ecken (nach innen) erstellt;
```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();
    childShape.setGeometryPath(geometryPath);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ermitteln, ob eine Formgeometrie geschlossen ist**

Eine geschlossene Form ist definiert als eine, bei der alle Seiten verbunden sind und eine durchgehende Grenze ohne Lücken bilden. Eine solche Form kann eine einfache geometrische Form oder eine komplexe benutzerdefinierte Kontur sein. Das folgende Codebeispiel zeigt, wie man prüft, ob eine Formgeometrie geschlossen ist:
```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```


## **GeometryPath in java.awt.Shape konvertieren**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape). 
2. Erstellen Sie eine Instanz der Klasse [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html). 
3. Konvertieren Sie die [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) Instanz mithilfe von [ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil) in die [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) Instanz. 
4. Wenden Sie die Pfade auf die Form an. 

Dieser JavaScript‑Code – eine Umsetzung der obigen Schritte – demonstriert den Konvertierungsprozess von **GeometryPath** zu **GraphicsPath**:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Neue Form erstellen
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Geometriepfad der Form abrufen
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // neuen Grafikpfad mit Text erstellen
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // Grafikpfad in Geometriepfad konvertieren
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Kombination aus neuem Geometriepfad und ursprünglichem Geometriepfad für die Form festlegen
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**Was passiert mit Füllung und Kontur, nachdem die Geometrie ersetzt wurde?**

Der Stil bleibt bei der Form erhalten; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie kann ich eine benutzerdefinierte Form korrekt zusammen mit ihrer Geometrie drehen?**

Verwenden Sie die Methode [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setrotation/) der Form; die Geometrie dreht sich mit der Form, da sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis „einzusperren“?**

Ja. Exportieren Sie den gewünschten [slide](/slides/de/nodejs-java/convert-powerpoint-to-png/)‑Bereich oder die [shape](/slides/de/nodejs-java/create-shape-thumbnails/) selbst in ein Rasterformat; dies erleichtert die weitere Arbeit mit komplexen Geometrien.