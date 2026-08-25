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
- recorrer diapositivas
- recorrer formas
- recorrer texto
- recopilar formas
- comprimir presentación
- eliminar diapositivas maestras no utilizadas
- eliminar diapositivas de diseño no utilizadas
- comprimir fuentes incrustadas
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Utilice la API de bajo código de Aspose.Slides en C++ para convertir y combinar presentaciones, recorrer el contenido, recopilar formas y reducir el tamaño de la presentación."
---
## **Visión general**

El espacio de nombres Aspose::Slides::LowCode proporciona clases auxiliares estáticas para operaciones comunes con presentaciones. Estas ayudas envuelven flujos de trabajo del modelo de objetos frecuentemente utilizados en métodos específicos, de modo que pueda convertir o combinar archivos, procesar elementos de la presentación, recopilar formas y eliminar contenido no utilizado con menos código.

Los ayudantes low‑code son más útiles cuando la operación se aplica a un archivo o presentación completa y el flujo de trabajo predeterminado se ajusta a sus requisitos. Utilice el modelo de objetos completo Aspose.Slides cuando necesite un control granular sobre diapositivas individuales, maestros, diseños, formas, configuraciones de exportación o relaciones entre los elementos de la presentación.

La tabla siguiente resume los ayudantes disponibles:

| Ayuda | Para qué sirve |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/convert/) | Convertir una presentación a otro formato mediante una llamada directa de archivo a archivo. |
| [Merger](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/merger/) | Combinar archivos de presentación completos del mismo formato. |
| [ForEach](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/) | Ejecutar una acción para cada diapositiva, forma, párrafo o porción de texto. |
| [Collect](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/collect/) | Obtener formas de toda la presentación para procesamiento o análisis repetido. |
| [Compress](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/) | Eliminar maestros y diseños no utilizados y reducir los datos de fuentes incrustadas. |

## **Convertir una presentación**

Use Convert::AutoByExtension cuando la extensión del archivo de salida sea suficiente para seleccionar el formato de exportación. El método abre la presentación de origen, determina el formato requerido a partir de la ruta de salida y escribe el resultado.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

La clase [Convert](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/convert/) también ofrece métodos dedicados para PDF, SVG, JPEG, PNG y TIFF. Utilice el modelo de objetos completo cuando necesite inspeccionar o modificar la presentación antes de la exportación o configurar una opción de exportación que no esté expuesta por el ayudante seleccionado. Vea [Convertir presentación](/slides/es/cpp/convert-presentation/) para flujos de trabajo y opciones específicas de formato.

## **Combinar presentaciones**

Use Merger::Process para combinar archivos de presentación completos con una única llamada. Las presentaciones de entrada deben tener el mismo formato de archivo.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

El ayudante es apropiado cuando todas las diapositivas deben añadirse a un único resultado sin seleccionarlas o reasignarlas individualmente. Utilice el modelo de objetos completo cuando necesite combinar diapositivas seleccionadas, aplicar un maestro o diseño de destino, conservar secciones explícitamente o conciliar tamaños de diapositiva diferentes. Vea [Combinar presentaciones](/slides/es/cpp/merge-presentation/) para esos escenarios.

## **Recorrer los elementos de la presentación**

La clase [ForEach](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/) invoca una devolución de llamada para cada tipo solicitado de elemento de presentación. Evita bucles de colección anidados y es cómoda para inspecciones o cambios de formato a nivel de toda la presentación.

El siguiente ejemplo usa [ForEach::Slide](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/paragraph/) y [ForEach::Portion](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/foreach/portion/) para inspeccionar los elementos correspondientes:

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

Por defecto, la recorrida de formas y texto en toda la presentación incluye diapositivas normales, de maestro y de diseño. Las sobrecargas con un parámetro `includeNotes` también pueden procesar diapositivas de notas. Utilice bucles de colección directos cuando el orden de recorrida, la salida temprana, el filtrado antes de la invocación de la devolución de llamada o el control detallado de padres‑hijos sea importante.

## **Recopilar formas**

Use Collect::Shapes cuando necesite una colección de todas las formas en una presentación en lugar de una devolución de llamada para cada forma. Esto es útil cuando el mismo conjunto será filtrado, contado o procesado más de una vez.

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

## **Comprimir contenido de la presentación**

La clase [Compress](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/) puede eliminar elementos estructurales no utilizados y reducir los datos de fuentes incrustadas:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) elimina diapositivas de diseño que no son referenciadas por ninguna diapositiva normal.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) elimina maestros que ya no se utilizan.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) elimina caracteres no usados de fuentes incrustadas.

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

Elimine los diseños no utilizados antes que los maestros no utilizados, de modo que un maestro que quede sin referencia tras la limpieza de diseños también pueda eliminarse. Guarde la presentación optimizada en un archivo nuevo si pudiera necesitar los maestros, diseños o datos completos de fuentes incrustadas originales más adelante. Para más detalle, vea [Maestro de diapositiva](/slides/es/cpp/slide-master/) y [Fuente incrustada](/slides/es/cpp/embedded-font/).

## **Preguntas frecuentes**

**¿Cuándo debo usar la API low‑code en lugar del modelo de objetos completo?**

Utilice los ayudantes low‑code cuando una operación estándar se aplica a un archivo o presentación completa y no requiere control detallado sobre elementos individuales. Use el modelo de objetos completo cuando necesite seleccionar diapositivas específicas, controlar relaciones de maestros y diseños, inspeccionar el estado intermedio o configurar un comportamiento que el ayudante no expone.

**¿Puede Merger combinar presentaciones en diferentes formatos de archivo?**

No. Merger::Process requiere que las presentaciones de entrada tengan el mismo formato. Convierta primero los archivos de entrada a un formato común, por ejemplo con Convert::AutoByExtension, y luego combine los archivos convertidos.

**¿ForEach procesa diapositivas de maestro, diseño y notas?**

ForEach::Slide recorre las diapositivas normales de la presentación. Las operaciones de todo el conjunto [ForEach::Shape], [ForEach::Paragraph] y [ForEach::Portion] incluyen por defecto diapositivas normales, de maestro y de diseño. Use sus sobrecargas con `includeNotes` establecido en `true` para incluir diapositivas de notas.

**¿Cuál es la diferencia entre ForEach::Shape y Collect::Shapes?**

Use ForEach::Shape para procesar cada forma inmediatamente mediante una devolución de llamada. Use Collect::Shapes cuando necesite un resultado enumerable que pueda conservarse, filtrarse, contarse o recorrerse varias veces.

**¿Compress siempre reduce el tamaño del archivo de presentación?**

No necesariamente. El resultado depende de si la presentación contiene diseños no usados, maestros no usados o fuentes incrustadas con caracteres no utilizados. Si ninguno de esos elementos está presente, las operaciones correspondientes de Compress pueden no disminuir el tamaño del archivo.

**¿Los cambios realizados por ForEach o Compress se guardan automáticamente?**

No. Estos ayudantes actúan sobre el objeto [Presentation] cargado en memoria. Después de modificar elementos en una devolución de llamada de ForEach o ejecutar Compress, llame a Presentation::Save para escribir el resultado.

## **Artículos relacionados**

- [Convertir presentación](/slides/es/cpp/convert-presentation/)
- [Combinar presentaciones](/slides/es/cpp/merge-presentation/)
- [Maestro de diapositiva](/slides/es/cpp/slide-master/)
- [Gestionar cuadro de texto](/slides/es/cpp/manage-textbox/)
- [Fuente incrustada](/slides/es/cpp/embedded-font/)