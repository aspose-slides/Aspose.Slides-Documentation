---
title: Linienformen zu Präsentationen in PHP hinzufügen
linktitle: Linie
type: docs
weight: 50
url: /de/php-java/line/
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
description: "Erfahren Sie, wie Sie die Linienformatierung in PowerPoint-Präsentationen mit Aspose.Slides für PHP via Java manipulieren. Entdecken Sie Eigenschaften, Methoden und Beispiele."
---
## **Übersicht**

Aspose.Slides ermöglicht das programmgesteuerte Hinzufügen von Linienformen zu PowerPoint‑Folien. Dieser Artikel zeigt, wie man eine einfache Linie erstellt und wie man eine Linie anpasst, sodass sie wie ein Pfeil aussieht.

Sie lernen, wie man einer Folie eine Linienform hinzufügt, ihr Erscheinungsbild anpasst und die aktualisierte Präsentation speichert. Die Beispiele konzentrieren sich auf praktische Linienformatierungseinstellungen wie Stil, Breite, Strichmuster, Pfeilspitzenoptionen und Füllfarbe.

## **Eine einfache Linie erstellen**

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation).
- Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/#addAutoShape) des Objekts [ShapeCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/) eine AutoShape vom Typ Linie hinzu.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

```php
  # Instanziiere die PresentationEx-Klasse, die die PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Hole die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Füge eine AutoShape vom Typ Linie hinzu
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Schreibe die PPTX-Datei auf die Festplatte
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Eine pfeilförmige Linie erstellen**

Aspose.Slides für PHP via Java ermöglicht es Entwicklern ebenfalls, einige Eigenschaften der Linie zu konfigurieren, damit sie ansprechender wirkt. Versuchen wir, einige Eigenschaften einer Linie so einzustellen, dass sie wie ein Pfeil aussieht. Bitte folgen Sie den nachstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation).
- Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie mit der Methode [addAutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/#addAutoShape) des Objekts [ShapeCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/) eine AutoShape vom Typ Linie hinzu.
- Setzen Sie den [Line Style](https://reference.aspose.com/slides/de/php-java/aspose.slides/LineStyle) auf einen der von Aspose.Slides für PHP via Java angebotenen Stile.
- Legen Sie die Breite der Linie fest.
- Setzen Sie den [Dash Style](https://reference.aspose.com/slides/de/php-java/aspose.slides/LineDashStyle) der Linie auf einen der von Aspose.Slides für PHP via Java angebotenen Stile.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/de/php-java/aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/de/php-java/aspose.slides/LineArrowheadLength) des Startpunkts der Linie.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/de/php-java/aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/de/php-java/aspose.slides/LineArrowheadLength) des Endpunkts der Linie.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

```php
  # Instanziiere die PresentationEx-Klasse, die die PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # Hole die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Füge eine AutoShape vom Typ Linie hinzu
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Wende einige Formatierungen auf die Linie an
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Schreibe die PPTX-Datei auf die Festplatte
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kann ich eine normale Linie in einen Connector umwandeln, sodass sie an Formen „einrastet“?**

Nein. Eine normale Linie (ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapetype/)) wird nicht automatisch zu einem Connector. Um sie an Formen einrasten zu lassen, verwenden Sie den speziellen [Connector](https://reference.aspose.com/slides/de/php-java/aspose.slides/connector/)-Typ und die [corresponding APIs](/slides/de/php-java/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Theme geerbt werden und es schwierig ist, die endgültigen Werte zu bestimmen?**

[Lesen Sie die effektiven Eigenschaften](/slides/de/php-java/shape-effective-properties/) über `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — diese berücksichtigen bereits Vererbung und Theme‑Stile.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Größenänderung) sperren?**

Ja. Formen bieten [lock objects](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/getautoshapelock/), mit denen Sie Bearbeitungsvorgänge verbieten können.