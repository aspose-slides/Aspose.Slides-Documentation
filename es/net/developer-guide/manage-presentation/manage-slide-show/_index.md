---
title: Administrar presentación de diapositivas
type: docs
weight: 90
url: /es/net/manage-slide-show/
keywords:
- tipo de presentación
- presentado por un orador
- navegado por un individuo
- navegado en un quiosco
- opciones de presentación
- bucle continuo
- presentación sin narración
- presentación sin animación
- color del lápiz
- mostrar diapositivas
- presentación personalizada
- avanzar diapositivas
- manualmente
- usando sincronizaciones
- PowerPoint
- presentación
- C#
- .NET
- Aspose.Slides para .NET
description: "Administrar la configuración de la presentación de diapositivas en presentaciones de PowerPoint usando C#"
---

En Microsoft PowerPoint, la configuración de **Presentación de diapositivas** es una herramienta clave para preparar y entregar presentaciones profesionales. Una de las funciones más importantes en esta sección es **Configurar presentación**, que le permite adaptar su presentación a condiciones y audiencias específicas, garantizando flexibilidad y comodidad. Con esta función, puede seleccionar el tipo de presentación (p. ej., presentada por un orador, navegada por un individuo o navegada en un quiosco), habilitar o deshabilitar el bucle, elegir diapositivas específicas para mostrar y usar sincronizaciones. Este paso en la preparación es crucial para que su presentación sea más eficaz y profesional.

`SlideShowSettings` es una propiedad de la clase [Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation/) , de tipo [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/), que permite gestionar la configuración de la presentación en un archivo PowerPoint. En este artículo, exploraremos cómo usar esta propiedad para configurar y controlar varios aspectos de la presentación.

## **Seleccionar tipo de presentación**

`SlideShowSettings.SlideShowType` define el tipo de presentación, que puede ser una instancia de las siguientes clases: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). Usar esta propiedad le permite adaptar la presentación a diferentes escenarios de uso, como quioscos automatizados o presentaciones manuales.

El ejemplo de código a continuación crea una nueva presentación y establece el tipo de presentación en “Navegada por un individuo” sin mostrar la barra de desplazamiento.
```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Habilitar opciones de presentación**

`SlideShowSettings.Loop` determina si la presentación debe repetirse en bucle hasta que se detenga manualmente. Esto es útil para presentaciones automatizadas que necesitan ejecutarse de forma continua. `SlideShowSettings.ShowNarration` determina si las narraciones de voz deben reproducirse durante la presentación. Es útil para presentaciones automatizadas que contienen guías de voz para la audiencia. `SlideShowSettings.ShowAnimation` determina si las animaciones añadidas a los objetos de diapositiva deben reproducirse. Esto es útil para proporcionar el efecto visual completo de la presentación.

El siguiente ejemplo de código crea una nueva presentación y repite la presentación en bucle.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Seleccionar diapositivas para mostrar**

La propiedad `SlideShowSettings.Slides` le permite seleccionar un rango de diapositivas que se mostrarán durante la presentación. Esto es útil cuando necesita mostrar solo una parte de la presentación en lugar de todas las diapositivas. El siguiente ejemplo de código crea una nueva presentación y establece el rango de diapositivas para mostrarse desde la diapositiva `2` hasta la `9`.
```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Usar avance de diapositivas**

La propiedad `SlideShowSettings.UseTimings` le permite habilitar o deshabilitar el uso de sincronizaciones preestablecidas para cada diapositiva. Esto es útil para mostrar automáticamente diapositivas con duraciones de visualización definidas previamente. El ejemplo de código a continuación crea una nueva presentación y desactiva el uso de sincronizaciones.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Mostrar controles de medios**

La propiedad `SlideShowSettings.ShowMediaControls` determina si los controles de medios (como reproducir, pausar y detener) deben mostrarse durante la presentación cuando se reproduce contenido multimedia (p. ej., video o audio). Esto es útil cuando desea que el presentador controle la reproducción de los medios durante la presentación.

El siguiente ejemplo de código crea una nueva presentación y habilita la visualización de los controles de medios.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **FAQ**

**¿Puedo guardar una presentación para que se abra directamente en modo presentación?**

Sí. Guarde el archivo como PPSX o PPSM; estos formatos se inician directamente en modo presentación al abrirse en PowerPoint. En Aspose.Slides, elija el formato de guardado correspondiente [durante la exportación](/slides/es/net/save-presentation/).

**¿Puedo excluir diapositivas individuales de la presentación sin eliminarlas del archivo?**

Sí. Marque una diapositiva como [Oculta](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). Las diapositivas ocultas permanecen en la presentación pero no se muestran durante la presentación.

**¿Aspose.Slides puede reproducir una presentación o controlar una presentación en vivo en pantalla?**

No. Aspose.Slides edita, analiza y convierte archivos de presentación; la reproducción real la gestiona una aplicación de visor como PowerPoint.