---
title: Foliengröße in Präsentationen auf Android ändern
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
- benutzerdefinierte Foliengröße
- besondere Foliengröße
- einzigartige Foliengröße
- Vollbildfolie
- Bildschirmtyp
- nicht skalieren
- Passend anpassen
- maximieren
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Passen Sie Folien in PPT-, PPTX- und ODP-Dateien schnell mit Java und Aspose.Slides für Android an, optimieren Sie Präsentationen für jeden Bildschirm, ohne Qualitätsverlust."
---
## **Einleitung**

Aspose.Slides bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, die sowohl für den Druck als auch für die Anzeige auf dem Bildschirm von entscheidender Bedeutung sind. 

Beliebte Foliengrößen und -verhältnisse:

- **Standard (4:3 Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.
- **Breitbild (16:9 Seitenverhältnis)**: Empfohlen für moderne Projektoren und Bildschirme.

Stellen Sie die Konsistenz Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse setzen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation, um Komplikationen zu vermeiden.

{{% alert color="info" %}} 
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

## **Foliengröße in Präsentationen ändern**

Dieses Beispiel zeigt, wie Sie die Foliengröße in einer Präsentation in Java mit Aspose.Slides ändern:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Benutzerdefinierte Foliengrößen in Präsentationen festlegen**

Wenn die üblichen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht geeignet sind, können Sie eine spezifische oder einzigartige Foliengröße verwenden. Beispielsweise, wenn Sie Folien in voller Größe aus Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout drucken möchten oder wenn Sie Ihre Präsentation auf bestimmten Bildschirmtypen anzeigen wollen, profitieren Sie wahrscheinlich von einer benutzerdefinierten Größeneinstellung für Ihre Präsentation. 

Dieses Beispiel zeigt, wie Sie Aspose.Slides für Android über Java verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in Java festzulegen:

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

## **Folieninhalt nach Größenänderung behandeln**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (z. B. Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch so skaliert, dass sie zur neuen Foliengröße passen. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nach dem, was Sie erreichen möchten, können Sie eine der folgenden Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie zu einer kleineren Foliengröße skalieren und Aspose.Slides die Objekte verkleinern soll, damit sie alle auf die Folien passen (so vermeiden Sie Inhaltsverlust), verwenden Sie diese Einstellung. 

- `Maximize`

  Wenn Sie zu einer größeren Foliengröße skalieren und Aspose.Slides die Objekte vergrößern soll, damit sie proportional zur neuen Foliengröße sind, verwenden Sie diese Einstellung. 

Dieses Beispiel zeigt, wie Sie die Einstellung `Maximize` verwenden, wenn Sie die Größe einer Folie einer Präsentation ändern:

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

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Definition von Folienbreite und -höhe verwenden.

### Beeinflusst eine sehr große benutzerdefinierte Foliengröße die Leistung und den Speicherverbrauch beim Rendern?

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit höherer Render‑Skalierung führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Ziel ist eine praktikable Foliengröße; passen Sie die Render‑Skalierung nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

### Kann ich eine nicht‑standardmäßige Foliengröße definieren und dann Folien aus Präsentationen zusammenführen, die unterschiedliche Größen haben?

Sie können nicht [merge presentations](/slides/de/androidjava/merge-presentation/) zusammenführen, solange sie unterschiedliche Foliengrößen haben – zuerst die Größe einer Präsentation an die andere anpassen. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach der Angleichung der Größen können Sie Folien zusammenführen und dabei die Formatierung beibehalten.

### Kann ich Thumbnails für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen sie dabei die neue Foliengröße?

Ja. Aspose.Slides kann Thumbnails für [entire slides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) sowie für [selected shapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) rendern. Die erzeugten Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider und sorgen für konsistente Bildausschnitte und Geometrie.