---
title: PowerPoint-Präsentationen im Handout-Modus mit Python konvertieren
linktitle: Handout-Modus
type: docs
weight: 150
url: /de/python-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Handout-Modus
- Handout
- PPT
- PPTX
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "PowerPoint-Präsentationen in Handouts in Python über Java konvertieren. Mehrere Folien pro Seite anordnen und mit Aspose.Slides als PDF exportieren."
---
## **Einleitung**

Aspose.Slides for Python via Java ermöglicht das Exportieren von Präsentationen im Handout‑Modus, wobei mehrere Folien auf einer einzelnen Seite angeordnet werden. Dies ist nützlich, um Präsentationsmaterialien für Konferenzen, Seminare und ähnliche Veranstaltungen zu drucken.

Konfigurieren Sie das Layout über die [setSlidesLayoutOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions)‑Methode. Handout‑Layouts werden von [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/) und [TiffOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/) unterstützt. Verwenden Sie ein [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/handoutlayoutingoptions/)‑Objekt, um das Layout und die Anzeigeeinstellungen festzulegen.

Um die Handout‑Seitenabmessungen und -orientierung vor dem Export festzulegen, siehe [Notes Page Size](/slides/de/python-java/notes-size/).

## **Export im Handout‑Modus**

Um eine Präsentation im Handout‑Modus zu exportieren, erstellen Sie eine [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/handoutlayoutingoptions/)‑Instanz und weisen sie den Ziel‑Exportoptionen mit [setSlidesLayoutOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) zu.

Das folgende Beispiel lädt `sample.pptx` und exportiert es nach PDF mit vier Folien pro Seite in horizontaler Reihenfolge. Es enthält Folienzahlen und Rahmen um die Folien und schließt Kommentare aus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Präsentation laden.
presentation = Presentation("sample.pptx")
try:
    # Handout-Layout konfigurieren.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Präsentation mit dem gewählten Layout als PDF exportieren.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Handout‑Layout‑Einstellungen gelten für unterstützte Ausgabformate wie PDF, HTML, TIFF und gerenderte Bilder. Sie ordnen die Folien in der Quellpräsentation nicht neu.
{{% /alert %}}

## **FAQ**

**Was ist die maximale Anzahl von Folien‑Miniaturbildern pro Seite im Handout‑Modus?**

Aspose.Slides unterstützt bis zu neun Miniaturbilder pro Seite. Die [HandoutType](https://reference.aspose.com/slides/de/python-java/aspose.slides/handouttype/)‑Voreinstellungen bieten ein, zwei, drei, vier, sechs oder neun Folien pro Seite. Die Voreinstellungen für vier, sechs und neun Folien ermöglichen horizontale und vertikale Anordnung.

**Kann ich ein benutzerdefiniertes Raster definieren, z. B. fünf oder acht Folien pro Seite?**

Nein. Die Anzahl und Reihenfolge der Miniaturbilder werden von den vordefinierten [HandoutType](https://reference.aspose.com/slides/de/python-java/aspose.slides/handouttype/)‑Werten gesteuert. Beliebige Raster werden von diesen Handout‑Layout‑Einstellungen nicht unterstützt.

**Kann ich ausgeblendete Folien in die Handout‑Ausgabe einbeziehen?**

Ja. Aktivieren Sie ausgeblendete Folien in den Exporteinstellungen für das Zielformat. Für PDF rufen Sie [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) mit `True` auf, bevor Sie die Präsentation speichern.