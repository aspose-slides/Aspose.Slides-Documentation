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
- главные заметки
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Настройте заметки презентации с помощью Aspose.Slides for Python via .NET. Беспрепятственно работайте с заметками PowerPoint и OpenDocument, повышая свою продуктивность."
---

Aspose.Slides поддерживает удаление слайдов заметок из презентации. В этой теме мы представим новую возможность удаления заметок, а также добавления стилей заметок к любой презентации. Aspose.Slides for Python via .NET предоставляет возможность удалять заметки любого слайда, а также добавлять стиль к существующим заметкам. Разработчики могут удалять заметки следующими способами:

- Удалить заметки конкретного слайда презентации.
- Удалить заметки всех слайдов презентации.
## **Удалить заметки со слайда**
Заметки определённого слайда можно удалить, как показано в примере ниже:
```py
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл презентации
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Удаление заметок первого слайда
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # Сохранить презентацию на диск
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Удалить заметки со всех слайдов**
Заметки всех слайдов презентации можно удалить, как показано в примере ниже:
```py
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл презентации 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Удаление заметок всех слайдов
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # Сохранить презентацию на диск
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Add NotesStyle**
Свойство NotesStyle было добавлено в интерфейс [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) и класс [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) соответственно. Это свойство задаёт стиль текста заметок. Реализация продемонстрирована в примере ниже.
```py
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл презентации
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Получить стиль текста MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Установить символный маркер для абзацев первого уровня
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # Сохранить файл PPTX на диск
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Какой объект API предоставляет доступ к заметкам конкретного слайда?**

Заметки доступны через менеджер заметок слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) и [property](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/) которые возвращают объект заметок, или `None`, если заметок нет.

**Есть ли различия в поддержке заметок в разных версиях PowerPoint, с которыми работает библиотека?**

Библиотека работает с широким диапазоном форматов Microsoft PowerPoint (97‑и новее) и ODP; заметки поддерживаются в этих форматах без необходимости установленной копии PowerPoint.