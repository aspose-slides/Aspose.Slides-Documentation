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
- Editierpunkte
- Punkt hinzufügen
- Punkt entfernen
- Bearbeitungsvorgang
- Gekrümmte Ecke
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen und anpassen von Formen in PowerPoint-Präsentationen mit Aspose.Slides für Java: Geometriepfade, gekrümmte Ecken, zusammengesetzte Formen."
---

# Eine Form mit Editierpunkten ändern
Betrachten Sie ein Quadrat. In PowerPoint können Sie mit **Editierpunkten** 

* die Ecke des Quadrats nach innen oder außen verschieben
* die Krümmung einer Ecke oder eines Punktes festlegen
* neue Punkte zum Quadrat hinzufügen
* Punkte am Quadrat manipulieren usw. 

Im Wesentlichen können Sie die beschriebenen Vorgänge an jeder Form ausführen. Mit Editierpunkten können Sie eine Form ändern oder aus einer vorhandenen Form eine neue Form erstellen. 

## **Tipps zum Formen‑Editieren**

![overview_image](custom_shape_0.png)

Bevor Sie beginnen, PowerPoint‑Formen über Editierpunkte zu bearbeiten, sollten Sie diese Punkte zu Formen beachten:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Wenn eine Form geschlossen ist, fehlt ein Anfangs‑ oder Endpunkt. Wenn eine Form offen ist, hat sie einen Anfang und ein Ende. 
* Alle Formen bestehen aus mindestens 2 Ankerpunkten, die durch Linien miteinander verbunden sind
* Eine Linie ist entweder gerade oder gekrümmt. Ankerpunkte bestimmen die Art der Linie. 
* Ankerpunkte existieren als Eckpunkte, Gerade‑Punkte oder Glatte‑Punkte:
  * Ein Eckpunkt ist ein Punkt, an dem 2 gerade Linien in einem Winkel zusammentreffen. 
  * Ein glatter Punkt ist ein Punkt, an dem 2 Griff‑Handles in einer Geraden liegen und die Liniensegmente in einer weichen Kurve zusammenlaufen. In diesem Fall sind alle Griff‑Handles vom Ankerpunkt gleichweit entfernt. 
  * Ein gerader Punkt ist ein Punkt, an dem 2 Griff‑Handles in einer Geraden liegen und die Liniensegmente in einer weichen Kurve zusammenlaufen. In diesem Fall müssen die Griff‑Handles nicht gleichweit vom Ankerpunkt entfernt sein. 
* Durch das Verschieben oder Editieren von Ankerpunkten (was den Winkel der Linien ändert) können Sie das Aussehen einer Form verändern. 

Um PowerPoint‑Formen über Editierpunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [**GeometryPath**](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) und das Interface [**IGeometryPath**](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath) bereit. 

* Eine [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath)-Instanz repräsentiert einen Geometrie‑Pfad des [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape)-Objekts. 
* Um den `GeometryPath` aus der `IGeometryShape`‑Instanz zu erhalten, können Sie die Methode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#getGeometryPaths--) verwenden. 
* Um den `GeometryPath` für eine Form zu setzen, können Sie diese Methoden verwenden: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) für *solide Formen* und [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) für *zusammengesetzte Formen*.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath) nutzen. 
* Mit den Methoden [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) und [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#setFillMode-byte-) können Sie das Erscheinungsbild eines Geometrie‑Pfads festlegen.
* Über die Methode [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#getPathData--) können Sie den Geometrie‑Pfad einer `GeometryShape` als Array von Pfadsegmenten abrufen. 
* Um weitere Optionen zur Anpassung der Formgeometrie zu nutzen, können Sie [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) konvertieren.
* Verwenden Sie die Methoden [geometryPathToGraphicsPath](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) und [graphicsPathToGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (aus der Klasse [ShapeUtil](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil)), um [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) und zurück zu konvertieren. 

## **Einfache Editier‑Operationen**

Dieser Java‑Code zeigt, wie man

**Eine Linie** an das Ende eines Pfads anhängt
``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```

**Eine Linie** an einer bestimmten Position eines Pfads hinzufügt:
``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```

**Eine kubische Bezier‑Kurve** am Ende eines Pfads hinzufügt:
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**Eine kubische Bezier‑Kurve** an einer angegebenen Position eines Pfads hinzufügt:
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```

**Eine quadratische Bezier‑Kurve** am Ende eines Pfads hinzufügt:
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```

**Eine quadratische Bezier‑Kurve** an einer angegebenen Position eines Pfads hinzufügt:
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```

**Einen gegebenen Bogen** an einen Pfad anhängt:
``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**Die aktuelle Figur** eines Pfads schließt:
``` java
public void closeFigure();
```

**Die Position für den nächsten Punkt** festlegt:
``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```

**Das Pfadsegment** an einem angegebenen Index entfernt:
``` java
public void removeAt(int index);
```


## **Benutzerdefinierte Punkte zu einer Form hinzufügen**
1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape) und setzen Sie den Typ [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType).
2. Holen Sie sich eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) aus der Form.
3. Fügen Sie einen neuen Punkt zwischen den beiden oberen Punkten des Pfads hinzu.
4. Fügen Sie einen neuen Punkt zwischen den beiden unteren Punkten des Pfads hinzu.
5. Wenden Sie den Pfad auf die Form an.

Dieser Java‑Code zeigt, wie man benutzerdefinierte Punkte zu einer Form hinzufügt:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Punkte aus einer Form entfernen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape) und setzen Sie den Typ [ShapeType.Heart](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType).
2. Holen Sie sich eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath) aus der Form.
3. Entfernen Sie das Segment des Pfads.
4. Wenden Sie den Pfad auf die Form an.

Dieser Java‑Code zeigt, wie man Punkte aus einer Form entfernt:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```

![example2_image](custom_shape_2.png)

##  **Eine benutzerdefinierte Form erstellen**

1. Berechnen Sie die Punkte für die Form.
2. Erstellen Sie eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath).
3. Füllen Sie den Pfad mit den Punkten.
4. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape).
5. Wenden Sie den Pfad auf die Form an.

Dieser Java‑Code zeigt, wie man eine benutzerdefinierte Form erstellt:
``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}
```

![example3_image](custom_shape_3.png)


## **Ein zusammengesetztes benutzerdefiniertes Formobjekt erstellen**

  1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape).
  2. Erstellen Sie eine erste Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath).
  3. Erstellen Sie eine zweite Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath).
  4. Wenden Sie die Pfade auf die Form an.

Dieser Java‑Code zeigt, wie man ein zusammengesetztes benutzerdefiniertes Formobjekt erstellt:
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```

![example4_image](custom_shape_4.png)

## **Eine benutzerdefinierte Form mit gekrümmten Ecken erstellen**

Dieser Java‑Code zeigt, wie man eine benutzerdefinierte Form mit gekrümmten Ecken (nach innen) erstellt:
```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

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

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```


## **Ermitteln, ob eine Formgeometrie geschlossen ist**

Eine geschlossene Form wird definiert als eine, bei der alle Seiten miteinander verbunden sind und eine einzige Grenze ohne Lücken bilden. Eine solche Form kann eine einfache geometrische Form oder ein komplexes benutzerdefiniertes Kontur sein. Das folgende Code‑Beispiel zeigt, wie man prüft, ob eine Formgeometrie geschlossen ist:
```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```


## **GeometryPath in java.awt.Shape konvertieren** 

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryShape).
2. Erstellen Sie eine Instanz der Klasse [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Konvertieren Sie die [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)-Instanz mithilfe von [ShapeUtil](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeUtil) in eine [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/GeometryPath)-Instanz.
4. Wenden Sie die Pfade auf die Form an.

Dieser Java‑Code – eine Umsetzung der obigen Schritte – demonstriert den **GeometryPath**‑zu‑**GraphicsPath**‑Konvertierungsprozess:
``` java
Presentation pres = new Presentation();
try {
    // Neue Form erstellen
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Geometriepfad der Form abrufen
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Neuen Grafikpfad mit Text erstellen
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // Grafikpfad in Geometriepfad konvertieren
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Kombination aus neuem Geometriepfad und ursprünglichem Geometriepfad zur Form hinzufügen
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**Was passiert mit Füllung und Kontur, wenn die Geometrie ersetzt wird?**

Der Stil bleibt bei der Form; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie drehe ich eine benutzerdefinierte Form korrekt zusammen mit ihrer Geometrie?**

Verwenden Sie die Methode `setRotation` der Form; die Geometrie rotiert mit der Form, weil sie an das Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis „einzusperren“?**

Ja. Exportieren Sie den gewünschten [slide](/slides/de/java/convert-powerpoint-to-png/)-Bereich oder die [shape](/slides/de/java/create-shape-thumbnails/)-Selbst in ein Rasterformat; das vereinfacht die weitere Arbeit mit aufwendigen Geometrien.