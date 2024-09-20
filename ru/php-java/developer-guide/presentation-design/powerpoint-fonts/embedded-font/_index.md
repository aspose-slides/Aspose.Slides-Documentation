---
title: Встроенные шрифты - PowerPoint Java API
linktitle: Встроенные шрифты
type: docs
weight: 40
url: /php-java/embedded-font/
keywords: "Шрифты, встроенные шрифты, добавление шрифтов, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Используйте встроенные шрифты в презентации PowerPoint"
---

**Встроенные шрифты в PowerPoint** полезны, когда вы хотите, чтобы ваша презентация корректно отображалась на любой системе или устройстве. Если вы использовали сторонний или нестандартный шрифт, потому что проявили креативность в своей работе, у вас еще больше причин встроить этот шрифт. В противном случае (без встроенных шрифтов) текст или цифры на ваших слайдах, макет, стилизация и т. д. могут измениться или превратиться в непонятные прямоугольники.

Класс [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), класс [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) и класс [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) и их интерфейсы содержат большинство свойств и методов, необходимых для работы с встроенными шрифтами в презентациях PowerPoint.

## **Получение или удаление встроенных шрифтов из презентации**

Aspose.Slides предоставляет метод [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (представленный классом [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)), который позволяет вам получить (или узнать) встроенные в презентацию шрифты. Для удаления шрифтов используется метод [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (представленный тем же классом).

Этот PHP-код показывает, как получить и удалить встроенные шрифты из презентации:

```php
  # Создает объект Presentation, представляющий файл презентации
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Рендерит слайд, содержащий текстовый фрейм, который использует встроенный "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Сохраняет изображение на диск в формате JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Получает все встроенные шрифты
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Находит шрифт "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Удаляет шрифт "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Рендерит презентацию; шрифт "Calibri" заменяется существующим
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Сохраняет изображение на диск в формате JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Сохраняет презентацию без встроенного шрифта "Calibri" на диск
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Добавление встроенных шрифтов в презентацию**

Используя перечисление [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) и два перегруженных метода [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) метода, вы можете выбрать предпочитаемое правило (встраивания) для добавления шрифтов в презентацию. Этот PHP-код показывает, как встроить и добавить шрифты в презентацию:

```php
  # Загружает презентацию
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # Сохраняет презентацию на диск
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Сжатие встроенных шрифтов**

Чтобы вы могли сжать встроенные в презентацию шрифты и уменьшить размер файла, Aspose.Slides предоставляет метод [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (представленный классом [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)).

Этот PHP-код показывает, как сжать встроенные шрифты PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```