---
title: Tekstvak
type: docs
weight: 40
url: /nl/androidjava/examples/elements/text-box/
keywords:
- codevoorbeeld
- tekstvak
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Werken met tekstvakken in Aspose.Slides voor Android: tekst toevoegen, opmaken, uitlijnen, afbreken, automatisch aanpassen en stijlen met Java voor PPT-, PPTX- en ODP-presentaties."
---
In Aspose.Slides wordt een **tekstvak** weergegeven door een `AutoShape`. Bijna elke vorm kan tekst bevatten, maar een typisch tekstvak heeft geen opvulling of rand en toont alleen tekst.

Deze gids legt uit hoe je tekstvakken programmatisch kunt toevoegen, benaderen en verwijderen.

## **Een tekstvak toevoegen**

Een tekstvak is simpelweg een `AutoShape` zonder opvulling of rand en met enige opgemaakte tekst. Zo maak je er één:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Maak een rechthoekige vorm (standaard gevuld met rand en zonder tekst).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Verwijder opvulling en rand om het te laten lijken op een typisch tekstvak.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Stel tekstopmaak in.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Wijs de feitelijke tekstinhoud toe.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Opmerking:** Elke `AutoShape` die een niet-leeg `TextFrame` bevat, kan functioneren als een tekstvak.

## **Tekstvakken benaderen op inhoud**

Om alle tekstvakken te vinden die een specifiek trefwoord bevatten (bijv. "Slide"), itereren door de vormen en hun tekst controleren:

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

Dit voorbeeld zoekt en verwijdert alle tekstvakken op de eerste dia die een specifiek trefwoord bevatten:

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

> 💡 **Tip:** Maak altijd een kopie van de vormverzameling voordat je deze tijdens iteratie wijzigt om fouten bij het aanpassen van de collectie te voorkomen.