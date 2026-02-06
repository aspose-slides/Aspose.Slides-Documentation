---
title: GroupShape
type: docs
weight: 170
url: /es/python-net/examples/elements/group-shape/
keywords:
- grupo
- agregar forma de grupo
- acceder a forma de grupo
- eliminar forma de grupo
- desagrupar formas
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Trabaje con formas de grupo en Python utilizando Aspose.Slides: cree y desagrupe, reordene las formas secundarias, establezca transformaciones y límites en PowerPoint y OpenDocument."
---
Ejemplos de creación de grupos de formas, acceso a ellos, desagrupación y eliminación mediante **Aspose.Slides for Python via .NET**.

## **Agregar una forma de grupo**

Cree un grupo que contenga dos formas básicas.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Añadir una forma de grupo.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a una forma de grupo**

Recupere la primera forma de grupo de una diapositiva.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Acceder a la primera forma de grupo en la diapositiva.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Eliminar una forma de grupo**

Elimine una forma de grupo de la diapositiva.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma sea una forma de grupo.
        group = slide.shapes[0]

        # Eliminar la forma de grupo.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Desagrupar formas**

Mueva las formas fuera de un contenedor de grupo.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma sea una forma de grupo.
        group = slide.shapes[0]

        # Mover las formas fuera del grupo.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```