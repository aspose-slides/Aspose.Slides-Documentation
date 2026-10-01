---
title: Presentaties converteren in Handout-modus met Python
linktitle: Handout-modus
type: docs
weight: 150
url: /nl/python-net/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint converteren
- presentatie converteren
- handout-modus
- hand-out
- PowerPoint
- presentatie
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Presentaties converteren naar hand-outs in Python. Stel dia's per pagina in, bewaar notities, exporteer naar PDF of afbeeldingen met Aspose.Slides, inclusief voorbeeldcode. Probeer het gratis."
---
## **Inleiding**

Aspose.Slides biedt de mogelijkheid om presentaties om te zetten naar verschillende formaten, inclusief het maken van hand‑outs voor afdrukken in Handout‑modus. Deze modus stelt u in staat om te configureren hoe meerdere dia’s op één pagina verschijnen, wat handig is voor conferenties, seminars en andere evenementen. U kunt deze modus inschakelen door de `slides_layout_options`‑eigenschap in te stellen in de [PdfOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmloptions/) en [TiffOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/) klassen.

Om de afmetingen en oriëntatie van de hand‑outpagina in te stellen vóór export, zie [Notes Page Size](/slides/nl/python-net/notes-size/).

## **Export van Handout-modus**

Om de Handout‑modus te configureren, gebruikt u het [HandoutLayoutingOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/handoutlayoutingoptions/) object, dat bepaalt hoeveel dia’s op één pagina worden geplaatst en andere weergave‑parameters.

Hieronder staat een code‑voorbeeld dat laat zien hoe u een presentatie naar PDF converteert in Handout‑modus.

```py
import aspose.slides as slides

# Laad een presentatie.
with slides.Presentation("sample.pptx") as presentation:

    # Stel de exportopties in.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 dia's op één pagina horizontaal
    slides_layout_options.print_slide_numbers = True                                 # druk dia‑nummers af
    slides_layout_options.print_frame_slide = True                                   # teken een kader rond de dia's
    slides_layout_options.print_comments = False                                     # geen opmerkingen

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Exporteer de presentatie naar PDF met de gekozen lay-out.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="Warning" %}}
Houd er rekening mee dat de `slides_layout_options`‑eigenschap alleen beschikbaar is voor bepaalde uitvoerformaten, zoals PDF, HTML, TIFF, en bij het renderen als afbeeldingen.
{{% /alert %}} 

## **FAQ**

**Wat is het maximale aantal dia‑miniaturen per pagina in Handout‑modus?**

Aspose.Slides ondersteunt [presets](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/handouttype/) tot 9 miniaturen per pagina met horizontale of verticale ordening: 1, 2, 3, 4 (horizontaal/verticaal), 6 (horizontaal/verticaal) en 9 (horizontaal/verticaal).

**Kan ik een aangepast raster definiëren, bijvoorbeeld 5 of 8 dia’s per pagina?**

Nee. Het aantal en de volgorde van de miniaturen worden strikt bepaald door de [HandoutType](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/handouttype/) opsomming; willekeurige lay‑outs worden niet ondersteund.

**Kan ik verborgen dia’s opnemen in de Handout‑uitvoer?**

Ja. Schakel de `show_hidden_slides`‑optie in de exportinstellingen in voor het doelformaat, zoals [PdfOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmloptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/tiffoptions/).