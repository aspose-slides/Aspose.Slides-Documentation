---
title: Получить полный фон слайда презентации в виде изображения
type: docs
weight: 95
url: /androidjava/get-the-entire-presentation-slide-background-as-an-image/
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
- Aspose.Slides для Android через Java
---

В презентациях PowerPoint фон слайда может состоять из многих элементов. В дополнение к изображению, установленному в качестве [фона слайда](/slides/androidjava/presentation-background/), на финальный фон могут влиять тема презентации, цветовая схема и фигуры, размещенные на главном слайде и слайде разметки.

Aspose.Slides для Android через Java не предоставляет простого метода для извлечения полного фона слайда презентации в виде изображения, но вы можете следовать приведенным ниже шагам, чтобы сделать это:
1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите размер слайда из презентации.
1. Выберите слайд.
1. Создайте временную презентацию.
1. Установите такой же размер слайда в временной презентации.
1. Клонируйте выбранный слайд во временную презентацию.
1. Удалите фигуры с клонированного слайда.
1. Преобразуйте клонированный слайд в изображение.

Следующий пример кода извлекает полный фон слайда презентации в виде изображения.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```