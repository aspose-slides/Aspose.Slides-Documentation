---
title: PowerPoint-Textabsätze in PHP verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- Text hinzufügen
- Absatz hinzufügen
- Text verwalten
- Absatz verwalten
- Aufzählungszeichen verwalten
- Absatzeinzug
- Hängender Einzug
- Absatzaufzählungszeichen
- Nummerierte Liste
- Aufzählungsliste
- Absatzeigenschaften
- HTML importieren
- Text zu HTML
- Absatz zu HTML
- Absatz zu Bild
- Text zu Bild
- Absatz exportieren
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für PHP via Java Absätze, Portionen, Aufzählungszeichen, nummerierte Listen, Einzüge, HTML-Inhalte und Absatz-Bilder erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides for PHP via Java stellt Text als Hierarchie von TextFrames, Paragraphs und Portions dar:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) repräsentiert den Textbehälter in einer Form und bietet Zugriff auf die zugehörige Paragraph‑Sammlung.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) stellt einen Absatz in einem TextFrame dar und ermöglicht den Zugriff auf seine Portions sowie die Absatzformatierung.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) repräsentiert einen Textlauf innerhalb eines Paragraphs. Jede Portion kann über eigenen Text und Zeichenformatierung verfügen.

Ein Paragraph kann daher Text mit unterschiedlichen Schriftarten, Farben, Größen und anderer Formatierung enthalten, indem mehrere Portions verwendet werden.

## **Absätze erstellen und formatieren**

### **Absätze mit mehreren Portions erstellen**

Die folgenden Schritte erzeugen einen TextFrame mit drei Paragraphs, wobei jeder drei Portions enthält:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die gewünschte Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) der Form zu.
5. Verwenden Sie den Standard‑Paragraph und fügen Sie dem TextFrame zwei weitere [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)‑Objekte hinzu.
6. Fügen Sie genügend [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)‑Objekte hinzu, sodass jeder Paragraph drei Portions enthält. Der Standard‑Paragraph enthält bereits eine leere Portion.
7. Setzen Sie den Text jeder Portion.
8. Wenden Sie Zeichenformatierung über [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat--) an.
9. Speichern Sie die geänderte Präsentation.

Dieses PHP‑Beispiel implementiert die Schritte:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Aufzählungs- und nummerierte Listen erstellen**

### **Eine Aufzählungs- oder nummerierte Liste erstellen**

Aufzählungszeichen und Nummerierung erleichtern das Scannen verwandter Elemente. In Aspose.Slides werden Listeneinstellungen über [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) definiert.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die gewünschte Folie zu.
3. Fügen Sie der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) der Form zu.
5. Entfernen Sie den Standard‑Paragraph aus dem TextFrame.
6. Erstellen Sie einen [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) für ein Symbol‑Aufzählungszeichen.
7. Setzen Sie [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) auf [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/) und geben Sie das Aufzählungszeichenzeichen an.
8. Setzen Sie den Paragraph‑Text, Einzug, Aufzählungszeichenfarbe und Aufzählungszeichenhöhe.
9. Fügen Sie den Paragraph dem TextFrame hinzu.
10. Erstellen Sie einen zweiten Paragraph und setzen Sie [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) auf [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/).
11. Konfigurieren Sie den nummerierten Aufzählungsstil und fügen Sie den Paragraph dem TextFrame hinzu.
12. Speichern Sie die Präsentation.

Dieses PHP‑Beispiel erzeugt ein Symbol‑Aufzählungszeichen und ein nummeriertes Aufzählungszeichen:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Bild‑Aufzählungszeichen verwenden**

Bild‑Aufzählungszeichen ermöglichen es, ein benutzerdefiniertes Bild anstelle eines Symbols oder einer Zahl zu verwenden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie über den Index auf die gewünschte Folie zu.
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu und greifen Sie auf dessen [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) zu.
4. Entfernen Sie den Standard‑Paragraph aus dem TextFrame.
5. Laden Sie das Aufzählungszeichen‑Bild und fügen Sie es der Bildsammlung der Präsentation als [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) hinzu.
6. Erstellen Sie einen [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) und setzen Sie dessen Text.
7. Setzen Sie [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) auf [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/).
8. Ordnen Sie das Bild über [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture--) zu und setzen Sie die Aufzählungszeichenhöhe.
9. Fügen Sie den Paragraph dem TextFrame hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieses PHP‑Beispiel erzeugt ein Bild‑Aufzählungszeichen:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **Eine mehrstufige Liste erstellen**

Setzen Sie [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth-short-), um Paragraphs auf unterschiedlichen Ebenen einer Liste zu platzieren. Die oberste Ebene hat die Tiefe `0`.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und greifen Sie auf eine Folie zu.
2. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu und entfernen Sie den Standard‑Paragraph aus dessen TextFrame.
3. Erstellen Sie vier Paragraphs und konfigurieren Sie deren Aufzählungszeichen‑Symbole.
4. Setzen Sie deren [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth-short-)‑Werte auf `0`, `1`, `2` und `3`.
5. Fügen Sie die Paragraphs dem TextFrame hinzu und speichern Sie die Präsentation.

Dieses PHP‑Beispiel erzeugt eine vierstufige Aufzählungsliste:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Nummerierte Listeneinträge mit benutzerdefinierten Werten beginnen**

Verwenden Sie [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-), um die Anfangsnummer für einen nummerierten Paragraph festzulegen.

1. Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und fügen Sie einem Folien‑AutoShape ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
2. Entfernen Sie den Standard‑Paragraph aus dem TextFrame der Form.
3. Erstellen Sie drei nummerierte Paragraphs.
4. Setzen Sie [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) auf `2`, `3` bzw. `7` für die jeweiligen Paragraphs.
5. Fügen Sie die Paragraphs dem TextFrame hinzu und speichern Sie die Präsentation.

Dieses PHP‑Beispiel weist jedem Paragraph eine individuelle Startnummer zu:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Absatzlayout und End‑Eigenschaften steuern**

### **Erste‑Zeilen‑Einzug festlegen**

Verwenden Sie [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-), um den Einzug der ersten Zeile eines Paragraphs zu steuern. Diese Methode verschiebt nur die erste Zeile relativ zum linken Rand des Paragraphs. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Paragraphkörper ausgerichtet bleiben.

Verwenden Sie [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-), wenn Sie den gesamten Paragraph verschieben möchten. Verwenden Sie [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-), wenn Sie ausschließlich die erste Zeile verschieben wollen.

Das nachfolgende Beispiel erzeugt mehrere Paragraphs und wendet unterschiedliche [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-)‑Werte an, um zu zeigen, wie sich der erste‑Zeilen‑Einzug auf das Layout auswirkt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) zur Folie hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) der Form zu und entfernen Sie den Standard‑Paragraph.
5. Erstellen Sie mehrere Paragraphs und setzen Sie für sie unterschiedliche [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-)‑Werte.
6. Fügen Sie die Paragraphs dem TextFrame hinzu.
7. Speichern Sie die geänderte Präsentation.

Dieses PHP‑Code‑Beispiel zeigt, wie ein Paragraph‑Einzug gesetzt wird:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Der Erste‑Zeilen‑Einzug der Paragraphs](first_line_indent.png)

### **Hängenden Einzug festlegen**

Ein hängender Einzug ist ein Paragraph‑Layout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-). Übergeben Sie einen negativen Wert, um die erste Zeile relativ zum Paragraphkörper nach links zu verschieben.

In der Praxis definiert [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) die linke Position des Paragraphkörpers, und [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) definiert die Position der ersten Zeile relativ zu diesem Rand. Um einen hängenden Einzug zu erzeugen, übergeben Sie einen positiven Wert an `setMarginLeft` und einen negativen Wert an `setIndent`.

Diese Formatierung ist nützlich für Bibliografien, Verweise, Glossareinträge und andere Paragraphs, bei denen umbrochene Zeilen unter dem Paragraphkörper und nicht unter dem ersten Zeichen der ersten Zeile ausgerichtet sein müssen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) zur Folie hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) der Form zu und entfernen Sie den Standard‑Paragraph.
5. Erstellen Sie Paragraphs und übergeben Sie für jeden einen positiven Wert an [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-).
6. Übergeben Sie einen negativen Wert an [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-), um den hängenden Einzug zu erzeugen.
7. Fügen Sie die Paragraphs dem TextFrame hinzu.
8. Speichern Sie die geänderte Präsentation.

Dieses PHP‑Code‑Beispiel zeigt, wie ein hängender Einzug für einen Paragraph gesetzt wird:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Der hängende Einzug der Paragraphs](hanging_indent.png)

### **End‑Paragraph‑Run‑Eigenschaften festlegen**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) steuert die Formatierung des Absatzendzeichens. Das folgende PHP‑Beispiel weist dem Endzeichen des zweiten Paragraphs eine Schriftgröße und eine Lateinschrift zu:

1. Laden Sie eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und greifen Sie auf eine Folie zu.
2. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu und entfernen Sie dessen Standard‑Paragraph.
3. Erstellen Sie zwei Paragraphs und fügen Sie Text‑Portions hinzu.
4. Erzeugen Sie ein [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) für das Endzeichen des zweiten Paragraphs.
5. Setzen Sie [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) und [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Weisen Sie das Format mit [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) zu und speichern Sie die Präsentation.

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Anzahl gerenderter Zeilen ermitteln**

Für Paragraph‑Regeln, die automatisches Umbrechen und Interpunktion am Zeilenende beeinflussen, siehe [Control Line Breaking](/slides/de/php-java/text-formatting/#control-line-breaking) und [Control Hanging Punctuation](/slides/de/php-java/text-formatting/#control-hanging-punctuation).

Verwenden Sie [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount--), um die nach Textlayout von einem Paragraph belegten Zeilen zu zählen, inklusive automatischem Umbrechen. Dies ist nützlich, wenn die Textlänge und das Layout in Präsentationsvorlagen geprüft werden sollen.

Ein Paragraph ist ein Element in [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs--), und er kann mehrere gerenderte Zeilen belegen. Ein expliziter Zeilenumbruch innerhalb eines Paragraphs erzwingt eine neue Zeile, ohne einen neuen Paragraph zu erzeugen. Automatisches Umbrechen erzeugt Zeilen anhand der verfügbaren Breite, ohne explizite Zeilenumbrüche in den Text einzufügen. Das Zählen von Paragraphs oder Zeilenumbruch‑Zeichen liefert daher nicht die gerenderte Zeilenanzahl.

Das nachfolgende Beispiel erstellt eine Textform, zählt ihre Zeilen, verengt die Form und ersetzt anschließend den Text durch eine kürzere Zeichenfolge. Umbrechen ist aktiviert und Autofit deaktiviert, sodass die Formbreite das Umbrechen steuert, ohne den Text automatisch zu verkleinern oder die Form zu skalieren. Formabmessungen werden in Punkt angegeben. Abschließend fügt das Beispiel einen weiteren Paragraph hinzu und summiert die Zeilenzahlen über das gesamte TextFrame.

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Mit diesem Text und diesen Abmessungen erhöht das Verengen der Form die Zeilenzahl, während das Ersetzen des Texts durch die kurze Zeichenfolge sie reduziert. Exakte Werte können je nach Verfügbarkeit und Substitution von Schriftarten, Schriftgröße, Rändern, Einzügen, Umbrechen und Autofit‑Einstellungen variieren. Verwenden Sie die für die Zielumgebung vorgesehenen Schriftarten und Layout‑Einstellungen beim Prüfen einer Vorlage.

Die Zeilenzahl allein entscheidet nicht, ob Text seinen Container überläuft. Verfügbare Höhe, Zeilenhöhen, Absatz‑ und Zeilenabstand sowie das Autofit‑Verhalten spielen ebenfalls eine Rolle; selbst eine einzelne Zeile kann die verfügbare Breite überschreiten, wenn Umbrechen deaktiviert ist.

## **Paragraph‑Inhalt importieren und exportieren**

### **HTML‑Text in Paragraphs importieren**

Verwenden Sie [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-), um HTML‑Markup in Paragraphs und Portions eines TextFrames zu konvertieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse.
2. Greifen Sie auf eine Folie zu und fügen Sie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
3. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) der Form zu und entfernen Sie den Standard‑Paragraph.
4. Lesen Sie die Quell‑HTML‑Datei.
5. Übergeben Sie den HTML‑String an [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Speichern Sie die geänderte Präsentation.

Dieses PHP‑Beispiel importiert HTML in einen TextFrame:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **Paragraph‑Text nach HTML exportieren**

Verwenden Sie [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-), um einen ausgewählten Bereich von Paragraphs als HTML zu exportieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse und laden Sie die gewünschte Präsentation.
2. Greifen Sie auf die Folie zu und finden Sie das [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), das den Text enthält.
3. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) der Form zu.
4. Rufen Sie [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) mit dem Start‑Paragraph‑Index und der Anzahl zu exportierender Paragraphs auf.
5. Schreiben Sie den zurückgegebenen HTML‑String in eine Datei.

Dieses PHP‑Beispiel exportiert alle Paragraphs aus der ersten Textform:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **Einen Paragraph als Bild rendern**

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--) rendert einen einzelnen Paragraph direkt und gibt ein [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) zurück. Speichern Sie das Ergebnis mit [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save-java.lang.String-int-) in einer Datei oder einem Stream. Sie müssen nicht die gesamte Form rendern oder ein Bitmap manuell zuschneiden.

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--) kann `null` zurückgeben, wenn der Paragraph in der übergeordneten Sammlung nicht gefunden wird, keine gültigen Rendering‑Grenzen hat oder nicht gerendert werden kann. Überprüfen Sie das Ergebnis, bevor Sie es speichern, und geben Sie das zurückgegebene Bild nach der Verwendung frei.

#### **Einen Paragraph im Standardskalen‑Modus rendern**

Angenommen, wir haben eine Präsentationsdatei namens `sample.pptx` mit einer Folie, wobei die erste Form ein Textfeld mit drei Paragraphs ist.

![Das Textfeld mit drei Paragraphs](paragraph_to_image_input.png)

Das folgende PHP‑Beispiel rendern den zweiten Paragraph in einer regulären Textform im Standardskalen‑Modus und speichert das zurückgegebene Bild im PNG‑Format. Der `finally`‑Block sorgt dafür, dass das Bild korrekt freigegeben wird.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Das Paragraph‑Bild](paragraph_to_image_output.png)

#### **Einen Paragraph in einer Tabellenzelle mit Skalierung rendern**

Verwenden Sie die Überladung von [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage-float-float-), die die Parameter `$scaleX` und `$scaleY` akzeptiert, um die horizontalen und vertikalen Skalierungsfaktoren festzulegen. Das folgende PHP‑Beispiel erstellt eine Tabelle, rendert den Paragraph in der ersten Zelle mit dem doppelten Standard‑Breiten‑ und Höhenfaktor und speichert das Ergebnis als PNG‑Bild.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

Ein Skalierungsfaktor von `1` behält die Standard‑Pixelgröße bei. Beispielsweise erzeugt `2` für beide Faktoren ein Bild, dessen Breite und Höhe etwa das Doppelte der Standardabmessungen betragen, also viermal so viele Pixel. Größere Faktoren erzeugen in der Regel schärferen Text für Zoom‑ oder hochauflösende Ausgaben, erhöhen jedoch den Speicherverbrauch und die Dateigröße. Faktoren unter `1` erzeugen kleinere Bilder mit weniger Details. Verwenden Sie gleiche Faktoren, um das Seitenverhältnis des Paragraphs beizubehalten; unterschiedliche horizontale und vertikale Faktoren strecken das Ergebnis unabhängig voneinander.

Das Rendern einer gesamten Form mit [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage--) bleibt nützlich, wenn die Ausgabe die Füllung, den Rand oder andere visuelle Kontexte der Form enthalten muss. Für ein Bild, das ausschließlich den Paragraph darstellt, verwenden Sie [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--).

## **FAQ**

**Kann ich das Zeilenumbruchverhalten innerhalb eines TextFrames komplett deaktivieren?**

Ja. Setzen Sie [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText-byte-) auf, um das Umbrechen zu deaktivieren, sodass Zeilen nicht an den Rändern des TextFrames umbrechen.

**Wie erhalte ich die exakten On‑Slide‑Grenzen eines bestimmten Paragraphs?**

Verwenden Sie [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect--), um das Begrenzungsrechteck des Paragraphs abzurufen. [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect--) liefert die Grenzen einer einzelnen Portion.

**Wo wird die Absatz‑Ausrichtung (links, rechts, zentriert oder Blocksatz) gesteuert?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment-int-) ist eine Absatz‑Ebene‑Einstellung und gilt für den gesamten Paragraph, unabhängig von einzelner Portion‑Formatierung.

Um Portionen unterschiedlicher Schriftgrößen innerhalb jeder Zeile vertikal auszurichten, siehe [Align Fonts Within a Line](/slides/de/php-java/text-formatting/#align-fonts-within-a-line).

**Kann ich die Rechtschreib‑Sprache für einen Teil eines Paragraphs festlegen?**

Ja. Setzen Sie [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) für einzelne Portions, sodass ein Paragraph Text in mehreren Sprachen enthalten kann.