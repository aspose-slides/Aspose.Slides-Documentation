---
title: Administrar presentaciones de diapositivas en Python mediante Java
linktitle: Presentación de diapositivas
type: docs
weight: 90
url: /es/python-java/manage-slide-show/
keywords:
- tipo de presentación
- presentado por el ponente
- navegado por un individuo
- navegado en kiosco
- opciones de presentación
- repetir continuamente
- presentación sin narración
- presentación sin animación
- color del lápiz
- presentar diapositivas
- presentación personalizada
- avanzar diapositivas
- manualmente
- usando temporizaciones
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda cómo administrar presentaciones de diapositivas en Aspose.Slides para Python mediante Java. Controle transiciones de diapositivas, temporizaciones y más en los formatos PPT, PPTX y ODP con facilidad."
---
## **Introducción**

Las opciones **Set Up Show** de Microsoft PowerPoint le permiten elegir el tipo de presentación, habilitar la repetición, seleccionar diapositivas y controlar cómo avanza la presentación. Con Aspose.Slides for Python via Java, puede configurar estas opciones mediante código y guardarlas en un archivo de presentación.

El método [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSlideShowSettings) devuelve un objeto [SlideShowSettings](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowsettings/) que controla estas opciones. Los ejemplos a continuación requieren Aspose.Slides for Python via Java y un tiempo de ejecución Java compatible. Cada ejemplo inicia la JVM si es necesario y libera la presentación al finalizar.

## **Seleccionar tipo de presentación**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowsettings/#setSlideShowType) define el tipo de presentación, que puede ser una instancia de las siguientes clases: [PresentedBySpeaker](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/es/python-java/aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/es/python-java/aspose.slides/browsedatkiosk/). Usar este método permite adaptar la presentación a distintos escenarios de uso, como kioscos automáticos o presentaciones manuales.

El ejemplo de código a continuación crea una nueva presentación y establece el tipo de presentación a "Navegado por un individuo" sin mostrar la barra de desplazamiento.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Habilitar opciones de presentación**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowsettings/#setLoop) determina si la presentación debe repetirse en bucle hasta que se detenga manualmente. Esto es útil para presentaciones automatizadas que deben ejecutarse continuamente. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowsettings/#setShowNarration) determina si las narraciones de voz deben reproducirse durante la presentación. Es útil para presentaciones automatizadas que contienen guía de voz para la audiencia. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowsettings/#setShowAnimation) determina si las animaciones añadidas a los objetos de diapositiva deben reproducirse. Esto es útil para proporcionar el efecto visual completo de la presentación.

El siguiente ejemplo de código crea una nueva presentación y repite la presentación en bucle.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Seleccionar diapositivas a mostrar**

El método [SlideShowSettings.setSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowsettings/#setSlides) permite seleccionar un rango de diapositivas que se mostrarán durante la presentación. Esto es útil cuando necesita mostrar solo una parte de la presentación en lugar de todas las diapositivas. El siguiente ejemplo de código crea una presentación con nueve diapositivas y selecciona las diapositivas 2 a 9. El rango utiliza números de diapositiva basados en 1.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Crear nueve diapositivas para que exista el rango seleccionado.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controlar el avance de diapositivas**

El método [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowsettings/#setUseTimings) permite habilitar o deshabilitar el uso de temporizaciones predefinidas para cada diapositiva. Esto es útil para mostrar automáticamente diapositivas con duraciones de visualización predefinidas. El ejemplo de código a continuación crea una nueva presentación y deshabilita el uso de temporizaciones.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mostrar controles de medios**

El método [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) determina si los controles de medios (como reproducir, pausar y detener) deben mostrarse durante la presentación cuando se reproduce contenido multimedia (p. ej., vídeo o audio). Esto es útil cuando desea dar al presentador control sobre la reproducción de medios durante la presentación.

El siguiente ejemplo de código crea una nueva presentación y habilita la visualización de los controles de medios.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo guardar una presentación para que se abra directamente en modo de presentación?**

Sí. Guarde el archivo como PPSX o PPSM; estos formatos se inician directamente en modo de presentación al abrirse en PowerPoint. En Aspose.Slides, elija el formato de guardado correspondiente [durante la exportación](/slides/es/python-java/save-presentation/).

**¿Puedo excluir diapositivas individuales de la presentación sin eliminarlas del archivo?**

Sí. Marque una diapositiva como [hidden](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#setHidden). Las diapositivas ocultas permanecen en la presentación pero no se muestran durante la presentación.

**¿Aspose.Slides puede reproducir una presentación o controlar una presentación en vivo en pantalla?**

No. Aspose.Slides edita, analiza y convierte archivos de presentación; la reproducción real es gestionada por una aplicación de visualización como PowerPoint.