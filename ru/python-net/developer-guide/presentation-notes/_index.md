---
title: Управление заметками презентации в Python
linktitle: Заметки презентации
type: docs
weight: 110
url: /ru/python-net/presentation-notes/
keywords:
- заметки
- слайд заметок
- добавить заметки
- удалить заметки
- стиль заметок
- мастер-заметки
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Настройте заметки презентации с помощью Aspose.Slides для Python через .NET. Бесшовно работайте с заметками PowerPoint и OpenDocument, чтобы повысить свою продуктивность."
---
## **Обзор**

Aspose.Slides поддерживает удаление слайдов с заметками из презентации. В этой теме мы расскажем об этой функции, включая способы удаления заметок и применения стиля к слайдам с заметками в презентации. Aspose.Slides позволяет удалять заметки с любого слайда, а также применять стили к существующим заметкам. Разработчики могут удалять заметки следующими способами:

- Удалить заметки с конкретного слайда в презентации.
- Удалить заметки со всех слайдов в презентации.

Чтобы прочитать или изменить размеры страницы заметок, переключить ориентацию и проверить поведение экспорта, см. [Размер страницы заметок](/slides/ru/python-net/notes-size/).

## **Удалить заметки со слайда**
Заметки с конкретного слайда можно удалить, как показано в примере ниже:

```py
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл презентации 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Удаление заметок с первого слайда
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # сохранить презентацию на диск
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Удалить заметки со всех слайдов**
Заметки со всех слайдов презентации можно удалить, как показано в примере ниже:

```py
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл презентации 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # Удаление заметок со всех слайдов
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # сохранить презентацию на диск
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Применить стиль к заметкам**
Свойство [notes_style](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masternotesslide/notes_style/) было добавлено в класс [MasterNotesSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masternotesslide/). Это свойство указывает стиль текста заметок. Реализация демонстрируется в примере ниже.

```py
import aspose.slides as slides

# Создайте объект класса Presentation, представляющий файл презентации
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Получить стиль текста MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Установить символный маркер для абзацев первого уровня
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # сохранить файл PPTX на диск
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Вопросы и ответы**

**Какой API‑элемент предоставляет доступ к заметкам конкретного слайда?**

Заметки доступны через менеджер заметок слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/ru/python-net/aspose.slides/notesslidemanager/) и [свойство](https://reference.aspose.com/slides/ru/python-net/aspose.slides/notesslidemanager/notes_slide/), которое возвращает объект заметок, или `None`, если заметок нет.

**Есть ли различия в поддержке заметок между версиями PowerPoint, с которыми работает библиотека?**

Библиотека ориентирована на широкий спектр форматов Microsoft PowerPoint (97‑наше время) и ODP; заметки поддерживаются в этих форматах независимо от установленной копии PowerPoint.