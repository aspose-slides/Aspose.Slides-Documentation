---
title: Benutzerdefinierte Schriftarten in C++
type: docs
weight: 20
url: /de/cpp/custom-font/
keywords: "Schriftarten, benutzerdefinierte Schriftarten, PowerPoint-Präsentation, C++, CPP, Aspose.Slides für C++"
description: "PowerPoint benutzerdefinierte Schriftarten in C++"
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht es Ihnen, diese Schriftarten mit [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) zu laden:

* TrueType (.ttf) und TrueType Collection (.ttc) Schriftarten. Siehe [TrueType](https://de.wikipedia.org/wiki/TrueType).

* OpenType (.otf) Schriftarten. Siehe [OpenType](https://de.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht es Ihnen, Schriftarten, die in Präsentationen gerendert werden, zu laden, ohne diese Schriftarten installieren zu müssen. Die Schriftarten werden aus einem benutzerdefinierten Verzeichnis geladen. 

1. Erstellen Sie eine Instanz der [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) Klasse und rufen Sie die [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) Methode auf.
2. Laden Sie die Präsentation, die gerendert werden soll.
3. Leeren Sie den Cache in der [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) Klasse.

Dieser C++ Code demonstriert den Schriftartenladeprozess:

``` cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// Setzt den Schriftartenpfad
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// Lädt die Schriftarten aus dem benutzerdefinierten Verzeichnis
FontsLoader::LoadExternalFonts(folders);

// Führen Sie einige Arbeiten aus und rendern Sie die Präsentation/Slide
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// Leert den Schriftart-Cache
FontsLoader::ClearCache();
```

## **Benutzerdefinierte Schriftartenordner abrufen**
Aspose.Slides bietet [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) an, um Ihnen zu helfen, Schriftartenordner zu finden. Diese Methode gibt Ordner zurück, die über die Methode `LoadExternalFonts` hinzugefügt wurden, sowie Systemschriftartenordner.

Dieser C++ Code zeigt Ihnen, wie Sie die [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) Methode verwenden:

``` cpp
// Diese Zeile gibt die Ordner aus, die auf Schriftartdateien überprüft werden.
// Dies sind Ordner, die über die LoadExternalFonts Methode und Systemschriftartenordner hinzugefügt wurden.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Benutzerdefinierte Schriftarten spezifizieren, die mit der Präsentation verwendet werden**
Aspose.Slides bietet die [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) Eigenschaft an, um Ihnen zu ermöglichen, externe Schriftarten zu spezifizieren, die mit der Präsentation verwendet werden.

Dieser C++ Code zeigt Ihnen, wie Sie die [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) Eigenschaft verwenden:

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // Arbeiten mit der Präsentation
    // CustomFont1, CustomFont2 sowie Schriftarten aus den Ordnern assets\fonts & global\fonts und deren Unterordnern sind für die Präsentation verfügbar
}
```

## **Schriftarten extern verwalten**
Aspose.Slides bietet die [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) Methode an, um Ihnen zu ermöglichen, externe Schriftarten in ein Byte-Array zu laden.

Dieser C++ Code demonstriert den Prozess des Ladens von Schriftarten in ein Byte-Array:

```cpp
// Der Pfad zum Dokumentenverzeichnis
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```