---
title: Foliengröße
type: docs
weight: 70
url: /de/php-java/slide-size/

---

## Foliengrößen in PowerPoint-Präsentationen

Aspose.Slides für PHP via Java ermöglicht es Ihnen, die Foliengröße oder das Seitenverhältnis in PowerPoint-Präsentationen zu ändern. Wenn Sie planen, Ihre Präsentation zu drucken oder ihre Folien auf einem Bildschirm anzuzeigen, müssen Sie auf die Foliengröße oder das Seitenverhältnis achten.

Dies sind die gebräuchlichsten Foliengrößen und Seitenverhältnisse:

- **Standard (4:3-Seitenverhältnis)**

  Wenn Ihre Präsentation auf relativ älteren Geräten oder Bildschirmen angezeigt oder betrachtet wird, möchten Sie möglicherweise diese Einstellung verwenden.

- **Breitbild (16:9-Seitenverhältnis)** 

  Wenn Ihre Präsentation auf modernen Projektoren oder Displays gesehen wird, möchten Sie möglicherweise diese Einstellung verwenden.

Sie können in einer einzelnen Präsentation keine mehreren Foliengrößeneinstellungen verwenden. Wenn Sie eine Foliengröße für eine Präsentation auswählen, wird diese Foliengrößeneinstellung auf alle Folien in der Präsentation angewendet.

Wenn Sie eine spezielle Foliengröße für Ihre Präsentationen verwenden möchten, empfehlen wir Ihnen dringend, dies frühzeitig zu tun. Idealerweise sollten Sie Ihre bevorzugte Foliengröße zu Beginn festlegen, d.h. wenn Sie die Präsentation gerade einrichten – bevor Sie Inhalte zur Präsentation hinzufügen. Auf diese Weise vermeiden Sie Komplikationen, die aus (künftigen) Änderungen an den Foliengrößen resultieren.

{{% alert color="primary" %}} 

 Wenn Sie Aspose.Slides zur Erstellung einer Präsentation verwenden, erhalten alle Folien in der Präsentation automatisch die Standardgröße oder das 4:3-Seitenverhältnis.

{{% /alert %}} 

## Ändern der Foliengröße in Präsentationen 

 Dieser Beispielcode zeigt Ihnen, wie Sie die Foliengröße in einer Präsentation mit Aspose.Slides ändern:

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Festlegen benutzerdefinierter Foliengrößen in Präsentationen

Wenn Sie die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit als ungeeignet empfinden, können Sie sich entscheiden, eine spezifische oder einzigartige Foliengröße zu verwenden. Wenn Sie beispielsweise planen, vollständige Folien aus Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout zu drucken oder Ihre Präsentation auf bestimmten Bildschirmtypen anzuzeigen, könnten Sie von der Verwendung einer benutzerdefinierten Größe für Ihre Präsentation profitieren.

Dieser Beispielcode zeigt Ihnen, wie Sie Aspose.Slides für PHP via Java verwenden können, um eine benutzerdefinierte Foliengröße für eine Präsentation festzulegen:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// A4-Papiergröße

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Umgang mit Problemen beim Ändern der Foliengröße in Präsentationen

Nachdem Sie die Foliengröße für eine Präsentation geändert haben, können die Inhalte der Folien (Bilder oder Objekte zum Beispiel) verzerrt werden. Standardmäßig werden die Objekte automatisch in der Größe angepasst, um zur neuen Foliengröße zu passen. Wenn Sie jedoch die Foliengröße einer Präsentation ändern, können Sie eine Einstellung angeben, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nachdem, was Sie tun oder erreichen möchten, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien in der Größe angepasst werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie auf eine kleinere Foliengröße skalieren möchten und benötigen, dass Aspose.Slides die Objekte der Folien verkleinert, um sicherzustellen, dass sie alle auf den Folien passen (auf diese Weise vermeiden Sie den Verlust von Inhalten), verwenden Sie diese Einstellung. 

- `Maximize`

  Wenn Sie auf eine größere Foliengröße skalieren möchten und benötigen, dass Aspose.Slides die Objekte der Folien vergrößert, um sie proportional zur neuen Foliengröße zu machen, verwenden Sie diese Einstellung. 

Dieser Beispielcode zeigt Ihnen, wie Sie die Einstellung `Maximize` verwenden, wenn Sie die Größe einer Präsentationsfolie ändern:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```