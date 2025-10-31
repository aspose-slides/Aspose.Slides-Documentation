---
title: Управление примечаниями к презентации в Python
linktitle: Примечания к презентации
type: docs
weight: 110
url: /ru/python-net/presentation-notes/
keywords:
- примечания
- слайд примечаний
- добавить примечания
- удалить примечания
- стиль примечаний
- главные примечания
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Настройте примечания к презентации с помощью Aspose.Slides for Python via .NET. Беспрепятственно работайте с примечаниями PowerPoint и OpenDocument, повышая свою продуктивность."
---

Aspose.Slides поддерживает удаление слайдов примечаний из презентации. В этой статье мы представим новую возможность удаления примечаний, а также добавления слайдов стиля примечаний в любую презентацию. Aspose.Slides for Python via .NET предоставляет возможность удалять примечания любого слайда, а также добавлять стиль к существующим примечаниям. Разработчики могут удалять примечания следующими способами:

- Удалить примечания конкретного слайда презентации.
- Удалить примечания всех слайдов презентации.

## **Удалить примечания со слайда**

Примечания конкретного слайда могут быть удалены, как показано в примере ниже:

```py
import aspose.slides as slides

# Создать объект Presentation, представляющий файл презентации
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Удаление примечаний первого слайда
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # сохранить презентацию на диск
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Удалить примечания со всех слайдов**

Примечания всех слайдов презентации могут быть удалены, как показано в примере ниже:

```py
import aspose.slides as slides

# Создать объект Presentation, представляющий файл презентации
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Удаление примечаний со всех слайдов
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # сохранить презентацию на диск
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавить NotesStyle**

Свойство NotesStyle было добавлено в интерфейс [IMasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/) и класс [MasterNotesSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslide/) соответственно. Это свойство задает стиль текста примечаний. Реализация демонстрируется в примере ниже.

```py
import aspose.slides as slides

# Создать объект Presentation, представляющий файл презентации
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # Получить стиль текста MasterNotesSlide
        notesStyle = notesMaster.notes_style

        # Установить символный маркер для абзацев первого уровня
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # сохранить файл PPTX на диск
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Какой объект API предоставляет доступ к примечаниям конкретного слайда?**

Примечания доступны через менеджер примечаний слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/) и [свойство](https://reference.aspose.com/slides/python-net/aspose.slides/notesslidemanager/notes_slide/), которое возвращает объект примечаний, или `None`, если примечаний нет.

**Есть ли различия в поддержке примечаний между версиями PowerPoint, с которыми работает библиотека?**

Библиотека поддерживает широкий спектр форматов Microsoft PowerPoint (97‑newer) и ODP; примечания поддерживаются в этих форматах без необходимости установленной копии PowerPoint.