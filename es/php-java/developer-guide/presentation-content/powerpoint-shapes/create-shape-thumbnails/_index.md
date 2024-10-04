---
title: Crear miniaturas de formas
type: docs
weight: 70
url: /php-java/create-shape-thumbnails/
---


## **Descripción general**
{{% alert color="primary" %}} 

Aspose.Slides para PHP a través de Java se puede usar para crear archivos de presentación en los que cada página corresponde a una diapositiva. Las diapositivas se pueden ver abriendo los archivos de presentación con Microsoft PowerPoint. Sin embargo, a veces los desarrolladores necesitan ver las imágenes de las formas por separado en un visor de imágenes. En tales casos, Aspose.Slides para PHP a través de Java les ayuda a generar imágenes en miniatura de las formas de las diapositivas.

{{% /alert %}} 

En este tema, mostraremos cómo generar miniaturas de diapositivas en diferentes situaciones:

- Generar una miniatura de forma dentro de una diapositiva.
- Generar una miniatura de forma para una forma de diapositiva con dimensiones definidas por el usuario.
- Generar una miniatura de forma en los límites de la apariencia de una forma.

## **Generar miniaturas de formas de diapositivas**
Para generar una miniatura de forma de cualquier diapositiva usando Aspose.Slides para PHP a través de Java, haga esto:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. [Obtenga la imagen en miniatura de la forma](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage--) de la diapositiva referenciada en la escala predeterminada.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este código de muestra le muestra cómo generar una miniatura de forma de una diapositiva:

```php
  # Instanciar una clase Presentation que representa el archivo de presentación
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Crear una imagen a escala completa
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Guardar la imagen en disco en formato PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Generar miniaturas de formas con un factor de escala definido por el usuario**
Para generar la miniatura de forma de una diapositiva usando Aspose.Slides para PHP a través de Java, haga esto:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. [Obtenga la imagen en miniatura de la forma](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage-int-float-float-) de la diapositiva referenciada con dimensiones definidas por el usuario.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este código de muestra le muestra cómo generar una miniatura de forma basada en un factor de escala definido:

```php
  # Instanciar una clase Presentation que representa el archivo de presentación
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Crear una imagen a escala completa
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Guardar la imagen en disco en formato PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Generar miniatura de forma de los límites**
Este método de creación de miniaturas de formas permite a los desarrolladores generar una miniatura en los límites de la apariencia de la forma. Tiene en cuenta todos los efectos de la forma. La miniatura de forma generada está restringida por los límites de la diapositiva. Para generar una miniatura de una forma de diapositiva en el límite de su apariencia, haga esto:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Obtenga la referencia de cualquier diapositiva usando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con los límites de la forma como apariencia.
1. Guarde la imagen en miniatura en el formato de imagen que prefiera.

Este código de muestra se basa en los pasos anteriores:

```php
  # Instanciar una clase Presentation que representa el archivo de presentación
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Crear una imagen a escala completa
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Guardar la imagen en disco en formato PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```