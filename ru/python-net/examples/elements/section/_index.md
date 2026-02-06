---
title: Раздел
type: docs
weight: 90
url: /ru/python-net/examples/elements/section/
keywords:
- раздел
- раздел слайда
- добавить раздел
- доступ к разделу
- удалить раздел
- переименовать раздел
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Управляйте разделами слайдов в Python с помощью Aspose.Slides: создавайте, переименовывайте, легко переупорядочивайте, перемещайте слайды между разделами и контролируйте их видимость для PPT, PPTX и ODP."
---
Примеры управления разделами презентации — добавление, доступ, удаление и переименование их программно с помощью **Aspose.Slides for Python via .NET**.

## **Добавить раздел**

Создайте раздел, начинающийся с определённого слайда.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Добавьте новый раздел и укажите слайд, обозначающий начало раздела.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к разделу**

Получите раздел из презентации.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Доступ к разделу по индексу.
        section = presentation.sections[0]
```

## **Удалить раздел**

Удалите ранее добавленный раздел.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Удалить раздел.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Переименовать раздел**

Измените имя существующего раздела.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Переименовать раздел.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```