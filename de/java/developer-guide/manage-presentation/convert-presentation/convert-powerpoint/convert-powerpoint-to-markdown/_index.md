---
title: PowerPoint-Präsentationen in Java zu Markdown konvertieren
linktitle: PowerPoint zu Markdown
type: docs
weight: 140
url: /de/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "PowerPoint-Folien - PPT, PPTX - in sauberes Markdown konvertieren mit Aspose.Slides für Java, Dokumentation automatisieren und die Formatierung beibehalten."
---

{{% alert color="info" %}} 

Unterstützung für die Konvertierung von PowerPoint nach Markdown wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der Export von PowerPoint nach Markdown erfolgt standardmäßig **without images**. Wenn Sie ein PowerPoint‑Dokument mit Bildern exportieren möchten, müssen Sie `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` setzen und auch den `BasePath` festlegen, in dem die im Markdown‑Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint nach Markdown konvertieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Klasse, um ein Präsentationsobjekt zu repräsentieren.  
2. Verwenden Sie die [Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)‑Methode, um das Objekt als Markdown‑Datei zu speichern.

Dieser Java‑Code zeigt, wie Sie PowerPoint nach Markdown konvertieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## PowerPoint in Markdown‑Varianten konvertieren

Aspose.Slides ermöglicht die Konvertierung von PowerPoint nach Markdown (mit Grundsyntax), CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab und 17 weiteren Markdown‑Varianten.

Dieser Java‑Code zeigt, wie Sie PowerPoint nach CommonMark konvertieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


Die 23 unterstützten Markdown‑Varianten sind [listed under the Flavor enumeration](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) von der [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/)‑Klasse.

## **Präsentation mit Bildern nach Markdown konvertieren**

Die [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/)‑Klasse bietet Eigenschaften und Aufzählungen, mit denen Sie bestimmte Optionen oder Einstellungen für die resultierende Markdown‑Datei verwenden können. Die [MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/)‑Aufzählung kann beispielsweise auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder behandelt werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn Sie möchten, dass die Bilder einzeln nacheinander im resultierenden Markdown erscheinen, müssen Sie die sequenzielle Option wählen. Dieser Java‑Code zeigt, wie Sie eine Präsentation mit Bildern nach Markdown konvertieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Bilder visuell konvertieren**

Wenn Sie möchten, dass die Bilder gemeinsam im resultierenden Markdown erscheinen, müssen Sie die visuelle Option wählen. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und es wird ein relativer Pfad dafür im Markdown‑Dokument erstellt) oder Sie können Ihren bevorzugten Pfad und Ordnernamen angeben.

Dieser Java‑Code demonstriert den Vorgang:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```
