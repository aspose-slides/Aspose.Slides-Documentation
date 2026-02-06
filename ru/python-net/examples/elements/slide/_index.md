---
title: Слайд
type: docs
weight: 10
url: /ru/python-net/examples/elements/slide/
keywords:
- слайд
- добавить слайд
- доступ к слайду
- индекс слайда
- клонировать слайд
- переупорядочить слайды
- удалить слайд
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Управляйте слайдами в Python с помощью Aspose.Slides: создавайте, клонируйте, переупорядочивайте, скрывайте, задавайте фон и размер, применяйте переходы и экспортируйте для PowerPoint и OpenDocument."
---
В этой статье представлена серия примеров, демонстрирующих работу со слайдами с использованием **Aspose.Slides for Python via .NET**. Вы узнаете, как добавлять, получать доступ, копировать, переупорядочивать и удалять слайды с помощью класса `Presentation`.

Каждый пример ниже содержит краткое объяснение, за которым следует фрагмент кода на Python.

## **Добавить слайд**

Чтобы добавить новый слайд, сначала необходимо выбрать макет. В этом примере мы используем макет `Blank` и добавляем пустой слайд в презентацию.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # Каждый слайд основан на макете, который сам основан на главном слайде.
        # Используйте макет Blank для создания нового слайда.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Добавьте новый пустой слайд, используя выбранный макет.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Подсказка:** Каждый макет слайда наследуется от главного слайда, который определяет общий дизайн и структуру заполнителей. На изображении ниже показано, как главные слайды и связанные с ними макеты организованы в PowerPoint.

![Отношения главного слайда и макетов](master-layout-slide.png)

## **Доступ к слайдам по индексу**

Вы можете получать доступ к слайдам, используя их индекс. Это полезно для перебора или изменения конкретных слайдов.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # Получить доступ к слайду по индексу.
        first_slide = presentation.slides[0]
```

## **Клонировать слайд**

В этом примере демонстрируется, как клонировать существующий слайд. Клонированный слайд автоматически добавляется в конец коллекции слайдов.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Склонировать слайд; он будет добавлен в конец презентации.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **Переупорядочить слайды**

Вы можете изменить порядок слайдов, переместив один на новый индекс. В данном случае мы перемещаем слайд на первую позицию.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # Переместить слайд на первую позицию (остальные сдвигаются вниз).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **Удалить слайд**

Чтобы удалить слайд, просто укажите его и вызовите `remove`. В этом примере удаляется первый слайд.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Удалить слайд.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```