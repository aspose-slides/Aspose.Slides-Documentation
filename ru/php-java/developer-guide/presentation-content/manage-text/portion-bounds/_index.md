---
title: Получить границы текстового фрагмента из презентаций в PHP
linktitle: Границы фрагмента
type: docs
weight: 47
url: /ru/php-java/portion-bounds/
keywords:
- границы текстового фрагмента
- текстовый фрагмент
- часть текста
- координаты текста
- позиция текста
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как получить границы текстового фрагмента в презентациях PowerPoint с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Текстовый фрагмент представляет собой конкретный отрывок текста внутри абзаца и позволяет работать с этим отрывком независимо от окружающего содержимого. В Aspose.Slides фрагменты могут использоваться, когда нужно получить границы текстового отрывка, применить форматирование только к части абзаца или управлять поведением текста на более детальном уровне.

В этой статье показано, как получить ограничивающий прямоугольник фрагмента, используя [Portion::getRect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/getrect/). Также показано, как получить координаты начала фрагмента, используя [Portion::getCoordinates](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/getcoordinates/). Кроме того, рассматриваются типичные сценарии, связанные с фрагментами, такие как применение гиперссылки к отдельному текстовому отрывку, понимание того, как форматирование разрешается через уровень фрагмента, абзаца, текстового кадра и наследование темы, а также обработка случаев, когда указанный шрифт недоступен.

## **Получить границы текстового фрагмента**

Используйте [Portion::getRect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/getrect/) для получения ограничивающего прямоугольника текстового фрагмента:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Получить координаты текстового фрагмента**

Используйте [Portion::getCoordinates](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/getcoordinates/) для получения координат начала текстового фрагмента:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Вопросы и ответы**

**Можно ли применить гиперссылку только к части текста внутри одного абзаца?**

Да, вы можете [присвоить гиперссылку](/slides/ru/php-java/manage-hyperlinks/) отдельному фрагменту; только этот отрывок будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет фрагмент, а что берётся из абзаца или текстового кадра?**

Свойства уровня фрагмента имеют наивысший приоритет. Если свойство не задано у [Portion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/), Aspose.Slides берёт его из [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/). Если оно не задано и там, Aspose.Slides использует стиль из [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) или [theme](https://reference.aspose.com/slides/ru/php-java/aspose.slides/theme/).

**Что происходит, если указанный для фрагмента шрифт отсутствует на целевой машине или сервере?**

[Правила подстановки шрифтов](/slides/ru/php-java/font-selection-sequence/) применяются. Текст может перераспределиться: метрики, переносы и ширина могут измениться, что важно для точного позиционирования.

**Могу ли я задать прозрачность заливки текста или градиент для конкретного фрагмента независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [Portion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/) могут отличаться от соседних фрагментов.