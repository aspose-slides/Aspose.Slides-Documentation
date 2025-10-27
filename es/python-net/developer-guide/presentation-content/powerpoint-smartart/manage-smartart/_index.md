---
title: Administrar SmartArt en presentaciones de PowerPoint usando Python
linktitle: Administrar SmartArt
type: docs
weight: 10
url: /es/python-net/manage-smartart/
keywords:
- SmartArt
- text from SmartArt
- layout type
- hidden property
- organization chart
- picture organization chart
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Aprenda a crear y editar SmartArt de PowerPoint con Aspose.Slides para Python a través de .NET usando ejemplos de código claros que aceleran el diseño y la automatización de diapositivas."
---

## **Visión general**

Esta guía muestra cómo crear y manipular SmartArt en Aspose.Slides para Python. Aprenderá a extraer texto de SmartArt (incluido el contenido de [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) dentro de las formas de nodo), agregar SmartArt a diapositivas y cambiar su diseño, detectar y gestionar nodos ocultos, configurar diseños de organigramas y crear organigramas de imagen, todo con ejemplos concisos de Python que pueden copiarse y pegarse, abren una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), trabajan con diapositivas y nodos de SmartArt, y guardan los resultados en PPTX. 

## **Obtener texto de SmartArt**

La propiedad `text_frame` del [SmartArtShape](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/) le permite recuperar todo el texto de una forma SmartArt, no solo el texto contenido en sus nodos. El siguiente ejemplo muestra cómo obtener texto de un nodo SmartArt.

```py
import aspose.slides as slides

with slides.Presentation("SmartArt.pptx") as presentation:
    slide = presentation.slides[0]
    smart_art = slide.shapes[0]

    for smart_art_node in smart_art.all_nodes:
        for node_shape in smart_art_node.shapes:
            if node_shape.text_frame is not None:
                print(node_shape.text_frame.text)
```

## **Cambiar el tipo de diseño de SmartArt**

Para cambiar el tipo de diseño de SmartArt, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a una diapositiva por su índice.
1. Agregue una forma SmartArt con el diseño `BASIC_BLOCK_LIST`.
1. Cambie su diseño a `BASIC_PROCESS`.
1. Guarde la presentación como un archivo PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Agregar una forma SmartArt con el diseño BASIC_BLOCK_LIST.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Cambiar el tipo de diseño a BASIC_PROCESS.
    smart.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    # Guardar la presentación.
    presentation.save("ChangedSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprobar la propiedad Oculto de SmartArt**

La propiedad `SmartArtNode.is_hidden` devuelve `True` si el nodo está oculto en el modelo de datos. Para comprobar si un nodo SmartArt está oculto, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Agregue una forma SmartArt con el diseño `RADIAL_CYCLE`.
1. Agregue un nodo al SmartArt.
1. Compruebe la propiedad `is_hidden`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Agregar una forma SmartArt con el diseño RADIAL_CYCLE.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    # Agregar un nodo al SmartArt.
    node = smart.all_nodes.add_node()

    # Comprobar la propiedad is_hidden.
    if node.is_hidden:
        print("The node is hidden.")
```

## **Obtener o establecer el tipo de organigrama**

La propiedad `SmartArtNode.organization_chart_layout` obtiene o establece el tipo de organigrama asociado al nodo actual. Para obtener o establecer el tipo de organigrama, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Agregue una forma SmartArt a la diapositiva.
1. Obtenga o establezca el tipo de organigrama.
1. Guarde la presentación como un archivo PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Agregar una forma SmartArt con el diseño ORGANIZATION_CHART.
    smart = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    # Establecer el tipo de organigrama.
    smart.nodes[0].organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    # Guardar la presentación.
    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Crear un organigrama de imagen**

Aspose.Slides para Python proporciona una API sencilla para crear organigramas de imagen fácilmente. Para crear un organigrama en una diapositiva:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a la diapositiva por su índice.
1. Agregue un organigrama con los datos predeterminados del tipo deseado.
1. Guarde la presentación modificada como un archivo PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    
    presentation.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿SmartArt admite reflejo/inversión para idiomas RTL?**

Sí. La propiedad [is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) invierte la dirección del diagrama (LTR/RTL) si el tipo de SmartArt seleccionado soporta la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación manteniendo el formato?**

Puede [clonar la forma SmartArt](/slides/es/python-net/shape-manipulations/) mediante la colección de formas ([ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/)) o [clonar toda la diapositiva](/slides/es/python-net/clone-slides/) que contiene esa forma. Ambos métodos conservan el tamaño, la posición y el estilo.

**¿Cómo renderizo SmartArt a una imagen raster para vista previa o exportación web?**

[Renderice la diapositiva](/slides/es/python-net/convert-powerpoint-to-png/) (o toda la presentación) a PNG/JPEG mediante la API que convierte diapositivas/presentaciones a imágenes; SmartArt se dibujará como parte de la diapositiva.

**¿Cómo puedo seleccionar programáticamente un SmartArt específico en una diapositiva si hay varios?**

Una práctica común es usar el [texto alternativo](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/) (Alt Text) o un [nombre](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/name/) y buscar la forma por ese atributo dentro de [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), luego comprobar el tipo para confirmar que es [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/). La documentación describe técnicas típicas para encontrar y trabajar con formas.