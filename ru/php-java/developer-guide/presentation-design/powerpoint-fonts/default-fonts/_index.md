---
title: Шрифты по умолчанию - PowerPoint Java API
linktitle: Шрифты по умолчанию
type: docs
weight: 30
url: /php-java/default-font/
description: PowerPoint Java API позволяет установить шрифт по умолчанию для рендеринга презентации в PDF, XPS или миниатюры. В этой статье показано, как определить шрифт DefaultRegular и шрифт DefaultAsian для использования в качестве шрифтов по умолчанию.
---

## **Использование шрифтов по умолчанию для рендеринга презентации**
Aspose.Slides позволяет установить шрифт по умолчанию для рендеринга презентации в PDF, XPS или миниатюры. В этой статье показано, как определить шрифт DefaultRegular и шрифт DefaultAsian для использования в качестве шрифтов по умолчанию. Пожалуйста, выполните следующие шаги для загрузки шрифтов из внешних директорий, используя Aspose.Slides для PHP через Java API:

1. Создайте экземпляр [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions).
1. [Установите DefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) на желаемый шрифт. В следующем примере я использовал Wingdings.
1. [Установите DefaultAsianFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) на желаемый шрифт. Я также использовал Wingdings в следующем примере.
1. Загрузите презентацию, используя Presentation и установив параметры загрузки.
1. Теперь сгенерируйте миниатюру слайда, PDF и XPS, чтобы проверить результаты.

Реализация вышеуказанного приведена ниже.

```php
  # Используйте параметры загрузки для определения шрифтов по умолчанию
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Загрузите презентацию
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Генерация миниатюры слайда
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # Сохраните изображение на диск.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Генерация PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Генерация XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```