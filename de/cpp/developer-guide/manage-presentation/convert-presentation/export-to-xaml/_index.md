---
title: Präsentationen nach XAML in C++ exportieren
linktitle: Präsentation nach XAML
type: docs
weight: 30
url: /de/cpp/export-to-xaml/
keywords:
- PowerPoint exportieren
- OpenDocument exportieren
- Präsentation exportieren
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- PowerPoint nach XAML
- OpenDocument nach XAML
- Präsentation nach XAML
- PPT nach XAML
- PPTX nach XAML
- ODP nach XAML
- PPT als XAML speichern
- PPTX als XAML speichern
- ODP als XAML speichern
- PPT nach XAML exportieren
- PPTX nach XAML exportieren
- ODP nach XAML exportieren
- C++
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Folien in C++ mit Aspose.Slides nach XAML konvertieren -- schnelle, Office-freie Lösung, die das Layout unverändert beibehält."
---
## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen mit Aspose.Slides nach XAML exportiert. Er enthält eine kurze Einführung in XAML, zeigt, wie man eine Präsentation mit Standardeinstellungen nach XAML speichert, und demonstriert, wie man den Export über [XamlOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export.xaml/xamloptions/), einschließlich des Exports versteckter Folien, anpasst. Der Artikel beantwortet außerdem einige häufige Fragen zu Ersatzschriften, XAML‑Stack‑Kompatibilität und dem Verhalten beim Export versteckter Folien.

## **Über XAML**

XAML ist eine XML‑basierte Auszeichnungssprache, die verwendet wird, um Benutzeroberflächen in Frameworks wie WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) und Xamarin.Forms zu beschreiben.

Sie können mit XAML‑Dateien in einem visuellen Designer arbeiten oder die Auszeichnung direkt schreiben und bearbeiten.

## **Präsentationen mit Standardeinstellungen nach XAML exportieren**

Das folgende C++‑Beispiel zeigt, wie man eine Präsentation mit den Standardeinstellungen nach XAML exportiert:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

Standardmäßig werden die exportierten Folien in einem Unterordner `pres` des aktuellen Arbeitsverzeichnisses des Prozesses gespeichert, wie von [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/de/cpp/system.io/directory/getcurrentdirectory/) zurückgegeben. Der Ordner wird automatisch erstellt, und alle erforderlichen Bilder werden dort ebenfalls gespeichert.

Der Ausgabeverzeichnisname wird aus dem Namen der Quelldatei ohne Erweiterung übernommen. Für `pres.pptx` werden die Ausgabedateien `pres/Slide_1.xaml`, `pres/Slide_2.xaml` usw. genannt. Selbst wenn Sie einen absoluten Pfad zur Eingabedatei übergeben, wird der Ausgabeverzeichnis relativ zum aktuellen Arbeitsverzeichnis erstellt, nicht neben der Eingabedatei.

## **Präsentationen mit benutzerdefinierten Optionen nach XAML exportieren**

Verwenden Sie das Interface [IXamlOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export.xaml/ixamloptions/), um zu steuern, wie Aspose.Slides eine Präsentation nach XAML exportiert.

Um die Ausgabe an einem benutzerdefinierten Ort zu speichern, implementieren Sie [IXamlOutputSaver](https://reference.aspose.com/slides/de/cpp/aspose.slides.export.xaml/ixamloutputsaver/) und übergeben eine Instanz Ihrer Implementierung an die Methode [set_OutputSaver](https://reference.aspose.com/slides/de/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) von [XamlOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export.xaml/xamloptions/).

Um versteckte Folien in die XAML‑Ausgabe einzuschließen, übergeben Sie `true` an die Methode [set_ExportHiddenSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/), wie im folgenden C++‑Beispiel gezeigt:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **Alle generierten XAML‑Artefakte erfassen**

Ein XAML‑Export kann ein XAML‑Dokument für jede exportierte Folie sowie separate Bilder und begleitende Ressourcen erzeugen. Übergeben Sie ein benutzerdefiniertes [IXamlOutputSaver](https://reference.aspose.com/slides/de/cpp/aspose.slides.export.xaml/ixamloutputsaver/) an [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/de/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/), um diese Artefakte zu erhalten, anstatt den standardmäßigen Dateisystem‑Saver zu verwenden. Starten Sie den Export mit der XAML‑spezifischen Überladung von [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/), die XAML‑Optionen akzeptiert.

### **Den Lebenszyklus des Callbacks verstehen**

Der Exporter ruft [IXamlOutputSaver::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) separat für jedes erzeugte Artefakt auf:

- `path` identifiziert das Artefakt und kann relative Verzeichnisse enthalten. Bewahren Sie diese Information auf, da XAML Ressourcen möglicherweise über relative Pfade referenziert.
- `data` enthält die Bytes des Artefakts. Bilder und andere binäre Ressourcen dürfen nicht als Text dekodiert werden.
- Der Saver ist dafür verantwortlich, die Daten zu behalten oder zu persistieren, bevor er zurückkehrt. Die Beispiele kopieren jedes Byte‑Array in Anwendungsspeicher.
- Betrachten Sie den Export nur dann als erfolgreich, wenn der Präsentations‑Save‑Vorgang zurückkehrt und jeder Callback erfolgreich abgeschlossen wurde. Ignorieren Sie keine Speicherfehler und starten Sie keine unbeobachteten Hintergrundwrites. Erfolgt die Persistenz anschließend, melden Sie den Gesamterfolg erst, wenn dieser Schritt ebenfalls erfolgreich war.

[XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) gilt ebenfalls für einen benutzerdefinierten Saver. Die Standardeinstellung `false` schließt XAML‑Dokumente versteckter Folien aus. Wird sie auf `true` gesetzt, werden sie sowie alle für ihren Export benötigten Ressourcen einbezogen. Die Anzahl der Ressourcen hängt von der Präsentation ab; gehen Sie nicht davon aus, dass pro Folie genau ein Callback erfolgt oder dass die Callback‑Reihenfolge fest ist.

### **In den Speicher exportieren und die Artefakte inspizieren**

Dieses vollständige Beispiel lädt `pres.pptx`, sammelt jedes Artefakt in einem [Dictionary<String,ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/de/cpp/system.collections.generic/dictionary/), und gibt dessen Namen, Typ und Byte‑Anzahl aus. Es erhält die bereitgestellten Namen unverändert. Doppelte Namen führen zum Fehlschlagen der Sammlung, anstatt ein Artefakt stillschweigend zu überschreiben.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // Nur XAML dekodieren, und nur wenn eine Textinspektion erforderlich ist.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Rufen Sie `InMemoryXamlExample::Run` aus Ihrer Anwendung auf. Erweiterungsprüfungen sind nützlich für die Inspektion; bewahren Sie alle Artefakte, einschließlich unbekannter Ressourcentypen, auf. Lassen Sie die Bytes unverändert, wenn Sie sie speichern oder übertragen. Verwenden Sie [Encoding::GetString](https://reference.aspose.com/slides/de/cpp/system.text/encoding/getstring/) mit UTF‑8‑Kodierung ausschließlich für XAML, das eine Textverarbeitung erfordert.

### **Sammelte Artefakte in einem ZIP‑Archiv verpacken**

Dieses unabhängige Beispiel sammelt den Export, validiert die Namen und schreibt die ursprünglichen Bytes in ein ZIP‑Archiv. Ein eindeutiger Archivname trennt gleichzeitige Exportjobs. ZIP‑Einträge verwenden Vorwärtsschrägstriche und behalten relative Verzeichnisse bei. Unsichere Namen oder Namen, die nach Normalisierung kollidieren, führen zur Ablehnung des gesamten Pakets, bevor es geschrieben wird.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // Save finalisiert das ZIP-Verzeichnis; schließen Sie die Datei, bevor der Erfolg gemeldet wird.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Rufen Sie `ZipXamlExample::Run` aus Ihrer Anwendung auf. Das Beispiel verwendet `Aspose::Zip::ZipFile` aus der C++‑Runtime, um ein lokales Archiv zu schreiben; der Exporter selbst schreibt keine losen XAML‑ oder Bilddateien. Für Fernspeicherung ersetzen Sie die Archiv‑Schreibphase durch Uploads der gesammelten Byte‑Arrays. Verwenden Sie einen Export‑Job‑Bezeichner plus den vollständigen relativen Artefaktnamen als Blob‑Schlüssel oder speichern Sie den Job‑Bezeichner, den relativen Namen und die Binärdaten in einer Datenbankzeile. Veröffentlichen Sie den Job erst, nachdem alle Uploads abgeschlossen oder die Datenbank‑Transaktion committet wurde. Bereinigen Sie Teil‑Ausgaben, wenn die Persistenz fehlschlägt.

Für große Präsentationen kann ein benutzerdefinierter Saver jedes Artefakt direkt im Anwendungsspeicher persistieren, um das Halten einer zusätzlichen Kopie des gesamten Exports zu vermeiden. Der Exporter sammelt dennoch alle erzeugten Artefakte im Speicher, bevor er den Saver aufruft. Halten Sie jeden Callback aus Sicht des Exporters synchron: Rückgabe erst, nachdem das Ziel die Bytes akzeptiert hat, und lassen Sie Fehler zum Aufrufer propagieren.

### **Ressourcennamen bewahren und Referenzen prüfen**

- Normalisieren Sie Pfad‑Separatoren, wenn das Ziel dies erfordert, bewahren Sie jedoch relative Verzeichnisse. Verwenden Sie nicht ausschließlich [Path::GetFileName](https://reference.aspose.com/slides/de/cpp/system.io/path/getfilename/), es sei denn, jeder erzeugte Name ist eindeutig und Ressourcen‑Referenzen bleiben gültig.
- Wenden Sie zielseitige Namensvalidierung an. Beim Schreiben loser Dateien lehnen Sie Pfade mit Wurzelverzeichnissen und Traversal‑Segmenten ab, lösen das Ziel mit [Path::GetFullPath](https://reference.aspose.com/slides/de/cpp/system.io/path/getfullpath/) auf und prüfen, dass es sich innerhalb des vorgesehenen Export‑Verzeichnisses befindet, einschließlich des Verzeichnis‑Separators bei der Besitz‑Prüfung. Verwenden Sie ein vom Anwendungs‑Controller gesteuertes Verzeichnis ohne symbolische Links, die Schreibvorgänge umleiten könnten.
- Nutzen Sie für jeden Export‑Job einen separaten Saver und Namensraum. Erkennen Sie Kollisionen nach Separator‑Normalisierung und gemäß den Groß‑/Kleinschreibregeln des Ziels.
- Vor der Veröffentlichung parsen Sie jedes XAML‑Dokument als XML und prüfen die dateibasierten Ressourcen‑Referenzen, etwa Bild‑`Source`‑ oder `ImageSource`‑Attribute. Lösen Sie jede relative URI gegen das Verzeichnis des enthaltenden XAML‑Artefakts auf, normalisieren Sie den resultierenden Speicher‑Namen und bestätigen Sie, dass der entsprechende Dictionary‑Schlüssel, ZIP‑Eintrag oder gespeicherte Objekt existiert. Behandeln Sie externe URIs und XAML‑Markup‑Ausdrücke getrennt von relativen Dateinamen.

Beispiel: Wenn `pres/Slide_1.xaml` auf `images/image1.png` verweist, muss die gespeicherte Ressource als `pres/images/image1.png` verfügbar sein. Nur `image1.png` zu speichern würde die Beziehung brechen. Für Objekt‑Speicherung bewahren Sie dieselbe Struktur unter dem Job‑Präfix und stellen Sie diese Ressourcen‑URLs dem XAML‑Verbraucher bereit. Öffnen Sie das fertige ZIP erneut, um Eintragsnamen und Ressourcen‑Bytes zu prüfen, und laden Sie repräsentative Folien in der Ziel‑XAML‑Umgebung, um zu bestätigen, dass Bilder korrekt aufgelöst werden.

## **FAQ**

**Wie kann ich vorhersehbare Schriften sicherstellen, wenn die Originalschrift auf dem Rechner nicht verfügbar ist?**

Verwenden Sie [set_DefaultRegularFont](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export.xaml/xamloptions/) — sie wird beim Export als Ersatzschrift verwendet, wenn die Originalschrift fehlt. Dies garantiert nicht, dass das erzeugte XAML die Ersatzschrift referenziert oder dass die Schrift auf dem Zielrechner verfügbar ist. Stellen Sie sicher, dass die im XAML referenzierten Schriften in der Umgebung, in der es angezeigt wird, vorhanden sind.

**Ist das exportierte XAML ausschließlich für WPF gedacht oder kann es auch in anderen XAML‑Stacks verwendet werden?**

Aspose.Slides exportiert WPF‑XAML über seine öffentliche API. Die Kompatibilität mit anderen XAML‑Stacks wie UWP und Xamarin.Forms ist nicht garantiert. Testen Sie das erzeugte Markup in Ihrer Zielumgebung.

**Werden versteckte Folien unterstützt und wie kann ich verhindern, dass sie standardmäßig exportiert werden?**

Standardmäßig werden versteckte Folien nicht einbezogen. Sie können dieses Verhalten über [set_ExportHiddenSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export.xaml/xamloptions/) steuern — lassen Sie es deaktiviert, wenn Sie sie nicht exportieren möchten.