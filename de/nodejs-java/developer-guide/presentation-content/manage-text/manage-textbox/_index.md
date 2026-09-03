---
title: Verwalten von Textfeldern in Präsentationen mit JavaScript
linktitle: Textfeld verwalten
type: docs
weight: 20
url: /de/nodejs-java/manage-textbox/
keywords:
- Textfeld
- Textframe
- Text hinzufügen
- Text aktualisieren
- Textfeld erstellen
- Textfeld prüfen
- Textspalte hinzufügen
- Hyperlink hinzufügen
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen, Erkennen, Formatieren und Aktualisieren von Textfeldern in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Node.js via Java."
---
## **Einführung**

In Aspose.Slides für Node.js via Java wird der Folientext in Textframes gespeichert, die zu Formen gehören. Die Klasse AutoShape repräsentiert die am häufigsten vorkommende texteinbettende Form und stellt ihren Text über die Methode AutoShape.getTextFrame zur Verfügung.

{{% alert color="info" title="Hinweis" %}}
Jede Autoform erbt von Shape, aber nicht jede Form ist eine Autoform oder unterstützt ein Textframe. Beim Verarbeiten einer vorhandenen Präsentation sollte geprüft werden, ob eine Form eine Instanz von AutoShape ist, bevor ihr Text zugegriffen wird.
{{% /alert %}}

## **Erstellen einer Textbox auf einer Folie**

Um eine Textbox zu erstellen, fügen Sie einer Folie eine Autoform hinzu, fügen Sie dem dazugehörigen Textframe Text hinzu und speichern Sie die Präsentation. Das folgende Beispiel erstellt eine rechteckige Textbox:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die an ShapeCollection.addAutoShape übergebenen Koordinaten und Abmessungen werden in Punkt gemessen. AutoShape.addTextFrame initialisiert das Textframe mit dem übergebenen Text.

## **Prüfen, ob eine Form eine Textbox ist**

Verwenden Sie die Methode AutoShape.isTextBox, um festzustellen, ob eine Autoform als Textbox behandelt wird. Dies ist nützlich, wenn eine Präsentation sowohl texteinbettende als auch rein grafische Autoformen enthält.

![Eine Textbox und eine Form](istextbox.png)

Das folgende Beispiel untersucht jede Autoform in einer Präsentation:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Eine neu hinzugefügte Autoform wird erst dann als Textbox betrachtet, wenn sie nicht-leeren Text enthält. Sie können diesen Text über AutoShape.addTextFrame oder TextFrame.setText bereitstellen. Das Hinzufügen oder Zuweisen einer leeren Zeichenkette lässt AutoShape.isTextBox `false` zurückgeben:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Die ersten beiden Aufrufe geben `true` aus; die letzten beiden geben `false` aus.

## **Ermitteln Sie die Form, die ein Textframe besitzt**

Allgemeiner Textverarbeitungscode kann ein Textframe erhalten, ohne zu wissen, welches Präsentationsobjekt es enthält. Verwenden Sie die schreibgeschützte Methode TextFrame.getParentShape, um zurück zur zugehörigen Shape zu navigieren.

Für ein Textframe, das einer Autoform oder einer anderen texteinbettenden Form gehört, gibt TextFrame.getParentShape den Eigentümer zurück und TextFrame.getParentCell gibt `null` zurück. Prüfen Sie den zurückgegebenen Wert, bevor Sie darauf zugreifen. Um sowohl Formen- als auch Tabellenzellen‑Eigentümer zu identifizieren, einschließlich Formen, die mit SmartArt‑Knoten verbunden sind, siehe [Suche und Ersetzen von Text](/slides/de/nodejs-java/search-and-replace-text/).

## **Spalten zu einer Textbox hinzufügen**

Die Methode TextFrameFormat.setColumnCount teilt das Textframe in Spalten, während TextFrameFormat.setColumnSpacing den Abstand zwischen den Spalten in Punkten festlegt. Beide Einstellungen gehören zu TextFrameFormat und können über das Textframe einer bestehenden Textbox geändert werden. Der Text fließt zwischen den Spalten innerhalb derselben Form um; er wird nicht in eine andere Form fortgesetzt.

Das folgende Beispiel erstellt eine dreispaltige Textbox mit 10 Punkten Abstand zwischen den Spalten, speichert die Präsentation und liest die gespeicherten Einstellungen aus der Ausgabedatei wieder ein:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Text aus einzelnen Spalten extrahieren**

Verwenden Sie TextFrame.splitTextByColumns, um den Text abzurufen, der jeder visuellen Spalte in einem vorhandenen Textframe zugewiesen ist. Die Methode gibt für jede Spalte einen String in spaltenbasierter Lesereihenfolge zurück. Ein einspaltiger Textframe erzeugt ein Array mit einem Element, und eine leere Spalte wird durch einen leeren String dargestellt. Die Strings enthalten ausschließlich reinen Text; Formatierungen auf Portionsebene werden nicht beibehalten.

Dies ist nützlich, wenn Sie:
- Text extrahieren und dabei seine spaltenbasierte Lesereihenfolge beibehalten.
- Inhalt von Folien mit mehreren Spalten indexieren oder vergleichen.
- Jede Spalte in eine separate Datei, Datenbankfeld oder ein anderes Ziel exportieren.
- Untersuchen, wie Text nach dem Ändern der Spaltenanzahl mit TextFrameFormat.setColumnCount, des Abstands mit TextFrameFormat.setColumnSpacing, der Schriftart oder der Größe des Textframes umverteilt wird.

Die Methode meldet den Text, der innerhalb des aktuellen TextFrames verteilt ist; sie lässt Text nicht automatisch zwischen separaten Formen oder Textboxen fließen. Die Spaltenverteilung kann von verfügbaren Schriftarten und anderen Textlayout‑Einstellungen abhängen, daher sollten die erforderlichen Schriftarten vorhanden sein, wenn konsistente Ergebnisse wichtig sind.

Das folgende Beispiel lädt eine Präsentation, findet die erste mehrspaltige Autoform mit einem Textframe, liest die konfigurierte Spaltenanzahl aus und schreibt den Text jeder Spalte in eine separate Datei. Formen, die kein Textframe bereitstellen, werden übersprungen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Text aktualisieren**

Um Text in einer gesamten Präsentation zu aktualisieren, iterieren Sie über die Folien und Formen, wählen Autoformen aus und bearbeiten anschließend deren Textportionen. Die Arbeit auf Portionsebene ermöglicht das Ändern von Text und Zeichenformatierung.

Das folgende Beispiel ersetzt jedes Vorkommen von `years` durch `months` im Text von Autoformen und formatiert jede betroffene Portion fett:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diese Durchlauf aktualisiert Text nur in Autoformen. In Tabellen, Diagrammen, SmartArt oder gruppierten Formen gespeicherter Text erfordert das Durchlaufen der jeweiligen Objektkollektionen.

## **Eine Textbox mit Hyperlink hinzufügen**

Ein Hyperlink kann einer bestimmten Textportion zugewiesen werden, sodass nur dieser Text als anklickbarer Link fungiert. Verwenden Sie HyperlinkManager.setExternalHyperlinkClick, um die Portion mit einer externen URL zu verknüpfen.

Das folgende Beispiel erstellt verknüpften Text und speichert ihn in einer Präsentation:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Was ist der Unterschied zwischen einer Textbox und einem Textplatzhalter auf einer Master‑ oder Layoutfolie?**

Ein Platzhalter kann seine Position und Formatierung von einer Masterfolie oder Layoutfolie erben. Eine reguläre Textbox ist eine eigenständige Form auf der Folie, auf der sie erstellt wurde, und übernimmt kein Platzhalterverhalten, wenn sich das Layout ändert.

**Wie kann ich Text ersetzen, ohne den Text in Diagrammen, Tabellen oder SmartArt zu ändern?**

Beschränken Sie die Durchlauf auf Formen, die Instanzen von AutoShape sind, wie im Beispiel Text aktualisieren gezeigt. Diagramme, Tabellen und SmartArt speichern Text in eigenen Objektmodellen, sodass sie durch diese Schleife nicht verändert werden.