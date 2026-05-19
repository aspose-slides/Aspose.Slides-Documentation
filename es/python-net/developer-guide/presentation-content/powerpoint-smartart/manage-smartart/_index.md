---
title: Gestionar SmartArt en presentaciones de PowerPoint usando Python
linktitle: Gestionar SmartArt
type: docs
weight: 10
url: /es/python-net/manage-smartart/
keywords:
- SmartArt
- texto de SmartArt
- tipo de diseño
- propiedad oculta
- organigrama
- organigrama con imágenes
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprende a crear y editar SmartArt en PowerPoint con Aspose.Slides para Python mediante .NET utilizando ejemplos de código claros que aceleran el diseño y la automatización de diapositivas."
---
## **Descripción general**

SmartArt es un diagrama de PowerPoint formado por nodos, formas de nodos y un diseño. Con Aspose.Slides for Python a través de .NET, puedes crear SmartArt, leer el texto de sus nodos, cambiar su diseño, inspeccionar nodos ocultos, configurar diseños de organigramas y crear organigramas con imágenes.

## **Obtener texto de un objeto SmartArt**

Un nodo de SmartArt puede contener una o más formas. Para leer el texto visible, itera a través de [SmartArt.all_nodes](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/smartart/all_nodes/) y luego lee el [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) devuelto por [SmartArtShape.text_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/smartartshape/text_frame/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```

## **Cambiar el tipo de diseño de un objeto SmartArt**

El diseño de SmartArt controla cómo se disponen y conectan los nodos. El siguiente ejemplo crea un objeto SmartArt con el valor `BASIC_BLOCK_LIST` del [SmartArtLayoutType](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/smartartlayouttype/), lo cambia al valor `BASIC_PROCESS` y guarda la presentación.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprobar si un nodo SmartArt está oculto**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/smartartnode/is_hidden/) indica si el nodo está oculto en el modelo de datos de SmartArt. Los nodos ocultos pueden existir en la estructura aunque el diseño seleccionado no los muestre como elementos visibles del diagrama.

El siguiente ejemplo añade un nodo a un objeto SmartArt que utiliza el valor `RADIAL_CYCLE` del [SmartArtLayoutType](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/smartartlayouttype/) y comprueba el estado de ocultación del nodo.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtener o establecer el diseño del organigrama**

Para diagramas SmartArt que usan un diseño de organigrama, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) define cómo se disponen los nodos hijos bajo un nodo padre. Por ejemplo, puedes establecer que los nodos hijos cuelguen a la izquierda, a la derecha o a ambos lados, según el [OrganizationChartLayoutType](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/organizationchartlayouttype/) seleccionado.

El siguiente ejemplo crea un organigrama y establece el diseño para el primer nodo al valor `LEFT_HANGING` del [OrganizationChartLayoutType](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/organizationchartlayouttype/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Crear un organigrama con imágenes**

Un organigrama con imágenes es un diseño de SmartArt pensado para diagramas jerárquicos que incluyen marcadores de posición de imagen. Usa el valor `PICTURE_ORGANIZATION_CHART` del [SmartArtLayoutType](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/smartartlayouttype/) al añadir el objeto SmartArt a una diapositiva.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿SmartArt soporta la reflexión o inversión para idiomas RTL?**

Sí. La propiedad [SmartArt.is_reversed](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/smartart/is_reversed/) cambia la dirección del diagrama de izquierda a derecha a derecha a izquierda, o viceversa, cuando el diseño de SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación conservando el formato?**

Puedes [clonar la forma SmartArt](/slides/es/python-net/shape-manipulations/) con [ShapeCollection.add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_clone/) o [clonar la diapositiva completa](/slides/es/python-net/clone-slides/) que contiene el SmartArt. Ambos enfoques conservan el tamaño, la posición y el formato.

**¿Cómo renderizo SmartArt a una imagen raster para vista previa o exportación web?**

[Renderizar la diapositiva](/slides/es/python-net/convert-powerpoint-to-png/) o toda la presentación a PNG o JPEG. SmartArt se renderiza como parte de la diapositiva.

**¿Cómo puedo encontrar un objeto SmartArt específico en una diapositiva si hay varios?**

Establece un texto alternativo distintivo con [Shape.alternative_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/alternative_text/) o un nombre con [Shape.name](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/name/) en la forma SmartArt, busca ese valor en [Slide.shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/shapes/) y, a continuación, verifica que la forma coincidente sea un [SmartArt](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/smartart/).