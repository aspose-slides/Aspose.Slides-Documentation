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
- PPT nach MD exportieren
- exportPPTX zu MD
- PowerPoint
- Präsentation
- Markdown
- C++
- Aspose.Slides
description: "PowerPoint-Folien - PPT, PPTX - in sauberes Markdown mit Aspose.Slides für C++ konvertieren, Dokumentation automatisieren und Formatierung beibehalten."
---

{{% alert color="info" %}} 

Die Unterstützung für die Konvertierung von PowerPoint zu Markdown wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der Export von PowerPoint zu Markdown erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint‑Dokument mit Bildern exportieren möchten, müssen Sie `SaveOptions::MarkdownExportType::Visual)` festlegen und außerdem den `BasePath` setzen, in dem die im Markdown‑Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint in Markdown konvertieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) , um ein Präsentationsobjekt darzustellen.  
2. Verwenden Sie die Methode [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method), um das Objekt als Markdown‑Datei zu speichern.

Dieses C++‑Beispiel zeigt, wie PowerPoint in Markdown konvertiert wird:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **PowerPoint in einen Markdown‑Flavor konvertieren**

Aspose.Slides ermöglicht die Konvertierung von PowerPoint zu Markdown (mit grundlegender Syntax), CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab und 17 weiteren Markdown‑Flavors.

Dieses C++‑Beispiel zeigt, wie PowerPoint in CommonMark konvertiert wird: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


Die 23 unterstützten Markdown‑Flavors sind im [Flavor](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/)‑Enum der Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) aufgelistet.

## **Eine Präsentation mit Bildern in Markdown konvertieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) stellt Eigenschaften und Aufzählungen bereit, mit denen Sie bestimmte Optionen oder Einstellungen für die resultierende Markdown‑Datei festlegen können. Das Enum [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) kann beispielsweise auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder behandelt werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn Sie möchten, dass die Bilder im resultierenden Markdown einzeln nacheinander erscheinen, müssen Sie die Option „Sequential“ wählen. Dieses C++‑Beispiel zeigt, wie eine Präsentation mit Bildern in Markdown konvertiert wird:
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

Wenn Sie möchten, dass die Bilder im resultierenden Markdown zusammen angezeigt werden, müssen Sie die Option „Visual“ wählen. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und im Markdown‑Dokument wird ein relativer Pfad dafür erzeugt), oder Sie können Ihren gewünschten Pfad und Ordnernamen angeben.

Dieses C++‑Beispiel demonstriert den Vorgang: 
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

Ja. Text‑[Hyperlinks](/slides/de/cpp/manage-hyperlinks/) werden als reguläre Markdown‑Links beibehalten. Folien‑[Übergänge](/slides/de/cpp/slide-transition/) und -[Animationen](/slides/de/cpp/powerpoint-animation/) werden nicht konvertiert.

**Kann ich die Konvertierung beschleunigen, indem ich sie in mehreren Threads ausführe?**

Sie können die Verarbeitung über Dateien hinweg parallelisieren, aber Sie sollten dieselbe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Instanz nicht über Threads hinweg [teilen](/slides/de/cpp/multithreading/). Verwenden Sie für jede Datei separate Instanzen/Prozesse, um Konflikte zu vermeiden.

**Was passiert mit den Bildern – wo werden sie gespeichert und sind die Pfade relativ?**

[Bilder](/slides/de/cpp/image/) werden in einen eigenen Ordner exportiert, und die Markdown‑Datei verweist standardmäßig mit relativen Pfaden darauf. Sie können den Basis‑Ausgabepfad und den Namen des Asset‑Ordners konfigurieren, um eine vorhersehbare Repository‑Struktur beizubehalten.