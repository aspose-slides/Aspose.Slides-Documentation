---
title: PowerPoint-Präsentationen in Java nach Markdown konvertieren
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
- PPT nach MD exportieren
- PPTX nach MD exportieren
- PowerPoint
- Präsentation
- Markdown
- Java
- Aspose.Slides
description: "PowerPoint‑Folien—PPT, PPTX—mit Aspose.Slides for Java in sauberes Markdown konvertieren, Dokumentation automatisieren und Formatierung beibehalten."
---

{{% alert color="info" %}}

Die Unterstützung für die Konvertierung von PowerPoint zu Markdown wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/) implementiert.

{{% /alert %}}

{{% alert color="warning" %}}

Der Export von PowerPoint nach Markdown erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint‑Dokument mit Bildern exportieren möchten, müssen Sie `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` setzen und außerdem den `BasePath` angeben, in dem die im Markdown‑Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}}

## **PowerPoint zu Markdown konvertieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), um ein Präsentationsobjekt zu repräsentieren.  
2. Verwenden Sie die [Speichern](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)-Methode, um das Objekt als Markdown‑Datei zu speichern.

Dieses Java‑Beispiel zeigt, wie Sie PowerPoint in Markdown konvertieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint in Markdown‑Variante konvertieren**

Aspose.Slides ermöglicht die Konvertierung von PowerPoint in Markdown (mit Grundsyntax), CommonMark, GitHub‑flavoured Markdown, Trello, XWiki, GitLab und 17 weitere Markdown‑Varianten.

Dieses Java‑Beispiel zeigt, wie Sie PowerPoint in CommonMark konvertieren:
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


Die 23 unterstützten Markdown‑Varianten sind in der [Flavor‑Aufzählung](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) der Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) aufgelistet.

## **Eine Präsentation mit Bildern in Markdown konvertieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) stellt Eigenschaften und Aufzählungen bereit, mit denen Sie bestimmte Optionen oder Einstellungen für die resultierende Markdown‑Datei festlegen können. Die Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/) kann beispielsweise auf Werte gesetzt werden, die bestimmen, wie Bilder gerendert oder verarbeitet werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn die Bilder im resultierenden Markdown einzeln nacheinander erscheinen sollen, müssen Sie die sequenzielle Option wählen. Dieses Java‑Beispiel zeigt, wie Sie eine Präsentation mit Bildern in Markdown konvertieren:
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

Wenn die Bilder im resultierenden Markdown zusammen erscheinen sollen, müssen Sie die visuelle Option wählen. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und im Markdown‑Dokument wird ein relativer Pfad dafür erstellt) oder Sie können Ihren bevorzugten Pfad und Ordnernamen angeben.

Dieses Java‑Beispiel demonstriert die Vorgehensweise:
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

Ja. Text-[Hyperlinks](/slides/de/java/manage-hyperlinks/) werden als Standard‑Markdown‑Links beibehalten. Folien-[Übergänge](/slides/de/java/slide-transition/) und -[Animationen](/slides/de/java/powerpoint-animation/) werden nicht konvertiert.

**Kann ich die Konvertierung durch Ausführung in mehreren Threads beschleunigen?**

Sie können die Verarbeitung über Dateien hinweg parallelisieren, jedoch sollten Sie die gleiche [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Instanz nicht über Threads hinweg teilen. Verwenden Sie separate Instanzen/Prozesse pro Datei, um Ressourcenkonflikte zu vermeiden.  

**Was passiert mit Bildern – wo werden sie gespeichert und sind die Pfade relativ?**

[Bilder](/slides/de/java/image/) werden in einen eigenen Ordner exportiert, und die Markdown‑Datei referenziert sie standardmäßig mit relativen Pfaden. Sie können den Basis‑Ausgabepfad und den Namen des Asset‑Ordners konfigurieren, um eine vorhersehbare Repository‑Struktur beizubehalten.