---
title: Linie
type: docs
weight: 50
url: /de/php-java/Linie/
---


{{% alert color="primary" %}} 

Aspose.Slides für PHP über Java unterstützt das Hinzufügen verschiedener Arten von Formen zu den Folien. In diesem Thema werden wir mit Formen beginnen, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides für PHP über Java können Entwickler nicht nur einfache Linien erstellen, sondern auch einige fancy Linien auf den Folien zeichnen.

{{% /alert %}} 

## **Einfache Linie erstellen**

Um eine einfache, gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine AutoShape vom Typ Linie mit der [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) Methode des [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) Objekts hinzu.
- Schreiben Sie die bearbeitete Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

```php
  # Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Linie hinzu
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Schreiben Sie die PPTX auf die Festplatte
    $pres->save("Linienform.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Pfeilförmige Linie erstellen**

Aspose.Slides für PHP über Java ermöglicht es Entwicklern auch, einige Eigenschaften der Linie zu konfigurieren, um sie ansprechender zu gestalten. Lassen Sie uns versuchen, einige Eigenschaften einer Linie zu konfigurieren, um sie wie einen Pfeil aussehen zu lassen. Bitte folgen Sie den folgenden Schritten, um dies zu tun:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine AutoShape vom Typ Linie mit der [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) Methode des [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) Objekts hinzu.
- Setzen Sie den [Linienstil](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) auf einen der von Aspose.Slides für PHP über Java angebotenen Stile.
- Setzen Sie die Breite der Linie.
- Setzen Sie den [Strichstil](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) der Linie auf einen der von Aspose.Slides für PHP über Java angebotenen Stile.
- Setzen Sie den [Pfeilkopf-Stil](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) und die [Länge](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) des Startpunkts der Linie.
- Setzen Sie den [Pfeilkopf-Stil](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) und die [Länge](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) des Endpunkts der Linie.
- Schreiben Sie die bearbeitete Präsentation als PPTX-Datei.

```php
  # Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Linie hinzu
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Wenden Sie einige Formatierungen auf die Linie an
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Schreiben Sie die PPTX auf die Festplatte
    $pres->save("Linienform.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```