---
title: Макет слайдов
type: docs
weight: 60
url: /ru/net/slide-layout/
keyword: "Установить размер слайда, установить параметры слайда, указать размер слайда, Видимость нижнего колонтитула, Нижний колонтитул для дочернего слайда, Масштабирование содержимого, размер страницы, C#, Csharp, .NET, Aspose.Slides"
description: "Установите размер и параметры слайда PowerPoint на C# или .NET"
---

Макет слайда содержит заполнители и информацию о форматировании для всего содержимого, которое появляется на слайде. Макет определяет доступные заполнители содержимого и их расположение.

Макеты слайдов позволяют быстро создавать и разрабатывать презентации (будь то простые или сложные). Вот некоторые из самых популярных макетов слайдов, используемых в презентациях PowerPoint:

* **Макет титульного слайда**. Этот макет состоит из двух текстовых заполнителей. Один заполнитель предназначен для заголовка, а другой — для подзаголовка.
* **Макет заголовка и содержимого**. Этот макет содержит относительно небольшой заполнитель вверху для заголовка и больший заполнитель для основного содержимого (график, абзацы, маркированный список, нумерованный список, изображения и т. д.).
* **Пустой макет**. Этот макет не содержит заполнителей, поэтому позволяет создавать элементы с нуля.

Поскольку мастер-слайд является верхним по иерархии слайдом, который хранит информацию о макетах слайдов, вы можете использовать мастер-слайд для доступа к макетам слайдов и внесения изменений в них. К макету слайда можно получить доступ по типу или имени. Аналогично, каждый слайд имеет уникальный идентификатор, который можно использовать для доступа к нему.

В качестве альтернативы вы можете вносить изменения непосредственно в конкретный макет слайда в презентации.

* Чтобы работать с макетами слайдов (включая те, что находятся на мастер-слайдах), Aspose.Slides предоставляет такие свойства, как [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) и [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) в классе [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
* Для выполнения связанных задач Aspose.Slides предоставляет [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/) и многие другие типы.

{{% alert title="Информация" color="info" %}}

Для получения дополнительной информации о работе с мастер-слайдами, смотрите статью [Slide Master](https://docs.aspose.com/slides/net/slide-master/).

{{% /alert %}}

## **Добавить макет слайда в презентацию**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите доступ к коллекции [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/).
1. Просмотрите существующие макеты слайдов, чтобы подтвердить, что необходимый макет слайда уже существует в коллекции макетов слайдов. Если нет, добавьте нужный макет слайда.
1. Добавьте пустой слайд на основе нового макета слайда.
1. Сохраните презентацию.

Этот код C# показывает, как добавить макет слайда в презентацию PowerPoint:

```c#
// Создает экземпляр класса Presentation, представляющий файл презентации
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Проходит по типам макетов слайдов
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Ситуация, когда презентация не содержит некоторые типы макетов.
        // Файл презентации содержит только пустые и пользовательские типы макетов.
        // Но макеты слайдов с пользовательскими типами имеют разные имена слайдов,
        // такие как "Title", "Title and Content" и т. д. И можно использовать эти
        // имена для выбора макета слайда.
        // Вы также можете использовать набор типов форм заполнителей. Например,
        // титульный слайд должен иметь только тип заполнителя заголовка и т. д.
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

    // Добавляет пустой слайд с добавленным макетом
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Сохраняет презентацию на диск
    presentation.Save("AddLayoutSlides_out.pptx", SaveFormat.Pptx);
}
```

## **Удалить неиспользуемый макет слайда**

Aspose.Slides предоставляет метод [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) из класса [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), чтобы позволить вам удалить нежелательные и неиспользуемые макеты слайдов. Этот код C# показывает, как удалить макет слайда из презентации PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Установить размер и тип для макета слайда**

Чтобы позволить вам установить размер и тип для конкретного макета слайда, Aspose.Slides предоставляет свойства [Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/type) и [Size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/size) (из класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)). Этот C# демонстрирует операцию:

```c#
// Создает экземпляр объекта Presentation, представляющего файл презентации
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Устанавливает размер слайда для созданной презентации на размер источника
auxPresentation.SlideSize.SetSize(presentation.SlideSize.Type, SlideSizeScaleType.EnsureFit);

auxPresentation.Slides.InsertClone(0, slide);
auxPresentation.Slides.RemoveAt(0);
// Сохраняет презентацию на диск
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **Установить видимость нижнего колонтитула внутри слайда**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд через его индекс.
1. Установите видимость заполнителя нижнего колонтитула слайда.
1. Установите видимость заполнителя даты и времени.
1. Сохраните презентацию.

Этот код C# показывает, как установить видимость нижнего колонтитула слайда (и выполнить связанные задачи):

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.Slides[0].HeaderFooterManager;
    if (!headerFooterManager.IsFooterVisible) // Свойство IsFooterVisible используется для указания на отсутствие заполнителя нижнего колонтитула слайда
    {
        headerFooterManager.SetFooterVisibility(true); // Метод SetFooterVisibility используется для установки видимости заполнителя нижнего колонтитула слайда
    }
    if (!headerFooterManager.IsSlideNumberVisible) // Свойство IsSlideNumberVisible используется для указания на отсутствие заполнителя номера страницы слайда
    {
        headerFooterManager.SetSlideNumberVisibility(true); // Метод SetSlideNumberVisibility используется для установки видимости заполнителя номера страницы слайда
    }
    if (!headerFooterManager.IsDateTimeVisible) // Свойство IsDateTimeVisible используется для указания на отсутствие заполнителя даты и времени слайда
    {
        headerFooterManager.SetDateTimeVisibility(true); // Метод SetFooterVisibility используется для установки видимости заполнителя даты и времени слайда
    }
    headerFooterManager.SetFooterText("Текст нижнего колонтитула"); // Метод SetFooterText используется для установки текста для заполнителя нижнего колонтитула слайда
    headerFooterManager.SetDateTimeText("Текст даты и времени"); // Метод SetDateTimeText используется для установки текста для заполнителя даты и времени слайда.

	presentation.Save("Presentation.ppt", SaveFormat.ppt);
}
```

## **Установить видимость нижнего колонтитула дочерних слайдов**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на мастер-слайд через его индекс.
1. Установите видимость мастер-слайда и всех заполнителей нижнего колонтитула дочерних слайдов.
1. Установите текст для мастер-слайда и всех заполнителей нижнего колонтитула дочерних слайдов.
1. Установите текст для мастер-слайда и всех заполнителей даты и времени дочерних слайдов.
1. Сохраните презентацию.

Этот код C# демонстрирует операцию:

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;
    headerFooterManager.SetFooterAndChildFootersVisibility(true); // Метод SetFooterAndChildFootersVisibility используется для установки видимости мастер-слайда и всех заполнителей нижнего колонтитула дочерних слайдов
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // Метод SetSlideNumberAndChildSlideNumbersVisibility используется для установки видимости мастер-слайда и всех заполнителей номеров страниц дочерних слайдов
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // Метод SetDateTimeAndChildDateTimesVisibility используется для установки видимости мастер-слайда и всех заполнителей даты и времени дочерних слайдов

    headerFooterManager.SetFooterAndChildFootersText("Текст нижнего колонтитула"); // Метод SetFooterAndChildFootersText используется для установки текстов для мастер-слайда и всех заполнителей нижнего колонтитула дочерних слайдов
    headerFooterManager.SetDateTimeAndChildDateTimesText("Текст даты и времени"); // Метод SetDateTimeAndChildDateTimesText используется для установки текста для мастер-слайда и всех заполнителей даты и времени дочерних слайдов
}
```

## **Установить размер слайда с учетом масштабирования содержимого**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) и загрузите презентацию, содержащую слайд, размер которого вы хотите установить.
1. Создайте еще один экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), чтобы создать новую презентацию.
1. Получите ссылку на слайд (из первой презентации) через его индекс.
1. Установите видимость заполнителя нижнего колонтитула слайда.
1. Установите видимость заполнителя даты и времени.
1. Сохраните презентацию.

Этот C# демонстрирует операцию:

```c#
// Создает экземпляр объекта Presentation, представляющего файл презентации
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Устанавливает размер слайда для созданных презентаций на размер источника
presentation.SlideSize.SetSize(540, 720, SlideSizeScaleType.EnsureFit); // Метод SetSize используется для установки размера слайда с масштабированием содержимого для обеспечения соответствия
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // Метод SetSize используется для установки размера слайда с максимальным размером содержимого

// Сохраняет презентацию на диск
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **Установить размер страницы при генерации PDF**

Некоторые презентации (например, постеры) часто конвертируются в PDF-документы. Если вы хотите конвертировать вашу PowerPoint-презентацию в PDF, чтобы получить лучшие параметры печати и доступности, вы хотите установить размеры слайдов, которые подходят для PDF-документов (например, A4).

Aspose.Slides предоставляет класс [SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/), чтобы позволить вам указать предпочитаемые настройки для слайдов. Этот код C# показывает, как использовать свойство [Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/type/) (из класса `SlideSize`), чтобы установить конкретный размер бумаги для слайдов в презентации:

```c#
// Создает экземпляр объекта Presentation, представляющего файл презентации
Presentation presentation = new Presentation();

// Устанавливает свойство SlideSize.Type 
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.EnsureFit);

// Устанавливает различные свойства для параметров PDF
PdfOptions opts = new PdfOptions();
opts.SufficientResolution = 600;

// Сохраняет презентацию на диск
presentation.Save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
```