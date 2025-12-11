---
title: Применить или изменить макеты слайдов в C++
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
- содержание с подписью
- изображение с подписью
- заголовок и вертикальный текст
- вертикальный заголовок и текст
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Управляйте и настраивайте макеты слайдов в Aspose.Slides для C++. Исследуйте типы макетов, контроль заполнителей и видимость нижних колонтитулов через примеры кода на C++."
---

## **Обзор**

Макет слайда определяет расположение заполнителей и форматирование содержимого на слайде. Он контролирует, какие заполнители доступны и где они находятся. Макеты слайдов помогают быстро и последовательно создавать презентации — независимо от того, создаёте ли вы что‑то простое или более сложное. Некоторые из самых распространённых макетов слайдов в PowerPoint включают:

**Макет титульного слайда** – Содержит два текстовых заполнителя: один для заголовка и один для подзаголовка.

**Макет «Заголовок и содержимое»** – Содержит меньший заполнитель заголовка вверху и более крупный ниже для основного содержимого (например, текста, маркеров, диаграмм, изображений и прочего).

**Макет «Пустой»** – Не содержит заполнителей, предоставляя полный контроль для разработки слайда с нуля.

Макеты слайдов являются частью шаблона слайда, который представляет собой слайд высшего уровня, определяющий стили макетов презентации. Вы можете получать доступ к макетам слайдов и изменять их через шаблон слайда — по типу, имени или уникальному идентификатору. Кроме того, можно редактировать конкретный макет слайда непосредственно в презентации.

Для работы с макетами слайдов в Aspose.Slides for Android вы можете использовать:

- Методы, такие как [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) и [get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) в классе [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 
- Типы, такие как [ILayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/), и [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Чтобы узнать больше о работе с шаблонами слайдов, ознакомьтесь со статьёй [Slide Master](/slides/ru/cpp/slide-master/).
{{% /alert %}}

## **Добавить макеты слайдов в презентации**

Чтобы настроить внешний вид и структуру ваших слайдов, возможно, понадобится добавить новые макеты слайдов в презентацию. Aspose.Slides for Android позволяет проверить, существует ли уже определённый макет, при необходимости добавить новый и использовать его для вставки слайдов на основе этого макета.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите доступ к [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Проверьте, существует ли нужный макет слайда в коллекции. Если нет, добавьте требуемый макет слайда.
1. Добавьте пустой слайд на основе нового макета слайда.
1. Сохраните презентацию.

Следующий код на C++ демонстрирует, как добавить макет слайда в презентацию PowerPoint:
```cpp
// Создать экземпляр класса Presentation, представляющего файл PowerPoint.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Перебрать типы макетов слайдов для выбора макета слайда.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // Ситуация, когда презентация не содержит всех типов макетов.
    // Файл презентации содержит только типы макетов Blank и Custom.
    // Однако макеты слайдов с пользовательскими типами могут иметь узнаваемые имена,
    // например "Title", "Title and Content" и т.д., которые можно использовать для выбора макета слайда.
    // Вы также можете опираться на набор типов заполнителей фигур.
    // Например, слайд Title должен иметь только тип заполнителя Title и т.д.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Добавить пустой слайд, используя добавленный макет слайда.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Сохранить презентацию на диск.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Удалить неиспользуемые макеты слайдов**

Aspose.Slides предоставляет метод [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) из класса [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/), позволяющий удалять нежелательные и неиспользуемые макеты слайдов.

Следующий код на C++ показывает, как удалить макет слайда из презентации PowerPoint:
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Добавить заполнители в макет слайда**

Aspose.Slides предоставляет метод [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/), позволяющий добавлять новые заполнители в макет слайда.

Этот менеджер содержит методы для следующих типов заполнителей:

| Заполнитель PowerPoint | Метод [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/) |
| ---------------------- | ------------------------------------------------------------ |
| ![Содержание](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Содержание (вертикальное)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Текст](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Текст (вертикальный)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Изображение](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Диаграмма](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Таблица](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Медиа](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Онлайн‑изображение](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Следующий код на C++ демонстрирует, как добавить новые фигуры‑заполнители в макет «Пустой» слайда:
```cpp
auto presentation = MakeObject<Presentation>();

// Получить пустой макет слайда.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Получить менеджер заполнителей макетного слайда.
auto placeholderManager = layout->get_PlaceholderManager();

// Добавить разные заполнители к пустому макету слайда.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Добавить новый слайд с пустым макетом.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Результат:

![Заполнители на макете слайда](add_placeholders.png)

## **Установить видимость нижнего колонтитула для макета слайда**

В презентациях PowerPoint элементы нижнего колонтитула, такие как дата, номер слайда и пользовательский текст, могут отображаться или скрываться в зависимости от макета слайда. Aspose.Slides for Android позволяет управлять видимостью этих заполнителей нижнего колонтитула. Это полезно, когда вы хотите, чтобы определённые макеты отображали информацию нижнего колонтитула, а другие оставались чистыми и минимальными.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите ссылку на макет слайда по его индексу.
1. Установите видимость заполнителя нижнего колонтитула слайда.
1. Установите видимость заполнителя номера слайда.
1. Установите видимость заполнителя даты и времени.
1. Сохраните презентацию.

Следующий код на C++ показывает, как установить видимость нижнего колонтитула слайда и выполнить связанные задачи:
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```


## **Установить видимость нижнего колонтитула у дочерних макетов слайда**

​В презентациях PowerPoint элементы нижнего колонтитула, такие как дата, номер слайда и пользовательский текст, можно контролировать на уровне шаблона слайда, чтобы обеспечить согласованность во всех макетах слайдов. Aspose.Slides for Android позволяет установить видимость и содержимое этих заполнителей нижнего колонтитула на шаблоне слайда и распространить эти настройки на все дочерние макеты слайдов. Такой подход обеспечивает единообразную информацию нижнего колонтитула во всей презентации.​

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите ссылку на шаблон слайда по его индексу.
1. Установите видимость заполнителей нижнего колонтитула шаблона и всех дочерних макетов.
1. Установите видимость заполнителей номеров слайдов шаблона и всех дочерних макетов.
1. Установите видимость заполнителей даты и времени шаблона и всех дочерних макетов.
1. Сохраните презентацию.

Следующий код на C++ демонстрирует эту операцию:
```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **FAQ**

**В чём разница между шаблоном слайда и макетом слайда?**

Шаблон слайда определяет общую тему и форматирование по умолчанию, тогда как макеты слайдов задают конкретные расположения заполнителей для различных типов содержимого.

**Можно ли скопировать макет слайда из одной презентации в другую?**

Да, вы можете клонировать макет слайда из коллекции макетов слайдов одной презентации, доступной через метод [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/), и вставить его в другую презентацию с помощью метода `AddClone`.

**Что произойдёт, если удалить макет слайда, который всё ещё используется слайдом?**

Если попытаться удалить макет слайда, который всё ещё используется хотя бы одним слайдом в презентации, Aspose.Slides выбросит исключение [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/). Чтобы избежать этого, используйте [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/), который безопасно удаляет только неиспользуемые макеты слайдов.