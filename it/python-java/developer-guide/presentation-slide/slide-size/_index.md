---
title: Modifica la dimensione della diapositiva della presentazione in Python tramite Java
linktitle: Dimensione diapositiva
type: docs
weight: 70
url: /it/python-java/slide-size/
keywords:
- dimensione diapositiva
- rapporto d'aspetto
- standard
- schermo panoramico
- 4:3
- 16:9
- imposta dimensione diapositiva
- cambia dimensione diapositiva
- dimensione diapositiva personalizzata
- dimensione diapositiva speciale
- dimensione diapositiva unica
- diapositiva a grandezza naturale
- tipo di schermo
- non ridimensionare
- garantire adattamento
- massimizzare
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con Python tramite Java e Aspose.Slides, e ottimizzare le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides fornisce strumenti completi per regolare la dimensione della diapositiva e il rapporto d'aspetto nelle presentazioni PowerPoint, fondamentali sia per la stampa sia per la visualizzazione a schermo.

Dimensioni delle diapositive più comuni e rapporti:

- **Standard (Rapporto d'aspetto 4:3)**: Ideale per schermi e dispositivi più vecchi.
- **Widescreen (Rapporto d'aspetto 16:9)**: Consigliato per proiettori e display moderni.

Assicurati coerenza in tutta la presentazione poiché una singola dimensione e un unico rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni delle diapositive all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="info" title="Note" %}}
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto d'aspetto standard 4:3.
{{% /alert %}}

## **Modifica la dimensione della diapositiva nelle presentazioni**

Questo esempio di codice mostra come modificare la dimensione della diapositiva in una presentazione in Python tramite Java usando Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Specifica dimensioni personalizzate delle diapositive nelle presentazioni**

Se trovi le dimensioni comuni delle diapositive (4:3 e 16:9) inadeguate per il tuo lavoro, potresti decidere di utilizzare una dimensione specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza naturale dalla tua presentazione su un layout di pagina personalizzato o se intendi visualizzare la presentazione su determinati tipi di schermo, probabilmente trarrai vantaggio dall'utilizzare un'impostazione di dimensione personalizzata per la tua presentazione.

Questo esempio di codice mostra come usare Aspose.Slides per Python tramite Java per specificare una dimensione personalizzata della diapositiva per una presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gestisci il contenuto della diapositiva dopo il ridimensionamento**

Dopo aver modificato la dimensione della diapositiva per una presentazione, i contenuti delle diapositive (ad esempio immagini o oggetti) possono risultare distorti. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, modificando la dimensione della diapositiva di una presentazione, è possibile specificare un'impostazione che determina come Aspose.Slides gestisce i contenuti sulle diapositive.

A seconda di ciò che intendi fare o raggiungere, puoi utilizzare una qualsiasi di queste impostazioni:

- [DoNotScale](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesizescaletype/#DoNotScale)
  
  Se NON desideri che gli oggetti sulle diapositive vengano ridimensionati, utilizza questa impostazione.

- [EnsureFit](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesizescaletype/#EnsureFit)
  
  Se desideri ridimensionare a una dimensione di diapositiva più piccola e hai bisogno che Aspose.Slides riduca gli oggetti delle diapositive per assicurarsi che tutti siano contenuti nelle diapositive (in questo modo eviti la perdita di contenuti), utilizza questa impostazione.

- [Maximize](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesizescaletype/#Maximize)
  
  Se desideri ridimensionare a una dimensione di diapositiva più grande e hai bisogno che Aspose.Slides ingrandisca gli oggetti delle diapositive per renderli proporzionali alla nuova dimensione, utilizza questa impostazione.

Questo esempio di codice mostra come utilizzare l'impostazione [Maximize](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesizescaletype/#Maximize) quando si modifica la dimensione della diapositiva di una presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso impostare una dimensione personalizzata della diapositiva usando unità diverse da pollici (ad esempio, punti o millimetri)?**

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto corrisponde a 1/72 di pollice. È possibile convertire qualsiasi unità (come millimetri o centimetri) in punti e utilizzare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

**Una dimensione personalizzata della diapositiva molto grande influirà sulle prestazioni e sull'utilizzo della memoria durante il rendering?**

Sì. Dimensioni della diapositiva più grandi (in punti) combinate con una scala di rendering più elevata aumentano il consumo di memoria e i tempi di elaborazione. Mira a una dimensione di diapositiva pratica e regola la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.

**Posso definire una dimensione della diapositiva non standard e poi unire diapositive da presentazioni che hanno dimensioni diverse?**

Non è possibile [merge presentations](/slides/it/python-java/merge-presentation/) quando hanno dimensioni della diapositiva diverse — prima ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive preservando la formattazione.

**Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispetteranno la nuova dimensione della diapositiva?**

Sì. Aspose.Slides può generare miniature per [entire slides](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) così come per [selected shapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getImage). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto attuali della diapositiva, garantendo inquadrature e geometrie coerenti.