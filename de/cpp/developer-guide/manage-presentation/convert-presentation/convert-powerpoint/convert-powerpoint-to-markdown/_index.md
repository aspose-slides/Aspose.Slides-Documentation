---
title: PowerPoint-Präsentationen in Markdown konvertieren in C++
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
  - PPT zu MD exportieren
  - PPTX zu MD exportieren
  - PowerPoint
  - Präsentation
  - Markdown
  - C++
  - Aspose.Slides
description: "PowerPoint-Folien—PPT, PPTX—nach sauberem Markdown mit Aspose.Slides für C++ konvertieren, Dokumentation automatisieren und Formatierung beibehalten."
---

{{% alert color="info" %}} 

Die Unterstützung für die Konvertierung von PowerPoint zu Markdown wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der PowerPoint‑zu‑Markdown‑Export erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint‑Dokument mit Bildern exportieren möchten, müssen Sie `SaveOptions::MarkdownExportType::Visual)` festlegen und außerdem den `BasePath` angeben, in dem die im Markdown‑Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint zu Markdown konvertieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse, um ein Präsentationsobjekt zu repräsentieren.  
2. Verwenden Sie die [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method)‑Methode, um das Objekt als Markdown‑Datei zu speichern.

Dieser C++‑Code zeigt, wie Sie PowerPoint zu Markdown konvertieren:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **PowerPoint zu Markdown‑Flavor konvertieren**

Aspose.Slides ermöglicht die Konvertierung von PowerPoint zu Markdown (mit Grundsyntax), CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab und 17 weiteren Markdown‑Flavors.

Dieser C++‑Code zeigt, wie Sie PowerPoint zu CommonMark konvertieren: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


Die 23 unterstützten Markdown‑Flavors sind [unter der Flavor‑Aufzählung](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) der Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) aufgelistet.

## **Eine Präsentation mit Bildern zu Markdown konvertieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) bietet Eigenschaften und Aufzählungen, mit denen Sie bestimmte Optionen oder Einstellungen für die resultierende Markdown‑Datei festlegen können. Die Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) kann beispielsweise auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder behandelt werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn Sie möchten, dass die Bilder einzeln hintereinander im resultierenden Markdown erscheinen, wählen Sie die sequenzielle Option. Dieser C++‑Code zeigt, wie Sie eine Präsentation mit Bildern zu Markdown konvertieren:
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

Wenn Sie möchten, dass die Bilder zusammen im resultierenden Markdown erscheinen, wählen Sie die visuelle Option. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und ein relativer Pfad wird im Markdown‑Dokument erstellt) oder Sie können Ihren bevorzugten Pfad und Ordnernamen angeben.

Dieser C++‑Code demonstriert die Vorgehensweise: 
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

Ja. Text [hyperlinks](/slides/de/cpp/manage-hyperlinks/) werden als Standard‑Markdown‑Links beibehalten. Folien [transitions](/slides/de/cpp/slide-transition/) und [animations](/slides/de/cpp/powerpoint-animation/) werden nicht konvertiert.

**Kann ich die Konvertierung beschleunigen, indem ich mehrere Threads verwende?**

Sie können die Verarbeitung dateiweise parallelisieren, jedoch [don’t share](/slides/de/cpp/multithreading/) dieselbe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Instanz über Threads hinweg. Verwenden Sie separate Instanzen/Prozesse pro Datei, um Kontention zu vermeiden.

**Was passiert mit Bildern – wo werden sie gespeichert und sind die Pfade relativ?**

[Images](/slides/de/cpp/image/) werden in einen eigenen Ordner exportiert, und die Markdown‑Datei verweist standardmäßig mit relativen Pfaden darauf. Sie können den Basis‑Ausgabepfad und den Asset‑Ordnernamen konfigurieren, um eine vorhersehbare Repository‑Struktur zu erhalten.