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
description: "Создайте коллекцию резервных шрифтов в Aspose.Slides для PHP через Java, чтобы текст в презентациях PowerPoint и OpenDocument оставался согласованным и чётким."
---

## **Применить правила резервного шрифта**

Экземпляры класса [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) можно организовать в [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection), который реализует интерфейс [IFontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRulesCollection). Можно добавлять или удалять правила из этой коллекции.

Затем эту коллекцию можно назначить методу [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager). FontsManager управляет шрифтами во всей презентации. Подробнее [О FontsManager и FontsLoader](/slides/ru/php-java/about-fontsmanager-and-fontsloader/).

У каждого [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) есть метод [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) с собственным экземпляром класса [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager).

Ниже приведён пример того, как создать коллекцию правил резервных шрифтов и назначить её в [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager--) определённой презентации:  
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


После инициализации FontsManager коллекцией резервных шрифтов, резервные шрифты применяются во время отрисовки презентации.

{{% alert color="primary" %}} 
Подробнее о том, как [Отрисовка презентации с резервным шрифтом](/slides/ru/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Будут ли мои правила резервного шрифта встроены в файл PPTX и видны в PowerPoint после сохранения?**

Нет. Правила резервного шрифта представляют собой настройки рендеринга во время выполнения; они не сериализуются в PPTX и не будут отображаться в пользовательском интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Для любого текста в этих объектах используется тот же механизм подстановки глифов.

**Поставляет ли Aspose какие‑либо шрифты вместе с библиотекой?**

Нет. Шрифты вы добавляете и используете самостоятельно, полностью отвечая за них.

**Можно ли одновременно использовать замену/подстановку недостающих шрифтов и резервный шрифт для недостающих глифов?**

Да. Это независимые этапы одного конвейера разрешения шрифтов: сначала движок определяет доступность шрифтов ([replacement](/slides/ru/php-java/font-replacement/)/[substitution](/slides/ru/php-java/font-substitution/)), затем резервный шрифт заполняет пробелы недостающих глифов в доступных шрифтах.