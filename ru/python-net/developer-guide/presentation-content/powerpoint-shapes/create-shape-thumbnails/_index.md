---
title: Создание миниатюр фигур презентации в Python
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/python-net/developer-guide/presentation-content/powerpoint-shapes/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- рендер фигуры
- визуализация фигуры
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте высококачественные миниатюры фигур из слайдов PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET – легко генерируйте и экспортируйте миниатюры презентаций."
---

## **Введение**

Aspose.Slides for Python via .NET используется для создания файлов презентаций, где каждая страница представляет собой слайд. Вы можете просматривать эти слайды в Microsoft PowerPoint, открыв файл презентации. Однако иногда разработчикам требуется просматривать изображения фигур отдельно в программе просмотра изображений. В таких случаях Aspose.Slides может генерировать миниатюрные изображения фигур слайдов. В этой статье объясняется, как использовать эту функцию.

## **Создание миниатюр фигур из слайдов**

Когда вам нужен предварительный просмотр конкретного объекта, а не всего слайда, вы можете отрендерить миниатюру отдельной фигуры. Aspose.Slides позволяет экспортировать любую фигуру в изображение, что упрощает создание легковесных предварительных просмотров, значков или ресурсов для последующей обработки.

Чтобы создать миниатюру любой фигуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его идентификатору или индексу.
1. Получите ссылку на фигуру на этом слайде.
1. Отрендерьте изображение миниатюры фигуры.
1. Сохраните изображение миниатюры в требуемом формате.

Ниже приведён пример, который генерирует миниатюру фигуры.

```py
import aspose.slides as slides

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Create a image with the default scale.
    with shape.get_image() as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Создание миниатюр с пользовательским коэффициентом масштабирования**

В этом разделе показано, как генерировать миниатюры фигур с пользовательским коэффициентом масштабирования в Aspose.Slides. Управляя масштабом, вы можете точно настроить размер миниатюры для предварительных просмотров, экспорта или дисплеев с высоким DPI.

Чтобы создать миниатюру любой фигуры на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите слайд по его идентификатору или индексу.
1. Получите целевую фигуру на этом слайде.
1. Отрендерьте изображение миниатюры фигуры с указанным масштабом.
1. Сохраните изображение миниатюры в требуемом формате.

Ниже пример, который генерирует миниатюру с пользовательским коэффициентом масштабирования.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Create an image with the defined scale.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Создание миниатюр с использованием границ внешнего вида фигуры**

В этом разделе показано, как генерировать миниатюру в пределах границ внешнего вида фигуры. При этом учитываются все эффекты фигуры. Сгенерированная миниатюра ограничена границами слайда.

Чтобы создать миниатюру любой фигуры слайда в пределах её внешнего вида:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите слайд по его идентификатору или индексу.
1. Получите целевую фигуру на этом слайде.
1. Отрендерьте изображение миниатюры фигуры с указанными границами.
1. Сохраните изображение миниатюры в требуемом формате изображения.

Ниже пример, который создаёт миниатюру с пользовательскими границами.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Instantiate the Presentation class to open the presentation file.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Create an appearance-bounds shape image.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Save the image to disk in PNG format.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), и другие. Фигуры также можно [экспортировать как векторный SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) путем сохранения содержимого фигуры в SVG.

**В чём разница между границами SHAPE и APPEARANCE при рендеринге миниатюры?**

`SHAPE` использует геометрию фигуры; `APPEARANCE` учитывает [визуальные эффекты](/slides/ru/python-net/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура отмечена как скрытая? Будет ли она всё равно отрендерена как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрендерена; флаг скрытия влияет лишь на отображение в показе слайдов, но не препятствует созданию изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), и [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)), можно сохранить как миниатюру или как SVG.

**Влияют ли системные шрифты на качество миниатюр текстовых фигур?**

Да. Вам следует [предоставить требуемые шрифты](/slides/ru/python-net/custom-font/) (или [настроить замену шрифтов](/slides/ru/python-net/font-substitution/)), чтобы избежать нежелательных замен и переполнения текста.