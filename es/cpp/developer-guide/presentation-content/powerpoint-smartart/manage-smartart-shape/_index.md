---
title: Administrar Forma de SmartArt
type: docs
weight: 20
url: /es/cpp/manage-smartart-shape/
---


## **Crear Forma de SmartArt**
Aspose.Slides para C++ ahora facilita agregar formas de SmartArt personalizadas en sus diapositivas desde cero. Aspose.Slides para C++ ha proporcionado la API más simple para crear formas de SmartArt de la manera más fácil. Para crear una forma de SmartArt en una diapositiva, por favor siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenga la referencia de una diapositiva utilizando su índice.
- Agregue una forma de SmartArt estableciendo su LayoutType.
- Escriba la presentación modificada como un archivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}


## **Acceder a la Forma de SmartArt en la Diapositiva**
El siguiente código se utilizará para acceder a las formas de SmartArt agregadas en la diapositiva de la presentación. En el código de ejemplo, recorreremos cada forma dentro de la diapositiva y verificaremos si es una forma de SmartArt. Si la forma es del tipo SmartArt, la convertiremos en una instancia de SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Acceder a la Forma de SmartArt con un Tipo de Diseño Particular**
El siguiente código de muestra ayudará a acceder a la forma de SmartArt con un LayoutType particular. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt ya que es de solo lectura y se establece solo cuando se agrega la forma de SmartArt.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma de SmartArt.
- Obtenga la referencia de la primera diapositiva utilizando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es del tipo SmartArt y convierta la forma seleccionada a SmartArt si es SmartArt.
- Verifique la forma de SmartArt con el LayoutType particular y realice lo que se requiere realizar posteriormente.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}


## **Cambiar el Estilo de la Forma de SmartArt**
El siguiente código de muestra ayudará a acceder a la forma de SmartArt con un LayoutType particular.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma de SmartArt.
- Obtenga la referencia de la primera diapositiva utilizando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es del tipo SmartArt y convierta la forma seleccionada a SmartArt si es SmartArt.
- Encuentre la forma de SmartArt con un estilo particular.
- Establezca el nuevo estilo para la forma de SmartArt.
- Guarde la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}


## **Cambiar el Estilo de Color de la Forma de SmartArt**
En este ejemplo, aprenderemos a cambiar el estilo de color para cualquier forma de SmartArt. En el siguiente código de muestra accederemos a la forma de SmartArt con un estilo de color particular y cambiaremos su estilo.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma de SmartArt.
- Obtenga la referencia de la primera diapositiva utilizando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es del tipo SmartArt y convierta la forma seleccionada a SmartArt si es SmartArt.
- Encuentre la forma de SmartArt con un estilo de color particular.
- Establezca el nuevo estilo de color para la forma de SmartArt.
- Guarde la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}