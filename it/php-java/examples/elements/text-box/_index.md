---
title: Casella di testo
type: docs
weight: 40
url: /it/php-java/examples/elements/text-box/
keywords:
- casella di testo
- aggiungere casella di testo
- accedere casella di testo
- rimuovere casella di testo
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Crea e formatta le caselle di testo in PHP con Aspose.Slides: imposta caratteri, allineamento, a capo, adattamento automatico e collegamenti per perfezionare le diapositive per PowerPoint e OpenDocument."
---
In Aspose.Slides, una **casella di testo** è rappresentata da un `AutoShape`. Quasi qualsiasi forma può contenere testo, ma una tipica casella di testo non ha riempimento né bordo e mostra solo il testo.

Questa guida spiega come aggiungere, accedere e rimuovere le caselle di testo programmaticamente.

## **Aggiungi una casella di testo**

Una casella di testo è semplicemente un `AutoShape` senza riempimento né bordo e con del testo formattato. Ecco come crearne una:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Crea una forma rettangolare (predefinita con riempimento e bordo e senza testo).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Rimuovi riempimento e bordo per farla apparire come una tipica casella di testo.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Imposta la formattazione del testo.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Assegna il contenuto testuale effettivo.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Nota:** Qualsiasi `AutoShape` che contiene un `TextFrame` non vuoto può funzionare come una casella di testo.

## **Accedi alle caselle di testo per contenuto**

Per trovare tutte le caselle di testo che contengono una parola chiave specifica (ad esempio "Slide"), itera attraverso le forme e controlla il loro testo:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accedi alla prima casella di testo nella diapositiva.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Esegui un'operazione con la casella di testo corrispondente.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi le caselle di testo per contenuto**

Questo esempio trova ed elimina tutte le caselle di testo nella prima diapositiva che contengono una parola chiave specifica:

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

> 💡 **Suggerimento:** Crea sempre una copia della raccolta di forme prima di modificarla durante l'iterazione per evitare errori di modifica della collezione.