---
title: Управление текстовыми полями в презентациях с помощью Python через Java
linktitle: Управление текстовым полем
type: docs
weight: 20
url: /ru/python-java/manage-textbox/
keywords:
- текстовое поле
- текстовый фрейм
- добавить текст
- обновить текст
- создать текстовое поле
- проверить текстовое поле
- добавить столбец текста
- добавить гиперссылку
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Создавайте, определяйте, форматируйте и обновляйте текстовые поля в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для Python через Java."
---
## **Введение**

В Aspose.Slides for Python via Java текст слайда хранится в текстовых фреймах, которые принадлежат фигурам. Класс [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) представляет наиболее распространённую форму, содержащую текст, и предоставляет доступ к её тексту через метод [AutoShape.getTextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Каждая автофигура наследует класс [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/), но не каждая фигура является автофигурой или поддерживает текстовый фрейм. При обработке существующей презентации проверьте, что фигура является экземпляром [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) прежде чем получать доступ к её тексту.
{{% /alert %}}

## **Создать текстовое поле на слайде**

Чтобы создать текстовое поле, добавьте автофигуру на слайд, добавьте текст в её текстовый фрейм и сохраните презентацию. Следующий пример создаёт прямоугольное текстовое поле:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Координаты и размеры, передаваемые в [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addAutoShape), измеряются в пунктах. [AutoShape.addTextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/#addTextFrame) инициализирует текстовый фрейм переданным текстом.

## **Проверка на форму текстового поля**

Используйте метод [AutoShape.isTextBox](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/#isTextBox), чтобы определить, рассматривается ли автофигура как текстовое поле. Это полезно, когда презентация содержит как фигуры с текстом, так и чисто графические автофигуры.

![Текстовое поле и форма](istextbox.png)

Следующий пример проверяет каждую автофигуру в презентации:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

Недавно добавленная автофигура не считается текстовым полем, пока в ней нет непустого текста. Вы можете задать этот текст через [AutoShape.addTextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/#addTextFrame) или [TextFrame.setText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#setText). Добавление или присвоение пустой строки оставляет [AutoShape.isTextBox](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/#isTextBox) возвращающим `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

Первые два вызова выводят `True`; последние два — `False`.

## **Найти форму, владеющую текстовым фреймом**

Общий код обработки текста может получить объект [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) без сведения, к какому объекту презентации он относится. Используйте только для чтения метод [TextFrame.getParentShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#getParentShape), чтобы перейти к его родительской [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/).

Для текстового фрейма, принадлежащего автофигуре или другой фигуре с текстом, [TextFrame.getParentShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#getParentShape) возвращает владельца, а [TextFrame.getParentCell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#getParentCell) возвращает `None`. Проверьте возвращённое значение перед его использованием. Чтобы определить владельцев как фигур, так и ячеек таблиц, включая фигуры, связанные с узлами SmartArt, см. [Search and Replace Text](/slides/ru/python-java/search-and-replace-text/).

## **Добавить столбцы в текстовое поле**

Метод [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setColumnCount) делит текстовый фрейм на столбцы, а [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setColumnSpacing) задаёт промежуток между столбцами в пунктах. Оба параметра относятся к [TextFrameFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/) и могут быть изменены через текстовый фрейм существующего текстового поля. Текст перестраивается между столбцами внутри одной фигуры; он не переходит в другую фигуру.

Следующий пример создаёт трёхколоночное текстовое поле с 10 пунктами между столбцами, сохраняет презентацию и считывает сохранённые настройки из выходного файла:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Извлечь текст из отдельных столбцов**

Используйте [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#splitTextByColumns), чтобы получить текст, назначенный каждому визуальному столбцу в существующем текстовом фрейме. Метод возвращает одну строку для каждого столбца в порядке чтения по столбцам. Текстовый фрейм с одним столбцом возвращает массив из одного элемента, а пустой столбец представляется пустой строкой. Строки содержат только простой текст; форматирование на уровне частей не сохраняется.

Это полезно, когда нужно:

- Извлечь текст, сохраняя порядок чтения по столбцам.
- Индексировать или сравнивать содержимое слайдов с несколькими столбцами.
- Экспортировать каждый столбец в отдельный файл, поле базы данных или другое место назначения.
- Проверить, как текст перераспределяется после изменения количества столбцов с помощью [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setColumnCount), интервала с помощью [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setColumnSpacing), шрифта или размера текстового фрейма.

Метод сообщает о тексте, распределённом внутри текущего [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/); он автоматически не переносит текст между отдельными фигурами или текстовыми полями. Распределение по столбцам может зависеть от доступных шрифтов и других настроек разметки текста, поэтому убедитесь, что необходимые шрифты доступны, когда важна согласованность результатов.

Следующий пример загружает презентацию, находит первую автофигуру с несколькими столбцами и текстовым фреймом, считывает её текущий счётчик столбцов и записывает текст из каждого столбца в отдельный файл. Фигуры без текстового фрейма пропускаются.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Обновить текст**

Чтобы обновить текст по всей презентации, пройдите по слайдам и фигурам, выберите автофигуры и отредактируйте их части текста. Работа на уровне частей позволяет изменять и текст, и форматирование символов.

Следующий пример заменяет каждое вхождение `years` на `months` в тексте автофигур и делает каждую затронутую часть полужирной:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Этот обход обновляет текст только в автофигурах. Текст, хранящийся в таблицах, диаграммах, SmartArt или сгруппированных фигурах, требует обхода соответствующих коллекций этих объектов.

## **Добавить текстовое поле со ссылкой**

Гиперссылка может быть назначена конкретной части текста, поэтому только эта часть будет кликабельной. Используйте [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/ru/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), чтобы связать часть с внешним URL.

Следующий пример создаёт связанный текст и сохраняет его в презентацию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**В чём разница между текстовым полем и заполнительным текстом на слайде‑мастере или макете?**

[Заполнитель](/slides/ru/python-java/manage-placeholder/) может наследовать своё положение и форматирование от [слайда‑мастера](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/) или [слайда‑макета](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/). Обычное текстовое поле — это независимая фигура на том слайде, где оно было создано, и не приобретает поведения заполнителя при изменении макета.

**Как заменить текст, не изменяя его в диаграммах, таблицах или SmartArt?**

Ограничьте обход фигурами, которые являются экземплярами [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/), как показано в примере «Обновить текст». Диаграммы, таблицы и SmartArt хранят текст в собственных моделях объектов, поэтому они не изменяются этим циклом.