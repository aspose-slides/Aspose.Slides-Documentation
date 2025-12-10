---
title: Administrar nodos de forma SmartArt en presentaciones usando C++
linktitle: Nodo de forma SmartArt
type: docs
weight: 30
url: /es/cpp/manage-smartart-shape-node/
keywords:
- nodo SmartArt
- nodo hijo
- agregar nodo
- posición del nodo
- acceso al nodo
- eliminar nodo
- posición personalizada
- nodo asistente
- formato de relleno
- renderizar nodo
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Administre los nodos de forma SmartArt en PPT y PPTX con Aspose.Slides para C++. Obtenga ejemplos de código claros y consejos para optimizar sus presentaciones."
---

## **Agregar un nodo SmartArt**
Aspose.Slides for C++ ha proporcionado la API más simple para gestionar las formas SmartArt de la manera más fácil. El siguiente código de ejemplo ayuda a agregar un nodo y un nodo hijo dentro de una forma SmartArt.

- Cree una instancia de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) clase y cargue la presentación con una forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta (typecast) la forma seleccionada a SmartArt si lo es.
- Agregue un nuevo nodo en la colección NodeCollection de la forma SmartArt y establezca el texto en TextFrame.
- Ahora, agregue un nodo hijo en el nodo SmartArt recién agregado y establezca el texto en TextFrame.
- Guarde la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **Agregar un nodo SmartArt en una posición específica**
En el siguiente código de ejemplo explicamos cómo agregar los nodos hijos pertenecientes a los respectivos nodos de la forma SmartArt en una posición determinada.

- Cree una instancia de la clase `Presentation`.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Agregue una forma SmartArt de tipo StackedList en la diapositiva accedida.
- Acceda al primer nodo en la forma SmartArt agregada.
- Ahora, agregue el nodo hijo para el nodo seleccionado en la posición 2 y establezca su texto.
- Guarde la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **Acceder a un nodo SmartArt**
El siguiente código de ejemplo ayuda a acceder a los nodos dentro de una forma SmartArt. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt ya que es de solo lectura y se establece solo cuando se agrega la forma SmartArt.

- Cree una instancia de la clase `Presentation` y cargue la presentación con una forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta la forma seleccionada a SmartArt si lo es.
- Recorra todos los nodos dentro de la forma SmartArt.
- Acceda y muestre información como la posición del nodo SmartArt, nivel y texto.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **Acceder a un nodo hijo SmartArt**
El siguiente código de ejemplo ayuda a acceder a los nodos hijos pertenecientes a los respectivos nodos de la forma SmartArt.

- Cree una instancia de la clase PresentationEx y cargue la presentación con una forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta la forma seleccionada a SmartArtEx si lo es.
- Recorra todos los nodos dentro de la forma SmartArt.
- Para cada nodo de la forma SmartArt seleccionado, recorra todos los nodos hijos dentro del nodo particular.
- Acceda y muestre información como la posición del nodo hijo, nivel y texto.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Acceder a un nodo hijo SmartArt en una posición específica**
En este ejemplo, aprenderemos a acceder a los nodos hijos en una posición determinada que pertenecen a los respectivos nodos de la forma SmartArt.

- Cree una instancia de la clase `Presentation`.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Agregue una forma SmartArt de tipo StackedList.
- Acceda a la forma SmartArt agregada.
- Acceda al nodo en el índice 0 de la forma SmartArt accedida.
- Ahora, acceda al nodo hijo en la posición 1 del nodo SmartArt accedido usando el método GetNodeByPosition().
- Acceda y muestre información como la posición del nodo hijo, nivel y texto.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **Eliminar un nodo SmartArt**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt.

- Cree una instancia de la clase `Presentation` y cargue la presentación con una forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta la forma seleccionada a SmartArt si lo es.
- Verifique si el SmartArt tiene más de 0 nodos.
- Seleccione el nodo SmartArt que será eliminado.
- Ahora, elimine el nodo seleccionado usando el método RemoveNode()* Guarde la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Eliminar un nodo SmartArt en una posición específica**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt en una posición determinada.

- Cree una instancia de la clase `Presentation` y cargue la presentación con una forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta la forma seleccionada a SmartArt si lo es.
- Seleccione el nodo de la forma SmartArt en el índice 0.
- Ahora, verifique si el nodo SmartArt seleccionado tiene más de 2 nodos hijos.
- Ahora, elimine el nodo en la Posición 1 usando el método RemoveNodeByPosition().
- Guarde la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **Establecer una posición personalizada para un nodo hijo SmartArt**
Ahora Aspose.Slides admite la configuración de las propiedades X y Y de SmartArtShape. El fragmento de código a continuación muestra cómo establecer una posición, tamaño y rotación personalizados para SmartArtShape; también tenga en cuenta que agregar nuevos nodos provoca un recalculo de las posiciones y tamaños de todos los nodos.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **Verificar un nodo asistente**
En el siguiente código de ejemplo investigaremos cómo identificar nodos Asistente en la colección de nodos SmartArt y modificarlos.

- Cree una instancia de la clase PresentationEx y cargue la presentación con una forma SmartArt.
- Obtenga la referencia de la segunda diapositiva usando su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta la forma seleccionada a SmartArtEx si lo es.
- Recorrer todos los nodos dentro de la forma SmartArt y verifique si son nodos Asistente.
- Cambie el estado del nodo Asistente a nodo normal.
- Guarde la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Establecer el formato de relleno de un nodo**
Aspose.Slides for C++ permite agregar formas SmartArt personalizadas y establecer sus formatos de relleno. Este artículo explica cómo crear y acceder a formas SmartArt y establecer su formato de relleno usando Aspose.Slides for C++.

- Cree una instancia de la clase `Presentation`.
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue una forma SmartArt configurando su LayoutType.
- Establezca el FillFormat para los nodos de la forma SmartArt.
- Guarde la presentación modificada como un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **Generar una miniatura de un nodo hijo SmartArt**
Los desarrolladores pueden generar una miniatura del nodo hijo de un SmartArt siguiendo los pasos a continuación:

1. Instanciar la clase `Presentation` que representa el archivo PPTX.
2. Agregar SmartArt.
3. Obtener la referencia de un nodo usando su índice.
4. Obtener la imagen miniatura.
5. Guardar la imagen miniatura en el formato de imagen deseado.

El ejemplo a continuación genera una miniatura del nodo hijo de SmartArt
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


## **FAQ**

**¿Se admite la animación de SmartArt?**

Sí. SmartArt se trata como una forma normal, por lo que puede [aplicar animaciones estándar](/slides/es/cpp/shape-animation/) (entrada, salida, énfasis, trayectorias de movimiento) y ajustar el tiempo. También puede animar las formas dentro de los nodos SmartArt cuando sea necesario.

**¿Cómo puedo localizar de manera fiable un SmartArt específico en una diapositiva si su ID interno es desconocido?**

Asigne y busque por [texto alternativo](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/). Configurar un AltText distintivo en el SmartArt le permite encontrarlo programáticamente sin depender de los identificadores internos.

**¿Se preservará la apariencia de SmartArt al convertir la presentación a PDF?**

Sí. Aspose.Slides renderiza SmartArt con alta fidelidad visual durante la [exportación a PDF](/slides/es/cpp/convert-powerpoint-to-pdf/), preservando el diseño, los colores y los efectos.

**¿Puedo extraer una imagen de todo el SmartArt (para vistas previas o informes)?**

Sí. Puede renderizar una forma SmartArt a [formatos rasterizados](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) o a [SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) para obtener una salida vectorial escalable, lo que la hace adecuada para miniaturas, informes o uso web.