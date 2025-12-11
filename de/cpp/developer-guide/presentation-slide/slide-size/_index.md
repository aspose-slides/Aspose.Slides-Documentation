---
title: Foliengröße in einer Präsentation in C++ ändern
linktitle: Foliengröße
type: docs
weight: 70
url: /de/cpp/slide-size/
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
- Vollformat-Folie
- Bildschirmtyp
- Nicht skalieren
- Passend anpassen
- Maximieren
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
descriptions: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit C++ und Aspose.Slides schnell ändern, Präsentationen für jeden Bildschirm optimieren und dabei die Qualität erhalten."
---

## **Foliengrößen in PowerPoint-Präsentationen**

Aspose.Slides für C++ ermöglicht das Ändern der Foliengröße oder des Seitenverhältnisses in PowerPoint‑Präsentationen. Wenn Sie Ihre Präsentation drucken oder die Folien auf einem Bildschirm anzeigen möchten, müssen Sie die Foliengröße bzw. das Seitenverhältnis berücksichtigen.

Dies sind die gängigsten Foliengrößen und Seitenverhältnisse:

- **Standard (4:3‑Seitenverhältnis)**

  Wenn Ihre Präsentation auf relativ älteren Geräten oder Bildschirmen angezeigt werden soll, können Sie diese Einstellung verwenden.

- **Breitbild (16:9‑Seitenverhältnis)**

  Wenn Ihre Präsentation auf modernen Projektoren oder Displays gesehen werden soll, können Sie diese Einstellung verwenden.

Sie können nicht mehrere Foliengrößeneinstellungen in einer einzelnen Präsentation verwenden. Wenn Sie eine Foliengröße für eine Präsentation auswählen, wird diese Einstellung auf alle Folien der Präsentation angewendet.

Wenn Sie für Ihre Präsentationen eine spezielle Foliengröße verwenden möchten, empfehlen wir dringend, dies frühzeitig zu tun. Idealerweise sollten Sie Ihre bevorzugte Folie zu Beginn festlegen, d. h. bereits beim Einrichten der Präsentation – bevor Sie Inhalte hinzufügen. Auf diese Weise vermeiden Sie Komplikationen, die durch (zukünftige) Änderungen der Foliengröße entstehen können.

{{% alert color="primary" %}} 
Wenn Sie Aspose.Slides zum Erstellen einer Präsentation verwenden, erhalten alle Folien in der Präsentation automatisch die Standardgröße bzw. das 4:3‑Seitenverhältnis.
{{% /alert %}} 

## **Foliengröße in Präsentationen ändern**

Dieses Beispiel zeigt, wie Sie die Foliengröße in einer Präsentation in C++ mit Aspose.Slides ändern:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```


## **Benutzerdefinierte Foliengrößen in Präsentationen angeben**

Wenn Sie die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit als ungeeignet erachten, können Sie eine bestimmte oder eindeutige Foliengröße verwenden. Beispielsweise, wenn Sie Vollformat‑Folien aus Ihrer Präsentation auf einem benutzerdefinierten Seitendesign drucken möchten oder wenn Sie Ihre Präsentation auf bestimmten Bildschirmen anzeigen wollen, können Sie von einer benutzerdefinierten Einstellung profitieren.

Dieses Beispiel zeigt, wie Sie mit Aspose.Slides für C++ eine benutzerdefinierte Foliengröße für eine Präsentation in C++ festlegen:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4-Papiergröße
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```


## **Folieninhalt nach Größenänderung behandeln**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (Bilder oder Objekte usw.) verzerrt werden. Standardmäßig werden die Objekte automatisch so skaliert, dass sie zur neuen Foliengröße passen. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nach Ziel können Sie eine der folgenden Optionen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie zu einer kleineren Foliengröße skalieren und Aspose.Slides die Objekte verkleinern soll, damit alles auf die Folien passt (und Sie somit Inhalte nicht verlieren), verwenden Sie diese Einstellung.

- `Maximize`

  Wenn Sie zu einer größeren Foliengröße skalieren und Aspose.Slides die Objekte vergrößern soll, damit sie proportional zur neuen Foliengröße werden, verwenden Sie diese Einstellung.

Dieses Beispiel zeigt, wie Sie die Einstellung `Maximize` beim Ändern der Foliengröße einer Präsentation verwenden:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```


## **FAQ**

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die konvertierten Werte zur Definition von Folienbreite und -höhe verwenden.

**Beeinflusst eine sehr große benutzerdefinierte Foliengröße die Leistung und den Speicherverbrauch beim Rendern?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einer höheren Render‑Skalierung führen zu erhöhtem Speicherverbrauch und längeren Verarbeitungszeiten. Streben Sie eine praktische Foliengröße an und passen Sie die Render‑Skalierung nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

**Kann ich eine nicht standardmäßige Foliengröße definieren und dann Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?**

Sie können keine [merge presentations](/slides/de/cpp/merge-presentation/) durchführen, solange die Präsentationen unterschiedliche Foliengrößen haben – passen Sie zunächst eine Präsentation an die andere an. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach der Angleichung der Größen können Sie Folien zusammenführen, wobei das Format erhalten bleibt.

**Kann ich Thumbnails für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und werden sie die neue Foliengröße berücksichtigen?**

Ja. Aspose.Slides kann Thumbnails für [entire slides](https://reference.aspose.com/slides/cpp/aspose.slides/slide/getimage/) sowie für [selected shapes](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider, wodurch ein konsistenter Bildausschnitt und die richtige Geometrie gewährleistet werden.