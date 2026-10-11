---
title: Foliengröße einer Präsentation unter Android ändern
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
- Folien in voller Größe
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
description: "Ändern Sie schnell die Größe von Folien in PPT-, PPTX- und ODP-Dateien mit Java und Aspose.Slides für Android, optimieren Sie Präsentationen für jeden Bildschirm, ohne Qualitätsverlust."
---
## **Einführung**

Aspose.Slides stellt umfassende Werkzeuge zur Verfügung, um die Foliengröße und das Seitenverhältnis in PowerPoint‑Präsentationen anzupassen, was sowohl für den Druck als auch für die Anzeige auf dem Bildschirm entscheidend ist.

Beliebte Foliengrößen und Verhältnisse:

- **Standard (4:3 Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (16:9 Seitenverhältnis)**: Empfohlen für moderne Projektoren und Anzeigen.

Stellen Sie sicher, dass Ihre gesamte Präsentation konsistent ist, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gilt. Für optimale Ergebnisse legen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation fest, um Komplikationen zu vermeiden.

{{% alert color="info" title="Note" %}}
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

Notizen‑ und Handzettelseiten haben andere Abmessungen als reguläre Folien. Siehe [Notes Page Size](/slides/de/androidjava/notes-size/) um deren Größe und Ausrichtung zu ändern.

## **Foliengröße in Präsentationen ändern**

Dieses Beispielcode zeigt, wie Sie die Foliengröße in einer Präsentation in Java mit Aspose.Slides ändern:

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

Wenn die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht geeignet sind, können Sie eine bestimmte oder einzigartige Foliengröße verwenden. Zum Beispiel, wenn Sie Folien in voller Größe aus Ihrer Präsentation auf einem benutzerdefinierten Seitendesign drucken möchten oder wenn Sie Ihre Präsentation auf bestimmten Bildschirmsystemen anzeigen möchten, profitieren Sie wahrscheinlich von einer benutzerdefinierten Größeneinstellung für Ihre Präsentation.

Dieses Beispielcode zeigt, wie Sie Aspose.Slides für Android über Java verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in Java festzulegen:

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

## **Folieninhalt nach der Größenänderung behandeln**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (z. B. Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch auf die neue Foliengröße skaliert. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nachdem, was Sie beabsichtigen, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`  
  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`  
  Wenn Sie zu einer kleineren Foliengröße skalieren und Aspose.Slides die Objekte verkleinern soll, damit sie alle auf die Folien passen (so vermeiden Sie Inhaltsverlust), verwenden Sie diese Einstellung.

- `Maximize`  
  Wenn Sie zu einer größeren Foliengröße skalieren und Aspose.Slides die Objekte vergrößern soll, um sie proportional zur neuen Foliengröße zu machen, verwenden Sie diese Einstellung.

Dieses Beispielcode zeigt, wie Sie die Einstellung `Maximize` beim Ändern der Foliengröße einer Präsentation verwenden:

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

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?**  

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Definition von Folienbreite und -höhe verwenden.

**Wirkt sich eine sehr große benutzerdefinierte Foliengröße auf die Leistung und den Speicherverbrauch beim Rendern aus?**  

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einem höheren Rendering‑Skalenfaktor führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Streben Sie eine praktisch geeignete Foliengröße an und passen Sie den Rendering‑Skalenfaktor nur nach Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht‑standardmäßige Foliengröße definieren und anschließend Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?**  

Sie können keine [Präsentationen zusammenführen](/slides/de/androidjava/merge-presentation/), wenn sie unterschiedliche Foliengrößen haben – passen Sie zunächst eine Präsentation an die andere an. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach dem Angleichen der Größen können Sie die Folien zusammenführen und dabei das Format beibehalten.

**Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und werden sie die neue Foliengröße berücksichtigen?**  

Ja. Aspose.Slides kann Miniaturansichten für [gesamte Folien](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider, wodurch ein konsistenter Bildausschnitt und eine einheitliche Geometrie gewährleistet wird.