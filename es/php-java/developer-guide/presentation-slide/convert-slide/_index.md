---
title: Convertir Diapositiva
type: docs
weight: 35
url: /php-java/convert-slide/
keywords: 
- convertir diapositiva a imagen
- exportar diapositiva como imagen
- guardar diapositiva como imagen
- diapositiva a imagen
- diapositiva a PNG
- diapositiva a JPEG
- diapositiva a mapa de bits
- PHP
- Aspose.Slides para PHP a través de Java
description: "Convertir diapositiva de PowerPoint a imagen (Mapa de bits, PNG o JPG) en PHP"
---

Aspose.Slides para PHP a través de Java te permite convertir diapositivas (en presentaciones) a imágenes. Estos son los formatos de imagen admitidos: BMP, PNG, JPG (JPEG), GIF y otros.

Para convertir una diapositiva a una imagen, haz lo siguiente: 

1. Primero, establece los parámetros de conversión y los objetos de diapositiva a convertir usando:
   * la interfaz [ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) o
   * la interfaz [IRenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IRenderingOptions). 

2. Segundo, convierte la diapositiva a una imagen utilizando el método [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-). 

## **Acerca del Mapa de Bits y Otros Formatos de Imagen**

En Java, un [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) es un objeto que te permite trabajar con imágenes definidas por datos de píxeles. Puedes usar una instancia de esta clase para guardar imágenes en una amplia gama de formatos (JPG, PNG, etc.).

{{% alert title="Info" color="info" %}}

Aspose desarrolló recientemente un convertidor en línea de [Texto a GIF](https://products.aspose.app/slides/text-to-gif). 

{{% /alert %}}

## **Convirtiendo Diapositivas a Mapa de Bits y Guardando las Imágenes en PNG**

Este código PHP te muestra cómo convertir la primera diapositiva de una presentación a un objeto de mapa de bits y luego cómo guardar la imagen en formato PNG:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Convierte la primera diapositiva en la presentación a un objeto Images
    $slideImage = $pres->getSlides()->get_Item(0)->getImage();
    # Guarda la imagen en formato PNG
    try {
      # guarda la imagen en el disco.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
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

Este código de muestra te muestra cómo convertir la primera diapositiva de una presentación a un objeto de mapa de bits utilizando el método [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-):

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Obtiene el tamaño de la diapositiva de la presentación
    $slideSize = new Java("java.awt.Dimension", $slideSize->getWidth(), $slideSize->getHeight());
    # Crea un Images con el tamaño de la diapositiva
    $slideImage = $sld->getImage(new RenderingOptions(), $slideSize);
    try {
      # guarda la imagen en el disco.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
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

{{% alert title="Consejo" color="primary" %}} 

Puedes convertir una diapositiva a un objeto Images y luego usar el objeto directamente en algún lugar. O puedes convertir una diapositiva en una Images y luego guardar la imagen en JPEG o cualquier otro formato que prefieras.

{{% /alert %}}  

## **Convirtiendo Diapositivas a Imágenes con Tamaños Personalizados**

Puede que necesites obtener una imagen de un tamaño específico. Usando una sobrecarga del método [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-) puedes convertir una diapositiva en una imagen con dimensiones específicas (largo y ancho).

Este código de muestra demuestra la conversión propuesta utilizando el método [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-):

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Convierte la primera diapositiva en la presentación a un Bitmap con el tamaño especificado
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 1820, 1040));
    # Guarda la imagen en formato JPEG
    try {
      # guarda la imagen en el disco.
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
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

## **Convirtiendo Diapositivas con Notas y Comentarios a Imágenes**

Algunas diapositivas contienen notas y comentarios. 

Aspose.Slides proporciona dos interfaces—[ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) y [IRenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IRenderingOptions)—que te permiten controlar el renderizado de las diapositivas de presentación a imágenes. Ambas interfaces albergan la interfaz [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions) que te permite agregar notas y comentarios en una diapositiva cuando estás convirtiendo esa diapositiva a una imagen.

{{% alert title="Info" color="info" %}} 

Con la interfaz [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions), puedes especificar tu posición preferida para notas y comentarios en la imagen resultante.

{{% /alert %}} 

Este código PHP demuestra el proceso de conversión para una diapositiva con notas y comentarios:

```php
  $pres = new Presentation("PresentationNotesComments.pptx");
  try {
    # Crea las opciones de renderizado
    $options = new RenderingOptions();
    # Establece la posición de las notas en la página
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # Establece la posición de los comentarios en la página
    $options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);
    # Establece el ancho del área de salida de comentarios
    $options->getNotesCommentsLayouting()->setCommentsAreaWidth(500);
    # Establece el color para el área de comentarios
    $options->getNotesCommentsLayouting()->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);
    # Convierte la primera diapositiva de la presentación a un objeto Bitmap
    $slideImage = $pres->getSlides()->get_Item(0)->getImage($options, 2.0, 2.0);
    # Guarda la imagen en formato GIF
    try {
      $slideImage->save("Slide_Notes_Comments_0.gif", ImageFormat::Gif);
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

Este código PHP demuestra el proceso de conversión para una diapositiva con notas utilizando el método [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-):

```php
  $pres = new Presentation("PresentationNotes.pptx");
  try {
    # Obtiene el tamaño de las notas de la presentación
    $notesSize = $pres->getNotesSize()->getSize();
    # Crea las opciones de renderizado
    $options = new RenderingOptions();
    # Establece la posición de las notas
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # Crea un Images con el tamaño de las notas
    $slideImage = $pres->getSlides()->get_Item(0)->getImage($options, $notesSize);
    # Guarda la imagen en formato PNG
    try {
      # guarda la imagen en el disco.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
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

{{% alert title="Nota" color="warning" %}} 

En cualquier proceso de conversión de diapositiva a imagen, la propiedad [NotesPositions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) no puede ser establecida en BottomFull (para especificar la posición de las notas) porque el texto de una nota puede ser grande, lo que significa que podría no caber en el tamaño de imagen especificado.

{{% /alert %}} 

## **Convirtiendo Diapositivas a Imágenes Usando ITiffOptions**

La interfaz [ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) te da más control (en términos de parámetros) sobre la imagen resultante. Usando esta interfaz, puedes especificar el tamaño, la resolución, la paleta de colores y otros parámetros para la imagen resultante.

Este código PHP demuestra un proceso de conversión donde se utilizan ITiffOptions para producir una imagen en blanco y negro con una resolución de 300dpi y un tamaño de 2160 × 2800:

```php
  $pres = new Presentation("PresentationNotesComments.pptx");
  try {
    # Obtiene una diapositiva por su índice
    $slide = $pres->getSlides()->get_Item(0);
    # Crea un objeto TiffOptions
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));
    # Establece la fuente utilizada en caso de que no se encuentre la fuente de origen
    $options->setDefaultRegularFont("Arial Black");
    # Establece la posición de las notas en la página
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # Establece el formato de píxeles (blanco y negro)
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);
    # Establece la resolución
    $options->setDpiX(300);
    $options->setDpiY(300);
    # Convierte la diapositiva a un objeto Bitmap
    $slideImage = $slide->getImage($options);
    # Guarda la imagen en formato TIFF
    try {
      $slideImage->save("PresentationNotesComments.tiff", ImageFormat::Tiff);
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

{{% alert title="Nota" color="warning" %}} 

El soporte para Tiff no está garantizado en versiones anteriores a JDK 9.

{{% /alert %}} 

## **Convirtiendo Todas las Diapositivas a Imágenes**

Aspose.Slides te permite convertir todas las diapositivas en una sola presentación a imágenes. Esencialmente, puedes convertir la presentación (en su totalidad) a imágenes. 

Este código de muestra te muestra cómo convertir todas las diapositivas en una presentación a imágenes:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Renderiza la presentación a un array de imágenes diapositiva por diapositiva
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      # Controla las diapositivas ocultas (no renderiza diapositivas ocultas)
      if ($pres->getSlides()->get_Item($i)->getHidden()) {
        continue;
      }
      # Convierte la diapositiva a un objeto Bitmap
      $slideImage = $pres->getSlides()->get_Item($i)->getImage(2.0, 2.0);
      # Guarda la imagen en formato PNG
      try {
        $slideImage->save("Slide_" . $i . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```