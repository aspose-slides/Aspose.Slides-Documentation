---
title: Управление заголовками и нижними колонтитулами презентаций в .NET
linktitle: Заголовок и нижний колонтитул
type: docs
weight: 140
url: /ru/net/presentation-header-and-footer/
keywords:
- заголовок
- текст заголовка
- нижний колонтитул
- текст нижнего колонтитула
- установить заголовок
- установить нижний колонтитул
- раздаточный материал
- заметки
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как управлять заполнителями нижнего колонтитула, даты и времени, номера слайда и заголовка на слайдах, страницах заметок и раздаточных материалах с помощью Aspose.Slides для .NET."
---
## **Обзор**

PowerPoint использует различные заполнительные поля заголовка и нижнего колонтитула в зависимости от типа страницы. Aspose.Slides for .NET позволяет управлять текстом и видимостью этих заполнителей через интерфейсы менеджеров заголовков/нижних колонтитулов.

Доступные заполнители зависят от области:

| Область | Заголовок | Нижний колонтитул | Дата/время | Номер слайда/страницы |
|---|---|---|---|---|
| Обычный слайд | Нет | Да | Да | Да |
| Мастер заметок | Да | Да | Да | Да |
| Слайд заметок | Да | Да | Да | Да |
| Мастер раздаточных материалов | Да | Да | Да | Да |

Обычный слайд презентации не имеет заполнителя заголовка. Заголовки доступны на страницах заметок и раздаточных материалов. Для обычных слайдов используйте заполнители нижнего колонтитула, даты/времени и номера слайда.

Область изменения зависит от используемого менеджера. Интерфейс [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/net/aspose.slides/islideheaderfootermanager/) управляет одним обычным слайдом. Интерфейс [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/net/aspose.slides/inotesslideheaderfootermanager/) управляет одним слайдом заметок. Менеджеры мастеров и макетов могут также распространять настройки на зависимые слайды, тогда как интерфейс [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterhandoutslideheaderfootermanager/) управляет мастером раздаточных материалов.

## **Установить нижний колонтитул, дату/время и номера слайдов на обычных слайдах**

Для обычных слайдов базовый порядок действий — получить менеджер заголовков/нижних колонтитулов каждого слайда, задать текст нижнего колонтитула и даты/времени, включить требуемые заполнители и сохранить презентацию. Номера слайдов генерируются презентацией, поэтому нужно только управлять их видимостью.

Используйте [`SetFooterText`](https://reference.aspose.com/slides/ru/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) и [`SetDateTimeText`](https://reference.aspose.com/slides/ru/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) для задания текста, а также [`SetFooterVisibility`](https://reference.aspose.com/slides/ru/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/ru/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) и [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/ru/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) для отображения соответствующих заполнителей.

Следующий сквозной пример применяет одинаковый нижний колонтитул, текст даты/времени и видимость номера слайда ко всем обычным слайдам:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

Если необходимо обновить только один слайд, обратитесь к этому слайду напрямую через коллекцию [`Slides`](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/slides/ru/) вместо перебора всей коллекции.

## **Установить заголовки и нижние колонтитулы в мастере заметок**

Мастер заметок задает общее форматирование и поведение заполнителей для страниц заметок. Используйте интерфейс [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/net/aspose.slides/imasternotesslideheaderfootermanager/) когда нужно изменить только сам мастер заметок.

Следующий пример задает заголовок, нижний колонтитул и текст даты/времени в мастере заметок и делает все поддерживаемые заполнители видимыми в этом мастере:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

Свойство [`MasterNotesSlide`](https://reference.aspose.com/slides/ru/net/aspose.slides/imasternotesslidemanager/masternotesslide/) возвращает `null`, когда презентация не содержит мастер заметок.

## **Применить настройки мастера заметок к дочерним слайдам заметок**

Мастер заметок может применять настройки заголовка и нижнего колонтитула к себе и ко всем зависимым слайдам заметок. Используйте специальные методы распространения в [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/net/aspose.slides/imasternotesslideheaderfootermanager/) когда одинаковые настройки должны применяться по всей иерархии заметок.

Например, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ru/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) и [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ru/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) обновляют заголовок мастера заметок и всех дочерних заголовков. Аналогичные методы доступны для нижних колонтитулов, даты/времени и номеров слайдов.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

Методы распространения, использованные выше, это [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/ru/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ru/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ru/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ru/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), и [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ru/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Установить заголовки и нижние колонтитулы на отдельном слайде заметок**

Слайд заметок принадлежит конкретному обычному слайду. Используйте его интерфейс [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/net/aspose.slides/inotesslideheaderfootermanager/) когда нужно настроить только эту страницу заметок.

Метод [`AddNotesSlide`](https://reference.aspose.com/slides/ru/net/aspose.slides/inotesslidemanager/addnotesslide/) возвращает слайд заметок для текущего слайда и создает его, если он еще не существует. Следующий пример настраивает страницу заметок, связанную с первым слайдом презентации:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

Если сначала распространить настройки из мастера заметок, а затем изменить отдельный слайд заметок, позднее локальное изменение позволяет настроить эту страницу независимо.

## **Установить заголовки и нижние колонтитулы в мастере раздаточных материалов**

Страницы раздаточных материалов используют мастер раздаточных материалов для своих заполнителей заголовка, нижнего колонтитула, даты/времени и номера страницы. В отличие от страниц заметок, настройки раздаточных материалов управляются через мастер, а не через отдельные слайды раздаточных материалов.

Используйте свойство [`MasterHandoutSlide`](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) для доступа к мастеру раздаточных материалов. Если он отсутствует, вызовите [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) для создания мастера по умолчанию.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Понимание области и наследования**

Выберите менеджер заголовков/нижних колонтитулов, соответствующий области, которую нужно изменить:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/net/aspose.slides/islideheaderfootermanager/) изменяет настройки нижнего колонтитула, даты/времени и номера слайда для одного обычного слайда.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslideheaderfootermanager/) управляет макетом слайда и может распространять поддерживаемые настройки на зависимые слайды.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslideheaderfootermanager/) управляет обычным мастером слайдов и может распространять поддерживаемые настройки на зависимые слайды.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/net/aspose.slides/imasternotesslideheaderfootermanager/) управляет мастером заметок и может распространять настройки на все зависимые слайды заметок.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/net/aspose.slides/inotesslideheaderfootermanager/) изменяет один слайд заметок и поддерживает заполнители заголовка, кроме нижнего колонтитула, даты/времени и номера слайда.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterhandoutslideheaderfootermanager/) изменяет мастер раздаточных материалов и поддерживает все четыре типа заполнителей.

Используйте распространение из мастера или макета, когда одно и то же значение должно применяться ко всей иерархии. Используйте менеджер отдельного слайда или слайда заметок, когда требуется локальная настройка для одной страницы.

## **FAQ**

**Можно ли добавить заголовок к обычному слайду?**

Нет. PowerPoint не определяет заполнитель заголовка для обычных слайдов. На обычных слайдах используйте заполнители нижнего колонтитула, даты/времени и номера слайда. Заполнители заголовков доступны на страницах заметок и раздаточных материалов.

**Что делать, если заполнитель нижнего колонтитула, даты/времени или номера слайда не виден?**

Используйте соответствующий менеджер заголовков/нижних колонтитулов, чтобы проверить его видимость и включить при необходимости. Например, [`IsFooterVisible`](https://reference.aspose.com/slides/ru/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) сообщает, присутствует ли заполнитель нижнего колонтитула, а [`SetFooterVisibility`](https://reference.aspose.com/slides/ru/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) изменяет его видимость.

**Как задать нумерацию слайдов, начиная с числа, отличного от 1?**

Установите свойство презентации [`FirstSlideNumber`](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/firstslidenumber/). Затем заполнители номеров слайдов используют обновлённую последовательность нумерации.

**Что происходит с заголовками и нижними колонтитулами при экспорте в PDF, изображения или HTML?**

Видимые элементы заголовков и нижних колонтитулов рендерятся вместе с остальным содержимым презентации в выходном формате. Их отображение зависит от типа экспортируемой страницы и соответствующих настроек видимости заполнителей.