---
title: PowerPoint-Präsentationen in Markdown mit Python konvertieren
linktitle: PowerPoint zu Markdown
type: docs
weight: 140
url: /de/python-net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint in Markdown konvertieren
- OpenDocument in Markdown konvertieren
- Präsentation in Markdown konvertieren
- Folie in Markdown konvertieren
- PPT in Markdown konvertieren
- PPTX in Markdown konvertieren
- ODP in Markdown konvertieren
- PowerPoint in MD konvertieren
- OpenDocument in MD konvertieren
- Präsentation in MD konvertieren
- Folie in MD konvertieren
- PPT in MD konvertieren
- PPTX in MD konvertieren
- ODP in MD konvertieren
- PowerPoint
- OpenDocument
- Präsentation
- Markdown
- Python
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Folien—PPT, PPTX, ODP— in sauberes Markdown mit Aspose.Slides für Python via .NET konvertieren, Dokumentation automatisieren und die Formatierung beibehalten."
---

## **Präsentationen in Markdown konvertieren**

Das nachstehende Beispiel zeigt den einfachsten Weg, eine PowerPoint‑Präsentation mit Aspose.Slides für Python via .NET und den Standardeinstellungen in Markdown zu konvertieren.

1. Instanzieren Sie eine [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), um die Präsentation zu laden.
1. `save` aufrufen, um sie als Markdown‑Datei zu exportieren.

Verwenden Sie das untenstehende Python‑Snippet, um die Konvertierung durchzuführen:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```


## **Präsentationen in Markdown‑Varianten konvertieren**

Aspose.Slides ermöglicht das Konvertieren von Präsentationen in verschiedene Markdown‑Formate, einschließlich einfachem Markdown, CommonMark, GitHub‑flavour‑Markdown, Trello, XWiki, GitLab und 17 weiteren Markdown‑Varianten.

Das folgende Python‑Beispiel zeigt, wie man eine PowerPoint‑Präsentation in CommonMark konvertiert:
```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```


Die 23 unterstützten Markdown‑Varianten sind in der Aufzählung [Flavor](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) der Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) aufgeführt.

## **Präsentationen mit Bildern in Markdown konvertieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) bietet Eigenschaften und Aufzählungen, mit denen Sie die resultierende Markdown‑Datei konfigurieren können. Beispielsweise steuert die Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/), wie Bilder behandelt werden: `SEQUENTIAL`, `TEXT_ONLY` oder `VISUAL`.

### **Bilder sequentiell konvertieren**

Wenn Sie möchten, dass Bilder einzeln – nach und nach – im erzeugten Markdown erscheinen, wählen Sie die Option `SEQUENTIAL`. Das untenstehende Python‑Beispiel zeigt, wie man eine Präsentation mit Bildern in Markdown konvertiert.
```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```


### **Bilder visuell konvertieren**

Wenn Sie möchten, dass die Bilder zusammen im resultierenden Markdown erscheinen, wählen Sie die Option `VISUAL`. In diesem Modus werden die Bilder im aktuellen Verzeichnis der Anwendung gespeichert (und das Markdown‑Dokument verwendet relative Pfade) bzw. Sie können einen benutzerdefinierten Ausgabepfad und Ordnernamen angeben.

Das untenstehende Python‑Beispiel demonstriert diesen Vorgang:
```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```


## **FAQ**

**Bleiben Hyperlinks beim Export nach Markdown erhalten?**

Ja. Text-[Hyperlinks](/slides/de/python-net/manage-hyperlinks/) werden als Standard‑Markdown‑Links beibehalten. Folien-[Übergänge](/slides/de/python-net/slide-transition/) und -[Animationen](/slides/de/python-net/powerpoint-animation/) werden nicht konvertiert.

**Kann ich die Konvertierung beschleunigen, indem ich sie in mehreren Threads ausführe?**

Sie können die Verarbeitung über mehrere Dateien hinweg parallelisieren, aber [nicht teilen](/slides/de/python-net/multithreading/) Sie nicht dieselbe [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Instanz über Threads hinweg. Verwenden Sie für jede Datei separate Instanzen/Prozesse, um Konkurrenz zu vermeiden.

**Was passiert mit Bildern – wo werden sie gespeichert und sind die Pfade relativ?**

[Bilder](/slides/de/python-net/image/) werden in einen eigenen Ordner exportiert, und die Markdown‑Datei verweist standardmäßig mit relativen Pfaden darauf. Sie können den Basis‑Ausgabepfad und den Namen des Asset‑Ordners konfigurieren, um eine vorhersehbare Repository‑Struktur zu erhalten.