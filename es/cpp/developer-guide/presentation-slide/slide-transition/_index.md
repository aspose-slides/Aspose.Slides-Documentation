---
title: Transición de Diapositivas
type: docs
weight: 80
url: /es/cpp/slide-transition/
keywords: "transición de diapositivas de PowerPoint, transición de morph"
description: "Transición de diapositivas de PowerPoint, transición de morph de PowerPoint con Aspose.Slides."
---


## **Agregar Transición de Diapositivas**
Para facilitar su comprensión, hemos demostrado el uso de Aspose.Slides para C++ para gestionar transiciones de diapositivas simples. Los desarrolladores no solo pueden aplicar diferentes efectos de transición de diapositivas, sino también personalizar el comportamiento de estos efectos de transición. Para crear un efecto de transición de diapositivas simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Aplique un tipo de transición de diapositivas sobre la diapositiva de uno de los efectos de transición ofrecidos por Aspose.Slides para C++ a través del enum TransitionType.
1. Escriba el archivo de presentación modificado.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **Agregar Transición de Diapositivas Avanzada**
En la sección anterior, solo aplicamos un efecto de transición simple en la diapositiva. Ahora, para mejorar y controlar aún más ese efecto de transición simple, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Aplique un tipo de transición de diapositivas sobre la diapositiva de uno de los efectos de transición ofrecidos por Aspose.Slides para C++.
1. También puede configurar la transición para avanzar al hacer clic, después de un período específico o ambos.
1. Si la transición de diapositivas está habilitada para avanzar al hacer clic, la transición solo avanzará cuando alguien haga clic con el ratón. Además, si se establece la propiedad Avanzar Después de el Tiempo, la transición avanzará automáticamente después de que haya transcurrido el tiempo de avance especificado.
1. Escriba la presentación modificada como un archivo de presentación.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}


## **Transición de Morph**
Aspose.Slides para C++ ahora admite la Transición de Morph. Representa una nueva transición de morph introducida en PowerPoint 2019. La transición de Morph le permite animar un movimiento suave de una diapositiva a la siguiente. Este artículo describe el concepto y cómo usar la transición de Morph. Para usar la transición de Morph de manera efectiva, necesitará tener dos diapositivas con al menos un objeto en común. La manera más fácil es duplicar la diapositiva y luego mover el objeto en la segunda diapositiva a un lugar diferente.

El siguiente fragmento de código le muestra cómo agregar un clon de la diapositiva con algo de texto a la presentación y establecer una transición de tipo morph a la segunda diapositiva.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Tipo de Transición de Morph**
Se ha agregado el nuevo enum Aspose.Slides.SlideShow.TransitionMorphType. Representa diferentes tipos de transición de diapositivas Morph.

El enum TransitionMorphType tiene tres miembros:

- ByObject: La transición de morph se realizará considerando las formas como objetos indivisibles.
- ByWord: La transición de morph se realizará transfiriendo texto por palabras cuando sea posible.
- ByChar: La transición de morph se realizará transfiriendo texto por caracteres cuando sea posible.

El siguiente fragmento de código le muestra cómo establecer la transición de morph en la diapositiva y cambiar el tipo de morph:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}


## **Establecer Efectos de Transición**
Aspose.Slides para C++ admite la configuración de efectos de transición como de negro, de la izquierda, de la derecha, etc. Para establecer el efecto de transición, siga los pasos a continuación:

- Cree una instancia de la clase Presentation.
- Obtenga una referencia de la diapositiva.
- Establezca el efecto de transición.
- Escriba la presentación como un archivo PPTX.

En el siguiente ejemplo, hemos establecido los efectos de transición.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}