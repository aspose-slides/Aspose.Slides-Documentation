---
title: Añadir diapositivas a presentaciones en Python
linktitle: Añadir diapositiva
type: docs
weight: 10
url: /es/python-java/add-slide-to-presentation/
keywords:
- añadir diapositiva
- crear diapositiva
- diapositiva vacía
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Añada diapositivas fácilmente a sus presentaciones PowerPoint y OpenDocument utilizando Aspose.Slides para Python vía Java: inserción de diapositivas fluida y eficiente en segundos."
---
## **Visión general**

Aspose.Slides le permite añadir diapositivas a presentaciones de PowerPoint de forma programada. Una presentación contiene diapositivas maestro/disposición y diapositivas normales, y las diapositivas normales se organizan mediante un índice basado en cero. Cada diapositiva tiene un ID único, y los archivos de presentación sin diapositivas no son compatibles.

Este artículo explica cómo crear un objeto [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) , acceder a su colección de diapositivas, añadir una diapositiva vacía, trabajar con la diapositiva recién añadida y guardar la presentación actualizada. También cubre puntos relacionados como insertar diapositivas en una posición concreta, usar disposiciones y comprender la diapositiva en blanco que existe en una presentación recién creada.

## **Añadir una diapositiva a una presentación**

Antes de abordar cómo añadir diapositivas a los archivos de presentación, revisemos algunos datos sobre las diapositivas. Cada archivo de presentación de PowerPoint contiene **diapositivas maestro/disposición** y **diapositivas normales**. Un archivo de presentación contiene al menos una diapositiva. Los archivos de presentación sin diapositivas no son compatibles con Aspose.Slides for Python via Java. Cada diapositiva tiene un ID único, y todas las diapositivas normales se organizan en un orden especificado por un índice basado en cero.

Aspose.Slides for Python via Java permite a los desarrolladores añadir diapositivas vacías a sus presentaciones. Para añadir una diapositiva vacía a una presentación, siga estos pasos:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
- Obtenga una referencia al objeto [SlideCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidecollection/) mediante el método [getSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSlides) expuesto por el objeto [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
- Añada una diapositiva vacía al final de la colección de diapositivas de la presentación llamando al método [addEmptySlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidecollection/#addEmptySlide) expuesto por el objeto [SlideCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidecollection/).
- Realice alguna operación con la diapositiva vacía recién añadida.
- Finalmente, escriba el archivo de presentación utilizando el objeto [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Instanciar la clase Presentation que representa el archivo de presentación.
presentation = Presentation()
try:
    # Obtener la colección de diapositivas.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # Añadir una diapositiva vacía a la colección de diapositivas.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # Realizar alguna operación en la diapositiva recién añadida.

    # Guardar el archivo PPTX en disco.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo insertar una nueva diapositiva en una posición específica, no solo al final?**

Sí. La biblioteca admite colecciones de diapositivas y operaciones de [insert](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidecollection/#insertClone), por lo que puede añadir una diapositiva en el índice requerido en lugar de solo al final.

**¿Se conservan los temas/estilos al añadir una diapositiva basada en una disposición?**

Sí. Una disposición hereda el formato de su maestro, y la nueva diapositiva hereda de la disposición seleccionada y de su maestro asociado.

**¿Qué diapositiva está presente en una nueva presentación “vacía” antes de añadir diapositivas?**

Una presentación recién creada ya contiene una diapositiva en blanco con índice cero. Esto es importante a la hora de calcular los índices de inserción.

**¿Cómo elegir la disposición “correcta” para una nueva diapositiva si el maestro tiene muchas opciones?**

Generalmente, elija la [LayoutSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutslide/) que coincida con la estructura requerida ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidelayouttype/)). Si falta dicha disposición, puede [add it to the master](/slides/es/python-java/slide-layout/) y luego usarla.