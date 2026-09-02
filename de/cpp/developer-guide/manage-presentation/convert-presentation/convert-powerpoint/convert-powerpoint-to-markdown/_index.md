---
title: PowerPoint-Präsentationen nach Markdown in C++ konvertieren
linktitle: PowerPoint zu Markdown
type: docs
weight: 140
url: /de/cpp/convert-powerpoint-to-markdown/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu MD
- Präsentation zu MD
- Folie zu MD
- PPT zu MD
- PPTX zu MD
- PowerPoint als Markdown speichern
- Präsentation als Markdown speichern
- Folie als Markdown speichern
- PPT als MD speichern
- PPTX als MD speichern
- PPT nach MD exportieren
- PPTX nach MD exportieren
- Markdown-Bildexport
- CDN-Bildlinks
- PowerPoint
- Präsentation
- Markdown
- C++
- Aspose.Slides
description: "Konvertieren Sie PPT‑ und PPTX‑Präsentationen in Markdown in C++ und steuern Sie, wo exportierte Bitmap‑, Metafile‑ und SVG‑Bilder gespeichert und referenziert werden."
---
## **Übersicht**

Aspose.Slides für C++ kann PPT‑ und PPTX‑Präsentationen in Markdown für Dokumentation, statische Websites, Content‑Migration und Versions‑Control‑Workflows konvertieren. Sie können einen Markdown‑Flavor wählen, steuern, wie Folieninhalt gerendert wird, und festlegen, wo exportierte Bilder gespeichert werden und wie das erzeugte Markdown auf sie verweist.

Standardmäßig verwendet der Markdown‑Export nur Textausgabe. Um visuelle Inhalte zu exportieren, setzen Sie die [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/)‑Methode auf den Wert `Sequential` oder `Visual` aus der Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/markdownexporttype/). `Sequential` rendert Folienelemente einzeln und in Reihenfolge, während `Visual` gruppierte Elemente zusammenhält, um deren visuelle Beziehung zu bewahren. Der Wert `TextOnly` erzeugt keine Bildressourcen, sodass die Bild‑Speicher‑Ereignisse in diesem Modus nicht aufgerufen werden.

## **Eine Präsentation in Markdown konvertieren**

Laden Sie die Quelldatei mit der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse und rufen Sie anschließend die [Presentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/save/)‑Methode mit dem `Md`‑Wert aus der Aufzählung [SaveFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/) auf.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Wählen Sie einen Markdown‑Flavor aus**

Die [MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/)‑Methode steuert die für die Ausgabe verwendete Markdown‑Spezifikation. Die Aufzählung [Flavor](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/flavor/) enthält CommonMark, GitHub Flavored Markdown und andere unterstützte Varianten.

Das folgende Beispiel exportiert eine Präsentation im CommonMark‑Format:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **Bilder mit dem standardmäßigen lokalen Speicherverhalten exportieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/markdownsaveoptions/) stellt zwei Methoden zur Konfiguration lokal gespeicherter Bilder bereit:

- [set_BasePath](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) gibt das Basisverzeichnis für das Markdown‑Dokument und seine Ressourcen an.
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) gibt das Unterverzeichnis für Bilder an. Der Standardwert ist `Images`.

Das folgende Beispiel rendert visuelle Inhalte, schreibt Bilder nach `output/assets` und erzeugt relative Bildreferenzen im Markdown‑Dokument:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Dieses Verhalten dient auch als Fallback, wenn ein benutzerdefinierter Bild‑Speicher‑Handler `false` zurückgibt.

## **Bildspeicherung und Markdown‑Links anpassen**

Verwenden Sie das Ereignis `MarkdownSaveOptions::ImageSaving` für nicht‑SVG‑Bitmap‑ und Metafile‑Ressourcen, die beim Markdown‑Export erzeugt werden. Sein [MarkdownImageSavingHandler](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/)‑Delegat erhält das [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)‑Objekt, sein [ImageFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/imageformat/) und den erzeugten Markdown‑Link als Parameter vom Typ `System::String&`. Speichern oder laden Sie das Bild mit dem angegebenen Format hoch und ersetzen Sie `link` durch die Referenz, die im Markdown‑Ausgabe erscheinen soll.

Ressourcen, die im SVG‑Format erzeugt werden, werden separat behandelt. Abonnieren Sie das Ereignis `MarkdownSaveOptions::SvgImageSaving`, dessen [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/)‑Delegat ein [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/)‑Objekt und den Parameter `System::String& link` erhält. Ein SVG hat kein `ImageFormat`‑Argument; schreiben oder laden Sie stattdessen die XML‑Daten über die Methode [ISvgImage::get_SvgData](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/get_svgdata/). Je nach Exportmodus und visueller Gruppierung kann ein SVG in der Quellpräsentation gerastert oder mit anderem Inhalt kombiniert werden; die resultierende nicht‑SVG‑Ressource wird dann an `ImageSaving` übergeben. Abonnieren Sie beide Ereignisse, wenn jede exportierte visuelle Ressource eine benutzerdefinierte Verarbeitung erfordert.

Der Rückgabewert des Handlers bestimmt, wer das Bild verarbeitet:

- Geben Sie `true` zurück, nachdem der Handler das Bild gespeichert, hochgeladen, transformiert oder anderweitig verarbeitet und `link` einen gültigen Wert zugewiesen hat. Aspose.Slides schreibt diesen Wert in das Markdown‑Dokument und führt nicht das standardmäßige lokale Speichern aus.
- Geben Sie `false` zurück, damit Aspose.Slides das Bild lokal speichert und den Link gemäß [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) und [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) generiert.

{{% alert color="warning" title="Important" %}}
Ein Handler, der `true` zurückgibt, übernimmt die Verantwortung für das Bild. Gibt er `true` zurück, ohne einen gültigen, nicht leeren Link zuzuweisen, schlägt der Export mit einer `InvalidOperationException` fehl.
{{% /alert %}}

### **Bilder in ein CDN‑Ursprungsverzeichnis speichern und externe URLs verwenden**

Das folgende Beispiel behandelt `cdn-origin/presentations/quarterly-report` als eingehängtes oder synchronisiertes CDN‑Ursprungsverzeichnis. Jeder Handler extrahiert den erzeugten Dateinamen, speichert das Bild in diesem benutzerdefinierten Verzeichnis und ersetzt die erzeugte lokale Referenz durch eine öffentliche CDN‑URL. Das Beispiel führt selbst keinen Netzwerk‑Upload durch: Die URL wird erst gültig, wenn das Verzeichnis als CDN‑Ursprung eingehängt oder seine Dateien im CDN veröffentlicht wurden. Für Object‑Storage ersetzen Sie den Dateisystem‑Write‑Vorgang durch den Upload‑Aufruf des jeweiligen SDKs und weisen `link` erst zu, wenn der Upload erfolgreich war.

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

Der Bitmap‑Handler gibt bewusst `false` zurück für Bilder kleiner als 128 × 128 Pixel, sodass Aspose.Slides diese Bilder nach `output/fallback-images` speichert und das Standardverhalten verwendet. Größere Bitmap‑ und Metafile‑Ressourcen sowie SVG‑Ressourcen werden durch den benutzerdefinierten Code verarbeitet. Z. B. wird eine erzeugte lokale Referenz wie `fallback-images/image1.png` zu `https://cdn.example.com/presentations/quarterly-report/image1.png`. Die Handler benutzen Dateisystem‑Pfadangaben nur beim Schreiben von Dateien; Links, die in Markdown geschrieben werden, verwenden Vorwärtsschrägstriche und URL‑kodierte Dateinamen. Wenden Sie dieselbe Regel beim Erzeugen relativer Links an: Verwenden Sie `/`, nicht den plattformspezifischen Pfadtrenner.

## **FAQ**

**Kann ein Handler sowohl Raster‑ als auch SVG‑Bilder verarbeiten?**

Nein. Verwenden Sie `MarkdownSaveOptions::ImageSaving` für erzeugte Bitmap‑ und Metafile‑Ressourcen und `MarkdownSaveOptions::SvgImageSaving` für als SVG erzeugte Ressourcen. Ersterer liefert ein [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)‑Objekt und ein [ImageFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/imageformat/); letzterer liefert ein [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/)‑Objekt, dessen SVG‑Daten über [ISvgImage::get_SvgData](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/get_svgdata/) gelesen werden können. Ein Quell‑SVG, das während des Exports rastert, wird von `ImageSaving` verarbeitet.

**Was passiert, wenn ein Bild‑Speicher‑Handler `false` zurückgibt?**

Aspose.Slides verwendet das standardmäßige lokale Speicherverhalten. Speicherort und erzeugte Referenz werden durch [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) und [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) gesteuert.

**Kann ein Handler eine URL bereitstellen, ohne das Bild lokal zu speichern?**

Ja. Der Handler kann das Bild in einen Object‑Storage hochladen oder an einen anderen Dienst weitergeben, die resultierende URL `link` zuweisen und `true` zurückgeben. Der Handler muss die gesamte Verarbeitung selbst abschließen; die Rückgabe von `true` verhindert das standardmäßige lokale Speichern.

**Warum wirft der Markdown‑Export eine `InvalidOperationException` aus einem Handler?**

Diese Ausnahme tritt auf, wenn der Handler `true` zurückgibt, aber keinen gültigen Link bereitstellt. Weisen Sie den relativen Pfad oder die externe URL, die in Markdown geschrieben werden soll, zu, bevor Sie `true` zurückgeben.

**Welches Pfadtrennzeichen sollten Bild‑Links verwenden?**

Verwenden Sie Vorwärtsschrägstriche (`/`) in Markdown‑Links und URLs. `Path::Combine` nur für Dateisystem‑Pfade; konstruieren oder normalisieren Sie die Markdown‑Referenz separat.

**Werden Hyperlinks beim Markdown‑Export beibehalten?**

Ja. Text‑[Hyperlinks](/slides/de/cpp/manage-hyperlinks/) werden als Standard‑Markdown‑Links erhalten. Folien‑[Übergänge](/slides/de/cpp/slide-transition/) und -[Animationen](/slides/de/cpp/powerpoint-animation/) werden nicht konvertiert.

**Können Präsentationen parallel in Markdown konvertiert werden?**

Sie können verschiedene Präsentationsdateien parallel verarbeiten, aber dieselbe [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Instanz nicht zwischen Threads teilen. Beachten Sie die [Multithreading‑Richtlinien](/slides/de/cpp/multithreading/) und verwenden Sie für jede Datei eine eigene Instanz.