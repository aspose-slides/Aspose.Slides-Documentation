---
title: Ändern der Foliengröße in Java
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
- Anpassen sicherstellen
- Maximieren
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit Java und Aspose.Slides schnell skalieren und Präsentationen für jeden Bildschirm optimieren, ohne Qualitätsverlust."
---
## **Einleitung**

Aspose.Slides bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, die sowohl für den Druck als auch für die Anzeige auf dem Bildschirm entscheidend sind. 

Beliebte Foliengrößen und -verhältnisse:

- **Standard (Seitenverhältnis 4:3)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (Seitenverhältnis 16:9)**: Empfohlen für moderne Projektoren und Displays.

Stellen Sie die Konsistenz Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse legen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation fest, um Komplikationen zu vermeiden.

{{% alert color="info" title="Note" %}}
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

Notizen- und Handzettelseiten haben andere Abmessungen als reguläre Folien. Siehe [Größe der Notizseite](/slides/de/java/notes-size/) um deren Größe und Ausrichtung zu ändern.

## **Foliengröße in Präsentationen ändern**

Dieses Beispiel zeigt, wie Sie die Foliengröße in einer Präsentation in Java mit Aspose.Slides ändern:

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

## **Benutzerdefinierte Foliengrößen in Präsentationen festlegen**

Wenn die üblichen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht geeignet sind, können Sie eine bestimmte oder einzigartige Foliengröße verwenden. Beispielsweise, wenn Sie Vollformatfolien aus Ihrer Präsentation auf einem benutzerdefinierten Seitendesign drucken möchten oder Ihre Präsentation auf bestimmten Bildschirmtypen anzeigen wollen, profitieren Sie vermutlich von einer benutzerdefinierten Größeneinstellung für Ihre Präsentation. 

Dieses Beispiel zeigt, wie Sie Aspose.Slides für Java verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in Java festzulegen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 Papiergröße
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Folieninhalt nach Größenänderung behandeln**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (z. B. Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch auf die neue Foliengröße skaliert. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nach dem, was Sie erreichen möchten, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie zu einer kleineren Foliengröße skalieren möchten und Aspose.Slides die Folienobjekte verkleinern soll, damit sie alle auf die Folien passen (so vermeiden Sie Inhaltsverlust), verwenden Sie diese Einstellung. 

- `Maximize`

  Wenn Sie zu einer größeren Foliengröße skalieren möchten und Aspose.Slides die Folienobjekte vergrößern soll, um sie proportional zur neuen Foliengröße zu machen, verwenden Sie diese Einstellung. 

Dieses Beispiel zeigt, wie Sie die Einstellung `Maximize` beim Ändern der Foliengröße einer Präsentation verwenden:

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

**Wie wirkt sich eine sehr große benutzerdefinierte Foliengröße auf die Leistung und den Speicherverbrauch beim Rendern aus?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit höherer Render‑Skala führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Streben Sie eine praktische Foliengröße an und passen Sie die Render‑Skala nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht standardmäßige Foliengröße definieren und dann Folien aus Präsentationen zusammenführen, die unterschiedliche Größen haben?**

Sie können nicht [Präsentationen zusammenführen](/slides/de/java/merge-presentation/), solange sie unterschiedliche Foliengrößen haben – zuerst die Größe einer Präsentation an die andere anpassen. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach dem Angleichen der Größen können Sie Folien zusammenführen und das Format beibehalten.

**Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen sie die neue Foliengröße?**

Ja. Aspose.Slides kann Miniaturansichten für [gesamte Folien](https://reference.aspose.com/slides/de/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getImage-int-float-float-) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider und sorgen für konsistente Bildausschnitte und Geometrie.