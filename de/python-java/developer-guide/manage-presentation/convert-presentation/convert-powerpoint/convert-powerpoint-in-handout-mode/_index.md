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
description: "PowerPoint-Präsentationen in Handouts mit Python via Java konvertieren. Mehrere Folien pro Seite anordnen und mit Aspose.Slides als PDF exportieren."
---
## **Einführung**

Aspose.Slides for Python via Java ermöglicht den Export von Präsentationen im Handout‑Modus, bei dem mehrere Folien auf einer Seite angeordnet werden. Dies ist nützlich, um Präsentationsmaterialien für Konferenzen, Seminare und ähnliche Veranstaltungen zu drucken.

Konfigurieren Sie das Layout über die [setSlidesLayoutOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions)-Methode. Handout‑Layouts werden von [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/htmloptions/) und [TiffOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/tiffoptions/) unterstützt. Verwenden Sie ein [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/handoutlayoutingoptions/)-Objekt, um die Layout‑ und Anzeigeeinstellungen festzulegen.

## **Export im Handout‑Modus**

Um eine Präsentation im Handout‑Modus zu exportieren, erstellen Sie eine [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/handoutlayoutingoptions/)-Instanz und weisen sie den Ziel‑Exportoptionen über [setSlidesLayoutOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) zu.

Das folgende Beispiel lädt `sample.pptx` und exportiert es als PDF mit vier Folien pro Seite in horizontaler Reihenfolge. Es enthält Foliennummern und Rahmen um die Folien und schließt Kommentare aus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Lade eine Präsentation.
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

    # Exportiere die Präsentation mit dem gewählten Layout als PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Handout‑Layout‑Einstellungen gelten für unterstützte Ausgabeformate wie PDF, HTML, TIFF und gerenderte Bilder. Sie ändern nicht die Anordnung der Folien in der Quellpräsentation.
{{% /alert %}}

## **FAQ**

**Was ist die maximale Anzahl von Folien‑Thumbnails pro Seite im Handout‑Modus?**

Aspose.Slides unterstützt bis zu neun Thumbnails pro Seite. Die [HandoutType](https://reference.aspose.com/slides/de/python-java/aspose.slides/handouttype/)-Voreinstellungen bieten ein, zwei, drei, vier, sechs oder neun Folien pro Seite. Die Voreinstellungen für vier, sechs und neun Folien ermöglichen horizontale und vertikale Anordnung.

**Kann ich ein benutzerdefiniertes Raster definieren, z. B. fünf oder acht Folien pro Seite?**

Nein. Die Anzahl und Reihenfolge der Thumbnails werden durch die vordefinierten Werte von [HandoutType](https://reference.aspose.com/slides/de/python-java/aspose.slides/handouttype/) gesteuert. Beliebige Raster werden von diesen Handout‑Layout‑Einstellungen nicht unterstützt.

**Kann ich versteckte Folien in der Handout‑Ausgabe einbeziehen?**

Ja. Aktivieren Sie versteckte Folien in den Exporteinstellungen für das Ziel­format. Für PDF rufen Sie [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) mit `True` auf, bevor Sie die Präsentation speichern.