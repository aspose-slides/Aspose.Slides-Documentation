---
title: PowerPoint-Präsentationen nach Markdown konvertieren in C++
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
- exportPPTX nach MD
- PowerPoint
- Präsentation
- Markdown
- C++
- Aspose.Slides
description: "Konvertieren Sie PowerPoint‑Folien—PPT, PPTX—zu sauberem Markdown mit Aspose.Slides für C++, automatisieren Sie die Dokumentation und erhalten Sie die Formatierung."
---

{{% alert color="info" %}} 

Unterstützung für die Konvertierung von PowerPoint zu Markdown wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der Export von PowerPoint zu Markdown erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint-Dokument mit Bildern exportieren möchten, müssen Sie `SaveOptions::MarkdownExportType::Visual)` setzen und außerdem den `BasePath` angeben, wo die im Markdown-Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint nach Markdown konvertieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), um ein Präsentationsobjekt zu repräsentieren.  
2. Verwenden Sie die Methode [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method), um das Objekt als Markdown‑Datei zu speichern.

Dieser C++‑Code zeigt, wie Sie PowerPoint nach Markdown konvertieren:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```


## **PowerPoint in Markdown‑Varianten konvertieren**

Aspose.Slides ermöglicht die Konvertierung von PowerPoint zu Markdown (mit Grundsyntax), CommonMark, GitHub‑flavoured Markdown, Trello, XWiki, GitLab und 17 weiteren Markdown‑Varianten.

Dieser C++‑Code zeigt, wie Sie PowerPoint nach CommonMark konvertieren: 
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```


Die 23 unterstützten Markdown‑Varianten sind im [Flavor enumeration](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) der Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) aufgeführt.

## **Eine Präsentation mit Bildern in Markdown konvertieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) stellt Eigenschaften und Aufzählungen bereit, mit denen Sie bestimmte Optionen bzw. Einstellungen für die resultierende Markdown‑Datei festlegen können. Die Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/), zum Beispiel, kann auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder behandelt werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn Sie möchten, dass die Bilder im resultierenden Markdown einzeln nacheinander erscheinen, müssen Sie die sequenzielle Option wählen. Dieser C++‑Code zeigt, wie Sie eine Präsentation mit Bildern in Markdown konvertieren:
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

Wenn Sie möchten, dass die Bilder im resultierenden Markdown zusammen angezeigt werden, müssen Sie die visuelle Option wählen. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und im Markdown‑Dokument wird ein relativer Pfad dafür erstellt) oder Sie können einen gewünschten Pfad und Ordnernamen angeben.

Dieser C++‑Code demonstriert den Vorgang: 
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

Ja. Text‑[hyperlinks](/slides/de/cpp/manage-hyperlinks/) werden als Standard‑Markdown‑Links beibehalten. Folien‑[transitions](/slides/de/cpp/slide-transition/) und [animations](/slides/de/cpp/powerpoint-animation/) werden nicht konvertiert.

**Kann ich die Konvertierung beschleunigen, indem ich sie in mehreren Threads ausführe?**

Sie können die Verarbeitung über Dateien hinweg parallelisieren, aber Sie sollten dieselbe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Instanz nicht über Threads hinweg [don’t share](/slides/de/cpp/multithreading/) . Verwenden Sie separate Instanzen/Prozesse pro Datei, um Konflikte zu vermeiden.

**Was passiert mit den Bildern – wo werden sie gespeichert und sind die Pfade relativ?**

[Images](/slides/de/cpp/image/) werden in einen eigenen Ordner exportiert, und die Markdown‑Datei verweist standardmäßig mit relativen Pfaden darauf. Sie können den Basis‑Ausgabepfad und den Namen des Asset‑Ordners konfigurieren, um eine vorhersehbare Repository‑Struktur zu erhalten.