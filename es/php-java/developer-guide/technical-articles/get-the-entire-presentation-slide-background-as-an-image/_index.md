---
title: Obtener todo el fondo de la diapositiva de una presentación como imagen
linktitle: Fondo completo de la diapositiva
type: docs
weight: 95
url: /es/php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- fondo de diapositiva
- fondo final
- extraer fondo
- fondo completo
- fondo a imagen
- fondo PPT
- fondo PPTX
- fondo ODP
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Extrae fondos completos de diapositivas como imágenes de presentaciones PowerPoint y OpenDocument usando Aspose.Slides para PHP a través de Java, optimizando flujos visuales."
---

## **Obtener todo el fondo de la diapositiva**

En las presentaciones de PowerPoint, el fondo de la diapositiva puede estar formado por muchos elementos. Además de la imagen establecida como el [fondo de la diapositiva](/slides/es/php-java/presentation-background/), el fondo final puede verse influido por el tema de la presentación, el esquema de colores y las formas situadas en la diapositiva maestra y en la diapositiva de diseño.

Aspose.Slides para PHP a través de Java no proporciona un método sencillo para extraer todo el fondo de la diapositiva de la presentación como imagen, pero puedes seguir los pasos a continuación para hacerlo:
1. Cargar la presentación usando la clase [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/).
1. Obtener el tamaño de la diapositiva de la presentación.
1. Seleccionar una diapositiva.
1. Crear una presentación temporal.
1. Establecer el mismo tamaño de diapositiva en la presentación temporal.
1. Clonar la diapositiva seleccionada en la presentación temporal.
1. Eliminar las formas de la diapositiva clonada.
1. Convertir la diapositiva clonada en una imagen.

El siguiente ejemplo de código extrae todo el fondo de la diapositiva de la presentación como una imagen.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```


## **FAQ**

**¿Se conservarán los degradados complejos, texturas o rellenos de imagen de una diapositiva maestra en la imagen de fondo resultante?**

Sí. Aspose.Slides renderiza los rellenos de degradado, imagen y textura definidos en la diapositiva, el diseño o la maestra. Si necesitas aislar el aspecto de las maestras heredadas, [establecer un fondo propio](/slides/es/php-java/presentation-background/) en la diapositiva actual antes de exportar.

**¿Puedo añadir una marca de agua a la imagen de fondo resultante antes de guardarla?**

Sí. Puedes [añadir una marca de agua](/slides/es/php-java/watermark/) como forma o imagen en una [copia de la diapositiva](/slides/es/php-java/clone-slides/) de trabajo (colocada detrás de otro contenido) y luego exportar. Esto te permite generar una imagen de fondo con la marca de agua incorporada.

**¿Puedo obtener el fondo de un diseño o maestra específicos sin vincularlo a una diapositiva existente?**

Sí. Accede a la maestra o diseño deseado, aplícalo a una [diapositiva temporal](/slides/es/php-java/clone-slides/) con el tamaño requerido y exporta esa diapositiva para obtener el fondo derivado de ese diseño o maestra.

**¿Existen limitaciones de licencia que afecten la exportación de imágenes?**

Las funciones de renderizado están completamente disponibles con una [licencia válida](/slides/es/php-java/licensing/). En modo de evaluación, la salida puede incluir limitaciones como una marca de agua. Activa la licencia una vez por proceso antes de ejecutar exportaciones por lotes.