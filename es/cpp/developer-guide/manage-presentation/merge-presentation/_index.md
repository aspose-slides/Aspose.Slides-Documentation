---
title: "Combinar presentaciones de forma eficiente en C++"
linktitle: "Combinar presentaciones"
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
description: "Fusiona sin esfuerzo presentaciones PowerPoint (PPT, PPTX) y OpenDocument (ODP) con Aspose.Slides para C++, optimizando su flujo de trabajo."
---
## **Visión general**

Aspose.Slides le permite combinar presentaciones clonando diapositivas de una presentación a otra. Este artículo explica cómo combinar presentaciones completas o diapositivas seleccionadas, usar un patrón de diapositivas o un diseño específico durante la combinación, manejar presentaciones con diferentes tamaños de diapositiva y añadir diapositivas combinadas a una sección de presentación. También cubre notas prácticas relacionadas con el contenido combinado, incluidas notas del presentador, comentarios, archivos de origen protegidos con contraseña y uso de subprocesos.

## **Combinar presentaciones**

Al combinar una presentación con otra, está combinando efectivamente sus diapositivas en una sola presentación para obtener un archivo.

{{% alert title="Información" color="info" %}}

La mayoría de los programas de presentación (PowerPoint u OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esta manera.

[**Aspose.Slides for C++**](https://products.aspose.com/slides/es/cpp/), sin embargo, permite combinar presentaciones de diferentes formas. Puede combinar presentaciones con todas sus formas, estilos, textos, formatos, comentarios, animaciones, etc., sin preocuparse por la pérdida de calidad o datos.

**Ver también**

[Clonar diapositivas](https://docs.aspose.com/slides/es/cpp/clone-slides/)*.*

{{% /alert %}}

### **Qué se puede combinar**

Con Aspose.Slides, puede combinar

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación
* presentaciones en un formato (PPT a PPT, PPTX a PPTX, etc.) y en formatos diferentes (PPT a PPTX, PPTX a ODP, etc.) entre sí.

{{% alert title="Nota" color="warning" %}}

Además de presentaciones, Aspose.Slides le permite combinar otros archivos:

* [Imágenes](https://products.aspose.com/slides/es/cpp/merger/image-to-image/), como [JPG a JPG](https://products.aspose.com/slides/es/cpp/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/es/cpp/merger/png-to-png/)
* Documentos, como [PDF a PDF](https://products.aspose.com/slides/es/cpp/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/es/cpp/merger/html-to-html/)
* Y dos archivos diferentes, como [imagen a PDF](https://products.aspose.com/slides/es/cpp/merger/image-to-pdf/), [JPG a PDF](https://products.aspose.com/slides/es/cpp/merger/jpg-to-pdf/) o [TIFF a PDF](https://products.aspose.com/slides/es/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opciones de combinación**

Puede aplicar opciones que determinen si

* cada diapositiva en la presentación de salida conserva un estilo único
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida.

Para combinar presentaciones, Aspose.Slides proporciona los métodos [AddClone](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (de la interfaz [ISlideCollection](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_slide_collection)). Existen varias implementaciones del método `AddClone` que definen los parámetros del proceso de combinación. Cada objeto Presentation tiene una colección [Slides](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), por lo que puede llamar a un método `AddClone` desde la presentación a la que desea combinar diapositivas.

El método `AddClone` devuelve un objeto `ISlide`, que es una copia de la diapositiva de origen. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas del origen. Por lo tanto, puede modificar las diapositivas resultantes (por ejemplo, aplicar estilos, opciones de formato o diseños) sin preocuparse de que las presentaciones de origen se vean afectadas.

## **Combinar presentaciones**

Aspose.Slides proporciona el método [**AddClone (ISlide)**](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) que le permite combinar diapositivas mientras las diapositivas conservan sus diseños y estilos (parámetros predeterminados).

Este código C++ le muestra cómo combinar presentaciones:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Combinar presentaciones con un patrón de diapositivas**

Aspose.Slides proporciona el método [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) que le permite combinar diapositivas aplicando una plantilla de patrón de diapositivas. De este modo, si es necesario, puede cambiar el estilo de las diapositivas en la presentación de salida.

Este código en C++ demuestra la operación descrita:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Nota" color="warning" %}}

El diseño de diapositiva para el patrón se determina automáticamente. Cuando no se puede determinar un diseño adecuado, si el parámetro booleano `allowCloneMissingLayout` del método `AddClone` se establece en true, se utiliza el diseño de la diapositiva de origen. De lo contrario, se lanzará una [PptxEditException](https://reference.aspose.com/slides/es/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d).

{{% /alert %}}

Si desea que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, utilice el método [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) en su lugar al combinar.

## **Combinar diapositivas específicas de presentaciones**

Combinar diapositivas específicas de varias presentaciones es útil para crear juegos de diapositivas personalizados. Aspose.Slides C++ le permite seleccionar e importar sólo las diapositivas que necesita. La API conserva el formato, el diseño y el estilo de las diapositivas originales.

El siguiente código C++ crea una nueva presentación, añade diapositivas de título de dos presentaciones distintas y guarda el resultado en un archivo:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Declarado en el código anterior.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Combinar presentaciones con un diseño de diapositiva**

Este código C++ le muestra cómo combinar diapositivas de presentaciones aplicando su diseño de diapositiva preferido para obtener una sola presentación de salida:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Combinar presentaciones con diferentes tamaños de diapositiva**

{{% alert title="Nota" color="warning" %}}

No se pueden combinar presentaciones con diferentes tamaños de diapositiva.

{{% /alert %}}

Para combinar 2 presentaciones con tamaños de diapositiva diferentes, debe redimensionar una de las presentaciones para que su tamaño coincida con el de la otra presentación.

Este código de ejemplo demuestra la operación descrita:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Combinar diapositivas en una sección de presentación**

Este código C++ le muestra cómo combinar una diapositiva específica en una sección de una presentación:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

La diapositiva se añade al final de la sección.

{{% alert title="Consejo" color="info" %}}

Aspose ofrece una aplicación web GRATUITA de Collage ([https://products.aspose.app/slides/es/collage](https://products.aspose.app/slides/es/collage)). Con este servicio en línea, puede combinar [JPG a JPG](https://products.aspose.app/slides/es/collage/jpg) o PNG a PNG, crear [cuadrículas de fotos](https://products.aspose.app/slides/es/collage/photo-grid) y mucho más.

{{% /alert %}}

## **FAQ**

### ¿Se conservan las notas del presentador durante la combinación?

Sí. Al clonar diapositivas, Aspose.Slides traslada todos los elementos de la diapositiva, incluidas las notas, el formato y las animaciones.

### ¿Se transfieren los comentarios y sus autores?

Los comentarios, como parte del contenido de la diapositiva, se copian con la diapositiva. Las etiquetas de autor de los comentarios se conservan como objetos de comentario en la presentación resultante.

### ¿Qué ocurre si la presentación de origen está protegida con contraseña?

Debe [abrirse con la contraseña](/slides/es/cpp/password-protected-presentation/) mediante [LoadOptions::set_Password](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_password/); después de cargarla, esas diapositivas pueden clonarse de forma segura en un archivo de destino no protegido (o también protegido).

### ¿Qué tan seguro para subprocesos es el proceso de combinación?

No utilice la misma instancia de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) desde [varios subprocesos](/slides/es/cpp/multithreading/). La regla recomendada es “un documento — un subproceso”; diferentes archivos pueden procesarse en paralelo en subprocesos independientes.