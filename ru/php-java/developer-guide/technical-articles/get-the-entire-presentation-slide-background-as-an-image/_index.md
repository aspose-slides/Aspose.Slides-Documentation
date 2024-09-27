---
title: Получение фона слайда всей презентации в виде изображения
type: docs
weight: 95
url: /ru/php-java/get-the-entire-presentation-slide-background-as-an-image/
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
- Php
- Aspose.Slides для PHP через Java
---

В презентациях PowerPoint фон слайда может состоять из множества элементов. В дополнение к изображению, установленному в качестве [фона слайда](/slides/ru/php-java/presentation-background/), на окончательный фон могут влиять тема презентации, цветовая схема и формы, расположенные на слайде мастер и слайде макета.

Aspose.Slides для PHP через Java не предоставляет простого метода для извлечения фона всей презентации слайда в виде изображения, но вы можете следовать приведённым ниже шагам, чтобы сделать это:
1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/).
1. Получите размер слайда из презентации.
1. Выберите слайд.
1. Создайте временную презентацию.
1. Установите тот же размер слайда в временной презентации.
1. Клонируйте выбранный слайд в временную презентацию.
1. Удалите формы с клонированного слайда.
1. Преобразуйте клонированный слайд в изображение.

Следующий пример кода извлекает фон всей презентации слайда в виде изображения.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```