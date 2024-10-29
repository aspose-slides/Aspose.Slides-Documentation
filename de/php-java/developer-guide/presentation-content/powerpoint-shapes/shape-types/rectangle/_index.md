---
title: Rechteck
type: docs
weight: 80
url: /de/php-java/rectangle/
---

{{% alert color="primary" %}} 

Wie bei den vorherigen Themen geht es auch diesmal darum, eine Form hinzuzufügen, und das Thema, über das wir sprechen werden, ist **Rechteck**. In diesem Thema haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien mit Aspose.Slides für PHP über Java hinzufügen können.

{{% /alert %}} 

## **Rechteck zur Folie hinzufügen**
Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) vom Typ Rechteck mithilfe der [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) Methode des [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) Objekts hinzu.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.

```php
  # Instanziieren Sie die Presentation-Klasse, die das PPTX repräsentiert
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Ellipse hinzu
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Schreiben Sie die PPTX-Datei auf die Festplatte
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Formatiertes Rechteck zur Folie hinzufügen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, folgen Sie bitte den folgenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) vom Typ Rechteck mithilfe der [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) Methode des [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) Objekts hinzu.
- Setzen Sie den [Fill Type](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) des Rechtecks auf Solid.
- Setzen Sie die Farbe des Rechtecks mithilfe der [SolidFillColor.setColor](https://reference.aspose.com/slides/php-java/aspose.slides/IColorFormat#setColor-java.awt.Color-) Methode, wie sie vom [IFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) Objekt bereitgestellt wird, das mit dem [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) Objekt verbunden ist.
- Setzen Sie die Farbe der Linien des Rechtecks.
- Setzen Sie die Breite der Linien des Rechtecks.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Die obigen Schritte werden im folgenden Beispiel umgesetzt.

```php
  # Instanziieren Sie die Presentation-Klasse, die das PPTX repräsentiert
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Ellipse hinzu
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Wenden Sie einige Formatierungen auf die Ellipsenform an
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Wenden Sie einige Formatierungen auf die Linie der Ellipse an
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Schreiben Sie die PPTX-Datei auf die Festplatte
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```