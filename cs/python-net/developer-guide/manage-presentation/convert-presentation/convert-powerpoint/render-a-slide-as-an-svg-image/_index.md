---
title: Vykreslit snímky prezentace jako SVG obrázky v Pythonu
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
description: "Exportujte snímky PowerPointu jako SVG obrázky v Pythonu a pomocí Aspose.Slides ovládejte písma, text a obrázky."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který se dobře hodí pro webové publikování, prohlížeče snímků, workflow přístupnosti a automatizované následné zpracování. Aspose.Slides exportuje každý snímek do samostatného souboru SVG a umožňuje vám řídit, jak jsou zapisovány text, písma, obrázky a SVG prvky.

Použijte [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) když exportovaný SVG musí být kompaktní, předvídatelný napříč prohlížeči nebo připravený pro interaktivní použití.

## **Exportovat snímek jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), vyberte snímek a zapište jej do streamu. Následující příklad exportuje každý snímek v prezentaci jako samostatný soubor SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Název souboru používá [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) místo indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/), když prohlížeč snímků nebo webová stránka potřebuje jen tento tvar.

## **Konfigurovat výstup SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) řídí vykreslování SVG. Pro textové rámečky [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) zahrnuje textový rámec do oblasti vykreslování a [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) určuje, zda se aplikuje otáčení rámce. Nastavte [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) na `True`, když musí být text vykreslen bez ligatur.

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

## **Řídit text a písma**

Při exportu snímků do SVG můžete řídit, zda text zůstane jako text nebo bude převeden na vektorovou grafiku, a jak jsou zahrnuta nebo odkazována externí písma. Následující možnosti vám pomohou vyvážit vizuální konzistenci, možnost výběru textu a závislosti na písmu v exportovaném SVG.

### **Vektorizovat celý text**

Nastavte [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) na `True`, aby byl celý text snímku zapsán jako vektorová grafika. Tím se odstraní závislosti na písmu a vizuální výsledek bude konzistentnější napříč prohlížeči, ale text již nebude možné vybrat ani prohledávat jako SVG text.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Zvolit způsob zacházení s externími písmy**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) pro písma načítaná externě. Vyberte `ADD_LINKS_TO_FONT_FILES` pro odkazování na samostatné soubory písem, `EMBED` pro zahrnutí dat písem do SVG, nebo `VECTORIZE` pro vykreslení pouze textu používajícího externí písma jako grafiky. Před vkládáním písem ověřte licencování písem.

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

Použijte [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) ke snížení rozlišení vložených obrázků, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) k vynechání ořezaných oblastí zdroje a [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) ke kontrole kvality kódování JPEG. Tato nastavení snižují velikost souboru na úkor věrnosti obrazu nebo zachování dat obrazu.

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

## **Řídit rozlišení rasterizace metafile**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) nastavuje spodní limit rozlišení pro rasterizaci metafile během exportu SVG. Použijte jej k vyvážení detailů a velikosti souboru, když je rasterizován obraz EMF nebo WMF. Nedefinuje globální DPI pro SVG ani nenutí každý objekt na snímku stát se rastrovým obrázkem.

Stáhněte [metafile-rasterization.pptx](metafile-rasterization.pptx), který obsahuje EMF obrázek s úzce umístěnými diagonálními čarami. Následující příklad exportuje jeho první snímek ve třech rozlišeních rasterizace pomocí [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Všechna ostatní nastavení exportu zůstávají stejné, aby bylo možné výsledky porovnat.

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

Ve výstupu se EMF stal jedním vloženým PNG v každém SVG. Následující měření se vztahují k dodané prezentaci; nejsou obecnou formulí pro převod DPI na rozměry v pixelech.

| Rozlišení rasterizace metafile (DPI) | Rozměry vloženého PNG | Velikost souboru SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Níže uvedené srovnání ukazuje stejnou oblast vloženého rastru při stejném zvětšeném zobrazení. Diagonální čáry vykazují viditelnou pixelaci při 72 DPI a hladší okraje při vyšších rozlišeních, zatímco velikost SVG souboru roste. Zvýšení hodnoty nutně neznamená zlepšení každého detailu ani změnu každého exportovaného obrazu.

![Zvětšený detail diagonální čáry při 72, 150 a 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) řídí snížení rozlišení obrázku a může maskovat efekt změny rozlišení rasterizace metafile. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) řídí kvalitu kódování JPEG, nikoli rozlišení rasterizace metafile.

## **Často kladené otázky**

**Kdy bych měl použít [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) místo [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Použijte [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/), když musí být celý text nezávislý na písmu. Použijte [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/), když by měl být převáděn na grafiku jen text, který používá externí písma.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, odstraněním ořezaných oblastí obrázků a výběrem odkazovaných souborů písem, pokud je cílové prostředí schopno je poskytovat. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.