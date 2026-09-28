---
title: Применение или изменение макетов слайдов в C++
linktitle: Макет слайда
type: docs
weight: 60
url: /ru/cpp/slide-layout/
keywords:
- макет слайда
- макет содержимого
- заполнитель
- дизайн презентации
- дизайн слайда
- неиспользуемый макет
- видимость нижнего колонтитула
- титульный слайд
- заголовок и содержимое
- заголовок раздела
- два содержимых
- сравнение
- только заголовок
- пустой макет
- содержимое с подписью
- изображение с подписью
- заголовок и вертикальный текст
- вертикальный заголовок и текст
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Применяйте, создавайте и изменяйте макеты слайдов в Aspose.Slides для C++, добавляйте заполнители, удаляйте неиспользуемые макеты и контролируйте видимость нижнего колонтитула."
---
## **Обзор**

Макет слайда определяет позиции и форматирование заполнителей, таких как заголовки, текст, изображения, диаграммы и таблицы. Применение макета обеспечивает согласованную структуру слайдов, позволяя каждому слайду содержать собственное содержимое.

Самые распространённые макеты включают:

- **Титульный слайд**: Содержит заполнители заголовка и подзаголовка.
- **Заголовок и содержание**: Содержит заполнитель заголовка и универсальный заполнитель содержимого.
- **Пустой**: Не содержит заполнителей содержимого и полезен, когда все объекты будут размещаться вручную.

## **Понимание наследования макетов**

Презентация имеет три связанных уровня:

1. [Главный слайд](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/) определяет тему, общее форматирование, фоны и общие объекты.
2. [Макетный слайд](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/) относится к главному слайду и определяет определённое расположение заполнителей.
3. [Обычный слайд](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/) использует один макет и хранит введённое для него содержимое.

Обычный слайд наследует тему и форматирование от своего макета, а макет наследует их от главного слайда. Значение, установленное непосредственно на обычном слайде, переопределяет унаследованное значение на этом уровне. При создании обычного слайда его формы‑заполнители генерируются из выбранного макета, тогда как содержимое, введённое в эти заполнители, принадлежит обычному слайду.

Добавьте необходимые заполнители в макет перед созданием из него слайдов. Добавление другого заполнителя в макет позже не добавляет автоматически соответствующую форму‑заполнитель в существующие обычные слайды.

Эти отношения имеют две важные последствия:

- Изменение унаследованного форматирования или существующей геометрии заполнителей в макете может обновить каждый слайд, зависящий от него. Перед редактированием уже используемого макета проверьте его зависимые слайды и пересмотрите получившуюся презентацию.
- Макет, который используется хотя бы одним слайдом, нельзя удалить. Сначала переназначьте его зависимые слайды на другой макет либо удалите только неиспользуемые макеты.

Для получения дополнительной информации о верхнем уровне этой иерархии см. [Главный слайд](/slides/ru/cpp/slide-master/).

Чтобы скрыть унаследованные логотипы или декоративные объекты главного слайда на отдельном слайде или через общий макет, см. [Управление видимостью графики главного слайда](/slides/ru/cpp/slide-master/). Пример сравнивает два слайда, использующих один и тот же главный слайд.

## **Выбор и применение макета слайда**

Используйте тип макета, когда презентация следует стандартным определениям макетов PowerPoint. Имена макетов могут редактироваться пользователем и локализоваться, поэтому выбор по имени менее надёжен, если вы не контролируете исходный шаблон.

В следующем примере ищется **Заголовок и содержание** на первом главном слайде. Если этот макет недоступен, он намеренно переходит к **Пустому**. Второй проверка на null необходима, потому что презентация может содержать только пользовательские макеты. Затем выбранный макет применяется к первому обычному слайду с помощью метода [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/set_layoutslide/).

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

Изменение макета слайда не удаляет обычные формы, добавленные непосредственно к слайду. Однако позиции заполнителей, унаследованное форматирование и соответствие между существующими заполнителями и новым макетом могут измениться, поэтому проверяйте результат при переключении между существенно различными макетами.

## **Добавление макетного слайда**

Выбор и создание – отдельные операции. Предыдущий пример выбирает существующий макет; он не создаёт его. Чтобы создать макет, вызовите метод [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterlayoutslidecollection/add/) у коллекции макетов целевого главного слайда.

В следующем примере всегда добавляется новый макет **Заголовок и содержание** с именем `Report Title and Content`, затем добавляется обычный слайд, основанный на нём. Имена макетов должны быть уникальными в коллекции.

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

Добавляйте макет только тогда, когда шаблон действительно нуждается в другой переиспользуемой структуре. Если подходящий макет уже существует, выберите и используйте его повторно вместо создания дубликата.

## **Добавление заполнителей в макетный слайд**

Метод [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) предоставляет [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/) для добавления форм‑заполнителей в макет.

| Заполнитель PowerPoint              | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Содержание](content.png)          | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Содержание (вертикальное)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Текст](text.png)                 | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Текст (вертикальный)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Изображение](picture.png)        | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Диаграмма](chart.png)            | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Таблица](table.png)              | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)          | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Медиа](media.png)                | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Онлайн‑изображение](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

В следующем примере проверяется существование макета **Пустой**, в него добавляются четыре заполнителя, после чего создаётся обычный слайд, использующий изменённый макет. Порядок намеренный: заполнители добавляются до создания обычного слайда, чтобы Aspose.Slides мог генерировать соответствующие формы‑заполнители на этом слайде.

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

![Заполнители на макетном слайде](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Изменение унаследованного форматирования или геометрии существующих заполнителей макета может повлиять на зависимые слайды. Новый добавленный заполнитель макета не заполняет автоматически существующие обычные слайды. Тестируйте изменения макета на копии презентации и проверяйте каждый зависимый слайд.
{{% /alert %}}

## **Удаление неиспользуемых макетных слайдов**

Используйте метод [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/), чтобы удалить макеты, на которые не ссылаются обычные слайды. Метод оставляет неизменными макеты, которые всё ещё используются.

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

Чтобы удалить конкретный макет, сначала используйте его метод [get_HasDependingSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) или метод [GetDependingSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/getdependingslides/). Переназначьте все зависимые слайды перед вызовом [ILayoutSlide::Remove](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/remove/). Попытка удалить используемый макет вызывает исключение [PptxEditException](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pptxeditexception/).

## **Управление видимостью нижнего колонтитула на макетном слайде**

У макета есть собственные заполнители нижнего колонтитула, номера слайда и даты‑времени. Используйте метод [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) для управления этими заполнителями в одном макете. Это полезно, когда, например, макеты содержания должны показывать нижний колонтитул, а титульные – нет.

В следующем примере безопасно выбирается макет и делаются видимыми его элементы нижнего колонтитула:

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

## **Управление видимостью нижнего колонтитула в главном слайде и его дочерних макетах**

Чтобы применить единые настройки нижнего колонтитула по всей иерархии главного слайда, используйте метод [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/get_headerfootermanager/). Методы распространения [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslideheaderfootermanager/) работают с главным слайдом, его зависимыми макетными слайдами и обычными слайдами; они не направлены только на один обычный слайд.

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

**В чём разница между главным слайдом и макетным слайдом?**

Главный слайд определяет тему презентации и общее форматирование. Макетный слайд относится к главному и задаёт одну переиспользуемую раскладку заполнителей. Обычные слайды используют эти макеты и хранят специфическое для слайда содержимое.

**Можно ли скопировать макетный слайд из одной презентации в другую?**

Да. Добавьте копию в целевую коллекцию с помощью метода [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/igloballayoutslidecollection/addclone/). При копировании между презентациями также проверяйте шрифты, темы, изображения и другие ресурсы, использованные в исходном макете.

**Что происходит, если я изменяю макет, который уже используется?**

Зависимые слайды наследуют изменения макета, если только они не переопределили затронутое форматирование или объекты локально. Поэтому геометрия заполнителей и унаследованные стили могут измениться сразу на многих слайдах. Используйте [GetDependingSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslide/getdependingslides/), чтобы определить затронутые слайды перед редактированием макета.

**Что происходит, если я удаляю макет, который всё ещё используется?**

Aspose.Slides выдаёт исключение [PptxEditException](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pptxeditexception/). Сначала переназначьте зависимые слайды или используйте [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/), чтобы удалить только неиспользуемые макеты.