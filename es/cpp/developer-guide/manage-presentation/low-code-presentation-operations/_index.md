---
title: Operaciones de presentación de bajo código en C++
linktitle: API de bajo código
type: docs
weight: 50
url: /es/cpp/low-code-presentation-operations/
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
- C++
- Aspose.Slides
description: "Utilice la API de bajo código de Aspose.Slides en C++ para convertir y combinar presentaciones, iterar a través del contenido, recopilar formas y reducir el tamaño de la presentación."
---
## **Descripción general**

El espacio de nombres [Aspose::Slides::LowCode](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/) proporciona clases estáticas de ayuda para operaciones comunes de presentaciones. Estas ayudas envuelven flujos de trabajo del modelo de objetos frecuentemente usados en métodos focalizados, de modo que puedes convertir o combinar archivos, procesar elementos de la presentación, recopilar formas y eliminar contenido no utilizado con menos código.

Los asistentes de bajo código son más útiles cuando la operación se aplica a un archivo o presentación completa y el flujo de trabajo predeterminado coincide con sus requisitos. Utilice el [modelo de objetos completo de Aspose.Slides](https://reference.aspose.com/slides/es/cpp/aspose.slides/) cuando necesite un control fino sobre diapositivas individuales, maestros, diseños, formas, configuraciones de exportación o relaciones entre los elementos de la presentación.

La tabla siguiente resume los asistentes disponibles:

| Asistente | Para qué se usa |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/convert/) | Convertir una presentación a otro formato con una llamada directa de archivo a archivo. |
| [Merger](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/merger/) | Combinar archivos de presentación completos del mismo formato. |
| [ForEach](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/) | Ejecutar una acción para cada diapositiva, forma, párrafo o fragmento de texto. |
| [Collect](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/collect/) | Recuperar formas de toda la presentación para procesamiento o análisis repetido. |
| [Compress](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/) | Eliminar maestros y diseños no utilizados y reducir los datos de fuentes incrustadas. |

## **Convertir una presentación**

Utilice [Convert::AutoByExtension](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/convert/autobyextension/) cuando la extensión del archivo de salida sea suficiente para seleccionar el formato de exportación. El método abre la presentación de origen, determina el formato necesario a partir de la ruta de salida y escribe el resultado.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

La clase [Convert](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/convert/) también proporciona métodos específicos para salida en PDF, SVG, JPEG, PNG y TIFF. Utilice el modelo de objetos completo cuando necesite inspeccionar o modificar la presentación antes de la exportación o configurar una opción de exportación que no esté expuesta por el asistente seleccionado. Consulte [Convert Presentation](/cpp/convert-presentation/) para flujos de trabajo y opciones específicas de cada formato.

## **Combinar presentaciones**

Utilice [Merger::Process](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/merger/process/) para combinar archivos de presentación completos con una sola llamada. Las presentaciones de entrada deben tener el mismo formato de archivo.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

El asistente es apropiado cuando todas las diapositivas deben agregarse a un único resultado sin seleccionarlas o remapearlas individualmente. Utilice el modelo de objetos completo cuando necesite combinar diapositivas seleccionadas, aplicar un maestro o diseño de destino, preservar secciones de forma explícita o reconciliar diferentes tamaños de diapositiva. Consulte [Merge Presentations](/cpp/merge-presentation/) para esos escenarios.

## **Iterar a través de los elementos de la presentación**

La clase [ForEach](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/) invoca una devolución de llamada para cada tipo solicitado de elemento de la presentación. Evita bucles de colección anidados y es conveniente para inspecciones o cambios de formato a nivel de toda la presentación.

El siguiente ejemplo utiliza [ForEach::Slide](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/paragraph/), y [ForEach::Portion](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/portion/) para inspeccionar los elementos correspondientes:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

Por defecto, el recorrido de formas y texto a nivel de presentación incluye diapositivas normales, maestras y de diseño. Las sobrecargas con un parámetro `includeNotes` también pueden procesar diapositivas de notas. Utilice bucles de colección directos cuando el orden de recorrido, la salida anticipada, el filtrado antes de la invocación de la devolución de llamada o el control detallado padre‑hijo sean importantes.

## **Recopilar formas**

Utilice [Collect::Shapes](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/collect/shapes/) cuando necesite una colección de todas las formas de una presentación en lugar de una devolución de llamada para cada forma. Esto es útil cuando el mismo conjunto será filtrado, contado o procesado más de una vez.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Utilice [ForEach::Shape](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/shape/) en su lugar cuando cada forma pueda manejarse inmediatamente y no necesite conservar el resultado recopilado.

## **Comprimir el contenido de la presentación**

La clase [Compress](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/) puede eliminar elementos estructurales no utilizados y reducir los datos de fuentes incrustadas:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) elimina las diapositivas de diseño que no son referenciadas por ninguna diapositiva normal.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) elimina las diapositivas maestras que ya no se usan.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) elimina los caracteres no utilizados de las fuentes incrustadas.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Elimine los diseños no utilizados antes que los maestros no utilizados, de modo que un maestro que quede sin referencia después de la limpieza de diseños también pueda eliminarse. Guarde la presentación optimizada en un nuevo archivo si puede necesitar más tarde los maestros, diseños originales o los datos completos de fuentes incrustadas. Para más detalle, consulte [Slide Master](/cpp/slide-master/) y [Embedded Font](/cpp/embedded-font/).

## **Preguntas frecuentes**

**¿Cuándo debo usar la API de bajo código en lugar del modelo de objetos completo?**

Utilice los asistentes de bajo código cuando una operación estándar se aplique a un archivo o presentación completa y no requiera un control detallado sobre los elementos individuales. Utilice el modelo de objetos completo cuando necesite seleccionar diapositivas específicas, controlar las relaciones entre maestros y diseños, inspeccionar el estado intermedio o configurar un comportamiento que el asistente no expone.

**¿Puede Merger combinar presentaciones en diferentes formatos de archivo?**

No. [Merger::Process](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/merger/process/) requiere que las presentaciones de entrada estén en el mismo formato. Convierta los archivos de entrada a un formato común primero, por ejemplo con [Convert::AutoByExtension](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/convert/autobyextension/), y luego combine los archivos convertidos.

**¿Procesa ForEach las diapositivas maestras, de diseño y de notas?**

[ForEach::Slide](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/slide/) recorre las diapositivas normales de la presentación. Las operaciones a nivel de presentación de [ForEach::Shape](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/paragraph/) y [ForEach::Portion](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/portion/) incluyen por defecto diapositivas normales, maestras y de diseño. Utilice sus sobrecargas con el parámetro `includeNotes` establecido en `true` para incluir las diapositivas de notas.

**¿Cuál es la diferencia entre ForEach::Shape y Collect::Shapes?**

Utilice [ForEach::Shape](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/shape/) para procesar cada forma inmediatamente mediante una devolución de llamada. Utilice [Collect::Shapes](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/collect/shapes/) cuando necesite un resultado enumerable que pueda conservarse, filtrarse, contarse o recorrerse varias veces.

**¿Compress siempre reduce el tamaño del archivo de la presentación?**

No necesariamente. El resultado depende de si la presentación contiene diseños no utilizados, maestros no utilizados o fuentes incrustadas con caracteres sin usar. Si ninguno de estos está presente, las operaciones correspondientes de [Compress](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/) pueden no reducir el tamaño del archivo.

**¿Los cambios realizados por ForEach o Compress se guardan automáticamente?**

No. Estos asistentes operan sobre el objeto [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) cargado en memoria. Después de modificar elementos en una devolución de llamada de [ForEach](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/) o ejecutar [Compress](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/), llame a [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/) para escribir el resultado.

## **Artículos relacionados**

- [Convertir presentación](/cpp/convert-presentation/)
- [Combinar presentaciones](/cpp/merge-presentation/)
- [Máster de diapositiva](/cpp/slide-master/)
- [Gestionar cuadro de texto](/cpp/manage-textbox/)
- [Fuente incrustada](/cpp/embedded-font/)