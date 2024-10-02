---
title: Конвертация PowerPoint в PNG
type: docs
weight: 30
url: /ru/php-java/convert-powerpoint-to-png/
keywords: PowerPoint в PNG, PPT в PNG, PPTX в PNG, java, Aspose.Slides для PHP через Java
description: Конвертация презентации PowerPoint в PNG
---

## **О конвертации PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но все же довольно распространен. 

**Сценарий использования:** Когда у вас есть сложное изображение и размер не является проблемой, PNG является лучшим форматом изображения, чем JPEG. 

{{% alert title="Совет" color="primary" %}} Вам стоит обратить внимание на бесплатные **конвертеры PowerPoint в PNG** от Aspose: [PPTX в PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT в PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Это живые реализации процесса, описанного на этой странице. {{% /alert %}}

## **Конвертация PowerPoint в PNG**

Следуйте этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите объект слайда из коллекции [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) под интерфейсом [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide).
3. Используйте метод [ISlide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide), чтобы получить миниатюру для каждого слайда.
4. Используйте метод [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)), чтобы сохранить миниатюру слайда в формате PNG.

Этот код на PHP показывает, как конвертировать презентацию PowerPoint в PNG:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Конвертация PowerPoint в PNG с пользовательскими размерами**

Если вы хотите получить PNG-файлы определенного масштаба, вы можете установить значения для `desiredX` и `desiredY`, которые определяют размеры полученной миниатюры. 

Этот код демонстрирует описанную операцию:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Конвертация PowerPoint в PNG с заданным размером**

Если вы хотите получить PNG-файлы определенного размера, вы можете передать свои предпочтительные аргументы `width` и `height` для `ImageSize`. 

Этот код показывает, как конвертировать PowerPoint в PNG, указывая размеры для изображений: 

```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```