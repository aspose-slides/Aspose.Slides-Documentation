---
title: Casella di testo
type: docs
weight: 40
url: /it/java/examples/elements/text-box/
keywords:
- esempio di codice
- casella di testo
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Lavora con le caselle di testo in Aspose.Slides per Java: aggiungi, formatta, allinea, avvolgi, adattamento automatico e stile del testo usando Java per presentazioni PPT, PPTX e ODP."
---
In Aspose.Slides, una **casella di testo** è rappresentata da un `AutoShape`. Quasi qualsiasi forma può contenere testo, ma una tipica casella di testo non ha riempimento né bordo e visualizza solo il testo.

Questa guida spiega come aggiungere, accedere e rimuovere le caselle di testo programmaticamente.

## **Aggiungi una casella di testo**

Una casella di testo è semplicemente un `AutoShape` senza riempimento né bordo e con del testo formattato. Ecco come crearne una:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Crea una forma rettangolare (predefinita riempita con bordo e senza testo).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Rimuovi il riempimento e il bordo per farla sembrare una tipica casella di testo.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Imposta la formattazione del testo.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Assegna il contenuto testuale effettivo.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Nota:** Qualsiasi `AutoShape` che contiene un `TextFrame` non vuoto può funzionare come una casella di testo.

## **Accedi alle caselle di testo per contenuto**

Per trovare tutte le caselle di testo che contengono una parola chiave specifica (ad es. "Slide"), itera attraverso le forme e controlla il loro testo:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Solo gli AutoShape possono contenere testo modificabile.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Esegui qualcosa con la casella di testo corrispondente.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi le caselle di testo per contenuto**

Questo esempio trova ed elimina tutte le caselle di testo nella prima diapositiva che contengono una parola chiave specifica:

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

> 💡 **Suggerimento:** Crea sempre una copia della collezione di forme prima di modificarla durante l'iterazione per evitare errori di modifica della collezione.