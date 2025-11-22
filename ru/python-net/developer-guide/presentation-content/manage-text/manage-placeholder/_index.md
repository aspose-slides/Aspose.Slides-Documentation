---
title: Управление заполнителями в презентациях с помощью Python
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/python-net/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- заполнитель изображения
- заполнитель диаграммы
- текст подсказки
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Легко управлять заполнителями в Aspose.Slides для Python через .NET: заменять текст, настраивать подсказки и задавать прозрачность изображений в PowerPoint и OpenDocument."
---

## **Обзор**

Заполнители определяют зарезервированные области на мастерах, макетах и слайдах — такие как заголовок, основное содержание, изображение, диаграмма, дата/время, номер слайда и нижний колонтитул — которые контролируют, куда помещается контент и как он наследует форматирование. С помощью Aspose.Slides для Python вы можете обнаружить заполнители на слайде, его макете или мастере, проверив, что `shape.placeholder` не равно `None`, изучив `placeholder.type`, а затем считать или изменить связанное содержимое и форматирование. API позволяет добавить новые заполнители в мастер или макет, чтобы они распространялись на дочерние слайды, перемещать и изменять размер существующих, преобразовать заполнитель в обычную форму, когда требуется полный контроль, или удалить его для упрощения дизайна. Приведённые ниже примеры показывают, как перечислить заполнители, обновить текст и стиль, а также поддерживать согласованность макетов, применяя изменения на соответствующем уровне.

## **Изменение текста в заполнителях**

С помощью Aspose.Slides для Python вы можете находить и изменять заполнители на слайдах презентации. Aspose.Slides позволяет изменять текст в заполнитель.

**Prerequisite:** Вам нужна презентация, содержащая заполнитель. Вы можете создать такую презентацию в Microsoft PowerPoint.

Это как использовать Aspose.Slides для замены текста в заполнитель:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и передайте презентацию в качестве аргумента.  
2. Получите ссылку на слайд по его индексу.  
3. Итерируйте формы, чтобы найти заполнитель.  
4. Измените текст, используя [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) связанную с [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).  
5. Сохраните изменённую презентацию.

Этот код Python показывает, как изменить текст в заполнитель:
```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # Получите первый слайд.
    slide = presentation.slides[0]

    # Переберите фигуры, чтобы найти заполнители.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # Измените текст в каждом заполняющем элементе.
            shape.text_frame.text = "This is Placeholder"

    # Сохраните презентацию на диск.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка текста‑подсказки для заполнителя**

Стандартные и готовые макеты включают текст‑подсказки заполнителей, такие как **Click to add a title** или **Click to add a subtitle**. С помощью Aspose.Slides вы можете заменить эти подсказки собственным текстом в макетах заполнителей.

Следующий пример Python показывает, как установить текст‑подсказку для заполнителя:
```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # Переберите формы, чтобы найти заполнители.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка прозрачности изображения в заполнитель**

Aspose.Slides позволяет установить прозрачность фонового изображения в текстовом заполнителе. Регулируя прозрачность картинки в этом кадре, вы можете выделять либо текст, либо изображение, в зависимости от их цветов.

Следующий пример Python показывает, как установить прозрачность фонового изображения внутри формы:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```


## **FAQ**

**Что такое базовый заполнитель и чем он отличается от локальной формы на слайде?**

Базовый заполнитель — это оригинальная форма на макете или мастере, от которой наследуется форма слайда — тип, позиция и часть форматирования берутся из него. Локальная форма — независимая; если базового заполнителя нет, наследование не применяется.

**Как обновить все заголовки или подписи во всей презентации без перебора каждого слайда?**

Отредактируйте соответствующий заполнитель на макете или мастере. Слайды, основанные на этих макетах/мастере, автоматически унаследуют изменение.

**Как управлять стандартными заполнителями верхнего/нижнего колонтитула — датой и временем, номером слайда и текстом нижнего колонтитула?**

Используйте менеджеры HeaderFooter в нужном объёме (обычные слайды, макеты, мастер, заметки/раздатки), чтобы включать или отключать эти заполнители и задавать их содержимое.