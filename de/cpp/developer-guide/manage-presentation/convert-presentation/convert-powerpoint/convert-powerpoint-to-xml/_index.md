---
title: PowerPoint-Präsentationen nach XML konvertieren in C++
linktitle: PowerPoint zu XML
type: docs
weight: 145
url: /de/cpp/convert-powerpoint-to-xml/
keywords:
- PowerPoint in XML konvertieren
- Präsentation in XML konvertieren
- PPT nach XML
- PPTX nach XML
- ODP nach XML
- PowerPoint XML-Präsentation
- SaveFormat::Xml
- Präsentation als XML speichern
- Präsentation nach XML exportieren
- XML-Stream
- C++
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Präsentationen in PowerPoint XML-Dateien oder -Streams in C++ mit Aspose.Slides für C++."
---
## **Übersicht**

Aspose.Slides for C++ kann PowerPoint‑Präsentationen in das PowerPoint XML Presentation‑Format konvertieren. XML‑Ausgabe ist nützlich, wenn Sie eine textbasierte Darstellung benötigen, um die Präsentationsstruktur zu untersuchen, generierte Dokumente zu Fehlersuchen, Ausgaben in automatisierten Tests zu vergleichen oder in einen Workflow zu integrieren, der XML anstelle eines Präsentationspakets verbraucht.

Verwenden Sie die [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/)‑Methode mit dem `Xml`‑Wert aus der [SaveFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/)‑Aufzählung. Sie können das Ergebnis direkt in eine Datei oder in einen Stream schreiben.

{{% alert color="info" title="Hinweis" %}}
`SaveFormat::Xml` erzeugt ein PowerPoint XML Presentation. Es extrahiert nicht die einzelnen Office Open XML‑Teile, die in einem PPTX‑Paket gespeichert sind. Wenn Sie die genauen PPTX‑Paket‑Teile benötigen, wie `ppt/presentation.xml` oder einzelne Folien‑XML‑Dateien, untersuchen Sie das PPTX‑Paket selbst.
{{% /alert %}}

## **Eine Präsentation in eine XML‑Datei konvertieren**

Laden Sie eine Quellpräsentation mit der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse und übergeben Sie dann den Ausgabepfad und `SaveFormat::Xml` an [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/). Die Quelle kann jedes von Aspose.Slides unterstützte Präsentationsformat sein, z. B. PPT, PPTX oder ODP.

Das folgende Beispiel konvertiert eine PPTX‑Präsentation in eine XML‑Datei:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **XML‑Ausgabe in einen Stream schreiben**

Verwenden Sie die Stream‑Überladung von [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/), wenn das XML im Speicher bleiben oder an eine andere Komponente, wie einen Web‑Dienst, Speicher‑Provider oder eine XML‑Verarbeitungspipeline, übergeben werden soll. Das folgende Beispiel schreibt das Ergebnis in einen [MemoryStream](https://reference.aspose.com/slides/de/cpp/system.io/memorystream/) und spult ihn für ein anschließendes Lesen zurück:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// Übergeben Sie xmlStream an die nächste Komponente im Workflow.
```

## **XML mit Präsentations‑ und Exportformaten vergleichen**

Wählen Sie das Ausgabformat entsprechend der geplanten Nutzung:

| Format | Ausgabe | Typische Verwendung |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Eine PowerPoint XML Presentation | Untersuchung der Struktur, Fehlersuche, Vergleich generierter Ausgaben und XML‑basierte Integration |
| PPT (`.ppt`) | Eine Legacy‑Binärpräsentationsdatei | Kompatibilität mit älteren PowerPoint‑Workflows |
| PPTX (`.pptx`) | Ein Office Open XML‑Paket mit mehreren Teilen | Regelmäßige PowerPoint‑Bearbeitung und Präsentationsaustausch |
| PDF oder TIFF | Fest‑Layout‑Seiten oder ein mehrseitiges Bild | Anzeige, Druck und Archivierung |
| PNG, JPEG oder SVG | Eine gerenderte Darstellung einer einzelnen Folie | Miniaturansichten, Vorschauen und Bild‑Assets |
| HTML oder HTML5 | Web‑orientierte Präsentationsausgabe | Browseranzeige und Web‑Veröffentlichung |

Im Gegensatz zu PPT und PPTX ist die XML‑Ausgabe hauptsächlich für Inspektion und datenorientierte Workflows gedacht. Im Gegensatz zu PDF, TIFF, HTML und Folien‑Bildformaten stellt sie Präsentationsdaten dar, anstatt Folien als Seiten oder visuelle Assets zu rendern. Die Tabelle der [supported file formats](/slides/de/cpp/supported-file-formats/) führt PowerPoint XML Presentation als reines Speicherformat auf; verwenden Sie sie nicht, wenn ein Workflow die exportierte Datei wieder in Aspose.Slides laden muss, um weiter zu bearbeiten.

## **FAQ**

**Ist `SaveFormat::Xml` dasselbe wie das Speichern einer PPTX‑Datei?**

Nein. PPTX ist ein Paket, das mehrere Office Open XML‑Teile enthält, während `SaveFormat::Xml` eine PowerPoint XML Presentation‑Datei erzeugt.

**Kann ich die XML‑Ausgabe speichern, ohne eine Datei auf Festplatte zu erstellen?**

Ja. Übergeben Sie einen beschreibbaren Stream an [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/). Verwenden Sie beispielsweise einen [MemoryStream](https://reference.aspose.com/slides/de/cpp/system.io/memorystream/) für die In‑Memory‑Verarbeitung.

**Kann Aspose.Slides die exportierte XML‑Datei erneut laden?**

Nein. PowerPoint XML Presentation wird derzeit nur zum Speichern unterstützt, nicht zum Laden. Verwenden Sie PPTX oder ein anderes unterstütztes Präsentationsformat, wenn ein Round‑Trip‑Editing erforderlich ist.

**Wandelt die XML‑Konvertierung jede Folie in eine Seite oder ein Bild um?**

Nein. Die XML‑Konvertierung schreibt strukturierte Präsentationsdaten. Verwenden Sie PDF oder TIFF für seitenorientierte Ausgaben oder PNG, JPEG und SVG für einzelne Folien‑Bilder.