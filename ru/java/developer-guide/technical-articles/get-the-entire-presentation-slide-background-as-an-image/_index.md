---
title: Получите весь фон слайдов презентации в виде изображения
type: docs
weight: 95
url: /java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- слайд
- фон
- фон слайда
- фон в изображение
- PowerPoint
- PPT
- PPTX
- презентация PowerPoint
- Java
- Aspose.Slides для Java
---

В презентациях PowerPoint фон слайда может состоять из множества элементов. В дополнение к изображению, установленному в качестве [фона слайда](/slides/java/presentation-background/), на окончательный фон могут влиять тема презентации, цветовая схема и фигуры, размещенные на слайде-макете и главном слайде.

Aspose.Slides для Java не предоставляет простого метода извлечения всего фона слайда презентации в виде изображения, но вы можете следовать приведенным ниже шагам, чтобы сделать это:
1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите размер слайда из презентации.
1. Выберите слайд.
1. Создайте временную презентацию.
1. Установите такой же размер слайда в временной презентации.
1. Клонируйте выбранный слайд в временную презентацию.
1. Удалите фигуры с клонированного слайда.
1. Преобразуйте клонированный слайд в изображение.

Следующий пример кода извлекает весь фон слайда презентации в виде изображения.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```