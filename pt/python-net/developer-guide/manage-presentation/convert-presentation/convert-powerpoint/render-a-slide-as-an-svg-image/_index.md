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
description: "Exportar slides do PowerPoint como imagens SVG em Python e controlar fontes, texto e imagens com Aspose.Slides."
---
## **Visão geral**

SVG é um formato de imagem escalável baseado em XML que funciona bem para publicação na web, visualizadores de slides, fluxos de trabalho de acessibilidade e pós‑processamento automatizado. Aspose.Slides exporta cada slide para um arquivo SVG separado e permite controlar como texto, fontes, imagens e elementos SVG são gravados.

Use [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) quando o SVG exportado precisar ser compacto, previsível em diferentes navegadores ou pronto para uso interativo.

## **Exportar um Slide como SVG**

Crie uma [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), selecione um slide e grave-o em um fluxo. O exemplo a seguir exporta cada slide de uma apresentação como um arquivo SVG separado.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

O nome do arquivo usa [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) em vez do índice do loop. Você também pode exportar uma forma individual com [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) quando um visualizador de slides ou página web precisar apenas dessa forma.

## **Configurar Saída SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) controla a renderização do SVG. Para quadros de texto, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) inclui o quadro de texto na área de renderização, e [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) determina se a rotação do quadro é aplicada. Defina [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) como `True` quando o texto precisar ser renderizado sem ligaduras.

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

## **Controlar Corte de Extremidade de Linha em Pontas de Setas**

SVG 1.1 não possui configuração de inserção de marcador para especificar onde uma linha deve parar sob uma ponta de seta. Por padrão, Aspose.Slides encurta a linha exportada para que seu traço não ultrapasse o marcador. Defina [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) como `True` para desenhar o traço até o ponto final original da linha. Essa configuração afeta apenas a saída SVG. A linha mantém sua posição e comprimento no slide.

O exemplo desenha pontas de seta triangulares e em forma de losango em linhas de 2 e 10 pontos de espessura. Ele exporta o mesmo slide duas vezes, alterando apenas a opção de corte.

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

A comparação mostra a ponta triangular na linha de 10 pontos. Com o corte habilitado, a ponta fica afiada. Com o corte desabilitado, o traço ultrapassa os lados inclinados do marcador e deixa uma extremidade plana.

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

Nas demais linhas do exemplo, o traço que ultrapassa é menos visível na ponta triangular de 2 pontos. O losango preenchido cobre a extremidade do traço em ambas as larguras.

## **Controlar Texto e Fontes**

Ao exportar slides para SVG, você pode controlar se o texto permanece como texto ou é convertido em gráficos vetoriais, além de como fontes externas são incluídas ou referenciadas. As opções a seguir ajudam a equilibrar consistência visual, seleção de texto e dependências de fontes no SVG exportado.

### **Vetorizar Todo o Texto**

Defina [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) como `True` para gravar todo o texto do slide como gráficos vetoriais. Isso elimina dependências de fontes e torna o resultado visual mais consistente entre navegadores, porém o texto não pode mais ser selecionado ou pesquisado como texto SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Escolher Como as Fontes Externas São Tratadas**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) usa um valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) para fontes carregadas externamente. Escolha `ADD_LINKS_TO_FONT_FILES` para referenciar arquivos de fonte separados, `EMBED` para incluir os dados da fonte no SVG ou `VECTORIZE` para renderizar apenas o texto que usa fontes externas como gráficos. Verifique a licença das fontes antes de incorporá‑las.

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

## **Reduzir Tamanho de Imagens Incorporadas**

Use [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) para reduzir a resolução das imagens incorporadas, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) para omitir áreas recortadas da fonte e [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) para controlar a qualidade da codificação JPEG. Essas configurações reduzem o tamanho do arquivo à custa da fidelidade ou dos dados da imagem.

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

## **Controlar Resolução de Rasterização de Metarquivo**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) define o limite inferior de resolução para rasterizar metarquivos durante a exportação SVG. Use‑o para equilibrar detalhes e tamanho do arquivo quando uma imagem EMF ou WMF for rasterizada. Ele não define um DPI global para o SVG nem força que todo objeto no slide se torne uma imagem raster.

Baixe [metafile-rasterization.pptx](metafile-rasterization.pptx), que contém uma imagem EMF com linhas diagonais próximas. O exemplo a seguir exporta o primeiro slide em três resoluções de rasterização através de [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Todas as demais configurações de exportação permanecem idênticas para que os resultados possam ser comparados.

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

Na saída, o EMF tornou‑se um PNG incorporado em cada SVG. As medições a seguir referem‑se à apresentação fornecida; não constituem uma fórmula geral para converter DPI em dimensões de pixel.

| DPI de rasterização de metarquivo | Dimensões do PNG incorporado | Tamanho do arquivo SVG (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

A comparação abaixo mostra a mesma área do raster incorporado no mesmo tamanho de exibição ampliado. As linhas diagonais exibem pixelização visível em 72 DPI e bordas mais suaves em resoluções superiores, enquanto o arquivo SVG cresce. Aumentar o valor não melhora necessariamente cada detalhe nem altera todas as imagens exportadas.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) controla a redução da resolução da imagem e pode mascarar o efeito da mudança na resolução de rasterização de metarquivo. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) controla a qualidade da codificação JPEG, não a resolução de rasterização de metarquivo.

## **Perguntas Frequentes**

**Quando devo usar [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) em vez de [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Use [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) quando todo o texto precisar ser independente de fontes. Use [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) quando somente o texto que utiliza fontes externas deve ser convertido em gráficos.

**Qual é a melhor maneira de tornar um SVG menor?**

Comece comprimindo as imagens incorporadas, excluindo áreas recortadas e escolhendo arquivos de fontes vinculados quando o ambiente de destino puder fornecê‑los. Teste o resultado, pois menor resolução de imagem, menor qualidade JPEG e texto vetorizado têm diferentes compromissos de qualidade e tamanho.