---
title: Obtener el Fondo Completo de una Diapositiva de Presentación como Imagen
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

En las presentaciones de PowerPoint, el fondo de la diapositiva puede consistir en muchos elementos. Además de la imagen configurada como el [fondo de la diapositiva](/slides/es/net/presentation-background/), el fondo final puede verse influenciado por el tema de la presentación, la paleta de colores y las formas colocadas en la diapositiva maestra y en la diapositiva de diseño.

Aspose.Slides for .NET no proporciona un método simple para extraer el fondo completo de la diapositiva de la presentación como una imagen, pero puedes seguir los pasos a continuación para hacerlo:
1. Cargar la presentación utilizando la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtener el tamaño de la diapositiva de la presentación.
1. Seleccionar una diapositiva.
1. Crear una presentación temporal.
1. Establecer el mismo tamaño de diapositiva en la presentación temporal.
1. Clonar la diapositiva seleccionada en la presentación temporal.
1. Eliminar las formas de la diapositiva clonada.
1. Convertir la diapositiva clonada a una imagen.

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