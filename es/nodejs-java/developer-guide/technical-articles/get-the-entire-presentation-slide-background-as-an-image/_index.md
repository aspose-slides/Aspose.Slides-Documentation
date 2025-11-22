---
title: Obtener el fondo completo de la diapositiva de la presentación como una imagen
type: docs
weight: 95
url: /es/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositiva
- fondo
- fondo de diapositiva
- fondo a una imagen
- PowerPoint
- PPT
- PPTX
- presentación de PowerPoint
- Node
- JavaScript
- Aspose.Slides for Node.js via Java
---

## **Obtener el fondo completo de la diapositiva**

En presentaciones de PowerPoint, el fondo de la diapositiva puede constar de muchos elementos. Además de la imagen establecida como [fondo de la diapositiva](/slides/es/nodejs-java/presentation-background/), el fondo final puede verse influenciado por el tema de la presentación, el esquema de colores y las formas colocadas en la diapositiva maestra y en la diapositiva de diseño.

Aspose.Slides for Node.js via Java no proporciona un método sencillo para extraer el fondo completo de la diapositiva de la presentación como una imagen, pero puede seguir los pasos a continuación para hacerlo:
1. Cargar la presentación usando la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtener el tamaño de la diapositiva de la presentación.
1. Seleccionar una diapositiva.
1. Crear una presentación temporal.
1. Establecer el mismo tamaño de diapositiva en la presentación temporal.
1. Clonar la diapositiva seleccionada en la presentación temporal.
1. Eliminar las formas de la diapositiva clonada.
1. Convertir la diapositiva clonada a una imagen.

El siguiente ejemplo de código extrae el fondo completo de la diapositiva de la presentación como una imagen.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```


## **FAQ**

**¿Se conservarán los degradados complejos, texturas o rellenos de imagen de una diapositiva maestra en la imagen de fondo resultante?**

Sí. Aspose.Slides representa los rellenos de degradado, imagen y textura definidos en la diapositiva, el diseño o la maestra. Si necesita aislar el aspecto de las másters heredadas, [establezca un fondo propio](/slides/es/nodejs-java/presentation-background/) en la diapositiva actual antes de exportar.

**¿Puedo añadir una marca de agua a la imagen de fondo resultante antes de guardarla?**

Sí. Puede [añadir una marca de agua](/slides/es/nodejs-java/watermark/) como forma o imagen en una [copia de trabajo de la diapositiva](/slides/es/nodejs-java/clone-slides/) (colocada detrás del resto del contenido) y luego exportar. Así genera una imagen de fondo con la marca de agua incorporada.

**¿Puedo obtener el fondo de un diseño o maestro específico sin asociarlo a una diapositiva existente?**

Sí. Acceda al maestro o diseño deseado, aplíquelo a una [diapositiva temporal](/slides/es/nodejs-java/clone-slides/) con el tamaño requerido y exporte esa diapositiva para obtener el fondo derivado de ese diseño o maestro.

**¿Existen limitaciones de licencia que afecten la exportación de imágenes?**

Las funciones de renderizado están totalmente disponibles con una [licencia válida](/slides/es/nodejs-java/licensing/). En modo de evaluación, la salida puede incluir limitaciones como una marca de agua. Active la licencia una vez por proceso antes de ejecutar exportaciones por lotes.