---
title: Применение или изменение макетов слайдов в C++
linktitle: Макет слайда
type: docs
weight: 60
url: /ru/cpp/slide-layout/
keywords:
- макет слайда
- макет содержания
- заполнитель
- дизайн презентации
- дизайн слайда
- неиспользуемый макет
- видимость нижнего колонтитула
- титульный слайд
- заголовок и содержание
- заголовок раздела
- два содержания
- сравнение
- только заголовок
- пустой макет
- содержание с подписью
- изображение с подписью
- заголовок и вертикальный текст
- вертикальный заголовок и текст
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Применяйте, создавайте и изменяйте макеты слайдов в Aspose.Slides для C++, добавляйте заполнители, удаляйте неиспользуемые макеты и управляйте видимостью нижнего колонтитула."
---
## **Обзор**

Макет слайда определяет позиции и форматирование заполнителей, таких как заголовки, текст, изображения, диаграммы и таблицы. Применение макета обеспечивает слайдам единообразную структуру, позволяя каждому слайду содержать собственное содержимое.

- **Титульный слайд**: Содержит заполнители заголовка и подзаголовка.
- **Заголовок и содержание**: Содержит заполнитель заголовка и универсальный заполнитель содержания.
- **Пустой**: Не содержит заполнителей содержания и полезен, когда каждый объект будет размещён вручную.

## **Понимание наследования макетов**

Презентация имеет три взаимосвязанных уровня:

1. [главный слайд](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/) определяет тему, общие форматы, фоны и общие объекты.  
2. [макетный слайд](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/) принадлежит главному слайду и определяет конкретную раскладку заполнителей.  
3. [обычный слайд](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/) использует один макет и хранит введённое для этого слайда содержимое.  

Обычный слайд наследует тему и форматирование от своего макета, а макет наследует их от главного слайда. Значение, установленное непосредственно на обычном слайде, переопределяет унаследованное значение на этом уровне. При создании обычного слайда его формы‑заполнители генерируются из выбранного макета, тогда как содержимое, введённое в эти заполнители, относится к обычному слайду.

Добавьте необходимые заполнители в макет до создания слайдов на его основе. Добавление другого заполнителя в макет позже не приводит к автоматическому добавлению соответствующей формы‑заполнителя в уже существующие обычные слайды.

Эта связь имеет два важных последствия:

- Изменение унаследованного форматирования или геометрии существующего заполнителя в макете может обновить каждый слайд, зависящий от него. Перед редактированием уже используемого макета проверьте его зависимые слайды и просмотрите получившуюся презентацию.  
- Макет, который всё ещё используется слайдом, нельзя удалить. Сначала переназначьте его зависимые слайды на другой макет или удалите только неиспользуемые макеты.

Для получения дополнительной информации о верхнем уровне этой иерархии см. [Мастер‑слайд](/slides/ru/cpp/slide-master/).

## **Выбор и применение макета слайда**

Используйте тип макета, когда презентация следует стандартным определениям макетов PowerPoint. Имена макетов редактируемы пользователем и могут быть локализованы, поэтому выбор по имени менее надёжен, если вы не контролируете исходный шаблон.

Следующий пример ищет **Заголовок и содержание** на первом мастере. Если такой макет недоступен, он преднамеренно переходит к **Пустому**. Второй проверка на null необходима, потому что презентация может содержать только пользовательские макеты. Затем выбранный макет применяется к первому обычному слайду с помощью метода [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/set_layoutslide/).

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

Изменение макета слайда не удаляет обычные фигуры, добавленные напрямую на слайд. Однако позиции заполнителей, унаследованное форматирование и соответствие между существующими заполнителями и новым макетом могут измениться, поэтому проверяйте результат при переключении между существенно различными макетами.

## **Добавление макетного слайда**

Выбор и создание — отдельные операции. Предыдущий пример выбирает существующий макет; он не создаёт его. Чтобы создать макет, вызовите метод [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterlayoutslidecollection/add/) у коллекции макетов целевого мастера.

Следующий пример всегда добавляет новый макет **Заголовок и содержание** с именем `Report Title and Content`, затем добавляет обычный слайд на его основе. Имена макетов должны быть уникальными в пределах коллекции.

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

Добавляйте макет только тогда, когда шаблон действительно требует ещё одной переиспользуемой структуры. Если подходящий макет уже существует, выберите и используйте его повторно вместо создания дубликата.

## **Добавление заполнителей в макетный слайд**

Метод [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) предоставляет [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/) для добавления фигур‑заполнителей в макет.

| Заполнитель PowerPoint | `ILayoutPlaceholderManager` Method |
| ---------------------- | ---------------------------------- |
| ![Content](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

Следующий пример проверяет существование макета **Пустой**, добавляет к нему четыре заполнителя и затем создаёт обычный слайд, использующий изменённый макет. Порядок намеренен: заполнители добавляются до создания обычного слайда, чтобы Aspose.Slides мог сгенерировать соответствующие фигуры‑заполнители на этом слайде.

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

Результат:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Изменение унаследованного форматирования или геометрии существующих заполнителей макета может повлиять на зависимые слайды. Ново‑добавленный заполнитель макета не заполняется в уже существующие обычные слайды. Тестируйте изменения макета на копии презентации и проверяйте каждый зависимый слайд.
{{% /alert %}}

## **Удаление неиспользуемых макетных слайдов**

Используйте метод [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) для удаления макетов, на которые не ссылаются обычные слайды. Метод оставляет нетронутыми макеты, которые всё ещё используются.

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

Чтобы удалить один конкретный макет, сначала используйте его метод [get_HasDependingSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) или метод [GetDependingSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/getdependingslides/). Переназначьте любые зависимые слайды перед вызовом [ILayoutSlide::Remove](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/remove/). Попытка удалить используемый макет вызывает [PptxEditException](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pptxeditexception/).

## **Управление видимостью нижнего колонтитула на макетном слайде**

У макетного слайда есть свои заполнители нижнего колонтитула, номера слайда и даты‑времени. Используйте метод [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) для управления этими заполнителями в одном макете. Это полезно, например, когда макеты содержания должны показывать нижний колонтитул, а титульные — нет.

Следующий пример безопасно выбирает макет и делает его элементы нижнего колонтитула видимыми:

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

## **Управление видимостью нижнего колонтитула в мастере и его дочерних макетах**

Чтобы применить единые настройки нижнего колонтитула по всей иерархии мастера, используйте метод [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Методы распространения [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslideheaderfootermanager/) работают на мастере, его зависимых макетных слайдах и обычных слайдах; они не нацелены только на один обычный слайд.

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

## **FAQ**

**В чем разница между мастером‑слайда и макетным слайдом?**

Мастер‑слайд определяет тему презентации и общие форматы. Макетный слайд принадлежит мастеру и задаёт одну переиспользуемую раскладку заполнителей. Обычные слайды используют эти макеты и хранят содержание, специфичное для конкретного слайда.

**Можно ли скопировать макетный слайд из одной презентации в другую?**

Да. Добавьте копию в целевую коллекцию с помощью метода [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/igloballayoutslidecollection/addclone/). При копировании между презентациями также проверьте шрифты, темы, изображения и другие ресурсы, используемые исходным макетом.

**Что происходит, когда я изменяю уже используемый макет?**

Зависимые слайды наследуют изменения макета, если только они не переопределяют затронутое форматирование или объекты локально. Поэтому геометрия заполнителей и унаследованный стиль могут измениться сразу на многих слайдах. Используйте [GetDependingSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/getdependingslides/) для определения затронутых слайдов перед редактированием макета.

**Что происходит, если удалить макет, который всё ещё используется?**

Aspose.Slides генерирует [PptxEditException](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pptxeditexception/). Сначала переназначьте зависимые слайды или используйте [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) для удаления только неиспользуемых макетов.