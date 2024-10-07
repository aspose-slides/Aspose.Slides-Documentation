---
title: PowerPoint in Markdown konvertieren in C++
type: docs
weight: 140
url: /cpp/convert-powerpoint-to-markdown/
keywords: "PowerPoint in Markdown konvertieren, ppt in md konvertieren, PowerPoint, PPT, PPTX, Präsentation, Markdown, C++, CPP, Aspose.Slides für C++"
description: "PowerPoint in Markdown konvertieren in C++"
---

{{% alert color="info" %}} 

Die Unterstützung für die Konvertierung von PowerPoint in Markdown wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der Export von PowerPoint nach Markdown erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint-Dokument mit Bildern exportieren möchten, müssen Sie `SaveOptions::MarkdownExportType::Visual)` festlegen und auch den `BasePath` angeben, in dem die in dem Markdown-Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint in Markdown konvertieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse, um ein Präsentationsobjekt darzustellen.
2. Verwenden Sie die [Save ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method)Methode, um das Objekt als Markdown-Datei zu speichern.

Dieser C++-Code zeigt Ihnen, wie Sie PowerPoint in Markdown konvertieren:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## PowerPoint in Markdown Geschmack konvertieren

Aspose.Slides ermöglicht es Ihnen, PowerPoint in Markdown (mit grundlegender Syntax), CommonMark, GitHub-flavored Markdown, Trello, XWiki, GitLab und 17 andere Markdown-Geschmäcker zu konvertieren.

Dieser C++-Code zeigt Ihnen, wie Sie PowerPoint in CommonMark konvertieren:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

Die 23 unterstützten Markdown-Geschmäcker sind [unter der Flavor-Enumeration aufgelistet](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) aus der [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) Klasse.

## **Präsentation mit Bildern in Markdown konvertieren**

Die [MarkdownSaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) Klasse bietet Eigenschaften und Enumerationen, die es Ihnen ermöglichen, bestimmte Optionen oder Einstellungen für die resultierende Markdown-Datei zu verwenden. Der [MarkdownExportType](https://reference.aspose.com/slides/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) Enum kann beispielsweise auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder behandelt werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn Sie möchten, dass die Bilder einzeln nacheinander im resultierenden Markdown erscheinen, müssen Sie die sequenzielle Option wählen. Dieser C++-Code zeigt Ihnen, wie Sie eine Präsentation mit Bildern in Markdown konvertieren:

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

Wenn Sie möchten, dass die Bilder zusammen im resultierenden Markdown erscheinen, müssen Sie die visuelle Option wählen. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und ein relativer Pfad wird für sie im Markdown-Dokument erstellt), oder Sie können Ihren bevorzugten Pfad und Ordnernamen angeben.

Dieser C++-Code demonstriert die Operation: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```