---
title: Ridimensiona forme su diapositive di presentazione in Python tramite Java
type: docs
weight: 110
url: /it/python-java/resizing-shapes-on-slide/
aliases:
  - /it/python-java/re-sizing-shapes-on-slide/
  /python-java/re-sizing-shapes-on-slide/
keywords:
- ridimensiona forma
- cambia dimensione forma
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Ridimensiona facilmente le forme su diapositive PowerPoint e OpenDocument con Aspose.Slides per Python tramite Java — automatizza le modifiche del layout delle diapositive e aumenta la produttività."
---
## **Panoramica**

Quando modifichi la dimensione della diapositiva di una presentazione, potresti dover anche ridimensionare e riposizionare le forme per adattarle alle nuove dimensioni. Questo articolo mostra come ridimensionare manualmente le forme e come gestire le tabelle su diapositive, master e layout.

## **Ridimensiona forme**

Per conservare la posizione e le dimensioni relative di ogni forma, moltiplica le sue coordinate orizzontali e la larghezza per il rapporto tra la nuova larghezza della diapositiva e quella originale. Applica il corrispondente rapporto di altezza alle sue coordinate verticali e all'altezza.

Il primo esempio carica una presentazione le cui diapositive non contengono tabelle, cambia la dimensione della diapositiva in A4 e salva il risultato. Utilizza [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) con [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) in modo che il ciclo successivo controlli il ridimensionamento. I rapporti sono privi di unità; le posizioni e le dimensioni delle forme sono misurate in punti. Rapporti diversi per larghezza e altezza possono deformare le forme e la modifica delle dimensioni di una forma non ridimensiona le dimensioni dei caratteri.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Calcola fattori di scala orizzontali e verticali indipendenti.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Le tabelle richiedono una gestione separata: ridimensiona le larghezze delle colonne e le altezze delle righe invece di assegnare la larghezza e l'altezza complessive della tabella. Le altezze delle righe possono rimanere maggiori rispetto a quelle richieste se il contenuto delle celle richiede più spazio.
{{% /alert %}}

Il secondo esempio supporta le tabelle ed elabora le forme su master e layout così come su diapositive individuali prima di salvare la presentazione ridimensionata. Il suo helper gestisce ogni [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) ridimensionando le larghezze delle colonne con [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) e le altezze minime delle righe con [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Quindi ridimensiona la posizione della tabella senza ridimensionare separatamente le sue dimensioni complessive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # Le dimensioni della tabella sono controllate dalle larghezze delle colonne e dalle altezze delle righe.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # Calcola fattori di scala orizzontali e verticali indipendenti.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Ridimensiona le forme definite su master e layout così come su diapositive individuali.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Perché le forme risultano distorte o tagliate dopo aver ridimensionato una diapositiva?**

Se cambi la dimensione della diapositiva senza ridimensionare le forme, queste mantengono le loro posizioni e dimensioni originali e possono estendersi al di fuori della diapositiva. Ridimensionare larghezza e altezza con rapporti diversi può anche distorcere le forme.

**Il codice fornito funziona per tutti i tipi di forme?**

Il primo esempio modifica direttamente i limiti delle forme ed è destinato a diapositive senza tabelle. Il secondo esempio gestisce le tabelle separatamente. Verifica il layout risultante, in particolare testo e tabelle, poiché questi esempi non ridimensionano le dimensioni dei caratteri e il contenuto delle tabelle può limitare le altezze delle righe.

**Come ridimensionare le tabelle quando si ridimensiona una diapositiva?**

Ridimensiona le larghezze delle colonne con il rapporto di larghezza e le altezze minime delle righe con il rapporto di altezza, quindi ridimensiona la posizione della tabella, come mostrato nel secondo esempio.

**Questo ridimensionamento funziona per le diapositive master e layout?**

Sì. Il secondo esempio itera su [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) e sui [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) di ciascun master e applica la stessa logica di ridimensionamento alle loro forme.

**Posso cambiare l'orientamento di una diapositiva (ritratto/paesaggio) insieme al ridimensionamento?**

Sì. Chiama [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) dopo aver modificato la dimensione della diapositiva e prima di leggere le dimensioni target, in modo che i fattori di scala riflettano l'orientamento finale.

**Esiste un limite alla dimensione della diapositiva che posso impostare?**

Puoi specificare dimensioni della diapositiva personalizzate con [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). Le dimensioni supportate dipendono anche dal formato della presentazione e dall'applicazione utilizzata per aprire il file.

**Come posso evitare che le forme con rapporto di aspetto fisso diventino distorte?**

Usa lo stesso fattore di scala per larghezza e altezza. Per adattare il layout originale alle nuove dimensioni della diapositiva, utilizza il più piccolo dei rapporti di larghezza e altezza per entrambe le dimensioni e posizioni. Questo preserva le proporzioni ma può lasciare spazio inutilizzato lungo un lato.