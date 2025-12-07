---
title: PowerPoint-Präsentationen mit C++ in Markdown konvertieren
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
- PowerPoint
- Präsentation
- Markdown
- C++
- Aspose.Slides
description: "PowerPoint-Folien—PPT, PPTX—mit Aspose.Slides für C++ in sauberes Markdown konvertieren, Dokumentation automatisieren und die Formatierung beibehalten."
---

{{% alert color="info" %}} 

Unterstützung für die PowerPoint‑zu‑Markdown‑Konvertierung wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der PowerPoint‑zu‑Markdown‑Export erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint‑Dokument mit Bildern exportieren möchten, müssen Sie `SaveOptions::MarkdownExportType::Visual)` festlegen und zudem den `BasePath` angeben, in dem die im Markdown‑Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint in Markdown konvertieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), um ein Präsentationsobjekt darzustellen.
2. Verwenden Sie die Methode [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method), um das Objekt als Markdown‑Datei zu speichern.

This C++ code shows you how to convert PowerPoint to markdown:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **PowerPoint in Markdown‑Variante konvertieren**

Aspose.Slides ermöglicht die Konvertierung von PowerPoint in Markdown (mit grundlegender Syntax), CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab und 17 weitere Markdown‑Varianten.

This C++ code shows you how to convert PowerPoint to CommonMark: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


Die 23 unterstützten Markdown‑Varianten sind [unter der Aufzählung Flavor aufgeführt](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) in der Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Eine Präsentation mit Bildern in Markdown konvertieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) stellt Eigenschaften und Aufzählungen bereit, die es ermöglichen, bestimmte Optionen oder Einstellungen für die resultierende Markdown‑Datei zu verwenden. Das Enum [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) kann beispielsweise auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder verarbeitet werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn Sie möchten, dass die Bilder einzeln nacheinander im resultierenden Markdown erscheinen, müssen Sie die sequenzielle Option wählen. Dieser C++‑Code zeigt, wie Sie eine Präsentation mit Bildern in Markdown konvertieren:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```


### **Bilder visuell konvertieren**

Wenn Sie möchten, dass die Bilder zusammen im resultierenden Markdown erscheinen, müssen Sie die visuelle Option wählen. In diesem Fall werden Bilder im aktuellen Anwendungsverzeichnis gespeichert (und ein relativer Pfad wird im Markdown‑Dokument dafür erzeugt), oder Sie können einen bevorzugten Pfad und Ordnernamen angeben.

This C++ code demonstrates the operation: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```


## **FAQ**

**Bleiben Hyperlinks beim Export nach Markdown erhalten?**

Ja. Text-[Hyperlinks](/slides/de/cpp/manage-hyperlinks/) werden als Standard‑Markdown‑Links beibehalten. Folien-[Übergänge](/slides/de/cpp/slide-transition/) und -[Animationen](/slides/de/cpp/powerpoint-animation/) werden nicht konvertiert.

**Kann ich die Konvertierung beschleunigen, indem ich sie in mehreren Threads ausführe?**

Sie können die Verarbeitung über mehrere Dateien parallelisieren, aber [nicht teilen](/slides/de/cpp/multithreading/) Sie die gleiche [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Instanz nicht über Threads hinweg. Verwenden Sie pro Datei separate Instanzen/Prozesse, um Konkurrenz zu vermeiden.

**Was passiert mit Bildern—wo werden sie gespeichert und sind die Pfade relativ?**

[Bilder](/slides/de/cpp/image/) werden in einen eigenen Ordner exportiert, und die Markdown‑Datei referenziert sie standardmäßig mit relativen Pfaden. Sie können den Basis‑Ausgabepfad und den Asset‑Ordnernamen konfigurieren, um eine vorhersehbare Repository‑Struktur beizubehalten.