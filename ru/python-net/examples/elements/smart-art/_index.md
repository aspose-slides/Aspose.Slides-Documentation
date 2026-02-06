---
title: SmartArt
type: docs
weight: 140
url: /ru/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- добавить SmartArt
- доступ к SmartArt
- удалить SmartArt
- макет SmartArt
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Создавайте и редактируйте SmartArt в Python с помощью Aspose.Slides: добавляйте узлы, изменяйте макеты и стили, преобразовывайте в фигуры с точностью и экспортируйте в PPT, PPTX и ODP."
---
Показано, как добавлять графику SmartArt, получать к ней доступ, удалять её и изменять макеты с помощью **Aspose.Slides for Python via .NET**.

## **Добавить SmartArt**

Вставьте графику SmartArt, используя один из встроенных макетов.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к SmartArt**

Получите первый объект SmartArt на слайде.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Доступ к первой фигуре SmartArt.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **Удалить SmartArt**

Удалите объект SmartArt со слайда.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что первая фигура является объектом SmartArt.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменить макет SmartArt**

Обновите тип макета существующей графики SmartArt.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что первая фигура является объектом SmartArt.
        smart_art = slide.shapes[0]

        # Изменить макет SmartArt.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```