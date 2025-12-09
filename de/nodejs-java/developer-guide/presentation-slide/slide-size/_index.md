---
title: Foliengröße
type: docs
weight: 70
url: /de/nodejs-java/slide-size/
---

## **Foliengrößen in PowerPoint-Präsentationen**

Aspose.Slides für Node.js via Java ermöglicht es Ihnen, die Foliengröße oder das Seitenverhältnis in PowerPoint‑Präsentationen zu ändern. Wenn Sie Ihre Präsentation drucken oder die Folien auf einem Bildschirm anzeigen möchten, müssen Sie auf die Foliengröße bzw. das Seitenverhältnis achten.

Dies sind die gängigsten Foliengrößen und Seitenverhältnisse:

- **Standard (Seitenverhältnis 4:3)**

  Wenn Ihre Präsentation auf relativ älteren Geräten oder Bildschirmen angezeigt werden soll, möchten Sie diese Einstellung verwenden. 

- **Widescreen (Seitenverhältnis 16:9)** 

  Wenn Ihre Präsentation auf modernen Projektoren oder Displays gesehen wird, sollten Sie diese Einstellung wählen. 

Sie können nicht mehrere Foliengrößeneinstellungen in einer einzigen Präsentation verwenden. Wenn Sie eine Foliengröße für eine Präsentation auswählen, wird diese Einstellung auf alle Folien der Präsentation angewendet. 

Wenn Sie für Ihre Präsentationen eine Spezial‑Foliengröße verwenden möchten, empfehlen wir dringend, dies frühzeitig zu tun. Idealerweise sollten Sie Ihre bevorzugte Folie zu Beginn festlegen, d. h. bereits beim Einrichten der Präsentation – bevor Sie Inhalte hinzufügen. So vermeiden Sie Komplikationen, die durch (zukünftige) Änderungen der Foliengröße entstehen können. 

{{% alert color="primary" %}} 

 Wenn Sie Aspose.Slides zum Erstellen einer Präsentation verwenden, erhalten alle Folien in der Präsentation automatisch die Standardgröße bzw. das 4:3‑Seitenverhältnis.

{{% /alert %}} 

## **Ändern der Foliengröße in Präsentationen**

 Dieser Beispielcode zeigt, wie Sie die Foliengröße in einer Präsentation in JavaScript mithilfe von Aspose.Slides ändern:
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

Wenn Ihnen die gängigen Foliengrößen (4:3 und 16:9) nicht passen, können Sie eine spezielle oder eindeutige Foliengröße verwenden. Beispielsweise, wenn Sie Vollgrößen‑Folien aus Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout drucken oder die Präsentation auf bestimmten Bildschirmtypen anzeigen möchten, profitieren Sie möglicherweise von einer benutzerdefinierten Größeneinstellung für Ihre Präsentation. 

Dieser Beispielcode demonstriert, wie Sie Aspose.Slides für Node.js via Java verwenden, um in JavaScript eine benutzerdefinierte Foliengröße für eine Präsentation festzulegen:
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

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (Bilder oder Objekte usw.) verzerrt werden. Standardmäßig werden Objekte automatisch skaliert, um in die neue Foliengröße zu passen. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nach dem, was Sie erreichen wollen, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie zu einer kleineren Foliengröße skalieren und Aspose.Slides die Objekte verkleinern soll, damit sie alle auf die Folien passen (damit Sie keinen Inhalt verlieren), wählen Sie diese Einstellung. 

- `Maximize`

  Wenn Sie zu einer größeren Foliengröße skalieren und Aspose.Slides die Objekte vergrößern soll, damit sie proportional zur neuen Foliengröße werden, nutzen Sie diese Einstellung. 

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

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die konvertierten Werte zur Definition von Folienbreite und -höhe verwenden.

**Beeinflusst eine sehr große benutzerdefinierte Foliengröße die Leistung und den Speicherverbrauch beim Rendern?**

Ja. Größere Folienmaße (in Punkten) kombiniert mit einem höheren Rendering‑Skalenfaktor führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Ziel ist eine praktikable Foliengröße; passen Sie die Rendering‑Skala nur bei Bedarf an, um die gewünschte Ausgabqualität zu erzielen.

**Kann ich eine nicht‑standardmäßige Foliengröße definieren und dann Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?**

Sie können nicht [merge presentations](/slides/de/nodejs-java/merge-presentation/) während die Präsentationen unterschiedliche Foliengrößen haben – zuerst die Größe einer Präsentation an die andere anpassen. Beim Ändern der Foliengröße können Sie wählen, wie vorhandene Inhalte über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/) behandelt werden. Nach dem Angleichen der Größen können Sie Folien zusammenführen und das Format beibehalten.

**Kann ich Thumbnails für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und berücksichtigen diese die neue Foliengröße?**

Ja. Aspose.Slides kann Thumbnails für [entire slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) sowie für [selected shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) rendern. Die erzeugten Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider, wodurch eine konsistente Bildkomposition und Geometrie gewährleistet wird.