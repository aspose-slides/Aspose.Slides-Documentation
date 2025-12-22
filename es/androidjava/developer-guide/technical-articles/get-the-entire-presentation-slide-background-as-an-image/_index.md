---
title: Obtener todo el fondo de la diapositiva de una presentación como imagen
linktitle: Fondo completo de la diapositiva
type: docs
weight: 95
url: /es/androidjava/get-the-entire-presentation-slide-background-as-an-image/
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
- Android
- Java
- Aspose.Slides
description: "Extraer fondos completos de diapositivas como imágenes de presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Android mediante Java, simplificando los flujos de trabajo visuales."
---

## **Obtener todo el fondo de la diapositiva**

En presentaciones de PowerPoint, el fondo de la diapositiva puede constar de varios elementos. Además de la imagen establecida como el [fondo de la diapositiva](/slides/es/androidjava/presentation-background/), el fondo final puede verse influenciado por el tema de la presentación, el esquema de colores y las formas ubicadas en la diapositiva maestra y la diapositiva de diseño.

Aspose.Slides for Android via Java no proporciona un método sencillo para extraer todo el fondo de la diapositiva de la presentación como una imagen, pero puedes seguir los pasos a continuación para hacerlo:
1. Cargar la presentación usando la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtener el tamaño de la diapositiva de la presentación.
1. Seleccionar una diapositiva.
1. Crear una presentación temporal.
1. Establecer el mismo tamaño de diapositiva en la presentación temporal.
1. Clonar la diapositiva seleccionada en la presentación temporal.
1. Eliminar las formas de la diapositiva clonada.
1. Convertir la diapositiva clonada en una imagen.

El siguiente ejemplo de código extrae todo el fondo de la diapositiva de la presentación como una imagen.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```


## **Preguntas frecuentes**

**¿Se conservarán los degradados complejos, texturas o rellenos de imagen de una diapositiva maestra en la imagen de fondo resultante?**

Sí. Aspose.Slides representa degradados, imágenes y texturas definidos en la diapositiva, el diseño o la maestra. Si necesitas aislar el aspecto de las maestros heredados, [establecer un fondo propio](/slides/es/androidjava/presentation-background/) en la diapositiva actual antes de exportar.

**¿Puedo agregar una marca de agua a la imagen de fondo resultante antes de guardarla?**

Sí. Puedes [agregar una marca de agua](/slides/es/androidjava/watermark/) como forma o imagen en una [copia de la diapositiva](/slides/es/androidjava/clone-slides/) de trabajo (colocada detrás de otro contenido) y luego exportar. Esto te permite generar una imagen de fondo con la marca de agua incorporada.

**¿Puedo obtener el fondo de un diseño o maestra específico sin vincularlo a una diapositiva existente?**

Sí. Accede a la maestra o diseño deseado, aplícalo a una [diapositiva temporal](/slides/es/androidjava/clone-slides/) con el tamaño requerido y exporta esa diapositiva para obtener el fondo derivado de ese diseño o maestra.

**¿Existen limitaciones de licencia que afecten la exportación de imágenes?**

Las funciones de renderizado están completamente disponibles con una [licencia válida](/slides/es/androidjava/licensing/). En modo de evaluación, la salida puede incluir limitaciones como una marca de agua. Activa la licencia una vez por proceso antes de ejecutar exportaciones por lotes.