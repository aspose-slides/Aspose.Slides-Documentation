---
title: Gestionar transiciones de diapositivas en presentaciones usando C++
linktitle: Transición de diapositiva
type: docs
weight: 80
url: /es/cpp/slide-transition/
keywords:
- transición de diapositiva
- añadir transición de diapositiva
- aplicar transición de diapositiva
- transición de diapositiva avanzada
- transición morph
- tipo de transición
- efecto de transición
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Descubra cómo personalizar las transiciones de diapositivas en Aspose.Slides para C++, con guía paso a paso para presentaciones PowerPoint y OpenDocument."
---

## **Agregar transición de diapositiva**
Para facilitar la comprensión, hemos demostrado el uso de Aspose.Slides para C++ para administrar transiciones de diapositiva simples. Los desarrolladores pueden no solo aplicar diferentes efectos de transición de diapositiva en las diapositivas, sino también personalizar el comportamiento de estos efectos de transición. Para crear un efecto de transición de diapositiva simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
1. Applique un tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides para C++ mediante el enum TransitionType.
1. Guarde el archivo de presentación modificado.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Agregar transición de diapositiva avanzada**
En la sección anterior, solo aplicamos un efecto de transición simple en la diapositiva. Ahora, para mejorar y controlar ese efecto de transición simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
1. Applique un tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides para C++
1. También puede establecer la transición para Avanzar al hacer clic, después de un período de tiempo específico o ambas cosas.
1. Si la transición de diapositiva está habilitada para Avanzar al hacer clic, la transición solo avanzará cuando alguien haga clic con el mouse. Además, si se establece la propiedad Avanzar después del tiempo, la transición avanzará automáticamente después de que haya transcurrido el tiempo de avance especificado.
1. Guarde la presentación modificada como un archivo de presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Transición Morph**
Aspose.Slides para C++ ahora admite la transición Morph. Representan la nueva transición morph introducida en PowerPoint 2019. La transición Morph le permite animar un movimiento suave de una diapositiva a la siguiente. Este artículo describe el concepto y cómo usar la transición Morph. Para usar la transición Morph de manera eficaz, necesitará dos diapositivas con al menos un objeto en común. La forma más sencilla es duplicar la diapositiva y luego mover el objeto en la segunda diapositiva a una posición diferente.

El siguiente fragmento de código le muestra cómo agregar un clon de la diapositiva con algo de texto a la presentación y establecer una transición de tipo morph en la segunda diapositiva.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Tipos de transición Morph**
Se ha añadido un nuevo enum Aspose.Slides.SlideShow.TransitionMorphType. Representa diferentes tipos de transición de diapositiva Morph.

El enum TransitionMorphType tiene tres miembros:

- ByObject: la transición Morph se realizará considerando las formas como objetos indivisibles.
- ByWord: la transición Morph se realizará transfiriendo el texto por palabras cuando sea posible.
- ByChar: la transición Morph se realizará transfiriendo el texto por caracteres cuando sea posible.

El siguiente fragmento de código le muestra cómo establecer la transición morph en una diapositiva y cambiar el tipo de morph:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **Establecer efectos de transición**
Aspose.Slides para C++ admite la configuración de efectos de transición, como desde negro, desde la izquierda, desde la derecha, etc. Para establecer el efecto de transición, siga los pasos a continuación:

- Cree una instancia de la clase Presentation.
- Obtenga una referencia a la diapositiva.
- Establezca el efecto de transición.
- Guarde la presentación como archivo PPTX.

En el ejemplo a continuación, hemos establecido los efectos de transición.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Establezca la [velocidad](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) de la transición usando la configuración [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) (por ejemplo, lento/medio/rápido).

**¿Puedo adjuntar audio a una transición y hacer que se repita?**

Sí. Puede incrustar un sonido para la transición y controlar su comportamiento mediante configuraciones como modo de sonido y bucle (por ejemplo, [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), además de metadatos como [set_SoundIsBuiltIn](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) y [set_SoundName](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)).

**¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?**

Configure el tipo de transición deseado en la configuración de transición de cada diapositiva; las transiciones se almacenan por diapositiva, por lo que aplicar el mismo tipo en todas las diapositivas produce un resultado consistente.

**¿Cómo puedo verificar qué transición está configurada actualmente en una diapositiva?**

Inspeccione la [configuración de transición](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_slideshowtransition/) de la diapositiva y lea su [tipo de transición](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/slideshowtransition/get_type/); ese valor le indica exactamente qué efecto está aplicado.