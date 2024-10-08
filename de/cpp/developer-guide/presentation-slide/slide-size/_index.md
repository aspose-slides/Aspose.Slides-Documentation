---
title: Foliengröße
type: docs
weight: 70
url: /de/cpp/slide-size/

---

## Foliengrößen in PowerPoint-Präsentationen

Aspose.Slides für C++ ermöglicht es Ihnen, die Foliengröße oder das Seitenverhältnis in PowerPoint-Präsentationen zu ändern. Wenn Sie Ihre Präsentation drucken oder die Folien auf einem Bildschirm anzeigen möchten, müssen Sie auf die Foliengröße oder das Seitenverhältnis achten. 

Dies sind die häufigsten Foliengrößen und Seitenverhältnisse:

- **Standard (4:3-Seitenverhältnis)**

  Wenn Ihre Präsentation auf relativ älteren Geräten oder Bildschirmen angezeigt oder angesehen werden soll, möchten Sie möglicherweise diese Einstellung verwenden. 

- **Breitbild (16:9-Seitenverhältnis)** 

  Wenn Ihre Präsentation auf modernen projektoren oder Bildschirmen gesehen werden soll, möchten Sie möglicherweise diese Einstellung verwenden. 

Sie können in einer einzigen Präsentation keine mehreren Foliengrößeneinstellungen verwenden. Wenn Sie eine Foliengröße für eine Präsentation auswählen, wird diese Foliengrößeneinstellung auf alle Folien in der Präsentation angewendet. 

Wenn Sie eine spezielle Foliengröße für Ihre Präsentationen verwenden möchten, empfehlen wir dringend, dies frühzeitig zu tun. Idealerweise sollten Sie Ihre bevorzugte Größe zu Beginn angeben, d. h. wenn Sie gerade die Präsentation einrichten – bevor Sie Inhalte zur Präsentation hinzufügen. Auf diese Weise vermeiden Sie Komplikationen, die aus (zukünftigen) Änderungen der Foliengröße resultieren können. 

{{% alert color="primary" %}} 

 Wenn Sie Aspose.Slides verwenden, um eine Präsentation zu erstellen, erhalten alle Folien in der Präsentation automatisch die Standardgröße oder das 4:3-Seitenverhältnis.

{{% /alert %}} 

## Ändern der Foliengröße in Präsentationen 

 Dieser Beispielcode zeigt Ihnen, wie Sie die Foliengröße in einer Präsentation in C++ mit Aspose.Slides ändern:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## Festlegen benutzerdefinierter Foliengrößen in Präsentationen

Wenn Sie die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit als ungeeignet erachten, können Sie sich entscheiden, eine spezifische oder einzigartige Foliengröße zu verwenden. Zum Beispiel, wenn Sie vorhaben, vollformatige Folien aus Ihrer Präsentation in einem benutzerdefinierten Seitenlayout zu drucken oder wenn Sie beabsichtigen, Ihre Präsentation auf bestimmten Bildschirmtypen anzuzeigen, profitieren Sie wahrscheinlich von der Verwendung einer benutzerdefinierten Größeneinstellung für Ihre Präsentation. 

Dieser Beispielcode zeigt Ihnen, wie Sie Aspose.Slides für C++ verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in C++ festzulegen:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4-Papiergröße
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## Umgang mit Problemen beim Ändern der Größe von Folien in Präsentationen

Nachdem Sie die Foliengröße für eine Präsentation geändert haben, können die Inhalte der Folien (Bilder oder Objekte zum Beispiel) verzerrt werden. Standardmäßig werden die Objekte automatisch an die neue Foliengröße angepasst. Wenn Sie jedoch die Foliengröße einer Präsentation ändern, können Sie eine Einstellung angeben, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nachdem, was Sie tun oder erreichen möchten, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie nicht möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie auf eine kleinere Foliengröße skalieren möchten und Sie möchten, dass Aspose.Slides die Objekte der Folien verkleinert, um sicherzustellen, dass sie alle auf die Folien passen (auf diese Weise vermeiden Sie den Verlust von Inhalten), verwenden Sie diese Einstellung. 

- `Maximize`

  Wenn Sie auf eine größere Foliengröße skalieren möchten und Sie möchten, dass Aspose.Slides die Objekte der Folien vergrößert, um sie proportional zur neuen Foliengröße zu machen, verwenden Sie diese Einstellung. 

Dieser Beispielcode zeigt Ihnen, wie Sie die Einstellung `Maximize` verwenden, wenn Sie die Größe einer Folie in einer Präsentation ändern:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```