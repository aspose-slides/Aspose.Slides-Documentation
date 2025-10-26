---
title: Manage Text Boxes in Presentations with Python
linktitle: Manage Text Box
type: docs
weight: 20
url: /ru/python-net/developer-guide/presentation-content/manage-text/manage-textbox/
keywords:
- text box
- text frame
- add text
- update text
- create text box
- check text box
- add text column
- add hyperlink
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET makes it easy to create, edit, and clone text boxes in PowerPoint and OpenDocument files, enhancing your presentation automation."
---

## **Обзор**

Текст на слайдах обычно находится в текстовых полях или фигурах. Поэтому, чтобы добавить текст на слайд, необходимо добавить текстовое поле, а затем поместить текст внутрь этого поля. Aspose.Slides for Python предоставляет класс [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), который позволяет добавить фигуру, содержащую текст.

{{% alert title="Информация" color="info" %}}

Aspose.Slides также предоставляет класс [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/). Однако не все фигуры могут содержать текст.

{{% /alert %}}

{{% alert title="Примечание" color="warning" %}}

Поэтому, когда вы работаете с фигурой, в которую хотите добавить текст, рекомендуется проверить и убедиться, что она была приведена к классу [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Только тогда вы сможете работать с [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), который является свойством класса [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). См. раздел [Update Text](/slides/ru/python-net/manage-textbox/#update-text) на этой странице.

{{% /alert %}}

## **Создание текстовых полей на слайдах**

Чтобы создать текстовое поле на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на первый слайд.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа `ShapeType.RECTANGLE` в нужном месте на слайде.
4. Установите текст в свойстве [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) фигуры.
5. Сохраните презентацию в файл PPTX.

Ниже приведён пример на Python, реализующий эти шаги:

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide in the presentation.
    slide = presentation.slides[0]

    # Add an AutoShape of type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Save the presentation to disk.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Проверка, является ли фигура текстовым полем**

Aspose.Slides предоставляет свойство [is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/) класса [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), которое позволяет определить, является ли фигура текстовым полем.

![Text box and shape](istextbox.png)

Этот пример на Python показывает, как проверить, было ли создано фигуру как текстовое поле:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Обратите внимание, что если вы добавляете [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) с помощью класса [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/), свойство `is_text_box` возвращает `False`. Однако после добавления текста — либо методом `add_text_frame`, либо установкой свойства `text` — `is_text_box` возвращает `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box is false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box is true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box is false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box is true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box is false
    shape3.add_text_frame("")
    # shape3.is_text_box is false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box is false
    shape4.text_frame.text = ""
    # shape4.is_text_box is false
```

## **Добавление столбцов к текстовым полям**

Aspose.Slides предоставляет свойства [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/) и [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/) класса [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/), позволяющие добавить столбцы к текстовым полям. Вы можете задать количество столбцов и установить интервал (в пунктах) между ними.

Ниже показан код на Python, реализующий эту функцию:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Get the first slide in the presentation.
	slide = presentation.slides[0]

	# Add an AutoShape of type RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Add a TextFrame to the rectangle.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Get the text format of the TextFrame.
	format = shape.text_frame.text_frame_format

	# Specify the number of columns in the TextFrame.
	format.column_count = 3

	# Specify the spacing between columns.
	format.column_spacing = 10

	# Save the presentation.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Обновление текста**

Aspose.Slides позволяет обновлять текст в отдельном текстовом поле или во всей презентации.

Ниже пример на Python, показывающий, как обновить весь текст в презентации:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # Save the modified presentation.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление текстовых полей с гиперссылками**

Вы можете вставить ссылку в текстовое поле. При клике по полю ссылка откроется.

Чтобы добавить текстовое поле, содержащее гиперссылку, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на первый слайд.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа `ShapeType.RECTANGLE` в нужном месте на слайде.
4. Установите текст в свойстве [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) фигуры.
5. Получите ссылку на [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/).
6. Используйте свойство `hyperlink_manager` для задания внешней гиперссылки по клику.
7. Сохраните презентацию в файл PPTX.

Этот пример на Python показывает, как добавить текстовое поле с гиперссылкой на слайд:

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide in the presentation.
    slide = presentation.slides[0]

    # Add an AutoShape of type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Add text to the frame.
    text_portion.text = "Aspose.Slides"

    # Set a hyperlink for the portion text.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Save the presentation as a PPTX file.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Вопросы и ответы**

**В чём разница между текстовым полем и заполняющим текстом (placeholder) при работе с макетами слайдов?**

[Заполнитель](/slides/ru/python-net/manage-placeholder/) наследует стиль/позицию от [мастера](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) и может быть переопределён на [макетах](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), тогда как обычное текстовое поле — это независимый объект на конкретном слайде и не меняется при переключении макетов.

**Как выполнить массовую замену текста во всей презентации, не затрагивая текст внутри диаграмм, таблиц и SmartArt?**

Ограничьте итерацию авто‑фигурами, у которых есть TextFrame, и исключите встроенные объекты ([диаграммы](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), [таблицы](https://reference.aspose.com/slides/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)), обходя их коллекции отдельно или пропуская эти типы объектов.