---
title: Управление заголовками и нижними колонтитулами презентации в Python через Java
linktitle: Заголовок и нижний колонтитул
type: docs
weight: 140
url: /ru/python-java/presentation-header-and-footer/
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
- Python
- Java
- Aspose.Slides
description: "Узнайте, как управлять заполнителями нижнего колонтитула, даты и времени, номера слайда и заголовка на слайдах, страницах заметок и раздаточных материалах с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

PowerPoint использует разные заполнители заголовков и нижних колонтитулов в зависимости от типа страницы. Aspose.Slides для Python через Java позволяет управлять текстом и видимостью этих заполнителей с помощью классов менеджеров заголовков/нижних колонтитулов.

Доступные заполнители зависят от области:

| Область | Заголовок | Нижний колонтитул | Дата/время | Номер слайда/страницы |
|---|---|---|---|---|
| Обычный слайд | Нет | Да | Да | Да |
| Шаблон заметок | Да | Да | Да | Да |
| Слайд заметок | Да | Да | Да | Да |
| Шаблон раздаточных материалов | Да | Да | Да | Да |

У обычного слайда презентации нет заполнителя заголовка. Заголовки доступны на страницах заметок и раздаточных материалов. Для обычных слайдов используйте заполнители нижнего колонтитула, даты/времени и номера слайда.

Область изменения зависит от используемого менеджера. Класс [SlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideheaderfootermanager/) управляет одним обычным слайдом. Класс [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notesslideheaderfootermanager/) управляет одним слайдом заметок. Менеджеры мастеров и макетов также могут распространять настройки на зависимые слайды, тогда как класс [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) управляет мастером раздаточных материалов.

## **Установить нижний колонтитул, дату/время и номера слайдов на обычных слайдах**

Для обычных слайдов основной рабочий процесс состоит в доступе к менеджеру заголовков/нижних колонтитулов каждого слайда, установке текста нижнего колонтитула и даты/времени, включении требуемых заполнителей и сохранении презентации. Номера слайдов генерируются презентацией, поэтому вам нужно только управлять их видимостью.

Используйте [setFooterText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) и [setDateTimeText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) для установки текста, а также [setFooterVisibility](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) и [setSlideNumberVisibility](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) для отображения соответствующих заполнителей.

Следующий сквозной пример применяет одинаковый нижний колонтитул, текст даты/времени и видимость номера слайда ко всем обычным слайдам:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Если необходимо обновить только один слайд, получите доступ к этому слайду напрямую через метод [getSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSlides), а не перебирая всю коллекцию.

## **Установить заголовки и нижние колонтитулы в шаблоне заметок**

Шаблон заметок определяет общие параметры форматирования и поведения заполнителей для страниц заметок. Используйте класс [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masternotesslideheaderfootermanager/), когда нужно изменить только сам шаблон заметок.

Следующий пример задаёт заголовок, нижний колонтитул и текст даты/времени в шаблоне заметок и делает все поддерживаемые заполнители видимыми в этом мастере:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Метод `getMasterNotesSlide` возвращает `None`, когда презентация не содержит шаблона заметок.

## **Применить настройки шаблона заметок к дочерним слайдам заметок**

Шаблон заметок может применять настройки заголовков и нижних колонтитулов к себе и ко всем зависимым слайдам заметок. Используйте специальные методы распространения в классе [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masternotesslideheaderfootermanager/), когда одинаковые настройки должны применяться по всей иерархии заметок.

Например, [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) и [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) обновляют заголовок шаблона заметок и все дочерние заголовки. Эквивалентные методы доступны для нижних колонтитулов, даты/времени и номеров слайдов.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Методы распространения, использованные выше, — [setFooterAndChildFootersText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) и [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Установить заголовки и нижние колонтитулы на отдельном слайде заметок**

Слайд заметок относится к определённому обычному слайду. Используйте его класс [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notesslideheaderfootermanager/), когда нужно настроить только эту страницу заметок.

Метод [addNotesSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notesslidemanager/#addNotesSlide) возвращает слайд заметок для текущего слайда и создаёт его, если он ещё не существует. Следующий пример настраивает страницу заметок, связанную с первым слайдом презентации:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Если сначала распространить настройки из шаблона заметок, а затем изменить отдельный слайд заметок, последующие настройки конкретного слайда позволят адаптировать эту страницу заметок независимо.

## **Установить заголовки и нижние колонтитулы в шаблоне раздаточных материалов**

Страницы раздаточных материалов используют шаблон раздаточных материалов для своих заполнителей заголовка, нижнего колонтитула, даты/времени и номера страницы. В отличие от страниц заметок, настройки раздаточных материалов управляются через шаблон раздаточных материалов, а не через отдельные слайды раздаточных материалов.

Используйте метод `getMasterHandoutSlide` для доступа к шаблону раздаточного материала. Если он отсутствует, вызовите `setDefaultMasterHandoutSlide`, чтобы создать шаблон раздаточного материала по умолчанию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Понимание области применения и наследования**

Выберите менеджер заголовков/нижних колонтитулов, соответствующий области, которую необходимо изменить:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideheaderfootermanager/) меняет настройки нижнего колонтитула, даты/времени и номера слайда для одного обычного слайда.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslideheaderfootermanager/) управляет макетом слайда и может распространять поддерживаемые настройки на зависимые слайды.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslideheaderfootermanager/) управляет обычным мастером слайдов и может распространять поддерживаемые настройки на зависимые слайды.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masternotesslideheaderfootermanager/) управляет шаблоном заметок и может распространять настройки на все зависимые слайды заметок.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notesslideheaderfootermanager/) меняет один слайд заметок и поддерживает заполнитель заголовка в дополнение к нижнему колонтитулу, дате/времени и номеру слайда.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) меняет шаблон раздаточных материалов и поддерживает все четыре типа заполнителей.

Используйте распространение из мастера или макета, когда одна и та же настройка должна применяться ко всей иерархии. Используйте менеджер отдельного слайда или слайда заметок, когда требуется локальная настройка для одной страницы.

## **Часто задаваемые вопросы**

**Могу ли я добавить заголовок к обычному слайду?**

Нет. PowerPoint не определяет заполнитель заголовка для обычных слайдов. На обычных слайдах используйте заполнители нижнего колонтитула, даты/времени и номера слайда. Заполнители заголовка доступны на страницах заметок и раздаточных материалов.

**Что делать, если заполнитель нижнего колонтитула, даты/времени или номера слайда не виден?**

Используйте соответствующий менеджер заголовков/нижних колонтитулов, чтобы проверить его видимость и включить его при необходимости. Например, [isFooterVisible](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) сообщает, присутствует ли заполнитель нижнего колонтитула, а [setFooterVisibility](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) изменяет его видимость.

**Как начать нумерацию слайда с значения, отличного от 1?**

Вызовите метод презентации [setFirstSlideNumber](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#setFirstSlideNumber). После этого заполнители номеров слайдов используют обновлённую последовательность нумерации.

**Что происходит с заголовками и нижними колонтитулами при экспорте в PDF, изображения или HTML?**

Видимые элементы заголовков и нижних колонтитулов рендерятся вместе с остальным содержимым презентации в выходном формате. Их отображение зависит от типа экспортируемой страницы и соответствующих настроек видимости заполнителей.