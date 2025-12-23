---
title: Administrar presentación de diapositivas en PHP
linktitle: Presentación de diapositivas
type: docs
weight: 90
url: /es/php-java/manage-slide-show/
keywords:
- tipo de presentación
- presentada por orador
- explorada por individuo
- explorada en kiosco
- opciones de presentación
- repetir continuamente
- presentación sin narración
- presentación sin animación
- color del lápiz
- diapositivas de presentación
- presentación personalizada
- avanzar diapositivas
- manualmente
- usando tiempos
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a administrar presentaciones de diapositivas en Aspose.Slides para PHP a través de Java. Controle transiciones de diapositivas, tiempos y más en los formatos PPT, PPTX y ODP con facilidad."
---

En Microsoft PowerPoint, la configuración de **Presentación de diapositivas** es una herramienta clave para preparar y ofrecer presentaciones profesionales. Una de las características más importantes en esta sección es **Configurar presentación**, que le permite adaptar su presentación a condiciones y audiencias específicas, garantizando flexibilidad y comodidad. Con esta función, puede seleccionar el tipo de presentación (p. ej., presentada por un orador, explorada por un individuo o explorada en un quiosco), habilitar o deshabilitar el bucle, elegir diapositivas específicas para mostrar y usar los tiempos. Este paso en la preparación es crucial para que su presentación sea más efectiva y profesional.

`getSlideShowSettings` es un método de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) que devuelve un objeto de tipo [SlideShowSettings](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowsettings/), que le permite administrar la configuración de la presentación de diapositivas en una presentación de PowerPoint. En este artículo, exploraremos cómo usar este método para configurar y controlar varios aspectos de la configuración de la presentación de diapositivas. 

## **Seleccionar tipo de presentación**

`SlideShowSettings->setSlideShowType` define el tipo de presentación de diapositivas, que puede ser una instancia de las siguientes clases: [PresentedBySpeaker](https://reference.aspose.com/slides/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/php-java/aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/php-java/aspose.slides/browsedatkiosk/). Usar este método le permite adaptar la presentación a diferentes escenarios de uso, como quioscos automatizados o presentaciones manuales.

El siguiente ejemplo de código crea una nueva presentación y establece el tipo de presentación a "Explorada por un individuo" sin mostrar la barra de desplazamiento.
```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Habilitar opciones de presentación**

`SlideShowSettings->setLoop` determina si la presentación debe repetirse en bucle hasta que se detenga manualmente. Esto es útil para presentaciones automatizadas que deben ejecutarse continuamente. `SlideShowSettings->setShowNarration` determina si se deben reproducir narraciones de voz durante la presentación. Es útil para presentaciones automatizadas que contienen guía de voz para la audiencia. `SlideShowSettings->setShowAnimation` determina si se deben reproducir las animaciones añadidas a los objetos de diapositiva. Esto es útil para proporcionar el efecto visual completo de la presentación.

El siguiente ejemplo de código crea una nueva presentación y repite la presentación en bucle.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Seleccionar diapositivas para mostrar**

El método `SlideShowSettings->setSlides` le permite seleccionar un rango de diapositivas que se mostrarán durante la presentación. Esto es útil cuando necesita mostrar solo una parte de la presentación en vez de todas las diapositivas. El siguiente ejemplo de código crea una nueva presentación y establece el rango de diapositivas a mostrar desde la diapositiva `2` hasta la `9`.
```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Usar avance de diapositivas**

El método `SlideShowSettings->setUseTimings` le permite habilitar o deshabilitar el uso de tiempos preestablecidos para cada diapositiva. Esto es útil para mostrar automáticamente las diapositivas con duraciones de exhibición predefinidas. El siguiente ejemplo de código crea una nueva presentación y desactiva el uso de los tiempos.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Mostrar controles de medios**

El método `SlideShowSettings->setShowMediaControls` determina si los controles de medios (como reproducir, pausar y detener) deben mostrarse durante la presentación cuando se reproduce contenido multimedia (p. ej., video o audio). Esto es útil cuando desea dar al presentador control sobre la reproducción de medios durante la presentación.

El siguiente ejemplo de código crea una nueva presentación y habilita que se muestren los controles de medios.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **Preguntas frecuentes**

**¿Puedo guardar una presentación para que se abra directamente en modo de presentación de diapositivas?**

Sí. Guarde el archivo como PPSX o PPSM; estos formatos se inician directamente en modo de presentación de diapositivas al abrirse en PowerPoint. En Aspose.Slides, elija el formato de guardado correspondiente [durante la exportación](/slides/es/php-java/save-presentation/).

**¿Puedo excluir diapositivas individuales de la presentación sin eliminarlas del archivo?**

Sí. Marque una diapositiva como [oculta](https://reference.aspose.com/slides/php-java/aspose.slides/slide/sethidden/). Las diapositivas ocultas permanecen en la presentación pero no se muestran durante la presentación de diapositivas.

**¿Puede Aspose.Slides reproducir una presentación de diapositivas o controlar una presentación en vivo en pantalla?**

No. Aspose.Slides edita, analiza y convierte archivos de presentación; la reproducción real la maneja una aplicación de visualización como PowerPoint.