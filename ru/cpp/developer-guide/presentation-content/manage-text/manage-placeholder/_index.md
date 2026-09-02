---
title: Управление заполнителями презентации в C++
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/cpp/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- заполнитель изображения
- заполнитель диаграммы
- заполнитель содержимого
- подсказочный текст
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как просматривать и изменять текстовые, графические, диаграммные и содержательные заполнители, а также понять наследование заполнителей с помощью Aspose.Slides для C++."
---
## **Обзор**

Заполнитель — это объект, который резервирует позицию для определённого типа содержимого в шаблоне презентации. Распространённые примеры: заполнитель заголовка, основного текста, изображения, диаграммы и универсальный заполнитель содержимого. В отличие от обычного объекта, заполнитель может наследовать свою позицию, размер, форматирование и другие параметры от слайда‑макета или мастер‑слайда.

Aspose.Slides предоставляет информацию о заполнителях через метод [IShape::get_Placeholder](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_placeholder/). Метод возвращает объект [IPlaceholder](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iplaceholder/) или `nullptr` для обычного объекта. Используйте [IPlaceholder::get_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iplaceholder/get_type/) чтобы определить, какое содержимое предполагается в заполнителе.

Интерфейс объекта всё ещё имеет значение после того как вы узнали тип заполнителя:

- Пустой текстовый, графический, диаграммный или контент‑заполнитель обычно представлен объектом [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/).
- Заполненный графический заполнитель может быть представлен объектом [IPictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipictureframe/).
- Заполненный диаграммный заполнитель может быть представлен объектом [IChart](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/).
- Контент‑заполнитель может содержать несколько типов содержимого. Проверьте как [IPlaceholder::get_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iplaceholder/get_type/), так и интерфейс объекта во время выполнения, вместо того чтобы предполагать, что каждый заполнитель — это [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iplaceholder/get_type/) описывает роль заполнителя; он не гарантирует тип объекта во время выполнения. Всегда проверяйте тип перед доступом к членам, специфичным для текста, изображения, диаграммы, таблицы или медиа.
{{% /alert %}}

## **Понимание наследования заполнителей**

Заполнители образуют иерархию:

1. Мастер‑слайд определяет переиспользуемые стили и, в некоторых случаях, заполнители уровня мастера.
2. Слайд‑макет определяет расположение, используемое одним или несколькими обычными слайдами, и может наследовать от мастера.
3. Обычный слайд содержит заполнители для данного слайда и может наследовать от своего макета.

Вызовите [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/getbaseplaceholder/) чтобы подняться на один уровень выше в этой иерархии. Заполнитель слайда обычно возвращает свой заполнитель макета; заполнитель макета может вернуть свой заполнитель мастера. Метод возвращает `nullptr`, когда у объекта нет базового заполнителя.

В следующем примере перечисляются заполнители на первом слайде и выводятся их базовые заполнители:

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

Редактирование заполнителя на обычном слайде создаёт или изменяет локальное переопределение для этого слайда. Редактирование связанного макета или мастера может затронуть все слайды, которые всё ещё наследуют эту настройку. Обычный локальный объект не имеет базового заполнителя и не начинает наследовать лишь потому, что занимает те же координаты.

## **Изменение текста в заполнителе**

Заполнители заголовка, центрированного заголовка, подзаголовка, основного текста и текстовые заполнители обычно поддерживают ввод текста. Проверьте, является ли объект [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/), прежде чем вызывать его метод [get_TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/get_textframe/).

В этом примере обновляется первый заполнитель заголовка на первом слайде и сохраняется результат:

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

Этот подход избегает приведения графических, диаграммных, табличных или медиа‑заполнителей к [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/). Он также идентифицирует заполнитель по назначению, а не полагается на хрупкий индекс объекта.

## **Установить подсказочный текст на макете**

Подсказочный текст — это инструкция, отображаемая в пустом заполнителе во время разработки, например *Нажмите, чтобы добавить заголовок*. Устанавливайте пользовательский подсказочный текст непосредственно на заполнитель макета, а не пытаясь достучаться до него через коллекцию объектов обычного слайда. Получите макет через [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/get_layoutslide/) и пройдите по коллекции [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/get_shapes/).

В следующем примере изменяются подсказки заголовка и подзаголовка на макете, используемом первым слайдом:

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

Подсказочный текст не является обычным содержимым слайда. Он предназначен для пустых заполнителей в редакторах, таких как PowerPoint. Как только пользователь или программа вставляют реальное содержимое, подсказка перестаёт отображаться. Изменение подсказки также не заменяет существующий текст на слайдах, использующих данный макет.

## **Обновление заполняющего изображения**

Есть два случая, которые необходимо обработать:

- Если графический заполнитель уже заполнен и представлен объектом [IPictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipictureframe/), замените изображение через [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipicturefillformat/get_picture/) и [ISlidesPicture::set_Image](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidespicture/set_image/).
- Если он всё ещё пустой, добавьте графический объект в координаты заполнителя с помощью [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/addpictureframe/) и удалите пустой заполнитель.

Следующий пример поддерживает оба случая и сохраняет презентацию:

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

Замена, созданная для пустого заполнителя, представляет собой локальный графический объект, а не новый заполнитель, поскольку [IShape::get_Placeholder](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_placeholder/) только для чтения. Он сохраняет зарезервированную позицию, но более не наследует поведение заполнителя. Если сохранение связи с заполнителем критично, подготовьте и заполните заполнитель в PowerPoint, а затем обновите полученный [IPictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ipictureframe/) с помощью Aspose.Slides.

Для прозрачности изображения, обрезки и других графических эффектов см. [Manage Picture Frames](/slides/ru/cpp/picture-frame/). Эти операции относятся к графическому объекту или заливке изображения, а не к метаданным заполнителя.

## **Работа с диаграммными и контентными заполнителями**

Заполненный диаграммный заполнитель может быть представлен объектом [IChart](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/). Этот пример находит такую диаграмму по типу заполнителя и интерфейсу во время выполнения, изменяет её заголовок и сохраняет файл:

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

Общий контент‑заполнитель обычно имеет тип [PlaceholderType::Object](https://reference.aspose.com/slides/ru/cpp/aspose.slides/placeholdertype/). В PowerPoint он служит запускателем для различных типов содержимого, включая диаграммы, таблицы, схемы, изображения и медиа. После заполнения проверьте фактический интерфейс объекта, чтобы узнать, что именно он содержит. Специализированные макеты могут также предоставлять типы [PlaceholderType::Chart](https://reference.aspose.com/slides/ru/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/ru/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/ru/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/ru/cpp/aspose.slides/placeholdertype/), или [PlaceholderType::Diagram](https://reference.aspose.com/slides/ru/cpp/aspose.slides/placeholdertype/).

Aspose.Slides не преобразует пустой заполнитель [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) в [IChart](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/ichart/) простым изменением [IPlaceholder::get_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iplaceholder/get_type/); тип только для чтения. Чтобы программно заполнить пустую диаграмму или область контента, добавьте необходимый объект в координаты заполнителя, а затем удалите пустой заполнитель. Следующий пример делает это для диаграммы:

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

Добавленная диаграмма — обычная локальная диаграмма. Она занимает область заполнителя, но не наследует свойства от заполняющего макета. Используйте специализированные статьи по управлению диаграммами [/slides/ru/cpp/powerpoint-charts/] при необходимости заменить категории, серии или данные книги.

## **Полный пример: обновление текста или изображения**

В следующем сквозном примере открывается шаблон, ищется первый слайд для заполнителя заголовка или изображения, проверяются типы заполнителя и объекта, обновляется соответствующее содержимое и сохраняется результат. Пример намеренно избегает предположения о индексе объекта и приведения каждого заполнителя к одному интерфейсу.

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

## **Вопросы и ответы**

**Что такое базовый заполнитель?**

Базовый заполнитель — это соответствующий объект на макете или мастере, от которого другой заполнитель наследует свойства. Используйте [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/getbaseplaceholder/) чтобы получить его. Обычный локальный объект возвращает `nullptr`, потому что он не является частью иерархии заполнителей.

**Можно ли изменить все заголовки слайдов, отредактировав заполнитель макета?**

Можно изменить наследуемое форматирование или подсказочный текст через макет, но фактическое содержимое заголовков хранится на обычных слайдах. Чтобы заменить реальный текст заголовков во всей презентации, пройдитесь по слайдам и обновите каждый заполнитель заголовка.

**Как управлять заполнителями даты, номера слайда, верхнего и нижнего колонтитулов?**

Используйте менеджеры колонтитулов на соответствующем уровне — слайд, макет, мастер, заметки или раздаточная версия. См. [Manage Presentation Header and Footer](/slides/ru/cpp/presentation-header-and-footer/) для полных примеров.