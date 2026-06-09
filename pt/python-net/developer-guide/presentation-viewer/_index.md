---
title: Criar um Visualizador de Apresentação em Python
linktitle: Visualizador de Apresentação
type: docs
weight: 50
url: /pt/python-net/presentation-viewer/
keywords:
- visualizar apresentação
- visualizador de apresentação
- criar visualizador de apresentação
- visualizar PPT
- visualizar PPTX
- visualizar ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aprenda a criar um visualizador de apresentação personalizado em Python usando Aspose.Slides. Exiba facilmente arquivos PowerPoint (PPTX, PPT) e OpenDocument (ODP) sem o Microsoft PowerPoint ou outro software de escritório."
---
## **Introdução**

O Aspose.Slides for Python é usado para criar arquivos de apresentação com slides. Esses slides podem ser visualizados ao abrir as apresentações no Microsoft PowerPoint, por exemplo. Entretanto, os desenvolvedores às vezes podem precisar visualizar os slides como imagens em seu visualizador de imagens preferido ou usá‑los em um visualizador de apresentações personalizado. Nesses casos, o Aspose.Slides permite exportar slides individuais como imagens. Este artigo explica como fazer isso.

## **Gerar uma Imagem SVG a partir de um Slide**

Para gerar uma imagem SVG a partir de um slide de apresentação com Aspose.Slides, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo seu índice.
3. Abra um fluxo de arquivo.
4. Salve o slide como uma imagem SVG no fluxo de arquivo.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Criar uma Imagem Miniatura de Slide**

O Aspose.Slides ajuda a gerar imagens em miniatura dos slides. Para gerar uma miniatura de um slide usando Aspose.Slides, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo seu índice.
3. Crie uma imagem miniatura do slide referenciado na escala desejada.
4. Salve a imagem miniatura no formato de imagem de sua preferência.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Criar uma Miniatura de Slide com Dimensões Definidas pelo Usuário**

Para criar uma imagem miniatura de slide com dimensões definidas pelo usuário, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo seu índice.
3. Gere uma imagem miniatura do slide referenciado com as dimensões especificadas.
4. Salve a imagem miniatura no formato de imagem de sua preferência.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Criar uma Miniatura de Slide com Notas do Apresentador**

Para gerar uma miniatura de um slide com notas do apresentador usando Aspose.Slides, siga as etapas abaixo:

1. Crie uma instância da classe [RenderingOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/renderingoptions/).
2. Use a propriedade `RenderingOptions.slides_layout_options` para definir a posição das notas do apresentador.
3. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
4. Obtenha uma referência ao slide pelo seu índice.
5. Gere uma imagem miniatura do slide referenciado usando as opções de renderização.
6. Salve a imagem miniatura no formato de imagem de sua preferência.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **Exemplo ao Vivo**

Experimente o aplicativo gratuito [**Aspose.Slides Viewer**](https://products.aspose.app/slides/pt/viewer/) para ver o que você pode implementar com a API do Aspose.Slides:

[![Visualizador Online de PowerPoint](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/pt/viewer/)

## **Perguntas Frequentes**

**Posso incorporar um visualizador de apresentações em uma aplicação web ASP.NET?**

Sim. Você pode usar o Aspose.Slides no lado do servidor para renderizar slides como [imagens](/slides/pt/python-net/convert-powerpoint-to-png/) ou [HTML](/slides/pt/python-net/convert-powerpoint-to-html/) e exibi‑los no navegador. Recursos de navegação e zoom podem ser implementados com JavaScript para uma experiência interativa.

**Qual é a melhor forma de exibir slides dentro de um visualizador .NET personalizado?**

A abordagem recomendada é renderizar cada slide como uma [imagem](/slides/pt/python-net/convert-powerpoint-to-png/) (por exemplo, PNG ou SVG) ou convertê‑lo para [HTML](/slides/pt/python-net/convert-powerpoint-to-html/) usando o Aspose.Slides, e então exibir o resultado dentro de uma caixa de imagem (para desktop) ou de um contêiner HTML (para web).

**Como lidar com apresentações grandes com muitos slides?**

Para apresentações extensas, considere carregamento preguiçoso ou renderização sob demanda dos slides. Isso significa gerar o conteúdo de um slide somente quando o usuário navega até ele, reduzindo o uso de memória e o tempo de carregamento.