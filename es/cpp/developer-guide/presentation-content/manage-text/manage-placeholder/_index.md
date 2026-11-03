---
title: Gestionar marcadores de posición de presentaciones en C++
linktitle: Gestionar marcadores de posición
type: docs
weight: 10
url: /es/cpp/manage-placeholder/
keywords:
- marcador de posición
- marcador de posición de texto
- marcador de posición de imagen
- marcador de posición de gráfico
- marcador de posición de contenido
- texto de sugerencia
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprende a inspeccionar y editar marcadores de posición de texto, imagen, gráfico y contenido, y comprende la herencia de marcadores de posición con Aspose.Slides para C++."
---
## **Visión general**

Un marcador de posición es una forma que reserva una posición para un tipo particular de contenido en una plantilla de presentación. Los ejemplos más comunes son los marcadores de posición de título, cuerpo, imagen, gráfico y contenido de propósito general. A diferencia de una forma ordinaria, un marcador de posición puede heredar su posición, tamaño, formato y otros ajustes de una diapositiva de diseño o de una diapositiva maestra.

Aspose.Slides expone la información de los marcadores de posición mediante el método [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/). El método devuelve un objeto [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/) o `nullptr` para una forma normal. Use [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) para determinar lo que se pretende que contenga el marcador de posición.

El interfaz de la forma sigue siendo importante después de conocer el tipo de marcador de posición:

- Un marcador de posición vacío de texto, imagen, gráfico o contenido se representa normalmente mediante un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
- Un marcador de posición de imagen poblado puede representarse mediante un [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/).
- Un marcador de posición de gráfico poblado puede representarse mediante un [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/).
- Un marcador de posición de contenido puede contener varios tipos de contenido. Compruebe tanto [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) como la interfaz de forma en tiempo de ejecución en lugar de asumir que cada marcador de posición es un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) describe el rol de un marcador de posición; no garantiza el tipo de forma en tiempo de ejecución. Siempre realice una comprobación de tipo antes de acceder a miembros específicos de texto, imagen, gráfico, tabla o multimedia.
{{% /alert %}}

## **Comprender la herencia de marcadores de posición**

Los marcadores de posición forman una jerarquía:

1. Una diapositiva maestra define estilos reutilizables y, en algunos casos, marcadores de posición a nivel maestro.
2. Una diapositiva de diseño define la disposición utilizada por una o más diapositivas normales y puede heredar de la maestra.
3. Una diapositiva normal contiene los marcadores de posición de esa diapositiva y puede heredar de su diseño.

Utilice [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) para subir un nivel en esta jerarquía. Un marcador de posición de diapositiva normalmente devuelve su marcador de posición de diseño; un marcador de posición de diseño puede devolver su marcador de posición maestro. El método devuelve `nullptr` cuando la forma no tiene un marcador de posición base.

El siguiente ejemplo enumera los marcadores de posición de la primera diapositiva y muestra sus marcadores de posición base:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

Editar un marcador de posición en una diapositiva normal crea o modifica una anulación local para esa diapositiva. Editar el diseño o la maestra relacionados puede afectar a todas las diapositivas que todavía heredan ese ajuste. Una forma ordinaria local no tiene marcador de posición base y no comienza a heredar solo porque ocupa las mismas coordenadas.

## **Eliminar el estado de marcador de posición**

Al adaptar una plantilla, utilice [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) para mantener un objeto existente como una forma ordinaria. Su método [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) devuelve `nullptr`, pero la forma sigue en la colección de la diapositiva. En contraste, [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) elimina la forma de esa colección.

El siguiente ejemplo requiere `template.pptx` con al menos una diapositiva y un marcador de posición de texto no vacío en la primera diapositiva. Utilice un marcador de posición con formato heredado de su diseño o maestra para observar el efecto de eliminar esa relación. El ejemplo verifica que la misma forma permanezca, llama al método nuevamente sobre la forma ahora ordinaria y guarda el resultado.

{{% alert color="warning" title="Warning" %}}
La eliminación del estado de marcador de posición no preserva automáticamente los ajustes de apariencia heredados. El ejemplo a continuación deja deliberadamente esos ajustes sin cambios, por lo que la salida puede verse diferente. Una forma cuya posición y tamaño son totalmente heredados puede quedar con coordenadas y dimensiones cero después de la llamada y volverse invisible aunque siga en la colección.
{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // Llamar al método sobre una forma ordinaria no tiene efecto.
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

Para un marcador de posición coincidente, los tres controles imprimen `True`. El texto permanece, pero la posición, tamaño, rotación, fuente, alineación de párrafo, márgenes del marco de texto, anclaje vertical, relleno y ajustes de línea heredados pueden cambiar cuando se elimina la relación del marcador de posición. Por ejemplo, el formato de título heredado puede volver al formato de texto ordinario. Consulte [Slide Layout](/slides/es/cpp/slide-layout/) para obtener más información sobre los diseños.

Para preservar la apariencia prevista, capture la posición, tamaño y rotación resueltos antes de la llamada y copie los valores de formato efectivo necesarios en variables independientes. Obtenga esos valores mediante [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/), [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/), [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/), y [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/). No confíe únicamente en los objetos de formato efectivo, ya que sus valores de formato de texto pueden cambiar después de que se elimine la relación. Aplique explícitamente los valores capturados a la forma ordinaria posteriormente, incluyendo la familia, tamaño, estilo, color de la fuente, ajustes de párrafo, ajustes del marco de texto, relleno y línea usados por su plantilla.

La geometría heredada de la forma también puede necesitar asignarse explícitamente mediante [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/). Para un marcador de posición de texto rectangular, esto significa asignar [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/); restaurar solo el relleno y la línea puede no restaurar el rectángulo visible. Las plantillas con efectos adicionales o formato más complejo requieren que dichos ajustes también se gestionen.

## **Cambiar texto en un marcador de posición**

Los marcadores de posición de título, título centrado, subtítulo, cuerpo y texto normalmente admiten texto. Verifique la presencia de [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) antes de usar su método [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/).

Este ejemplo actualiza el primer marcador de posición de título en la primera diapositiva y guarda el resultado:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

Este patrón evita convertir marcadores de posición de imagen, gráfico, tabla o multimedia a [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). También identifica el marcador de posición por su propósito en lugar de depender de un índice de forma frágil.

## **Establecer texto de sugerencia en un diseño**

El texto de sugerencia es la instrucción en tiempo de diseño que se muestra en un marcador de posición vacío, como *Haz clic para añadir título*. Establezca un texto de sugerencia personalizado en el marcador de posición del diseño en lugar de intentar alcanzarlo a través de la colección de formas de una diapositiva normal. Acceda al diseño mediante [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) e itere sobre [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/).

El siguiente ejemplo cambia los textos de sugerencia de título y subtítulo en el diseño utilizado por la primera diapositiva:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

El texto de sugerencia no es contenido normal de la diapositiva. Está destinado a marcadores de posición vacíos en aplicaciones de edición como PowerPoint. Cuando un usuario o programa proporciona contenido real, la sugerencia deja de mostrarse. Cambiar una sugerencia tampoco sustituye el texto existente en las diapositivas que usan el diseño.

## **Actualizar un marcador de posición de imagen**

Hay dos casos a manejar:

- Si el marcador de posición de imagen ya está poblado y representado por un [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), reemplace la imagen mediante [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) y [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/).
- Si sigue siendo un marcador de posición vacío, añada un marco de imagen en las coordenadas del marcador de posición con [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) y elimine el marcador de posición vacío.

El siguiente ejemplo admite ambos casos y guarda la presentación:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

La sustitución creada para un marcador de posición vacío es un marco de imagen local, no un nuevo marcador de posición, porque [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) es de solo lectura. Conserva la posición reservada pero ya no hereda el comportamiento específico del marcador de posición. Si es esencial mantener la relación del marcador de posición, prepare y rellene el marcador de posición en PowerPoint primero, y luego actualice el [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) resultante con Aspose.Slides.

Para la transparencia de imágenes, recorte y otros efectos específicos de la imagen, consulte [Manage Picture Frames](/slides/es/cpp/picture-frame/). esas operaciones pertenecen al marco de imagen o al relleno de imagen, no a los metadatos del marcador de posición.

## **Trabajar con marcadores de posición de gráfico y contenido**

Un marcador de posición de gráfico poblado puede representarse mediante un [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/). Este ejemplo encuentra dicho gráfico tanto por tipo de marcador de posición como por interfaz en tiempo de ejecución, cambia su título y guarda el archivo:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

Un marcador de posición de contenido general suele tener [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/). En PowerPoint actúa como lanzador para varios tipos de contenido, incluyendo gráficos, tablas, diagramas, imágenes y multimedia. Después de haber sido poblado, inspeccione la interfaz de forma real para saber qué contiene. Los diseños especializados también pueden exponer [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), o [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/).

Aspose.Slides no convierte un marcador de posición vacío de [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) en un [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) simplemente cambiando [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/); el tipo es de solo lectura. Para rellenar un gráfico o área de contenido vacía programáticamente, añada el objeto necesario en las coordenadas del marcador de posición y luego elimine el marcador de posición vacío. El siguiente ejemplo hace eso para un gráfico:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

El gráfico añadido es un gráfico local ordinario. Ocupa el área del marcador de posición pero no hereda del marcador de posición del diseño. Utilice los artículos dedicados a la gestión de gráficos [chart management articles](/slides/es/cpp/powerpoint-charts/) cuando necesite reemplazar sus categorías, series o datos del libro de trabajo.

## **Ejemplo completo: actualizar texto o contenido de imagen**

El siguiente ejemplo completo abre una plantilla, busca en la primera diapositiva un marcador de posición de título o de imagen, verifica los tipos de marcador de posición y de forma, actualiza el contenido correspondiente y guarda el resultado. El ejemplo evita deliberadamente asumir un índice de forma o convertir todos los marcadores de posición a la misma interfaz.

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **Preguntas frecuentes**

**¿Qué es un marcador de posición base?**

Un marcador de posición base es la forma correspondiente en el diseño o la maestra de la que otro marcador de posición hereda. Utilice [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) para obtenerlo. Una forma local ordinaria devuelve `nullptr` porque no forma parte de la jerarquía de marcadores de posición.

**¿Puedo cambiar todos los títulos de diapositiva editando un marcador de posición de diseño?**

Puede cambiar el formato heredado o el texto de sugerencia mediante un diseño, pero el contenido del título existente se almacena en las diapositivas normales. Para reemplazar el texto real del título en toda la presentación, itere sobre las diapositivas y actualice cada marcador de posición de título.

**¿Cómo gestiono los marcadores de posición de fecha, número de diapositiva, encabezado y pie de página?**

Utilice los gestores de encabezado y pie de página en la diapositiva, diseño, maestra, notas o alcance de folletos correspondiente. Consulte [Manage Presentation Header and Footer](/slides/es/cpp/presentation-header-and-footer/) para obtener ejemplos completos.