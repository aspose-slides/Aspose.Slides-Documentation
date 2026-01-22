---
title: PowerPoint-Präsentationen in Markdown mit JavaScript konvertieren
linktitle: PowerPoint zu Markdown
type: docs
weight: 140
url: /de/nodejs-java/convert-powerpoint-to-markdown/
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
- exportPPTX zu MD
- PowerPoint
- Präsentation
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint-Folien in JavaScript - PPT, PPTX - mit Aspose.Slides für Node.js über Java in sauberes Markdown konvertieren, Dokumentation automatisieren und die Formatierung beibehalten."
---

{{% alert color="warning" %}} 

Der PowerPoint-zu-Markdown-Export erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint-Dokument mit Bildern exportieren möchten, müssen Sie `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` aufrufen und außerdem den `BasePath` festlegen, in dem die im Markdown-Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint in Markdown konvertieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)-Klasse, um ein Präsentationsobjekt zu repräsentieren.
2. Verwenden Sie die [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-)-Methode, um das Objekt als Markdown-Datei zu speichern.

Dieser JavaScript-Code zeigt, wie PowerPoint in Markdown konvertiert wird:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint in ein Markdown-Format konvertieren**

Aspose.Slides ermöglicht die Konvertierung von PowerPoint in Markdown (mit grundlegender Syntax), CommonMark, GitHub-flavored Markdown, Trello, XWiki, GitLab und 17 weitere Markdown-Formate.

Dieser JavaScript-Code zeigt, wie PowerPoint in CommonMark konvertiert wird:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Die 23 unterstützten Markdown-Formate sind [unter der Aufzählung Flavor aufgelistet](https://reference.aspose.com/slides/nodejs-java/aspose.slides/flavor/) in der Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/).

## **Präsentation mit Bildern in Markdown konvertieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) bietet Eigenschaften und Aufzählungen, mit denen Sie bestimmte Optionen oder Einstellungen für die resultierende Markdown-Datei festlegen können. Die Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownexporttype/) kann beispielsweise auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder behandelt werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn Sie möchten, dass die Bilder einzeln nacheinander im resultierenden Markdown erscheinen, müssen Sie die sequenzielle Option wählen. Dieser JavaScript-Code zeigt, wie eine Präsentation mit Bildern in Markdown konvertiert wird:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Bilder visuell konvertieren**

Wenn Sie möchten, dass die Bilder zusammen im resultierenden Markdown erscheinen, müssen Sie die visuelle Option wählen. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und ein relativer Pfad wird im Markdown-Dokument dafür erzeugt) oder Sie können Ihren bevorzugten Pfad und Ordnernamen angeben.

Dieser JavaScript-Code demonstriert den Vorgang:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Bleiben Hyperlinks beim Export nach Markdown erhalten?**

Ja. Text-[hyperlinks](/slides/de/nodejs-java/manage-hyperlinks/) werden als Standard-Markdown-Links beibehalten. Folien-[transitions](/slides/de/nodejs-java/slide-transition/) und -[animations](/slides/de/nodejs-java/powerpoint-animation/) werden nicht konvertiert.

**Kann ich die Konvertierung beschleunigen, indem ich sie in mehreren Threads ausführe?**

Sie können Dateien parallel verarbeiten, dürfen jedoch nicht dieselbe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)-Instanz über Threads hinweg teilen. Verwenden Sie separate Instanzen/Prozesse pro Datei, um Kontention zu vermeiden.

**Was passiert mit Bildern – wo werden sie gespeichert und sind die Pfade relativ?**

[Images](/slides/de/nodejs-java/image/) werden in einen eigenen Ordner exportiert, und die Markdown-Datei verweist standardmäßig mit relativen Pfaden darauf. Sie können den Basis-Ausgabe-Pfad und den Asset-Ordnernamen konfigurieren, um eine vorhersehbare Repository-Struktur zu erhalten.