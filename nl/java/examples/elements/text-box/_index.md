---
title: Tekstvak
type: docs
weight: 40
url: /nl/java/examples/elements/text-box/
keywords:
- codevoorbeeld
- tekstvak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Werken met tekstvakken in Aspose.Slides voor Java: tekst toevoegen, opmaken, uitlijnen, laten omloop, automatisch aanpassen en stijlen voor PPT-, PPTX- en ODP-presentaties."
---
In Aspose.Slides wordt een **tekstvak** weergegeven door een `AutoShape`. Bijna elke vorm kan tekst bevatten, maar een typisch tekstvak heeft geen opvulling of rand en toont alleen tekst.

Deze gids legt uit hoe je tekstvakken via code kunt toevoegen, benaderen en verwijderen.

## **Tekstvak toevoegen**

Een tekstvak is eenvoudigweg een `AutoShape` zonder opvulling of rand en met enige opgemaakte tekst. Dit is hoe je er een maakt:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Maak een rechthoekige vorm (standaard gevuld met rand en zonder tekst).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Verwijder opvulling en rand om het eruit te laten zien als een typisch tekstvak.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Stel tekstopmaak in.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Wijs de daadwerkelijke tekstinhoud toe.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Opmerking:** Elke `AutoShape` die een niet‑lege `TextFrame` bevat kan functioneren als een tekstvak.

## **Toegang tot tekstvakken op inhoud**

Om alle tekstvakken te vinden die een specifiek sleutelwoord bevatten (bijv. "Slide"), doorloop je de vormen en controleer je hun tekst:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Alleen AutoShapes kunnen bewerkbare tekst bevatten.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Doe iets met het overeenkomende tekstvak.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Tekstvakken verwijderen op inhoud**

Dit voorbeeld vindt en verwijdert alle tekstvakken op de eerste dia die een specifiek sleutelwoord bevatten:

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

> 💡 **Tip:** Maak altijd een kopie van de vormverzameling voordat je deze tijdens het itereren wijzigt om fouten door wijziging van de collectie te voorkomen.