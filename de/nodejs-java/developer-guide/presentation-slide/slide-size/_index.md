---
title: Ändern der Foliengröße der Präsentation in JavaScript
linktitle: Foliengröße
type: docs
weight: 70
url: /de/nodejs-java/slide-size/
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
- Vollgrößenfolie
- Bildschirmtyp
- Nicht skalieren
- Anpassung sicherstellen
- Maximieren
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit Node.js und Aspose.Slides schnell ändern, Präsentationen für jeden Bildschirm optimieren, ohne Qualitätsverlust."
---
## **Einleitung**

Aspose.Slides bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, was sowohl für den Druck als auch für die Anzeige auf Bildschirmen entscheidend ist.

Beliebte Foliengrößen und Seitenverhältnisse:

- **Standard (4:3 Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.  
- **Breitbild (16:9 Seitenverhältnis)**: Empfohlen für moderne Projektoren und Displays.

Stellen Sie die Konsistenz Ihrer gesamten Präsentation sicher, da eine einzige Foliengröße und ein einziges Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse setzen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation, um Komplikationen zu vermeiden.

{{% alert color="primary" %}} 
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Seitenverhältnis 4:3.  
{{% /alert %}}

## **Ändern der Foliengröße in Präsentationen**

Dieser Beispielcode zeigt, wie Sie die Foliengröße in einer Präsentation in JavaScript mit Aspose.Slides ändern:

```javascript
var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Angeben benutzerdefinierter Foliengrößen in Präsentationen**

Wenn Ihnen die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht passen, können Sie eine spezifische oder einzigartige Foliengröße verwenden. Beispielsweise profitieren Sie von einer benutzerdefinierten Größe, wenn Sie Vollgrößen‑Folien Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout drucken oder die Präsentation auf bestimmten Bildschirmen anzeigen möchten.

Dieser Beispielcode zeigt, wie Sie Aspose.Slides für Node.js über Java nutzen, um eine benutzerdefinierte Foliengröße für eine Präsentation in JavaScript festzulegen:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// A4-Papiergröße
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Umgang mit Problemen beim Ändern der Foliengröße in Präsentationen**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch auf die neue Foliengröße skaliert. Beim Ändern der Foliengröße können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Folieninhalten umgeht.

Je nach gewünschtem Ergebnis können Sie eine der folgenden Einstellungen verwenden:

- `DoNotScale`  

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`  

  Wenn Sie zu einer kleineren Foliengröße skalieren und Aspose.Slides die Objekte verkleinern soll, damit sie alle auf die Folien passen (Sie vermeiden so Inhaltsverlust), verwenden Sie diese Einstellung.

- `Maximize`  

  Wenn Sie zu einer größeren Foliengröße skalieren und Aspose.Slides die Objekte vergrößern soll, damit sie proportional zur neuen Foliengröße sind, verwenden Sie diese Einstellung.

Dieser Beispielcode zeigt, wie Sie die Einstellung `Maximize` beim Ändern der Foliengröße einer Präsentation verwenden:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (z. B. Millimeter oder Zentimeter) in Punkte umrechnen und die konvertierten Werte zur Festlegung von Folienbreite und –höhe verwenden.

**Wirkt sich eine sehr große benutzerdefinierte Foliengröße während des Renderns auf die Leistung und den Speicherverbrauch aus?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einer höheren Render‑Skala führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Streben Sie eine praktische Foliengröße an und passen Sie die Render‑Skala nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht standardmäßige Foliengröße definieren und anschließend Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?**

Sie können nicht [Präsentationen zusammenführen](/slides/de/nodejs-java/merge-presentation/), solange sie unterschiedliche Foliengrößen besitzen — skalieren Sie zunächst eine Präsentation, sodass sie der anderen entspricht. Beim Ändern der Foliengröße können Sie festlegen, wie vorhandene Inhalte über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesizescaletype/) behandelt werden. Nach dem Angleichen der Größen können Sie Folien zusammenführen und dabei die Formatierung beibehalten.

**Kann ich Thumbnails für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen diese die neue Foliengröße?**

Ja. Aspose.Slides kann Thumbnails für [gesamte Folien](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#getImage) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getImage) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider und sorgen so für konsistente Bildausschnitte und Geometrie.