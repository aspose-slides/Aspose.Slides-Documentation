---
title: Foliengröße
type: docs
weight: 70
url: /de/androidjava/slide-size/

---

## Foliengrößen in PowerPoint-Präsentationen

Aspose.Slides für Android über Java ermöglicht es Ihnen, die Foliengröße oder das Seitenverhältnis in PowerPoint-Präsentationen zu ändern. Wenn Sie planen, Ihre Präsentation zu drucken oder ihre Folien auf einem Bildschirm anzuzeigen, müssen Sie auf die Foliengröße oder das Seitenverhältnis achten.

Dies sind die gängigsten Foliengrößen und Seitenverhältnisse:

- **Standard (4:3-Seitenverhältnis)**

  Wenn Ihre Präsentation auf relativ älteren Geräten oder Bildschirmen angezeigt oder betrachtet wird, möchten Sie möglicherweise diese Einstellung verwenden. 

- **Breitbild (16:9-Seitenverhältnis)** 

  Wenn Ihre Präsentation auf modernen Projektoren oder Displays angesehen wird, möchten Sie möglicherweise diese Einstellung verwenden. 

Sie können nicht mehrere Foliengrößeneinstellungen in einer einzigen Präsentation verwenden. Wenn Sie eine Foliengröße für eine Präsentation auswählen, wird diese Foliengrößeneinstellung auf alle Folien in der Präsentation angewendet. 

Wenn Sie eine spezielle Foliengröße für Ihre Präsentationen verwenden möchten, empfehlen wir Ihnen dringend, dies frühzeitig zu tun. Idealerweise sollten Sie die bevorzugte Foliengröße zu Beginn angeben, d.h. wenn Sie gerade die Präsentation einrichten – bevor Sie Inhalte zur Präsentation hinzufügen. Auf diese Weise vermeiden Sie Komplikationen, die aus (künftigen) Änderungen an der Foliengröße resultieren. 

{{% alert color="primary" %}} 

 Wenn Sie Aspose.Slides verwenden, um eine Präsentation zu erstellen, erhalten alle Folien in der Präsentation automatisch die Standardgröße oder das 4:3-Seitenverhältnis.

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

## Angeben benutzerdefinierter Foliengrößen in Präsentationen

Wenn Sie die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit als ungeeignet empfinden, können Sie entscheiden, eine spezifische oder einzigartige Foliengröße zu verwenden. Beispielsweise, wenn Sie planen, Vollbildfolien aus Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout zu drucken oder wenn Sie beabsichtigen, Ihre Präsentation auf bestimmten Bildschirmtypen anzuzeigen, werden Sie wahrscheinlich von der Verwendung einer benutzerdefinierten Größe für Ihre Präsentation profitieren. 

Dieser Beispielcode zeigt Ihnen, wie Sie Aspose.Slides für Android über Java verwenden können, um eine benutzerdefinierte Foliengröße für eine Präsentation in Java anzugeben:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-Papiergröße
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Umgang mit Problemen beim Ändern der Größe von Folien in Präsentationen

Nachdem Sie die Foliengröße für eine Präsentation geändert haben, können die Inhalte der Folien (z.B. Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch skaliert, um zur neuen Foliengröße zu passen. Wenn Sie jedoch die Foliengröße einer Präsentation ändern, können Sie eine Einstellung angeben, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nachdem, was Sie beabsichtigen zu tun oder zu erreichen, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie möchten, dass die Objekte auf den Folien nicht skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie auf eine kleinere Foliengröße skalieren möchten und Aspose.Slides die Objekte der Folien verkleinern soll, um sicherzustellen, dass sie alle auf die Folien passen (so vermeiden Sie den Verlust von Inhalten), verwenden Sie diese Einstellung. 

- `Maximize`

  Wenn Sie auf eine größere Foliengröße skalieren möchten und Aspose.Slides die Objekte der Folien vergrößern soll, um sie proportional zur neuen Foliengröße zu machen, verwenden Sie diese Einstellung. 

Dieser Beispielcode zeigt Ihnen, wie Sie die `Maximize`-Einstellung verwenden, wenn Sie die Größe der Folien einer Präsentation ändern:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```