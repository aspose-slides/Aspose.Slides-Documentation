---
title: Formas de grupos em apresentações no Python via Java
linktitle: Grupo de Formas
type: docs
weight: 40
url: /pt/python-java/group/
keywords:
- shape de grupo
- grupo de shape
- adicionar grupo
- texto alternativo
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a agrupar e desagrupar formas em apresentações PowerPoint usando o Aspose.Slides para Python via Java — um guia passo a passo com código Python gratuito."
---
## **Visão geral**

Este artigo explica como trabalhar com shapes de grupo no Aspose.Slides. Ele mostra como adicionar um shape de grupo a um slide, colocar shapes dentro dele e salvar a apresentação atualizada. Também demonstra como acessar shapes armazenados dentro de um grupo e ler o texto alternativo usando [getAlternativeText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getAlternativeText). Além disso, o artigo aborda brevemente recursos relacionados a shapes de grupo, como grupos aninhados, ordem Z e opções de bloqueio.

## **Adicionar um Grupo de Formas**

O Aspose.Slides oferece suporte ao trabalho com shapes de grupo em slides. Esse recurso ajuda os desenvolvedores a criar apresentações mais ricas. O Aspose.Slides for Python via Java permite adicionar e acessar shapes de grupo. Você pode preencher um shape de grupo com shapes ou acessar suas propriedades. Para adicionar um shape de grupo a um slide usando o Aspose.Slides for Python via Java:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo índice.
1. Adicione um shape de grupo ao slide.
1. Adicione shapes ao shape de grupo.
1. Salve a apresentação modificada como um arquivo PPTX.

O exemplo abaixo adiciona um shape de grupo a um slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Instanciar a classe Presentation.
presentation = Presentation()
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Acessar a coleção de shapes do slide.
    slide_shapes = slide.getShapes()

    # Adicionar um shape de grupo ao slide.
    group_shape = slide_shapes.addGroupShape()

    # Adicionar shapes dentro do shape de grupo.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Definir o frame do shape de grupo.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # Gravar o arquivo PPTX no disco.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acessar Texto Alternativo**

Esta seção mostra como acessar o texto alternativo dos shapes dentro de um grupo em um slide. Para acessar esse texto usando o Aspose.Slides for Python via Java:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) que representa um arquivo PPTX.
1. Obtenha uma referência a um slide pelo índice.
1. Acesse a coleção de shapes do slide.
1. Acesse o shape de grupo.
1. Leia o texto alternativo de seus shapes usando [getAlternativeText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getAlternativeText).

O exemplo abaixo acessa o texto alternativo dos shapes dentro de um grupo:

```python
import jpway
import asposeslides

if not jpway.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import GroupShape, Presentation

# Instanciar a classe Presentation que representa o arquivo PPTX.
presentation = Presentation("AltText.pptx")
try:
    # Obter o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Acessar um shape na coleção de shapes do slide.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Acessar os shapes dentro do grupo.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Ler o texto alternativo.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**O agrupamento aninhado (um grupo dentro de outro grupo) é suportado?**

Sim. [GroupShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/groupshape/) possui o método [getParentGroup](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getParentGroup), que indica suporte a hierarquia: um grupo pode ser filho de outro grupo.

**Como controlo a ordem Z do grupo em relação a outros objetos no slide?**

Use o método [getZOrderPosition](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getZOrderPosition) do objeto [GroupShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/groupshape/) para inspecionar sua posição na pilha de exibição.

**Posso impedir a movimentação, edição ou desagrupamento?**

Sim. Os bloqueios do grupo são expostos via [getGroupShapeLock](https://reference.aspose.com/slides/pt/python-java/aspose.slides/groupshape/#getGroupShapeLock), que permite restringir operações no objeto.