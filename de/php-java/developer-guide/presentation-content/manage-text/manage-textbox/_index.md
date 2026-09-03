---
title: Textboxen in Präsentationen mit PHP verwalten
linktitle: Textbox verwalten
type: docs
weight: 20
url: /de/php-java/manage-textbox/
keywords:
- Textbox
- Textframe
- Text hinzufügen
- Text aktualisieren
- Textbox erstellen
- Textbox prüfen
- Textspalte hinzufügen
- Hyperlink hinzufügen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen, identifizieren, formatieren und aktualisieren Sie Textboxen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java."
---
## **Einleitung**

In Aspose.Slides für PHP via Java wird der Folientext in Textframes gespeichert, die zu Formen gehören. Die Klasse [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) stellt die am häufigsten vorkommende texttragende Form dar und stellt ihren Text über die Methode [AutoShape::getTextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/#getTextFrame) zur Verfügung.

{{% alert color="info" title="Note" %}}
Jede AutoForm leitet sich von [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/), aber nicht jede Form ist eine AutoForm oder unterstützt einen Textframe. Beim Verarbeiten einer vorhandenen Präsentation sollte `java_instanceof` verwendet werden, um zu prüfen, ob eine Form eine [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) ist, bevor auf ihren Text zugegriffen wird.
{{% /alert %}}

## **Erstellen einer Textbox auf einer Folie**

Um eine Textbox zu erstellen, fügt man einer Folie eine AutoForm hinzu, fügt Text zu ihrem Textframe hinzu und speichert die Präsentation. Das folgende Beispiel erstellt eine rechteckige Textbox:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die an [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/#addAutoShape) übergebenen Koordinaten und Abmessungen werden in Punkten gemessen. [AutoShape::addTextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/#addTextFrame) initialisiert den Textframe mit dem angegebenen Text.

## **Prüfen, ob eine Form eine Textbox ist**

Verwenden Sie die Methode [AutoShape::isTextBox](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/#isTextBox), um festzustellen, ob eine AutoForm als Textbox behandelt wird. Dies ist nützlich, wenn eine Präsentation sowohl texttragende als auch rein grafische AutoFormen enthält.

![A text box and a shape](istextbox.png)

Das folgende Beispiel untersucht jede AutoForm in einer Präsentation:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Eine neu hinzugefügte AutoForm wird erst dann als Textbox betrachtet, wenn sie nicht‑leeren Text enthält. Sie können diesen Text über [AutoShape::addTextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/#addTextFrame) oder [TextFrame::setText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#setText) bereitstellen. Das Hinzufügen oder Zuweisen einer leeren Zeichenkette führt dazu, dass [AutoShape::isTextBox](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/#isTextBox) `false` zurückgibt:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Die ersten beiden Aufrufe geben `true` aus; die letzten beiden geben `false` aus.

## **Ermitteln der Form, die einen Textframe besitzt**

Generischer Textverarbeitungs‑Code kann ein [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) erhalten, ohne zu wissen, welches Präsentationsobjekt es enthält. Verwenden Sie die schreibgeschützte Methode [TextFrame::getParentShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getParentShape), um zurück zur zugehörigen [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/) zu navigieren.

Für einen Textframe, der einer AutoForm oder einer anderen texttragenden Form gehört, gibt [TextFrame::getParentShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getParentShape) den Besitzer zurück und [TextFrame::getParentCell](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#getParentCell) liefert `null`. Überprüfen Sie den zurückgegebenen Wert mit `java_is_null`, bevor Sie darauf zugreifen. Um sowohl Form‑ als auch Tabellenzellen‑Besitzer zu identifizieren, einschließlich Formen, die mit SmartArt‑Knoten verknüpft sind, siehe [Search and Replace Text](/slides/de/php-java/search-and-replace-text/).

## **Spalten zu einer Textbox hinzufügen**

Die Methode [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/#setColumnCount) teilt den Textframe in Spalten auf, während [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/#setColumnSpacing) den Abstand zwischen den Spalten in Punkten festlegt. Beide Einstellungen gehören zu [TextFrameFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/) und können über den Textframe einer vorhandenen Textbox geändert werden. Der Text fließt zwischen den Spalten innerhalb derselben Form um; er wird nicht in eine andere Form fortgesetzt.

Das folgende Beispiel erstellt eine dreispaltige Textbox mit 10 Punkten Abstand zwischen den Spalten, speichert die Präsentation und liest die gespeicherten Einstellungen aus der Ausgabedatei zurück:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Text aus einzelnen Spalten extrahieren**

Verwenden Sie [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/#splitTextByColumns), um den Text abzurufen, der jedem visuellen Spaltenbereich in einem vorhandenen Textframe zugewiesen ist. Die Methode gibt für jede Spalte einen String zurück, in spaltenbasierter Lesereihenfolge. Ein einstufiger Textframe erzeugt ein Array mit einem Element, und eine leere Spalte wird durch einen leeren String dargestellt. Die Strings enthalten nur reinen Text; Formatierungen auf Portionsebene werden nicht erhalten.

Dies ist nützlich, wenn Sie:

- Text extrahieren und dabei die spaltenbasierte Lesereihenfolge beibehalten.
- Den Inhalt mehrspaltiger Folien indexieren oder vergleichen.
- Jede Spalte in eine separate Datei, Datenbankfeld oder ein anderes Ziel exportieren.
- Untersuchen, wie der Text nach einer Änderung der Spaltenanzahl mit [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/#setColumnCount), des Abstands mit [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/#setColumnSpacing), der Schriftart oder der Größe des Textframes neu verteilt wird.

Die Methode gibt den Text zurück, der im aktuellen [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) verteilt ist; sie fließt Text nicht automatisch zwischen separaten Formen oder Textboxen. Die Spaltenverteilung kann von verfügbaren Schriftarten und anderen Textlayout‑Einstellungen abhängen, daher sollten die erforderlichen Schriftarten vorhanden sein, wenn konsistente Ergebnisse wichtig sind.

Das folgende Beispiel lädt eine Präsentation, findet die erste mehrspaltige AutoForm mit einem Textframe, liest die konfigurierte Spaltenanzahl aus und schreibt den Text jeder Spalte in eine separate Datei. Formen, die keinen Textframe bereitstellen, werden übersprungen.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Text aktualisieren**

Um Text in einer gesamten Präsentation zu aktualisieren, iterieren Sie über die Folien und Formen, wählen AutoFormen aus und bearbeiten dann deren Textportionen. Das Arbeiten auf Portionsebene ermöglicht das Ändern von Text und Zeichenformatierung.

Das folgende Beispiel ersetzt jedes Vorkommen von `years` durch `months` im Text von AutoFormen und macht jede betroffene Portion fett:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dieser Durchlauf aktualisiert Text nur in AutoFormen. Text, der in Tabellen, Diagrammen, SmartArt oder Gruppierungen gespeichert ist, erfordert das Durchlaufen der jeweiligen Objekt‑Sammlungen.

## **Eine Textbox mit Hyperlink hinzufügen**

Ein Hyperlink kann einem bestimmten Textabschnitt zugewiesen werden, sodass nur dieser Text als anklickbarer Link fungiert. Verwenden Sie [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/de/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), um den Abschnitt mit einer externen URL zu verknüpfen.

Das folgende Beispiel erstellt verlinkten Text und speichert ihn in einer Präsentation:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Was ist der Unterschied zwischen einer Textbox und einem Text‑Platzhalter auf einer Master‑ oder Layout‑Folie?**

Ein [placeholder](/slides/de/php-java/manage-placeholder/) kann seine Position und Formatierung von einer [master slide](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/) oder einer [layout slide](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/) übernehmen. Eine normale Textbox ist eine eigenständige Form auf der Folie, auf der sie erstellt wurde, und erwirbt kein Platzhalter‑Verhalten, wenn sich das Layout ändert.

**Wie kann ich Text ersetzen, ohne den Text in Diagrammen, Tabellen oder SmartArt zu ändern?**

Beschränken Sie die Durchläufe auf [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/)‑Objekte, wie im Beispiel „Text aktualisieren“ gezeigt. Diagramme, Tabellen und SmartArt speichern Text in ihren eigenen Objektmodellen, sodass sie durch diese Schleife nicht geändert werden.