---
title: Collegamento ipertestuale
type: docs
weight: 130
url: /it/java/examples/elements/hyperlink/
keywords:
- esempio di codice
- collegamento ipertestuale
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Aggiungi e gestisci collegamenti ipertestuali in Aspose.Slides per Java: testo dei collegamenti, forme e immagini, imposta destinazioni e azioni per PPT, PPTX e ODP con esempi Java."
---
Questo articolo dimostra come aggiungere, accedere, rimuovere e aggiornare collegamenti ipertestuali su forme usando **Aspose.Slides for Java**.

## **Aggiungi un collegamento ipertestuale**

Crea una forma rettangolare con un collegamento ipertestuale che punta a un sito web esterno.

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

## **Accedi a un collegamento ipertestuale**

Leggi le informazioni del collegamento ipertestuale dalla parte testuale di una forma.

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

## **Rimuovi un collegamento ipertestuale**

Elimina il collegamento ipertestuale dal testo di una forma.

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

## **Aggiorna un collegamento ipertestuale**

Modifica la destinazione di un collegamento ipertestuale esistente. Usa `HyperlinkManager` per modificare il testo che contiene già un collegamento ipertestuale, simulando il modo in cui PowerPoint aggiorna i collegamenti ipertestuali in modo sicuro.

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

        // Modificare un collegamento ipertestuale all'interno del testo esistente deve essere eseguito tramite
        // HyperlinkManager anziché impostare la proprietà direttamente.
        // Questo imita il modo in cui PowerPoint aggiorna in modo sicuro i collegamenti ipertestuali.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```