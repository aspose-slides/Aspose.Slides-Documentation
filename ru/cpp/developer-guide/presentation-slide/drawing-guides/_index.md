---
title: Управление направляющими в презентациях на C++
linktitle: Направляющие
type: docs
weight: 85
url: /ru/cpp/drawing-guides/
keywords:
- направляющая
- горизонтальная направляющая
- вертикальная направляющая
- направляющая выравнивания
- представление слайда
- мастер‑слайд
- макетный слайд
- мастер заметок
- мастер раздаточных материалов
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Добавляйте, получайте доступ и удаляйте горизонтальные и вертикальные направляющие в презентациях PowerPoint с помощью Aspose.Slides для C++."
---
## **Обзор**

Линейки‑направляющие представляют собой регулируемые горизонтальные и вертикальные линии, которые помогают пользователям последовательно выравнивать фигурки при редактировании презентации в PowerPoint. Они особенно полезны, когда приложение генерирует презентацию, которую затем будет дорабатывать вручную: приложение может сохранить те же вспомогательные линии выравнивания, которыми должны пользоваться авторы при добавлении или перемещении содержимого.

Линейки‑направляющие — это вспомогательные средства редактирования, а не содержимое слайдов. Они не отображаются в показе слайдов и в результирующем выводе. Aspose.Slides for C++ предоставляет их через интерфейс [IDrawingGuidesCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idrawingguidescollection/) . Одна направляющая представлена объектом [IDrawingGuide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idrawingguide/) и имеет ориентацию, позицию и цвет.

Позиция измеряется в пунктах от верхнего левого угла соответствующего слайда или шаблона. Вертикальная направляющая использует горизонтальную координату, обычно в диапазоне от нуля до ширины слайда. Горизонтальная направляющая использует вертикальную координату, обычно в диапазоне от нуля до высоты слайда.

## **Добавление направляющих в представление слайда**

Используйте [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) для управления направляющими, отображаемыми при редактировании обычных слайдов. Вызовите [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idrawingguidescollection/add/) с параметром [Orientation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/orientation/) и позицией в пунктах.

В следующем примере добавляются одна вертикальная направляющая справа от центра слайда и одна горизонтальная направляющая ниже её:

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

## **Доступ к направляющим**

Метод [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idrawingguidescollection/get_count/) и метод [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idrawingguidescollection/idx_get/) предоставляют доступ к существующим направляющим. Методы [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idrawingguide/get_position/), и [IDrawingGuide::get_Color](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idrawingguide/get_color/) возвращают текущие свойства направляющей. Соответствующие методы‑установщики могут изменять эти свойства.

В следующем примере читаются направляющие представления слайда из выше созданной презентации:

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

## **Добавление направляющих к шаблонам слайдов и макетам**

У шаблона слайда и каждого его макета могут быть свои собственные коллекции направляющих. Используйте [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/get_drawingguides/) для шаблона слайда и [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/get_drawingguides/) для макета.

В следующем примере добавляется вертикальная направляющая к первому шаблону слайда и горизонтальная направляющая к первому макету:

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

## **Добавление направляющих к шаблонам заметок и раздаточных материалов**

Шаблоны заметок и раздаточных материалов также поддерживают направляющие. Используйте [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasternotesslide/get_drawingguides/) и [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) для доступа к их коллекциям. Если презентация не содержит один из этих шаблонов, [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) или [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) создают шаблон по умолчанию и возвращают его.

В следующем примере добавляется горизонтальная направляющая к шаблону заметок и вертикальная направляющая к шаблону раздаточного материала:

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

## **Удаление направляющих**

Вызовите [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/ru/cpp/aspose.slides/idrawingguidescollection/clear/) , чтобы удалить все направляющие из определённой коллекции. Очистка одной коллекции не влияет на направляющие, хранящиеся в другом контексте.

В следующем примере очищаются направляющие представления слайда и все направляющие на шаблонах слайдов, макетах, шаблоне заметок и шаблоне раздаточного материала без создания недостающих шаблонов:

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

**Появляются ли направляющие в показе слайдов или экспортированных изображениях?**

Нет. Направляющие — это вспомогательные средства выравнивания при редактировании и они не отображаются как содержимое презентации.

**Можно ли добавить направляющую напрямую к отдельному обычному слайду?**

Направляющие для редактирования обычного слайда хранятся в свойствах представления слайда презентации. Отдельные коллекции направляющих доступны для шаблонов слайдов, макетов, шаблонов заметок и шаблонов раздаточного материала.

**Какие единицы измерения используются для позиций направляющих?**

Позиции указываются в пунктах, где 72 пункта соответствуют одному дюйму. Вертикальные позиции измеряются от левого края, а горизонтальные — от верхнего края.

**Удаляет ли очистка направляющих фигуры или изменяет содержимое слайда?**

Нет. Метод `Clear` удаляет только направляющие в выбранной коллекции. Фигуры и другое содержимое слайда остаются без изменений.