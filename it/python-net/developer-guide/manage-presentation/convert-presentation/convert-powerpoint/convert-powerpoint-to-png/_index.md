---
title: Converti le diapositive PowerPoint in PNG con Python
linktitle: Diapositiva a PNG
type: docs
weight: 30
url: /it/python-net/convert-powerpoint-to-png/
keywords:
- converti PowerPoint in PNG
- converti presentazione in PNG
- converti diapositiva in PNG
- converti PPT in PNG
- converti PPTX in PNG
- converti ODP in PNG
- PowerPoint in PNG
- presentazione in PNG
- diapositiva in PNG
- PPT in PNG
- PPTX in PNG
- ODP in PNG
- Python
- Aspose.Slides
description: "Converti le presentazioni PowerPoint e OpenDocument in immagini PNG di alta qualità rapidamente con Aspose.Slides per Python via .NET, garantendo risultati precisi e automatizzati."
---
## **Panoramica**

Aspose.Slides per Python via .NET rende semplice la conversione delle presentazioni PowerPoint in PNG. Carichi una presentazione, iteri le sue diapositive, rendi ciascuna in un’immagine raster e salvi il risultato come file PNG. È ideale per generare anteprime delle diapositive, incorporare diapositive in pagine web o produrre risorse statiche per elaborazioni successive.

## **Convertire diapositive in PNG**

Questa sezione mostra l’esempio più semplice possibile di conversione di una presentazione PowerPoint in immagini PNG usando Aspose.Slides per Python via .NET.

Segui questi passaggi:

1. Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni una diapositiva dalla collezione `Presentation.slides` (vedi la classe [Slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/)).
1. Usa il metodo `Slide.get_image` per generare una miniatura della diapositiva.
1. Usa il metodo `Presentation.save` per salvare la miniatura della diapositiva in formato PNG.

Questo codice Python mostra come convertire una presentazione PowerPoint in PNG:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Convertire diapositive in PNG con dimensioni personalizzate**

Per esportare le diapositive in PNG a una scala personalizzata, chiama `Slide.get_image` con i fattori di scala orizzontale e verticale. questi moltiplicatori ridimensionano l’output rispetto alle dimensioni originali della diapositiva — ad esempio, `2.0` raddoppia sia la larghezza sia l’altezza. Usa valori uguali per `scale_x` e `scale_y` per mantenere il rapporto d’aspetto.

Questo codice Python dimostra l’operazione descritta:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Convertire diapositive in PNG con dimensione specifica**

Se desideri generare file PNG con una dimensione specifica, passa i valori desiderati per `width` e `height`. Il codice di seguito mostra come convertire un PowerPoint in PNG specificando la dimensione dell’immagine:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}
Potresti provare i convertitori gratuiti di Aspose **PowerPoint-to-PNG** — [PPTX to PNG](https://products.aspose.app/slides/it/conversion/pptx-to-png) e [PPT to PNG](https://products.aspose.app/slides/it/conversion/ppt-to-png). Offrono un’implementazione live del processo descritto in questa pagina.
{{% /alert %}}

## **FAQ**

**Come posso esportare solo una forma specifica (ad es. un grafico o un’immagine) invece dell’intera diapositiva?**

Aspose.Slides supporta [la generazione di miniature per forme individuali](/slides/it/python-net/create-shape-thumbnails/); è possibile renderizzare una forma in un’immagine PNG.

**La conversione in parallelo è supportata su un server?**

Sì, ma [non condividere](/slides/it/python-net/multithreading/) un’unica istanza di presentazione tra thread. Usa un’istanza separata per ogni thread o processo.

**Quali sono le limitazioni della versione di prova durante l’esportazione in PNG?**

La modalità di valutazione aggiunge una filigrana alle immagini di output e applica [altre restrizioni](/slides/it/python-net/licensing/) fino a quando non viene applicata una licenza.