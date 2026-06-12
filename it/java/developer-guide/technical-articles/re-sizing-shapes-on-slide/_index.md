---
title: Ridimensiona forme su diapositive di presentazione
type: docs
weight: 110
url: /it/java/re-sizing-shapes-on-slide/
keywords:
- ridimensiona forma
- cambia dimensione forma
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Ridimensiona facilmente forme su diapositive PowerPoint e OpenDocument con Aspose.Slides per Java—automatizza le regolazioni del layout delle diapositive e aumenta la produttività."
---
## **Panoramica**

Una delle domande più comuni dei clienti di Aspose.Slides per Java è come ridimensionare le forme in modo che, quando le dimensioni della diapositiva cambiano, i dati non vengano tagliati. Questo breve articolo tecnico mostra come farlo.

## **Ridimensionare le forme**

Per evitare che le forme vengano disallineate quando le dimensioni della diapositiva cambiano, aggiorna la posizione e le dimensioni di ogni forma in modo che si conformino al nuovo layout della diapositiva.

```java
// Carica il file di presentazione.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Ottieni le dimensioni originali della diapositiva.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Modifica le dimensioni della diapositiva senza scalare le forme esistenti.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Ottieni le nuove dimensioni della diapositiva.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Ridimensiona e riposiziona le forme su ogni diapositiva.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Scala le dimensioni della forma.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Scala la posizione della forma.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}} 
Se una diapositiva contiene una tabella, il codice sopra non funzionerà correttamente. In tal caso, ogni cella della tabella deve essere ridimensionata.
{{% /alert %}} 

Utilizza il codice seguente per ridimensionare le diapositive che contengono tabelle. Per le tabelle, impostare la larghezza o l’altezza è un caso speciale: è necessario regolare le altezze delle righe e le larghezze delle colonne individuali per modificare le dimensioni complessive della tabella.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Ottieni le dimensioni originali della diapositiva.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Modifica le dimensioni della diapositiva senza scalare le forme esistenti.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Ottieni le nuove dimensioni della diapositiva.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Scala le dimensioni della forma.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Scala la posizione della forma.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Scala le dimensioni della forma.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Scala la posizione della forma.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Scala le dimensioni della forma.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Scala la posizione della forma.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Perché le forme si distorcono o vengono tagliate dopo aver ridimensionato una diapositiva?**

Quando si ridimensiona una diapositiva, le forme mantengono la loro posizione e dimensione originali a meno che la scala non venga modificata esplicitamente. Questo può causare il ritaglio del contenuto o il disallineamento delle forme.

**Il codice fornito funziona per tutti i tipi di forma?**

L’esempio base funziona per la maggior parte dei tipi di forma (caselle di testo, immagini, grafici, ecc.). Tuttavia, per le tabelle è necessario gestire righe e colonne separatamente, poiché altezza e larghezza di una tabella sono determinate dalle dimensioni delle singole celle.

**Come ridimensionare le tabelle quando si ridimensiona una diapositiva?**

È necessario iterare tutte le righe e le colonne della tabella e ridimensionare le loro altezze e larghezze in modo proporzionale, come mostrato nel secondo esempio di codice.

**Questo ridimensionamento funziona per le diapositive master e per le diapositive di layout?**

Sì, ma dovresti anche iterare attraverso [Master](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getMasters--) e [Diapositive di layout](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getLayoutSlides--) e applicare la stessa logica di scaling alle loro forme per garantire coerenza nella presentazione.

**Posso cambiare l’orientamento di una diapositiva (ritratto/paesaggio) insieme al ridimensionamento?**

Sì. Puoi utilizzare [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidesize/#setOrientation-int-) per cambiare l’orientamento. Assicurati di impostare la logica di scaling di conseguenza per preservare il layout.

**Esiste un limite alle dimensioni della diapositiva che posso impostare?**

Aspose.Slides supporta dimensioni personalizzate, ma dimensioni molto grandi possono influire sulle prestazioni o sulla compatibilità con alcune versioni di PowerPoint.

**Come posso impedire che le forme con rapporto d’aspetto fisso si distorcano?**

Puoi verificare il metodo `getAspectRatioLocked` della forma prima di applicare lo scaling. Se è bloccato, regola la larghezza o l’altezza in modo proporzionale anziché scalarli singolarmente.