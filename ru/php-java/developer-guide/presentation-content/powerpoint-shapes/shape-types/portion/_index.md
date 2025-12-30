---
title: Управление частями текста в презентациях с помощью PHP
linktitle: Текстовая часть
type: docs
weight: 70
url: /ru/php-java/portion/
keywords:
- текстовая часть
- часть текста
- координаты текста
- позиция текста
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как управлять частями текста в презентациях PowerPoint, используя Aspose.Slides для PHP через Java, повышая производительность и возможность настройки."
---

## **Получить координаты части текста**
Метод [**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion#getCoordinates--) был добавлен в классы [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPortion) и [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/classes/Portion), что позволяет получить координаты начала части текста.
```php
  # Создать объект класса Presentation, представляющий PPTX
  # Переформировать контекст презентации
  $pres = new Presentation();
  try {
    # Reshaping the context of presentation
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Часто задаваемые вопросы**

**Могу ли я применить гиперссылку только к части текста в одном абзаце?**

Да, вы можете [назначить гиперссылку](/slides/ru/php-java/manage-hyperlinks/) отдельной части; только этот фрагмент будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет Portion и что берётся из Paragraph/TextFrame?**

Свойства уровня Portion имеют наивысший приоритет. Если свойство не задано у [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/), движок берёт его из [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/); если оно не задано и там, то из [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) или стиля [theme](https://reference.aspose.com/slides/php-java/aspose.slides/theme/).

**Что происходит, если шрифт, указанный для Portion, отсутствует на целевой машине/сервере?**

[Правила подстановки шрифтов](/slides/ru/php-java/font-selection-sequence/) применяются. Текст может перераспределиться: метрики, переносы и ширина могут измениться, что важно для точного позиционирования.

**Могу ли я задать прозрачность заливки текста или градиент для конкретного Portion независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) могут отличаться от соседних фрагментов.