---
title: Textfeld
type: docs
weight: 40
url: /de/androidjava/examples/elements/text-box/
keywords:
- Codebeispiel
- Textfeld
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Arbeiten Sie mit Textfeldern in Aspose.Slides für Android: Text hinzufügen, formatieren, ausrichten, umbrechen, automatisch anpassen und stylen mithilfe von Java für PPT-, PPTX- und ODP-Präsentationen."
---
In Aspose.Slides wird ein **Textfeld** durch ein `AutoShape` dargestellt. Fast jede Form kann Text enthalten, aber ein typisches Textfeld hat keine Füllung oder Rahmen und zeigt nur Text an.

Dieser Leitfaden erklärt, wie man Textfelder programmgesteuert hinzufügt, darauf zugreift und sie entfernt.

## **Textfeld hinzufügen**

Ein Textfeld ist einfach ein `AutoShape` ohne Füllung oder Rahmen und mit formatiertem Text. So erstellen Sie eines:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Erstelle ein Rechteck-Shape (Standard: ausgefüllt mit Rahmen und ohne Text).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Entferne Füllung und Rahmen, damit es wie ein typisches Textfeld aussieht.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Setze Textformatierung.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Weist den eigentlichen Textinhalt zu.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Hinweis:** Jeder `AutoShape`, der ein nicht leeres `TextFrame` enthält, kann als Textfeld fungieren.

## **Zugriff auf Textfelder nach Inhalt**

Um alle Textfelder zu finden, die ein bestimmtes Schlüsselwort enthalten (z. B. „Slide“), iterieren Sie über die Formen und prüfen deren Text:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Nur AutoShapes können bearbeitbaren Text enthalten.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Etwas mit dem passenden Textfeld machen.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Entfernen von Textfeldern nach Inhalt**

Dieses Beispiel findet und löscht alle Textfelder auf der ersten Folie, die ein bestimmtes Schlüsselwort enthalten:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Tipp:** Erstellen Sie immer eine Kopie der Formensammlung, bevor Sie sie während einer Iteration ändern, um Fehler durch Modifikation der Sammlung zu vermeiden.