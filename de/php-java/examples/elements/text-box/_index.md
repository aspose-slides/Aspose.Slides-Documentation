---
title: Textfeld
type: docs
weight: 40
url: /de/php-java/examples/elements/text-box/
keywords:
- Textfeld
- Textfeld hinzufügen
- Auf Textfeld zugreifen
- Textfeld entfernen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen und formatieren Sie Textfelder in PHP mit Aspose.Slides: Schriftarten, Ausrichtung, Zeilenumbrüche, automatisches Anpassen und Links festlegen, um Folien für PowerPoint und OpenDocument zu verfeinern."
---
In Aspose.Slides wird ein **Textfeld** durch ein `AutoShape` dargestellt. Praktisch jede Form kann Text enthalten, aber ein typisches Textfeld hat keine Füllung oder Kontur und zeigt nur Text an.

Diese Anleitung erklärt, wie man Textfelder programmgesteuert hinzufügt, darauf zugreift und sie entfernt.

## **Textfeld hinzufügen**

Ein Textfeld ist einfach ein `AutoShape` ohne Füllung oder Kontur und mit etwas formatiertem Text. So erstellen Sie eines:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Erstelle eine Rechteckform (standardmäßig gefüllt mit Rahmen und ohne Text).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Entferne Füllung und Rahmen, um es wie ein typisches Textfeld aussehen zu lassen.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Textformatierung festlegen.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Zuweisen des tatsächlichen Textinhalts.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Hinweis:** Jedes `AutoShape`, das ein nicht leeres `TextFrame` enthält, kann als Textfeld fungieren.

## **Zugriff auf Textfelder nach Inhalt**

Um alle Textfelder zu finden, die ein bestimmtes Schlüsselwort enthalten (z. B. "Slide"), iterieren Sie über die Formen und prüfen deren Text:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Greift auf das erste Textfeld in der Folie zu.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Etwas mit dem passenden Textfeld machen.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Entfernen von Textfeldern nach Inhalt**

Dieses Beispiel findet und löscht alle Textfelder auf der ersten Folie, die ein bestimmtes Schlüsselwort enthalten:

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

> 💡 **Tipp:** Erstellen Sie stets eine Kopie der Formensammlung, bevor Sie sie während einer Iteration ändern, um Fehler bei der Modifikation der Sammlung zu vermeiden.