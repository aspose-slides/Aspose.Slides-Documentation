---
title: Acceder a diapositivas de presentación en PHP
linktitle: Acceder a diapositiva
type: docs
weight: 20
url: /es/php-java/access-slide-in-presentation/
keywords:
- acceso a diapositiva
- índice de diapositiva
- id de diapositiva
- posición de diapositiva
- cambiar posición
- propiedades de diapositiva
- número de diapositiva
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Aprenda cómo acceder y gestionar diapositivas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para PHP a través de Java. Aumente la productividad con ejemplos de código."
---

Aspose.Slides permite acceder a diapositivas de dos maneras: por índice y por ID.

## **Acceder a una diapositiva por índice**

Todas las diapositivas de una presentación se disponen numéricamente según la posición, empezando por 0. La primera diapositiva es accesible mediante el índice 0; la segunda mediante el índice 1; etc.

La clase Presentation, que representa un archivo de presentación, expone todas las diapositivas como una colección [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/) (colección de objetos [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/)). Este código PHP muestra cómo acceder a una diapositiva mediante su índice:
```php
  # Instancia un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("demo.pptx");
  try {
    # Accede a una diapositiva usando su índice de diapositiva
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


## **Acceder a una diapositiva por ID**

Cada diapositiva de una presentación tiene un ID único asociado. Puede usar el método [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) (expuesto por la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)) para apuntar a ese ID. Este código PHP muestra cómo proporcionar un ID de diapositiva válido y acceder a esa diapositiva mediante el método [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-):
```php
  # Instancia un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("demo.pptx");
  try {
    # Obtiene el ID de una diapositiva
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # Accede a la diapositiva mediante su ID
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```


## **Cambiar la posición de la diapositiva**

Aspose.Slides permite cambiar la posición de una diapositiva. Por ejemplo, puede especificar que la primera diapositiva pase a ser la segunda.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtener la referencia de la diapositiva (cuya posición desea cambiar) a través de su índice.
1. Establecer una nueva posición para la diapositiva mediante la propiedad [setSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/islide/#setSlideNumber-int-).
1. Guardar la presentación modificada.

Este código PHP demuestra una operación en la que la diapositiva en la posición 1 se mueve a la posición 2:
```php
  # Instancia un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("Presentation.pptx");
  try {
    # Obtiene la diapositiva cuya posición será cambiada
    $sld = $pres->getSlides()->get_Item(0);
    # Establece la nueva posición para la diapositiva
    $sld->setSlideNumber(2);
    # Guarda la presentación modificada
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


La primera diapositiva pasó a ser la segunda; la segunda diapositiva pasó a ser la primera. Cuando cambia la posición de una diapositiva, las demás diapositivas se ajustan automáticamente.

## **Establecer el número de diapositiva**

Usando la propiedad [setFirstSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (expuesta por la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)), puede especificar un nuevo número para la primera diapositiva de una presentación. Esta operación hace que los demás números de diapositiva se recalculen.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtener el número de la diapositiva.
1. Establecer el número de la diapositiva.
1. Guardar la presentación modificada.

Este código PHP demuestra una operación donde el número de la primera diapositiva se establece en 10:
```php
  # Instancia un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # Obtiene el número de la diapositiva
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # Establece el número de la diapositiva
    $pres->setFirstSlideNumber(10);
    # Guarda la presentación modificada
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


Si prefiere omitir la primera diapositiva, puede iniciar la numeración a partir de la segunda diapositiva (y ocultar la numeración de la primera) de la siguiente manera:
```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # Establece el número para la primera diapositiva de la presentación
    $presentation->setFirstSlideNumber(0);
    # Muestra los números de diapositiva en todas las diapositivas
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # Oculta el número de diapositiva de la primera diapositiva
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # Guarda la presentación modificada
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿El número de diapositiva que ve el usuario coincide con el índice basado en cero de la colección?**

El número que se muestra en una diapositiva puede comenzar desde un valor arbitrario (por ejemplo, 10) y no tiene que coincidir con el índice; la relación se controla mediante la configuración del [first slide number](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/setfirstslidenumber/) de la presentación.

**¿Las diapositivas ocultas afectan la indexación?**

Sí. Una diapositiva oculta permanece en la colección y se cuenta en la indexación; “oculta” se refiere a la visualización, no a su posición en la colección.

**¿Cambia el índice de una diapositiva cuando se añaden o eliminan otras diapositivas?**

Sí. Los índices siempre reflejan el orden actual de las diapositivas y se recalculan al insertar, eliminar o mover diapositivas.