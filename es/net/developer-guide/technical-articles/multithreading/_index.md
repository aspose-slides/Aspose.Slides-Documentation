---
title: Multithreading en Aspose.Slides
type: docs
weight: 310
url: /net/multithreading/
keywords:
- PowerPoint
- presentación
- multithreading
- trabajo paralelo
- convertir diapositivas
- diapositivas a imágenes
- C#
- .NET
- Aspose.Slides para .NET
---

## **Introducción**

Si bien el trabajo paralelo con presentaciones es posible (además del análisis/carga/clonación) y todo suele ir bien (la mayoría de las veces), hay una pequeña posibilidad de que obtengas resultados incorrectos cuando utilices la biblioteca en múltiples hilos.

Recomendamos encarecidamente que **no** utilices una sola instancia de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) en un entorno de multithreading porque podría resultar en errores o fallos impredecibles que no son fácilmente detectables.

No es **seguro** cargar, guardar y/o clonar una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) en múltiples hilos. Tales operaciones **no** son admitidas. Si necesitas realizar tales tareas, debes paralelizar las operaciones utilizando varios procesos de un solo hilo, y cada uno de estos procesos debe utilizar su propia instancia de presentación.

## **Convertir diapositivas de presentación a imágenes en paralelo**

Supongamos que queremos convertir todas las diapositivas de una presentación de PowerPoint a imágenes PNG en paralelo. Dado que no es seguro utilizar una sola instancia de `Presentation` en múltiples hilos, separamos las diapositivas de la presentación en presentaciones separadas y convertimos las diapositivas a imágenes en paralelo, utilizando cada presentación en un hilo separado. El siguiente ejemplo de código muestra cómo hacer esto.

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // Extraer la diapositiva i en una presentación separada.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Convertir la diapositiva a una imagen en una tarea separada.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```