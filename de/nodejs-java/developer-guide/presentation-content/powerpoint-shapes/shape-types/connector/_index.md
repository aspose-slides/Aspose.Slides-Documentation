---
title: Verbinder
type: docs
weight: 10
url: /de/nodejs-java/connector/
keywords: "Formen verbinden, Verbinder, PowerPoint-Formen, PowerPoint-Präsentation, Java, Aspose.Slides für Node.js via Java"
description: "PowerPoint-Formen in JavaScript verbinden"
---

Ein PowerPoint‑Verbinder ist eine spezielle Linie, die zwei Formen miteinander verbindet oder verknüpft und an den Formen befestigt bleibt, selbst wenn sie auf einer Folie verschoben oder neu positioniert werden. 

Verbinder sind typischerweise mit *Verbindungspunkten* (grüne Punkte) verbunden, die standardmäßig auf allen Formen vorhanden sind. Verbindungspunkte erscheinen, wenn sich der Zeiger ihnen nähert.

*Anpassungspunkte* (orange Punkte), die nur bei bestimmten Verbindern existieren, werden verwendet, um die Positionen und Formen von Verbindern zu ändern.

## **Arten von Verbindern**

In PowerPoint können Sie gerade, Ellenbogen‑(gekrümmte) und gekrümmte Verbinder verwenden. 

Aspose.Slides stellt diese Verbinder bereit:

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

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) hinzu, indem Sie die Methode `addAutoShape` des `Shapes`‑Objekts verwenden.
4. Fügen Sie einen Verbinder hinzu, indem Sie die Methode `addConnector` des `Shapes`‑Objekts verwenden und den Verbinder‑Typ definieren.
5. Verbinden Sie die Formen mit dem Verbinder.
6. Rufen Sie die Methode `reroute` auf, um den kürzesten Verbindungsweg anzuwenden.
7. Speichern Sie die Präsentation. 

Dieser JavaScript‑Code zeigt, wie man einen Verbinder (einen gebogenen Verbinder) zwischen zwei Formen (einer Ellipse und einem Rechteck) hinzufügt:
```javascript
// Instanziiert eine Präsentationsklasse, die die PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die Formen-Sammlung einer bestimmten Folie zu
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Fügt eine Ellipse-Autoshape hinzu
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Fügt eine Rechteck-Autoshape hinzu
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Fügt der Formen-Sammlung der Folie ein Verbinder-Shape hinzu
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Verbindet die Formen mit dem Verbinder
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Ruft reroute auf, das den automatischen kürzesten Pfad zwischen Formen festlegt
    connector.reroute();
    // Speichert die Präsentation
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

Die Methode `Connector.reroute` leitet einen Verbinder neu und zwingt ihn, den kürzesten möglichen Pfad zwischen Formen zu nehmen. Um dies zu erreichen, kann die Methode die Punkte `setStartShapeConnectionSiteIndex` und `setEndShapeConnectionSiteIndex` ändern. 

{{% /alert %}} 

## **Verbindungspunkt angeben**

Wenn Sie möchten, dass ein Verbinder zwei Formen über bestimmte Punkte auf den Formen verbindet, müssen Sie Ihre bevorzugten Verbindungspunkte wie folgt angeben:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) hinzu, indem Sie die Methode `addAutoShape` des `Shapes`‑Objekts verwenden.
4. Fügen Sie einen Verbinder hinzu, indem Sie die Methode `addConnector` des `Shapes`‑Objekts verwenden und den Verbinder‑Typ definieren.
5. Verbinden Sie die Formen mit dem Verbinder.
6. Setzen Sie Ihre bevorzugten Verbindungspunkte auf den Formen.
7. Speichern Sie die Präsentation.

Dieser JavaScript‑Code demonstriert einen Vorgang, bei dem ein bevorzugter Verbindungspunkt angegeben wird:
```javascript
// Instanziiert eine Präsentationsklasse, die eine PPTX-Datei repräsentiert
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die Formen-Sammlung einer bestimmten Folie zu
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // Fügt eine Ellipse-Autoshape hinzu
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // Fügt eine Rechteck-Autoshape hinzu
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // Fügt der Formen-Sammlung der Folie ein Verbinder-Shape hinzu
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // Verbindet die Formen mithilfe des Verbinders
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // Legt den bevorzugten Verbindungs-Punkt‑Index auf der Ellipse-Shape fest
    var wantedIndex = 6;
    // Prüft, ob der bevorzugte Index kleiner ist als die maximale Site‑Index‑Anzahl
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // Setzt den bevorzugten Verbindungs‑Punkt auf der Ellipse-Autoshape
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // Speichert die Präsentation
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Verbinder‑Punkt anpassen**

Sie können einen vorhandenen Verbinder über seine Anpassungspunkte anpassen. Nur Verbinder mit Anpassungspunkten können auf diese Weise geändert werden. Siehe die Tabelle unter **[Arten von Verbindern.](/slides/de/nodejs-java/connector/#types-of-connectors)**

### **Einfacher Fall**

Betrachten Sie den Fall, dass ein Verbinder zwischen zwei Formen (A und B) durch eine dritte Form (C) führt:

![connector-obstruction](connector-obstruction.png)
```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Um die dritte Form zu vermeiden oder zu umfahren, können wir den Verbinder anpassen, indem wir seine vertikale Linie nach links verschieben:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```


### **Komplexe Fälle** 

Um kompliziertere Anpassungen vorzunehmen, müssen Sie folgende Punkte berücksichtigen:

* Ein anpassbarer Punkt eines Verbinders ist eng mit einer Formel verbunden, die seine Position berechnet und bestimmt. Änderungen der Punktposition können daher die Form des Verbinders verändern.
* Die Anpassungspunkte eines Verbinders werden in einem Array in einer festen Reihenfolge definiert. Die Punkte werden vom Start- zum Endpunkt des Verbinders nummeriert.
* Die Werte der Anpassungspunkte geben den Prozentsatz der Breite/Höhe der Verbinderform wieder.
  * Die Form ist durch die Start- und Endpunkte des Verbinders multipliziert mit 1000 begrenzt.
  * Der erste Punkt, der zweite Punkt und der dritte Punkt definieren jeweils den Prozentsatz der Breite, den Prozentsatz der Höhe und erneut den Prozentsatz der Breite.
* Für Berechnungen, die die Koordinaten der Anpassungspunkte eines Verbinders bestimmen, müssen Sie die Drehung des Verbinders und seine Spiegelung berücksichtigen. **Hinweis**, dass der Drehwinkel für alle unter **[Arten von Verbindern](/slides/de/nodejs-java/connector/#types-of-connectors)** gezeigten Verbinder 0 ist.

#### **Fall 1**

Betrachten Sie den Fall, dass zwei Textfeld‑Objekte über einen Verbinder miteinander verbunden sind:

![connector-shape-complex](connector-shape-complex.png)
```javascript
// Instanziert eine Präsentationsklasse, die eine PPTX-Datei repräsentiert
var pres = new aspose.slides.Presentation();
try {
    // Holt die erste Folie der Präsentation
    var sld = pres.getSlides().get_Item(0);
    // Fügt Formen hinzu, die über einen Verbinder zusammengefügt werden
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // Fügt einen Verbinder hinzu
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // Legt die Richtung des Verbinders fest
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // Legt die Farbe des Verbinders fest
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Legt die Linienstärke des Verbinders fest
    connector.getLineFormat().setWidth(3);
    // Verbindet die Formen mittels des Verbinders
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // Ermittelt Anpassungspunkte für den Verbinder
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**Anpassung**

Wir können die Werte der Anpassungspunkte des Verbinders ändern, indem wir den jeweiligen Prozentsatz der Breite um 20 % und den der Höhe um 200 % erhöhen:
```javascript
// Ändert die Werte der Anpassungspunkte
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


Das Ergebnis:

![connector-adjusted-1](connector-adjusted-1.png)

Um ein Modell zu definieren, das uns ermöglicht, die Koordinaten und die Form einzelner Teile des Verbinders zu bestimmen, erstellen wir eine Form, die der horizontalen Komponente des Verbinders am Punkt `connector.getAdjustments().get_Item(0)` entspricht:
```javascript
// Zeichnet die vertikale Komponente des Verbinders
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```


Das Ergebnis:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

In **Fall 1** haben wir eine einfache Verbinder‑Anpassungsoperation anhand grundlegender Prinzipien demonstriert. In normalen Situationen müssen Sie die Drehung des Verbinders und seine Darstellung (die durch `connector.getRotation()`, `connector.getFrame().getFlipH()` und `connector.getFrame().getFlipV()` festgelegt werden) berücksichtigen. Wir werden nun den Vorgang demonstrieren.

Zunächst fügen wir der Folie ein neues Textfeld‑Objekt (**To 1**) (zwecks Verbindung) hinzu und erstellen einen neuen (grünen) Verbinder, der es mit den bereits erstellten Objekten verbindet.  
```javascript
// Erstellt ein neues Bindungsobjekt
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// Erstellt einen neuen Verbinder
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// Verbindet Objekte mithilfe des neu erstellten Verbinders
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// Ermittelt die Anpassungspunkte des Verbinders
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// Ändert die Werte der Anpassungspunkte
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```


Das Ergebnis:

![connector-adjusted-3](connector-adjusted-3.png)

Zweitens erstellen wir eine Form, die der horizontalen Komponente des Verbinders entspricht, die durch den Anpassungspunkt des neuen Verbinders `connector.getAdjustments().get_Item(0)` verläuft. Wir verwenden die Werte aus den Connector‑Daten für `connector.getRotation()`, `connector.getFrame().getFlipH()` und `connector.getFrame().getFlipV()` und wenden die bekannte Koordinaten‑Umrechnungsformel für die Rotation um einen gegebenen Punkt x0 an:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Rotationswinkel des Objekts 90 Grad und der Verbinder wird vertikal dargestellt, daher ist dies der entsprechende Code:
```javascript
// Speichert die Koordinaten des Verbinders
x = connector.getX();
y = connector.getY();
// Korrigiert die Koordinaten des Verbinders, falls sie erscheinen
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// Verwendet den Wert des Anpassungspunkts als Koordinate
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// Konvertiert die Koordinaten, da Sin(90) = 1 und Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// Bestimmt die Breite der horizontalen Komponente mithilfe des Wertes des zweiten Anpassungspunkts
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```


Das Ergebnis:

![connector-adjusted-4](connector-adjusted-4.png)

Wir haben Berechnungen gezeigt, die einfache Anpassungen und komplexe Anpassungspunkte (Anpassungspunkte mit Drehwinkeln) umfassen. Mit dem erworbenen Wissen können Sie Ihr eigenes Modell entwickeln (oder Code schreiben), um ein `GraphicsPath`‑Objekt zu erhalten oder sogar die Werte der Anpassungspunkte eines Verbinders basierend auf spezifischen Folienkoordinaten festzulegen.

## **Winkel von Verbinder‑Linien ermitteln**

1. Erstellen Sie eine Instanz der Klasse.
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Greifen Sie auf die Form der Verbinder‑Linie zu.
4. Verwenden Sie die Linienbreite, -höhe, die Rahmenhöhe der Form und die Rahmenbreite der Form, um den Winkel zu berechnen.

Dieser JavaScript‑Code demonstriert einen Vorgang, bei dem wir den Winkel einer Verbinder‑Linienform berechnet haben:
```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```


## **FAQ**

**Wie kann ich erkennen, ob ein Verbinder an einer bestimmten Form „geklebt“ werden kann?**

Überprüfen Sie, ob die Form [connection sites](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getconnectionsitecount/) bereitstellt. Wenn keine vorhanden sind oder die Anzahl null beträgt, ist das Kleben nicht verfügbar; verwenden Sie in diesem Fall freie Endpunkte und positionieren Sie diese manuell. Es ist sinnvoll, die Anzahl der Sites vor dem Anfügen zu prüfen.

**Was passiert mit einem Verbinder, wenn ich eine der verbundenen Formen lösche?**

Seine Enden werden getrennt; der Verbinder bleibt als gewöhnliche Linie mit freien Start‑/Endpunkten auf der Folie erhalten. Sie können ihn entweder löschen oder die Verbindungen neu zuweisen und bei Bedarf [reroute](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/reroute/) verwenden.

**Werden Verbinder‑Verbindungen beim Kopieren einer Folie in eine andere Präsentation erhalten?**

Im Allgemeinen ja, vorausgesetzt, die Ziel‑Formen werden ebenfalls kopiert. Wenn die Folie in eine andere Datei eingefügt wird, ohne die verbundenen Formen, werden die Enden frei und Sie müssen sie erneut anfügen.