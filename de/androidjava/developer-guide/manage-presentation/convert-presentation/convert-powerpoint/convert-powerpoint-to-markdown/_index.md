---
title: PowerPoint‑Präsentationen zu Markdown auf Android konvertieren
linktitle: PowerPoint zu Markdown
type: docs
weight: 140
url: /de/androidjava/convert-powerpoint-to-markdown/
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
- Android
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint‑Folien—PPT, PPTX—zu sauberem Markdown mit Aspose.Slides für Android via Java, automatisieren Sie die Dokumentation und erhalten Sie die Formatierung."
---

{{% alert color="info" %}} 

Die Unterstützung für die PowerPoint‑zu‑Markdown‑Konvertierung wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der PowerPoint‑zu‑Markdown‑Export erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint‑Dokument mit Bildern exportieren möchten, müssen Sie `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` setzen und außerdem den `BasePath` angeben, in dem die im Markdown‑Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint in Markdown konvertieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse, um ein Präsentationsobjekt zu repräsentieren.  
2. Verwenden Sie die [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)‑Methode, um das Objekt als Markdown‑Datei zu speichern.

Dieser Java‑Code zeigt, wie Sie PowerPoint in Markdown konvertieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint in Markdown‑Flavor konvertieren**

Aspose.Slides ermöglicht die Konvertierung von PowerPoint in Markdown (mit Grundsyntax), CommonMark, GitHub‑flavoured Markdown, Trello, XWiki, GitLab und 17 weitere Markdown‑Flavors.

Dieser Java‑Code zeigt, wie Sie PowerPoint in CommonMark konvertieren:
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


Die 23 unterstützten Markdown‑Flavors sind in der [Flavor‑Aufzählung](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) der Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) aufgelistet.

## **Eine Präsentation mit Bildern in Markdown konvertieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) bietet Eigenschaften und Aufzählungen, mit denen Sie bestimmte Optionen oder Einstellungen für die erzeugte Markdown‑Datei festlegen können. Das Enum [MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) kann beispielsweise auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder verarbeitet werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn die Bilder einzeln nacheinander im resultierenden Markdown erscheinen sollen, wählen Sie die Option „Sequential“. Dieser Java‑Code zeigt, wie Sie eine Präsentation mit Bildern in Markdown konvertieren:
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

Wenn die Bilder zusammen im resultierenden Markdown erscheinen sollen, wählen Sie die Option „Visual“. In diesem Fall werden die Bilder im aktuellen Arbeitsverzeichnis der Anwendung gespeichert (und ein relativer Pfad zu ihnen im Markdown‑Dokument erzeugt), oder Sie können Ihren gewünschten Pfad und Ordnernamen angeben.

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


## **FAQ**

**Bleiben Hyperlinks beim Export nach Markdown erhalten?**

Ja. Text‑[hyperlinks](/slides/de/androidjava/manage-hyperlinks/) werden als Standard‑Markdown‑Links beibehalten. Folien‑[transitions](/slides/de/androidjava/slide-transition/) und‑[animations](/slides/de/androidjava/powerpoint-animation/) werden nicht konvertiert.

**Kann ich die Konvertierung beschleunigen, indem ich sie in mehreren Threads ausführe?**

Sie können die Verarbeitung über Dateien hinweg parallelisieren, jedoch dürfen Sie dieselbe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Instanz nicht über Threads hinweg teilen. Verwenden Sie separate Instanzen/Prozesse pro Datei, um Konkurrenzprobleme zu vermeiden.

**Was passiert mit Bildern – wo werden sie gespeichert und sind die Pfade relativ?**

[Images](/slides/de/androidjava/image/) werden in einen eigenen Ordner exportiert, und die Markdown‑Datei referenziert sie standardmäßig mit relativen Pfaden. Sie können den Basis‑Ausgabepfad und den Asset‑Ordnernamen konfigurieren, um eine vorhersehbare Repository‑Struktur zu erhalten.