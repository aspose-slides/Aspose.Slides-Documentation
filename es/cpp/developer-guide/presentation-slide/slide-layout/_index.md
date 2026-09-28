---
title: "Aplicar o cambiar diseños de diapositiva en C++"
linktitle: "Diseño de diapositiva"
type: docs
weight: 60
url: /es/cpp/slide-layout/
keywords:
- "diseño de diapositiva"
- "diseño de contenido"
- "marcador de posición"
- "diseño de presentación"
- "diseño de diapositiva"
- "diseño no usado"
- "visibilidad del pie de página"
- "diapositiva de título"
- "título y contenido"
- "encabezado de sección"
- "dos contenidos"
- "comparación"
- "solo título"
- "diseño en blanco"
- "contenido con leyenda"
- "imagen con leyenda"
- "título y texto vertical"
- "título vertical y texto"
- "PowerPoint"
- "OpenDocument"
- "presentación"
- "C++"
- "Aspose.Slides"
description: "Aplicar, crear y modificar diseños de diapositiva en Aspose.Slides para C++, añadir marcadores de posición, eliminar diseños no usados y controlar la visibilidad del pie de página."
---
## **Visión general**

Un diseño de diapositiva define las posiciones y el formato de los marcadores de posición como títulos, texto, imágenes, gráficos y tablas. Aplicar un diseño proporciona a las diapositivas una estructura coherente al tiempo que permite que cada diapositiva contenga su propio contenido.

Los diseños más comunes incluyen:

- **Diapositiva de título**: Contiene marcadores de posición de título y subtítulo.
- **Título y contenido**: Contiene un marcador de posición de título y un marcador de posición de contenido de uso general.
- **En blanco**: No contiene marcadores de posición de contenido y es útil cuando cada forma se posicionará manualmente.

## **Comprender la herencia de diseños**

Una presentación tiene tres niveles relacionados:

1. Una [diapositiva maestra](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/) define el tema, el formato compartido, los fondos y los objetos comunes.
1. Una [diapositiva de diseño](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/) pertenece a una maestra y define una disposición particular de marcadores de posición.
1. Una [diapositiva normal](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/) utiliza un diseño y almacena el contenido introducido para esa diapositiva.

Una diapositiva normal hereda el tema y formato de su diseño, y el diseño hereda de su maestra. Un valor establecido directamente en una diapositiva normal sobrescribe el valor heredado en ese nivel. Cuando se crea una diapositiva normal, sus formas de marcador de posición se generan a partir del diseño seleccionado, mientras que el contenido introducido en esos marcadores pertenece a la diapositiva normal.

Añada los marcadores de posición necesarios a un diseño antes de crear diapositivas a partir de él. Añadir otro marcador de posición a un diseño más tarde no añade automáticamente una forma de marcador correspondiente a las diapositivas normales existentes.

Esta relación tiene dos consecuencias importantes:

- Cambiar el formato heredado o la geometría de los marcadores de posición existentes en un diseño puede actualizar todas las diapositivas que dependen de él. Antes de editar un diseño que ya está en uso, inspeccione sus diapositivas dependientes y revise la presentación resultante.
- Un diseño que todavía es usado por una diapositiva no puede eliminarse. Asigne primero sus diapositivas dependientes a otro diseño, o elimine solo los diseños no utilizados.

Para obtener más información sobre el nivel superior de esta jerarquía, consulte [Maestra de diapositivas](/slides/es/cpp/slide-master/).

Para ocultar logotipos heredados o formas decorativas de la maestra en una diapositiva o mediante un diseño compartido, consulte [Controlar la visibilidad de los gráficos de la maestra](/slides/es/cpp/slide-master/). El ejemplo compara dos diapositivas que utilizan la misma maestra.

## **Seleccionar y aplicar un diseño de diapositiva**

Utilice un tipo de diseño cuando la presentación sigue definiciones estándar de diseños de PowerPoint. Los nombres de los diseños son editables por el usuario y pueden localizarse, por lo que la selección basada en nombres es menos fiable a menos que controle la plantilla origen.

El siguiente ejemplo busca **Título y contenido** en la primera maestra. Si ese diseño no está disponible, recurre deliberadamente a **En blanco**. La segunda comprobación de nulo es necesaria porque una presentación puede contener solo diseños personalizados. El diseño seleccionado se aplica entonces a la primera diapositiva normal mediante el método [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/set_layoutslide/).

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Cambiar el diseño de una diapositiva no elimina las formas ordinarias añadidas directamente a la diapositiva. Sin embargo, las posiciones de los marcadores de posición, el formato heredado y la correspondencia entre los marcadores existentes y el nuevo diseño pueden cambiar, por lo que debe inspeccionar el resultado al cambiar entre diseños sustancialmente diferentes.

## **Añadir una diapositiva de diseño**

La selección y la creación son operaciones separadas. El ejemplo anterior selecciona un diseño existente; no lo crea. Para crear un diseño, llame al método [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterlayoutslidecollection/add/) en la colección de diseños de la maestra de destino.

El siguiente ejemplo siempre añade un nuevo diseño **Título y contenido** llamado `Report Title and Content`, y luego añade una diapositiva normal basada en él. Los nombres de los diseños deben ser únicos dentro de la colección.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Añada un diseño solo cuando la plantilla realmente necesite otra estructura reutilizable. Si ya existe un diseño adecuado, selecciónelo y reutilícelo en lugar de crear un duplicado.

## **Añadir marcadores de posición a una diapositiva de diseño**

El método [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) proporciona un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/) para añadir formas de marcador de posición a un diseño.

| Marcador de posición PowerPoint | Método ILayoutPlaceholderManager |
| -------------------------------- | -------------------------------- |
| ![Contenido](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Contenido (vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Texto](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Texto (vertical)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Imagen](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Gráfico](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Tabla](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Multimedia](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Imagen en línea](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

El siguiente ejemplo verifica que el diseño **En blanco** exista, añade cuatro marcadores de posición a él y luego crea una diapositiva normal que utiliza el diseño modificado. El orden es intencional: los marcadores de posición se añaden antes de crear la diapositiva normal, de modo que Aspose.Slides pueda generar las formas de marcador correspondientes en esa diapositiva.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![Los marcadores de posición en la diapositiva de diseño](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Cambiar el formato heredado o la geometría de los marcadores de posición del diseño existente puede afectar a las diapositivas dependientes. Un marcador de posición de diseño recién añadido no se retropropaga a las diapositivas normales existentes. Pruebe los cambios de diseño en una copia de la presentación e inspeccione cada diapositiva dependiente.
{{% /alert %}}

## **Eliminar diseños de diapositiva no utilizados**

Utilice el método [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) para eliminar los diseños que no son referenciados por ninguna diapositiva normal. El método deja intactos los diseños que aún están en uso.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para eliminar un diseño específico, primero use su método [get_HasDependingSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) o el método [GetDependingSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/getdependingslides/). Reasigne cualquier diapositiva dependiente antes de llamar a [ILayoutSlide::Remove](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/remove/). Intentar eliminar un diseño en uso genera una [PptxEditException](https://reference.aspose.com/slides/es/cpp/aspose.slides/pptxeditexception/).

## **Controlar la visibilidad del pie de página en una diapositiva de diseño**

Un diseño tiene sus propios marcadores de posición de pie de página, número de diapositiva y fecha/hora. Utilice el método [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) para controlar esos marcadores de posición en un diseño. Esto es útil cuando, por ejemplo, los diseños de contenido deben mostrar pies de página pero los diseños de título no.

El siguiente ejemplo selecciona un diseño de forma segura y hace visibles sus elementos de pie de página:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Controlar la visibilidad del pie de página en una maestra y sus diseños hijos**

Para aplicar configuraciones de pie de página coherentes a lo largo de una jerarquía maestra, utilice el método [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Los métodos de propagación de [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslideheaderfootermanager/) operan sobre la maestra y sus diapositivas de diseño y diapositivas normales dependientes; no se dirigen a una sola diapositiva normal.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de diseño?**

Una diapositiva maestra define el tema y el formato compartido de la presentación. Una diapositiva de diseño pertenece a una maestra y define una disposición reutilizable de marcadores de posición. Las diapositivas normales utilizan esos diseños y almacenan el contenido específico de cada diapositiva.

**¿Puedo copiar una diapositiva de diseño de una presentación a otra?**

Sí. Añada una copia a la colección de destino con el método [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Al copiar entre presentaciones, también verifique fuentes, temas, imágenes y otros recursos utilizados por el diseño origen.

**¿Qué ocurre cuando modifico un diseño que ya está en uso?**

Las diapositivas dependientes heredan los cambios del diseño a menos que sobrescriban localmente el formato u objetos afectados. La geometría de los marcadores de posición y el estilo heredado pueden cambiar en muchas diapositivas a la vez. Utilice [GetDependingSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/getdependingslides/) para identificar las diapositivas afectadas antes de editar el diseño.

**¿Qué ocurre si elimino un diseño que todavía está en uso?**

Aspose.Slides lanza una [PptxEditException](https://reference.aspose.com/slides/es/cpp/aspose.slides/pptxeditexception/). Reasigne primero las diapositivas dependientes, o utilice [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) para eliminar solo los diseños no referenciados.