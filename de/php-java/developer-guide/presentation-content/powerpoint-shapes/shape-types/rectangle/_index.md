---
title: Rechtecke zu Präsentationen in PHP hinzufügen
linktitle: Rechteck
type: docs
weight: 80
url: /de/php-java/rectangle/
keywords:
  - Rechteck hinzufügen
  - Rechteck erstellen
  - Rechteckform
  - einfaches Rechteck
  - formatiertes Rechteck
  - PowerPoint
  - Präsentation
  - PHP
  - Aspose.Slides
description: "Steigern Sie Ihre PowerPoint-Präsentationen, indem Sie Rechtecke mit Aspose.Slides für PHP via Java hinzufügen — gestalten und ändern Sie Formen problemlos programmgesteuert."
---

{{% alert color="primary" %}} 

Wie die vorherigen Themen, handelt dieses ebenfalls vom Hinzufügen einer Form und diesmal geht es um das **Rechteck**. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien mit Aspose.Slides für PHP via Java hinzufügen können.

{{% /alert %}} 

## **Ein Rechteck zu einer Folie hinzufügen**
Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den nachstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) vom Typ Rectangle mithilfe der Methode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) bereitgestellt wird.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.
```php
  # Instanziieren Sie die Presentation-Klasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Die erste Folie abrufen
    $sld = $pres->getSlides()->get_Item(0);
    # AutoShape vom Ellipsentyp hinzufügen
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Die PPTX-Datei auf die Festplatte schreiben
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ein formatiertes Rechteck zu einer Folie hinzufügen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, folgen Sie bitte den nachstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie ein [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) vom Typ Rectangle mithilfe der Methode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) bereitgestellt wird.
- Setzen Sie den [Fill Type](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) des Rechtecks auf Solid.
- Setzen Sie die Farbe des Rechtecks mit der Methode [SolidFillColor.setColor](https://reference.aspose.com/slides/php-java/aspose.slides/IColorFormat#setColor-java.awt.Color-) , die vom Objekt [IFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) bereitgestellt wird, das mit dem Objekt [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) verknüpft ist.
- Setzen Sie die Farbe der Linien des Rechtecks.
- Setzen Sie die Breite der Linien des Rechtecks.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die obigen Schritte sind im nachstehenden Beispiel implementiert.
```php
  # Instanziieren Sie die Presentation-Klasse, die die PPTX repräsentiert
  $pres = new Presentation();
  try {
    # Die erste Folie abrufen
    $sld = $pres->getSlides()->get_Item(0);
    # AutoShape vom Ellipsentyp hinzufügen
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Einige Formatierungen auf die Ellipsenform anwenden
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Einige Formatierungen auf die Linie der Ellipse anwenden
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Die PPTX-Datei auf die Festplatte schreiben
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wie füge ich ein Rechteck mit abgerundeten Ecken hinzu?**

Verwenden Sie den abgerundeten [shape type](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) und passen Sie den Eckradius in den Eigenschaften der Form an; die Abrundung kann auch für jede Ecke separat über Geometrieanpassungen angewendet werden.

**Wie fülle ich ein Rechteck mit einem Bild (Textur)?**

Wählen Sie den Bild-[fill type](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), geben Sie die Bildquelle an und konfigurieren Sie die [stretching/tiling modes](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/).

**Kann ein Rechteck Schatten und Leuchteffekt haben?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/de/php-java/shape-effect/) sind mit einstellbaren Parametern verfügbar.

**Kann ich ein Rechteck in einen Button mit Hyperlink umwandeln?**

Ja. [Assign a hyperlink](/slides/de/php-java/manage-hyperlinks/) zur Formklick (Springen zu einer Folie, Datei, Webadresse oder E‑Mail).

**Wie kann ich ein Rechteck vor Verschieben und Änderungen schützen?**

[Use shape locks](/slides/de/php-java/applying-protection-to-presentation/): Sie können das Verschieben, die Größenänderung, Auswahl oder Textbearbeitung verhindern, um das Layout zu bewahren.

**Kann ich ein Rechteck in ein Rasterbild oder SVG konvertieren?**

Ja. Sie können die Form [render the shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) zu einem Bild mit einer angegebenen Größe/Skala rendern oder sie [export it as SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) für die Vektornutzung exportieren.

**Wie erhalte ich schnell die tatsächlichen (effektiven) Eigenschaften eines Rechtecks unter Berücksichtigung von Theme und Vererbung?**

[Use the shape’s effective properties](/slides/de/php-java/shape-effective-properties/): Die API gibt berechnete Werte zurück, die Theme‑Stile, Layout und lokale Einstellungen berücksichtigen, was die Formatierungsanalyse vereinfacht.