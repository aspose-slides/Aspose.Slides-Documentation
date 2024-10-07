---
title: Connector
type: docs
weight: 10
url: /php-java/connector/
keywords: "Formen verbinden, Verbindungen, PowerPoint Formen, PowerPoint Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Verbinden Sie PowerPoint Formen"
---

Ein PowerPoint-Connector ist eine spezielle Linie, die zwei Formen miteinander verbindet oder verknüpft und auch bei Verschiebung oder Umpositionierung auf einer Folie an diesen Formen haften bleibt. 

Connectoren sind typischerweise mit *Verbindungspunkten* (grüne Punkte) verbunden, die standardmäßig auf allen Formen vorhanden sind. Verbindungspunkte erscheinen, wenn der Cursor in ihre Nähe kommt.

*Anpassungspunkte* (orange Punkte), die nur auf bestimmten Verbindern existieren, werden verwendet, um die Position und Form der Connectoren zu ändern.

## **Typen von Connectors**

In PowerPoint können Sie gerade, winkelige (geknickte) und gebogene Connectoren verwenden. 

Aspose.Slides bietet diese Connectoren an:

| Connector                      | Bild                                                        | Anzahl der Anpassungspunkte |
| ------------------------------ | ---------------------------------------------------------- | --------------------------- |
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

## **Formen mit Connectors verbinden**

1. Erstellen Sie eine Instanz der [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Holen Sie sich eine Referenz auf die Folie über ihren Index.
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) mit der Methode `addAutoShape` hinzu, die vom `Shapes` Objekt bereitgestellt wird.
1. Fügen Sie einen Connector mit der von dem `Shapes` Objekt bereitgestellten Methode `addConnector` hinzu, indem Sie den Connector-Typ definieren.
1. Verbinden Sie die Formen mit dem Connector. 
1. Rufen Sie die Methode `reroute` auf, um den kürzesten Verbindungsweg anzuwenden.
1. Speichern Sie die Präsentation. 

Dieser PHP-Code zeigt, wie Sie einen Connector (einen geknickten Connector) zwischen zwei Formen (einem Ellipsen- und einem Rechteck) hinzufügen:

```php
// Instanziiert eine Präsentationsklasse, die die PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Greift auf die Shapes-Sammlung für eine bestimmte Folie zu
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Fügt eine Ellipse AutoShape hinzu
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Fügt eine Rechteck AutoShape hinzu
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Fügt eine Connector-Form zur Shape-Sammlung der Folie hinzu
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Verbindet die Formen mit dem Connector
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Ruft reroute auf, das den automatischen kürzesten Weg zwischen den Formen festlegt
    $connector->reroute();
    # Speichert die Präsentation
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="HINWEIS"  color="warning"   %}} 

Die Methode `Connector.reroute` ändert die Route eines Connectors und zwingt ihn, den kürzesten möglichen Weg zwischen den Formen zu nehmen. Um sein Ziel zu erreichen, kann die Methode die Punkte `setStartShapeConnectionSiteIndex` und `setEndShapeConnectionSiteIndex` ändern. 

{{% /alert %}} 

## **Verbindungspunkt angeben**

Wenn Sie möchten, dass ein Connector zwei Formen mithilfe spezifischer Punkte auf den Formen verbindet, müssen Sie Ihre bevorzugten Verbindungspunkte folgendermaßen angeben:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Holen Sie sich eine Referenz auf die Folie über ihren Index.
1. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) mit der Methode `addAutoShape` hinzu, die vom `Shapes` Objekt bereitgestellt wird.
1. Fügen Sie einen Connector mit der von dem `Shapes` Objekt bereitgestellten Methode `addConnector` hinzu, indem Sie den Connector-Typ definieren.
1. Verbinden Sie die Formen mit dem Connector. 
1. Legen Sie Ihre bevorzugten Verbindungspunkte auf den Formen fest. 
1. Speichern Sie die Präsentation.

Dieser PHP-Code demonstriert eine Operation, bei der ein bevorzugter Verbindungspunkt angegeben wird:

```php
  # Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Greift auf die Shapes-Sammlung für eine bestimmte Folie zu
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # Fügt eine Ellipse AutoShape hinzu
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # Fügt eine Rechteck AutoShape hinzu
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # Fügt eine Connector-Form zur Shape-Sammlung der Folie hinzu
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # Verbindet die Formen mit dem Connector
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # Setzt den gewünschten Verbindungspunktindex auf der Ellipsenform
    $wantedIndex = 6;
    # Überprüft, ob der bevorzugte Index kleiner als die maximale Anzahl der Verbindungspunkte ist
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # Setzt den bevorzugten Verbindungspunkt auf der Ellipse AutoShape
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

## **Connector-Punkt anpassen**

Sie können einen vorhandenen Connector über seine Anpassungspunkte anpassen. Nur Connectoren mit Anpassungspunkten können auf diese Weise verändert werden. Siehe die Tabelle unter **[Typen von Connectors](/slides/php-java/connector/#types-of-connectors)**

#### **Einfacher Fall**

Betrachten Sie den Fall, in dem ein Connector zwischen zwei Formen (A und B) durch eine dritte Form (C) verläuft:

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

Um die dritte Form zu vermeiden oder zu umgehen, können wir den Connector anpassen, indem wir seine vertikale Linie auf diese Weise nach links verschieben:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **Komplexe Fälle** 

Um kompliziertere Anpassungen vorzunehmen, müssen Sie folgende Dinge beachten:

* Ein anpassbarer Punkt eines Connectors ist stark an eine Formel gebunden, die seine Position berechnet und bestimmt. Änderungen am Standort des Punktes können die Form des Connectors ändern.
* Die Anpassungspunkte eines Connectors sind in einer strengen Reihenfolge in einem Array definiert. Die Anpassungspunkte sind von dem Startpunkt eines Connectors bis zu seinem Endpunkt nummeriert.
* Die Werte der Anpassungspunkte spiegeln den Prozentsatz der Breite/Höhe einer Connectorform wider. 
  * Die Form wird durch die Start- und Endpunkte des Connectors multipliziert mit 1000 begrenzt. 
  * Der erste Punkt, der zweite Punkt und der dritte Punkt definieren den Prozentsatz von der Breite, den Prozentsatz von der Höhe und erneut den Prozentsatz von der Breite.
* Bei Berechnungen, die die Koordinaten der Anpassungspunkte eines Connectors bestimmen, müssen Sie die Drehung und die Spiegelung des Connectors berücksichtigen. **Hinweis**: Der Drehwinkel für alle Connectoren, die unter **[Typen von Connectors](/slides/php-java/connector/#types-of-connectors)** angezeigt werden, beträgt 0.

#### **Fall 1**

Betrachten Sie den Fall, in dem zwei Textfeldobjekte durch einen Connector miteinander verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

```php
  # Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Holt sich die erste Folie in der Präsentation
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt Formen hinzu, die durch einen Connector verbunden werden
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("Von");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("Zu");
    # Fügt einen Connector hinzu
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # Gibt die Richtung des Connectors an
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # Gibt die Farbe des Connectors an
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Gibt die Dicke der Linien des Connectors an
    $connector->getLineFormat()->setWidth(3);
    # Verknüpft die Formen mit dem Connector
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # Holt sich die Anpassungspunkte für den Connector
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Anpassung**

Wir können die Werte der Anpassungspunkte des Connectors ändern, indem wir den entsprechenden Breiten- und Höhenprozentsatz um 20% bzw. 200% erhöhen:

```php
  # Ändert die Werte der Anpassungspunkte
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);

```

Das Ergebnis:

![connector-adjusted-1](connector-adjusted-1.png)

Um ein Modell zu definieren, das es uns ermöglicht, die Koordinaten und die Form einzelner Teile des Connectors zu bestimmen, erstellen wir eine Form, die dem horizontalen Bestandteil des Connectors am Punkt connector.getAdjustments().get_Item(0) entspricht:

```php
  # Zeichnet den vertikalen Bestandteil des Connectors
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);

```

Das Ergebnis:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

Im **Fall 1** haben wir eine einfache Connector-Anpassungsoperation mit grundlegenden Prinzipien demonstriert. In normalen Situationen müssen Sie die Drehung des Connectors und seine Darstellung (die durch connector.getRotation(), connector.getFrame().getFlipH() und connector.getFrame().getFlipV() festgelegt werden) berücksichtigen. Jetzt werden wir den Prozess demonstrieren.

Zuerst fügen wir ein neues Textfeldobjekt (**Zu 1**) zur Folie hinzu (zum Zwecke der Verbindung) und erstellen einen neuen (grünen) Connector, der es mit den bereits erstellten Objekten verbindet.

```php
  # Erstellt ein neues Bindungsobjekt
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("Zu 1");
  # Erstellt einen neuen Connector
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # Verbindet Objekte mit dem neu erstellten Connector
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # Holt sich die Anpassungspunkte des Connectors
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # Ändert die Werte der Anpassungspunkte
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);

```

Das Ergebnis:

![connector-adjusted-3](connector-adjusted-3.png)

Zweitens erstellen wir eine Form, die dem horizontalen Bestandteil des Connectors entspricht, der durch den neuen Anpassungspunkt des Connectors connector.getAdjustments().get_Item(0) verläuft. Wir verwenden die Werte aus den Connector-Daten für connector.getRotation(), connector.getFrame().getFlipH() und connector.getFrame().getFlipV() und wenden die populäre Koordinatenumrechnungsformel für die Drehung um einen bestimmten Punkt x0 an:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Drehwinkel des Objekts 90 Grad und der Connector wird vertikal angezeigt, sodass dieser entsprechende Code verwendet wird:

```php
  # Speichert die Koordinaten des Connectors
  $x = $connector->getX();
  $y = $connector->getY();
  # Korrigiert die Koordinaten des Connectors für den Fall, dass sie auftreten
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # Nimmt den Wert des Anpassungspunktes als Koordinate
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # Konvertiert die Koordinaten, da Sin(90) = 1 und Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # Bestimmt die Breite des horizontalen Bestandteils unter Verwendung des Wertes des zweiten Anpassungspunkts
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

```

Das Ergebnis:

![connector-adjusted-4](connector-adjusted-4.png)

Wir haben Berechnungen, die einfache Anpassungen und komplizierte Anpassungspunkte (Anpassungspunkte mit Drehwinkeln) betreffen, demonstriert. Mit dem erworbenen Wissen können Sie Ihr eigenes Modell entwickeln (oder einen Code schreiben), um ein `GraphicsPath`-Objekt zu erhalten oder sogar die Werte der Anpassungspunkte eines Connectors basierend auf bestimmten Folienkoordinaten festzulegen.

## **Winkel der Connectorlinien finden**

1. Erstellen Sie eine Instanz der Klasse.
1. Holen Sie sich eine Referenz auf die Folie über ihren Index.
1. Greifen Sie auf die Connectorlinienform zu.
1. Verwenden Sie die Linienbreite, Höhe, Formrahmenhöhe und Formrahmenbreite, um den Winkel zu berechnen.

Dieser PHP-Code demonstriert eine Operation, bei der wir den Winkel für eine Connectorlinienform berechnet haben:

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