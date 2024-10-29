---
title: Obtener el Fondo Completo de la Diapositiva de Presentación como una Imagen
type: docs
weight: 95
url: /es/php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositiva
- fondo
- fondo de diapositiva
- fondo a una imagen
- PowerPoint
- PPT
- PPTX
- presentación de PowerPoint
- Java
- Php
- Aspose.Slides para PHP a través de Java
---

En las presentaciones de PowerPoint, el fondo de la diapositiva puede consistir en muchos elementos. Además de la imagen establecida como el [fondo de la diapositiva](/slides/es/php-java/presentation-background/), el fondo final puede verse influenciado por el tema de la presentación, el esquema de colores y las formas colocadas en la diapositiva maestra y la diapositiva de diseño.

Aspose.Slides para PHP a través de Java no proporciona un método simple para extraer el fondo completo de la diapositiva de presentación como una imagen, pero puedes seguir los pasos a continuación para hacerlo:
1. Carga la presentación utilizando la clase [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/).
1. Obtén el tamaño de la diapositiva de la presentación.
1. Selecciona una diapositiva.
1. Crea una presentación temporal.
1. Establece el mismo tamaño de diapositiva en la presentación temporal.
1. Clona la diapositiva seleccionada en la presentación temporal.
1. Elimina las formas de la diapositiva clonada.
1. Convierte la diapositiva clonada en una imagen.

El siguiente ejemplo de código extrae el fondo completo de la diapositiva de presentación como una imagen.
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