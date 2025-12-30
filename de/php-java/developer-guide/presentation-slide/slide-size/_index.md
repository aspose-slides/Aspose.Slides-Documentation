---
title: Foliengröße in der Präsentation mit PHP ändern
linktitle: Foliengröße
type: docs
weight: 70
url: /de/php-java/slide-size/
keywords:
- Foliengröße
- Seitenverhältnis
- Standard
- Breitbild
- 4:3
- 16:9
- Foliengröße festlegen
- Foliengröße ändern
- benutzerdefinierte Foliengröße
- spezielle Foliengröße
- einzigartige Foliengröße
- Folie in voller Größe
- Bildschirmtyp
- nicht skalieren
- Passend anpassen
- maximieren
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
descriptions: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit PHP und Aspose.Slides schnell skalieren, Präsentationen für jeden Bildschirm optimieren, ohne Qualitätsverlust."
---

## **Foliengrößen in PowerPoint-Präsentationen**

Aspose.Slides für PHP via Java ermöglicht das Ändern der Foliengröße oder des Seitenverhältnisses in PowerPoint-Präsentationen. Wenn Sie Ihre Präsentation drucken oder die Folien auf einem Bildschirm anzeigen möchten, müssen Sie auf die Foliengröße bzw. das Seitenverhältnis achten.

Dies sind die gängigsten Foliengrößen und Seitenverhältnisse:

- **Standard (4:3 Seitenverhältnis)**

  Wenn Ihre Präsentation auf relativ älteren Geräten oder Bildschirmen angezeigt oder betrachtet wird, möchten Sie vielleicht diese Einstellung verwenden. 

- **Breitbild (16:9 Seitenverhältnis)** 

  Wenn Ihre Präsentation auf modernen Projektoren oder Bildschirmen angezeigt wird, möchten Sie vielleicht diese Einstellung verwenden. 

Sie können nicht mehrere Foliengrößeneinstellungen in einer einzelnen Präsentation verwenden. Wenn Sie eine Foliengröße für eine Präsentation auswählen, wird diese Einstellung auf alle Folien der Präsentation angewendet. 

Wenn Sie für Ihre Präsentationen eine spezielle Foliengröße verwenden möchten, empfehlen wir dringend, dies frühzeitig zu tun. Idealerweise sollten Sie Ihre bevorzugte Folie zu Beginn festlegen, d. h. bereits beim Erstellen der Präsentation – bevor Sie Inhalte hinzufügen. Auf diese Weise vermeiden Sie Komplikationen, die durch (zukünftige) Änderungen der Foliengröße entstehen. 

{{% alert color="primary" %}} 

 Wenn Sie Aspose.Slides verwenden, um eine Präsentation zu erstellen, erhalten alle Folien in der Präsentation automatisch die Standardgröße bzw. das 4:3‑Seitenverhältnis.

{{% /alert %}} 

## **Foliengröße in Präsentationen ändern**

 Dieser Beispielcode zeigt, wie Sie die Foliengröße in einer Präsentation mit Aspose.Slides ändern:
```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Benutzerdefinierte Foliengrößen in Präsentationen angeben**

 Wenn die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht geeignet sind, können Sie eine spezifische oder einzigartige Foliengröße verwenden. Beispielsweise, wenn Sie beabsichtigen, Folien Ihrer Präsentation in voller Größe auf einem benutzerdefinierten Seitenlayout zu drucken oder die Präsentation auf bestimmten Bildschirmtypen anzuzeigen, profitieren Sie wahrscheinlich von einer benutzerdefinierten Größeneinstellung für Ihre Präsentation. 

 Dieser Beispielcode zeigt, wie Sie Aspose.Slides für PHP via Java verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation festzulegen:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// A4-Papiergröße

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Folieninhalt nach Größenänderung verarbeiten**

 Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (z. B. Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch an die neue Foliengröße angepasst. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

 Je nach dem, was Sie tun oder erreichen möchten, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie auf eine kleinere Foliengröße skalieren und Aspose.Slides die Folienobjekte verkleinern soll, damit sie alle auf die Folien passen (so vermeiden Sie Inhaltsverlust), verwenden Sie diese Einstellung. 

- `Maximize`

  Wenn Sie auf eine größere Foliengröße skalieren und Aspose.Slides die Folienobjekte vergrößern soll, damit sie proportional zur neuen Foliengröße werden, verwenden Sie diese Einstellung. 

 Dieser Beispielcode zeigt, wie Sie die Einstellung `Maximize` beim Ändern der Foliengröße einer Präsentation verwenden:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können beliebige Einheiten (wie Millimeter oder Zentimeter) in Punkte umrechnen und die konvertierten Werte zur Definition von Folienbreite und -höhe verwenden.

**Beeinflusst eine sehr große benutzerdefinierte Foliengröße die Leistung und den Speicherverbrauch beim Rendern?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einer höheren Render‑Skala führen zu höherem Speicherverbrauch und längeren Verarbeitungszeiten. Streben Sie eine praktische Foliengröße an und passen Sie die Render‑Skala nur bei Bedarf an, um die gewünschte Ausgabqualität zu erreichen.

**Kann ich eine nicht‑standardmäßige Foliengröße festlegen und dann Folien aus Präsentationen zusammenführen, die unterschiedliche Größen haben?**

Sie können nicht [Präsentationen zusammenführen](/slides/de/php-java/merge-presentation/), solange sie unterschiedliche Foliengrößen haben — resize zunächst eine Präsentation, damit sie der anderen entspricht. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach dem Angleichen der Größen können Sie Folien zusammenführen und dabei die Formatierung beibehalten.

**Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen sie die neue Foliengröße?**

Ja. Aspose.Slides kann Miniaturansichten für [gesamte Folien](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) rendern. Die erzeugten Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider und gewährleisten eine konsistente Bildrahmung und Geometrie.