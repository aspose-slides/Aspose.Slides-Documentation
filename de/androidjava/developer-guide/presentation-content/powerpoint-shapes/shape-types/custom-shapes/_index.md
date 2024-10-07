---
title: Benutzerdefinierte Form
type: docs
weight: 20
url: /androidjava/custom-shape/
keywords: "PowerPoint-Form, benutzerdefinierte Form, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "Fügen Sie eine benutzerdefinierte Form in PowerPoint-Präsentationen in Java hinzu"
---

# Ändern einer Form mithilfe von Bearbeitungspunkten
Betrachten Sie ein Quadrat. In PowerPoint können Sie mit **Bearbeitungspunkten** 

* die Ecke des Quadrats hinein oder heraus bewegen
* die Krümmung für eine Ecke oder einen Punkt angeben
* neue Punkte zum Quadrat hinzufügen
* Punkte auf dem Quadrat manipulieren usw.

Im Wesentlichen können Sie die beschriebenen Aufgaben bei jeder Form durchführen. Mithilfe von Bearbeitungspunkten können Sie eine Form ändern oder eine neue Form aus einer vorhandenen Form erstellen.

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Bevor Sie PowerPoint-Formen über Bearbeitungspunkte bearbeiten, sollten Sie diese Punkte zu Formen beachten:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Wenn eine Form geschlossen ist, fehlt ein Start- oder Endpunkt. Wenn eine Form offen ist, hat sie einen Anfang und ein Ende.
* Alle Formen bestehen aus mindestens 2 Ankerpunkten, die durch Linien miteinander verbunden sind.
* Eine Linie ist entweder gerade oder gekrümmt. Ankerpunkte bestimmen die Beschaffenheit der Linie.
* Ankerpunkte existieren als Eckpunkte, gerade Punkte oder glatte Punkte:
  * Ein Eckpunkt ist ein Punkt, an dem 2 gerade Linien in einem Winkel zusammentreffen.
  * Ein glatter Punkt ist ein Punkt, an dem 2 Griffe in einer geraden Linie existieren und die Segmente der Linie in einer sanften Kurve zusammenlaufen. In diesem Fall sind alle Griffe gleich weit vom Ankerpunkt entfernt.
  * Ein gerader Punkt ist ein Punkt, an dem 2 Griffe in einer geraden Linie existieren und deren Segmente in einer sanften Kurve zusammenlaufen. In diesem Fall müssen die Griffe nicht gleich weit vom Ankerpunkt entfernt sein.
* Durch Verschieben oder Bearbeiten von Ankerpunkten (was den Winkel der Linien ändert) können Sie das Aussehen einer Form verändern.

Um PowerPoint-Formen über Bearbeitungspunkte zu bearbeiten, bietet **Aspose.Slides** die [**GeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) Klasse und das [**IGeometryPath**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath) Interface.

* Eine [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) Instanz repräsentiert einen Geometriepfeil des [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape) Objekts.
* Um den `GeometryPath` von der `IGeometryShape` Instanz abzurufen, können Sie die Methode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) verwenden.
* Um den `GeometryPath` für eine Form festzulegen, können Sie diese Methoden verwenden: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) für *feste Formen* und [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) für *komposite Formen*.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath) verwenden.
* Durch Verwendung der Methoden [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) und [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-) können Sie das Aussehen für einen Geometriepfeil festlegen.
* Mit der Methode [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IGeometryPath#getPathData--) können Sie den Geometriepfeil einer `GeometryShape` als Array von Pfadsegmenten abrufen.
* Um auf zusätzliche Anpassungsoptionen für die Geometrie der Form zuzugreifen, können Sie [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) umwandeln.
* Verwenden Sie die Methoden [geometryPathToGraphicsPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) und [graphicsPathToGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (aus der [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil) Klasse), um [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) und umgekehrt umzuwandeln.

## **Einfache Bearbeitungsoperationen**

Dieser Java-Code zeigt Ihnen, wie Sie

**Eine Linie** an das Ende eines Pfades hinzufügen

```java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Eine Linie** an einer bestimmten Position auf einem Pfad hinzufügen:

```java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Eine kubische Bézier-Kurve** am Ende eines Pfades hinzufügen:

```java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Eine kubische Bézier-Kurve** an einer bestimmten Position auf einem Pfad hinzufügen:

```java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Eine quadratische Bézier-Kurve** am Ende eines Pfades hinzufügen:

```java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Eine quadratische Bézier-Kurve** an einer bestimmten Position auf einem Pfad hinzufügen:

```java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Einen gegebenen Bogen** zu einem Pfad hinzufügen:

```java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Die aktuelle Figur** eines Pfades schließen:

```java
public void closeFigure();
```
**Die Position für den nächsten Punkt** festlegen:

```java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Das Pfadsegment** an einem bestimmten Index entfernen:

```java
public void removeAt(int index);
```

## **Benutzerdefinierte Punkte zur Form hinzufügen**
1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) Klasse und setzen Sie den [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType) Typ.
2. Holen Sie sich eine Instanz der [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) Klasse aus der Form.
3. Fügen Sie einen neuen Punkt zwischen den beiden oberen Punkten auf dem Pfad hinzu.
4. Fügen Sie einen neuen Punkt zwischen den beiden unteren Punkten auf dem Pfad hinzu.
5. Wenden Sie den Pfad auf die Form an.

Dieser Java-Code zeigt Ihnen, wie Sie benutzerdefinierte Punkte zu einer Form hinzufügen:

```java
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

## Punkte von der Form entfernen

1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) Klasse und setzen Sie den [ShapeType.Heart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType) Typ.
2. Holen Sie sich eine Instanz der [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) Klasse aus der Form.
3. Entfernen Sie das Segment für den Pfad.
4. Wenden Sie den Pfad auf die Form an.

Dieser Java-Code zeigt Ihnen, wie Sie Punkte von einer Form entfernen:

```java
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

## **Benutzerdefinierte Form erstellen**

1. Berechnen Sie die Punkte für die Form.
2. Erstellen Sie eine Instanz der [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) Klasse.
3. Füllen Sie den Pfad mit den Punkten.
4. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) Klasse.
5. Wenden Sie den Pfad auf die Form an.

Dieser Java-Code zeigt Ihnen, wie Sie eine benutzerdefinierte Form erstellen:

```java
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

## **Komposite benutzerdefinierte Form erstellen**

1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) Klasse.
2. Erstellen Sie die erste Instanz der [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) Klasse.
3. Erstellen Sie die zweite Instanz der [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) Klasse.
4. Wenden Sie die Pfade auf die Form an.

Dieser Java-Code zeigt Ihnen, wie Sie eine komposite benutzerdefinierte Form erstellen:

```java
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

## **Benutzerdefinierte Form mit abgerundeten Ecken erstellen**

Dieser Java-Code zeigt Ihnen, wie Sie eine benutzerdefinierte Form mit abgerundeten Ecken (nach innen) erstellen:

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

## **Konvertieren von GeometryPath zu java.awt.Shape** 

1. Erstellen Sie eine Instanz der [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryShape) Klasse.
2. Erstellen Sie eine Instanz der [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) Klasse.
3. Konvertieren Sie die Instanz von [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) in die Instanz von [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GeometryPath) mithilfe von [ShapeUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeUtil).
4. Wenden Sie die Pfade auf die Form an.

Dieser Java-Code—eine Implementierung der oben genannten Schritte—demonstriert den **GeometryPath** zu **GraphicsPath** Konversionsprozess:

```java
Presentation pres = new Presentation();
try {
    // Erstellen Sie eine neue Form
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Holen Sie sich den Geometriepfeil der Form
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Erstellen Sie einen neuen Grafikpfad mit Text
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in Form";
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

    // Konvertieren Sie den Grafikpfad in einen Geometriepfeil
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Setzen Sie die Kombination aus neuem Geometriepfeil und ursprünglichem Geometriepfeil auf die Form
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)