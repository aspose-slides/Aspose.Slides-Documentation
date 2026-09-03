---
title: "Управление текстовыми блоками в презентациях с помощью Python"
linktitle: "Управление текстовым блоком"
type: docs
weight: 20
url: /ru/python-net/manage-textbox/
keywords:
- текстовый блок
- текстовый фрейм
- добавить текст
- обновить текст
- создать текстовый блок
- проверить текстовый блок
- добавить колонку текста
- добавить гиперссылку
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте, определяйте, форматируйте и обновляйте текстовые блоки в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET."
---
## **Введение**

В Aspose.Slides for Python via .NET текст слайдов хранится в текстовых фреймах, которые принадлежат фигурам. Класс [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) представляет наиболее распространённую форму, содержащую текст, и предоставляет её текст через свойство [AutoShape.text_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/text_frame/).

{{% alert color="info" title="Note" %}}
Каждая автофигура наследуется от [Shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/), но не каждая фигура является автофигурой или поддерживает текстовый фрейм. При обработке существующей презентации используйте `isinstance(shape, slides.AutoShape)`, чтобы проверить тип фигуры перед доступом к её тексту.
{{% /alert %}}

## **Создание текстового блока на слайде**

Чтобы создать текстовый блок, добавьте автофигуру на слайд, добавьте текст в её текстовый фрейм и сохраните презентацию. Следующий пример создаёт прямоугольный текстовый блок:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

Координаты и размеры, передаваемые в [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_auto_shape/), измеряются в пунктах. [AutoShape.add_text_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/add_text_frame/) инициализирует текстовый фрейм переданным текстом.

## **Проверка, является ли форма текстовым блоком**

Используйте свойство [AutoShape.is_text_box](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/is_text_box/) для определения, рассматривается ли автофигура как текстовый блок. Это полезно, когда презентация содержит как текстовые, так и чисто графические автофигуры.

![Текстовый блок и фигура](istextbox.png)

Следующий пример проверяет каждую автофигуру в презентации:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

Новодобавленная автофигура не считается текстовым блоком, пока она не содержит непустой текст. Вы можете задать этот текст через [AutoShape.add_text_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/add_text_frame/) или [TextFrame.text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/text/). Добавление или присвоение пустой строки оставляет [is_text_box](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/is_text_box/) со значением `False`:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

Первые два вызова выводят `True`; последние два — `False`.

## **Нахождение формы, которой принадлежит текстовый фрейм**

Общий код обработки текста может получать объект [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) без знания, какому объекту презентации он принадлежит. Используйте только для чтения свойство [TextFrame.parent_shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/parent_shape/), чтобы перейти к его владельцу — [Shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/).

Если текстовый фрейм принадлежит автофигуре или другой фигуре, содержащей текст, [parent_shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/parent_shape/) содержит владельца, а [TextFrame.parent_cell](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/parent_cell/) равно `None`. Проверьте возвращённое значение перед доступом к нему. Чтобы определить как владельцев фигур, так и ячеек таблиц, включая фигуры, связанные с узлами SmartArt, см. [Search and Replace Text](/slides/ru/python-net/search-and-replace-text/).

## **Добавление колонок в текстовый блок**

Свойство [TextFrameFormat.column_count](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/column_count/) делит текстовый фрейм на колонки, а [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/column_spacing/) задаёт расстояние между колонками в пунктах. Оба параметра относятся к [TextFrameFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/) и могут быть изменены через текстовый фрейм существующего текстового блока. Текст перераспределяется между колонками внутри одной формы; он не продолжается в другую форму.

Следующий пример создаёт трёхколоночный текстовый блок с 10 пунктами между колонками, сохраняет презентацию и считывает сохранённые настройки из выходного файла:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Извлечение текста из отдельных колонок**

Используйте [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/split_text_by_columns/) для получения текста, назначенного каждой визуальной колонке в существующем текстовом фрейме. Метод возвращает одну строку для каждой колонки в порядке чтения по колонкам. Текстовый фрейм с одной колонкой возвращает список из одного элемента, а пустая колонка представлена пустой строкой. Строки содержат только обычный текст; форматирование на уровне частей не сохраняется.

Это полезно, когда вам нужно:
- Извлечь текст, сохранив порядок чтения по колонкам.
- Проиндексировать или сравнить содержание слайдов с несколькими колонками.
- Экспортировать каждую колонку в отдельный файл, поле базы данных или другое место назначения.
- Проверить, как текст перераспределяется после изменения [TextFrameFormat.column_count](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/column_spacing/), шрифта или размера текстового фрейма.

Метод сообщает текст, распределённый внутри текущего [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/); он не переходит автоматически между отдельными формами или текстовыми блоками. Распределение колонок может зависеть от доступных шрифтов и других настроек макета текста, поэтому убедитесь, что необходимые шрифты доступны, когда важны согласованные результаты.

Следующий пример загружает презентацию, находит первую автофигуру с несколькими колонками и текстовым фреймом, считывает её настроенное количество колонок и записывает текст каждой колонки в отдельный файл. Фигуры без текстового фрейма пропускаются.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Обновление текста**

Чтобы обновить текст во всей презентации, пройдите по слайдам и фигурам, выберите автофигуры и затем отредактируйте их части текста. Работа на уровне частей позволяет менять как текст, так и форматирование символов.

Следующий пример заменяет каждое вхождение `years` на `months` в тексте автофигур и делает каждую затронутую часть жирной:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Этот проход обновляет текст только в автофигурах. Текст, хранящийся в таблицах, диаграммах, SmartArt или сгруппированных фигурах, требует обхода собственных коллекций этих объектов.

## **Добавление текстового блока с гиперссылкой**

Гиперссылка может быть назначена определённой части текста, поэтому только этот текст будет кликабельным. Используйте [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/ru/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) для связывания части с внешним URL.

Следующий пример создаёт связанный текст и сохраняет его в презентацию:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**What is the difference between a text box and a text placeholder on a master or layout slide?**

[placeholder](/slides/ru/python-net/manage-placeholder/) может наследовать своё положение и форматирование от [master slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/masterslide/) или [layout slide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/). Обычный текстовый блок — это независимая фигура на том слайде, где он был создан, и не получает поведения плейсхолдера при изменении макета.

**How can I replace text without changing text in charts, tables, or SmartArt?**

Ограничьте обход экземплярами [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/), как показано в примере «Update Text». Диаграммы, таблицы и SmartArt хранят текст в собственных моделях объектов, поэтому они не изменяются этим циклом.