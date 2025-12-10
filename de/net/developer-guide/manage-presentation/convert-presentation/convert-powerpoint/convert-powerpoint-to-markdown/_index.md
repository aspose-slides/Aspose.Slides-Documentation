---
title: PowerPoint-Präsentationen nach Markdown konvertieren in .NET
linktitle: PowerPoint zu Markdown
type: docs
weight: 140
url: /de/net/convert-powerpoint-to-markdown/
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
- .NET
- C#
- Aspose.Slides
description: "PowerPoint-Folien - PPT, PPTX - zu sauberem Markdown mit Aspose.Slides für .NET konvertieren, Dokumentation automatisieren und die Formatierung beibehalten."
---

{{% alert color="info" %}} 

Die Unterstützung für die Konvertierung von PowerPoint zu Markdown wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der Export von PowerPoint zu Markdown erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint-Dokument mit Bildern exportieren möchten, müssen Sie `ExportType = MarkdownExportType.Visual` festlegen und den BasePath setzen, in dem die im Markdown-Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint zu Markdown konvertieren**

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), um ein Präsentationsobjekt zu repräsentieren.
2. Verwenden Sie die [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)Methode, um das Objekt als Markdown-Datei zu speichern.

Dieser C#‑Code zeigt, wie Sie PowerPoint zu Markdown konvertieren:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **PowerPoint in einen Markdown‑Flavor konvertieren**

Aspose.Slides ermöglicht die Konvertierung von PowerPoint zu Markdown (mit Basis‑Syntax), CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab und 17 weiteren Markdown‑Flavors.

Dieser C#‑Code zeigt, wie Sie PowerPoint zu CommonMark konvertieren:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


Die 23 unterstützten Markdown‑Flavors sind [unter der Flavor‑Aufzählung](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) der Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) aufgeführt.

## **Eine Präsentation mit Bildern zu Markdown konvertieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) bietet Eigenschaften und Aufzählungen, mit denen Sie bestimmte Optionen oder Einstellungen für die resultierende Markdown‑Datei festlegen können. Die Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) kann beispielsweise auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder behandelt werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequentiell konvertieren**

Wenn Sie möchten, dass die Bilder im resultierenden Markdown einzeln nacheinander erscheinen, müssen Sie die sequentielle Option wählen. Dieser C#‑Code zeigt, wie Sie eine Präsentation mit Bildern zu Markdown konvertieren:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```


### **Bilder visuell konvertieren**

Wenn Sie möchten, dass die Bilder im resultierenden Markdown zusammen angezeigt werden, müssen Sie die visuelle Option wählen. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und im Markdown‑Dokument wird ein relativer Pfad für sie erstellt) oder Sie können Ihren bevorzugten Pfad und Ordnernamen angeben.

Dieser C#‑Code demonstriert die Vorgehensweise:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```


## **FAQ**

**Bleiben Hyperlinks beim Export nach Markdown erhalten?**

Ja. Text-[Hyperlinks](/slides/de/net/manage-hyperlinks/) werden als Standard‑Markdown‑Links beibehalten. Folien-[Übergänge](/slides/de/net/slide-transition/) und -[Animationen](/slides/de/net/powerpoint-animation/) werden nicht konvertiert.

**Kann ich die Konvertierung beschleunigen, indem ich sie in mehreren Threads ausführe?**

Sie können die Verarbeitung über Dateien hinweg parallelisieren, aber Sie sollten die gleiche [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Instanz nicht über Threads hinweg [teilen](/slides/de/net/multithreading/). Verwenden Sie für jede Datei separate Instanzen/Prozesse, um Konflikte zu vermeiden.

**Was passiert mit Bildern – wo werden sie gespeichert und sind die Pfade relativ?**

[Bilder](/slides/de/net/image/) werden in einen eigenen Ordner exportiert, und die Markdown‑Datei verweist standardmäßig mit relativen Pfaden darauf. Sie können den Basis‑Ausgabepfad und den Namen des Asset‑Ordners konfigurieren, um eine vorhersehbare Repository‑Struktur beizubehalten.