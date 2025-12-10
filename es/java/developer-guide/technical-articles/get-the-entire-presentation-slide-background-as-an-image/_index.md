---
title: Obtener el fondo completo de la diapositiva de una presentación como imagen
linktitle: Fondo completo de la diapositiva
type: docs
weight: 95
url: /es/java/get-the-entire-presentation-slide-background-as-an-image/
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
- Java
- Aspose.Slides
description: "Extraiga fondos completos de diapositivas como imágenes de presentaciones PowerPoint y OpenDocument usando Aspose.Slides for Java, optimizando flujos de trabajo visuales."
---

## **Obtener el fondo completo de la diapositiva**

En presentaciones de PowerPoint, el fondo de la diapositiva puede constar de muchos elementos. Además de la imagen establecida como el [fondo de la diapositiva](/slides/es/java/presentation-background/), el fondo final puede verse influenciado por el tema de la presentación, el esquema de colores y las formas ubicadas en la diapositiva maestra y en la diapositiva de diseño.

Aspose.Slides for Java no ofrece un método sencillo para extraer todo el fondo de la diapositiva de la presentación como una imagen, pero puede seguir los pasos a continuación para hacerlo:
1. Cargue la presentación usando la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Obtenga el tamaño de la diapositiva de la presentación.
1. Seleccione una diapositiva.
1. Cree una presentación temporal.
1. Establezca el mismo tamaño de diapositiva en la presentación temporal.
1. Clone la diapositiva seleccionada en la presentación temporal.
1. Elimine las formas de la diapositiva clonada.
1. Convierta la diapositiva clonada a una imagen.

El siguiente ejemplo de código extrae todo el fondo de la diapositiva de la presentación como una imagen.
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


## **Preguntas frecuentes**

**¿Se conservarán degradados complejos, texturas o rellenos de imagen de una diapositiva maestra en la imagen de fondo resultante?**

Sí. Aspose.Slides renderiza degradados, imágenes y texturas definidas en la diapositiva, el diseño o la maestra. Si necesita aislar el aspecto de las másters heredadas, [establezca un fondo propio](/slides/es/java/presentation-background/) en la diapositiva actual antes de exportar.

**¿Puedo añadir una marca de agua a la imagen de fondo resultante antes de guardarla?**

Sí. Puede [añadir una marca de agua](/slides/es/java/watermark/) en forma de forma o imagen en una [copia de trabajo de la diapositiva](/slides/es/java/clone-slides/) (colocada detrás de otro contenido) y luego exportar. Esto le permite generar una imagen de fondo con la marca de agua incorporada.

**¿Puedo obtener el fondo de un diseño o maestra específicos sin asociarlo a una diapositiva existente?**

Sí. Acceda a la maestra o al diseño deseado, aplíquelo a una [diapositiva temporal](/slides/es/java/clone-slides/) con el tamaño requerido y exporte esa diapositiva para obtener el fondo derivado de ese diseño o maestra.

**¿Existen limitaciones de licencia que afecten la exportación de imágenes?**

Las funcionalidades de renderizado están totalmente disponibles con una [licencia válida](/slides/es/java/licensing/). En modo de evaluación, la salida puede incluir limitaciones como una marca de agua. Active la licencia una vez por proceso antes de ejecutar exportaciones por lotes.