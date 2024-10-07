---
title: Foliengröße
type: docs
weight: 70
url: /java/slide-size/

---

## Foliengrößen in PowerPoint-Präsentationen

Aspose.Slides für Java ermöglicht es Ihnen, die Foliengröße oder das Seitenverhältnis in PowerPoint-Präsentationen zu ändern. Wenn Sie planen, Ihre Präsentation zu drucken oder ihre Folien auf einem Bildschirm anzuzeigen, müssen Sie auf die Foliengröße oder das Seitenverhältnis achten.

Dies sind die gebräuchlichsten Foliengrößen und Seitenverhältnisse:

- **Standard (4:3 Seitenverhältnis)**

  Wenn Ihre Präsentation auf relativ älteren Geräten oder Bildschirmen angezeigt oder angesehen wird, möchten Sie möglicherweise diese Einstellung verwenden.

- **Breitbild (16:9 Seitenverhältnis)** 

  Wenn Ihre Präsentation auf modernen Projektoren oder Displays gesehen wird, möchten Sie möglicherweise diese Einstellung verwenden.

Sie können keine mehreren Foliengrößeneinstellungen in einer einzelnen Präsentation verwenden. Wenn Sie eine Foliengröße für eine Präsentation auswählen, wird diese Foliengröße auf alle Folien in der Präsentation angewendet.

Wenn Sie eine spezielle Foliengröße für Ihre Präsentationen verwenden möchten, empfehlen wir Ihnen dringend, dies frühzeitig zu tun. Idealerweise sollten Sie Ihre bevorzugte Foliengröße zu Beginn festlegen, d.h. wenn Sie die Präsentation gerade einrichten – bevor Sie Inhalte zur Präsentation hinzufügen. Auf diese Weise vermeiden Sie Komplikationen, die aus (zukünftigen) Änderungen der Größe der Folien resultieren.

{{% alert color="primary" %}} 

 Wenn Sie Aspose.Slides zur Erstellung einer Präsentation verwenden, erhalten alle Folien in der Präsentation automatisch die Standardgröße oder das 4:3 Seitenverhältnis.

{{% /alert %}} 

## Ändern der Foliengröße in Präsentationen 

 Dieser Beispielcode zeigt Ihnen, wie Sie die Foliengröße in einer Präsentation in Java mit Aspose.Slides ändern:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Festlegen benutzerdefinierter Foliengrößen in Präsentationen

Wenn Sie die gängigen Foliengrößen (4:3 und 16:9) als ungeeignet für Ihre Arbeit empfinden, können Sie sich entscheiden, eine bestimmte oder einzigartige Foliengröße zu verwenden. Wenn Sie beispielsweise vorhaben, Folien in voller Größe aus Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout zu drucken oder wenn Sie beabsichtigen, Ihre Präsentation auf bestimmten Bildschirmtypen anzuzeigen, profitieren Sie wahrscheinlich von der Verwendung einer benutzerdefinierten Größe für Ihre Präsentation.

Dieser Beispielcode zeigt Ihnen, wie Sie Aspose.Slides für Java verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in Java festzulegen:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 Papiergröße
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Umgang mit Problemen beim Ändern der Foliengröße in Präsentationen

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (z.B. Bilder oder Objekte) verzerrt erscheinen. Standardmäßig werden die Objekte automatisch so angepasst, dass sie in die neue Foliengröße passen. Wenn Sie jedoch die Foliengröße einer Präsentation ändern, können Sie eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nachdem, was Sie tun oder erreichen möchten, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie möchten, dass die Objekte auf den Folien nicht skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie auf eine kleinere Foliengröße skalieren möchten und Sie möchten, dass Aspose.Slides die Objekte der Folien so verkleinert, dass sie alle auf die Folien passen (auf diese Weise vermeiden Sie den Verlust von Inhalten), verwenden Sie diese Einstellung.

- `Maximize`

  Wenn Sie auf eine größere Foliengröße skalieren möchten und Sie möchten, dass Aspose.Slides die Objekte der Folien vergrößert, um sie proportional zur neuen Foliengröße zu machen, verwenden Sie diese Einstellung.

Dieser Beispielcode zeigt Ihnen, wie Sie die Einstellung `Maximize` verwenden, wenn Sie die Größe einer Präsentationsfolie ändern:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```