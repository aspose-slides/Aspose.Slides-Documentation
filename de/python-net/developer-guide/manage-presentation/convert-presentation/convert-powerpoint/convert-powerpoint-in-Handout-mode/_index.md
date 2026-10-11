---
title: Präsentationen im Handout‑Modus mit Python konvertieren
linktitle: Handout‑Modus
type: docs
weight: 150
url: /de/python-net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Handout‑Modus
- Handout
- PowerPoint
- Präsentation
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Präsentationen in Python in Handouts konvertieren. Folien pro Seite festlegen, Notizen behalten, in PDF oder Bilder exportieren mit Aspose.Slides, mit Beispielcode. Jetzt kostenlos testen."
---
## **Einführung**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handouts zum Druck im Handout‑Modus. Dieser Modus ermöglicht es, zu konfigurieren, wie mehrere Folien auf einer einzelnen Seite angezeigt werden, was ihn für Konferenzen, Seminare und andere Veranstaltungen nützlich macht. Sie können diesen Modus aktivieren, indem Sie die `slides_layout_options`‑Eigenschaft in den Klassen [PdfOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/htmloptions/) und [TiffOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/) festlegen.

Um die Handout‑Seitengröße und Ausrichtung vor dem Export festzulegen, siehe [Notes Page Size](/slides/de/python-net/notes-size/).

## **Export im Handout‑Modus**

Um den Handout‑Modus zu konfigurieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/handoutlayoutingoptions/), das bestimmt, wie viele Folien auf einer einzelnen Seite platziert werden und weitere Anzeigeparameter.

Unten finden Sie ein Codebeispiel, das zeigt, wie Sie eine Präsentation im Handout‑Modus in PDF konvertieren.

```py
import aspose.slides as slides

# Präsentation laden.
with slides.Presentation("sample.pptx") as presentation:

    # Exportoptionen festlegen.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 Folien horizontal auf einer Seite
    slides_layout_options.print_slide_numbers = True                                 # Foliennummern drucken
    slides_layout_options.print_frame_slide = True                                   # Rahmen um Folien drucken
    slides_layout_options.print_comments = False                                     # keine Kommentare

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Präsentation mit dem gewählten Layout als PDF exportieren.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="Warning" %}}
Beachten Sie, dass die Eigenschaft `slides_layout_options` nur für bestimmte Ausgabformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.
{{% /alert %}} 

## **FAQ**

**Wie hoch ist die maximale Anzahl von Folienminiaturansichten pro Seite im Handout‑Modus?**

Aspose.Slides unterstützt [presets](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/handouttype/) von bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster festlegen, z. B. 5 oder 8 Folien pro Seite?**

Nein. Die Anzahl und Reihenfolge der Miniaturansichten werden strikt durch die Aufzählung [HandoutType](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich ausgeblendete Folien in die Handout‑Ausgabe einbeziehen?**

Ja. Aktivieren Sie die Option `show_hidden_slides` in den Exporteinstellungen für das Zielformat, z. B. [PdfOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/).