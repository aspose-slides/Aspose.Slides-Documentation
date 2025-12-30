---
title: Получить полный фон слайда из презентации в виде изображения
linktitle: Полный фон слайда
type: docs
weight: 95
url: /ru/php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- фон слайда
- окончательный фон
- извлечение фона
- полный фон
- фон в изображение
- фон PPT
- фон PPTX
- фон ODP
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Извлекайте полные фоны слайдов в виде изображений из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java, упрощая визуальные рабочие процессы."
---

## **Получить полный фон слайда**

В презентациях PowerPoint фон слайда может состоять из множества элементов. Помимо изображения, установленного как [фон слайда](/slides/ru/php-java/presentation-background/), окончательный фон может зависеть от темы презентации, цветовой схемы и фигур, размещённых на мастер‑слайде и макете слайда.

Aspose.Slides for PHP via Java не предоставляет простого метода для извлечения полного фона слайда презентации в виде изображения, но вы можете выполнить следующие шаги:
1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/).
1. Получите размер слайда из презентации.
1. Выберите слайд.
1. Создайте временную презентацию.
1. Установите такой же размер слайда во временной презентации.
1. Клонируйте выбранный слайд во временную презентацию.
1. Удалите фигуры из клонированного слайда.
1. Преобразуйте клонированный слайд в изображение.

Ниже приведён пример кода, который извлекает полный фон слайда презентации в виде изображения.
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


## **FAQ**

**Будут ли сложные градиенты, текстуры или рисунки из мастер‑слайда сохранены в результирующем изображении фона?**

Да. Aspose.Slides рендерит градиентные, рисунковые и текстурные заливки, определённые на слайде, макете или мастере. Если нужно изолировать вид от унаследованных мастеров, [установите собственный фон](/slides/ru/php-java/presentation-background/) на текущем слайде перед экспортом.

**Могу ли я добавить водяной знак к полученному изображению фона перед сохранением?**

Да. Вы можете [добавить водяной знак](/slides/ru/php-java/watermark/) в виде фигуры или изображения на рабочую [копию слайда](/slides/ru/php-java/clone-slides/) (разместив её позади другого содержимого), а затем выполнить экспорт. Это позволит создать изображение фона с встроенным водяным знаком.

**Можно ли получить фон для конкретного макета или мастера без привязки к существующему слайду?**

Да. Обратитесь к нужному мастеру или макету, примените его к [временному слайду](/slides/ru/php-java/clone-slides/) с требуемым размером и экспортируйте этот слайд, чтобы получить фон, полученный из выбранного макета или мастера.

**Есть ли ограничения лицензирования, влияющие на экспорт изображений?**

Функции рендеринга полностью доступны при наличии [действующей лицензии](/slides/ru/php-java/licensing/). В режиме оценки вывод может содержать ограничения, такие как водяной знак. Активируйте лицензию один раз на процесс перед запуском пакетного экспорта.