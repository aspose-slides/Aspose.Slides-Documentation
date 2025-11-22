---
title: PowerPoint in Markdown konvertieren in C#
type: docs
weight: 140
url: /de/net/convert-powerpoint-to-markdown/
keywords: "PowerPoint in Markdown konvertieren, ppt zu md konvertieren, PowerPoint, PPT, PPTX, Präsentation, Markdown, C#, Csharp, .NET, Aspose.Slides"
description: "PowerPoint in Markdown konvertieren in C#"
---

{{% alert color="info" %}} 

Die Unterstützung für die Konvertierung von PowerPoint nach Markdown wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der Export von PowerPoint nach Markdown erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint-Dokument mit Bildern exportieren möchten, müssen Sie `ExportType = MarkdownExportType.Visual` festlegen und den BasePath setzen, in dem die im Markdown-Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint nach Markdown konvertieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), um ein Präsentationsobjekt zu repräsentieren.
2. Verwenden Sie die Methode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save), um das Objekt als Markdown-Datei zu speichern.

Dieser C#‑Code zeigt, wie PowerPoint nach Markdown konvertiert wird:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **PowerPoint in Markdown‑Varianten konvertieren**

Aspose.Slides ermöglicht die Konvertierung von PowerPoint nach Markdown (mit Grundsyntax), CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab und weiteren 17 Markdown‑Varianten.

Dieser C#‑Code zeigt, wie PowerPoint nach CommonMark konvertiert wird:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


Die 23 unterstützten Markdown‑Varianten sind im [Flavor‑Enum](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) der Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) aufgelistet.

## **Präsentation mit Bildern in Markdown konvertieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) bietet Eigenschaften und Aufzählungen, mit denen Sie bestimmte Optionen oder Einstellungen für die resultierende Markdown‑Datei festlegen können. Das Enum [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) kann beispielsweise auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder behandelt werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn die Bilder einzeln nacheinander im resultierenden Markdown erscheinen sollen, wählen Sie die sequenzielle Option. Dieser C#‑Code zeigt, wie eine Präsentation mit Bildern nach Markdown konvertiert wird:
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

Wenn die Bilder gemeinsam im resultierenden Markdown erscheinen sollen, wählen Sie die visuelle Option. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und ein relativer Pfad wird im Markdown‑Dokument erzeugt), oder Sie können Ihren bevorzugten Pfad und Ordnernamen angeben.

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

Ja. Text-[Hyperlinks](/slides/de/net/manage-hyperlinks/) werden als standardmäßige Markdown‑Links beibehalten. Folien-[Übergänge](/slides/de/net/slide-transition/) und -[Animationen](/slides/de/net/powerpoint-animation/) werden nicht konvertiert.

**Kann ich die Konvertierung beschleunigen, indem ich sie in mehreren Threads ausführe?**

Sie können die Verarbeitung dateiweise parallelisieren, aber [teilen Sie nicht](/slides/de/net/multithreading/) dieselbe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Instanz über Threads hinweg. Verwenden Sie für jede Datei separate Instanzen/Prozesse, um Konkurrenz zu vermeiden.

**Was passiert mit den Bildern – wo werden sie gespeichert und sind die Pfade relativ?**

[Bilder](/slides/de/net/image/) werden in einen eigenen Ordner exportiert, und die Markdown‑Datei verweist standardmäßig mit relativen Pfaden darauf. Sie können den Basisausgabepfad und den Asset‑Ordnernamen konfigurieren, um eine vorhersehbare Repository‑Struktur beizubehalten.