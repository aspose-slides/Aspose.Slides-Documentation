---
title: Применить или изменить макет слайда в C#
linktitle: Макет слайда
type: docs
weight: 60
url: /ru/net/slide-layout/
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
- два содержимого
- сравнение
- только заголовок
- пустой макет
- содержимое с подписью
- изображение с подписью
- заголовок и вертикальный текст
- вертикальный заголовок и текст
- C#
- .NET
- Aspose.Slides
description: "Узнайте, как управлять и настраивать макеты слайдов в Aspose.Slides для .NET. Исследуйте типы макетов, управление заполнителями, видимость нижнего колонтитула и манипуляцию макетами с помощью примеров кода на C#."
---

## **Обзор**

Макет слайда определяет расположение рамок заполнителей и форматирование содержимого на слайде. Он контролирует, какие заполнители доступны и где они располагаются. Макеты слайдов помогают быстро и последовательно создавать презентации — независимо от того, создаёте ли вы простой или более сложный материал. Некоторые из самых распространённых макетов слайдов в PowerPoint включают:

**Макет титульного слайда** – Содержит два текстовых заполнителя: один для заголовка и один для подзаголовка.

**Макет «Заголовок и содержимое»** – Содержит меньший заполнитель заголовка вверху и более крупный ниже для основного содержимого (текст, маркеры, диаграммы, изображения и т.д.).

**Пустой макет** – Не содержит заполнителей, предоставляя полный контроль над созданием слайда с нуля.

Макеты слайдов являются частью шаблона слайда, который представляет собой верхний уровень слайда, определяющий стили макетов для презентации. Вы можете получить доступ к макетам слайдов и изменять их через шаблон слайда — по типу, имени или уникальному идентификатору. Кроме того, можно редактировать конкретный макет слайда непосредственно в презентации.

Для работы с макетами слайдов в Aspose.Slides для .NET вы можете использовать:
- Свойства, такие как [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) и [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) в классе [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
- Типы, такие как [ILayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/), и [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Чтобы узнать больше о работе с шаблонами слайдов, ознакомьтесь со статьёй [Slide Master](/slides/ru/net/slide-master/).
{{% /alert %}}

## **Добавление макетов слайдов в презентации**

Чтобы настроить внешний вид и структуру слайдов, возможно, потребуется добавить новые макеты слайдов в презентацию. Aspose.Slides для .NET позволяет проверить, существует ли конкретный макет, при необходимости добавить новый и использовать его для вставки слайдов на основе этого макета.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Получите доступ к [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/) .
3. Проверьте, существует ли требуемый макет слайда в коллекции. Если нет, добавьте нужный макет слайда.
4. Добавьте пустой слайд на основе нового макета слайда.
5. Сохраните презентацию.

Следующий код C# демонстрирует, как добавить макет слайда в презентацию PowerPoint:
```cs
// Создайте экземпляр класса Presentation, представляющего файл PowerPoint.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Пройдитесь по типам макетов слайдов, чтобы выбрать макет слайда.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Ситуация, когда презентация не содержит все типы макетов.
        // Файл презентации содержит только типы макетов Blank и Custom.
        // Однако макеты слайдов с пользовательскими типами могут иметь узнаваемые имена,
        // такие как "Title", "Title and Content", etc., которые можно использовать для выбора макета слайда.
        // Вы также можете полагаться на набор типов фигур-заполнителей.
        // Например, слайд Title должен содержать только тип заполнителя Title, и т.д.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Добавьте пустой слайд, используя добавленный макет слайда.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Сохраните презентацию на диск.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```



## **Удаление неиспользуемых макетов слайдов**

Aspose.Slides предоставляет метод [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) из класса [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) , позволяющий удалять нежелательные и неиспользуемые макеты слайдов.

Следующий код C# показывает, как удалить макет слайда из презентации PowerPoint:
```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **Добавление заполнителей в макеты слайдов**

Aspose.Slides предоставляет свойство [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/placeholdermanager/) , которое позволяет добавлять новые заполнители в макет слайда.

Этот менеджер содержит методы для следующих типов заполнителей:

| Заполнитель PowerPoint              | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/) Method |
| ----------------------------------- | ------------------------------------------------------------ |
| Содержимое                          | AddContentPlaceholder(float x, float y, float width, float height) |
| Содержимое (Вертикальное)           | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| Текст                               | AddTextPlaceholder(float x, float y, float width, float height) |
| Текст (Вертикальный)                | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| Изображение                         | AddPicturePlaceholder(float x, float y, float width, float height) |
| Диаграмма                           | AddChartPlaceholder(float x, float y, float width, float height) |
| Таблица                             | AddTablePlaceholder(float x, float y, float width, float height) |
| SmartArt                            | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| Медиа                               | AddMediaPlaceholder(float x, float y, float width, float height) |
| Онлайн‑изображение                  | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

Следующий код C# демонстрирует, как добавить новые формы‑заполнители к пустому макету слайда:
```cs
using (var presentation = new Presentation())
{
    // Получить пустой макет слайда.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Получить менеджер заполнителей макета слайда.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Добавить различные заполнители к пустому макету слайда.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Добавить новый слайд с пустым макетом.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```


Результат:

![Заполнители на макете слайда](add_placeholders.png)

## **Установка видимости нижнего колонтитула для макета слайда**

В презентациях PowerPoint элементы нижнего колонтитула, такие как дата, номер слайда и пользовательский текст, могут отображаться или скрываться в зависимости от макета слайда. Aspose.Slides для .NET позволяет управлять видимостью этих заполнителей нижнего колонтитула. Это полезно, когда нужно, чтобы некоторые макеты показывали информацию нижнего колонтитула, а остальные оставались чистыми и минимальными.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Получите ссылку на макет слайда по его индексу.
3. Установите видимость заполнителя нижнего колонтитула слайда.
4. Установите видимость заполнителя номера слайда.
5. Установите видимость заполнителя даты и времени.
Сохраните презентацию.

Следующий код C# показывает, как установить видимость нижнего колонтитула слайда и выполнить связанные задачи:
```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```


## **Установка видимости нижнего колонтитула у дочерних слайдов**

В презентациях PowerPoint элементы нижнего колонтитула, такие как дата, номер слайда и пользовательский текст, могут контролироваться на уровне шаблона слайда, чтобы обеспечить согласованность во всех макетах слайдов. Aspose.Slides для .NET позволяет задать видимость и содержание этих заполнителей нижнего колонтитула на шаблоне слайда и распространить эти настройки на все дочерние макеты слайдов. Такой подход обеспечивает единообразную информацию нижнего колонтитула по всей презентации.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Получите ссылку на шаблон слайда по его индексу.
3. Установите видимость заполнителей нижнего колонтитула шаблона и всех дочерних макетов.
4. Установите видимость заполнителей номеров слайдов шаблона и всех дочерних макетов.
5. Установите видимость заполнителей даты и времени шаблона и всех дочерних макетов.
6. Сохраните презентацию.

Следующий код C# демонстрирует эту операцию:
```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**В чём разница между шаблоном слайда и макетом слайда?**

Шаблон слайда определяет общую тему и форматирование по умолчанию, тогда как макеты слайдов задают конкретные расположения заполнителей для различных типов содержимого.

**Могу ли я скопировать макет слайда из одной презентации в другую?**

Да, вы можете клонировать макет слайда из коллекции [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) одной презентации и вставить его в другую с помощью метода `AddClone`.

**Что происходит, если я удалю макет слайда, который всё ещё используется другим слайдом?**

Если попытаться удалить макет слайда, который всё ещё присутствует в качестве ссылки у хотя бы одного слайда презентации, Aspose.Slides выдаст исключение [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception/). Чтобы избежать этого, используйте [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/)…, которое безопасно удаляет только неиспользуемые макеты слайдов.