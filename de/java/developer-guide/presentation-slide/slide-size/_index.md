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
- Passend skalieren
- Maximieren
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
descriptions: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit Java und Aspose.Slides schnell ändern können, um Präsentationen für jeden Bildschirm zu optimieren, ohne Qualitätsverlust."
---

## **Foliengrößen in PowerPoint-Präsentationen**

Aspose.Slides für Java ermöglicht es Ihnen, die Foliengröße oder das Seitenverhältnis in PowerPoint-Präsentationen zu ändern. Wenn Sie Ihre Präsentation drucken oder die Folien auf einem Bildschirm anzeigen möchten, müssen Sie auf die Foliengröße bzw. das Seitenverhältnis achten. 

Dies sind die gängigsten Foliengrößen und Seitenverhältnisse:

- **Standard (Seitenverhältnis 4:3)**

  Wenn Ihre Präsentation auf relativ älteren Geräten oder Bildschirmen angezeigt oder betrachtet werden soll, können Sie diese Einstellung verwenden. 

- **Widescreen (Seitenverhältnis 16:9)** 

  Wenn Ihre Präsentation auf modernen Projektoren oder Displays gesehen wird, können Sie diese Einstellung verwenden. 

Sie können nicht mehrere Foliengrößeneinstellungen in einer einzigen Präsentation verwenden. Wenn Sie eine Foliengröße für eine Präsentation auswählen, wird diese Einstellung auf alle Folien der Präsentation angewendet. 

Wenn Sie für Ihre Präsentationen eine spezielle Foliengröße verwenden möchten, empfehlen wir dringend, dies frühzeitig zu tun. Idealerweise sollten Sie Ihre bevorzugte Folie zu Beginn festlegen, d. h. beim Einrichten der Präsentation – bevor Sie Inhalte hinzufügen. So vermeiden Sie Komplikationen, die durch (zukünftige) Änderungen der Foliengröße entstehen können. 

{{% alert color="primary" %}} 

Wenn Sie Aspose.Slides verwenden, um eine Präsentation zu erstellen, erhalten alle Folien der Präsentation automatisch die Standardgröße bzw. das Seitenverhältnis 4:3.

{{% /alert %}} 

## **Foliengröße in Präsentationen ändern**

Dieser Beispielcode zeigt, wie Sie die Foliengröße einer Präsentation in Java mit Aspose.Slides ändern:
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

Wenn Sie die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit als ungeeignet empfinden, können Sie eine bestimmte oder einzigartige Foliengröße verwenden. Beispielsweise, wenn Sie Vollformatfolien Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout drucken oder Ihre Präsentation auf bestimmten Bildschirmtypen anzeigen möchten, profitieren Sie wahrscheinlich von einer benutzerdefinierten Größeneinstellung für Ihre Präsentation. 

Dieser Beispielcode zeigt, wie Sie mit Aspose.Slides für Java eine benutzerdefinierte Foliengröße für eine Präsentation in Java festlegen:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-Papiergröße
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Folieninhalt nach Größenänderung behandeln**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (Bilder oder Objekte usw.) verzerrt werden. Standardmäßig werden die Objekte automatisch skaliert, damit sie zur neuen Foliengröße passen. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten der Folien umgeht.

Je nach dem, was Sie beabsichtigen, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie zu einer kleineren Foliengröße skalieren und Aspose.Slides die Folienobjekte verkleinern soll, damit sie alle auf die Folien passen (so vermeiden Sie Inhaltsverlust), verwenden Sie diese Einstellung. 

- `Maximize`

  Wenn Sie zu einer größeren Foliengröße skalieren und Aspose.Slides die Folienobjekte vergrößern soll, damit sie proportional zur neuen Foliengröße werden, verwenden Sie diese Einstellung. 

Dieser Beispielcode zeigt, wie Sie die `Maximize`-Einstellung beim Ändern der Größe einer Präsentationsfolie verwenden:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll (z. B. Punkten oder Millimetern) festlegen?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die konvertierten Werte zur Definition von Folienbreite und -höhe verwenden.

**Wirkt sich eine sehr große benutzerdefinierte Foliengröße auf Leistung und Speicherverbrauch beim Rendern aus?**

Ja. Größere Folienabmessungen (in Punkten) kombiniert mit höherer Render‑Skalierung führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Ziel ist eine praktikable Foliengröße; passen Sie die Render‑Skalierung nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht‑standardmäßige Foliengröße definieren und dann Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?**

Sie können keine [Präsentationen zusammenführen](/slides/de/java/merge-presentation/), solange sie unterschiedliche Foliengrößen haben – zuerst müssen Sie eine Präsentation auf die Größe der anderen anpassen. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/) festlegen, wie vorhandener Inhalt behandelt wird. Nachdem die Größen angepasst wurden, können Sie Folien zusammenführen und das Format beibehalten.

**Kann ich Thumbnails für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und werden sie die neue Foliengröße berücksichtigen?**

Ja. Aspose.Slides kann Thumbnails für [gesamte Folien](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) erzeugen. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider, wodurch ein konsistenter Bildausschnitt und die Geometrie gewährleistet werden.