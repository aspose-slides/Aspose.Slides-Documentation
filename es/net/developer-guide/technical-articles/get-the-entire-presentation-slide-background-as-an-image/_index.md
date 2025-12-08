---
title: Obtener todo el fondo de la diapositiva de la presentación como una imagen
type: docs
weight: 95
url: /es/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositiva
- fondo
- fondo de diapositiva
- fondo a una imagen
- PowerPoint
- PPT
- PPTX
- presentación de PowerPoint
- C#
- VB.NET
- Aspose.Slides for .NET
---

## **Obtener todo el fondo de la diapositiva**

En las presentaciones de PowerPoint, el fondo de la diapositiva puede estar compuesto por muchos elementos. Además de la imagen establecida como el [fondo de la diapositiva](/slides/es/net/presentation-background/), el fondo final puede verse influido por el tema de la presentación, el esquema de colores y las formas ubicadas en la diapositiva maestra y en la diapositiva de diseño.

Aspose.Slides para .NET no ofrece un método simple para extraer todo el fondo de la diapositiva de la presentación como una imagen, pero puedes seguir los pasos a continuación para hacerlo:
1. Carga la presentación usando la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtén el tamaño de la diapositiva de la presentación.
1. Selecciona una diapositiva.
1. Crea una presentación temporal.
1. Establece el mismo tamaño de diapositiva en la presentación temporal.
1. Clona la diapositiva seleccionada en la presentación temporal.
1. Elimina las formas de la diapositiva clonada.
1. Convierte la diapositiva clonada a una imagen.

El siguiente ejemplo de código extrae todo el fondo de la diapositiva de la presentación como una imagen.
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

Sí. Aspose.Slides renderiza degradados, imágenes y texturas definidos en la diapositiva, el diseño o la maestra. Si necesitas aislar el aspecto de las másters heredadas, [establece un fondo propio](/slides/es/net/presentation-background/) en la diapositiva actual antes de exportar.

**¿Puedo añadir una marca de agua a la imagen de fondo resultante antes de guardarla?**

Sí. Puedes [añadir una marca de agua](/slides/es/net/watermark/) como forma o imagen en una [copia de la diapositiva](/slides/es/net/clone-slides/) de trabajo (colocada detrás de otro contenido) y luego exportar. Esto te permite generar una imagen de fondo con la marca de agua incorporada.

**¿Puedo obtener el fondo de un diseño o maestra específico sin asociarlo a una diapositiva existente?**

Sí. Accede a la maestra o diseño deseado, aplícalo a una [diapositiva temporal](/slides/es/net/clone-slides/) con el tamaño requerido y exporta esa diapositiva para obtener el fondo derivado de ese diseño o maestra.

**¿Existen limitaciones de licencia que afecten la exportación de imágenes?**

Las funciones de renderizado están totalmente disponibles con una [licencia válida](/slides/es/net/licensing/). En modo de evaluación, la salida puede incluir limitaciones como una marca de agua. Activa la licencia una vez por proceso antes de ejecutar exportaciones por lotes.