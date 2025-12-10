---
title: Создание миниатюр фигур презентации в .NET
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/net/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- рендеринг фигуры
- отрисовка фигуры
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте миниатюры фигур высокого качества из слайдов PowerPoint с помощью Aspose.Slides для .NET — легко создавайте и экспортируйте миниатюры презентаций."
---

Aspose.Slides for .NET используется для создания файлов презентаций, где каждая страница является слайдом. Эти слайды можно просматривать, открывая файлы презентаций с помощью Microsoft PowerPoint. Но иногда разработчикам может потребоваться просматривать изображения фигур отдельно в просмотрщике изображений. В таких случаях Aspose.Slides for .NET помогает генерировать миниатюры изображений фигур слайдов. Как использовать эту функцию описано в этой статье.

В этой статье объясняется, как генерировать миниатюры слайдов разными способами:

- Создание миниатюры фигуры внутри слайда.
- Создание миниатюры фигуры слайда с пользовательскими размерами.
- Создание миниатюры фигуры в пределах внешнего вида фигуры.
- Создание миниатюры дочернего узла SmartArt.

## **Создать миниатюру фигуры из слайда**
Для создания миниатюры фигуры из любого слайда с помощью Aspose.Slides for .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на любой слайд, используя его ID или индекс.
3. Получите изображение миниатюры фигуры ссылки на слайд в масштабе по умолчанию.
4. Сохраните изображение миниатюры в любой нужный формат изображения.

Ниже приведён пример создания миниатюры фигуры.
```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```


## **Создать миниатюру с пользовательским коэффициентом масштабирования**
Для создания миниатюры фигуры любого слайда с помощью Aspose.Slides for .NET:

1. Создайте экземпляр класса `Presentation`.
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. Получите изображение миниатюры ссылки на слайд с границами фигуры.
1. Сохраните изображение миниатюры в любой нужный формат изображения.

Ниже приведён пример создания миниатюры с пользовательским коэффициентом масштабирования.
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Масштабирование по осям X и Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```


## **Создать миниатюру внешнего вида фигуры на основе границ**
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в пределах внешнего вида фигуры. Он учитывает все эффекты фигуры. Сгенерированная миниатюра фигуры ограничена границами слайда. Чтобы создать миниатюру любой фигуры слайда в границах её внешнего вида, используйте следующий пример кода:

1. Создайте экземпляр класса `Presentation`.
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. Получите изображение миниатюры ссылки на слайд с границами фигуры как внешним видом.
1. Сохраните изображение миниатюры в любой нужный формат изображения.

Ниже приведён пример создания миниатюры.
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Масштабирование вдоль осей X и Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```


## **FAQ**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), и другие. Фигуры также могут быть [экспортированы как векторный SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) путем сохранения содержимого фигуры в формате SVG.

**В чём разница между границами Shape и Appearance при рендеринге миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [визуальные эффекты](/slides/ru/net/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отрисована как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет на отображение в слайд-шоу, но не препятствует генерации изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/) и [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)), можно сохранить как миниатюру или как SVG.

**Влияют ли системные шрифты на качество миниатюр текстовых фигур?**

Да. Необходимо [предоставить требуемые шрифты](/slides/ru/net/custom-font/) (или [настроить замену шрифтов](/slides/ru/net/font-substitution/)), чтобы избежать нежелательных подстановок и перераспределения текста.