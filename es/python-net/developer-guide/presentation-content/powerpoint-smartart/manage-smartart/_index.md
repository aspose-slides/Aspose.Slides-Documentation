---
title: Gestionar SmartArt en presentaciones de PowerPoint con Python
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
description: "Aprenda a crear y editar SmartArt de PowerPoint con Aspose.Slides para Python a través de .NET utilizando ejemplos de código claros que aceleran el diseño y la automatización de diapositivas."
---
## **Visión general**

SmartArt es un diagrama de PowerPoint formado por nodos, formas de nodo y un diseño. Con Aspose.Slides para Python a través de .NET, puedes crear SmartArt, leer texto de sus nodos, cambiar su diseño, inspeccionar nodos ocultos, configurar diseños de organigrama y crear organigramas con imágenes.

## **Obtener texto de un objeto SmartArt**

Un nodo de SmartArt puede contener una o más formas. Para leer el texto de las formas del nodo, itera a través de [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/), y luego lee el [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) devuelto por [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/).

El ejemplo requiere una presentación con al menos una diapositiva y un objeto SmartArt como la primera forma en esa diapositiva. Imprime cada marco de texto disponible en la consola.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```

## **Cambiar el tipo de diseño de un objeto SmartArt**

El diseño de SmartArt controla cómo se organizan y conectan los nodos. El siguiente ejemplo crea un objeto SmartArt con el valor [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, lo cambia al valor `BASIC_PROCESS` y guarda la presentación. La posición y el tamaño pasados a [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/) se miden en puntos. Establece [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/) para cambiar el diseño.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprobar si un nodo SmartArt está oculto**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) indica si el nodo está oculto en el modelo de datos de SmartArt. Los nodos ocultos pueden existir en la estructura incluso cuando el diseño seleccionado no los muestra como elementos visibles del diagrama.

El siguiente ejemplo añade un nodo a un objeto SmartArt que utiliza el valor [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE` y comprueba el estado de ocultación del nodo añadido. Imprime un mensaje si el nodo está oculto y guarda el diagrama.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtener o establecer el diseño del organigrama**

Para diagramas SmartArt que utilizan un diseño de organigrama, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) define cómo se organizan los nodos hijos bajo un nodo padre. Por ejemplo, puedes establecer que los nodos hijos cuelguen a la izquierda, a la derecha o en ambos lados, según el [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) seleccionado.

El siguiente ejemplo crea un organigrama y establece el diseño para el primer nodo al valor [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`. El índice basado en cero `0` selecciona el primer nodo de nivel superior; sus nodos hijos utilizan la disposición seleccionada. La presentación modificada se guarda a continuación.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```

## **Crear un organigrama con imágenes**

Un organigrama con imágenes es un diseño de SmartArt diseñado para diagramas jerárquicos que incluyen marcadores de posición de imágenes. Usa el valor [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART` al añadir el objeto SmartArt a una diapositiva. Este ejemplo guarda un diagrama con marcadores de posición de imágenes; no rellena los marcadores con imágenes.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Convertir diagramas heredados en grupos de formas**

Al modernizar una presentación existente, puede ser necesario actualizar un organigrama creado originalmente en PowerPoint 97–2003. Aspose.Slides representa estos diagramas heredados como objetos [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/). Usa [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/) para convertir un diagrama en un grupo de formas de modo que puedas editar elementos visuales individuales. Consulta la [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) para obtener más detalles.

La conversión añade un nuevo grupo a la colección de formas sin eliminar el diagrama original. Tras una conversión exitosa, elimina el original con [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) para evitar contenido duplicado. Recopila los diagramas heredados en una lista antes de convertirlos para que la adición y eliminación de formas no interrumpa la iteración.

El siguiente ejemplo abre una presentación, busca en cada diapositiva, convierte los diagramas en grupos de formas y guarda la presentación actualizada como PPTX.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```

La presentación guardada contiene grupos de formas editables en lugar de los diagramas heredados convertidos, sin diagramas originales junto a ellos. Abre el PPTX en PowerPoint para editar elementos individuales dentro de cada grupo, como su texto, relleno o posición.

## **FAQ**

**¿SmartArt admite la reflexión o inversión para idiomas RTL?**

Sí. La propiedad [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) cambia la dirección del diagrama de izquierda a derecha a derecha a izquierda, o viceversa, cuando el diseño de SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación manteniendo el formato?**

Puedes [clonar la forma SmartArt](/slides/es/python-net/shape-manipulations/) con [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) o [clonar toda la diapositiva](/slides/es/python-net/clone-slides/) que contiene el SmartArt. Ambas opciones conservan el tamaño, la posición y el formato.

**¿Cómo renderizo SmartArt a una imagen raster para vista previa o exportación web?**

[Renderiza la diapositiva](/slides/es/python-net/convert-powerpoint-to-png/) o toda la presentación a PNG o JPEG. SmartArt se renderiza como parte de la diapositiva.

**¿Cómo puedo encontrar un objeto SmartArt específico en una diapositiva si hay varios?**

Establece un [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) o [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) distintivo en la forma SmartArt, busca ese valor en [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), y luego verifica que la forma coincidente sea un [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).