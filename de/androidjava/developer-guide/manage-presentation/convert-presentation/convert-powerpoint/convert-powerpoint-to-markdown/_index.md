---
title: PowerPoint-Präsentationen auf Android in Markdown konvertieren
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
- PPTX nach MD exportieren
- PowerPoint
- Präsentation
- Markdown
- Android
- Java
- Aspose.Slides
description: "PowerPoint-Folien - PPT, PPTX - in sauberes Markdown mit Aspose.Slides für Android über Java konvertieren, Dokumentation automatisieren und Formatierung beibehalten."
---

{{% alert color="info" %}} 

Die Unterstützung für die Konvertierung von PowerPoint zu Markdown wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der Export von PowerPoint zu Markdown erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint-Dokument mit Bildern exportieren möchten, müssen Sie `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` festlegen und zudem den `BasePath` angeben, in dem die im Markdown-Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint zu Markdown konvertieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), um ein Präsentationsobjekt zu repräsentieren.
2. Verwenden Sie die Methode [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), um das Objekt als Markdown-Datei zu speichern.

Dieser Java‑Code zeigt, wie Sie PowerPoint zu Markdown konvertieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint in Markdown-Varianten konvertieren**

Aspose.Slides ermöglicht die Konvertierung von PowerPoint zu Markdown (mit grundlegender Syntax), CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab und 17 weiteren Markdown‑Varianten.

Dieser Java‑Code zeigt, wie Sie PowerPoint zu CommonMark konvertieren:
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


Die 23 unterstützten Markdown‑Varianten sind in der [Flavor‑Aufzählung](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) der Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) aufgeführt.

## **Eine Präsentation mit Bildern in Markdown konvertieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) stellt Eigenschaften und Aufzählungen bereit, mit denen Sie bestimmte Optionen oder Einstellungen für die resultierende Markdown‑Datei festlegen können. Die Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) kann beispielsweise auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder verarbeitet werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn Sie möchten, dass die Bilder im resultierenden Markdown einzeln hintereinander erscheinen, müssen Sie die sequenzielle Option wählen. Dieser Java‑Code zeigt, wie Sie eine Präsentation mit Bildern in Markdown konvertieren:
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

Wenn Sie möchten, dass die Bilder im resultierenden Markdown zusammen erscheinen, müssen Sie die visuelle Option wählen. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und im Markdown‑Dokument wird ein relativer Pfad dafür erstellt) oder Sie können einen bevorzugten Pfad und Ordnernamen angeben.

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

Ja. Text‑[hyperlinks](/slides/de/androidjava/manage-hyperlinks/) werden als Standard‑Markdown‑Links beibehalten. Folien‑[transitions](/slides/de/androidjava/slide-transition/) und -[animations](/slides/de/androidjava/powerpoint-animation/) werden nicht konvertiert.

**Kann ich die Konvertierung beschleunigen, indem ich sie in mehreren Threads ausführe?**

Sie können die Verarbeitung über Dateien hinweg parallelisieren, aber [nicht teilen](/slides/de/androidjava/multithreading/) Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Instanz über Threads hinweg. Verwenden Sie separate Instanzen/Prozesse pro Datei, um Konflikte zu vermeiden.

**Was passiert mit Bildern – wo werden sie gespeichert und sind die Pfade relativ?**

[Images](/slides/de/androidjava/image/) werden in einen eigenen Ordner exportiert, und die Markdown‑Datei verweist standardmäßig mit relativen Pfaden darauf. Sie können den Basis‑Ausgabepfad und den Namen des Asset‑Ordners konfigurieren, um eine vorhersehbare Repository‑Struktur beizubehalten.