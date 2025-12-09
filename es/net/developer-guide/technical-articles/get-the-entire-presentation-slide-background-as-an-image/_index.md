---
title: Obtener el fondo completo de la diapositiva de una presentación como una imagen
linktitle: Fondo completo de la diapositiva
type: docs
weight: 95
url: /es/net/get-the-entire-presentation-slide-background-as-an-image/
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
- .NET
- C#
- Aspose.Slides
description: "Extrae fondos completos de diapositivas como imágenes de presentaciones PowerPoint y OpenDocument usando Aspose.Slides para .NET, optimizando flujos de trabajo visuales."
---

## **Obtener el fondo completo de la diapositiva**

En las presentaciones de PowerPoint, el fondo de la diapositiva puede constar de varios elementos. Además de la imagen establecida como el [fondo de diapositiva](/slides/es/net/presentation-background/), el fondo final puede verse influido por el tema de la presentación, el esquema de colores y las formas colocadas en la diapositiva maestra y en la diapositiva de diseño.

Aspose.Slides for .NET no proporciona un método simple para extraer todo el fondo de la diapositiva de la presentación como una imagen, pero puede seguir los pasos a continuación para hacerlo:
1. Cargue la presentación usando la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenga el tamaño de la diapositiva de la presentación.
1. Seleccione una diapositiva.
1. Cree una presentación temporal.
1. Establezca el mismo tamaño de diapositiva en la presentación temporal.
1. Clone la diapositiva seleccionada en la presentación temporal.
1. Elimine las formas de la diapositiva clonada.
1. Convierta la diapositiva clonada a una imagen.

El siguiente ejemplo de código extrae el fondo completo de la diapositiva de la presentación como una imagen.
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```


## **Preguntas frecuentes**

**¿Se conservarán los degradados complejos, texturas o rellenos de imagen de una diapositiva maestra en la imagen de fondo resultante?**

Sí. Aspose.Slides renderiza los rellenos de degradado, imagen y textura definidos en la diapositiva, el diseño o la maestra. Si necesita aislar el aspecto de las maestras heredadas, [establezca un fondo propio](/slides/es/net/presentation-background/) en la diapositiva actual antes de exportar.

**¿Puedo añadir una marca de agua a la imagen de fondo resultante antes de guardarla?**

Sí. Puede [añadir una marca de agua](/slides/es/net/watermark/) como forma o imagen en una [copia de trabajo de la diapositiva](/slides/es/net/clone-slides/) (colocada detrás de otro contenido) y luego exportar. Esto le permite generar una imagen de fondo con la marca de agua incorporada.

**¿Puedo obtener el fondo para un diseño o maestra específico sin asociarlo a una diapositiva existente?**

Sí. Acceda a la maestra o diseño deseado, aplíquelo a una [diapositiva temporal](/slides/es/net/clone-slides/) con el tamaño requerido y exporte esa diapositiva para obtener el fondo derivado de ese diseño o maestra.

**¿Existen limitaciones de licencia que afecten la exportación de imágenes?**

Las funciones de renderizado están completamente disponibles con una [licencia válida](/slides/es/net/licensing/). En modo de evaluación, la salida puede incluir limitaciones como una marca de agua. Active la licencia una vez por proceso antes de ejecutar exportaciones por lotes.