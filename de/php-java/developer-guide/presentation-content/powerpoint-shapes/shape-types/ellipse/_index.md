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
- Formatierte Ellipse
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Ellipsenformen in Aspose.Slides für PHP via Java in PPT- und PPTX‑Präsentationen erstellen, formatieren und manipulieren – Codebeispiele inklusive."
---

{{% alert color="primary" %}} 

In diesem Beitrag stellen wir Entwicklern das Hinzufügen von Ellipsenformen zu ihren Folien mit Aspose.Slides für PHP via Java vor. Aspose.Slides für PHP via Java bietet einen einfacheren Satz von APIs, um verschiedene Formen mit nur wenigen Codezeilen zu zeichnen.

{{% /alert %}} 

## **Eine Ellipse erstellen**
Um einer ausgewählten Folie der Präsentation eine einfache Ellipse hinzuzufügen, gehen Sie bitte wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Rufen Sie die Referenz einer Folie anhand ihres Index ab.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ein AutoShape vom Typ Ellipse hinzu, das vom Objekt [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) bereitgestellt wird.
- Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir der ersten Folie eine Ellipse hinzugefügt
```php
  # Instanziiere die Presentation-Klasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Hole die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Füge ein AutoShape vom Typ Ellipse hinzu
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Schreibe die PPTX-Datei auf die Festplatte
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eine formatierte Ellipse erstellen**
Um einer Folie eine besser formatierte Ellipse hinzuzufügen, gehen Sie bitte wie folgt vor:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Rufen Sie die Referenz einer Folie anhand ihres Index ab.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ein AutoShape vom Typ Ellipse hinzu, das vom Objekt [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) bereitgestellt wird.
- Setzen Sie den Fülltyp der Ellipse auf Solid.
- Setzen Sie die Farbe der Ellipse über die Eigenschaft SolidFillColor.Color, die vom Objekt [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) bereitgestellt wird, das dem Objekt [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) zugeordnet ist.
- Setzen Sie die Farbe der Linien der Ellipse.
- Setzen Sie die Breite der Linien der Ellipse.
- Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Im nachfolgenden Beispiel haben wir der ersten Folie der Präsentation eine formatierte Ellipse hinzugefügt.
```php
  # Instanziiere die Presentation-Klasse, die die PPTX darstellt
  $pres = new Presentation();
  try {
    # Hole die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Füge ein AutoShape vom Typ Ellipse hinzu
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Wende einige Formatierungen auf die Ellipsenform an
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Wende einige Formatierungen auf die Linie der Ellipse an
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Schreibe die PPTX-Datei auf die Festplatte
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wie lege ich die exakte Position und Größe einer Ellipse in Bezug auf die Einheiten der Folie fest?**

Koordinaten und Größen werden in der Regel **in Punkten** angegeben. Für vorhersehbare Ergebnisse sollten Sie Ihre Berechnungen auf der Foliengröße basieren und die erforderlichen Millimeter oder Zoll vor der Zuweisung in Punkte umrechnen.

**Wie kann ich eine Ellipse über oder unter anderen Objekten platzieren (Stapelnungsreihenfolge steuern)?**

Passen Sie die Zeichnungsreihenfolge des Objekts an, indem Sie es in den Vordergrund holen oder in den Hintergrund senden. So kann die Ellipse andere Objekte überlappen oder diejenigen darunter sichtbar machen.

**Wie animiere ich das Auftreten oder die Betonung einer Ellipse?**

[Anwenden](/slides/de/php-java/shape-animation/) von Eingangs‑, Betonungs‑ oder Ausgangseffekten auf die Form und konfigurieren Sie Trigger und Timing, um zu steuern, wann und wie die Animation abgespielt wird.