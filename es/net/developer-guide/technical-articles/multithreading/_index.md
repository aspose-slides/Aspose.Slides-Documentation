---
title: Multithreading en Aspose.Slides para .NET
linktitle: Multihilo
type: docs
weight: 310
url: /es/net/multithreading/
keywords:
- multihilo
- varios hilos
- trabajo paralelo
- convertir diapositivas
- diapositivas a imágenes
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "El multihilo de Aspose.Slides para .NET mejora el procesamiento de PowerPoint y OpenDocument. Descubra las mejores prácticas para flujos de trabajo de presentación eficientes."
---

## **Introducción**

Aunque el trabajo paralelo con presentaciones es posible (además del análisis/carga/clonado) y la mayoría de las veces todo funciona bien, existe una pequeña probabilidad de obtener resultados incorrectos al usar la biblioteca en varios hilos.

Recomendamos encarecidamente que **no** utilice una única instancia de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) en un entorno multihilo porque podría generar errores o fallas impredecibles que no se detectan fácilmente. 

No es **seguro** cargar, guardar y/o clonar una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) en varios hilos. Tales operaciones **no** están soportadas. Si necesita realizar esas tareas, debe paralelizar las operaciones usando varios procesos de un solo hilo, y cada uno de estos procesos debe usar su propia instancia de presentación. 

## **Convertir diapositivas de presentación a imágenes en paralelo**

Supongamos que queremos convertir todas las diapositivas de una presentación de PowerPoint a imágenes PNG en paralelo. Dado que no es seguro usar una única instancia de `Presentation` en varios hilos, dividimos las diapositivas de la presentación en presentaciones separadas y convertimos las diapositivas a imágenes en paralelo, usando cada presentación en un hilo separado. El siguiente ejemplo de código muestra cómo hacerlo.
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
    // Extraer la diapositiva i a una presentación separada.
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


## **Preguntas frecuentes**

**¿Necesito llamar a la configuración de licencia en cada hilo?**

No. Basta hacerlo una vez por proceso o dominio de aplicación antes de que los hilos se inicien. Si la [configuración de licencia](/slides/es/net/licensing/) podría invocarse concurrentemente (por ejemplo, durante la inicialización perezosa), sincronice esa llamada porque el método de configuración de licencia no es seguro para hilos.

**¿Puedo pasar objetos `Presentation` o `Slide` entre hilos?**

Pasar objetos de presentación "en vivo" entre hilos no se recomienda: use instancias independientes por hilo o precree presentaciones/contendedores de diapositivas separados para cada hilo. Este enfoque sigue la recomendación general de no compartir una única instancia de presentación entre hilos.

**¿Es seguro paralelizar la exportación a diferentes formatos (PDF, HTML, imágenes) siempre que cada hilo tenga su propia instancia `Presentation`?**

Sí. Con instancias independientes y rutas de salida separadas, esas tareas normalmente se paralelizan correctamente; evite cualquier objeto de presentación compartido y flujos de E/S compartidos.

**¿Qué debo hacer con la configuración global de fuentes (carpetas, sustituciones) en entornos multihilo?**

Inicialice toda la configuración global de fuentes antes de iniciar los hilos y no la modifique durante el trabajo paralelo. Esto elimina las condiciones de carrera al acceder a recursos de fuentes compartidos.