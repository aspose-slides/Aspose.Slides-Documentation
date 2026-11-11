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
description: "Exportera PowerPoint-bilder som SVG-bilder i Python och kontrollera typsnitt, text och bilder med Aspose.Slides."
---
## **Översikt**

SVG är ett skalbart XML-baserat bildformat som fungerar bra för webbpublicering, bildspelsvisare, tillgänglighetsarbetsflöden och automatiserad efterbehandling. Aspose.Slides exporterar varje bild till en separat SVG-fil och låter dig kontrollera hur text, typsnitt, bilder och SVG-element skrivs.

Använd [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) när den exporterade SVG:n måste vara kompakt, förutsägbar i olika webbläsare eller klar för interaktiv användning.

## **Exportera en bild som SVG**

Skapa en [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), välj en bild och skriv den till en ström. Följande exempel exporterar varje bild i en presentation som en separat SVG-fil.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Filnamnet använder [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) snarare än loopindexet. Du kan också exportera en enskild form med [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) när en bildvisare eller webbsida bara behöver den formen.

## **Konfigurera SVG-utdata**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) styr SVG-rendering. För textramar inkluderar [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) textramen i renderingsområdet, och [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) bestämmer om ramrotationen tillämpas. Ställ in [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) till `True` när text måste renderas utan ligaturer.

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

## **Kontroll av linjeändbeskärning vid pilspetsar**

SVG 1.1 har ingen markeringsinset-inställning för att ange var en linje ska sluta under en pilspets. Som standard förkortar Aspose.Slides den exporterade linjen så att dess penseldrag inte sticker igenom markören. Ställ in [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) till `True` för att rita penseldraget ända fram till linjens ursprungliga slutpunkt. Denna inställning påverkar endast SVG-utdata. Linjen behåller sin position och längd på bilden.

Exemplet ritar triangel- och diamantpilspetsar på linjer med bredd 2 respektive 10 punkter. Det exporterar samma bild två gånger och ändrar bara beskärningsalternativet.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

Jämförelsen visar den triangulära pilspetsen på 10‑punktslinjen. Med beskärning aktiverad är spetsen skarp. Med beskärning avaktiverad sticker penseldraget igenom de snedställda delarna av markören och lämnar ett platt slut.

![Förstorad 10‑punkts triangel med en skarp spets när beskärning är aktiverad och en platt ände när beskärning är avaktiverad](line-end-cropping.png)

I de andra linjerna i exemplet är det utskjutande penseldraget mindre synligt på 2‑punkts triangeln. Den fyllda diamanten täcker penseldragets slut på båda bredderna.

## **Kontrollera text och typsnitt**

När du exporterar bilder till SVG kan du kontrollera om text förblir text eller konverteras till vektorgrafik, samt hur externa typsnitt inkluderas eller refereras. Följande alternativ hjälper dig att balansera visuell konsistens, textmarkering och typsnittsberoenden i den exporterade SVG:n.

### **Vektorisera all text**

Ställ in [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) till `True` för att skriva all bildtext som vektorgrafik. Detta eliminerar typsnittsberoenden och gör det visuella resultatet mer konsekvent i olika webbläsare, men texten blir inte längre markerbar eller sökbar som SVG-text.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Välj hur externa typsnitt hanteras**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) använder ett [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)‑värde för typsnitt som laddas externt. Välj `ADD_LINKS_TO_FONT_FILES` för att referera separata typsnittsfiler, `EMBED` för att inkludera typsnittsdata i SVG, eller `VECTORIZE` för att rendera endast text som använder externa typsnitt som grafik. Verifiera typsnittslicensiering innan du bäddar in typsnitt.

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

## **Minska inbäddad bildstorlek**

Använd [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) för att minska upplösningen på inbäddade bilder, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) för att utesluta beskurna källområden, och [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) för att kontrollera JPEG‑kodningskvaliteten. Dessa inställningar minskar filstorleken på bekostnad av bildkvalitet eller bevarad bilddata.

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

## **Kontrollera rasteriseringsupplösning för metafiler**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) anger den lägre upplösningsgränsen för rasterisering av metafiler under SVG-export. Använd den för att balansera detaljrikedom och filstorlek när en EMF- eller WMF-bild rasteriseras. Den definierar inte en global DPI för SVG:n eller tvingar varje objekt på bilden att bli en rasterbild.

Ladda ner [metafile-rasterization.pptx](metafile-rasterization.pptx), som innehåller en EMF-bild med tätt placerade diagonala linjer. Följande exempel exporterar dess första bild i tre rasteriseringsupplösningar via [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Alla andra exportinställningar förblir identiska så att resultaten kan jämföras.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

I utdata blev EMF-filen en inbäddad PNG i varje SVG. Följande mått gäller den levererade presentationen; de är inte en generell formel för att konvertera DPI till pixelmått.

| Metafils rasteriserings‑DPI | Inbäddade PNG-dimensioner | SVG‑filstorlek (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Jämförelsen nedan visar samma område av den inbäddade rasterbilden i samma förstoring. De diagonala linjerna visar tydlig pixellering vid 72 DPI och jämnare kanter vid högre upplösningar, medan SVG‑filen växer. Att öka värdet förbättrar inte nödvändigtvis varje detalj eller förändrar varje exporterad bild.

![Förstorad detalj av diagonallinjer vid 72, 150 och 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) styr minskning av bildupplösning och kan maskera effekten av att ändra metafils rasteriserings‑DPI. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) styr JPEG‑kodningskvalitet, inte metafils rasteriserings‑DPI.

## **FAQ**

**När bör jag använda [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) istället för [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Använd [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) när all text måste vara oberoende av typsnitt. Använd [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) när endast text som använder externa typsnitt ska konverteras till grafik.

**Vad är det bästa sättet att göra en SVG mindre?**

Börja med att komprimera inbäddade bilder, ta bort beskurna bildområden och välja länkade typsnittsfiler när målmiljön kan leverera dem. Testa resultatet eftersom lägre bildupplösning, lägre JPEG‑kvalitet och vektorisering av text alla har olika kompromisser mellan kvalitet och storlek.