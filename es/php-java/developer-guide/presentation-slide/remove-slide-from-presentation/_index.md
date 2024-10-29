---
title: Eliminar Diapositiva de la Presentación
type: docs
weight: 30
url: /es/php-java/remove-slide-from-presentation/
keywords: "Eliminar diapositiva, Borrar diapositiva, PowerPoint, Presentación, Java, Aspose.Slides"
description: "Eliminar diapositiva de PowerPoint por referencia o índice"

---

Si una diapositiva (o su contenido) se vuelve redundante, puedes eliminarla. Aspose.Slides proporciona la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) que encapsula [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/), que es un repositorio para todas las diapositivas en una presentación. Usando punteros (referencia o índice) para un objeto [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/), puedes especificar la diapositiva que deseas eliminar.

## **Eliminar Diapositiva por Referencia**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtén una referencia de la diapositiva que deseas eliminar a través de su ID o índice.
1. Elimina la diapositiva referenciada de la presentación.
1. Guarda la presentación modificada.

Este código PHP te muestra cómo eliminar una diapositiva a través de su referencia:

```php
  # Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("demo.pptx");
  try {
    # Accede a una diapositiva a través de su índice en la colección de diapositivas
    $slide = $pres->getSlides()->get_Item(0);
    # Elimina una diapositiva a través de su referencia
    $pres->getSlides()->remove($slide);
    # Guarda la presentación modificada
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Eliminar Diapositiva por Índice**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Elimina la diapositiva de la presentación a través de su posición de índice.
1. Guarda la presentación modificada.

Este código PHP te muestra cómo eliminar una diapositiva a través de su índice:

```php
  # Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("demo.pptx");
  try {
    # Elimina una diapositiva a través de su índice de diapositiva
    $pres->getSlides()->removeAt(0);
    # Guarda la presentación modificada
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Eliminar Diapositiva de Diseño No Utilizada**

Aspose.Slides proporciona el método [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (de la clase [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) para permitirte eliminar diapositivas de diseño no deseadas y no utilizadas. Este código PHP te muestra cómo eliminar una diapositiva de diseño de una presentación de PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Eliminar Diapositiva Maestro No Utilizada**

Aspose.Slides proporciona el método [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (de la clase [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) para permitirte eliminar diapositivas maestro no deseadas y no utilizadas. Este código PHP te muestra cómo eliminar una diapositiva maestro de una presentación de PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```