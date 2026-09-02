---
title: "PowerPoint-Schriftarten in C++ anpassen"
linktitle: "Benutzerdefinierte Schriftart"
type: docs
weight: 20
url: /de/cpp/custom-font/
keywords:
- Schriftart
- benutzerdefinierte Schriftart
- externe Schriftart
- Schriftart laden
- Schriftarten verwalten
- Schriftartenordner
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Passen Sie Schriftarten in PowerPoint-Folien mit Aspose.Slides für C++ an, um Ihre Präsentationen überall scharf und konsistent zu halten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, benutzerdefinierte Schriftarten in Präsentationen zu verwenden, ohne sie im Betriebssystem zu installieren. Sie können Schriftarten aus benutzerdefinierten Ordnern laden, Schriftarten für eine bestimmte Präsentation über dokumentenbezogene Schriftartenquellen bereitstellen oder externe Schriftarten direkt aus Binärdaten laden.

Geladene Schriftarten werden verwendet, wenn eine Präsentation gerendert oder exportiert wird, zum Beispiel nach PDF, Bildern und anderen unterstützten Formaten. Dies hilft, die Ausgabe der Präsentation in verschiedenen Umgebungen konsistent zu halten. Der Artikel erklärt außerdem, wie Sie die von Aspose.Slides verwendeten Schriftordner untersuchen und den Schriftarten‑Cache nach der Arbeit mit externen Schriftarten leeren können.

Das Registrieren benutzerdefinierter Schriftarten für das Rendering ist getrennt vom Einbetten von Schriftarten in eine PPTX‑Datei. Wenn eine Schriftart innerhalb der Präsentation selbst gespeichert werden muss, verwenden Sie explizit die Funktionen zum Einbetten von Schriftarten.

Ein Präsentationsthema kann für einzelne Schriftsysteme verschiedene Schriftfamilien referenzieren. Diese Zuordnungen speichern Schriftartnamen, installieren oder laden jedoch nicht die Schriftdateien. Siehe [Skript‑spezifische Themen‑Schriftarten](/slides/de/cpp/script-specific-font-mappings/), um die Zuordnungen zu verwalten, und verwenden Sie die unten genannten Laderoptionen, um die referenzierten Schriftarten für ein konsistentes Rendering verfügbar zu machen.

{{% alert color="info" title="Note" %}}
Aspose Slides ermöglicht das Laden dieser Schriftarten mit [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) und TrueType Collection (.ttc) Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht es Ihnen, Schriftarten zu laden, die in einer Präsentation verwendet werden, ohne sie auf dem System zu installieren. Dies wirkt sich auf die Exportausgabe – wie PDF, Bilder und andere unterstützte Formate – aus, sodass die resultierenden Dokumente in verschiedenen Umgebungen konsistent aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.
2. Rufen Sie die statische Methode [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/loadexternalfonts/) auf, um Schriftarten aus diesen Ordnern zu laden.
3. Laden und rendern/exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader.clearCache](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/clearcache/) auf, um den Schriftarten‑Cache zu leeren.

Das folgende Codebeispiel demonstriert den Schriftarten‑Ladevorgang:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Definieren Sie Ordner, die benutzerdefinierte Schriftdateien enthalten.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Laden Sie benutzerdefinierte Schriftarten aus den angegebenen Ordnern.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Rendern/Exportieren Sie die Präsentation (z. B. als PDF, Bilder oder andere Formate) unter Verwendung der geladenen Schriftarten.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Leeren Sie den Schriftarten-Cache, nachdem die Arbeit abgeschlossen ist.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/loadexternalfonts/) fügt zusätzliche Ordner zu den Schriftart‑Suchpfaden hinzu, ändert jedoch nicht die Initialisierungsreihenfolge der Schriftarten. Schriftarten werden in dieser Reihenfolge initialisiert:

1. Der standardmäßige Betriebssystem‑Schriftpfad.  
1. Die über [FontsLoader](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/) geladenen Pfade.
{{%/alert %}}

## **Benutzerdefinierte Schriftartenordner abrufen**
Aspose.Slides stellt [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/getfontfolders/) bereit, um Ihnen das Auffinden von Schriftordnern zu ermöglichen. Diese Methode gibt Ordner zurück, die über die Methode `LoadExternalFonts` hinzugefügt wurden, sowie System‑Schriftordner.

Der folgende C++‑Code zeigt, wie Sie die Methode [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/getfontfolders/) verwenden:

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Diese Zeile gibt die Ordner aus, die auf Schriftdateien überprüft werden.
// Das sind Ordner, die über die Methode LoadExternalFonts hinzugefügt wurden, sowie System-Schriftordner.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Benutzerdefinierte Schriftarten für eine Präsentation festlegen**
Aspose.Slides stellt die Eigenschaft [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) bereit, um externe Schriftarten anzugeben, die mit der Präsentation verwendet werden sollen.

Der folgende C++‑Code zeigt, wie Sie die Eigenschaft [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) verwenden:

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //mit der Präsentation arbeiten
    //CustomFont1, CustomFont2 sowie Schriftarten aus den Ordnern assets\fonts & global\fonts und deren Unterordnern stehen der Präsentation zur Verfügung
}
```

## **Schriftarten extern verwalten**
Aspose.Slides bietet die Methode [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/loadexternalfont/) an, um externe Schriftarten in ein Byte‑Array zu laden.

Der folgende C++‑Code demonstriert den Ladevorgang einer Schriftart in ein Byte‑Array:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// Der Pfad zum Dokumentenverzeichnis
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **FAQ**

### Wirken sich benutzerdefinierte Schriftarten auf den Export in alle Formate (PDF, PNG, SVG, HTML) aus?

Ja. Verbundene Schriftarten werden vom Renderer in allen Exportformaten verwendet.

### Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?

Nein. Das Registrieren einer Schriftart für das Rendering ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schriftart innerhalb der Präsentationsdatei mitgeführt werden soll, müssen Sie die expliziten [Einbettungsfunktionen](/slides/de/cpp/embedded-font/) verwenden.

### Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?

Ja. Konfigurieren Sie die [Schriftart-Substitution](/slides/de/cpp/font-substitution/), [Ersetzungsregeln](/slides/de/cpp/font-replacement/) und [Fallback‑Sets](/slides/de/cpp/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die angeforderte Glyphe fehlt.

### Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?

Ja. Verweisen Sie auf Ihre eigenen Schriftordner oder laden Sie Schriftarten aus Byte‑Arrays. Damit entfällt jede Abhängigkeit von systemweiten Schriftverzeichnissen im Container‑Image.

### Wie sieht es mit Lizenzen aus – kann ich jede benutzerdefinierte Schriftart ohne Einschränkungen einbetten?

Sie sind für die Einhaltung der Schriftlizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die Endbenutzerlizenz (EULA) der Schriftart, bevor Sie Ausgaben verbreiten.