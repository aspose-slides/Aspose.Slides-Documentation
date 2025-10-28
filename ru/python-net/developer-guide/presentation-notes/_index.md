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
- мастер‑записей
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Настройте заметки презентации с помощью Aspose.Slides для Python через .NET. Беспрепятственно работайте с заметками PowerPoint и OpenDocument, повышая свою продуктивность."
---

Aspose.Slides поддерживает удаление записей‑слайдов из презентации. В этой теме мы представим новую возможность удаления заметок, а также добавления стилей заметок к любому слайду. Aspose.Slides для Python через .NET предоставляет функцию удаления заметок любого слайда, а также применения стиля к существующим заметкам. Разработчики могут удалить заметки следующими способами:

- Удалить заметки конкретного слайда презентации.
- Удалить заметки всех слайдов презентации.

## **Удалить заметки со слайда**
Заметки конкретного слайда можно удалить, как показано в примере ниже:

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Removing notes of first slide
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # save presentation to disk
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Удалить заметки со всех слайдов**
Заметки всех слайдов презентации можно удалить, как показано в примере ниже:

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Removing notes of all slides
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # save presentation to disk
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавить стиль заметок**
Свойство **NotesStyle** было добавлено к интерфейсу [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) и классу [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/). Это свойство определяет стиль текста заметок. Реализация продемонстрирована в примере ниже.

```py
import aspose.slides as slides

# Instantiate Presentation class that represents the presentation file
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Get MasterNotesSlide text style
        notesStyle = notesMaster.notes_style

        #Set symbol bullet for the first level paragraphs
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # save the PPTX file to the Disk
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Какой объект API предоставляет доступ к заметкам конкретного слайда?**

Заметки доступны через менеджер заметок слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) и [свойство](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/), которое возвращает объект заметок или `None`, если заметок нет.

**Есть ли различия в поддержке заметок в разных версиях PowerPoint, с которыми работает библиотека?**

Библиотека охватывает широкий спектр форматов Microsoft PowerPoint (97‑и новее) и ODP; заметки поддерживаются в этих форматах независимо от наличия установленной копии PowerPoint.