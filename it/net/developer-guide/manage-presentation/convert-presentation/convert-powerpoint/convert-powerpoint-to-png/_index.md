---
title: Converti le diapositive PowerPoint in PNG in .NET
linktitle: PowerPoint in PNG
type: docs
weight: 30
url: /it/net/convert-powerpoint-to-png/
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
- .NET
- C#
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in immagini PNG di alta qualità rapidamente con Aspose.Slides per .NET, garantendo risultati precisi e automatizzati."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in immagini PNG utilizzando Aspose.Slides. Mostra come caricare file di presentazione in formati come PPT, PPTX e ODP, renderizzare le diapositive come immagini e salvare i risultati nel formato PNG.

L'articolo dimostra anche come personalizzare le immagini PNG generate impostando valori di scala o specificando la larghezza e l'altezza desiderate.

## **Converti PowerPoint in PNG**

Segui questi passaggi:

1. Istanzia la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Ottieni l'oggetto diapositiva dalla collezione [Presentation.Slides](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/properties/slides) tramite l'interfaccia [ISlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide).
3. Usa il metodo [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/it/net/aspose.slides/islide/getimage/) per renderizzare ogni diapositiva alla scala necessaria.
4. Usa il metodo [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/it/net/aspose.slides.ipresentation/save/methods/5) per salvare la miniatura della diapositiva nel formato PNG.

Questo codice C# mostra come convertire una presentazione PowerPoint in PNG. L'oggetto Presentation può caricare PPT, PPTX, ODP ecc., quindi ogni diapositiva nell'oggetto Presentation viene convertita nel formato PNG o in altri formati immagine.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**Nota:** Gli argomenti di scala `1f, 1f` renderizzano ogni diapositiva alla sua dimensione completa, quindi una diapositiva di 720×540 pt produce un'immagine di 720×540 px. La sovraccarico senza parametri [GetImage()](https://reference.aspose.com/slides/it/net/aspose.slides/islide/getimage/) restituisce invece una miniatura di anteprima molto più piccola. 
{{% /alert %}} 

## **Converti PowerPoint in PNG con Dimensioni Personalizzate**

Se desideri ottenere file PNG con una certa scala, puoi impostare i valori per `desiredX` e `desiredY`, che determinano le dimensioni della miniatura risultante. 

Questo codice in C# dimostra l'operazione descritta:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Converti PowerPoint in PNG con Dimensione Personalizzata**

Se desideri ottenere file PNG con una certa dimensione, puoi passare i tuoi argomenti `width` e `height` preferiti per `imageSize`. 

Questo codice mostra come convertire un PowerPoint in PNG specificando la dimensione per le immagini: 

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **FAQ**

### Come posso esportare solo una forma specifica (ad esempio, un grafico o un'immagine) invece dell'intera diapositiva?

Aspose.Slides supporta la [generazione di miniature per forme individuali](/slides/it/net/create-shape-thumbnails/); è possibile renderizzare una forma in un'immagine PNG.

### La conversione parallela è supportata su un server?

Sì, ma [non condividere](/slides/it/net/multithreading/) una singola istanza di presentation tra thread. Usa un'istanza separata per thread o per processo.

### Quali sono le limitazioni della versione di prova quando si esporta in PNG?

La modalità di valutazione aggiunge una filigrana alle immagini di output e impone [altre restrizioni](/slides/it/net/licensing/) fino a quando non viene applicata una licenza.