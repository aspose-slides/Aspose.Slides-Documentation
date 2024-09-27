---
title: Заметки для презентации
type: docs
weight: 110
url: /ru/cpp/presentation-notes/
keywords: "Заметки для спикера презентации PowerPoint"
---

## **Добавление и удаление заметок слайдов**
Aspose.Slides теперь поддерживает удаление заметок слайдов из презентации. В этой теме мы представим новую функцию удаления заметок, а также добавления стиля заметок из любой презентации. Aspose.Slides для C++ предоставляет возможность удаления заметок любого слайда, а также добавления стиля к существующим заметкам. Разработчики могут удалять заметки следующими способами:

- Удаление заметок конкретного слайда презентации.
- Удаление заметок со всех слайдов презентации.

## **Удаление заметок с конкретного слайда**
Заметки конкретного слайда могут быть удалены, как показано в следующем примере:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Удаление заметок со всех слайдов**
Заметки со всех слайдов презентации могут быть удалены, как показано в следующем примере:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Добавление стиля заметок**
Свойство NotesStyle было добавлено в интерфейс IMasterNotesSlide и класс MasterNotesSlide соответственно. Это свойство определяет стиль текста заметок. Реализация демонстрируется в следующем примере.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}