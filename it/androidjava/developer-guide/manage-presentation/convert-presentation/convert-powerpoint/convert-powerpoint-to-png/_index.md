---
title: Converti le diapositive PowerPoint in PNG su Android
linktitle: PowerPoint in PNG
type: docs
weight: 30
url: /it/androidjava/convert-powerpoint-to-png/
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
- Android
- Java
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in immagini PNG ad alta qualità rapidamente con Aspose.Slides per Android tramite Java, garantendo risultati precisi e automatizzati."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in immagini PNG usando Aspose.Slides. Mostra come caricare file di presentazione in formati come PPT, PPTX e ODP, renderizzare le diapositive come immagini e salvare i risultati in formato PNG.

L'articolo dimostra inoltre come personalizzare le immagini PNG generate impostando i valori di scala o specificando la larghezza e l'altezza desiderate.

## **Converti PowerPoint in PNG**

Segui questi passaggi:

1. Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottieni l'oggetto slide dalla collezione [Presentation.getSlides()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#getSlides--) sotto l'interfaccia [ISlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlide).
3. Usa il metodo [ISlide.getImage()](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ISlide) per ottenere la miniatura di ogni diapositiva.
4. Usa il metodo [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) per salvare la miniatura della diapositiva nel formato PNG.

Questo codice Java mostra come convertire una presentazione PowerPoint in PNG:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Converti PowerPoint in PNG con dimensioni personalizzate**

Se desideri ottenere file PNG con una certa scala, puoi impostare i valori di `desiredX` e `desiredY`, che determinano le dimensioni della miniatura risultante.

Questo codice Java dimostra l'operazione descritta:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Converti PowerPoint in PNG con dimensione personalizzata**

Se desideri ottenere file PNG con una certa dimensione, puoi passare i tuoi argomenti preferiti `width` e `height` per `ImageSize`.

Questo codice mostra come convertire un PowerPoint in PNG specificando la dimensione delle immagini:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Come posso esportare solo una forma specifica (ad esempio un grafico o un'immagine) anziché l'intera diapositiva?**

Aspose.Slides supporta la [generazione di miniature per forme individuali](/slides/it/androidjava/create-shape-thumbnails/); è possibile renderizzare una forma in un'immagine PNG.

**La conversione parallela è supportata su un server?**

Sì, ma [non condividere](/slides/it/androidjava/multithreading/) un'unica istanza di presentazione tra thread. Usa un'istanza separata per thread o processo.

**Quali sono le limitazioni della versione di prova durante l'esportazione in PNG?**

La modalità di valutazione aggiunge una filigrana alle immagini di output e applica [altre restrizioni](/slides/it/androidjava/licensing/) finché non viene applicata una licenza.