---
title: Ändern der Foliengröße einer Präsentation in Java
linktitle: Foliengröße
type: docs
weight: 70
url: /de/java/slide-size/
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
- Vollgröße-Folie
- Bildschirmtyp
- Nicht skalieren
- Passend sicherstellen
- Maximieren
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit Java und Aspose.Slides schnell skalieren, um Präsentationen für jeden Bildschirm zu optimieren, ohne Qualitätsverlust."
---
## **Einleitung**

Aspose.Slides bietet umfassende Werkzeuge, um die Foliengröße und das Seitenverhältnis in PowerPoint‑Präsentationen anzupassen, was sowohl für den Druck als auch für die Anzeige auf dem Bildschirm entscheidend ist.

Beliebte Foliengrößen und Seitenverhältnisse:

- **Standard (4:3 Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (16:9 Seitenverhältnis)**: Empfohlen für moderne Projektoren und Anzeigen.

Stellen Sie sicher, dass während Ihrer gesamten Präsentation Konsistenz besteht, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse sollten Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation festlegen, um Komplikationen zu vermeiden.

{{% alert color="info" %}} 
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

## **Ändern der Foliengröße in Präsentationen**

Dieser Beispielcode zeigt, wie Sie die Foliengröße in einer Präsentation in Java mit Aspose.Slides ändern:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Angeben benutzerdefinierter Foliengrößen in Präsentationen**

Wenn die üblichen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht geeignet sind, können Sie eine bestimmte oder eindeutige Foliengröße wählen. Zum Beispiel, wenn Sie Voll‑Size‑Folien aus Ihrer Präsentation auf einem benutzerdefinierten Seitendesign drucken möchten oder wenn Sie die Präsentation auf bestimmten Bildschirmtypen anzeigen wollen, profitieren Sie wahrscheinlich von einer benutzerdefinierten Größeneinstellung.

Dieser Beispielcode zeigt, wie Sie mit Aspose.Slides für Java eine benutzerdefinierte Foliengröße für eine Präsentation in Java festlegen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-Papiergröße
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Umgang mit Folieninhalt nach Größenänderung**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (Bilder oder Objekte usw.) verzerrt werden. Standardmäßig werden die Objekte automatisch so skaliert, dass sie zur neuen Foliengröße passen. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nach dem, was Sie beabsichtigen, können Sie eine der folgenden Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie auf eine kleinere Foliengröße skalieren möchten und Aspose.Slides die Objekte der Folien verkleinern soll, damit sie alle auf die Folien passen (so vermeiden Sie Inhaltsverlust), verwenden Sie diese Einstellung.

- `Maximize`

  Wenn Sie auf eine größere Foliengröße skalieren möchten und Aspose.Slides die Objekte der Folien vergrößern soll, sodass sie proportional zur neuen Foliengröße sind, verwenden Sie diese Einstellung.

Dieser Beispielcode zeigt, wie Sie die Einstellung `Maximize` beim Ändern der Foliengröße einer Präsentation verwenden:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die konvertierten Werte zur Definition von Folienbreite und -höhe verwenden.

### Wird eine sehr große benutzerdefinierte Foliengröße die Leistung und den Speicherverbrauch beim Rendern beeinflussen?

Ja. Größere Folienabmessungen (in Punkten) kombiniert mit höherer Render‑Skala führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Ziel ist eine praktikable Foliengröße, und die Render‑Skala sollte nur bei Bedarf angepasst werden, um die gewünschte Ausgabequalität zu erreichen.

### Kann ich eine nicht‑standardmäßige Foliengröße definieren und dann Folien aus Präsentationen zusammenführen, die unterschiedliche Größen haben?

Sie können nicht [Präsentationen zusammenführen](/slides/de/java/merge-presentation/), während sie unterschiedliche Foliengrößen haben – zuerst müssen Sie eine Präsentation auf die Größe der anderen ändern. Beim Ändern der Foliengröße können Sie festlegen, wie der vorhandene Inhalt über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidesizescaletype/) behandelt wird. Nach dem Angleichen der Größen können Sie Folien zusammenführen und dabei die Formatierung beibehalten.

### Kann ich Thumbnails für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen sie die neue Foliengröße?

Ja. Aspose.Slides kann Thumbnails für [gesamte Folien](https://reference.aspose.com/slides/de/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getImage-int-float-float-) erstellen. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider, wodurch ein konsistenter Bildausschnitt und Geometrie gewährleistet sind.