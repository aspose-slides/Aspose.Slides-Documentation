---
title: Foliengröße
type: docs
weight: 70
url: /de/net/slide-size/
keywords: "Folien festlegen, Foliengröße bearbeiten, PowerPoint-Präsentation, benutzerdefinierte Foliengröße, Folienprobleme lösen, C#, Csharp, .NET, Aspose.Slides"
descriptions: "Foliengröße oder Seitenverhältnis in PowerPoint in C# oder .NET festlegen und bearbeiten"
---

## Foliengrößen in PowerPoint-Präsentationen

Aspose.Slides für .NET ermöglicht es Ihnen, die Foliengröße oder das Seitenverhältnis in PowerPoint-Präsentationen zu ändern. Wenn Sie planen, Ihre Präsentation zu drucken oder ihre Folien auf einem Bildschirm anzuzeigen, müssen Sie auf die Foliengröße oder das Seitenverhältnis achten.

Dies sind die häufigsten Foliengrößen und Seitenverhältnisse:

- **Standard (4:3-Seitenverhältnis)**

  Wenn Ihre Präsentation auf relativ älteren Geräten oder Bildschirmen angezeigt oder betrachtet werden soll, möchten Sie möglicherweise diese Einstellung verwenden.

- **Breitbild (16:9-Seitenverhältnis)**

  Wenn Ihre Präsentation auf modernen Projektoren oder Displays angezeigt werden soll, möchten Sie möglicherweise diese Einstellung verwenden.

Sie können in einer einzigen Präsentation keine mehreren Foliengrößeinstellungen verwenden. Wenn Sie eine Foliengröße für eine Präsentation auswählen, wird diese Foliengrößeinstellung auf alle Folien in der Präsentation angewendet.

Wenn Sie eine spezielle Foliengröße für Ihre Präsentationen verwenden möchten, empfehlen wir Ihnen dringend, dies frühzeitig zu tun. Idealerweise sollten Sie Ihre bevorzugte Foliengröße zu Beginn festlegen, d. h. wenn Sie die Präsentation gerade einrichten – bevor Sie Inhalte zur Präsentation hinzufügen. Auf diese Weise vermeiden Sie Komplikationen, die aus (zukünftigen) Änderungen an der Größe der Folien resultieren.

{{% alert color="primary" %}} 

 Wenn Sie Aspose.Slides verwenden, um eine Präsentation zu erstellen, erhalten automatisch alle Folien in der Präsentation die Standardgröße oder das 4:3-Seitenverhältnis.

{{% /alert %}} 

## Ändern der Foliengröße in Präsentationen

Dieser Beispielcode zeigt Ihnen, wie Sie die Foliengröße in einer Präsentation in C# mit Aspose.Slides ändern:

```c#
using (Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
}
```

## Festlegen benutzerdefinierter Foliengrößen in Präsentationen

Wenn Sie die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit als ungeeignet empfinden, können Sie sich entscheiden, eine spezifische oder einzigartige Foliengröße zu verwenden. Zum Beispiel, wenn Sie planen, Vollformatfolien aus Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout zu drucken oder wenn Sie Ihre Präsentation auf bestimmten Bildschirmtypen anzeigen möchten, werden Sie wahrscheinlich von der Verwendung einer benutzerdefinierten Größe für Ihre Präsentation profitieren.

Dieser Beispielcode zeigt Ihnen, wie Sie Aspose.Slides für .NET verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in C# festzulegen:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4-Papiersize
    pres.Save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
}
```

## Umgang mit Problemen bei der Änderung der Größe von Folien in Präsentationen

Nachdem Sie die Foliengröße für eine Präsentation geändert haben, können die Inhalte der Folien (z. B. Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch angepasst, um in die neue Foliengröße zu passen. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung angeben, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nachdem, was Sie vorhaben oder erreichen möchten, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie nicht möchten, dass die Objekte auf den Folien neu skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie auf eine kleinere Foliengröße skalieren möchten und Sie möchten, dass Aspose.Slides die Objekte auf den Folien verkleinert, um sicherzustellen, dass sie alle auf die Folien passen (auf diese Weise vermeiden Sie den Verlust von Inhalten), verwenden Sie diese Einstellung.

- `Maximize`

  Wenn Sie auf eine größere Foliengröße skalieren möchten und Sie möchten, dass Aspose.Slides die Objekte auf den Folien vergrößert, um sie proportional zur neuen Foliengröße zu machen, verwenden Sie diese Einstellung.

Dieser Beispielcode zeigt Ihnen, wie Sie die Einstellung `Maximize` verwenden, wenn Sie die Größe einer Folie in einer Präsentation ändern:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```