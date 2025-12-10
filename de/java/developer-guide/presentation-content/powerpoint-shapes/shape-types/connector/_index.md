---
title: Verwalten von Verbindern in Präsentationen mit Java
linktitle: Verbinder
type: docs
weight: 10
url: /de/java/connector/
keywords:
- Verbinder
- Verbinder-Typ
- Verbinderpunkt
- Verbinderlinie
- Verbinderwinkel
- Formen verbinden
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Ermöglichen Sie Java-Anwendungen, Linien in PowerPoint-Folien zu zeichnen, zu verbinden und automatisch zu routen – erhalten Sie die vollständige Kontrolle über gerade, Ellenbogen- und gebogene Verbinder."
---

Ein PowerPoint‑Verbinder ist eine spezielle Linie, die zwei Formen miteinander verbindet oder verknüpft und an den Formen befestigt bleibt, selbst wenn sie auf einer Folie verschoben oder neu positioniert werden. 

Verbinder sind typischerweise mit *Verbindungspunkten* (grüne Punkte) verbunden, die standardmäßig auf allen Formen vorhanden sind. Verbindungspunkte erscheinen, wenn ein Cursor sich ihnen nähert.

*Anpassungspunkte* (orange Punkte), die nur bei bestimmten Verbindern existieren, werden verwendet, um die Position und Form von Verbindern zu ändern.

## **Typen von Verbindern**

In PowerPoint können Sie gerade, Ellenbogen‑ (gekrümmte) und gebogene Verbinder verwenden. 

Aspose.Slides stellt diese Verbinder bereit:

| Verbinder                      | Bild                                                         | Anzahl der Anpassungspunkte |
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

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.  
1. Holen Sie sich über den Index einen Verweis auf die Folie.  
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) mittels der `addAutoShape`‑Methode des `Shapes`‑Objekts hinzu.  
1. Fügen Sie einen Verbinder über die `addConnector`‑Methode des `Shapes`‑Objekts hinzu, indem Sie den Verbinder‑Typ angeben.  
1. Verbinden Sie die Formen mit dem Verbinder.  
1. Rufen Sie die `reroute`‑Methode auf, um den kürzesten Verbindungsweg anzuwenden.  
1. Speichern Sie die Präsentation.  

Der folgende Java‑Code zeigt, wie Sie zwischen zwei Formen (einem Ellipse und einem Rechteck) einen gebogenen Verbinder hinzufügen:
```Java
// Instanziiert eine Präsentationsklasse, die die PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Greift auf die Formen-Sammlung einer bestimmten Folie zu
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // Fügt eine Ellipse-Autoform hinzu
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // Fügt eine Rechteck-Autoform hinzu
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // Fügt eine Verbinderform zur Formen-Sammlung der Folie hinzu
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // Verbindet die Formen mit dem Verbinder
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // Ruft reroute auf, das den automatischen kürzesten Pfad zwischen den Formen festlegt
    connector.reroute();
    
    // Speichert die Präsentation
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

Die Methode `Connector.reroute` leitet einen Verbinder neu und zwingt ihn, den kürzesten möglichen Pfad zwischen den Formen zu nehmen. Dazu kann die Methode die Punkte `setStartShapeConnectionSiteIndex` und `setEndShapeConnectionSiteIndex` ändern. 

{{% /alert %}} 

## **Verbindungspunkt angeben**

Wenn Sie einen Verbinder so verknüpfen möchten, dass er zwei Formen über bestimmte Punkte auf den Formen verbindet, geben Sie die gewünschten Verbindungspunkte folgendermaßen an:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)-Klasse.  
1. Holen Sie sich über den Index einen Verweis auf die Folie.  
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) mittels der `addAutoShape`‑Methode des `Shapes`‑Objekts hinzu.  
1. Fügen Sie einen Verbinder über die `addConnector`‑Methode des `Shapes`‑Objekts hinzu, indem Sie den Verbinder‑Typ angeben.  
1. Verbinden Sie die Formen mit dem Verbinder.  
1. Setzen Sie Ihre bevorzugten Verbindungspunkte auf den Formen.  
1. Speichern Sie die Präsentation.  

Der folgende Java‑Code demonstriert die Angabe eines bevorzugten Verbindungspunkts:
```java
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Greift auf die Formen-Sammlung einer bestimmten Folie zu
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // Fügt eine Ellipse-Autoform hinzu
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Fügt eine Rechteck-Autoform hinzu
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Fügt eine Verbinderform zur Formen-Sammlung der Folie hinzu
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Verbindet die Formen mit dem Verbinder
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // Legt den bevorzugten Verbindungspunkt-Index auf der Ellipse-Form fest
    int wantedIndex = 6;

    // Prüft, ob der bevorzugte Index kleiner als die maximale Site-Index-Anzahl ist
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // Setzt den bevorzugten Verbindungspunkt auf der Ellipse-Autoform
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // Speichert die Präsentation
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Anpassung eines Verbinderspunkts**

Sie können einen vorhandenen Verbinder über dessen Anpassungspunkte anpassen. Nur Verbinder mit Anpassungspunkten können auf diese Weise verändert werden. Siehe die Tabelle unter **[Typen von Verbindern.](/slides/de/java/connector/#types-of-connectors)** 

### **Einfacher Fall**

Betrachten Sie den Fall, dass ein Verbinder zwischen zwei Formen (A und B) durch eine dritte Form (C) verläuft:

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


Um die dritte Form zu umgehen, können wir den Verbinder anpassen, indem wir seine vertikale Linie nach links verschieben:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **Komplexe Fälle** 

Für aufwändigere Anpassungen müssen Sie Folgendes berücksichtigen:

* Ein verstellbarer Punkt eines Verbinders ist eng mit einer Formel verknüpft, die seine Position berechnet. Änderungen der Punktposition können daher die Form des Verbinders ändern.  
* Die Anpassungspunkte eines Verbinders sind in einem Array in einer festen Reihenfolge definiert. Sie werden vom Start‑ zum Endpunkt des Verbinders nummeriert.  
* Die Werte der Anpassungspunkte geben den Prozentsatz der Breite/Höhe des Verbinder‑Shapes an.  
  * Der Shape wird durch die Start‑ und Endpunkte des Verbinders multipliziert mit 1000 begrenzt.  
  * Der erste, zweite bzw. dritte Punkt definiert jeweils den Prozentsatz der Breite, der Höhe und erneut der Breite.  
* Für Berechnungen, die die Koordinaten der Anpassungspunkte eines Verbinders bestimmen, müssen Sie die Rotation und Spiegelung des Verbinders berücksichtigen. **Hinweis**: Der Rotationswinkel für alle unter **[Typen von Verbindern](/slides/de/java/connector/#types-of-connectors)** gezeigten Verbinder beträgt 0.

#### **Fall 1**

Betrachten Sie den Fall, dass zwei Text‑Frame‑Objekte über einen Verbinder verknüpft sind:

![connector-shape-complex](connector-shape-complex.png)
```java
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Holt die erste Folie der Präsentation
    ISlide sld = pres.getSlides().get_Item(0);
    // Fügt Formen hinzu, die über einen Verbinder zusammengeführt werden
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Fügt einen Verbinder hinzu
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // Gibt die Richtung des Verbinders an
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // Gibt die Farbe des Verbinders an
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // Gibt die Dicke der Verbinderlinie an
    connector.getLineFormat().setWidth(3);
    
    // Verknüpft die Formen mit dem Verbinder
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // Holt Anpassungspunkte für den Verbinder
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```


**Anpassung**

Wir können die Werte der Anpassungspunkte erhöhen, indem wir den entsprechenden Breiten‑ bzw. Höhen‑Prozentsatz um 20 % bzw. 200 % steigern:
```java
// Ändert die Werte der Anpassungspunkte
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


Das Ergebnis:

![connector-adjusted-1](connector-adjusted-1.png)

Um ein Modell zu definieren, das uns die Koordinaten und die Form einzelner Verbinder‑Teile liefert, erstellen wir ein Shape, das dem horizontalen Anteil des Verbinders am Punkt `connector.getAdjustments().get_Item(0)` entspricht:
```java
// Zeichne den vertikalen Teil des Verbinders
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```


Das Ergebnis:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

In **Fall 1** haben wir eine einfache Verbinder‑Anpassung anhand grundlegender Prinzipien demonstriert. In normalen Situationen müssen Sie die Rotation des Verbinders und seine Darstellung (gesetzt durch `connector.getRotation()`, `connector.getFrame().getFlipH()` und `connector.getFrame().getFlipV()`) berücksichtigen. Im Folgenden wird der Vorgang gezeigt.

Zuerst fügen wir der Folie ein neues Text‑Frame‑Objekt (**To 1**) zum Zweck der Verbindung hinzu und erzeugen einen neuen (grünen) Verbinder, der es mit den bereits erstellten Objekten verbindet.
```java
// Erstellt ein neues Bindungsobjekt
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Erstellt einen neuen Verbinder
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
// Holt die Anpassungspunkte des Verbinders
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Ändert die Werte der Anpassungspunkte
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


Das Ergebnis:

![connector-adjusted-3](connector-adjusted-3.png)

Als nächstes erstellen wir ein Shape, das dem horizontalen Anteil des Verbinders entspricht, der durch den neuen Anpassungspunkt `connector.getAdjustments().get_Item(0)` verläuft. Wir verwenden die Werte aus `connector.getRotation()`, `connector.getFrame().getFlipH()` und `connector.getFrame().getFlipV()` und wenden die gängige Koordinaten‑Umrechnungs‑Formel für eine Rotation um einen Punkt x0 an:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Rotationswinkel des Objekts 90 Grad und der Verbinder wird vertikal dargestellt, sodass der entsprechende Code lautet:
```java
// Speichert die Koordinaten des Connectors
x = connector.getX();
y = connector.getY();
// Korrigiert die Connector‑Koordinaten, falls sie auftreten
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
//  Konvertiert die Koordinaten, da Sin(90)=1 und Cos(90)=0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// Bestimmt die Breite der horizontalen Komponente mit dem Wert des zweiten Anpassungspunkts
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```


Das Ergebnis:

![connector-adjusted-4](connector-adjusted-4.png)

Wir haben Berechnungen sowohl für einfache Anpassungen als auch für komplexe Anpassungspunkte (mit Rotationswinkel) demonstriert. Mit diesem Wissen können Sie Ihr eigenes Modell entwickeln (oder Code schreiben), um ein `GraphicsPath`‑Objekt zu erhalten oder die Werte von Verbinder‑Anpassungspunkten basierend auf konkreten Folien‑Koordinaten festzulegen.

## **Winkel von Verbinder‑Linien bestimmen**

1. Erstellen Sie eine Instanz der Klasse.  
1. Holen Sie sich über den Index einen Verweis auf die Folie.  
1. Greifen Sie auf das Verbinder‑Linien‑Shape zu.  
1. Verwenden Sie Breite, Höhe, Frame‑Höhe und Frame‑Breite, um den Winkel zu berechnen.  

Der folgende Java‑Code demonstriert die Berechnung des Winkels für ein Verbinder‑Linien‑Shape:
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

**Wie kann ich feststellen, ob ein Verbinder an eine bestimmte Form „geklebt“ werden kann?**

Prüfen Sie, ob die Form [connection sites](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getConnectionSiteCount--) bereitstellt. Gibt es keine oder ist die Anzahl 0, ist ein Kleben nicht möglich; verwenden Sie in diesem Fall freie Endpunkte und positionieren Sie sie manuell. Es ist sinnvoll, die Site‑Anzahl vor dem Anhängen zu prüfen.

**Was passiert mit einem Verbinder, wenn ich eine der verbundenen Formen lösche?**

Seine Enden werden getrennt; der Verbinder bleibt als gewöhnliche Linie mit freien Start‑/Endpunkten auf der Folie. Sie können ihn entweder löschen oder die Verbindungen neu zuweisen und bei Bedarf [reroute](https://reference.aspose.com/slides/java/com.aspose.slides/connector/#reroute--) aufrufen.

**Werden Verbinder‑Bindungen beim Kopieren einer Folie in eine andere Präsentation beibehalten?**

In der Regel ja, sofern die Ziel‑Formen ebenfalls kopiert werden. Wird die Folie in eine andere Datei eingefügt, ohne die verbundenen Formen, werden die Enden frei und Sie müssen sie erneut anhängen.