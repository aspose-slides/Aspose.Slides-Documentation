---
title: Управление текстовыми полями в презентациях с помощью Python
linktitle: Управление текстовым полем
type: docs
weight: 20
url: /ru/python-net/manage-textbox/
keywords:
- текстовое поле
- текстовая рамка
- добавить текст
- обновить текст
- создать текстовое поле
- проверить текстовое поле
- добавить колонку текста
- добавить гиперссылку
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET упрощает создание, редактирование и клонирование текстовых полей в файлах PowerPoint и OpenDocument, расширяя возможности автоматизации ваших презентаций."
---

## **Обзор**

Текст на слайдах обычно находится в текстовых полях или фигурах. Поэтому, чтобы добавить текст на слайд, необходимо добавить текстовое поле, а затем поместить в него текст. Aspose.Slides for Python предоставляет класс [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), позволяющий добавить фигуру, содержащую текст.

{{% alert title="Информация" color="info" %}}

Aspose.Slides также предоставляет класс [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/). Однако не все фигуры могут содержать текст.

{{% /alert %}}

{{% alert title="Примечание" color="warning" %}}

Поэтому, когда вы работаете с фигурой, в которую хотите добавить текст, рекомендуется проверить, что она была приведена к классу [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Только тогда вы сможете работать с [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), который является свойством [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). См. раздел [Обновление текста](/slides/ru/python-net/manage-textbox/#update-text) на этой странице.

{{% /alert %}}

## **Создание текстовых полей на слайдах**

Чтобы создать текстовое поле на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на первый слайд.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) с `ShapeType.RECTANGLE` в нужное положение на слайде.
4. Установите текст в свойстве [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) фигуры.
5. Сохраните презентацию как файл PPTX.

Ниже приведён пример на Python, реализующий эти шаги:

```py
import aspose.slides as slides

# Создайте объект класса Presentation.
with slides.Presentation() as presentation:

    # Получите первый слайд в презентации.
    slide = presentation.slides[0]

    # Добавьте AutoShape типа RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Сохраните презентацию на диск.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Проверка, является ли фигура текстовым полем**

Aspose.Slides предоставляет свойство [is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/) в классе [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), позволяющее определить, является ли фигура текстовым полем.

![Текстовое поле и фигура](istextbox.png)

Этот пример на Python показывает, как проверить, было ли фигура создана как текстовое поле:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Обратите внимание, что если вы добавляете [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) с помощью класса [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/), свойство `is_text_box` у фигуры возвращает `False`. Однако после добавления текста — либо методом `add_text_frame`, либо установкой свойства `text` — `is_text_box` возвращает `True`.

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

## **Добавление столбцов в текстовые поля**

Aspose.Slides предоставляет свойства [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/) и [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/) в классе [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/), позволяющие добавить столбцы в текстовые поля. Вы можете указать количество столбцов и задать расстояние (в пунктах) между ними.

Ниже показан код на Python, демонстрирующий эту операцию:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Получите первый слайд в презентации.
	slide = presentation.slides[0]

	# Добавьте AutoShape типа RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Добавьте TextFrame к прямоугольнику.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Получите формат текста TextFrame.
	format = shape.text_frame.text_frame_format

	# Укажите количество столбцов в TextFrame.
	format.column_count = 3

	# Укажите расстояние между столбцами.
	format.column_spacing = 10

	# Сохраните презентацию.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Обновление текста**

Aspose.Slides позволяет обновлять текст в одном текстовом поле или во всей презентации.

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
  
    # Сохраните изменённую презентацию.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление текстовых полей с гиперссылками** 

Можно вставить ссылку в текстовое поле. При щелчке по полю ссылка открывается.

Чтобы добавить текстовое поле, содержащее гиперссылку, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на первый слайд.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) с `ShapeType.RECTANGLE` в нужное положение на слайде.
4. Установите текст в свойстве [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) фигуры.
5. Получите ссылку на [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/).
6. Используйте свойство `hyperlink_manager`, чтобы задать внешнюю гиперссылку по щелчку.
7. Сохраните презентацию как файл PPTX.

Этот пример на Python показывает, как добавить текстовое поле с гиперссылкой на слайд:

```py
import aspose.slides as slides

# Создайте объект класса Presentation.
with slides.Presentation() as presentation:

    # Получите первый слайд в презентации.
    slide = presentation.slides[0]

    # Добавьте AutoShape типа RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Добавьте текст в фрейм.
    text_portion.text = "Aspose.Slides"

    # Установите гиперссылку для текста части.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Сохраните презентацию как файл PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**В чём разница между текстовым полем и заполнителем текста при работе с главными слайдами?**

[Заполнитель](/slides/ru/python-net/manage-placeholder/) наследует стиль/позицию от [главного слайда](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) и может быть переопределён на [макетах](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), тогда как обычное текстовое поле является независимым объектом на конкретном слайде и не меняется при переключении макетов.

**Как выполнить массовую замену текста во всей презентации, не затрагивая текст внутри диаграмм, таблиц и SmartArt?**

Ограничьте итерацию автофигурами, имеющими текстовые кадры, и исключите встроенные объекты ([диаграммы](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), [таблицы](https://reference.aspose.com/slides/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)), проходя их коллекции отдельно или пропуская такие типы объектов.