---
title: Получить фоновое изображение всей презентации слайдов
type: docs
weight: 95
url: /python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- слайд
- фон
- фон слайда
- фон в изображение
- PowerPoint
- PPT
- PPTX
- Презентация PowerPoint
- Python
- Aspose.Slides для Python
---

В презентациях PowerPoint фон слайда может состоять из множества элементов. В дополнение к изображению, установленному в качестве [фона слайда](/slides/python-net/presentation-background/), финальный фон может зависеть от темы презентации, цветовой схемы и форм, размещенных на основном слайде и слайде макета.

Aspose.Slides для Python не предоставляет простого метода для извлечения всего фонового изображения презентации слайда, но вы можете следовать приведенным ниже шагам, чтобы сделать это:
1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите размер слайда из презентации.
1. Выберите слайд.
1. Создайте временную презентацию.
1. Установите тот же размер слайда в временной презентации.
1. Клонируйте выбранный слайд во временную презентацию.
1. Удалите фигуры с клонированного слайда.
1. Преобразуйте клонированный слайд в изображение.

Следующий пример кода извлекает фоновое изображение всей презентации слайда.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```