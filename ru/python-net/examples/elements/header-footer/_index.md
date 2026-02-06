---
title: Заголовок и Нижний колонтитул
type: docs
weight: 220
url: /ru/python-net/examples/elements/header-footer/
keywords:
- заголовок и нижний колонтитул
- добавить заголовок и нижний колонтитул
- обновить заголовок и нижний колонтитул
- установить дату и время
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Управляйте заголовками и нижними колонтитулами в Python с помощью Aspose.Slides: добавляйте или редактируйте дату/время, номера слайдов и текст нижнего колонтитула, отображайте или скрывайте заполнители в PPT, PPTX и ODP."
---
Показывает, как добавить нижние колонтитулы и обновить заполнители даты и времени, используя **Aspose.Slides for Python via .NET**.

## **Добавить нижний колонтитул**

Добавьте текст в область нижнего колонтитула слайда и сделайте его видимым.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Обновить дату и время**

Измените заполнитель даты и времени на слайде.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```