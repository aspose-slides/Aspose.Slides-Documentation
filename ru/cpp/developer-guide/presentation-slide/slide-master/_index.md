---
title: УManaging презентаций мастеров слайдов в C++
linktitle: Мастер слайда
type: docs
weight: 80
url: /ru/cpp/slide-master/
keywords:
- мастер слайда
- мастер‑слайд
- мастер‑слайд PPT
- несколько мастеров слайдов
- сравнение мастеров слайдов
- фон
- заполнитель
- клонирование мастера слайда
- копирование мастера слайда
- дублирование мастера слайда
- неиспользуемый мастер слайда
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Управляйте мастерами слайдов в Aspose.Slides для C++: получайте доступ, редактируйте, клонируйте, сравнивайте и удаляйте мастер‑слайды в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Слайд‑мастер** определяет общие параметры дизайна для группы слайдов. Он может содержать общие фигуры, логотипы, фоны, стили текста, параметры темы и настройки нижних колонтитулов. В PowerPoint редактирование слайд‑мастера — обычный способ поддерживать согласованность презентации без повторения одинакового форматирования на каждом слайде.

Aspose.Slides для C++ поддерживает ту же модель. Презентация может содержать один или несколько мастеров слайдов, каждый из которых может включать несколько макетов слайдов. Обычные слайды обычно не ссылаются напрямую на мастер‑слайд. Вместо этого обычный слайд использует макетный слайд, а этот макетный слайд принадлежит мастеру.

Иерархия выглядит так:

1. **Слайд‑мастер** – определяет общий дизайн и тему.  
1. **Макетный слайд** – определяет конкретное расположение заполнителей и форматирование уровня макета.  
1. **Обычный слайд** – содержит фактическое содержимое презентации и использует один макетный слайд.

![Иерархия мастеров слайдов, макетных слайдов и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides слайд‑мастер представлен интерфейсом [IMasterSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/). Все мастера слайдов в презентации доступны через коллекцию [Presentation::get_Masters](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_masters/), реализующую [IMasterSlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Когда одно и то же свойство определено на более чем одном уровне, приоритет имеет более конкретный уровень. Например, если мастер‑слайд и макетный слайд оба определяют фон, слайды, основанные на этом макете, используют фон макета. Более подробную информацию о макетных слайдах см. в разделе [Применить или изменить макеты слайдов](/slides/ru/cpp/slide-layout/).
{{% /alert %}}

## **Доступ к мастерам слайдов**

В PowerPoint вы можете открыть режим просмотра Слайд‑мастер через **Вид** > **Слайд‑мастер**.

![Команда Слайд‑мастер на вкладке Вид в PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию `get_Masters()` для доступа к мастерам слайдов:

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Вы также можете получить мастер‑слайд, используемый обычным слайдом, через его макет:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Что содержит мастер‑слайд**

Мастер‑слайд — это объект, похожий на слайд. Он реализует [IBaseSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/), поэтому предоставляет многие из тех же свойств слайда, которые используются обычными и макетными слайдами. Специфические для мастера члены перечислены на странице API [IMasterSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/).

Часто используемые члены мастер‑слайда включают:

| Член | Назначение |
| --- | --- |
| `get_Background()` | Устанавливает фон слайда уровня мастера. |
| `get_Shapes()` | Содержит фигуры, размещённые на мастере, такие как логотипы, рамки изображений и общий текст. |
| `get_LayoutSlides()` | Содержит макетные слайды, принадлежащие этому мастеру. |
| `get_ThemeManager()` | Предоставляет доступ к API темы мастера. |
| `get_HeaderFooterManager()` | Управляет верхними и нижними колонтитулами, датами и номерами слайдов для мастера и его дочерних макетов. |
| `GetDependingSlides()` | Возвращает обычные слайды, зависящие от мастера через их макеты. |

## **Добавление изображения в мастер‑слайд**

Когда вы добавляете изображение в мастер‑слайд, оно появляется на слайдах, использующих макеты этого мастера. Это удобно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

Следующий пример добавляет логотип на первый мастер‑слайд:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Более подробную информацию о рамках изображений см. в разделе [Рамка изображения](/slides/ru/cpp/picture-frame/).

## **Управление видимостью графики мастера**

Используйте [IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/set_showmastershapes/), чтобы скрыть унаследованную графику мастера, такую как логотипы или декоративные фигуры, не удаляя их из мастера. Передайте `false` в [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/slide/set_showmastershapes/) на слайде, где графика должна быть скрыта, и `true` на слайдах, где её нужно отобразить.

Следующий независимый пример создаёт синюю декоративную полосу на мастере и два слайда, использующие один и тот же пустой макет. Полоса видна на первом слайде и скрыта на втором. Входная презентация или изображение не требуются.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Пример использует макет **Blank**, поставляемый с новой презентацией, и удаляет собственные заполнители начального слайда.

### **Выбор области действия настройки**

Обычный слайд использует свой мастер через [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/get_layoutslide/) и [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/get_masterslide/). Установка свойства на отдельном слайде влияет только на этот слайд. Передача `false` в [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/layoutslide/set_showmastershapes/) скрывает графику мастера для всех слайдов, использующих общий макет, даже если их собственная настройка `true`. Чтобы скрыть графику только на одном слайде, измените свойство слайда и оставьте общий макет без изменений.

Настройка не поддерживается как средство управления видимостью непосредственно на мастере. На мастере она всегда возвращает `false`, а присвоение `true` генерирует `System::NotSupportedException`. Применяйте её к обычному слайду или к макету.

### **Отличие графики от фона**

| Операция | Эффект |
| --- | --- |
| Скрыть графику мастера | Управляет видимостью унаследованных фигур мастера без их удаления или изменения собственных фигур слайда. |
| Изменить заливку фона слайда | Меняет цвет, градиент или изображение фона. Графика мастера — отдельные фигуры и может оставаться видимой поверх этого фона. См. [Фон презентации](/slides/ru/cpp/presentation-background/). |
| Удалить фигуру из мастера | Удаляет общую исходную фигуру, поэтому она более недоступна ни для одного слайда, использующего этот мастер. |

## **Работа с заполнителями**

Заполнители обычно определяются на макетных слайдах. Мастер‑слайд предоставляет общий стиль и тему, которые наследуют эти макеты, а каждый макет решает, какие заполнители доступны и где они размещаются.

В PowerPoint команды заполнителей доступны в режиме просмотра Слайд‑мастер.

![Команда Вставить заполнитель в режиме просмотра Слайд‑мастер PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с Aspose.Slides, работайте с макетным слайдом, принадлежащим мастеру:

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Вы также можете форматировать уже существующие фигуры заполнителей на мастере. В следующем примере находится заполнитель заголовка и применяется линейная градиентная заливка:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Отформатированный заполнитель заголовка, унаследованный обычными слайдами](slide-master_8.png)

Для дополнительных вариантов форматирования заполнителей и текста см. [Установить подсказочный текст в заполнитель](/slides/ru/cpp/manage-placeholder/) и [Форматирование текста](/slides/ru/cpp/text-formatting/).

## **Изменение фона мастера слайда**

Фон мастера наследуется макетами и слайдами, которые его не переопределяют. В следующем примере задаётся сплошной цвет фона для первого мастера слайда:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

См. связанные темы: [Фон презентации](/slides/ru/cpp/presentation-background/) и [Тема презентации](/slides/ru/cpp/presentation-theme/).

## **Клонирование мастера слайда в другую презентацию**

Используйте [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslidecollection/addclone/) для копирования мастера слайда в другую презентацию. Скопированный мастер затем может использоваться макетами и слайдами в целевой презентации.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Если необходимо клонировать обычные слайды вместе с их мастером, см. [Клонировать слайды](/slides/ru/cpp/clone-slides/).

## **Добавление нескольких мастеров слайдов**

Презентация может содержать несколько мастеров слайдов. Это полезно, когда разные разделы требуют различного брендинга, структуры страниц или параметров темы.

![Команды PowerPoint для вставки и управления мастерами слайдов](slide-master_9.jpg)

В следующем примере клонируется мастер по умолчанию, клону задаётся иной фон, создаётся макет под этим клонированным мастером и добавляется новый слайд, основанный на этом макете:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Сравнение мастеров слайдов**

Мастера слайдов можно сравнивать методом `Equals`, унаследованным от [IBaseSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/). Сравнение проверяет структуру и статическое содержимое, такое как фигуры, текст, форматирование, анимацию и другие параметры слайда. Оно не сравнивает уникальные идентификаторы, например ID слайдов, или динамические значения заполнителей, такие как текущая дата.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Для более подробной информации см. [Сравнить слайды презентации](/slides/ru/cpp/compare-slides/).

## **Установка просмотра Слайд‑мастер как представления по умолчанию**

Используйте метод `set_LastView` у [ViewProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/) для управления тем, какое представление PowerPoint открывает первым. В следующем примере презентация открывается в режиме просмотра Слайд‑мастер:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Для дополнительных настроек представления см. [Сохранить презентацию](/slides/ru/cpp/save-presentation/).

## **Удаление неиспользуемых мастеров слайдов**

Иногда в презентациях остаются мастеры слайдов, которые больше не используются никакими обычными слайдами. Удаление таких мастеров может уменьшить размер файла и упростить обслуживание шаблонов.

Используйте [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/ru/cpp/aspose.slides/masterslidecollection/removeunused/) для удаления неиспользуемых мастеров из коллекции `get_Masters()`:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Можно также применить метод низкоуровневого кода [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**В чём разница между мастером слайда и макетным слайдом?**

Мастер‑слайд определяет общие параметры дизайна, такие как тема, фон, общие фигуры и стили текста. Макетный слайд принадлежит мастеру и определяет конкретное расположение заполнителей. Обычный слайд использует макетный слайд, поэтому наследует как от макета, так и от мастера.

**Может ли одна презентация содержать несколько мастеров слайдов?**

Да. Презентация может содержать несколько мастеров слайдов. Используйте несколько мастеров, когда разные разделы требуют разных визуальных систем или брендинга.

**Следует ли добавлять заполнители в мастер‑слайд или в макетный слайд?**

В большинстве случаев заполнители добавляются в макетные слайды. Общие визуальные элементы и общие параметры форматирования помещаются в мастер‑слайд, а заполнители содержимого – в макеты, которые будут использовать обычные слайды.

**Можно ли удалить мастер‑слайд, который всё ещё используется?**

Нет. Мастер‑слайд, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала переместите эти слайды в макеты под другим мастером или используйте метод очистки неиспользуемых мастеров, который удалит только те мастеры, которые не задействованы.