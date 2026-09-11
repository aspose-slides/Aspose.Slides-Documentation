---
title: Gestionar nodos de forma SmartArt en presentaciones usando Python
linktitle: Nodo de forma SmartArt
type: docs
weight: 30
url: /es/python-java/manage-smartart-shape-node/
keywords:
- nodo SmartArt
- nodo secundario
- añadir nodo
- posición del nodo
- acceder al nodo
- eliminar nodo
- posición personalizada
- nodo asistente
- formato de relleno
- renderizar nodo
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Gestiona los nodos de forma SmartArt en PPT y PPTX con Aspose.Slides para Python a través de Java. Obtén ejemplos de código claros y consejos para optimizar tus presentaciones."
---
## **Resumen**

Los gráficos SmartArt en presentaciones de PowerPoint se organizan mediante nodos que contienen texto y definen la estructura del diagrama. Aspose.Slides permite trabajar con estos nodos SmartArt de forma programática: añadir nuevos nodos y nodos secundarios, insertar nodos secundarios en una posición concreta, acceder a nodos existentes y leer su texto, nivel y posición.

Este artículo explica cómo gestionar los nodos de forma de SmartArt. Muestra cómo eliminar nodos, trabajar con nodos secundarios por índice o posición, cambiar un nodo asistente a nodo normal, ajustar la posición, tamaño y rotación de las formas de los nodos SmartArt, establecer formatos de relleno de los nodos y generar una imagen en miniatura para un nodo secundario de SmartArt.

## **Añadir un nodo SmartArt**
Aspose.Slides for Python via Java proporciona una API para gestionar formas SmartArt. El siguiente ejemplo añade un nodo y un nodo secundario a una forma SmartArt.

1. Crear una instancia de la [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargar la presentación que contiene una forma SmartArt.  
2. Obtener la primera diapositiva por su índice.  
3. Recorrer todas las formas de la primera diapositiva.  
4. Comprobar si la forma es una instancia de [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/).  
5. [Añadir un nuevo nodo](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnodecollection/#addNode) a la [colección de nodos](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/#getAllNodes) de la forma SmartArt y establecer su texto mediante [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/).  
6. [Añadir](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnodecollection/#addNode) un [nodo secundario](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnode/#getChildNodes) al nuevo nodo y establecer su texto mediante [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/).  
7. Guardar la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Añadir un nodo SmartArt en una posición específica**
El siguiente ejemplo añade un nodo secundario en una posición concreta dentro de un nodo SmartArt.

1. Crear una instancia de la [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).  
2. Obtener la primera diapositiva por su índice.  
3. Añadir una forma [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/) con el diseño [StackedList](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartlayouttype/#StackedList) a la diapositiva.  
4. Acceder al primer nodo de la forma SmartArt añadida.  
5. Añadir un nodo secundario al nodo seleccionado en la posición 2 mediante [addNodeByPosition](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) y establecer su texto.  
6. Guardar la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acceder a un nodo SmartArt**
El siguiente ejemplo accede a los nodos de una forma SmartArt. El diseño devuelto por [getLayout](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/#getLayout) es de solo lectura y se establece cuando se añade la forma SmartArt.

1. Crear una instancia de la [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargar la presentación que contiene una forma SmartArt.  
2. Obtener la primera diapositiva por su índice.  
3. Recorrer todas las formas de la primera diapositiva.  
4. Comprobar si la forma es una instancia de [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/).  
5. Recorrer todos los [nodos](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/#getAllNodes) de la forma SmartArt.  
6. Leer y mostrar la posición, nivel y texto de cada nodo SmartArt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **Acceder a un nodo secundario de SmartArt**
El siguiente ejemplo accede a los nodos secundarios de cada nodo en una forma SmartArt.

1. Crear una instancia de la [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargar la presentación que contiene una forma SmartArt.  
2. Obtener la primera diapositiva por su índice.  
3. Recorrer todas las formas de la primera diapositiva.  
4. Comprobar si la forma es una instancia de [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/).  
5. Recorrer todos los [nodos](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/#getAllNodes) de la forma SmartArt.  
6. Para cada nodo, recorrer sus [nodos secundarios](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnode/#getChildNodes).  
7. Leer y mostrar la posición, nivel y texto del [nodo secundario](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **Acceder a un nodo secundario de SmartArt en una posición específica**
El siguiente ejemplo accede a un nodo secundario en un índice concreto dentro de la colección del nodo principal.

1. Crear una instancia de la [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).  
2. Obtener la primera diapositiva por su índice.  
3. Añadir una forma SmartArt con el diseño [StackedList](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartlayouttype/#StackedList).  
4. Acceder a la forma SmartArt añadida.  
5. Acceder al nodo en el índice 0 de la forma SmartArt.  
6. Acceder al nodo secundario en el índice 1 mediante [get_Item](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnodecollection/#get_Item).  
7. Leer y mostrar la posición, nivel y texto del [nodo secundario](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **Eliminar un nodo SmartArt**
El siguiente ejemplo elimina un nodo de una forma SmartArt.

1. Crear una instancia de la [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargar la presentación que contiene una forma SmartArt.  
2. Obtener la primera diapositiva por su índice.  
3. Recorrer todas las formas de la primera diapositiva.  
4. Comprobar si la forma es una instancia de [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/).  
5. Verificar que la forma [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/) contiene al menos un nodo.  
6. Seleccionar el nodo SmartArt que se va a eliminar.  
7. Eliminar el nodo seleccionado mediante [removeNode](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnodecollection/#removeNode).  
8. Guardar la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Eliminar un nodo SmartArt de una posición específica**
El siguiente ejemplo elimina un nodo secundario en un índice concreto dentro de la colección de un nodo SmartArt.

1. Crear una instancia de la [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargar la presentación que contiene una forma SmartArt.  
2. Obtener la primera diapositiva por su índice.  
3. Recorrer todas las formas de la primera diapositiva.  
4. Comprobar si la forma es una instancia de [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/).  
5. Acceder al nodo SmartArt en el índice 0 si existe.  
6. Verificar que el nodo SmartArt seleccionado tiene al menos dos nodos secundarios.  
7. Eliminar el nodo secundario en el índice 1 mediante [removeNode](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnodecollection/#removeNode).  
8. Guardar la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer una posición personalizada para un nodo secundario en un objeto SmartArt**
Aspose.Slides for Python via Java permite establecer la posición de un [SmartArtShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartshape/) mediante [setX](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#setX) y [setY](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#setY). El siguiente ejemplo define una posición, tamaño y rotación personalizada para las formas de los nodos SmartArt. Añadir nuevos nodos recalcula las posiciones y tamaños de todos los nodos. La posición personalizada permite organizar los nodos según sea necesario.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Comprobar un nodo asistente**
{{% alert color="info" title="Note" %}} 

Esta sección explora las formas SmartArt añadidas a diapositivas de presentación de forma programática mediante Aspose.Slides for Python via Java.

{{% /alert %}} 

La forma SmartArt de origen utilizada en este ejemplo es la siguiente.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figura: Forma SmartArt de origen en una diapositiva**|

El siguiente ejemplo identifica nodos asistentes en una colección de nodos SmartArt y los transforma en nodos normales.

1. Crear una instancia de la [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y cargar la presentación que contiene una forma SmartArt.  
2. Obtener la primera diapositiva por su índice.  
3. Recorrer todas las formas de la primera diapositiva.  
4. Comprobar si la forma es una instancia de [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/).  
5. Recorrer todos los nodos de la forma SmartArt y comprobar si son [Assistant Nodes](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartnode/#isAssistant).  
6. Cambiar cada nodo asistente a un nodo normal.  
7. Guardar la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figura: Nodos asistentes modificados en una forma SmartArt sobre una diapositiva**|

## **Establecer el formato de relleno de un nodo**
Aspose.Slides for Python via Java permite añadir formas SmartArt personalizadas y establecer su formato de relleno. Este artículo explica cómo crear y acceder a formas SmartArt y establecer su formato de relleno usando Aspose.Slides for Python via Java.

Siga los pasos a continuación:

1. Crear una instancia de la [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).  
2. Obtener una diapositiva por su índice.  
3. Añadir una forma [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/) con el diseño [ClosedChevronProcess](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess).  
4. Establecer el [FillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getFillFormat) para los nodos de la forma SmartArt.  
5. Guardar la presentación modificada como archivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Generar una miniatura de un nodo secundario de SmartArt**
Para generar una miniatura de un nodo secundario de SmartArt, siga estos pasos:

1. Crear una instancia de la [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).  
2. [Añadir una forma SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addSmartArt).  
3. Obtener un nodo por su índice.  
4. Obtener la imagen en miniatura.  
5. Guardar la imagen en miniatura en el formato de imagen deseado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Se admite la animación de SmartArt?**

Sí. SmartArt se trata como una forma normal, por lo que puede [aplicar animaciones estándar](/slides/es/python-java/shape-animation/) (entrada, salida, énfasis, trayectorias de movimiento) y ajustar la sincronización. También puede animar las formas dentro de los nodos SmartArt cuando sea necesario.

**¿Cómo localizar de forma fiable un SmartArt específico en una diapositiva si su ID interno es desconocido?**

Asigne y busque por [texto alternativo](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getAlternativeText). Establecer un texto alternativo distintivo en el SmartArt permite encontrarlo programáticamente sin depender de identificadores internos.

**¿Se preservará la apariencia de SmartArt al convertir la presentación a PDF?**

Sí. Aspose.Slides renderiza SmartArt con alta fidelidad visual durante la [exportación a PDF](/slides/es/python-java/convert-powerpoint-to-pdf/), preservando el diseño, colores y efectos.

**¿Puedo extraer una imagen de todo el SmartArt (para vistas previas o informes)?**

Sí. Puede renderizar una forma SmartArt a [formatos rasterizados](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage) o a [SVG](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#writeAsSvgToBytes) para obtener una salida vectorial escalable, lo que la hace adecuada para miniaturas, informes o uso web.