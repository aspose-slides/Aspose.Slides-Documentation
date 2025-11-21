---
title: Administrar presentación de diapositivas
type: docs
weight: 90
url: /es/nodejs-java/manage-slide-show/
keywords:
- tipo de presentación
- presentado por un orador
- navegado por un individuo
- navegado en un quiosco
- opciones de presentación
- repetir continuamente
- presentación sin narración
- presentación sin animación
- color del lápiz
- mostrar diapositivas
- presentación personalizada
- avanzar diapositivas
- manualmente
- usando cronometrajes
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides para Node.js mediante Java
description: "Administrar la configuración de la presentación de diapositivas en presentaciones de PowerPoint usando JavaScript"
---

En Microsoft PowerPoint, la configuración de **Slide Show** es una herramienta clave para preparar y presentar presentaciones profesionales. Una de las funciones más importantes de esta sección es **Set Up Show**, que le permite adaptar su presentación a condiciones y audiencias específicas, garantizando flexibilidad y comodidad. Con esta función, puede seleccionar el tipo de presentación (p. ej., presentada por un orador, navegada por un individuo o navegada en un kiosco), habilitar o desactivar el bucle, elegir diapositivas específicas para mostrar y utilizar cronometraje. Este paso en la preparación es crucial para que su presentación sea más eficaz y profesional.

`getSlideShowSettings` es un método de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) que devuelve un objeto del tipo [SlideShowSettings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowsettings/), lo que le permite gestionar la configuración del pase de diapositivas en una presentación de PowerPoint. En este artículo, exploraremos cómo usar este método para configurar y controlar varios aspectos de la configuración del pase de diapositivas. 

## **Select Show Type**

`SlideShowSettings.setSlideShowType` define el tipo de pase de diapositivas, que puede ser una instancia de las siguientes clases: [PresentedBySpeaker](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/nodejs-java/aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/nodejs-java/aspose.slides/browsedatkiosk/). Usar este método le permite adaptar la presentación a diferentes escenarios de uso, como kioscos automatizados o presentaciones manuales.

El ejemplo de código a continuación crea una nueva presentación y establece el tipo de pase en “Browsed by an individual” sin mostrar la barra de desplazamiento.
```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Enable Show Options**

`SlideShowSettings.setLoop` determina si el pase de diapositivas debe repetirse en bucle hasta que se detenga manualmente. Esto es útil para presentaciones automatizadas que deben ejecutarse de forma continua. `SlideShowSettings.setShowNarration` determina si se deben reproducir narraciones de voz durante el pase de diapositivas. Es útil para presentaciones automatizadas que contienen guías de voz para la audiencia. `SlideShowSettings.setShowAnimation` determina si se deben reproducir las animaciones añadidas a los objetos de diapositiva. Esto es útil para proporcionar el efecto visual completo de la presentación.

El siguiente ejemplo de código crea una nueva presentación y pone el pase de diapositivas en bucle.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Select Slides to Show**

El método `SlideShowSettings.setSlides` le permite seleccionar un rango de diapositivas que se mostrarán durante la presentación. Esto es útil cuando necesita mostrar solo una parte de la presentación en lugar de todas las diapositivas. El siguiente ejemplo de código crea una nueva presentación y establece el rango de diapositivas para mostrarlas desde la diapositiva `2` hasta la `9`.
```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Use Advance Slides**

El método `SlideShowSettings.setUseTimings` le permite habilitar o deshabilitar el uso de cronometrajes predefinidos para cada diapositiva. Esto es útil para mostrar automáticamente diapositivas con duraciones de visualización preestablecidas. El ejemplo de código a continuación crea una nueva presentación y desactiva el uso de cronometrajes.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Show Media Controls**

`SlideShowSettings.setShowMediaControls` determina si los controles de medios (como reproducir, pausar y detener) deben mostrarse durante el pase de diapositivas cuando se reproduce contenido multimedia (p. ej., video o audio). Esto es útil cuando desea dar al presentador control sobre la reproducción de medios durante la presentación.

El siguiente ejemplo de código crea una nueva presentación y habilita la visualización de los controles de medios.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **FAQ**

**¿Puedo guardar una presentación para que se abra directamente en modo de pase de diapositivas?**

Sí. Guarde el archivo como PPSX o PPSM; estos formatos se inician directamente en modo de pase de diapositivas al abrirse en PowerPoint. En Aspose.Slides, elija el formato de guardado correspondiente [durante la exportación](/slides/es/nodejs-java/save-presentation/).

**¿Puedo excluir diapositivas individuales del pase sin eliminarlas del archivo?**

Sí. Marque una diapositiva como [hidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/sethidden/). Las diapositivas ocultas permanecen en la presentación pero no se muestran durante el pase de diapositivas.

**¿Aspose.Slides puede reproducir un pase de diapositivas o controlar una presentación en vivo en pantalla?**

No. Aspose.Slides edita, analiza y convierte archivos de presentación; la reproducción real la gestiona una aplicación de visualización como PowerPoint.