---
title: Управление заголовками и нижними колонтитулами презентации на Android
linktitle: Заголовок и нижний колонтитул
type: docs
weight: 140
url: /ru/androidjava/presentation-header-and-footer/
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
- Android
- Java
- Aspose.Slides
description: "Узнайте, как управлять заполнителями нижнего колонтитула, даты-времени, номера слайда и заголовка на слайдах, страницах заметок и раздаточных материалах с помощью Aspose.Slides для Android через Java."
---
## **Обзор**

PowerPoint использует разные заполнители заголовка и нижнего колонтитула в зависимости от типа страницы. Aspose.Slides для Android через Java позволяет управлять текстом и видимостью этих заполнителей через интерфейсы менеджеров заголовков/нижних колонтитулов.

Доступные заполнители зависят от области:

| Область | Заголовок | Нижний колонтитул | Дата/время | Номер слайда/страницы |
|---|---|---|---|---|
| Обычный слайд | Нет | Да | Да | Да |
| Шаблон заметок | Да | Да | Да | Да |
| Слайд заметок | Да | Да | Да | Да |
| Шаблон раздаточного материала | Да | Да | Да | Да |

Обычный слайд презентации не имеет заполнителя заголовка. Заголовки доступны на страницах заметок и раздаточных материалах. Для обычных слайдов используйте заполнители нижнего колонтитула, даты/времени и номера слайда.

Область изменения зависит от используемого менеджера. Интерфейс [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideheaderfootermanager/) управляет одним обычным слайдом. Интерфейс [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) управляет одним слайдом заметок. Менеджеры мастеров и макетов также могут распространять настройки на зависимые слайды, а интерфейс [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) управляет мастером раздаточного материала.

## **Установка нижнего колонтитула, даты/времени и номеров слайдов на обычных слайдах**

Для обычных слайдов базовый процесс состоит в получении менеджера заголовка/нижнего колонтитула каждого слайда, установке текста нижнего колонтитула и даты/времени, включении требуемых заполнителей и сохранении презентации. Номера слайдов генерируются презентацией, поэтому нужно только управлять их видимостью.

Используйте [`setFooterText`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) и [`setDateTimeText`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) для задания текста, а также [`setFooterVisibility`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), и [`setSlideNumberVisibility`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) для отображения соответствующих заполнителей.

Следующий пример от начала до конца применяет одинаковый нижний колонтитул, текст даты/времени и видимость номера слайда ко всем обычным слайдам:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если необходимо обновить только один слайд, получите его напрямую через метод [`getSlides`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getSlides--) вместо перебора всей коллекции.

## **Установка заголовков и нижних колонтитулов в мастере заметок**

Мастер заметок определяет общие параметры форматирования и поведения заполнителей для страниц заметок. Используйте интерфейс [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) когда нужно изменить только сам мастер заметок.

Следующий пример задает заголовок, нижний колонтитул и текст даты/времени в мастере заметок и делает все поддерживаемые заполнители видимыми в этом мастере:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Метод [`getMasterNotesSlide`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) возвращает `null`, если в презентации нет мастера заметок.

## **Применение настроек мастера заметок к дочерним слайдам заметок**

Мастер заметок может применить настройки заголовка и нижнего колонтитула к себе и ко всем зависимым слайдам заметок. Используйте специальные методы распространения на интерфейсе [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) когда одинаковые настройки должны быть применены по всей иерархии заметок.

Например, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) и [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) обновляют заголовок мастера заметок и все дочерние заголовки. Аналогичные методы доступны для нижних колонтитулов, даты/времени и номеров слайдов.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Методы распространения, использованные выше, это [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), и [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Установка заголовков и нижних колонтитулов в отдельном слайде заметок**

Слайд заметок принадлежит конкретному обычному слайду. Используйте его интерфейс [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) когда нужно настроить только эту страницу заметок.

Метод [`addNotesSlide`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) возвращает слайд заметок для текущего слайда и создает его, если он ещё не существует. Следующий пример настраивает страницу заметок, связанную с первым слайдом презентации:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если сначала распространить настройки из мастера заметок, а затем изменить отдельный слайд заметок, последующие настройки конкретного слайда позволяют кастомизировать эту страницу независимо.

## **Установка заголовков и нижних колонтитулов в мастере раздаточного материала**

Страницы раздаточного материала используют мастер раздаточного материала для своих заполнителей заголовка, нижнего колонтитула, даты/времени и номера страницы. В отличие от страниц заметок, настройки раздаточного материала управляются через мастер раздаточного материала, а не через отдельные слайды раздатки.

Используйте метод [`getMasterHandoutSlide`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) для доступа к мастеру раздаточного материала. Если он отсутствует, вызовите [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) для создания мастера по умолчанию.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Понимание области и наследования**

Выберите менеджер заголовка/нижнего колонтитула, соответствующий области, которую нужно изменить:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideheaderfootermanager/) изменяет настройки нижнего колонтитула, даты/времени и номера слайда для одного обычного слайда.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) управляет макетным слайдом и может распространять поддерживаемые настройки на зависимые слайды.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) управляет обычным мастером слайдов и может распространять поддерживаемые настройки на зависимые слайды.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) управляет мастером заметок и может распространять настройки на все зависимые слайды заметок.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) изменяет один слайд заметок и поддерживает заполнитель заголовка в дополнение к нижнему колонтитулу, дате/времени и номеру слайда.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) изменяет мастер раздаточного материала и поддерживает все четыре типа заполнителей.

Используйте распространение из мастера или макета, когда одинаковая настройка должна применяться по всей иерархии. Используйте отдельный слайд или менеджер слайда заметок, когда нужна локальная настройка для одной страницы.

## **FAQ**

**Можно ли добавить заголовок к обычному слайду?**

Нет. PowerPoint не определяет заполнитель заголовка для обычных слайдов. На обычных слайдах используйте заполнители нижнего колонтитула, даты/времени и номера слайда. Заполнители заголовка доступны на страницах заметок и раздаточных материалах.

**Что делать, если заполнитель нижнего колонтитула, даты/времени или номера слайда не виден?**

Используйте соответствующий менеджер заголовка/нижнего колонтитула, чтобы проверить его видимость и включить при необходимости. Например, [`isFooterVisible`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) сообщает, присутствует ли заполнитель нижнего колонтитула, а [`setFooterVisibility`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) изменяет его видимость.

**Как начать нумерацию слайдов с значения, отличного от 1?**

Вызовите метод презентации [`setFirstSlideNumber`](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) . После этого заполнители номеров слайдов используют обновлённую последовательность нумерации.

**Что происходит с заголовками и нижними колонтитулами при экспорте в PDF, изображения или HTML?**

Видимые элементы заголовка и нижнего колонтитула рендерятся вместе с остальным содержимым презентации в выходном формате. Их отображение зависит от типа экспортируемой страницы и соответствующих настроек видимости заполнителей.