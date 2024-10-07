---
title: Connector
type: docs
weight: 10
url: /java/connector/
keywords: "Formen verbinden, Verbindungen, PowerPoint Formen, PowerPoint Präsentation, Java, Aspose.Slides für Java"
description: "Verbinden Sie PowerPoint Formen in Java"
---

Ein PowerPoint-Connector ist eine spezielle Linie, die zwei Formen verbindet oder verlinkt und auch beim Verschieben oder Neuplatzieren auf einer bestimmten Folie an den Formen haften bleibt.

Connectoren sind typischerweise mit *Verbindungspunkten* (grüne Punkte) verbunden, die standardmäßig auf allen Formen vorhanden sind. Verbindungspunkte erscheinen, wenn der Cursor ihnen nahekommt.

*Anpassungspunkte* (orange Punkte), die nur auf bestimmten Connectoren vorhanden sind, werden verwendet, um die Positionen und Formen der Connectoren zu modifizieren.

## **Arten von Connectoren**

In PowerPoint können Sie gerade, geknickte (winkelige) und kurvige Connectoren verwenden.

Aspose.Slides bietet diese Connectoren an:

| Connector                      | Bild                                                        | Anzahl der Anpassungspunkte |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Formen mit Connectoren verbinden**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
1. Holen Sie sich eine Referenz auf die Folie über ihren Index.
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) mit der Methode `addAutoShape` des `Shapes`-Objekts hinzu.
1. Fügen Sie einen Connector mit der Methode `addConnector` des `Shapes`-Objekts hinzu, indem Sie den Connector-Typ definieren.
1. Verbinden Sie die Formen mit dem Connector.
1. Rufen Sie die Methode `reroute` auf, um den kürzesten Verbindungsweg anzuwenden.
1. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie einen Connector (einen geknickten Connector) zwischen zwei Formen (einer Ellipse und einem Rechteck) hinzufügen:

```Java
// Instanziiert eine Präsentationsklasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die Formen Sammlung für eine bestimmte Folie zu
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Fügt eine Ellipse-Autoshape hinzu
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Fügt eine Rechteck-Autoshape hinzu
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Fügt eine Connector-Form zur Folienform-Sammlung hinzu
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Verbindet die Formen mit dem Connector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Ruft reroute auf, das den automatischen kürzesten Weg zwischen den Formen festlegt
    connector.reroute();
    
    // Speichert die Präsentation
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="HINWEIS"  color="warning"   %}} 

Die Methode `Connector.reroute` leitet einen Connector um und zwingt ihn, den kürzestmöglichen Weg zwischen den Formen zu nehmen. Um dieses Ziel zu erreichen, kann die Methode die Punkte `setStartShapeConnectionSiteIndex` und `setEndShapeConnectionSiteIndex` ändern. 

{{% /alert %}} 

## **Verbindungspunkt angeben**

Wenn Sie möchten, dass ein Connector zwei Formen über spezifische Punkte an den Formen verbindet, müssen Sie Ihre bevorzugten Verbindungspunkte folgendermaßen angeben:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.
1. Holen Sie sich eine Referenz auf die Folie über ihren Index.
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) mit der Methode `addAutoShape` des `Shapes`-Objekts hinzu.
1. Fügen Sie einen Connector mit der Methode `addConnector` des `Shapes`-Objekts hinzu, indem Sie den Connector-Typ definieren.
1. Verbinden Sie die Formen mit dem Connector.
1. Setzen Sie Ihre bevorzugten Verbindungspunkte an den Formen.
1. Speichern Sie die Präsentation.

Dieser Java-Code demonstriert eine Operation, bei der ein bevorzugter Verbindungspunkt angegeben wird:

```java
// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die Formen Sammlung für eine bestimmte Folie zu
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Fügt eine Ellipse-Autoshape hinzu
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Fügt eine Rechteck-Autoshape hinzu
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Fügt eine Connector-Form zur Folienform-Sammlung hinzu
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Verbindet die Formen mit dem Connector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Setzt den bevorzugten Verbindungspunktindex auf der Ellipsenform
    int wantedIndex = 6;

    // Überprüft, ob der bevorzugte Index kleiner ist als die maximale Anzahl der Seitenindex
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Setzt den bevorzugten Verbindungspunkt auf der Ellipse-Autoshape
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Speichert die Präsentation
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Connector-Punkt anpassen**

Sie können einen bestehenden Connector über seine Anpassungspunkte anpassen. Nur Connectoren mit Anpassungspunkten können auf diese Weise verändert werden. Siehe die Tabelle unter **[Arten von Connectoren.](/slides/java/connector/#types-of-connectors)** 

#### **Einfacher Fall**

Betrachten Sie einen Fall, in dem ein Connector zwischen zwei Formen (A und B) durch eine dritte Form (C) führt:

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

Um die dritte Form zu vermeiden oder zu umgehen, können wir den Connector anpassen, indem wir seine vertikale Linie nach links bewegen:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Komplexe Fälle**

Um kompliziertere Anpassungen vorzunehmen, müssen Sie diese Dinge berücksichtigen:

* Ein anpassbarer Punkt eines Connectors ist eng mit einer Formel verbunden, die seine Position berechnet und bestimmt. Änderungen an der Position des Punktes können die Form des Connectors verändern.
* Die Anpassungspunkte eines Connectors sind in einer strengen Reihenfolge in einem Array definiert. Die Anpassungspunkte werden von dem Startpunkt eines Connectors bis zu seinem Endpunkt nummeriert.
* Die Werte der Anpassungspunkte spiegeln den Prozentsatz der Breite/Höhe der Connectorform wider. 
  * Die Form wird durch die Start- und Endpunkte des Connectors multipliziert mit 1000 begrenzt. 
  * Der erste Punkt, der zweite Punkt und der dritte Punkt definieren den Prozentsatz von der Breite, den Prozentsatz von der Höhe und den Prozentsatz von der Breite (erneut) jeweils.
* Bei Berechnungen, die die Koordinaten der Anpassungspunkte eines Connectors bestimmen, müssen Sie die Rotation und Reflexion des Connectors berücksichtigen. **Hinweis**: Der Rotationswinkel für alle unter **[Arten von Connectoren](/slides/java/connector/#types-of-connectors)** gezeigten Connectoren ist 0.

#### **Fall 1**

Betrachten Sie einen Fall, in dem zwei Textfeldobjekte durch einen Connector miteinander verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

```java
// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die erste Folie in der Präsentation zu
    ISlide sld = pres.getSlides().get_Item(0);
    // Fügt Formen hinzu, die durch einen Connector verbunden werden
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("Von");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("Zu");
    // Fügt einen Connector hinzu
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Gibt die Richtung des Connectors an
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Gibt die Farbe des Connectors an
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Gibt die Dicke der Linie des Connectors an
    connector.getLineFormat().setWidth(3);
    
    // Verbindet die Formen mit dem Connector
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Holt Anpassungspunkte für den Connector
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Anpassung**

Wir können die Werte der Anpassungspunkte des Connectors ändern, indem wir den jeweiligen Breiten- und Höhenprozentsatz um 20 % und 200 % erhöhen:

```java
// Ändert die Werte der Anpassungspunkte
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Das Ergebnis:

![connector-adjusted-1](connector-adjusted-1.png)

Um ein Modell zu definieren, das uns ermöglicht, die Koordinaten und die Form der einzelnen Teile des Connectors zu bestimmen, erstellen wir eine Form, die dem horizontalen Bestandteil des Connectors am Punkt connector.getAdjustments().get_Item(0) entspricht:

```java
// Zeichnet die vertikale Komponente des Connectors
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Das Ergebnis:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

In **Fall 1** haben wir eine einfache Anpassungsoperation des Connectors unter Verwendung grundlegender Prinzipien demonstriert. In normalen Situationen müssen Sie die Rotation des Connectors und dessen Anzeige (die durch connector.getRotation(), connector.getFrame().getFlipH() und connector.getFrame().getFlipV() festgelegt werden) berücksichtigen. Wir demonstrieren nun den Prozess.

Zuerst fügen wir ein neues Textfeldobjekt (**Zu 1**) zur Folie hinzu (zum Verbindungszweck) und erstellen einen neuen (grünen) Connector, der es mit den bereits erstellten Objekten verbindet.

```java
// Erstellt ein neues Bindungsobjekt
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("Zu 1");
// Erstellt einen neuen Connector
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Verbindet die Objekte mit dem neu erstellten Connector
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Holt die Anpassungspunkte des Connectors
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Ändert die Werte der Anpassungspunkte
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Das Ergebnis:

![connector-adjusted-3](connector-adjusted-3.png)

Zweitens erstellen wir eine Form, die der horizontalen Komponente des Connectors entspricht, die durch den neuen Connector-Punkt connector.getAdjustments().get_Item(0) führt. Wir verwenden die Werte aus den Connector-Daten für connector.getRotation(), connector.getFrame().getFlipH() und connector.getFrame().getFlipV() und wenden die gängige Koordinatentransformationsformel für die Rotation um einen gegebenen Punkt x0 an:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Rotationswinkel des Objekts 90 Grad, und der Connector wird vertikal angezeigt, sodass dies der entsprechende Code ist:

```java
// Speichert die Koordinaten des Connectors
x = connector.getX();
y = connector.getY();
// Korrigiert die Koordinaten des Connectors, falls diese erscheinen
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Nimmt den Wert des Anpassungspunktes als die Koordinate
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Wandelt die Koordinaten um, da Sin(90) = 1 und Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Bestimmt die Breite der horizontalen Komponente unter Verwendung des Wertes des zweiten Anpassungspunktes
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Das Ergebnis:

![connector-adjusted-4](connector-adjusted-4.png)

Wir haben Berechnungen durchgeführt, die einfache Anpassungen und komplizierte Anpassungspunkte (Anpassungspunkte mit Rotationswinkeln) betreffen. Mit dem gewonnenen Wissen können Sie Ihr eigenes Modell entwickeln (oder einen Code schreiben), um ein `GraphicsPath`-Objekt zu erhalten oder sogar die Werte der Anpassungspunkte eines Connectors basierend auf spezifischen Folienkoordinaten festzulegen.

## **Winkel der Connector-Linien finden**

1. Erstellen Sie eine Instanz der Klasse.
1. Holen Sie sich eine Referenz auf die Folie über ihren Index.
1. Greifen Sie auf die Connectorlinienform zu.
1. Verwenden Sie die Linienbreite, -höhe, die Formrahmenhöhe und -breite, um den Winkel zu berechnen.

Dieser Java-Code demonstriert eine Operation, bei der wir den Winkel für eine Connectorlinienform berechnet haben:

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```