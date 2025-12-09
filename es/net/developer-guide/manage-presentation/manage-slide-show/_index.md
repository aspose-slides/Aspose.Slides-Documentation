---
title: Gestionar la presentación de diapositivas en .NET
linktitle: Presentación
type: docs
weight: 90
url: /es/net/manage-slide-show/
keywords:
- tipo de presentación
- presentado por el orador
- navegado por individuo
- navegado en kiosco
- opciones de presentación
- repetir continuamente
- presentar sin narración
- presentar sin animación
- color del lápiz
- mostrar diapositivas
- presentación personalizada
- avanzar diapositivas
- manualmente
- usando tiempos
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo gestionar presentaciones de diapositivas en Aspose.Slides para .NET. Controle transiciones de diapositivas, tiempos y más en los formatos PPT, PPTX y ODP con facilidad."
---

En Microsoft PowerPoint, la configuración de **Presentación** es una herramienta clave para preparar y ofrecer presentaciones profesionales. Una de las características más importantes de esta sección es **Configurar presentación**, que le permite adaptar su presentación a condiciones y audiencias específicas, garantizando flexibilidad y comodidad. Con esta función, puede seleccionar el tipo de presentación (p. ej., presentada por un orador, navegada por una persona o en modo quiosco), habilitar o deshabilitar el bucle, elegir diapositivas específicas para mostrar y usar cronometraje. Este paso de preparación es fundamental para que su presentación sea más eficaz y profesional.

`SlideShowSettings` es una propiedad de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) , de tipo [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/) , que le permite administrar la configuración de la presentación en una presentación de PowerPoint. En este artículo, exploraremos cómo usar esta propiedad para configurar y controlar varios aspectos de la configuración de la presentación. 

## **Seleccionar tipo de presentación**

`SlideShowSettings.SlideShowType` define el tipo de presentación, que puede ser una instancia de las siguientes clases: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/) , [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/) o [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/) . Usar esta propiedad le permite adaptar la presentación a diferentes escenarios de uso, como quioscos automatizados o presentaciones manuales.

El ejemplo de código a continuación crea una nueva presentación y establece el tipo de presentación en "Navegada por una persona" sin mostrar la barra de desplazamiento.
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

`SlideShowSettings.Loop` determina si la presentación debe repetirse en bucle hasta que se detenga manualmente. Esto es útil para presentaciones automatizadas que deben ejecutarse continuamente. `SlideShowSettings.ShowNarration` determina si se deben reproducir narraciones de voz durante la presentación. Es útil para presentaciones automatizadas que incluyen guía de voz para la audiencia. `SlideShowSettings.ShowAnimation` determina si se deben reproducir las animaciones añadidas a los objetos de la diapositiva. Esto es útil para proporcionar el efecto visual completo de la presentación.

El siguiente ejemplo de código crea una nueva presentación y reproduce la presentación en bucle.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Seleccionar diapositivas para mostrar**

La propiedad `SlideShowSettings.Slides` le permite seleccionar un rango de diapositivas que se mostrarán durante la presentación. Esto es útil cuando necesita mostrar solo una parte de la presentación en lugar de todas las diapositivas. El siguiente ejemplo de código crea una nueva presentación y define el rango de diapositivas para mostrar desde la diapositiva `2` hasta la `9`.
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

La propiedad `SlideShowSettings.UseTimings` le permite habilitar o deshabilitar el uso de tiempos predefinidos para cada diapositiva. Esto es útil para mostrar automáticamente diapositivas con duraciones de visualización predefinidas. El ejemplo de código a continuación crea una nueva presentación y deshabilita el uso de los tiempos.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Mostrar controles de medios**

La propiedad `SlideShowSettings.ShowMediaControls` determina si se deben mostrar los controles de medios (como reproducir, pausar y detener) durante la presentación cuando se reproduce contenido multimedia (p. ej., video o audio). Esto es útil cuando desea que el presentador controle la reproducción de los medios durante la presentación.

El siguiente ejemplo de código crea una nueva presentación y habilita la visualización de los controles de medios.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **Preguntas frecuentes**

**¿Puedo guardar una presentación para que se abra directamente en modo presentación?**

Sí. Guarde el archivo como PPSX o PPSM; estos formatos se inician directamente en modo presentación al abrirse en PowerPoint. En Aspose.Slides, elija el formato de guardado correspondiente [during export](/slides/es/net/save-presentation/).

**¿Puedo excluir diapositivas individuales de la presentación sin eliminarlas del archivo?**

Sí. Marque una diapositiva como [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) . Las diapositivas ocultas permanecen en la presentación pero no se muestran durante la presentación.

**¿Aspose.Slides puede reproducir una presentación o controlar una presentación en vivo en pantalla?**

No. Aspose.Slides edita, analiza y convierte archivos de presentación; la reproducción real la realiza una aplicación de visualización como PowerPoint.