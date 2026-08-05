---
title: PowerPoint-Schriftarten in C++ anpassen
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
description: "Passen Sie Schriftarten in PowerPoint-Folien mit Aspose.Slides für C++ an, um Ihre Präsentationen scharf und auf allen Geräten konsistent zu halten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, benutzerdefinierte Schriftarten in Präsentationen zu verwenden, ohne sie im Betriebssystem zu installieren. Sie können Schriftarten aus eigenen Ordnern laden, Schriftarten für eine bestimmte Präsentation über dokumentbezogene Schriftquellen bereitstellen oder externe Schriftarten direkt aus Binärdaten laden.

Geladene Schriftarten werden verwendet, wenn eine Präsentation gerendert oder exportiert wird, z. B. nach PDF, Bildern und anderen unterstützten Formaten. Dadurch bleibt die Ausgabe der Präsentation in verschiedenen Umgebungen konsistent. Der Artikel erklärt zudem, wie Sie die von Aspose.Slides verwendeten Schriftordner inspizieren und wie Sie den Schriftarten‑Cache nach der Arbeit mit externen Schriftarten leeren können.

Das Registrieren benutzerdefinierter Schriftarten zum Rendern ist getrennt vom Einbetten von Schriftarten in eine PPTX‑Datei. Wenn eine Schriftart innerhalb der Präsentation selbst gespeichert werden muss, verwenden Sie die Einbettungs‑Features explizit.

{{% alert color="primary" %}} 

Aspose Slides ermöglicht das Laden dieser Schriftarten mit [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType‑Schriftarten (.ttf) und TrueType‑Sammlungen (.ttc). Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType‑Schriftarten (.otf). Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht das Laden von Schriftarten, die in einer Präsentation verwendet werden, ohne sie im System zu installieren. Dies wirkt sich auf die Exportausgabe – wie PDF, Bilder und andere unterstützte Formate – aus, sodass die erzeugten Dokumente in verschiedenen Umgebungen einheitlich aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.
2. Rufen Sie die statische Methode [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/loadexternalfonts/) auf, um Schriftarten aus diesen Ordnern zu laden.
3. Laden und rendern/exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader.clearCache](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/clearcache/) auf, um den Schriftarten‑Cache zu leeren.

Das folgende Codebeispiel demonstriert den Schriftarten‑Ladevorgang:

```cpp
// Definieren Sie Ordner, die benutzerdefinierte Schriftdateien enthalten.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Laden Sie benutzerdefinierte Schriftarten aus den angegebenen Ordnern.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Rendern/Exportieren Sie die Präsentation (z. B. nach PDF, Bildern oder anderen Formaten) mit den geladenen Schriftarten.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Löschen Sie den Schriftarten-Cache, nachdem die Arbeit abgeschlossen ist.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Hinweis" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/loadexternalfonts/) fügt zusätzliche Ordner zu den Schriftart‑Suchpfaden hinzu, ändert jedoch nicht die Reihenfolge der Schriftarten‑Initialisierung.
Schriftarten werden in dieser Reihenfolge initialisiert:

1. Der standardmäßige Betriebssystem‑Schriftpfad.
1. Die über [FontsLoader](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/) geladenen Pfade.

{{%/alert %}}

## **Benutzerdefinierte Schriftordner ermitteln**
Aspose.Slides stellt [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/getfontfolders/) zur Verfügung, um Ihnen das Finden von Schriftordnern zu ermöglichen. Diese Methode gibt Ordner zurück, die über die Methode `LoadExternalFonts` hinzugefügt wurden, sowie System‑Schriftordner.

Dieser C++‑Code zeigt, wie Sie die Methode [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/getfontfolders/) verwenden:

``` cpp
// Diese Zeile gibt die Ordner aus, die auf Schriftdateien überprüft werden.
// Das sind Ordner, die über die Methode LoadExternalFonts hinzugefügt wurden, sowie System-Schriftordner.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Benutzerdefinierte Schriftarten für eine Präsentation festlegen**
Aspose.Slides bietet die Eigenschaft [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) an, mit der Sie externe Schriftarten angeben können, die mit der Präsentation verwendet werden sollen.

Dieser C++‑Code zeigt, wie Sie die Eigenschaft [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) verwenden:

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    // Arbeiten mit der Präsentation
    // CustomFont1, CustomFont2 sowie Schriftarten aus den Ordnern assets\fonts & global\fonts und deren Unterordnern stehen der Präsentation zur Verfügung
}
```

## **Schriftarten extern verwalten**
Aspose.Slides stellt die Methode [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/loadexternalfont/) bereit, mit der Sie externe Schriftarten in ein Byte‑Array laden können.

Dieser C++‑Code demonstriert den Ladevorgang einer Schriftart als Byte‑Array:

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

**Wirken sich benutzerdefinierte Schriftarten auf den Export in alle Formate (PDF, PNG, SVG, HTML) aus?**

Ja. Verbundene Schriftarten werden vom Renderer bei allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schriftart zum Rendern ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schriftart innerhalb der Präsentationsdatei gespeichert werden muss, müssen Sie die expliziten [Einbettungs‑Features](/slides/de/cpp/embedded-font/) nutzen.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [Schriftart‑Substitution](/slides/de/cpp/font-substitution/), [Ersetzungsregeln](/slides/de/cpp/font-replacement/) und [Fallback‑Sets](/slides/de/cpp/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf Ihre eigenen Schriftordner oder laden Sie Schriftarten aus Byte‑Arrays. Dadurch entfällt jede Abhängigkeit von System‑Schriftverzeichnissen im Container‑Image.

**Wie sieht es mit Lizenzierung aus – kann ich jede benutzerdefinierte Schriftart ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen untersagen das Einbetten oder die kommerzielle Nutzung. Prüfen Sie stets die EULA der jeweiligen Schriftart, bevor Sie Ausgaben verteilen.