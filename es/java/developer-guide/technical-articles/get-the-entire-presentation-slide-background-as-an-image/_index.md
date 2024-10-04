---
title: Obtener el Fondo Completo de la Diapositiva de Presentación como una Imagen
type: docs
weight: 95
url: /java/get-the-entire-presentation-slide-background-as-an-image/
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
- Aspose.Slides para Java
---

En las presentaciones de PowerPoint, el fondo de la diapositiva puede consistir en muchos elementos. Además de la imagen configurada como el [fondo de la diapositiva](/slides/java/presentation-background/), el fondo final puede verse influenciado por el tema de la presentación, el esquema de colores y las formas colocadas en la diapositiva maestra y la diapositiva de diseño.

Aspose.Slides para Java no proporciona un método simple para extraer el fondo completo de la diapositiva de presentación como una imagen, pero puedes seguir los pasos a continuación para hacerlo:
1. Carga la presentación usando la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtén el tamaño de la diapositiva de la presentación.
1. Selecciona una diapositiva.
1. Crea una presentación temporal.
1. Establece el mismo tamaño de diapositiva en la presentación temporal.
1. Clona la diapositiva seleccionada en la presentación temporal.
1. Elimina las formas de la diapositiva clonada.
1. Convierte la diapositiva clonada a una imagen.

El siguiente ejemplo de código extrae el fondo completo de la diapositiva de presentación como una imagen.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```