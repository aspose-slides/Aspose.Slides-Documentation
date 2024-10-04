---
title: Renderizar una diapositiva como una imagen SVG
type: docs
weight: 50
url: /php-java/render-a-slide-as-an-svg-image/
---

SVG—un acrónimo de Gráficos Vectoriales Escalables—es un tipo de gráficos estándar o formato utilizado para renderizar imágenes bidimensionales. SVG almacena imágenes como vectores en XML con detalles que definen su comportamiento o apariencia.

SVG es uno de los pocos formatos de imágenes que cumple con estándares muy altos en estos términos: escalabilidad, interactividad, rendimiento, accesibilidad, programabilidad y otros. Por estas razones, se utiliza comúnmente en el desarrollo web.

Es posible que desee utilizar archivos SVG cuando necesite

- **imprimir su presentación en un *formato muy grande*.** Las imágenes SVG pueden escalar a cualquier resolución o nivel. Puede redimensionar imágenes SVG tantas veces como sea necesario sin sacrificar calidad.
- **utilizar gráficos y tablas de sus diapositivas en *diferentes medios o plataformas**.* La mayoría de los lectores pueden interpretar archivos SVG.
- **usar los *tamaños más pequeños posibles de imágenes***. Los archivos SVG son generalmente más pequeños que sus equivalentes de alta resolución en otros formatos, especialmente aquellos formatos basados en mapa de bits (JPEG o PNG).

Aspose.Slides para PHP a través de Java le permite exportar diapositivas en sus presentaciones como imágenes SVG. Siga estos pasos para generar imágenes SVG:

1. Cree una instancia de la clase Presentation.
2. Itere a través de todas las diapositivas en la presentación.
3. Escriba cada diapositiva en su propio archivo SVG a través de FileOutputStream.

{{% alert color="primary" %}} 

Es posible que desee probar nuestra [aplicación web gratuita](https://products.aspose.app/slides/conversion/ppt-to-svg) en la que implementamos la función de conversión de PPT a SVG de Aspose.Slides para PHP a través de Java.

{{% /alert %}} 

Este código de muestra le muestra cómo convertir PPT a SVG usando Aspose.Slides:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $fileStream = new Java("java.io.FileOutputStream", "slide-" . $index . ".svg");
      try {
        $slide->writeAsSvg($fileStream);
      } finally {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```