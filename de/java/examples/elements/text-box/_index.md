---
title: Textfeld
type: docs
weight: 40
url: /de/java/examples/elements/text-box/
keywords:
- Codebeispiel
- Textfeld
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Arbeiten Sie mit Textfeldern in Aspose.Slides für Java: Text hinzufügen, formatieren, ausrichten, umbrechen, automatisch anpassen und stilisieren für PPT-, PPTX- und ODP-Präsentationen."
---
In Aspose.Slides wird eine **Textbox** durch ein `AutoShape` dargestellt. Praktisch jede Form kann Text enthalten, aber eine typische Textbox hat keine Füllung oder Kontur und zeigt nur Text an.

Dieser Leitfaden erklärt, wie man Textboxen programmgesteuert hinzufügt, darauf zugreift und sie entfernt.

## **Add a Text Box**

Ein Textbox ist einfach ein `AutoShape` ohne Füllung oder Kontur und mit etwas formatiertem Text. So erstellen Sie eines:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Erstelle ein Rechteck-Shape (standardmäßig gefüllt mit Rand und ohne Text).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Entferne Füllung und Rand, damit es wie ein typisches Textfeld aussieht.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Setze Textformatierung.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Weise den eigentlichen Textinhalt zu.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Hinweis:** Jedes `AutoShape`, das ein nicht leeres `TextFrame` enthält, kann als Textbox fungieren.

## **Access Text Boxes by Content**

Um alle Textboxen zu finden, die ein bestimmtes Stichwort (z.B. "Slide") enthalten, iterieren Sie über die Formen und prüfen deren Text:

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

## **Remove Text Boxes by Content**

Dieses Beispiel findet und löscht alle Textboxen auf der ersten Folie, die ein bestimmtes Stichwort enthalten:

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

> 💡 **Tipp:** Erstellen Sie immer eine Kopie der Formsammlung, bevor Sie sie während der Iteration ändern, um Fehler durch Änderung der Sammlung zu vermeiden.