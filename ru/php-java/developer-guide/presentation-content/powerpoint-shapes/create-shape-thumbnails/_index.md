---
title: Создание миниатюр фигур презентаций в PHP
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/php-java/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- рендеринг фигуры
- визуализация фигуры
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Создавайте миниатюры фигур высокого качества из слайдов PowerPoint с помощью Aspose.Slides for PHP via Java — легко создавайте и экспортируйте миниатюры презентаций."
---

## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java можно использовать для создания файлов презентаций, где каждая страница соответствует слайду. Слайды можно просматривать, открывая файлы презентаций в Microsoft PowerPoint. Однако разработчикам иногда требуется просматривать изображения фигур отдельно в просмотрщике изображений. В таких случаях Aspose.Slides for PHP via Java помогает им генерировать миниатюры фигур слайда.

{{% /alert %}} 

В этой теме мы покажем, как создать миниатюры слайдов в различных ситуациях:

- Создание миниатюры фигуры внутри слайда.
- Создание миниатюры фигуры для фигуры слайда с пользовательскими размерами.
- Создание миниатюры фигуры в границах отображения фигуры.

## **Создание миниатюры фигуры из слайда**
Чтобы создать миниатюру фигуры из любого слайда с помощью Aspose.Slides for PHP via Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Получите ссылку на любой слайд, используя его идентификатор или индекс.
3. [Получить изображение миниатюры фигуры](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage--) для указанного слайда в масштабе по умолчанию.
4. Сохраните изображение миниатюры в предпочитаемом вами формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры из слайда:
```php
  # Создать экземпляр класса Presentation, представляющего файл презентации
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


## **Создание миниатюры с пользовательским коэффициентом масштабирования**
Чтобы создать миниатюру фигуры слайда с пользовательским коэффициентом масштабирования с помощью Aspose.Slides for PHP via Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Получите ссылку на любой слайд, используя его идентификатор или индекс.
3. [Получить изображение миниатюры фигуры](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage-int-float-float-) для указанного слайда с пользовательскими размерами.
4. Сохраните изображение миниатюры в предпочитаемом вами формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры на основе определённого коэффициента масштабирования:
```php
  # Создать экземпляр класса Presentation, представляющего файл презентации
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


## **Создание миниатюры фигуры на основе границ отображения**
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в границах отображения фигуры. При этом учитываются все эффекты фигуры. Сгенерированная миниатюра ограничена границами слайда. Чтобы создать миниатюру фигуры слайда в границе её отображения, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. Получите ссылку на любой слайд, используя его идентификатор или индекс.
3. Получите изображение миниатюры указанного слайда с границами фигуры как отображение.
4. Сохраните изображение миниатюры в предпочитаемом вами формате изображения.

Этот пример кода основан на описанных шагах:
```php
  # Создать экземпляр класса Presentation, представляющего файл презентации
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


## **FAQ**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/), и другие. Фигуры также могут быть [экспортированы как векторный SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) путем сохранения содержимого фигуры в виде SVG.

**В чем разница между границами Shape и Appearance при рендеринге миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [визуальные эффекты](/slides/ru/php-java/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отрисована как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет только на отображение в слайд‑шоу, но не препятствует генерации изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/), и [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)) может быть сохранён как миниатюра или как SVG.

**Влияют ли системные шрифты, установленные в системе, на качество миниатюр текстовых фигур?**

Да. Вы должны [предоставить требуемые шрифты](/slides/ru/php-java/custom-font/) (или [настроить замену шрифтов](/slides/ru/php-java/font-substitution/)), чтобы избежать нежелательных замен и переполнения текста.