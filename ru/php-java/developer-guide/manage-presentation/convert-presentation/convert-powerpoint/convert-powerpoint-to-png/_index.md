---
title: Преобразование слайдов PowerPoint в PNG на PHP
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/php-java/convert-powerpoint-to-png/
keywords:
- конвертация PowerPoint
- конвертация презентации
- конвертация слайда
- конвертация PPT
- конвертация PPTX
- PowerPoint в PNG
- презентация в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспорт PPT в PNG
- экспорт PPTX в PNG
- PHP
- Aspose.Slides
description: "Быстро конвертируйте презентации PowerPoint в высококачественные PNG‑изображения с помощью Aspose.Slides для PHP через Java, обеспечивая точные и автоматические результаты."
---

## **О преобразовании PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но всё равно очень популярен. 

**Случай использования:** Когда у вас сложное изображение и размер не имеет значения, PNG — лучшее изображение, чем JPEG. 

{{% alert title="Tip" color="primary" %}} Возможно, вам стоит ознакомиться с бесплатными конвертерами Aspose **PowerPoint в PNG**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Они являются живой реализацией процесса, описанного на этой странице. {{% /alert %}}

## **Преобразовать PowerPoint в PNG**

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите объект слайда из коллекции [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) под интерфейсом [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide).
3. Используйте метод [ISlide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) чтобы получить миниатюру для каждого слайда.
4. Вызовите метод [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) чтобы сохранить миниатюру слайда в формате PNG.

Этот код PHP показывает, как преобразовать презентацию PowerPoint в PNG:
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


## **Преобразовать PowerPoint в PNG с пользовательскими размерами**

Если вы хотите получить PNG‑файлы определённого масштаба, можете задать значения `desiredX` и `desiredY`, которые определяют размеры получаемой миниатюры. 

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


## **Преобразовать PowerPoint в PNG с пользовательским размером**

Если вы хотите получить PNG‑файлы определённого размера, можете передать желаемые параметры `width` и `height` для `ImageSize`. 

Этот код показывает, как преобразовать PowerPoint в PNG, задав размер изображений: 
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


## **FAQ**

**Как я могу экспортировать только конкретную форму (например, диаграмму или изображение), а не весь слайд?**

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/php-java/create-shape-thumbnails/); вы можете отрисовать форму в PNG‑изображение.

**Поддерживается ли параллельное преобразование на сервере?**

Да, но [не делитесь](/slides/ru/php-java/multithreading/) одним экземпляром презентации между потоками. Используйте отдельный экземпляр для каждого потока или процесса.

**Каковы ограничения пробной версии при экспорте в PNG?**

Режим оценки добавляет водяной знак к создаваемым изображениями и накладывает [прочие ограничения](/slides/ru/php-java/licensing/), пока не будет применена лицензия.