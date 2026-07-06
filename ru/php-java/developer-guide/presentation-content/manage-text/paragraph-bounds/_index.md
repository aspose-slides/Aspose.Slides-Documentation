---
title: Получить границы абзаца из презентаций в PHP
linktitle: Границы абзаца
type: docs
weight: 43
url: /ru/php-java/paragraph-bounds/
keywords:
- границы абзаца
- координаты абзаца
- размер абзаца
- текстовый кадр
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как получить границы абзаца в Aspose.Slides для PHP через Java, чтобы оптимизировать размещение текста в презентациях PowerPoint."
---
## **Обзор**

Эта статья объясняет, как получить границы, размер и координаты абзацев в Aspose.Slides. Она показывает, как получить прямоугольник абзаца из [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) с помощью [Paragraph::getRect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/getrect/), как получить координаты абзаца внутри текстового кадра ячейки таблицы и выделяет важные детали, такие как единицы измерения, влияние переноса текста на границы, преобразование в пиксели и эффективные значения форматирования абзаца.

## **Получить прямоугольные координаты абзаца**

Используйте [Paragraph::getRect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/getrect/) для получения ограничивающего прямоугольника абзаца.

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **Получить размер абзаца внутри текстового кадра ячейки таблицы**

Чтобы получить размер и координаты [Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/) в текстовом кадре ячейки таблицы, используйте [Paragraph::getRect](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/getrect/). Возвращаемый прямоугольник относится к текстовому кадру ячейки таблицы, поэтому добавляйте позицию таблицы и смещение ячейки, когда нужны координаты уровня слайда.

Следующий пример получает границы абзаца внутри ячейки таблицы и рисует прямоугольники на слайде для визуализации этих границ:

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Часто задаваемые вопросы**

**В каких единицах измеряются координаты абзаца?**

Они измеряются в пунктах, где 1 дюйм равен 72 пунктам. Это относится ко всем координатам и размерам на слайде.

**Влияет ли перенос слов на границы абзаца?**

Да. Если для [TextFrame](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframe/) включен [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/ru/php-java/aspose.slides/textframeformat/setwraptext/), текст переносится, чтобы соответствовать ширине области, что изменяет фактические границы абзаца.

**Можно ли надёжно преобразовать координаты абзаца в пиксели при экспорте изображения?**

Да. Преобразуйте пункты в пиксели по формуле: пиксели = пункты × (DPI / 72). Результат зависит от выбранного DPI для рендеринга или экспорта.

**Как получить «эффективные» параметры форматирования абзаца с учётом наследования стилей?**

Используйте [effective paragraph formatting data structure](/slides/ru/php-java/shape-effective-properties/); он возвращает окончательные объединённые значения отступов, интервалов, переносов, RTL и других параметров.