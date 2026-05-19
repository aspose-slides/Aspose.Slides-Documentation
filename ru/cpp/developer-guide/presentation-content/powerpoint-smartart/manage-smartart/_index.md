---
title: Управление SmartArt в презентациях PowerPoint с помощью C++
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/cpp/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- Тип макета
- Свойство скрытия
- Организационная схема
- Изображённая организационная схема
- PowerPoint
- Презентация
- C++
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides для C++ с помощью понятных примеров кода, ускоряющих разработку слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, состоящая из узлов, фигур узлов и макета. С помощью Aspose.Slides для C++ вы можете создавать SmartArt, считывать текст из его узлов, изменять макет, проверять скрытые узлы, настраивать макеты организационных схем и создавать изображения организационных схем.

## **Получение текста из объекта SmartArt**

У узла SmartArt может быть одна или несколько фигур. Чтобы прочитать видимый текст, пройдитесь по [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/smartart/get_allnodes/), затем прочитайте [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/), возвращаемый [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/smartartshape/get_textframe/).



## **Изменение типа макета объекта SmartArt**

Макет SmartArt определяет, как узлы располагаются и соединяются. В следующем примере создаётся объект SmartArt с типом [SmartArtLayoutType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, затем он меняется на значение `BasicProcess` и презентация сохраняется.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Проверка, скрыт ли узел SmartArt**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут присутствовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере добавляется узел к объекту SmartArt, использующему тип [SmartArtLayoutType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle`, и проверяется состояние скрытости узла.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Получение или установка макета организационной схемы**

Для диаграмм SmartArt, использующих макет организационной схемы, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) и [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) определяют, как дочерние узлы располагаются под родительским узлом. Например, можно задать «висеть» дочерним узлам слева, справа или с обеих сторон, в зависимости от выбранного [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/organizationchartlayouttype/).

В следующем примере создаётся организационная схема и для первого узла задаётся макет [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Создание изображённой организационной схемы**

Изображённая организационная схема — это макет SmartArt, предназначенный для иерархических диаграмм с заполнителями изображений. При добавлении объекта SmartArt на слайд используйте значение [SmartArtLayoutType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart`.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Поддерживает ли SmartArt зеркальное отображение или инверсию для RTL‑языков?**

Да. Метод [SmartArt::set_IsReversed](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/smartart/set_isreversed/) переключает направление диаграммы слева направо ↔ справа налево, если выбранный макет SmartArt поддерживает инверсию.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Можно [клонировать форму SmartArt](/slides/ru/cpp/shape-manipulations/) с помощью [ShapeCollection::AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shapecollection/addclone/) или [клонировать весь слайд](/slides/ru/cpp/clone-slides/), содержащий SmartArt. Оба способа сохраняют размер, позицию и форматирование.

**Как отобразить SmartArt в растровом изображении для предварительного просмотра или веб‑экспорта?**

[Отрендерите слайд](/slides/ru/cpp/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt будет отрисован как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Установите уникальное значение в [Shape::set_AlternativeText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shape/set_alternativetext/) или [Shape::set_Name](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shape/set_name/) для формы SmartArt, выполните поиск этого значения в [BaseSlide::get_Shapes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/baseslide/get_shapes/), а затем проверьте, что найденная форма является [ISmartArt](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/ismartart/).