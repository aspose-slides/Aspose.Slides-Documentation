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
## **Introducción**

Clonar es el proceso de crear una copia exacta o réplica de algo. Aspose.Slides for C++ también permite crear una copia o clon de cualquier diapositiva y luego insertar esa diapositiva clonada en la presentación actual o en cualquier otra presentación abierta. El proceso de clonación de diapositivas crea una nueva diapositiva que los desarrolladores pueden modificar sin alterar la diapositiva original. Existen varias formas posibles de clonar una diapositiva:

- Clonar al final dentro de una presentación.
- Clonar en otra posición dentro de la presentación.
- Clonar al final en otra presentación.
- Clonar en otra posición en otra presentación.
- Clonar en una posición específica en otra presentación.

En Aspose.Slides for C++, (una colección de [ISlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/) objects) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) proporciona los métodos [AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) y [InsertClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/insertclone/) para realizar los tipos de clonación de diapositivas mencionados anteriormente.

## **Clonar una diapositiva al final de una presentación**
Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación al final de las diapositivas existentes, utilice el método [AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) según los pasos enumerados a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) .
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/) haciendo referencia a la colección Slides expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) .
1. Llame al método [AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/) y pase la diapositiva a clonar como parámetro al método [AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) .
1. Guarde el archivo de presentación modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (situada en la primera posición – índice cero – de la presentación) al final de la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **Clonar una diapositiva a otra posición dentro de una presentación**
Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una posición diferente, utilice el método [InsertClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/insertclone/) :

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) .
1. Instancie la clase haciendo referencia a la colección **Slides** expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) .
1. Llame al método [InsertClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/insertclone/) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/) y pase la diapositiva a clonar junto con el índice para la nueva posición como parámetro al método [InsertClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/insertclone/) .
1. Guarde la presentación modificada como archivo PPTX.

En el ejemplo dado a continuación, hemos clonado una diapositiva (situada en el índice cero – posición 1 – de la presentación) al índice 1 – Posición 2 – de la presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Clonar una diapositiva al final de otra presentación**
Si necesita clonar una diapositiva de una presentación y usarla en otro archivo de presentación, al final de las diapositivas existentes:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) que contenga la presentación de la que se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) que contenga la presentación de destino a la que se añadirá la diapositiva.
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/) haciendo referencia a la colección **Slides** expuesta por el objeto Presentation de la presentación de destino.
1. Llame al método [AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/) y pase la diapositiva de la presentación fuente como parámetro al método [AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) .
1. Guarde el archivo de presentación de destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (del primer índice de la presentación fuente) al final de la presentación de destino.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clonar una diapositiva a otra posición en otra presentación**
Si necesita clonar una diapositiva de una presentación y usarla en otro archivo de presentación, en una posición específica:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) que contenga la presentación fuente de la que se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) que contenga la presentación a la que se añadirá la diapositiva.
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/) haciendo referencia a la colección Slides expuesta por el objeto Presentation de la presentación de destino.
1. Llame al método [InsertClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/insertclone/) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/) y pase la diapositiva de la presentación fuente junto con la posición deseada como parámetro al método [InsertClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/insertclone/) .
1. Guarde el archivo de presentación de destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva (del índice cero de la presentación fuente) al índice 1 (posición 2) de la presentación de destino.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Clonar una diapositiva en una posición específica en otra presentación**
Si necesita clonar una diapositiva con diapositiva maestra de una presentación y usarla en otra presentación, primero debe clonar la diapositiva maestra deseada de la presentación fuente a la presentación de destino. Luego debe usar esa diapositiva maestra para clonar la diapositiva con maestra. El método **AddClone(ISlide, IMasterSlide)** espera la diapositiva maestra de la presentación de destino y no de la presentación fuente. Para clonar la diapositiva con maestra, siga los pasos siguientes:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) que contenga la presentación fuente de la que se clonará la diapositiva.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) que contenga la presentación de destino a la que se clonará la diapositiva.
1. Acceda a la diapositiva a clonar junto con la diapositiva maestra.
1. Instancie la clase [IMasterSlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslidecollection/) haciendo referencia a la colección Masters expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) de la presentación de destino.
1. Llame al método [AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) expuesto por el objeto [IMasterSlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslidecollection/) y pase la maestra del PPTX fuente que se va a clonar como parámetro al método [AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) .
1. Instancie la clase [ISlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/) estableciendo la referencia a la colección Slides expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) de la presentación de destino.
1. Llame al método [AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) expuesto por el objeto [ISlideCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/) y pase la diapositiva de la presentación fuente que se va a clonar y la diapositiva maestra como parámetros al método [AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) .
1. Guarde el archivo de presentación de destino modificado.

En el ejemplo dado a continuación, hemos clonado una diapositiva con maestra (situada en el índice cero de la presentación fuente) al final de la presentación de destino usando la maestra de la diapositiva fuente.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **Clonar una diapositiva al final de una sección especificada**
Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una sección diferente, utilice el método [**AddClone()**](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) expuesto por la interfaz [**ISlideCollection**](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/). Aspose.Slides for C++ permite clonar una diapositiva de la primera sección y luego insertar esa diapositiva clonada en la segunda sección de la misma presentación.

El siguiente fragmento de código muestra cómo clonar una diapositiva e insertar la diapositiva clonada en una sección especificada.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **Asegurar que el tamaño de la diapositiva coincida**

Al clonar diapositivas en otra presentación, asegúrese de que la presentación de destino tenga el mismo tamaño de diapositiva que la fuente. Si los tamaños difieren, Aspose.Slides no redimensiona automáticamente las formas clonadas; sus coordenadas y dimensiones originales se conservan, lo que puede provocar que el contenido aparezca desalineado o se extienda más allá de los límites de la diapositiva.

Puede establecer el tamaño de diapositiva de la presentación de destino para que coincida con el de la fuente antes de clonar la maestra y la diapositiva:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

Haga esto antes de clonar el maestro y la diapositiva.

## **Preguntas frecuentes**

**¿Se clonan las notas del orador y los comentarios de revisión?**

Sí. La página de notas y los comentarios de revisión se incluyen en el clon. Si no los desea, [eliminarlos](/slides/es/cpp/presentation-notes/) después de la inserción.

**¿Cómo se gestionan los gráficos y sus fuentes de datos?**

Se copia el objeto del gráfico, su formato y los datos incrustados. Si el gráfico estaba vinculado a una fuente externa (por ejemplo, un libro de trabajo incrustado como OLE), ese vínculo se conserva como un [objeto OLE](/slides/es/cpp/manage-ole/). Después de moverlo entre archivos, verifique la disponibilidad de los datos y el comportamiento de actualización.

**¿Puedo controlar la posición de inserción y las secciones del clon?**

Sí. Puede insertar el clon en un índice de diapositiva específico y colocarlo en una [sección](/slides/es/cpp/slide-section/) elegida. Si la sección de destino no existe, créela primero y luego mueva la diapositiva a ella.