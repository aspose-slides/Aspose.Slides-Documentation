---
title: Управление заметками презентации на C++
linktitle: Заметки презентации
type: docs
weight: 110
url: /ru/cpp/presentation-notes/
keywords:
- заметки
- слайд заметок
- добавить заметки
- удалить заметки
- стиль заметок
- главные заметки
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Настройте заметки презентации с помощью Aspose.Slides для C++. Бесшовно работайте с заметками PowerPoint и OpenDocument, повышая свою производительность."
---
## **Обзор**

Aspose.Slides поддерживает удаление слайдов с заметками из презентации. В этом разделе мы представим эту возможность, включая то, как удалять заметки и как применять стиль к слайдам заметок в презентации. Aspose.Slides позволяет удалять заметки с любого слайда, а также применять стили к существующим заметкам. Разработчики могут удалять заметки следующими способами:

- Удалить заметки с конкретного слайда в презентации.
- Удалить заметки со всех слайдов в презентации.

Для чтения или изменения размеров страницы заметок, переключения ориентации и проверки поведения экспорта см. [Размер страницы заметок](/slides/ru/cpp/notes-size/).

## **Удалить заметки с конкретного слайда**
Заметки с конкретного слайда могут быть удалены, как показано в примере ниже:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Удалить заметки со всех слайдов**
Заметки со всех слайдов в презентации могут быть удалены, как показано в примере ниже:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Добавить стиль заметок**
Свойство NotesStyle было добавлено в интерфейс IMasterNotesSlide и класс MasterNotesSlide. Это свойство задает стиль текста заметок. Реализация продемонстрирована в примере ниже.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

### Какой объект API предоставляет доступ к заметкам конкретного слайда?

Заметки доступны через менеджер заметок слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/ru/cpp/aspose.slides/notesslidemanager/) и [метод](https://reference.aspose.com/slides/ru/cpp/aspose.slides/notesslidemanager/get_notesslide/), который возвращает объект заметок, или `null`, если заметок нет.

### Есть ли различия в поддержке заметок между версиями PowerPoint, с которыми работает библиотека?

Библиотека ориентирована на широкий спектр форматов Microsoft PowerPoint (97–newer) и ODP; заметки поддерживаются в этих форматах без зависимости от установленной копии PowerPoint.