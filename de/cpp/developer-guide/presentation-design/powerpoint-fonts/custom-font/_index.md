---
title: Anpassen von PowerPoint-Schriftarten in C++
linktitle: Benutzerdefinierte Schriftart
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
description: "Passen Sie Schriftarten in PowerPoint-Folien mit Aspose.Slides für C++ an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht das Laden dieser Schriftarten mit [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) und TrueType Collection (.ttc) Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides ermöglicht das Laden von Schriftarten, die in einer Präsentation verwendet werden, ohne sie auf dem System zu installieren. Dies wirkt sich auf die Exportausgabe – wie PDF, Bilder und andere unterstützte Formate – aus, sodass die resultierenden Dokumente in allen Umgebungen konsistent aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.
2. Rufen Sie die statische [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/)‑Methode auf, um Schriftarten aus diesen Ordnern zu laden.
3. Laden und rendern/ exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader.clearCache](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/clearcache/) auf, um den Schriftarten‑Cache zu leeren.

Der folgende Codebeispiel zeigt den Vorgang des Schriftartenladens:
```cpp
// Ordner definieren, die benutzerdefinierte Schriftdateien enthalten.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Load custom fonts from the specified folders.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Die Präsentation rendern/exportieren (z. B. als PDF, Bilder oder andere Formate) unter Verwendung der geladenen Schriftarten.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Den Schriftarten-Cache leeren, nachdem die Arbeit abgeschlossen ist.
FontsLoader::ClearCache();
```


{{% alert color="info" title="Hinweis" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) fügt zusätzliche Ordner zu den Schriftart‑Suchpfaden hinzu, ändert jedoch nicht die Reihenfolge der Schriftart‑Initialisierung.
Schriftarten werden in dieser Reihenfolge initialisiert:

1. Der standardmäßige Betriebssystem‑Schriftpfad.
1. Die über [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) geladenen Pfade.

{{%/alert %}}

## **Get Custom Font Folders**
Aspose.Slides stellt [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) bereit, um Schriftordner zu ermitteln. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode hinzugefügt wurden, sowie System‑Schriftordner.

Der folgende C++‑Code zeigt, wie die [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/)‑Methode verwendet wird:
``` cpp
// Diese Zeile gibt die Ordner aus, die auf Schriftdateien überprüft werden.
// Das sind Ordner, die über die LoadExternalFonts-Methode hinzugefügt wurden, sowie System-Schriftordner.
auto fontFolders = FontsLoader::GetFontFolders();
```


## **Specify Custom Fonts Used with a Presentation**
Aspose.Slides bietet die Eigenschaft [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) an, um externe Schriftarten festzulegen, die mit der Präsentation verwendet werden.

Der folgende C++‑Code zeigt, wie die [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/)‑Eigenschaft verwendet wird:
``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //Arbeiten mit der Präsentation
    //CustomFont1, CustomFont2 sowie Schriftarten aus den Ordnern assets\fonts & global\fonts und deren Unterordnern stehen der Präsentation zur Verfügung
}
```


## **Manage Fonts Externally**
Aspose.Slides stellt die Methode [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) bereit, um externe Schriftarten in ein Byte‑Array zu laden.

Der folgende C++‑Code demonstriert den Ladevorgang eines Schriftarten‑Byte‑Arrays:
```cpp
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

**Beeinflussen benutzerdefinierte Schriftarten den Export in alle Formate (PDF, PNG, SVG, HTML)?**

Ja. Verbundene Schriftarten werden vom Renderer in allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schriftart für das Rendering ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schriftart in der Präsentationsdatei enthalten sein soll, müssen Sie die expliziten [Einbettungs‑Funktionen](/slides/de/cpp/embedded-font/) nutzen.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [Schriftart‑Substitution](/slides/de/cpp/font-substitution/), [Ersetzungsregeln](/slides/de/cpp/font-replacement/) und [Fallback‑Sätze](/slides/de/cpp/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf eigene Schriftordner oder laden Sie Schriftarten aus Byte‑Arrays. Damit entfällt jede Abhängigkeit von System‑Schriftverzeichnissen im Container‑Image.

**Wie steht es mit Lizenzierung – kann ich jede benutzerdefinierte Schriftart ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenzierung verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Prüfen Sie stets die EULA der jeweiligen Schriftart, bevor Sie Ausgaben verbreiten.