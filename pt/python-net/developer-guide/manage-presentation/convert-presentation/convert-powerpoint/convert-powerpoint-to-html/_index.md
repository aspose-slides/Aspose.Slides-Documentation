---
title: Converter apresentações PowerPoint para HTML em Python
linktitle: PowerPoint para HTML
type: docs
weight: 30
url: /pt/python-net/convert-powerpoint-to-html/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para HTML
- apresentação para HTML
- slide para HTML
- PPT para HTML
- PPTX para HTML
- salvar PowerPoint como HTML
- salvar apresentação como HTML
- salvar slide como HTML
- salvar PPT como HTML
- salvar PPTX como HTML
- exportar PPT para HTML
- exportar PPTX para HTML
- Python
- Aspose.Slides
description: "Converter apresentações PowerPoint para HTML em Python. Use Aspose.Slides para exportar arquivos PPT e PPTX, slides selecionados, notas, fontes, imagens, SVG e mídia."
---
## **Visão geral**

Aspose.Slides for Python via .NET pode salvar apresentações PowerPoint como HTML sem o Microsoft PowerPoint. A conversão básica consiste em um único carregamento de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e uma chamada `save` com [SaveFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/saveformat/). Use [HtmlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/htmloptions/) quando precisar controlar o layout exportado, fontes, imagens, notas, comentários, saída SVG ou recursos vinculados.

Este guia foca em cenários práticos de exportação HTML:

- Exportar uma apresentação completa ou slides selecionados.
- Gerar HTML com layout fixo, responsivo ou baseado em SVG.
- Incluir notas do apresentador e comentários.
- Controlar a qualidade da imagem e os dados de imagens recortadas.
- Incorporar fontes ou salvar arquivos de fonte separadamente.
- Escolher como recursos externos e arquivos de mídia são gravados e referenciados.

Por padrão, a exportação HTML produz um documento HTML auto‑contido onde a maioria dos recursos é incorporada. Isso é conveniente para compartilhar um único arquivo, mas pode aumentar o tamanho da saída. Para publicação na web, considere recursos externos, DPI de imagem menor e incorpore apenas fontes que não estejam disponíveis de forma confiável no ambiente de destino.

## **Converter uma Apresentação para HTML**

Para exportar uma apresentação para HTML, carregue‑a com [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e salve‑a com [SaveFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

Este exemplo grava um arquivo HTML. A instrução `with` descarta o objeto presentation e libera manipuladores de arquivo e recursos de renderização após a exportação.

## **Usar HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/htmloptions/) é a classe de configuração principal para exportação HTML. Configurações comuns incluem:

- `slides_layout_options`: adiciona notas, comentários, folhetos ou outras informações de layout.
- `html_formatter`: altera a estrutura do documento HTML ou delega a formatação a um controlador.
- `slide_image_format`: altera como os slides são representados, por exemplo como SVG.
- `pictures_compression`: controla o DPI da imagem e o tamanho da saída.
- `delete_pictures_cropped_areas`: mantém ou remove os dados de imagens recortadas.
- `svg_responsive_layout`: faz o conteúdo SVG exportado adaptar‑se ao seu contêiner.
- `show_hidden_slides`: inclui slides ocultos quando necessário.

As seções a seguir mostram as opções mais comuns separadamente, para que você possa combinar apenas as que seu fluxo de trabalho requer.

## **Converter Slides Selecionados para HTML**

A sobrecarga `save` que aceita números de slides usa posições baseadas em 1. O laço abaixo salva cada slide em um arquivo HTML separado.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Use este padrão quando um site ou aplicativo precisar de uma página HTML por slide. Se cada slide deve ter o mesmo layout, crie uma instância de [HtmlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/htmloptions/) e passe‑a para cada chamada `save`.

## **Criar HTML Responsivo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/responsivehtmlcontroller/) fornece saída HTML responsiva por meio de [HtmlFormatter](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/htmlformatter/). Use‑o quando a página exportada precisar se adaptar melhor à largura do navegador.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

Para layout responsivo baseado em SVG, defina `svg_responsive_layout` em [HtmlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/htmloptions/). Isso é útil quando o conteúdo do slide é exportado como marcação SVG escalável.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Incluir Notas do Apresentador e Comentários**

Use [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/notescommentslayoutingoptions/) através de `html_options.slides_layout_options` para incluir notas do apresentador ou comentários. Notas e comentários são ocultos por padrão, a menos que você escolha suas posições.

Suponha que a apresentação de origem contenha notas do apresentador:

![Slide com notas do apresentador no PowerPoint](slide_with_notes.png)

O código a seguir exporta o conteúdo do slide com as notas do apresentador abaixo do slide.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

A saída HTML inclui a área de notas:

![Saída HTML com o slide e notas do apresentador](HTML_with_notes.png)

Para exportar comentários, defina `comments_position`, por exemplo para `CommentsPositions.RIGHT` ou `CommentsPositions.BOTTOM`. Se precisar apenas de comentários, omita `notes_position`. Se precisar de notas e comentários, defina ambas as propriedades.

## **Controlar Qualidade da Imagem e Áreas Recortadas**

A exportação HTML pode comprimir imagens de slide para reduzir o tamanho da saída. Defina `pictures_compression` com um valor de [PicturesCompression](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/picturescompression/) quando precisar de maior qualidade de imagem.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

Por padrão, áreas recortadas de imagens podem ser removidas da saída exportada. Mantenha os dados recortados somente quando os usuários precisarem recuperar ou inspecionar essas partes ocultas da imagem. Mantê‑los pode aumentar o tamanho do HTML.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **Adicionar CSS**

Para estilização simples, passe uma string CSS para [HtmlFormatter](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/htmlformatter/). Isso altera o documento HTML circundante enquanto o Aspose.Slides continua renderizando o conteúdo do slide.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Para um cabeçalho de documento personalizado, um arquivo CSS vinculado ou marcação personalizada ao redor de slides e formas, use um controlador de formatação personalizado e passe‑o para [HtmlFormatter](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/htmlformatter/) com `create_custom_formatter`.

## **Incorporar Fontes**

Se o ambiente de destino pode não ter as fontes da apresentação instaladas, incorpore fontes no HTML com [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/embedallfontshtmlcontroller/). A incorporação melhora a fidelidade visual, mas aumenta o tamanho da saída.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Exclua uma fonte somente quando estiver confiante de que os navegadores ou sistemas de destino já a fornecem. Para fontes de marca ou menos comuns, a incorporação costuma ser mais segura.

## **Vincular Arquivos de Fonte ao Em vez de Incorporá‑los**

Para reduzir o tamanho do arquivo HTML, você pode gravar os dados da fonte em arquivos WOFF separados e adicionar regras `@font-face` ao HTML. Isso requer um controlador que personalize como os dados da fonte são gravados durante a exportação. Em Python via .NET, implemente esse controlador em um pequeno assembly auxiliar .NET, carregue‑o em Python e passe o objeto auxiliar para [HtmlFormatter](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/htmlformatter/) com `create_custom_formatter`.

Ao externalizar fontes, escolha deliberadamente dois caminhos:

- O diretório de saída no sistema de arquivos onde os arquivos WOFF gerados serão gravados.
- O caminho URL que aparecerá no documento HTML e que o navegador usará para carregar esses arquivos de fonte.

Mantenha o arquivo HTML e os arquivos de fonte gerados juntos até que os caminhos de implantação estejam definidos. Se os arquivos forem implantados em outro local, ajuste o prefixo URL para corresponder ao caminho URL implantado.

## **Gravar Recursos Externamente**

HTML auto‑contido é fácil de mover, mas recursos Base64 incorporados podem tornar o arquivo grande. Se sua aplicação precisar de arquivos de imagem, fonte, áudio ou vídeo externos, use um controlador personalizado de link/incorporação e passe‑o ao construtor de [HtmlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/htmloptions/).

Ao externalizar recursos, escolha deliberadamente dois caminhos:

- O caminho de saída no sistema de arquivos, onde sua aplicação grava imagens, fontes, áudio ou vídeo gerados.
- O caminho URL, que é o que o navegador usa a partir do documento HTML para carregar esses arquivos.

Para uma discussão completa sobre vinculação de imagens, veja [Exportar apresentações para HTML com imagens vinculadas externamente](/slides/pt/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **Exportar Arquivos de Mídia**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/videoplayerhtmlcontroller/) exporta arquivos de vídeo e áudio e grava HTML que pode reproduzi‑los em um navegador. Seu construtor recebe:

- `path`: o diretório onde os arquivos de mídia gerados serão gravados.
- `file_name`: o nome do arquivo HTML que está sendo gerado.
- `base_uri`: o prefixo URI absoluto usado nos links HTML para arquivos de mídia.

Se o arquivo HTML for `html-output/presentation.html` e os arquivos de mídia forem salvos em `html-output/media`, `path` deve apontar para o diretório de mídia no disco, enquanto `base_uri` deve apontar para o mesmo diretório do ponto de vista do navegador. Para pré‑visualização local, você pode montar um URI `file:///` a partir do diretório de mídia. Para uma aplicação implantada, use a URL absoluta do diretório de mídia publicado.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Use diretórios de saída que sejam únicos por tarefa de exportação, especialmente em aplicações de servidor. Caminhos de saída compartilhados podem fazer com que arquivos de diferentes conversões sobrescrevam uns aos outros.

## **Desempenho e Gerenciamento de Recursos**

A conversão HTML é uma operação de renderização, portanto o tempo de processamento e o uso de memória dependem da contagem de slides, resolução das imagens, fontes, efeitos, gráficos e mídia incorporada. Valores de DPI mais altos em `pictures_compression`, fontes incorporadas, saída SVG e áreas de imagem recortadas mantidas podem melhorar a fidelidade, mas geralmente aumentam o tamanho da saída.

Para conversão em lote:

- Descarte rapidamente cada instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
- Use diretórios de saída separados para trabalhos diferentes.
- Evite incorporar fontes comuns a menos que a fidelidade exija.
- Reduza o DPI da imagem quando o HTML for para pré‑visualização ou miniaturas.
- Mantenha a apresentação fonte, o HTML gerado e os recursos externos juntos até que os caminhos de implantação estejam definidos.

## **FAQ**

**Os hiperlinks são preservados na saída HTML?**

Sim. Os hiperlinks da apresentação são exportados para HTML e permanecem clicáveis quando o URL de destino é válido.

**Posso converter apresentações para HTML em paralelo?**

Sim, mas não compartilhe uma única instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) entre threads. Processar arquivos diferentes com instâncias de apresentação separadas, fluxos separados e diretórios de saída separados. Veja as [orientações de multithreading](/slides/pt/python-net/multithreading/) para detalhes.

**Um objeto Presentation é thread‑safe?**

Não. Uma única instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) deve ser carregada, modificada, salva e descartada em um único thread. Para trabalho paralelo, crie uma instância independente por thread ou processo.

**Por que o arquivo HTML gerado é grande?**

A exportação padrão pode incorporar recursos diretamente no HTML. Fontes incorporadas, imagens de alta DPI, mídia, conteúdo SVG e áreas de imagem recortadas mantidas também aumentam o tamanho. Use recursos externos, exclua fontes comuns da incorporação e reduza `pictures_compression` quando um tamanho menor for mais importante que a fidelidade máxima.

**Por que um tamanho de fonte PowerPoint como 24 pt aparece como 17.999819 pt no HTML?**

Isso pode acontecer porque PowerPoint e HTML usam modelos DPI diferentes. O PowerPoint grava tamanhos de texto em pontos tipográficos baseados em 72 DPI, enquanto o layout HTML baseia‑se em pixels CSS em um modelo de 96 DPI. Quando o Aspose.Slides exporta uma apresentação para HTML, o tamanho da fonte é traduzido entre esses sistemas, e a conversão pode introduzir pequenas diferenças de arredondamento.

Esses valores não indicam uma mudança visual real no tamanho da fonte. São apenas um efeito colateral matemático da conversão de métricas de texto entre PowerPoint e HTML.

**Como devo escolher base_uri para exportação de mídia?**

Escolha `base_uri` do ponto de vista do navegador e passe‑o como um URI absoluto. Para pré‑visualização local, você pode derivá‑lo do diretório de saída com `Path(media_directory).as_uri() + "/"`. Para implantação, use a URL absoluta do diretório de mídia publicado. O `path` do sistema de arquivos e o `base_uri` do navegador não precisam ser a mesma string, mas devem descrever o mesmo local de recurso.

**Posso incluir slides ocultos?**

Sim. Defina `show_hidden_slides = True` em [HtmlOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/htmloptions/) quando slides ocultos devem ser exportados.