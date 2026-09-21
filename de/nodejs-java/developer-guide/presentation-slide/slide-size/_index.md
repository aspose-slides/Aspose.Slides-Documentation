---
title: Ändern der Präsentationsfoliengröße in JavaScript
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
- Vollformatfolie
- Bildschirmtyp
- Nicht skalieren
- Passend skalieren
- Maximieren
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit Node.js und Aspose.Slides schnell ändern können, um Präsentationen für jeden Bildschirm zu optimieren, ohne Qualitätsverlust."
---
## **Einleitung**

Aspose.Slides bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, was sowohl für den Druck als auch für die Anzeige auf Bildschirmen entscheidend ist.

Beliebte Foliengrößen und Verhältnisse:

- **Standard (Seitenverhältnis 4:3)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (Seitenverhältnis 16:9)**: Empfohlen für moderne Projektoren und Displays.

Stellen Sie die Konsistenz in Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse legen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses fest, um Komplikationen zu vermeiden.

{{% alert color="info" title="Hinweis" %}}
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Seitenverhältnis 4:3.
{{% /alert %}}

Notizen‑ und Handout‑Seiten haben separate Abmessungen zu regulären Folien. Siehe [Notizseitengröße](/slides/de/nodejs-java/notes-size/) zum Ändern von Größe und Ausrichtung.

## **Ändern der Foliengröße in Präsentationen**

Dieses Beispiel zeigt, wie Sie die Foliengröße in einer Präsentation mit JavaScript und Aspose.Slides ändern:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Festlegen benutzerdefinierter Foliengrößen in Präsentationen**

Wenn die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht geeignet sind, können Sie eine spezifische oder einzigartige Foliengröße verwenden. Beispielsweise, wenn Sie Folien in Originalgröße auf einem benutzerdefinierten Seitenlayout drucken oder Ihre Präsentation auf bestimmten Bildschirmtypen anzeigen möchten, profitieren Sie von einer benutzerdefinierten Größe.

Dieses Beispiel zeigt, wie Sie Aspose.Slides für Node.js via Java verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in JavaScript festzulegen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können Inhalte der Folien (Bilder oder Objekte usw.) verzerrt werden. Standardmäßig werden Objekte automatisch skaliert, um in die neue Foliengröße zu passen. Beim Ändern der Foliengröße können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nach gewünschtem Ergebnis können Sie eine der folgenden Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie auf eine kleinere Foliengröße skalieren und Aspose.Slides die Folienobjekte verkleinern soll, damit sie alle auf die Folien passen (damit Sie keine Inhalte verlieren), verwenden Sie diese Einstellung.

- `Maximize`

  Wenn Sie auf eine größere Foliengröße skalieren und Aspose.Slides die Folienobjekte vergrößern soll, damit sie proportional zur neuen Foliengröße werden, verwenden Sie diese Einstellung.

Dieses Beispiel zeigt, wie Sie die Einstellung `Maximize` beim Ändern der Foliengröße einer Präsentation verwenden:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Definition von Folienbreite und -höhe verwenden.

**Wirkt sich eine sehr große benutzerdefinierte Foliengröße auf die Leistung und den Speicherverbrauch beim Rendern aus?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einer höheren Render‑Skala führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Streben Sie eine praktikable Foliengröße an und passen Sie die Render‑Skala nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht‑standardmäßige Foliengröße definieren und dann Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?**

Sie können keine [Präsentationen zusammenführen](/slides/de/nodejs-java/merge-presentation/), solange sie unterschiedliche Foliengrößen haben — passen Sie zunächst eine Präsentation an die Größe der anderen an. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach dem Angleichen der Größen können Sie Folien zusammenführen und das Format beibehalten.

**Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen diese die neue Foliengröße?**

Ja. Aspose.Slides kann Miniaturansichten für [gesamte Folien](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#getImage) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getImage) rendern. Die erzeugten Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider, sodass Bildausschnitt und Geometrie konsistent bleiben.