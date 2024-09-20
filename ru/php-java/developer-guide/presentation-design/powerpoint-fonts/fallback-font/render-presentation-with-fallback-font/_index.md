---
title: Отображение презентации с запасным шрифтом
type: docs
weight: 30
url: /php-java/render-presentation-with-fallback-font/
---

Следующий пример включает в себя эти шаги:

1. Мы [создаем коллекцию правил запасного шрифта](/slides/php-java/create-fallback-fonts-collection/).
1. [Удаляем](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) правило запасного шрифта и [добавляем запасные шрифты](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) к другому правилу.
1. Устанавливаем коллекцию правил в метод [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
1. С помощью метода [Presentation.save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) мы можем сохранить презентацию в том же формате или сохранить её в другом. После того как коллекция правил запасного шрифта установлена в [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), эти правила применяются во время любых операций с презентацией: сохранение, отображение, преобразование и т.д.

```php
  # Создаем новый экземпляр коллекции правил
  $rulesList = new FontFallBackRulesCollection();
  # создаем несколько правил
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Пытаемся удалить запасной шрифт "Tahoma" из загруженных правил
    $fallBackRule->remove("Tahoma");
    # И обновляем правила для указанного диапазона
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Также мы можем удалить любые существующие правила из списка
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Назначаем подготовленный список правил для использования
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Отображение миниатюры с использованием инициализированной коллекции правил и сохранение в JPEG
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Сохраняем изображение на диск в формате JPEG
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
Узнайте больше о [Сохранении и Конвертации в Презентации](/slides/php-java/creating-saving-and-converting-a-presentation/).
{{% /alert %}}