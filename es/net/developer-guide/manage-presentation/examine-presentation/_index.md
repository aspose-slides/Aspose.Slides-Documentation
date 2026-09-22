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
description: "Explore diapositivas, estructura y metadatos en presentaciones PowerPoint y OpenDocument usando .NET para obtener información más rápida y auditorías de contenido más inteligentes."
---
## **Visión general**

Aspose.Slides puede identificar el formato de una presentación y leer sus metadatos de documento sin crear un modelo de objetos de presentación completo. Esto es útil cuando necesita clasificar archivos, crear un inventario o inspeccionar propiedades antes de decidir si cargar y procesar el contenido de la presentación.

Este artículo muestra una inspección ligera mediante [PresentationFactory](https://reference.aspose.com/slides/es/net/aspose.slides/presentationfactory/) y [IPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/), así como actualizaciones dirigidas mediante [IDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/).

## **Comprobar el formato de una presentación**

Si ya tiene una presentación cargada, consulte [Determine the Original Presentation Format](/slides/es/net/detect-presentation-source-format/) para la detección después de la carga y las limitaciones de los flujos heredados PPT, PPS y POT.

Utilice [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/presentationfactory/getpresentationinfo/) para inspeccionar un archivo sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/). La propiedad [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/loadformat/) informa del formato detectado, como PPTX, PPT u ODP.

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

Cuando procesa muchos archivos de presentación, puede necesitar un inventario compacto para validación, indexación o un sistema de gestión documental. En este escenario, utilice [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/presentationfactory/getpresentationinfo/) para obtener un objeto [IPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/) y, a continuación, llame a [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/readdocumentproperties/) para leer los metadatos del documento. Este enfoque no crea una instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) ni requiere recorrer todo el modelo de objetos de la presentación.

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

Cada [IHeadingPair](https://reference.aspose.com/slides/es/net/aspose.slides/iheadingpair/) suministra un nombre de grupo y el número de elementos en ese grupo. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/titlesofparts/) es una matriz plana y ordenada, por lo que debe consumir el número de títulos consecutivos especificado por cada pareja de encabezado.

### **Metadatos almacenados y limitaciones de formato**

Las propiedades de inventario devueltas por [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/readdocumentproperties/) reflejan los metadatos disponibles en el documento origen. Aspose.Slides no carga ni recorre el modelo de objetos de la presentación para recalcular estos valores en esta llamada. Las propiedades ausentes se representan con valores predeterminados, y los valores almacenados pueden estar desactualizados si la aplicación que guardó el archivo por última vez no actualizó sus propiedades de documento.

- **PPTX:** El formato proporciona propiedades de documento extendidas para recuentos de diapositivas, notas, diapositivas ocultas, párrafos, palabras y elementos multimedia, así como parejas de encabezado y títulos de partes. La disponibilidad depende de qué propiedades haya escrito el productor del documento.
- **PPT:** El formato binario puede almacenar propiedades de resumen de documento correspondientes. Si una propiedad está ausente o no fue actualizada por el productor del documento, Aspose.Slides devuelve su valor almacenado o predeterminado en lugar de calcularlo a partir de las diapositivas.
- **ODP:** Los metadatos OpenDocument proporcionan estadísticas generales del documento, como recuentos de páginas, párrafos y palabras, pero esos valores no se corresponden con todas las propiedades extendidas específicas de PowerPoint. Los metadatos de diapositivas ocultas, notas, multimedia, parejas de encabezado y títulos de partes pueden no estar disponibles, y las propiedades de inventario pueden devolver valores predeterminados. No trate un valor cero o una matriz vacía como prueba concluyente de que el contenido correspondiente está ausente.

Utilice el enfoque de metadatos ligeros para inventarios y comprobaciones preliminares. Cargue la presentación e inspeccione su modelo de objetos en tiempo real cuando el resultado deba reflejar cambios en memoria o cuando necesite verificar el contenido real de la presentación.

## **Actualizar propiedades de la presentación**

Las propiedades devueltas por [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/readdocumentproperties/) también pueden modificarse sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/). Aplique los cambios con [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/updatedocumentproperties/), y luego escriba la presentación vinculada con [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

La siguiente imagen muestra las propiedades originales del documento de la presentación PowerPoint.

![Propiedades originales del documento de la presentación PowerPoint](input_properties.png)

El siguiente ejemplo cambia el título y la fecha de última guardado y escribe el resultado en un nuevo archivo:

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

La siguiente imagen muestra las propiedades modificadas del documento de la presentación PowerPoint.

![Propiedades modificadas del documento de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

Para comprobaciones de seguridad relacionadas y configuraciones de protección, consulte los siguientes artículos:

- [Password-Protect Presentations](/slides/es/net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/es/net/write-protected-presentation/)

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Cargue la presentación y use [Presentation.FontsManager](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/fontsmanager/). Llame a [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/es/net/aspose.slides/fontsmanager/getembeddedfonts/) para obtener las fuentes incrustadas y a [FontsManager.GetFonts](https://reference.aspose.com/slides/es/net/aspose.slides/fontsmanager/getfonts/) para obtener las fuentes utilizadas por la presentación. Compare los dos resultados para encontrar fuentes que son necesarias para la renderización pero no están incrustadas.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Cuando los metadatos almacenados del documento son suficientes, lea [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/es/net/aspose.slides/idocumentproperties/hiddenslides/) a través de [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/presentationfactory/getpresentationinfo/) y [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/readdocumentproperties/). Esto es adecuado para un inventario ligero. Si la presentación ha sido modificada en memoria, los metadatos almacenados pueden estar ausentes o desactualizados, o necesita verificar valores en tiempo real; recorra [Presentation.Slides](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slides/es/) y examine la propiedad [Slide.Hidden](https://reference.aspose.com/slides/es/net/aspose.slides/slide/hidden/) de cada diapositiva.

**¿Puedo detectar si se utiliza un tamaño y orientación de diapositiva personalizados, y si difieren de los valores predeterminados?**

Sí. Cargue la presentación y lea [Presentation.SlideSize](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slidesize/). Inspeccione [ISlideSize.Type](https://reference.aspose.com/slides/es/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/es/net/aspose.slides/islidesize/size/) y [ISlideSize.Orientation](https://reference.aspose.com/slides/es/net/aspose.slides/islidesize/orientation/) para comparar la configuración actual con el preset y dimensiones esperados.

**¿Existe una forma rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Localice cada [Chart](https://reference.aspose.com/slides/es/net/aspose.slides.charts/chart/) e inspeccione [ChartData.DataSourceType](https://reference.aspose.com/slides/es/net/aspose.slides.charts/chartdata/datasourcetype/). Para un libro de trabajo externo, lea [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/es/net/aspose.slides.charts/chartdata/externalworkbookpath/). El tipo de fuente de datos y la ruta identifican una referencia externa, pero verificar si el recurso está disponible requiere una comprobación adicional.

**¿Cómo puedo evaluar diapositivas 'pesadas' que pueden ralentizar la renderización o la exportación a PDF?**

No existe una única propiedad de complejidad. Recorra [Presentation.Slides](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slides/es/) y la colección [IBaseSlide.Shapes](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/shapes/) de cada diapositiva. Utilice el recuento de formas y la presencia de imágenes grandes, efectos, animaciones o multimedia como señales de filtrado, y mida una renderización o exportación representativa antes de considerar una diapositiva como un cuello de botella confirmado.