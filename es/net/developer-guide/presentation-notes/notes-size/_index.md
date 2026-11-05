---
title: Cambiar el tamaño y la orientación de la página de notas en .NET
linktitle: Tamaño de la página de notas
type: docs
weight: 10
url: /es/net/notes-size/
keywords:
- tamaño de la página de notas
- orientación de notas
- notas horizontales
- notas verticales
- tamaño del folleto
- PowerPoint
- presentación
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Lea y cambie las dimensiones de la página de notas en Aspose.Slides para .NET, cambie la orientación, verifique los tamaños guardados y exporte notas o folletos a PDF e imágenes."
---
## **Descripción general**

Utilice [Presentation.NotesSize](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/notessize/) para acceder a la configuración de la página de notas de la presentación. Devuelve un objeto [INotesSize](https://reference.aspose.com/slides/es/net/aspose.slides/inotessize/) cuya propiedad [Size](https://reference.aspose.com/slides/es/net/aspose.slides/inotessize/size/) es de escritura. Aunque el propio objeto de configuración es de solo lectura, puede asignar nuevas dimensiones a su propiedad Size.

El ancho y la altura se especifican en **puntos**, con 72 puntos por pulgada. Por ejemplo, 900 × 600 puntos equivale a 12,5 × 8⅓ pulgadas. Estos ajustes se aplican a la presentación, no a las notas de una diapositiva individual.

| Configuración | Propósito |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/notessize/) | Controla las dimensiones de la página de notas y las dimensiones de página utilizadas para la exportación de folletos. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slidesize/) | Controla las dimensiones de las diapositivas normales de la presentación a través de [ISlideSize](https://reference.aspose.com/slides/es/net/aspose.slides/islidesize/). |

Cambiar cualquiera de los ajustes no modifica automáticamente el otro. Cambiar la orientación de la página de notas tampoco gira las diapositivas normales. Consulte [Slide Size](/slides/es/net/slide-size/) para cambiar el tamaño de las diapositivas normales.

Los ejemplos a continuación utilizan un archivo `sample.pptx` existente. Para los ejemplos de exportación, use una presentación que contenga al menos una diapositiva con notas del presentador. Cada ejemplo puede ejecutarse de forma independiente.

## **Leer el tamaño y la orientación de la página de notas**

Lea el ancho y la altura y compárelos para determinar la orientación: una página más ancha es horizontal, una más alta es vertical y dimensiones iguales describen una página cuadrada. Este ejemplo muestra las dimensiones reales en puntos, sin asumir un tamaño de papel estándar.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Cambiar a horizontal sin modificar el tamaño del papel**

Para cambiar solo la orientación, intercambie el ancho y la altura existentes. Esto conserva la longitud de ambos lados, incluidos los de un tamaño de papel personalizado. La condición a continuación evita que una página ya horizontal se vuelva vertical y deja una página cuadrada sin cambios.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

Para orientación vertical, use la misma asignación cuando `size.Width > size.Height`. No sustituya dimensiones de A4 o Letter a menos que también desee cambiar el tamaño del papel.

## **Establecer y verificar un tamaño de página de notas personalizado**

Asigne ambas dimensiones a la vez y luego use [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) para guardar la presentación. Este ejemplo establece una página horizontal de 900 × 600 puntos, la guarda como PPTX y vuelve a abrir el archivo guardado para comprobar los valores persistidos. La comparación permite una tolerancia de 0,01 puntos para valores de punto flotante; no garantiza precisión para todos los formatos de archivo.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

El resultado esperado es `900 x 600 points` y `Size preserved: True`. Comprobar una presentación recién abierta verifica el archivo guardado, no solo la configuración en memoria.

## **Exportar notas y folletos**

Las dimensiones de la página definen el área disponible para diseños de notas o folletos. No habilitan esos diseños por sí mismas: también hay que configurar las opciones de exportación. La exportación de diapositivas normales sigue usando las dimensiones de la diapositiva.

### **Exportar notas a PDF y PNG**

Asigne [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/notescommentslayoutingoptions/) a [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) para incluir notas en el PDF. Este ejemplo también renderiza la primera diapositiva con notas a PNG usando [Slide.GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/slide/getimage/) y [RenderingOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/renderingoptions/).

El modo [BottomTruncated](https://reference.aspose.com/slides/es/net/aspose.slides.export/notespositions/) mantiene las notas en una sola página; las notas que no caben pueden truncarse. El PDF utiliza páginas de 900 × 600 puntos. Con la escala de imagen 1 × 1 usada a continuación, el PNG mide 900 × 600 píxeles. Los puntos describen la geometría de la página; los píxeles describen la salida raster, cuyas dimensiones también dependen de la escala de renderizado.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

Para la exportación a PDF con notas largas, [BottomFull](https://reference.aspose.com/slides/es/net/aspose.slides.export/notespositions/) permite páginas adicionales según sea necesario. No utilice ese modo con la llamada de imagen de diapositiva única anterior, que no lo admite. Después de cambiar el tamaño, inspeccione la salida para notas recortadas y la ubicación de los objetos existentes del maestro de notas; cambiar solo las dimensiones de la página no garantiza que todo el contenido quepa. Consulte [Convert PowerPoint to PDF with Notes](/slides/es/net/convert-powerpoint-to-pdf-with-notes/) para más información sobre la exportación de notas.

### **Exportar folletos a PDF**

Utilice [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/handoutlayoutingoptions/) para varios miniaturas de diapositiva en una página. El siguiente ejemplo establece una página de 900 × 600 puntos y usa [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/es/net/aspose.slides.export/handouttype/) para disponer hasta cuatro diapositivas por página. El preset horizontal controla el orden de las diapositivas; la orientación de la página proviene de su ancho y altura.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Cambiar el tamaño de la página modifica el área disponible para la cuadrícula del folleto sin cambiar las dimensiones de las diapositivas de origen. Para imágenes de folletos, use [Presentation.GetImages](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/getimages/) con el diseño de folleto, en lugar del método de imagen de una diapositiva individual. En Aspose.Slides, el renderizado de folletos a nivel de presentación usa las dimensiones de la página de notas, mientras que la llamada de imagen de diapositiva individual no produce la página de folleto. Consulte [Handout Mode](/slides/es/net/convert-powerpoint-in-handout-mode/) para opciones de diseño.

## **Tamaño de página en visores, exportación e impresión**

Mantenga separados el tamaño almacenado de la presentación, el tamaño de página exportado y el tamaño de papel impreso:

- **Visores de presentación:** Un visor puede mostrar o imprimir notas usando sus propias reglas de diseño. Si otra aplicación guarda el archivo, ábralo de nuevo y compruebe las dimensiones; la conversión de formato de esa aplicación puede normalizarlas.
- **Formatos de exportación:** Los ejemplos de PDF de notas y folletos anteriores usan las dimensiones de página configuradas. Las imágenes raster usan dimensiones de píxeles enteras y una escala de renderizado, por lo que los valores fraccionarios de puntos pueden redondearse en la salida de la imagen. Exportar diapositivas normales no aplica el tamaño de página de notas.
- **Controladores de impresora:** La selección de papel, la rotación automática y la configuración de ajuste a página pueden modificar la salida física sin cambiar las dimensiones almacenadas en la presentación o el PDF. Para un tamaño de papel específico, coincida con la configuración de la impresora e inspeccione la vista previa de impresión.

## **FAQ**

**¿Puedo establecer el tamaño de notas solo para una diapositiva?**

El tamaño de la página de notas es una configuración a nivel de presentación. Las diapositivas individuales pueden contener contenido de notas diferente, pero esta propiedad no proporciona un tamaño de página separado para cada diapositiva.

**¿Por qué al cambiar la orientación de las notas no cambiaron mis diapositivas?**

Las páginas de notas y las diapositivas normales tienen dimensiones independientes. Use la configuración de tamaño de diapositiva regular cuando desee redimensionar las propias diapositivas.

**¿Por qué el resultado guardado o impreso tiene un tamaño distinto?**

Primero vuelva a abrir la presentación guardada y compare sus dimensiones de notas. Si esas cambiaron, verifique si al guardar o convertir el archivo en otra aplicación se modificaron los ajustes de página. Si no, revise el diseño de exportación, la escala de imagen, la configuración del visor y la selección de papel de la impresora.