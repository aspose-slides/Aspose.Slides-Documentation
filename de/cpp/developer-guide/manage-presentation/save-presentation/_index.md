---
title: Präsentationen in C++ speichern
linktitle: Präsentation speichern
type: docs
weight: 80
url: /de/cpp/save-presentation/
keywords:
- PowerPoint speichern
- OpenDocument speichern
- Präsentation speichern
- Folie speichern
- PPT speichern
- PPTX speichern
- ODP speichern
- Präsentation in Datei
- Präsentation in Stream
- vordefinierter Ansichtstyp
- Strict Office Open XML-Format
- Zip64-Modus
- Thumbnail aktualisieren
- Speicherfortschritt
- C++
- Aspose.Slides
description: "Entdecken Sie, wie Sie Präsentationen in C++ mit Aspose.Slides speichern – Export nach PowerPoint oder OpenDocument bei gleichzeitiger Beibehaltung von Layouts, Schriftarten und Effekten."
---
## **Übersicht**

[Präsentationen in C++ öffnen](/slides/de/cpp/open-presentation/) beschreibt, wie die [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie man Präsentationen erstellt und speichert. Die [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse enthält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine vorhandene ändern, Sie möchten sie am Ende speichern. Mit Aspose.Slides für C++ können Sie in eine **Datei** oder **Stream** speichern. Dieser Artikel erläutert die verschiedenen Möglichkeiten, eine Präsentation zu speichern.

## **Präsentationen in Dateien speichern**

Speichern Sie eine Präsentation in einer Datei, indem Sie die `Save`-Methode der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse aufrufen. Übergeben Sie den Dateinamen und das Speicherformat an die Methode. Das folgende Beispiel zeigt, wie man mit Aspose.Slides eine Präsentation speichert.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Führen Sie hier einige Arbeiten aus...
// Speichern Sie die Präsentation in einer Datei.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Präsentationen in Streams speichern**

Sie können eine Präsentation in einen Stream speichern, indem Sie einen Ausgabestream an die `Save`-Methode der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse übergeben. Eine Präsentation kann in viele Stream‑Typen geschrieben werden. Im folgenden Beispiel erstellen wir eine neue Präsentation und speichern sie in einen Dateistream.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Speichern Sie die Präsentation im Stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Präsentationen mit vordefiniertem Ansichtstyp speichern**

Aspose.Slides ermöglicht es Ihnen, die anfängliche Ansicht festzulegen, die PowerPoint beim Öffnen der erzeugten Präsentation verwendet, über die Klasse [ViewProperties](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewproperties/). Verwenden Sie die Methode [set_LastView](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewproperties/set_lastview/) mit einem Wert aus der Aufzählung [ViewType](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewtype/).

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Präsentationen im Strict Office Open XML‑Format speichern**

Aspose.Slides ermöglicht das Speichern einer Präsentation im Strict Office Open XML‑Format. Verwenden Sie die Klasse [PptxOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pptxoptions/) und setzen Sie beim Speichern deren Conformance‑Eigenschaft. Wenn Sie `Conformance.Iso29500_2008_Strict` festlegen, wird die Ausgabedatei im Strict Office Open XML‑Format gespeichert.

Das folgende Beispiel erstellt eine Präsentation und speichert sie im Strict Office Open XML‑Format.

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>();

// Speichern Sie die Präsentation im Strict Office Open XML-Format.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Präsentationen im Office Open XML‑Format im Zip64‑Modus speichern**

Eine Office Open XML‑Datei ist ein ZIP‑Archiv, das Grenzen von 4 GB (2^32 Bytes) für die unkomprimierte Größe jeder Datei, die komprimierte Größe jeder Datei und die Gesamtgröße des Archivs festlegt und das Archiv auf 65 535 (2^16‑1) Dateien begrenzt. ZIP64‑Formatserweiterungen erhöhen diese Grenzen auf 2^64.

Die Methode [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) ermöglicht die Auswahl, wann ZIP64‑Formatserweiterungen beim Speichern einer Office Open XML‑Datei verwendet werden.

Diese Methode kann mit den folgenden Modi verwendet werden:

- `IfNecessary` verwendet ZIP64‑Formatserweiterungen nur, wenn die Präsentation die oben genannten Beschränkungen überschreitet. Dies ist der Standardmodus.
- `Never` verwendet ZIP64‑Formatserweiterungen nie.
- `Always` verwendet ZIP64‑Formatserweiterungen immer.

Der folgende Code demonstriert, wie man eine Präsentation als PPTX‑Datei mit aktivierten ZIP64‑Formatserweiterungen speichert:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Wenn Sie mit `Zip64Mode.Never` speichern, wird eine [PptxException](https://reference.aspose.com/slides/de/cpp/aspose.slides/pptxexception/) ausgelöst, wenn die Präsentation nicht im ZIP32‑Format gespeichert werden kann.
{{% /alert %}}

## **Präsentationen im Office Open XML‑Format mit Komprimierungsstufen speichern**

Bei großen Präsentationen können Sie die Komprimierungsstufe anpassen, um Größe und Verarbeitungszeit auszubalancieren. Je nach Anforderungen bevorzugen Sie möglicherweise schnellere Verarbeitung oder kleinere Ausgabedateien.

Aspose.Slides bietet die Methode [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/), mit der Sie die beim Speichern einer Präsentation im Office Open XML‑Format zu verwendende Komprimierungsstufe festlegen können.

Die folgenden Komprimierungsstufen stehen zur Verfügung:

- **None**: Keine Komprimierung wird angewendet. Dateien werden unverändert gespeichert.
- **Level1**: Schnellste Komprimierung mit dem niedrigsten Komprimierungsverhältnis.
- **Level2**: Schnellere Komprimierung mit etwas besserem Verhältnis als **Level1**.
- **Level3**: Bessere Komprimierung als **Level2** bei moderatem Einfluss auf die Verarbeitungszeit.
- **Level4**: Bessere Komprimierung als **Level3**.
- **Level5**: Verbesserte Komprimierung gegenüber **Level4** mit zusätzlicher Verarbeitungszeit.
- **Level6**: Standardkomprimierung, die ein gutes Gleichgewicht zwischen Verarbeitungsgeschwindigkeit und Dateigröße bietet. Dies ist die *Standardkomprimierungsstufe*.
- **Level7**: Bessere Komprimierung als **Level6** bei langsamerer Verarbeitung.
- **Level8**: Bessere Komprimierung als **Level7**.
- **Level9**: Maximale Komprimierung. Produziert die kleinste Dateigröße auf Kosten der längsten Verarbeitungszeit.

Das folgende Beispiel demonstriert, wie man eine Präsentation als PPTX‑Datei *ohne Komprimierung* speichert:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

Dieses Beispiel zeigt, wie man eine Präsentation als PPTX‑Datei mit *maximaler Komprimierung* speichert:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **Präsentationen ohne Aktualisierung des Thumbnails speichern**

Die Methode [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) steuert die Thumbnail‑Erstellung beim Speichern einer Präsentation als PPTX:

- Wenn sie auf `true` gesetzt ist, wird das Thumbnail während des Speichervorgangs aktualisiert. Dies ist der Standard.
- Wenn sie auf `false` gesetzt ist, bleibt das aktuelle Thumbnail erhalten. Hat die Präsentation kein Thumbnail, wird keines erzeugt.

Im nachfolgenden Code wird die Präsentation als PPTX gespeichert, ohne ihr Thumbnail zu aktualisieren.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Diese Option hilft, die zum Speichern einer Präsentation im PPTX‑Format benötigte Zeit zu reduzieren.
{{% /alert %}}

## **Speicherfortschritt in Prozent erhalten**

Das Interface [IProgressCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprogresscallback/) wird über die Methode `set_ProgressCallback` verwendet, die vom [ISaveOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/isaveoptions/) Interface und der abstrakten Klasse [SaveOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveoptions/) bereitgestellt wird. Weisen Sie mit `set_ProgressCallback` eine Implementierung von [IProgressCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprogresscallback/) zu, um Fortschritts‑Updates beim Speichern als Prozentsatz zu erhalten.

Die folgenden Code‑Snippets zeigen, wie `IProgressCallback` verwendet wird.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // Verwenden Sie hier den prozentualen Fortschrittswert.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Die oben definierte Fortschritts-Callback-Klasse.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose hat eine [kostenlose PowerPoint‑Splitter‑App](https://products.aspose.app/slides/de/splitter) basierend auf seiner eigenen API entwickelt. Die App ermöglicht es, eine Präsentation in mehrere Dateien zu teilen, indem ausgewählte Folien als neue PPTX‑ oder PPT‑Dateien gespeichert werden.
{{% /alert %}}

## **FAQ**

**Unterstützt „schnelles Speichern“ (inkrementelles Speichern), sodass nur Änderungen geschrieben werden?**

Nein. Beim Speichern wird jedes Mal die komplette Zieldatei erzeugt; inkrementelles „schnelles Speichern“ wird nicht unterstützt.

**Ist es threadsicher, dieselbe Presentation‑Instanz aus mehreren Threads zu speichern?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Instanz ist [nicht threadsicher](/slides/de/cpp/multithreading/); speichern Sie sie aus einem einzelnen Thread.

**Was passiert mit Hyperlinks und extern verknüpften Dateien beim Speichern?**

[Hyperlinks](/slides/de/cpp/manage-hyperlinks/) bleiben erhalten. Extern verknüpfte Dateien (z. B. Videos über relative Pfade) werden nicht automatisch kopiert – stellen Sie sicher, dass die referenzierten Pfade weiterhin zugänglich sind.

**Kann ich Dokument‑Metadaten (Autor, Titel, Unternehmen, Datum) festlegen/speichern?**

Ja. Standard‑[Dokumenteneigenschaften](/slides/de/cpp/presentation-properties/) werden unterstützt und beim Speichern in die Datei geschrieben.