---
title: Renderovat snímky prezentace jako SVG obrázky v Pythonu
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
description: "Exportujte PowerPoint snímky jako SVG obrázky v Pythonu a ovládejte písma, text a obrázky pomocí Aspose.Slides."
---
## **Přehled**

SVG je škálovatelný formát obrázků založený na XML, který se dobře hodí pro webové publikování, prohlížeče snímků, workflow přístupnosti a automatické následné zpracování. Aspose.Slides exportuje každý snímek do samostatného souboru SVG a umožňuje vám řídit, jak jsou zapisovány text, písma, obrázky a elementy SVG.

Použijte [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) , pokud musí být exportované SVG kompaktní, předvídatelné napříč prohlížeči nebo připravené k interaktivnímu použití.

## **Export snímku jako SVG**

Vytvořte [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), vyberte snímek a zapište jej do proudu. Následující příklad exportuje každý snímek prezentace do samostatného souboru SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Název souboru používá [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) namísto indexu smyčky. Můžete také exportovat jednotlivý tvar pomocí [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/), pokud prohlížeč snímků nebo webová stránka potřebuje pouze tento tvar.

## **Konfigurace výstupu SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) řídí vykreslování SVG. Pro textové rámečky [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) zahrnuje textový rámeček do oblasti vykreslování a [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) určuje, zda se použije rotace rámečku. Nastavte [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) na `True`, když musí být text vykreslen bez ligatur.

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

## **Řízení ořezávání konců čar u šípů**

SVG 1.1 nemá nastavení vložení markeru, které by určovalo, kde má linie skončit pod špičkou šipky. Ve výchozím nastavení Aspose.Slides zkracuje exportovanou linii, aby tah nevyčníval skrz marker. Nastavte [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) na `True`, aby se tah kreslil až po původní koncový bod linie. Toto nastavení ovlivňuje pouze výstup SVG. Linie si zachovává svou pozici a délku na snímku.

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

Příklad kreslí trojúhelníkové a diamantové šipky na čárach o šířce 2 a 10 bodů. Exportuje stejný snímek dvakrát, přičemž mění pouze volbu ořezávání.

Srovnání ukazuje trojúhelníkovou šipku na čáře o šířce 10 bodů. Při povoleném ořezávání je špička ostrá. Při zakázaném ořezávání tah vyčnívá skrz šikmé strany markeru a zanechává plochý konec.

![Zvětšený trojúhelník o šířce 10 bodů s ostrou špičkou při povoleném ořezávání a plochým koncem při zakázaném ořezávání](line-end-cropping.png)

Na ostatních čarách z příkladu je vyčnívající tah méně viditelný u trojúhelníku o šířce 2 body. Vyplněný diamant zakrývá konec tahu u obou šířek.

## **Řízení textu a písem**

Při exportu snímků do SVG můžete řídit, zda text zůstane jako text nebo bude převeden na vektorovou grafiku, a jak jsou zahrnuta nebo odkazována externí písma. Následující možnosti vám pomohou vyvážit vizuální konzistenci, výběr textu a závislosti na písmu v exportovaném SVG.

### **Vektorizovat celý text**

Nastavte [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) na `True`, aby byl celý text snímku zapsán jako vektorová grafika. Tím se odstraní závislosti na písmu a vizuální výsledek je konzistentnější napříč prohlížeči, ale text již není možné vybírat ani vyhledávat jako SVG text.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Zvolte, jak jsou externí písma zpracovávána**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) používá hodnotu [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) pro písma načtená externě. Zvolte `ADD_LINKS_TO_FONT_FILES` pro odkazování na samostatné soubory písem, `EMBED` pro zahrnutí dat písem do SVG, nebo `VECTORIZE` pro vykreslení pouze textu používajícího externí písma jako grafiku. Před vložením písem ověřte licenční podmínky.

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

## **Zmenšení velikosti vložených obrázků**

Použijte [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) ke snížení rozlišení vložených obrázků, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) k vynechání oříznutých oblastí zdroje a [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) ke kontrole kvality JPEG kódování. Tato nastavení snižují velikost souboru na úkor věrnosti obrazu nebo zachovaných dat obrázku.

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

## **Řízení rozlišení rasterizace metafile**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) stanoví spodní limit rozlišení pro rasterizaci metafile během exportu SVG. Použijte jej k vyvážení detailu a velikosti souboru, když je rasterizován obraz EMF nebo WMF. Nedefinuje globální DPI pro SVG ani neznutí, aby se každý objekt na snímku stal rastrovým obrázkem.

Stáhněte [metafile-rasterization.pptx](metafile-rasterization.pptx), který obsahuje EMF obrázek s úzce umístěnými úhlopříčnými čarami. Následující příklad exportuje první snímek při třech rozlišeních rasterizace pomocí [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Všechna ostatní nastavení exportu zůstávají stejná, aby bylo možné výsledky porovnat.

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

Ve výstupu se EMF převedl na jeden vložený PNG v každém SVG. Následující měření jsou pro dodanou prezentaci; nejsou obecnou formulí pro převod DPI na rozměry v pixelech.

| Rasterizace metafile DPI | Rozměry vloženého PNG | Velikost SVG souboru (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Srovnání níže ukazuje stejnou oblast vloženého rastru při stejném zvětšeném zobrazení. Úhlopříčkové čáry ukazují viditelnou pixelaci při 72 DPI a hladší hrany při vyšších rozlišeních, zatímco velikost SVG souboru roste. Zvýšení hodnoty nutně nezlepší každý detail ani nezmění každý exportovaný obrázek.

![Zvětšený detail úhlopříčkové čáry při 72, 150 a 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) řídí snížení rozlišení obrázku a může skrýt vliv změny rozlišení rasterizace metafile. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) řídí kvalitu JPEG kódování, nikoli rozlišení rasterizace metafile.

## **Často kladené otázky**

**Kdy mám použít [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) místo [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Použijte [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/), když musí být celý text nezávislý na píscích. Použijte [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/), když má být převáděn na grafiku pouze text, který používá externí písma.

**Jaký je nejlepší způsob, jak zmenšit SVG?**

Začněte kompresí vložených obrázků, odstraněním oříznutých oblastí obrázků a výběrem odkazovaných souborů písem, pokud cílové prostředí může soubory obsloužit. Otestujte výsledek, protože nižší rozlišení obrázku, nižší kvalita JPEG a vektorizovaný text mají různé kompromisy mezi kvalitou a velikostí.