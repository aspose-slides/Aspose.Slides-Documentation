---
title: Acceder a diapositivas de presentación en Python
linktitle: Acceder diapositiva
type: docs
weight: 20
url: /es/python-java/access-slide-in-presentation/
keywords:
- acceder a diapositiva
- índice de diapositiva
- id de diapositiva
- posición de diapositiva
- cambiar posición
- propiedades de diapositiva
- número de diapositiva
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a acceder y gestionar diapositivas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Python a través de Java. Mejore la productividad con ejemplos de código."
---
## **Descripción general**

Este artículo explica cómo acceder y gestionar diapositivas en una presentación usando Aspose.Slides. Muestra cómo obtener diapositivas por su índice basado en cero de la colección de diapositivas y cómo acceder a una diapositiva por su ID único mediante el método [getSlideById](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSlideById).

También aprenderá cómo cambiar la posición de una diapositiva usando el método [setSlideNumber](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#setSlideNumber) y cómo definir el número de diapositiva inicial para una presentación con el método [setFirstSlideNumber](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#setFirstSlideNumber). Los ejemplos demuestran cómo cargar una presentación, obtener referencias a diapositivas, actualizar el orden o la numeración de las mismas y guardar la presentación modificada.

## **Acceder a una diapositiva por índice**

Todas las diapositivas de una presentación están ordenadas numéricamente según la posición de la diapositiva, comenzando desde 0. La primera diapositiva es accesible mediante el índice 0; la segunda diapositiva se accede mediante el índice 1; etc.

La clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) , que representa un archivo de presentación, expone todas las diapositivas como una colección [SlideCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidecollection/) (colección de objetos [Slide](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/)). Este código Python le muestra cómo acceder a una diapositiva mediante su índice:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Instanciar un objeto Presentation que representa un archivo de presentación.
presentation = Presentation("demo.pptx")
try:
    # Acceder a una diapositiva usando su índice.
    slide = presentation.getSlides().get_Item(0)
finally:
    presentation.dispose()
```

## **Acceder a una diapositiva por ID**

Cada diapositiva de una presentación tiene un ID único asociado. Puede usar el método [getSlideById](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSlideById) (expuesto por la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/)) para dirigirse a ese ID. Este código Python le muestra cómo proporcionar un ID de diapositiva válido y acceder a esa diapositiva mediante el método [getSlideById](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSlideById):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Instanciar un objeto Presentation que representa un archivo de presentación.
presentation = Presentation("demo.pptx")
try:
    # Obtener el ID de una diapositiva.
    slide_id = presentation.getSlides().get_Item(0).getSlideId()

    # Acceder a la diapositiva mediante su ID.
    slide = presentation.getSlideById(slide_id)
finally:
    presentation.dispose()
```

## **Cambiar la posición de la diapositiva**

Aspose.Slides le permite cambiar la posición de una diapositiva. Por ejemplo, puede especificar que la primera diapositiva se convierta en la segunda.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva (cuya posición desea cambiar) mediante su índice.
1. Establezca una nueva posición para la diapositiva mediante el método [setSlideNumber](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#setSlideNumber).
1. Guarde la presentación modificada.

Este código Python demuestra una operación en la que la diapositiva en la posición 1 se mueve a la posición 2:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar un objeto Presentation que representa un archivo de presentación.
presentation = Presentation("Presentation.pptx")
try:
    # Obtener la diapositiva cuya posición se va a cambiar.
    slide = presentation.getSlides().get_Item(0)

    # Establecer la nueva posición para la diapositiva.
    slide.setSlideNumber(2)

    # Guardar la presentación modificada.
    presentation.save("helloworld_Pos.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La primera diapositiva pasó a ser la segunda; la segunda diapositiva pasó a ser la primera. Cuando cambia la posición de una diapositiva, las demás diapositivas se ajustan automáticamente.

## **Establecer el número de la diapositiva**

Usando el método [setFirstSlideNumber](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#setFirstSlideNumber) (expuesto por la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/)), puede especificar un nuevo número para la primera diapositiva de una presentación. Esta operación hace que se recalculen los números de las demás diapositivas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtenga el número de la diapositiva.
1. Establezca el número de la diapositiva.
1. Guarde la presentación modificada.

Este código Python demuestra una operación donde el número de la primera diapositiva se establece en 10:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar un objeto Presentation que representa un archivo de presentación.
presentation = Presentation("HelloWorld.pptx")
try:
    # Obtener el número de diapositiva.
    first_slide_number = presentation.getFirstSlideNumber()

    # Establecer el número de diapositiva.
    presentation.setFirstSlideNumber(10)

    # Guardar la presentación modificada.
    presentation.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Si prefiere omitir la primera diapositiva, puede iniciar la numeración desde la segunda diapositiva (y ocultar la numeración de la primera) de la siguiente manera:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    # Establecer el número para la primera diapositiva de la presentación.
    presentation.setFirstSlideNumber(0)

    # Mostrar números de diapositiva en todas las diapositivas.
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(True)

    # Ocultar el número de diapositiva de la primera diapositiva.
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(False)

    # Guardar la presentación modificada.
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿El número de diapositiva que ve el usuario coincide con el índice basado en cero de la colección?**

El número que se muestra en una diapositiva puede comenzar en un valor arbitrario (por ejemplo, 10) y no tiene que coincidir con el índice; la relación está controlada por la configuración del [first slide number](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#setFirstSlideNumber) de la presentación.

**¿Las diapositivas ocultas afectan al indexado?**

Sí. Una diapositiva oculta permanece en la colección y se cuenta en el indexado; "oculta" se refiere a la visualización, no a su posición en la colección.

**¿Cambia el índice de una diapositiva cuando se añaden o eliminan otras diapositivas?**

Sí. Los índices siempre reflejan el orden actual de las diapositivas y se recalculan después de operaciones de inserción, eliminación y movimiento.