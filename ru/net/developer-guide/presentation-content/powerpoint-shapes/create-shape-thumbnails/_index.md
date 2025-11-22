---
title: Создание миниатюр фигур
type: docs
weight: 70
url: /ru/net/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- PowerPoint
- презентация
- C#
- Csharp
- Aspose.Slides for .NET
description: "Извлеките миниатюры фигур из презентаций PowerPoint на C# или .NET"
---

Aspose.Slides for .NET используется для создания файлов презентаций, где каждая страница — это слайд. Эти слайды можно просматривать, открывая файлы презентаций с помощью Microsoft PowerPoint. Но иногда разработчикам требуется просмотреть изображения фигур отдельно в просмотрщике изображений. В таких случаях Aspose.Slides for .NET помогает генерировать миниатюры фигур слайдов. Как использовать эту функцию, описано в этой статье.  
Эта статья объясняет, как генерировать миниатюры слайдов разными способами:

- Генерация миниатюры фигуры внутри слайда.  
- Генерация миниатюры фигуры с пользовательскими размерами.  
- Генерация миниатюры фигуры в границах её внешнего вида.  
- Генерация миниатюры дочернего узла SmartArt.  


## **Создание миниатюры фигуры со слайда**
Чтобы создать миниатюру фигуры любого слайда с помощью Aspose.Slides for .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
1. Получите ссылку на любой слайд, используя его ID или индекс.  
1. Получите изображение миниатюры фигуры слайда по умолчанию.  
1. Сохраните изображение миниатюры в нужном вам формате изображения.  

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



## **Создание миниатюры с пользовательским коэффициентом масштабирования**
Чтобы создать миниатюру любой фигуры слайда с помощью Aspose.Slides for .NET:

1. Создайте экземпляр класса `Presentation`.  
1. Получите ссылку на любой слайд, используя его ID или индекс.  
1. Получите изображение миниатюры слайда с учётом границ фигуры.  
1. Сохраните изображение миниатюры в нужном формате.  

Ниже показан пример создания миниатюры с пользовательским коэффициентом масштабирования.  
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



## **Создание миниатюры внешнего вида фигуры в её границах**
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в границах внешнего вида фигуры. Он учитывает все эффекты фигуры. Сгенерированная миниатюра ограничена границами слайда. Чтобы создать миниатюру любой фигуры слайда в границах её внешнего вида, используйте следующий пример кода:

1. Создайте экземпляр класса `Presentation`.  
1. Получите ссылку на любой слайд, используя его ID или индекс.  
1. Получите изображение миниатюры слайда с учётом границ фигуры как внешнего вида.  
1. Сохраните изображение миниатюры в нужном формате изображения.  

Ниже показан пример создания миниатюры с учётом границ внешнего вида.  
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

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), и другие. Фигуры также можно [экспортировать как векторный SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) путём сохранения содержимого фигуры в формате SVG.

**В чём разница между границами Shape и Appearance при рендеринге миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [визуальные эффекты](/slides/ru/net/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отображаться как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет только на отображение слайдшоу и не препятствует генерации изображения фигуры.

**Поддерживаются групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), и [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) можно сохранить в виде миниатюры или SVG.

**Влияют ли системные шрифты на качество миниатюр текстовых фигур?**

Да. Необходимо [предоставить требуемые шрифты](/slides/ru/net/custom-font/) (или [настроить замену шрифтов](/slides/ru/net/font-substitution/)), чтобы избежать нежелательных замен и перемещения текста.