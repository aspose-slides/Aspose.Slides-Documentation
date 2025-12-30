---
title: Verwalten von Verbindern in Präsentationen mit PHP
linktitle: Verbinder
type: docs
weight: 10
url: /de/php-java/connector/
keywords:
- Verbinder
- Verbindertyp
- Verbindungspunkt
- Verbindungslinie
- Verbindungswinkel
- Formen verbinden
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Ermöglichen Sie PHP-Anwendungen, Linien in PowerPoint-Folien zu zeichnen, zu verbinden und automatisch zu routen - erhalten Sie die volle Kontrolle über gerade, Ellenbogen- und gekrümmte Verbinder."
---

Ein PowerPoint‑Verbinder ist eine spezielle Linie, die zwei Formen miteinander verbindet oder verknüpft und an den Formen haften bleibt, selbst wenn sie auf einer Folie verschoben oder neu positioniert werden. 

Verbinder werden typischerweise an *Verbindungspunkten* (grüne Punkte) befestigt, die standardmäßig auf allen Formen vorhanden sind. Verbindungspunkte erscheinen, wenn sich der Cursor ihnen nähert.

*Anpassungspunkte* (orange Punkte), die nur bei bestimmten Verbindern existieren, werden verwendet, um die Positionen und Formen von Verbindern zu ändern.

## **Typen von Verbindern**

In PowerPoint können Sie gerade, Ellenbogen‑ (geknickte) und gekrümmte Verbinder verwenden. 

Aspose.Slides stellt diese Verbinder bereit:

| Verbinder                      | Bild                                                         | Anzahl der Anpassungspunkte |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Formen mit Verbindern verbinden**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Holen Sie sich über den Index die Referenz einer Folie.
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) mithilfe der vom `Shapes`‑Objekt bereitgestellten Methode `addAutoShape` hinzu.
1. Fügen Sie einen Verbinder hinzu, indem Sie die vom `Shapes`‑Objekt bereitgestellte Methode `addConnector` verwenden und den Verbinder‑Typ festlegen.
1. Verbinden Sie die Formen mithilfe des Verbinders.
1. Rufen Sie die Methode `reroute` auf, um den kürzesten Verbindungsweg anzuwenden.
1. Speichern Sie die Präsentation. 

Dieser PHP‑Code zeigt, wie Sie einen Verbinder (einen gebogenen Verbinder) zwischen zwei Formen (einer Ellipse und einem Rechteck) hinzufügen:
```php
// Instanziiert eine Präsentationsklasse, die die PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # Greift auf die Shape-Sammlung einer bestimmten Folie zu
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Fügt ein Ellipse-AutoShape hinzu
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Fügt ein Rechteck-AutoShape hinzu
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Fügt ein Verbindungs-Shape zur Shape-Sammlung der Folie hinzu
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Verbindet die Shapes mittels des Connectors
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Ruft reroute auf, das den automatischen kürzesten Pfad zwischen den Shapes festlegt
    $connector->reroute();
    # Speichert die Präsentation
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```


{{%  alert title="NOTE"  color="warning"   %}} 

Die Methode `Connector.reroute` leitet einen Verbinder neu und zwingt ihn, den kürzesten möglichen Pfad zwischen den Formen zu nehmen. Um dies zu erreichen, kann die Methode die Punkte `setStartShapeConnectionSiteIndex` und `setEndShapeConnectionSiteIndex` ändern. 

{{% /alert %}} 

## **Verbindungspunkt festlegen**

Wenn Sie möchten, dass ein Verbinder zwei Formen über bestimmte Punkte auf den Formen verbindet, müssen Sie die gewünschten Verbindungspunkte wie folgt festlegen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Holen Sie sich über den Index die Referenz einer Folie.
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) mithilfe der vom `Shapes`‑Objekt bereitgestellten Methode `addAutoShape` hinzu.
1. Fügen Sie einen Verbinder hinzu, indem Sie die vom `Shapes`‑Objekt bereitgestellte Methode `addConnector` verwenden und den Verbinder‑Typ festlegen.
1. Verbinden Sie die Formen mithilfe des Verbinders.
1. Legen Sie die gewünschten Verbindungspunkte auf den Formen fest.
1. Speichern Sie die Präsentation.

Dieser PHP‑Code demonstriert einen Vorgang, bei dem ein gewünschter Verbindungspunkt angegeben wird:
```php
  # Instanziiert eine Präsentationsklasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # Greift auf die Shape-Sammlung einer bestimmten Folie zu
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Fügt ein Ellipse-AutoShape hinzu
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Fügt ein Rechteck-AutoShape hinzu
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Fügt ein Connector-Shape zur Shape-Sammlung der Folie hinzu
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Verbindet die Shapes mittels des Connectors
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Setzt den gewünschten Verbindungspunkt-Index auf dem Ellipse-Shape
    $wantedIndex = 6;
    # Prüft, ob der gewünschte Index kleiner ist als die maximale Site-Index-Anzahl
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Setzt den gewünschten Verbindungspunkt auf dem Ellipse-AutoShape
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # Speichert die Präsentation
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Einen Verbinderpunkt anpassen**

Sie können einen bestehenden Verbinder über seine Anpassungspunkte anpassen. Nur Verbinder mit Anpassungspunkten können auf diese Weise verändert werden. Siehe die Tabelle unter **[Typen von Verbindern.](/slides/de/php-java/connector/#types-of-connectors)**

### **Einfacher Fall**

Betrachten Sie einen Fall, bei dem ein Verbinder zwischen zwei Formen (A und B) durch eine dritte Form (C) verläuft:

![connector-obstruction](connector-obstruction.png)
```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Um die dritte Form zu umgehen oder zu umgehen, können wir den Verbinder anpassen, indem wir seine vertikale Linie nach links verschieben:

![connector-obstruction-fixed](connector-obstruction-fixed.png)
```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```


### **Komplexe Fälle** 

Um komplexere Anpassungen vorzunehmen, müssen Sie Folgendes berücksichtigen:

* Der anpassbare Punkt eines Verbinders ist eng mit einer Formel verknüpft, die seine Position berechnet und bestimmt. Änderungen der Punktposition können daher die Form des Verbinders verändern.
* Die Anpassungspunkte eines Verbinders werden in einem Array in einer strikten Reihenfolge definiert. Die Punkte werden vom Start- zum Endpunkt des Verbinders nummeriert.
* Die Werte der Anpassungspunkte geben den Prozentsatz der Breite/Höhe der Verbinderform an.
  * Die Form wird durch die Start- und Endpunkte des Verbinders multipliziert mit 1000 begrenzt.
  * Der erste, zweite und dritte Punkt definieren jeweils den Prozentsatz der Breite, der Höhe und erneut der Breite.
* Für Berechnungen, die die Koordinaten der Anpassungspunkte eines Verbinders bestimmen, müssen Sie die Drehung und Spiegelung des Verbinders berücksichtigen. **Hinweis**: Der Rotationswinkel aller unter **[Typen von Verbindern](/slides/de/php-java/connector/#types-of-connectors)** dargestellten Verbinder beträgt 0.

#### **Fall 1**

Betrachten Sie einen Fall, bei dem zwei Textfeld‑Objekte über einen Verbinder miteinander verbunden sind:

![connector-shape-complex](connector-shape-complex.png)
```php
  # Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Ruft die erste Folie der Präsentation ab
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt Formen hinzu, die über einen Verbinder verbunden werden
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # Fügt einen Verbinder hinzu
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Legt die Richtung des Verbinders fest
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Legt die Farbe des Verbinders fest
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Legt die Dicke der Verbinderlinie fest
    $connector->getLineFormat()->setWidth(3);
    # Verbindet die Formen mithilfe des Verbinders
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Ruft die Anpassungspunkte des Verbinders ab
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


**Anpassung**

Wir können die Werte der Anpassungspunkte des Verbinders ändern, indem wir die jeweilige Breiten‑ bzw. Höhenprozentsätze um 20 % bzw. 200 % erhöhen:
```php
  # Ändert die Werte der Anpassungspunkte
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```


Das Ergebnis:

![connector-adjusted-1](connector-adjusted-1.png)

Um ein Modell zu definieren, mit dem wir die Koordinaten und die Form einzelner Teile des Verbinders bestimmen können, erstellen wir eine Form, die der horizontalen Komponente des Verbinders am Punkt connector.getAdjustments().get_Item(0) entspricht:
```php
  # Zeichnet die vertikale Komponente des Verbinders
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```


Das Ergebnis:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

In **Fall 1** haben wir eine einfache Verbinderanpassung anhand grundlegender Prinzipien demonstriert. In normalen Situationen müssen Sie die Drehung des Verbinders und seine Darstellung (die durch connector.getRotation(), connector.getFrame().getFlipH() und connector.getFrame().getFlipV() festgelegt werden) berücksichtigen. Wir werden nun den Vorgang demonstrieren.

Zuerst fügen wir der Folie ein neues Textfeld‑Objekt (**To 1**) (zur Verbindung) hinzu und erstellen einen neuen (grünen) Verbinder, der es mit den bereits erstellten Objekten verbindet.
```php
  # Erstellt ein neues Bindungsobjekt
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # Erstellt einen neuen Verbinder
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Verbindet Objekte mit dem neu erstellten Verbinder
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Liest die Anpassungspunkte des Verbinders
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Ändert die Werte der Anpassungspunkte
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```


Das Ergebnis:

![connector-adjusted-3](connector-adjusted-3.png)

Als Nächstes erstellen wir eine Form, die der horizontalen Komponente des Verbinders entspricht, die durch den neuen Anpassungspunkt des Verbinders connector.getAdjustments().get_Item(0) verläuft. Wir verwenden die Werte aus den Connector‑Daten für connector.getRotation(), connector.getFrame().getFlipH() und connector.getFrame().getFlipV() und wenden die gängige Koordinatenumrechnungs‑Formel für die Drehung um einen gegebenen Punkt x0 an:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Rotationswinkel des Objekts 90 Grad und der Verbinder wird vertikal angezeigt, sodass der entsprechende Code lautet:
```php
  # Speichert die Connector‑Koordinaten
  $x = $connector->getX();
  $y = $connector->getY();
  # Korrigiert die Connector‑Koordinaten, falls sie auftreten
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Nimmt den Wert des Anpassungspunkts als Koordinate
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Konvertiert die Koordinaten, da Sin(90) = 1 und Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # Bestimmt die Breite der horizontalen Komponente anhand des zweiten Anpassungspunktwerts
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```


Das Ergebnis:

![connector-adjusted-4](connector-adjusted-4.png)

Wir haben Berechnungen zu einfachen Anpassungen und komplexen Anpassungspunkten (Anpassungspunkte mit Rotationswinkeln) demonstriert. Mit dem erworbenen Wissen können Sie Ihr eigenes Modell entwickeln (oder Code schreiben), um ein `GraphicsPath`‑Objekt zu erhalten oder sogar die Werte der Anpassungspunkte eines Verbinders basierend auf spezifischen Folienkoordinaten festzulegen.

## **Den Winkel von Verbinderlinien ermitteln**

1. Erstellen Sie eine Instanz der Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Greifen Sie auf die Form der Verbinderlinie zu.
4. Verwenden Sie die Linienbreite, -höhe, die Höhe des Formrahmens und die Breite des Formrahmens, um den Winkel zu berechnen.

Dieser PHP‑Code demonstriert eine Operation, bei der wir den Winkel einer Verbinderlinien‑Form berechnet haben:
```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wie kann ich feststellen, ob ein Verbinder an einer bestimmten Form „geklebt“ werden kann?**

Prüfen Sie, ob die Form [Verbindungspunkte](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getconnectionsitecount/) bereitstellt. Wenn keine vorhanden sind oder die Anzahl null beträgt, ist ein Kleben nicht möglich; verwenden Sie in diesem Fall freie Endpunkte und positionieren Sie sie manuell. Es ist sinnvoll, die Anzahl der Punkte vor dem Anhängen zu überprüfen.

**Was passiert mit einem Verbinder, wenn ich eine der verbundenen Formen lösche?**

Seine Enden werden gelöst; der Verbinder bleibt als normale Linie mit freiem Start/Ende auf der Folie erhalten. Sie können ihn entweder löschen oder die Verbindungen neu zuordnen und bei Bedarf [neu routen](https://reference.aspose.com/slides/php-java/aspose.slides/connector/reroute/).

**Bleiben Verbinderbindungen erhalten, wenn eine Folie in eine andere Präsentation kopiert wird?**

Im Allgemeinen ja, sofern die Ziel‑Formen ebenfalls kopiert werden. Wird die Folie in eine andere Datei eingefügt, ohne dass die verbundenen Formen enthalten sind, werden die Enden frei und müssen erneut angehängt werden.