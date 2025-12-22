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
- Besondere Foliengröße
- Einzigartige Foliengröße
- Vollformat‑Folie
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
descriptions: "Ändern Sie schnell die Foliengröße in PPT-, PPTX- und ODP-Dateien mit Java und Aspose.Slides für Android, optimieren Sie Präsentationen für jeden Bildschirm ohne Qualitätsverlust."
---

## **Foliengrößen in PowerPoint-Präsentationen**

Aspose.Slides for Android via Java ermöglicht es Ihnen, die Foliengröße oder das Seitenverhältnis in PowerPoint-Präsentationen zu ändern. Wenn Sie planen, Ihre Präsentation zu drucken oder die Folien auf einem Bildschirm anzuzeigen, müssen Sie auf die Foliengröße bzw. das Seitenverhältnis achten.

Dies sind die gebräuchlichsten Foliengrößen und Seitenverhältnisse:

- **Standard (4:3 Seitenverhältnis)**

  Wenn Ihre Präsentation auf relativ älteren Geräten oder Bildschirmen angezeigt oder betrachtet wird, möchten Sie möglicherweise diese Einstellung verwenden. 

- **Breitbild (16:9 Seitenverhältnis)** 

  Wenn Ihre Präsentation auf modernen Projektoren oder Bildschirmen angezeigt wird, möchten Sie möglicherweise diese Einstellung verwenden. 

Sie können nicht mehrere Foliengrößeneinstellungen in einer einzelnen Präsentation verwenden. Wenn Sie eine Foliengröße für eine Präsentation auswählen, wird diese Einstellung auf alle Folien der Präsentation angewendet. 

Wenn Sie für Ihre Präsentationen eine spezielle Foliengröße verwenden möchten, empfehlen wir dringend, dies früh zu tun. Idealerweise sollten Sie Ihre bevorzugte Folie zu Beginn festlegen, d. h. bereits beim Einrichten der Präsentation—bevor Sie Inhalte hinzufügen. Auf diese Weise vermeiden Sie Komplikationen, die durch (zukünftige) Änderungen der Foliengröße entstehen können. 

{{% alert color="primary" %}} 
 Wenn Sie Aspose.Slides zum Erstellen einer Präsentation verwenden, erhalten alle Folien in der Präsentation automatisch die Standardgröße bzw. das 4:3‑Seitenverhältnis.
{{% /alert %}} 

## **Foliengröße in Präsentationen ändern**

 Dieser Beispielcode zeigt, wie Sie die Foliengröße in einer Präsentation in Java mit Aspose.Slides ändern:
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

Wenn Ihnen die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht passen, können Sie eine spezifische oder eindeutige Foliengröße verwenden. Zum Beispiel, wenn Sie planen, Vollformatfolien Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout zu drucken oder wenn Sie Ihre Präsentation auf bestimmten Bildschirmtypen anzeigen möchten, profitieren Sie wahrscheinlich von einer benutzerdefinierten Größeneinstellung für Ihre Präsentation. 

Dieser Beispielcode zeigt, wie Sie Aspose.Slides for Android via Java verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in Java festzulegen:
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

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (z. B. Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch an die neue Foliengröße angepasst. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nachdem, was Sie beabsichtigen, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skalieren, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie auf eine kleinere Foliengröße skalieren möchten und Aspose.Slides die Objekte verkleinern soll, damit sie alle auf die Folien passen (so vermeiden Sie den Verlust von Inhalten), verwenden Sie diese Einstellung. 

- `Maximize`

  Wenn Sie auf eine größere Foliengröße skalieren möchten und Aspose.Slides die Objekte vergrößern soll, um sie proportional zur neuen Foliengröße zu machen, verwenden Sie diese Einstellung. 

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

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Definition von Folienbreite und -höhe verwenden.

**Wirkt sich eine sehr große benutzerdefinierte Foliengröße auf die Leistung und den Speicherverbrauch beim Rendern aus?**

Ja. Größere Folienabmessungen (in Punkten) kombiniert mit einer höheren Rendering‑Skala führen zu einem erhöhten Speicherverbrauch und längeren Verarbeitungszeiten. Streben Sie eine praktische Foliengröße an und passen Sie die Rendering‑Skala nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht‑standardmäßige Foliengröße festlegen und dann Folien aus Präsentationen zusammenführen, die unterschiedliche Größen haben?**

Sie können nicht [merge presentations](/slides/de/androidjava/merge-presentation/) durchführen, solange die Präsentationen unterschiedliche Foliengrößen haben – zuerst müssen Sie eine Präsentation auf die Größe der anderen ändern. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach dem Angleichen der Größen können Sie Folien zusammenführen und das Layout beibehalten.

**Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen sie die neue Foliengröße?**

Ja. Aspose.Slides kann Miniaturansichten für [entire slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) sowie für [selected shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider und sorgen für konsistente Bildausschnitte und Geometrie.