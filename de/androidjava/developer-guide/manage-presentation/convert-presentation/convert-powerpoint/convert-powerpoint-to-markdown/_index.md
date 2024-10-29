---
title: PowerPoint in Markdown in Java konvertieren
type: docs
weight: 140
url: /de/androidjava/convert-powerpoint-to-markdown/
keywords: "PowerPoint in Markdown konvertieren, ppt in md konvertieren, PowerPoint, PPT, PPTX, Präsentation, Markdown, Java, Aspose.Slides für Android über Java"
description: "PowerPoint in Markdown in Java konvertieren"
---

{{% alert color="info" %}} 

Die Unterstützung für die Konvertierung von PowerPoint nach Markdown wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der Export von PowerPoint nach Markdown erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint-Dokument mit Bildern exportieren möchten, müssen Sie `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` setzen und auch den `BasePath` festlegen, in dem die im Markdown-Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint in Markdown konvertieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) -Klasse, um ein Präsentationsobjekt darzustellen.
2. Verwenden Sie die [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) -Methode, um das Objekt als Markdown-Datei zu speichern.

Dieser Java-Code zeigt Ihnen, wie Sie PowerPoint in Markdown konvertieren:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## PowerPoint in Markdown Geschmacksrichtung konvertieren

Aspose.Slides ermöglicht es Ihnen, PowerPoint in Markdown (mit grundlegender Syntax), CommonMark, GitHub-flavored Markdown, Trello, XWiki, GitLab und 17 andere Markdown-Geschmäcker zu konvertieren.

Dieser Java-Code zeigt Ihnen, wie Sie PowerPoint in CommonMark konvertieren:

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

Die 23 unterstützten Markdown-Geschmäcker sind [unter der Flavor-Enumeration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) aus der [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) -Klasse aufgeführt.

## **Präsentation mit Bildern in Markdown konvertieren**

Die [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) -Klasse bietet Eigenschaften und Enumerationen, die es Ihnen ermöglichen, bestimmte Optionen oder Einstellungen für die resultierende Markdown-Datei zu verwenden. Die [MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) -Enumeration kann beispielsweise auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder behandelt werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn Sie möchten, dass die Bilder einzeln nacheinander in der resultierenden Markdown erscheinen, müssen Sie die sequenzielle Option wählen. Dieser Java-Code zeigt Ihnen, wie Sie eine Präsentation mit Bildern in Markdown konvertieren:

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

Wenn Sie möchten, dass die Bilder zusammen in der resultierenden Markdown erscheinen, müssen Sie die visuelle Option wählen. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und ein relativer Pfad wird im Markdown-Dokument für sie erstellt), oder Sie können Ihren bevorzugten Pfad und Ordnernamen angeben.

Dieser Java-Code zeigt den Vorgang:

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