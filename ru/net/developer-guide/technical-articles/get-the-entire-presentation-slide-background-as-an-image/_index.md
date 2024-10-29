---
title: Получите весь фон слайда презентации в виде изображения
type: docs
weight: 95
url: /ru/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- слайд
- фон
- фон слайда
- фон в изображение
- PowerPoint
- PPT
- PPTX
- презентация PowerPoint
- C#
- VB.NET
- Aspose.Slides для .NET
---

В презентациях PowerPoint фон слайда может состоять из множества элементов. В дополнение к изображению, установленному в качестве [фона слайда](/slides/ru/net/presentation-background/), на финальный фон могут влиять тема презентации, цветовая схема и фигуры, размещенные на главном слайде и слайде макета.

Aspose.Slides для .NET не предоставляет простого метода для извлечения всего фона слайда презентации в виде изображения, но вы можете следовать приведенным ниже шагам, чтобы сделать это:
1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Получите размер слайда из презентации.
1. Выберите слайд.
1. Создайте временную презентацию.
1. Установите тот же размер слайда в временной презентации.
1. Клонируйте выбранный слайд во временной презентации.
1. Удалите фигуры с клонированного слайда.
1. Преобразуйте клонированный слайд в изображение.

Следующий пример кода извлекает весь фон слайда презентации в виде изображения.
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```