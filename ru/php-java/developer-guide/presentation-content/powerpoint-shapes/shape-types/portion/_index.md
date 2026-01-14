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
[**getCoordinates()**](https://reference.aspose.com/slides/php-java/aspose.slides/portion/getcoordinates/) метод был добавлен в класс [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) который позволяет получить координаты начала части.
```php
  # Создать экземпляр класса Prseetation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Перестройка контекста презентации
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


## **FAQ**

**Могу ли я применить гиперссылку только к части текста в одном абзаце?**

Да, вы можете [назначить гиперссылку](/slides/ru/php-java/manage-hyperlinks/) отдельной части; только этот фрагмент будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет Portion и что берётся из Paragraph/TextFrame?**

Свойства уровня Portion имеют наивысший приоритет. Если свойство не задано для [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/), движок берёт его из [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/); если оно не задано и там, — из [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) либо из стиля [theme](https://reference.aspose.com/slides/php-java/aspose.slides/theme/).

**Что произойдёт, если шрифт, указанный для Portion, отсутствует на целевой машине/сервере?**

[Правила подстановки шрифтов](/slides/ru/php-java/font-selection-sequence/) применяются. Текст может перераспределяться: могут измениться метрики, переносы и ширина, что имеет значение для точного позиционирования.

**Могу ли я задать прозрачность или градиент заливки текста на уровне Portion независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) могут отличаться от соседних фрагментов.