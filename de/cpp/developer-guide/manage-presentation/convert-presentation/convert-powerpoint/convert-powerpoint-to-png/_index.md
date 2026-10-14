---
title: PowerPoint-Folien nach PNG konvertieren in C++
linktitle: PowerPoint zu PNG
type: docs
weight: 30
url: /de/cpp/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu PNG
- Präsentation zu PNG
- Folie zu PNG
- PPT zu PNG
- PPTX zu PNG
- PPT als PNG speichern
- PPTX als PNG speichern
- PPT nach PNG exportieren
- PPTX nach PNG exportieren
- C++
- Aspose.Slides
description: "PowerPoint-Präsentationen schnell in hochwertige PNG-Bilder konvertieren mit Aspose.Slides für C++ und dabei präzise, automatisierte Ergebnisse sicherstellen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Präsentationsfolien mithilfe von Aspose.Slides für C++ in PNG‑Bilder konvertieren. Sie können Präsentationen in Formaten wie PPT, PPTX und ODP laden, jede Folie rendern und sie als separates PNG‑Bild speichern.

Die nachfolgenden Beispiele zeigen das Rendern mit dem Standardskala, das Erhöhen der Skalierung, das Festlegen der Ausgabedimensionen in Pixeln und das Auswählen eines Gradienten‑Render‑Stils.

## **PowerPoint in PNG konvertieren**

Laden Sie eine Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) und greifen Sie über den Zugriff [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) auf deren Folien zu. Das Beispiel rendert jede Folie mit [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) ohne Parameter, um ein Vorschaubild zu erzeugen. Anschließend wird [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) mit [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) aufgerufen, um jede gerenderte Folie als PNG‑Bild zu speichern.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Die parameterlose Überladung [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) rendert mit einer Skalierung von 0.2. Beispielsweise erzeugt eine Folie mit den Abmessungen 720 × 540 Punkte ein Vorschaubild von 144 × 108 Pixeln. Um die Ausgabedimensionen zu steuern, verwenden Sie die Überladungen mit Skalierungsfaktoren oder einer expliziten Bildgröße, wie unten gezeigt.
{{% /alert %}}

## **PowerPoint in PNG mit benutzerdefinierten Abmessungen konvertieren**

Übergeben Sie horizontale und vertikale Skalierungsfaktoren an [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/), um die gerenderten Abmessungen zu steuern. In diesem Beispiel sind beide Faktoren 2, sodass eine Folie mit 720 × 540 Punkten ein Bild von 1440 × 1080 Pixeln erzeugt. Gleiche Skalierungsfaktoren erhalten das Seitenverhältnis der Folie bei. Jede Bild wird im PNG‑Format mit [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) gespeichert.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **PowerPoint in PNG mit benutzerdefinierter Größe konvertieren**

Um die Ausgabedimensionen in Pixeln anzugeben, übergeben Sie statt Skalierungsfaktoren eine Größe an [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/). Dieses Beispiel rendert jede Folie mit 960 × 720 Pixeln und speichert das Ergebnis mit [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Wählen Sie Abmessungen, die dem Seitenverhältnis der Folie entsprechen, um ein Verziehen des Bildes zu vermeiden.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Gradient‑Render‑Stil auswählen**

Angenommen, eine Folie enthält Farbverläufe, aber die Übergänge im exportierten PNG sehen heller oder anderweitig anders aus als in PowerPoint. Sie können die Methode [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) von [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) verwenden, um zu bestimmen, wie die Verläufe gerendert werden.

Laden Sie [gradient-styles.pptx](gradient-styles.pptx) herunter und legen Sie sie im Arbeitsverzeichnis der Anwendung ab. Die erste Folie enthält zwei lineare Verläufe: Cyan zu Orange oben und Blau zu Gelb unten. Jeder Verlauf hat zwei Stopps bei 0 % und 100 %.

Das folgende Beispiel lädt diese Präsentation und rendert dieselbe erste Folie in beiden Modi mit [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-zu-Orange- und Blau-zu-Gelb-Verläufe, gerendert mit Default](gradient-Default.png) | ![Dieselbe Verläufe, gerendert mit PowerPointUI](gradient-PowerPointUI.png) |

In diesem Beispiel erzeugt `Default` hellere Zwischenfarben, während `PowerPointUI` dunklere Zwischenfarben erzeugt. Der Unterschied hängt von den Farben und Stopps im Verlauf ab.

Wählen Sie `Default`, wenn die Standardausgabe von Aspose.Slides Ihren Anforderungen entspricht. Verwenden Sie `PowerPointUI`, wenn Ihre Priorität darin besteht, das Aussehen in PowerPoint nachzubilden. Vergleichen Sie beide Ausgaben mit dem gewünschten Ergebnis; keiner der Modi ist allgemein vorzuziehen.

## **FAQ**

**Wie kann ich ein bestimmtes Shape, z. B. ein Diagramm oder Bild, statt der gesamten Folie exportieren?**  
Aspose.Slides unterstützt das [Erzeugen von Miniaturansichten für einzelne Shapes](/slides/de/cpp/shape-thumbnails/), sodass Sie ein Shape als PNG‑Bild rendern können.

**Wird eine parallele Konvertierung auf einem Server unterstützt?**  
Ja. Verwenden Sie für jeden Thread oder Prozess eine separate Präsentationsinstanz; [teilen Sie keine einzelne Instanz über Threads hinweg](/slides/de/cpp/multithreading/).

**Welche Einschränkungen gelten im Evaluierungsmodus beim Exportieren nach PNG?**  
Im Evaluierungsmodus wird den Ausgabebildern ein Wasserzeichen hinzugefügt und es gelten [weitere Einschränkungen](/slides/de/cpp/licensing/), bis eine Lizenz angewendet wird.