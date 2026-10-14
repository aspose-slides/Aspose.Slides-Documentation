---
title: Converti le diapositive PowerPoint in PNG con Python
linktitle: PowerPoint in PNG
type: docs
weight: 30
url: /it/python-java/convert-powerpoint-to-png/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- PowerPoint in PNG
- presentazione in PNG
- diapositiva in PNG
- PPT in PNG
- PPTX in PNG
- salvare PPT come PNG
- salvare PPTX come PNG
- esportare PPT in PNG
- esportare PPTX in PNG
- Python
- Java
- Aspose.Slides
description: "Converti le diapositive PowerPoint in immagini PNG con Python tramite Java. Esporta presentazioni PPT, PPTX e ODP con scale personalizzate o dimensioni dell'immagine precise."
---
## **Panoramica**

Questo articolo spiega come convertire le diapositive di una presentazione in immagini PNG utilizzando Aspose.Slides per Python tramite Java. È possibile caricare presentazioni in formati come PPT, PPTX e ODP, renderizzare ogni diapositiva e salvarla come immagine PNG separata.

Gli esempi seguenti mostrano il rendering alla scala predefinita, l'aumento della scala, la specifica delle dimensioni di output in pixel e la scelta di uno stile di rendering con gradiente.

## **Converti PowerPoint in PNG**

Carica una presentazione con la classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) e accedi alle sue diapositive tramite la collezione [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides). L'esempio rende ogni diapositiva con [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) senza parametri per creare una miniatura. Quindi chiama [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) con [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) per salvare ogni diapositiva renderizzata come immagine PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
La sovraccarico senza parametri di [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) rende a una scala di 0.2. Ad esempio, una diapositiva di 720 × 540 punti produce una miniatura di 144 × 108 pixel. Per controllare le dimensioni di output, usa le sovraccarichi con fattori di scala o una dimensione dell'immagine esplicita mostrata di seguito.
{{% /alert %}}

## **Converti PowerPoint in PNG con dimensioni personalizzate**

Passa i fattori di scala orizzontali e verticali a [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) per controllare le dimensioni renderizzate. In questo esempio, entrambi i fattori sono 2, quindi una diapositiva di 720 × 540 punti produce un'immagine di 1440 × 1080 pixel. Fattori di scala uguali preservano il rapporto d'aspetto della diapositiva. Ogni immagine renderizzata viene salvata in formato PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Converti PowerPoint in PNG con dimensioni personalizzate**

Per specificare le dimensioni di output in pixel, passa una dimensione a [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) invece dei fattori di scala. Questo esempio rende ogni diapositiva a 960 × 720 pixel e salva il risultato in formato PNG. Scegli dimensioni che corrispondono al rapporto d'aspetto della diapositiva per evitare lo stiramento dell'immagine.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Scegli uno stile di rendering con gradiente**

Supponiamo che una diapositiva contenga riempimenti a gradiente, ma le transizioni nel PNG esportato appaiano più chiare o altrimenti diverse da quelle che vedi in PowerPoint. È possibile utilizzare il metodo [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) ereditato da [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) per scegliere come renderizzare i gradienti.

Scarica [gradient-styles.pptx](gradient-styles.pptx) e posizionalo nella directory di lavoro dell'applicazione. La sua prima diapositiva contiene due gradienti lineari: dal ciano all'arancione nella parte superiore e dal blu al giallo nella parte inferiore. Ogni gradiente ha due stop, allo 0% e al 100%.

L'esempio seguente carica questa presentazione e renderizza la prima diapositiva in entrambi i modi con [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

Le immagini di seguito mostrano l'output della stessa diapositiva, con entrambi i gradienti in ogni immagine:

| Default | PowerPointUI |
| --- | --- |
| ![Gradienti dal ciano all'arancione e dal blu al giallo renderizzati con Default](gradient-Default.png) | ![Gli stessi gradienti renderizzati con PowerPointUI](gradient-PowerPointUI.png) |

In questo esempio, `Default` produce colori intermedi più chiari, mentre `PowerPointUI` produce colori intermedi più scuri. La differenza dipende dai colori e dagli stop nel gradiente.

Scegli `Default` quando l'output standard di Aspose.Slides soddisfa le tue esigenze. Prova `PowerPointUI` quando la tua priorità è corrispondere all'aspetto in PowerPoint. Confronta entrambi gli output con il risultato desiderato; nessuna modalità è universalmente preferibile.

## **FAQ**

**Come posso esportare una forma specifica, come un grafico o un'immagine, invece dell'intera diapositiva?**

Aspose.Slides supporta la [generazione di miniature per forme individuali](/slides/it/python-java/create-shape-thumbnails/), consentendo di renderizzare una forma come immagine PNG.

**La conversione parallela è supportata su un server?**

Sì. Usa un'istanza di presentazione separata per ogni thread o processo; [non condividere un'unica istanza tra i thread](/slides/it/python-java/multithreading/).

**Quali sono le limitazioni della valutazione quando si esporta in PNG?**

La modalità di valutazione aggiunge una filigrana alle immagini di output e applica [altre restrizioni](/slides/it/python-java/licensing/) fino a quando non viene applicata una licenza.