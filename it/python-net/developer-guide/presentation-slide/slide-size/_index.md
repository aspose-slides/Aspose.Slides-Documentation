---
title: Modifica la dimensione della diapositiva nelle presentazioni con Python
linktitle: Dimensione diapositiva
type: docs
weight: 70
url: /it/python-net/slide-size/
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
- diapositiva a grandezza piena
- tipo di schermo
- non scalare
- garantisci adattamento
- massimizza
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con Python e Aspose.Slides, ottimizza le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides offre strumenti completi per regolare la dimensione della diapositiva e il rapporto d'aspetto nelle presentazioni PowerPoint, elementi critici sia per la stampa sia per la visualizzazione su schermo. 

Dimensioni e rapporti d'aspetto più comuni:

- **Standard (rapporto d'aspetto 4:3)**: Ideale per schermi e dispositivi più vecchi.
- **Widescreen (rapporto d'aspetto 16:9)**: Consigliato per proiettori e display moderni.

Assicurati la coerenza in tutta la presentazione, poiché una singola dimensione e un singolo rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni delle diapositive all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="info" title="Note" %}}
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto d'aspetto standard 4:3.
{{% /alert %}}

Le note e le pagine di stampa hanno dimensioni separate rispetto alle diapositive regolari. Vedi [Notes Page Size](/slides/it/python-net/notes-size/) per modificare la loro dimensione e orientamento.

## **Cambia la dimensione della diapositiva in una presentazione**

Questo esempio di codice mostra come cambiare la dimensione della diapositiva in una presentazione in Python usando Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Specifica dimensioni personalizzate per le diapositive**

Se le dimensioni comuni delle diapositive (4:3 e 16:9) non sono adatte al tuo lavoro, potresti decidere di utilizzare una dimensione specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza naturale da una presentazione su un layout di pagina personalizzato o se intendi visualizzare la presentazione su determinati tipi di schermo, è probabile che tu tragga vantaggio dall'utilizzare un'impostazione di dimensione personalizzata per la presentazione. 

Questo esempio di codice mostra come utilizzare Aspose.Slides per Python via .NET per specificare una dimensione personalizzata della diapositiva per una presentazione in Python:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # formato carta A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestisci il contenuto della diapositiva dopo il ridimensionamento**

Dopo aver modificato la dimensione della diapositiva di una presentazione, il contenuto delle diapositive (immagini o oggetti, per esempio) può risultare distorto. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, quando si cambia la dimensione della diapositiva di una presentazione, è possibile specificare un'impostazione che determina come Aspose.Slides gestisce il contenuto delle diapositive.

A seconda di ciò che intendi fare o ottenere, puoi utilizzare una di queste impostazioni:

- `DO_NOT_SCALE`

  Se NON vuoi che gli oggetti sulle diapositive vengano ridimensionati, utilizza questa impostazione.

- `ENSURE_FIT`

  Se desideri ridimensionare a una diapositiva più piccola e necessiti che Aspose.Slides riduca gli oggetti delle diapositive per garantire che tutti siano contenuti (in questo modo eviti la perdita di contenuto), utilizza questa impostazione. 

- `MAXIMIZE`

  Se desideri ridimensionare a una diapositiva più grande e necessiti che Aspose.Slides ingrandisca gli oggetti delle diapositive per renderli proporzionali alla nuova dimensione, utilizza questa impostazione. 

Questo esempio di codice mostra come utilizzare l'impostazione `MAXIMIZE` quando si cambia la dimensione della diapositiva di una presentazione:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Posso impostare una dimensione personalizzata della diapositiva usando unità diverse dai pollici (ad esempio punti o millimetri)?**

Sì. Aspose.Slides utilizza internamente i punti, dove 1 punto è pari a 1/72 di pollice. Puoi convertire qualsiasi unità (come millimetri o centimetri) in punti e utilizzare i valori convertiti per definire larghezza e altezza della diapositiva.

**Una dimensione personalizzata della diapositiva molto grande influisce sulle prestazioni e sull'uso della memoria durante il rendering?**

Sì. Dimensioni della diapositiva più grandi (in punti) combinate con una scala di rendering più alta aumentano il consumo di memoria e i tempi di elaborazione. Punta a una dimensione pratica della diapositiva e regola la scala di rendering solo quando necessario per ottenere la qualità di output desiderata.

**Posso definire una dimensione non standard della diapositiva e poi unire diapositive da presentazioni con dimensioni diverse?**

Non è possibile [unire presentazioni](/slides/it/python-net/merge-presentation/) mentre hanno dimensioni della diapositiva differenti — prima, ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire il contenuto esistente tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive preservando la formattazione.

**Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e queste rispetteranno la nuova dimensione della diapositiva?**

Sì. Aspose.Slides può rendere miniature per [diapositive intere](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/) nonché per [forme selezionate](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_image/). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto attuali della diapositiva, assicurando un'inquadratura e una geometria coerenti.