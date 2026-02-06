---
title: Макетный слайд
type: docs
weight: 20
url: /ru/python-net/examples/elements/layout-slide/
keywords:
- макетный слайд
- добавить макетный слайд
- получить доступ к макетному слайду
- удалить макетный слайд
- неиспользуемый макетный слайд
- клонировать макетный слайд
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Используйте Python для управления макетными слайдами с помощью Aspose.Slides: создавайте, применяйте, клонируйте, переименовывайте и настраивайте заполнители и темы в презентациях для форматов PPT, PPTX и ODP."
---
Эта статья демонстрирует, как работать с **Layout Slides** в Aspose.Slides for Python via .NET. Макетный слайд определяет дизайн и форматирование, которые наследуются обычными слайдами. Вы можете добавлять, получать доступ, клонировать и удалять макетные слайды, а также очищать неиспользуемые, чтобы уменьшить размер презентации.

## **Добавить макетный слайд**

Вы можете создать пользовательский макетный слайд для определения повторно используемого форматирования.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Создайте макетный слайд с указанным типом и именем.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Подсказка 1:** Макетные слайды служат шаблонами для отдельных слайдов. Вы можете определить общие элементы один раз и повторно использовать их на многих слайдах.

> 💡 **Подсказка 2:** Когда вы добавляете фигуры или текст в макетный слайд, все слайды, основанные на этом макете, автоматически отображают этот общий контент.
> На скриншоте ниже показаны два слайда, каждый из которых наследует текстовое поле из одного и того же макетного слайда.

![Слайды, наследующие содержимое макета](layout-slide-result.png)


## **Получить доступ к макетному слайду**

К макетным слайдам можно получить доступ по индексу или по типу макета (например, `Blank`, `Title`, `SectionHeader` и т.д.).

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Доступ по индексу.
        first_layout_slide = presentation.layout_slides[0]

        # Доступ по типу макета.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Удалить макетный слайд**

Вы можете удалить конкретный макетный слайд, если он больше не нужен.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Получить макетный слайд по типу и удалить его.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Удалить неиспользуемые макетные слайды**

Чтобы уменьшить размер презентации, возможно, понадобится удалить макетные слайды, которые не используются никакими обычными слайдами.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Автоматически удаляет все макетные слайды, на которые не ссылаются никакие слайды.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонировать макетный слайд**

Вы можете дублировать макетный слайд, используя метод `AddClone`.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Получить существующий макетный слайд по типу.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Клонировать макетный слайд в конец коллекции макетных слайдов.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Итог:** Макетные слайды являются мощным инструментом для управления согласованным форматированием на всех слайдах. Aspose.Slides предоставляет полный контроль над созданием, управлением и оптимизацией макетных слайдов.