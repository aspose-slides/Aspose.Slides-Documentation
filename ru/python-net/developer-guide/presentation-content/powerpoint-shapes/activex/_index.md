---
title: Управление элементами ActiveX в презентациях с помощью Python
linktitle: ActiveX
type: docs
weight: 80
url: /ru/python-net/activex/
keywords:
- ActiveX
- элемент управления ActiveX
- управление ActiveX
- добавление ActiveX
- изменение ActiveX
- медиаплеер
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Редактировать текстовые поля и кнопки ActiveX, обновлять предварительные просмотры элементов управления и повторно использовать элемент Windows Media Player в презентациях PowerPoint с помощью Aspose.Slides for Python через .NET."
---
## **Введение**

ActiveX‑элементы управления предоставляют слайду PowerPoint интерактивные элементы, такие как текстовые поля, кнопки команд и медиаплееры. Aspose.Slides for Python via .NET предоставляет доступ к элементам управления слайда через [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/). Используйте эту коллекцию, чтобы изменить элемент управления, переместить его на слайде или удалить его.

## **Список ActiveX‑элементов управления и их сохранённых свойств**

Чтобы проанализировать незнакомый шаблон, откройте его для чтения и пройдитесь по элементам управления на каждом слайде. Пример выводит номер слайда, имя элемента управления, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/), и каждую пару «ключ‑значение» в [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties). Презентация читается без активации элементов управления, без вызова событий или макросов, без изменения значений и без сохранения файла.

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
```

Выбранный вывод из `ActiveX.pptm` показывает текстовое поле и кнопку команды.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Пустая коллекция свойств отображается как `[]`. Для элементов управления, использующих бинарное хранение, `properties` может возвращать `None`, что отображается как `Properties unavailable`. Если нужны только имена, используйте [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) после проверки на `None`. В отчёте перечислены свойства, доступные из презентации. Элемент управления может поддерживать дополнительные свойства во время выполнения.

## **Изменение ActiveX‑элементов управления**

Пример предполагает презентацию с поддержкой макросов, содержащую текстовое поле с именем `TextBox1` и кнопку команды с именем `CommandButton1` на первом слайде. Он использует [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) для изменения значения текстового поля и подписи кнопки. Каждый элемент управления также имеет статический предварительный просмотр, который PowerPoint может отобразить до активации. Предоставьте PNG‑файл для каждого элемента, показывающий обновлённый текст и внешний вид. Пример назначает эти изображения через [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/).

Пример перемещает каждый элемент управления на первом слайде вниз на 100 пунктов, изменяя его [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/). Затем он сохраняет отредактированную презентацию в формате PPTM, после чего использует [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) для сохранения второй копии без всех ActiveX‑элементов управления на этом слайде.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **Добавление элемента управления ActiveX Media Player**

Чтобы повторно использовать настроенный элемент Windows Media Player, начните с шаблона, у которого первый слайд содержит плеер с именем `WindowsMediaPlayer1`. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) копирует весь слайд в новую презентацию. Пример задаёт `URL` плеера в его [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) и сохраняет склонированный слайд единственным слайдом в выводе. Видео остаётся внешним, поэтому укажите путь, доступный плееру во время воспроизведения.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Может ли Aspose.Slides сохранять ActiveX‑элементы управления без их выполнения?**

Да. Aspose.Slides может читать и сохранять элементы управления, включая их свойства и позиции, без их активации.

**Чем отличаются ActiveX‑элементы управления от OLE‑объектов?**

ActiveX‑элементы управления позволяют пользователям взаимодействовать со слайдом, например вводить текст или нажимать кнопку. [OLE object](/slides/ru/python-net/manage-ole/) позволяет слайду содержать или ссылаться на контент, управляемый другим приложением, например лист Excel.

**Будут ли события ActiveX по‑прежнему запускать макросы VBA после сохранения презентации с помощью Aspose.Slides?**

Сохраните презентацию в формате, поддерживающем макросы, например PPTM, чтобы сохранить её проект VBA. PowerPoint для Windows может выполнять существующие обработчики событий, если параметры безопасности позволяют работу как ActiveX‑элементов управления, так и макросов.