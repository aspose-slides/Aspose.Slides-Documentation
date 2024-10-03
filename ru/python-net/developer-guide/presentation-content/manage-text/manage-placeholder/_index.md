---
title: Управление Заполнителем
type: docs
weight: 10
url: /ru/python-net/manage-placeholder/
keywords: "Заполнитель, Текст заполнителя, Текст подсказки, Презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Изменение текста заполнителя и текста подсказки в презентациях PowerPoint на Python"
---

## **Изменить Текст в Заполнителе**

С помощью [Aspose.Slides для Python через .NET](/slides/ru/python-net/) вы можете находить и изменять заполнители на слайдах в презентациях. Aspose.Slides позволяет изменять текст в заполнителе.

**Предварительные условия**: Вам нужна презентация, содержащая заполнитель. Вы можете создать такую презентацию в стандартном приложении Microsoft PowerPoint.

Вот как вы можете использовать Aspose.Slides для замены текста в заполнителе в этой презентации:

1. Создайте экземпляр класса [`Presentation`](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и передайте презентацию в качестве аргумента.
2. Получите ссылку на слайд по его индексу.
3. Переберите фигуры, чтобы найти заполнитель.
4. Приведите фигуру заполнителя к типу [`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) и измените текст с помощью [`TextFrame`](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), связанного с [`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
5. Сохраните измененную презентацию.

Этот код на Python показывает, как изменить текст в заполнителе:

```python
import aspose.slides as slides

# Создает экземпляр класса Presentation
with slides.Presentation(path + "ReplacingText.pptx") as pres:
    # Получает доступ к первому слайду
    sld = pres.slides[0]

    # Перебирает фигуры, чтобы найти заполнитель
    for shp in sld.shapes:
        if shp.placeholder != None:
            # Изменяет текст в каждом заполнителе
            shp.text_frame.text = "Это Заполнитель"

    # Сохраняет презентацию на диск
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить Текст Подсказки в Заполнителе**
Стандартные и заранее определенные макеты содержат текст подсказки для заполнителей, такой как ***Нажмите, чтобы добавить заголовок*** или ***Нажмите, чтобы добавить подзаголовок***. С помощью Aspose.Slides вы можете вставить предпочтительные тексты подсказок в макеты заполнителей.

Этот код на Python показывает, как установить текст подсказки в заполнитель:

```python
import aspose.slides as slides

with slides.Presentation(path + "Presentation2.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.slide.shapes: # Перебирает слайд
        if shape.placeholder != None and type(shape) is slides.AutoShape:
            text = ""
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE: # PowerPoint отображает "Нажмите, чтобы добавить заголовок". 
                text = "Добавить Заголовок"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE: # Добавляет подзаголовок.
                text = "Добавить Подзаголовок"

            shape.text_frame.text = text

            print("Заполнитель с текстом: {text}".format(text = text))

    pres.save("Placeholders_PromptText.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить Прозрачность Изображения Заполнителя**

Aspose.Slides позволяет устанавливать прозрачность фона изображения в текстовом заполнителе. Регулируя прозрачность изображения в таком кадре, вы можете выделить текст или изображение (в зависимости от цветов текста и изображения).

Этот код на Python показывает, как установить прозрачность для фона изображения (внутри фигуры):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoShape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    
    autoShape.fill_format.fill_type = slides.FillType.PICTURE
    with open("image.png", "rb") as in_file:
        autoShape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(in_file)

        autoShape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        autoShape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)

```