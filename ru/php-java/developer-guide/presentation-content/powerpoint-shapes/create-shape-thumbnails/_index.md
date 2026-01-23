---
title: Создание миниатюр фигур презентации в PHP
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/php-java/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- отрисовка фигуры
- рендеринг фигуры
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте высококачественные миниатюры фигур из слайдов PowerPoint с помощью Aspose.Slides for PHP via Java — легко создавайте и экспортируйте миниатюры презентаций."
---

## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java можно использовать для создания файлов презентаций, в которых каждая страница соответствует слайду. Слайды можно просматривать, открывая файлы презентаций в Microsoft PowerPoint. Однако разработчикам иногда требуется просматривать изображения фигур отдельно во внешнем просмотрщике изображений. В таких случаях Aspose.Slides for PHP via Java помогает им создавать миниатюры изображений фигур слайда.

{{% /alert %}} 

В этой теме мы покажем, как генерировать миниатюры слайдов в разных ситуациях:

- Создание миниатюры фигуры внутри слайда.
- Создание миниатюры фигуры слайда с пользовательскими размерами.
- Создание миниатюры фигуры в границах её отображения.

## **Создание миниатюры фигуры из слайда**
Чтобы создать миниатюру фигуры из любого слайда с помощью Aspose.Slides for PHP via Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. [Получите изображение миниатюры фигуры](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) для указанного слайда в масштабе по умолчанию.
1. Сохраните изображение миниатюры в желаемом формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры из слайда:
```php
  # Создать объект класса Presentation, представляющий файл презентации
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Создать изображение в полном масштабе
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Сохранить изображение на диск в формате PNG
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


## **Создание миниатюры с пользовательским фактором масштабирования**
Чтобы создать миниатюру фигуры слайда с помощью Aspose.Slides for PHP via Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. [Получите изображение миниатюры фигуры](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) для указанного слайда с пользовательскими размерами.
1. Сохраните изображение миниатюры в желаемом формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры на основе заданного фактора масштабирования:
```php
  # Создать объект класса Presentation, представляющий файл презентации
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Создать изображение в полном масштабе
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Сохранить изображение на диск в формате PNG
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


## **Создание миниатюры отображения фигуры на основе границ**
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в границах отображения фигуры. Он учитывает все эффекты фигуры. Сгенерированная миниатюра фигуры ограничена границами слайда. Чтобы создать миниатюру фигуры слайда в пределах её отображения, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. Получите изображение миниатюры указанного слайда, используя границы фигуры как отображение.
1. Сохраните изображение миниатюры в желаемом формате изображения.

Этот пример кода основан на приведенных выше шагах:
```php
  # Создать объект класса Presentation, представляющий файл презентации
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Создать изображение в полном масштабе
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Сохранить изображение на диск в формате PNG
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


## **Вопросы и ответы**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/), и другие. Фигуры также можно [экспортировать как векторный SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/), сохранив содержимое фигуры в формате SVG.

**В чём разница между границами Shape и Appearance при отрисовке миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [визуальные эффекты](/slides/ru/php-java/shape-effect/) (тени, свечения и т. д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отрисована как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет на отображение в слайдшоу, но не препятствует созданию изображения фигуры.

**Поддерживаются ли составные фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/), и [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)), можно сохранить как миниатюру или как SVG.

**Влияют ли системные шрифты на качество миниатюр текстовых фигур?**

Да. Необходимо [предоставить требуемые шрифты](/slides/ru/php-java/custom-font/) (или [настроить замену шрифтов](/slides/ru/php-java/font-substitution/)), чтобы избежать нежелательных подстановок и переполнения текста.