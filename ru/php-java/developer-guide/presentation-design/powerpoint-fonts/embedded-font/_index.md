---
title: Встраивание шрифтов в презентации с использованием PHP
linktitle: Встраивание шрифта
type: docs
weight: 40
url: /ru/php-java/embedded-font/
keywords:
- добавить шрифт
- встроить шрифт
- встраивание шрифтов
- получить встроенный шрифт
- добавить встроенный шрифт
- удалить встроенный шрифт
- сжать встроенный шрифт
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Встраивание шрифтов TrueType в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java, обеспечивая точный рендеринг на всех платформах."
---

**Встроенные шрифты в PowerPoint** полезны, когда вы хотите, чтобы ваша презентация отображалась правильно на любой системе или устройстве. Если вы использовали сторонний или нестандартный шрифт, потому что проявили креативность в работе, то у вас есть еще больше причин встроить шрифт. В противном случае (без встроенных шрифтов) текст или цифры на слайдах, макет, стиль и т. д. могут измениться или превратиться в непонятные прямоугольники. 

Классы [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) и [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) , а также их интерфейсы содержат большинство свойств и методов, необходимых для работы со встроенными шрифтами в презентациях PowerPoint.

## **Получить и удалить встроенные шрифты**

Aspose.Slides предоставляет метод [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (доступный через класс [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)), позволяющий получить (или узнать) шрифты, встроенные в презентацию. Для удаления шрифтов используется метод [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (доступный тем же классом).

```php
  # Создает объект Presentation, представляющий файл презентации
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Отрисовывает слайд, содержащий текстовый фрейм, использующий встроенный "FunSized"
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
    # Ищет шрифт "Calibri"
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
    # Отрисовывает презентацию; шрифт "Calibri" заменяется существующим
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


## **Добавить встроенные шрифты**

С помощью перечисления [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) и двух перегрузок метода [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) вы можете выбрать предпочтительное правило встраивания шрифтов в презентацию. Этот PHP‑код показывает, как встраивать и добавлять шрифты в презентацию:

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


## **Сжать встроенные шрифты**

Чтобы вы могли сжать встроенные в презентацию шрифты и уменьшить размер файла, Aspose.Slides предоставляет метод [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (доступный через класс [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)).

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


## **FAQ**

**Как определить, что конкретный шрифт в презентации всё равно будет заменён при рендеринге, несмотря на встраивание?**

Проверьте [substitution information](/slides/ru/php-java/font-substitution/) в менеджере шрифтов и [fallback/substitution rules](/slides/ru/php-java/fallback-font/): если шрифт недоступен или ограничен, будет использован резервный шрифт.

**Стоит ли встраивать «системные» шрифты, такие как Arial/Calibri?**

Обычно нет — они почти всегда доступны. Однако для полной переносимости в «тонких» средах (Docker, Linux‑сервер без предустановленных шрифтов) встраивание системных шрифтов может устранить риск неожиданных замен.