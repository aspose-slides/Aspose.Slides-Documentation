---
title: "Создание миниатюр фигур презентации на PHP"
linktitle: "Миниатюры фигур"
type: docs
weight: 70
url: /ru/php-java/create-shape-thumbnails/
keywords:
  - "миниатюра фигуры"
  - "изображение фигуры"
  - "отображение фигуры"
  - "рендеринг фигуры"
  - "визуальные границы"
  - "границы фигуры"
  - "PowerPoint"
  - "презентация"
  - "PHP"
  - "Aspose.Slides"
description: "Создавайте миниатюры фигур высокого качества из слайдов PowerPoint с помощью Aspose.Slides for PHP via Java – легко создавайте и экспортируйте миниатюры презентаций."
---
## **Введение**

Aspose.Slides используется для создания файлов презентаций, где каждая страница является слайдом. Эти слайды можно просматривать, открывая файлы презентаций в Microsoft PowerPoint. Однако иногда разработчикам требуется просматривать изображения фигур отдельно в просмотрщике изображений. В таких случаях Aspose.Slides помогает создавать миниатюры изображений фигур слайда. Как использовать эту функцию, описано в этой статье.  
В этой статье объясняется, как генерировать миниатюры слайдов разными способами:

- Создание миниатюры фигуры внутри слайда.
- Создание миниатюры фигуры для фигуры слайда с пользовательскими размерами.
- Создание миниатюры фигуры в границах внешнего вида фигуры.

## **Создание миниатюры фигуры из слайда**
Чтобы создать миниатюру фигуры из любого слайда с помощью Aspose.Slides для PHP через Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation).
2. Получите ссылку на любой слайд, используя его ID или индекс.
3. [Получите изображение миниатюры фигуры](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getImage) для указанного слайда с масштабом по умолчанию.
4. Сохраните изображение миниатюры в выбранном вами формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры из слайда:

```php
  # Создайте экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Создайте изображение в полном масштабе
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Сохраните изображение на диск в формате PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Создание миниатюры с пользовательским коэффициентом масштабирования**
Чтобы создать миниатюру фигуры слайда с помощью Aspose.Slides для PHP через Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation).
2. Получите ссылку на любой слайд, используя его ID или индекс.
3. [Получите изображение миниатюры фигуры](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getImage) для указанного слайда с пользовательскими размерами.
4. Сохраните изображение миниатюры в выбранном вами формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры на основе заданного коэффициента масштабирования:

```php
  # Создайте объект класса Presentation, представляющего файл презентации
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Создайте изображение в полном масштабе
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Сохраните изображение на диск в формате PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Создание миниатюры внешнего вида фигуры на основе границ**
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в пределах границ внешнего вида фигуры. Он учитывает все эффекты фигуры. Сгенерированная миниатюра фигуры ограничена границами слайда. Чтобы создать миниатюру фигуры слайда в пределах её внешнего вида, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation).
2. Получите ссылку на любой слайд, используя его ID или индекс.
3. Получите изображение миниатюры указанного слайда с границами фигуры в качестве внешнего вида.
4. Сохраните изображение миниатюры в выбранном вами формате изображения.

Этот пример кода основан на описанных выше шагах:

```php
  # Создайте объект класса Presentation, представляющего файл презентации
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Создайте изображение в полном масштабе
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Сохраните изображение на диск в формате PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Получить фактические визуальные границы фигуры**

Свойства рамки [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/) — `Shape::getX()`, `Shape::getY()`, `Shape::getWidth()` и `Shape::getHeight()` — описывают прямоугольник, хранящийся в модели презентации. Содержимое, которое действительно отображается, может выходить за пределы этой рамки или занимать иной прямоугольник, выровненный по осям. Поворот, контуры, наконечники стрел, компоновка и переполнение текста, сгенерированная геометрия SmartArt и другие эффекты рендеринга могут изменить занимаемую область.  
Используйте [Shape::getVisualBounds](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getVisualBounds), чтобы вычислить эту занимаемую область без создания изображения. Метод возвращает объект [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) в координатах слайда. Возвращаемый прямоугольник не обрезается по границе слайда, поэтому его координаты могут быть отрицательными, когда содержимое выходит за пределы начала слайда.  

Следующий пример получает и сравнивает рамку и визуальные границы:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

Тот же [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) можно использовать для выравнивания соседних фигур по их левой, правой, верхней или нижней границе; для резервирования достаточного пространства в сгенерированном макете; или для обнаружения содержимого за пределами разрешённого региона. Визуальные границы особенно полезны для SmartArt, текстовых полей, стрелок, изображений, повернутых фигур и групповых фигур, где сохранённая рамка может не отражать полного результата рендеринга.  

Используйте [Shape::getVisualBounds](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getVisualBounds), когда нужны координаты для компоновки или проверки и bitmap не требуется. Используйте [Shape::getImage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/#getImage), когда необходимо отобразить фигуру. С помощью [ShapeThumbnailBounds](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds::Shape` задаёт размер изображения по границам фигуры, включая настройки контура, тогда как `ShapeThumbnailBounds::Appearance` задаёт размер по внешнему виду фигуры и ограничивает результат границами слайда. В отличие от этого, `Shape::getVisualBounds` возвращает только вычисленный прямоугольник и не обрезает его по слайду.

## **FAQ**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ru/php-java/aspose.slides/imageformat/), и другие. Фигуры также могут быть [экспортированы как векторный SVG](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/writeassvg/) путем сохранения содержимого фигуры в формате SVG.

**В чем разница между границами Shape и Appearance при рендеринге миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [визуальные эффекты](/slides/ru/php-java/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отображаться как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет на отображение в режиме слайд‑шоу, но не препятствует созданию изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/ru/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ru/php-java/aspose.slides/chart/) и [SmartArt](https://reference.aspose.com/slides/ru/php-java/aspose.slides/smartart/)), может быть сохранён в виде миниатюры или SVG.

**Влияют ли системные шрифты, установленные в системе, на качество миниатюр текстовых фигур?**

Да. Вам следует [предоставить необходимые шрифты](/slides/ru/php-java/custom-font/) (или [настроить замену шрифтов](/slides/ru/php-java/font-substitution/)), чтобы избежать нежелательных замен и перелома текста.