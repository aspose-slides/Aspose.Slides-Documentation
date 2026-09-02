---
title: Combinar presentaciones de forma eficiente en C++
linktitle: Combinar presentaciones
type: docs
weight: 40
url: /es/cpp/merge-presentation/
keywords:
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- C++
- Aspose.Slides
description: "Aprenda cómo combinar presentaciones de PowerPoint y OpenDocument en C++ clonando diapositivas, controlando maestros y diseños, redimensionando el contenido de las diapositivas, preservando secciones y gestionando archivos protegidos o de gran tamaño."
---
## **Visión general**

Aspose.Slides for C++ combina presentaciones clonando diapositivas de una [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) a otra. La operación principal es [ISlideCollection::AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/), que puede preservar el formato de la diapositiva origen o adjuntar la diapositiva clonada a un maestro o diseño en la presentación de destino.

Este artículo cubre los flujos de trabajo de combinación más habituales:

- combinar todas las diapositivas conservando su formato original;
- combinar diapositivas seleccionadas;
- aplicar un maestro de la presentación de destino;
- aplicar un diseño específico de la presentación de destino;
- normalizar diferentes tamaños de diapositiva antes de combinar;
- añadir diapositivas clonadas a una sección;
- combinar varias presentaciones en un flujo de trabajo de extremo a extremo;
- gestionar maestros, recursos, notas, comentarios, medios, fuentes, contraseñas, archivos grandes y consideraciones de multihilo.

## **Cómo afecta la clonación de diapositivas a maestros y diseños**

Una diapositiva hereda gran parte de su apariencia de su diseño y maestro. Por esa razón, la sobrecarga de clonación que elija determina cómo se integra la diapositiva combinada en la presentación de destino.

Use [ISlideCollection::AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) de una de estas formas:

- `AddClone(sourceSlide)` — preserve el diseño y formato de la diapositiva origen. Cuando sea necesario, el maestro origen puede clonarse automáticamente en la presentación de destino. Aspose.Slides rastrea los maestros clonados automáticamente para que diapositivas repetidas que usen el mismo maestro origen no provoquen una clonación repetida de ese maestro.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — adjunte la diapositiva clonada a un [IMasterSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/) de destino específico. Aspose.Slides busca un diseño coincidente bajo ese maestro por tipo o nombre.
- `AddClone(sourceSlide, destinationLayout)` — adjunte la diapositiva clonada directamente a un [ILayoutSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/) de destino específico.

El maestro o diseño pasado a una sobrecarga `AddClone` debe pertenecer a la **presentación de destino**, no a la presentación de origen.

## **Combinar presentaciones completas y preservar el formato origen**

La combinación más simple copia cada diapositiva de la presentación origen a la presentación de destino. Esta es la opción adecuada cuando las diapositivas importadas deben mantener su tema, maestro y relaciones de diseño originales.

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

La presentación resultante puede contener varios maestros cuando el origen y el destino usan diseños diferentes. Esto es normal cuando se preserva intencionadamente el formato origen.

## **Combinar diapositivas seleccionadas**

No es necesario clonar todas las diapositivas. El siguiente ejemplo importa sólo los índices de diapositivas seleccionados de la presentación origen.

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

## **Combinar diapositivas usando un maestro de destino**

Utilice la sobrecarga [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) cuando las diapositivas importadas deban seguir un maestro que ya pertenece a la presentación de destino.

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

Aspose.Slides selecciona un diseño apropiado bajo el maestro especificado coincidiendo con el tipo o nombre del diseño origen. Si no existe un diseño adecuado y `allowCloneMissingLayout` es `true`, el diseño origen se clona para que la diapositiva pueda añadirse. Si es `false`, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/cpp/aspose.slides/details_pptxeditexception/).

Use `false` cuando desee que la combinación falle en lugar de introducir un diseño adicional en el maestro de destino.

## **Combinar diapositivas usando un diseño de destino específico**

Utilice la sobrecarga [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) cuando conozca exactamente qué diseño de destino deben usar las diapositivas importadas.

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

Aplicar un diseño de destino cambia la relación de diseño heredada; no rediseña el contenido de la diapositiva origen. Si los diseños origen y destino tienen estructuras de marcadores diferentes, inspeccione el resultado para confirmar que el formato heredado y el comportamiento de los marcadores son adecuados.

## **Combinar presentaciones con tamaños de diapositiva diferentes**

Las presentaciones con dimensiones de diapositiva distintas pueden combinarse, pero clonar una diapositiva en una presentación con otro tamaño de diapositiva no rediseña automáticamente su contenido para el nuevo lienzo. Las formas pueden aparecer desplazadas, escaladas de forma inesperada o fuera del área visible de la diapositiva.

Un enfoque práctico es cambiar el tamaño de la presentación origen antes de clonar. El método [SlideSize::SetSize](https://reference.aspose.com/slides/es/cpp/aspose.slides/slidesize/setsize/) puede escalar el contenido existente mientras cambia las dimensiones de la diapositiva. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/es/cpp/aspose.slides/slidesizescaletype/) escala el contenido para que se ajuste al tamaño solicitado.

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

Redimensionar modifica el objeto de la presentación origen en memoria. Si necesita mantener la presentación origen sin cambios para otras operaciones, abra una instancia separada para la combinación.

## **Combinar diapositivas en una sección de presentación**

El bucle básico de clonación de diapositivas no recrea la jerarquía de secciones de la presentación origen. Si las secciones son relevantes en la salida, cree o seleccione secciones en la presentación de destino y clone las diapositivas en ellas explícitamente con [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/).

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

Las diapositivas clonadas se añaden al final de la sección de destino especificada. Para preservar varias secciones origen, enumere [Presentation::get_Sections](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_sections/), recupere las diapositivas actuales de cada sección origen con [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/es/cpp/aspose.slides/isection/getslideslistofsection/), recree las secciones en el destino y clone cada diapositiva devuelta en su sección de destino correspondiente. Consulte [Manage Slide Sections](/slides/es/cpp/slide-section/) para un ejemplo completo de enumeración de secciones, incluidas secciones vacías y cambios estructurales.

## **Combinar varias presentaciones de forma segura**

El siguiente ejemplo de extremo a extremo utiliza la primera presentación como destino, normaliza el tamaño de diapositiva de cada origen adicional, mantiene cada origen abierto solo mientras se copia y guarda el archivo final una única vez.

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

Este es un punto de partida útil para preservar el formato origen de las diapositivas importadas. Si su salida debe usar un único tema de destino, reemplace la llamada simple `AddClone(slide)` por la sobrecarga de maestro o diseño de destino mostrada anteriormente.

## **Consideraciones prácticas**

### **Maestros, diseños y fidelidad del formato**

La clonación predeterminada de diapositivas puede traer automáticamente un maestro origen necesario a la presentación de destino. Aspose.Slides mantiene un registro interno de los maestros clonados automáticamente para evitar clonar el mismo maestro repetidamente. Los maestros clonados manualmente no se registran, por lo que debe evitar pre‑clonar maestros a menos que necesite un control explícito sobre la estructura del maestro.

No asuma que dos maestros o diseños con el mismo nombre son visualmente equivalentes. Si una plantilla corporativa debe controlar la apariencia final, elija explícitamente un maestro o diseño de destino y verifique el resultado después de la combinación.

### **Notas y comentarios**

Las notas del orador y los comentarios de diapositiva están asociados al contenido de la diapositiva y se copian cuando se clona una diapositiva. Aspose.Slides también expone APIs dedicadas para [presentation notes](/slides/es/cpp/presentation-notes/) y [presentation comments](/slides/es/cpp/presentation-comments/).

Si el formato de la página de notas es importante, verifique la presentación combinada porque los maestros de notas son objetos a nivel de presentación y pueden diferir entre los archivos origen. Para flujos de revisión, también verifique los autores de los comentarios y los hilos de comentarios tras combinar archivos de diferentes autores o plantillas.

### **Imágenes, audio, vídeo, objetos OLE y enlaces externos**

Las diapositivas pueden referenciar recursos a nivel de presentación como imágenes, audio incrustado, vídeo incrustado y datos OLE. Clone la diapositiva completa en lugar de copiar sólo sus formas visibles para que Aspose.Slides pueda mantener las relaciones de la diapositiva con sus recursos.

Los recursos incrustados y los vinculados deben tratarse de forma diferente. Un audio, vídeo, objeto OLE o hipervínculo vinculado sigue dependiendo de su destino externo; clonar una diapositiva no convierte un enlace externo en contenido incrustado. Pruebe las rutas y URL de los recursos vinculados en el entorno donde se abrirá la presentación combinada.

Aspose.Slides rastrea explícitamente los maestros clonados automáticamente, pero esto no debe considerarse una garantía general de que recursos binarios idénticos de presentaciones origen no relacionadas se deduplicarán siempre. Si el tamaño del archivo de salida es importante, inspeccione el paquete combinado y mida el resultado en lugar de confiar en la deduplicación implícita.

### **Fuentes incrustadas y disponibilidad de fuentes**

Las fuentes se gestionan a nivel de presentación. Si la tipografía debe mantenerse coherente entre máquinas, no asuma que clonar sólo las diapositivas garantiza que todas las fuentes necesarias estén disponibles en el entorno de destino. Puede inspeccionar las fuentes incrustadas con [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsmanager/getembeddedfonts/) y gestionar la incrustación explícitamente como se describe en [Embed Fonts in Presentations](/slides/es/cpp/embedded-font/).

También verifique que tiene permiso para incrustar las fuentes utilizadas por los archivos origen. Las licencias de fuentes pueden restringir la incrustación.

### **Presentaciones protegidas con contraseña**

Una fuente protegida con contraseña debe abrirse correctamente antes de que sus diapositivas puedan clonarse. Proporcione la contraseña a través de [LoadOptions::set_Password](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_password/).

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

Las presentaciones grandes que contienen imágenes de alta resolución, audio, vídeo u otros objetos binarios grandes pueden consumir mucha memoria. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) proporciona controles para la gestión de BLOB y el uso de archivos temporales. Consulte [Manage Presentation BLOBs](/slides/es/cpp/manage-blob/) para estrategias con archivos grandes.

Para archivos grandes, prefiera cargar desde rutas de archivo cuando sea posible, libere cada presentación origen tan pronto como haya sido combinada y evite guardar repetidamente resultados intermedios a menos que el flujo requiera puntos de control.

### **Seguridad en entornos multihilo**

No cargue, modifique, guarde ni clone la misma instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) simultáneamente desde varios hilos. Mantenga cada instancia de presentación confinada a una única operación de combinación. Si paraleliza trabajos independientes, use instancias de presentación independientes y siga la [guía de multihilo de Aspose.Slides](/slides/es/cpp/multithreading/).

## **Preguntas frecuentes**

**¿Cómo conservo el diseño original de cada presentación origen?**

Utilice [AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) sin proporcionar un maestro o diseño de destino. Aspose.Slides puede clonar automáticamente el maestro origen cuando la diapositiva importada lo necesite.

**¿Cómo hago que las diapositivas importadas usen el tema de destino?**

Use la sobrecarga que acepta un maestro de destino. Pase un maestro de la presentación de destino, no del origen. Aspose.Slides intentará asignar cada diapositiva origen a un diseño apropiado bajo ese maestro.

**¿Cuándo debo usar un diseño de destino específico en lugar de un maestro de destino?**

Utilice un diseño específico cuando cada diapositiva importada deba usar un diseño conocido. Use un maestro cuando quiera que Aspose.Slides seleccione entre los diseños de ese maestro basándose en el tipo o nombre del diseño origen.

**¿Se pueden combinar presentaciones con tamaños de diapositiva diferentes?**

Sí, pero el contenido de la diapositiva no se rediseña automáticamente para las dimensiones de destino. Redimensione la presentación origen primero cuando necesite una colocación predecible, por ejemplo con [SlideSize::SetSize](https://reference.aspose.com/slides/es/cpp/aspose.slides/slidesize/setsize/) y [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/es/cpp/aspose.slides/slidesizescaletype/).

**¿Puedo combinar archivos PPT, PPTX y ODP en un solo archivo?**

Sí. Cargue cada presentación origen, clone las diapositivas necesarias en una única presentación de destino y guarde el destino en un formato de salida compatible. Como los formatos de presentación no soportan exactamente el mismo conjunto de funcionalidades, verifique el contenido complejo después de combinaciones entre formatos. Consulte [Supported File Formats](/slides/es/cpp/supported-file-formats/).

**¿Se conservan automáticamente las secciones del origen?**

No, no con un bucle básico que solo clone diapositivas. Recree las secciones necesarias en el destino y use la sobrecarga de sección de [AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidecollection/addclone/) cuando la estructura de secciones deba preservarse.

**¿Se conservan las notas del orador y los comentarios?**

Se copian con la diapositiva clonada. Para flujos que dependan del estilo del maestro de notas, de los autores de comentarios o de los hilos de revisión, verifique el resultado combinado porque esos escenarios implican estructuras a nivel de presentación además del contenido de la diapositiva.

**¿Qué ocurre con audio, vídeo, objetos OLE y hipervínculos?**

El contenido incrustado se transporta como parte de las relaciones de recursos de la diapositiva clonada. Los enlaces externos siguen siendo externos, por lo que sus archivos o URL de destino deben seguir disponibles después de la combinación.

**¿Están garantizadas las fuentes incrustadas de cada origen en la presentación combinada?**

No confíe sólo en la clonación de diapositivas para la implantación de fuentes. Inspeccione las fuentes incrustadas del destino y gestione explícitamente la incrustación de fuentes o la disponibilidad externa cuando la tipografía sea importante.

**¿Cómo combino un archivo protegido con contraseña?**

Ábralo con la [LoadOptions::set_Password](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_password/) correcta y luego clone sus diapositivas normalmente. La protección de salida se configura por separado.

**¿Cómo debo manejar presentaciones muy grandes?**

Use la gestión de BLOB cuando los objetos binarios grandes dominen el uso de memoria, prefiera la carga por ruta de archivo para archivos muy grandes, libere las presentaciones origen con prontitud y guarde el resultado final sólo cuando sea necesario.

**¿Puedo combinar diapositivas desde varios hilos?**

No utilice una única instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) concurrentemente desde varios hilos. Mantenga cada operación de combinación aislada en sus propias instancias de presentación.