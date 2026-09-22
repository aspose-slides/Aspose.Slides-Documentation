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
- Striktes Office Open XML-Format
- Zip64-Modus
- Vorschaubild aktualisieren
- Speicherfortschritt
- C++
- Aspose.Slides
description: "PowerPoint- und OpenDocument‑Präsentationen in C++ mit Aspose.Slides in Dateien oder Streams speichern und die PPTX‑Ausgabe sowie die Fortschrittsanzeige konfigurieren."
---
## **Übersicht**

Nachdem Sie eine Präsentation erstellt oder [eine vorhandene geöffnet](/slides/de/cpp/open-presentation/), verwenden Sie die [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/) Methode, um das Ergebnis zu schreiben. Aspose.Slides für C++ kann eine Präsentation in eine Datei oder einen Stream in PowerPoint, OpenDocument, PDF und anderen Formaten speichern. Die folgenden Abschnitte behandeln die Standard‑Speichervorgänge und die für PPTX‑Ausgabe verfügbaren Optionen.

## **Präsentationen in Dateien speichern**

Um eine Präsentation in einer Datei zu speichern, übergeben Sie den Ausgabepfad und einen [SaveFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/) Wert an die [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/) Methode. Der Formatwert bestimmt den Dateityp, den Aspose.Slides erstellt.

Das folgende Beispiel erstellt eine Präsentation und speichert sie als PPTX‑Datei:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Fügen Sie hier Präsentationsinhalt hinzu oder ändern Sie ihn.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Präsentationen im Originalformat speichern**

Für Beispiele zur Datei‑ und Stream‑Erkennung, zum Verhalten neu erstellter Präsentationen und zur Unterscheidung zwischen Quell‑ und Ausgabeformaten siehe [Determine the Original Presentation Format](/slides/de/cpp/detect-presentation-source-format/).

In einer Stapelverarbeitungs‑Anwendung ist das Eingabeformat möglicherweise im Voraus nicht bekannt. Nach dem Laden einer Datei lesen Sie das Originalformat mit [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_sourceformat/). Übergeben Sie den resultierenden [SourceFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/sourceformat/) Wert an [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides.util/slideutil/tosaveformat/), um den entsprechenden [SaveFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/) Wert zu erhalten, und verwenden Sie anschließend [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/), um die modifizierte Präsentation zu schreiben.

Das folgende vollständige Beispiel verarbeitet jede Datei in einem Eingabeverzeichnis, aktualisiert deren Titel und speichert sie in ein Ausgabeverzeichnis im Format, aus dem sie geladen wurde:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides.util/slideutil/tosaveformat/) mappt PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP und PowerPoint‑XML zu den entsprechenden Speicherformaten der Präsentation. Es mappt nur Präsentations‑Quellformate; es ist nicht dazu gedacht, Exportformate wie PDF, HTML, TIFF oder Bilder auszuwählen. Das Übergeben eines nicht unterstützten oder ungültigen [SourceFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/sourceformat/) Wertes führt zu einer [ArgumentException](https://reference.aspose.com/slides/de/cpp/system/argumentexception/).

Legacy‑PPT-, PPS- und POT‑Dateien verwenden denselben Binärcontainer. Wenn eine solche Präsentation aus einem Stream ohne Dateierweiterung geladen wird, kann eine PPS‑ oder POT‑Datei daher als PPT identifiziert werden. Wenn die Beibehaltung dieser Legacy‑Untertypen erforderlich ist, bewahren Sie den ursprünglichen Dateinamen oder die Format‑Metadaten separat auf und verwenden Sie diese bei der Auswahl von Ausgabedateinamen und -format.

## **Präsentationen in Streams speichern**

Um eine Präsentation zu schreiben, ohne sich auf einen endgültigen Dateipfad zu verlassen, übergeben Sie einen beschreibbaren [Stream](https://reference.aspose.com/slides/de/cpp/system.io/stream/) und einen [SaveFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/) Wert an die [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/) Methode. Dieser Ansatz ist nützlich, wenn die Ausgabe von einem Web‑Service zurückgegeben, in einer Datenbank gespeichert oder im Speicher verarbeitet werden muss.

Das folgende Beispiel speichert eine neue Präsentation in einen Dateistream:

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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Präsentationen mit einem vordefinierten Ansichtstyp speichern**

Sie können die Ansicht festlegen, in der PowerPoint eine gespeicherte Präsentation zunächst öffnet. Rufen Sie vor dem Speichern [ViewProperties::set_LastView](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewproperties/set_lastview/) mit einem [ViewType](https://reference.aspose.com/slides/de/cpp/aspose.slides/viewtype/) Wert auf.

Das folgende Beispiel konfiguriert die Folienmaster‑Ansicht als Anfangsansicht:

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

## **Präsentationen im strikten Office Open XML‑Format speichern**

Um eine PPTX‑Datei zu erstellen, die dem Strict‑Profil von Office Open XML entspricht, erzeugen Sie eine Instanz von [PptxOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pptxoptions/) und rufen Sie [PptxOptions::set_Conformance](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pptxoptions/set_conformance/) mit `Conformance::Iso29500_2008_Strict` auf. Übergeben Sie anschließend die Optionen an die [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/) Methode.

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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Präsentationen im Office Open XML‑Format im Zip64‑Modus speichern**

Ein standardmäßiges ZIP‑Archiv begrenzt die komprimierte und unkomprimierte Größe jedes Eintrags, die Gesamtarbeitsspeichergröße des Archivs und die Anzahl der Einträge. Da eine PPTX‑Datei ein ZIP‑Archiv ist, kann eine sehr große Präsentation diese Grenzen überschreiten. ZIP64‑Erweiterungen erhöhen die geltenden Größen‑ und Eintragsanzahl‑Grenzen.

Verwenden Sie [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pptxoptions/set_zip64mode/), um zu steuern, ob Aspose.Slides ZIP64‑Erweiterungen schreibt:

- `IfNecessary` verwendet ZIP64 nur, wenn die Präsentation die Standard‑ZIP‑Grenzen überschreitet. Dies ist der Standardmodus.
- `Never` deaktiviert ZIP64‑Erweiterungen.
- `Always` schreibt immer ZIP64‑Erweiterungen.

Das folgende Beispiel aktiviert ZIP64‑Erweiterungen für die Ausgabepäsentation immer:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
Wenn `Zip64Mode` auf `Never` gesetzt ist und die Präsentation nicht in die standardmäßigen ZIP‑Grenzen passt, wirft der Speicher­vorgang eine [PptxException](https://reference.aspose.com/slides/de/cpp/aspose.slides/pptxexception/).
{{% /alert %}}

## **Präsentationen im Office Open XML‑Format mit Kompressionsstufen speichern**

Für PPTX‑Ausgabe können Sie die Speichergeschwindigkeit gegenüber der Dateigröße ausbalancieren, indem Sie [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) aufrufen. Die Aufzählung [CompressionLevel](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/compressionlevel/) liefert die folgenden Werte:

- `None` speichert Daten ohne Kompression.
- `Level1` bietet die schnellste Kompression und die größte komprimierte Ausgabe.
- `Level2` bis `Level5` bevorzugen zunehmend kleinere Ausgaben gegenüber der Speichergeschwindigkeit.
- `Level6` balanciert Speichergeschwindigkeit und Dateigröße. Dies ist die Standardstufe.
- `Level7` und `Level8` bevorzugen noch stärker kleinere Ausgaben gegenüber der Speichergeschwindigkeit.
- `Level9` bietet die stärkste Kompression und erfordert die meiste Verarbeitungszeit.

Das folgende Beispiel speichert eine Präsentation ohne Kompression:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

Das folgende Beispiel verwendet die maximale Kompressionsstufe:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Präsentationen ohne Aktualisierung des Vorschaubilds speichern**

Wenn eine Präsentation als PPTX gespeichert wird, steuert [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) ihr Dokumentenvorschaubild:

- `true` regeneriert das Vorschaubild während des Speicher­vorgangs. Dies ist der Standardwert.
- `false` bewahrt das vorhandene Vorschaubild. Hat die Präsentation kein Vorschaubild, erzeugt Aspose.Slides keins.

Das folgende Beispiel speichert eine Präsentation, ohne ihr Vorschaubild zu aktualisieren:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Das Deaktivieren der Vorschaubild‑Aktualisierung kann die zum Speichern einer PPTX‑Datei benötigte Zeit verringern.
{{% /alert %}}

## **Speicher‑Fortschritts‑Updates in Prozent**

Um einen Speicher­vorgang zu überwachen, implementieren Sie die [IProgressCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprogresscallback/) Schnittstelle und übergeben die Implementierung an [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). Aspose.Slides ruft dann [IProgressCallback::Reporting](https://reference.aspose.com/slides/de/cpp/aspose.slides/iprogresscallback/reporting/) mit Fortschrittswerten während des Exports auf.

Das folgende Beispiel meldet den Fortschritt eines PDF‑Exports auf der Konsole:

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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose stellt einen kostenlosen [PowerPoint Splitter](https://products.aspose.app/slides/de/splitter) bereit, der mit der Aspose.Slides‑API gebaut ist. Er speichert ausgewählte Folien einer Präsentation als separate PPT‑ oder PPTX‑Dateien.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides inkrementelles oder „schnelles Speichern“?**

Nein. Jeder Speicher­vorgang schreibt eine komplette Ausgabedatei, anstatt nur die geänderten Teile zu aktualisieren.

**Können mehrere Threads dieselbe Presentation‑Instanz speichern?**

Nein. Eine [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Instanz ist nicht threadsicher. Greifen Sie jeweils nur von einem Thread auf eine Instanz zu und speichern Sie sie.

**Was passiert mit Hyperlinks und extern verknüpften Dateien, wenn ich eine Präsentation speichere?**

[Hyperlinks](/slides/de/cpp/manage-hyperlinks/) bleiben in der Präsentation erhalten. Aspose.Slides kopiert keine extern verknüpften Dateien, sodass die gespeicherte Präsentation weiterhin auf deren Speicherorte zugreifen können muss.

**Kann ich Dokument‑Metadaten wie Autor, Titel, Firma und Erstellungsdatum speichern?**

Ja. Setzen Sie vor dem Speichern die entsprechenden [document properties](/slides/de/cpp/presentation-properties/), und Aspose.Slides schreibt sie in die Ausgabedatei.