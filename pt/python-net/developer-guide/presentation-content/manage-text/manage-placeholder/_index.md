---
title: Gerenciar Marcadores de Posição em Apresentações com Python
linktitle: Gerenciar Marcadores de Posição
type: docs
weight: 10
url: /pt/python-net/manage-placeholder/
keywords:
- marcador de posição
- marcador de posição de texto
- marcador de posição de imagem
- marcador de posição de gráfico
- texto de sugestão
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Gerencie marcadores de posição no Aspose.Slides para Python via .NET de forma fácil: substitua texto, personalize sugestões e defina a transparência de imagens no PowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite gerenciar marcadores de posição de apresentações programaticamente. Este artigo explica como encontrar marcadores de posição em slides e alterar seu texto, definir texto de sugestão personalizado para layouts de marcadores de posição e ajustar a transparência de uma imagem usada como plano de fundo de um marcador de posição. Também inclui um FAQ breve que esclarece a diferença entre marcadores de posição base e formas locais, explica como as alterações de marcadores de posição podem ser aplicadas por meio de layouts ou mestres e aponta para o gerenciamento de marcadores de posição de cabeçalho e rodapé.

## **Alterar texto em marcadores de posição**

Usando Aspose.Slides para Python, você pode encontrar e modificar marcadores de posição em slides de uma apresentação. Aspose.Slides permite modificar o texto em um marcador de posição.

**Pré-requisito:** Você precisa de uma apresentação que contenha um marcador de posição. Você pode criar essa apresentação no Microsoft PowerPoint.

Veja como usar Aspose.Slides para substituir o texto em um marcador de posição:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e passe a apresentação como argumento.
1. Obtenha uma referência ao slide pelo seu índice.
1. Percorra as formas para encontrar o marcador de posição.
1. Altere o texto usando o [TextFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/) associado ao [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/).
1. Salve a apresentação modificada.

Este código Python mostra como alterar o texto em um marcador de posição:

```python
import aspose.slides as slides

# Instanciar a classe Presentation.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # Acessar o primeiro slide.
    slide = presentation.slides[0]

    # Percorrer as formas para encontrar marcadores de posição.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Alterar o texto em cada marcador de posição.
            shape.text_frame.text = "This is Placeholder"

    # Salvar a apresentação no disco.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir texto de sugestão para um marcador de posição**

Layouts padrão e pré-construídos incluem texto de sugestão de marcador de posição, como **Clique para adicionar um título** ou **Clique para adicionar um subtítulo**. Com Aspose.Slides, você pode substituir essas sugestões por seu próprio texto nos layouts de marcadores de posição.

O exemplo Python a seguir mostra como definir o texto de sugestão para um marcador de posição:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Percorra as formas para encontrar marcadores de posição.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir transparência da imagem em um marcador de posição**

Aspose.Slides permite definir a transparência de uma imagem de fundo em um marcador de posição de texto. Ao ajustar a transparência da imagem nesse quadro, você pode destacar o texto ou a imagem, dependendo das cores.

O exemplo Python a seguir mostra como definir a transparência de uma imagem de fundo dentro de uma forma:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **FAQ**

**O que é um marcador de posição base e como ele difere de uma forma local em um slide?**

Um marcador de posição base é a forma original em um layout ou mestre que a forma do slide herda—tipo, posição e parte da formatação vêm dela. Uma forma local é independente; se não houver um marcador de posição base, a herança não se aplica.

**Como atualizar todos os títulos ou legendas em uma apresentação sem percorrer cada slide?**

Edite o marcador de posição correspondente no layout ou no mestre. Slides baseados nesses layouts/nesse mestre herdarão automaticamente a alteração.

**Como controlar os marcadores de posição padrão de cabeçalho/rodapé—data e hora, número do slide e texto do rodapé?**

Use os gerenciadores HeaderFooter no escopo apropriado (slides normais, layouts, mestre, notas/manuais) para ativar ou desativar esses marcadores de posição e definir seu conteúdo.