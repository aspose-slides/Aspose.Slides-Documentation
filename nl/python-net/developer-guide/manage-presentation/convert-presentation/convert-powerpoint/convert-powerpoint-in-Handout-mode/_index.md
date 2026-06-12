---
title: Presentaties converteren in Handout-modus met Python
linktitle: Handout-modus
type: docs
weight: 150
url: /nl/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint converteren
- presentatie converteren
- handout-modus
- handout
- PowerPoint
- presentatie
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Converteer presentaties naar handouts in Python. Stel dia's per pagina in, behoud notities, exporteer naar PDF of afbeeldingen met Aspose.Slides, inclusief voorbeeldcode. Probeer het gratis."
---
## **Introductie**

Aspose.Slides biedt de mogelijkheid om presentaties te converteren naar verschillende formaten, inclusief het maken van hand-outs voor afdrukken in Handout-modus. Deze modus stelt je in staat om te configureren hoe meerdere dia's op één pagina verschijnen, wat handig is voor conferenties, seminars en andere evenementen. Je kunt deze modus inschakelen door de `slides_layout_options`‑eigenschap in te stellen in de [PdfOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmloptions/) en [TiffOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/) klassen.

## **Export van Handout-modus**

Om de Handout-modus te configureren, gebruik je het [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/handoutlayoutingoptions/) object, dat bepaalt hoeveel dia's er op één pagina worden geplaatst en andere weergave‑parameters.

Hieronder staat een code‑voorbeeld dat laat zien hoe je een presentatie naar PDF converteert in Handout-modus.

```py
# Laad een presentatie.
with slides.Presentation("sample.pptx") as presentation:

    # Stel de exportopties in.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 dia's op één pagina horizontaal
    slides_layout_options.print_slide_numbers = True                                 # druk dia-nummers af
    slides_layout_options.print_frame_slide = True                                   # druk een kader rond dia's af
    slides_layout_options.print_comments = False                                     # geen commentaren

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Exporteer de presentatie naar PDF met de gekozen lay-out.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Houd er rekening mee dat de `slides_layout_options`‑eigenschap alleen beschikbaar is voor bepaalde uitvoerformaten, zoals PDF, HTML, TIFF, en bij het renderen als afbeeldingen.
{{% /alert %}} 

## **FAQ**

**Wat is het maximale aantal dia‑miniaturen per pagina in Handout-modus?**

Aspose.Slides ondersteunt [presets](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/handouttype/) tot 9 miniaturen per pagina met horizontale of verticale ordening: 1, 2, 3, 4 (horizontaal/verticaal), 6 (horizontaal/verticaal) en 9 (horizontaal/verticaal).

**Kan ik een aangepast raster definiëren, bijvoorbeeld 5 of 8 dia's per pagina?**

Nee. Het aantal en de volgorde van de miniaturen worden strikt beheerd door de [HandoutType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/handouttype/) enumeratie; willekeurige indelingen worden niet ondersteund.

**Kan ik verborgen dia's opnemen in de Handout-uitvoer?**

Ja. Schakel de `show_hidden_slides`‑optie in de exportinstellingen in voor het gewenste formaat, zoals [PdfOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmloptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/).