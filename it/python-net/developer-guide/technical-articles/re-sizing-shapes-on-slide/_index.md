---
title: Ridimensionare le forme nelle diapositive della presentazione in Python
type: docs
weight: 130
url: /it/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /it/python-net/re-sizing-shapes-on-slide/
keywords:
- ridimensionare forma
- modificare dimensione forma
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Ridimensiona facilmente le forme su diapositive PowerPoint e OpenDocument con Aspose.Slides per Python via .NET—automatizza le regolazioni del layout delle diapositive e aumenta la produttività."
---
## **Panoramica**

Quando cambi le dimensioni delle diapositive di una presentazione, potresti dover anche ridimensionare e riposizionare le forme per adattarle alle nuove dimensioni. Questo articolo mostra come scalare le forme manualmente e come gestire le tabelle su diapositive, master e layout.

## **Ridimensiona forme**

Per preservare la posizione e le dimensioni relative di ciascuna forma, moltiplica le sue coordinate orizzontali e la larghezza per il rapporto tra la nuova larghezza della diapositiva e la larghezza originale. Applica il rapporto di altezza corrispondente alle coordinate verticali e all'altezza.

Il primo esempio carica una presentazione le cui diapositive non contengono tabelle, modifica la dimensione della diapositiva in A4 e salva il risultato. Utilizza [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) con [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) in modo che il ciclo successivo controlli la scalatura. I rapporti sono adimensionati; le posizioni e le dimensioni delle forme sono misurate in punti. Rapporti diversi per larghezza e altezza possono distorcere le forme, e la modifica delle dimensioni di una forma non scala le dimensioni del carattere.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Calcola fattori di scala orizzontali e verticali indipendenti.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Le tabelle richiedono una gestione separata: scala le larghezze delle colonne e le altezze delle righe anziché assegnare la larghezza e l'altezza complessive della tabella. Le altezze delle righe possono rimanere più grandi di quanto richiesto se il contenuto della cella richiede più spazio.
{{% /alert %}}

Il secondo esempio supporta le tabelle e elabora le forme nei master e nei layout così come nelle diapositive individuali prima di salvare la presentazione ridimensionata. Il suo helper gestisce ogni [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) scalando [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) e [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). Quindi scala la posizione della tabella senza scalare separatamente le sue dimensioni complessive.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Le dimensioni della tabella sono controllate dalle larghezze delle colonne e dalle altezze delle righe.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Calcola fattori di scala orizzontali e verticali indipendenti.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Ridimensiona le forme definite su master e layout così come su diapositive individuali.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Domande frequenti**

**Perché le forme vengono distorte o tagliate dopo aver ridimensionato una diapositiva?**

Se cambi le dimensioni della diapositiva senza scalare le forme, mantengono le loro posizioni e dimensioni originali e possono estendersi oltre la diapositiva. Scalare larghezza e altezza con rapporti diversi può anche distorcere le forme.

**Il codice fornito funziona per tutti i tipi di forma?**

Il primo esempio modifica direttamente i confini delle forme ed è destinato a diapositive senza tabelle. Il secondo esempio gestisce le tabelle separatamente. Controlla il layout risultante, in particolare testo e tabelle, perché questi esempi non scalano le dimensioni del carattere e il contenuto della tabella può limitare le altezze delle righe.

**Come ridimensionare le tabelle quando ridimensiono una diapositiva?**

Scala le larghezze delle colonne in base al rapporto di larghezza e le altezze minime delle righe in base al rapporto di altezza, quindi scala la posizione della tabella, come mostrato nel secondo esempio.

**Questo ridimensionamento funziona per le diapositive master e per le diapositive di layout?**

Sì. Il secondo esempio itera attraverso [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) e le [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) di ciascun master e applica la stessa logica di ridimensionamento alle loro forme.

**Posso cambiare l'orientamento di una diapositiva (ritratto/paesaggio) insieme al ridimensionamento?**

Sì. Imposta [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) dopo aver modificato la dimensione della diapositiva e prima di leggere le dimensioni target, così i fattori di scala riflettono l'orientamento finale.

**Esiste un limite alle dimensioni della diapositiva che posso impostare?**

Puoi specificare dimensioni personalizzate della diapositiva con [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). Le dimensioni supportate dipendono anche dal formato della presentazione e dall'applicazione utilizzata per aprire il file.

**Come posso evitare che le forme con rapporto d'aspetto fisso vengano distorte?**

Usa lo stesso fattore di scala per larghezza e altezza. Per adattare il layout originale alle nuove dimensioni della diapositiva, utilizza il rapporto più piccolo tra larghezza e altezza sia per le dimensioni che per le posizioni. Questo preserva le proporzioni ma può lasciare spazio inutilizzato su un bordo.