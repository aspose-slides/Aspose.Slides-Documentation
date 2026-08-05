---
title: Foliengröße der Präsentation in C++ ändern
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
- benutzerdefinierte Foliengröße
- spezielle Foliengröße
- einzigartige Foliengröße
- Vollformatfolie
- Bildschirmtyp
- nicht skalieren
- passend halten
- maximieren
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit C++ und Aspose.Slides schnell ändern können, um Präsentationen für jeden Bildschirm zu optimieren, ohne Qualitätsverlust."
---
## **Einleitung**

Aspose.Slides bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, die sowohl für den Druck als auch für die Anzeige auf dem Bildschirm entscheidend sind.

Gängige Foliengrößen und Seitenverhältnisse:

- **Standard (4:3 Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (16:9 Seitenverhältnis)**: Empfohlen für moderne Projektoren und Displays.

Stellen Sie die Konsistenz Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis für alle Folien gelten. Für optimale Ergebnisse setzen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation, um Komplikationen zu vermeiden.

{{% alert color="primary" %}} 
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

## **Foliengröße in Präsentationen ändern**

Dieses Beispielcode zeigt, wie Sie die Foliengröße in einer Präsentation in C++ mit Aspose.Slides ändern:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Benutzerdefinierte Foliengrößen in Präsentationen angeben**

Wenn die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht geeignet sind, können Sie eine spezifische oder einzigartige Foliengröße verwenden. Beispielsweise, wenn Sie beabsichtigen, Vollformatfolien aus Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout zu drucken oder die Präsentation auf bestimmten Bildschirmtypen anzuzeigen, profitieren Sie wahrscheinlich von einer benutzerdefinierten Größe für Ihre Präsentation.

Dieses Beispielcode zeigt, wie Sie Aspose.Slides für C++ verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in C++ festzulegen:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4-Papiergröße
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Folieninhalt nach Größenänderung behandeln**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (z. B. Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch angepasst, um in die neue Foliengröße zu passen. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nach dem, was Sie beabsichtigen, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`
  
  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`
  
  Wenn Sie zu einer kleineren Foliengröße skalieren möchten und Aspose.Slides die Objekte der Folien verkleinern soll, um sicherzustellen, dass alle auf die Folien passen (so vermeiden Sie Verlust von Inhalten), verwenden Sie diese Einstellung. 

- `Maximize`
  
  Wenn Sie zu einer größeren Foliengröße skalieren möchten und Aspose.Slides die Objekte der Folien vergrößern soll, damit sie proportional zur neuen Foliengröße sind, verwenden Sie diese Einstellung. 

Dieses Beispielcode zeigt, wie Sie die Einstellung `Maximize` verwenden, wenn Sie die Größe einer Folie in einer Präsentation ändern:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

**Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?**

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte verwenden, um die Folienbreite und -höhe festzulegen.

**Beeinflusst eine sehr große benutzerdefinierte Foliengröße die Leistung und den Speicherverbrauch beim Rendern?**

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einem höheren Rendermaßstab führen zu einem höheren Speicherverbrauch und längeren Verarbeitungszeiten. Ziel ist eine praktische Foliengröße, und der Rendermaßstab sollte nur bei Bedarf angepasst werden, um die gewünschte Ausgabeverqualität zu erreichen.

**Kann ich eine nicht‑standardmäßige Foliengröße festlegen und dann Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?**

Sie können nicht [merge presentations](/slides/de/cpp/merge-presentation/) zusammenführen, solange sie unterschiedliche Foliengrößen haben – zuerst die Größe einer Präsentation an die andere anpassen. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/cpp/aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach dem Angleichen der Größen können Sie Folien zusammenführen und dabei die Formatierung beibehalten.

**Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und werden sie die neue Foliengröße berücksichtigen?**

Ja. Aspose.Slides kann Miniaturansichten für [entire slides](https://reference.aspose.com/slides/de/cpp/aspose.slides/slide/getimage/) sowie für [selected shapes](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/getimage/) rendern. Die erzeugten Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider und gewährleisten eine konsistente Bildausschnitt und Geometrie.