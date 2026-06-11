---
title: Textruta
type: docs
weight: 40
url: /sv/java/examples/elements/text-box/
keywords:
- kodexempel
- textruta
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Arbeta med textrutor i Aspose.Slides för Java: lägg till, formatera, justera, radbryt, autofit och stilisera text med Java för PPT-, PPTX- och ODP-presentationer."
---
I Aspose.Slides representeras en **textruta** av en `AutoShape`. Nästan alla former kan innehålla text, men en typisk textruta har ingen fyllning eller kant och visar endast text.

Denna guide förklarar hur du lägger till, får åtkomst till och tar bort textrutor programatiskt.

## **Lägg till en textruta**

En textruta är helt enkelt en `AutoShape` utan fyllning eller kant och med formaterad text. Så här skapar du en:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Skapa en rektangelform (standard är fylld med kant och utan text).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Ta bort fyllning och kant så att den ser ut som en vanlig textruta.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Ställ in textformatering.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Tilldela det faktiska textinnehållet.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Obs:** Alla `AutoShape` som innehåller en icke-tom `TextFrame` kan fungera som en textruta.

## **Få åtkomst till textrutor efter innehåll**

För att hitta alla textrutor som innehåller ett specifikt nyckelord (t.ex. "Slide"), iterera genom formerna och kontrollera deras text:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Endast AutoShapes kan innehålla redigerbar text.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Gör något med den matchande textrutan.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort textrutor efter innehåll**

Detta exempel hittar och tar bort alla textrutor på den första bilden som innehåller ett specifikt nyckelord:

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

> 💡 **Tips:** Skapa alltid en kopia av formsamlingen innan du modifierar den under iteration för att undvika fel vid samlingsändring.