---
title: Gestionar el nodo de forma SmartArt
type: docs
weight: 30
url: /python-net/manage-smartart-shape-node/
keywords: "nodo SmartArt, nodo hijo de SmartArt, presentación de PowerPoint, Python, Aspose.Slides para Python via .NET"
description: "Nodo inteligente y nodo hijo en presentaciones de PowerPoint en Python"
---


## **Agregar nodo SmartArt**
Aspose.Slides para Python via .NET ha proporcionado la API más simple para gestionar las formas SmartArt de la manera más fácil. El siguiente código de ejemplo ayudará a agregar un nodo y un nodo hijo dentro de la forma SmartArt.

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y carga la presentación con la forma SmartArt.
- Obtén la referencia de la primera diapositiva utilizando su índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es del tipo SmartArt y convierte la forma seleccionada a SmartArt si es SmartArt.
- Agrega un nuevo nodo en la colección de nodos de la forma SmartArt y establece el texto en el TextFrame.
- Ahora, agrega un nodo hijo en el nuevo nodo SmartArt agregado y establece el texto en el TextFrame.
- Guarda la presentación.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Cargar la presentación deseada
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Recorre cada forma dentro de la primera diapositiva
    for shape in pres.slides[0].shapes:

        # Verifica si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Agregar un nuevo nodo SmartArt
            node1 = shape.all_nodes.add_node()
            # Agregar texto
            node1.text_frame.text = "Prueba"

            # Agregar un nuevo nodo hijo en el nodo padre. Se agregará al final de la colección
            new_node = node1.child_nodes.add_node()

            # Agregar texto
            new_node.text_frame.text = "Nuevo nodo agregado"

    # Guardar presentación
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Agregar nodo SmartArt en una posición específica**
En el siguiente código de ejemplo hemos explicado cómo agregar los nodos hijos pertenecientes a los nodos respectivos de la forma SmartArt en una posición particular.

- Crea una instancia de la clase `Presentation`.
- Obtén la referencia de la primera diapositiva utilizando su índice.
- Agrega una forma SmartArt de tipo StackedList en la diapositiva accedida.
- Accede al primer nodo en la forma SmartArt agregada.
- Ahora, agrega el nodo hijo para el nodo seleccionado en la posición 2 y establece su texto.
- Guarda la presentación.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Crear una instancia de presentación
with slides.Presentation() as pres:
    # Acceder a la diapositiva de presentación
    slide = pres.slides[0]

    # Agregar forma Smart Art
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Accediendo al nodo SmartArt en el índice 0
    node = smart.all_nodes[0]

    # Agregar nuevo nodo hijo en la posición 2 en el nodo padre
    chNode = node.child_nodes.add_node_by_position(2)

    # Agregar texto
    chNode.text_frame.text = "Texto de ejemplo agregado"

    # guardar presentación
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Acceder al nodo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos dentro de la forma SmartArt. Ten en cuenta que no puedes cambiar el LayoutType del SmartArt ya que es de solo lectura y se establece solo cuando se agrega la forma SmartArt.

- Crea una instancia de la clase `Presentation` y carga la presentación con la forma SmartArt.

- Obtén la referencia de la primera diapositiva utilizando su índice.

- Recorre cada forma dentro de la primera diapositiva.

- Verifica si la forma es del tipo SmartArt y convierte la forma seleccionada a SmartArt si es SmartArt.

- Recorre todos los nodos dentro de la forma SmartArt.

- Accede y muestra información como la posición del nodo SmartArt, el nivel y el texto.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Cargar la presentación deseada
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Recorre cada forma dentro de la primera diapositiva
    for shape in pres.slides[0].shapes:
        # Verifica si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Recorre todos los nodos dentro de SmartArt
            for i in range(len(shape.all_nodes)):
                # Accediendo al nodo SmartArt en el índice i
                node = shape.all_nodes[i]

                # Imprimiendo los parámetros del nodo SmartArt
                print("i = {0}, texto = {1},  nivel = {2}, posición = {3}".format(i, node.text_frame.text, node.level, node.position))
  ```

  


## **Acceder al nodo hijo de SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos hijos pertenecientes a los nodos respectivos de la forma SmartArt.

- Crea una instancia de la clase PresentationEx y carga la presentación con la forma SmartArt.
- Obtén la referencia de la primera diapositiva utilizando su índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es del tipo SmartArt y convierte la forma seleccionada a SmartArtEx si es SmartArt.
- Recorre todos los nodos dentro de la forma SmartArt.
- Para cada nodo de forma SmartArt seleccionado, recorre todos los nodos hijos dentro de ese nodo particular.
- Accede y muestra información como la posición del nodo hijo, el nivel y el texto.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Cargar la presentación deseada
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Recorre cada forma dentro de la primera diapositiva
    for shape in pres.slides[0].shapes:
        # Verifica si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Recorre todos los nodos dentro de SmartArt
            for node0 in shape.all_nodes:
                # Recorriendo los nodos hijos
                for j in range(len(node0.child_nodes)):
                    # Accediendo al nodo hijo en el nodo SmartArt
                    node = node0.child_nodes[j]

                    # Imprimiendo los parámetros del nodo hijo de SmartArt
                    print("j = {0}, texto = {1},  nivel = {2}, posición = {3}".format(j, node.text_frame.text, node.level, node.position))

```



## **Acceder al nodo hijo de SmartArt en una posición específica**
En este ejemplo, aprenderemos a acceder a los nodos hijos en una posición particular perteneciente a nodos respectivos de la forma SmartArt.

- Crea una instancia de la clase `Presentation`.
- Obtén la referencia de la primera diapositiva utilizando su índice.
- Agrega una forma SmartArt de tipo StackedList.
- Accede a la forma SmartArt agregada.
- Accede al nodo en el índice 0 para la forma SmartArt accedida.
- Ahora, accede al nodo hijo en la posición 1 para el nodo SmartArt accedido utilizando el método GetNodeByPosition().
- Accede y muestra información como la posición del nodo hijo, el nivel y el texto.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Instanciar la presentación
with slides.Presentation() as pres:
    # Acceder a la primera diapositiva
    slide = pres.slides[0]
    # Agregar la forma SmartArt en la primera diapositiva
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Accediendo al nodo SmartArt en el índice 0
    node = smart.all_nodes[0]
    # Accediendo al nodo hijo en la posición 1 en el nodo padre
    position = 1
    chNode = node.child_nodes[position] 
    # Imprimiendo los parámetros del nodo hijo de SmartArt
    print("j = {0}, texto = {1},  nivel = {2}, posición = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```



## **Eliminar nodo SmartArt**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt.

- Crea una instancia de la clase `Presentation` y carga la presentación con la forma SmartArt.
- Obtén la referencia de la primera diapositiva utilizando su índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es del tipo SmartArt y convierte la forma seleccionada a SmartArt si es SmartArt.
- Verifica si el SmartArt tiene más de 0 nodos.
- Selecciona el nodo SmartArt que debe eliminarse.
- Ahora, elimina el nodo seleccionado utilizando el método RemoveNode(). Guarda la presentación.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Cargar la presentación deseada
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Recorre cada forma dentro de la primera diapositiva
    for shape in pres.slides[0].shapes:
        # Verifica si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Convierte la forma a SmartArtEx
            if len(shape.all_nodes) > 0:
                # Accediendo al nodo SmartArt en el índice 0
                node = shape.all_nodes[0]

                # Eliminando el nodo seleccionado
                shape.all_nodes.remove_node(node)

    # guardar presentación
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Eliminar nodo SmartArt en una posición específica**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt en una posición particular.

- Crea una instancia de la clase `Presentation` y carga la presentación con la forma SmartArt.
- Obtén la referencia de la primera diapositiva utilizando su índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es del tipo SmartArt y convierte la forma seleccionada a SmartArt si es SmartArt.
- Selecciona el nodo de forma SmartArt en el índice 0.
- Ahora, verifica si el nodo SmartArt seleccionado tiene más de 2 nodos hijos.
- Ahora, elimina el nodo en la posición 1 utilizando el método RemoveNodeByPosition().
- Guarda la presentación.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Cargar la presentación deseada
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Recorre cada forma dentro de la primera diapositiva
    for shape in pres.slides[0].shapes:
        # Verifica si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Convierte la forma a SmartArt
            if len(shape.all_nodes) > 0:
                # Accediendo al nodo SmartArt en el índice 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Eliminando el nodo hijo en la posición 1
                    node.child_nodes.remove_node(1)

    # guardar presentación
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Establecer posición personalizada para un nodo hijo en SmartArt**
Ahora Aspose.Slides para Python via .NET admite el establecimiento de las propiedades X e Y de SmartArtShape. El fragmento de código a continuación muestra cómo establecer la posición personalizada de SmartArtShape, el tamaño y la rotación. También ten en cuenta que agregar nuevos nodos provoca un recálculo de las posiciones y tamaños de todos los nodos.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

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
En el siguiente código de ejemplo investigaremos cómo identificar nodos asistentes en la colección de nodos SmartArt y cambiarlos.

- Crea una instancia de la clase PresentationEx y carga la presentación con la forma SmartArt.
- Obtén la referencia de la segunda diapositiva usando su índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es del tipo SmartArt y convierte la forma seleccionada a SmartArtEx si es SmartArt.
- Recorre todos los nodos dentro de la forma SmartArt y verifica si son nodos asistentes.
- Cambia el estado del nodo asistente a nodo normal.
- Guarda la presentación.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Crear una instancia de presentación
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Recorre cada forma dentro de la primera diapositiva
    for shape in pres.slides[0].shapes:
        # Verifica si la forma es del tipo SmartArt
        if type(shape) is art.SmartArt:
            # Recorriendo todos los nodos de la forma SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Verifica si el nodo es un nodo asistente
                if node.is_assistant:
                    # Estableciendo el nodo asistente a falso y convirtiéndolo en un nodo normal
                    node.is_assistant = False
    # guardar presentación
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Establecer formato de relleno del nodo**
Aspose.Slides para Python via .NET hace posible agregar formas SmartArt personalizadas y establecer sus formatos de relleno. Este artículo explica cómo crear y acceder a las formas SmartArt y establecer su formato de relleno usando Aspose.Slides para Python via .NET.

Sigue los pasos a continuación:

- Crea una instancia de la clase `Presentation`.
- Obtén la referencia de una diapositiva usando su índice.
- Agrega una forma SmartArt estableciendo su LayoutType.
- Establece el FillFormat para los nodos de la forma SmartArt.
- Escribe la presentación modificada como un archivo PPTX.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Accediendo a la diapositiva
    slide = presentation.slides[0]

    # Agregando forma SmartArt y nodos
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Algún texto"

    # Estableciendo el color de relleno del nodo
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Guardando presentación
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Generar miniatura del nodo hijo SmartArt**
Los desarrolladores pueden generar una miniatura del nodo hijo de un SmartArt siguiendo los pasos a continuación:

1. Instanciar la clase `Presentation` que representa el archivo PPTX.
1. Agregar SmartArt.
1. Obtener la referencia de un nodo utilizando su índice.
1. Obtener la imagen en miniatura.
1. Guardar la imagen en miniatura en cualquier formato de imagen deseado.

El siguiente ejemplo genera una miniatura del nodo hijo de SmartArt

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Instanciar la clase Presentation que representa el archivo PPTX 
with slides.Presentation() as presentation: 
    # Agregar SmartArt 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Obtener la referencia de un nodo utilizando su índice  
    node = smart.nodes[1]

    # Obtener miniatura
    with node.shapes[0].get_image() as bmp:
        # guardar miniatura
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```