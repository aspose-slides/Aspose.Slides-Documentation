---
title: PowerPoint in Markdown konvertieren in C#
type: docs
weight: 140
url: /net/convert-powerpoint-to-markdown/
keywords: "PowerPoint in Markdown konvertieren, ppt in md konvertieren, PowerPoint, PPT, PPTX, Präsentation, Markdown, C#, Csharp, .NET, Aspose.Slides"
description: "PowerPoint in Markdown konvertieren in C#"
---

{{% alert color="info" %}} 

Die Unterstützung für die Konvertierung von PowerPoint zu Markdown wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der Export von PowerPoint zu Markdown erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint-Dokument mit Bildern exportieren möchten, müssen Sie `ExportType = MarkdownExportType.Visual` setzen und den BasePath angeben, unter dem die im Markdown-Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint in Markdown konvertieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, um ein Präsentationsobjekt darzustellen.
2. Verwenden Sie die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) Methode, um das Objekt als Markdown-Datei zu speichern.

Dieser C#-Code zeigt Ihnen, wie Sie PowerPoint in Markdown konvertieren:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## PowerPoint in Markdown Flavor konvertieren

Aspose.Slides ermöglicht es Ihnen, PowerPoint in Markdown (mit grundlegender Syntax), CommonMark, GitHub-flavored Markdown, Trello, XWiki, GitLab und 17 andere Markdown-Flavors zu konvertieren.

Dieser C#-Code zeigt Ihnen, wie Sie PowerPoint in CommonMark konvertieren:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

Die 23 unterstützten Markdown-Flavors sind [unter der Flavor-Enumeration](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) aus der [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) Klasse aufgelistet.

## **Präsentation mit Bildern in Markdown konvertieren**

Die [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) Klasse bietet Eigenschaften und Enumerationen, die es Ihnen ermöglichen, bestimmte Optionen oder Einstellungen für die resultierende Markdown-Datei zu verwenden. Der [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) Enum kann beispielsweise auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder behandelt werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn Sie möchten, dass die Bilder einzeln nacheinander im resultierenden Markdown erscheinen, müssen Sie die sequenzielle Option wählen. Dieser C#-Code zeigt Ihnen, wie Sie eine Präsentation mit Bildern in Markdown konvertieren:

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

Wenn Sie möchten, dass die Bilder zusammen im resultierenden Markdown erscheinen, müssen Sie die visuelle Option wählen. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und ein relativer Pfad für sie im Markdown-Dokument erstellt), oder Sie können Ihren bevorzugten Pfad und Ordnernamen angeben.

Dieser C#-Code demonstriert die Operation:

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