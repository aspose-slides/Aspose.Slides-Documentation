---
title: Ridimensiona forme su diapositive di presentazione su Android
type: docs
weight: 130
url: /it/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/re-sizing-shapes-on-slide/
keywords:
  - ridimensiona forma
  - cambia dimensione forma
  - PowerPoint
  - OpenDocument
  - presentazione
  - Android
  - Aspose.Slides
description: "Ridimensiona facilmente le forme su diapositive PowerPoint e OpenDocument con Aspose.Slides per Android tramite Java—automatizza le regolazioni del layout delle diapositive e aumenta la produttività."
---
## **Panoramica**

Quando si modifica la dimensione delle diapositive di una presentazione, potrebbe essere necessario ridimensionare e riposizionare le sue forme per adattarle alle nuove dimensioni. Questo articolo mostra come scalare le forme manualmente e come gestire le tabelle su diapositive, master e layout.

## **Ridimensiona forme**

Per preservare la posizione e la dimensione relative di ciascuna forma, moltiplica le coordinate orizzontali e la larghezza per il rapporto tra la nuova larghezza della diapositiva e quella originale. Applica il corrispondente rapporto di altezza alle coordinate verticali e all’altezza.

Il primo esempio carica una presentazione le cui diapositive non contengono tabelle, modifica la dimensione della diapositiva a A4 e salva il risultato. Utilizza [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) con [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) in modo che il ciclo successivo controlli la scalatura. I rapporti sono privi di unità; le posizioni e le dimensioni delle forme sono misurate in punti. Rapporti di larghezza e altezza diversi possono deformare le forme, e la modifica delle dimensioni di una forma non scala le dimensioni dei caratteri.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Calcola i fattori di scala orizzontali e verticali indipendenti.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Nota" %}}

Le tabelle richiedono una gestione separata: scala le larghezze delle colonne e le altezze delle righe invece di assegnare la larghezza e l’altezza complessive della tabella. Le altezze delle righe possono rimanere più grandi di quanto richiesto se il contenuto della cella necessita di più spazio.

{{% /alert %}}

Il secondo esempio supporta le tabelle e elabora le forme sui master e sui layout così come sulle diapositive individuali prima di salvare la presentazione ridimensionata. Il suo helper gestisce ogni [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) scalando le larghezze delle colonne con [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) e le altezze minime delle righe con [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Quindi scala la posizione della tabella senza scalare separatamente le sue dimensioni complessive.

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Le dimensioni della tabella sono controllate dalle larghezze delle colonne e dalle altezze delle righe.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Calcola i fattori di scala orizzontali e verticali indipendenti.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Ridimensiona le forme definite sui master e sui layout così come sulle diapositive individuali.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Perché le forme risultano deformate o tagliate dopo aver ridimensionato una diapositiva?**

Se si modifica la dimensione della diapositiva senza scalare le forme, queste mantengono le loro posizioni e dimensioni originali e possono estendersi oltre la diapositiva. Scalare larghezza e altezza con rapporti diversi può anche deformare le forme.

**Il codice fornito funziona per tutti i tipi di forma?**

Il primo esempio modifica direttamente i limiti delle forme ed è destinato a diapositive senza tabelle. Il secondo esempio gestisce le tabelle separatamente. Verificare il layout risultante, in particolare testi e tabelle, perché questi esempi non scalano le dimensioni dei caratteri e il contenuto delle tabelle può limitare le altezze delle righe.

**Come ridimensionare le tabelle quando si ridimensiona una diapositiva?**

Scala le larghezze delle colonne con il rapporto di larghezza e le altezze minime delle righe con il rapporto di altezza, quindi scala la posizione della tabella, come mostrato nel secondo esempio.

**Questo ridimensionamento funziona per slide master e slide layout?**

Sì. Il secondo esempio itera attraverso [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) e le [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) di ogni master, applicando la stessa logica di ridimensionamento alle loro forme.

**Posso cambiare l’orientamento di una diapositiva (ritratto/paesaggio) insieme al ridimensionamento?**

Sì. Chiama [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) dopo aver modificato la dimensione della diapositiva e prima di leggere le dimensioni target, così i fattori di scala riflettono l’orientamento finale.

**Esiste un limite alla dimensione della diapositiva che posso impostare?**

È possibile specificare dimensioni personalizzate della diapositiva con [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). Le dimensioni supportate dipendono anche dal formato della presentazione e dall’applicazione utilizzata per aprire il file.

**Come posso impedire che le forme con rapporto di aspetto fisso si deformino?**

Usa lo stesso fattore di scala per larghezza e altezza. Per far entrare il layout originale nelle nuove dimensioni della diapositiva, usa il valore minore tra i rapporti di larghezza e altezza per entrambe le dimensioni e le posizioni. Questo preserva le proporzioni ma può lasciare spazio inutilizzato su un lato.