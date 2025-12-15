---
title: Verwalten von Verbindern in Präsentationen auf Android
linktitle: Verbinder
type: docs
weight: 10
url: /de/androidjava/connector/
keywords:
- Verbinder
- Verbinder-Typ
- Verbinderpunkt
- Verbinderlinie
- Verbinderwinkel
- Formen verbinden
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Ermöglichen Sie Java-Apps, Linien in PowerPoint-Folien auf Android zu zeichnen, zu verbinden und automatisch zu routen - erhalten Sie die volle Kontrolle über gerade, Ellenbogen- und gekrümmte Verbinder."
---

Ein PowerPoint‑Verbinder ist eine spezielle Linie, die zwei Formen miteinander verbindet oder verknüpft und an den Formen befestigt bleibt, selbst wenn sie auf einer Folie verschoben oder neu positioniert werden.

Verbinder sind typischerweise mit *Verbindungspunkten* (grüne Punkte) verbunden, die standardmäßig auf allen Formen vorhanden sind. Verbindungspunkte erscheinen, wenn ein Cursor ihnen nahekommt.

*Anpassungspunkte* (orange Punkte), die nur bei bestimmten Verbindern existieren, werden verwendet, um die Positionen und Formen von Verbindern zu ändern.

## **Typen von Verbindern**

In PowerPoint können Sie gerade, Ellenbogen‑ (gewinkelte) und gekrümmte Verbinder verwenden.

Aspose.Slides bietet diese Verbinder:

| Verbinder | Bild | Anzahl der Anpassungspunkte |
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

## **Formen mit Verbindern verbinden**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) hinzu, indem Sie die Methode `addAutoShape` des `Shapes`‑Objekts verwenden.
1. Fügen Sie einen Verbinder hinzu, indem Sie die Methode `addConnector` des `Shapes`‑Objekts verwenden und den Verbinder‑Typ angeben.
1. Verbinden Sie die Formen mithilfe des Verbinders.
1. Rufen Sie die Methode `reroute` auf, um den kürzesten Verbindungsweg anzuwenden.
1. Speichern Sie die Präsentation.

Dieser Java‑Code zeigt, wie Sie einen Verbinder (einen gebogenen Verbinder) zwischen zwei Formen (einer Ellipse und einem Rechteck) hinzufügen:
```Java
// Instanziiert eine Presentation-Klasse, die die PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Greift auf die Shapes-Sammlung einer bestimmten Folie zu
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Fügt eine Ellipse-AutoShape hinzu
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Fügt ein Rechteck-AutoShape hinzu
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Fügt ein Connector-Shape zur Shapes-Sammlung der Folie hinzu
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Verbindet die Shapes mithilfe des Connectors
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Ruft reroute auf, das den automatischen kürzesten Pfad zwischen den Shapes festlegt
    connector.reroute();
    
    // Speichert die Präsentation
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 
Die Methode `Connector.reroute` leitet einen Verbinder um und zwingt ihn, den kürzesten möglichen Weg zwischen Formen zu nehmen. Um dies zu erreichen, kann die Methode die Punkte `setStartShapeConnectionSiteIndex` und `setEndShapeConnectionSiteIndex` ändern. 
{{% /alert %}} 

## **Verbindungspunkt festlegen**

Wenn Sie möchten, dass ein Verbinder zwei Formen über bestimmte Punkte auf den Formen verbindet, müssen Sie die gewünschten Verbindungspunkte wie folgt angeben:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) hinzu, indem Sie die Methode `addAutoShape` des `Shapes`‑Objekts verwenden.
1. Fügen Sie einen Verbinder hinzu, indem Sie die Methode `addConnector` des `Shapes`‑Objekts verwenden und den Verbinder‑Typ angeben.
1. Verbinden Sie die Formen mithilfe des Verbinders.
1. Legen Sie die gewünschten Verbindungspunkte auf den Formen fest.
1. Speichern Sie die Präsentation.

Dieser Java‑Code demonstriert einen Vorgang, bei dem ein bevorzugter Verbindungspunkt festgelegt wird:
```java
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Greift auf die Shape-Sammlung einer bestimmten Folie zu
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Fügt eine Ellipse-AutoShape hinzu
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Fügt eine Rechteck-AutoShape hinzu
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Fügt ein Connector-Shape zur Shape-Sammlung der Folie hinzu
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Verbindet die Shapes mithilfe des Connectors
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Legt den Index des bevorzugten Verbindungspunkts auf der Ellipse-Shape fest
    int wantedIndex = 6;

    // Prüft, ob der bevorzugte Index kleiner ist als die maximale Anzahl von Verbindungspunkten
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Setzt den bevorzugten Verbindungspunkt auf der Ellipse-AutoShape
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Speichert die Präsentation
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Einen Verbinderpunkt anpassen**

Sie können einen bestehenden Verbinder über seine Anpassungspunkte anpassen. Nur Verbinder mit Anpassungspunkten können auf diese Weise geändert werden. Siehe die Tabelle unter **[Typen von Verbindern.](/slides/de/androidjava/connector/#types-of-connectors)**

### **Einfacher Fall**

Betrachten Sie einen Fall, in dem ein Verbinder zwischen zwei Formen (A und B) durch eine dritte Form (C) verläuft:

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


Um die dritte Form zu meiden oder zu umgehen, können wir den Verbinder anpassen, indem wir seine vertikale Linie nach links verschieben:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **Komplexe Fälle**

Um komplexere Anpassungen durchzuführen, müssen Sie folgende Aspekte berücksichtigen:

* Der anpassbare Punkt eines Verbinders ist eng mit einer Formel verknüpft, die seine Position berechnet und bestimmt. Änderungen der Punktposition können daher die Form des Verbinders verändern.
* Die Anpassungspunkte eines Verbinders werden in einem Array in einer festen Reihenfolge definiert. Die Punkte werden vom Startpunkt des Verbinders bis zum Endpunkt nummeriert.
* Die Werte der Anpassungspunkte spiegeln den Prozentsatz der Breite/Höhe der Verbinderform wider.
  * Die Form wird durch die Start‑ und Endpunkte des Verbinders multipliziert mit 1000 begrenzt.
  * Der erste Punkt, der zweite Punkt und der dritte Punkt definieren jeweils den Prozentsatz der Breite, den Prozentsatz der Höhe und erneut den Prozentsatz der Breite.
* Für Berechnungen, die die Koordinaten der Anpassungspunkte eines Verbinders bestimmen, müssen Sie die Drehung und Spiegelung des Verbinders berücksichtigen. **Hinweis**: Der Drehwinkel für alle unter **[Typen von Verbindern](/slides/de/androidjava/connector/#types-of-connectors)** gezeigten Verbinder beträgt 0.

#### **Fall 1**

Betrachten Sie einen Fall, in dem zwei Textfeld‑Objekte über einen Verbinder verbunden sind:

![connector-shape-complex](connector-shape-complex.png)
```java
// Instanziert eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Holt die erste Folie der Präsentation
    ISlide sld = pres.getSlides().get_Item(0);
    // Fügt Formen hinzu, die über einen Verbinder verbunden werden sollen
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Fügt einen Verbinder hinzu
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Legt die Richtung des Verbinders fest
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Legt die Farbe des Verbinders fest
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Legt die Linienstärke des Verbinders fest
    connector.getLineFormat().setWidth(3);
    
    // Verbindet die Formen miteinander mit dem Verbinder
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Holt die Anpassungspunkte des Verbinders
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```


**Anpassung**

Wir können die Werte der Anpassungspunkte des Verbinders ändern, indem wir die entsprechenden Breiten‑ bzw. Höhen‑Prozentsätze um 20 % bzw. 200 % erhöhen:
```java
// Ändert die Werte der Anpassungspunkte
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


Das Ergebnis:

![connector-adjusted-1](connector-adjusted-1.png)

Um ein Modell zu definieren, das uns die Koordinaten und die Form einzelner Teile des Verbinders bestimmt, erstellen wir eine Form, die der horizontalen Komponente des Verbinders am Punkt `connector.getAdjustments().get_Item(0)` entspricht:
```java
// Zeichnet die vertikale Komponente des Verbinders
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


Das Ergebnis:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

In **Fall 1** haben wir einen einfachen Verbinder‑Anpassungsvorgang anhand grundlegender Prinzipien demonstriert. In normalen Situationen müssen Sie die Drehung des Verbinders und seine Anzeige (die durch `connector.getRotation()`, `connector.getFrame().getFlipH()` und `connector.getFrame().getFlipV()` festgelegt werden) berücksichtigen. Wir werden nun den Vorgang demonstrieren.

Zuerst fügen wir ein neues Textfeld‑Objekt (**To 1**) zur Folie hinzu (zur Verbindung) und erstellen einen neuen (grünen) Verbinder, der es mit den bereits erstellten Objekten verbindet.
```java
// Erzeugt ein neues Bindungsobjekt
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Erzeugt einen neuen Verbinder
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// Verbindet Objekte mit dem neu erstellten Verbinder
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Ruft die Anpassungspunkte des Verbinders ab
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Ändert die Werte der Anpassungspunkte
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


Das Ergebnis:

![connector-adjusted-3](connector-adjusted-3.png)

Zweitens erstellen wir eine Form, die der horizontalen Komponente des Verbinders entspricht, die durch den Anpassungspunkt des neuen Verbinders `connector.getAdjustments().get_Item(0)` verläuft. Wir verwenden die Werte aus den Connector‑Daten für `connector.getRotation()`, `connector.getFrame().getFlipH()` und `connector.getFrame().getFlipV()` und wenden die bekannte Koordinatenumwandlungsformel für die Drehung um einen gegebenen Punkt x0 an:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Rotationswinkel des Objekts 90 Grad und der Verbinder wird vertikal angezeigt, sodass der entsprechende Code lautet:
```java
// Speichert die Koordinaten des Verbinders
x = connector.getX();
y = connector.getY();
// Korrigiert die Koordinaten des Verbinders falls erforderlich
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// Verwendet den Wert des Anpassungspunkts als Koordinate
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  Konvertiert die Koordinaten weil Sin(90) = 1 und Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Bestimmt die Breite der horizontalen Komponente unter Verwendung des zweiten Anpassungspunkts
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```


Das Ergebnis:

![connector-adjusted-4](connector-adjusted-4.png)

Wir haben Berechnungen gezeigt, die sowohl einfache Anpassungen als auch komplizierte Anpassungspunkte (Anpassungspunkte mit Drehwinkeln) umfassen. Mit dem erworbenen Wissen können Sie Ihr eigenes Modell entwickeln (oder Code schreiben), um ein `GraphicsPath`‑Objekt zu erhalten oder sogar die Werte der Anpassungspunkte eines Verbinders anhand spezifischer Folienkoordinaten festzulegen.

## **Winkel von Verbinder‑Linien ermitteln**

1. Erstellen Sie eine Instanz der Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Greifen Sie auf die Verbinder‑Linienform zu.
4. Verwenden Sie die Linienbreite, Höhe, den Rahmen‑Höhe und die Rahmen‑Breite der Form, um den Winkel zu berechnen.

Dieser Java‑Code demonstriert einen Vorgang, bei dem wir den Winkel einer Verbinder‑Linienform berechnet haben:
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


## **FAQ**

**Wie kann ich feststellen, ob ein Verbinder an einer bestimmten Form „geklebt“ werden kann?**

Prüfen Sie, ob die Form [Verbindungspunkte](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getConnectionSiteCount--) bereitstellt. Gibt es keine oder ist die Anzahl null, ist das Kleben nicht möglich; verwenden Sie in diesem Fall freie Endpunkte und positionieren Sie diese manuell. Es ist sinnvoll, die Anzahl der Punkte vor dem Anbinden zu prüfen.

**Was passiert mit einem Verbinder, wenn ich eine der verbundenen Formen lösche?**

Seine Enden werden getrennt; der Verbinder bleibt als gewöhnliche Linie mit freiem Start‑/Endpunkt auf der Folie erhalten. Sie können ihn entweder löschen oder die Verbindungen neu zuordnen und, falls nötig, [reroute](https://reference.aspose.com/slides/androidjava/com.aspose.slides/connector/#reroute--) verwenden.

**Werden Verbinder‑Verbindungen beim Kopieren einer Folie in eine andere Präsentation beibehalten?**

In der Regel ja, sofern die Ziel­formen ebenfalls kopiert werden. Wird die Folie in eine andere Datei eingefügt, ohne dass die verbundenen Formen mitkopiert werden, werden die Enden frei und Sie müssen sie erneut anbringen.