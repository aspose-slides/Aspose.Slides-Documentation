---
title: Создание миниатюр фигур презентации в .NET
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/net/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- визуализация фигуры
- отрисовка фигуры
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте высококачественные миниатюры фигур из слайдов PowerPoint с помощью Aspose.Slides for .NET – легко создавайте и экспортируйте миниатюры презентаций."
---

Aspose.Slides for .NET используется для создания файлов презентаций, где каждая страница является слайдом. Эти слайды можно просматривать, открывая файлы презентаций в Microsoft PowerPoint. Но иногда разработчикам может потребоваться просматривать изображения фигур отдельно в средстве просмотра изображений. В таких случаях Aspose.Slides for .NET помогает генерировать миниатюры изображений фигур слайда. Как использовать эту функцию, описано в этой статье.

В этой статье объясняется, как генерировать миниатюры слайдов различными способами:

- Создание миниатюры фигуры внутри слайда.
- Создание миниатюры фигуры для фигуры слайда с пользовательскими размерами.
- Создание миниатюры фигуры в границах внешнего вида фигуры.
- Создание миниатюры дочернего узла SmartArt.

## **Создание миниатюры фигуры из слайда**
Для создания миниатюры фигуры из любого слайда с использованием Aspose.Slides for .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. Получите изображение миниатюры фигуры ссылочного слайда в масштабе по умолчанию.
1. Сохраните изображение миниатюры в любой желаемый формат изображения.

Ниже приведен пример, генерирующий миниатюру фигуры.
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


## **Создание миниатюры с пользовательским коэффициентом масштабирования**
Для создания миниатюры фигуры любого элемента слайда с использованием Aspose.Slides for .NET:

1. Создайте экземпляр класса `Presentation`.
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. Получите изображение миниатюры ссылочного слайда с границами фигуры.
1. Сохраните изображение миниатюры в любой желаемый формат изображения.

Ниже приведен пример, генерирующий миниатюру с пользовательским коэффициентом масштабирования.
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


## **Создание миниатюры внешнего вида фигуры в границах**
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в границах внешнего вида фигуры. Он учитывает все эффекты фигуры. Сгенерированная миниатюра фигуры ограничена границами слайда. Чтобы создать миниатюру любой фигуры слайда в границах её внешнего вида, используйте следующий пример кода:

1. Создайте экземпляр класса `Presentation`.
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. Получите изображение миниатюры ссылочного слайда с границами фигуры как внешнего вида.
1. Сохраните изображение миниатюры в любой желаемый формат изображения.

Ниже приведен пример, создающий миниатюру с пользовательским коэффициентом масштабирования.
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Масштабирование по осям X и Y.

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

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), и другие. Фигуры также могут быть [экспортированы как векторный SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/), сохранив содержимое фигуры в SVG.

**В чём разница между границами Shape и Appearance при рендеринге миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [visual effects](/slides/ru/net/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отображаться как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет только на отображение в слайд‑шоу, но не препятствует генерации изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), и [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)), может быть сохранён как миниатюра или как SVG.

**Влияют ли системные шрифты на качество миниатюр текстовых фигур?**

Да. Необходимо [provide the required fonts](/slides/ru/net/custom-font/) (или [configure font substitutions](/slides/ru/net/font-substitution/)), чтобы избежать нежелательных замен и переполнения текста.