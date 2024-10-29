---
title: Convertir PowerPoint a JPG
type: docs
weight: 60
url: /es/php-java/convert-powerpoint-to-jpg/
keywords: "Convertir PowerPoint a JPG, PPTX a JPEG, PPT a JPEG"
description: "Convertir PowerPoint a JPG: PPT a JPG, PPTX a JPG "
---

## **Acerca de la Conversión de PowerPoint a JPG**
Con [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) puedes convertir presentaciones PowerPoint PPT o PPTX a imágenes JPG. También es posible convertir PPT/PPTX a JPEG, PNG o SVG. Con estas características es fácil implementar tu propio visor de presentaciones, crear una miniatura para cada diapositiva. Esto puede ser útil si deseas proteger las diapositivas de presentación del copyright, demostrar la presentación en modo de solo lectura. Aspose.Slides permite convertir toda la presentación o una diapositiva en formatos de imagen. 

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte PowerPoint a imágenes JPG, puede que quieras probar estos convertidores en línea gratuitos: PowerPoint [PPTX a JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) y [PPT a JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX a JPG**
Aquí están los pasos para convertir PPT/PPTX a JPG:

1. Crea una instancia del tipo [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén el objeto de diapositiva del tipo [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) de la colección [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--).
3. Crea la miniatura de cada diapositiva y luego conviértela a JPG. [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) se utiliza para obtener una miniatura de una diapositiva, devuelve un objeto [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) como resultado. El método [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) debe ser llamado desde la diapositiva necesaria del tipo [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide), los escalas de la miniatura resultante se pasan al método.
4. Después de obtener la miniatura de la diapositiva, llama al método [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) desde el objeto de miniatura. Pasa el nombre del archivo resultante y el formato de imagen.

{{% alert color="primary" %}}

**Nota**: La conversión de PPT/PPTX a JPG difiere de la conversión a otros tipos en Aspose.Slides API. Para otros tipos, normalmente usas el método [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), pero aquí necesitas el método [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)).

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

## **Convertir PowerPoint PPT/PPTX a JPG con Dimensiones Personalizadas**
Para cambiar la dimensión de la miniatura resultante y la imagen JPG, puedes establecer los valores de *ScaleX* y *ScaleY* pasándolos a los métodos [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-):

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Define dimensiones
    $desiredX = 1200;
    $desiredY = 800;
    # Obtiene valores escalados de X y Y
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

## **Renderizar Comentarios al guardar Presentación como Imagen**
Aspose.Slides para PHP a través de Java proporciona una herramienta que te permite renderizar comentarios en las diapositivas de una presentación cuando conviertes esas diapositivas en imágenes. Este código PHP demuestra la operación:

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

{{% alert title="Consejo" color="primary" %}}

Aspose proporciona una [aplicación web de collage GRATIS](https://products.aspose.app/slides/collage). Usando este servicio en línea, puedes fusionar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid), y más. 

Usando los mismos principios descritos en este artículo, puedes convertir imágenes de un formato a otro. Para más información, consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Ver también**

Consulta otras opciones para convertir PPT/PPTX en imagen como:

- [Conversión de PPT/PPTX a SVG](/slides/es/php-java/render-a-slide-as-an-svg-image/).