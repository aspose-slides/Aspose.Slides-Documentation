---
title: Создание миниатюр фигур презентации в Python
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/python-net/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- визуализация фигуры
- отрисовка фигуры
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте миниатюры фигур высокого качества из слайдов PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET – легко создавайте и экспортируйте миниатюры презентаций."
---

## **Введение**

Aspose.Slides for Python via .NET используется для создания файлов презентаций, где каждая страница представляет собой слайд. Вы можете просматривать эти слайды в Microsoft PowerPoint, открыв файл презентации. Однако разработчикам иногда требуется просмотреть изображения фигур отдельно в просмотрщике изображений. В таких случаях Aspose.Slides может создавать миниатюры фигур слайдов. В этой статье объясняется, как использовать эту возможность.

## **Создание миниатюр фигур из слайдов**

Когда нужен предварительный просмотр конкретного объекта, а не всего слайда, можно отрисовать миниатюру отдельной фигуры. Aspose.Slides позволяет экспортировать любую фигуру в изображение, упрощая создание лёгких превью, иконок или ресурсов для последующей обработки.

Чтобы создать миниатюру любой фигуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его ID или индексу.
1. Получите ссылку на фигуру на этом слайде.
1. Отрисуйте миниатюру изображения фигуры.
1. Сохраните изображение миниатюры в требуемом формате.

Ниже приведён пример, генерирующий миниатюру фигуры.

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

В этом разделе показано, как генерировать миниатюры фигур с заданным пользователем коэффициентом масштабирования в Aspose.Slides. Управляя масштабом, можно точно подобрать размер миниатюры для превью, экспорта или дисплеев с высоким DPI.

Чтобы создать миниатюру любой фигуры на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите слайд по его ID или индексу.
1. Получите целевую фигуру на этом слайде.
1. Отрисуйте изображение миниатюры фигуры с указанным масштабом.
1. Сохраните изображение миниатюры в требуемом формате.

Ниже приведён пример, генерирующий миниатюру с пользовательским коэффициентом масштабирования.

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

## **Создание миниатюр с учётом границ отображения фигуры**

В этом разделе показано, как генерировать миниатюру в границах отображения фигуры. При этом учитываются все визуальные эффекты фигуры. Сгенерированная миниатюра ограничивается границами слайда.

Чтобы создать миниатюру любой фигуры слайда в пределах её границ отображения:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите слайд по его ID или индексу.
1. Получите целевую фигуру на этом слайде.
1. Отрисуйте изображение миниатюры фигуры с указанными границами.
1. Сохраните изображение миниатюры в требуемом формате изображения.

Ниже пример создания миниатюры с пользовательскими границами.

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

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), и др. Фигуры также могут быть [экспортированы как векторный SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) путём сохранения их содержимого в SVG.

**В чём разница между границами SHAPE и APPEARANCE при отрисовке миниатюры?**

`SHAPE` использует геометрию фигуры; `APPEARANCE` учитывает [визуальные эффекты](/slides/ru/python-net/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отрисована как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет только на отображение в слайд‑шоу и не препятствует генерации изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), и [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)), можно сохранить как миниатюру или SVG.

**Влияют ли системные шрифты на качество миниатюр текстовых фигур?**

Да. Необходимо [предоставить требуемые шрифты](/slides/ru/python-net/custom-font/) (или [настроить замену шрифтов](/slides/ru/python-net/font-substitution/)), чтобы избежать нежелательных подстановок и переполнения текста.