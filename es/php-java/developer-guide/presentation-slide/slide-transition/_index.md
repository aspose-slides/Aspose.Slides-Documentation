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
description: "Descubra cómo personalizar las transiciones de diapositivas en Aspose.Slides para PHP a través de Java, con una guía paso a paso para presentaciones de PowerPoint y OpenDocument."
---

## **Resumen**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java también permite a los desarrolladores gestionar o personalizar los efectos de transición de diapositivas. En este tema, hablaremos sobre cómo controlar las transiciones de diapositivas con gran facilidad usando Aspose.Slides for PHP via Java.

{{% /alert %}} 

Para facilitar la comprensión, hemos demostrado el uso de Aspose.Slides for PHP via Java para gestionar transiciones de diapositivas simples. Los desarrolladores pueden no solo aplicar diferentes efectos de transición a las diapositivas, sino también personalizar el comportamiento de estos efectos de transición.

## **Añadir transición de diapositiva**
Para crear un efecto de transición de diapositiva simple, sigue los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Aplica un tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides for PHP via Java mediante el enum TransitionType.
3. Escribe el archivo de presentación modificado.
```php
  # Instanciar la clase Presentation para cargar el archivo de presentación origen
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Aplicar transición tipo círculo en la diapositiva 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Aplicar transición tipo peine en la diapositiva 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Guardar la presentación en disco
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Añadir transición de diapositiva avanzada**
En la sección anterior, solo aplicamos un efecto de transición simple en la diapositiva. Ahora, para mejorar y controlar ese efecto de transición simple, sigue los pasos a continuación:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Aplica un tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides for PHP via Java.
3. También puedes configurar la transición para Avanzar al hacer clic, después de un período de tiempo específico o ambas.
4. Si la transición de diapositiva está configurada para Avanzar al hacer clic, la transición solo avanzará cuando alguien haga clic con el ratón. Además, si la propiedad Advance After Time está establecida, la transición avanzará automáticamente después de que haya transcurrido el tiempo especificado.
5. Escribe la presentación modificada como un archivo de presentación.
```php
  # Instanciar la clase Presentation que representa un archivo de presentación
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Aplicar transición tipo círculo en la diapositiva 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Establecer el tiempo de transición a 3 segundos
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Aplicar transición tipo peine en la diapositiva 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Establecer el tiempo de transición a 5 segundos
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Aplicar transición tipo zoom en la diapositiva 3
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

Aspose.Slides for PHP via Java ahora admite la [Transición Morph](https://reference.aspose.com/slides/php-java/aspose.slides/IMorphTransition). Representan la nueva transición morph introducida en PowerPoint 2019.

{{% /alert %}} 

La transición Morph permite animar un movimiento suave de una diapositiva a la siguiente. Este artículo describe el concepto y cómo usar la transición Morph. Para usar la transición Morph de manera eficaz, necesitarás dos diapositivas con al menos un objeto en común. La forma más sencilla es duplicar la diapositiva y luego mover el objeto en la segunda diapositiva a otro lugar.

El siguiente fragmento de código muestra cómo añadir un clon de la diapositiva con algún texto a la presentación y establecer una transición de [tipo morph](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) en la segunda diapositiva.
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
Se ha añadido el nuevo enumerado [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType). Representa diferentes tipos de transición de diapositiva Morph.

El enum TransitionMorphType tiene tres miembros:

- ByObject: La transición Morph se realizará considerando las formas como objetos indivisibles.
- ByWord: La transición Morph se realizará transfiriendo el texto por palabras cuando sea posible.
- ByChar: La transición Morph se realizará transfiriendo el texto por caracteres cuando sea posible.

El siguiente fragmento de código muestra cómo establecer la transición morph en una diapositiva y cambiar el tipo de morph:
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
Aspose.Slides for PHP via Java permite establecer efectos de transición, como desde negro, desde la izquierda, desde la derecha, etc. Para establecer el efecto de transición, sigue los pasos a continuación:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Obtén la referencia de la diapositiva.
- Establece el efecto de transición.
- Guarda la presentación como un archivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

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


## **FAQ**

**¿Puedo controlar la velocidad de reproducción de una transición de diapositiva?**

Sí. Establece la [velocidad](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setspeed/) de la transición usando la configuración [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) (p. ej., lenta/media/rápida).

**¿Puedo adjuntar audio a una transición y hacer que se repita?**

Sí. Puedes incrustar un sonido para la transición y controlar su comportamiento mediante ajustes como modo de sonido y bucle (p. ej., [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundloop/), además de metadatos como [setSoundIsBuiltIn](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) y [setSoundName](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**¿Cuál es la forma más rápida de aplicar la misma transición a todas las diapositivas?**

Configura el tipo de transición deseado en la configuración de transición de cada diapositiva; las transiciones se almacenan por diapositiva, por lo que aplicar el mismo tipo a todas las diapositivas produce un resultado consistente.

**¿Cómo puedo comprobar qué transición está configurada actualmente en una diapositiva?**

Inspecciona la [configuración de transición](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositiva y lee su [tipo de transición](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/settype/); ese valor indica exactamente qué efecto está aplicado.