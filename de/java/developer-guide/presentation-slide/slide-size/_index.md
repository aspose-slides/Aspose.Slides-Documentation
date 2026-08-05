---
title: Foliengröße einer Präsentation in Java ändern
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
- Vollformatfolie
- Bildschirmtyp
- Nicht skalieren
- Passend anpassen
- Maximieren
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit Java und Aspose.Slides schnell in der Größe ändern und Präsentationen für jede Anzeige optimieren, ohne Qualitätsverlust."
---
## **Einführung**

Aspose.Slides bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, was sowohl für den Druck als auch für die Anzeige auf dem Bildschirm entscheidend ist.

Beliebte Foliengrößen und Seitenverhältnisse:

- **Standard (4:3‑Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (16:9‑Seitenverhältnis)**: Empfohlen für moderne Projektoren und Anzeigen.

Stellen Sie sicher, dass Ihre gesamte Präsentation konsistent bleibt, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse setzen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation, um Komplikationen zu vermeiden.

{{% alert color="primary" %}} 
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

## **Foliengröße in Präsentationen ändern**

Dieser Beispielcode zeigt, wie Sie die Foliengröße in einer Präsentation mit Java und Aspose.Slides ändern:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Benutzerdefinierte Foliengrößen in Präsentationen festlegen**

Wenn die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit ungeeignet sind, können Sie eine spezifische oder einzigartige Foliengröße verwenden. Beispielsweise, wenn Sie Vollformat‑Folien aus Ihrer Präsentation auf einem benutzerdefinierten Seitendesign drucken möchten oder die Präsentation auf bestimmten Bildschirmtypen anzeigen wollen, profitieren Sie von einer benutzerdefinierten Größeneinstellung.

Dieser Beispielcode zeigt, wie Sie Aspose.Slides für Java verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in Java festzulegen:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-Papiergröße
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Umgang mit Folieninhalten nach dem Ändern der Größe**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (z. B. Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch an die neue Foliengröße angepasst. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Abhängig davon, was Sie beabsichtigen, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie auf eine kleinere Foliengröße skalieren wollen und Aspose.Slides die Objekte verkleinern soll, damit sie alle auf die Folien passen (so vermeiden Sie das Verlieren von Inhalten), verwenden Sie diese Einstellung.

- `Maximize`

  Wenn Sie auf eine größere Foliengröße skalieren wollen und Aspose.Slides die Objekte vergrößern soll, damit sie proportional zur neuen Foliengröße sind, verwenden Sie diese Einstellung.

Dieser Beispielcode zeigt, wie Sie die Einstellung `Maximize` beim Ändern der Foliengröße einer Präsentation verwenden:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die konvertierten Werte zur Definition von Folienbreite und -höhe verwenden.

**Wirkt sich eine sehr große benutzerdefinierte Foliengröße während der Renderung auf Leistung und Speicherverbrauch aus?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einem höheren Rendering‑Skalenfaktor führen zu einem höheren Speicherverbrauch und längeren Verarbeitungszeiten. Streben Sie eine praktikable Foliengröße an und passen Sie den Rendering‑Skalenfaktor nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht standardmäßige Foliengröße definieren und anschließend Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?**

Sie können keine [Präsentationen zusammenführen](/slides/de/java/merge-presentation/) durchführen, solange sie unterschiedliche Foliengrößen haben – zuerst müssen Sie eine Präsentation an die andere anpassen. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach dem Angleichen der Größen können Sie Folien zusammenführen und dabei die Formatierung beibehalten.

**Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und werden sie die neue Foliengröße berücksichtigen?**

Ja. Aspose.Slides kann Miniaturansichten für [gesamte Folien](https://reference.aspose.com/slides/de/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getImage-int-float-float-) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider, wodurch ein konsistenter Bildausschnitt und eine einheitliche Geometrie gewährleistet werden.