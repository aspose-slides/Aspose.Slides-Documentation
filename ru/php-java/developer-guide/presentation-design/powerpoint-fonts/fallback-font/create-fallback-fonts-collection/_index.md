---
title: Создание коллекции запасных шрифтов
type: docs
weight: 20
url: /ru/php-java/create-fallback-fonts-collection/
---

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection), который реализует [IFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRulesCollection) интерфейс. Можно добавлять или удалять правила из коллекции.

Затем эта коллекция может быть назначена методу [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager). FontsManager управляет шрифтами в презентации. Узнайте больше [О FontsManager и FontsLoader](/slides/ru/php-java/about-fontsmanager-and-fontsloader/).

Каждая [Презентация](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) имеет метод [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) с собственным экземпляром класса [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager).

Вот пример того, как создать коллекцию правил запасных шрифтов и назначить ее в [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) определенной презентации:  

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

После инициализации FontsManager с коллекцией запасных шрифтов, запасные шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Узнайте больше, как [Отобразить презентацию с запасным шрифтом](/slides/ru/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}