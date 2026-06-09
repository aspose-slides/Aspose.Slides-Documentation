---
title: Formas de Apresentação em Grupo com Python
linktitle: Grupo de Formas
type: docs
weight: 40
url: /pt/python-net/group/
keywords:
- forma de grupo
- grupo de formas
- adicionar grupo
- texto alternativo
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a agrupar e desagrupar formas no PowerPoint e em apresentações OpenDocument usando Aspose.Slides para Python — guia rápido, passo a passo, com código gratuito."
---
## **Visão geral**

Este artigo explica como trabalhar com formas de grupo no Aspose.Slides. Ele mostra como adicionar uma forma de grupo a um slide, colocar formas dentro dela e salvar a apresentação atualizada. Também demonstra como acessar as formas armazenadas dentro de um grupo e ler seus valores `alternative_text`. Além disso, o artigo aborda brevemente recursos relacionados a formas de grupo, como grupos aninhados, ordem Z e opções de bloqueio.

## **Adicionar formas de grupo**

O Aspose.Slides oferece suporte ao trabalho com formas de grupo em um slide. Esse recurso permite criar apresentações mais ricas tratando várias formas como um único objeto. Você pode adicionar novas formas de grupo, acessar as existentes, preenchê-las com formas filhas e ler ou modificar quaisquer de suas propriedades. Para adicionar uma forma de grupo a um slide:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha uma referência a um slide por índice.
3. Adicione um [GroupShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/groupshape/) ao slide.
4. Adicione formas à nova forma de grupo.
5. Salve a apresentação modificada como um arquivo PPTX.

O exemplo abaixo mostra como adicionar uma forma de grupo a um slide.

```py
import aspose.slides as slides

# Instanciar a classe Presentation.
with slides.Presentation() as presentation:
    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar uma forma de grupo ao slide.
    group_shape = slide.shapes.add_group_shape()

    # Adicionar formas dentro da forma de grupo.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Gravar o arquivo PPTX no disco.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar a propriedade Alt Text**

Esta seção explica como ler o Alt Text das formas contidas dentro de uma forma de grupo em um slide usando o Aspose.Slides. Para acessar o Alt Text das formas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) para representar um arquivo PPTX.
2. Obtenha uma referência ao slide pelo seu índice.
3. Acesse a coleção de formas do slide.
4. Acesse o [GroupShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/groupshape/).
5. Leia a propriedade Alt Text.

O exemplo abaixo recupera o Alt Text das formas contidas dentro de formas de grupo.

```py
import aspose.slides as slides

# Instanciar a classe Presentation para abrir o arquivo PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # Obter o primeiro slide.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Acessar a forma de grupo.
            for child_shape in shape.shapes:
                # Acessar a propriedade Alt Text.
                print(child_shape.alternative_text)
```

## **Perguntas frequentes**

**É o agrupamento aninhado (um grupo dentro de outro grupo) suportado?**

Sim. O [GroupShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/groupshape/) possui a propriedade [parent_group](https://reference.aspose.com/slides/pt/python-net/aspose.slides/groupshape/parent_group/), que indica diretamente o suporte à hierarquia (um grupo pode ser filho de outro grupo).

**Como controlar a ordem Z do grupo em relação a outros objetos no slide?**

Use a propriedade [z_order_position](https://reference.aspose.com/slides/pt/python-net/aspose.slides/groupshape/z_order_position/) do [GroupShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/groupshape/) para verificar sua posição na pilha de exibição.

**Posso impedir mover/editar/desagrupar?**

Sim. A seção de bloqueio do grupo é exposta através de [group_shape_lock](https://reference.aspose.com/slides/pt/python-net/aspose.slides/groupshape/group_shape_lock/), que permite restringir operações no objeto.