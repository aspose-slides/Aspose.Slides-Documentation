---
title: ActiveX
type: docs
weight: 200
url: /ru/python-net/examples/elements/activex/
keywords:
- ActiveX
- Элемент управления ActiveX
- добавить ActiveX
- доступ к ActiveX
- удалить ActiveX
- Свойства ActiveX
- примеры кода
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как находить, редактировать и удалять элементы управления ActiveX в Python с помощью Aspose.Slides, включая обновление свойств для презентаций PowerPoint."
---
Продемонстрировано, как добавлять, получать доступ, удалять и настраивать элементы управления ActiveX в презентации с использованием **Aspose.Slides for Python via .NET**.

## **Добавить элемент управления ActiveX**

Вставьте новый элемент управления ActiveX.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Добавить новый элемент управления ActiveX (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **Получить доступ к элементу управления ActiveX**

Прочитайте информацию о первом элементе управления ActiveX на слайде.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Доступ к первому элементу управления ActiveX.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # Вывести имя элемента управления.
            print(f"Control Name: {control.name}")
```

## **Удалить элемент управления ActiveX**

Удалите существующий элемент управления ActiveX со слайда.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # Удалить первый элемент управления ActiveX.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **Установить свойства ActiveX**

Настройте несколько свойств ActiveX.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что коллекция Controls содержит хотя бы один элемент управления.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```