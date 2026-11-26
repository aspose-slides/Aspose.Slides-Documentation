---
title: Управление элементами ActiveX в презентациях с помощью Python
linktitle: ActiveX
type: docs
weight: 80
url: /ru/python-java/activex/
keywords:
- ActiveX
- элемент управления ActiveX
- управление ActiveX
- добавление ActiveX
- модификация ActiveX
- медиаплеер
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Редактировать текстовые поля и кнопки ActiveX, обновлять превью элементов управления и повторно использовать элемент Windows Media Player в презентациях PowerPoint с Aspose.Slides for Python via Java."
---
## **Введение**

Элементы управления ActiveX предоставляют слайду PowerPoint интерактивные элементы, такие как текстовые поля, кнопки команд и медиаплееры. Aspose.Slides for Python via Java предоставляет доступ к элементам управления слайда через [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). Используйте эту коллекцию, чтобы изменить элемент управления, переместить его на слайде или удалить его.

## **Список ActiveX‑элементов управления и их сохранённых свойств**

Чтобы изучить незнакомый шаблон, откройте его для чтения и пройдитесь по элементам управления на каждом слайде. Пример выводит номер слайда, имя элемента управления, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId), а также каждую пару ключ‑значение из [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). Он читает презентацию без активации элементов управления, вызова событий или макросов, изменения значений и сохранения файла.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
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

Пустая коллекция свойств отображается как `[]`. Для элементов управления, использующих бинарное хранилище, [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) может возвращать `None`, отображаемое как `Properties unavailable`. Если нужны только имена, используйте [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties), проверив предварительно доступность коллекции. Отчёт перечисляет свойства, доступные в презентации. Элемент управления может поддерживать дополнительные свойства во время выполнения.

## **Изменение ActiveX‑элементов управления**

В примере ожидается презентация с поддержкой макросов, содержащая текстовое поле `TextBox1` и кнопку команды `CommandButton1` на первом слайде. Он использует [коллекцию свойств элемента управления](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) чтобы изменить значение текстового поля и подпись кнопки. Каждый элемент управления также имеет статический предварительный просмотр, который PowerPoint может показывать до активации. Предоставьте PNG‑изображение для каждого элемента управления, демонстрирующее обновлённый текст и внешний вид. Пример назначает эти изображения через [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

Пример перемещает каждый элемент управления на первом слайде вниз на 100 пунктов, задавая его кадр с помощью [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). Он сохраняет отредактированную презентацию в формате PPTM, затем использует [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) чтобы сохранить вторую копию без всех ActiveX‑элементов управления на этом слайде.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **Добавление ActiveX‑элемента управления медиаплеером**

Чтобы повторно использовать настроенный элемент управления Windows Media Player, начните с шаблона, первый слайд которого содержит плеер с именем `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) копирует весь слайд в новую презентацию. Пример задаёт `URL` плеера в его [коллекцию свойств](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) и сохраняет клонированный слайд единственным слайдом в выводе. Видео остаётся внешним, поэтому укажите путь, к которому плеер может получить доступ во время воспроизведения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **Вопросы и ответы**

**Может ли Aspose.Slides сохранять ActiveX‑элементы управления без их выполнения?**

Да. Aspose.Slides может читать и сохранять элементы управления, включая их свойства и позиции, без их активации.

**Чем отличаются ActiveX‑элементы управления от OLE‑объектов?**

Элементы управления ActiveX позволяют пользователям взаимодействовать со слайдом, например вводить текст или нажимать кнопку. [OLE объект](/slides/ru/python-java/manage-ole/) позволяет слайду содержать или ссылаться на контент, управляемый другим приложением, например лист Excel.

**Будут ли события ActiveX по‑прежнему вызывать макросы VBA после сохранения презентации с помощью Aspose.Slides?**

Сохраните презентацию в формате с поддержкой макросов, например PPTM, чтобы сохранить её проект VBA. PowerPoint для Windows может выполнять существующие обработчики событий, если настройки безопасности позволяют использовать как ActiveX‑элементы управления, так и макросы.