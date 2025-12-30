---
title: Укажите шрифты по умолчанию для презентаций в PHP
linktitle: Шрифт по умолчанию
type: docs
weight: 30
url: /ru/php-java/default-font/
keywords:
- шрифт по умолчанию
- обычный шрифт
- нормальный шрифт
- азиатский шрифт
- экспорт в PDF
- экспорт в XPS
- экспорт изображений
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Установите шрифты по умолчанию в Aspose.Slides для PHP через Java, чтобы обеспечить корректное преобразование PowerPoint (PPT, PPTX) и OpenDocument (ODP) в PDF, XPS и изображения."
---

## **Использовать шрифты по умолчанию для рендеринга презентации**
Aspose.Slides позволяет задать шрифт по умолчанию для рендеринга презентации в PDF, XPS или эскизы. В этой статье показано, как определить DefaultRegularFont и DefaultAsianFont для использования их в качестве шрифтов по умолчанию. Пожалуйста, выполните нижеописанные шаги для загрузки шрифтов из внешних каталогов с помощью Aspose.Slides for PHP via Java API:

1. Создайте экземпляр [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) на нужный шрифт. В следующем примере я использовал Wingdings.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) на нужный шрифт. В примере я также использовал Wingdings.
1. Загрузите презентацию с помощью Presentation, указав параметры загрузки.
1. Теперь сгенерируйте эскиз слайда, PDF и XPS, чтобы проверить результаты.

Реализация вышеописанного приведена ниже.
```php
  # Используйте параметры загрузки для определения шрифтов по умолчанию: обычного и азиатского
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Загрузите презентацию
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Сгенерировать миниатюру слайда
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # сохранить изображение на диск.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Сгенерировать PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Сгенерировать XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Что именно влияют DefaultRegularFont и DefaultAsianFont — только экспорт или также эскизы, PDF, XPS, HTML и SVG?**

Они участвуют в конвейере рендеринга для всех поддерживаемых форматов вывода. Это включает эскизы слайдов, [PDF](/slides/ru/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/ru/php-java/convert-powerpoint-to-xps/), [растровые изображения](/slides/ru/php-java/convert-powerpoint-to-png/), [HTML](/slides/ru/php-java/convert-powerpoint-to-html/) и [SVG](/slides/ru/php-java/render-a-slide-as-an-svg-image/), потому что Aspose.Slides использует одинаковую логику расположения и разрешения глифов для всех этих целей.

**Применяются ли шрифты по умолчанию при простом чтении и сохранении PPTX без рендеринга?**

Нет. Шрифты по умолчанию важны, когда текст необходимо измерять и отрисовывать. Простая операция «открыть‑и‑сохранить» не меняет сохранённые наборы шрифтов или структуру файла. Шрифты по умолчанию вступают в действие только во время операций, которые рендерят или перестраивают текст.

**Если я добавлю свои папки со шрифтами или предоставлю шрифты из памяти, будут ли они учитываться при выборе шрифтов по умолчанию?**

Да. [Custom font sources](/slides/ru/php-java/custom-font/) расширяют каталог доступных семейств и глифов, которые может использовать движок. Шрифты по умолчанию и любые [fallback rules](/slides/ru/php-java/fallback-font/) сначала будут разрешаться против этих источников, обеспечивая более надёжное покрытие на серверах и в контейнерах.

**Повлияют ли шрифты по умолчанию на метрики текста (кернинг, advance) и, следовательно, на разрывы строк и их перенос?**

Да. Смена шрифта меняет метрики глифов и может изменить разрывы строк, переносы и разбиение на страницы во время рендеринга. Для стабильности раскладки рекомендуется [embed the original fonts](/slides/ru/php-java/embedded-font/) или выбрать метрически совместимые семейства по умолчанию и запасные.

**Есть ли смысл задавать шрифты по умолчанию, если все шрифты в презентации встроены?**

Часто это не требуется, потому что [embedded fonts](/slides/ru/php-java/embedded-font/) уже обеспечивают одинаковый вид. Шрифты по умолчанию всё же полезны как резервный вариант для символов, не покрытых встроенным набором, или когда файл комбинирует встроенный и не встроенный текст.