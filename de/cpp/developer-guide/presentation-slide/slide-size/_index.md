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
- besondere Foliengröße
- einzigartige Foliengröße
- Vollgrößenfolie
- Bildschirmtyp
- nicht skalieren
- Passend sicherstellen
- maximieren
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PPT-, PPTX- und ODP-Dateien mit C++ und Aspose.Slides schnell skalieren und Präsentationen für jeden Bildschirm optimieren, ohne Qualitätsverlust."
---
## **Einleitung**

Aspose.Slides bietet umfassende Werkzeuge zum Anpassen der Foliengröße und des Seitenverhältnisses in PowerPoint‑Präsentationen, die sowohl für den Druck als auch für die Anzeige auf Bildschirmen wichtig sind.

Beliebte Foliengrößen und -verhältnisse:

- **Standard (4:3‑Seitenverhältnis)**: Ideal für ältere Bildschirme und Geräte.
- **Widescreen (16:9‑Seitenverhältnis)**: Empfohlen für moderne Projektoren und Anzeigen.

Stellen Sie die Konsistenz Ihrer gesamten Präsentation sicher, da eine einheitliche Foliengröße und ein einheitliches Seitenverhältnis auf alle Folien angewendet werden. Für optimale Ergebnisse legen Sie die Folienabmessungen zu Beginn des Erstellungsprozesses Ihrer Präsentation fest, um Komplikationen zu vermeiden.

{{% alert color="info" %}} 
Standardmäßig verwenden mit Aspose.Slides erstellte Präsentationen das Standard‑Seitenverhältnis 4:3.
{{% /alert %}}

Notiz- und Handzettelseiten haben andere Abmessungen als reguläre Folien. Siehe [Größe der Notizseite](/slides/de/cpp/notes-size/) um deren Größe und Ausrichtung zu ändern.

## **Foliengröße in Präsentationen ändern**

Dieser Beispielcode zeigt, wie Sie die Foliengröße in einer Präsentation in C++ mit Aspose.Slides ändern:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Benutzerdefinierte Foliengrößen in Präsentationen festlegen**

Wenn Ihnen die gängigen Foliengrößen (4:3 und 16:9) für Ihre Arbeit nicht geeignet erscheinen, können Sie eine bestimmte oder einzigartige Foliengröße verwenden. Zum Beispiel, wenn Sie beabsichtigen, Vollgrößenfolien Ihrer Präsentation auf einem benutzerdefinierten Seitenlayout zu drucken oder Ihre Präsentation auf bestimmten Bildschirmtypen anzuzeigen, profitieren Sie wahrscheinlich von einer benutzerdefinierten Größeneinstellung für Ihre Präsentation.

Dieser Beispielcode zeigt, wie Sie Aspose.Slides für C++ verwenden, um eine benutzerdefinierte Foliengröße für eine Präsentation in C++ festzulegen:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4-Papiergröße
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Folieninhalt nach Größenänderung behandeln**

Nachdem Sie die Foliengröße einer Präsentation geändert haben, können die Inhalte der Folien (z. B. Bilder oder Objekte) verzerrt werden. Standardmäßig werden die Objekte automatisch auf die neue Foliengröße skaliert. Beim Ändern der Foliengröße einer Präsentation können Sie jedoch eine Einstellung festlegen, die bestimmt, wie Aspose.Slides mit den Inhalten auf den Folien umgeht.

Je nach dem, was Sie beabsichtigen, können Sie eine dieser Einstellungen verwenden:

- `DoNotScale`

  Wenn Sie NICHT möchten, dass die Objekte auf den Folien skaliert werden, verwenden Sie diese Einstellung.

- `EnsureFit`

  Wenn Sie zu einer kleineren Foliengröße skalieren möchten und Aspose.Slides die Folienobjekte verkleinern soll, damit sie alle auf die Folien passen (so vermeiden Sie Inhaltsverlust), verwenden Sie diese Einstellung.

- `Maximize`

  Wenn Sie zu einer größeren Foliengröße skalieren möchten und Aspose.Slides die Folienobjekte vergrößern soll, damit sie proportional zur neuen Foliengröße werden, verwenden Sie diese Einstellung.

Dieser Beispielcode zeigt, wie Sie die Einstellung `Maximize` beim Ändern der Foliengröße einer Präsentation verwenden:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

### Kann ich eine benutzerdefinierte Foliengröße mit anderen Einheiten als Zoll festlegen (z. B. Punkte oder Millimeter)?

Ja. Aspose.Slides verwendet intern Punkte, wobei 1 Punkt 1/72 Zoll entspricht. Sie können jede Einheit (wie Millimeter oder Zentimeter) in Punkte umrechnen und die umgerechneten Werte zur Definition von Folienbreite und -höhe verwenden.

### Hat eine sehr große benutzerdefinierte Foliengröße Auswirkungen auf die Leistung und den Speicherverbrauch beim Rendern?

Ja. Größere Folienabmessungen (in Punkten) in Kombination mit einem höheren Render‑Skalierungsfaktor führen zu einem höheren Speicherverbrauch und längeren Verarbeitungszeiten. Ziel ist eine praktisch geeignete Foliengröße; passen Sie den Render‑Skalierungsfaktor nur bei Bedarf an, um die gewünschte Ausgabequalität zu erreichen.

### Kann ich eine nicht‑standardmäßige Foliengröße definieren und anschließend Folien aus Präsentationen mit unterschiedlichen Größen zusammenführen?

Sie können keine [Präsentationen zusammenführen](/slides/de/cpp/merge-presentation/) durchführen, solange die Präsentationen unterschiedliche Foliengrößen haben – passen Sie zuerst eine Präsentation an die andere an. Beim Ändern der Foliengröße können Sie über die Option [SlideSizeScaleType](https://reference.aspose.com/slides/de/cpp/aspose.slides/slidesizescaletype/) festlegen, wie vorhandene Inhalte behandelt werden. Nach der Angleichung der Größen können Sie die Folien zusammenführen und das Format beibehalten.

### Kann ich Miniaturansichten für einzelne Formen oder bestimmte Bereiche einer Folie erzeugen, und werden sie die neue Foliengröße berücksichtigen?

Ja. Aspose.Slides kann Miniaturansichten für [gesamte Folien](https://reference.aspose.com/slides/de/cpp/aspose.slides/slide/getimage/) sowie für [ausgewählte Formen](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/getimage/) rendern. Die resultierenden Bilder spiegeln die aktuelle Foliengröße und das Seitenverhältnis wider und gewährleisten ein konsistentes Framing und eine konsistente Geometrie.