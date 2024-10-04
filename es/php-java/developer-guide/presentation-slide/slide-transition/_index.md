---
title: Transición de Diapositivas
type: docs
weight: 80
url: /php-java/slide-transition/
keywords: "transición de diapositivas de PowerPoint, transición de morph"
description: "transición de diapositivas de PowerPoint, transición de morph de PowerPoint"
---


## **Descripción General**
{{% alert color="primary" %}} 

Aspose.Slides para PHP a través de Java también permite a los desarrolladores gestionar o personalizar los efectos de transición de las diapositivas. En este tema, discutiremos cómo controlar las transiciones de las diapositivas con gran facilidad utilizando Aspose.Slides para PHP a través de Java.

{{% /alert %}} 

Para facilitar la comprensión, hemos demostrado el uso de Aspose.Slides para PHP a través de Java para gestionar transiciones simples de diapositivas. Los desarrolladores no solo pueden aplicar diferentes efectos de transición en las diapositivas, sino también personalizar el comportamiento de esos efectos de transición.

## **Agregar Transición de Diapositiva**
Para crear un efecto de transición simple de diapositivas, sigue los pasos a continuación:

1. Crea una instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) clase.
1. Aplica un tipo de transición de diapositiva en la diapositiva de uno de los efectos de transición ofrecidos por Aspose.Slides para PHP a través de Java a través del enum TransitionType.
1. Escribe el archivo de presentación modificado.

```php
  # Instanciar la clase Presentation para cargar el archivo de presentación fuente
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Aplicar transición tipo círculo en la diapositiva 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Aplicar transición tipo comb en la diapositiva 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Escribir la presentación en disco
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Agregar Transición de Diapositiva Avanzada**
En la sección anterior, solo aplicamos un efecto de transición simple en la diapositiva. Ahora, para mejorar y controlar aún más ese efecto de transición simple, sigue los pasos a continuación:

1. Crea una instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) clase.
1. Aplica un tipo de transición de diapositiva en la diapositiva de uno de los efectos de transición ofrecidos por Aspose.Slides para PHP a través de Java.
1. También puedes establecer la transición para avanzar al hacer clic, después de un período de tiempo específico o ambos.
1. Si la transición de la diapositiva está habilitada para avanzar al hacer clic, la transición solo avanzará cuando alguien haga clic con el ratón. Además, si se establece la propiedad Avanzar Después del Tiempo, la transición avanzará automáticamente después de que haya pasado el tiempo de avance especificado.
1. Escribe la presentación modificada como un archivo de presentación.

```php
  # Instanciar la clase Presentation que representa un archivo de presentación
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Aplicar transición tipo círculo en la diapositiva 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Establecer el tiempo de transición de 3 segundos
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Aplicar transición tipo comb en la diapositiva 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Establecer el tiempo de transición de 5 segundos
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Aplicar transición tipo zoom en la diapositiva 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Establecer el tiempo de transición de 7 segundos
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Escribir la presentación en disco
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Transición Morph**
{{% alert color="primary" %}} 

Aspose.Slides para PHP a través de Java ahora soporta la [Transición Morph](https://reference.aspose.com/slides/php-java/aspose.slides/IMorphTransition). Representa una nueva transición morph introducida en PowerPoint 2019.

{{% /alert %}} 

La transición Morph permite animar un movimiento suave de una diapositiva a la siguiente. Este artículo describe el concepto y cómo usar la transición Morph. Para usar la transición Morph de manera efectiva, necesitarás tener dos diapositivas con al menos un objeto en común. La manera más fácil es duplicar la diapositiva y luego mover el objeto en la segunda diapositiva a un lugar diferente.

El siguiente fragmento de código te muestra cómo agregar un clon de la diapositiva con algo de texto a la presentación y establecer una transición de [tipo morph](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) a la segunda diapositiva.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Transición Morph en Presentaciones de PowerPoint");
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

## **Tipos de Transición Morph**
Se ha añadido un nuevo enum [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType). Representa diferentes tipos de transición de diaposa Morph.

El enum TransitionMorphType tiene tres miembros:

- ByObject: La transición Morph se realizará considerando las formas como objetos indivisibles.
- ByWord: La transición Morph se realizará transfiriendo el texto por palabras donde sea posible.
- ByChar: La transición Morph se realizará transfiriendo el texto por caracteres donde sea posible.

El siguiente fragmento de código te muestra cómo establecer la transición morph a una diapositiva y cambiar el tipo de morph:

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

## **Establecer Efectos de Transición**
Aspose.Slides para PHP a través de Java soporta establecer efectos de transición como, desde negro, desde la izquierda, desde la derecha, etc. Para establecer el Efecto de Transición, sigue los pasos a continuación:

- Crea una instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase.
- Obtén la referencia de la diapositiva.
- Establecer el efecto de transición.
- Escribe la presentación como un archivo [PPTX ](https://docs.fileformat.com/presentation/pptx/).

En el ejemplo dado a continuación, hemos establecido los efectos de transición.

```php
  # Crear una instancia de la clase Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Establecer efecto
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Escribir la presentación en disco
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```