---
title: Создание миниатюр фигур презентации в .NET
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/net/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- отображение фигуры
- визуализация фигуры
- визуальные границы
- границы фигуры
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте высококачественные миниатюры фигур из слайдов PowerPoint с помощью Aspose.Slides для .NET – легко создавайте и экспортируйте миниатюры презентаций."
---
## **Введение**

Aspose.Slides for .NET используется для создания файлов презентаций, где каждая страница является слайдом. Эти слайды можно просматривать, открыв файлы презентаций в Microsoft PowerPoint. Но иногда разработчикам может потребоваться просмотреть изображения фигур отдельно в просмотрщике изображений. В таких случаях Aspose.Slides for .NET помогает генерировать миниатюры фигур слайдов. Как использовать эту возможность, описано в этой статье.  
Эта статья объясняет, как создавать миниатюры слайдов различными способами:

- Создание миниатюры фигуры внутри слайда.  
- Создание миниатюры фигуры для формы слайда с пользовательскими размерами.  
- Создание миниатюры фигуры в границах отображения фигуры.  

## **Создание миниатюры фигуры из слайда**
Для создания миниатюры фигуры из любого слайда с помощью Aspose.Slides for .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation).  
1. Получите ссылку на любой слайд, используя его ID или индекс.  
1. Получите изображение миниатюры фигуры указанного слайда в масштабе по умолчанию.  
1. Сохраните изображение миниатюры в любом требуемом графическом формате.  

Пример ниже создает миниатюру фигуры.

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
Для создания миниатюры фигуры любого элемента слайда с помощью Aspose.Slides for .NET:

1. Создайте экземпляр класса `Presentation`.  
1. Получите ссылку на любой слайд, используя его ID или индекс.  
1. Получите изображение миниатюры указанного слайда с границами фигуры.  
1. Сохраните изображение миниатюры в любом требуемом графическом формате.  

В примере ниже создаётся миниатюра с пользовательским коэффициентом масштабирования.

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

## **Создание миниатюры формы на основе границ отображения**
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в границах отображения фигуры. Он учитывает все эффекты фигуры. Сгенерированная миниатюра ограничена границами слайда. Чтобы создать миниатюру любой фигуры слайда в границах её отображения, используйте следующий пример кода:

1. Создайте экземпляр класса `Presentation`.  
1. Получите ссылку на любой слайд, используя его ID или индекс.  
1. Получите изображение миниатюры указанного слайда с границами фигуры как отображение.  
1. Сохраните изображение миниатюры в любом требуемом графическом формате.  

В примере ниже создаётся миниатюра с пользовательским коэффициентом масштабирования.

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

## **Получение фактических визуальных границ фигуры**

Свойства кадра [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/) — его `X`, `Y`, `Width` и `Height` — описивают прямоугольник, хранящийся в модели презентации. Содержимое, которое фактически отрисовывается, может выходить за пределы этого кадра или занимать иной прямоугольник, выровненный по осям. Поворот, обводки, концы стрелок, компоновка и переполнение текста, генерируемая геометрия SmartArt и другие эффекты рендеринга могут менять занимаемую площадь.

Используйте [GetVisualBounds](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/getvisualbounds/) для расчёта этой площади без создания изображения. Метод возвращает объект [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) в координатах слайда. Возвращённый прямоугольник не обрезается по границе слайда, поэтому его координаты могут быть отрицательными, если содержимое выходит за начало слайда.

[GetVisualBounds](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/getvisualbounds/) в настоящее время не объявлен в интерфейсе [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/). Поэтому храните полученную из коллекции фигур слайда фигуру как значение интерфейса и приводите тип только при вызове метода.

Следующий пример получает и сравнивает границы кадра и визуальные границы:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

Тот же [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) можно использовать для выравнивания соседних фигур по её левому, правому, верхнему или нижнему краю; для резервирования достаточно места в сгенерированном макете; либо для обнаружения содержимого за пределами разрешённой области. Визуальные границы особенно полезны для SmartArt, текстовых полей, стрелок, изображений, повернутых фигур и составных фигур, где сохранённый кадр может не отражать полностью отрисованный результат.

Используйте [GetVisualBounds](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/getvisualbounds/), когда нужны координаты для компоновки или проверки и не требуется bitmap. Используйте [IShape.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/getimage/), когда необходимо отрисовать фигуру. С помощью [ShapeThumbnailBounds](https://reference.aspose.com/slides/ru/net/aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds.Shape` задаёт размер изображения из границ фигуры, включая настройки обводки, тогда как `ShapeThumbnailBounds.Appearance` задаёт размер из отображения фигуры и ограничивает результат границами слайда. В отличие от этого, [GetVisualBounds](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/getvisualbounds/) возвращает только рассчитанный прямоугольник и не обрезает его по границе слайда.

## **Часто задаваемые вопросы**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ru/net/aspose.slides/imageformat/), и другие. Фигуры также могут быть [exported as vector SVG](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/writeassvg/) путём сохранения их содержимого в формате SVG.

**В чём разница между границами Shape и Appearance при рендеринге миниатюры?**  
`Shape` использует геометрию фигуры; `Appearance` учитывает [visual effects](/slides/ru/net/shape-effect/) (тени, свечения и т.д.).

**Что произойдёт, если фигура помечена как скрытая? Будет ли она всё равно отрисована как миниатюра?**  
Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет только на отображение в режиме слайд‑шоу и не препятствует созданию изображения фигуры.

**Поддерживаются ли составные фигуры, диаграммы, SmartArt и другие сложные объекты?**  
Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/ru/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chart/), и [SmartArt](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/smartart/)), может быть сохранён в виде миниатюры или в формате SVG.

**Влияют ли системные шрифты, установленные в ОС, на качество миниатюр текстовых фигур?**  
Да. Необходимо [provide the required fonts](/slides/ru/net/custom-font/) (или [configure font substitutions](/slides/ru/net/font-substitution/)), чтобы избежать нежелательных замен и переполнения текста.