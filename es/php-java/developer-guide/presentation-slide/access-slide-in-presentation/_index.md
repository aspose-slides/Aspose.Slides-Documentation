---
title: Acceder a la Diapositiva en la Presentación
type: docs
weight: 20
url: /php-java/access-slide-in-presentation/
keywords: "Acceder a la Presentación de PowerPoint, Acceder a la diapositiva, Editar propiedades de la diapositiva, Cambiar posición de la diapositiva, Establecer número de diapositiva, índice, ID, posición Java, Aspose.Slides"
description: "Acceder a la diapositiva de PowerPoint por índice, ID o posición. Editar propiedades de la diapositiva"
---

Aspose.Slides te permite acceder a las diapositivas de dos maneras: por índice y por ID.

## **Acceder a la Diapositiva por Índice**

Todas las diapositivas en una presentación están organizadas numéricamente según la posición de la diapositiva comenzando desde 0. La primera diapositiva es accesible a través del índice 0; la segunda diapositiva se accede a través del índice 1; etc.

La clase Presentation, que representa un archivo de presentación, expone todas las diapositivas como una colección de [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/) (colección de objetos [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/)). Este código PHP te muestra cómo acceder a una diapositiva a través de su índice:

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

## **Acceder a la Diapositiva por ID**

Cada diapositiva en una presentación tiene un ID único asociado. Puedes usar el método [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) (expuesto por la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)) para apuntar a ese ID. Este código PHP te muestra cómo proporcionar un ID de diapositiva válido y acceder a esa diapositiva a través del método [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-):

```php
  # Instancia un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("demo.pptx");
  try {
    # Obtiene un ID de diapositiva
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # Accede a la diapositiva a través de su ID
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **Cambiar la Posición de la Diapositiva**

Aspose.Slides te permite cambiar la posición de una diapositiva. Por ejemplo, puedes especificar que la primera diapositiva debe convertirse en la segunda diapositiva.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtén la referencia de la diapositiva (cuya posición deseas cambiar) a través de su índice.
1. Establece una nueva posición para la diapositiva a través de la propiedad [setSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/islide/#setSlideNumber-int-).
1. Guarda la presentación modificada.

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

La primera diapositiva se convirtió en la segunda; la segunda diapositiva se convirtió en la primera. Cuando cambias la posición de una diapositiva, otras diapositivas se ajustan automáticamente.

## **Establecer el Número de Diapositiva**

Usando la propiedad [setFirstSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (expuesta por la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)), puedes especificar un nuevo número para la primera diapositiva en una presentación. Esta operación hace que otros números de diapositiva sean recalculados.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtén el número de la diapositiva.
1. Establece el número de la diapositiva.
1. Guarda la presentación modificada.

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

Si prefieres omitir la primera diapositiva, puedes iniciar la numeración desde la segunda diapositiva (y ocultar la numeración para la primera diapositiva) de esta manera:

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # Establece el número para la primera diapositiva de la presentación
    $presentation->setFirstSlideNumber(0);
    # Muestra los números de las diapositivas para todas las diapositivas
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # Oculta el número de la diapositiva para la primera diapositiva
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # Guarda la presentación modificada
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```