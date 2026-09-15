---
title: Ridimensiona le forme nelle diapositive di presentazione con Python via Java
type: docs
weight: 110
url: /it/python-java/re-sizing-shapes-on-slide/
keywords:
- ridimensionare forma
- cambiare dimensione forma
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Ridimensiona facilmente le forme nelle diapositive PowerPoint e OpenDocument con Aspose.Slides per Python via Java—automatizza le regolazioni del layout delle diapositive e aumenta la produttività."
---
## **Panoramica**

Una delle domande più comuni dei clienti di Aspose.Slides per Python tramite Java è come ridimensionare le forme in modo che, quando le dimensioni della diapositiva cambiano, i dati non vengano tagliati. Questo breve articolo tecnico mostra come farlo.

## **Ridimensionare le forme**

Per evitare che le forme si disallineino quando le dimensioni della diapositiva cambiano, aggiorna la posizione e le dimensioni di ogni forma affinché si conformino al nuovo layout della diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Carica il file di presentazione.
presentation = Presentation("sample.ppt")
try:
    # Ottieni le dimensioni originali della diapositiva.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Cambia la dimensione della diapositiva senza scalare le forme esistenti.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Ottieni le nuove dimensioni della diapositiva.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Ridimensiona e riposiziona le forme su ogni diapositiva.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Scala le dimensioni della forma.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Scala la posizione della forma.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}} 

Le tabelle non richiedono trattamenti speciali: impostare la larghezza e l’altezza di una tabella ne ridimensiona le colonne e le righe proporzionalmente, quindi ridimensionare nuovamente le altezze delle righe e le larghezze delle colonne applicherebbe il rapporto due volte.

{{% /alert %}} 

Il codice sopra modifica solo le forme nelle diapositive. Le diapositive master e le diapositive layout mantengono le proprie forme, quindi ridimensionali anche loro quando vuoi che l’intera presentazione segua le nuove dimensioni della diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Ottieni le dimensioni originali della diapositiva.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Cambia la dimensione della diapositiva senza scalare le forme esistenti.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Ottieni le nuove dimensioni della diapositiva.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Scala le dimensioni della forma.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Scala la posizione della forma.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Scala le dimensioni della forma.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Scala la posizione della forma.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Scala le dimensioni della forma.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Scala la posizione della forma.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Perché le forme vengono distorte o tagliate dopo aver ridimensionato una diapositiva?**

Quando si ridimensiona una diapositiva, le forme mantengono la loro posizione e dimensione originali a meno che la scala non venga modificata esplicitamente. Questo può provocare il ritaglio del contenuto o il disallineamento delle forme.

**Il codice fornito funziona per tutti i tipi di forma?**

Sì. Impostare altezza e larghezza funziona allo stesso modo per caselle di testo, immagini, grafici e tabelle.

**Come si ridimensionano le tabelle quando si ridimensiona una diapositiva?**

Ridimensiona la forma della tabella stessa, esattamente come qualsiasi altra forma. Le sue righe e colonne si adattano proporzionalmente, quindi non ridimensionarle nuovamente in seguito.

**Questo ridimensionamento funziona per le diapositive master e layout?**

Sì, ma dovresti anche scorrere [Presentation.getMasters](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getMasters) e [Presentation.getLayoutSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getLayoutSlides) applicando la stessa logica di scala alle loro forme per garantire la coerenza nell’intera presentazione.

**Posso cambiare l’orientamento di una diapositiva (ritratto/paesaggio) insieme al ridimensionamento?**

Sì. Puoi utilizzare [SlideSize.setOrientation](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesize/#setOrientation) per cambiare l’orientamento. Assicurati di impostare la logica di scala di conseguenza per preservare il layout.

**Esiste un limite alle dimensioni della diapositiva che posso impostare?**

Aspose.Slides supporta dimensioni personalizzate, ma dimensioni molto grandi possono influire sulle prestazioni o sulla compatibilità con alcune versioni di PowerPoint.

**Come posso evitare che le forme a rapporto d’aspetto fisso diventino distorte?**

Puoi verificare il metodo [getAspectRatioLocked](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) del blocco della forma prima di scalarla. Se è bloccato, regola larghezza o altezza proporzionalmente anziché scalarle singolarmente.