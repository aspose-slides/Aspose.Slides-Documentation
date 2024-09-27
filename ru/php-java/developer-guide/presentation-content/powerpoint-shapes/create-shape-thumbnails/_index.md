---
title: Создание миниатюр форм
type: docs
weight: 70
url: /ru/php-java/create-shape-thumbnails/
---


## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides для PHP через Java может использоваться для создания файлов презентаций, в которых каждая страница соответствует слайду. Слайды можно просматривать, открывая файлы презентаций с помощью Microsoft PowerPoint. Однако разработчикам иногда нужно отдельно просматривать изображения форм в просмотрщике изображений. В таких случаях Aspose.Slides для PHP через Java помогает им генерировать миниатюры изображений форм слайдов.

{{% /alert %}} 

В этой теме мы покажем, как генерировать миниатюры слайдов в различных ситуациях:

- Генерация миниатюры формы внутри слайда.
- Генерация миниатюры формы для формы слайда с заданными пользователем размерами.
- Генерация миниатюры формы в границах внешнего вида формы.

## **Генерация миниатюр форм из слайдов**
Чтобы сгенерировать миниатюру формы из любого слайда, используя Aspose.Slides для PHP через Java, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. [Получите изображение миниатюры формы](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage--) ссылочного слайда в масштабе по умолчанию.
1. Сохраните изображение миниатюры в предпочтительном вами формате изображения.

Этот образец кода показывает, как сгенерировать миниатюру формы из слайда:

```php
  # Создайте экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Создайте изображение полного масштаба
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

## **Генерация миниатюр форм с заданным пользователем коэффициентом масштабирования**
Чтобы сгенерировать миниатюру формы слайда, используя Aspose.Slides для PHP через Java, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. [Получите изображение миниатюры формы](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage-int-float-float-) ссылочного слайда с заданными пользователем размерами.
1. Сохраните изображение миниатюры в предпочтительном вами формате изображения.

Этот образец кода показывает, как сгенерировать миниатюру формы на основе заданного коэффициента масштабирования:

```php
  # Создайте экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Создайте изображение полного масштаба
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

## **Генерация миниатюры формы по границам**
Этот метод создания миниатюр форм позволяет разработчикам генерировать миниатюру в границах внешнего вида формы. Он учитывает все эффекты формы. Сгенерированная миниатюра формы ограничена границами слайда. Чтобы сгенерировать миниатюру формы слайда в границах его внешнего вида, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. Получите изображение миниатюры ссылочного слайда с границами формы как внешнего вида.
1. Сохраните изображение миниатюры в предпочтительном вами формате изображения.

Этот образец кода основан на вышеописанных шагах:

```php
  # Создайте экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Создайте изображение полного масштаба
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