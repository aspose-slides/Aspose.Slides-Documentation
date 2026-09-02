---
title: Управление заголовками и нижними колонтитулами презентации в C++
linktitle: Заголовок и нижний колонтитул
type: docs
weight: 140
url: /ru/cpp/presentation-header-and-footer/
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
- C++
- Aspose.Slides
description: "Узнайте, как управлять заполнителями нижнего колонтитула, даты и времени, номера слайда и заголовка на слайдах, страницах заметок и раздаточных материалах с помощью Aspose.Slides для C++."
---
## **Обзор**

PowerPoint использует различные заполнители заголовка и нижнего колонтитула в зависимости от типа страницы. Aspose.Slides for C++ позволяет управлять текстом и видимостью этих заполнителей через интерфейсы менеджеров заголовков/нижних колонтитулов.

Доступные заполнители зависят от области применения:

| Область | Заголовок | Нижний колонтитул | Дата/время | Номер слайда/страницы |
|---|---|---|---|---|
| Обычный слайд | Нет | Да | Да | Да |
| Шаблон заметок | Да | Да | Да | Да |
| Слайд заметок | Да | Да | Да | Да |
| Шаблон раздач | Да | Да | Да | Да |

Обычный слайд презентации не имеет заполнителя заголовка. Заголовки доступны на страницах заметок и раздач. Для обычных слайдов используйте заполнители нижнего колонтитула, даты/времени и номера слайда.

Область изменения зависит от используемого менеджера. Интерфейс [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideheaderfootermanager/) управляет одним обычным слайдом. Интерфейс [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/inotesslideheaderfootermanager/) управляет одним слайдом заметок. Менеджеры шаблонов и макетов также могут распространять настройки на зависимые слайды, тогда как интерфейс [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) управляет шаблоном раздач.

## **Установка нижнего колонтитула, даты/времени и номеров слайдов на обычных слайдах**

Для обычных слайдов базовый процесс состоит в получении менеджера заголовков/нижних колонтитулов каждого слайда, установке текста нижнего колонтитула и даты/времени, включении требуемых заполнителей и сохранении презентации. Номера слайдов генерируются презентацией, поэтому необходимо лишь управлять их видимостью.

Используйте [`SetFooterText`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) и [`SetDateTimeText`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) для установки текста, а также [`SetFooterVisibility`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/) и [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) для отображения соответствующих заполнителей.

Следующий сквозной пример применяет одинаковый нижний колонтитул, текст даты/времени и видимость номера слайда ко всем обычным слайдам:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

Если необходимо обновить только один слайд, получите его напрямую через [`Presentation::get_Slide`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_slide/) вместо перебора всей коллекции слайдов.

## **Установка заголовков и нижних колонтитулов в шаблоне заметок**

Шаблон заметок определяет общие параметры форматирования и поведения заполнителей для страниц заметок. Используйте интерфейс [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasternotesslideheaderfootermanager/) когда нужно изменить только сам шаблон заметок.

Следующий пример задаёт заголовок, нижний колонтитул и текст даты/времени в шаблоне заметок и делает все поддерживаемые заполнители видимыми в этом шаблоне:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

Метод [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) возвращает `nullptr`, если в презентации отсутствует шаблон заметок.

## **Применение настроек шаблона заметок к дочерним слайдам заметок**

Шаблон заметок может применять настройки заголовка и нижнего колонтитула к себе и ко всем зависимым слайдам заметок. Используйте специальные методы распространения в [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasternotesslideheaderfootermanager/) когда те же настройки должны быть применены по всей иерархии заметок.

Например, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) и [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) обновляют заголовок шаблона заметок и все дочерние заголовки. Эквивалентные методы доступны для нижних колонтитулов, даты/времени и номеров слайдов.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

Методы распространения, использованные выше, это [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), и [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Установка заголовков и нижних колонтитулов на отдельном слайде заметок**

Слайд заметок принадлежит конкретному обычному слайду. Используйте его интерфейс [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/inotesslideheaderfootermanager/) когда нужно настроить только эту страницу заметок.

Метод [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/inotesslidemanager/addnotesslide/) возвращает слайд заметок для текущего слайда и создаёт его, если он ещё не существует. Следующий пример настраивает страницу заметок, связанную с первым слайдом презентации:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

Если сначала распространить настройки из шаблона заметок, а затем изменить отдельный слайд заметок, последующие настройки для конкретного слайда позволяют кастомизировать эту страницу независимо.

## **Установка заголовков и нижних колонтитулов в шаблоне раздач**

Страницы раздач используют шаблон раздач для своих заполнителей заголовка, нижнего колонтитула, даты/времени и номера страницы. В отличие от страниц заметок, настройки раздач управляются через шаблон раздач, а не через отдельные слайды раздач.

Используйте [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) для доступа к шаблону раздач. Если его нет, вызовите [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) для создания шаблона раздач по умолчанию.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **Понимание области применения и наследования**

Выберите менеджер заголовков/нижних колонтитулов, соответствующий нужной области:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islideheaderfootermanager/) изменяет настройки нижнего колонтитула, даты/времени и номера слайда для одного обычного слайда.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ilayoutslideheaderfootermanager/) управляет макетом слайда и может распространять поддерживаемые настройки на зависимые слайды.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslideheaderfootermanager/) управляет обычным шаблоном слайдов и может распространять поддерживаемые настройки на зависимые слайды.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasternotesslideheaderfootermanager/) управляет шаблоном заметок и может распространять настройки на все зависимые слайды заметок.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/inotesslideheaderfootermanager/) изменяет один слайд заметок и поддерживает заполнитель заголовка в дополнение к нижнему колонтитулу, дате/времени и номеру слайда.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) изменяет шаблон раздач и поддерживает все четыре типа заполнителей.

Используйте распространение из шаблона или макета, когда одинаковая настройка должна применяться по всей иерархии. Используйте отдельный слайд или менеджер слайда заметок, когда требуется локальная настройка для одной страницы.

## **FAQ**

**Можно ли добавить заголовок к обычному слайду?**

Нет. PowerPoint не определяет заполнитель заголовка для обычных слайдов. На обычных слайдах используйте заполнители нижнего колонтитула, даты/времени и номера слайда. Заполнители заголовка доступны на страницах заметок и раздач.

**Что делать, если заполнитель нижнего колонтитула, даты/времени или номера слайда не виден?**

Используйте соответствующий менеджер заголовков/нижних колонтитулов, чтобы проверить его видимость и включить при необходимости. Например, [`get_IsFooterVisible`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) сообщает, присутствует ли заполнитель нижнего колонтитула, а [`SetFooterVisibility`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) изменяет его видимость.

**Как начать нумерацию слайдов с значения, отличного от 1?**

Используйте [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/set_firstslidenumber/) для установки первого номера слайда. Затем заполнители номеров слайдов используют обновлённую последовательность нумерации.

**Что происходит с заголовками и нижними колонтитулами при экспорте в PDF, изображения или HTML?**

Видимые элементы заголовка и нижнего колонтитула рендерятся вместе с остальным содержимым презентации в выходном формате. Их отображение зависит от типа экспортируемой страницы и соответствующих настроек видимости заполнителей.