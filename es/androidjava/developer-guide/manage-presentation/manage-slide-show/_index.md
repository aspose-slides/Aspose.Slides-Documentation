---
title: Administrar presentación de diapositivas en Android
linktitle: Presentación de diapositivas
type: docs
weight: 90
url: /es/androidjava/manage-slide-show/
keywords:
- tipo de presentación
- presentado por el orador
- navegado por individuo
- navegado en kiosco
- opciones de presentación
- repetir continuamente
- presentar sin narración
- presentar sin animación
- color del bolígrafo
- presentar diapositivas
- presentación personalizada
- avanzar diapositivas
- manualmente
- usando temporizaciones
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo administrar presentaciones de diapositivas en Aspose.Slides para Android mediante Java. Controle transiciones de diapositivas, temporizaciones y más en los formatos PPT, PPTX y ODP con facilidad."
---

En Microsoft PowerPoint, la configuración de **Presentación de diapositivas** es una herramienta clave para preparar y ofrecer presentaciones profesionales. Una de las características más importantes de esta sección es **Configurar presentación**, que le permite adaptar su presentación a condiciones y audiencias específicas, garantizando flexibilidad y comodidad. Con esta función, puede seleccionar el tipo de presentación (p. ej., presentada por un orador, navegada por una persona o navegada en un kiosco), habilitar o deshabilitar el bucle, elegir diapositivas específicas para mostrar y usar temporizaciones. Este paso en la preparación es crucial para que su presentación sea más eficaz y profesional.

`getSlideShowSettings` es un método de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) que devuelve un objeto del tipo [SlideShowSettings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowsettings/), el cual le permite gestionar la configuración de la presentación de diapositivas en un archivo de PowerPoint. En este artículo, exploraremos cómo usar este método para configurar y controlar varios aspectos de la configuración de la presentación de diapositivas. 

## **Seleccionar tipo de presentación**

`SlideShowSettings.setSlideShowType` define el tipo de presentación de diapositivas, que puede ser una instancia de las siguientes clases: [PresentedBySpeaker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedatkiosk/). Usar este método le permite adaptar la presentación a diferentes escenarios de uso, como kioscos automatizados o presentaciones manuales.

El ejemplo de código a continuación crea una nueva presentación y establece el tipo de presentación en “Navegada por una persona” sin mostrar la barra de desplazamiento.
```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Habilitar opciones de presentación**

`SlideShowSettings.setLoop` determina si la presentación de diapositivas debe repetirse en bucle hasta que se detenga manualmente. Esto es útil para presentaciones automatizadas que deben ejecutarse de forma continua. `SlideShowSettings.setShowNarration` determina si se deben reproducir narraciones de voz durante la presentación de diapositivas. Es útil para presentaciones automatizadas que contienen guías de voz para la audiencia. `SlideShowSettings.setShowAnimation` determina si se deben reproducir las animaciones añadidas a los objetos de la diapositiva. Esto es útil para proporcionar el efecto visual completo de la presentación.

El siguiente ejemplo de código crea una nueva presentación y reproduce la presentación de diapositivas en bucle.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Seleccionar diapositivas para mostrar**

El método `SlideShowSettings.setSlides` le permite seleccionar un rango de diapositivas que se mostrarán durante la presentación. Esto es útil cuando necesita mostrar solo una parte de la presentación en lugar de todas las diapositivas. El siguiente ejemplo de código crea una nueva presentación y establece el rango de diapositivas a mostrar desde la diapositiva `2` hasta la `9`.
```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Usar avance de diapositivas**

El método `SlideShowSettings.setUseTimings` le permite habilitar o deshabilitar el uso de temporizaciones predefinidas para cada diapositiva. Esto es útil para mostrar diapositivas automáticamente con duraciones de visualización definidas previamente. El ejemplo de código a continuación crea una nueva presentación y deshabilita el uso de temporizaciones.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Mostrar controles de medios**

`SlideShowSettings.setShowMediaControls` determina si se deben mostrar los controles de medios (como reproducir, pausar y detener) durante la presentación de diapositivas cuando se reproduce contenido multimedia (p. ej., video o audio). Esto es útil cuando desea dar al presentador control sobre la reproducción de medios durante la presentación.

El siguiente ejemplo de código crea una nueva presentación y habilita la visualización de los controles de medios.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **FAQ**

**¿Puedo guardar una presentación para que se abra directamente en modo presentación de diapositivas?**

Sí. Guarde el archivo como PPSX o PPSM; estos formatos se inician directamente en modo presentación de diapositivas al abrirse en PowerPoint. En Aspose.Slides, elija el formato de guardado correspondiente [durante la exportación](/slides/es/androidjava/save-presentation/).

**¿Puedo excluir diapositivas individuales de la presentación sin eliminarlas del archivo?**

Sí. Marque una diapositiva como [oculta](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Las diapositivas ocultas permanecen en la presentación pero no se muestran durante la presentación de diapositivas.

**¿Aspose.Slides puede reproducir una presentación de diapositivas o controlar una presentación en vivo en pantalla?**

No. Aspose.Slides edita, analiza y convierte archivos de presentación; la reproducción real la gestiona una aplicación de visualización como PowerPoint.