---
title: Gestionar guías de dibujo en presentaciones en C++
linktitle: Guías de dibujo
type: docs
weight: 85
url: /es/cpp/drawing-guides/
keywords:
- guía de dibujo
- guía horizontal
- guía vertical
- guía de alineación
- vista de diapositiva
- diapositiva maestra
- diapositiva de diseño
- maestro de notas
- maestro de folletos
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Añadir, acceder y eliminar guías de dibujo horizontales y verticales en presentaciones de PowerPoint utilizando Aspose.Slides para C++."
---
## **Visión general**

Las guías de dibujo son líneas horizontales y verticales ajustables que ayudan a los usuarios a alinear formas de forma consistente al editar una presentación en PowerPoint. Resultan especialmente útiles cuando una aplicación genera una presentación que será refinada manualmente después: la aplicación puede guardar los mismos elementos de alineación que los autores deben seguir al añadir o mover contenido.

Las guías de dibujo son ayudas de edición, no contenido de diapositiva. No aparecen en una presentación de diapositivas ni en la salida renderizada. Aspose.Slides for C++ las expone a través de la interfaz [IDrawingGuidesCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/idrawingguidescollection/). Una guía está representada por [IDrawingGuide](https://reference.aspose.com/slides/es/cpp/aspose.slides/idrawingguide/) y tiene una orientación, una posición y un color.

La posición se mide en puntos desde la esquina superior izquierda de la diapositiva o maestro correspondiente. Una guía vertical utiliza una coordenada horizontal, normalmente entre cero y el ancho de la diapositiva. Una guía horizontal utiliza una coordenada vertical, normalmente entre cero y la altura de la diapositiva.

## **Añadir guías a la vista de diapositiva**

Utilice [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/es/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) para gestionar las guías mostradas mientras se editan diapositivas normales. Llame a [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/es/cpp/aspose.slides/idrawingguidescollection/add/) con un valor de [Orientation](https://reference.aspose.com/slides/es/cpp/aspose.slides/orientation/) y una posición en puntos.

El siguiente ejemplo añade una guía vertical a la derecha del centro de la diapositiva y una guía horizontal debajo de ella:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Acceder a las guías de dibujo**

El método [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/es/cpp/aspose.slides/idrawingguidescollection/get_count/) y el método [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/es/cpp/aspose.slides/idrawingguidescollection/idx_get/) proporcionan acceso a las guías existentes. Los métodos [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/es/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/es/cpp/aspose.slides/idrawingguide/get_position/) y [IDrawingGuide::get_Color](https://reference.aspose.com/slides/es/cpp/aspose.slides/idrawingguide/get_color/) devuelven las propiedades actuales de una guía. Sus correspondientes métodos setter pueden modificar esas propiedades.

El siguiente ejemplo lee las guías de la vista de diapositiva de la presentación creada anteriormente:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **Añadir guías a los maestros y diapositivas de diseño**

Un maestro de diapositiva y cada una de sus diapositivas de diseño pueden tener sus propias colecciones de guías de dibujo. Utilice [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterslide/get_drawingguides/) para un maestro de diapositiva y [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilayoutslide/get_drawingguides/) para una diapositiva de diseño.

El siguiente ejemplo añade una guía vertical al primer maestro de diapositiva y una guía horizontal a la primera diapositiva de diseño:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Añadir guías a los maestros de notas y de folletos**

Los maestros de notas y los maestros de folletos también admiten guías de dibujo. Utilice [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasternotesslide/get_drawingguides/) y [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) para acceder a sus colecciones. Si una presentación no contiene uno de estos maestros, [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) o [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) crea el maestro predeterminado y lo devuelve.

El siguiente ejemplo añade una guía horizontal a un maestro de notas y una guía vertical a un maestro de folletos:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Eliminar guías de dibujo**

Llame a [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/es/cpp/aspose.slides/idrawingguidescollection/clear/) para eliminar todas las guías de una colección concreta. Vaciar una colección no afecta a las guías almacenadas en otro ámbito.

El siguiente ejemplo elimina las guías de la vista de diapositiva y todas las guías de los maestros de diapositiva, diapositivas de diseño, el maestro de notas y el maestro de folletos sin crear maestros que falten:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**¿Las guías de dibujo aparecen en una presentación de diapositivas o en imágenes exportadas?**

No. Las guías de dibujo son ayudas de alineación para la edición y no se renderizan como contenido de la presentación.

**¿Se puede añadir una guía de dibujo directamente a una diapositiva normal individual?**

Las guías de edición de diapositivas normales se almacenan en las propiedades de vista de diapositiva de la presentación. Existen colecciones de guías independientes para los maestros de diapositiva, las diapositivas de diseño, los maestros de notas y los maestros de folletos.

**¿Qué unidades se utilizan para las posiciones de las guías?**

Las posiciones se especifican en puntos, donde 72 puntos equivalen a una pulgada. Las posiciones verticales se miden desde el borde izquierdo y las posiciones horizontales se miden desde el borde superior.

**¿El borrado de guías de dibujo elimina formas o modifica el contenido de la diapositiva?**

No. El método `Clear` elimina únicamente las guías de la colección seleccionada. Las formas y demás contenido de la diapositiva permanecen sin cambios.