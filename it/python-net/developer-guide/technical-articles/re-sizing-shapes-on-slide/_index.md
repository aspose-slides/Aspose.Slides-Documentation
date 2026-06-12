---
title: Ridimensiona le forme nelle presentazioni con Python
linktitle: Ridimensionamento delle forme
type: docs
weight: 130
url: /it/python-net/re-sizing-shapes-on-slide/
keywords:
- ridimensionare forma
- modificare dimensione forma
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Ridimensiona facilmente forme su diapositive PowerPoint e OpenDocument con Aspose.Slides per Python via .NET—automatizza le regolazioni del layout delle diapositive e aumenta la produttività."
---
## **Panoramica**

Una delle domande più comuni dei clienti di Aspose.Slides per Python è come ridimensionare le forme in modo che, quando le dimensioni della diapositiva cambiano, i dati non vengano ritagliati. Questo breve articolo tecnico mostra come farlo.

## **Ridimensiona le forme**

Per evitare che le forme si disallineino quando le dimensioni della diapositiva cambiano, aggiorna la posizione e le dimensioni di ciascuna forma affinché si conformino al nuovo layout della diapositiva.

```py
import aspose.slides as slides

# Carica il file di presentazione.
with slides.Presentation("sample.pptx") as presentation:
    # Ottieni le dimensioni originali della diapositiva.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Modifica le dimensioni della diapositiva senza ridimensionare le forme esistenti.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Ottieni le nuove dimensioni della diapositiva.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Ridimensiona e riposiziona le forme su ogni diapositiva.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Scala le dimensioni della forma.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Scala la posizione della forma.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
Se una diapositiva contiene una tabella, il codice sopra non funzionerà correttamente. In tal caso, ogni cella della tabella deve essere ridimensionata.
{{% /alert %}} 

Utilizza il codice seguente per ridimensionare le diapositive che contengono tabelle. Per le tabelle, impostare la larghezza o l'altezza è un caso speciale: è necessario regolare le altezze delle righe e le larghezze delle colonne singolarmente per modificare la dimensione complessiva della tabella.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Ottieni le dimensioni originali della diapositiva.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Modifica le dimensioni della diapositiva senza ridimensionare le forme esistenti.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Ottieni le nuove dimensioni della diapositiva.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Scala le dimensioni della forma.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Scala la posizione della forma.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Scala le dimensioni della forma.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Scala la posizione della forma.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Scala le dimensioni della forma.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Scala la posizione della forma.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Perché le forme sono distorte o ritagliate dopo il ridimensionamento di una diapositiva?**

Quando si ridimensiona una diapositiva, le forme mantengono la loro posizione e dimensione originali a meno che la scala non venga modificata esplicitamente. Ciò può provocare il ritaglio del contenuto o il disallineamento delle forme.

**Il codice fornito funziona per tutti i tipi di forma?**

L'esempio di base funziona per la maggior parte dei tipi di forma (caselle di testo, immagini, grafici, ecc.). Tuttavia, per le tabelle è necessario gestire riga e colonna separatamente, poiché l'altezza e la larghezza di una tabella sono determinate dalle dimensioni delle singole celle.

**Come ridimensionare le tabelle quando si ridimensiona una diapositiva?**

È necessario iterare tutte le righe e le colonne della tabella e ridimensionare la loro altezza e larghezza in proporzione, come mostrato nel secondo esempio di codice.

**Questo ridimensionamento funziona per le diapositive master e le diapositive layout?**

Sì, ma dovresti anche iterare le [Masters](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/masters/) e le [Layout slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/layout_slides/) e applicare la stessa logica di scala alle loro forme per garantire la coerenza nella presentazione.

**Posso cambiare l'orientamento di una diapositiva (ritratto/orizzontale) insieme al ridimensionamento?**

Sì. Puoi utilizzare [presentation.slide_size.orientation](https://reference.aspose.com/slides/it/python-net/aspose.slides/islidesize/orientation/) per cambiare l'orientamento. Assicurati di impostare la logica di scala di conseguenza per preservare il layout.

**Esiste un limite alle dimensioni della diapositiva che posso impostare?**

Aspose.Slides supporta dimensioni personalizzate, ma dimensioni molto grandi possono influire sulle prestazioni o sulla compatibilità con alcune versioni di PowerPoint.

**Come posso impedire che le forme a rapporto d'aspetto fisso vengano distorte?**

Puoi verificare la proprietà `aspect_ratio_locked` della forma prima di ridimensionare. Se è bloccata, regola la larghezza o l'altezza proporzionalmente invece di scalarle singolarmente.