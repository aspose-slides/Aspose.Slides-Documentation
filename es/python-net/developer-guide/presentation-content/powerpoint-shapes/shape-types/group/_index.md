---
title: Grupo
type: docs
weight: 40
url: /es/python-net/group/
keywords: "Forma de grupo, forma de PowerPoint, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Añadir forma de grupo a la presentación de PowerPoint en Python"
---

## **Añadir forma de grupo**
Aspose.Slides permite trabajar con formas de grupo en las diapositivas. Esta característica ayuda a los desarrolladores a soportar presentaciones más ricas. Aspose.Slides para Python a través de .NET soporta añadir o acceder a formas de grupo. Es posible añadir formas a una forma de grupo añadida para poblarla o acceder a cualquier propiedad de la forma de grupo. Para añadir una forma de grupo a una diapositiva usando Aspose.Slides para Python a través de .NET:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva utilizando su índice.
1. Añadir una forma de grupo a la diapositiva.
1. Añadir las formas a la forma de grupo añadida.
1. Guardar la presentación modificada como un archivo PPTX.

El siguiente ejemplo añade una forma de grupo a una diapositiva.

```py
import aspose.slides as slides

# Instanciar la clase Presentation
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Accediendo a la colección de formas de las diapositivas
    slideShapes = sld.shapes

    # Añadiendo una forma de grupo a la diapositiva
    groupShape = slideShapes.add_group_shape()

    # Añadiendo formas dentro de la forma de grupo añadida
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Añadiendo marco a la forma de grupo
    groupShape.frame = slides.ShapeFrame(100, 300, 500, 40, -1, -1, 0)

    # Escribir el archivo PPTX en disco
    pres.save("GroupShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Acceder a la propiedad AltText**
Este tema muestra pasos simples, completos con ejemplos de código, para añadir una forma de grupo y acceder a la propiedad AltText de las formas de grupo en las diapositivas. Para acceder a AltText de una forma de grupo en una diapositiva utilizando Aspose.Slides para Python a través de .NET:

1. Instanciar la clase `Presentation` que representa el archivo PPTX.
1. Obtener la referencia de una diapositiva utilizando su índice.
1. Acceder a la colección de formas de las diapositivas.
1. Acceder a la forma de grupo.
1. Acceder a la propiedad AltText.

El siguiente ejemplo accede al texto alternativo de la forma de grupo.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa el archivo PPTX
with slides.Presentation(path + "AltText.pptx") as pres:

    # Obtener la primera diapositiva
    sld = pres.slides[0]

    for i in range(len(sld.shapes)):
        # Accediendo a la colección de formas de las diapositivas
        shape = sld.shapes[i]

        if type(shape) is slides.GroupShape:
            # Accediendo a la forma de grupo.
            for j in range(len(shape.shapes)):
                # Accediendo a la propiedad AltText
                print(shape.shapes[j].alternative_text)
```