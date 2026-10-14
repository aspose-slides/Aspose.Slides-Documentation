---
title: Converti le diapositive PowerPoint in PNG con Python
linktitle: PowerPoint in PNG
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
description: "Converti le presentazioni PowerPoint e OpenDocument in immagini PNG di alta qualità rapidamente con Aspose.Slides per Python tramite .NET, garantendo risultati precisi e automatici."
---
## **Panoramica**

Questo articolo spiega come convertire le diapositive di una presentazione in immagini PNG utilizzando Aspose.Slides per Python tramite .NET. È possibile caricare presentazioni in formati come PPT, PPTX e ODP, renderizzare ogni diapositiva e salvarla come immagine PNG separata.

Gli esempi seguenti mostrano il rendering alla scala predefinita, l'aumento della scala, la specifica delle dimensioni di output in pixel e la scelta di uno stile di rendering a gradiente.

## **Converti PowerPoint in PNG**

Carica una presentazione con la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e accedi alle sue diapositive tramite la collezione [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/). L'esempio renderizza ogni diapositiva con [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) senza parametri per creare una miniatura. Quindi chiama [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) con [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) per salvare ogni diapositiva renderizzata come immagine PNG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
La sovraccarico di [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) senza parametri esegue il rendering a una scala di 0,2. Per esempio, una diapositiva di 720 × 540 punti produce una miniatura di 144 × 108 pixel. Per controllare le dimensioni di output, utilizza le sovraccariche con fattori di scala o una dimensione immagine esplicita mostrata di seguito.
{{% /alert %}}

## **Converti PowerPoint in PNG con Dimensioni Personalizzate**

Passa fattori di scala orizzontali e verticali a [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) per controllare le dimensioni renderizzate. In questo esempio, entrambi i fattori sono 2, quindi una diapositiva di 720 × 540 punti produce un'immagine di 1440 × 1080 pixel. Fattori di scala uguali preservano il rapporto d'aspetto della diapositiva. Ogni immagine viene salvata in formato PNG con [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/).

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Converti PowerPoint in PNG con Dimensioni Personalizzate**

Per specificare le dimensioni di output in pixel, passa una dimensione a [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) invece dei fattori di scala. Questo esempio renderizza ogni diapositiva a 960 × 720 pixel e salva il risultato con [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Scegli dimensioni che corrispondono al rapporto d'aspetto della diapositiva per evitare lo stiramento dell'immagine.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Scegli uno Stile di Rendering a Gradiente**

Supponiamo che una diapositiva contenga riempimenti a gradiente, ma le transizioni nel PNG esportato appaiano più chiare o comunque diverse da quelle visualizzate in PowerPoint. È possibile utilizzare la proprietà [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) di [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) per scegliere come vengono renderizzati i gradienti.

Scarica [gradient-styles.pptx](gradient-styles.pptx) e posizionalo nella directory di lavoro dell'applicazione. La sua prima diapositiva contiene due gradienti lineari: ciano verso arancione in alto e blu verso giallo in basso. Ogni gradiente ha due fermate, allo 0% e al 100%.

Il seguente esempio carica questa presentazione e renderizza la stessa prima diapositiva in entrambe le modalità con [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

Le immagini seguenti mostrano l'output della stessa diapositiva, con entrambi i gradienti in ciascuna immagine:

| Default | PowerPointUI |
| --- | --- |
| ![Gradienti da ciano a arancione e da blu a giallo renderizzati con Default](gradient-Default.png) | ![Gli stessi gradienti renderizzati con PowerPointUI](gradient-PowerPointUI.png) |

In questo esempio, `DEFAULT` produce colori intermedi più chiari, mentre `POWER_POINT_UI` produce colori intermedi più scuri. La differenza dipende dai colori e dalle fermate del gradiente.

Scegli `DEFAULT` quando l'output standard di Aspose.Slides soddisfa le tue esigenze. Prova `POWER_POINT_UI` quando la tua priorità è corrispondere all'aspetto in PowerPoint. Confronta entrambi gli output con il risultato desiderato; nessuna modalità è universalmente preferibile.

## **FAQ**

**Come posso esportare una forma specifica, come un grafico o un'immagine, invece dell'intera diapositiva?**

Aspose.Slides supporta la [generazione di miniature per forme individuali](/slides/it/python-net/create-shape-thumbnails/), consentendo di renderizzare una forma come immagine PNG.

**La conversione parallela è supportata su un server?**

Sì. Utilizza un'istanza di presentazione separata per ogni thread o processo; [non condividere un'unica istanza tra i thread](/slides/it/python-net/multithreading/).

**Quali sono le limitazioni della modalità di valutazione quando si esporta in PNG?**

La modalità di valutazione aggiunge una filigrana alle immagini di output e applica [altre restrizioni](/slides/it/python-net/licensing/) fino a quando non viene applicata una licenza.