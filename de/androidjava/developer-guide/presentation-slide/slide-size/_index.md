---
title: Präsentationsfoliengröße auf Android ändern
linktitle: Foliengröße
type: docs
weight: 70
url: /de/androidjava/slide-size/
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
- Android
- Java
- Aspose.Slides
description: "Folien in PPT-, PPTX- und ODP-Dateien schnell mit Java und Aspose.Slides für Android skalieren, Präsentationen für jeden Bildschirm optimieren, ohne Qualitätsverlust."
---
## **Einleitung**

Aspose.Slides bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, die sowohl für den Druck als auch für die Anzeige auf dem Bildschirm entscheidend sind. 

Beliebte Foliengrößen und -verhältnisse:

- **Standard (4:3 Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (16:9 Seitenverhältnis)**: Empfohlen für moderne Projektoren und Displays.

Stellen Sie die Konsistenz Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse legen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation fest, um Komplikationen zu vermeiden.

{{% alert color="primary" %}} 
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

## **Foliengröße in Präsentationen ändern**

Dieses Beispielcode zeigt, wie Sie die Foliengröße in einer Präsentation in Java mit Aspose.Slides ändern:

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

Wenn die üblichen Foliengrößen (4:3 und 16:9) für Ihre Arbeit ungeeignet sind, können Sie sich für eine bestimmte oder einzigartige Foliengröße entscheiden. Wenn Sie beispielsweise Vollformat‑Folien Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout drucken oder Ihre Präsentation auf bestimmten Bildschirmtypen anzeigen möchten, profitieren Sie wahrscheinlich von einer benutzerdefinierten Größeneinstellung für Ihre Präsentation. 

Dieses Beispielcode zeigt, wie Sie Aspose.Slides für Android über Java verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in Java festzulegen:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-Papiergröße
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Folieninhalt nach Größenänderung handhaben**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (z. B. Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch an die neue Foliengröße angepasst. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Folieninhalten umgeht.

Je nach dem, was Sie erreichen möchten, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie zu einer kleineren Foliengröße skalieren möchten und Aspose.Slides die Objekte der Folien verkleinern soll, damit sie alle auf die Folien passen (so vermeiden Sie Inhaltsverlust), verwenden Sie diese Einstellung. 

- `Maximize`

  Wenn Sie zu einer größeren Foliengröße skalieren möchten und Aspose.Slides die Objekte vergrößern soll, damit sie proportional zur neuen Foliengröße werden, verwenden Sie diese Einstellung. 

Dieses Beispielcode zeigt, wie Sie die Einstellung `Maximize` beim Ändern der Foliengröße einer Präsentation verwenden:

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

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (z. B. Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Definition von Folienbreite und -höhe verwenden.

**Wirkt sich eine sehr große benutzerdefinierte Foliengröße auf die Leistung und den Speicherverbrauch beim Rendern aus?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einem höheren Rendering‑Skalierungsfaktor führen zu einem erhöhten Speicherverbrauch und längeren Verarbeitungszeiten. Streben Sie eine praktikable Foliengröße an und passen Sie den Rendering‑Skalierungsfaktor nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht‑standardmäßige Foliengröße definieren und dann Folien aus Präsentationen zusammenführen, die unterschiedliche Größen haben?**

Sie können nicht [Präsentationen zusammenführen](/slides/de/androidjava/merge-presentation/), solange sie unterschiedliche Foliengrößen haben – zuerst passen Sie eine Präsentation an die andere an. Beim Ändern der Foliengröße können Sie festlegen, wie vorhandene Inhalte über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidesizescaletype/) behandelt werden. Nach der Angleichung der Größen können Sie Folien zusammenführen und das Layout beibehalten.

**Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und werden sie die neue Foliengröße berücksichtigen?**

Ja. Aspose.Slides kann Miniaturansichten für [gesamte Folien](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) rendern. Die erzeugten Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider und gewährleisten ein konsistentes Bildfeld und eine korrekte Geometrie.