---
title: Отображение презентаций с резервными шрифтами в PHP
linktitle: Отображение презентаций
type: docs
weight: 30
url: /ru/php-java/render-presentation-with-fallback-font/
keywords:
- резервный шрифт
- отображение PowerPoint
- отображение презентации
- отображение слайда
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Отображайте презентации с резервными шрифтами в Aspose.Slides для PHP через Java — сохраняйте единообразие текста в PPT, PPTX и ODP с пошаговыми примерами кода."
---

В следующем примере приведены следующие шаги:

1. Мы [создаем коллекцию правил резервных шрифтов](/slides/ru/php-java/create-fallback-fonts-collection/).
1. [Удалить](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) правило резервного шрифта и [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) к другому правилу.
1. Установите коллекцию правил с помощью метода [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
1. С помощью метода [Presentation.save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) мы можем сохранить презентацию в том же формате или в другом. После того как коллекция правил резервных шрифтов установлена в [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), эти правила применяются при любых операциях с презентацией: сохранение, рендеринг, конвертация и т.д.
```php
  # Создать новый экземпляр коллекции правил
  $rulesList = new FontFallBackRulesCollection();
  # создать несколько правил
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Пытаемся удалить шрифт FallBack "Tahoma" из загруженных правил
    $fallBackRule->remove("Tahoma");
    # И обновить правила для указанного диапазона
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Также можно удалить любые существующие правила из списка
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Назначение подготовленного списка правил для использования
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Рендеринг миниатюры с использованием инициализированной коллекции правил и сохранением в JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Сохранить изображение на диск в формате JPEG
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
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


{{% alert color="primary" %}} 
Узнайте больше о том, как [конвертировать PPT и PPTX в JPG на PHP](/slides/ru/php-java/convert-powerpoint-to-jpg/).
{{% /alert %}}