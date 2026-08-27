---
title: PowerPoint-Präsentationen in Markdown mit Python konvertieren
linktitle: PowerPoint zu Markdown
type: docs
weight: 140
url: /de/python-net/convert-powerpoint-to-markdown/
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
- Markdown-Bildexport
- CDN-Bildlinks
- PowerPoint
- Präsentation
- Markdown
- Python
- Python via .NET
- Aspose.Slides
description: "Konvertieren Sie PPT- und PPTX-Präsentationen in Markdown mit Python und steuern Sie, wo exportierte Bilder gespeichert werden und wie das erzeugte Markdown auf sie verweist."
---
## **Übersicht**

Aspose.Slides for Python via .NET kann PPT- und PPTX-Präsentationen in Markdown für Dokumentation, statische Websites, Inhaltsmigration und Versionskontroll‑Workflows konvertieren. Sie können einen Markdown‑Flavor wählen, steuern, wie Folieninhalt gerendert wird, und entscheiden, wo exportierte Bilder gespeichert werden und wie das erzeugte Markdown auf sie verweist.

Standardmäßig verwendet der Markdown‑Export eine rein textbasierte Ausgabe. Um visuelle Inhalte zu exportieren, setzen Sie die [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/markdownsaveoptions/export_type/)‑Eigenschaft auf den Wert `SEQUENTIAL` oder `VISUAL` aus der Aufzählung [MarkdownExportType](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/markdownexporttype/). `SEQUENTIAL` rendert Folienelemente getrennt und in Reihenfolge, während `VISUAL` gruppierte Elemente zusammenhält, um deren visuelle Beziehung zu bewahren. Der Wert `TEXT_ONLY` erzeugt keine Bildressourcen.

## **Präsentation in Markdown konvertieren**

Laden Sie die Quelldatei mit der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) und rufen Sie anschließend die Methode [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/ipresentation/save/) mit dem Wert `MD` aus der Aufzählung [SaveFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/) auf.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Markdown‑Flavor auswählen**

Die Eigenschaft [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/markdownsaveoptions/flavor/) steuert die für die Ausgabe verwendete Markdown‑Spezifikation. Die Aufzählung [Flavor](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/flavor/) enthält CommonMark, GitHub Flavored Markdown und weitere unterstützte Varianten.

Das folgende Beispiel exportiert eine Präsentation als CommonMark:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Bilder mit dem standardmäßigen lokalen Speicherverhalten exportieren**

Die Klasse [MarkdownSaveOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/markdownsaveoptions/) stellt zwei Eigenschaften für lokal gespeicherte Bilder bereit:

- [base_path](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/markdownsaveoptions/base_path/) gibt das Basisverzeichnis für das Markdown‑Dokument und dessen Ressourcen an.
- [images_save_folder_name](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) gibt das Unterverzeichnis für Bilder an. Der Standardwert ist `Images`.

Das folgende Beispiel rendert visuelle Inhalte, schreibt Bilder nach `output/assets` und erzeugt relative Bildverweise im Markdown‑Dokument:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Aspose.Slides erstellt das Bildunterverzeichnis, wenn der Export Bildressourcen erzeugt, aber die Anwendung muss `base_path` anlegen, bevor die Markdown‑Datei gespeichert wird.

## **Markdown und Bilder für die Veröffentlichung vorbereiten**

Aspose.Slides for Python via .NET stellt die .NET‑Callbacks zum Bildspeichern nicht bereit, um jeden erzeugten Bildlink beim Export zu ersetzen. Stattdessen exportieren Sie das Markdown‑Dokument und den zugehörigen Bildordner in ein Publikationsverzeichnis und veröffentlichen dieses Verzeichnis, ohne die relative Struktur zu ändern.

Das folgende Beispiel bereitet `cdn-origin/presentations/quarterly-report` als eingehängtes oder synchronisiertes Publikationsverzeichnis vor. Das Beispiel führt keinen Netzwerk‑Upload aus: Die erzeugten Links werden gültig, sobald das Verzeichnis an der vorgesehenen Website oder CDN‑Stelle veröffentlicht wird.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Veröffentlichen Sie `presentation.md` zusammen mit dem `assets`‑Verzeichnis. Das Markdown‑Dokument verwendet relative Bildverweise, sodass beide Elemente am Zielort dieselbe Beziehung beibehalten müssen. Wenn ein Veröffentlichungssystem absolute externe URLs verlangt, überschreiben Sie die erzeugten Links in einem separaten Nachbearbeitungsschritt, nachdem alle Bilddateien veröffentlicht wurden.

## **FAQ**

**Können Python‑Callbacks einzelne Bilddateien und Links während des Markdown‑Exports anpassen?**

Nein. Aspose.Slides for Python via .NET stellt die .NET‑Callbacks `ImageSaving` und `SvgImageSaving` nicht bereit. Konfigurieren Sie die lokale Ausgabe mit [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/markdownsaveoptions/base_path/) und [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/), anschließend veröffentlichen oder nachbearbeiten Sie die erzeugten Ressourcen.

**Wo werden exportierte Bilder gespeichert?**

Der Bildspeicherort wird durch [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/markdownsaveoptions/base_path/) und [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) gesteuert. Das Markdown‑Dokument referenziert diese Bilder mit relativen Pfaden.

**Welchen Pfadtrennzeichen sollten Bildlinks verwenden?**

Verwenden Sie Vorwärtsschrägstriche in Markdown‑Links und URLs. Nutzen Sie `os.path.join` nur für Dateisystempfade und normalisieren Sie jeden während der Nachbearbeitung erstellten Link separat.

**Werden Hyperlinks beim Markdown‑Export beibehalten?**

Ja. Text [Hyperlinks](/slides/de/python-net/manage-hyperlinks/) werden als Standard‑Markdown‑Links beibehalten. Folien-[Übergänge](/slides/de/python-net/slide-transition/) und -[Animationen](/slides/de/python-net/powerpoint-animation/) werden nicht konvertiert.

**Können Präsentationen parallel in Markdown konvertiert werden?**

Sie können verschiedene Präsentationsdateien parallel verarbeiten, sollten aber dieselbe [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Instanz nicht zwischen Threads teilen. Befolgen Sie die [multithreading guidelines](/slides/de/python-net/multithreading/) und verwenden Sie für jede Datei eine separate Instanz.