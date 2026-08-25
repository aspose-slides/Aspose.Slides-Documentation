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
description: "Konvertieren Sie Legacy-PPT-Dateien zu PPTX in C++ mit Aspose.Slides. Enthält C++-Beispiele für Einzeldatei- und Batch-Konvertierung, Fehlerbehandlung und Genauigkeits-Hinweise."
---
## **Übersicht**

PPT ist das ältere binäre PowerPoint-Format, während PPTX das neuere Open‑XML‑Format ist. Aspose.Slides für C++ kann eine PPT‑Datei laden und sie ohne Microsoft PowerPoint als PPTX speichern. Dieser Artikel zeigt, wie man eine einzelne Datei oder ein Verzeichnis von Dateien konvertiert und erklärt, was nach der Konvertierung zu überprüfen ist.

## **Konvertieren einer PPT‑Datei zu PPTX**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/), und rufen Sie dann [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/) mit dem Argument [SaveFormat::Pptx](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/) auf. Entsorgen Sie die Präsentation, sobald sie nicht mehr benötigt wird, um ihre Ressourcen freizugeben.

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

Die Dateierweiterung bestimmt das Ausgabeformat nicht; das Argument [SaveFormat::Pptx](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/) tut es. Verwenden Sie unterschiedliche Eingabe‑ und Ausgabepfade, wenn Sie die ursprüngliche PPT‑Datei behalten möchten.

## **Konvertieren mehrerer PPT‑Dateien**

Das folgende Beispiel konvertiert jede `.ppt`‑Datei in einem Verzeichnis. Jede Datei wird unabhängig verarbeitet, sodass ein fehlgeschlagener Vorgang den Rest des Stapels nicht stoppt.

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

Für produktive Workloads sollten Sie die vollständige Ausnahme protokollieren, entscheiden, ob eine vorhandene Ausgabedatei überschrieben werden darf, und fehlgeschlagene Dateinamen in eine Wiederholungs‑ oder Prüfungswarteschlange schreiben. Beschädigte Dateien, passwortgeschützte Dateien, die ohne das erforderliche Passwort geöffnet werden, nicht erreichbare Pfade und nicht unterstützte Inhalte können die Konvertierung zum Scheitern bringen. Siehe [Password‑Protected Presentations](/slides/de/cpp/password-protected-presentation/) zum Laden verschlüsselter Dateien.

## **Genauigkeit und Legacy‑Funktionen**

Die Konvertierung bewahrt normalerweise Folien, Master, Layouts, Text, Formen, Bilder, Tabellen und Diagramme. PPT und PPTX repräsentieren jedoch nicht jedes Feature exakt auf dieselbe Weise. Ein Legacy‑Feature, das kein PPTX‑Äquivalent hat oder von der Bibliothek nicht unterstützt wird, kann normalisiert, weggelassen oder anders dargestellt werden.

Überprüfen Sie die konvertierte Datei, wenn sie Animationen, Übergänge, eingebettete oder verknüpfte OLE‑Objekte, ActiveX‑Steuerelemente, eingebettete Medien, seltene Schriften oder VBA‑Makros enthält. Eine reine PPTX‑Datei ist kein makrofähiges Format; verwenden Sie daher einen geeigneten makrofähigen Workflow, wenn VBA erhalten bleiben muss. Stellen Sie außerdem sicher, dass erforderliche Schriften und externe Ressourcen in der Umgebung vorhanden sind, in der die konvertierte Präsentation geöffnet oder gerendert wird.

Für wichtige Dokumente öffnen Sie das erzeugte PPTX programmgesteuert erneut, prüfen Sie wichtige Folienzahlen und Inhalte und vergleichen Sie anschließend Aussehen und Bildlaufverhalten im gewünschten Viewer. Betrachten Sie einen erfolgreichen Aufruf von [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/) nicht als Beweis dafür, dass jedes Legacy‑Feature eine exakte PPTX‑Darstellung besitzt.

## **Wann PPTX verwenden**

Verwenden Sie PPTX, wenn die Präsentation in aktuellen PowerPoint‑Versionen bearbeitet, mit Systemen ausgetauscht wird, die Open‑XML‑Pakete verarbeiten, oder in einem Format gespeichert werden soll, das leichter zu inspizieren und wiederherzustellen ist als das alte binäre PPT. Bewahren Sie das ursprüngliche PPT als Archiv‑ oder Rückfallkopie auf, bis die konvertierte Präsentation Ihre Genauigkeitsprüfungen bestanden hat.

Falls Sie stattdessen PDF, HTML, Bilder, XPS oder ein anderes Ausgabeformat benötigen, nutzen Sie die formatbezogene Anleitung in [Convert Presentations to Multiple Formats](/slides/de/cpp/convert-presentation/) und gehen Sie nicht davon aus, dass alle Ziele editierbare PowerPoint‑Features erhalten.

## **Online‑Konverter**

Für eine einzelne Datei oder einen schnellen Vergleich können Sie den [online PPT to PPTX converter](https://products.aspose.app/slides/de/conversion/ppt-to-pptx) verwenden. Für wiederholbare Konvertierungen, Batch‑Verarbeitung oder fehlerbehaftete Anwendungslogik nutzen Sie die C++‑API.

## **Verwandte Artikel**

- [Save Presentations in C++](/slides/de/cpp/save-presentation/)
- [Supported File Formats](/slides/de/cpp/supported-file-formats/)
- [Open Presentations in C++](/slides/de/cpp/open-presentation/)

## **FAQ**

**Kann ich PPT zu PPTX konvertieren, ohne Microsoft PowerPoint installiert zu haben?**

Ja. Aspose.Slides für C++ lädt und speichert Präsentationsdateien, ohne dass Microsoft PowerPoint erforderlich ist.

**Wird die PPT‑zu‑PPTX‑Konvertierung sämtliche Inhalte exakt erhalten?**

Sie erhält die gängigen Präsentationsinhalte, jedoch ist eine exakte Treue für jedes Legacy‑ oder nicht unterstützte Feature nicht garantiert. Überprüfen Sie die erzeugte Datei, wenn sie Makros, OLE‑ oder ActiveX‑Objekte, Medien, spezialisierte Animationen oder seltene Schriften enthält.

**Kann ich eine passwortgeschützte PPT‑Datei konvertieren?**

Ja, sofern Sie beim Laden das korrekte Passwort angeben. Ein fehlendes oder falsches Passwort führt zum Fehlschlag des Ladevorgangs.

**Sollte ich die PPT‑Datei nach der Konvertierung löschen?**

Bewahren Sie das Original auf, bis Sie das PPTX in den relevanten Viewern und Workflows geprüft haben. So haben Sie eine Rückfallkopie, falls ein Legacy‑Feature anders konvertiert wird.