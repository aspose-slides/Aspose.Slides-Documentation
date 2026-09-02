---
title: Aplicar o cambiar diseños de diapositiva en C++
linktitle: Diseño de diapositiva
type: docs
weight: 60
url: /es/cpp/slide-layout/
keywords:
- diseño de diapositiva
- diseño de contenido
- marcador de posición
- diseño de presentación
- diseño de diapositiva
- diseño sin usar
- visibilidad del pie de página
- diapositiva de título
- título y contenido
- encabezado de sección
- dos contenidos
- comparación
- solo título
- diseño en blanco
- contenido con subtítulo
- imagen con subtítulo
- título y texto vertical
- título vertical y texto
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aplicar, crear y modificar diseños de diapositiva en Aspose.Slides para C++, añadir marcadores de posición, eliminar diseños sin usar y controlar la visibilidad del pie de página."
---
## **Descripción general**

Un diseño de diapositiva define las posiciones y el formato de los marcadores de posición como títulos, texto, imágenes, gráficos y tablas. Aplicar un diseño proporciona a las diapositivas una estructura coherente mientras permite que cada diapositiva contenga su propio contenido.

- **Diapositiva de título**: Contiene marcadores de posición de título y subtítulo.  
- **Título y contenido**: Contiene un marcador de posición de título y un marcador de posición de contenido de uso general.  
- **En blanco**: No contiene marcadores de posición de contenido y es útil cuando cada forma se posicionará manualmente.

## **Comprender la herencia de diseños**

Una presentación tiene tres niveles relacionados:

1. Una [diapositiva maestra](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/) define el tema, el formato compartido, los fondos y los objetos comunes.  
1. Una [diapositiva de diseño](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/) pertenece a una maestra y define una disposición particular de marcadores de posición.  
1. Una [diapositiva normal](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/) usa un diseño y almacena el contenido introducido para esa diapositiva.

Una diapositiva normal hereda el tema y el formato de su diseño, y el diseño hereda de su maestra. Un valor establecido directamente en una diapositiva normal sobrescribe el valor heredado en ese nivel. Cuando se crea una diapositiva normal, sus formas de marcador de posición se generan a partir del diseño seleccionado, mientras que el contenido introducido en esos marcadores pertenece a la diapositiva normal.

Agregue los marcadores de posición necesarios a un diseño antes de crear diapositivas a partir de él. Añadir otro marcador de posición a un diseño más tarde no agrega automáticamente una forma de marcador correspondiente a las diapositivas normales existentes.

Esta relación tiene dos consecuencias importantes:

- Cambiar el formato heredado o la geometría de los marcadores de posición existentes en un diseño puede actualizar todas las diapositivas que dependen de él. Antes de editar un diseño que ya está en uso, inspeccione sus diapositivas dependientes y revise la presentación resultante.  
- Un diseño que aún es usado por una diapositiva no puede eliminarse. Reasigne sus diapositivas dependientes a otro diseño primero, o elimine solo los diseños no usados.

Para obtener más información sobre el nivel superior de esta jerarquía, consulte [Maestro de diapositivas](/slides/es/cpp/slide-master/).

## **Seleccionar y aplicar un diseño de diapositiva**

Utilice un tipo de diseño cuando la presentación siga las definiciones estándar de diseños de PowerPoint. Los nombres de los diseños son editables por el usuario y pueden localizarse, por lo que la selección basada en nombres es menos fiable a menos que controle la plantilla origen.

El siguiente ejemplo busca **Título y contenido** en la primera maestra. Si ese diseño no está disponible, recurre deliberadamente a **En blanco**. La segunda comprobación de nulidad es necesaria porque una presentación puede contener solo diseños personalizados. El diseño seleccionado se aplica entonces a la primera diapositiva normal mediante el método [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/islide/set_layoutslide/).

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

Cambiar el diseño de una diapositiva no elimina las formas ordinarias añadidas directamente a la diapositiva. Sin embargo, las posiciones de los marcadores, el formato heredado y la correspondencia entre los marcadores existentes y el nuevo diseño pueden variar, por lo que es conveniente inspeccionar la salida al alternar entre diseños sustancialmente diferentes.

## **Añadir una diapositiva de diseño**

La selección y la creación son operaciones separadas. El ejemplo anterior selecciona un diseño existente; no lo crea. Para crear un diseño, invoque el método [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterlayoutslidecollection/add/) en la colección de diseños de la maestra de destino.

El siguiente ejemplo siempre añade un nuevo diseño **Título y contenido** llamado `Report Title and Content`, y luego agrega una diapositiva normal basada en él. Los nombres de los diseños deben ser únicos dentro de la colección.

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

El método [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) proporciona un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/) para agregar formas de marcador de posición a un diseño.

| Marcador de posición de PowerPoint | Método `ILayoutPlaceholderManager` |
| ---------------------------------- | ----------------------------------- |
| ![Content](content.png)            | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                  | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png)      | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png)            | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png)                | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png)                | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)          | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)                | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png)   | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

El siguiente ejemplo verifica que el diseño **En blanco** exista, agrega cuatro marcadores de posición a él y, a continuación, crea una diapositiva normal que usa el diseño modificado. El orden es intencional: los marcadores se añaden antes de crear la diapositiva normal, de modo que Aspose.Slides pueda generar las formas de marcador correspondientes en esa diapositiva.

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

{{% alert color="warning" title="Advertencia" %}}
Cambiar el formato heredado o la geometría de los marcadores de posición existentes en un diseño puede afectar a las diapositivas dependientes. Un marcador de posición de diseño recién añadido no se retroalimenta en las diapositivas normales existentes. Pruebe los cambios de diseño en una copia de la presentación y examine cada diapositiva dependiente.
{{% /alert %}}

## **Eliminar diapositivas de diseño no usadas**

Utilice el método [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) para eliminar los diseños a los que ninguna diapositiva normal hace referencia. El método deja intactos los diseños que siguen en uso.

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

Para eliminar un diseño específico, primero utilice su método [get_HasDependingSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) o [GetDependingSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/getdependingslides/). Reasigne cualquier diapositiva dependiente antes de llamar a [ILayoutSlide::Remove](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/remove/). Intentar eliminar un diseño en uso genera una [PptxEditException](https://reference.aspose.com/slides/es/cpp/aspose.slides/pptxeditexception/).

## **Controlar la visibilidad del pie de página en una diapositiva de diseño**

Un diseño tiene sus propios marcadores de pie de página, número de diapositiva y fecha/hora. Utilice el método [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) para controlar esos marcadores en un diseño. Esto resulta útil, por ejemplo, cuando los diseños de contenido deben mostrar pies de página pero los diseños de título no.

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

Para aplicar configuraciones de pie de página consistentes en toda la jerarquía de una maestra, utilice el método [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Los métodos de propagación de [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslideheaderfootermanager/) actúan sobre la maestra y sus diapositivas de diseño y diapositivas normales dependientes; no se centran en una sola diapositiva normal.

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

Una diapositiva maestra define el tema de la presentación y el formato compartido. Una diapositiva de diseño pertenece a una maestra y define una disposición reutilizable de marcadores de posición. Las diapositivas normales usan esos diseños y almacenan el contenido específico de cada diapositiva.

**¿Puedo copiar una diapositiva de diseño de una presentación a otra?**

Sí. Añada una copia a la colección de destino con el método [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/igloballayoutslidecollection/addclone/). Al copiar entre presentaciones, también verifique fuentes, temas, imágenes y demás recursos utilizados por el diseño origen.

**¿Qué ocurre cuando modifico un diseño que ya está en uso?**

Las diapositivas dependientes heredan los cambios del diseño, salvo que hayan sobrescrito localmente el formato o los objetos afectados. La geometría de los marcadores y el estilo heredado pueden cambiar en muchas diapositivas a la vez. Utilice [GetDependingSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/getdependingslides/) para identificar las diapositivas afectadas antes de editar el diseño.

**¿Qué ocurre si elimino un diseño que sigue en uso?**

Aspose.Slides lanza una [PptxEditException](https://reference.aspose.com/slides/es/cpp/aspose.slides/pptxeditexception/). Reasigne primero las diapositivas dependientes, o utilice [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) para eliminar solo los diseños no referenciados.