---
title: Гиперссылка
type: docs
weight: 130
url: /ru/python-net/examples/elements/hyperlink/
keywords:
- гиперссылка
- добавить гиперссылку
- доступ к гиперссылке
- удалить гиперссылку
- обновить гиперссылку
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Добавляйте, редактируйте и удаляйте гиперссылки в Python с Aspose.Slides: связывайте текст, фигуры, слайды, URL-адреса и электронную почту; задавайте цели и действия для PPT, PPTX и ODP."
---
Показывает, как добавлять, получать доступ, удалять и обновлять гиперссылки на фигурах с помощью **Aspose.Slides for Python via .NET**.

## **Добавить гиперссылку**

Создайте прямоугольную фигуру с гиперссылкой, указывающей на внешний веб‑сайт.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к гиперссылке**

Считайте информацию о гиперссылке из текстовой части фигуры.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Удалить гиперссылку**

Очистите гиперссылку из текста фигуры.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Обновить гиперссылку**

Измените цель существующей гиперссылки. Используйте `HyperlinkManager` для изменения текста, уже содержащего гиперссылку, что имитирует безопасное обновление гиперссылок в PowerPoint.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Изменение гиперссылки внутри существующего текста должно выполняться через
        # HyperlinkManager вместо прямой установки свойства.
        # Это имитирует способ, которым PowerPoint безопасно обновляет гиперссылки.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```