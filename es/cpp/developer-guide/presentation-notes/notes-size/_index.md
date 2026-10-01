---
title: Cambiar el tamaño y la orientación de la página de notas en C++
linktitle: Tamaño de la página de notas
type: docs
weight: 10
url: /es/cpp/notes-size/
keywords:
- tamaño de la página de notas
- orientación de las notas
- notas en horizontal
- notas en vertical
- tamaño del folleto
- PowerPoint
- presentación
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Lea y cambie las dimensiones de la página de notas en Aspose.Slides para C++, cambie la orientación, verifique los tamaños guardados y exporte notas o folletos a PDF e imágenes."
---
## **Visión general**

Utilice [Presentation::get_NotesSize](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_notessize/) para acceder a la configuración de la página de notas de la presentación. Devuelve un [INotesSize](https://reference.aspose.com/slides/es/cpp/aspose.slides/inotessize/) objeto cuyo [set_Size](https://reference.aspose.com/slides/es/cpp/aspose.slides/inotessize/set_size/) método establece las dimensiones. Aunque el objeto de configuración de notas no puede ser sustituido, puede cambiar su tamaño.

El ancho y la altura se especifican en **puntos**, con 72 puntos por pulgada. Por ejemplo, 900 × 600 puntos equivalen a 12,5 × 8⅓ pulgadas. Estas configuraciones se aplican a la presentación, en lugar de a las notas de una diapositiva individual.

| Configuración | Propósito |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_notessize/) | Controla las dimensiones de la página de notas y las dimensiones de página utilizadas para la exportación de folletos. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_slidesize/) | Controla las dimensiones de las diapositivas de presentación habituales mediante [ISlideSize](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidesize/). |

Cambiar cualquiera de las configuraciones no modifica automáticamente la otra. Cambiar la orientación de la página de notas tampoco rota las diapositivas habituales. Consulte [Tamaño de diapositiva](/slides/es/cpp/slide-size/) para cambiar el tamaño de las diapositivas habituales.

Los ejemplos a continuación usan un `sample.pptx` existente. Para los ejemplos de exportación, utilice una presentación con al menos una diapositiva que contenga notas del presentador. Cada ejemplo puede ejecutarse de forma independiente.

## **Leer el tamaño y la orientación de la página de notas**

Lea el ancho y la altura y compárelos para determinar la orientación: una página más ancha es horizontal, una página más alta es vertical, y dimensiones iguales describen una página cuadrada. Este ejemplo muestra las dimensiones reales en puntos, sin asumir un tamaño de papel estándar.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Cambiar a horizontal sin modificar el tamaño del papel**

Para cambiar solo la orientación, intercambie el ancho y la altura existentes. Esto conserva las longitudes de ambos lados, incluidas las de un tamaño de papel personalizado. La condición a continuación evita que una página ya horizontal se vuelva a cambiar a vertical y deja una página cuadrada sin cambios.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

Para orientación vertical, use la misma asignación cuando `size.get_Width() > size.get_Height()`. No sustituya dimensiones A4 o Letter a menos que también desee cambiar el tamaño del papel.

## **Establecer y verificar un tamaño de página de notas personalizado**

Asigne ambas dimensiones juntas y luego utilice [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/) para guardar la presentación. Este ejemplo establece una página horizontal de 900 × 600 puntos, la guarda como PPTX y vuelve a abrir el archivo guardado para comprobar los valores persistidos. La comparación permite una tolerancia de 0,01 puntos para valores de punto flotante; no garantiza precisión para todos los formatos de archivo.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

El resultado esperado es `900 x 600 points` y `Size preserved: True`. Comprobar una presentación recién abierta verifica el archivo guardado, en lugar de solo las configuraciones en memoria.

## **Exportar notas y folletos**

Las dimensiones de la página definen el área disponible para diseños de notas o folletos. No activan esos diseños por sí mismas: también hay que configurar las opciones de exportación. La exportación de diapositivas habituales sigue utilizando las dimensiones de la diapositiva.

### **Exportar notas a PDF y PNG**

Asigne [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/notescommentslayoutingoptions/) a [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) para incluir notas en el PDF. Este ejemplo también renderiza la primera diapositiva con notas a PNG usando [Slide::GetImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/slide/getimage/) y [RenderingOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/renderingoptions/).

El modo [BottomTruncated](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/notespositions/) mantiene las notas en una sola página; las notas que no caben pueden truncarse. El PDF utiliza páginas de 900 × 600 puntos. Con la escala de imagen de 1 × 1 utilizada a continuación, el PNG es de 900 × 600 píxeles. Los puntos describen la geometría de la página; los píxeles describen la salida raster, cuyas dimensiones también dependen de la escala de renderizado.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

Para la exportación a PDF con notas extensas, [BottomFull](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/notespositions/) permite páginas adicionales según sea necesario. No utilice ese modo con la llamada de imagen de una sola diapositiva anterior, que no lo admite. Después de cambiar el tamaño, inspeccione la salida para ver notas recortadas y la ubicación de los objetos de notas‑maestra existentes; modificar solo las dimensiones de la página no debe considerarse una garantía de que todo el contenido quepa. Consulte [Convertir PowerPoint a PDF con notas](/slides/es/cpp/convert-powerpoint-to-pdf-with-notes/) para obtener más información sobre la exportación de notas.

### **Exportar folletos a PDF**

Utilice [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/handoutlayoutingoptions/) para varias miniaturas de diapositivas en una página. El siguiente ejemplo establece una página de 900 × 600 puntos y usa [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/handouttype/) para disponer hasta cuatro diapositivas por página. El preset horizontal controla el orden de las diapositivas; la orientación de la página proviene de su ancho y altura.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Cambiar el tamaño de la página modifica el área disponible para la cuadrícula de folletos sin cambiar las dimensiones de las diapositivas de origen. Para imágenes de folletos, use [Presentation::GetImages](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/getimages/) con el diseño de folleto, en lugar del método de imagen de una diapositiva individual. En Aspose.Slides, el renderizado de folletos a nivel de presentación utiliza las dimensiones de la página de notas, mientras que la llamada de imagen de diapositiva individual no produce la página de folleto. Consulte [Modo de folleto](/slides/es/cpp/convert-powerpoint-in-handout-mode/) para opciones de diseño.

## **Tamaño de página en visores, exportación e impresión**

Mantenga distintivos el tamaño de la presentación almacenada, el tamaño de página exportado y el tamaño de papel impreso:

- **Visores de presentaciones:** Un visor puede mostrar o imprimir notas usando sus propias reglas de diseño. Si otra aplicación guarda el archivo, vuelva a abrirlo y compruebe las dimensiones nuevamente; la conversión de formato de esa aplicación puede normalizarlas.
- **Formatos de exportación:** Los ejemplos de PDF de notas y folletos anteriores usan las dimensiones de página configuradas. Las imágenes raster utilizan dimensiones de píxeles enteras y una escala de renderizado, por lo que los valores fraccionarios de puntos pueden redondearse en la salida de la imagen. Exportar diapositivas habituales no aplica el tamaño de página de notas.
- **Controladores de impresora:** La selección de papel, la rotación automática y los ajustes de ajuste a la página pueden cambiar la salida física sin modificar las dimensiones almacenadas en la presentación o PDF. Para un tamaño de papel específico, ajuste la configuración de la impresora y examine la vista previa de impresión.

## **Preguntas frecuentes**

**¿Puedo establecer el tamaño de las notas solo para una diapositiva?**

El tamaño de la página de notas es una configuración a nivel de presentación. Las diapositivas individuales pueden contener contenido de notas diferente, pero esta propiedad no proporciona un tamaño de página independiente para cada diapositiva.

**¿Por qué al cambiar la orientación de las notas no cambiaron mis diapositivas?**

Las páginas de notas y las diapositivas habituales tienen dimensiones independientes. Utilice la configuración del tamaño de diapositiva habitual cuando desee cambiar el tamaño de las propias diapositivas.

**¿Por qué mi resultado guardado o impreso tiene un tamaño diferente?**

Primero vuelva a abrir la presentación guardada y compare sus dimensiones de notas. Si estas cambiaron, verifique si al guardar o convertir el archivo en otra aplicación se modificaron los ajustes de página. Si no es así, revise el diseño de exportación, la escala de la imagen, la configuración del visor y la selección de papel de la impresora.