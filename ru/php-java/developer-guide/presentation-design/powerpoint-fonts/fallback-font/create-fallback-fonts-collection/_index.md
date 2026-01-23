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
description: "Настройте коллекцию резервных шрифтов в Aspose.Slides для PHP через Java, чтобы текст оставался согласованным и чётким в презентациях PowerPoint и OpenDocument."
---

## **Применение правил резервного шрифта**

Экземпляры [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) класса могут быть организованы в [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection). Можно добавлять или удалять правила из коллекции.

Затем эту коллекцию можно назначить методу [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) класса [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager). FontsManager управляет шрифтами во всей презентации.

У каждого [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) есть метод [getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager), возвращающий собственный экземпляр класса [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager).

Ниже приведён пример того, как создать коллекцию правил резервных шрифтов и назначить её в [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getFontsManager) определённой презентации:
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


После инициализации FontsManager коллекцией резервных шрифтов, резервные шрифты применяются при рендеринге презентации.

{{% alert color="primary" %}} 
Подробнее о том, как [Отобразить презентацию с резервным шрифтом](/slides/ru/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Вопросы и ответы**

**Будут ли мои правила резервного шрифта внедрены в файл PPTX и видны в PowerPoint после сохранения?**

Нет. Правила резервного шрифта являются настройками рендеринга во время выполнения; они не сериализуются в PPTX и не появятся в пользовательском интерфейсе PowerPoint.

**Применяется ли резервный шрифт к тексту внутри SmartArt, WordArt, диаграмм и таблиц?**

Да. Тот же механизм подстановки глифов используется для любого текста в этих объектах.

**Поставляет ли Aspose какие‑либо шрифты вместе с библиотекой?**

Нет. Вы добавляете и используете шрифты самостоятельно и отвечаете за их наличие.

**Можно ли использовать замену/подстановку недостающих шрифтов и резервный шрифт для отсутствующих глифов одновременно?**

Да. Это независимые этапы одного конвейера разрешения шрифтов: сначала движок решает доступность шрифтов ([replacement](/slides/ru/php-java/font-replacement/)/[substitution](/slides/ru/php-java/font-substitution/)), затем резервный шрифт заполняет пробелы для отсутствующих глифов в доступных шрифтах.