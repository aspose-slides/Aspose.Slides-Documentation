---
title: Convertir diapositivas de PowerPoint a PNG en PHP
linktitle: PowerPoint a PNG
type: docs
weight: 30
url: /es/php-java/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a PNG
- presentación a PNG
- diapositiva a PNG
- PPT a PNG
- PPTX a PNG
- guardar PPT como PNG
- guardar PPTX como PNG
- exportar PPT a PNG
- exportar PPTX a PNG
- PHP
- Aspose.Slides
description: "Convierta presentaciones de PowerPoint a imágenes PNG de alta calidad rápidamente con Aspose.Slides para PHP a través de Java, garantizando resultados precisos y automatizados."
---

## **Acerca de la conversión de PowerPoint a PNG**

El formato PNG (Portable Network Graphics) no es tan popular como JPEG (Joint Photographic Experts Group), pero sigue siendo muy popular. 

**Caso de uso:** Cuando tienes una imagen compleja y el tamaño no es un problema, PNG es un formato de imagen mejor que JPEG. 

{{% alert title="Tip" color="primary" %}} Puede que quieras consultar los convertidores gratuitos de **PowerPoint a PNG** de Aspose: [PPTX a PNG](https://products.aspose.app/slides/conversion/pptx-to-png) y [PPT a PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Son una implementación en vivo del proceso descrito en esta página. {{% /alert %}}

## **Convertir PowerPoint a PNG**

Sigue estos pasos:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtener el objeto diapositiva de la colección [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) bajo la interfaz [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide).
3. Utilizar el método [ISlide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) para obtener la miniatura de cada diapositiva.
4. Utilizar el método [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) para guardar la miniatura de la diapositiva en formato PNG.

Este código PHP muestra cómo convertir una presentación PowerPoint a PNG:
```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
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


## **Convertir PowerPoint a PNG con dimensiones personalizadas**

Si deseas obtener archivos PNG con una cierta escala, puedes establecer los valores de `desiredX` y `desiredY`, que determinan las dimensiones de la miniatura resultante. 

Este código demuestra la operación descrita:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
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


## **Convertir PowerPoint a PNG con tamaño personalizado**

Si deseas obtener archivos PNG con un cierto tamaño, puedes pasar tus argumentos preferidos `width` y `height` para `ImageSize`. 

Este código muestra cómo convertir un PowerPoint a PNG especificando el tamaño de las imágenes: 
```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
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


## **Preguntas frecuentes**

**¿Cómo puedo exportar solo una forma específica (p. ej., gráfico o imagen) en lugar de toda la diapositiva?**

Aspose.Slides soporta [la generación de miniaturas para formas individuales](/slides/es/php-java/create-shape-thumbnails/); puedes renderizar una forma a una imagen PNG.

**¿Se admite la conversión paralela en un servidor?**

Sí, pero [no compartas](/slides/es/php-java/multithreading/) una única instancia de presentación entre hilos. Usa una instancia separada por hilo o proceso.

**¿Cuáles son las limitaciones de la versión de prueba al exportar a PNG?**

El modo de evaluación agrega una marca de agua a las imágenes de salida y aplica [otras restricciones](/slides/es/php-java/licensing/) hasta que se aplique una licencia.