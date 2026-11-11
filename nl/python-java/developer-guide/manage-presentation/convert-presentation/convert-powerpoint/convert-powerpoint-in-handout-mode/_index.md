---
title: PowerPoint-presentaties converteren in handout-modus met Python
linktitle: Handout-modus
type: docs
weight: 150
url: /nl/python-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint converteren
- presentatie converteren
- handout-modus
- handout
- PPT
- PPTX
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Converteer PowerPoint-presentaties naar handouts in Python via Java. Rangschik meerdere dia's per pagina en exporteer naar PDF met Aspose.Slides."
---
## **Introduction**

Aspose.Slides for Python via Java stelt u in staat om presentaties te exporteren in handout-modus, waarbij meerdere dia’s op één pagina worden geplaatst. Dit is handig voor het afdrukken van presentatiemateriaal voor conferenties, seminars en soortgelijke evenementen.

Configureer de lay-out via de [setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) methode. Handout-lay-outs worden ondersteund door [PdfOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/htmloptions/) en [TiffOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/tiffoptions/). Gebruik een [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/handoutlayoutingoptions/) object om de lay-out en weergave-instellingen te specificeren.

Om de afmetingen en oriëntatie van de handout-pagina in te stellen vóór het exporteren, zie [Notes Page Size](/slides/nl/python-java/notes-size/).

## **Handout Mode Export**

Om een presentatie in handout-modus te exporteren, maak een [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/handoutlayoutingoptions/) instantie aan en wijs deze toe aan de doel-exportopties via [setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Het volgende voorbeeld laadt `sample.pptx` en exporteert het naar PDF met vier dia’s per pagina in horizontale volgorde. Het bevat dia-nummers en kaders rond de dia’s, en sluit opmerkingen uit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Een presentatie laden.
presentation = Presentation("sample.pptx")
try:
    # De handout-indeling configureren.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # De presentatie exporteren naar PDF met de gekozen indeling.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Handout‑lay-outinstellingen zijn van toepassing op ondersteunde uitvoerformaten, zoals PDF, HTML, TIFF en gerenderde afbeeldingen. Ze herschikken de dia’s niet in de bronpresentatie.
{{% /alert %}}

## **FAQ**

**Wat is het maximale aantal dia‑miniaturen per pagina in handout-modus?**

Aspose.Slides ondersteunt maximaal negen miniaturen per pagina. De [HandoutType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/handouttype/) presets bieden één, twee, drie, vier, zes of negen dia’s per pagina. De vier‑, zes‑ en negen‑dia‑presets bieden zowel horizontale als verticale ordening.

**Kan ik een aangepast raster definiëren, zoals vijf of acht dia’s per pagina?**

Nee. Het aantal en de volgorde van de miniaturen worden bepaald door de vooraf gedefinieerde [HandoutType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/handouttype/) waarden. Willekeurige rasters worden niet ondersteund door deze handout‑lay-outinstellingen.

**Kan ik verborgen dia’s opnemen in de handout-output?**

Ja. Schakel verborgen dia’s in de exportinstellingen voor het doel‑formaat in. Voor PDF, roep [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) aan met `True` voordat u de presentatie opslaat.