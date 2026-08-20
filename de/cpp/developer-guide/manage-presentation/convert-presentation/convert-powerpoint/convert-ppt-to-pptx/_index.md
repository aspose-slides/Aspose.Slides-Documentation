---
title: PPT zu PPTX in C++ konvertieren
linktitle: PPT zu PPTX
type: docs
weight: 20
url: /de/cpp/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
- PPT konvertieren
- PPT zu PPTX
- PPT als PPTX speichern
- PPT nach PPTX exportieren
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Konvertieren Sie Legacy-PPT-Dateien in PPTX in C++ mit Aspose.Slides. Enthält C++-Beispiele für Einzel-Datei- und Batch-Konvertierung, Fehlerbehandlung und Genauigkeits-Hinweise."
---
## **Übersicht**

PPT ist das veraltete binäre PowerPoint‑Format, während PPTX das neuere Open XML‑Format ist. Aspose.Slides für C++ kann eine PPT‑Datei laden und sie ohne Microsoft PowerPoint als PPTX speichern. Dieser Artikel zeigt, wie man eine einzelne Datei oder ein Verzeichnis von Dateien konvertiert und erklärt, was nach der Konvertierung zu überprüfen ist.

## **Eine PPT‑Datei in PPTX konvertieren**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) , dann rufen Sie [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/) mit [SaveFormat::Pptx](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/) auf. Entsorgen Sie das Präsentationsobjekt, sobald es nicht mehr benötigt wird, um seine Ressourcen freizugeben.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Die Dateierweiterung wählt das Ausgabeformat nicht automatisch aus; das Argument [SaveFormat::Pptx](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/) tut es. Halten Sie Eingabe‑ und Ausgabe‑Pfad unterschiedlich, wenn Sie die ursprüngliche PPT‑Datei beibehalten müssen.

## **Mehrere PPT‑Dateien konvertieren**

Das folgende Beispiel konvertiert jede `.ppt`‑Datei in einem Verzeichnis. Jede Datei wird unabhängig verarbeitet, sodass ein fehlgeschlagener Konvertierungsvorgang den Rest des Stapels nicht stoppt.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

Für produktive Arbeitslasten protokollieren Sie die vollständige Ausnahme, entscheiden Sie, ob eine vorhandene Ausgabedatei überschrieben werden darf, und schreiben Sie fehlgeschlagene Dateinamen in eine Wiederhol‑ oder Prüfschlange. Beschädigte Dateien, passwortgeschützte Dateien, die ohne das erforderliche Passwort geöffnet wurden, nicht zugängliche Pfade und nicht unterstützte Inhalte können alle zu einem Fehlversagen der Konvertierung führen. Siehe [Password-Protected Presentations](/cpp/password-protected-presentation/) zum Laden verschlüsselter Dateien.

## **Genauigkeit und Legacy‑Funktionen**

Die Konvertierung erhält normalerweise Folien, Folienmaster, Layouts, Text, Formen, Bilder, Tabellen und Diagramme. PPT und PPTX repräsentieren jedoch nicht jedes Feature exakt gleich. Ein Legacy‑Feature, das kein PPTX‑Äquivalent hat oder von der Bibliothek nicht unterstützt wird, kann normalisiert, weggelassen oder anders dargestellt werden.

Überprüfen Sie die konvertierte Datei, wenn sie Animationen, Übergänge, eingebettete oder verknüpfte OLE‑Objekte, ActiveX‑Steuerelemente, eingebettete Medien, ungewöhnliche Schriften oder VBA‑Makros enthält. Eine reine PPTX‑Datei ist kein makrofähiges Format, verwenden Sie daher einen geeigneten makrofähigen Workflow, wenn VBA erhalten bleiben muss. Vergewissern Sie sich außerdem, dass erforderliche Schriften und externe Ressourcen in der Umgebung vorhanden sind, in der die konvertierte Präsentation geöffnet oder gerendert wird.

Für wichtige Dokumente öffnen Sie das erzeugte PPTX programmgesteuert erneut, prüfen Sie die wichtigsten Folienzahlen und Inhalte und vergleichen Sie anschließend das Erscheinungsbild und das Folien‑Show‑Verhalten im gewünschten Viewer. Betrachten Sie einen erfolgreichen Aufruf von [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/) nicht als Beweis dafür, dass jedes Legacy‑Feature eine exakte PPTX‑Darstellung hat.

## **Wann PPTX verwenden**

Verwenden Sie PPTX, wenn die Präsentation in aktuellen PowerPoint‑Versionen bearbeitet, mit Systemen ausgetauscht wird, die mit Open‑XML‑Paketen arbeiten, oder in einem Format gespeichert werden soll, das einfacher zu prüfen und wiederherzustellen ist als das alte binäre PPT. Bewahren Sie das ursprüngliche PPT als Archiv‑ oder Rücklaufkopie auf, bis die konvertierte Präsentation Ihre Genauigkeitsprüfungen bestanden hat.

Falls Sie stattdessen PDF, HTML, Bilder, XPS oder einen anderen Ausgabetyp benötigen, nutzen Sie die formatbezogene Anleitung in [Convert Presentations to Multiple Formats](/cpp/convert-presentation/) anstatt anzunehmen, dass alle Ziele bearbeitbare PowerPoint‑Features erhalten.

## **Online‑Konverter**

Für eine gelegentliche Datei oder einen schnellen Vergleich können Sie den [online PPT to PPTX converter](https://products.aspose.app/slides/de/conversion/ppt-to-pptx) verwenden. Für wiederholbare Konvertierungen, Stapelverarbeitung oder anwendungsbezogene Fehlerbehandlung nutzen Sie die C++‑API.

## **Verwandte Artikel**

- [Präsentationen in C++ speichern](/cpp/save-presentation/)
- [Unterstützte Dateiformate](/cpp/supported-file-formats/)
- [Präsentationen in C++ öffnen](/cpp/open-presentation/)

## **FAQ**

**Kann ich PPT nach PPTX konvertieren, ohne dass Microsoft PowerPoint installiert ist?**

Ja. Aspose.Slides für C++ lädt und speichert Präsentationsdateien, ohne Microsoft PowerPoint zu benötigen.

**Wird die PPT‑zu‑PPTX‑Konvertierung den gesamten Inhalt exakt erhalten?**

Sie erhält gängige Präsentationsinhalte, aber die exakte Treue ist nicht für jedes Legacy‑ oder nicht unterstützte Feature garantiert. Prüfen Sie die erzeugte Datei, wenn sie Makros, OLE‑ oder ActiveX‑Objekte, Medien, spezialisierte Animationen oder ungewöhnliche Schriften enthält.

**Kann ich eine passwortgeschützte PPT‑Datei konvertieren?**

Ja, wenn Sie beim Laden der Datei das korrekte Passwort angeben. Ein fehlendes oder falsches Passwort führt dazu, dass der Ladevorgang fehlschlägt.

**Sollte ich die PPT‑Datei nach der Konvertierung löschen?**

Behalten Sie das Original, bis Sie das PPTX in den für Sie relevanten Viewern und Workflows überprüft haben. Dies bietet eine Rücklaufkopie, falls ein Legacy‑Feature anders konvertiert wird.