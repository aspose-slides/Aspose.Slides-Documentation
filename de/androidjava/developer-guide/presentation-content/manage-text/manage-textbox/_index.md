---
title: Textfelder in Präsentationen auf Android verwalten
linktitle: Textfeld verwalten
type: docs
weight: 20
url: /de/androidjava/manage-textbox/
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
- Android
- Java
- Aspose.Slides
description: "Erstellen, Erkennen, Formatieren und Aktualisieren von Textfeldern in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android via Java."
---
## **Einleitung**

In Aspose.Slides for Android via Java wird Folientext in TextFrames gespeichert, die zu Shapes gehören. Die [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) Schnittstelle stellt die am häufigsten vorkommende texttragende Form dar und gibt ihren Text über die [IAutoShape.getTextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) Methode frei.

{{% alert color="info" title="Note" %}}

Jede Auto‑Form implementiert [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/), aber nicht jede Form ist eine Auto‑Form oder unterstützt einen TextFrame. Beim Verarbeiten einer vorhandenen Präsentation prüfen Sie, ob eine Form [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) implementiert, bevor Sie auf deren Text zugreifen.

{{% /alert %}}

## **Textfeld auf einer Folie erstellen**

Um ein Textfeld zu erstellen, fügen Sie einer Folie eine Auto‑Form hinzu, fügen Sie dessen TextFrame Text hinzu und speichern die Präsentation. Das folgende Beispiel erstellt ein rechteckiges Textfeld:

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

Die an [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) übergebenen Koordinaten und Abmessungen werden in Punkten gemessen. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) initialisiert den TextFrame mit dem angegebenen Text.

## **Überprüfen, ob ein Shape ein Textfeld ist**

Verwenden Sie die [IAutoShape.isTextBox](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/#isTextBox--) Methode, um festzustellen, ob eine Auto‑Form als Textfeld behandelt wird. Dies ist nützlich, wenn eine Präsentation sowohl texttragende als auch rein grafische Auto‑Formen enthält.

![Ein Textfeld und ein Shape](istextbox.png)

Das folgende Beispiel prüft jede Auto‑Form in einer Präsentation:

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

Eine neu hinzugefügte Auto‑Form wird nicht als Textfeld betrachtet, bis sie nicht‑leeren Text enthält. Sie können diesen Text über [IAutoShape.addTextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) oder [ITextFrame.setText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) bereitstellen. Das Hinzufügen oder Zuweisen eines leeren Strings lässt [IAutoShape.isTextBox](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/#isTextBox--) `false` zurückgeben:

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

Der erste und zweite Aufruf geben `true` aus; die letzten beiden geben `false` aus.

## **Das Shape finden, dem ein TextFrame gehört**

Generischer Text‑Verarbeitungscode kann ein [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) erhalten, ohne zu wissen, welches Präsentationsobjekt es enthält. Verwenden Sie die schreibgeschützte [ITextFrame.getParentShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getParentShape--) Methode, um zum besitzenden [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/) zurückzunavigieren.

Für ein TextFrame, das einer Auto‑Form oder einer anderen texttragenden Form gehört, liefert [ITextFrame.getParentShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getParentShape--) den Besitzer und [ITextFrame.getParentCell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getParentCell--) liefert `null`. Überprüfen Sie den zurückgegebenen Wert, bevor Sie darauf zugreifen. Um sowohl Shape‑ als auch Tabellenzellen‑Besitzer zu identifizieren, einschließlich Shapes, die zu SmartArt‑Knoten gehören, siehe [Search and Replace Text](/slides/de/androidjava/search-and-replace-text/).

## **Spalten zu einem Textfeld hinzufügen**

Die [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) Methode teilt das TextFrame in Spalten, während [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) den Abstand zwischen den Spalten in Punkten festlegt. Beide Einstellungen gehören zu [ITextFrameFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/) und können über das TextFrame eines vorhandenen Textfelds geändert werden. Der Text fließt zwischen den Spalten innerhalb derselben Form um; er setzt nicht in einer anderen Form fort.

Das folgende Beispiel erstellt ein dreispaltiges Textfeld mit 10 Punkten Abstand zwischen den Spalten, speichert die Präsentation und liest die gespeicherten Einstellungen aus der Ausgabedatei zurück:

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

Verwenden Sie [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) um den jedem visuellen Spaltenbereich zugeordneten Text eines vorhandenen TextFrames abzurufen. Die Methode gibt für jede Spalte einen String in spaltenbasierter Lesereihenfolge zurück. Ein einspaltiges TextFrame liefert ein Array mit einem Element, und eine leere Spalte wird durch einen leeren String dargestellt. Die Strings enthalten ausschließlich Klartext; Formatierungen auf Portionsebene werden nicht erhalten.

Dies ist nützlich, wenn Sie:

- Text extrahieren und dabei die spaltenbasierte Lesereihenfolge beibehalten.
- Den Inhalt von Folien mit mehreren Spalten indizieren oder vergleichen.
- Jede Spalte in eine separate Datei, ein Datenbankfeld oder ein anderes Ziel exportieren.
- Untersuchen, wie Text nach einer Änderung der Spaltenanzahl mit [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-), des Abstands mit [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), der Schriftart oder der Größe des TextFrames umverteilt wird.

Die Methode gibt den Text zurück, der im aktuellen [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) verteilt ist; sie fließt Text nicht automatisch zwischen separaten Shapes oder Textfeldern. Die Spaltenverteilung kann von verfügbaren Schriftarten und anderen Text‑Layout‑Einstellungen abhängen, stellen Sie also sicher, dass die erforderlichen Schriftarten verfügbar sind, wenn konsistente Ergebnisse wichtig sind.

Das folgende Beispiel lädt eine Präsentation, findet die erste mehrspaltige Auto‑Form mit einem TextFrame, liest die konfigurierte Spaltenanzahl und schreibt den Text jeder Spalte in eine separate Datei. Shapes, die keinen TextFrame bereitstellen, werden übersprungen.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

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
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
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

Um Text in einer gesamten Präsentation zu aktualisieren, iterieren Sie über die Folien und Shapes, wählen Auto‑Shapes aus und bearbeiten dann deren Text‑Portionen. Die Arbeit auf Portionsebene ermöglicht es, sowohl Text als auch Zeichenformatierung zu ändern.

Das folgende Beispiel ersetzt jedes Vorkommen von `years` durch `months` im Text von Auto‑Shapes und macht jede betroffene Portion fett:

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

Diese Traversierung aktualisiert Text nur in Auto‑Shapes. Text, der in Tabellen, Diagrammen, SmartArt oder gruppierten Shapes gespeichert ist, erfordert die Traversierung der jeweiligen Objekt‑Sammlungen.

## **Ein Textfeld mit Hyperlink hinzufügen**

Einem bestimmten Textabschnitt kann ein Hyperlink zugewiesen werden, sodass nur dieser Text als anklickbarer Link fungiert. Verwenden Sie [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), um den Abschnitt mit einer externen URL zu verknüpfen.

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

**Was ist der Unterschied zwischen einem Textfeld und einem Textplatzhalter auf einer Master‑ oder Layout‑Folien?**

Ein [Platzhalter](/slides/de/androidjava/manage-placeholder/) kann seine Position und Formatierung von einer [Master‑Folien](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/masterslide/) oder einer [Layout‑Folien](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/layoutslide/) erben. Ein reguläres Textfeld ist eine unabhängige Form auf der Folie, auf der es erstellt wurde, und übernimmt kein Platzhalter‑Verhalten, wenn das Layout geändert wird.

**Wie kann ich Text ersetzen, ohne den Text in Diagrammen, Tabellen oder SmartArt zu ändern?**

Beschränken Sie die Traversierung auf Shapes, die [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) implementieren, wie im Beispiel „Text aktualisieren“ gezeigt. Diagramme, Tabellen und SmartArt speichern Text in ihren eigenen Objektmodellen, sodass sie durch diese Schleife nicht verändert werden.