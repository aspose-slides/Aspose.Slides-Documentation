---
title: Управление заголовками и нижними колонтитулами презентации в JavaScript
linktitle: Заголовок и нижний колонтитул
type: docs
weight: 140
url: /ru/nodejs-java/presentation-header-and-footer/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как управлять заполнителями нижнего колонтитула, даты-времени, номера слайда и заголовка на слайдах, страницах заметок и раздаточных листах с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

PowerPoint использует разные заполнители заголовков и нижних колонтитулов в зависимости от типа страницы. Aspose.Slides for Node.js via Java позволяет управлять текстом и видимостью этих заполнителей через классы менеджеров заголовков/нижних колонтитулов.

Доступные заполнители зависят от области:

| Область | Заголовок | Нижний колонтитул | Дата/время | Номер слайда/страницы |
|---|---|---|---|---|
| Обычный слайд | Нет | Да | Да | Да |
| Макет заметок | Да | Да | Да | Да |
| Слайд заметок | Да | Да | Да | Да |
| Макет раздач | Да | Да | Да | Да |

У обычного слайда презентации нет заполнителя заголовка. Заголовки доступны на страницах заметок и раздач. Для обычных слайдов используйте заполнители нижнего колонтитула, даты/времени и номера слайда.

Область изменения зависит от используемого менеджера. Класс [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideheaderfootermanager/) управляет одним обычным слайдом. Класс [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notesslideheaderfootermanager/) управляет одним слайдом заметок. Менеджеры мастера и макета также могут распространять настройки на зависимые слайды, тогда как класс [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) управляет мастером раздач.

## **Установка нижнего колонтитула, даты/времени и номеров слайдов на обычных слайдах**

Для обычных слайдов базовый процесс состоит в получении менеджера заголовков/нижних колонтитулов каждого слайда, установке текста нижнего колонтитула и даты/времени, включении необходимых заполнителей и сохранении презентации. Номера слайдов генерируются презентацией, поэтому требуется только контролировать их видимость.

Используйте [`setFooterText`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) и [`setDateTimeText`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) для задания текста, а также [`setFooterVisibility`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) и [`setSlideNumberVisibility`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) для отображения соответствующих заполнителей.

Ниже приведён пример сквозного применения одинакового нижнего колонтитула, текста даты/времени и видимости номера слайда ко всем обычным слайдам:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если требуется обновить только один слайд, получайте этот слайд напрямую через метод [`getSlides`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getslides/) вместо перебора всей коллекции.

## **Установка заголовков и нижних колонтитулов в мастере заметок**

Мастер заметок определяет общие параметры форматирования и поведения заполнителей для страниц заметок. Используйте класс [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/), когда нужно изменить только сам мастер заметок.

Следующий пример задаёт заголовок, нижний колонтитул и текст даты/времени в мастере заметок и делает все поддерживаемые заполнители видимыми в этом мастере:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Метод [`getMasterNotesSlide`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) возвращает `null`, если презентация не содержит мастера заметок.

## **Применение настроек мастера заметок к дочерним слайдам заметок**

Мастер заметок может применять настройки заголовков и нижних колонтитулов к себе и ко всем зависимым слайдам заметок. Используйте специальные методы распространения в классе [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/), когда одинаковые настройки должны применяться по всей иерархии заметок.

Например, методы [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) и [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) обновляют заголовок мастера заметок и все дочерние заголовки. Аналогичные методы доступны для нижних колонтитулов, даты/времени и номеров слайдов.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Методы распространения, использованные выше, включают [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) и [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Установка заголовков и нижних колонтитулов на отдельном слайде заметок**

Слайд заметок принадлежит конкретному обычному слайду. Используйте его класс [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notesslideheaderfootermanager/), когда нужно настроить только эту страницу заметок.

Метод [`addNotesSlide`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) возвращает слайд заметок для текущего слайда и создаёт его, если он ещё не существует. Ниже пример конфигурации страницы заметок, связанной с первым слайдом презентации:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если сначала распространить настройки из мастера заметок, а затем изменить отдельный слайд заметок, более поздние настройки позволят кастомизировать эту страницу заметок независимо.

## **Установка заголовков и нижних колонтитулов в мастере раздач**

Страницы раздач используют мастер раздач для заполнителей заголовков, нижних колонтитулов, даты/времени и номеров страниц. В отличие от страниц заметок, настройки раздач управляются через мастер раздач, а не через отдельные слайды раздач.

Используйте [`getMasterHandoutSlide`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) для доступа к мастеру раздач. Если он отсутствует, вызовите [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) для создания мастера раздач по умолчанию.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Понимание области и наследования**

Выберите менеджер заголовков/нижних колонтитулов, соответствующий области, которую нужно изменить:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideheaderfootermanager/) изменяет настройки нижнего колонтитула, даты/времени и номера слайда для одного обычного слайда.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) управляет слайдом макета и может распространять поддерживаемые настройки на зависимые слайды.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterslideheaderfootermanager/) управляет обычным мастером слайдов и может распространять поддерживаемые настройки на зависимые слайды.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) управляет мастером заметок и может распространять настройки на все зависимые слайды заметок.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notesslideheaderfootermanager/) меняет один слайд заметок и поддерживает заполнитель заголовка в дополнение к нижнему колонтитулу, дате/времени и номеру слайда.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) меняет мастер раздач и поддерживает все четыре типа заполнителей.

Используйте распространение из мастера или макета, когда одинаковая настройка должна применяться по всей его иерархии. Используйте индивидуальный слайд или менеджер слайда заметок, когда требуется локальная настройка для одной страницы.

## **FAQ**

**Можно ли добавить заголовок к обычному слайду?**

Нет. PowerPoint не определяет заполнитель заголовка для обычных слайдов. На обычных слайдах используйте заполнители нижнего колонтитула, даты/времени и номера слайда. Заполнители заголовков доступны на страницах заметок и раздач.

**А что если заполнитель нижнего колонтитула, даты/времени или номера слайда не виден?**

Используйте соответствующий менеджер заголовков/нижних колонтитулов, чтобы проверить его видимость и включить её при необходимости. Например, метод [`isFooterVisible`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) сообщает, присутствует ли заполнитель нижнего колонтитула, а [`setFooterVisibility`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) изменяет его видимость.

**Как начать нумерацию слайдов с значения, отличного от 1?**

Вызовите метод презентации [`setFirstSlideNumber`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/setfirstslidenumber/). Затем заполнители номеров слайдов будут использовать обновлённую последовательность нумерации.

**Что происходит с заголовками и нижними колонтитулами при экспорте в PDF, изображения или HTML?**

Видимые элементы заголовков и нижних колонтитулов рендерятся вместе с остальным содержимым презентации в конечном формате. Их отображение зависит от типа экспортируемой страницы и соответствующих настроек видимости заполнителей.