---
title: Clonar diapositivas de presentación en C++
linktitle: Clonar diapositivas
type: docs
weight: 40
url: /es/cpp/clone-slides/
keywords:
- clonar diapositiva
- copiar diapositiva
- guardar diapositiva
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Duplica rápidamente diapositivas de PowerPoint con Aspose.Slides para C++. Sigue nuestros claros ejemplos de código para automatizar la creación de PPT en segundos y eliminar el trabajo manual."
---

## **Clonar diapositivas en una presentación**
La clonación es el proceso de crear una copia exacta o réplica de algo. Aspose.Slides for C++ también permite crear una copia o clon de cualquier diapositiva y luego insertar esa diapositiva clonada en la presentación actual o en cualquier otra presentación abierta. El proceso de clonación de diapositivas crea una nueva diapositiva que los desarrolladores pueden modificar sin cambiar la diapositiva original. Existen varias formas posibles de clonar una diapositiva:

- Clonar al final dentro de una presentación.
- Clonar en otra posición dentro de la presentación.
- Clonar al final en otra presentación.
- Clonar en otra posición en otra presentación.
- Clonar en una posición específica en otra presentación.

En Aspose.Slides for C++, (una colección de [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) objetos) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) proporciona los métodos [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) y [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) para realizar los tipos de clonación de diapositivas descritos anteriormente.

## **Clonar una diapositiva al final de una presentación**
Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación al final de las diapositivas existentes, use el método [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) según los pasos que se enumeran a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) haciendo referencia a la colección Slides expuesta por el objeto [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Llame al método [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) y pase la diapositiva que se va a clonar como parámetro al método [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/).
1. Guarde el archivo de presentación modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (ubicada en la primera posición – índice cero – de la presentación) al final de la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Clonar una diapositiva a otra posición dentro de una presentación**
 in Presentation**
Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una posición diferente, use el método [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/):

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Instancie la clase haciendo referencia a la colección **Slides** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Llame al método [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) y pase la diapositiva que se va a clonar junto con el índice para la nueva posición como parámetro al método [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/).
1. Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (ubicada en el índice cero – posición 1 – de la presentación) al índice 1 – Posición 2 – de la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Clonar una diapositiva al final de otra presentación**
Si necesita clonar una diapositiva de una presentación y usarla en otra presentación, al final de las diapositivas existentes:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) que contiene la presentación de la cual se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) que contiene la presentación de destino a la que se añadirá la diapositiva.
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) haciendo referencia a la colección **Slides** expuesta por el objeto Presentation de la presentación de destino.
1. Llame al método [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) y pase la diapositiva de la presentación fuente como parámetro al método [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/).
1. Guarde el archivo de presentación de destino modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (del primer índice de la presentación fuente) al final de la presentación de destino.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clonar una diapositiva a otra posición en otra presentación**
Si necesita clonar una diapositiva de una presentación y usarla en otra presentación, en una posición específica:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) que contiene la presentación de origen de la cual se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) que contiene la presentación a la que se añadirá la diapositiva.
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) haciendo referencia a la colección Slides expuesta por el objeto Presentation de la presentación de destino.
1. Llame al método [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) y pase la diapositiva de la presentación fuente junto con la posición deseada como parámetro al método [InsertClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/insertclone/).
1. Guarde el archivo de presentación de destino modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva (del índice cero de la presentación fuente) al índice 1 (posición 2) de la presentación de destino.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clonar una diapositiva en una posición específica en otra presentación**
Si necesita clonar una diapositiva con diapositiva maestra de una presentación y usarla en otra presentación, primero debe clonar la diapositiva maestra deseada de la presentación origen a la presentación destino. Luego debe usar esa diapositiva maestra para clonar la diapositiva con maestra. El método **AddClone(ISlide, IMasterSlide)** espera la diapositiva maestra de la presentación destino, no de la presentación origen. Para clonar la diapositiva con maestra, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) que contiene la presentación de origen de la cual se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) que contiene la presentación de destino a la que se clonará la diapositiva.
1. Acceda a la diapositiva que se va a clonar junto con la diapositiva maestra.
1. Instancie la clase [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/) haciendo referencia a la colección Masters expuesta por el objeto [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) de la presentación de destino.
1. Llame al método [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) expuesto por el objeto [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/) y pase la maestra del PPTX fuente que se va a clonar como parámetro al método [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/).
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) estableciendo la referencia a la colección Slides expuesta por el objeto [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) de la presentación de destino.
1. Llame al método [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) y pase la diapositiva de la presentación fuente que se va a clonar y la diapositiva maestra como parámetro al método [AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/).
1. Guarde el archivo de presentación de destino modificado.

En el ejemplo que se muestra a continuación, hemos clonado una diapositiva con maestra (ubicada en el índice cero de la presentación origen) al final de la presentación de destino usando la maestra de la diapositiva origen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Clonar una diapositiva al final de una sección especificada**
Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una sección diferente, use el método [**AddClone()**](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) expuesto por la interfaz [**ISlideCollection**](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/). Aspose.Slides for C++ permite clonar una diapositiva de la primera sección y luego insertar esa diapositiva clonada en la segunda sección de la misma presentación.

El siguiente fragmento de código muestra cómo clonar una diapositiva e insertarla en una sección especificada.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **FAQ**

**¿Se clonan las notas del orador y los comentarios de revisión?**

Sí. La página de notas y los comentarios de revisión se incluyen en el clon. Si no los desea, [eliminarlos](/slides/es/cpp/presentation-notes/) después de la inserción.

**¿Cómo se manejan los gráficos y sus fuentes de datos?**

El objeto del gráfico, su formato y los datos incrustados se copian. Si el gráfico estaba vinculado a una fuente externa (p. ej., un libro de trabajo incrustado como OLE), ese vínculo se conserva como un [objeto OLE](/slides/es/cpp/manage-ole/). Después de moverlo entre archivos, verifique la disponibilidad de los datos y el comportamiento de actualización.

**¿Puedo controlar la posición de inserción y las secciones del clon?**

Sí. Puede insertar el clon en un índice de diapositiva específico y colocarlo en una [sección](/slides/es/cpp/slide-section/) elegida. Si la sección de destino no existe, créela primero y luego mueva la diapositiva a ella.