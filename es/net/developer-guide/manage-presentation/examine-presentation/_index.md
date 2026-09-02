---
title: Recuperar y actualizar información de la presentación en .NET
linktitle: Información de la presentación
type: docs
weight: 30
url: /es/net/examine-presentation/
keywords:
- formato de presentación
- propiedades de la presentación
- propiedades del documento
- obtener propiedades
- leer propiedades
- cambiar propiedades
- modificar propiedades
- actualizar propiedades
- examinar PPTX
- examinar PPT
- examinar ODP
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Explora diapositivas, estructura y metadatos en presentaciones PowerPoint y OpenDocument usando .NET para obtener insights más rápidos y auditorías de contenido más inteligentes."
---
## **Visión general**

Aspose.Slides puede identificar el formato de una presentación y leer sus metadatos de documento sin crear un modelo de objeto de presentación completo. Esto es útil cuando necesitas clasificar archivos, crear un inventario o inspeccionar propiedades antes de decidir si cargar y procesar el contenido de la presentación.

Este artículo muestra la inspección ligera mediante [PresentationFactory](https://reference.aspose.com/slides/es/net/aspose.slides/presentationfactory/) y [IPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/), así como actualizaciones específicas mediante [IDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/).

## **Comprobar el formato de una presentación**

Utiliza [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/presentationfactory/getpresentationinfo/) para inspeccionar un archivo sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/). La propiedad [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/loadformat/) informa del formato detectado, como PPTX, PPT u ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Crear un inventario ligero de presentaciones**

Cuando procesas muchos archivos de presentación, puede que necesites un inventario compacto para validación, indexación o un sistema de gestión documental. En este caso, utiliza [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/presentationfactory/getpresentationinfo/) para obtener un objeto [IPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/) y, a continuación, llama a [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/readdocumentproperties/) para leer los metadatos del documento. Este enfoque no crea una instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) ni requiere recorrer todo el modelo de objeto de la presentación.

Las propiedades extendidas expuestas por [IDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/) proporcionan los siguientes valores de inventario:

| Propiedad | Valor de inventario |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/slides/es/) | Número total de diapositivas. |
| [HiddenSlides](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/hiddenslides/) | Número de diapositivas ocultas. |
| [Notes](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/notes/) | Número de diapositivas que contienen notas. |
| [Paragraphs](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/paragraphs/) | Número total de párrafos, cuando está disponible. |
| [Words](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/words/) | Número total de palabras. |
| [MultimediaClips](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/multimediaclips/) | Número total de clips de audio y vídeo. |

El siguiente ejemplo lee estos valores sin crear un objeto [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) e imprime un inventario compacto. También combina [HeadingPairs](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/headingpairs/) con [TitlesOfParts](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/titlesofparts/) para mostrar grupos de contenido como fuentes, temas y títulos de diapositivas.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Cada [IHeadingPair](https://reference.aspose.com/slides/es/net/aspose.slides/iheadingpair/) suministra un nombre de grupo y el número de elementos en ese grupo. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/titlesofparts/) es una matriz plana y ordenada, por lo que se consumen el número de títulos consecutivos especificado por cada pareja de encabezado.

### **Metadatos almacenados y limitaciones de formato**

Las propiedades de inventario devueltas por [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/readdocumentproperties/) reflejan los metadatos disponibles en el documento de origen. Aspose.Slides no carga y recorre el modelo de objeto de la presentación para recalcular estos valores en esta llamada. Las propiedades ausentes se representan con valores predeterminados, y los valores almacenados pueden estar desactualizados si la aplicación que guardó por última vez el archivo no actualizó sus propiedades de documento.

- **PPTX:** El formato proporciona propiedades de documento extendidas para recuentos de diapositivas, notas, diapositivas ocultas, párrafos, palabras y elementos multimedia, así como pares de encabezado y títulos de partes. La disponibilidad depende de qué propiedades fueron escritas por el productor del documento.
- **PPT:** El formato binario puede almacenar las propiedades de resumen de documento correspondientes. Si una propiedad está ausente o no fue actualizada por el productor del documento, Aspose.Slides devuelve su valor almacenado o predeterminado en lugar de calcularlo a partir de las diapositivas.
- **ODP:** Los metadatos de OpenDocument proporcionan estadísticas generales del documento, como recuentos de páginas, párrafos y palabras, pero estos valores no se asignan a todas las propiedades extendidas específicas de PowerPoint. Los metadatos de diapositivas ocultas, notas, multimedia, pares de encabezado y títulos de partes pueden no estar disponibles, y las propiedades de inventario pueden devolver valores predeterminados. No consideres que un valor cero o una matriz vacía sea una prueba concluyente de que el contenido correspondiente está ausente.

Utiliza el enfoque de metadatos ligeros para inventarios y comprobaciones preliminares. Carga la presentación e inspecciona su modelo de objeto en tiempo de ejecución cuando el resultado debe reflejar los cambios en memoria o cuando necesitas verificar el contenido real de la presentación.

## **Actualizar propiedades de la presentación**

Las propiedades devueltas por [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/readdocumentproperties/) también pueden modificarse sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/). Aplica los cambios con [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) y, a continuación, escribe la presentación vinculada con [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

La siguiente imagen muestra las propiedades originales del documento.

![Propiedades originales del documento de la presentación PowerPoint](input_properties.png)

El siguiente ejemplo cambia el título y la hora de la última guardada y escribe el resultado en un nuevo archivo:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

La siguiente imagen muestra las propiedades del documento actualizadas.

![Propiedades del documento modificadas de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

Para comprobaciones de seguridad relacionadas y configuraciones de protección, consulta los siguientes artículos:

- [Password-Protect Presentations](/slides/es/net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/es/net/write-protected-presentation/)

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Carga la presentación y utiliza [Presentation.FontsManager](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/fontsmanager/). Llama a [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/es/net/aspose.slides/fontsmanager/getembeddedfonts/) para obtener las fuentes incrustadas y a [FontsManager.GetFonts](https://reference.aspose.com/slides/es/net/aspose.slides/fontsmanager/getfonts/) para obtener las fuentes usadas por la presentación. Compara los dos resultados para encontrar fuentes que son necesarias para la renderización pero no están incrustadas.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Cuando los metadatos del documento almacenado son suficientes, lee [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/hiddenslides/) a través de [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/presentationfactory/getpresentationinfo/) y [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/readdocumentproperties/). Esto es adecuado para un inventario ligero. Si la presentación se ha modificado en memoria, los metadatos almacenados pueden estar ausentes o desactualizados, o necesitas verificar los valores en tiempo real, recorre [Presentation.Slides](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slides/es/) y examina la propiedad [Slide.Hidden](https://reference.aspose.com/slides/es/net/aspose.slides/slide/hidden/) de cada diapositiva.

**¿Puedo detectar si se usa un tamaño y orientación de diapositiva personalizados y si difieren de los predeterminados?**

Sí. Carga la presentación y lee [Presentation.SlideSize](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slidesize/). Inspecciona [ISlideSize.Type](https://reference.aspose.com/slides/es/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/es/net/aspose.slides/islidesize/size/) y [ISlideSize.Orientation](https://reference.aspose.com/slides/es/net/aspose.slides/islidesize/orientation/) para comparar la configuración actual con la predefinida y sus dimensiones.

**¿Existe una forma rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Localiza cada [Chart](https://reference.aspose.com/slides/es/net/aspose.slides.charts/chart/) e inspecciona [ChartData.DataSourceType](https://reference.aspose.com/slides/es/net/aspose.slides.charts/chartdata/datasourcetype/). Para un libro de trabajo externo, lee [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/es/net/aspose.slides.charts/chartdata/externalworkbookpath/). El tipo de fuente de datos y la ruta identifican una referencia externa, pero verificar si el destino está disponible requiere una comprobación de recursos independiente.

**¿Cómo puedo evaluar las diapositivas “pesadas” que pueden ralentizar la renderización o la exportación a PDF?**

No existe una sola propiedad de complejidad. Recorre [Presentation.Slides](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slides/es/) y la colección [IBaseSlide.Shapes](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/shapes/) de cada diapositiva. Utiliza el recuento de formas y la presencia de imágenes grandes, efectos, animaciones o elementos multimedia como señales de alerta, y mide una renderización o exportación representativa antes de considerar una diapositiva como un cuello de botella de rendimiento confirmado.