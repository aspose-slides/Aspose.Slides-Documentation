---
title: Foliengröße in Präsentationen mit PHP ändern
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
- besondere Foliengröße
- einzigartige Foliengröße
- Vollformatfolie
- Bildschirmtyp
- nicht skalieren
- Passend anpassen
- maximieren
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit PHP und Aspose.Slides schnell skalieren und Präsentationen für jeden Bildschirm optimieren, ohne Qualitätsverlust."
---
## **Einführung**

Aspose.Slides bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, die sowohl für den Druck als auch für die Anzeige auf dem Bildschirm entscheidend sind.

Beliebte Foliengrößen und Seitenverhältnisse:

- **Standard (4:3 Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (16:9 Seitenverhältnis)**: Empfohlen für moderne Projektoren und Bildschirme.

Stellen Sie die Konsistenz in Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse legen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation fest, um Komplikationen zu vermeiden.

{{% alert color="primary" %}} 
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Standard‑Seitenverhältnis 4:3.
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

## **Benutzerdefinierte Foliengrößen in Präsentationen festlegen**

Wenn die üblichen Foliengrößen (4:3 und 16:9) für Ihre Arbeit ungeeignet sind, können Sie eine spezifische oder einzigartige Foliengröße verwenden. Beispielsweise profitieren Sie von einer benutzerdefinierten Größe, wenn Sie Vollformat‑Folien Ihrer Präsentation auf einem individuellen Seitenlayout drucken oder Ihre Präsentation auf bestimmten Bildschirmtypen anzeigen möchten.

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

Je nach dem, was Sie erreichen möchten, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie zu einer kleineren Foliengröße skalieren und Aspose.Slides die Folienobjekte verkleinern soll, damit alle auf die Folien passen (so vermeiden Sie den Verlust von Inhalten), verwenden Sie diese Einstellung.

- `Maximize`

  Wenn Sie zu einer größeren Foliengröße skalieren und Aspose.Slides die Folienobjekte vergrößern soll, damit sie proportional zur neuen Foliengröße sind, verwenden Sie diese Einstellung.

Dieser Beispielcode zeigt, wie Sie die Einstellung `Maximize` verwenden, wenn Sie die Größe einer Folie einer Präsentation ändern:

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

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (zum Beispiel Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Festlegung von Folienbreite und -höhe verwenden.

**Wirkt sich eine sehr große benutzerdefinierte Foliengröße auf die Leistung und den Speicherverbrauch beim Rendern aus?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einem höheren Render‑Skalenfaktor führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Ziel ist eine praktikable Foliengröße, und der Render‑Skalenfaktor sollte nur bei Bedarf angepasst werden, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht‑standardmäßige Foliengröße definieren und anschließend Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?**

Sie können nicht [merge presentations](/slides/de/php-java/merge-presentation/) durchführen, solange die Präsentationen unterschiedliche Foliengrößen haben – passen Sie zunächst eine Präsentation an die andere an. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach der Angleichung der Größen können Sie Folien zusammenführen und dabei die Formatierung beibehalten.

**Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen sie die neue Foliengröße?**

Ja. Aspose.Slides kann Miniaturansichten für [entire slides](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#getImage) sowie für [selected shapes](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#getImage) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider und sorgen für konsistente Bildausschnitte und Geometrie.