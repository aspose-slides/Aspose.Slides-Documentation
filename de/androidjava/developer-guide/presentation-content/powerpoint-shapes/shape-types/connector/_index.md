---
title: Connector
type: docs
weight: 10
url: /androidjava/connector/
keywords: "Verbindungen von Formen, Verbindungsstücken, PowerPoint Formen, PowerPoint Präsentation, Java, Aspose.Slides für Android über Java"
description: "Verbinden von PowerPoint Formen in Java"
---

Ein PowerPoint-Connector ist eine spezielle Linie, die zwei Formen miteinander verbindet oder verknüpft und auch dann an den Formen bleibt, wenn sie auf einer bestimmten Folie verschoben oder neu positioniert werden. 

Connectoren sind typischerweise mit *Verbindungspunkten* (grüne Punkte) verbunden, die standardmäßig auf allen Formen vorhanden sind. Verbindungspunkte erscheinen, wenn der Cursor sich ihnen nähert.

*Anpassungspunkte* (orange Punkte), die nur bei bestimmten Connectoren vorhanden sind, werden verwendet, um die Positionen und Formen der Connectoren zu modifizieren.

## **Arten von Connectoren**

In PowerPoint können Sie gerade, winkelige (eckige) und gekrümmte Connectoren verwenden. 

Aspose.Slides bietet diese Connectoren:

| Connector                      | Bild                                                         | Anzahl der Anpassungspunkte |
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

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Erhalten Sie eine Folienreferenz über ihren Index.
1. Fügen Sie zwei [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) zur Folie hinzu, indem Sie die `addAutoShape` Methode des `Shapes` Objekts verwenden.
1. Fügen Sie einen Connector mit der `addConnector` Methode des `Shapes` Objekts hinzu, indem Sie den Connector-Typ definieren.
1. Verbinden Sie die Formen mit dem Connector. 
1. Rufen Sie die `reroute` Methode auf, um den kürzesten Verbindungspfad anzuwenden.
1. Speichern Sie die Präsentation. 

Dieser Java-Code zeigt, wie man einen Connector (einen gewinkelten Connector) zwischen zwei Formen (einer Ellipse und einem Rechteck) hinzufügt:

```Java
// Erstellt eine Präsentationsklasse, die die PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die Shapes-Sammlung für eine bestimmte Folie zu
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Fügt eine Ellipse Autoshape hinzu
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Fügt eine Rechteck Autoshape hinzu
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Fügt eine Connector-Form zur Shapes-Sammlung der Folie hinzu
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Verbindet die Formen mit dem Connector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Ruft reroute auf, um den automatischen kürzesten Pfad zwischen den Formen festzulegen
    connector.reroute();
    
    // Speichert die Präsentation
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="HINWEIS"  color="warning"   %}} 

Die `Connector.reroute` Methode leitet einen Connector neu und zwingt ihn, den kürzest möglichen Pfad zwischen den Formen zu nehmen. Um dies zu erreichen, kann die Methode die Punkte `setStartShapeConnectionSiteIndex` und `setEndShapeConnectionSiteIndex` ändern. 

{{% /alert %}} 

## **Verbindungspunkt angeben**

Wenn Sie möchten, dass ein Connector zwei Formen über bestimmte Punkte auf den Formen verbindet, müssen Sie Ihre bevorzugten Verbindungspunkte auf diese Weise angeben:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Erhalten Sie eine Folienreferenz über ihren Index.
1. Fügen Sie zwei [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) zur Folie hinzu, indem Sie die `addAutoShape` Methode des `Shapes` Objekts verwenden.
1. Fügen Sie einen Connector mit der `addConnector` Methode des `Shapes` Objekts hinzu, indem Sie den Connector-Typ definieren.
1. Verbinden Sie die Formen mit dem Connector. 
1. Setzen Sie Ihre bevorzugten Verbindungspunkte auf den Formen. 
1. Speichern Sie die Präsentation.

Dieser Java-Code demonstriert eine Operation, bei der ein bevorzugter Verbindungspunkt angegeben wird:

```java
// Erstellt eine Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die Shapes-Sammlung für eine bestimmte Folie zu
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Fügt eine Ellipse Autoshape hinzu
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Fügt eine Rechteck Autoshape hinzu
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Fügt eine Connector-Form zur Shapes-Sammlung der Folie hinzu
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Verbindet die Formen mit dem Connector
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Setzt den bevorzugten Verbindungspunktindex auf der Ellipse-Form
    int wantedIndex = 6;

    // Überprüft, ob der bevorzugte Index kleiner ist als die maximale Anzahl von Verbindungspunkt-Indizes
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

Sie können einen bestehenden Connector über seine Anpassungspunkte anpassen. Nur Connectoren mit Anpassungspunkten können auf diese Weise verändert werden. Siehe die Tabelle unter **[Arten von Connectoren](/slides/androidjava/connector/#types-of-connectors)**

#### **Einfacher Fall**

Betrachten Sie einen Fall, in dem ein Connector zwischen zwei Formen (A und B) durch eine dritte Form (C) verläuft:

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

Um die dritte Form zu vermeiden oder zu umgehen, können wir den Connector anpassen, indem wir seine vertikale Linie auf diese Weise nach links verschieben:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **Komplexe Fälle** 

Um kompliziertere Anpassungen vorzunehmen, müssen Sie Folgendes berücksichtigen:

* Ein anpassbarer Punkt eines Connectors ist stark mit einer Formel verknüpft, die seine Position berechnet und bestimmt. Änderungen am Standort des Punkts können die Form des Connectors beeinflussen.
* Die Anpassungspunkte eines Connectors sind in einer strengen Reihenfolge in einem Array definiert. Die Anpassungspunkte werden von einem Startpunkt des Connectors zu seinem Endpunkt nummeriert.
* Die Werte der Anpassungspunkte spiegeln den Prozentsatz der Breite/Höhe der Connector-Form wider. 
  * Die Form wird durch die Start- und Endpunkte des Connectors multipliziert mit 1000 begrenzt. 
  * Der erste Punkt, der zweite Punkt und der dritte Punkt definieren respektiv den Prozentsatz der Breite, den Prozentsatz der Höhe und den Prozentsatz der Breite (wieder).
* Für Berechnungen, die die Koordinaten der Anpassungspunkte eines Connectors bestimmen, müssen Sie die Drehung und die Reflexion des Connectors berücksichtigen. **Hinweis**: Der Drehwinkel für alle Connectoren, die unter **[Arten von Connectoren](/slides/androidjava/connector/#types-of-connectors)** gezeigt werden, beträgt 0.

#### **Fall 1**

Betrachten Sie einen Fall, in dem zwei Textfeldobjekte über einen Connector miteinander verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

```java
// Erstellt eine Präsentationsklasse, die eine PPTX-Datei darstellt
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
    // Gibt die Dicke der Linienstärke des Connectors an
    connector.getLineFormat().setWidth(3);
    
    // Verbindet die Formen mit dem Connector
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Ruft die Anpassungspunkte für den Connector ab
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**Anpassung**

Wir können die Werte der Anpassungspunkte des Connectors ändern, indem wir den entsprechenden Breiten- und Höhenprozentsatz um 20 % und 200 % erhöhen:

```java
// Ändert die Werte der Anpassungspunkte
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Das Ergebnis:

![connector-adjusted-1](connector-adjusted-1.png)

Um ein Modell zu definieren, das es uns ermöglicht, die Koordinaten und die Form einzelner Teile des Connectors zu bestimmen, erstellen wir eine Form, die dem horizontalen Teil des Connectors am Punkt connector.getAdjustments().get_Item(0) entspricht:

```java
// Zeichnet das vertikale Element des Connectors
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

Das Ergebnis:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

In **Fall 1** haben wir eine einfache Connector-Anpassungsoperation unter Verwendung grundlegender Prinzipien demonstriert. In normalen Situationen müssen Sie die Drehung des Connectors und seine Darstellungen (die durch connector.getRotation(), connector.getFrame().getFlipH() und connector.getFrame().getFlipV() festgelegt werden) berücksichtigen. Wir werden nun den Prozess demonstrieren.

Zuerst fügen wir ein neues Textfeldobjekt (**Zu 1**) zur Folie hinzu (zur Verbindungszwecken) und erstellen einen neuen (grünen) Connector, der es mit den Objekten, die wir bereits erstellt haben, verbindet.

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
// Verbindet Objekte über den neu erstellten Connector
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Ruft die Anpassungspunkte des Connectors ab
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Ändert die Werte der Anpassungspunkte
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

Das Ergebnis:

![connector-adjusted-3](connector-adjusted-3.png)

Zweitens erstellen wir eine Form, die dem horizontalen Teil des Connectors entspricht, der durch den neuen Connector-Punkt connector.getAdjustments().get_Item(0) verläuft. Wir werden die Werte aus den Connector-Daten für connector.getRotation(), connector.getFrame().getFlipH() und connector.getFrame().getFlipV() verwenden und die gängige Koordinatenumrechnungsformel für die Drehung um einen gegebenen Punkt x0 anwenden:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Drehwinkel des Objekts 90 Grad und der Connector wird vertikal dargestellt, sodass dies der entsprechende Code ist:

```java
// Speichert die Koordinaten des Connectors
x = connector.getX();
y = connector.getY();
// Korrigiert die Koordinaten des Connectors, falls sie erscheinen
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Nimmt den Wert des Anpassungspunkts als Koordinaten
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Konvertiert die Koordinaten, da Sin(90) = 1 und Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Bestimmt die Breite des horizontalen Elements unter Verwendung des Wertes des zweiten Anpassungspunktes
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

Das Ergebnis:

![connector-adjusted-4](connector-adjusted-4.png)

Wir haben Berechnungen mit einfachen Anpassungen und komplizierten Anpassungspunkten (Anpassungspunkte mit Drehwinkeln) demonstriert. Mit dem erlernten Wissen können Sie Ihr eigenes Modell (oder Code) entwickeln, um ein `GraphicsPath`-Objekt zu erstellen oder sogar die Anpassungspunktwerte eines Connectors basierend auf bestimmten Folienkoordinaten festzulegen.

## **Winkel der Connector-Linien finden**

1. Erstellen Sie eine Instanz der Klasse.
1. Erhalten Sie eine Folienreferenz über ihren Index.
1. Greifen Sie auf die Connector-Linienform zu.
1. Verwenden Sie die Breite, Höhe, Höhe des Formenrahmens und Breite des Formenrahmens, um den Winkel zu berechnen.

Dieser Java-Code demonstriert eine Operation, in der wir den Winkel für eine Connector-Linienform berechnet haben:

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