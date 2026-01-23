---
title: "Linienformen zu Präsentationen in PHP hinzufügen"
linktitle: "Linie"
type: docs
weight: 50
url: /de/php-java/Line/
keywords:
- Linie
- Linie erstellen
- Linie hinzufügen
- einfache Linie
- Linie konfigurieren
- Linie anpassen
- Strichstil
- Pfeilspitze
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie die Linienformatierung in PowerPoint-Präsentationen mit Aspose.Slides für PHP via Java manipulieren können. Entdecken Sie Eigenschaften, Methoden und Beispiele."
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java unterstützt das Hinzufügen verschiedener Shape‑Arten zu den Folien. In diesem Thema beginnen wir mit Shapes, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides for PHP via Java können Entwickler nicht nur einfache Linien erstellen, sondern auch einige ausgefallene Linien auf den Folien zeichnen.

{{% /alert %}} 

## **Eine einfache Linie erstellen**

Um einer ausgewählten Folie der Präsentation eine einfache gerade Linie hinzuzufügen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
- Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape), die vom [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/)-Objekt bereitgestellt wird, eine AutoShape des Typs Line hinzu.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir der ersten Folie der Präsentation eine Linie hinzugefügt.
```php
  # Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Holen Sie die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Linie hinzu
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Schreiben Sie die PPTX auf die Festplatte
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eine pfeilförmige Linie erstellen**

Aspose.Slides for PHP via Java ermöglicht es Entwicklern außerdem, einige Eigenschaften der Linie zu konfigurieren, damit sie ansprechender wirkt. Lassen Sie uns einige Eigenschaften einer Linie konfigurieren, sodass sie wie ein Pfeil aussieht. Befolgen Sie dazu die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
- Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape), die vom [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/)-Objekt bereitgestellt wird, eine AutoShape des Typs Line hinzu.
- Setzen Sie den [Line Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) auf einen der von Aspose.Slides for PHP via Java angebotenen Stile.
- Setzen Sie die Breite der Linie.
- Setzen Sie den [Dash Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) der Linie auf einen der von Aspose.Slides for PHP via Java angebotenen Stile.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) des Startpunkts der Linie.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) des Endpunkts der Linie.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.
```php
  # Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Holen Sie die erste Folie
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
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich eine normale Linie in einen Verbinder umwandeln, damit sie „einrastet“?**

Nein. Eine normale Linie (eine [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/)) wird nicht automatisch zu einem Verbinder. Verwenden Sie den speziellen [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/)-Typ und die dazugehörigen APIs(/slides/de/php-java/connector/) für Verbindungen.

**Was tun, wenn die Eigenschaften einer Linie vom Theme geerbt werden und die endgültigen Werte schwer zu ermitteln sind?**

[Lesen Sie die effektiven Eigenschaften](/slides/de/php-java/shape-effective-properties/) über `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — diese berücksichtigen bereits Vererbung und Theme‑Stile.

**Kann ich eine Linie vor Bearbeitung (Verschieben, Größ ändern) sperren?**

Ja. Shapes bieten [Lock‑Objekte](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/getautoshapelock/), mit denen Sie Bearbeitungsvorgänge verhindern können.