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
- заполнитель контента
- текст подсказки
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как просматривать и редактировать текстовые, изображения, диаграммы и контентные заполнители, а также понять наследование заполнителей с помощью Aspose.Slides для C++."
---
## **Обзор**

Заполнитель — это фигура, которая резервирует позицию для определённого типа содержимого в шаблоне презентации. Распространёнными примерами являются заполнитель заголовка, основного текста, изображения, диаграммы и заполнитель общего назначения. В отличие от обычной фигуры, заполнитель может наследовать свою позицию, размер, форматирование и другие параметры от слайда‑шаблона или шаблона‑маски.

Aspose.Slides предоставляет информацию о заполнителе через метод [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/). Метод возвращает объект [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/) или `nullptr` для обычной фигуры. Используйте [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) для определения того, что должен содержать заполнитель.

Интерфейс фигуры всё ещё важен после того, как вы определили тип заполнителя:

- Пустой текстовый, изображений, диаграммный или контентный заполнитель обычно представлен объектом [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
- Заполненный заполнитель изображения может быть представлен объектом [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/).
- Заполненный заполнитель диаграммы может быть представлен объектом [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/).
- Заполнитель контента может содержать несколько видов содержимого. Проверяйте как [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/), так и интерфейс фигуры во время выполнения, вместо того чтобы предполагать, что каждый заполнитель — это [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) описывает роль заполнителя; она не гарантирует тип фигуры во время выполнения. Всегда проверяйте тип перед доступом к тексту, изображению, диаграмме, таблице или медиа‑специфичным членам.
{{% /alert %}}

## **Понимание наследования заполнителей**

Заполнители образуют иерархию:

1. Шаблон‑маска определяет переиспользуемые стили и, в некоторых случаях, заполнители уровня маски.
2. Слайд‑шаблон определяет расположение, используемое одним или несколькими обычными слайдами, и может наследовать от маски.
3. Обычный слайд содержит заполнители для данного слайда и может наследовать от своего шаблона‑шаблона.

Вызовите [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) для перехода на один уровень выше в этой иерархии. Заполнитель слайда обычно возвращает свой заполнитель шаблона; заполнитель шаблона может вернуть свой заполнитель маски. Метод возвращает `nullptr`, когда у фигуры нет базового заполнителя.

Следующий пример перечисляет заполнители на первом слайде и выводит их базовые заполнители:

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

Редактирование заполнителя на обычном слайде создаёт или изменяет локальное переопределение для этого слайда. Редактирование связанного шаблона‑шаблона или маски может повлиять на все слайды, которые ещё наследуют этот параметр. Обычная локальная фигура не имеет базового заполнителя и не начинает наследовать только потому, что занимает те же координаты.

## **Удаление статуса заполнителя**

При адаптации шаблона используйте [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) чтобы сохранить существующий объект как обычную фигуру. Его метод [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) возвращает `nullptr`, но фигура остаётся в коллекции слайда. В отличие от этого, [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) удаляет фигуру из этой коллекции.

Следующий пример требует файл `template.pptx` как минимум с одним слайдом и непустым текстовым заполняющим элементом на первом слайде. Используйте заполнитель с форматированием, унаследованным от его шаблона‑шаблона или маски, чтобы увидеть эффект удаления этой связи. Пример проверяет, что та же фигура остаётся, снова вызывает метод для теперь уже обычной фигуры и сохраняет результат.

{{% alert color="warning" title="Warning" %}}
Удаление статуса заполнителя автоматически не сохраняет унаследованные параметры внешнего вида. Ниже приведённый пример преднамеренно оставляет эти настройки без изменений, поэтому результат может выглядеть иначе. Фигура, позиция и размер которой полностью унаследованы, может после вызова иметь нулевые координаты и размеры и стать невидимой, хотя остаётся в коллекции.
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

    // Вызов метода на обычной фигуре не оказывает эффекта.
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

Для совпадающего заполнителя все три проверки выводят `True`. Текст остаётся, но унаследованные позиция, размер, вращение, шрифт, выравнивание абзаца, отступы текстового кадра, вертикальная привязка, параметры заливки и линии могут измениться при удалении связи заполнителя. Например, унаследованное форматирование заголовка может вернуться к обычному текстовому форматированию. См. [Slide Layout](/slides/ru/cpp/slide-layout/) для более подробной информации о шаблонах‑шаблонах.

Чтобы сохранить ожидаемый вид, зафиксируйте вычисленные позицию, размер и вращение до вызова и скопируйте необходимые эффективные значения форматирования в отдельные переменные. Получите эти значения через [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/), [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/), [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/), и [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/). Не полагайтесь только на объекты эффективного форматирования, поскольку их параметры текстового форматирования могут измениться после удаления связи. Явно примените зафиксированные значения к обычной фигуре впоследствии, включая семейство шрифта, размер, стиль, цвет, параметры абзаца, настройки текстового кадра, заливку и линию, используемые в вашем шаблоне.

Унаследованная геометрия фигуры также может потребовать явного назначения через [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/). Для прямоугольного текстового заполнителя это означает назначение [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/); восстановление только заливки и линии может не восстановить видимый прямоугольник. Шаблоны с дополнительными эффектами или более сложным форматированием требуют обработки этих параметров также.

## **Изменение текста в заполнитель**

Заголовок, центрированный‑заголовок, подзаголовок, основной текст и текстовые заполнители обычно поддерживают текст. Проверьте наличие [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) перед использованием его метода [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/).

Этот пример обновляет первый заполнитель заголовка на первом слайде и сохраняет результат:

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

Этот подход избегает приведения заполнителей изображения, диаграммы, таблицы или медиа к [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). Он также определяет заполнитель по назначению, а не опирается на хрупкий индекс фигуры.

## **Установить текст подсказки в макете**

Текст подсказки — это инструкция времени разработки, отображаемая в пустом заполнителе, например *Щелкните, чтобы добавить заголовок*. Установите пользовательский текст подсказки в заполнитель макета, а не пытайтесь получить его через коллекцию фигур обычного слайда. Доступ к макету осуществляется через [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) и перебором [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/).

Следующий пример меняет подсказки заголовка и подзаголовка в макете, используемом первым слайдом:

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

Текст подсказки не является обычным содержимым слайда. Он предназначен для пустых заполнителей в редакторах, таких как PowerPoint. Как только пользователь или программа предоставляют реальное содержимое, подсказка больше не отображается. Изменение подсказки также не заменяет существующий текст на слайдах, использующих данный макет.

## **Обновление заполнителя изображения**

Существует два сценария обработки:

- Если заполнитель изображения уже заполнен и представлен объектом [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), замените изображение через [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) и [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/).
- Если это всё ещё пустой заполнитель, добавьте кадр изображения в координатах заполнителя с помощью [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) и удалите пустой заполнитель.

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

Созданная замена для пустого заполнителя представляет собой локальный кадр изображения, а не новый заполнитель, потому что [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) только для чтения. Он сохраняет зарезервированную позицию, но более не наследует поведение, специфичное для заполнителя. Если сохранение связи заполнителя критично, подготовьте и заполните заполнитель в PowerPoint сначала, затем обновите полученный [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) с помощью Aspose.Slides.

Для прозрачности изображения, обрезки и других эффектов, специфичных для изображений, см. [Manage Picture Frames](/slides/ru/cpp/picture-frame/). Эти операции относятся к кадру изображения или заливке изображения, а не к метаданным заполнителя.

## **Работа с заполнителями диаграмм и контента**

Заполненный заполнитель диаграммы может быть представлен объектом [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/). Этот пример находит такую диаграмму по типу заполнителя и интерфейсу во время выполнения, меняет её заголовок и сохраняет файл:

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

Обычный заполнитель контента обычно имеет тип [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/). В PowerPoint он служит запускателем нескольких типов содержимого, включая диаграммы, таблицы, схемы, изображения и медиа. После заполнения изучайте фактический интерфейс фигуры, чтобы понять, что она содержит. Специализированные макеты могут также раскрывать типы [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), или [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/).

Aspose.Slides не преобразует пустой заполнитель [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) в [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) простым изменением [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/); тип доступен только для чтения. Чтобы программно заполнить пустую диаграмму или область контента, добавьте требуемый объект в координаты заполнителя, а затем удалите пустой заполнитель. Следующий пример делает это для диаграммы:

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

Добавленная диаграмма — это обычная локальная диаграмма. Она занимает область заполнителя, но не наследует от заполнителя макета. Используйте специализированные [chart management articles](/slides/ru/cpp/powerpoint-charts/) при необходимости заменить её категории, серии или данные рабочей книги.

## **Полный пример: обновление текстового или графического содержимого**

Следующий сквозной пример открывает шаблон, ищет на первом слайде заполнитель заголовка или изображения, проверяет типы заполнителя и фигуры, обновляет соответствующее содержимое и сохраняет результат. Пример преднамеренно избегает предположений о индексе фигуры или приведения каждого заполнителя к одному интерфейсу.

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

## **FAQ**

**Что такое базовый заполнитель?**

Базовый заполнитель — это соответствующая фигура в шаблоне‑шаблоне или маске, от которой другой заполнитель наследует параметры. Используйте [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) для его получения. Обычная локальная фигура возвращает `nullptr`, потому что она не является частью иерархии заполнителей.

**Можно ли изменить все заголовки слайдов, редактируя заполнитель шаблона‑шаблона?**

Вы можете изменить унаследованное форматирование или текст подсказки через шаблон‑шаблон, но фактическое содержимое заголовков хранится на обычных слайдах. Чтобы заменить реальный текст заголовков во всей презентации, пройдитесь по слайдам и обновите каждый заполнитель заголовка.

**Как управлять заполнителями даты, номера слайда, верхнего и нижнего колонтитулов?**

Используйте менеджеры верхних и нижних колонтитулов в соответствующей области слайда, шаблона‑шаблона, маски, заметок или раздаточного листа. См. [Manage Presentation Header and Footer](/slides/ru/cpp/presentation-header-and-footer/) для полных примеров.