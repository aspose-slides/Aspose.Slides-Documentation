---
title: Управление SmartArt в презентациях PowerPoint с использованием C++
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/cpp/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- тип макета
- свойство скрытия
- организационная схема
- организационная схема с изображениями
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Изучите, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides для C++ с использованием понятных примеров кода, ускоряющих разработку слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, состоящая из узлов, фигур узлов и макета. С помощью Aspose.Slides для C++ вы можете создавать SmartArt, считывать текст из его узлов, изменять его макет, проверять скрытые узлы, настраивать макеты организационных схем и создавать диаграммы организационных схем с изображениями.

## **Получить текст из объекта SmartArt**

Узел SmartArt может содержать одну или несколько фигур. Чтобы считать текст из фигур узла, переберите [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/), затем прочитайте [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) , возвращаемый [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/).

Для примера требуется презентация с как минимум одним слайдом и объектом SmartArt в качестве первой фигуры на этом слайде. Он выводит каждый доступный текстовый фрейм в консоль.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **Изменить тип макета объекта SmartArt**

Макет SmartArt управляет тем, как узлы располагаются и соединяются. В следующем примере создаётся объект SmartArt с типом макета [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, затем он изменяется на значение `BasicProcess` и сохраняется презентация. Позиция и размер, передаваемые в [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/), измеряются в пунктах. Используйте [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) , чтобы изменить макет.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Проверить, скрыт ли узел SmartArt**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут присутствовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере добавляется узел к объекту SmartArt, использующему значение [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle`, и проверяется состояние скрытости добавленного узла. Если узел скрыт, выводится сообщение, и диаграмма сохраняется.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Получить или задать макет организационной схемы**

Для диаграмм SmartArt, использующих макет организационной схемы, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) и [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) определяют, как дочерние узлы располагаются под родительским узлом. Например, можно задать, чтобы дочерние узлы висели слева, справа или с обеих сторон, в зависимости от выбранного [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/).

В следующем примере создаётся организационная схема и задаётся макет для первого узла со значением [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`. Нулевой индекс `0` выбирает первый узел верхнего уровня; его дочерние узлы используют выбранное расположение. Затем изменённая презентация сохраняется.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Создать организационную схему с изображениями**

Организационная схема с изображениями — это макет SmartArt, предназначенный для иерархических диаграмм с заполнителями изображений. При добавлении объекта SmartArt на слайд используйте значение [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart`. Этот пример сохраняет диаграмму с заполнителями изображений; он не заполняет заполнители изображениями.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Преобразовать устаревшие диаграммы в группы фигур**

При модернизации существующей презентации возможно понадобится обновить организационную схему, изначально созданную в PowerPoint 97–2003. Aspose.Slides представляет эти устаревшие диаграммы как объекты [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/). Используйте [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/), чтобы преобразовать диаграмму в группу фигур, позволяя редактировать отдельные визуальные элементы. Подробности см. в [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/).

Преобразование добавляет новую группу в коллекцию фигур, не удаляя оригинальную диаграмму. После успешного преобразования удалите оригинал с помощью [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) , чтобы избежать дублирования содержимого. Сначала соберите устаревшие диаграммы в вектор перед их преобразованием, чтобы добавление и удаление фигур не нарушали перебор.

В следующем примере открывается презентация, ищутся все слайды, диаграммы преобразуются в группы фигур, и обновлённая презентация сохраняется в формате PPTX.

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Сохранённая презентация содержит редактируемые группы фигур вместо преобразованных устаревших диаграмм, без оставшихся оригинальных диаграмм рядом с ними. Откройте PPTX в PowerPoint, чтобы редактировать отдельные элементы внутри каждой группы, такие как их текст, заливка или позиция.

## **FAQ**

**Поддерживает ли SmartArt зеркальное отображение или обратное направление для RTL‑языков?**

Да. Метод [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) переключает направление диаграммы с слева направо на справа налево и обратно, если выбранный макет SmartArt поддерживает обратное направление.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать фигурку SmartArt](/slides/ru/cpp/shape-manipulations/) с помощью [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) , либо [клонировать весь слайд](/slides/ru/cpp/clone-slides/) , содержащий SmartArt. Оба подхода сохраняют размер, позицию и форматирование.

**Как отрендерить SmartArt в растровое изображение для предварительного просмотра или экспорта в веб?**

[Отрендерите слайд](/slides/ru/cpp/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt рендерится как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Задайте уникальное значение [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) или [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) для фигуры SmartArt, выполните поиск этого значения в [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/), а затем проверьте, что найденная фигура является [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/).