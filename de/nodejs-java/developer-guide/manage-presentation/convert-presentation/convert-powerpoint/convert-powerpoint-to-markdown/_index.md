---
title: PowerPoint in JavaScript zu Markdown konvertieren
type: docs
weight: 140
url: /de/nodejs-java/convert-powerpoint-to-markdown/
keywords: "PowerPoint zu Markdown konvertieren, ppt zu md konvertieren, PowerPoint, PPT, PPTX, Präsentation, Markdown, Java, Aspose.Slides für Node.js via Java"
description: "PowerPoint in JavaScript zu Markdown konvertieren"
---

{{% alert color="info" %}} 

Unterstützung für die Konvertierung von PowerPoint zu Markdown wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der Export von PowerPoint zu Markdown erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint-Dokument mit Bildern exportieren möchten, müssen Sie `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` aufrufen und außerdem den `BasePath` festlegen, in dem die im Markdown‑Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint zu Markdown konvertieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Klasse, um ein Präsentationsobjekt zu repräsentieren.  
2. Verwenden Sie die [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) Methode, um das Objekt als Markdown‑Datei zu speichern.

Dieser JavaScript‑Code zeigt, wie Sie PowerPoint zu Markdown konvertieren:
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


## **PowerPoint zu Markdown‑Variante konvertieren**

Aspose.Slides ermöglicht die Konvertierung von PowerPoint zu Markdown (mit Grundsyntax), CommonMark, GitHub‑flavoured Markdown, Trello, XWiki, GitLab und 17 weiteren Markdown‑Varianten.

Dieser JavaScript‑Code zeigt, wie Sie PowerPoint zu CommonMark konvertieren:
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


Die 23 unterstützten Markdown‑Varianten sind [unter der Aufzählung Flavor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/flavor/) aus der Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) aufgelistet.

## **Präsentation mit Bildern zu Markdown konvertieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) bietet Eigenschaften und Aufzählungen, mit denen Sie bestimmte Optionen oder Einstellungen für die resultierende Markdown‑Datei festlegen können. Der Enum [MarkdownExportType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownexporttype/) kann auf Werte gesetzt werden, die bestimmen, wie Bilder dargestellt oder verarbeitet werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn Sie möchten, dass die Bilder im resultierenden Markdown nacheinander einzeln erscheinen, müssen Sie die Option **Sequential** wählen. Dieser JavaScript‑Code zeigt, wie Sie eine Präsentation mit Bildern zu Markdown konvertieren:
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

Wenn Sie möchten, dass die Bilder im resultierenden Markdown zusammen erscheinen, müssen Sie die Option **Visual** wählen. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und im Markdown‑Dokument wird ein relativer Pfad dafür erstellt), oder Sie können einen gewünschten Pfad und Ordnernamen angeben.

Dieser JavaScript‑Code demonstriert die Vorgehensweise:
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

Ja. Text-[Hyperlinks](/slides/de/nodejs-java/manage-hyperlinks/) werden als Standard‑Markdown‑Links beibehalten. Folien-[Übergänge](/slides/de/nodejs-java/slide-transition/) und -[Animationen](/slides/de/nodejs-java/powerpoint-animation/) werden nicht konvertiert.

**Kann ich die Konvertierung beschleunigen, indem ich sie in mehreren Threads ausführe?**

Sie können die Verarbeitung über Dateien hinweg parallelisieren, jedoch sollten Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) Instanz über Threads hinweg teilen. Verwenden Sie separate Instanzen/Prozesse pro Datei, um Konflikte zu vermeiden.

**Was passiert mit den Bildern – wo werden sie gespeichert und sind die Pfade relativ?**

[Bilder](/slides/de/nodejs-java/image/) werden in einen eigenen Ordner exportiert, und die Markdown‑Datei verweist standardmäßig mit relativen Pfaden auf sie. Sie können den Basis‑Ausgabepfad und den Asset‑Ordnernamen konfigurieren, um eine konsistente Repository‑Struktur beizubehalten.