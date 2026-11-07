---
title: Operaciones de presentación de bajo código en .NET
linktitle: API de bajo código
type: docs
weight: 50
url: /es/net/low-code-presentation-operations/
keywords:
- API de presentación de bajo código
- convertir presentación
- combinar presentaciones
- iterar diapositivas
- iterar formas
- iterar texto
- recopilar formas
- comprimir presentación
- eliminar diapositivas maestras no usadas
- eliminar diapositivas de diseño no usadas
- comprimir fuentes incrustadas
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Utilice la API de bajo código de Aspose.Slides en .NET para convertir y combinar presentaciones, iterar a través del contenido, recopilar formas y reducir el tamaño de la presentación."
---
## **Visión general**

El espacio de nombres [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) proporciona clases auxiliares estáticas para operaciones comunes de presentaciones. Estas ayudas envuelven flujos de trabajo del modelo de objetos frecuentemente usados en métodos concentrados, de modo que puedes convertir o combinar archivos, procesar elementos de la presentación, recopilar formas y eliminar contenido no utilizado con menos código.

Los asistentes de bajo código son más útiles cuando la operación se aplica a un archivo o presentación completa y el flujo de trabajo predeterminado coincide con tus requisitos. Utiliza el modelo de objetos completo de [Aspose.Slides](https://reference.aspose.com/slides/net/aspose.slides/) cuando necesites un control granular sobre diapositivas individuales, maestros, diseños, formas, configuraciones de exportación o relaciones entre los elementos de la presentación.

La tabla siguiente resume los asistentes disponibles:

| Asistente | Uso |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Convertir una presentación a otro formato mediante una llamada directa de archivo a archivo. |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Combinar archivos de presentación completos del mismo formato. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Ejecutar una acción para cada diapositiva, forma, párrafo o porción de texto. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Recuperar formas de toda la presentación para procesamiento o análisis repetido. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Eliminar maestros/diseños no utilizados, reducir datos de fuentes incrustadas y comprimir imágenes. |

## **Convertir una presentación**

Utiliza [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) cuando la extensión del archivo de salida es suficiente para seleccionar el formato de exportación. El método abre la presentación origen, determina el formato requerido a partir de la ruta de salida y escribe el resultado.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

La clase [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) también ofrece métodos dedicados para salida PDF, SVG, JPEG, PNG y TIFF. Utiliza el modelo de objetos completo cuando necesites inspeccionar o modificar la presentación antes de la exportación o configurar una opción de exportación que no esté expuesta por el asistente seleccionado. Consulta [Convertir presentación](/slides/es/net/convert-presentation/) para flujos de trabajo y opciones específicas de formato.

## **Combinar presentaciones**

Utiliza [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) para combinar archivos de presentación completos con una sola llamada. Las presentaciones de entrada deben tener el mismo formato de archivo.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

El asistente es apropiado cuando todas las diapositivas deben añadirse a un único resultado sin seleccionarlas o reasignarlas individualmente. Utiliza el modelo de objetos completo cuando necesites combinar diapositivas seleccionadas, aplicar un maestro o diseño de destino, preservar secciones explícitamente o reconciliar tamaños de diapositiva diferentes. Consulta [Combinar presentaciones](/slides/es/net/merge-presentation/) para esos escenarios.

## **Iterar a través de los elementos de la presentación**

La clase [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) invoca una devolución de llamada para cada tipo solicitado de elemento de la presentación. Evita bucles de colección anidados y resulta cómoda para inspecciones a nivel de presentación o cambios de formato.

El siguiente ejemplo usa [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/), y [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) para inspeccionar los elementos correspondientes:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

Por defecto, el recorrido de formas y texto a nivel de presentación incluye diapositivas normales, maestras y de diseño. Las sobrecargas con un parámetro `includeNotes` también pueden procesar diapositivas de notas. Utiliza bucles de colección directos cuando el orden de recorrido, la salida temprana, el filtrado antes de la invocación de la devolución de llamada o el control detallado padre‑hijo son importantes.

## **Recopilar formas**

Utiliza [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) cuando necesites una colección de todas las formas en una presentación en lugar de una devolución de llamada para cada forma. Esto es útil cuando el mismo conjunto será filtrado, contado o procesado más de una vez.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Usa [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) en su lugar cuando cada forma pueda manejarse inmediatamente y no necesites conservar el resultado recopilado.

## **Comprimir contenido de la presentación**

La clase [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) puede eliminar elementos estructurales no utilizados y reducir los datos de fuentes incrustadas:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) elimina las diapositivas de diseño que ninguna diapositiva normal referencia.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) elimina las diapositivas maestras que ya no se usan.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) elimina los caracteres no utilizados de las fuentes incrustadas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Elimina los diseños no utilizados antes que los maestros no utilizados, de modo que un maestro que quede sin referencia tras la limpieza de diseños también pueda eliminarse. Guarda la presentación optimizada en un archivo nuevo si puedes necesitar más adelante los maestros, diseños o los datos completos de fuentes incrustadas originales. Para más detalles, consulta [Slide Master](/slides/es/net/slide-master/) y [Embedded Font](/slides/es/net/embedded-font/).

### **Comprimir toda la presentación**

Aspose.Slides for .NET 26.11 incorpora [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). Combina la eliminación de diapositivas de diseño/maestro no utilizadas, la reducción de fuentes incrustadas a los caracteres usados y la compresión de imágenes a 150 DPI. Utiliza las operaciones individuales anteriores cuando necesites controlar qué cambios se aplican.

Instala [Aspose.Slides for .NET](/slides/es/net/installation/) 26.11 o posterior y proporciona `input.pptx`. Guarda en un archivo separado: los diseños eliminados, los caracteres de fuente y los píxeles recortados de las imágenes pueden ser necesarios para edición posterior.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Comprimir imágenes a una resolución elegida**

Utiliza [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) para procesar imágenes elegibles sin eliminar también diseños o reducir fuentes. Este ejemplo usa 96 DPI; selecciona otro valor de [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) para tus necesidades de salida.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Ambos asistentes utilizan el siguiente alcance de procesamiento de imágenes:

| Contenido | Tratamiento |
| --- | --- |
| Imágenes raster y rellenos de forma con imágenes en diapositivas normales, maestras y de diseño, incluidas formas agrupadas | Elegibles para compresión. |
| Imágenes ya en la resolución solicitada o inferior | No se aumentan. Las áreas recortadas aún pueden eliminarse. |
| Áreas recortadas de imágenes | Los píxeles ocultos se eliminan permanentemente y los desplazamientos de recorte se restablecen. |
| Fondos de diapositiva y rellenos de celdas de tabla | No procesados por estos asistentes. |
| Elementos internos de gráficos/SmartArt, GIF y formatos vectoriales como SVG, EMF y WMF | Fuera del alcance documentado de compresión de imágenes. |

En la versión 26.11, [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) evita el muestreo descendente basado en la resolución de una imagen no recortada, pero **no conserva los píxeles recortados**. Una imagen recortada aún puede volver a escribirse con sus áreas ocultas eliminadas. Ninguno de los asistentes expone una opción de conservar recorte. Para control individual, consulta el [ejemplo de compresión por imagen](/slides/es/net/examples/optimization-batch/compression/).

Compara la apariencia y el tamaño del archivo resultante antes de sustituir el original. El ahorro depende de las imágenes fuente, su tamaño de visualización y el contenido no utilizado; la compresión no garantiza un archivo más pequeño. Consulta [Embedded Fonts](/slides/es/net/embedded-font/) para conocer las implicaciones de la reducción de fuentes.

## **Preguntas frecuentes**

**¿Cuándo debo usar la API de bajo código en lugar del modelo de objetos completo?**

Utiliza los asistentes de bajo código cuando una operación estándar se aplica a un archivo o presentación completa y no requiere control detallado sobre elementos individuales. Utiliza el modelo de objetos completo cuando necesites seleccionar diapositivas específicas, controlar relaciones de maestros y diseños, inspeccionar el estado intermedio o configurar un comportamiento que el asistente no exponga.

**¿Puede Merger combinar presentaciones en diferentes formatos de archivo?**

No. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) requiere que las presentaciones de entrada tengan el mismo formato. Convierte los archivos de entrada a un formato común primero, por ejemplo con [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), y luego combina los archivos convertidos.

**¿ForEach procesa diapositivas maestras, de diseño y de notas?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) itera a través de diapositivas normales de la presentación. [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) y [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) a nivel de presentación incluyen diapositivas normales, maestras y de diseño por defecto. Usa sus sobrecargas con `includeNotes` establecidas en `true` para incluir diapositivas de notas.

**¿Cuál es la diferencia entre ForEach.Shape y Collect.Shapes?**

Utiliza [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) para procesar cada forma inmediatamente mediante una devolución de llamada. Utiliza [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) cuando necesites un resultado enumerable que pueda conservarse, filtrarse, contarse o recorrerse varias veces.

**¿Compress siempre hace que el archivo de la presentación sea más pequeño?**

No necesariamente. El ahorro depende de los diseños/maestros no utilizados, las fuentes incrustadas con caracteres no usados y las imágenes que se benefician de la compresión. Los asistentes [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) pueden dejar el tamaño sin cambios o producir un archivo mayor para algunas entradas. Compara tanto el tamaño como la calidad renderizada, y conserva el original.

**¿Los cambios realizados por ForEach o Compress se guardan automáticamente?**

No. Estos asistentes operan sobre el objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) cargado en memoria. Después de cambiar elementos en una devolución de llamada de [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) o ejecutar [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), llama a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) para escribir el resultado.

## **Artículos relacionados**

- [Convertir presentación](/slides/es/net/convert-presentation/)
- [Combinar presentaciones](/slides/es/net/merge-presentation/)
- [Slide Master](/slides/es/net/slide-master/)
- [Gestionar cuadro de texto](/slides/es/net/manage-textbox/)
- [Embedded Font](/slides/es/net/embedded-font/)