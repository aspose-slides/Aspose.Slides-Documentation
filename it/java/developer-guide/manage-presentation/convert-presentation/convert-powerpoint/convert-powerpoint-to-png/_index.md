---
title: Converti diapositive PowerPoint in PNG in Java
linktitle: PowerPoint in PNG
type: docs
weight: 30
url: /it/java/convert-powerpoint-to-png/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in PNG
- presentazione in PNG
- diapositiva in PNG
- PPT in PNG
- PPTX in PNG
- salva PPT come PNG
- salva PPTX come PNG
- esporta PPT in PNG
- esporta PPTX in PNG
- Java
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in immagini PNG di alta qualità rapidamente con Aspose.Slides per Java, garantendo risultati precisi e automatizzati."
---
## **Panoramica**

Questo articolo spiega come convertire le diapositive di presentazione in immagini PNG utilizzando Aspose.Slides per Java. È possibile caricare presentazioni in formati come PPT, PPTX e ODP, renderizzare ogni diapositiva e salvarla come immagine PNG separata.

Gli esempi di seguito mostrano il rendering alla scala predefinita, l'aumento della scala, la specifica delle dimensioni di output in pixel e la scelta di uno stile di rendering a gradiente.

## **Convertire PowerPoint in PNG**

Carica una presentazione con la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) e accedi alle sue diapositive tramite la raccolta [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--). L'esempio rende ogni diapositiva con [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) senza parametri per creare una miniatura. Quindi chiama [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) con [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) per salvare ogni diapositiva renderizzata come immagine PNG.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
L'overload di [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) senza parametri rende a una scala di 0.2. Per esempio, una diapositiva di 720 × 540 punti produce una miniatura di 144 × 108 pixel. Per controllare le dimensioni di output, usa gli overload con fattori di scala o una dimensione dell'immagine esplicita mostrata di seguito.
{{% /alert %}}

## **Convertire PowerPoint in PNG con Dimensioni Personalizzate**

Passa fattori di scala orizzontale e verticale a [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) per controllare le dimensioni renderizzate. In questo esempio, entrambi i fattori sono 2, quindi una diapositiva di 720 × 540 punti produce un'immagine di 1440 × 1080 pixel. Fattori di scala uguali preservano il rapporto d'aspetto della diapositiva. Ogni immagine viene salvata in formato PNG con [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Convertire PowerPoint in PNG con Dimensione Personalizzata**

Per specificare le dimensioni di output in pixel, passa una dimensione a [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) anziché ai fattori di scala. Questo esempio rende ogni diapositiva a 960 × 720 pixel e salva il risultato con [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Scegli dimensioni che corrispondono al rapporto d'aspetto della diapositiva per evitare lo stiramento dell'immagine.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Scegliere uno Stile di Rendering a Gradiente**

Supponiamo che una diapositiva contenga riempimenti a gradiente, ma le transizioni nel PNG esportato appaiano più chiare o altrimenti diverse da quelle visualizzate in PowerPoint. È possibile utilizzare il metodo [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) ereditato da [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) per scegliere come vengono renderizzati i gradienti.

Scarica [gradient-styles.pptx](gradient-styles.pptx) e posizionalo nella directory di lavoro dell'applicazione. La sua prima diapositiva contiene due gradienti lineari: ciano a arancione in alto e blu a giallo in basso. Ogni gradiente ha due fermate, allo 0% e al 100%.

L'esempio seguente carica questa presentazione e renderizza la stessa prima diapositiva in entrambi i modi con [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Le immagini sottostanti mostrano l'output della stessa diapositiva, con entrambi i gradienti in ogni immagine:

| Predefinito | PowerPointUI |
| --- | --- |
| ![Gradienti dal ciano all'arancione e dal blu al giallo renderizzati con Predefinito](gradient-Default.png) | ![Gli stessi gradienti renderizzati con PowerPointUI](gradient-PowerPointUI.png) |

In questo esempio, `Predefinito` produce colori intermedi più chiari, mentre `PowerPointUI` produce colori intermedi più scuri. La differenza dipende dai colori e dalle fermate nel gradiente.

Scegli `Predefinito` quando l'output standard di Aspose.Slides soddisfa le tue esigenze. Prova `PowerPointUI` quando la tua priorità è corrispondere all'aspetto in PowerPoint. Confronta entrambi gli output con il risultato desiderato; nessuna modalità è universalmente preferibile.

## **FAQ**

**Come posso esportare una forma specifica, ad esempio un grafico o un'immagine, invece dell'intera diapositiva?**

Aspose.Slides supporta [la generazione di miniature per forme individuali](/slides/it/java/create-shape-thumbnails/), consentendo di renderizzare una forma come immagine PNG.

**La conversione parallela è supportata su un server?**

Sì. Utilizza un'istanza di presentazione separata per ogni thread o processo; [non condividere una singola istanza tra thread](/slides/it/java/multithreading/).

**Quali sono le limitazioni della valutazione quando si esporta in PNG?**

La modalità di valutazione aggiunge una filigrana alle immagini di output e applica [altre restrizioni](/slides/it/java/licensing/) fino a quando non viene applicata una licenza.