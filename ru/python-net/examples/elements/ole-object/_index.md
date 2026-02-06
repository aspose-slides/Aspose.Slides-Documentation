---
title: OLE объект
type: docs
weight: 210
url: /ru/python-net/examples/elements/ole-object/
keywords:
- OLE объект
- добавить OLE объект
- доступ к OLE объекту
- удалить OLE объект
- обновить OLE объект
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Работа с OLE объектами в Python с использованием Aspose.Slides: вставка или обновление встроенных файлов, установка значков или ссылок, извлечение содержимого, управление поведением для PPT, PPTX и ODP."
---
Продемонстрировано внедрение файла в виде OLE‑объекта и обновление его данных с использованием **Aspose.Slides for Python via .NET**.

## **Добавить OLE объект**

Внедрить PDF‑файл в презентацию.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Загрузить данные PDF для внедрения.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Добавить кадр OLE объекта на слайд.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Получить OLE объект**

Получить первый кадр OLE‑объекта на слайде.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Получить первый кадр OLE объекта на слайде.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Удалить OLE объект**

Удалить внедрённый OLE‑объект со слайда.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что первая shape является объектом OleObjectFrame.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Обновить данные OLE объекта**

Заменить данные, внедрённые в существующий OLE‑объект.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что первая shape является объектом OleObjectFrame.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Обновить OLE объект новыми встроенными данными.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```