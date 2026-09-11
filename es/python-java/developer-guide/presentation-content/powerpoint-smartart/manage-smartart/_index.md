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
- organigrama con imagen
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprende a crear y editar SmartArt de PowerPoint con Aspose.Slides para Python a través de Java utilizando ejemplos de código claros que aceleran el diseño y la automatización de diapositivas."
---
## **Descripción general**

SmartArt es un diagrama de PowerPoint formado por nodos, formas de nodo y un diseño. Con Aspose.Slides for Python a través de Java, puedes crear SmartArt, leer el texto de sus nodos, cambiar su diseño, inspeccionar nodos ocultos, configurar diseños de organigramas y crear organigramas con imágenes.

## **Obtener texto de un objeto SmartArt**

Un nodo de SmartArt puede contener una o más formas. Para leer el texto visible, itera a través de [SmartArt.getAllNodes](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/#getAllNodes), luego lee el [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) devuelto por [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartshape/#getTextFrame).

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

El diseño de SmartArt controla cómo se disponen y conectan los nodos. El siguiente ejemplo crea un objeto SmartArt con el valor `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartlayouttype/), lo cambia al valor `BasicProcess` y guarda la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Comprobar si un nodo SmartArt está oculto**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnode/#isHidden) indica si el nodo está oculto en el modelo de datos de SmartArt. Los nodos ocultos pueden existir en la estructura incluso cuando el diseño seleccionado no los muestra como elementos visibles del diagrama.

El siguiente ejemplo añade un nodo a un objeto SmartArt que utiliza el valor `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartlayouttype/) y verifica el estado de ocultación del nodo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obtener o establecer el diseño del organigrama**

Para los diagramas SmartArt que utilizan un diseño de organigrama, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) y [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) definen cómo se disponen los nodos hijos bajo un nodo padre. Por ejemplo, puedes establecer que los nodos hijos cuelguen a la izquierda, a la derecha o a ambos lados, según el [OrganizationChartLayoutType](https://reference.aspose.com/slides/es/python-java/aspose.slides/organizationchartlayouttype/) seleccionado.

El siguiente ejemplo crea un organigrama y establece el diseño del primer nodo al valor `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/es/python-java/aspose.slides/organizationchartlayouttype/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Crear un organigrama con imágenes**

Un organigrama con imágenes es un diseño de SmartArt creado para diagramas jerárquicos que incluyen marcadores de posición de imagen. Utiliza el valor `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartlayouttype/) al añadir el objeto SmartArt a una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿SmartArt admite el reflejo o la inversión para idiomas RTL?**

Sí. El método [SmartArt.setReversed](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/#setReversed) cambia la dirección del diagrama de izquierda a derecha a derecha a izquierda, o viceversa, cuando el diseño de SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación conservando el formato?**

Puedes [clonar la forma SmartArt](/slides/es/python-java/shape-manipulations/) con [ShapeCollection.addClone](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addClone) o [clonar la diapositiva completa](/slides/es/python-java/clone-slides/) que contiene el SmartArt. Ambos métodos conservan el tamaño, la posición y el formato.

**¿Cómo renderizo SmartArt a una imagen raster para vista previa o exportación web?**

[Renderiza la diapositiva](/slides/es/python-java/convert-powerpoint-to-png/) o toda la presentación a PNG o JPEG. SmartArt se renderiza como parte de la diapositiva.

**¿Cómo puedo encontrar un objeto SmartArt concreto en una diapositiva si hay varios?**

Establece un valor distintivo en [Shape.getAlternativeText](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getAlternativeText) o [Shape.getName](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getName) en la forma SmartArt, busca ese valor en [BaseSlide.getShapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getShapes), y luego verifica que la forma coincidente sea un [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/).