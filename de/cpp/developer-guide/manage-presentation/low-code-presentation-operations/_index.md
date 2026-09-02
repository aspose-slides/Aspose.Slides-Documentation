---
title: Low-Code-Präsentationsoperationen in C++
linktitle: Low-Code-API
type: docs
weight: 50
url: /de/cpp/low-code-presentation-operations/
keywords:
- Low-Code-Präsentations-API
- Präsentation konvertieren
- Präsentationen zusammenführen
- Folien iterieren
- Shapes iterieren
- Text iterieren
- Shapes sammeln
- Präsentation komprimieren
- Unbenutzte Masterfolien entfernen
- Unbenutzte Layoutfolien entfernen
- Eingebettete Schriftarten komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Verwenden Sie die Aspose.Slides Low-Code-API in C++, um Präsentationen zu konvertieren und zusammenzuführen, Inhalte zu iterieren, Shapes zu sammeln und die Präsentationsgröße zu reduzieren."
---
## **Übersicht**

Der Namensraum [Aspose::Slides::LowCode](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/) stellt statische Hilfsklassen für gängige Präsentationsvorgänge bereit. Diese Helfer kapseln häufig genutzte Objektmodell‑Arbeitsabläufe in fokussierten Methoden, sodass Sie Dateien konvertieren oder zusammenführen, Präsentationselemente verarbeiten, Shapes sammeln und ungenutzten Inhalt mit weniger Code entfernen können.

Low‑code‑Helfer sind am nützlichsten, wenn der Vorgang auf eine gesamte Datei oder Präsentation angewendet wird und der Standard‑Workflow Ihren Anforderungen entspricht. Verwenden Sie das vollständige [Aspose.Slides object model](https://reference.aspose.com/slides/de/cpp/aspose.slides/), wenn Sie eine feinkörnige Kontrolle über einzelne Folien, Master, Layouts, Shapes, Export‑Einstellungen oder Beziehungen zwischen Präsentationselementen benötigen.

Die folgende Tabelle fasst die verfügbaren Helfer zusammen:

| Helfer | Verwendung |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/convert/) | Konvertieren einer Präsentation in ein anderes Format mit einem direkten Datei‑zu‑Datei‑Aufruf. |
| [Merger](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/merger/) | Kombinieren vollständiger Präsentationsdateien desselben Formats. |
| [ForEach](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/foreach/) | Ausführen einer Aktion für jede Folie, jedes Shape, jeden Absatz oder Textabschnitt. |
| [Collect](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/collect/) | Abrufen von Shapes aus der gesamten Präsentation für wiederholte Verarbeitung oder Analyse. |
| [Compress](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/) | Entfernen ungenutzter Master und Layouts sowie Reduzieren eingebetteter Schriftartdaten. |

## **Präsentation konvertieren**

Verwenden Sie [Convert::AutoByExtension](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/convert/autobyextension/), wenn die Dateierweiterung des Ausgabedokuments ausreicht, um das Exportformat auszuwählen. Die Methode öffnet die Quellpräsentation, ermittelt das erforderliche Format aus dem Ausgabepfad und schreibt das Ergebnis.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

Die [Convert](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/convert/)‑Klasse bietet außerdem dedizierte Methoden für PDF, SVG, JPEG, PNG und TIFF. Verwenden Sie das vollständige Objektmodell, wenn Sie die Präsentation vor dem Export inspizieren oder ändern oder eine Export‑Option konfigurieren müssen, die vom jeweiligen Helfer nicht bereitgestellt wird. Siehe [Convert Presentation](/slides/de/cpp/convert-presentation/) für format‑spezifische Workflows und Optionen.

## **Präsentationen zusammenführen**

Verwenden Sie [Merger::Process](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/merger/process/), um komplette Präsentationsdateien mit einem Aufruf zu kombinieren. Die Eingabedateien müssen dasselbe Dateiformat besitzen.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

Der Helfer ist geeignet, wenn alle Folien zu einem Ergebnis hinzugefügt werden sollen, ohne sie einzeln auszuwählen oder neu zuzuordnen. Verwenden Sie das vollständige Objektmodell, wenn Sie ausgewählte Folien zusammenführen, einen Ziel‑Master oder -Layout anwenden, Abschnitte explizit erhalten oder unterschiedliche Foliengrößen abgleichen müssen. Siehe [Merge Presentations](/slides/de/cpp/merge-presentation/) für diese Szenarien.

## **Durch Präsentationselemente iterieren**

Die [ForEach](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/foreach/)‑Klasse ruft einen Rückruf für jeden angeforderten Typ von Präsentationselement auf. Sie vermeidet verschachtelte Schleifen über Sammlungen und eignet sich für prüfungen- oder formatierungsänderungen auf Präsentationsebene.

Das folgende Beispiel verwendet [ForEach::Slide](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/foreach/paragraph/) und [ForEach::Portion](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/foreach/portion/), um die entsprechenden Elemente zu inspizieren:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

Standardmäßig umfasst die traversal über Shapes und Text die normalen, Master‑ und Layout‑Folien. Überladungen mit einem `includeNotes`‑Parameter können zusätzlich Notizfolien verarbeiten. Verwenden Sie direkte Schleifen, wenn die Traversal‑Reihenfolge, ein vorzeitiger Abbruch, Filterung vor dem Rückruf oder eine detaillierte Eltern‑Kind‑Steuerung wichtig sind.

## **Shapes sammeln**

Verwenden Sie [Collect::Shapes](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/collect/shapes/), wenn Sie eine Sammlung aller Shapes in einer Präsentation benötigen, anstatt eines Rückrufs für jedes einzelne Shape. Dies ist nützlich, wenn dieselbe Menge mehrfach gefiltert, gezählt oder verarbeitet werden soll.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Verwenden Sie stattdessen [ForEach::Shape](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/foreach/shape/), wenn jedes Shape sofort verarbeitet werden kann und Sie das gesammelte Ergebnis nicht behalten müssen.

## **Präsentationsinhalt komprimieren**

Die [Compress](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/)‑Klasse kann ungenutzte Strukturelemente entfernen und eingebettete Schriftartdaten reduzieren:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) entfernt Layout‑Folien, auf die keine normale Folie verweist.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) entfernt Master‑Folien, die nicht mehr verwendet werden.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) entfernt ungenutzte Zeichen aus eingebetteten Schriftarten.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Entfernen Sie zuerst ungenutzte Layouts, bevor Sie ungenutzte Master entfernen, damit ein Master, der nach der Layout‑Aufräumung unreferenziert wird, ebenfalls gelöscht werden kann. Speichern Sie die optimierte Präsentation in einer neuen Datei, falls Sie die ursprünglichen Master, Layouts oder die vollständigen eingebetteten Schriftartdaten später benötigen. Weitere Details finden Sie unter [Slide Master](/slides/de/cpp/slide-master/) und [Embedded Font](/slides/de/cpp/embedded-font/).

## **FAQ**

**Wann sollte ich die Low‑Code‑API anstelle des vollständigen Objektmodells verwenden?**

Verwenden Sie Low‑Code‑Helfer, wenn ein Standardvorgang auf eine komplette Datei oder Präsentation zutrifft und keine detaillierte Kontrolle über einzelne Elemente erfordert. Verwenden Sie das vollständige Objektmodell, wenn Sie bestimmte Folien auswählen, Master‑ und Layout‑Beziehungen steuern, den Zwischenzustand inspizieren oder Verhalten konfigurieren müssen, das der Helfer nicht bereitstellt.

**Kann Merger Präsentationen in unterschiedlichen Dateiformaten kombinieren?**

Nein. [Merger::Process](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/merger/process/) erfordert Eingabedateien im selben Format. Konvertieren Sie die Eingabedateien zunächst in ein gemeinsames Format, zum Beispiel mit [Convert::AutoByExtension](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/convert/autobyextension/), und führen Sie anschließend die konvertierten Dateien zusammen.

**Verarbeitet ForEach Master‑, Layout‑ und Notizfolien?**

[ForEach::Slide](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/foreach/slide/) iteriert über normale Präsentationsfolien. Präsentationsweite [ForEach::Shape](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/foreach/paragraph/) und [ForEach::Portion](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/foreach/portion/) umfassen standardmäßig normale, Master‑ und Layout‑Folien. Verwenden Sie deren Überladungen mit `includeNotes` = `true`, um Notizfolien mit einzubeziehen.

**Was ist der Unterschied zwischen ForEach::Shape und Collect::Shapes?**

Verwenden Sie [ForEach::Shape](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/foreach/shape/), um jedes Shape sofort über einen Rückruf zu verarbeiten. Verwenden Sie [Collect::Shapes](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/collect/shapes/), wenn Sie ein aufzählbares Ergebnis benötigen, das behalten, gefiltert, gezählt oder mehrfach durchlaufen werden kann.

**Macht Compress immer die Präsentationsdatei kleiner?**

Nicht unbedingt. Das Ergebnis hängt davon ab, ob die Präsentation ungenutzte Layouts, ungenutzte Master oder eingebettete Schriftarten mit ungenutzten Zeichen enthält. Wenn keine dieser Bedingungen vorliegt, reduzieren die entsprechenden [Compress](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/)‑Operationen möglicherweise nicht die Dateigröße.

**Werden Änderungen, die durch ForEach oder Compress vorgenommen wurden, automatisch gespeichert?**

Nein. Diese Helfer arbeiten mit dem geladenen [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Objekt im Speicher. Nachdem Sie Elemente in einem [ForEach](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/foreach/)‑Rückruf geändert oder [Compress](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/) ausgeführt haben, rufen Sie [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/) auf, um das Ergebnis zu schreiben.

## **Verwandte Artikel**

- [Convert Presentation](/slides/de/cpp/convert-presentation/)
- [Merge Presentations](/slides/de/cpp/merge-presentation/)
- [Slide Master](/slides/de/cpp/slide-master/)
- [Manage Text Box](/slides/de/cpp/manage-textbox/)
- [Embedded Font](/slides/de/cpp/embedded-font/)