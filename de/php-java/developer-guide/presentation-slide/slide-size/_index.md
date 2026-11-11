---
title: Ändern der Foliengröße einer Präsentation in PHP
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
- Benutzerdefinierte Foliengröße
- Spezielle Foliengröße
- Einzigartige Foliengröße
- Vollformatfolie
- Bildschirmtyp
- Nicht skalieren
- Einpassen sicherstellen
- Maximieren
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit PHP und Aspose.Slides schnell skalieren, Präsentationen für jeden Bildschirm optimieren, ohne Qualitätsverlust."
---
## **Einleitung**

Aspose.Slides stellt umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen bereit, die sowohl für den Druck als auch für die Bildschirmanzeige entscheidend sind. 

Beliebte Foliengrößen und Verhältnisse:

- **Standard (4:3 Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (16:9 Seitenverhältnis)**: Empfohlen für moderne Projektoren und Anzeigen.

Stellen Sie die Konsistenz Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse legen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation fest, um Komplikationen zu vermeiden.

{{% alert color="info" title="Note" %}}
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

Notiz- und Handzettelseiten haben andere Abmessungen als reguläre Folien. Siehe [Notizseitengröße](/slides/de/php-java/notes-size/) zum Ändern ihrer Größe und Ausrichtung.

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

Wenn die üblichen Foliengrößen (4:3 und 16:9) für Ihre Arbeit ungeeignet sind, können Sie eine bestimmte oder eindeutige Foliengröße verwenden. Zum Beispiel, wenn Sie beabsichtigen, Vollformat‑Folien aus Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout zu drucken oder wenn Sie Ihre Präsentation auf bestimmten Bildschirmtypen anzeigen möchten, profitieren Sie wahrscheinlich von einer benutzerdefinierten Größeneinstellung für Ihre Präsentation. 

Dieser Beispielcode zeigt, wie Sie Aspose.Slides für PHP über Java verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation festzulegen:

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

## **Umgang mit Folieninhalten nach der Größenänderung**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Folieninhalte (Bilder oder Objekte usw.) verzerrt werden. Standardmäßig werden die Objekte automatisch auf die neue Foliengröße skaliert. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nach dem, was Sie beabsichtigen, können Sie eine der folgenden Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie auf eine kleinere Foliengröße skalieren möchten und Aspose.Slides die Folienobjekte verkleinern soll, damit sie alle auf die Folien passen (damit Sie keine Inhalte verlieren), verwenden Sie diese Einstellung. 

- `Maximize`

  Wenn Sie auf eine größere Foliengröße skalieren möchten und Aspose.Slides die Folienobjekte vergrößern soll, um sie proportional zur neuen Foliengröße zu machen, verwenden Sie diese Einstellung. 

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

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (zum Beispiel Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Definition von Folienbreite und -höhe verwenden.

**Beeinflusst eine sehr große benutzerdefinierte Foliengröße die Leistung und den Speicherverbrauch beim Rendern?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit höherer Render‑Skalierung führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Ziel sollte eine praktikable Foliengröße sein und die Render‑Skalierung nur nach Bedarf anpassen, um die gewünschte Ausgabqualität zu erreichen.

**Kann ich eine nicht‑standardmäßige Foliengröße definieren und dann Folien aus Präsentationen zusammenführen, die unterschiedliche Größen haben?**

Sie können keine [Präsentationen zusammenführen](/slides/de/php-java/merge-presentation/), solange sie unterschiedliche Foliengrößen haben – zuerst die eine Präsentation auf die Größe der anderen anpassen. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/php-java/aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach dem Angleichen der Größen können Sie Folien zusammenführen und das Format beibehalten.

**Kann ich Thumbnails für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen sie die neue Foliengröße?**

Ja. Aspose.Slides kann Thumbnails für [gesamte Folien](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#getImage) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#getImage) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider und gewährleisten ein konsistentes Bildausschnitt und Geometrie.