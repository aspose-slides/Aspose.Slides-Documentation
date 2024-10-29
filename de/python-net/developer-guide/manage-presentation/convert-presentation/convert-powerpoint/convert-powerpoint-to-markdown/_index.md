---
title: PowerPoint in Markdown in Python konvertieren
type: docs
weight: 140
url: /de/python-net/convert-powerpoint-to-markdown/
keywords: "PowerPoint in Markdown konvertieren, ppt in md konvertieren, PowerPoint, PPT, PPTX, Präsentation, Markdown, Python, Aspose.Slides für Python über .NET"
description: "PowerPoint in Markdown in Python konvertieren"
---

{{% alert color="info" %}} 

Die Unterstützung für die Konvertierung von PowerPoint in Markdown wurde in [Aspose.Slides 23.7](https://docs.aspose.com/slides/python-net/aspose-slides-for-python-net-23-7-release-notes/) implementiert.

{{% /alert %}} 

{{% alert color="warning" %}} 

Der Export von PowerPoint nach Markdown erfolgt standardmäßig **ohne Bilder**. Wenn Sie ein PowerPoint-Dokument mit Bildern exportieren möchten, müssen Sie `saveOptions.export_type = MarkdownExportType.VISUAL` festlegen und den `base_path` angeben, in dem die in dem Markdown-Dokument referenzierten Bilder gespeichert werden.

{{% /alert %}} 

## **PowerPoint in Markdown konvertieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, um ein Präsentationsobjekt darzustellen.
2. Verwenden Sie die [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods) Methode, um das Objekt als Markdown-Datei zu speichern.

Dieser Python-Code zeigt Ihnen, wie Sie PowerPoint in Markdown konvertieren: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:  
    pres.save("pres.md", slides.export.SaveFormat.MD)
```

## PowerPoint in Markdown Flavor konvertieren

Aspose.Slides ermöglicht Ihnen die Konvertierung von PowerPoint in Markdown (mit grundlegender Syntax), CommonMark, GitHub-flavored Markdown, Trello, XWiki, GitLab und 17 weiteren Markdown-Flavors.

Dieser Python-Code zeigt Ihnen, wie Sie PowerPoint in CommonMark konvertieren: 

```python
from aspose.slides import Presentation
from aspose.slides.dom.export.markdown.saveoptions import MarkdownSaveOptions, Flavor
from aspose.slides.export import SaveFormat

with Presentation("pres.pptx") as pres:  
    saveOptions = MarkdownSaveOptions()
    saveOptions.flavor = Flavor.COMMONMARK

    pres.save("pres.md", SaveFormat.MD, saveOptions)
```

Die 23 unterstützten Markdown-Flavors sind [unter der Flavor-Enumeration](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) aus der [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) Klasse aufgeführt.

## **Präsentation mit Bildern in Markdown konvertieren**

Die [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) Klasse bietet Eigenschaften und Aufzählungen, die es Ihnen ermöglichen, bestimmte Optionen oder Einstellungen für die resultierende Markdown-Datei zu verwenden. Die [MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) Enumeration kann beispielsweise auf Werte gesetzt werden, die festlegen, wie Bilder gerendert oder verarbeitet werden: `Sequential`, `TextOnly`, `Visual`.

### **Bilder sequenziell konvertieren**

Wenn Sie möchten, dass die Bilder einzeln nacheinander in der resultierenden Markdown erscheinen, müssen Sie die sequenzielle Option wählen. Dieser Python-Code zeigt Ihnen, wie Sie eine Präsentation mit Bildern in Markdown konvertieren: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    markdownSaveOptions = slides.export.MarkdownSaveOptions()
    markdownSaveOptions.show_hidden_slides = True
    markdownSaveOptions.show_slide_number = True
    markdownSaveOptions.flavor = slides.export.Flavor.GITHUB
    markdownSaveOptions.export_type = slides.export.MarkdownExportType.SEQUENTIAL
    markdownSaveOptions.new_line_type = slides.export.NewLineType.WINDOWS
    
    pres.save("doc.md", [ 1, 2, 3, 4, 5, 6, 7, 8, 9 ], slides.export.SaveFormat.MD, markdownSaveOptions)
```

### **Bilder visuell konvertieren**

Wenn Sie möchten, dass die Bilder gemeinsam in der resultierenden Markdown erscheinen, müssen Sie die visuelle Option wählen. In diesem Fall werden Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und ein relativer Pfad wird für sie im Markdown-Dokument erstellt), oder Sie können Ihren bevorzugten Pfad und Ordnernamen angeben.

Dieser Python-Code demonstriert den Vorgang: 

```python
from aspose.slides import Presentation
from aspose.slides.dom.export.markdown.saveoptions import MarkdownSaveOptions, MarkdownExportType
from aspose.slides.export import SaveFormat

with Presentation("pres.pptx") as pres:  
    outPath = "c:\\documents"

    saveOptions = MarkdownSaveOptions()
    saveOptions.export_type = MarkdownExportType.VISUAL
    saveOptions.images_save_folder_name = "md-images"
    saveOptions.base_path = outPath

    pres.save(outPath + "\\pres.md", SaveFormat.MD, saveOptions)
```