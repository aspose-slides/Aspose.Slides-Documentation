---
title: Преобразование PowerPoint в анимированный GIF
type: docs
weight: 65
url: /ru/php-java/convert-powerpoint-to-animated-gif/
keywords: "Преобразование PowerPoint в анимированный GIF, PPT в GIF, PPTX в GIF"
description: "Преобразование PowerPoint в анимированный GIF: PPT в GIF, PPTX в GIF с помощью API Aspose.Slides."
---

## Преобразование презентаций в анимированный GIF с использованием стандартных настроек ##

Этот образец кода показывает, как преобразовать презентацию в анимированный GIF с использованием стандартных настроек:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Анимированный GIF будет создан с параметрами по умолчанию. 

{{%  alert  title="СОВЕТ"  color="primary"  %}} 

Если вы хотите настроить параметры для GIF, вы можете использовать класс [GifOptions](https://reference.aspose.com/slides/php-java/aspose.slides/GifOptions). Смотрите пример кода ниже.

{{% /alert %}} 

## Преобразование презентаций в анимированный GIF с использованием пользовательских настроек ##
Этот образец кода показывает, как преобразовать презентацию в анимированный GIF с использованием пользовательских настроек:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// размер полученного GIF

    $gifOptions->setDefaultDelay(2000);// как долго будет показываться каждый слайд до его замены на следующий

    $gifOptions->setTransitionFps(35);// увеличьте FPS для лучшего качества анимации перехода

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Информация" color="info" %}}

Вам может быть интересно узнать о БЕСПЛАТНОМ конвертере [Текст в GIF](https://products.aspose.app/slides/text-to-gif), разработанном компанией Aspose. 

{{% /alert %}}