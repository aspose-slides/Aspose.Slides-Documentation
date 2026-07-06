---
title: Absatzgrenzen aus Präsentationen in PHP abrufen
linktitle: Absatzgrenzen
type: docs
weight: 43
url: /de/php-java/paragraph-bounds/
keywords:
- Absatzgrenzen
- Absatzkoordinaten
- Absatzgröße
- Textfeld
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Absatzgrenzen in Aspose.Slides für PHP über Java abrufen, um die Textpositionierung in PowerPoint‑Präsentationen zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man die Begrenzungen, die Größe und die Koordinaten von Absätzen in Aspose.Slides ermittelt. Er zeigt, wie man ein Absatzrechteck aus einem [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) mithilfe von [Paragraph::getRect](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/getrect/) abruft, wie man Absatzkoordinaten innerhalb eines Tabellenzellen‑TextFrames erhält und hebt wichtige Details hervor, wie Maßeinheiten, die Auswirkung von Textumbruch auf die Begrenzungen, Pixelumrechnung und effektive Absatzformatierungswerte.

## **Rechteckige Koordinaten eines Absatzes erhalten**

Verwenden Sie [Paragraph::getRect](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/getrect/), um das Begrenzungsrechteck eines Absatzes zu erhalten.

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

## **Größe eines Absatzes innerhalb eines Tabellenzellen‑TextFrames ermitteln**

Um die Größe und die Koordinaten eines [Paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/) in einem Tabellenzellen‑TextFrame zu erhalten, verwenden Sie [Paragraph::getRect](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/getrect/). Das zurückgegebene Rechteck ist relativ zum Tabellenzellen‑TextFrame, daher müssen Sie die Tabellenposition und den Zellenversatz hinzufügen, wenn Sie Folien‑bezogene Koordinaten benötigen.

Das folgende Beispiel ermittelt die Absatzbegrenzungen innerhalb einer Tabellenzelle und zeichnet Rechtecke auf die Folie, um diese Begrenzungen zu visualisieren:

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

## **FAQ**

**In welchen Einheiten werden Absatzkoordinaten gemessen?**

Sie werden in Punkten gemessen, wobei 1 Zoll 72 Punkten entspricht. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Wirkt sich der Zeilenumbruch auf die Begrenzungen eines Absatzes aus?**

Ja. Wenn [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/setwraptext/) für den [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) aktiviert ist, wird der Text so umbrochen, dass er in die Breite des Bereichs passt, was die tatsächlichen Begrenzungen des Absatzes ändert.

**Können Absatzkoordinaten zuverlässig in Pixel im exportierten Bild umgerechnet werden?**

Ja. Konvertieren Sie Punkte in Pixel mit folgender Formel: pixel = punkte x (DPI / 72). Das Ergebnis hängt vom für die Darstellung oder den Export gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter, die die Vererbung von Stilen berücksichtigen?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/php-java/shape-effective-properties/); sie liefert die endgültigen konsolidierten Werte für Einzüge, Abstand, Umbruch, RTL und mehr.