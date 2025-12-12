---
title: Gestionar la presentación de diapositivas en Android
linktitle: Presentación de diapositivas
type: docs
weight: 90
url: /es/androidjava/manage-slide-show/
keywords:
- tipo de presentación
- presentado por el ponente
- explorado por un individuo
- explorado en quiosco
- opciones de presentación
- repetir continuamente
- presentar sin narración
- presentar sin animación
- color del lápiz
- mostrar diapositivas
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
description: "Aprenda cómo gestionar presentaciones de diapositivas en Aspose.Slides para Android mediante Java. Controle transiciones de diapositivas, temporizaciones y más en los formatos PPT, PPTX y ODP con facilidad."
---

En Microsoft PowerPoint, la configuración de **Slide Show** es una herramienta clave para preparar y ofrecer presentaciones profesionales. Una de las características más importantes de esta sección es **Set Up Show**, que le permite adaptar su presentación a condiciones y audiencias específicas, garantizando flexibilidad y comodidad. Con esta función, puede seleccionar el tipo de presentación (p.ej., presentado por un orador, explorado por un individuo o explorado en un kiosco), habilitar o deshabilitar el bucle, elegir diapositivas específicas para mostrar y usar temporizaciones. Este paso en la preparación es crucial para que su presentación sea más eficaz y profesional.

`getSlideShowSettings` es un método de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) que devuelve un objeto de tipo [SlideShowSettings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowsettings/), lo que le permite gestionar la configuración del slide show en una presentación de PowerPoint. En este artículo, exploraremos cómo usar este método para configurar y controlar varios aspectos de la configuración del slide show. 

## **Seleccionar tipo de presentación**

`SlideShowSettings.setSlideShowType` define el tipo de slide show, que puede ser una instancia de las siguientes clases: [PresentedBySpeaker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedatkiosk/). Usar este método le permite adaptar la presentación a diferentes escenarios de uso, como kioscos automatizados o presentaciones manuales.

El ejemplo de código a continuación crea una nueva presentación y establece el tipo de presentación a "Browsed by an individual" sin mostrar la barra de desplazamiento.
```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Habilitar opciones de presentación**

`SlideShowSettings.setLoop` determina si el slide show debe repetirse en un bucle hasta que se detenga manualmente. Esto es útil para presentaciones automatizadas que necesitan ejecutarse de forma continua. `SlideShowSettings.setShowNarration` determina si se deben reproducir las narraciones de voz durante el slide show. Es útil para presentaciones automatizadas que contienen guía de voz para la audiencia. `SlideShowSettings.setShowAnimation` determina si se deben reproducir las animaciones añadidas a los objetos de diapositiva. Esto es útil para proporcionar el efecto visual completo de la presentación.

El siguiente ejemplo de código crea una nueva presentación y hace que el slide show se repita en bucle.
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

El método `SlideShowSettings.setUseTimings` le permite habilitar o deshabilitar el uso de temporizaciones predefinidas para cada diapositiva. Esto es útil para mostrar automáticamente diapositivas con duraciones predefinidas. El ejemplo de código a continuación crea una nueva presentación y deshabilita el uso de temporizaciones.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Mostrar controles multimedia**

El método `SlideShowSettings.setShowMediaControls` determina si los controles multimedia (como reproducir, pausar y detener) deben mostrarse durante el slide show cuando se reproduce contenido multimedia (p.ej., video o audio). Esto es útil cuando desea dar al presentador control sobre la reproducción de medios durante la presentación.

El siguiente ejemplo de código crea una nueva presentación y habilita que se muestren los controles multimedia.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Preguntas frecuentes**

**¿Puedo guardar una presentación para que se abra directamente en modo de presentación?**

Sí. Guarde el archivo como PPSX o PPSM; estos formatos se abren directamente en modo de presentación al abrirse en PowerPoint. En Aspose.Slides, elija el formato de guardado correspondiente [durante la exportación](/slides/es/androidjava/save-presentation/).

**¿Puedo excluir diapositivas individuales de la presentación sin eliminarlas del archivo?**

Sí. Marque una diapositiva como [hidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Las diapositivas ocultas permanecen en la presentación pero no se muestran durante el slide show.

**¿Puede Aspose.Slides reproducir una presentación o controlar una presentación en vivo en pantalla?**

No. Aspose.Slides edita, analiza y convierte archivos de presentación; la reproducción real es gestionada por una aplicación visor como PowerPoint.