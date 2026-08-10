---
title: Vykreslit snímky prezentace jako obrázky SVG v Pythonu
linktitle: Snímek do SVG
type: docs
weight: 50
url: /cs/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint do SVG
- prezentace do SVG
- snímek do SVG
- PPT do SVG
- PPTX do SVG
- Možnosti exportu SVG
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Exportujte snímky PowerPointu jako obrázky SVG v Pythonu a pomocí Aspose.Slides ovládejte fonty, text a obrázky."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který dobře funguje pro publikování na webu, prohlížeče snímků, pracovní postupy přístupnosti a automatické následné zpracování. Aspose.Slides exportuje každý snímek do samostatného souboru SVG a umožňuje vám řídit, jak jsou zapisovány text, fonty, obrázky a elementy SVG.

Použijte [SVGOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/), pokud exportované SVG musí být kompaktní, předvídatelné napříč prohlížeči nebo připravené pro interaktivní použití.

## **Exportovat snímek jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/), vyberte snímek a zapište jej do proudu. Následující příklad exportuje každý snímek v prezentaci jako samostatný soubor SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Název souboru používá [Slide.slide_number](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/slide_number/) místo indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [Shape.write_as_svg](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/write_as_svg/), pokud prohlížeč snímků nebo webová stránka potřebuje jen tento tvar.

## **Konfigurovat výstup SVG**

[SVGOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/) řídí vykreslování SVG. Pro textové rámečky [SVGOptions.use_frame_size](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/use_frame_size/) zahrnuje textový rámec do oblasti vykreslování a [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) určuje, zda se aplikuje rotace rámce. Nastavte [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) na `True`, pokud musí být text vykreslen bez ligatur.

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

## **Ovládání textu a fontů**

### **Vektorizovat celý text**

Nastavte [SVGOptions.vectorize_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/vectorize_text/) na `True`, aby byl celý text snímku zapsán jako vektorová grafika. Tím se odstraní závislost na fontech a vizuální výsledek bude konzistentnější napříč prohlížeči, ale text již nebude možné vybírat ani vyhledávat jako SVG text.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Zvolte, jak jsou zpracovávány externí fonty**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgexternalfontshandling/) pro fonty načítané externě. Zvolte `ADD_LINKS_TO_FONT_FILES` pro odkaz na samostatné soubory fontů, `EMBED` pro zahrnutí dat fontu do SVG, nebo `VECTORIZE` pro vykreslení textu používajícího externí fonty jako grafiku. Před vložením fontů ověřte licencování fontů.

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

## **Zmenšit velikost vložených obrázků**

Použijte [SVGOptions.pictures_compression](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/pictures_compression/) ke snížení rozlišení vložených obrázků, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) k vynechání oříznutých částí zdroje a [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/jpeg_quality/) k řízení kvality JPEG kódování. Tato nastavení snižují velikost souboru na úkor věrnosti obrazu nebo zachovaných dat obrázku.

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

## **Často kladené otázky**

**Kdy bych měl použít [SVGOptions.vectorize_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/vectorize_text/) místo [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Použijte [SVGOptions.vectorize_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgoptions/vectorize_text/), pokud musí být veškerý text nezávislý na fontech. Použijte [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/cs/python-net/aspose.slides.export/svgexternalfontshandling/), pokud má být pouze text používající externí fonty převeden na grafiku.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, odstraněním oříznutých částí obrázků a výběrem odkazovaných souborů fontů, pokud je cílové prostředí schopno je poskytovat. Otestujte výsledek, protože nižší rozlišení obrazu, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.