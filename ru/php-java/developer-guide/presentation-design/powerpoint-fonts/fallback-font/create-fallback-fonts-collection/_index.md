---
title: Настройка коллекций резервных шрифтов в PHP
linktitle: Коллекция резервных шрифтов
type: docs
weight: 20
url: /ru/php-java/create-fallback-fonts-collection/
keywords:
- резервный шрифт
- правило резервного шрифта
- коллекция шрифтов
- настройка шрифта
- установка шрифта
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Создайте коллекцию резервных шрифтов в Aspose.Slides для PHP через Java, чтобы обеспечить согласованность и чёткость текста в презентациях PowerPoint и OpenDocument."
---

## **Применение правил резервного шрифта**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection). Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно назначить методу [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager). FontsManager управляет шрифтами во всей презентации. Подробнее о [About FontsManager and FontsLoader](/slides/ru/php-java/about-fontsmanager-and-fontsloader/).

У каждого [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) есть метод [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) со своей собственной копией класса [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager).

Ниже приведён пример создания коллекции правил резервных шрифтов и назначения её в [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) определённой презентации:  
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


После инициализации FontsManager коллекцией резервных шрифтов, резервные шрифты применяются во время рендеринга презентации.

{{% alert color="primary" %}} 
Подробнее о том, как [Render Presentation with Fallback Font](/slides/ru/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Будут ли мои правила резервного шрифта встроены в файл PPTX и видимы в PowerPoint после сохранения?**

Нет. Правила резервного шрифта являются настройками рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в пользовательском интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Для любого текста в этих объектах используется тот же механизм подстановки глифов.

**Поставляет ли Aspose какие‑либо шрифты вместе с библиотекой?**

Нет. Шрифты вы добавляете и используете самостоятельно, и это ваша ответственность.

**Можно ли использовать замену/подстановку недостающих шрифтов и резервный шрифт для недостающих глифов одновременно?**

Да. Это независимые этапы одного и того же конвейера разрешения шрифтов: сначала движок определяет наличие шрифтов ([replacement](/slides/ru/php-java/font-replacement/)/[substitution](/slides/ru/php-java/font-substitution/)), затем резервный шрифт заполняет пробелы для недостающих глифов в доступных шрифтах.