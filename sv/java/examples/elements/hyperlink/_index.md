---
title: Hyperlänk
type: docs
weight: 130
url: /sv/java/examples/elements/hyperlink/
keywords:
- kodexempel
- hyperlänk
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lägg till och hantera hyperlänkar i Aspose.Slides for Java: länka text, former och bilder, ange mål och åtgärder för PPT, PPTX och ODP med Java-exempel."
---
Denna artikel demonstrerar hur man lägger till, får åtkomst till, tar bort och uppdaterar hyperlänkar på former med hjälp av **Aspose.Slides for Java**.

## **Add a Hyperlink**
## **Lägg till en hyperlänk**

Skapa en rektangelform med en hyperlänk som pekar på en extern webbplats.

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

## **Access a Hyperlink**
## **Få åtkomst till en hyperlänk**

Läs hyperlänkinformation från ett textavsnitt i en form.

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

## **Remove a Hyperlink**
## **Ta bort en hyperlänk**

Rensa hyperlänken från en formes text.

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

## **Update a Hyperlink**
## **Uppdatera en hyperlänk**

Ändra målet för en befintlig hyperlänk. Använd `HyperlinkManager` för att modifiera text som redan innehåller en hyperlänk, vilket efterliknar hur PowerPoint uppdaterar hyperlänkar på ett säkert sätt.

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

        // Att ändra en hyperlänk i befintlig text bör göras via
        // HyperlinkManager snarare än att sätta egenskapen direkt.
        // Detta efterliknar hur PowerPoint säkert uppdaterar hyperlänkar.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```