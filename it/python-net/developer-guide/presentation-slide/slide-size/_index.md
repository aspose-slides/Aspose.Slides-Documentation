---
title: Modifica la dimensione della diapositiva nelle presentazioni con Python
linktitle: Dimensione diapositiva
type: docs
weight: 70
url: /it/python-net/slide-size/
keywords:
- "dimensione diapositiva"
- "rapporto d'aspetto"
- "standard"
- "schermo ampio"
- "4:3"
- "16:9"
- "imposta dimensione diapositiva"
- "cambia dimensione diapositiva"
- "dimensione diapositiva personalizzata"
- "dimensione diapositiva speciale"
- "dimensione diapositiva unica"
- "diapositiva a grandezza intera"
- "tipo schermo"
- "non ridimensionare"
- "adatta"
- "massimizza"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- "Python"
- "Aspose.Slides"
descriptions: "Scopri come ridimensionare rapidamente le diapositive nei file PPT, PPTX e ODP con Python e Aspose.Slides, ottimizza le presentazioni per qualsiasi schermo senza perdere qualità."
---
## **Introduzione**

Aspose.Slides fornisce strumenti completi per regolare le dimensioni della diapositiva e il rapporto d'aspetto nelle presentazioni PowerPoint, elementi critici sia per la stampa che per la visualizzazione su schermo. 

Dimensioni e rapporti d'aspetto delle diapositive più comuni:

- **Standard (Rapporto 4:3)**: Ideale per schermi e dispositivi più vecchi.
- **Widescreen (Rapporto 16:9)**: Consigliato per proiettori e display moderni.

Assicurati della coerenza in tutta la presentazione, poiché una singola dimensione e un unico rapporto d'aspetto si applicano a tutte le diapositive. Per risultati ottimali, imposta le dimensioni delle diapositive all'inizio del processo di creazione della presentazione per evitare complicazioni.

{{% alert color="primary" %}} 
Per impostazione predefinita, le presentazioni create con Aspose.Slides utilizzano il rapporto standard 4:3.
{{% /alert %}}

## **Modifica la dimensione della diapositiva in una presentazione**

Questo esempio di codice mostra come modificare la dimensione della diapositiva in una presentazione in Python usando Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Specifica dimensioni personalizzate della diapositiva**

Se trovi che le dimensioni comuni delle diapositive (4:3 e 16:9) non siano adatte al tuo lavoro, potresti decidere di utilizzare una dimensione specifica o unica. Ad esempio, se prevedi di stampare diapositive a grandezza naturale dalla tua presentazione su un layout di pagina personalizzato o se intendi visualizzare la presentazione su determinati tipi di schermo, è probabile che trarrai vantaggio dall'utilizzare un'impostazione di dimensione personalizzata per la tua presentazione. 

Questo esempio di codice mostra come utilizzare Aspose.Slides per Python tramite .NET per specificare una dimensione personalizzata della diapositiva per una presentazione in Python:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # Dimensione carta A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestisci il contenuto della diapositiva dopo il ridimensionamento**

Dopo aver modificato la dimensione della diapositiva di una presentazione, il contenuto delle diapositive (ad esempio immagini o oggetti) può risultare distorto. Per impostazione predefinita, gli oggetti vengono ridimensionati automaticamente per adattarsi alla nuova dimensione della diapositiva. Tuttavia, quando si cambia la dimensione della diapositiva di una presentazione, è possibile specificare un'impostazione che determina come Aspose.Slides gestisce i contenuti sulle diapositive.

A seconda di ciò che intendi fare o raggiungere, puoi utilizzare una di queste impostazioni:

- `DO_NOT_SCALE`

  Se NON vuoi che gli oggetti sulle diapositive vengano ridimensionati, usa questa impostazione.

- `ENSURE_FIT`

  Se desideri ridimensionare a una dimensione diapositive più piccola e hai bisogno che Aspose.Slides riduca gli oggetti delle diapositive per garantirne il completo inserimento (in questo modo eviti la perdita di contenuto), usa questa impostazione. 

- `MAXIMIZE`

  Se desideri ridimensionare a una dimensione diapositive più grande e hai bisogno che Aspose.Slides ingrandisca gli oggetti delle diapositive per renderli proporzionali alla nuova dimensione, usa questa impostazione. 

Questo esempio di codice mostra come utilizzare l'impostazione `MAXIMIZE` quando si cambia la dimensione della diapositiva di una presentazione:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Posso impostare una dimensione della diapositiva personalizzata usando unità diverse da pollici (ad esempio punti o millimetri)?**

Sì. Aspose.Slides utilizza i punti internamente, dove 1 punto equivale a 1/72 di pollice. È possibile convertire qualsiasi unità (come millimetri o centimetri) in punti e utilizzare i valori convertiti per definire la larghezza e l'altezza della diapositiva.

**Una dimensione della diapositiva molto grande influenzerà le prestazioni e l'utilizzo della memoria durante il rendering?**

Sì. Dimensioni maggiori della diapositiva (in punti) combinate con una scala di rendering più alta comportano un aumento del consumo di memoria e tempi di elaborazione più lunghi. Punta a una dimensione della diapositiva pratica e regola la scala di rendering solo se necessario per ottenere la qualità di output desiderata.

**Posso definire una dimensione della diapositiva non standard e poi unire diapositive da presentazioni che hanno dimensioni diverse?**

Non è possibile [unire le presentazioni](/slides/it/python-net/merge-presentation/) quando hanno dimensioni delle diapositive diverse — prima, ridimensiona una presentazione per farla corrispondere all'altra. Quando cambi la dimensione della diapositiva, puoi scegliere come gestire i contenuti esistenti tramite l'opzione [SlideSizeScaleType](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidesizescaletype/). Dopo aver allineato le dimensioni, puoi unire le diapositive preservando la formattazione.

**Posso generare miniature per forme individuali o regioni specifiche di una diapositiva, e rispetteranno la nuova dimensione della diapositiva?**

Sì. Aspose.Slides può generare miniature per [intere diapositive](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/) così come per [forme selezionate](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_image/). Le immagini risultanti riflettono la dimensione e il rapporto d'aspetto attuali della diapositiva, garantendo un inquadramento e una geometria coerenti.