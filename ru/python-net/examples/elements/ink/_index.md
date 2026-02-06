---
title: Чернила
type: docs
weight: 180
url: /ru/python-net/examples/elements/ink/
keywords:
  - чернила
  - доступ к чернилам
  - удалить чернила
  - примеры кода
  - PowerPoint
  - OpenDocument
  - презентация
  - Python
  - Aspose.Slides
description: "Работайте с цифровыми чернилами на слайдах в Python с помощью Aspose.Slides: добавляйте штрихи пера, редактируйте пути, задавайте цвет и ширину, а также экспортируйте результаты в PowerPoint и OpenDocument."
---
Предоставляет примеры доступа к существующим чернильным фигурам и их удаления с использованием **Aspose.Slides for Python via .NET**.

> ❗ **Примечание:** Чернильные фигуры представляют ввод пользователя со специализированных устройств. Aspose.Slides не может программно создавать новые чернильные штрихи, но вы можете читать и изменять существующие чернильные фигуры.

## **Доступ к чернилу**

Получить первую чернильную фигуру со слайда.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Удалить чернила**

Удалить чернильную фигуру со слайда.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что первая фигура является объектом Ink.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```