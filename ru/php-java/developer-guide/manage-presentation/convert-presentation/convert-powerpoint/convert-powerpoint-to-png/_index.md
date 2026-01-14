---
title: Конвертировать слайды PowerPoint в PNG в PHP
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/php-java/convert-powerpoint-to-png/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в PNG
- презентацию в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- PHP
- Aspose.Slides
description: "Конвертируйте презентации PowerPoint в высококачественные PNG‑изображения быстро с помощью Aspose.Slides для PHP через Java, обеспечивая точные, автоматизированные результаты."
---

## **О конвертации PowerPoint в PNG**

Формат PNG (Portable Network Graphics) не так популярен, как JPEG (Joint Photographic Experts Group), но он всё ещё очень популярен. 

**Случай использования:** Если у вас сложное изображение и размер не имеет значения, PNG — лучший формат изображения, чем JPEG. 

{{% alert title="Tip" color="primary" %}} Вы можете ознакомиться с бесплатными **конвертерами PowerPoint в PNG** от Aspose: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) и [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Это живой пример процесса, описанного на этой странице. {{% /alert %}}

## **Конвертация PowerPoint в PNG**

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Получите объект слайда из коллекции [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) класса [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/).
3. Вызовите метод [Slide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage), чтобы получить миниатюру каждого слайда.
4. Используйте метод [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) для сохранения миниатюры слайда в формате PNG.

Этот PHP‑код демонстрирует, как преобразовать презентацию PowerPoint в PNG:
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

Если вы хотите получить PNG‑файлы определённого масштаба, можете установить значения `desiredX` и `desiredY`, которые определяют размеры получаемой миниатюры. 

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


## **Конвертация PowerPoint в PNG с пользовательским размером**

Если вы хотите получить PNG‑файлы определённого размера, можете передать желаемые параметры `width` и `height` для `ImageSize`. 

Этот код показывает, как конвертировать PowerPoint в PNG, задав размер изображений: 
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


## **Вопросы и ответы**

**Как экспортировать только определённую форму (например, диаграмму или изображение), а не весь слайд?**  
Aspose.Slides поддерживает [создание миниатюр отдельных фигур](/slides/ru/php-java/create-shape-thumbnails/); вы можете отрисовать форму в PNG‑изображение.

**Поддерживается ли параллельная конвертация на сервере?**  
Да, но [не следует делить](/slides/ru/php-java/multithreading/) один экземпляр презентации между потоками. Используйте отдельный экземпляр для каждого потока или процесса.

**Каковы ограничения пробной версии при экспорте в PNG?**  
В режиме оценки к выходным изображениям добавляется водяной знак и применяются [другие ограничения](/slides/ru/php-java/licensing/), пока не будет применена лицензия.