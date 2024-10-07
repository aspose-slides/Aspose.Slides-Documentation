---
title: Ellipse
type: docs
weight: 30
url: /php-java/ellipse/
---


{{% alert color="primary" %}} 

In diesem Thema werden wir Entwicklern vorstellen, wie man Ellipsenformen zu ihren Folien mit Aspose.Slides für PHP über Java hinzufügt. Aspose.Slides für PHP über Java bietet eine einfachere API, um verschiedene Arten von Formen mit nur wenigen Codezeilen zu zeichnen.

{{% /alert %}} 

## **Ellipse erstellen**
Um eine einfache Ellipse zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie eine AutoShape vom Typ Ellipse mit der Methode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) Objekt bereitgestellt wird.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Ellipse zur ersten Folie hinzugefügt.

```php
  # Instanziieren Sie die Presentation-Klasse, die das PPTX repräsentiert
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie ein AutoShape vom Typ Ellipse hinzu
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Schreiben Sie die PPTX-Datei auf die Festplatte
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Formatierte Ellipse erstellen**
Um eine besser formatierte Ellipse zu einer Folie hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie ein AutoShape vom Typ Ellipse mit der Methode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) Objekt bereitgestellt wird.
- Setzen Sie den Fülltyp der Ellipse auf Solid.
- Setzen Sie die Farbe der Ellipse mit der SolidFillColor.Color-Eigenschaft, die vom [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) Objekt bereitgestellt wird, das mit dem [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) Objekt verknüpft ist.
- Setzen Sie die Farbe der Linien der Ellipse.
- Setzen Sie die Breite der Linien der Ellipse.
- Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine formatierte Ellipse zur ersten Folie der Präsentation hinzugefügt.

```php
  # Instanziieren Sie die Presentation-Klasse, die das PPTX repräsentiert
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie ein AutoShape vom Typ Ellipse hinzu
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Wenden Sie einige Formatierungen auf die Ellipsenform an
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Wenden Sie einige Formatierungen auf die Linie der Ellipse an
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Schreiben Sie die PPTX-Datei auf die Festplatte
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```