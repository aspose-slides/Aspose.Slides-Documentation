---
title: Criar Miniaturas de Formas de Apresentação em Python
linktitle: Miniaturas de Formas
type: docs
weight: 70
url: /pt/python-net/create-shape-thumbnails/
keywords:
- miniatura de forma
- imagem de forma
- renderizar forma
- renderização de forma
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Gere miniaturas de alta qualidade de formas a partir de slides PowerPoint e OpenDocument com Aspose.Slides para Python via .NET – crie e exporte miniaturas de apresentações facilmente."
---
## **Introdução**

Aspose.Slides for Python via .NET é usado para criar arquivos de apresentação nos quais cada página é um slide. Você pode visualizar esses slides no Microsoft PowerPoint abrindo o arquivo de apresentação. No entanto, os desenvolvedores às vezes precisam visualizar imagens de formas separadamente em um visualizador de imagens. Nesses casos, o Aspose.Slides pode gerar imagens em miniatura para as formas dos slides. Este artigo explica como usar esse recurso.

## **Gerar miniaturas de formas a partir de slides**

Quando você precisa de uma visualização de um objeto específico em vez do slide inteiro, pode renderizar uma miniatura para uma forma individual. O Aspose.Slides permite exportar qualquer forma para uma imagem, facilitando a criação de visualizações leves, ícones ou recursos para processamento posterior.

Para gerar uma miniatura a partir de qualquer forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu ID ou índice.
1. Obtenha uma referência a uma forma nesse slide.
1. Renderize a imagem em miniatura da forma.
1. Salve a imagem em miniatura no formato desejado.

O exemplo abaixo gera uma miniatura de forma.

```py
import aspose.slides as slides

# Instanciar a classe Presentation para abrir o arquivo de apresentação.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Criar uma imagem com a escala padrão.
    with shape.get_image() as thumbnail:
        # Salvar a imagem no disco no formato PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Gerar miniaturas com um fator de escala personalizado**

Esta seção mostra como gerar miniaturas de formas com um fator de escala definido pelo usuário no Aspose.Slides. Ao controlar a escala, você pode ajustar finamente o tamanho da miniatura para atender a visualizações, exportações ou telas de alta DPI.

Para gerar uma miniatura para qualquer forma em um slide:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha um slide pelo seu ID ou índice.
1. Obtenha a forma alvo nesse slide.
1. Renderize a imagem em miniatura da forma com a escala especificada.
1. Salve a imagem em miniatura no formato desejado.

O exemplo abaixo gera uma miniatura com um fator de escala definido pelo usuário.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instanciar a classe Presentation para abrir o arquivo de apresentação.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Criar uma imagem com a escala definida.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Salvar a imagem no disco no formato PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Gerar miniaturas usando os limites de aparência de uma forma**

Esta seção mostra como gerar uma miniatura dentro dos limites de aparência de uma forma. Ela considera todos os efeitos da forma. A miniatura gerada é restrita pelos limites do slide.

Para gerar uma miniatura de qualquer forma de slide dentro dos limites de sua aparência:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha um slide pelo seu ID ou índice.
1. Obtenha a forma alvo nesse slide.
1. Renderize a imagem em miniatura da forma com os limites especificados.
1. Salve a imagem em miniatura no formato de imagem desejado.

O exemplo abaixo cria uma miniatura com limites definidos pelo usuário.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instanciar a classe Presentation para abrir o arquivo de apresentação.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Criar uma imagem de forma com limites de aparência.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Salvar a imagem no disco no formato PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Perguntas frequentes**

**Quais formatos de imagem podem ser usados ao salvar miniaturas de formas?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pt/python-net/aspose.slides/imageformat/), e outros. As formas também podem ser [exportadas como SVG vetorial](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/write_as_svg/) salvando o conteúdo da forma como SVG.

**Qual é a diferença entre os limites SHAPE e APPEARANCE ao renderizar uma miniatura?**

`SHAPE` usa a geometria da forma; `APPEARANCE` leva em conta os [efeitos visuais](/slides/pt/python-net/shape-effect/) (sombras, brilhos, etc.).

**O que acontece se uma forma for marcada como oculta? Ela ainda será renderizada como miniatura?**

Uma forma oculta continua fazendo parte do modelo e pode ser renderizada; a flag oculta afeta a exibição da apresentação, mas não impede a geração da imagem da forma.

**Grupos de formas, gráficos, SmartArt e outros objetos complexos são suportados?**

Sim. Qualquer objeto representado como [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/) (incluindo [GroupShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/) e [SmartArt](https://reference.aspose.com/slides/pt/python-net/aspose.slides.smartart/smartart/)) pode ser salvo como miniatura ou como SVG.

**As fontes instaladas no sistema afetam a qualidade das miniaturas de formas de texto?**

Sim. Você deve [fornecer as fontes necessárias](/slides/pt/python-net/custom-font/) (ou [configurar substituições de fontes](/slides/pt/python-net/font-substitution/)) para evitar substituições indesejadas e reflow de texto.