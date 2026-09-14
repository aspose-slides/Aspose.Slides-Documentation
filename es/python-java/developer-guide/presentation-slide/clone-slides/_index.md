---
title: Clonar diapositivas de presentación en Python
linktitle: Clonar diapositivas
type: docs
weight: 35
url: /es/python-java/clone-slides/
keywords:
- clonar diapositiva
- copiar diapositiva
- guardar diapositiva
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Duplica rápidamente diapositivas de PowerPoint con Aspose.Slides para Python via Java. Sigue nuestros claros ejemplos de código para automatizar la creación de PPT en segundos y eliminar el trabajo manual."
---
## **Introducción**

Clonar es el proceso de crear una copia exacta o réplica de algo. Aspose.Slides for Python via Java también permite crear una copia o clon de cualquier diapositiva y luego insertar esa diapositiva clonada en la presentación actual o en cualquier otra presentación abierta. El proceso de clonación de diapositivas crea una nueva diapositiva que los desarrolladores pueden modificar sin cambiar la diapositiva original. Existen varias formas posibles de clonar una diapositiva:

- Clonar al final dentro de una presentación.
- Clonar en otra posición dentro de una presentación.
- Clonar al final en otra presentación.
- Clonar en otra posición en otra presentación.
- Clonar junto con su diapositiva maestra en otra presentación.

En Aspose.Slides for Python via Java, la colección de diapositivas (una colección de [Slide](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/) objetos) expuesta por el objeto [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) proporciona los métodos [addClone](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidecollection/#addClone) e[insertClone](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidecollection/#insertClone) para realizar los tipos de clonación de diapositivas descritos anteriormente.

## **Clonar una diapositiva al final de una presentación**

Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación al final de las diapositivas existentes, utilice el método [addClone] según los pasos enumerados a continuación:

1. Cree una instancia de la clase [Presentation].
2. Obtenga el objeto [SlideCollection] haciendo referencia a la colección Slides expuesta por el objeto [Presentation].
3. Llame al método [addClone] expuesto por el objeto [SlideCollection] y pase la diapositiva que se va a clonar como parámetro al método [addClone].
4. Guarde el archivo de presentación modificado.

En el ejemplo que sigue, hemos clonado una diapositiva (situada en la primera posición – índice cero – de la presentación) al final de la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar la clase Presentation que representa un archivo de presentación
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # Clonar la diapositiva deseada al final de la colección de diapositivas en la misma presentación
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Guardar la presentación modificada en disco
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clonar una diapositiva a otra posición dentro de una presentación**

Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una posición diferente, utilice el método [insertClone]:

1. Cree una instancia de la clase [Presentation].
2. Obtenga una referencia a la colección de diapositivas devuelta por [getSlides] en el objeto [Presentation].
3. Llame al método [insertClone] expuesto por el objeto [SlideCollection] y pase la diapositiva que se va a clonar junto con el índice de la nueva posición como parámetro al método [insertClone].
4. Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que sigue, hemos clonado una diapositiva (situada en el índice 1 – posición 2 – de la presentación) al índice 2 – posición 3 – de la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar la clase Presentation que representa un archivo de presentación
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Obtener la colección de diapositivas de la presentación
    slides = presentation.getSlides()

    # Clonar la diapositiva deseada al índice especificado en la misma presentación
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Guardar la presentación modificada en disco
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clonar una diapositiva al final de otra presentación**

Si necesita clonar una diapositiva de una presentación y usarla en otro archivo de presentación, al final de las diapositivas existentes:

1. Cree una instancia de la clase [Presentation] que contenga la presentación de la cual se clonará la diapositiva.
2. Cree una instancia de la clase [Presentation] que contenga la presentación de destino a la que se añadirá la diapositiva.
3. Obtenga el objeto [SlideCollection] haciendo referencia a la colección de diapositivas devuelta por [getSlides] en el objeto [Presentation] de la presentación de destino.
4. Llame al método [addClone] expuesto por el objeto [SlideCollection] y pase la diapositiva de la presentación origen como parámetro al método [addClone].
5. Guarde el archivo de la presentación de destino modificada.

En el ejemplo que sigue, hemos clonado una diapositiva (del índice 0 de la presentación origen) al final de la presentación de destino.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar la clase Presentation para cargar el archivo de presentación origen
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instanciar la clase Presentation para el PPTX de destino (donde se clonará la diapositiva)
    destination_presentation = Presentation()
    try:
        # Clonar la diapositiva deseada de la presentación origen al final de la colección de diapositivas en la presentación de destino
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # Guardar la presentación de destino en disco
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Clonar una diapositiva a otra posición en otra presentación**

Si necesita clonar una diapositiva de una presentación y usarla en otro archivo de presentación, en una posición específica:

1. Cree una instancia de la clase [Presentation] que contenga la presentación fuente de la cual se clonará la diapositiva.
2. Cree una instancia de la clase [Presentation] que contenga la presentación a la que se añadirá la diapositiva.
3. Obtenga el objeto [SlideCollection] haciendo referencia a la colección Slides expuesta por el objeto [Presentation] de la presentación de destino.
4. Llame al método [insertClone] expuesto por el objeto [SlideCollection] y pase la diapositiva de la presentación origen junto con la posición deseada como parámetro al método [insertClone].
5. Guarde el archivo de la presentación de destino modificada.

En el ejemplo que sigue, hemos clonado una diapositiva (del índice cero de la presentación origen) al índice 1 (posición 2) de la presentación de destino.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar la clase Presentation para cargar el archivo de presentación origen
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Instanciar la clase Presentation para el PPTX de destino (donde se clonará la diapositiva)
    destination_presentation = Presentation()
    try:
        # Clonar la diapositiva deseada de la presentación origen al índice especificado en la presentación de destino
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Guardar la presentación de destino en disco
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Clonar una diapositiva con su diapositiva maestra a otra presentación**

Si necesita clonar una diapositiva con su diapositiva maestra a otra presentación, primero debe clonar la diapositiva maestra deseada de la presentación origen a la presentación de destino. Luego use la maestra clonada al clonar la diapositiva. El método [addClone] espera una diapositiva maestra de la presentación de destino, no de la origen. Para clonar la diapositiva con su maestra, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation] que contenga la presentación fuente de la cual se clonará la diapositiva.
2. Cree una instancia de la clase [Presentation] que contenga la presentación de destino a la que se clonará la diapositiva.
3. Acceda a la diapositiva que se va a clonar junto con su diapositiva maestra.
4. Obtenga el objeto [MasterSlideCollection] haciendo referencia a la colección Masters expuesta por el objeto [Presentation] de la presentación de destino.
5. Llame al método [addClone] expuesto por el objeto [MasterSlideCollection] y pase la diapositiva maestra del PPTX origen que se va a clonar como parámetro al método [addClone].
6. Obtenga el objeto [SlideCollection] haciendo referencia a la colección Slides expuesta por el objeto [Presentation] de la presentación de destino.
7. Llame al método [addClone] expuesto por el objeto [SlideCollection] y pase la diapositiva de la presentación origen que se va a clonar y la diapositiva maestra como parámetro al método [addClone].
8. Guarde el archivo de la presentación de destino modificada.

En el ejemplo que sigue, hemos clonado una diapositiva con su maestra (situada en el índice cero de la presentación origen) al final de la presentación de destino usando la maestra de la diapositiva origen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar la clase Presentation para cargar el archivo de presentación origen
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Instanciar la clase Presentation para la presentación de destino (donde se clonará la diapositiva)
    destination_presentation = Presentation()
    try:
        # Instanciar la diapositiva de la colección de diapositivas de la presentación origen junto con
        # Diapositiva maestra
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Clonar la diapositiva maestra deseada de la presentación origen a la colección de maestras en la
        # presentación de destino
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Clonar la diapositiva deseada de la presentación origen con la maestra deseada al final de la
        # colección de diapositivas de la presentación de destino
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Guardar la presentación de destino en disco
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Clonar una diapositiva al final de una sección especificada**

Si desea clonar una diapositiva y luego usarla dentro del mismo archivo de presentación pero en una sección diferente, utilice el método [**addClone**] expuesto por la clase [**SlideCollection**]. Aspose.Slides for Python via Java permite clonar una diapositiva de la primera sección e insertarla en la segunda sección de la misma presentación.

El siguiente fragmento de código le muestra cómo clonar una diapositiva e insertar la diapositiva clonada en una sección especificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Guardar la presentación de destino en disco
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Asegurar que el tamaño de la diapositiva coincida**

Al clonar diapositivas en otra presentación, asegúrese de que la presentación de destino tenga el mismo tamaño de diapositiva que la origen. Si los tamaños de las diapositivas difieren, Aspose.Slides no redimensiona automáticamente las formas clonadas; sus coordenadas y dimensiones originales se conservan, lo que puede hacer que el contenido aparezca desalineado o se extienda más allá de los límites de la diapositiva.

Puede establecer el tamaño de la diapositiva de la presentación de destino para que coincida con el de la origen antes de clonar la maestra y la diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Haga esto antes de clonar la maestra y la diapositiva.

## **FAQ**

**¿Se clonan las notas del presentador y los comentarios del revisor?**

Sí. La página de notas y los comentarios de revisión se incluyen en el clon. Si no los quiere, [elimínelos](/slides/es/python-java/presentation-notes/) después de la inserción.

**¿Cómo se gestionan los gráficos y sus fuentes de datos?**

El objeto del gráfico, su formato y los datos incrustados se copian. Si el gráfico estaba vinculado a una fuente externa (p. ej., un libro de trabajo incrustado como OLE), ese vínculo se conserva como un [OLE object](/slides/es/python-java/manage-ole/). Después de moverlo entre archivos, verifique la disponibilidad de los datos y el comportamiento de actualización.

**¿Puedo controlar la posición de inserción y las secciones del clon?**

Sí. Puede insertar el clon en un índice de diapositiva específico y colocarlo en una [section](/slides/es/python-java/slide-section/) elegida. Si la sección de destino no existe, créela primero y luego mueva la diapositiva a ella.