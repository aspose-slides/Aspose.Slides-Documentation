---
title: Administrar presentación de diapositivas en C++
linktitle: Presentación de diapositivas
type: docs
weight: 90
url: /es/cpp/manage-slide-show/
keywords:
- tipo de presentación
- presentado por el orador
- visualizado por individuo
- visualizado en kiosco
- opciones de presentación
- repetir continuamente
- presentación sin narración
- presentación sin animación
- color de lápiz
- presentar diapositivas
- presentación personalizada
- avanzar diapositivas
- manualmente
- usando temporizaciones
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo administrar presentaciones de diapositivas en Aspose.Slides para C++. Controle transiciones de diapositivas, temporizaciones y más en formatos PPT, PPTX y ODP con facilidad."
---

En Microsoft PowerPoint, la configuración de **Slide Show** es una herramienta clave para preparar y ofrecer presentaciones profesionales. Una de las funciones más importantes en esta sección es **Set Up Show**, que le permite adaptar su presentación a condiciones y audiencias específicas, garantizando flexibilidad y comodidad. Con esta función, puede seleccionar el tipo de presentación (por ejemplo, presentado por un orador, examinado por un individuo o examinado en un kiosco), habilitar o desactivar el bucle, elegir diapositivas específicas para mostrar y usar temporizaciones. Este paso en la preparación es crucial para que su presentación sea más eficaz y profesional.

`get_SlideShowSettings` es un método de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) que devuelve un objeto del tipo [SlideShowSettings](https://reference.aspose.com/slides/cpp/aspose.slides/slideshowsettings/), que le permite gestionar la configuración de la presentación de diapositivas en un archivo PowerPoint. En este artículo, exploraremos cómo usar este método para configurar y controlar varios aspectos de la configuración del espectáculo de diapositivas. 

## **Select Show Type**

`SlideShowSettings.set_SlideShowType` define el tipo de presentación de diapositivas, que puede ser una instancia de las siguientes clases: [PresentedBySpeaker](https://reference.aspose.com/slides/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cpp/aspose.slides/browsedbyindividual/), o [BrowsedAtKiosk](https://reference.aspose.com/slides/cpp/aspose.slides/browsedatkiosk/). Usar este método le permite adaptar la presentación a diferentes escenarios de uso, como kioscos automáticos o presentaciones manuales.

El ejemplo de código a continuación crea una nueva presentación y establece el tipo de espectáculo en "Browsed by an individual" sin mostrar la barra de desplazamiento.
```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Enable Show Options**

`SlideShowSettings.set_Loop` determina si la presentación de diapositivas debe repetirse en bucle hasta que se detenga manualmente. Esto es útil para presentaciones automatizadas que deben ejecutarse de forma continua. `SlideShowSettings.set_ShowNarration` determina si se deben reproducir narraciones de voz durante la presentación de diapositivas. Es útil para presentaciones automatizadas que contienen guías de voz para la audiencia. `SlideShowSettings.set_ShowAnimation` determina si se deben reproducir las animaciones añadidas a los objetos de la diapositiva. Esto es útil para proporcionar el efecto visual completo de la presentación.

El siguiente ejemplo de código crea una nueva presentación y hace que la presentación de diapositivas se reproduzca en bucle.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Select Slides to Show**

El método `SlideShowSettings.set_Slides` le permite seleccionar un rango de diapositivas que se mostrarán durante la presentación. Esto es útil cuando necesita mostrar solo una parte de la presentación en lugar de todas las diapositivas. El siguiente ejemplo de código crea una nueva presentación y establece el rango de diapositivas para mostrarse desde la diapositiva `2` hasta la `9`.
```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Use Advance Slides**

El método `SlideShowSettings.set_UseTimings` le permite habilitar o desactivar el uso de temporizaciones predefinidas para cada diapositiva. Esto es útil para mostrar diapositivas automáticamente con duraciones de exhibición predefinidas. El ejemplo de código a continuación crea una nueva presentación y desactiva el uso de temporizaciones.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Show Media Controls**

El método `SlideShowSettings.set_ShowMediaControls` determina si los controles multimedia (como reproducir, pausar y detener) deben mostrarse durante la presentación de diapositivas cuando se reproduce contenido multimedia (por ejemplo, vídeo o audio). Esto es útil cuando desea dar al presentador control sobre la reproducción de medios durante la presentación.

El siguiente ejemplo de código crea una nueva presentación y habilita la visualización de los controles multimedia.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**¿Puedo guardar una presentación para que se abra directamente en modo presentación?**

Sí. Guarde el archivo como PPSX o PPSM; estos formatos se inician directamente en modo presentación al abrirse en PowerPoint. En Aspose.Slides, elija el formato de guardado correspondiente [durante la exportación](/slides/es/cpp/save-presentation/).

**¿Puedo excluir diapositivas individuales del espectáculo sin eliminarlas del archivo?**

Sí. Marque una diapositiva como [hidden](https://reference.aspose.com/slides/cpp/aspose.slides/slide/set_hidden/). Las diapositivas ocultas permanecen en la presentación pero no se muestran durante la presentación de diapositivas.

**¿Aspose.Slides puede reproducir una presentación o controlar una presentación en vivo en pantalla?**

No. Aspose.Slides edita, analiza y convierte archivos de presentación; la reproducción real la gestiona una aplicación de visualización como PowerPoint.