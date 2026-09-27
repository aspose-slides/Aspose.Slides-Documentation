---
title: Präsentationen in C++ erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/cpp/create-presentation/
keywords:
- Präsentation erstellen
- neue Präsentation
- PPT erstellen
- neues PPT
- PPTX erstellen
- neues PPTX
- ODP erstellen
- neues ODP
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Präsentationen in C++ mit Aspose.Slides erstellen - PPT-, PPTX- und ODP-Dateien erzeugen, von OpenDocument-Unterstützung profitieren und sie programmatisch speichern für zuverlässige Ergebnisse."
---
## **Übersicht**

Dieser Artikel zeigt, wie man eine Präsentation in Aspose.Slides erstellt, eine Textbox zur ersten Folie hinzufügt und das Ergebnis als Datei speichert. Ein kurzer FAQ am Ende behandelt häufige Fragen zu Formaten, Vorlagen, Foliengröße, Einheiten, Speicherverbrauch, Threading, Lizenzierung, digitalen Signaturen und VBA‑Unterstützung.

Bevor Sie beginnen, fügen Sie Aspose.Slides zu Ihrem Projekt hinzu: aus NuGet in einem Visual Studio‑Projekt unter Windows oder aus dem ZIP‑Paket mit CMake unter Linux. Siehe [Installation](/slides/de/cpp/installation/).

## **PowerPoint‑Präsentation erstellen**

Um eine Präsentation zu erstellen und eine Textbox auf der ersten Folie zu platzieren, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse. Eine neue Präsentation enthält bereits eine leere Folie.
2. Rufen Sie diese Folie mit der Methode [Presentation::get_Slide](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_slide/) und dem Index 0 ab.
3. Fügen Sie mit der Methode [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addautoshape/) ein Rechteck hinzu und setzen Sie dessen Text mit der Methode [ITextFrame::set_Text](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/set_text/).
4. Speichern Sie die Präsentation als PPTX‑Datei mit der Methode [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Die linke obere Ecke des Rechtecks befindet sich 50 Punkte vom linken Rand und 50 Punkte vom oberen Rand der Folie entfernt, und das Rechteck ist 400 Punkte breit und 100 Punkte hoch. Das Programm speichert *hello.pptx* im Arbeitsverzeichnis, mit einer Folie, die das Rechteck und dessen Text enthält. Ohne Lizenz fügt Aspose.Slides jeder gespeicherten Folie ein Evaluierungs‑Wasserzeichen hinzu; siehe [Lizenzierung](/slides/de/cpp/licensing/).

## **FAQ**

### In welche Formate kann ich eine neue Präsentation speichern?

Sie können in [PPTX, PPT und ODP](/slides/de/cpp/save-presentation/) speichern und nach [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/de/cpp/convert-powerpoint-to-xps/), [HTML](/slides/de/cpp/convert-powerpoint-to-html/), [SVG](/slides/de/cpp/render-a-slide-as-an-svg-image/) und [Bildern](/slides/de/cpp/convert-powerpoint-to-png/) exportieren, unter anderem.

### Kann ich von einer Vorlage (POTX/POTM) ausgehen und als reguläres PPTX speichern?

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate [werden unterstützt](/slides/de/cpp/supported-file-formats/).

### Wie kann ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation steuern?

Legen Sie die [Foliengröße](/slides/de/cpp/slide-size/) fest (inklusive Vorgaben wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und wählen Sie, wie der Inhalt skaliert werden soll.

### In welchen Einheiten werden Größen und Koordinaten gemessen?

In Punkten: 1 Zoll entspricht 72 Einheiten.

### Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/cpp/manage-blob/), begrenzen Sie den In‑Memory‑Speicher durch die Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Workflows statt reiner In‑Memory‑Streams.

### Kann ich Präsentationen parallel erstellen/speichern?

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Instanz von [mehreren Threads](/slides/de/cpp/multithreading/) aus verwenden. Führen Sie separate, isolierte Instanzen pro Thread oder Prozess aus.

### Wie entferne ich das Test‑Wasserzeichen und die Beschränkungen?

[Wenden Sie eine Lizenz](/slides/de/cpp/licensing/) pro Prozess an. Die Lizenz‑XML darf nicht verändert werden, und die Lizenz‑Einrichtung sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

### Kann ich das von mir erstellte PPTX digital signieren?

Ja. [Digitale Signaturen](/slides/de/cpp/digital-signature-in-powerpoint/) (Hinzufügen und Verifizieren) werden für Präsentationen unterstützt.

### Werden Makros (VBA) in erstellten Präsentationen unterstützt?

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/cpp/presentation-via-vba/) und makrofähige Dateien wie PPTM/PPSM speichern.