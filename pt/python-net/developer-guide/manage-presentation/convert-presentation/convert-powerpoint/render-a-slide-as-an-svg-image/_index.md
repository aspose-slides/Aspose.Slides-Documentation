---
title: Renderizar Slides de Apresentação como Imagens SVG em Python
linktitle: Slide para SVG
type: docs
weight: 50
url: /pt/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint para SVG
- apresentação para SVG
- slide para SVG
- PPT para SVG
- PPTX para SVG
- opções de exportação SVG
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Exporte slides do PowerPoint como imagens SVG em Python e controle fontes, texto e imagens com Aspose.Slides."
---
## **Visão geral**

SVG é um formato de imagem baseado em XML escalável que funciona bem para publicação web, visualizadores de slides, fluxos de trabalho de acessibilidade e pós‑processamento automatizado. Aspose.Slides exporta cada slide para um arquivo SVG separado e permite controlar como texto, fontes, imagens e elementos SVG são gravados.

Use [SVGOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgoptions/) quando o SVG exportado precisar ser compacto, previsível em diferentes navegadores ou pronto para uso interativo.

## **Exportar um Slide como SVG**

Crie uma [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/), selecione um slide e grave‑o em um stream. O exemplo a seguir exporta cada slide de uma apresentação como um arquivo SVG separado.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

O nome do arquivo usa [Slide.slide_number](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/slide_number/) em vez do índice do loop. Você também pode exportar uma forma individual com [Shape.write_as_svg](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/write_as_svg/) quando um visualizador de slides ou página web precisar apenas dessa forma.

## **Configurar Saída SVG**

[SVGOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgoptions/) controla a renderização SVG. Para quadros de texto, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgoptions/use_frame_size/) inclui o quadro de texto na área de renderização, e [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) determina se a rotação do quadro é aplicada. Defina [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) como `True` quando o texto precisar ser renderizado sem ligaduras.

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

## **Controlar Texto e Fontes**

### **Vetorização de Todo o Texto**

Defina [SVGOptions.vectorize_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgoptions/vectorize_text/) como `True` para gravar todo o texto do slide como gráficos vetoriais. Isso elimina dependências de fontes e torna o resultado visual mais consistente entre navegadores, porém o texto deixa de ser selecionável ou pesquisável como texto SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Escolher Como as Fontes Externas São Tratadas**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) usa um valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgexternalfontshandling/) para fontes que são carregadas externamente. Escolha `ADD_LINKS_TO_FONT_FILES` para referenciar arquivos de fonte separados, `EMBED` para incluir os dados da fonte no SVG ou `VECTORIZE` para renderizar apenas o texto que usa fontes externas como gráficos. Verifique a licença das fontes antes de incorporá-las.

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

## **Reduzir o Tamanho das Imagens Incorporadas**

Use [SVGOptions.pictures_compression](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgoptions/pictures_compression/) para reduzir a resolução das imagens incorporadas, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) para omitir áreas recortadas das imagens de origem e [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgoptions/jpeg_quality/) para controlar a qualidade da codificação JPEG. Essas configurações reduzem o tamanho do arquivo ao custo da fidelidade da imagem ou dos dados da imagem preservados.

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

## **FAQ**

**Quando devo usar [SVGOptions.vectorize_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgoptions/vectorize_text/) em vez de [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Use [SVGOptions.vectorize_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgoptions/vectorize_text/) quando todo o texto precisa ser independente de fontes. Use [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgexternalfontshandling/) quando apenas o texto que utiliza fontes externas deve ser convertido em gráficos.

**Qual é a melhor maneira de tornar um SVG menor?**

Comece comprimindo as imagens incorporadas, excluindo áreas recortadas das imagens e escolhendo arquivos de fonte vinculados quando o ambiente de destino puder fornecê‑los. Teste o resultado, pois resolução de imagem reduzida, qualidade JPEG menor e texto vetorizado apresentam diferentes compromissos entre qualidade e tamanho.