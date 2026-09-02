---
title: Operaciones de presentación low-code en .NET
linktitle: API low-code
type: docs
weight: 50
url: /es/net/low-code-presentation-operations/
keywords:
- API low-code de presentación
- convertir presentación
- combinar presentaciones
- recorrer diapositivas
- recorrer formas
- recorrer texto
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
description: "Utiliza la API low-code de Aspose.Slides en .NET para convertir y combinar presentaciones, recorrer el contenido, recopilar formas y reducir el tamaño de la presentación."
---
## **Resumen**

El [Aspose.Slides.LowCode](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/) namespace proporciona clases auxiliares estáticas para operaciones comunes con presentaciones. Estos ayudantes envuelven flujos de trabajo del modelo de objetos frecuentemente usados en métodos enfocados, de modo que puedes convertir o combinar archivos, procesar elementos de la presentación, recopilar formas y eliminar contenido no utilizado con menos código.

Los ayudantes low‑code son más útiles cuando la operación se aplica a un archivo o presentación completa y el flujo de trabajo predeterminado coincide con tus requisitos. Utiliza el modelo de objetos completo [Aspose.Slides object model](https://reference.aspose.com/slides/es/net/aspose.slides/) cuando necesites inspeccionar o modificar la presentación antes de la exportación o configurar una opción de exportación que no esté expuesta por el ayudante seleccionado. Consulta [Convert Presentation](/slides/es/net/convert-presentation/) para flujos de trabajo y opciones específicas de cada formato.

La tabla siguiente resume los ayudantes disponibles:

| Ayudante | Para qué usarlo |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/convert/) | Convertir una presentación a otro formato con una llamada directa de archivo a archivo. |
| [Merger](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/merger/) | Combinar archivos de presentación completos del mismo formato. |
| [ForEach](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/foreach/) | Ejecutar una acción para cada diapositiva, forma, párrafo o porción de texto. |
| [Collect](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/collect/) | Recuperar formas de toda la presentación para procesarlas o analizarlas de forma repetida. |
| [Compress](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/compress/) | Eliminar maestros y diseños no usados y reducir los datos de fuentes incrustadas. |

## **Convertir una presentación**

Utiliza [Convert.AutoByExtension](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/convert/autobyextension/) cuando la extensión del archivo de salida es suficiente para seleccionar el formato de exportación. El método abre la presentación origen, determina el formato requerido a partir de la ruta de salida y escribe el resultado.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

La clase [Convert](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/convert/) también proporciona métodos dedicados para la salida en PDF, SVG, JPEG, PNG y TIFF. Utiliza el modelo de objetos completo cuando necesites inspeccionar o modificar la presentación antes de la exportación o configurar una opción de exportación que no esté expuesta por el ayudante seleccionado. Consulta [Convert Presentation](/slides/es/net/convert-presentation/) para flujos de trabajo y opciones específicas de cada formato.

## **Combinar presentaciones**

Utiliza [Merger.Process](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/merger/process/) para combinar archivos de presentación completos con una sola llamada. Las presentaciones de entrada deben tener el mismo formato de archivo.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

El ayudante es apropiado cuando todas las diapositivas deben añadirse a un único resultado sin seleccionarlas o remapeándolas individualmente. Utiliza el modelo de objetos completo cuando necesites combinar diapositivas seleccionadas, aplicar un maestro o diseño de destino, preservar secciones explícitamente, o conciliar diferentes tamaños de diapositiva. Consulta [Merge Presentations](/slides/es/net/merge-presentation/) para esos escenarios.

## **Recorrer los elementos de la presentación**

La clase [ForEach](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/foreach/) invoca una devolución de llamada para cada tipo solicitado de elemento de la presentación. Evita bucles de colección anidados y es conveniente para inspecciones o cambios de formato en toda la presentación.

El siguiente ejemplo utiliza [ForEach.Slide](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/foreach/paragraph/), y [ForEach.Portion](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/foreach/portion/) para inspeccionar los elementos correspondientes:

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

Por defecto, el recorrido de formas y texto en toda la presentación incluye diapositivas normales, maestras y de diseño. Las sobrecargas con un parámetro `includeNotes` también pueden procesar diapositivas de notas. Utiliza bucles de colección directos cuando el orden de recorrido, la salida anticipada, el filtrado antes de la invocación de la devolución de llamada, o el control detallado de padre‑hijo es importante.

## **Recopilar formas**

Utiliza [Collect.Shapes](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/collect/shapes/) cuando necesites una colección de todas las formas de una presentación en lugar de una devolución de llamada para cada forma. Esto es útil cuando el mismo conjunto será filtrado, contado o procesado más de una vez.

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

Utiliza [ForEach.Shape](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/foreach/shape/) en su lugar cuando cada forma pueda ser manejada inmediatamente y no necesites conservar el resultado recopilado.

## **Comprimir el contenido de la presentación**

La clase [Compress](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/compress/) puede eliminar elementos estructurales no usados y reducir los datos de fuentes incrustadas:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) elimina diapositivas de diseño que no son referenciadas por ninguna diapositiva normal.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) elimina diapositivas maestras que ya no se utilizan.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/compress/compressembeddedfonts/) elimina caracteres no usados de las fuentes incrustadas.

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

Elimina primero los diseños no usados antes que los maestros no usados, de modo que un maestro que quede sin referencias tras la limpieza de diseños también pueda eliminarse. Guarda la presentación optimizada en un archivo nuevo si puedes necesitar más tarde los maestros, diseños o datos completos de fuentes incrustadas originales. Para más detalle, consulta [Slide Master](/slides/es/net/slide-master/) y [Embedded Font](/slides/es/net/embedded-font/).

## **Preguntas frecuentes**

**¿Cuándo debo usar la API low‑code en lugar del modelo de objetos completo?**

Utiliza los ayudantes low‑code cuando una operación estándar se aplica a un archivo o presentación completa y no requiere control detallado sobre elementos individuales. Utiliza el modelo de objetos completo cuando necesites seleccionar diapositivas específicas, controlar relaciones de maestros y diseños, inspeccionar el estado intermedio, o configurar un comportamiento que el ayudante no expone.

**¿Puede Merger combinar presentaciones en diferentes formatos de archivo?**

No. [Merger.Process](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/merger/process/) requiere que las presentaciones de entrada tengan el mismo formato. Convierte primero los archivos de entrada a un formato común, por ejemplo con [Convert.AutoByExtension](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/convert/autobyextension/), y luego combina los archivos convertidos.

**¿Procesa ForEach las diapositivas maestras, de diseño y de notas?**

[ForEach.Slide](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/foreach/slide/) recorre las diapositivas normales de la presentación. Los [ForEach.Shape](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/foreach/paragraph/) y [ForEach.Portion](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/foreach/portion/) a nivel de presentación incluyen por defecto diapositivas normales, maestras y de diseño. Usa sus sobrecargas con `includeNotes` establecido a `true` para incluir diapositivas de notas.

**¿Cuál es la diferencia entre ForEach.Shape y Collect.Shapes?**

Utiliza [ForEach.Shape](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/foreach/shape/) para procesar cada forma inmediatamente mediante una devolución de llamada. Utiliza [Collect.Shapes](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/collect/shapes/) cuando necesites un resultado enumerable que pueda conservarse, filtrarse, contarse o recorrerse múltiples veces.

**¿Compress siempre reduce el tamaño del archivo de la presentación?**

No necesariamente. El resultado depende de si la presentación contiene diseños no usados, maestros no usados o fuentes incrustadas con caracteres no usados. Si ninguno de esos elementos está presente, las operaciones correspondientes de [Compress](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/compress/) pueden no reducir el tamaño del archivo.

**¿Los cambios realizados por ForEach o Compress se guardan automáticamente?**

No. Estos ayudantes operan sobre el objeto [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) cargado en memoria. Después de cambiar elementos en una devolución de llamada de [ForEach](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/foreach/) o ejecutar [Compress](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/compress/), llama a [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) para escribir el resultado.

## **Artículos relacionados**

- [Convertir presentación](/slides/es/net/convert-presentation/)
- [Combinar presentaciones](/slides/es/net/merge-presentation/)
- [Maestro de diapositiva](/slides/es/net/slide-master/)
- [Administrar cuadro de texto](/slides/es/net/manage-textbox/)
- [Fuente incrustada](/slides/es/net/embedded-font/)