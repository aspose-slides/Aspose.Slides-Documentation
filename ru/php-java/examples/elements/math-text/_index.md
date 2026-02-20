---
title: "Математический текст"
type: docs
weight: 160
url: /ru/php-java/examples/elements/math-text/
keywords:
  - "математический текст"
  - "добавление математического текста"
  - "доступ к математическому тексту"
  - "удаление математического текста"
  - "форматирование математического текста"
  - "примеры кода"
  - "PowerPoint"
  - "OpenDocument"
  - "презентация"
  - "PHP"
  - "Aspose.Slides"
description: "Работайте с математическим текстом в PHP с помощью Aspose.Slides: создавайте и редактируйте уравнения, дроби, радикалы, индексы, форматирование и рендерьте результаты для PPT и PPTX."
---
Иллюстрирует работу с текстовыми фигурами математических выражений и форматирование уравнений с использованием **Aspose.Slides for PHP via Java**.

## **Добавить математический текст**

Создайте форму с математическим выражением, содержащую дробь и форму Пифагора.

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Добавить форму с математикой на слайд.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // Доступ к математическому абзацу.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // Добавить простую дробь: x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // Добавить уравнение: c² = a² + b².
        $mathBlock = (new MathematicalText("c"))
            - >setSuperscript("2")
            - >join("=")
            - >join((new MathematicalText("a"))->setSuperscript("2"))
            - >join("+")
            - >join((new MathematicalText("b"))->setSuperscript("2"));
        $mathParagraph->add($mathBlock);

        $presentation->save("math_text.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Получить доступ к математическому тексту**

Найдите форму, содержащую абзац с математикой на слайде.

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Найти первую форму, содержащую математический абзац.
        $mathShape = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $textFrame = $shape->getTextFrame();
                if ($textFrame !== null) {
                    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
                    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                        $portionCount = java_values($paragraph->getPortions()->getCount());
                        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                            $portion = $paragraph->getPortions()->get_Item($portionIndex);
                            if (java_instanceof($portion, new JavaClass("com.aspose.slides.MathPortion"))) {
                                $mathShape = $shape;
                                break 3;
                            }
                        }
                    }
                }
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить математический текст**

Удалите математическую форму со слайда.

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что первая форма на слайде является формой Math.
        $mathShape = $slide->getShapes()->get_Item(0);

        // Удалить форму Math со слайда.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Форматировать математический текст**

Установите свойства шрифта для части математического текста.

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что первая форма на слайде является формой Math.
        $mathShape = $slide->getShapes()->get_Item(0);

        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(20);

        $presentation->save("math_text_formatted.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```