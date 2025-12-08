---
title: Administrar presentación de diapositivas en Python
linktitle: Presentación de diapositivas
type: docs
weight: 90
url: /es/python-net/manage-slide-show/
keywords:
- tipo de presentación
- presentado por orador
- navegado por individuo
- navegado en quiosco
- opciones de presentación
- bucle continuo
- presentar sin narración
- presentar sin animación
- color de lápiz
- presentar diapositivas
- presentación personalizada
- avanzar diapositivas
- manualmente
- usando temporizaciones
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a gestionar presentaciones de diapositivas en Aspose.Slides para Python mediante .NET. Controle transiciones de diapositivas, temporizaciones y más en formatos PPT, PPTX y ODP con facilidad."
---

En Microsoft PowerPoint, la configuración de **Presentación de diapositivas** es una herramienta clave para preparar y ofrecer presentaciones profesionales. Una de las funciones más importantes de esta sección es **Configurar presentación**, que le permite adaptar su presentación a condiciones y audiencias específicas, garantizando flexibilidad y comodidad. Con esta función, puede seleccionar el tipo de presentación (por ejemplo, presentada por un orador, navegada por un individuo o navegada en un quiosco), habilitar o deshabilitar el bucle, elegir diapositivas específicas para mostrar y usar cronómetros. Este paso en la preparación es crucial para que su presentación sea más eficaz y profesional.

`slide_show_settings` es una propiedad de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), de tipo [SlideShowSettings](https://reference.aspose.com/slides/python-net/aspose.slides/slideshowsettings/), que le permite administrar la configuración de la presentación de diapositivas en una presentación de PowerPoint. En este artículo, exploraremos cómo usar esta propiedad para configurar y controlar varios aspectos de la configuración de la presentación de diapositivas. 

## **Seleccionar tipo de presentación**

`SlideShowSettings.slide_show_type` define el tipo de presentación de diapositivas, que puede ser una instancia de las siguientes clases: [PresentedBySpeaker](https://reference.aspose.com/slides/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/python-net/aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/python-net/aspose.slides/browsedatkiosk/). Usar esta propiedad le permite adaptar la presentación a diferentes escenarios de uso, como quioscos automatizados o presentaciones manuales.

El ejemplo de código a continuación crea una nueva presentación y establece el tipo de presentación en "Navegado por un individuo" sin mostrar la barra de desplazamiento.
```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Habilitar opciones de presentación**

`SlideShowSettings.loop` determina si la presentación de diapositivas debe repetirse en bucle hasta que se detenga manualmente. Esto es útil para presentaciones automatizadas que deben ejecutarse de forma continua. `SlideShowSettings.show_narration` determina si se deben reproducir narraciones de voz durante la presentación de diapositivas. Es útil para presentaciones automatizadas que contienen guía de voz para la audiencia. `SlideShowSettings.show_animation` determina si se deben reproducir animaciones añadidas a los objetos de diapositiva. Esto es útil para proporcionar el efecto visual completo de la presentación.

El siguiente ejemplo de código crea una nueva presentación y hace que la presentación de diapositivas se repita en bucle.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Seleccionar diapositivas para mostrar**

La propiedad `SlideShowSettings.slides` le permite seleccionar un rango de diapositivas que se mostrará durante la presentación. Esto es útil cuando necesita mostrar solo una parte de la presentación en lugar de todas las diapositivas. El siguiente ejemplo de código crea una nueva presentación y establece el rango de diapositivas que se mostrarán desde la diapositiva `2` hasta la `9`.
```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Usar avance de diapositivas**

La propiedad `SlideShowSettings.use_timings` le permite habilitar o deshabilitar el uso de temporizaciones predefinidas para cada diapositiva. Esto es útil para mostrar automáticamente diapositivas con duraciones de visualización predefinidas. El siguiente ejemplo de código crea una nueva presentación y deshabilita el uso de temporizaciones.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Mostrar controles de medios**

La propiedad `SlideShowSettings.show_media_controls` determina si los controles de medios (como reproducir, pausar y detener) deben mostrarse durante la presentación de diapositivas cuando se reproduce contenido multimedia (p. ej., vídeo o audio). Esto es útil cuando desea dar al presentador control sobre la reproducción de medios durante la presentación.

El siguiente ejemplo de código crea una nueva presentación y habilita la visualización de los controles de medios.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Puedo guardar una presentación para que se abra directamente en modo de presentación?**

Sí. Guarde el archivo como PPSX o PPSM; estos formatos se inician directamente en modo presentación al abrirse en PowerPoint. En Aspose.Slides, elija el formato de guardado correspondiente [durante la exportación](/slides/es/python-net/save-presentation/).

**¿Puedo excluir diapositivas individuales de la presentación sin eliminarlas del archivo?**

Sí. Marque una diapositiva como [oculta](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/). Las diapositivas ocultas permanecen en la presentación pero no se muestran durante la presentación de diapositivas.

**¿Puede Aspose.Slides reproducir una presentación o controlar una presentación en vivo en pantalla?**

No. Aspose.Slides edita, analiza y convierte archivos de presentación; la reproducción real es manejada por una aplicación de visualización como PowerPoint.