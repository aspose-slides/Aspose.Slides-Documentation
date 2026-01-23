---
title: Convertir PPT y PPTX a JPG en PHP
linktitle: PowerPoint a JPG
type: docs
weight: 60
url: /es/php-java/convert-powerpoint-to-jpg/
keywords: 
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a JPG
- presentación a JPG
- diapositiva a JPG
- PPT a JPG
- PPTX a JPG
- guardar PowerPoint como JPG
- guardar presentación como JPG
- guardar diapositiva como JPG
- guardar PPT como JPG
- guardar PPTX como JPG
- exportar PPT a JPG
- exportar PPTX a JPG
- PHP
- Aspose.Slides
description: "Convertir diapositivas de PowerPoint (PPT, PPTX) a imágenes JPG de alta calidad en PHP con Aspose.Slides para PHP utilizando ejemplos de código rápidos y fiables."
---

## **Acerca de la conversión de PowerPoint a JPG**
Con [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) puedes convertir una presentación PowerPoint PPT o PPTX a una imagen JPG. También es posible convertir PPT/PPTX a JPEG, PNG o SVG. Con estas funciones es fácil implementar tu propio visor de presentaciones, crear la miniatura de cada diapositiva. Esto puede ser útil si deseas proteger las diapositivas de la presentación contra la copia, demostrar la presentación en modo solo lectura. Aspose.Slides permite convertir toda la presentación o una diapositiva determinada a formatos de imagen.

{{% alert color="primary" %}} 
Para ver cómo Aspose.Slides convierte PowerPoint a imágenes JPG, puedes probar estos conversores en línea gratuitos: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) y [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX a JPG**
A continuación se describen los pasos para convertir PPT/PPTX a JPG:

1. Crea una instancia del tipo [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén el objeto diapositiva del tipo [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) de la colección [Presentation::getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) .
3. Crea la miniatura de cada diapositiva y luego conviértela a JPG. El método [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) se utiliza para obtener una miniatura de una diapositiva. El método [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) debe llamarse desde la diapositiva necesaria del tipo [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) y las escalas de la miniatura resultante se pasan al método.
4. Después de obtener la miniatura de la diapositiva, llama al método [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) desde el objeto miniatura. Pasa a este método el nombre de archivo resultante y el formato de imagen.

{{% alert color="primary" %}}

**Nota**: La conversión de PPT/PPTX a JPG difiere de la conversión a otros tipos en la API de Aspose.Slides. Para otros tipos, normalmente se utiliza el método [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/), pero aquí se necesita el método [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)).
{{% /alert %}} 
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Crea una imagen a escala completa
      $slideImage = $sld->getImage(1.0, 1.0);
      # Guarda la imagen en disco en formato JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
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


## **Convertir PowerPoint PPT/PPTX a JPG con dimensiones personalizadas**
Para cambiar la dimensión de la miniatura y la imagen JPG resultantes, puedes establecer los valores *ScaleX* y *ScaleY* pasándolos a los métodos [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage):
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Define dimensiones
    $desiredX = 1200;
    $desiredY = 800;
    # Obtiene los valores escalados de X y Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Crea una imagen a escala completa
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # Guarda la imagen en disco en formato JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
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


## **Renderizar comentarios al guardar diapositivas como imágenes**
Aspose.Slides for PHP via Java ofrece una funcionalidad que permite renderizar los comentarios en las diapositivas de una presentación al convertir esas diapositivas en imágenes. Este código PHP muestra la operación:
```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
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


{{% alert title="Tip" color="primary" %}}

Aspose ofrece una [FREE Collage web app](https://products.aspose.app/slides/collage). Con este servicio en línea, puedes combinar imágenes [JPG to JPG](https://products.aspose.app/slides/collage/jpg) o PNG to PNG, crear [photo grids](https://products.aspose.app/slides/collage/photo-grid) y mucho más.

Usando los mismos principios descritos en este artículo, puedes convertir imágenes de un formato a otro. Para más información, consulta estas páginas: convertir [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); convertir [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); convertir [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), convertir [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); convertir [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), convertir [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**¿Este método admite la conversión por lotes?**

Sí, Aspose.Slides permite la conversión por lotes de múltiples diapositivas a JPG en una sola operación.

**¿La conversión admite SmartArt, gráficos y otros objetos complejos?**

Sí, Aspose.Slides renderiza todo el contenido, incluidos SmartArt, gráficos, tablas, formas y más. No obstante, la precisión del renderizado puede variar ligeramente respecto a PowerPoint, sobre todo al usar fuentes personalizadas o ausentes.

**¿Existen limitaciones en el número de diapositivas que se pueden procesar?**

Aspose.Slides no impone límites estrictos en la cantidad de diapositivas que puedes procesar. Sin embargo, podrías encontrar errores de falta de memoria al trabajar con presentaciones muy grandes o imágenes de alta resolución.

## **Ver también**

Consulta otras opciones para convertir PPT/PPTX a imagen, como:

- [PPT/PPTX to SVG conversion](/slides/es/php-java/render-a-slide-as-an-svg-image/)