---
title: Заметки для презентации
type: docs
weight: 110
url: /ru/python-net/presentation-notes/
keywords: "Заметки, заметки PowerPoint, добавить заметки, удалить заметки, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавление и удаление заметок в презентациях PowerPoint на Python"
---



Aspose.Slides поддерживает удаление слайдов с заметками из презентации. В этой теме мы представим эту новую функцию удаления заметок, а также добавления стилевых слайдов с заметками из любой презентации. Aspose.Slides для Python через .NET предоставляет возможность удаления заметок с любого слайда, а также добавления стиля к существующим заметкам. Разработчики могут удалять заметки следующими способами:

- Удалить заметки конкретного слайда презентации.
- Удалить заметки со всех слайдов презентации.
## **Удалить заметки со слайда**
Заметки с конкретного слайда можно удалить, как показано в следующем примере:

```py
import aspose.slides as slides

# Создаем объект презентации, представляющий файл презентации 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Удаляем заметки первого слайда
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # сохраняем презентацию на диск
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Удалить заметки со всех слайдов**
Заметки со всех слайдов презентации можно удалить, как показано в следующем примере:

```py
import aspose.slides as slides

# Создаем объект презентации, представляющий файл презентации 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Удаляем заметки со всех слайдов
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # сохраняем презентацию на диск
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Добавить стиль заметок**
Свойство NotesStyle было добавлено к интерфейсу [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) и классу [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) соответственно. Это свойство задает стиль текста заметок. Реализация демонстрируется в следующем примере.

```py
import aspose.slides as slides

# Создаем класс презентации, представляющий файл презентации
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Получаем стиль текста MasterNotesSlide
        notesStyle = notesMaster.notes_style

        # Устанавливаем символ для списков первого уровня
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # сохраняем файл PPTX на диск
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```