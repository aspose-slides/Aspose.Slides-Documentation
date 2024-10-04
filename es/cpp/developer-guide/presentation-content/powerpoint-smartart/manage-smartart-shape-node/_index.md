---
title: Administrar Nodo de Forma SmartArt
type: docs
weight: 30
url: /cpp/manage-smartart-shape-node/
keywords:
- SmartArt
- nodo de SmartArt
- nodo hijo de SmartArt
- PowerPoint
- presentación
- C++
- Aspose.Slides para C++
description: "Administra nodos SmartArt y nodos hijo en presentaciones de PowerPoint en C++"
---



## **Agregar Nodo SmartArt**
Aspose.Slides para C++ ha proporcionado la API más simple para gestionar las formas SmartArt de la manera más sencilla. El siguiente código de ejemplo ayudará a agregar un nodo y un nodo hijo dentro de la forma SmartArt.

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) y carga la presentación con la Forma SmartArt.
- Obtén la referencia de la primera diapositiva utilizando su Índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es de tipo SmartArt y convierte el tipo de forma seleccionada a SmartArt si lo es.
- Agrega un nuevo Nodo en la colección de nodos de la forma SmartArt y establece el texto en el TextFrame.
- Ahora, agrega un Nodo Hijo en el Nodo SmartArt recién agregado y establece el texto en el TextFrame.
- Guarda la Presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **Agregar Nodo SmartArt en una Posición Específica**
En el siguiente código de ejemplo explicamos cómo agregar los nodos hijos pertenecientes a los nodos respectivos de la forma SmartArt en una posición particular.

- Crea una instancia de la clase `Presentation`.
- Obtén la referencia de la primera diapositiva utilizando su Índice.
- Agrega una forma SmartArt de tipo StackedList en la diapositiva accedida.
- Accede al primer nodo en la forma SmartArt agregada.
- Ahora, agrega el Nodo Hijo para el Nodo seleccionado en la posición 2 y establece su texto.
- Guarda la Presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}


## **Acceder al Nodo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos dentro de la forma SmartArt. Ten en cuenta que no puedes cambiar el LayoutType del SmartArt ya que es de solo lectura y se establece solo cuando se agrega la forma SmartArt.

- Crea una instancia de la clase `Presentation` y carga la presentación con la Forma SmartArt.
- Obtén la referencia de la primera diapositiva utilizando su Índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es de tipo SmartArt y convierte el tipo de forma seleccionada a SmartArt si lo es.
- Recorre todos los Nodos dentro de la Forma SmartArt.
- Accede y muestra información como la posición del Nodo SmartArt, el nivel y el Texto.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **Acceder al Nodo Hijo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos hijo pertenecientes a los nodos respectivos de la forma SmartArt.

- Crea una instancia de la clase PresentationEx y carga la presentación con la Forma SmartArt.
- Obtén la referencia de la primera diapositiva utilizando su Índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es de tipo SmartArt y convierte el tipo de forma seleccionada a SmartArtEx si lo es.
- Recorre todos los Nodos dentro de la Forma SmartArt.
- Para cada Nodo SmartArt seleccionado, recorre todos los Nodos Hijos dentro del nodo particular.
- Accede y muestra información como la posición del Nodo Hijo, el nivel y el Texto.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Acceder al Nodo Hijo SmartArt en una Posición Específica**
En este ejemplo, aprenderemos a acceder a los nodos hijos en una posición particular pertenecientes a los nodos respectivos de la forma SmartArt.

- Crea una instancia de la clase `Presentation`.
- Obtén la referencia de la primera diapositiva utilizando su Índice.
- Agrega una forma SmartArt de tipo StackedList.
- Accede a la forma SmartArt agregada.
- Accede al nodo en el índice 0 para la forma SmartArt accedida.
- Ahora, accede al Nodo Hijo en la posición 1 para el nodo SmartArt accedido utilizando el método GetNodeByPosition().
- Accede y muestra información como la posición del Nodo Hijo, el nivel y el Texto.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **Eliminar Nodo SmartArt**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt.

- Crea una instancia de la clase `Presentation` y carga la presentación con la Forma SmartArt.
- Obtén la referencia de la primera diapositiva utilizando su Índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es de tipo SmartArt y convierte el tipo de forma seleccionada a SmartArt si lo es.
- Verifica si el SmartArt tiene más de 0 nodos.
- Selecciona el nodo SmartArt que se va a eliminar.
- Ahora, elimina el nodo seleccionado utilizando el método RemoveNode() * Guarda la Presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Eliminar Nodo SmartArt en una Posición Específica**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt en una posición particular.

- Crea una instancia de la clase `Presentation` y carga la presentación con la Forma SmartArt.
- Obtén la referencia de la primera diapositiva utilizando su Índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es de tipo SmartArt y convierte el tipo de forma seleccionada a SmartArt si lo es.
- Selecciona el nodo de la forma SmartArt en el índice 0.
- Ahora, verifica si el nodo SmartArt seleccionado tiene más de 2 nodos hijos.
- Ahora, elimina el nodo en la Posición 1 utilizando el método RemoveNodeByPosition().
- Guarda la Presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}


## **Establecer Posición Personalizada para el Nodo Hijo SmartArt**
Ahora Aspose.Slides para .NET admite establecer las propiedades X y Y de SmartArtShape. El fragmento de código a continuación muestra cómo establecer la posición, el tamaño y la rotación personalizadas de SmartArtShape; también ten en cuenta que agregar nuevos nodos provoca un recalculo de las posiciones y tamaños de todos los nodos.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}


## **Comprobar Nodo Asistente**
En el siguiente código de ejemplo investigaremos cómo identificar los Nodos Asistentes en la colección de nodos SmartArt y cambiarlos.

- Crea una instancia de la clase PresentationEx y carga la presentación con la Forma SmartArt.
- Obtén la referencia de la segunda diapositiva utilizando su Índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es de tipo SmartArt y convierte el tipo de forma seleccionada a SmartArtEx si lo es.
- Recorre todos los nodos dentro de la forma SmartArt y verifica si son Nodos Asistentes.
- Cambia el estado del Nodo Asistente a nodo normal.
- Guarda la Presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Establecer Formato de Relleno del Nodo**
Aspose.Slides para C++ permite agregar formas SmartArt personalizadas y establecer sus formatos de relleno. Este artículo explica cómo crear y acceder a las formas SmartArt y establecer su formato de relleno utilizando Aspose.Slides para C++.

Por favor, sigue los pasos a continuación:

- Crea una instancia de la clase `Presentation`.
- Obtén la referencia de una diapositiva utilizando su índice.
- Agrega una forma SmartArt estableciendo su LayoutType.
- Establece el FillFormat para los nodos de la forma SmartArt.
- Escribe la presentación modificada como un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}


## **Generar Miniatura del Nodo Hijo SmartArt**
Los desarrolladores pueden generar una miniatura del nodo hijo de un SmartArt siguiendo los pasos a continuación:

1. Instancia la clase `Presentation` que representa el archivo PPTX.
1. Agrega SmartArt.
1. Obtén la referencia de un nodo utilizando su Índice.
1. Obtén la imagen de la miniatura.
1. Guarda la imagen de la miniatura en cualquier formato de imagen deseado.

El ejemplo a continuación genera una miniatura del nodo hijo SmartArt

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```