---
title: Hyperlink
type: docs
weight: 130
url: /nl/androidjava/examples/elements/hyperlink/
keywords:
- codevoorbeeld
- hyperlink
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Voeg hyperlinks toe en beheer ze in Aspose.Slides voor Android: koppel tekst, vormen en afbeeldingen, stel doelen en acties in voor PPT, PPTX en ODP met Java-voorbeelden."
---
Dit artikel toont hoe u hyperlinks op vormen kunt toevoegen, benaderen, verwijderen en bijwerken met **Aspose.Slides for Android via Java**.

## **Hyperlink toevoegen**

Maak een rechthoekige vorm met een hyperlink die naar een externe website verwijst.

```java
static void addHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));
    } finally {
        presentation.dispose();
    }
}
```

## **Hyperlink benaderen**

Lees hyperlink‑informatie uit een tekstdeler van een vorm.

```java
static void accessHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        IHyperlink hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Hyperlink verwijderen**

Verwijder de hyperlink uit de tekst van een vorm.

```java
static void removeHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        textPortion.getPortionFormat().setHyperlinkClick(null);
    } finally {
        presentation.dispose();
    }
}
```

## **Hyperlink bijwerken**

Wijzig het doel van een bestaande hyperlink. Gebruik `HyperlinkManager` om tekst die al een hyperlink bevat te wijzigen, wat nabootst hoe PowerPoint hyperlinks veilig bijwerkt.

```java
static void updateHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://old.example.com"));

        // Een hyperlink in bestaande tekst wijzigen moet gebeuren via
        // HyperlinkManager in plaats van de eigenschap direct in te stellen.
        // Dit bootst na hoe PowerPoint hyperlinks veilig bijwerkt.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```