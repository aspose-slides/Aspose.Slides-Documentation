---
title: Ridimensiona forme su diapositive di presentazione in Python via Java
type: docs
weight: 110
url: /it/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /it/python-java/re-sizing-shapes-on-slide/
keywords:
  - ridimensionare forma
  - modificare dimensione forma
  - PowerPoint
  - OpenDocument
  - presentazione
  - Python
  - Java
  - Aspose.Slides
description: "Ridimensiona facilmente le forme su diapositive PowerPoint e OpenDocument con Aspose.Slides per Python tramite Java—automatizza le regolazioni del layout delle diapositive e aumenta la produttività."
---
## **Panoramica**

Quando modifichi la dimensione delle diapositive di una presentazione, potresti dover anche ridimensionare e riposizionare le sue forme per adattarle alle nuove dimensioni. Questo articolo mostra come scalare le forme manualmente e come gestire le tabelle su diapositive, master e layout.

## **Ridimensiona forme**

Per conservare la posizione e le dimensioni relative di ciascuna forma, moltiplica le sue coordinate orizzontali e la larghezza per il rapporto tra la nuova larghezza della diapositiva e la larghezza originale. Applica il corrispondente rapporto di altezza alle sue coordinate verticali e all'altezza.

Il primo esempio carica una presentazione le cui diapositive non contengono tabelle, cambia la dimensione della diapositiva in A4 e salva il risultato. Utilizza [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) con [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) in modo che il ciclo successivo controlli la scala. I rapporti sono senza unità; le posizioni e le dimensioni delle forme sono misurate in punti. Rapporti diversi per larghezza e altezza possono deformare le forme, e modificare le dimensioni di una forma non scala le dimensioni del carattere.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Calcola i fattori di scala orizzontali e verticali indipendenti.
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
Le tabelle richiedono una gestione separata: scala le larghezze delle colonne e le altezze delle righe invece di assegnare la larghezza e l'altezza complessive della tabella. Le altezze delle righe possono rimanere più grandi di quanto richiesto se il contenuto delle celle richiede più spazio.
{{% /alert %}}

Il secondo esempio supporta le tabelle e elabora le forme su master e layout così come su diapositive individuali prima di salvare la presentazione ridimensionata. Il suo helper gestisce ogni [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) scalando le larghezze delle colonne con [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) e le altezze minime delle righe con [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Quindi scala la posizione della tabella senza scalare separatamente le sue dimensioni complessive.

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
    # Calcola i fattori di scala orizzontali e verticali indipendenti.
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

## **Domande frequenti**

**Perché le forme sono distorte o tagliate dopo aver ridimensionato una diapositiva?**

Se cambi la dimensione della diapositiva senza scalare le forme, queste mantengono le loro posizioni e dimensioni originali e possono estendersi oltre la diapositiva. Scalare larghezza e altezza con rapporti diversi può anche deformare le forme.

**Il codice fornito funziona per tutti i tipi di forma?**

Il primo esempio modifica direttamente i limiti delle forme ed è destinato a diapositive senza tabelle. Il secondo esempio gestisce le tabelle separatamente. Controlla il layout risultante, in particolare testo e tabelle, perché questi esempi non scalano le dimensioni del carattere e il contenuto della tabella può vincolare le altezze delle righe.

**Come ridimensionare le tabelle quando si ridimensiona una diapositiva?**

Scala le larghezze delle colonne con il rapporto di larghezza e le altezze minime delle righe con il rapporto di altezza, quindi scala la posizione della tabella, come mostrato nel secondo esempio.

**Questo ridimensionamento funzionerà per le slide master e le slide di layout?**

Sì. Il secondo esempio itera attraverso [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) e le [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) di ogni master e applica la stessa logica di ridimensionamento alle loro forme.

**Posso cambiare l'orientamento di una diapositiva (ritratto/paesaggio) insieme al ridimensionamento?**

Sì. Chiama [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) dopo aver cambiato la dimensione della diapositiva e prima di leggere le dimensioni target, in modo che i fattori di scala riflettano l'orientamento finale.

**Esiste un limite alla dimensione della diapositiva che posso impostare?**

Puoi specificare dimensioni personalizzate per la diapositiva con [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). Le dimensioni supportate dipendono anche dal formato della presentazione e dall'applicazione utilizzata per aprire il file.

**Come posso impedire che le forme con rapporto d'aspetto fisso si deformino?**

Usa lo stesso fattore di scala per larghezza e altezza. Per adattare il layout originale alle nuove dimensioni della diapositiva, utilizza il più piccolo dei rapporti di larghezza e altezza per entrambi le dimensioni e le posizioni. Questo conserva le proporzioni ma può lasciare spazio inutilizzato lungo un bordo.