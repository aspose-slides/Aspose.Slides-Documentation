---
title: Linienformen zu Präsentationen in PHP hinzufügen
linktitle: Linie
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
- Pfeilkopf
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie die Linienformatierung in PowerPoint-Präsentationen mit Aspose.Slides für PHP via Java manipulieren können. Entdecken Sie Eigenschaften, Methoden und Beispiele."
---

{{% alert color="primary" %}} 

Aspose.Slides für PHP via Java unterstützt das Hinzufügen verschiedener Arten von Formen zu den Folien. In diesem Thema beginnen wir mit Formen, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides für PHP via Java können Entwickler nicht nur einfache Linien erstellen, sondern auch einige ausgefallene Linien auf den Folien zeichnen.

{{% /alert %}} 

## **Eine einfache Linie erstellen**

Um einer ausgewählten Folie der Präsentation eine einfache Linie hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Rufen Sie die Referenz einer Folie unter Verwendung ihres Indexes ab.
- Fügen Sie eine AutoShape des Typs Linie mithilfe der Methode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) bereitgestellt wird.
- Schreiben Sie die geänderte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.
```php
  # Instanziieren Sie die PresentationEx-Klasse, die die PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Holen Sie die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Linie hinzu
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Speichern Sie die PPTX-Datei auf dem Datenträger
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Pfeilförmige Linie erstellen**

Aspose.Slides für PHP via Java ermöglicht es Entwicklern außerdem, einige Eigenschaften der Linie zu konfigurieren, um sie ansprechender zu gestalten. Lassen Sie uns ein paar Eigenschaften einer Linie konfigurieren, damit sie wie ein Pfeil aussieht. Befolgen Sie dazu die untenstehenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Rufen Sie die Referenz einer Folie unter Verwendung ihres Indexes ab.
- Fügen Sie eine AutoShape des Typs Linie mithilfe der Methode [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) hinzu, die vom Objekt [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) bereitgestellt wird.
- Setzen Sie den [Line Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) auf einen der von Aspose.Slides für PHP via Java angebotenen Stile.
- Legen Sie die Breite der Linie fest.
- Setzen Sie den [Dash Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) der Linie auf einen der von Aspose.Slides für PHP via Java angebotenen Stile.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) des Startpunkts der Linie.
- Setzen Sie den [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) und die [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) des Endpunkts der Linie.
- Schreiben Sie die geänderte Präsentation als PPTX-Datei.
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

**Kann ich eine reguläre Linie in einen Connector umwandeln, damit sie an Formen „snapt“?**

Nein. Eine reguläre Linie (ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vom Typ [Line](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/)) wird nicht automatisch zu einem Connector. Um sie an Formen anzupassen, verwenden Sie den dedizierten [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/)‑Typ und die [corresponding APIs](/slides/de/php-java/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie von dem Theme geerbt werden und es schwierig ist, die endgültigen Werte zu bestimmen?**

[Lesen Sie die effektiven Eigenschaften](/slides/de/php-java/shape-effective-properties/) über `LineFormatEffectiveData`/`LineFillFormatEffectiveData` – diese berücksichtigen bereits Vererbung und Theme‑Stile.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Größenänderung) sperren?**

Ja. Formen stellen [lock objects](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/getautoshapelock/) bereit, mit denen Sie [disallow editing operations](/slides/de/php-java/applying-protection-to-presentation/) unterbinden können.