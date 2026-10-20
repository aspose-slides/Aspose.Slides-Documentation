---
title: Ridimensiona forme su diapositive di presentazione in Node.js
type: docs
weight: 130
url: /it/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
  - /it/nodejs-java/re-sizing-shapes-on-slide/
keywords:
  - ridimensiona forma
  - cambia dimensione forma
  - PowerPoint
  - OpenDocument
  - presentazione
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Ridimensiona facilmente le forme su diapositive PowerPoint e OpenDocument con Aspose.Slides per Node.js tramite Java — automatizza le regolazioni del layout delle diapositive e aumenta la produttività."
---
## **Panoramica**

Quando cambi le dimensioni della diapositiva di una presentazione, potresti dover anche ridimensionare e riposizionare le sue forme per adattarle alle nuove dimensioni. Questo articolo mostra come scalare le forme manualmente e come gestire le tabelle su diapositive, master e layout.

## **Ridimensiona forme**

Per conservare la posizione e la dimensione relative di ogni forma, moltiplica le sue coordinate orizzontali e la larghezza per il rapporto tra la larghezza della nuova diapositiva e quella originale. Applica il corrispondente rapporto di altezza alle sue coordinate verticali e all'altezza.

Il primo esempio carica una presentazione le cui diapositive non contengono tabelle, cambia la dimensione della diapositiva in A4 e salva il risultato. Utilizza [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) con [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) in modo che il ciclo successivo controlli la scalatura. I rapporti sono privi di unità; le posizioni e le dimensioni delle forme sono misurate in punti. Rapporti diversi per larghezza e altezza possono deformare le forme, e modificare le dimensioni di una forma non scala le dimensioni del carattere.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Calcola i fattori di scala orizzontali e verticali indipendenti.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Le tabelle richiedono una gestione separata: scalare le larghezze delle colonne e le altezze delle righe invece di assegnare la larghezza e l'altezza complessive della tabella. Le altezze delle righe possono rimanere più grandi di quanto richiesto se il contenuto della cella richiede più spazio.
{{% /alert %}}

Il secondo esempio supporta le tabelle ed elabora le forme sui master e sui layout così come sulle singole diapositive prima di salvare la presentazione ridimensionata. Il suo helper gestisce ciascuna [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) scalando le larghezze delle colonne con [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) e le altezze minime delle righe con [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). Successivamente scala la posizione della tabella senza scalare separatamente le sue dimensioni complessive.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Le dimensioni della tabella sono controllate dalle larghezze delle colonne e dalle altezze delle righe.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Calcola i fattori di scala orizzontali e verticali indipendenti.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Ridimensiona le forme definite su master e layout così come su diapositive individuali.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Domande frequenti**

**Perché le forme risultano distorte o tagliate dopo aver ridimensionato una diapositiva?**  
Se cambi le dimensioni della diapositiva senza scalare le forme, esse mantengono le loro posizioni e dimensioni originali e possono estendersi oltre la diapositiva. Scalare larghezza e altezza con rapporti diversi può anche deformare le forme.

**Il codice fornito funziona per tutti i tipi di forma?**  
Il primo esempio modifica direttamente i confini delle forme ed è destinato a diapositive senza tabelle. Il secondo esempio gestisce le tabelle separatamente. Controlla il layout risultante, in particolare testo e tabelle, poiché questi esempi non scalano le dimensioni dei caratteri e il contenuto delle tabelle può limitare le altezze delle righe.

**Come ridimensionare le tabelle quando si ridimensiona una diapositiva?**  
Scala le larghezze delle colonne con il rapporto di larghezza e le altezze minime delle righe con il rapporto di altezza, quindi scala la posizione della tabella, come mostrato nel secondo esempio.

**Questo ridimensionamento funzionerà per le diapositive master e di layout?**  
Sì. Il secondo esempio itera attraverso [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) e attraverso le [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) di ogni master e applica la stessa logica di ridimensionamento alle loro forme.

**Posso cambiare l'orientamento di una diapositiva (ritratto/paesaggio) insieme al ridimensionamento?**  
Sì. Chiama [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) dopo aver cambiato le dimensioni della diapositiva e prima di leggere le dimensioni target, in modo che i fattori di scala riflettano l'orientamento finale.

**Esiste un limite alle dimensioni della diapositiva che posso impostare?**  
Puoi specificare dimensioni personalizzate della diapositiva con [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). Le dimensioni supportate dipendono anche dal formato della presentazione e dall'applicazione usata per aprire il file.

**Come posso impedire che le forme con proporzioni fisse diventino distorte?**  
Usa lo stesso fattore di scala per larghezza e altezza. Per adattare il layout originale alle nuove dimensioni della diapositiva, utilizza il più piccolo dei due rapporti (larghezza e altezza) per entrambe le dimensioni e posizioni. Questo preserva le proporzioni ma può lasciare spazio inutilizzato lungo un bordo.