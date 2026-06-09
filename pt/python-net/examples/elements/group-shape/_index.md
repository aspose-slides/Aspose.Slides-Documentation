---
title: "Forma de Grupo"
type: docs
weight: 170
url: /pt/python-net/examples/elements/group-shape/
keywords:
- "grupo"
- "adicionar forma de grupo"
- "acessar forma de grupo"
- "remover forma de grupo"
- "desagrupar formas"
- "exemplos de código"
- "PowerPoint"
- "OpenDocument"
- "apresentação"
- "Python"
- "Aspose.Slides"
description: "Trabalhe com formas de grupo em Python usando Aspose.Slides: crie e desagrupe, reorganize formas filhas, defina transformações e limites em PowerPoint e OpenDocument."
---
Exemplos de criação de grupos de formas, acesso a eles, desagrupamento e remoção usando **Aspose.Slides for Python via .NET**.

## **Adicionar um Grupo de Formas**

Crie um grupo contendo duas formas básicas.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Adicionar uma forma de grupo.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar um Grupo de Formas**

Recupere o primeiro grupo de formas de um slide.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Acessar a primeira forma de grupo no slide.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Remover um Grupo de Formas**

Exclua um grupo de formas do slide.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Supondo que a primeira forma seja uma forma de grupo.
        group = slide.shapes[0]

        # Remover a forma de grupo.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Desagrupar Formas**

Mova as formas para fora de um contêiner de grupo.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Supondo que a primeira forma seja uma forma de grupo.
        group = slide.shapes[0]

        # Mover formas para fora do grupo.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```