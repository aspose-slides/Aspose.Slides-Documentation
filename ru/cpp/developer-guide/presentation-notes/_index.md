---
title: Управление заметками презентации в C++
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
- мастер заметки
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Настройте заметки презентации с помощью Aspose.Slides для C++. Без проблем работайте с заметками PowerPoint и OpenDocument, повышая свою продуктивность."
---

## **Add and Remove Slide Notes**
Aspose.Slides теперь поддерживает удаление заметок слайдов из презентации. В этом разделе мы представим новую возможность удаления заметок, а также добавления слайдов со стилем заметок в любую презентацию. Aspose.Slides для C++ предоставляет возможность удаления заметок с любого слайда, а также добавления стиля к существующим заметкам. Разработчики могут удалять заметки следующими способами:

- Удаление заметок с конкретного слайда презентации.
- Удаление заметок со всех слайдов презентации.

## **Remove Notes from a Specific Slide**
Заметки с определённого слайда можно удалить, как показано в примере ниже:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Remove Notes from All Slides**
Заметки со всех слайдов презентации можно удалить, как показано в примере ниже:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Add a Notes Style**
Свойство NotesStyle было добавлено в интерфейс IMasterNotesSlide и класс MasterNotesSlide соответственно. Это свойство задаёт стиль текста заметок. Реализация продемонстрирована в примере ниже.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

Заметки доступны через менеджер заметок слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/) и [method](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/get_notesslide/), которые возвращают объект заметок или `null`, если заметки отсутствуют.

**Are there differences in notes support across the PowerPoint versions the library works with?**

Библиотека охватывает широкий диапазон форматов Microsoft PowerPoint (97 и новее) и ODP; заметки поддерживаются в этих форматах без зависимости от установленной копии PowerPoint.