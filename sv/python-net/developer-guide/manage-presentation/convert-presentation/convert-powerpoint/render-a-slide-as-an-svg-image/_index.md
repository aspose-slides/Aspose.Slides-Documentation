---
title: Rendera presentationsbilder som SVG-bilder i Python
linktitle: Bild till SVG
type: docs
weight: 50
url: /sv/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint till SVG
- presentation till SVG
- bild till SVG
- PPT till SVG
- PPTX till SVG
- SVG-exportalternativ
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Exportera PowerPoint-bilder som SVG-bilder i Python och kontrollera teckensnitt, text och bilder med Aspose.Slides."
---
## **Översikt**

SVG är ett skalbart XML‑baserat bildformat som fungerar bra för webbpublicering, bildspelsvisare, tillgänglighetsarbetsflöden och automatiserad efterbehandling. Aspose.Slides exporterar varje bild till en separat SVG‑fil och låter dig styra hur text, teckensnitt, bilder och SVG‑element skrivs.

Använd [SVGOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgoptions/) när den exporterade SVG‑filen måste vara kompakt, förutsägbar i olika webbläsare eller klar för interaktiv användning.

## **Exportera en bild som SVG**

Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/), välj en bild och skriv den till en ström. Följande exempel exporterar varje bild i en presentation som en separat SVG‑fil.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Filnamnet använder [Slide.slide_number](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/slide_number/) istället för loopindexet. Du kan också exportera en enskild form med [Shape.write_as_svg](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/write_as_svg/) när en bildvisare eller webbsida bara behöver den formen.

## **Konfigurera SVG-utdata**

[SVGOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgoptions/) styr SVG-renderingen. För textramar inkluderar [SVGOptions.use_frame_size](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgoptions/use_frame_size/) textramen i renderingsområdet, och [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) bestämmer om ramrotationen tillämpas. Ställ in [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) till `True` när text måste renderas utan ligaturer.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Styr text och teckensnitt**

### **Vektorisera all text**

Ställ in [SVGOptions.vectorize_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgoptions/vectorize_text/) till `True` för att skriva all bildtext som vektorgrafik. Detta eliminerar teckensnittsberoenden och gör det visuella resultatet mer konsekvent i olika webbläsare, men texten är inte längre markerbar eller sökbar som SVG‑text.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Välj hur externa teckensnitt hanteras**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) använder ett [SvgExternalFontsHandling](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgexternalfontshandling/)‑värde för teckensnitt som laddas externt. Välj `ADD_LINKS_TO_FONT_FILES` för att referera separata teckensnittsfiler, `EMBED` för att inkludera teckensnittsdatan i SVG:n, eller `VECTORIZE` för att rendera endast text som använder externa teckensnitt som grafik. Verifiera teckensnittslicensen innan du bäddar in teckensnitt.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **Minska storlek på inbäddade bilder**

Använd [SVGOptions.pictures_compression](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgoptions/pictures_compression/) för att minska upplösningen på inbäddade bilder, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) för att utesluta beskurna källområden, och [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgoptions/jpeg_quality/) för att kontrollera JPEG‑kodningskvaliteten. Dessa inställningar minskar filstorleken på bekostnad av bildkvaliteten eller bevarad bilddata.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Vanliga frågor**

**När bör jag använda [SVGOptions.vectorize_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgoptions/vectorize_text/) istället för [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Använd [SVGOptions.vectorize_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgoptions/vectorize_text/) när all text måste vara oberoende av teckensnitt. Använd [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgexternalfontshandling/) när endast text som använder externa teckensnitt ska konverteras till grafik.

**Vad är det bästa sättet att göra en SVG mindre?**

Börja med att komprimera inbäddade bilder, ta bort beskurna bildområden och välja länkade teckensnittsfiler när målmiljön kan leverera dem. Testa resultatet eftersom lägre bildupplösning, lägre JPEG‑kvalitet och vektoriserad text alla har olika kompromisser mellan kvalitet och storlek.