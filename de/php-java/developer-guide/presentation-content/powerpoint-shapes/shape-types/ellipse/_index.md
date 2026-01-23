---
title: Ellipsen zu Präsentationen in PHP hinzufügen
linktitle: Ellipse
type: docs
weight: 30
url: /de/php-java/ellipse/
keywords:
- Ellipse
- Form
- Ellipse hinzufügen
- Ellipse erstellen
- Ellipse zeichnen
- formatierte Ellipse
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Ellipsenformen in Aspose.Slides für PHP via Java in PPT‑ und PPTX‑Präsentationen erstellen, formatieren und manipulieren — Codebeispiele inklusive."
---

{{% alert color="primary" %}} 

In diesem Thema stellen wir Entwicklern das Hinzufügen von Ellipsenformen zu ihren Folien mit Aspose.Slides für PHP via Java vor. Aspose.Slides für PHP via Java bietet einen einfacheren Satz von APIs, um verschiedene Arten von Formen mit nur wenigen Codezeilen zu zeichnen.

{{% /alert %}} 

## **Ellipse erstellen**
Um einer ausgewählten Folie der Präsentation eine einfache Ellipse hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) ein AutoShape vom Typ Ellipse hinzu, das vom Objekt [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) bereitgestellt wird.
- Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Ellipse zur ersten Folie hinzugefügt
```php
  # Instanziieren Sie die Presentation-Klasse, die die PPTX repräsentiert
  $pres = new Presentation();
  try {
    # Erste Folie abrufen
    $sld = $pres->getSlides()->get_Item(0);
    # AutoShape vom Typ Ellipse hinzufügen
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # PPTX-Datei auf die Festplatte schreiben
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Formatiertes Ellipse erstellen**
Um einer Folie eine besser formatierte Ellipse hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) ein AutoShape vom Typ Ellipse hinzu, das vom Objekt [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) bereitgestellt wird.
- Setzen Sie den Fülltyp der Ellipse auf Solid.
- Setzen Sie die Farbe der Ellipse mithilfe der Methode `SolidFillColor::setColor`, die vom Objekt [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) bereitgestellt wird und dem Objekt [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) zugeordnet ist.
- Setzen Sie die Farbe der Linien der Ellipse.
- Setzen Sie die Breite der Linien der Ellipse.
- Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir ein formatiertes Ellipse zur ersten Folie der Präsentation hinzugefügt.
```php
  # Instanziieren Sie die Presentation‑Klasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Erste Folie abrufen
    $sld = $pres->getSlides()->get_Item(0);
    # AutoShape vom Typ Ellipse hinzufügen
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Formatierungen auf die Ellipsenform anwenden
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Formatierungen auf die Linie der Ellipse anwenden
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # PPTX‑Datei auf die Festplatte schreiben
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wie lege ich die genaue Position und Größe einer Ellipse relativ zu den Einheiten der Folie fest?**

Koordinaten und Größen werden typischerweise **in Punkten** angegeben. Für vorhersehbare Ergebnisse sollten Sie Ihre Berechnungen auf die Foliengröße stützen und erforderliche Millimeter oder Zoll vor der Zuweisung in Punkte umrechnen.

**Wie kann ich eine Ellipse über oder unter anderen Objekten platzieren (Stapelhierarchie steuern)?**

Passen Sie die Zeichenreihenfolge des Objekts an, indem Sie es in den Vordergrund holen oder nach hinten schicken. Dadurch kann die Ellipse andere Objekte überlagern oder die darunter liegenden sichtbar machen.

**Wie animiere ich das Auftreten oder die Hervorhebung einer Ellipse?**

[Apply](/slides/de/php-java/shape-animation/) Eingangs-, Hervorhebungs- oder Ausgangseffekte auf die Form anwenden und Trigger sowie Timing konfigurieren, um zu steuern, wann und wie die Animation abgespielt wird.