---
title: Мастер‑слайд
type: docs
weight: 30
url: /ru/python-net/examples/elements/master-slide/
keywords:
- мастер‑слайд
- добавить мастер‑слайд
- доступ к мастер‑слайду
- удалить мастер‑слайд
- неиспользуемый мастер‑слайд
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Управляйте мастер‑слайдами в Python с помощью Aspose.Slides: создавайте, редактируйте, клонируйте и форматируйте темы, фон, заполнители, чтобы унифицировать слайды в PowerPoint и OpenDocument."
---
Мастер‑слайды составляют верхний уровень иерархии наследования слайдов в PowerPoint. **Мастер‑слайд** определяет общие элементы дизайна, такие как фон, логотипы и форматирование текста. **Слайды‑раскладки** наследуются от мастер‑слайдов, а **обычные слайды** наследуются от слайдов‑раскладки.

В этой статье показано, как создавать, изменять и управлять мастер‑слайдами с помощью Aspose.Slides для Python через .NET.

## **Добавить мастер‑слайд**

В данном примере показано, как создать новый мастер‑слайд, клонировав стандартный.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Клонировать мастер‑слайд по умолчанию.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** Мастер‑слайды позволяют применять единый брендинг или общие элементы дизайна ко всем слайдам. Любые изменения в мастере автоматически отражаются на зависимых слайдах‑раскладках и обычных слайдах.

> 💡 **Tip 2:** Все фигуры или форматирование, добавленные в мастер‑слайд, наследуются слайдам‑раскладкам и, соответственно, всем обычным слайдам, использующим эти раскладки. На изображении ниже показано, как текстовое поле, добавленное в мастер‑слайд, автоматически отображается на конечном слайде.

![Master Inheritance Example](master-slide-banner.png)

## **Получить доступ к мастер‑слайду**

Вы можете получить доступ к мастер‑слайдам с помощью коллекции `Presentation.masters`. Ниже показано, как извлечь их и работать с ними:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # Получить доступ к первому мастер‑слайду.
        first_master_slide = presentation.masters[0]
```

## **Удалить мастер‑слайд**

Мастер‑слайды можно удалить либо по индексу, либо по ссылке.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Удалить по индексу.
        presentation.masters.remove_at(0)

        # Или удалить по ссылке.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Удалить неиспользуемые мастер‑слайды**

Некоторые презентации содержат мастер‑слайды, которые не используются. Удаление этих слайдов может помочь сократить размер файла.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Удалить все неиспользуемые мастер‑слайды (даже те, которые помечены как Preserve).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Подсказка:** Используйте `remove_unused(True)`, чтобы очистить неиспользуемые мастер‑слайды и минимизировать размер презентации.