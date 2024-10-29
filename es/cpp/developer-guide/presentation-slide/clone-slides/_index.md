---
title: Clonar Diapositivas
type: docs
weight: 40
url: /es/cpp/clone-slides/
---


## **Clonar Diapositiva en Presentación**
Clonar es el proceso de hacer una copia exacta o réplica de algo. Aspose.Slides para C++ también hace posible hacer una copia o clon de cualquier diapositiva y luego insertar esa diapositiva clonada en la presentación actual o en cualquier otra presentación abierta. El proceso de clonación de diapositivas crea una nueva diapositiva que puede ser modificada por los desarrolladores sin cambiar la diapositiva original. Hay varias formas posibles de clonar una diapositiva:

- Clonar al final dentro de una presentación.
- Clonar en otra posición dentro de la presentación.
- Clonar al final en otra presentación.
- Clonar en otra posición en otra presentación.
- Clonar en una posición específica en otra presentación.

En Aspose.Slides para C++, (una colección de [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) objetos) expuestos por el [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) objeto proporciona los [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) y [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) métodos para realizar los tipos de clonación de diapositivas mencionados anteriormente.

## **Clonar al Final Dentro de la Presentación**
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación al final de las diapositivas existentes, utiliza el [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) método de acuerdo a los pasos que se enumeran a continuación:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
1. Instancia la [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) clase haciendo referencia a la colección de Diapositivas expuesta por el [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) objeto.
1. Llama al [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) método expuesto por el [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) objeto y pasa la diapositiva a clonar como parámetro al [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) método.
1. Escribe el archivo de presentación modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (ubicada en la primera posición - índice cero - de la presentación) al final de la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}


## **Clonar en Otra Posición en la Presentación**
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una posición diferente, utiliza el [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) método:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
1. Instancia la clase haciendo referencia a la colección de **Diapositivas** expuesta por el [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) objeto.
1. Llama al [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) método expuesto por el [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) objeto y pasa la diapositiva a clonar junto con el índice para la nueva posición como parámetro al [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) método.
1. Escribe la presentación modificada como un archivo PPTX.

En el ejemplo dado a continuación, hemos clonado una diapositiva (ubicada en el índice cero - posición 1 - de la presentación) al índice 1 - Posición 2 - de la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Clonar Diapositiva al Final en Otra Presentación**
Si necesitas clonar una diapositiva de una presentación y usarla en otro archivo de presentación, al final de las diapositivas existentes:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase que contenga la presentación de la cual se clonará la diapositiva.
1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase que contenga la presentación de destino a la cual se añadirá la diapositiva.
1. Instancia la [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) clase haciendo referencia a la colección de **Diapositivas** expuesta por el objeto Presentation de la presentación de destino.
1. Llama al [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) método expuesto por el [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) objeto y pasa la diapositiva de la presentación fuente como parámetro al [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) método.
1. Escribe el archivo de presentación de destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (de la primera posición de la presentación fuente) al final de la presentación de destino.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clonar Diapositiva a Otra Posición en Otra Presentación**
Si necesitas clonar una diapositiva de una presentación y usarla en otro archivo de presentación, en una posición específica:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase que contenga la presentación fuente de la cual se clonará la diapositiva.
1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase que contenga la presentación a la cual se añadirá la diapositiva.
1. Instancia la [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) clase haciendo referencia a la colección de Diapositivas expuesta por el objeto Presentation de la presentación de destino.
1. Llama al [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) método expuesto por el [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) objeto y pasa la diapositiva de la presentación fuente junto con la posición deseada como parámetro al [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) método.
1. Escribe el archivo de presentación de destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (del índice cero de la presentación fuente) al índice 1 (posición 2) de la presentación de destino.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}
## **Clonar Diapositiva en una Posición Específica en Otra Presentación**
Si necesitas clonar una diapositiva con una diapositiva maestra de una presentación y usarla en otra presentación, primero necesitas clonar la diapositiva maestra deseada de la presentación de origen a la presentación de destino. Luego necesitas usar esa diapositiva maestra para clonar la diapositiva con la diapositiva maestra. El **AddClone(ISlide, IMasterSlide)** espera una diapositiva maestra de la presentación de destino en lugar de la presentación de origen. Para clonar la diapositiva con la maestra, sigue los pasos a continuación:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase que contenga la presentación de origen de la cual se clonará la diapositiva.
1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase que contenga la presentación de destino a la cual se clonará la diapositiva.
1. Accede a la diapositiva que se va a clonar junto con la diapositiva maestra.
1. Instancia la [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection) clase haciendo referencia a la colección de Maestras expuesta por el [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) objeto de la presentación de destino.
1. Llama al [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) método expuesto por el [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection) objeto y pasa la maestra de la fuente PPTX que se va a clonar como parámetro al [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) método.
1. Instancia la [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) clase configurando la referencia a la colección de Diapositivas expuesta por el [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) objeto de la presentación de destino.
1. Llama al [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) método expuesto por el [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) objeto y pasa la diapositiva de la presentación fuente que se va a clonar y la diapositiva maestra como parámetro al [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) método.
1. Escribe el archivo de presentación de destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva con maestra (ubicada en el índice cero de la presentación fuente) al final de la presentación de destino utilizando la maestra de la diapositiva fuente.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}
## **Clonar Diapositiva en Sección Especificada**
Si deseas clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una sección diferente, entonces utiliza el [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a46981dac8b18355531a04a70c70c444b) método expuesto por la interfaz [**ISlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection). Aspose.Slides para C++ hace posible clonar una diapositiva de la primera sección y luego insertar esa diapositiva clonada en la segunda sección de la misma presentación.

El siguiente fragmento de código te muestra cómo clonar una diapositiva e insertar la diapositiva clonada en una sección especificada.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}