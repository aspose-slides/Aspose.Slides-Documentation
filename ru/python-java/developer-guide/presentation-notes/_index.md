---
title: Управление заметками презентации в Python через Java
linktitle: Заметки презентации
type: docs
weight: 110
url: /ru/python-java/presentation-notes/
keywords:
- заметки
- слайд заметок
- добавить заметки
- удалить заметки
- стиль заметок
- мастер-записки
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Настройте заметки презентации с помощью Aspose.Slides для Python через Java. Беспрепятственно работайте с заметками PowerPoint и OpenDocument, повышая свою продуктивность."
---
## **Обзор**

Aspose.Slides поддерживает удаление слайдов‑записок из презентации. В этой статье рассматривается эта возможность, включая способы удаления записок и применения стиля к слайдам‑запискам в презентации. Aspose.Slides позволяет удалять записки с любого слайда и применять стили к существующим запискам. Разработчики могут удалять записки следующими способами:

- Удалить записки с конкретного слайда в презентации.
- Удалить записки со всех слайдов в презентации.

Чтобы прочитать или изменить размеры страницы записок, поменять ориентацию и проверить поведение при экспорте, см. [Размер страницы заметок](/slides/ru/python-java/notes-size/).

## **Удаление записок со слайда**

Записки с конкретного слайда можно удалить, как показано в примере ниже:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Создайте объект Presentation, представляющий файл презентации.
presentation = Presentation("presWithNotes.pptx")
try:
    # Удалите заметки с первого слайда.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # Сохраните презентацию на диск.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Удаление записок из презентации**

Записки со всех слайдов в презентации можно удалить, как показано в примере ниже:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Создайте объект Presentation, представляющий файл презентации.
presentation = Presentation("presWithNotes.pptx")
try:
    # Удалите заметки со всех слайдов.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # Сохраните презентацию на диск.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Добавление стиля записок**

Метод [getNotesStyle](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masternotesslide/#getNotesStyle) класса [MasterNotesSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masternotesslide/) предоставляет доступ к стилю текста записок. Реализация продемонстрирована в примере ниже.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# Создайте объект Presentation, представляющий файл презентации.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # Получите стиль текста мастер-слайда заметок.
        notes_style = notes_master.getNotesStyle()

        # Установите символные маркеры для абзацев первого уровня.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Какой объект API предоставляет доступ к запискам конкретного слайда?**

Запискам можно получить доступ через менеджер записок слайда: у слайда есть [NotesSlideManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notesslidemanager/) и метод [getNotesSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notesslidemanager/#getNotesSlide), который возвращает объект записок или `None`, если записок нет.

**Есть ли различия в поддержке записок в разных версиях PowerPoint, с которыми работает библиотека?**

Библиотека ориентирована на широкий диапазон форматов Microsoft PowerPoint (97 и новее) и ODP; поддержка записок реализована во всех этих форматах без зависимости от установленной копии PowerPoint.