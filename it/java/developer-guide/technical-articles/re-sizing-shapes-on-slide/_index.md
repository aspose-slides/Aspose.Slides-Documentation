---
title: Ridimensiona forme nelle diapositive della presentazione
type: docs
weight: 110
url: /it/java/re-sizing-shapes-on-slide/
keywords:
- ridimensionare forma
- modificare dimensione forma
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Ridimensiona facilmente le forme su diapositive PowerPoint e OpenDocument con Aspose.Slides per Java—automatizza le regolazioni del layout delle diapositive e aumenta la produttività."
---
## **Panoramica**

Una delle domande più comuni dei clienti di Aspose.Slides per Java è come ridimensionare le forme in modo che, quando le dimensioni della diapositiva cambiano, i dati non vengano tagliati. Questo breve articolo tecnico mostra come fare.

## **Ridimensiona forme**

Per impedire che le forme si disallineino quando le dimensioni della diapositiva cambiano, aggiorna la posizione e le dimensioni di ciascuna forma in modo che si conformino al nuovo layout della diapositiva.

```java
import com.aspose.slides.*;

// Carica il file della presentazione.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Ottieni le dimensioni originali della diapositiva.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Modifica le dimensioni della diapositiva senza ridimensionare le forme esistenti.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Ottieni le nuove dimensioni della diapositiva.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Ridimensiona e riposiziona le forme in ogni diapositiva.
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

{{% alert color="info" %}} 

Le tabelle non richiedono trattamenti speciali: impostare larghezza e altezza di una tabella ridimensiona proporzionalmente le sue colonne e righe, quindi ridimensionare nuovamente le altezze delle righe e le larghezze delle colonne applicherebbe il rapporto due volte.

{{% /alert %}} 

Il codice sopra modifica solo le forme sulle diapositive. Le diapositive master e le diapositive di layout mantengono le proprie forme, quindi scalale anch'esse quando desideri che l'intera presentazione segua le nuove dimensioni della diapositiva:

```java
import com.aspose.slides.*;

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
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

### Perché le forme si deformano o vengono tagliate dopo il ridimensionamento di una diapositiva?

Quando una diapositiva viene ridimensionata, le forme mantengono la loro posizione e dimensione originali a meno che la scala non venga modificata esplicitamente. Questo può causare il taglio del contenuto o il disallineamento delle forme.

### Il codice fornito funziona per tutti i tipi di forma?

Sì. Impostare l'altezza e la larghezza funziona allo stesso modo per caselle di testo, immagini, grafici e tabelle.

### Come ridimensionare le tabelle quando si ridimensiona una diapositiva?

Ridimensiona la forma della tabella stessa, esattamente come qualsiasi altra forma. Le sue righe e colonne si ridimensionano proporzionalmente, quindi non scalarle nuovamente in seguito.

### Questo ridimensionamento funziona per le diapositive master e di layout?

Sì, ma dovresti anche iterare attraverso [Masters](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getMasters--) e [Layout slides](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getLayoutSlides--) e applicare la stessa logica di ridimensionamento alle loro forme per garantire la coerenza dell'intera presentazione.

### Posso cambiare l'orientamento di una diapositiva (ritratto/paesaggio) insieme al ridimensionamento?

Sì. È possibile utilizzare [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidesize/#setOrientation-int-) per cambiare l'orientamento. Assicurati di impostare la logica di ridimensionamento di conseguenza per preservare il layout.

### Esiste un limite alle dimensioni della diapositiva che posso impostare?

Aspose.Slides supporta dimensioni personalizzate, ma dimensioni molto grandi possono influire sulle prestazioni o sulla compatibilità con alcune versioni di PowerPoint.

### Come posso impedire che le forme con rapporto d'aspetto fisso si deformino?

È possibile verificare il metodo `getAspectRatioLocked` della forma prima del ridimensionamento. Se è bloccato, regola larghezza o altezza proporzionalmente anziché scalarle singolarmente.