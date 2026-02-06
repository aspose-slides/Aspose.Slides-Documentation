---
title: Текстовое поле
type: docs
weight: 40
url: /ru/python-net/examples/elements/text-box/
keywords:
- текстовое поле
- добавить текстовое поле
- доступ к текстовому полю
- удалить текстовое поле
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Создавайте и форматируйте текстовые поля в Python с Aspose.Slides: задавайте шрифты, выравнивание, перенос, авторазмер, а также ссылки для улучшения слайдов в PowerPoint и OpenDocument."
---
В Aspose.Slides **текстовое поле** представлено объектом `AutoShape`. Практически любая форма может содержать текст, но обычное текстовое поле не имеет заливки и обводки и отображает только текст.

Это руководство объясняет, как программно добавлять, получать доступ к и удалять текстовые поля.

## **Добавить текстовое поле**

Текстовое поле — это просто `AutoShape` без заливки и обводки и с некоторым форматированным текстом. Вот как его создать:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Создать прямоугольную форму (по умолчанию заполнена границей и без текста).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Удалить заливку и границу, чтобы он выглядел как типичное текстовое поле.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Установить форматирование текста.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Задать фактическое текстовое содержимое.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Примечание:** Любой `AutoShape`, содержащий непустой `TextFrame`, может функционировать как текстовое поле.

## **Получить доступ к текстовым полям по содержимому**

Чтобы найти все текстовые поля, содержащие определённое ключевое слово (например, "Slide"), пройдитесь по всем формам и проверьте их текст:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Только AutoShape могут содержать редактируемый текст.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Сделать что-либо с найденным текстовым полем.
                    pass
```

## **Удалить текстовые поля по содержимому**

Этот пример находит и удаляет все текстовые поля на первом слайде, содержащие определённое ключевое слово:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Найдите формы для удаления, которые являются AutoShape и содержат слово "Slide".
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Удалить каждую подходящую форму со слайда.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Совет:** Всегда создавайте копию коллекции фигур перед её изменением во время итерации, чтобы избежать ошибок изменения коллекции.