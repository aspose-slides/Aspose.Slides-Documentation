---
title: Управление заголовками и нижними колонтитулами презентации в PHP
linktitle: Заголовок и нижний колонтитул
type: docs
weight: 140
url: /ru/php-java/presentation-header-and-footer/
keywords:
- заголовок
- текст заголовка
- нижний колонтитул
- текст нижнего колонтитула
- установить заголовок
- установить нижний колонтитул
- раздаточный лист
- заметки
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как управлять плейсхолдерами нижнего колонтитула, даты-времени, номера слайда и заголовка на слайдах, страницах заметок и раздаточных листах с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

PowerPoint использует разные плейсхолдеры заголовков и нижних колонтитулов в зависимости от типа слайда. Aspose.Slides for PHP via Java позволяет управлять текстом и видимостью этих плейсхолдеров с помощью классов менеджеров заголовков/нижних колонтитулов.

Доступные плейсхолдеры зависят от области:

| Область | Заголовок | Нижний колонтитул | Дата/время | Номер слайда/страницы |
|---|---|---|---|---|
| Обычный слайд | Нет | Да | Да | Да |
| Шаблон заметок | Да | Да | Да | Да |
| Слайд заметок | Да | Да | Да | Да |
| Шаблон раздаточного листа | Да | Да | Да | Да |

У обычного слайда презентации нет плейсхолдера заголовка. Заголовки доступны на страницах заметок и раздаточных листах. Для обычных слайдов вместо этого используйте плейсхолдеры нижнего колонтитула, даты/времени и номера слайда.

Область изменения зависит от используемого менеджера. Класс [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideheaderfootermanager/) управляет одним обычным слайдом. Класс [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notesslideheaderfootermanager/) управляет одним слайдом заметок. Менеджеры мастер‑ и макетных слайдов также могут распространять настройки на зависимые слайды, тогда как класс [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) управляет шаблоном раздаточного листа.

## **Установка нижнего колонтитула, даты/времени и номеров слайдов на обычных слайдах**

Для обычных слайдов базовый процесс состоит в доступе к менеджеру заголовков/нижних колонтитулов каждого слайда, установке текста нижнего колонтитула и даты/времени, включении необходимых плейсхолдеров и сохранении презентации. Номера слайдов генерируются презентацией, поэтому нужно лишь управлять их видимостью.

Используйте [`setFooterText`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) и [`setDateTimeText`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) для установки текста, а также [`setFooterVisibility`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) и [`setSlideNumberVisibility`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) для отображения соответствующих плейсхолдеров.

Следующий пример от начала до конца применяет одинаковый нижний колонтитул, текст даты/времени и видимость номера слайда ко всем обычным слайдам:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Если нужно обновить только один слайд, получите доступ к этому слайду напрямую через метод [`getSlides`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/getslides/), а не перебирая всю коллекцию.

## **Установка заголовков и нижних колонтитулов в мастере заметок**

Мастер заметок определяет общие параметры форматирования и поведение плейсхолдеров для страниц заметок. Используйте класс [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masternotesslideheaderfootermanager/), когда необходимо изменить только сам мастер заметок.

Следующий пример устанавливает заголовок, нижний колонтитул и текст даты/времени в мастере заметок и делает все поддерживаемые плейсхолдеры видимыми в этом мастере:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Метод [`getMasterNotesSlide`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) возвращает `null`, когда презентация не содержит мастер заметок.

## **Применение настроек мастера заметок к дочерним слайдам заметок**

Мастер заметок может применять настройки заголовка и нижнего колонтитула к себе и ко всем зависимым слайдам заметок. Используйте специальные методы распространения в [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masternotesslideheaderfootermanager/), когда одинаковые настройки должны применяться по всей иерархии заметок.

Например, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) и [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) обновляют заголовок мастера заметок и все дочерние заголовки. Эквивалентные методы доступны для нижних колонтитулов, даты/времени и номеров слайдов.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Методы распространения, использованные выше, – [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) и [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Установка заголовков и нижних колонтитулов на отдельном слайде заметок**

Слайд заметок относится к конкретному обычному слайду. Используйте его класс [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notesslideheaderfootermanager/), когда нужно настроить только эту страницу заметок.

Метод [`addNotesSlide`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notesslidemanager/addnotesslide/) возвращает слайд заметок для текущего слайда и создает его, если он еще не существует. Следующий пример настраивает страницу заметок, связанную с первым слайдом презентации:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Если сначала распространить настройки из мастера заметок, а затем изменить отдельный слайд заметок, последующие настройки для конкретного слайда позволяют независимо настраивать эту страницу заметок.

## **Установка заголовков и нижних колонтитулов в мастере раздаточного листа**

Страницы раздаточного листа используют мастер раздаточного листа для своих плейсхолдеров заголовка, нижнего колонтитула, даты/времени и номера страницы. В отличие от страниц заметок, настройки раздаточного листа управляются через мастер раздаточного листа, а не через отдельные слайды раздаточного листа.

Используйте метод [`getMasterHandoutSlide`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) для доступа к мастеру раздаточного листа. Если он отсутствует, вызовите [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) для создания мастер‑раздаточного листа по умолчанию.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Понимание области и наследования**

Выберите менеджер заголовков/нижних колонтитулов, соответствующий области, которую вы хотите изменить:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideheaderfootermanager/) изменяет настройки нижнего колонтитула, даты/времени и номера слайда для одного обычного слайда.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/layoutslideheaderfootermanager/) управляет макетным слайдом и может распространять поддерживаемые настройки на зависимые слайды.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterslideheaderfootermanager/) управляет мастером обычных слайдов и может распространять поддерживаемые настройки на зависимые слайды.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masternotesslideheaderfootermanager/) управляет мастером заметок и может распространять настройки на все зависимые слайды заметок.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/notesslideheaderfootermanager/) изменяет один слайд заметок и поддерживает плейсхолдер заголовка в дополнение к нижнему колонтитулу, дате/времени и номеру слайда.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) изменяет мастер раздаточного листа и поддерживает все четыре типа плейсхолдеров.

Используйте распространение из мастера или макета, когда одинаковая настройка должна применяться ко всей его иерархии. Используйте менеджер отдельного слайда или слайда заметок, когда требуется локальная настройка для одной страницы.

## **FAQ**

**Могу ли я добавить заголовок к обычному слайду?**

Нет. PowerPoint не определяет плейсхолдер заголовка для обычных слайдов. На обычных слайдах используйте плейсхолдеры нижнего колонтитула, даты/времени и номера слайда. Плейсхолдеры заголовков доступны на страницах заметок и раздаточных листах.

**Что делать, если плейсхолдер нижнего колонтитула, даты/времени или номера слайда не виден?**

Используйте соответствующий менеджер заголовков/нижних колонтитулов, чтобы проверить его видимость и включить при необходимости. Например, [`isFooterVisible`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) сообщает, присутствует ли плейсхолдер нижнего колонтитула, а [`setFooterVisibility`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) изменяет его видимость.

**Как начать нумерацию слайдов со значения, отличного от 1?**

Вызовите метод презентации [`setFirstSlideNumber`](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/setfirstslidenumber/). Плейсхолдеры номеров слайдов затем используют обновлённую нумерацию.

**Что происходит с заголовками и нижними колонтитулами при экспорте в PDF, изображения или HTML?**

Видимые элементы заголовка и нижнего колонтитула отображаются вместе с остальным содержимым презентации в выходном формате. Их внешний вид зависит от типа экспортируемой страницы и соответствующих настроек видимости плейсхолдеров.