---
title: Präsentationen im Handout-Modus mit Python konvertieren
linktitle: Handout-Modus
type: docs
weight: 150
url: /de/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Handout-Modus
- Handout
- PowerPoint
- Präsentation
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Präsentationen in Handouts mit Python konvertieren. Folien pro Seite festlegen, Notizen beibehalten, mit Aspose.Slides in PDF oder Bilder exportieren, inkl. Beispielcode. Kostenlos testen."
---

## **Handout-Modus Export**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handouts zum Drucken im Handout-Modus. Dieser Modus ermöglicht es Ihnen, zu konfigurieren, wie mehrere Folien auf einer einzigen Seite angezeigt werden, was ihn für Konferenzen, Seminare und andere Veranstaltungen nützlich macht. Sie können diesen Modus aktivieren, indem Sie die Eigenschaft `slides_layout_options` in den Klassen [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/), und [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) setzen.

Um den Handout-Modus zu konfigurieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/handoutlayoutingoptions/), das bestimmt, wie viele Folien auf einer einzelnen Seite platziert werden und weitere Anzeigeparameter.

Nachfolgend finden Sie ein Codebeispiel, das zeigt, wie eine Präsentation im Handout-Modus in PDF konvertiert wird.
```py
# Präsentation laden.
with slides.Presentation("sample.pptx") as presentation:

    # Exportoptionen festlegen.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 Folien auf einer Seite horizontal
    slides_layout_options.print_slide_numbers = True                                 # Foliennummern drucken
    slides_layout_options.print_frame_slide = True                                   # Rahmen um Folien drucken
    slides_layout_options.print_comments = False                                     # keine Kommentare

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Präsentation mit gewähltem Layout als PDF exportieren.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```


{{% alert color="warning" %}} 

Beachten Sie, dass die Eigenschaft `slides_layout_options` nur für bestimmte Ausgabeformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.

{{% /alert %}} 

## **FAQ**

**Wie viele Folienminiaturansichten können maximal pro Seite im Handout-Modus angezeigt werden?**

Aspose.Slides unterstützt [Voreinstellungen](https://reference.aspose.com/slides/python-net/aspose.slides.export/handouttype/) von bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster definieren, z. B. 5 oder 8 Folien pro Seite?**

Nein. Die Anzahl und Anordnung der Miniaturansichten werden strikt durch die Aufzählung [HandoutType](https://reference.aspose.com/slides/python-net/aspose.slides.export/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich versteckte Folien in die Handout-Ausgabe einbeziehen?**

Ja. Aktivieren Sie die Option `show_hidden_slides` in den Export‑Einstellungen für das Ziel‑Format, wie z. B. [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/), oder [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/).