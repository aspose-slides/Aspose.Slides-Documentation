---
title: PowerPoint-Präsentationen in .NET zu Markdown konvertieren
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
- PPTX exportieren zu MD
- PowerPoint
- Präsentation
- Markdown
- .NET
- C#
- Aspose.Slides
description: "PowerPoint-Folien - PPT, PPTX - mit Aspose.Slides für .NET in sauberes Markdown konvertieren, Dokumentation automatisieren und das Layout beibehalten."
---

{{% alert color="info" %}} 

Unterstützung für die Konvertierung von PowerPoint zu Markdown wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der PowerPoint‑zu‑Markdown‑Export erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint‑Dokument mit Bildern exportieren möchten, müssen Sie `ExportType = MarkdownExportType.Visual` festlegen und den BasePath angeben, in dem die im Markdown‑Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint zu Markdown konvertieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), um ein Präsentationsobjekt darzustellen.  
2. Verwenden Sie die Methode [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save), um das Objekt als Markdown‑Datei zu speichern.

Dieser C#‑Code zeigt, wie Sie PowerPoint zu Markdown konvertieren:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **PowerPoint zu einem Markdown‑Flavor konvertieren**

Aspose.Slides ermöglicht die Konvertierung von PowerPoint zu Markdown (mit Basissyntax), CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab und 17 weiteren Markdown‑Flavors.

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


Die 23 unterstützten Markdown‑Flavors sind [unter der Aufzählung Flavor](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) aus der Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) aufgelistet.

## **Präsentation mit Bildern zu Markdown konvertieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) bietet Eigenschaften und Aufzählungen, mit denen Sie bestimmte Optionen oder Einstellungen für die resultierende Markdown‑Datei festlegen können. Die Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) kann beispielsweise auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder behandelt werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn die Bilder einzeln nacheinander im resultierenden Markdown erscheinen sollen, wählen Sie die sequenzielle Option. Dieser C#‑Code zeigt, wie Sie eine Präsentation mit Bildern zu Markdown konvertieren:
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

Wenn die Bilder zusammen im resultierenden Markdown erscheinen sollen, wählen Sie die visuelle Option. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und ein relativer Pfad wird im Markdown‑Dokument für sie erstellt) oder Sie können Ihren bevorzugten Pfad und Ordnernamen angeben.

Dieser C#‑Code demonstriert den Vorgang:
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

Ja. Text‑[Hyperlinks](/slides/de/net/manage-hyperlinks/) werden als Standard‑Markdown‑Links beibehalten. Folien‑[Transitions](/slides/de/net/slide-transition/) und -[Animations](/slides/de/net/powerpoint-animation/) werden nicht konvertiert.

**Kann ich die Konvertierung durch Mehrfach‑Threading beschleunigen?**

Sie können dateiweise parallelisieren, aber [don’t share](/slides/de/net/multithreading/) dieselbe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Instanz über Threads hinweg. Verwenden Sie separate Instanzen/Prozesse pro Datei, um Konflikte zu vermeiden.

**Was passiert mit Bildern – wo werden sie gespeichert und sind die Pfade relativ?**

[Images](/slides/de/net/image/) werden in einen eigenen Ordner exportiert, und die Markdown‑Datei referenziert sie standardmäßig mit relativen Pfaden. Sie können den Basis‑Ausgabepfad und den Asset‑Ordnernamen konfigurieren, um eine vorhersehbare Repository‑Struktur beizubehalten.