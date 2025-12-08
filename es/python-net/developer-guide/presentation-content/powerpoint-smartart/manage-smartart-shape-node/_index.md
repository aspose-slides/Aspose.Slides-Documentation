---
title: Administrar nodos de forma SmartArt en presentaciones usando Python
linktitle: Nodo de forma SmartArt
type: docs
weight: 30
url: /es/python-net/manage-smartart-shape-node/
keywords:
- nodo SmartArt
- nodo hijo
- agregar nodo
- posición del nodo
- acceso nodo
- eliminar nodo
- posición personalizada
- nodo asistente
- formato de relleno
- renderizar nodo
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Administre los nodos de forma SmartArt en PPT, PPTX y ODP con Aspose.Slides para Python a través de .NET. Obtenga ejemplos de código claros y consejos para optimizar sus presentaciones."
---

## **Agregar nodo SmartArt**
Aspose.Slides for Python via .NET ha proporcionado la API más simple para administrar las formas SmartArt de la manera más fácil. El siguiente código de ejemplo ayudará a agregar un nodo y un nodo hijo dentro de una forma SmartArt.

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargar la presentación con una forma SmartArt.
- Obtener la referencia de la primera diapositiva usando su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verificar si la forma es del tipo SmartArt y convertir la forma seleccionada a SmartArt si lo es.
- Agregar un nuevo nodo en la colección NodeCollection de la forma SmartArt y establecer el texto en TextFrame.
- Ahora, agregar un nodo hijo en el nodo SmartArt recién añadido y establecer el texto en TextFrame.
- Guardar la presentación.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Cargar la presentación deseada
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Recorrer todas las formas dentro de la primera diapositiva
    for shape in pres.slides[0].shapes:

        # Verificar si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Añadir un nuevo nodo SmartArt
            node1 = shape.all_nodes.add_node()
            # Añadir texto
            node1.text_frame.text = "Test"

            # Añadir un nuevo nodo hijo al nodo principal. Se añadirá al final de la colección
            new_node = node1.child_nodes.add_node()

            # Añadir texto
            new_node.text_frame.text = "New Node Added"

    # Guardar la presentación
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Agregar nodo SmartArt en posición específica**
En el siguiente código de ejemplo hemos explicado cómo agregar los nodos hijos pertenecientes a los nodos respectivos de la forma SmartArt en una posición particular.

- Crear una instancia de la clase `Presentation`.
- Obtener la referencia de la primera diapositiva usando su índice.
- Agregar una forma SmartArt de tipo StackedList en la diapositiva accedida.
- Acceder al primer nodo en la forma SmartArt añadida.
- Ahora, agregar el nodo hijo para el nodo seleccionado en la posición 2 y establecer su texto.
- Guardar la presentación.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Crear una instancia de presentación
with slides.Presentation() as pres:
    # Acceder a la diapositiva de la presentación
    slide = pres.slides[0]

    # Añadir IShape de Smart Art
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Acceder al nodo SmartArt en el índice 0
    node = smart.all_nodes[0]

    # Añadir nuevo nodo hijo en la posición 2 del nodo padre
    chNode = node.child_nodes.add_node_by_position(2)

    # Añadir texto
    chNode.text_frame.text = "Sample text Added"

    # Guardar la presentación
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Acceder al nodo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos dentro de una forma SmartArt. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt ya que es de solo lectura y se establece solo cuando se agrega la forma SmartArt.

- Crear una instancia de la clase `Presentation` y cargar la presentación con una forma SmartArt.
- Obtener la referencia de la primera diapositiva usando su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verificar si la forma es del tipo SmartArt y convertir la forma seleccionada a SmartArt si lo es.
- Recorrer todos los nodos dentro de la forma SmartArt.
- Acceder y mostrar información como la posición del nodo SmartArt, su nivel y texto.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Cargar la presentación deseada
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Recorrer todas las formas dentro de la primera diapositiva
    for shape in pres.slides[0].shapes:
        # Verificar si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Recorrer todos los nodos dentro del SmartArt
            for i in range(len(shape.all_nodes)):
                # Acceder al nodo SmartArt en el índice i
                node = shape.all_nodes[i]

                # Imprimir los parámetros del nodo SmartArt
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```


## **Acceder al nodo hijo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos hijos pertenecientes a los nodos respectivos de la forma SmartArt.

- Crear una instancia de la clase PresentationEx y cargar la presentación con una forma SmartArt.
- Obtener la referencia de la primera diapositiva usando su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verificar si la forma es del tipo SmartArt y convertir la forma seleccionada a SmartArtEx si lo es.
- Recorrer todos los nodos dentro de la forma SmartArt.
- Para cada nodo de forma SmartArt seleccionado, recorrer todos los nodos hijos dentro del nodo particular.
- Acceder y mostrar información como la posición del nodo hijo, su nivel y texto.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Cargar la presentación deseada
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Recorrer todas las formas dentro de la primera diapositiva
    for shape in pres.slides[0].shapes:
        # Verificar si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Recorrer todos los nodos dentro del SmartArt
            for node0 in shape.all_nodes:
                # Recorrer los nodos hijos
                for j in range(len(node0.child_nodes)):
                    # Acceder al nodo hijo en el nodo SmartArt
                    node = node0.child_nodes[j]

                    # Imprimir los parámetros del nodo hijo SmartArt
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))
```


## **Acceder al nodo hijo SmartArt en posición específica**
En este ejemplo, aprenderemos a acceder a los nodos hijos en una posición particular que pertenecen a los nodos respectivos de la forma SmartArt.

- Crear una instancia de la clase `Presentation`.
- Obtener la referencia de la primera diapositiva usando su índice.
- Agregar una forma SmartArt de tipo StackedList.
- Acceder a la forma SmartArt añadida.
- Acceder al nodo en el índice 0 de la forma SmartArt accedida.
- Ahora, acceder al nodo hijo en la posición 1 del nodo SmartArt accedido usando el método GetNodeByPosition().
- Acceder y mostrar información como la posición del nodo hijo, su nivel y texto.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Instanciar la presentación
with slides.Presentation() as pres:
    # Acceder a la primera diapositiva
    slide = pres.slides[0]
    # Añadir la forma SmartArt en la primera diapositiva
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Acceder al nodo SmartArt en el índice 0
    node = smart.all_nodes[0]
    # Acceder al nodo hijo en la posición 1 del nodo padre
    position = 1
    chNode = node.child_nodes[position] 
    # Imprimir los parámetros del nodo hijo SmartArt
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))
```


## **Eliminar nodo SmartArt**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt.

- Crear una instancia de la clase `Presentation` y cargar la presentación con una forma SmartArt.
- Obtener la referencia de la primera diapositiva usando su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verificar si la forma es del tipo SmartArt y convertir la forma seleccionada a SmartArt si lo es.
- Verificar si el SmartArt tiene más de 0 nodos.
- Seleccionar el nodo SmartArt que se eliminará.
- Ahora, eliminar el nodo seleccionado usando el método RemoveNode() * Guardar la presentación.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Cargar la presentación deseada
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Recorrer todas las formas dentro de la primera diapositiva
    for shape in pres.slides[0].shapes:
        # Verificar si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Convertir la forma a SmartArtEx
            if len(shape.all_nodes) > 0:
                # Acceder al nodo SmartArt en el índice 0
                node = shape.all_nodes[0]

                # Eliminar el nodo seleccionado
                shape.all_nodes.remove_node(node)

    # Guardar la presentación
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Eliminar nodo SmartArt en posición específica**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt en una posición particular.

- Crear una instancia de la clase `Presentation` y cargar la presentación con una forma SmartArt.
- Obtener la referencia de la primera diapositiva usando su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verificar si la forma es del tipo SmartArt y convertir la forma seleccionada a SmartArt si lo es.
- Seleccionar el nodo de forma SmartArt en el índice 0.
- Ahora, verificar si el nodo SmartArt seleccionado tiene más de 2 nodos hijos.
- Ahora, eliminar el nodo en la posición 1 usando el método RemoveNodeByPosition().
- Guardar la presentación.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Cargar la presentación deseada
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Recorrer todas las formas dentro de la primera diapositiva
    for shape in pres.slides[0].shapes:
        # Verificar si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Convertir la forma a SmartArt
            if len(shape.all_nodes) > 0:
                # Acceder al nodo SmartArt en el índice 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Eliminar el nodo hijo en la posición 1
                    node.child_nodes.remove_node(1)

    # Guardar la presentación
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer posición personalizada para el nodo hijo en SmartArt**
Ahora Aspose.Slides for Python via .NET admite la configuración de las propiedades X y Y de SmartArtShape. El fragmento de código a continuación muestra cómo establecer una posición, tamaño y rotación personalizados para SmartArtShape; también tenga en cuenta que agregar nuevos nodos provoca un recálculo de las posiciones y tamaños de todos los nodos.
```py
# Cargar la presentación deseada
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# Mover la forma SmartArt a una nueva posición
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# Cambiar los anchos de la forma SmartArt
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# Cambiar la altura de la forma SmartArt
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# Cambiar la rotación de la forma SmartArt
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```


## **Verificar nodo asistente**
En el siguiente código de ejemplo investigaremos cómo identificar los nodos asistente en la colección de nodos SmartArt y cambiarlos.

- Crear una instancia de la clase PresentationEx y cargar la presentación con una forma SmartArt.
- Obtener la referencia de la segunda diapositiva usando su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verificar si la forma es del tipo SmartArt y convertir la forma seleccionada a SmartArtEx si lo es.
- Recorrer todos los nodos dentro de la forma SmartArt y verificar si son nodos asistente.
- Cambiar el estado del nodo asistente a nodo normal.
- Guardar la presentación.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Crear una instancia de presentación
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Recorrer todas las formas dentro de la primera diapositiva
    for shape in pres.slides[0].shapes:
        # Verificar si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Recorrer todos los nodos de la forma SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Verificar si el nodo es Asistente
                if node.is_assistant:
                    # Establecer el nodo Asistente a False y convertirlo en nodo normal
                    node.is_assistant = False
    # Guardar la presentación
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer formato de relleno del nodo**
Aspose.Slides for Python via .NET permite agregar formas SmartArt personalizadas y establecer sus formatos de relleno. Este artículo explica cómo crear y acceder a formas SmartArt y establecer su formato de relleno usando Aspose.Slides for Python via .NET.

- Crear una instancia de la clase `Presentation`.
- Obtener la referencia de una diapositiva usando su índice.
- Agregar una forma SmartArt estableciendo su LayoutType.
- Establecer el FillFormat para los nodos de la forma SmartArt.
- Guardar la presentación modificada como un archivo PPTX.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Accediendo a la diapositiva
    slide = presentation.slides[0]

    # Añadiendo forma SmartArt y nodos
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Estableciendo color de relleno del nodo
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Guardando la presentación
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Generar miniatura del nodo hijo SmartArt**
Los desarrolladores pueden generar una miniatura del nodo hijo de un SmartArt siguiendo los pasos a continuación:

1. Instanciar la clase `Presentation` que representa el archivo PPTX.
2. Agregar SmartArt.
3. Obtener la referencia de un nodo usando su índice.
4. Obtener la imagen en miniatura.
5. Guardar la imagen en miniatura en el formato de imagen deseado.

El ejemplo a continuación genera una miniatura del nodo hijo de SmartArt
```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Instanciar la clase Presentation que representa el archivo PPTX 
with slides.Presentation() as presentation: 
    # Añadir SmartArt 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Obtener la referencia de un nodo usando su índice  
    node = smart.nodes[1]

    # Obtener miniatura
    with node.shapes[0].get_image() as bmp:
        # guardar miniatura
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```


## **FAQ**

**¿Se admite la animación de SmartArt?**

Sí. SmartArt se trata como una forma regular, por lo que puede [aplicar animaciones estándar](/slides/es/python-net/shape-animation/) (entrada, salida, énfasis, rutas de movimiento) y ajustar el tiempo. También puede animar formas dentro de los nodos SmartArt cuando sea necesario.

**¿Cómo puedo localizar de manera fiable un SmartArt específico en una diapositiva si su ID interno es desconocido?**

Asigne y busque por [alternative text](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/). Establecer un AltText distintivo en el SmartArt le permite encontrarlo programáticamente sin depender de identificadores internos.

**¿Se conservará la apariencia de SmartArt al convertir la presentación a PDF?**

Sí. Aspose.Slides renderiza SmartArt con alta fidelidad visual durante la [PDF export](/slides/es/python-net/convert-powerpoint-to-pdf/), preservando el diseño, colores y efectos.

**¿Puedo extraer una imagen de todo el SmartArt (para vistas previas o informes)?**

Sí. Puede renderizar una forma SmartArt a [raster formats](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/get_image/) o a [SVG](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/write_as_svg/) para salida vectorial escalable, lo que la hace adecuada para miniaturas, informes o uso web.