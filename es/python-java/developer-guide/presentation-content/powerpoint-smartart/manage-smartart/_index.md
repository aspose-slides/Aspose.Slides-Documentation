---
title: Gestionar SmartArt en presentaciones de PowerPoint usando Python
linktitle: Gestionar SmartArt
type: docs
weight: 10
url: /es/python-java/manage-smartart/
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
description: "Aprende a crear y editar SmartArt de PowerPoint con Aspose.Slides para Python a través de Java usando ejemplos de código claros que agilizan el diseño de diapositivas y la automatización."
---
## **Visión general**

SmartArt es un diagrama de PowerPoint compuesto por nodos, formas de nodo y un diseño. Con Aspose.Slides para Python a través de Java, puedes crear SmartArt, leer texto de sus nodos, cambiar su diseño, inspeccionar nodos ocultos, configurar diseños de organigramas y crear organigramas con imágenes.

## **Obtener texto de un objeto SmartArt**

Un nodo SmartArt puede contener una o más formas. Para leer el texto de las formas del nodo, recorre [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes), luego lee el [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) devuelto por [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame).

El ejemplo requiere una presentación con al menos una diapositiva y un objeto SmartArt como la primera forma en esa diapositiva. Imprime cada marco de texto disponible en la consola.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape
        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **Cambiar el tipo de diseño de un objeto SmartArt**

El diseño de SmartArt controla cómo se disponen y conectan los nodos. El siguiente ejemplo crea un objeto SmartArt con el valor `BasicBlockList` del [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/), lo cambia al valor `BasicProcess` y guarda la presentación. La posición y el tamaño pasados a [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) se miden en puntos. Usa [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) para cambiar el diseño.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Comprobar si un nodo SmartArt está oculto**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) indica si el nodo está oculto en el modelo de datos de SmartArt. Los nodos ocultos pueden existir en la estructura aun cuando el diseño seleccionado no los muestre como elementos visibles del diagrama.

El siguiente ejemplo añade un nodo a un objeto SmartArt que utiliza el valor `RadialCycle` del [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) y verifica el estado oculto del nodo añadido. Imprime un mensaje si el nodo está oculto y guarda el diagrama.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obtener o establecer el diseño del organigrama**

Para diagramas SmartArt que usan un diseño de organigrama, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) y [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) definen cómo se disponen los nodos hijos bajo un nodo padre. Por ejemplo, puedes establecer que los nodos hijos cuelguen del lado izquierdo, derecho o de ambos, según el [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) seleccionado.

El siguiente ejemplo crea un organigrama y establece el diseño del primer nodo al valor `LeftHanging` del [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/). El índice basado en cero `0` selecciona el primer nodo de nivel superior; sus nodos hijos utilizan la disposición seleccionada. La presentación modificada se guarda entonces.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Crear un organigrama con imágenes**

Un organigrama con imágenes es un diseño de SmartArt creado para diagramas jerárquicos que incluyen marcadores de posición de imágenes. Usa el valor `PictureOrganizationChart` del [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) al añadir el objeto SmartArt a una diapositiva. Este ejemplo guarda un diagrama con marcadores de posición de imagen; no rellena los marcadores con imágenes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Convertir diagramas heredados a grupos de formas**

Al modernizar una presentación existente, puede que necesites actualizar un organigrama creado originalmente en PowerPoint 97–2003. Aspose.Slides representa estos diagramas heredados como objetos [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/). Usa [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) para convertir un diagrama en un grupo de formas, de modo que puedas editar elementos visuales individualmente. Consulta la [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) para más detalles.

La conversión añade un nuevo grupo a la colección de formas sin eliminar el diagrama original. Tras una conversión exitosa, elimina el original con [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) para evitar contenido duplicado. Recoge los diagramas heredados en una lista antes de convertirlos, de modo que la adición y eliminación de formas no interrumpa la iteración.

El siguiente ejemplo abre una presentación, busca en cada diapositiva, convierte los diagramas en grupos de formas y guarda la presentación actualizada como PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La presentación guardada contiene grupos de formas editables en lugar de los diagramas heredados convertidos, sin diagramas originales junto a ellos. Abre el PPTX en PowerPoint para editar elementos individuales dentro de cada grupo, como su texto, relleno o posición.

## **FAQ**

**¿SmartArt soporta la reflexión o inversión para idiomas de derecha a izquierda?**

Sí. El método [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) cambia la dirección del diagrama de izquierda a derecha a derecha a izquierda, o viceversa, cuando el diseño SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación conservando el formato?**

Puedes [clonar la forma SmartArt](/slides/es/python-java/shape-manipulations/) con [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) o [clonar la diapositiva completa](/slides/es/python-java/clone-slides/) que contiene el SmartArt. Ambos enfoques conservan el tamaño, la posición y el formato.

**¿Cómo puedo renderizar SmartArt a una imagen rasterizada para vista previa o exportación web?**

[Renderizar la diapositiva](/slides/es/python-java/convert-powerpoint-to-png/) o la presentación completa a PNG o JPEG. SmartArt se renderiza como parte de la diapositiva.

**¿Cómo puedo encontrar un objeto SmartArt específico en una diapositiva si hay varios?**

Usa [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) o [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) para asignar un texto alternativo distintivo o un nombre al objeto SmartArt, busca ese valor en [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes), y luego verifica que la forma coincidente sea un [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/).