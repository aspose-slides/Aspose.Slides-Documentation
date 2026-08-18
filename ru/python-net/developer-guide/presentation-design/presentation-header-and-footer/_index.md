---
title: Управление заголовками и нижними колонтитулами презентации с помощью Python
linktitle: Заголовок и нижний колонтитул
type: docs
weight: 140
url: /ru/python-net/presentation-header-and-footer/
keywords:
- заголовок
- текст заголовка
- нижний колонтитул
- текст нижнего колонтитула
- установить заголовок
- установить нижний колонтитул
- раздатка
- заметки
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять заполнителями нижнего колонтитула, даты и времени, номера слайда и заголовка на слайдах, страницах заметок и раздаточных листах с помощью Aspose.Slides for Python via .NET."
---
## **Обзор**

PowerPoint использует различные заполнители заголовков и нижних колонтитулов в зависимости от типа страницы. Aspose.Slides for Python via .NET позволяет управлять текстом и видимостью этих заполнителей через классы менеджеров заголовков/нижних колонтитулов.

Доступные заполнители зависят от области применения:

| Область | Заголовок | Нижний колонтитул | Дата/время | Номер слайда/страницы |
|---|---|---|---|---|
| Обычный слайд | Нет | Да | Да | Да |
| Мастер заметок | Да | Да | Да | Да |
| Слайд заметок | Да | Да | Да | Да |
| Мастер раздатки | Да | Да | Да | Да |

Обычный слайд презентации не имеет заполнителя заголовка. Заголовки доступны на страницах заметок и раздаточных листах. Для обычных слайдов используйте заполнители нижнего колонтитула, даты/времени и номера слайда вместо заголовка.

Область изменения зависит от используемого менеджера. Класс [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slideheaderfootermanager/) управляет одним обычным слайдом. Класс [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/notesslideheaderfootermanager/) управляет одним слайдом заметок. Менеджеры мастеров и макетов также могут распространять настройки на зависимые слайды, тогда как класс [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) управляет мастером раздатки.

## **Установка нижнего колонтитула, даты/времени и номеров слайдов на обычных слайдах**

Для обычных слайдов базовый рабочий процесс состоит в получении менеджера заголовка/нижнего колонтитула каждого слайда, установке текста нижнего колонтитула и даты/времени, включении необходимых заполнителей и сохранении презентации. Номера слайдов генерируются презентацией, поэтому нужно лишь управлять их видимостью.

Используйте [`set_footer_text`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) и [`set_date_time_text`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) для установки текста, а также [`set_footer_visibility`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/) и [`set_slide_number_visibility`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) для отображения соответствующих заполнителей.

Следующий сквозной пример применяет одинаковый нижний колонтитул, текст даты/времени и видимость номера слайда ко всем обычным слайдам:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Если нужно обновить только один слайд, получайте его напрямую через коллекцию [`slides`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/slides/ru/) вместо перебора всей коллекции.

## **Установка заголовков и нижних колонтитулов в мастер заметок**

Мастер заметок определяет общее форматирование и поведение заполнителей для страниц заметок. Используйте класс [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masternotesslideheaderfootermanager/) когда необходимо изменить только сам мастер заметок.

Следующий пример устанавливает заголовок, нижний колонтитул и текст даты/времени в мастере заметок и делает все поддерживаемые заполнители видимыми в этом мастере:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

Презентация может не содержать мастер заметок, поэтому перед изменением проверьте возвращаемое значение на `None`.

## **Применение настроек мастера заметок к дочерним слайдам заметок**

Мастер заметок может применять настройки заголовка и нижнего колонтитула к себе и ко всем зависимым слайдам заметок. Используйте специальные методы распространения в [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masternotesslideheaderfootermanager/) когда одинаковые настройки должны быть применены во всей иерархии заметок.

Например, [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) и [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) обновляют заголовок мастера заметок и все дочерние заголовки. Аналогичные методы доступны для нижних колонтитулов, даты/времени и номеров слайдов.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Методы распространения, использованные выше, это [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), и [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Установка заголовков и нижних колонтитулов на отдельном слайде заметок**

Слайд заметок принадлежит конкретному обычному слайду. Используйте его класс [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/notesslideheaderfootermanager/) когда нужно настроить только эту страницу заметок.

Метод [`add_notes_slide`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/notesslidemanager/add_notes_slide/) возвращает слайд заметок для текущего слайда и создаёт его, если он ещё не существует. Ниже пример, который конфигурирует страницу заметок, связанную с первым слайдом презентации:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Если сначала распространить настройки из мастера заметок, а затем изменить отдельный слайд заметок, последние настройки для конкретного слайда позволят настроить эту страницу независимо.

## **Установка заголовков и нижних колонтитулов в мастер раздатки**

Страницы раздатки используют мастер раздатки для своих заполнителей заголовка, нижнего колонтитула, даты/времени и номера страницы. В отличие от страниц заметок, настройки раздатки управляются через мастер раздатки, а не через отдельные слайды раздатки.

Используйте свойство [`master_handout_slide`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) для доступа к мастеру раздатки. Если он отсутствует, вызовите [`set_default_master_handout_slide`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) для создания мастера раздатки по умолчанию.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Понимание области действия и наследования**

Выберите менеджер заголовков/нижних колонтитулов, соответствующий области, которую нужно изменить:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slideheaderfootermanager/) изменяет настройки нижнего колонтитула, даты/времени и номера слайда для одного обычного слайда.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslideheaderfootermanager/) управляет слайдом макета и может распространять поддерживаемые настройки на зависимые слайды.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslideheaderfootermanager/) управляет обычным мастером слайдов и может распространять поддерживаемые настройки на зависимые слайды.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masternotesslideheaderfootermanager/) управляет мастером заметок и может распространять настройки на все зависимые слайды заметок.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/notesslideheaderfootermanager/) изменяет один слайд заметок и поддерживает заполнитель заголовка в дополнение к нижнему колонтитулу, дате/времени и номеру слайда.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) изменяет мастер раздатки и поддерживает все четыре типа заполнителей.

Используйте распространение из мастера или макета, когда одинаковая настройка должна применяться по всей иерархии. Используйте менеджер отдельного слайда или слайда заметок, когда требуется локальная настройка для одной страницы.

## **Часто задаваемые вопросы**

**Могу ли я добавить заголовок к обычному слайду?**

Нет. PowerPoint не определяет заполнитель заголовка для обычных слайдов. На обычных слайдах используйте заполнители нижнего колонтитула, даты/времени и номера слайда. Заполнители заголовков доступны на страницах заметок и раздаточных листах.

**Что делать, если заполнитель нижнего колонтитула, даты/времени или номера слайда не виден?**

Используйте соответствующий менеджер заголовков/нижних колонтитулов, чтобы проверить его видимость и включить его при необходимости. Например, [`is_footer_visible`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) сообщает, присутствует ли заполнитель нижнего колонтитула, а [`set_footer_visibility`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) изменяет его видимость.

**Как начать нумерацию слайдов с значения, отличного от 1?**

Установите свойство [`first_slide_number`](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/first_slide_number/) презентации. Затем заполнители номеров слайдов используют обновлённую последовательность нумерации.

**Что происходит с заголовками и нижними колонтитулами при экспорте в PDF, изображения или HTML?**

Видимые элементы заголовка и нижнего колонтитула рендерятся вместе с остальным содержимым презентации в целевом формате. Их отображение зависит от типа экспортируемой страницы и соответствующих настроек видимости заполнителей.