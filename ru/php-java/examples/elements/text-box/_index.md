---
title: Текстовое поле
type: docs
weight: 40
url: /ru/php-java/examples/elements/text-box/
keywords:
- текстовое поле
- добавить текстовое поле
- доступ к текстовому полю
- удалить текстовое поле
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Создавайте и форматируйте текстовые поля в PHP с помощью Aspose.Slides: задавайте шрифты, выравнивание, перенос, автоматический подбор размеров и ссылки для улучшения слайдов в PowerPoint и OpenDocument."
---
В Aspose.Slides **текстовое поле** представлено как `AutoShape`. Практически любая фигура может содержать текст, но обычное текстовое поле не имеет заливки и границы и отображает только текст.

В этом руководстве объясняется, как программно добавлять, получать и удалять текстовые поля.

## **Добавить текстовое поле**

Текстовое поле — это просто `AutoShape` без заливки и границы и с некоторым форматированным текстом. Ниже показано, как его создать:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Создайте прямоугольную фигуру (по умолчанию заполнена границей и без текста).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Удалите заполнение и границу, чтобы выглядеть как типичное текстовое поле.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Установите форматирование текста.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Присвойте фактическое содержание текста.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Примечание:** Любой `AutoShape`, содержащий непустой `TextFrame`, может функционировать как текстовое поле.

## **Доступ к текстовым полям по содержимому**

Чтобы найти все текстовые поля, содержащие определённое ключевое слово (например, «Slide»), пройдите по фигурам и проверьте их текст:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Получить первое текстовое поле на слайде.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Выполнить действие с найденным текстовым полем.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить текстовые поля по содержимому**

В этом примере находятся и удаляются все текстовые поля на первом слайде, содержащие определённое ключевое слово:

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Совет:** Всегда создавайте копию коллекции фигур перед её изменением во время итерации, чтобы избежать ошибок изменения коллекции.