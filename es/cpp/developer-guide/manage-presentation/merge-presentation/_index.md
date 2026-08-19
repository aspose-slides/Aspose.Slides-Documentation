---
title: Fusionar presentaciones de forma eficiente en C++
linktitle: Fusionar presentaciones
type: docs
weight: 40
url: /es/cpp/merge-presentation/
keywords:
- fusionar PowerPoint
- fusionar presentaciones
- fusionar diapositivas
- fusionar PPT
- fusionar PPTX
- fusionar ODP
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- C++
- Aspose.Slides
description: "Aprenda cómo fusionar presentaciones PowerPoint y OpenDocument en C++ mediante la clonación de diapositivas, el control de maestras y diseños, el redimensionado del contenido de las diapositivas, la preservación de secciones y la gestión de archivos protegidos o de gran tamaño."
---
## **Visión general**

Aspose.Slides para C++ combina presentaciones clonando diapositivas de una [Presentación](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) a otra. La operación principal es [ISlideCollection::AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/), que puede conservar el formato original de la diapositiva o adjuntar la diapositiva clonada a una diapositiva maestra o a un diseño en la presentación de destino.

Este artículo cubre los flujos de trabajo de combinación más habituales:

- combinar todas las diapositivas conservando su formato original;
- combinar diapositivas seleccionadas;
- aplicar una maestra de la presentación de destino;
- aplicar un diseño específico de la presentación de destino;
- normalizar tamaños de diapositiva diferentes antes de combinar;
- añadir diapositivas clonadas a una sección;
- combinar varias presentaciones en un flujo de trabajo completo;
- gestionar maestras, recursos, notas, comentarios, medios, fuentes, contraseñas, archivos grandes y cuestiones de multihilo.

## **Cómo afecta la clonación de diapositivas a maestras y diseños**

Una diapositiva hereda gran parte de su apariencia de su diseño y maestra. Por ese motivo, la sobrecarga de clonación que elija determina cómo se integra la diapositiva combinada en la presentación de destino.

Utilice [ISlideCollection::AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) de una de estas formas:

- `AddClone(sourceSlide)` — conserva el diseño y formato de la diapositiva original. Cuando sea necesario, la maestra de origen puede clonarse automáticamente en la presentación de destino. Aspose.Slides rastrea las maestras clonadas automáticamente para que diapositivas repetidas que usen la misma maestra de origen no provoquen una clonación múltiple.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — adjunta la diapositiva clonada a una [IMasterSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/) de destino concreta. Aspose.Slides busca un diseño coincidente bajo esa maestra por tipo o nombre.
- `AddClone(sourceSlide, destinationLayout)` — adjunta la diapositiva clonada directamente a una [ILayoutSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/) de destino concreta.

La maestra o el diseño pasado a una sobrecarga `AddClone` debe pertenecer a la **presentación de destino**, no a la presentación de origen.

## **Combinar presentaciones completas y conservar el formato original**

La combinación más simple copia cada diapositiva de la presentación de origen a la de destino. Esta es la opción adecuada cuando las diapositivas importadas deben mantener su tema, maestra y relaciones de diseño originales.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

La presentación resultante puede contener varias maestras cuando el origen y el destino usan diseños diferentes. Esto es normal cuando se conserva intencionalmente el formato de origen.

## **Combinar diapositivas seleccionadas**

No es necesario clonar todas las diapositivas. El siguiente ejemplo importa solo los índices de diapositiva seleccionados de la presentación de origen.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

Valide los índices de diapositiva antes de clonarlos cuando provengan de la entrada del usuario o de una configuración externa.

## **Combinar diapositivas usando una maestra de destino**

Utilice la sobrecarga [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) cuando las diapositivas importadas deben seguir una maestra que ya pertenece a la presentación de destino.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides selecciona un diseño apropiado bajo la maestra especificada coincidiendo con el tipo o nombre del diseño de origen. Si no existe un diseño adecuado y `allowCloneMissingLayout` es `true`, el diseño de origen se clona para que la diapositiva pueda añadirse. Si es `false`, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/cpp/aspose.slides/details_pptxeditexception/).

Use `false` cuando desee que la combinación falle en lugar de introducir un diseño adicional en la maestra de destino.

## **Combinar diapositivas usando un diseño de destino específico**

Utilice la sobrecarga [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) cuando sepa exactamente qué diseño de destino deben usar las diapositivas importadas.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

Aplicar un diseño de destino cambia la relación de diseño heredada; no rediseña el contenido de la diapositiva original. Si los diseños de origen y destino tienen estructuras de marcadores de posición diferentes, inspeccione el resultado para confirmar que el formato heredado y el comportamiento de los marcadores son adecuados.

## **Combinar presentaciones con tamaños de diapositiva diferentes**

Las presentaciones con dimensiones de diapositiva distintas pueden combinarse, pero clonar una diapositiva en una presentación con otro tamaño no rediseña automáticamente su contenido para el nuevo lienzo. Las formas pueden aparecer desplazadas, escaladas de forma inesperada o fuera del área visible.

Un enfoque práctico es cambiar el tamaño de la presentación de origen antes de clonar. El método [SlideSize::SetSize](https://reference.aspose.com/slides/es/cpp/aspose.slides/slidesize/setsize/) puede escalar el contenido existente mientras modifica las dimensiones. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/es/cpp/aspose.slides/slidesizescaletype/) escala el contenido para que quepa en el tamaño solicitado.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

Redimensionar modifica el objeto de la presentación de origen en memoria. Si necesita conservar la presentación original sin cambios para otras operaciones, abra una instancia separada para la combinación.

## **Combinar diapositivas en una sección de la presentación**

El bucle básico de clonación de diapositivas no recrea la jerarquía de secciones de la presentación de origen. Si las secciones son importantes en la salida, cree o seleccione secciones en la presentación de destino y clone las diapositivas en ellas explícitamente con [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/).

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

Las diapositivas clonadas se añaden al final de la sección de destino especificada. Para conservar varias secciones de origen, recree esas secciones en el destino y asocie cada diapositiva de origen con la sección de destino correspondiente.

## **Combinar varias presentaciones de forma segura**

El siguiente ejemplo integral usa la primera presentación como destino, normaliza el tamaño de diapositiva de cada fuente adicional, mantiene cada fuente abierta solo mientras se copia y guarda el archivo final una sola vez.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

Este es un punto de partida útil para conservar el formato original de las diapositivas importadas. Si su salida debe usar un único tema de destino, reemplace la llamada simple `AddClone(slide)` por la sobrecarga de maestra o diseño de destino adecuada mostrada anteriormente.

## **Consideraciones prácticas**

### **Maestras, diseños y fidelidad del formato**

La clonación predeterminada de diapositivas puede introducir automáticamente la maestra necesaria del origen en la presentación de destino. Aspose.Slides mantiene un registro interno de las maestras clonadas automáticamente para evitar clonarlas repetidamente. Las maestras clonadas manualmente no se registran, por lo que se recomienda no preclonar maestras a menos que necesite un control explícito sobre la estructura de la maestra.

No asuma que dos maestras o diseños con el mismo nombre son visualmente equivalentes. Si una plantilla corporativa debe controlar la apariencia final, elija explícitamente una maestra o diseño de destino y verifique el resultado después de combinar.

### **Notas y comentarios**

Las notas del presentador y los comentarios de diapositiva están asociados al contenido de la diapositiva y se copian al clonar una diapositiva. Aspose.Slides también ofrece APIs dedicadas para [presentación notas](https://docs.aspose.com/slides/es/cpp/presentation-notes/) y [presentación comentarios](https://docs.aspose.com/slides/es/cpp/presentation-comments/).

Si el formato de la página de notas es importante, verifique la presentación combinada porque las maestras de notas son objetos a nivel de presentación y pueden diferir entre archivos de origen. En flujos de revisión, también revise los autores de los comentarios y los hilos de comentarios después de combinar archivos de diferentes autores o plantillas.

### **Imágenes, audio, vídeo, objetos OLE y enlaces externos**

Las diapositivas pueden referenciar recursos a nivel de presentación como imágenes, audio incrustado, vídeo incrustado y datos OLE. Clone la diapositiva completa en lugar de copiar solo sus formas visibles para que Aspose.Slides mantenga las relaciones de la diapositiva con sus recursos.

Los recursos incrustados y los enlazados deben tratarse de forma distinta. Un audio, vídeo, objeto OLE o hipervínculo enlazado sigue dependiendo de su destino externo; clonar una diapositiva no convierte un enlace externo en contenido incrustado. Pruebe las rutas y URL de los recursos enlazados en el entorno donde se abrirá la presentación combinada.

Aspose.Slides rastrea explícitamente las maestras clonadas automáticamente, pero no debe considerarse una garantía de que los recursos binarios idénticos de presentaciones fuentes no relacionadas se deduplicarán siempre. Si el tamaño del archivo de salida es importante, inspeccione el paquete combinado y mida el resultado en lugar de confiar en la deduplicación implícita.

### **Fuentes incrustadas y disponibilidad de fuentes**

Las fuentes se gestionan a nivel de presentación. Si la tipografía debe mantenerse coherente entre máquinas, no asuma que clonar diapositivas garantiza que cada fuente requerida esté disponible en el entorno de destino. Puede inspeccionar las fuentes incrustadas con [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsmanager/getembeddedfonts/) y gestionar la incrustación explícitamente como se describe en [Incrustar fuentes en presentaciones](https://docs.aspose.com/slides/es/cpp/embedded-font/).

También verifique que tiene permiso para incrustar las fuentes utilizadas por los archivos de origen. Las licencias de fuentes pueden restringir la incrustación.

### **Presentaciones protegidas con contraseña**

Una fuente protegida con contraseña debe abrirse correctamente antes de que sus diapositivas puedan clonarse. Proporcione la contraseña mediante [LoadOptions::set_Password](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Abrir una fuente cifrada no aplica automáticamente la misma protección a la presentación de destino. Configure la protección de salida por separado cuando sea necesario.

### **Presentaciones grandes y uso de memoria**

Las presentaciones grandes que contienen imágenes de alta resolución, audio, vídeo u otros objetos binarios voluminosos pueden consumir mucha memoria. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) ofrece controles para la gestión de BLOB y el uso de archivos temporales. Consulte [Gestionar BLOB de presentación](https://docs.aspose.com/slides/es/cpp/manage-blob/) para estrategias con archivos grandes.

Para archivos grandes, prefiera cargar desde rutas de archivo cuando sea posible, libere cada presentación de origen tan pronto como se haya combinado y evite guardar resultados intermedios repetidamente a menos que el flujo requiera puntos de control.

### **Seguridad en subprocesos**

No cargue, modifique, guarde ni clone la misma instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) concurrentemente desde varios subprocesos. Mantenga cada instancia de presentación confinada a una única operación de combinación. Si paraleliza trabajos independientes, use instancias de presentación independientes y siga la [guía multihilo de Aspose.Slides](https://docs.aspose.com/slides/es/cpp/multithreading/).

## **Preguntas frecuentes**

**¿Cómo mantengo el diseño original de cada presentación fuente?**

Utilice [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) sin proporcionar una maestra o diseño de destino. Aspose.Slides puede clonar automáticamente la maestra de origen cuando la necesite la diapositiva importada.

**¿Cómo hago que las diapositivas importadas usen el tema de destino?**

Use la sobrecarga que acepta una maestra de destino. Pase una maestra de la presentación de destino, no de la fuente. Aspose.Slides intentará asignar cada diapositiva de origen a un diseño apropiado bajo esa maestra.

**¿Cuándo debo usar un diseño de destino específico en lugar de una maestra de destino?**

Use un diseño específico cuando cada diapositiva importada deba usar un único diseño conocido. Use una maestra cuando quiera que Aspose.Slides seleccione entre los diseños de esa maestra según el tipo o nombre del diseño de origen.

**¿Se pueden combinar presentaciones con tamaños de diapositiva diferentes?**

Sí, pero el contenido de la diapositiva no se rediseña automáticamente para las dimensiones de destino. Redimensione la presentación de origen primero cuando necesite una ubicación predecible, por ejemplo con [SlideSize::SetSize](https://reference.aspose.com/slides/es/cpp/aspose.slides/slidesize/setsize/) y [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/es/cpp/aspose.slides/slidesizescaletype/).

**¿Puedo combinar presentaciones PPT, PPTX y ODP en un solo archivo?**

Sí. Cargue cada presentación fuente, clone las diapositivas requeridas en una única presentación de destino y guarde el destino en un formato de salida compatible. Como los formatos de presentación no soportan exactamente el mismo conjunto de funciones, verifique el contenido complejo después de combinaciones entre formatos. Consulte [Formatos de archivo compatibles](https://docs.aspose.com/slides/es/cpp/supported-file-formats/).

**¿Se preservan automáticamente las secciones de origen?**

No con un bucle básico que solo clona diapositivas. Recree las secciones necesarias en el destino y use la sobrecarga de sección de [AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) cuando la estructura de secciones deba preservarse.

**¿Se conservan las notas del presentador y los comentarios?**

Se copian con la diapositiva clonada. Para flujos que dependan del estilo del maestro de notas, de los autores de comentarios o de los hilos de revisión, verifique el resultado combinado porque esos escenarios implican estructuras a nivel de presentación además del contenido de diapositiva.

**¿Qué ocurre con audio, vídeo, objetos OLE y hipervínculos?**

El contenido incrustado se transporta como parte de las relaciones de recursos de la diapositiva clonada. Los enlaces externos siguen siendo externos, por lo que sus archivos o URL de destino deben seguir disponibles después de la combinación.

**¿Las fuentes incrustadas de cada fuente están garantizadas en la presentación combinada?**

No confíe solo en la clonación de diapositivas para el despliegue de fuentes. Inspeccione las fuentes incrustadas del destino y gestione explícitamente la incrustación o la disponibilidad externa de fuentes cuando la tipografía sea importante.

**¿Cómo combino un archivo protegido con contraseña?**

Ábralo con el [LoadOptions::set_Password](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_password/) correcto y luego clone sus diapositivas normalmente. La protección de salida se configura por separado.

**¿Cómo debo manejar presentaciones muy grandes?**

Utilice la gestión de BLOB cuando los objetos binarios grandes dominen el uso de memoria, prefiera la carga desde rutas de archivo para archivos muy grandes, libere rápidamente las presentaciones de origen y guarde el resultado final solo cuando sea necesario.

**¿Puedo combinar diapositivas desde varios subprocesos?**

No utilice una sola instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) concurrentemente desde varios subprocesos. Mantenga cada operación de combinación aislada en sus propias instancias de presentación.