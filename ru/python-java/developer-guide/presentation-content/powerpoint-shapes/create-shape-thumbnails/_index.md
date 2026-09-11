---
title: Создание миниатюр фигур презентации в Python через Java
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/python-java/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- отрисовка фигуры
- рендеринг фигуры
- визуальные границы
- границы фигуры
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Создавайте высококачественные миниатюры фигур из слайдов PowerPoint с помощью Aspose.Slides для Python через Java — легко создавайте и экспортируйте миниатюры презентаций."
---
## **Введение**

Aspose.Slides for Python via Java можно использовать для создания файлов презентаций, где каждая страница соответствует слайду. Слайды можно просматривать, открывая файлы презентаций в Microsoft PowerPoint. Однако разработчикам иногда необходимо отдельно просматривать изображения фигур в просмотрщике изображений. В таких случаях Aspose.Slides for Python via Java помогает генерировать миниатюрные изображения фигур слайда.

Эта статья объясняет, как создавать миниатюры фигур различными способами:

- Создание миниатюры фигуры внутри слайда.
- Создание миниатюры фигуры со слайда с пользовательскими размерами.
- Создание миниатюры фигуры в границах её внешнего вида.

## **Создание миниатюры фигуры со слайда**
Чтобы создать миниатюру фигуры с любого слайда, используя Aspose.Slides for Python via Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд, используя его ID или индекс.
1. [Получить миниатюру фигуры](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getImage) на указанном слайде с масштабом по умолчанию.
1. Сохраните миниатюрное изображение в предпочитаемом вами формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры со слайда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# Создайте объект класса Presentation, представляющего файл презентации.
presentation = Presentation("Thumbnail.pptx")
try:
    # Создать изображение полного масштаба.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Сохранить изображение на диск в формате PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Создание миниатюры с пользовательским коэффициентом масштабирования**
Чтобы создать миниатюру фигуры со слайда, используя Aspose.Slides for Python via Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд, используя его ID или индекс.
1. [Получить миниатюру фигуры](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getImage) на указанном слайде с пользовательскими размерами.
1. Сохраните миниатюрное изображение в предпочитаемом вами формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры на основе заданного коэффициента масштабирования:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Создайте объект класса Presentation, представляющего файл презентации.
presentation = Presentation("Thumbnail.pptx")
try:
    # Создать изображение, масштабированное в два раза по обеим направлениям.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Сохранить изображение на диск в формате PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Создание миниатюры внешнего вида фигуры по границам**
Этот способ создания миниатюр фигур позволяет разработчикам генерировать миниатюру в границах внешнего вида фигуры. При этом учитываются все эффекты фигуры. Сгенерированная миниатюра ограничивается границами слайда. Чтобы создать миниатюру фигуры со слайда в пределах её внешнего вида, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .
1. Получите ссылку на слайд, используя его ID или индекс.
1. Получите миниатюрное изображение фигуры на указанном слайде, используя границы её внешнего вида.
1. Сохраните миниатюрное изображение в предпочитаемом вами формате изображения.

Этот пример кода основан на перечисленных шагах:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Создайте объект класса Presentation, представляющего файл презентации.
presentation = Presentation("Thumbnail.pptx")
try:
    # Создать изображение полного масштаба.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Сохранить изображение на диск в формате PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Получить реальные визуальные границы фигуры**

Свойства кадра [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/) — его методы [getX](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getWidth) и [getHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getHeight) — описывают прямоугольник, хранящийся в модели презентации. Фактически отрисованное содержимое может выходить за пределы этого кадра или занимать иной прямоугольник, выровненный по осям. Повороты, контуры, стрелки, расположение и переполнение текста, генерируемая геометрия SmartArt и другие эффекты рендеринга могут изменить занимаемую область.

Используйте [Shape.getVisualBounds](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getVisualBounds), чтобы вычислить эту область без создания изображения. Метод возвращает объект [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) в координатах слайда. Возвращаемый прямоугольник не обрезается по границе слайда, поэтому его координаты могут быть отрицательными, если содержимое выходит за начало слайда.

Следующий пример получает и сравнивает кадр и визуальные границы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

Тот же объект [Rectangle2D.Float] можно использовать для выравнивания соседних фигур по левому, правому, верхнему или нижнему краю; для резервирования достаточного пространства в сгенерированном макете; или для обнаружения содержимого за пределами разрешённой области. Визуальные границы особенно полезны для SmartArt, текстовых блоков, стрелок, изображений, повернутых фигур и групповых фигур, когда сохранённый кадр не отражает полностью отрисованный результат.

Используйте [Shape.getVisualBounds], когда нужны координаты для компоновки или проверки и не требуется растровое изображение. Используйте [Shape.getImage], когда необходимо отрисовать фигуру. С помощью [ShapeThumbnailBounds] метод [ShapeThumbnailBounds.Shape] задаёт размер изображения по границам фигуры, включая настройки контура, а [ShapeThumbnailBounds.Appearance] — по внешнему виду фигуры и ограничивает результат границами слайда. В отличие от этого, [Shape.getVisualBounds] возвращает только вычисленный прямоугольник и не обрезает его по границе слайда.

## **FAQ**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imageformat/), и другие. Фигуры также можно [экспортировать как векторный SVG](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#writeAsSvgToBytes), сохранив их содержимое в формате SVG.

**В чем разница между границами Shape и Appearance при рендеринге миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [визуальные эффекты](/slides/ru/python-java/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отрисовываться как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет только на отображение в слайд-шоу и не препятствует генерации изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape] (включая [GroupShape], [Chart] и [SmartArt]), может быть сохранён как миниатюра или как SVG.

**Влияют ли системные шрифты на качество миниатюр текстовых фигур?**

Да. Необходимо [предоставить требуемые шрифты](/slides/ru/python-java/custom-font/) (или [настроить замену шрифтов](/slides/ru/python-java/font-substitution/)), чтобы избежать нежелательных замен и переflows текста.