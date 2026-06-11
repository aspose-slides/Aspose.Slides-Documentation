---
title: Pole tekstowe
type: docs
weight: 40
url: /pl/php-java/examples/elements/text-box/
keywords:
- pole tekstowe
- dodaj pole tekstowe
- dostęp do pola tekstowego
- usuń pole tekstowe
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Tworzenie i formatowanie pól tekstowych w PHP przy użyciu Aspose.Slides: ustawianie czcionek, wyrównania, zawijania, automatycznego dopasowania i linków do polskich slajdów dla PowerPoint i OpenDocument."
---
W Aspose.Slides **pole tekstowe** jest reprezentowane przez `AutoShape`. Prawie każdy kształt może zawierać tekst, ale typowe pole tekstowe nie ma wypełnienia ani obramowania i wyświetla tylko tekst.

Ten przewodnik wyjaśnia, jak programowo dodawać, uzyskiwać dostęp i usuwać pola tekstowe.

## **Dodaj pole tekstowe**

Pole tekstowe to po prostu `AutoShape` bez wypełnienia i obramowania oraz z pewnym sformatowanym tekstem. Oto jak je utworzyć:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Utwórz prostokątny kształt (domyślnie wypełniony obramowaniem i bez tekstu).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Usuń wypełnienie i obramowanie, aby wyglądało jak typowe pole tekstowe.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Ustaw formatowanie tekstu.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Przypisz rzeczywistą treść tekstu.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Uwaga:** Każdy `AutoShape`, który zawiera niepusty `TextFrame`, może pełnić funkcję pola tekstowego.

## **Uzyskaj dostęp do pól tekstowych według zawartości**

Aby znaleźć wszystkie pola tekstowe zawierające określone słowo kluczowe (np. „Slide”), przeiteruj kształty i sprawdź ich tekst:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Uzyskaj dostęp do pierwszego pola tekstowego na slajdzie.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Zrób coś z dopasowanym polem tekstowym.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Usuń pola tekstowe według zawartości**

Ten przykład znajduje i usuwa wszystkie pola tekstowe na pierwszym slajdzie, które zawierają określone słowo kluczowe:

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

> 💡 **Porada:** Zawsze twórz kopię kolekcji kształtów przed modyfikacją podczas iteracji, aby uniknąć błędów związanych ze zmianą kolekcji.