---
title: PowerPoint-Präsentationen in PHP in Markdown konvertieren
linktitle: PowerPoint zu Markdown
type: docs
weight: 140
url: /de/php-java/convert-powerpoint-to-markdown/
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
- PHP
- Aspose.Slides
description: "PowerPoint-Folien - PPT, PPTX - mit Aspose.Slides für PHP via Java in sauberes Markdown konvertieren, Dokumentation automatisieren und die Formatierung beibehalten."
---

## **Übersicht**

Aspose.Slides for PHP via Java ermöglicht die Konvertierung von Präsentationsinhalten in Markdown, sodass Sie PowerPoint‑Dateien (PPT, PPTX) und OpenDocument‑Dateien (ODP) für Wikis, Git‑Repositorys und Static‑Site‑Generatoren wiederverwenden können. Die API bewahrt die Folienhierarchie und erzeugt leichtes, lesbares Markdown, sodass Sie Dokumentations‑Pipelines automatisieren und Quellpräsentationen und Markdown‑Dateien perfekt synchron halten können.

Die Unterstützung für die PowerPoint‑zu‑Markdown‑Konvertierung wurde in [Aspose.Slides 23.7](https://releases.aspose.com/slides/php-java/release-notes/2023/aspose-slides-for-php-via-java-23-7-release-notes/) implementiert.

## **Präsentation in Markdown konvertieren**

Dieser Abschnitt erklärt, wie Aspose.Slides PowerPoint‑ und OpenDocument‑Präsentationen (PPT, PPTX, ODP) in sauberes Markdown konvertiert, wobei die ursprüngliche Folienhierarchie, der Text und die Kernformatierung erhalten bleiben, damit Sie den Inhalt in der Dokumentation oder in versionierten Workflows ohne zusätzlichen manuellen Aufwand wiederverwenden können.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) zur Darstellung der Präsentation.
1. Verwenden Sie die Methode [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save), um sie als Markdown‑Datei zu exportieren.

Dieser PHP‑Code zeigt, wie eine PowerPoint‑Präsentation in Markdown konvertiert wird:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```


## **Präsentation in einen Markdown‑Flavor konvertieren**

Aspose.Slides ermöglicht die Konvertierung von PowerPoint‑Präsentationen in Markdown mit grundlegender Syntax sowie in CommonMark, GitHub‑flavoured Markdown, Trello, XWiki, GitLab und siebzehn weitere Markdown‑Flavors.

Der folgende PHP‑Code demonstriert, wie eine PowerPoint‑Präsentation in CommonMark konvertiert wird:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


Die 23 unterstützten Markdown‑Flavors sind in der [Flavor enumeration](https://reference.aspose.com/slides/php-java/aspose.slides/flavor/) aufgelistet.

## **Präsentation mit Bildern in Markdown konvertieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/) stellt Eigenschaften und Aufzählungen bereit, mit denen Sie die resultierende Markdown‑Datei konfigurieren können. Beispielsweise legt die Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/php-java/aspose.slides/markdownexporttype/) fest, wie Bilder behandelt werden: `Sequential`, `TextOnly` oder `Visual`.

{{% alert color="warning" %}}
Standardmäßig enthält der PowerPoint‑zu‑Markdown‑Export **keine Bilder**. Um Bilder einzubetten, rufen Sie `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` auf und setzen Sie den `BasePath`, der angibt, wo die im Markdown‑Dokument referenzierten Bilder gespeichert werden.
{{% /alert %}}

### **Bilder sequenziell konvertieren**

Wenn Sie möchten, dass die Bilder einzeln, nacheinander, im resultierenden Markdown erscheinen, müssen Sie die Option `Sequential` wählen. Der folgende PHP‑Code zeigt, wie eine Präsentation mit Bildern in Markdown konvertiert wird:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


### **Bilder visuell konvertieren**

Wenn Sie möchten, dass die Bilder zusammen im resultierenden Markdown erscheinen, müssen Sie die Option `Visual` wählen. In diesem Fall werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und ein relativer Pfad zu ihnen im Markdown‑Document erzeugt), oder Sie können ein bevorzugtes Verzeichnis und einen Ordnernamen angeben.

Der folgende PHP‑Code demonstriert die Operation:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**Bleiben Hyperlinks beim Export nach Markdown erhalten?**

Ja. Text‑[hyperlinks](/slides/de/php-java/manage-hyperlinks/) werden als Standard‑Markdown‑Links beibehalten. Folien‑[transitions](/slides/de/php-java/slide-transition/) und -[animations](/slides/de/php-java/powerpoint-animation/) werden nicht konvertiert.

**Kann ich die Konvertierung beschleunigen, indem ich sie in mehreren Threads ausführe?**

Sie können die Verarbeitung über Dateien hinweg parallelisieren, aber [don’t share](/slides/de/php-java/multithreading/) Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Instanz über Threads hinweg. Verwenden Sie separate Instanzen/Prozesse pro Datei, um Konkurrenz zu vermeiden.

**Was passiert mit Bildern – wo werden sie gespeichert und sind die Pfade relativ?**

[Images](/slides/de/php-java/image/) werden in einen eigenen Ordner exportiert, und die Markdown‑Datei verweist standardmäßig mit relativen Pfaden darauf. Sie können den Basis‑Ausgabepfad und den Namen des Asset‑Ordners konfigurieren, um eine vorhersehbare Repository‑Struktur zu erhalten.