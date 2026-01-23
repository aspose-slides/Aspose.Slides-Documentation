---
title: Rechtecke zu Präsentationen in PHP hinzufügen
linktitle: Rechteck
type: docs
weight: 80
url: /de/php-java/rectangle/
keywords:
- Rechteck hinzufügen
- Rechteck erstellen
- Rechtecksform
- einfaches Rechteck
- formatiertes Rechteck
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Steigern Sie Ihre PowerPoint-Präsentationen, indem Sie mit Aspose.Slides für PHP über Java Rechtecke hinzufügen – gestalten und ändern Sie Formen ganz einfach programmgesteuert."
---

{{% alert color="primary" %}} 

Wie bei vorherigen Themen geht es in diesem Beitrag ebenfalls um das Hinzufügen einer Form, und diesmal werden wir die **Rectangle**‑Form besprechen. In diesem Kapitel haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien hinzufügen können, indem sie Aspose.Slides für PHP über Java verwenden.

{{% /alert %}} 

## **Ein Rechteck zu einer Folie hinzufügen**
Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Rufen Sie die Referenz einer Folie über deren Index ab.
- Fügen Sie über die vom Objekt [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) bereitgestellte Methode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vom Typ Rectangle hinzu.
- Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.
```php
  # Instanziieren der Presentation-Klasse, die die PPTX repräsentiert
  $pres = new Presentation();
  try {
    # Erste Folie abrufen
    $sld = $pres->getSlides()->get_Item(0);
    # AutoShape vom Typ Rechteck hinzufügen
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # PPTX-Datei auf Festplatte schreiben
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ein formatiertes Rechteck zu einer Folie hinzufügen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Rufen Sie die Referenz einer Folie über deren Index ab.
- Fügen Sie über die vom Objekt [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) bereitgestellte Methode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vom Typ Rectangle hinzu.
- Setzen Sie den [Fill Type](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) des Rechtecks auf Solid.
- Setzen Sie die Farbe des Rechtecks mithilfe der Methode [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor), die vom Objekt [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) bereitgestellt wird und dem [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)‑Objekt zugeordnet ist.
- Legen Sie die Farbe der Linien des Rechtecks fest.
- Legen Sie die Breite der Linien des Rechtecks fest.
- Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Die obigen Schritte sind im nachstehenden Beispiel implementiert.
```php
  # Instanziiere die Presentation-Klasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Hole die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Füge eine AutoShape vom Typ Ellipse hinzu
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Wende einige Formatierungen auf die Ellipse-Form an
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Wende einige Formatierungen auf die Linie der Ellipse an
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Schreibe die PPTX-Datei auf die Festplatte
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wie füge ich ein Rechteck mit abgerundeten Ecken hinzu?**

Verwenden Sie den [shape type](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) für abgerundete Ecken und passen Sie den Eckradius in den Eigenschaften der Form an; das Abrunden kann auch für jede Ecke einzeln über Geometrie‑Anpassungen angewendet werden.

**Wie fülle ich ein Rechteck mit einem Bild (Textur)?**

Wählen Sie den Bild‑[fill type](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), geben Sie die Bildquelle an und konfigurieren Sie die [stretching/tiling modes](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/).

**Kann ein Rechteck Schatten und Leuchteffekte haben?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/de/php-java/shape-effect/) sind mit einstellbaren Parametern verfügbar.

**Kann ich ein Rechteck in einen Button mit Hyperlink verwandeln?**

Ja. [Assign a hyperlink](/slides/de/php-java/manage-hyperlinks/) zur Form‑Klick‑Aktion (Springen zu einer Folie, Datei, Webadresse oder E‑Mail).

**Wie kann ich ein Rechteck vor Verschieben und Änderungen schützen?**

Verwenden Sie Form‑Sperren: Sie können das Verschieben, Skalieren, Auswählen oder Bearbeiten von Text verbieten, um das Layout zu bewahren.

**Kann ich ein Rechteck in ein Raster‑Bild oder SVG konvertieren?**

Ja. Sie können die Form [render the shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) zu einem Bild mit bestimmter Größe/Skala rendern oder sie [export it as SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) für die Vektor‑Verwendung exportieren.

**Wie erhalte ich schnell die tatsächlichen (effektiven) Eigenschaften eines Rechtecks unter Berücksichtigung von Design und Vererbung?**

[Use the shape’s effective properties](/slides/de/php-java/shape-effective-properties/): Die API gibt berechnete Werte zurück, die Design‑Stile, Layout und lokale Einstellungen berücksichtigen und die Analyse der Formatierung vereinfachen.