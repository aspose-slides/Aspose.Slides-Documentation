---
title: Convertire diapositive PowerPoint in PNG in .NET
linktitle: PowerPoint in PNG
type: docs
weight: 30
url: /it/net/convert-powerpoint-to-png/
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
- .NET
- C#
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in immagini PNG di alta qualità rapidamente con Aspose.Slides per .NET, garantendo risultati precisi e automatizzati."
---
## **Panoramica**

Questo articolo spiega come convertire le diapositive di una presentazione in immagini PNG usando Aspose.Slides per .NET. È possibile caricare presentazioni in formati come PPT, PPTX e ODP, renderizzare ogni diapositiva e salvarla come immagine PNG separata.

Gli esempi seguenti illustrano il rendering di miniature, l'impostazione dei fattori di scala, la specifica delle dimensioni di output in pixel e la scelta di uno stile di rendering dei gradienti.

## **Converti PowerPoint in PNG**

Carica una presentazione con la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) e accedi alle sue diapositive tramite la collezione [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). L'esempio renderizza ogni diapositiva con [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) senza parametri per creare una miniatura. Quindi chiama [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) con [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) per salvare ogni diapositiva renderizzata come immagine PNG.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
La sovraccarico senza parametri di [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) rende a una scala di 0,2. Per esempio, una diapositiva di 720 × 540 punti produce una miniatura di 144 × 108 pixel. Per controllare le dimensioni di output, utilizza le sovraccariche con fattori di scala o una dimensione di immagine esplicita mostrata di seguito.
{{% /alert %}}

## **Converti PowerPoint in PNG con Dimensioni Personalizzate**

Passa i fattori di scala orizzontale e verticale a [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) per controllare le dimensioni renderizzate. In questo esempio, entrambi i fattori sono 2, quindi una diapositiva di 720 × 540 punti produce un'immagine di 1440 × 1080 pixel. Fattori di scala uguali preservano il rapporto d'aspetto della diapositiva. Ogni immagine viene salvata in formato PNG con [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Converti PowerPoint in PNG con Dimensione Personalizzata**

Per specificare le dimensioni di output in pixel, passa una dimensione a [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) invece dei fattori di scala. Questo esempio renderizza ogni diapositiva a 960 × 720 pixel e salva il risultato con [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Scegli dimensioni che corrispondono al rapporto d'aspetto della diapositiva per evitare lo stiramento dell'immagine.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Scegli uno Stile di Rendering del Gradiente**

Supponiamo che una diapositiva contenga riempimenti a gradiente, ma le transizioni nel PNG esportato appaiano più chiare o comunque diverse da quelle visualizzate in PowerPoint. È possibile utilizzare la proprietà [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) di [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) per scegliere come renderizzare i gradienti.

Scarica [gradient-styles.pptx](gradient-styles.pptx) e posizionalo nella directory di lavoro dell'applicazione. La sua prima diapositiva contiene due gradienti lineari: ciano verso arancione in alto e blu verso giallo in basso. Ogni gradiente ha due fermate, al 0% e al 100%.

Il seguente esempio carica questa presentazione e renderizza la stessa prima diapositiva in entrambi i modi con [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

Le immagini di seguito mostrano l'output della stessa diapositiva, con entrambi i gradienti in ogni immagine:

| Default | PowerPointUI |
| --- | --- |
| ![Gradienti da ciano a arancione e da blu a giallo renderizzati con Default](gradient-Default.png) | ![Gli stessi gradienti renderizzati con PowerPointUI](gradient-PowerPointUI.png) |

In questo esempio, `Default` produce colori intermedi più chiari, mentre `PowerPointUI` produce colori intermedi più scuri. La differenza dipende dai colori e dalle fermate nel gradiente.

Scegli `Default` quando l'output standard di Aspose.Slides soddisfa le tue esigenze. Prova `PowerPointUI` quando la tua priorità è far corrispondere l'aspetto in PowerPoint. Confronta entrambi gli output con il risultato desiderato; nessuna modalità è universalmente preferibile.

## **FAQ**

**Come posso esportare una forma specifica, come un grafico o un'immagine, invece dell'intera diapositiva?**

Aspose.Slides supporta la [generazione di miniature per forme individuali](/slides/it/net/create-shape-thumbnails/), consentendo di renderizzare una forma come immagine PNG.

**La conversione parallela è supportata su un server?**

Sì. Usa un'istanza di presentazione separata per ogni thread o processo; [non condividere una singola istanza tra thread](/slides/it/net/multithreading/).

**Quali sono le limitazioni della versione di valutazione quando si esporta in PNG?**

La modalità di valutazione aggiunge una filigrana alle immagini di output e applica [altre restrizioni](/slides/it/net/licensing/) finché non viene applicata una licenza.