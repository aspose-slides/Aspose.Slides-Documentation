---
title: Gestionar transiciones de diapositivas en presentaciones usando PHP
linktitle: Transición de diapositiva
type: docs
weight: 80
url: /es/php-java/slide-transition/
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
- PHP
- Aspose.Slides
description: "Descubra cómo personalizar las transiciones de diapositivas en Aspose.Slides para PHP mediante Java, con una guía paso a paso para presentaciones PowerPoint y OpenDocument."
---

## **Visión general**
{{% alert color="primary" %}} 

Aspose.Slides para PHP a través de Java también permite a los desarrolladores gestionar o personalizar los efectos de transición de diapositivas. En este tema, hablaremos sobre cómo controlar las transiciones de diapositivas con gran facilidad usando Aspose.Slides para PHP a través de Java.

{{% /alert %}} 

Para facilitar la comprensión, hemos demostrado el uso de Aspose.Slides para PHP a través de Java para gestionar transiciones de diapositivas simples. Los desarrolladores pueden no solo aplicar diferentes efectos de transición a las diapositivas, sino también personalizar el comportamiento de estos efectos.

## **Agregar transición de diapositiva**
Para crear un efecto de transición de diapositiva sencillo, siga los pasos a continuación:

1. Cree una instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) clase.
1. Aplique un tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides para PHP a través de Java mediante el enumerado TransitionType.
1. Escriba el archivo de presentación modificado.
```php
  # Instanciar la clase Presentation para cargar el archivo de presentación origen
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Aplicar la transición de tipo círculo en la diapositiva 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Aplicar la transición de tipo peine en la diapositiva 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Guardar la presentación en disco
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Agregar transición de diapositiva avanzada**
En la sección anterior, solo aplicamos un efecto de transición sencillo a la diapositiva. Ahora, para mejorar y controlar ese efecto simple, siga los pasos a continuación:

1. Cree una instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) clase.
1. Aplique un tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides para PHP a través de Java.
1. También puede establecer la transición para Avanzar al hacer clic, después de un periodo de tiempo específico o ambos.
1. Si la transición de diapositiva está habilitada para Avanzar al hacer clic, la transición solo avanzará cuando alguien haga clic con el ratón. Además, si se establece la propiedad Avanzar después de tiempo, la transición avanzará automáticamente tras transcurrir el tiempo especificado.
1. Escriba la presentación modificada como archivo de presentación.
```php
  # Instanciar la clase Presentation que representa un archivo de presentación
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Aplicar transición de tipo círculo en la diapositiva 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Establecer el tiempo de transición a 3 segundos
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Aplicar transición de tipo peine en la diapositiva 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Establecer el tiempo de transición a 5 segundos
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Aplicar transición de tipo zoom en la diapositiva 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Establecer el tiempo de transición a 7 segundos
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Guardar la presentación en disco
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Transición Morph**
{{% alert color="primary" %}} 

Aspose.Slides para PHP a través de Java ahora admite la [Morph Transition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/). Representan la nueva transición morph introducida en PowerPoint 2019.

{{% /alert %}} 

La transición Morph le permite animar un movimiento suave de una diapositiva a la siguiente. Este artículo describe el concepto y cómo usar la transición Morph. Para usarla eficazmente, necesitará dos diapositivas que compartan al menos un objeto. La forma más fácil es duplicar la diapositiva y luego mover el objeto en la segunda diapositiva a otro lugar.

El siguiente fragmento de código muestra cómo agregar una copia de la diapositiva con algo de texto a la presentación y establecer una transición de [morph type](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) en la segunda diapositiva.
```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Tipos de transición Morph**
Se ha añadido el nuevo enumerado [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType). Representa diferentes tipos de transición Morph de diapositiva.

El enumerado TransitionMorphType tiene tres miembros:

- ByObject: La transición Morph se realizará considerando las formas como objetos indivisibles.
- ByWord: La transición Morph se realizará transfiriendo el texto por palabras cuando sea posible.
- ByChar: La transición Morph se realizará transfiriendo el texto por caracteres cuando sea posible.

El siguiente fragmento de código muestra cómo establecer una transición Morph en una diapositiva y cambiar el tipo de morph:
```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Establecer efectos de transición**
Aspose.Slides para PHP a través de Java admite la configuración de efectos de transición como, desde negro, desde la izquierda, desde la derecha, etc. Para establecer el efecto de transición, siga los pasos a continuación:

- Cree una instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase.
- Obtenga la referencia de la diapositiva.
- Establezca el efecto de transición.
- Guarde la presentación como archivo [PPTX](https://docs.fileformat.com/presentation/pptx/) .

En el ejemplo que se muestra a continuación, hemos establecido los efectos de transición.
```php
  # Crear una instancia de la clase Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Establecer efecto
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Guardar la presentación en disco
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Preguntas frecuentes**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Establezca la [speed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setspeed/) de la transición mediante la configuración [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) (p. ej., lento/medio/rápido).

**¿Puedo adjuntar audio a una transición y hacer que se repita?**

Sí. Puede incrustar un sonido para la transición y controlar su comportamiento mediante configuraciones como modo de sonido y bucle (p. ej., [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundloop/), además de metadatos como [setSoundIsBuiltIn](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) y [setSoundName](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?**

Configure el tipo de transición deseado en la configuración de transición de cada diapositiva; las transiciones se almacenan por diapositiva, por lo que aplicar el mismo tipo a todas las diapositivas produce un resultado uniforme.

**¿Cómo puedo comprobar qué transición está establecida actualmente en una diapositiva?**

Inspeccione la [transition settings](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositiva y lea su [transition type](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/settype/); ese valor le indica exactamente qué efecto está aplicado.