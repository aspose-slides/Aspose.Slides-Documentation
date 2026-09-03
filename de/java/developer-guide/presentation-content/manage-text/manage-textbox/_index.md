---
title: Textfelder in Präsentationen mit Java verwalten
linktitle: Textfeld verwalten
type: docs
weight: 20
url: /de/java/manage-textbox/
keywords:
- Textfeld
- Textrahmen
- Text hinzufügen
- Text aktualisieren
- Textfeld erstellen
- Textfeld prüfen
- Textspalte hinzufügen
- Hyperlink hinzufügen
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen, Identifizieren, Formatieren und Aktualisieren von Textfeldern in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java."
---
## **Einleitung**

In Aspose.Slides for Java wird Folientext in Textfeldern gespeichert, die zu Formen gehören. Das [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/)‑Interface stellt die am häufigsten vorkommende texttragende Form dar und stellt ihren Text über die Methode [IAutoShape.getTextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/#getTextFrame--) zur Verfügung.

{{% alert color="info" title="Hinweis" %}}
Jede Auto‑Form implementiert [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/), aber nicht jede Form ist eine Auto‑Form oder unterstützt ein Textfeld. Beim Verarbeiten einer bestehenden Präsentation sollte geprüft werden, ob eine Form [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) implementiert, bevor auf ihren Text zugegriffen wird.
{{% /alert %}}

## **Erstellen einer Textbox auf einer Folie**

Um eine Textbox zu erstellen, fügen Sie einer Folie eine Auto‑Form hinzu, fügen Sie ihrem Textfeld Text hinzu und speichern die Präsentation. Das folgende Beispiel erzeugt eine rechteckige Textbox:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die an [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) übergebenen Koordinaten und Abmessungen werden in Punkten angegeben. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) initialisiert das Textfeld mit dem angegebenen Text.

## **Überprüfen einer Textbox‑Form**

Verwenden Sie die Methode [IAutoShape.isTextBox](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/#isTextBox--) um festzustellen, ob eine Auto‑Form als Textbox behandelt wird. Dies ist nützlich, wenn eine Präsentation sowohl texttragende als auch rein grafische Auto‑Formen enthält.

![Eine Textbox und eine Form](istextbox.png)

Das folgende Beispiel untersucht jede Auto‑Form in einer Präsentation:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Eine neu hinzugefügte Auto‑Form wird erst dann als Textbox betrachtet, wenn sie nicht‑leeren Text enthält. Diesen Text können Sie über [IAutoShape.addTextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) oder [ITextFrame.setText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#setText-java.lang.String-) bereitstellen. Das Hinzufügen oder Zuweisen eines leeren Strings lässt [IAutoShape.isTextBox](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/#isTextBox--) `false` zurückgeben:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Die ersten beiden Aufrufe geben `true` aus; die letzten beiden `false`.

## **Ermitteln der Form, die einen Textrahmen besitzt**

Generischer Text‑Verarbeitungscode kann ein [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) erhalten, ohne zu wissen, welches Präsentationsobjekt ihn enthält. Verwenden Sie die schreibgeschützte Methode [ITextFrame.getParentShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#getParentShape--) um zurück zur übergeordneten [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/) zu navigieren.

Für ein Textfeld, das zu einer Auto‑Form oder einer anderen texttragenden Form gehört, gibt [ITextFrame.getParentShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#getParentShape--) den Eigentümer zurück und [ITextFrame.getParentCell](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#getParentCell--) liefert `null`. Prüfen Sie den zurückgegebenen Wert, bevor Sie darauf zugreifen. Um sowohl Form‑ als auch Tabellenzellen‑Eigentümer zu ermitteln, einschließlich Formen, die zu SmartArt‑Knoten gehören, siehe [Search and Replace Text](/slides/de/java/search-and-replace-text/).

## **Spalten zu einer Textbox hinzufügen**

Die Methode [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) teilt das Textfeld in Spalten, während [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) den Abstand zwischen den Spalten in Punkten festlegt. Beide Einstellungen gehören zu [ITextFrameFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/) und können über das Textfeld einer bestehenden Textbox geändert werden. Der Text fließt zwischen den Spalten derselben Form um; er wird nicht in eine andere Form fortgesetzt.

Das folgende Beispiel erzeugt eine Textbox mit drei Spalten und einem Abstand von 10 Punkten zwischen den Spalten, speichert die Präsentation und liest die gespeicherten Einstellungen aus der Ausgabedatei zurück:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Text aus einzelnen Spalten extrahieren**

Verwenden Sie [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#splitTextByColumns--) um den Text abzurufen, der jedem visuellen Spaltenbereich in einem bestehenden Textfeld zugeordnet ist. Die Methode gibt für jede Spalte einen String zurück, in spaltenbasierter Lesereihenfolge. Ein einspaltiges Textfeld liefert ein Array mit einem Element, und eine leere Spalte wird durch einen leeren String dargestellt. Die Strings enthalten ausschließlich Klartext; Formatierungen auf Portionsebene werden nicht beibehalten.

Das ist nützlich, wenn Sie:

- Text extrahieren und dabei die spaltenbasierte Lesereihenfolge beibehalten wollen.
- Inhalte mehrspaltiger Folien indexieren oder vergleichen möchten.
- Jede Spalte in eine separate Datei, Datenbankfeld oder ein anderes Ziel exportieren wollen.
- Untersuchen wollen, wie sich Text nach Änderung der Spaltenanzahl mit [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#setColumnCount-int-), des Abstands mit [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), der Schriftart oder der Größe des Textfelds neu verteilt.

Die Methode berichtet über den Text, der innerhalb des aktuellen [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) verteilt ist; sie fließt nicht automatisch zwischen separaten Formen oder Textboxen. Die Spaltenverteilung kann von verfügbaren Schriften und anderen Text‑Layout‑Einstellungen abhängen, stellen Sie also sicher, dass die erforderlichen Schriften verfügbar sind, wenn konsistente Ergebnisse wichtig sind.

Das folgende Beispiel lädt eine Präsentation, findet die erste mehrspaltige Auto‑Form mit einem Textfeld, liest die konfigurierte Spaltenanzahl aus und schreibt den Text jeder Spalte in eine separate Datei. Formen, die kein Textfeld bereitstellen, werden übersprungen.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Text aktualisieren**

Um Text in einer gesamten Präsentation zu aktualisieren, iterieren Sie über Folien und Formen, wählen Auto‑Formen aus und bearbeiten dann deren Text‑Portionen. Die Arbeit auf Portionsebene ermöglicht das Ändern sowohl des Textes als auch der Zeichenformatierung.

Das folgende Beispiel ersetzt jedes Vorkommen von `years` durch `months` im Text von Auto‑Formen und macht jede betroffene Portion fett:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dieser Durchlauf aktualisiert den Text nur in Auto‑Formen. Text, der in Tabellen, Diagrammen, SmartArt oder gruppierten Formen gespeichert ist, erfordert die Durchquerung der jeweiligen Objekt‑Sammlungen.

## **Eine Textbox mit Hyperlink hinzufügen**

Ein Hyperlink kann einem bestimmten Textabschnitt zugewiesen werden, sodass nur dieser Text als anklickbarer Link fungiert. Verwenden Sie [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), um den Abschnitt mit einer externen URL zu verknüpfen.

Das folgende Beispiel erstellt verknüpften Text und speichert ihn in einer Präsentation:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Was ist der Unterschied zwischen einer Textbox und einem Text‑Platzhalter auf einer Master‑ oder Layout‑Folien?**

Ein [Platzhalter](/slides/de/java/manage-placeholder/) kann seine Position und Formatierung von einer [Master‑Folien](https://reference.aspose.com/slides/de/java/com.aspose.slides/masterslide/) oder [Layout‑Folien](https://reference.aspose.com/slides/de/java/com.aspose.slides/layoutslide/) erben. Eine reguläre Textbox ist eine unabhängige Form auf der Folie, auf der sie erstellt wurde, und übernimmt kein Platzhalter‑Verhalten, wenn sich das Layout ändert.

**Wie kann ich Text ersetzen, ohne den Text in Diagrammen, Tabellen oder SmartArt zu ändern?**

Beschränken Sie die Durchquerung auf Formen, die [IAutoShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/iautoshape/) implementieren, wie im Beispiel „Text aktualisieren“ gezeigt. Diagramme, Tabellen und SmartArt speichern Text in eigenen Objektmodellen, sodass sie von dieser Schleife nicht modifiziert werden.