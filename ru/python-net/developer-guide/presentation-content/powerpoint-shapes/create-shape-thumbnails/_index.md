---
title: Создание миниатюр фигур презентации на Python
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/python-net/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- рисование фигуры
- рендеринг фигуры
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте высококачественные миниатюры фигур из слайдов PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET – легко создавайте и экспортируйте миниатюры презентаций."
---

## **Введение**

Aspose.Slides for Python via .NET используется для создания файлов презентаций, где каждая страница является слайдом. Вы можете просматривать эти слайды в Microsoft PowerPoint, открыв файл презентации. Однако разработчикам иногда требуется просматривать изображения фигур отдельно в просмотрщике изображений. В таких случаях Aspose.Slides может генерировать миниатюрные изображения фигур слайдов. В этой статье объясняется, как использовать эту функцию.

## **Создание миниатюр фигур со слайдов**

Когда вам нужен предварительный просмотр конкретного объекта, а не всего слайда, вы можете отрендерить миниатюру отдельной фигуры. Aspose.Slides позволяет экспортировать любую фигуру в изображение, что упрощает создание легковесных предварительных просмотров, иконок или ресурсов для последующей обработки.

Чтобы создать миниатюру любой фигуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его ID или индексу.
3. Получите ссылку на фигуру на этом слайде.
4. Отрендерите миниатюрное изображение фигуры.
5. Сохраните миниатюру в нужном формате.

Пример ниже генерирует миниатюру фигуры.
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, чтобы открыть файл презентации.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Создайте изображение с масштабом по умолчанию.
    with shape.get_image() as thumbnail:
        # Сохраните изображение на диск в формате PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```


## **Создание миниатюр с пользовательским коэффициентом масштабирования**

В этом разделе показано, как в Aspose.Slides генерировать миниатюры фигур с пользовательским коэффициентом масштабирования. Управляя масштабом, вы можете точно настроить размер миниатюры для предварительных просмотров, экспорта или дисплеев с высоким DPI.

Чтобы создать миниатюру любой фигуры на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите слайд по его ID или индексу.
3. Получите целевую фигуру на этом слайде.
4. Отрендерите миниатюрное изображение фигуры с указанным масштабом.
5. Сохраните миниатюру в нужном формате.

Пример ниже генерирует миниатюру с пользовательским коэффициентом масштабирования.
```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

    # Создайте экземпляр класса Presentation, чтобы открыть файл презентации.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Создайте изображение с заданным масштабом.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Сохраните изображение на диск в формате PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```


## **Создание миниатюр с использованием границ отображения фигуры**

В этом разделе показано, как создать миниатюру в пределах границ отображения фигуры. При этом учитываются все эффекты фигуры. Сгенерированная миниатюра ограничена границами слайда.

Чтобы создать миниатюру любой фигуры слайда в пределах её границ отображения:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите слайд по его ID или индексу.
3. Получите целевую фигуру на этом слайде.
4. Отрендерите миниатюрное изображение фигуры с указанными границами.
5. Сохраните миниатюру в нужном формате изображения.

Пример ниже создаёт миниатюру с пользовательски заданными границами.
```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Создайте экземпляр класса Presentation, чтобы открыть файл презентации.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Создайте изображение фигуры в пределах границ отображения.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Сохраните изображение на диск в формате PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```


## **FAQ**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), и другие. Фигуры также можно [экспортировать как векторный SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) сохраняя содержимое фигуры в виде SVG.

**В чём разница между границами SHAPE и APPEARANCE при рендеринге миниатюры?**

`SHAPE` использует геометрию фигуры; `APPEARANCE` учитывает [визуальные эффекты](/slides/ru/python-net/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отрендерена как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрендерена; флаг скрытия влияет на отображение в слайд-шоу, но не мешает генерации изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), и [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)), может быть сохранён как миниатюра или как SVG.

**Влияют ли системные шрифты на качество миниатюр текстовых фигур?**

Да. Вам следует [предоставить необходимые шрифты](/slides/ru/python-net/custom-font/) (или [настроить замену шрифтов](/slides/ru/python-net/font-substitution/)), чтобы избежать нежелательных подстановок и переполнения текста.