---
title: PowerPoint-Schriften in C++ anpassen
linktitle: Benutzerdefinierte Schrift
type: docs
weight: 20
url: /de/cpp/custom-font/
keywords:
- Schrift
- benutzerdefinierte Schrift
- externe Schrift
- Schrift laden
- Schriften verwalten
- Schriftordner
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Passen Sie Schriften in PowerPoint-Folien mit Aspose.Slides für C++ an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht das Laden dieser Schriften über [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) und TrueType Collection (.ttc) Schriften. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) Schriften. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriften laden**

Aspose.Slides ermöglicht das Laden von Schriften, die in Präsentationen gerendert werden, ohne dass diese Schriften installiert werden müssen. Die Schriften werden aus einem benutzerdefinierten Verzeichnis geladen. 

1. Erstellen Sie eine Instanz der [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/)‑Klasse und rufen Sie die Methode [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) auf.  
2. Laden Sie die Präsentation, die gerendert werden soll.  
3. Leeren Sie den Cache in der [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/)‑Klasse.

Dieser C++‑Code demonstriert den Schrift‑Ladevorgang:
``` cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// Legt den Schriftpfad fest
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// Lädt die Schriften aus dem benutzerdefinierten Schriftverzeichnis
FontsLoader::LoadExternalFonts(folders);

// Führt einige Arbeiten aus und rendert die Präsentation/Slide
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// Löscht den Schrift-Cache
FontsLoader::ClearCache();
```


## **Benutzerdefinierte Schriftordner abrufen**

Aspose.Slides stellt [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) bereit, um Schriftordner zu finden. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode und System‑Schriftordner hinzugefügt wurden.

Dieser C++‑Code zeigt, wie die Methode [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) verwendet wird:
``` cpp
// Diese Zeile gibt die Ordner aus, die auf Schriftdateien überprüft werden.
// Dabei handelt es sich um Ordner, die über die LoadExternalFonts-Methode und System-Schriftordner hinzugefügt wurden.
auto fontFolders = FontsLoader::GetFontFolders();
```


## **Benutzerdefinierte Schriften für eine Präsentation festlegen**

Aspose.Slides stellt die Eigenschaft [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) bereit, um externe Schriften anzugeben, die mit der Präsentation verwendet werden sollen.

Dieser C++‑Code zeigt, wie die Eigenschaft [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) verwendet wird:
``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //Arbeiten mit der Präsentation
    //CustomFont1, CustomFont2 sowie Schriften aus den Ordnern assets\fonts & global\fonts und deren Unterordner stehen der Präsentation zur Verfügung
}
```


## **Schriften extern verwalten**

Aspose.Slides stellt die Methode [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) bereit, um externe Schriften in ein Byte‑Array zu laden.

Dieser C++‑Code demonstriert den Ladevorgang einer Schrift als Byte‑Array:
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

**Beeinflussen benutzerdefinierte Schriften den Export in alle Formate (PDF, PNG, SVG, HTML)?**

Ja. Verknüpfte Schriften werden vom Renderer in allen Export‑Formaten verwendet.

**Werden benutzerdefinierte Schriften automatisch in die resultierende PPTX eingebettet?**

Nein. Die Registrierung einer Schrift für das Rendering ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schrift im Präsentations‑Datei‑Container sein soll, müssen Sie die expliziten [Einbettungs‑Funktionen](/slides/de/cpp/embedded-font/) nutzen.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schrift bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie die [Schrift‑Substitution](/slides/de/cpp/font-substitution/), [Ersetzungs‑Regeln](/slides/de/cpp/font-replacement/) und [Fallback‑Sets](/slides/de/cpp/fallback-font/), um genau festzulegen, welche Schrift verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriften in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf eigene Schriftordner oder laden Sie Schriften aus Byte‑Arrays. Damit entfällt jede Abhängigkeit von System‑Schriftverzeichnissen im Container‑Image.

**Wie steht es um Lizenzierung – kann ich jede benutzerdefinierte Schrift ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schrift‑Lizenzbedingungen verantwortlich. Die Lizenzbedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die EULA der Schrift, bevor Sie Ausgaben verteilen.