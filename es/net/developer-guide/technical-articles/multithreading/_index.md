---
title: Multithreading en Aspose.Slides
type: docs
weight: 310
url: /es/net/multithreading/
keywords:
- PowerPoint
- presentación
- multihilo
- trabajo paralelo
- convertir diapositivas
- diapositivas a imágenes
- C#
- .NET
- Aspose.Slides for .NET
---

## **Introducción**

Aunque el trabajo paralelo con presentaciones es posible (además del análisis/carga/clonado) y todo funciona bien (la mayoría de las veces), existe una pequeña probabilidad de obtener resultados incorrectos al usar la biblioteca en varios hilos.

Recomendamos encarecidamente que **no** use una única instancia de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) en un entorno de multihilo porque podría resultar en errores o fallas impredecibles que no se detectan fácilmente.

No es seguro cargar, guardar y/o clonar una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) en varios hilos. Tales operaciones **no** son compatibles. Si necesita realizar esas tareas, debe paralelizar las operaciones usando varios procesos de un solo hilo, y cada uno de esos procesos debe usar su propia instancia de presentación.

## **Convertir diapositivas de la presentación a imágenes en paralelo**

Supongamos que queremos convertir todas las diapositivas de una presentación de PowerPoint a imágenes PNG en paralelo. Dado que es inseguro usar una única instancia de `Presentation` en varios hilos, dividimos las diapositivas de la presentación en presentaciones separadas y convertimos las diapositivas a imágenes en paralelo, usando cada presentación en un hilo distinto. El siguiente ejemplo de código muestra cómo hacerlo.
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


## **FAQ**

**¿Necesito llamar a la configuración de licencia en cada hilo?**

No. Basta hacerlo una vez por proceso/área de aplicación antes de que comiencen los hilos. Si la [configuración de licencia](/slides/es/net/licensing/) pudiera invocarse simultáneamente (por ejemplo, durante la inicialización perezosa), sincronice esa llamada porque el método de configuración de licencia en sí no es seguro para hilos.

**¿Puedo pasar objetos `Presentation` o `Slide` entre hilos?**

No se recomienda pasar objetos de presentación "activos" entre hilos: use instancias independientes por hilo o precrea presentaciones/contendores de diapositivas separados para cada hilo. Este enfoque sigue la recomendación general de no compartir una única instancia de presentación entre hilos.

**¿Es seguro paralelizar la exportación a diferentes formatos (PDF, HTML, imágenes) siempre que cada hilo tenga su propia instancia de `Presentation`?**

Sí. Con instancias independientes y rutas de salida separadas, esas tareas normalmente se paralelizan correctamente; evite cualquier objeto de presentación compartido y flujos de E/S compartidos.

**¿Qué debo hacer con la configuración global de fuentes (carpetas, sustituciones) en multihilo?**

Inicialice todas las configuraciones globales de fuentes antes de iniciar los hilos y no las modifique durante el trabajo paralelo. Esto elimina las condiciones de carrera al acceder a recursos de fuentes compartidos.