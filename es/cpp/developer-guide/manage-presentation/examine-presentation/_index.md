---
title: Recuperar y actualizar la información de la presentación en C++
linktitle: Información de la presentación
type: docs
weight: 30
url: /es/cpp/examine-presentation/
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
- C++
- Aspose.Slides
description: "Explore diapositivas, estructura y metadatos en presentaciones PowerPoint y OpenDocument usando C++ para obtener información más rápida y auditorías de contenido más inteligentes."
---
## **Visión general**

Aspose.Slides puede identificar el formato de una presentación y leer sus metadatos de documento sin crear un modelo de objetos de presentación completo. Esto resulta útil cuando necesita clasificar archivos, crear un inventario o inspeccionar propiedades antes de decidir si cargar y procesar el contenido de la presentación.

Este artículo muestra cómo inspeccionar de forma ligera a través de [PresentationFactory](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentationfactory/) y [IPresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/), así como actualizaciones específicas mediante [IDocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/).

## **Comprobar el formato de una presentación**

Utilice [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) para inspeccionar un archivo sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/). El método [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/get_loadformat/) informa del formato detectado, como PPTX, PPT u ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Crear un inventario ligero de presentaciones**

Cuando procesa muchos archivos de presentación, puede necesitar un inventario compacto para validación, indexación o un sistema de gestión documental. En este caso, utilice [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) para obtener un objeto [IPresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/), y luego llame a [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) para leer los metadatos del documento. Este enfoque no crea una instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) ni requiere que recorra todo el modelo de objetos de la presentación.

Las propiedades extendidas expuestas por [IDocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/) proporcionan los siguientes valores de inventario:

| Método | Valor del inventario |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/get_slides/) | Número total de diapositivas. |
| [get_HiddenSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Número de diapositivas ocultas. |
| [get_Notes](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/get_notes/) | Número de diapositivas que contienen notas. |
| [get_Paragraphs](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Número total de párrafos, cuando estén disponibles. |
| [get_Words](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/get_words/) | Número total de palabras. |
| [get_MultimediaClips](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Número total de clips de audio y video. |

El siguiente ejemplo lee estos valores sin crear un objeto [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) e imprime un inventario compacto. También combina [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/get_headingpairs/) con [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) para mostrar grupos de contenido como fuentes, temas y títulos de diapositivas.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Cada [IHeadingPair](https://reference.aspose.com/slides/es/cpp/aspose.slides/iheadingpair/) proporciona un nombre de grupo mediante [IHeadingPair::get_Name](https://reference.aspose.com/slides/es/cpp/aspose.slides/iheadingpair/get_name/) y el número de elementos en ese grupo mediante [IHeadingPair::get_Count](https://reference.aspose.com/slides/es/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) devuelve una matriz plana y ordenada, por lo que debe consumir el número de títulos consecutivos especificado por cada pareja de encabezado.

### **Metadatos almacenados y limitaciones de formato**

Las propiedades de inventario devueltas por [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) reflejan los metadatos disponibles en el documento fuente. Aspose.Slides no carga ni recorre el modelo de objetos de la presentación para recalcular estos valores en esta llamada. Las propiedades ausentes se representan con valores por defecto, y los valores almacenados pueden estar desactualizados si la aplicación que guardó por última vez el archivo no actualizó sus propiedades de documento.

- **PPTX:** El formato proporciona propiedades de documento extendidas para recuentos de diapositivas, notas, diapositivas ocultas, párrafos, palabras y multimedia, así como parejas de encabezado y títulos de partes. La disponibilidad depende de qué propiedades fueron escritas por el creador del documento.
- **PPT:** El formato binario puede almacenar propiedades de resumen de documento correspondientes. Si una propiedad está ausente o no fue actualizada por el creador del documento, Aspose.Slides devuelve su valor almacenado o por defecto en lugar de calcularlo a partir de las diapositivas.
- **ODP:** Los metadatos de OpenDocument proporcionan estadísticas generales del documento, como recuentos de páginas, párrafos y palabras, pero estos valores no se asignan a todas las propiedades extendidas específicas de PowerPoint. Los metadatos de diapositivas ocultas, notas, multimedia, parejas de encabezado y títulos de partes pueden no estar disponibles, y las propiedades de inventario pueden devolver valores por defecto. No trate un valor cero o una matriz vacía como prueba concluyente de que el contenido correspondiente está ausente.

Utilice el enfoque de metadatos ligeros para inventarios y verificaciones preliminares. Cargue la presentación e inspeccione su modelo de objetos en tiempo real cuando el resultado deba reflejar cambios en memoria o cuando necesite verificar el contenido real de la presentación.

## **Actualizar propiedades de la presentación**

Las propiedades devueltas por [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) también pueden modificarse sin crear una instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/). Aplique los cambios con [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/), y luego escriba la presentación vinculada con [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

La siguiente imagen muestra las propiedades originales del documento.

![Propiedades originales del documento de la presentación PowerPoint](input_properties.png)

El siguiente ejemplo cambia el título y la hora de la última guardado y escribe el resultado en un archivo nuevo:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

La siguiente imagen muestra las propiedades actualizadas del documento.

![Propiedades modificadas del documento de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

Para verificaciones de seguridad relacionadas y configuraciones de protección, consulte los siguientes artículos:

- [Presentaciones protegidas con contraseña](/slides/es/cpp/password-protected-presentation/)
- [Presentaciones protegidas contra escritura](/slides/es/cpp/write-protected-presentation/)

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Cargue la presentación y utilice [Presentation::get_FontsManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_fontsmanager/). Llame a [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsmanager/getembeddedfonts/) para obtener las fuentes incrustadas y a [FontsManager::GetFonts](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsmanager/getfonts/) para obtener las fuentes usadas por la presentación. Compare los dos resultados para encontrar fuentes que son necesarias para la renderización pero no están incrustadas.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Cuando los metadatos almacenados del documento son suficientes, lea [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) a través de [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) y [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). Esto es adecuado para un inventario ligero. Si la presentación ha sido modificada en memoria, los metadatos almacenados pueden estar ausentes o desactualizados, o si necesita verificar valores en tiempo real, itere a través de [Presentation::get_Slides](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_slides/) e inspeccione el método [Slide::get_Hidden](https://reference.aspose.com/slides/es/cpp/aspose.slides/slide/get_hidden/) de cada diapositiva.

**¿Puedo detectar si se utiliza un tamaño y orientación de diapositiva personalizados, y si difieren de los valores predeterminados?**

Sí. Cargue la presentación y lea [Presentation::get_SlideSize](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_slidesize/). Inspeccione [ISlideSize::get_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidesize/get_size/) y [ISlideSize::get_Orientation](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidesize/get_orientation/) para comparar la configuración actual con el preset y dimensiones esperados.

**¿Existe una forma rápida de saber si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Localice cada [Chart](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chart/) e inspeccione [ChartData::get_DataSourceType](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). Para un libro de trabajo externo, lea [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). El tipo de fuente de datos y la ruta identifican una referencia externa, pero verificar si el objetivo está disponible requiere una comprobación de recursos aparte.

**¿Cómo puedo evaluar las diapositivas 'pesadas' que pueden ralentizar la renderización o la exportación a PDF?**

No existe una única propiedad de complejidad. Recorrra [Presentation::get_Slides](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_slides/) y la colección [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseslide/get_shapes/) de cada diapositiva. Utilice el recuento de formas y la presencia de imágenes grandes, efectos, animaciones o multimedia como señales de filtrado, y mida una renderización o exportación representativa antes de considerar una diapositiva como un cuello de botella de rendimiento confirmado.